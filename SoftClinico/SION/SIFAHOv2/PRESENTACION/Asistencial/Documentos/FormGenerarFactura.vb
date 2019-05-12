Imports System.Threading

Public Class FormGenerarFactura
    Private objFactura As Object ''luego debo colocar esto Object
    Private objLista As ListaCheck
    Dim perG As New Buscar_Permisos_generales
    Dim permisoGeneral As String
    Dim pEditar As String
    Dim pAnular As String
    Dim pNuevo As String
    Dim pBuscar As String
    Dim pImprimir As String
    Dim pExonerar As String
    Dim pReporte As String
    Dim usuarioActual As String
    Dim moduloTemporal As String
    Dim codigoTemporal As String
    Dim valorLetraTemporal As String
    Dim fechaTemporal As String
    Dim tipoFacturaTemporal As Integer
    Dim idEmpresaTemporal As Integer
    Dim nRegistroTemporal As String
    Dim nombrePDF As String
    Dim nombreCertificadoPDF As String
    Dim cargando As Boolean

    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btOpcionReporte_Click(sender As Object, e As EventArgs) Handles btOpcionReporte.Click
        If SesionActual.tienePermiso(pReporte) Then
            General.cargarForm(FormInformeRadicacion)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub Form__FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If btguardar.Enabled = True Then
            e.Cancel = True
            MsgBox(Mensajes.CAMBIOS_SIN_GUARDAR, MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub btBuscarContrato_Click(sender As Object, e As EventArgs) Handles btBuscarContrato.Click
        Try
            Select Case objFactura.tipo
                Case ConstantesAsis.TIPO_FACTURA_REMISION
                    buscaCliente()
                Case Else
                    buscaContrato()
            End Select
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub buscaContrato()
        Dim params As New List(Of String)
        params.Add(Nothing)
        params.Add(SesionActual.codigoEP)
        If objFactura.tipo = ConstantesAsis.TIPO_FACTURA_ASISTENCIAL OrElse objFactura.tipo = ConstantesAsis.TIPO_FACTURA_ASISTENCIAL_CTC Then
            params.Add(1)
        End If

        General.buscarElemento(objFactura.sqlBuscarContrato,
                           params,
                           AddressOf cargarContrato,
                           TitulosForm.BUSQUEDA_CLIENTES,
                           False, Constantes.TAMANO_MEDIANO, True)
    End Sub
    Private Sub buscaCliente()
        Dim params As New List(Of String)
        params.Add(Nothing)
        params.Add(SesionActual.codigoEP)
        General.buscarElemento(objFactura.sqlBuscarContrato,
                           params,
                           AddressOf cargarCliente,
                           TitulosForm.BUSQUEDA_CLIENTES,
                           False, Constantes.TAMANO_MEDIANO, True)
    End Sub

    Public Sub cargarContrato(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        Dim dt As New DataTable
        General.llenarTabla(objFactura.sqlCargarContrato, params, dt)
        If dt.Rows.Count > 0 Then
            textcodcontrato.Text = dt.Rows(0).Item("Contrato")
            objFactura.CodigoContrato = dt.Rows(0).Item("Contrato")
            textcodcliente.Text = dt.Rows(0).Item("NIT").ToString
            textdv.Text = dt.Rows(0).Item("DV")
            textcliente.Text = dt.Rows(0).Item("Cliente")
            If Not dt.Columns.Contains("Tarifa") Then
                texttarifa.Text = "P: " & dt.Rows(0).Item("Tarifa Procedimientos")
                texttarifa.Text = texttarifa.Text & "   L: " & dt.Rows(0).Item("Tarifa Laboratorio")
                texttarifa.Text = texttarifa.Text & "   I: " & dt.Rows(0).Item("Tarifa Imagenología")
                textlistamed.Text = dt.Rows(0).Item("Lista Precio Medicamento")
            Else
                texttarifa.Text = dt.Rows(0).Item("Tarifa")
            End If
            mensajeAyuda.RemoveAll()
            If String.IsNullOrEmpty(objFactura.codigoFactura) Then
                lblValorTotalFactura.Text = ""
                iniciarForm()
            End If
        End If
    End Sub

    Public Sub cargarCliente(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        Dim dt As New DataTable
        General.llenarTabla(objFactura.sqlCargarContrato, params, dt)
        If dt.Rows.Count > 0 Then
            textcodcontrato.Text = pCodigo
            objFactura.idCliente = dt.Rows(0).Item("Id_tercero")
            textcodcliente.Text = dt.Rows(0).Item("NIT").ToString
            textdv.Text = dt.Rows(0).Item("DV")
            textcliente.Text = dt.Rows(0).Item("CLIENTE")
            texttarifa.Text = dt.Rows(0).Item("DIRECCION")
            textlistamed.Text = dt.Rows(0).Item("TELEFONO")
            mensajeAyuda.RemoveAll()
            If String.IsNullOrEmpty(objFactura.codigoFactura) Then
                lblValorTotalFactura.Text = ""
                iniciarFormRemision()
            End If
        End If
    End Sub

    Private Sub iniciarForm()
        btBuscarAdmision.Enabled = True
        General.limpiarControles(gpInformacionPaciente)
        General.limpiarControles(gbInformacionFactura)
        General.limpiarControles(gbDetalleServicios)
        If objFactura.tipo = 2 Then
            General.limpiarControles(gbInformacionPEM)
            General.habilitarControles(gbInformacionPEM)
            objFactura.dtAFacturar.Clear()
            habilitarDiseño()
            lblValorTotalFactura.Text = CDbl(0).ToString("C2")

        End If
    End Sub
    Private Sub iniciarFormRemision()
        General.limpiarControles(gbInformacionRemision)
        General.limpiarControles(gbInformacionFactura)
        General.limpiarControles(gbDetalleServicios)
        General.habilitarControles(gbInformacionRemision)
        objFactura.fechaFactura = txtfechaFactura.Value
        objFactura.calcularFechas()
        txtFechaVence.Value = objFactura.fechaVencimiento
    End Sub

    Private Sub habilitarDiseño()
        If String.IsNullOrEmpty(objFactura.codigoFactura) Then
            objFactura.fechaFactura = txtfechaFactura.Value
            objFactura.calcularFechas()
            txtFechaVence.Value = objFactura.fechaVencimiento
            habilitarDGV()
        End If

    End Sub
    Private Sub habilitarDGV()
        If rbManual.Checked Then
            objFactura.dtParaclinicos.Rows.Add()
            objFactura.dtHemoderivados.Rows.Add()
            objFactura.dtProcedimientos.Rows.Add()
            objFactura.dtMedicamentos.Rows.Add()
            objFactura.dtInsumos.Rows.Add()
            btguardar.Enabled = True
        End If
        dgvParaclinicos.Columns("anularPara").Visible = rbManual.Checked
        dgvHemoderivados.Columns("anularHemo").Visible = rbManual.Checked
        dgvProcedimientos.Columns("anularProce").Visible = rbManual.Checked
        dgvMedicamentos.Columns("anularMed").Visible = rbManual.Checked
        dgvInsumos.Columns("anularInsu").Visible = rbManual.Checked
        dgvMedicamentos.Columns("dgCodigoMed").Visible = False
        dgvInsumos.Columns("dgCodigoInsu").Visible = False

    End Sub
    Private Sub btBuscarAdmision_Click(sender As Object, e As EventArgs) Handles btBuscarAdmision.Click
        Try
            Dim params As New List(Of String)
            Dim tbl As DataRow = Nothing
            params.Add(Nothing)
            params.Add(objFactura.CodigoContrato)
            Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(objFactura.sqlbuscarRegistroAFacturar,
                                                                              params, TitulosForm.BUSQUEDA_ADMISION,
                                                                              IIf(objFactura.tipo = ConstantesAsis.TIPO_FACTURA_AMBULANCIA,
                                                                                  True, False), Constantes.TAMANO_MEDIANO, True)
            tbl = formBusqueda.rowResultados
            If tbl IsNot Nothing Then
                Select Case objFactura.tipo
                    Case ConstantesAsis.TIPO_FACTURA_ASISTENCIAL, ConstantesAsis.TIPO_FACTURA_ASISTENCIAL_CTC
                        cargarRegistroAsistencial(tbl)
                    Case ConstantesAsis.TIPO_FACTURA_AMBULANCIA
                        cargarRegistroTraslado(tbl)
                End Select

            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub cargarRegistroAsistencial(tbl As DataRow)
        objFactura.CTC = tbl(0)
        objFactura.registroAFacturar = tbl(1)
        textidpaciente.Text = objFactura.registroAFacturar
        textpaciente.Text = tbl(2)
        txtFechaIngreso.Text = tbl(3)
        txtFechaEgreso.Text = tbl(4)
        texttipoafiliado.Text = tbl(5)
        texttipousuario.Text = tbl(6)
        objFactura.visado = tbl(7)
        aplicarDiseñoSegunCTC()
        cargarDetalleFactura()
        If SesionActual.tienePermiso(pExonerar) Then
            btExonerar.Visible = True
            btExonerar.Enabled = True
        Else
            btExonerar.Visible = False
            btExonerar.Enabled = False
        End If
    End Sub
    Private Sub cargarRegistroTraslado(tbl As DataRow)
        objFactura.observacion = tbl(0)
        objFactura.registroAFacturar = tbl(1)
        textidpaciente.Text = objFactura.registroAFacturar
        textpaciente.Text = tbl(2)
        txtFechaIngreso.Text = tbl(3)
        txtFechaEgreso.Text = tbl(4)
        texttipoafiliado.Text = tbl(5)
        texttipousuario.Text = tbl(6)
        objFactura.totalFactura = tbl(7)
        objFactura.precioTraslado = tbl(8)
        objFactura.cantidadKMS = tbl(9)
        objFactura.precioKMS = tbl(10)
        objFactura.cantidadHH = tbl(11)
        objFactura.precioHH = tbl(12)
        objFactura.precioRN = tbl(13)

        btguardar.Enabled = True
        cargarDetalleFactura()
    End Sub

    Private Sub cargarDetalleFactura()
        objFactura.cargarDetalle()
        dgvMedicamentos.Columns("dgCodigoMed").Visible = False
        dgvInsumos.Columns("dgCodigoInsu").Visible = False
        dgvMedicamentosRem.Columns("dgCodigoProMed").Visible = False
        dgvInsumosRem.Columns("dgCodigoProIns").Visible = False
        If String.IsNullOrEmpty(objFactura.codigoFactura) Then
            lblValorTotalFactura.Text = CDbl(objFactura.totalFactura).ToString("C2")
            validar()
        End If
        If String.IsNullOrEmpty(objFactura.codigoFactura) Then
            objFactura.fechaFactura = txtfechaFactura.Value
            objFactura.calcularFechas()
            txtFechaVence.Value = objFactura.fechaVencimiento
        End If

    End Sub
    Private Sub cargarDetalleAsistencial(pNRegistro As Integer)
        Dim params As New List(Of String)
        params.Add(pNRegistro)
        Dim dt As New DataTable
        General.llenarTabla(objFactura.sqlCargarRegistroAFacturar, params, dt)
        If dt.Rows.Count > 0 Then
            textpaciente.Text = dt.Rows(0).Item("Paciente")
            txtFechaIngreso.Text = dt.Rows(0).Item("Fecha admisión")
            txtFechaEgreso.Text = dt.Rows(0).Item("Fecha epicrisis")
            texttipoafiliado.Text = dt.Rows(0).Item("Afiliación")
            texttipousuario.Text = dt.Rows(0).Item("Régimen")
            objFactura.visado = dt.Rows(0).Item("Visado")
            aplicarDiseñoSegunCTC()
            cargarDetalleFactura()
        End If
    End Sub
    Private Sub cargarDetalleAmbulancia(pCodigo As Integer)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        Dim dt As New DataTable
        General.llenarTabla(objFactura.sqlCargarRegistroAFacturar, params, dt)
        If dt.Rows.Count > 0 Then
            textpaciente.Text = dt.Rows(0).Item("Paciente")
            txtFechaIngreso.Text = dt.Rows(0).Item("Fecha Salida")
            txtFechaEgreso.Text = dt.Rows(0).Item("Fecha Llegada")
            texttipoafiliado.Text = dt.Rows(0).Item("Afiliación")
            texttipousuario.Text = dt.Rows(0).Item("Régimen")
            cargarDetalleFactura()
        End If
    End Sub

    Private Sub aplicarDiseñoSegunCTC()
        If objFactura.visado = True Then
            picVisado.Image = My.Resources.OK
            btguardar.Enabled = True
            mensajeAyuda.SetToolTip(picVisado, "¡Listo para facturar!")
        Else
            picVisado.Image = My.Resources.Close_2_icon
            btguardar.Enabled = False
            mensajeAyuda.SetToolTip(picVisado, "¡Registro no se encuentra listo para facturar!")
        End If
        If objFactura.CTC = True Then
            tpEstancia.Parent = Nothing
            tpTraslado.Parent = Nothing
            tpOxigeno.Parent = Nothing
            tpParaclinico.Parent = Nothing
            tpHemoderivado.Parent = Nothing
            tpProcedimiento.Parent = Nothing
            tpInsumo.Parent = Nothing
        Else
            If IsNothing(tpEstancia.Parent) Then
                tpMedicamento.Parent = Nothing
                tpEstancia.Parent = tcServicios
                tpTraslado.Parent = tcServicios
                tpOxigeno.Parent = tcServicios
                tpParaclinico.Parent = tcServicios
                tpHemoderivado.Parent = tcServicios
                tpProcedimiento.Parent = tcServicios
                tpMedicamento.Parent = tcServicios
                tpInsumo.Parent = tcServicios
            End If
        End If
    End Sub

    Private Sub FormGenerarFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargando = True
        General.limpiarControles(Me)
        cargarPermisos()
        seleccionarObjeto()
        General.deshabilitarControles(Me)
        If Not SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) OrElse (Tag.codigo <> ConstantesAsis.CODIGO_MENU_FACTURA_ASISTENCIAL AndAlso Tag.codigo <> ConstantesAsis.CODIGO_MENU_FACTURA_EXTERNA) Then
            tssEditar.Visible = False
            bteditar.Visible = False
        End If
        If Tag.codigo = ConstantesAsis.CODIGO_MENU_FACTURA_EXTERNA_LAB OrElse
                  Tag.codigo = ConstantesAsis.CODIGO_MENU_FACTURA_EXTERNA_IMA OrElse
                  Tag.codigo = ConstantesAsis.CODIGO_MENU_FACTURA_EXTERNA_ATE OrElse
                   Tag.codigo = ConstantesAsis.CODIGO_MENU_FACTURA_EXTERNA_CEXT Then
            objFactura.sqlBuscarContrato = ConsultasAsis.FACTURA_EXTERNA_CLIENTE_PENDIENTE_BUSCAR
            rbManual.Visible = False
            objFactura.facturaManual = False
            rbPEM.Location = New Point(rbManual.Location.X - 15, rbManual.Location.Y)
            rbTotal.Location = New Point(95, 23)
            Label3.Location = New Point(95, 24)
            fechaInicio.Location = New Point(180, 20)
            Label4.Location = New Point(280, 24)
            fechaFin.Location = New Point(350, 20)
            btBuscarPEMs.Location = New Point(457, 47)
            chkExterno.Location = New Point(460, 24)
            chkExternoAuditoria.Location = New Point(530, 24)
            chkExternoAuditoria.Enabled = False
            rbPEM.Visible = False
            chkExterno.Visible = True
            chkExternoAuditoria.Visible = True
            If Tag.codigo = ConstantesAsis.CODIGO_MENU_FACTURA_EXTERNA_ATE Then
                btBuscarPEMs.Visible = True
            End If
        End If
        cargando = False
    End Sub

    Private Sub seleccionarObjeto()
        Select Case Tag.modulo
            Case Constantes.CODIGO_MENU_AMBU
                objFactura = New FacturaAtencionAmbulancia()
                aplicarDiseñoAmbulancia()
                enlazarTablaTraslado(dgvTrasladosAmbu, objFactura.dtTraslado)
            Case Constantes.CODIGO_MENU_INVEN
                objFactura = New FacturaRemision()
                aplicarDiseñoRemision()
                enlazarTablaProducto(dgvMedicamentosRem, objFactura.dtMedicamentos)
                enlazarTablaProducto(dgvInsumosRem, objFactura.dtInsumos)
                enlazarTablaRemision(dgvPendiente, objFactura.dtPendiente)
                enlazarTablaRemision(dgvRemision, objFactura.dtAFacturar)
            Case Else
                Select Case Tag.codigo
                    Case ConstantesAsis.CODIGO_MENU_FACTURA_ASISTENCIAL
                        verificarModuloFacturacionAsistencial()
                        enlazarDgvAsistencial()
                        tsExportarFactura.Visible = True
                    Case ConstantesAsis.CODIGO_MENU_FACTURA_EXTERNA,
                         ConstantesAsis.CODIGO_MENU_FACTURA_EXTERNA_LAB,
                         ConstantesAsis.CODIGO_MENU_FACTURA_EXTERNA_IMA,
                         ConstantesAsis.CODIGO_MENU_FACTURA_EXTERNA_ATE,
                         ConstantesAsis.CODIGO_MENU_FACTURA_EXTERNA_CEXT
                        objFactura = New FacturaExterna()
                        aplicarDiseñoFacturaExterna()
                        enlazarDgvExterna()
                        enlazarTablaExterna(dgvPendiente, objFactura.dtPendiente)
                        enlazarTablaExterna(dgvRemision, objFactura.dtAFacturar)
                        tsExportarFactura.Visible = True
                End Select
                tpMedicamentoRem.Parent = Nothing
                tpInsumoRem.Parent = Nothing
                tpTrasladoAmb.Parent = Nothing
        End Select
    End Sub

    Private Sub cargarPermisos()
        permisoGeneral = perG.buscarPermisoGeneral(Name, Tag.modulo)
        pNuevo = permisoGeneral & "pp" & "01"
        pEditar = permisoGeneral & "pp" & "02"
        pAnular = permisoGeneral & "pp" & "03"
        pBuscar = permisoGeneral & "pp" & "04"
        pReporte = permisoGeneral & "pp" & "05"
        pImprimir = permisoGeneral & "pp" & "06"
        pExonerar = permisoGeneral & "pp" & "07"
    End Sub

    Private Sub verificarModuloFacturacionAsistencial()
        Dim params As New List(Of String)
        Dim modulo As String
        params.Add(SesionActual.codigoEP)
        modulo = General.getValorConsulta(ConsultasAsis.FACTURA_ATENCION_MODULO_ACTIVO_VERIFICAR, params)
        objFactura = GeneralHC.fabricaHC.crear(ConstantesAsis.CODIGO_FACTURA_ASISTENCIAL & modulo)
        objLista = GeneralHC.fabricaHC.crear(Constantes.CODIGO_LISTA_CHEQUEO & modulo)
        moduloTemporal = objFactura.moduloReporte
    End Sub

    Private Sub enlazarDgvAsistencial()
        enlazarTabla(dgvEstancias, objFactura.dtEstancias)
        enlazarTabla(dgvTraslados, objFactura.dtTraslados)
        enlazarTabla(dgvOxigenos, objFactura.dtOxigenos)
        enlazarTabla(dgvParaclinicos, objFactura.dtParaclinicos)
        enlazarTabla(dgvHemoderivados, objFactura.dtHemoderivados)
        enlazarTabla(dgvProcedimientos, objFactura.dtProcedimientos)
        enlazarTablaEquivalencia(dgvMedicamentos, objFactura.dtMedicamentos)
        enlazarTablaEquivalencia(dgvInsumos, objFactura.dtInsumos)
    End Sub
    Private Sub enlazarDgvExterna()
        enlazarTabla(dgvParaclinicos, objFactura.dtParaclinicos)
        enlazarTabla(dgvHemoderivados, objFactura.dtHemoderivados)
        enlazarTabla(dgvProcedimientos, objFactura.dtProcedimientos)
        enlazarTablaEquivalencia(dgvMedicamentos, objFactura.dtMedicamentos)
        enlazarTablaEquivalencia(dgvInsumos, objFactura.dtInsumos)
        dgvConsolidado.DataSource = objFactura.dtConsolidado
    End Sub
    Public Shared Sub enlazarTabla(dgv As DataGridView, dt As DataTable)
        With dgv
            .Columns(0).DataPropertyName = "Código"
            .Columns(1).DataPropertyName = "Descripción"
            .Columns(2).DataPropertyName = "Cantidad"
            .Columns(3).DataPropertyName = "Precio unitario"
            .Columns(4).DataPropertyName = "Total"
        End With
        dgv.DataSource = dt
        dgv.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Public Shared Sub enlazarTablaEquivalencia(dgv As DataGridView, dt As DataTable)
        With dgv
            .Columns(0).DataPropertyName = "Código"
            .Columns(0).Visible = False
            .Columns(1).DataPropertyName = "Código Equivalencia"
            .Columns(2).DataPropertyName = "Descripción"
            .Columns(3).DataPropertyName = "Cantidad"
            .Columns(4).DataPropertyName = "Precio unitario"
            .Columns(5).DataPropertyName = "Total"
        End With
        dgv.DataSource = dt
        dgv.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Public Shared Sub enlazarTablaProducto(dgv As DataGridView, dt As DataTable)
        With dgv
            .Columns(0).DataPropertyName = "Código"
            .Columns(0).Visible = False
            .Columns(1).DataPropertyName = "Código Producto"
            .Columns(2).DataPropertyName = "Descripción"
            .Columns(3).DataPropertyName = "Laboratorio"
            .Columns(4).DataPropertyName = "Cantidad"
            .Columns(5).DataPropertyName = "IVA"
            .Columns(6).DataPropertyName = "ValorIVA"
            .Columns(7).DataPropertyName = "Precio unitario"
            .Columns(8).DataPropertyName = "Total"
        End With
        dgv.DataSource = dt
        dgv.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Public Shared Sub enlazarTablaRemision(dgv As DataGridView, dt As DataTable)
        With dgv
            .Columns(0).DataPropertyName = "Código"
            .Columns(1).DataPropertyName = "Bodega"
            .Columns(2).DataPropertyName = "Orden"
            .Columns(3).DataPropertyName = "Creacion"
            .Columns(4).DataPropertyName = "ValorBruto"
            .Columns(5).DataPropertyName = "IVA"
            .Columns(6).DataPropertyName = "ValorTotal"
        End With
        dgv.DataSource = dt
        dgv.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 8)
    End Sub
    Public Shared Sub enlazarTablaExterna(dgv As DataGridView, dt As DataTable)
        With dgv
            .Columns(0).DataPropertyName = "Código"
            .Columns(1).DataPropertyName = "Paciente"
            .Columns(2).DataPropertyName = "Fecha Atención"
            .Columns(3).DataPropertyName = "Observacion"
        End With
        dgv.DataSource = dt
        dgv.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 8)
    End Sub
    Public Shared Sub enlazarTablaTraslado(dgv As DataGridView, dt As DataTable)
        With dgv
            .Columns(0).DataPropertyName = "PaisO"
            .Columns(1).DataPropertyName = "DptoO"
            .Columns(2).DataPropertyName = "MpioO"
            .Columns(3).DataPropertyName = "EntidadO"
            .Columns(4).DataPropertyName = "PaisD"
            .Columns(5).DataPropertyName = "DptoD"
            .Columns(6).DataPropertyName = "MpioD"
            .Columns(7).DataPropertyName = "EntidadD"
            .Columns(8).DataPropertyName = "Descripcion"
        End With
        dgv.DataSource = dt
        dgv.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7)
    End Sub

    Private Sub aplicarDiseñoFacturaExterna()
        Label1.Text = "FACTURA EXTERNA"
        gbInformacionPEM.Visible = True
        gpInformacionPaciente.Visible = False
        gbInformacionPEM.Location = New Point(12, 142)
        gbDetalleServicios.Text = "Detalle de Servicios y Productos:"
        gbPendiente.Text = "Atenciones Pendientes"
        gbFacturar.Text = "Atenciones a Facturar"
        dgvPendiente.Columns(1).HeaderText = "Paciente"
        dgvPendiente.Columns(1).Width = 350
        dgvPendiente.Columns(2).HeaderText = "Fecha Atención"
        dgvPendiente.Columns(2).Width = 120
        dgvPendiente.Columns(3).HeaderText = "Observacion"
        dgvPendiente.Columns(3).Width = 220
        dgvPendiente.Columns(4).Visible = False
        dgvPendiente.Columns(5).Visible = False
        dgvPendiente.Columns(6).Visible = False

        dgvRemision.Columns(1).HeaderText = "Paciente"
        dgvRemision.Columns(1).Width = 350
        dgvRemision.Columns(2).HeaderText = "Fecha Atención"
        dgvRemision.Columns(2).Width = 120
        dgvRemision.Columns(3).HeaderText = "Observacion"
        dgvRemision.Columns(3).Width = 220
        dgvRemision.Columns(4).Visible = False
        dgvRemision.Columns(5).Visible = False
        dgvRemision.Columns(6).Visible = False

        tpEstancia.Parent = Nothing
        tpTraslado.Parent = Nothing
        tpOxigeno.Parent = Nothing
        objFactura.facturaManual = True
    End Sub

    Private Sub aplicarDiseñoAmbulancia()
        tpEstancia.Parent = Nothing
        tpTraslado.Parent = Nothing
        tpOxigeno.Parent = Nothing
        tpParaclinico.Parent = Nothing
        tpHemoderivado.Parent = Nothing
        tpProcedimiento.Parent = Nothing
        tpMedicamento.Parent = Nothing
        tpInsumo.Parent = Nothing
        tpMedicamentoRem.Parent = Nothing
        tpInsumoRem.Parent = Nothing
        gbDetalleServicios.Text = "Detalle de Servicios:"
        lblAdmision.Text = "N° Traslado:"
        lblFechaIngreso.Text = "Fecha Hora Salida:"
        lblFechaEgreso.Text = "Fecha Hora LLegada:"
        txtFechaIngreso.Location = New Point(txtFechaIngreso.Location.X + 63, txtFechaIngreso.Location.Y)
        txtFechaEgreso.Location = New Point(txtFechaEgreso.Location.X + 63, txtFechaEgreso.Location.Y)
        lblFechaIngreso.Location = New Point(lblFechaIngreso.Location.X + 56, lblFechaIngreso.Location.Y)
        lblFechaEgreso.Location = New Point(lblFechaEgreso.Location.X + 40, lblFechaEgreso.Location.Y)
        texttarifa.Size = New Size(texttarifa.Width + 500, texttarifa.Height)
        gbVisado.Visible = False
        lblListaMed.Visible = False
        textlistamed.Visible = False
    End Sub
    Private Sub aplicarDiseñoRemision()
        Label1.Text = "FACTURA REMISIÓN"
        gbInformacionRemision.Visible = True
        gpInformacionPaciente.Visible = False
        gbInformacionRemision.Location = New Point(12, 142)
        gbDetalleServicios.Text = "Detalle de Productos:"
        tpEstancia.Parent = Nothing
        tpTraslado.Parent = Nothing
        tpOxigeno.Parent = Nothing
        tpParaclinico.Parent = Nothing
        tpHemoderivado.Parent = Nothing
        tpProcedimiento.Parent = Nothing
        tpMedicamento.Parent = Nothing
        tpTrasladoAmb.Parent = Nothing
        tpInsumo.Parent = Nothing
        lblCodigo.Text = "Cliente:"
        lblTarifa.Text = "Dirección:"
        lblListaMed.Text = "Teléfono:"
        lblTotalIVA.Visible = True
        texttarifa.Location = New Point(texttarifa.Location.X - 46, texttarifa.Location.Y)
        texttarifa.Size = New Size(texttarifa.Width + 230, texttarifa.Height)
        textlistamed.Location = New Point(textlistamed.Location.X + 100, textlistamed.Location.Y)
        textlistamed.Size = New Size(textlistamed.Width - 100, textlistamed.Height)
        lblListaMed.Location = New Point(lblListaMed.Location.X + 230, lblListaMed.Location.Y)
        lblTotalFactura.Location = New Point(lblTotalFactura.Location.X, lblTotalFactura.Location.Y - 11)
        lblValorTotalFactura.Location = New Point(lblValorTotalFactura.Location.X, lblValorTotalFactura.Location.Y - 10)
        Label11.Location = New Point(Label11.Location.X, Label11.Location.Y - 5)
        Label13.Location = New Point(Label13.Location.X, Label13.Location.Y - 5)
        txtfechaFactura.Location = New Point(txtfechaFactura.Location.X, txtfechaFactura.Location.Y - 5)
        txtFechaVence.Location = New Point(txtFechaVence.Location.X, txtFechaVence.Location.Y - 5)
        panelRemisiones.BringToFront()
        dgvMedicamentosRem.Columns("dgCodigoProMed").Visible = False
        dgvInsumosRem.Columns("dgCodigoProIns").Visible = False
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(pBuscar) Then
            Dim tbl As DataRow = Nothing
            Dim params As New List(Of String)
            Dim tamanoBusqueda As Integer
            params.Add(Nothing)
            params.Add(SesionActual.codigoEP)
            tamanoBusqueda = Constantes.TAMANO_MEDIANO
            Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(objFactura.sqlBuscarFactura,
                                                                              params, TitulosForm.BUSQUEDA_FACTURAS, False, tamanoBusqueda, True)
            tbl = formBusqueda.rowResultados
            If tbl IsNot Nothing Then
                Select Case objFactura.tipo
                    Case ConstantesAsis.TIPO_FACTURA_ASISTENCIAL, ConstantesAsis.TIPO_FACTURA_ASISTENCIAL_CTC
                        cargarFactura(tbl(1))
                    Case ConstantesAsis.TIPO_FACTURA_AMBULANCIA
                        cargarFacturaAmbulancia(tbl(0))
                    Case ConstantesAsis.TIPO_FACTURA_EXTERNA
                        cargarFacturaExterna(tbl(0))
                    Case ConstantesAsis.TIPO_FACTURA_REMISION
                        cargarFacturaRemision(tbl(0))
                End Select
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub
    Private Sub cargarFactura(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(SesionActual.idEmpresa)
        Dim dt As New DataTable
        General.llenarTabla(objFactura.sqlCargarFactura, params, dt)
        If dt.Rows.Count > 0 Then
            objFactura.codigoFactura = pCodigo
            textcodfactura.Text = objFactura.codigoFactura
            objFactura.CTC = dt.Rows(0).Item("CTC")
            objFactura.fechaFactura = dt.Rows(0).Item("Fecha_Factura")
            objFactura.fechaVencimiento = dt.Rows(0).Item("Fecha_Vence")
            objFactura.totalFactura = dt.Rows(0).Item("Total_Factura")
            objFactura.CodigoContrato = dt.Rows(0).Item("Codigo_Contrato")
            objFactura.registroAFacturar = dt.Rows(0).Item("N_Registro")
            textidpaciente.Text = objFactura.registroAFacturar
            txtfechaFactura.Value = objFactura.fechaFactura
            txtFechaVence.Value = objFactura.fechaVencimiento
            lblValorTotalFactura.Text = CDbl(objFactura.totalFactura).ToString("c0")
            cargarContrato(objFactura.CodigoContrato)
            cargarDetalleAsistencial(objFactura.registroAFacturar)
            General.habilitarBotones(ToolStrip1)
            btcancelar.Enabled = False
            btguardar.Enabled = False
        End If
    End Sub
    Private Sub cargarFacturaExterna(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(SesionActual.idEmpresa)
        Dim dt As New DataTable
        General.llenarTabla(objFactura.sqlCargarFactura, params, dt)
        If dt.Rows.Count > 0 Then
            mensajeAyuda.RemoveAll()
            lblValorTotalFactura.Text = ""
            objFactura.codigoFactura = pCodigo
            textcodfactura.Text = objFactura.codigoFactura
            objFactura.fechaFactura = dt.Rows(0).Item("Fecha_Factura")
            objFactura.fechaVencimiento = dt.Rows(0).Item("Fecha_Vence")
            objFactura.fechaInicio = IIf(IsDBNull(dt.Rows(0).Item("Fecha_Inicio")), Now, dt.Rows(0).Item("Fecha_Inicio"))
            objFactura.fechaFin = IIf(IsDBNull(dt.Rows(0).Item("Fecha_Fin")), Now, dt.Rows(0).Item("Fecha_Fin"))
            objFactura.totalFactura = dt.Rows(0).Item("Total_Factura")
            objFactura.codigoContrato = dt.Rows(0).Item("Codigo_contrato")
            objFactura.observacion = dt.Rows(0).Item("Observacion")
            If dt.Rows(0).Item("AtencionLab") = 1 Then
                btSoportes.Visible = False
                tsExcel.Visible = True
                tsExcel.Tag = dt.Rows(0).Item("AtencionLab")
                btBuscarPEMs.Visible = True
            ElseIf dt.Rows(0).Item("AtencionLab") = 0 Then
                btBuscarPEMs.Visible = False
                btSoportes.Visible = False
                tsExcel.Visible = False
            ElseIf dt.Rows(0).Item("AtencionLab") = 2 Then
                btSoportes.Visible = False
                tsExcel.Visible = True
                tsExcel.Tag = dt.Rows(0).Item("AtencionLab")
                btBuscarPEMs.Visible = False
            End If
            txtObservacion.Text = objFactura.observacion
            txtfechaFactura.Value = objFactura.fechaFactura
            txtFechaVence.Value = objFactura.fechaVencimiento
            fechaInicio.Value = objFactura.fechaInicio
            fechaFin.Value = objFactura.fechaFin
            lblValorTotalFactura.Text = CDbl(objFactura.totalFactura).ToString("c2")
            cargarContrato(objFactura.codigoContrato)
            cargarDetalleFactura()
            General.habilitarBotones(ToolStrip1)
            btcancelar.Enabled = False
            btguardar.Enabled = False
            btBuscarPEMs.Enabled = True

            If SesionActual.codigoEnlace <> 1 Or SesionActual.codigoEP = 13 Then '--esto se tiene mientras se busca una manera mejor
                chkExterno.Visible = False
            End If

        End If
    End Sub
    Private Sub cargarFacturaRemision(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(SesionActual.idEmpresa)
        Dim dt As New DataTable
        General.llenarTabla(objFactura.sqlCargarFactura, params, dt)
        If dt.Rows.Count > 0 Then
            mensajeAyuda.RemoveAll()
            lblValorTotalFactura.Text = ""
            lblValorTotalIVA.Text = ""
            objFactura.codigoFactura = pCodigo
            textcodfactura.Text = objFactura.codigoFactura
            objFactura.fechaFactura = dt.Rows(0).Item("Fecha_Factura")
            objFactura.fechaVencimiento = dt.Rows(0).Item("Fecha_Vence")
            objFactura.totalFactura = dt.Rows(0).Item("Total_Factura")
            objFactura.idCliente = dt.Rows(0).Item("id_Cliente")
            objFactura.observacion = dt.Rows(0).Item("Observacion").ToString
            'objFactura.remisiones = dt.Rows(0).Item("Remisiones").ToString
            txtObservacionRem.Text = objFactura.observacion
            txtfechaFactura.Value = objFactura.fechaFactura
            txtFechaVence.Value = objFactura.fechaVencimiento
            lblValorTotalFactura.Text = CDbl(objFactura.totalFactura).ToString("c2")
            cargarCliente(objFactura.idCliente)
            cargarDetalleFactura()
            objFactura.cargarFactura()
            lblValorTotalIVA.Text = CDbl(objFactura.valorIVA).ToString("c2")
            General.habilitarBotones(ToolStrip1)
            btBuscarRemision.Enabled = True
            btcancelar.Enabled = False
            btguardar.Enabled = False
            concatenarAFacturar()
        End If
        dgvMedicamentosRem.Columns("dgCodigoProMed").Visible = False
        dgvInsumosRem.Columns("dgCodigoProIns").Visible = False
    End Sub

    Private Sub cargarFacturaAmbulancia(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(SesionActual.idEmpresa)
        Dim dt As New DataTable
        General.llenarTabla(objFactura.sqlCargarFactura, params, dt)
        If dt.Rows.Count > 0 Then
            objFactura.codigoFactura = pCodigo
            textcodfactura.Text = objFactura.codigoFactura
            objFactura.fechaFactura = dt.Rows(0).Item("Fecha_Factura")
            objFactura.fechaVencimiento = dt.Rows(0).Item("Fecha_Vence")
            objFactura.totalFactura = dt.Rows(0).Item("Total_Factura")
            objFactura.CodigoContrato = dt.Rows(0).Item("Codigo_Contrato")
            objFactura.registroAFacturar = dt.Rows(0).Item("Codigo_Traslado_Paciente")
            objFactura.precioTraslado = dt.Rows(0).Item("PrecioTraslado")
            objFactura.cantidadKMS = dt.Rows(0).Item("CantidadKMS")
            objFactura.precioKMS = dt.Rows(0).Item("PrecioKMS")
            objFactura.cantidadHH = dt.Rows(0).Item("CantidadHH")
            objFactura.precioHH = dt.Rows(0).Item("PrecioHH")
            objFactura.precioRN = dt.Rows(0).Item("PrecioRN")
            objFactura.observacion = dt.Rows(0).Item("Observacion")
            textidpaciente.Text = objFactura.registroAFacturar
            txtfechaFactura.Value = objFactura.fechaFactura
            txtFechaVence.Value = objFactura.fechaVencimiento
            lblValorTotalFactura.Text = CDbl(objFactura.totalFactura).ToString("c2")
            cargarContrato(objFactura.CodigoContrato)
            cargarDetalleAmbulancia(objFactura.registroAFacturar)
            General.habilitarBotones(ToolStrip1)
            btcancelar.Enabled = False
            btguardar.Enabled = False
        End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            Select Case objFactura.tipo
                Case ConstantesAsis.TIPO_FACTURA_EXTERNA
                    preGuardar()
                Case ConstantesAsis.TIPO_FACTURA_ASISTENCIAL, ConstantesAsis.TIPO_FACTURA_ASISTENCIAL_CTC
                    objFactura.calcularTotal()
            End Select
            lblValorTotalFactura.Text = CDbl(objFactura.totalFactura).ToString("C2")
            If validar() Then
                guardarFactura()
            End If
            tsActualizar.Visible = False
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub preGuardar()
        dgvParaclinicos.EndEdit()
        dgvHemoderivados.EndEdit()
        dgvProcedimientos.EndEdit()
        dgvMedicamentos.EndEdit()
        dgvInsumos.EndEdit()
        objFactura.dtParaclinicos.AcceptChanges()
        objFactura.dtHemoderivados.AcceptChanges()
        objFactura.dtProcedimientos.AcceptChanges()
        objFactura.dtMedicamentos.AcceptChanges()
        objFactura.dtInsumos.AcceptChanges()
        objFactura.calcularTotal()
    End Sub

    Private Sub guardarFactura()
        If objFactura.tipo = ConstantesAsis.TIPO_FACTURA_EXTERNA Then
            objFactura.observacion = If(Tag.codigo = ConstantesAsis.CODIGO_MENU_FACTURA_EXTERNA OrElse chkExterno.Checked, txtObservacion.Text, objFactura.listaDocumentos)
        ElseIf objFactura.tipo = ConstantesAsis.TIPO_FACTURA_REMISION Then
            objFactura.observacion = txtObservacionRem.Text
        End If
        objFactura.usuario = SesionActual.idUsuario
        objFactura.totalFactura = CDbl(lblValorTotalFactura.Text)
        objFactura.guardarFactura()
        textcodfactura.Text = objFactura.codigoFactura
        codigoTemporal = textcodfactura.Text
        nRegistroTemporal = textidpaciente.Text
        nombrePDF = objFactura.nombrePDF
        tipoFacturaTemporal = objFactura.tipo
        If objFactura.tipo = ConstantesAsis.TIPO_FACTURA_ASISTENCIAL Then
            nombreCertificadoPDF = objFactura.nombreCertificadoPDF
        End If
        valorLetraTemporal = FuncionesContables.Convertir_Numero(objFactura.totalFactura)
        fechaTemporal = txtFechaEgreso.Text
        idEmpresaTemporal = SesionActual.idEmpresa
        General.deshabilitarControles(Me)
        General.habilitarBotones(ToolStrip1)
        btguardar.Enabled = False
        btExonerar.Visible = False
        btcancelar.Enabled = False

        If chkExterno.Checked Then
            btBuscarPEMs.Visible = False
            btSoportes.Visible = False
            tsExcel.Visible = True
        Else
            btBuscarPEMs.Visible = True
            btSoportes.Visible = False
            tsExcel.Visible = False
        End If
        dgvMedicamentos.Columns("dgCodigoMed").Visible = False
        dgvInsumos.Columns("dgCodigoInsu").Visible = False
        MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
    End Sub

    Private Function validar() As Boolean
        Dim mensaje As String
        mensaje = objFactura.verificarClausulas()
        If String.IsNullOrEmpty(mensaje) Then
            mensaje = objFactura.verificarTotales()
        End If
        If Not String.IsNullOrEmpty(mensaje) Then
            mensaje = mensaje
            MsgBox(mensaje, MsgBoxStyle.Exclamation)
            If objFactura.tipo <> 2 Then
                btguardar.Enabled = False
            End If
            Return False
        End If
        If objFactura.totalFactura = 0 Then
            mensaje = "Factura en 0."
            MsgBox(mensaje, MsgBoxStyle.Exclamation)
            Return False
        End If
        Return True

    End Function
    Private Sub guardarSegundoPlano()
        Dim guardarEn2doPlano As Thread
        guardarEn2doPlano = New Thread(AddressOf guardarReporte)
        guardarEn2doPlano.Name = "Guardar Factura"
        guardarEn2doPlano.SetApartmentState(ApartmentState.STA)
        guardarEn2doPlano.Start()
    End Sub
    Private Sub guardarReporte()
        Try
            Dim reporte As New ftp_reportes
            Dim params As New List(Of String)
            params.Add(valorLetraTemporal)
            params.Add(fechaTemporal)
            reporte.crearReportePDF(nombrePDF, nRegistroTemporal, New rptFacturaAsistencial,
                                  codigoTemporal,
                                  "{VISTA_FACTURACION.codigo_factura} = '" & codigoTemporal & "' 
                                  AND {VISTA_FACTURACION.TipoFactura}=" & tipoFacturaTemporal & "
                                  AND {VISTA_FACTURACION.Id_Empresa}=" & idEmpresaTemporal & "",
                                  nombrePDF, IO.Path.GetTempPath,,, params)
            If tipoFacturaTemporal = 0 Then
                reporte.crearReportePDF(nombreCertificadoPDF, nRegistroTemporal, New rptFacturaCertificado,
                                  codigoTemporal,
                                  "{VISTA_FACTURACION_CERTIFICADOS.N_Registro} = " & nRegistroTemporal & " AND {VISTA_FACTURACION_CERTIFICADOS.Modulo}=" & moduloTemporal & "",
                                  nombreCertificadoPDF, IO.Path.GetTempPath)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(pAnular) Then
            General.limpiarControles(gpInformacionPaciente)
            General.limpiarControles(gbInformacionFactura)
            General.limpiarControles(gbDetalleServicios)
            General.limpiarControles(gbInformacionPEM)
            General.deshabilitarBotones(ToolStrip1)
            btBuscarContrato.Enabled = True
            btcancelar.Enabled = True
            btnuevo.Enabled = False
            tsActualizar.Visible = False
            mensajeAyuda.RemoveAll()
            lblValorTotalFactura.Text = ""
            objFactura.codigoFactura = ""
            btBuscarPEMs.Visible = False
            If Not String.IsNullOrEmpty(textcodcontrato.Text) Then
                btBuscarAdmision.Enabled = True
            End If
            If objFactura.TIPO = ConstantesAsis.TIPO_FACTURA_EXTERNA Then
                habilitarDGV()
                General.habilitarControles(gbInformacionPEM)

                If Tag.codigo = ConstantesAsis.CODIGO_MENU_FACTURA_EXTERNA_LAB OrElse
                   Tag.codigo = ConstantesAsis.CODIGO_MENU_FACTURA_EXTERNA_IMA OrElse
                   Tag.codigo = ConstantesAsis.CODIGO_MENU_FACTURA_EXTERNA_ATE OrElse
                    Tag.codigo = ConstantesAsis.CODIGO_MENU_FACTURA_EXTERNA_CEXT Then
                    objFactura.sqlBuscarContrato = ConsultasAsis.FACTURA_EXTERNA_CLIENTE_PENDIENTE_BUSCAR
                    rbManual.Visible = False
                    rbPEM.Checked = True
                    If Tag.codigo = ConstantesAsis.CODIGO_MENU_FACTURA_EXTERNA_ATE Then
                        btBuscarPEMs.Visible = True
                    End If
                Else
                    rbPEM.Visible = False
                    rbTotal.Visible = False
                    objFactura.fechaInicio = fechaInicio.Value
                    objFactura.fechaFin = fechaFin.Value
                End If
            End If
            If SesionActual.codigoEnlace <> 1 Or SesionActual.codigoEP = 13 Then '--esto se tiene mientras se busca una manera mejor
                chkExterno.Visible = False
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar) Then
            mensajeAyuda.RemoveAll()
            lblValorTotalFactura.Text = ""
            objFactura.codigoFactura = ""
            tsActualizar.Visible = False
        End If
    End Sub

    Private Sub textvalortotalfactura_MouseHover(sender As Object, e As EventArgs) Handles lblValorTotalFactura.MouseHover
        Dim mensaje As String = ""
        Select Case objFactura.tipo
            Case ConstantesAsis.TIPO_FACTURA_AMBULANCIA
            Case Else
                Select Case objFactura.tipo
                    Case ConstantesAsis.TIPO_FACTURA_ASISTENCIAL, ConstantesAsis.TIPO_FACTURA_ASISTENCIAL_CTC
                        mensajeAsistencial(mensaje)
                    Case ConstantesAsis.TIPO_FACTURA_EXTERNA
                        mensajeExterna(mensaje)
                End Select
        End Select
        mensajeAyuda.SetToolTip(lblValorTotalFactura, mensaje)
    End Sub
    Private Sub mensajeAsistencial(ByRef mensaje As String)
        mensaje = "Detallado: " & vbLf _
                   & "Estancia: " & CDbl(objFactura.totalEstancias).ToString("c2") _
                   & vbLf _
                   & "Traslados: " & CDbl(objFactura.totalTraslados).ToString("c2") _
                   & vbLf _
                   & "Oxigeno: " & CDbl(objFactura.totalOxigenos).ToString("c2") _
                   & vbLf _
                   & "Paraclinicos: " & CDbl(objFactura.totalParaclinicos).ToString("c2") _
                   & vbLf _
                   & "Hemoderivados: " & CDbl(objFactura.totalHemoderivados).ToString("c2") _
                   & vbLf _
                   & "Procedimientos: " & CDbl(objFactura.totalProcedimientos).ToString("c2") _
                   & vbLf _
                   & "Medicamentos: " & CDbl(objFactura.totalMedicamentos).ToString("c2") _
                   & vbLf _
                   & "Insumos: " & CDbl(objFactura.totalInsumos).ToString("c2")
    End Sub
    Private Sub mensajeExterna(ByRef mensaje As String)
        mensaje = "Detallado: " & vbLf _
                   & "Paraclinicos: " & CDbl(objFactura.totalParaclinicos).ToString("c2") _
                   & vbLf _
                   & "Hemoderivados: " & CDbl(objFactura.totalHemoderivados).ToString("c2") _
                   & vbLf _
                   & "Procedimientos: " & CDbl(objFactura.totalProcedimientos).ToString("c2") _
                   & vbLf _
                   & "Medicamentos: " & CDbl(objFactura.totalMedicamentos).ToString("c2") _
                   & vbLf _
                   & "Insumos: " & CDbl(objFactura.totalInsumos).ToString("c2")
    End Sub

    Private Sub dgv_CellFormatting(dgv As DataGridView, e As DataGridViewCellFormattingEventArgs) Handles _
                                            dgvEstancias.CellFormatting, dgvTraslados.CellFormatting,
                                            dgvOxigenos.CellFormatting, dgvParaclinicos.CellFormatting,
                                            dgvHemoderivados.CellFormatting, dgvProcedimientos.CellFormatting,
                                            dgvMedicamentos.CellFormatting, dgvInsumos.CellFormatting,
                                            dgvMedicamentosRem.CellFormatting, dgvInsumosRem.CellFormatting
        If dgv.Columns(e.ColumnIndex).Name.Contains("Valor") And (Not String.IsNullOrEmpty(dgv.Rows(e.RowIndex).Cells(1).Value.ToString) Or e.RowIndex <> dgv.RowCount - 1) Then
            If e.Value <= 0 Then
                dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Red
                dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.White
            Else
                dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.FromArgb(192, 255, 192)
                dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Black
            End If
        End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(pAnular) Then
            Try
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    objFactura.usuario = SesionActual.idUsuario
                    objFactura.anularFactura()
                    objFactura.codigoFactura = ""
                    lblValorTotalFactura.Text = ""
                    General.limpiarControles(Me)
                    General.deshabilitarBotones(ToolStrip1)
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    tsActualizar.Visible = False
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                End If
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(pEditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                Select Case objFactura.Tipo
                    Case ConstantesAsis.TIPO_FACTURA_ASISTENCIAL, ConstantesAsis.TIPO_FACTURA_ASISTENCIAL_CTC
                        editarFacturaAsistencial()
                    Case ConstantesAsis.TIPO_FACTURA_EXTERNA
                        habilitarDGV()
                        General.habilitarControles(gbInformacionPEM)
                        General.deshabilitarBotones(ToolStrip1)
                        btguardar.Enabled = True
                        btcancelar.Enabled = True
                End Select
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub editarFacturaAsistencial()
        If objFactura.CTC = False Then
            recalcular()
        Else
            objFactura.preCargarMedicamentosCTC()
            General.deshabilitarBotones(ToolStrip1)
            btguardar.Enabled = True
            btcancelar.Enabled = True
        End If
    End Sub

    Private Sub recalcular()
        Dim opciones As New FormFacturaOpcionesActualizar
        opciones.cargarDatos(objFactura)
        If opciones.ShowDialog() = MsgBoxResult.Ok Then
            recalcularSeleccion()
            General.deshabilitarBotones(ToolStrip1)
            btguardar.Enabled = True
            btcancelar.Enabled = True
            tsActualizar.Visible = True
            tsActualizar.Enabled = True
            dgvMedicamentos.Columns("dgCodigoMed").Visible = False
            dgvInsumos.Columns("dgCodigoInsu").Visible = False
        End If
    End Sub

    Private Sub recalcularSeleccion()
        If objFactura.actualizaEstancias Then
            objFactura.precargarEstancias()
        End If
        If objFactura.actualizaTraslados Then
            objFactura.precargarTraslados()
        End If
        If objFactura.actualizaOxigenos Then
            objFactura.precargarOxigenos()
        End If
        If objFactura.actualizaParaclinicos Then
            objFactura.precargarParaclinicos()
        End If
        If objFactura.actualizaHemoderivados Then
            objFactura.precargarHemoderivados()
        End If
        If objFactura.actualizaProcedimientos Then
            objFactura.precargarProcedimientos()
        End If
        If objFactura.actualizaMedicamentos Then
            objFactura.preCargarMedicamentos()
        End If
        If objFactura.actualizaInsumos Then
            objFactura.precargarInsumos()
        End If
    End Sub
    'no quitar att lycans'
    'Public Sub indice()
    '    Dim params As New List(Of String)
    '    Dim modulo As String
    '    params.Add(SesionActual.codigoEP)
    '    modulo = General.getValorConsulta(ConsultasAsis.FACTURA_ATENCION_MODULO_ACTIVO_VERIFICAR, params)

    '    Select Case modulo
    '        Case Constantes.HC
    '            Dim dt As New DataTable
    '            Dim list As New List(Of String)
    '            list.Add(textidpaciente.Text)
    '            list.Add(2)
    '            General.llenarTabla(Consultas.VERIFICAR_INDICE, list, dtIndice)
    '        Case Constantes.AM
    '            Dim dt As New DataTable
    '            Dim list As New List(Of String)
    '            list.Add(textidpaciente.Text)
    '            list.Add(2)
    '            General.llenarTabla(Consultas.VERIFICAR_INDICE_R, list, dtIndice)
    '        Case Constantes.AF
    '            Dim dt As New DataTable
    '            Dim list As New List(Of String)
    '            list.Add(textidpaciente.Text)
    '            list.Add(2)
    '            General.llenarTabla(Consultas.VERIFICAR_INDICE_RR, list, dtIndice)
    '    End Select

    'End Sub
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If (objFactura.tipo = ConstantesAsis.TIPO_FACTURA_ASISTENCIAL Or objFactura.tipo = ConstantesAsis.TIPO_FACTURA_ASISTENCIAL_CTC) And Not SesionActual.tienePermiso(pImprimir) Then

            Try
                Dim params As New List(Of String)
                Dim modulo As String
                params.Add(SesionActual.codigoEP)
                modulo = General.getValorConsulta(ConsultasAsis.FACTURA_ATENCION_MODULO_ACTIVO_VERIFICAR, params)
                objLista.registro = textidpaciente.Text
                objLista.cargarMenu()
                For i = 0 To objLista.dsLista.Tables("Table1").Rows.Count - 1
                    If objLista.dsLista.Tables("Table1").Rows(i).Item("indice") = 0 And objLista.dsLista.Tables("Table1").Rows(i).Item("exepcion") = False Then
                        MsgBox("Algunos procesos no tienen soportes", MsgBoxStyle.Exclamation)
                        Dim form As New FormFacturaImprimir
                        form.registro(objLista)
                        FormPrincipal.Cursor = Cursors.WaitCursor
                        form.ShowDialog()
                        form.Focus()
                        If form.WindowState = FormWindowState.Minimized Then
                            form.WindowState = FormWindowState.Normal
                        End If
                        FormPrincipal.Cursor = Cursors.Default
                        Exit Sub
                    End If
                Next
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try

        End If
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try
            If objFactura.tipo = ConstantesAsis.TIPO_FACTURA_ASISTENCIAL OrElse objFactura.tipo = ConstantesAsis.TIPO_FACTURA_ASISTENCIAL_CTC Then
                objFactura.fechaEgreso = txtFechaEgreso.Text
            End If
            objFactura.imprimirFactura()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvParaclinicos_CellDoubleClick(dgv As DataGridView, e As DataGridViewCellEventArgs) Handles dgvParaclinicos.CellDoubleClick
        If btguardar.Enabled = False OrElse dgv.RowCount = 0 Then
            Exit Sub
        End If
        If (dgvParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Cells("dgDescripcionPara").Selected = True _
                OrElse dgvParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Cells("dgCodigoPara").Selected = True) _
                And objFactura.dtParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Item("Código").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(objFactura.codigoContrato)
            params.Add(ConstantesAsis.CODIGO_TARIFA_LABORATORIO)
            params.Add(Constantes.GRUPO_PARACLINICO)
            General.busquedaItems(ConsultasAsis.BUSQUEDA_GRUPO_CUPS_FACT, params, TitulosForm.BUSQUEDA_PARACLINICO, dgvParaclinicos,
                                  objFactura.dtParaclinicos, 0, 1, dgvParaclinicos.Columns("dgDescripcionPara").Index,
, True, 0, True, AddressOf llenarParaclinico)
        ElseIf dgvParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Cells("anularPara").Selected = True _
            And objFactura.dtParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Item("Código").ToString <> "" Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                dgvParaclinicos.DataSource.Rows.RemoveAt(dgvParaclinicos.CurrentCell.RowIndex)
            End If
        End If
    End Sub
    Private Sub dgvParaclinicos_KeyDown(dgv As DataGridView, e As KeyEventArgs) Handles dgvParaclinicos.KeyDown
        If btguardar.Enabled = False OrElse dgv.RowCount = 0 Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 And objFactura.dtParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Item("Código").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(objFactura.codigoContrato)
            params.Add(ConstantesAsis.CODIGO_TARIFA_LABORATORIO)
            params.Add(Constantes.GRUPO_PARACLINICO)
            General.busquedaItems(ConsultasAsis.BUSQUEDA_GRUPO_CUPS_FACT, params, TitulosForm.BUSQUEDA_PARACLINICO, dgvParaclinicos,
                                  objFactura.dtParaclinicos, 0, 1, dgvParaclinicos.Columns("dgDescripcionPara").Index, False,
                                  True, 0, True, AddressOf llenarParaclinico)
        End If
    End Sub
    Private Sub llenarParaclinico()
        dgvParaclinicos.ReadOnly = False
        dgvParaclinicos.Columns("dgCodigoPara").ReadOnly = True
        dgvParaclinicos.Columns("dgDescripcionPara").ReadOnly = True
        dgvParaclinicos.Columns("dgPrecioPara").ReadOnly = True
        dgvParaclinicos.Columns("dgValorPara").ReadOnly = True
        dgvParaclinicos.Columns("dgCantidadPara").ReadOnly = False
        objFactura.buscarPrecioCUPS(objFactura.dtParaclinicos, ConstantesAsis.CODIGO_TARIFA_LABORATORIO)

        dgvParaclinicos.Rows(dgvParaclinicos.Rows.Count - 1).Cells("dgCantidadPara").ReadOnly = True
        dgvParaclinicos.Rows(dgvParaclinicos.Rows.Count - 2).Cells("dgCantidadPara").Selected = True
    End Sub
    Private Sub dgvHemoderivado_CellDoubleClick(dgv As DataGridView, e As DataGridViewCellEventArgs) Handles dgvHemoderivados.CellDoubleClick
        If btguardar.Enabled = False OrElse dgv.RowCount = 0 Then
            Exit Sub
        End If
        If (dgv.Rows(dgv.CurrentCell.RowIndex).Cells("dgDescripcionHemo").Selected = True _
                OrElse dgv.Rows(dgv.CurrentCell.RowIndex).Cells("dgCodigoHemo").Selected = True) _
                And objFactura.dtHemoderivados.Rows(dgv.CurrentCell.RowIndex).Item("Código").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(objFactura.codigoContrato)
            params.Add(ConstantesAsis.CODIGO_TARIFA_PROCEDIMIENTOS)
            params.Add(Constantes.GRUPO_HEMODERIVADO & "," & Constantes.GRUPO_TRANSFUSION)
            General.busquedaItems(ConsultasAsis.BUSQUEDA_GRUPO_CUPS_FACT, params, TitulosForm.BUSQUEDA_HEMODERIVADO, dgv,
                                  objFactura.dtHemoderivados, 0, 1, dgv.Columns("dgDescripcionHemo").Index,
                                  False, True, 0, True, AddressOf llenarHemoderivado)
        ElseIf dgv.Rows(dgv.CurrentCell.RowIndex).Cells("anularHemo").Selected = True _
            And objFactura.dtHemoderivados.Rows(dgv.CurrentCell.RowIndex).Item("Código").ToString <> "" Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                dgv.DataSource.Rows.RemoveAt(dgv.CurrentCell.RowIndex)
            End If
        End If
    End Sub
    Private Sub dgvHemoderivados_KeyDown(dgv As DataGridView, e As KeyEventArgs) Handles dgvHemoderivados.KeyDown
        If btguardar.Enabled = False OrElse dgv.RowCount = 0 Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 And objFactura.dtHemoderivados.Rows(dgvParaclinicos.CurrentCell.RowIndex).Item("Código").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(objFactura.codigoContrato)
            params.Add(ConstantesAsis.CODIGO_TARIFA_PROCEDIMIENTOS)
            params.Add(Constantes.GRUPO_HEMODERIVADO & "," & Constantes.GRUPO_TRANSFUSION)
            General.busquedaItems(ConsultasAsis.BUSQUEDA_GRUPO_CUPS_FACT, params, TitulosForm.BUSQUEDA_HEMODERIVADO, dgv,
                                  objFactura.dtHemoderivados, 0, 1, dgv.Columns("dgDescripcionHemo").Index,
                                  False, True, 0, True, AddressOf llenarHemoderivado)
        End If
    End Sub
    Private Sub llenarHemoderivado()
        dgvHemoderivados.ReadOnly = False
        dgvHemoderivados.Columns("dgCodigoHemo").ReadOnly = True
        dgvHemoderivados.Columns("dgDescripcionHemo").ReadOnly = True
        dgvHemoderivados.Columns("dgPrecioHemo").ReadOnly = True
        dgvHemoderivados.Columns("dgValorHemo").ReadOnly = True
        dgvHemoderivados.Columns("dgCantidadHemo").ReadOnly = False
        objFactura.buscarPrecioCUPS(objFactura.dtHemoderivados, ConstantesAsis.CODIGO_TARIFA_PROCEDIMIENTOS)
        dgvHemoderivados.Rows(dgvHemoderivados.Rows.Count - 1).Cells("dgCantidadHemo").ReadOnly = True
        dgvHemoderivados.Rows(dgvHemoderivados.Rows.Count - 2).Cells("dgCantidadHemo").Selected = True
    End Sub
    Private Sub dgvProce_CellDoubleClick(dgv As DataGridView, e As DataGridViewCellEventArgs) Handles dgvProcedimientos.CellDoubleClick
        If btguardar.Enabled = False OrElse dgv.RowCount = 0 Then
            Exit Sub
        End If
        If (dgv.Rows(dgv.CurrentCell.RowIndex).Cells("dgDescripcionPro").Selected = True _
             OrElse dgv.Rows(dgv.CurrentCell.RowIndex).Cells("dgCodigoPro").Selected = True) _
                And objFactura.dtprocedimientos.Rows(dgv.CurrentCell.RowIndex).Item("Código").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(objFactura.codigoContrato)
            params.Add(ConstantesAsis.CODIGO_TARIFA_PROCEDIMIENTOS)
            params.Add(Constantes.GRUPO_PROCEDIMIENTO & "," & Constantes.GRUPO_TERAPIA & "," & Constantes.GRUPO_HEMODIALISIS & "," & Constantes.GRUPO_QUIRURGICO)
            General.busquedaItems(ConsultasAsis.BUSQUEDA_GRUPO_CUPS_FACT, params, TitulosForm.BUSQUEDA_PROCEDIMIENTO, dgv,
                                  objFactura.dtprocedimientos, 0, 1, dgv.Columns("dgDescripcionPro").Index,
                                  False, True, 0, True, AddressOf llenarProcedimiento)
        ElseIf dgv.Rows(dgv.CurrentCell.RowIndex).Cells("anularProce").Selected = True _
            And objFactura.dtprocedimientos.Rows(dgv.CurrentCell.RowIndex).Item("Código").ToString <> "" Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                dgv.DataSource.Rows.RemoveAt(dgv.CurrentCell.RowIndex)
            End If
        End If
    End Sub
    Private Sub dgvProcedimientos_KeyDown(dgv As DataGridView, e As KeyEventArgs) Handles dgvProcedimientos.KeyDown
        If btguardar.Enabled = False OrElse dgv.RowCount = 0 Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 And objFactura.dtprocedimientos.Rows(dgv.CurrentCell.RowIndex).Item("Código").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(objFactura.codigoContrato)
            params.Add(ConstantesAsis.CODIGO_TARIFA_PROCEDIMIENTOS)
            params.Add(Constantes.GRUPO_PROCEDIMIENTO & "," & Constantes.GRUPO_TERAPIA & "," & Constantes.GRUPO_HEMODIALISIS & "," & Constantes.GRUPO_QUIRURGICO)
            General.busquedaItems(ConsultasAsis.BUSQUEDA_GRUPO_CUPS_FACT, params, TitulosForm.BUSQUEDA_PROCEDIMIENTO, dgv,
                                  objFactura.dtprocedimientos, 0, 1, dgv.Columns("dgDescripcionPro").Index,
                                  False, True, 0, True, AddressOf llenarProcedimiento)
        End If
    End Sub
    Private Sub llenarProcedimiento()
        dgvProcedimientos.ReadOnly = False
        dgvProcedimientos.Columns("dgCodigoPro").ReadOnly = True
        dgvProcedimientos.Columns("dgDescripcionPro").ReadOnly = True
        dgvProcedimientos.Columns("dgPrecioPro").ReadOnly = True
        dgvProcedimientos.Columns("dgValorPro").ReadOnly = True
        dgvProcedimientos.Columns("dgCantidadPro").ReadOnly = False
        objFactura.buscarPrecioCUPS(objFactura.dtprocedimientos, ConstantesAsis.CODIGO_TARIFA_PROCEDIMIENTOS)
        dgvProcedimientos.Rows(dgvProcedimientos.Rows.Count - 1).Cells("dgCantidadPro").ReadOnly = True
        dgvProcedimientos.Rows(dgvProcedimientos.Rows.Count - 2).Cells("dgCantidadPro").Selected = True
    End Sub

    Private Sub dgvMed_CellDoubleClick(dgv As DataGridView, e As DataGridViewCellEventArgs) Handles dgvMedicamentos.CellDoubleClick
        If btguardar.Enabled = False OrElse dgv.RowCount = 0 Then
            Exit Sub
        End If
        If (dgv.Rows(dgv.CurrentCell.RowIndex).Cells("dgDescripcionMed").Selected = True _
             OrElse dgv.Rows(dgv.CurrentCell.RowIndex).Cells("dgCodigoEquiMed").Selected = True) _
                And objFactura.dtMedicamentos.Rows(dgv.CurrentCell.RowIndex).Item("Código").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(objFactura.codigoContrato)
            params.Add(Constantes.LINEA_MEDICAMENTO & "," & Constantes.LINEA_INSUMO_Y_MEDICAMENTO)
            General.busquedaItems(ConsultasAsis.BUSQUEDA_MEDICAMENTO_FACT, params, TitulosForm.BUSQUEDA_MEDICAMENTO, dgv,
                                  objFactura.dtMedicamentos, 0, 2, dgv.Columns("dgDescripcionMed").Index,
                                  True, True, 0, True, AddressOf llenarMedicamento)
        ElseIf dgv.Rows(dgv.CurrentCell.RowIndex).Cells("anularMed").Selected = True _
            And objFactura.dtMedicamentos.Rows(dgv.CurrentCell.RowIndex).Item("Código").ToString <> "" Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                dgv.DataSource.Rows.RemoveAt(dgv.CurrentCell.RowIndex)
            End If
        End If
    End Sub
    Private Sub dgvMedicamentos_KeyDown(dgv As DataGridView, e As KeyEventArgs) Handles dgvMedicamentos.KeyDown
        If btguardar.Enabled = False OrElse dgv.RowCount = 0 Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 And objFactura.dtMedicamentos.Rows(dgv.CurrentCell.RowIndex).Item("Código").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(objFactura.codigoContrato)
            params.Add(Constantes.LINEA_MEDICAMENTO & "," & Constantes.LINEA_INSUMO_Y_MEDICAMENTO)
            General.busquedaItems(ConsultasAsis.BUSQUEDA_MEDICAMENTO_FACT, params, TitulosForm.BUSQUEDA_MEDICAMENTO, dgv,
                                  objFactura.dtMedicamentos, 0, 2, dgv.Columns("dgDescripcionMed").Index,
                                  True, True, 0, True, AddressOf llenarMedicamento)
        End If
    End Sub
    Private Sub llenarMedicamento()
        dgvMedicamentos.ReadOnly = False
        dgvMedicamentos.Columns("dgCodigoMed").ReadOnly = True
        dgvMedicamentos.Columns("dgCodigoEquiMed").ReadOnly = True
        dgvMedicamentos.Columns("dgDescripcionMed").ReadOnly = True
        dgvMedicamentos.Columns("dgPrecioMed").ReadOnly = True
        dgvMedicamentos.Columns("dgValorMed").ReadOnly = True
        dgvMedicamentos.Columns("dgCantidadMed").ReadOnly = False
        objFactura.buscarPrecioMed(objFactura.dtMedicamentos)
        dgvMedicamentos.Rows(dgvMedicamentos.Rows.Count - 1).Cells("dgCantidadMed").ReadOnly = True
        dgvMedicamentos.Rows(dgvMedicamentos.Rows.Count - 2).Cells("dgCantidadMed").Selected = True
    End Sub
    Private Sub dgvins_CellDoubleClick(dgv As DataGridView, e As DataGridViewCellEventArgs) Handles dgvInsumos.CellDoubleClick
        If btguardar.Enabled = False OrElse dgv.RowCount = 0 Then
            Exit Sub
        End If
        If (dgv.Rows(dgv.CurrentCell.RowIndex).Cells("dgDescripcionInsu").Selected = True _
             OrElse dgv.Rows(dgv.CurrentCell.RowIndex).Cells("dgCodigoEquiIns").Selected = True) _
                And objFactura.dtInsumos.Rows(dgv.CurrentCell.RowIndex).Item("Código").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(objFactura.codigoContrato)
            params.Add(Constantes.LINEA_INSUMO & "," & Constantes.LINEA_INSUMO_Y_MEDICAMENTO & "," & Constantes.LINEA_MATERIAL_MEDICO_QUIRURGICO &
                        "," & Constantes.LINEA_ALIMENTOS & "," & Constantes.LINEA_CATETER_UMBILICAL & "," & Constantes.LINEA_ASEO &
                        "," & Constantes.LINEA_MATERIAL_OFICINA & "," & Constantes.LINEA_LIQUIDO_GRAN_VOLUMEN)
            General.busquedaItems(ConsultasAsis.BUSQUEDA_MEDICAMENTO_FACT, params, TitulosForm.BUSQUEDA_MEDICAMENTO, dgv,
                                  objFactura.dtInsumos, 0, 2, dgv.Columns("dgDescripcionInsu").Index,
                                  True, True, 0, True, AddressOf llenarInsumo)
        ElseIf dgv.Rows(dgv.CurrentCell.RowIndex).Cells("anularInsu").Selected = True _
            And objFactura.dtInsumos.Rows(dgv.CurrentCell.RowIndex).Item("Código").ToString <> "" Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                dgv.DataSource.Rows.RemoveAt(dgv.CurrentCell.RowIndex)
            End If
        End If
    End Sub
    Private Sub dgvInsumos_KeyDown(dgv As DataGridView, e As KeyEventArgs) Handles dgvInsumos.KeyDown
        If btguardar.Enabled = False OrElse dgv.RowCount = 0 Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 And objFactura.dtInsumos.Rows(dgv.CurrentCell.RowIndex).Item("Código").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(objFactura.codigoContrato)
            params.Add(Constantes.LINEA_INSUMO & "," & Constantes.LINEA_INSUMO_Y_MEDICAMENTO & "," & Constantes.LINEA_MATERIAL_MEDICO_QUIRURGICO &
                        "," & Constantes.LINEA_ALIMENTOS & "," & Constantes.LINEA_CATETER_UMBILICAL & "," & Constantes.LINEA_ASEO &
                        "," & Constantes.LINEA_MATERIAL_OFICINA & "," & Constantes.LINEA_LIQUIDO_GRAN_VOLUMEN)
            General.busquedaItems(ConsultasAsis.BUSQUEDA_MEDICAMENTO_FACT, params, TitulosForm.BUSQUEDA_MEDICAMENTO, dgv,
                                  objFactura.dtInsumos, 0, 2, dgv.Columns("dgDescripcionInsu").Index,
                                  True, True, 0, True, AddressOf llenarInsumo)
        End If
    End Sub
    Private Sub llenarInsumo()
        dgvInsumos.ReadOnly = False
        dgvInsumos.Columns("dgCodigoInsu").ReadOnly = True
        dgvInsumos.Columns("dgCodigoEquiIns").ReadOnly = True
        dgvInsumos.Columns("dgDescripcionInsu").ReadOnly = True
        dgvInsumos.Columns("dgPrecioIn").ReadOnly = True
        dgvInsumos.Columns("dgValorIn").ReadOnly = True
        dgvInsumos.Columns("dgCantidadInsu").ReadOnly = False
        objFactura.buscarPrecioMed(objFactura.dtInsumos)
        dgvInsumos.Rows(dgvInsumos.Rows.Count - 1).Cells("dgCantidadInsu").ReadOnly = True
        dgvInsumos.Rows(dgvInsumos.Rows.Count - 2).Cells("dgCantidadInsu").Selected = True
    End Sub

    Private Sub rb_CheckedChanged(sender As Object, e As EventArgs) Handles rbPEM.CheckedChanged, rbTotal.CheckedChanged
        objFactura.limpiarTablas()
        lblValorTotalFactura.Text = ""
        txtObservacion.Text = ""
        If rbManual.Checked = True Then
            fechaFin.Enabled = False
            fechaInicio.Enabled = False
            btBuscarPEMs.Enabled = False
            habilitarDGV()
            objFactura.facturaManual = True
            btguardar.Enabled = True
            btBuscarPEMs.Visible = False
            chkExterno.Visible = False
            chkExternoAuditoria.Visible = False
        Else
            btBuscarPEMs.Enabled = True
            fechaFin.Enabled = True
            fechaInicio.Enabled = True
            objFactura.facturaManual = False
            btguardar.Enabled = False
            btBuscarPEMs.Visible = True
            rbPEM.Location = New Point(rbManual.Location.X - 15, rbManual.Location.Y)
            rbTotal.Location = New Point(95, 23)
            Label3.Location = New Point(95, 24)
            fechaInicio.Location = New Point(180, 20)
            Label4.Location = New Point(280, 24)
            fechaFin.Location = New Point(350, 20)
            btBuscarPEMs.Location = New Point(457, 47)
            chkExterno.Location = New Point(460, 24)
            chkExternoAuditoria.Location = New Point(530, 24)
            chkExternoAuditoria.Enabled = False
            rbPEM.Visible = False
            chkExterno.Visible = True
            chkExternoAuditoria.Visible = True
        End If
        dgvMedicamentos.Columns("dgCodigoMed").Visible = False
        dgvInsumos.Columns("dgCodigoInsu").Visible = False
    End Sub

    Private Sub dgv_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvParaclinicos.EditingControlShowing, dgvHemoderivados.EditingControlShowing,
                                                                                                                    dgvProcedimientos.EditingControlShowing, dgvMedicamentos.EditingControlShowing,
                                                                                                                    dgvInsumos.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivoNo0
    End Sub

    Private Sub dgvParaclinicos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvParaclinicos.DataError, dgvHemoderivados.DataError,
                                                                                                         dgvProcedimientos.DataError, dgvMedicamentos.DataError,
                                                                                                         dgvInsumos.DataError
        MsgBox(Mensajes.CANTIDAD_VALIDA, MsgBoxStyle.Exclamation)
    End Sub

    Private Sub dgvParaclinicos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvParaclinicos.CellEndEdit, dgvParaclinicos.CellClick,
                                                                                                      dgvHemoderivados.CellEndEdit, dgvHemoderivados.CellClick,
                                                                                                      dgvProcedimientos.CellEndEdit, dgvProcedimientos.CellClick,
                                                                                                      dgvMedicamentos.CellEndEdit, dgvMedicamentos.CellClick,
                                                                                                      dgvInsumos.CellEndEdit, dgvInsumos.CellClick,
                                                                                                      dgvParaclinicos.CellEnter, dgvHemoderivados.CellEnter,
                                                                                                      dgvProcedimientos.CellEnter, dgvMedicamentos.CellEnter,
                                                                                                      dgvInsumos.CellEnter
        For i = 0 To sender.datasource.rows.count - 2
            If String.IsNullOrEmpty(sender.datasource.rows(i).item("Cantidad").ToString) Then
                sender.datasource.rows(i).item("Cantidad") = 0
            End If
            sender.datasource.rows(i).item("Total") = sender.datasource.rows(i).item("Cantidad") * sender.datasource.rows(i).item("Precio unitario")
        Next
        objFactura.calcularTotal()

        lblValorTotalFactura.Text = CDbl(objFactura.totalFactura).ToString(retornarFormato())
        dgvParaclinicos.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub
    Function retornarFormato()
        Dim formato As String = "C2"
        If objFactura.tipo = ConstantesAsis.TIPO_FACTURA_ASISTENCIAL OrElse ConstantesAsis.TIPO_FACTURA_ASISTENCIAL_CTC Then
            formato = "C0"
        End If
        Return formato
    End Function
    Private Sub btRemisiones(sender As Object, e As EventArgs) Handles btBuscarRemision.Click
        Try
            cargarPendientes()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub cargarPendientes()
        GroupBox1.Enabled = False
        ToolStrip1.Enabled = False
        panelRemisiones.Visible = True
        panelRemisiones.BringToFront()
        gbInformacionRemision.Enabled = False
        gbInformacionPEM.Enabled = False
        If String.IsNullOrEmpty(objFactura.codigoFactura) Then
            If objFactura.TIPO = 2 Then
                objFactura.fechaInicio = fechaInicio.Value
                objFactura.fechaFin = fechaFin.Value
                objFactura.consolidado = chkExterno.Checked
                objFactura.consolidadoAuditoria = chkExternoAuditoria.Checked
            End If
            objFactura.cargarPendientes()
        Else
            objFactura.cargarFacturadas()
        End If
        PictureBox2.Image = Celer.My.Resources.Resources.Actions_go_down_icon
        PictureBox3.Image = Celer.My.Resources.Resources.Actions_go_up_icon
        GroupBox2.Visible = False
        If objFactura.consolidado Then
            dgvConsolidado.DataSource = objFactura.dtConsolidado
            GroupBox2.Visible = True
        End If

    End Sub
    Private Sub btAtenciones(sender As Object, e As EventArgs) Handles btBuscarPEMs.Click
        If String.IsNullOrEmpty(textcodcontrato.Text) Then
            Exit Sub
        End If
        If chkExterno.Checked Then
            Dim dtFacturas As New DataTable
            Dim params As New List(Of String)
            objFactura.fechaInicio = fechaInicio.Value
            objFactura.fechaFin = fechaFin.Value
            params.Add(Format(objFactura.fechaInicio, Constantes.FORMATO_FECHA_ACTUAL))
            params.Add(Format(objFactura.fechaFin, Constantes.FORMATO_FECHA_ACTUAL))
            params.Add(objFactura.codigoContrato)
            General.llenarTabla(objFactura.periodoVerificar, params, dtFacturas)
            Dim facturas As String
            If dtFacturas.Rows.Count > 0 Then
                For i = 0 To dtFacturas.Rows.Count - 1
                    facturas += vbCrLf & vbCrLf & "Factura: " & dtFacturas.Rows(i).Item("Codigo_Factura") & ", Periodo: " & dtFacturas.Rows(i).Item("Fecha_inicio") & " - " & dtFacturas.Rows(i).Item("Fecha_Fin")
                Next
                MsgBox("¡Periodo inválido!" & facturas, MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If
        Try
            cargarPendientes()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles tsGuardar.Click
        panelRemisiones.Visible = False
        GroupBox1.Enabled = True
        ToolStrip1.Enabled = True
        objFactura.cargarDetalle()
        If objFactura.TIPO = 2 Then
            gbInformacionPEM.Enabled = True
            dgvMedicamentos.Columns("dgCodigoMed").Visible = False
            dgvInsumos.Columns("dgCodigoInsu").Visible = False
        Else
            gbInformacionRemision.Enabled = True
            lblValorTotalIVA.Text = CDbl(objFactura.valorIVA).ToString("C2")
            dgvMedicamentosRem.Columns("dgCodigoProMed").Visible = False
            dgvInsumosRem.Columns("dgCodigoProIns").Visible = False
        End If
        concatenarAFacturar()

        If (objFactura.dtAFacturar.rows.count > 0 OrElse objFactura.dtConsolidado.rows.count > 0) And String.IsNullOrEmpty(objFactura.codigoFactura) Then
            btguardar.Enabled = True
            If chkExterno.Checked Then
                'btguardar.Enabled = False 'esto lo quito cuando estè listo

            End If
            objFactura.calcularTotal()
            validar()
        Else
            objFactura.calcularTotal()
            btguardar.Enabled = False
        End If
        lblValorTotalFactura.Text = CDbl(objFactura.totalFactura).ToString("C2")
        dgvParaclinicos.DataSource = objFactura.dtParaclinicos
        dgvMedicamentos.DataSource = objFactura.dtMedicamentos
        dgvInsumos.DataSource = objFactura.dtInsumos
    End Sub
    Private Sub concatenarAFacturar()
        Dim documentos As String = ""
        For i = 0 To objFactura.dtAFacturar.rows.count - 1
            documentos = documentos & objFactura.dtAFacturar.rows(i).item(0).ToString & ", "
        Next
        objFactura.listaDocumentos = documentos
    End Sub
    Private Sub IntercambiarRegistroLista(ByRef dtOrigen As DataTable, ByRef dtDestino As DataTable, posicionLista As Integer)

        Dim filaNueva As DataRow = dtDestino.NewRow
        Dim filaCopia As DataRow = dtOrigen.Rows(posicionLista)
        For i = 0 To filaCopia.ItemArray.Count - 1
            filaNueva(i) = filaCopia(i)
        Next
        dtDestino.Rows.InsertAt(filaNueva, dtDestino.Rows.Count)
        dtOrigen.Rows.RemoveAt(posicionLista)
    End Sub

    Private Sub dgv_CellDoubleClick(dgv As DataGridView, e As DataGridViewCellEventArgs) Handles dgvPendiente.CellDoubleClick, dgvRemision.CellDoubleClick
        If tsGuardar.Enabled = True AndAlso dgv.RowCount > 0 Then
            If dgvPendiente.Focused = True Then
                IntercambiarRegistroLista(objFactura.dtPendiente, objFactura.dtAFacturar, e.RowIndex)
            Else
                IntercambiarRegistroLista(objFactura.dtAFacturar, objFactura.dtPendiente, e.RowIndex)
            End If
        End If
    End Sub

    Private Sub dgvPendiente_CellFormatting(dgv As DataGridView, e As DataGridViewCellFormattingEventArgs) Handles dgvPendiente.CellFormatting, dgvRemision.CellFormatting
        If objFactura.TIPO = ConstantesAsis.TIPO_FACTURA_REMISION Then

            If e.ColumnIndex = 3 Then
                e.Value = Format(CDate(e.Value).Date, "yyyy-MM-dd")
            ElseIf e.ColumnIndex = 2 AndAlso e.Value = 0 Then
                e.Value = Format("", "")
            ElseIf e.ColumnIndex > 3 Then
                If IsDBNull(e.Value) Then
                    e.Value = 0
                End If
                e.Value = CDbl(e.Value).ToString("c2")
            End If
        Else
            If e.ColumnIndex = 2 Then
                e.Value = Format(CDate(e.Value).Date, "yyyy-MM-dd")
            End If
        End If

    End Sub
    Private Sub dgv2_CellFormatting(dgv As DataGridView, e As DataGridViewCellFormattingEventArgs) Handles dgvMedicamentosRem.CellFormatting, dgvInsumosRem.CellFormatting
        If e.ColumnIndex = 5 Then
            e.Value = CDbl(e.Value / 100).ToString("P2")
        ElseIf e.ColumnIndex > 5 Then
            e.Value = CDbl(e.Value).ToString("c2")
        End If
    End Sub

    Private Sub tsActualizar_Click(sender As Object, e As EventArgs) Handles tsActualizar.Click
        recalcular()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btBuscarPEMs.Click

    End Sub

    Private Sub PictureDown(sender As PictureBox, e As EventArgs) Handles PictureBox2.Click
        If tsGuardar.Enabled = True Then

            For I = 0 To objFactura.dtPendiente.Rows.Count - 1
                IntercambiarRegistroLista(objFactura.dtPendiente, objFactura.dtAFacturar, 0)
            Next

        End If
    End Sub
    Private Sub PictureUp(sender As PictureBox, e As EventArgs) Handles PictureBox3.Click
        If tsGuardar.Enabled = True Then

            For I = 0 To objFactura.dtAFacturar.Rows.Count - 1
                IntercambiarRegistroLista(objFactura.dtAFacturar, objFactura.dtPendiente, 0)
            Next

        End If
    End Sub

    Private Sub btExonerar_Click(sender As Object, e As EventArgs) Handles btExonerar.Click
        gbMotivo.Visible = True
        GroupBox1.Enabled = False
        gbMotivo.BringToFront()
        ToolStrip1.Enabled = False
        btExonerar.Enabled = False
        txtMotivo.Enabled = True
        txtMotivo.ReadOnly = False
        txtMotivo.Clear()
        lblValorTotalFactura.Enabled = True
        General.habilitarBotones(ToolStrip3)
    End Sub

    Private Sub tsCancelarMotivo_Click(sender As Object, e As EventArgs) Handles tsCancelarMotivo.Click
        gbMotivo.Visible = False
        GroupBox1.Enabled = True
        ToolStrip1.Enabled = True
        btExonerar.Enabled = True
    End Sub

    Private Sub tsGuardarMotivo_Click(sender As Object, e As EventArgs) Handles tsGuardarMotivo.Click
        If txtMotivo.TextLength = 0 Then
            MsgBox(Mensajes.EXONERAR_SIN_MOTIVO, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        objFactura.observacion = txtMotivo.Text
        objFactura.exonerar()
        cargarContrato(objFactura.codigoContrato)
        btExonerar.Visible = False
        gbMotivo.Visible = False
        GroupBox1.Enabled = True
        ToolStrip1.Enabled = True
        MsgBox(Mensajes.EXONERAR_FACTURA, MsgBoxStyle.Information)
    End Sub

    Private Sub chkExterno_CheckedChanged(sender As Object, e As EventArgs) Handles chkExterno.CheckedChanged, chkExternoAuditoria.CheckedChanged
        cambiarDescripcion()
    End Sub
    Private Sub cambiarDescripcion()

        If chkExterno.Checked Then
            btBuscarPEMs.Text = "Cargar Consolidado Externo"
            chkExternoAuditoria.Enabled = True
        Else
            btBuscarPEMs.Text = "Seleccionar Atenciones"
            chkExternoAuditoria.Checked = False
            chkExternoAuditoria.Enabled = False
        End If

        If Not IsNothing(objFactura.tipo) Then
            If objFactura.tipo = 2 Then
                objFactura.dtAFacturar.Clear()
                lblValorTotalFactura.Text = CDbl(objFactura.totalFactura).ToString("C2")
            End If
            If dgvParaclinicos.RowCount > 0 OrElse dgvMedicamentos.RowCount > 0 OrElse dgvInsumos.RowCount > 0 Then
                General.limpiarControles(gbDetalleServicios)
            End If
            objFactura.dtConsolidado.clear
            lblValorTotalFactura.Text = CDbl(0).ToString("C2")
        End If


    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRemision.CellDoubleClick, dgvPendiente.CellDoubleClick

    End Sub

    Private Sub dgvPendiente_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvRemision.CellFormatting, dgvPendiente.CellFormatting

    End Sub

    Private Sub fechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles fechaInicio.ValueChanged, fechaFin.ValueChanged
        If cargando OrElse Visible = False Then Exit Sub
        cambiarDescripcion()
    End Sub

    Private Sub fechaInicio_Validated(sender As Object, e As EventArgs) Handles fechaInicio.Validated, fechaFin.Validated
        If cargando OrElse Visible = False Then Exit Sub
        cambiarDescripcion()
    End Sub

    Private Sub tsCancelar_Click(sender As Object, e As EventArgs) Handles tsCancelar.Click
        panelRemisiones.Visible = False
        GroupBox1.Enabled = True
        ToolStrip1.Enabled = True
        gbInformacionPEM.Enabled = True
    End Sub

    Private Sub btSoportes_Click(sender As Object, e As EventArgs) Handles btSoportes.Click
        Cursor = Cursors.WaitCursor
        btSoportes.Enabled = False
        Try
            If objFactura.tipo = ConstantesAsis.TIPO_FACTURA_ASISTENCIAL OrElse objFactura.tipo = ConstantesAsis.TIPO_FACTURA_ASISTENCIAL_CTC Then
                objFactura.fechaEgreso = txtFechaEgreso.Text
            End If
            objFactura.imprimirSoporte()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btSoportes.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsExcel.Click
        Try
            tsExcel.Enabled = False
            Dim nombreRpt As String = "consolidado"
            Dim params As New List(Of String)

            Cursor = Cursors.WaitCursor
            params.Add(objFactura.codigoFactura)
            params.Add(SesionActual.idEmpresa)

            General.llenarTabla(If(tsExcel.Tag = 1, "PROC_CONSOLIDADO_ATENCION_SOPORTE_CARGAR", "PROC_CONSOLIDADO_EXTERNO_SOPORTE_CARGAR"), params, objFactura.dtConsolidadoPaciente)
            Dim rutaArchivo As String = FuncionesExcel.exportarDataTable(objFactura.dtConsolidadoPaciente, nombreRpt)

            Process.Start("file:///" & rutaArchivo)
        Catch ex As Exception
            General.manejoErrores(ex)
        Finally
            Cursor = Cursors.Default
            tsExcel.Enabled = True
        End Try
    End Sub

    Private Sub tsExportarFactura_Click(sender As Object, e As EventArgs) Handles tsExportarFactura.Click
        Try
            tsExportarFactura.Enabled = False
            Dim nombreRpt As String = "Detalle"
            Dim params As New List(Of String)

            Cursor = Cursors.WaitCursor
            Dim dtDetalle, dtMedicamentos, dtInsumos As New DataTable

            dtDetalle = objFactura.dtParaclinicos.clone
            dtDetalle.Columns.Add("Tipo")
            If Not objFactura.tipo = ConstantesAsis.TIPO_FACTURA_EXTERNA Then
                copiarDatos(dtDetalle, objFactura.dtEstancias, "Estancias")
                copiarDatos(dtDetalle, objFactura.dtOxigenos, "Oxigeno")
                copiarDatos(dtDetalle, objFactura.dtTraslados, "Traslados")
            End If
            copiarDatos(dtDetalle, objFactura.dtHemoderivados, "Hemoderivados")
            copiarDatos(dtDetalle, objFactura.dtParaclinicos, "Paraclinicos")
            copiarDatos(dtDetalle, objFactura.dtProcedimientos, "Procedimientos")
            dtMedicamentos = objFactura.dtMedicamentos.copy
            dtInsumos = objFactura.dtInsumos.copy
            dtMedicamentos.Columns.RemoveAt(0)
            dtInsumos.Columns.RemoveAt(0)
            dtMedicamentos.Columns("Código Equivalencia").SetOrdinal(0)
            dtInsumos.Columns("Código Equivalencia").SetOrdinal(0)
            copiarDatos(dtDetalle, dtMedicamentos, "Medicamentos")
            copiarDatos(dtDetalle, dtInsumos, "Insumos")
            Dim rutaArchivo As String = FuncionesExcel.exportarDataTable(dtDetalle, nombreRpt)

            Process.Start("file:///" & rutaArchivo)
        Catch ex As Exception
            General.manejoErrores(ex)
        Finally
            Cursor = Cursors.Default
            tsExportarFactura.Enabled = True
        End Try
    End Sub
    Private Sub copiarDatos(ByRef dtDestino As DataTable, dtOrigen As DataTable, tipo As String)
        For i = 0 To dtOrigen.Rows.Count - 1
            dtDestino.Rows.Add()
            For j = 0 To dtDestino.Columns.Count - 2
                dtDestino.Rows(dtDestino.Rows.Count - 1).Item(j) = dtOrigen.Rows(i).Item(j)
            Next
            dtDestino.Rows(dtDestino.Rows.Count - 1).Item("Tipo") = tipo
        Next
    End Sub
End Class