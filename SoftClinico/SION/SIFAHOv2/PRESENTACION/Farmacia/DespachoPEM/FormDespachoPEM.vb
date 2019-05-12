Imports System.Threading
Public Class FormDespachoPEM
    Dim objDespachoPem As DespachoPEM
    Dim perG As New Buscar_Permisos_generales
    Dim permisoGeneral, pNuevo, pEditar, pAnular, pBuscar, pConsolidar As String
    Private Sub FormDespachoPEM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarForm()
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
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
    Private Sub cmbTipoPedido_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoPedido.SelectedIndexChanged
        If cmbTipoPedido.SelectedIndex > 0 Then
            limpiarCajasPems()
            getTipoPedido()
        End If
    End Sub
#Region "Botones"
    Private Sub ImprimirEtiquetasMedicamentoExternoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirEtiquetasMedicamentoExternoToolStripMenuItem.Click
        imprimir(Constantes.REPORTE_ETIQUETAS_MEDICAMENTOS_EXTERNO)
    End Sub
    Private Sub ImprimirEtiquetasMedicamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirEtiquetasMedicamentoToolStripMenuItem.Click
        imprimir(Constantes.REPORTE_ETIQUETAS_MEDICAMENTOS)
    End Sub
    Private Sub ImprimirEtiquetasMedicamentoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ImprimirEtiquetasMedicamentoToolStripMenuItem1.Click
        imprimir(Constantes.REPORTE_ETIQUETAS_INFUSIONES)
    End Sub
    Private Sub BtnConsolidar_Click(sender As Object, e As EventArgs) Handles BtnConsolidar.Click
        If SesionActual.tienePermiso(pConsolidar) Then
            If verificarSeleccionPems() Then
                Cursor = Cursors.WaitCursor
                consolidarPems()
                btPemInicio.Enabled = False
                btPemFin.Enabled = False
                cmbTipoPedido.Enabled = False
                cmbAreas.Enabled = False
                Cursor = Cursors.Default
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(pNuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            cmbAreas.Enabled = False
            limpiarCajasPems()
            limpiarTablas()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(pBuscar) Then
            Dim params As New List(Of String)
            params.Add(Nothing)
            General.buscarElemento(Consultas.DESPACHO_PEM_BUSCAR,
                                   params,
                                   AddressOf cargarDeapchoPem,
                                   TitulosForm.BUSQUEDA_DESPACHO_PEM,
                                   True,
                                   Constantes.TAMANO_MEDIANO,
                                   True)

        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(pAnular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + vbYesNo) = MsgBoxResult.Yes Then
                Try
                    empalmarDisenoToObjeto()
                    Dim objDespachoPemBLL As New DespachoPEMBLL
                    objDespachoPemBLL.anularDespachoPEM(objDespachoPem, SesionActual.idUsuario)
                    General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btndetallado_Click(sender As Object, e As EventArgs) Handles btndetallado.Click
        If PnlDetallado.Visible = True Then
            PnlDetallado.Visible = False
        Else
            configurarDgvDetallado()
            PnlDetallado.BringToFront()
            PnlDetallado.Visible = True
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarForm() Then
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Try
                    empalmarDisenoToObjeto()
                    Dim objDespachoPemBLL As New DespachoPEMBLL
                    objDespachoPemBLL.guardarDespachoPEM(objDespachoPem, SesionActual.idUsuario, SesionActual.codigoEP)
                    General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, btanular, Nothing)
                    cargarDeapchoPem(objDespachoPem.codigoDespachoPEM)
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar) Then
            PnlDetallado.Visible = False
            valoresDefaulTexboxCalculos()
            limpiarTablas()
        End If
    End Sub
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Dim dgv As DataGridView = obtenerGrillaActual()
        Dim nombreTabla As String = objDespachoPem.nombrarTabla(getFilaActualDgv(), getCodigoFilaActual(), If(dgv.Equals(dgvMedicamentos), Constantes.GRILLA_MEDICAMENTOS, Constantes.GRILLA_INSUMOS))
        If objDespachoPem.verificarExistenciaTabla(nombreTabla) Then
            Dim cantidadLotesUtilizados As Integer
            cantidadLotesUtilizados = If(IsDBNull(objDespachoPem.tblLotes.Tables(nombreTabla).Select("cantidadDespachada>0", "").Count), 0, objDespachoPem.tblLotes.Tables(nombreTabla).Select("cantidadDespachada>0", "").Count)
            If cantidadLotesUtilizados = 0 Then
                objDespachoPem.quitarTabla(nombreTabla)
            End If
        End If
        panelBodegas.Visible = False
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        Dim reporte As New rptEtiquetaMedicamentos
        Try
            Dim tbl As New Hashtable
            tbl.Add("@pCodigoDespachoPem", objDespachoPem.codigoDespachoPEM)
            Funciones.getReporteNoFTP(reporte, Nothing, "", Constantes.FORMATO_PDF, tbl)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub btPemInicio_Click(sender As Object, e As EventArgs) Handles btPemInicio.Click
        If cmbTipoPedido.SelectedIndex > 0 Then
            buscarPemInicio()
        Else
            MsgBox("Debe elegir el tipo de pedido !", MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btPemFin_Click(sender As Object, e As EventArgs) Handles btPemFin.Click
        If cmbTipoPedido.SelectedIndex > 0 Then
            If txtPemInicio.Text <> "" Then
                BuscarPemFinal()
            Else
                MsgBox("Debe colocar el PEM inicial !", MsgBoxStyle.Exclamation)
            End If
        Else
            MsgBox("Debe elegir el tipo de pedido !", MsgBoxStyle.Exclamation)
        End If

    End Sub
#End Region
#Region "controles Generales"
    Function getTipoPedido() As Boolean
        If cmbTipoPedido.SelectedValue = 1 Then
            cmbAreas.Enabled = False
            Return False
        Else
            cmbAreas.Enabled = True
            Return True
        End If
    End Function
    Private Sub txtBusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtBusqueda.TextChanged
        Dim consulta As String
        If (objDespachoPem.swtGrilla = Constantes.GRILLA_MEDICAMENTOS) Then
            consulta = Consultas.DESPACHO_PEM_CARGAR_MEDICAMENTOS_LOTES_DISPONIBLES_BODEGA_COMERCIAL
        Else
            consulta = Consultas.DESPACHO_PEM_CARGAR_INSUMOS_LOTES_DISPONIBLES_BODEGA_COMERCIAL
        End If



        cargarLotesDisponible(consulta,
                              objDespachoPem.tablaBusqueda,
                              txtBusqueda.Text,
                              Consultas.DESPACHO_PEM_CARGAR_MEDICAMENTOS_LOTES_DISPONIBLES_BODEGA_PREPARACION,
                              objDespachoPem.tablaBusquedaPreparacion)
    End Sub
    Private Sub cmbAreas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAreas.SelectedIndexChanged
        limpiarCajasPems()
    End Sub
#End Region
#Region "Metodos"
    Sub configurarDgvBodegasDistintas(ByVal tbl As DataTable)
        With dgvBodegasDiferentes
            .Columns("codigo_EP").DataPropertyName = "codigo_EP"
            .Columns("Empresa").DataPropertyName = "Empresa"
            .Columns("Punto").DataPropertyName = "Punto"
            .AutoGenerateColumns = False
            .DataSource = tbl
            .ReadOnly = True
        End With

    End Sub
    Sub limpiarCajasPems()
        txtPemInicio.ResetText()
        txtPemFinal.ResetText()
        txtPemInicio.ReadOnly = True
        txtPemFinal.ReadOnly = True
    End Sub
    Sub imprimir(ByRef codigoReporte As Integer)
        Cursor = Cursors.WaitCursor
        Dim reporte = objDespachoPem.tablahas.Item(codigoReporte)
        Try
            Dim tbl As New Hashtable
            tbl.Add("@pCodigoDespachoPem", objDespachoPem.codigoDespachoPEM)
            Funciones.getReporteNoFTP(reporte, Nothing, "", Constantes.FORMATO_PDF, tbl)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub
    Sub llenarLotesGuardados(ByVal consulta As String, ByRef tabla As DataTable, ByVal Tipo As Integer, ByVal CantidadDespachada As String, Optional ByVal ConcnetracionDespachada As String = "")
        Dim codigoFilaActual As Integer = getCodigoFilaActual()
        Dim filaActual As Integer = getFilaActualDgv()
        Dim nombreTabla As String = objDespachoPem.nombrarTabla(codigoFilaActual, filaActual, Tipo)
        objDespachoPem.agregarTabla(nombreTabla)

        Dim params As New List(Of String)
        params.Add(objDespachoPem.codigoDespachoPEM)
        params.Add(codigoFilaActual)
        General.llenarTabla(consulta, params, objDespachoPem.tblLotes.Tables(nombreTabla))
        configurarDgvLotesDisponiblesBodegaComercial(objDespachoPem.tblLotes.Tables(nombreTabla))
        configuracionPanelDespacho(filaActual, tabla, CantidadDespachada, ConcnetracionDespachada)
        objDespachoPem.calcularConcentracionesDespachada(filaActual, codigoFilaActual, Tipo)
        asignarValoresDespachados()
        calcularConcentracionDeDespacho()
        configuracionTamañoPanel()
        panelBodegas.BringToFront()
        panelBodegas.Visible = True
    End Sub
    Sub limpiarTablas()
        objDespachoPem.tablaListadoDetalladoPEM.Clear()
        objDespachoPem.tablaBodegaVirtual.Clear()
        objDespachoPem.tblLotes.Reset()
        objDespachoPem.tablainsumos.Clear()
        objDespachoPem.tablaMedicamentos.Clear()
        objDespachoPem.tablaSobranteMed.Clear()
    End Sub
    Sub empalmarObjetoToDiseno()
        cmbAreas.SelectedValue = objDespachoPem.codigoAreaServicio
        txtCodigo.Text = objDespachoPem.codigoDespachoPEMPunto
        txtPemInicio.Text = objDespachoPem.codigoPEMInicio
        txtPemFinal.Text = objDespachoPem.codigoPemFin
        dtpFechaDespachoPem.Value = objDespachoPem.fechaDespachoPEM
    End Sub
    Sub empalmarDisenoToObjeto()
        objDespachoPem.codigoDespachoPEMPunto = txtCodigo.Text
        objDespachoPem.codigoPEMInicio = txtPemInicio.Text
        objDespachoPem.codigoPemFin = txtPemFinal.Text
        objDespachoPem.codigoAreaServicio = cmbAreas.SelectedValue
        objDespachoPem.fechaDespachoPEM = dtpFechaDespachoPem.Value
    End Sub
    Sub cargarDeapchoPem(ByVal codigo As Integer)
        limpiarTablas()
        objDespachoPem.codigoDespachoPEM = codigo
        Dim params As New List(Of String)
        params.Add(objDespachoPem.codigoDespachoPEM)
        Dim fila As DataRow
        fila = General.cargarItem(Consultas.DESPACHO_PEM_CARGAR, params)

        objDespachoPem.codigoDespachoPEMPunto = fila.Item("Codigo_Despacho_PEM_Punto")
        objDespachoPem.codigoPEMInicio = fila.Item("Codigo_PEM_Inicio")
        objDespachoPem.codigoPemFin = fila.Item("Codigo_PEM_Final")
        objDespachoPem.fechaDespachoPEM = fila.Item("Fecha_Despacho_PEM")

        fila = Nothing

        params.Clear()
        params.Add(objDespachoPem.codigoPEMInicio)
        params.Add(objDespachoPem.codigoPemFin)
        fila = General.cargarItem(Consultas.DESPACHO_PEM_CARGAR_AREA, params)

        objDespachoPem.codigoAreaServicio = fila.Item("Codigo")

        params.Clear()
        params.Add(objDespachoPem.codigoDespachoPEM)
        General.llenarTabla(Consultas.DESPACHO_PEM_CARGAR_MEDICAMENTOS_GUARDADOS,
                            params,
                            objDespachoPem.tablaMedicamentos, True)
        params.Clear()
        params.Add(objDespachoPem.codigoDespachoPEM)
        General.llenarTabla(Consultas.DESPACHO_PEM_CARGAR_INSUMOS_GUARDADOS,
                            params,
                            objDespachoPem.tablainsumos, True)
        params.Clear()
        params.Add(objDespachoPem.codigoDespachoPEM)
        General.llenarTabla(Consultas.DESPACHO_PEM_CARGAR_DETALLADO_GUARDADO,
                             params,
                             objDespachoPem.tablaListadoDetalladoPEM,
                             True)

        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, btanular, Nothing)
        empalmarObjetoToDiseno()
        ToolStripDropDownButton1.Enabled = True
        btndetallado.Enabled = True
   
    End Sub
    Sub aceptarCambiosDgvLotes(ByVal filaActual As Integer,
                               ByVal codigoEquivalencia As Integer)
        confirmarCambiosEnGrillas()
        objDespachoPem.guardarDespachoTemporal(filaActual, codigoEquivalencia, CInt(txtCantidadPedida.Text), CDbl(txtConcePed.Text), If(obtenerGrillaActual().Equals(dgvMedicamentos), Constantes.GRILLA_MEDICAMENTOS, Constantes.GRILLA_INSUMOS))
        registrarDespachoEnDgvPrincipal()
        objDespachoPem.distribucionDeConcentracionesDeapchadasPem(codigoEquivalencia, If(objDespachoPem.swtGrilla = Constantes.GRILLA_MEDICAMENTOS, objDespachoPem.tablaMedicamentos.Rows(filaActual).Item("Concen_Desp"), objDespachoPem.tablainsumos.Rows(filaActual).Item("CantidadDespachada")), True)
    End Sub
    Sub confirmarCambiosEnGrillas()
        dgvLotesDisponiblesbodegaComercial.CommitEdit(DataGridViewDataErrorContexts.Commit)
        dgvLotesDisponiblesbodegaComercial.EndEdit()
        dgvMedicamentos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        dgvMedicamentos.EndEdit()
        dgvInsumos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        dgvInsumos.EndEdit()
    End Sub
    Sub definirSoloInsumos()
        dgvLotesDisponiblesbodegaComercial.BringToFront()
        dgvLotesDisponiblesbodegaComercial.Size = New Size(1246, 396)
        dgvLotesDisponiblesbodegaComercial.Location = New Point(6, 49)
    End Sub
    Sub definirMedicamentosTamañoNormal()
        dgvLotesDisponiblesbodegaComercial.Size = New Size(1246, 220)
        dgvLotesDisponiblesbodegaComercial.Location = New Point(6, 247)
    End Sub
    Sub registrarDespachoEnDgvPrincipal()
        Dim filaActual, codigoEquivalencia, cantidadDespachada As Integer
        Dim cantidadFaltante, cantidadSobrante, cantidadConcentracionDespachada As Double
        Dim dgv As DataGridView = obtenerGrillaActual()
        cantidadDespachada = 0
        cantidadFaltante = 0
        cantidadSobrante = 0
        cantidadConcentracionDespachada = 0
        filaActual = getFilaActualDgv()
        codigoEquivalencia = getCodigoFilaActual()
        Dim nombreTablaLote As String = objDespachoPem.nombrarTabla(codigoEquivalencia, filaActual, If(dgv.Equals(dgvMedicamentos), Constantes.GRILLA_MEDICAMENTOS, Constantes.GRILLA_INSUMOS))
        If objDespachoPem.verificarExistenciaTabla(nombreTablaLote) Then
            cantidadDespachada = If(IsDBNull(objDespachoPem.tblLotes.Tables(nombreTablaLote).Compute("Sum(cantidadDespachada)", "codigo_interno='" & codigoEquivalencia & "'")), 0, objDespachoPem.tblLotes.Tables(nombreTablaLote).Compute("Sum(cantidadDespachada)", "codigo_interno='" & codigoEquivalencia & "'"))
            cantidadConcentracionDespachada = If(IsDBNull(objDespachoPem.tblLotes.Tables(nombreTablaLote).Compute("Sum(ConcentracionDesp)", "codigo_interno='" & codigoEquivalencia & "'")), 0, objDespachoPem.tblLotes.Tables(nombreTablaLote).Compute("Sum(ConcentracionDesp)", "codigo_interno='" & codigoEquivalencia & "'"))
            If objDespachoPem.swtGrilla = Constantes.GRILLA_MEDICAMENTOS Then
                objDespachoPem.tablaMedicamentos.Rows(filaActual).Item("Cant_Desp") = cantidadDespachada
                objDespachoPem.tablaMedicamentos.Rows(filaActual).Item("Concen_Desp") = cantidadConcentracionDespachada
            Else
                objDespachoPem.tablainsumos.Rows(filaActual).Item("CantidadDespachada") = cantidadDespachada
            End If

        End If
    End Sub
    Sub valoresDefaulTexboxCalculos()
        txtcantidadDepachada.ReadOnly = True
        txtCantidadPedida.ReadOnly = True
        txtCantidadFaltante.ReadOnly = True
        txtCantidadSobrante.ReadOnly = True
        txtConcePed.ReadOnly = True
        txtConcenFaltante.ReadOnly = True
        txtConcenSobrante.ReadOnly = True
        txtConcetDespachada.ReadOnly = True
        txtConcePed.Text = Format(0, "##,##.00")
        txtConcenFaltante.Text = Format(0, "##,##.00")
        txtConcenSobrante.Text = Format(0, "##,##.00")
        txtConcetDespachada.Text = Format(0, "##,##.00")
        txtCantidadSobrante.Text = Format(0, "##,##.00")
        txtcantidadDepachada.Text = Format(0, "##,##.00")
        txtCantidadPedida.Text = Format(0, "##,##.00")
        txtCantidadFaltante.Text = Format(0, "##,##.00")
    End Sub
    Sub calcularCantidadDeDespacho()
        Dim cantFaltante, cantSobrante, cantPedida, cantDespachada As Double
        cantPedida = If(txtCantidadPedida.Text = "", 0, CDbl(txtCantidadPedida.Text))
        cantDespachada = If(txtcantidadDepachada.Text = "", 0, CDbl(txtcantidadDepachada.Text))
        cantFaltante = If((cantPedida - cantDespachada) < 0, 0, (cantPedida - cantDespachada))
        cantSobrante = If((cantPedida - cantDespachada) > 0, 0, (cantPedida - cantDespachada) * -1)
        txtCantidadFaltante.Text = Format(cantFaltante, "##,##.00")
        txtCantidadSobrante.Text = Format(cantSobrante, "##,##.00")
        calcularConcentracionDeDespacho()
    End Sub
    Sub calcularConcentracionDeDespacho()
        Dim cantFaltante, cantSobrante, cantPedida, cantDespachada As Double
        cantPedida = If(txtConcePed.Text = "", 0, CDbl(txtConcePed.Text))
        cantDespachada = If(txtConcetDespachada.Text = "", 0, CDbl(txtConcetDespachada.Text))
        cantFaltante = If((cantPedida - cantDespachada) <= 0, 0, (cantPedida - cantDespachada))
        cantSobrante = If((cantPedida - cantDespachada) >= 0, 0, Math.Abs(cantPedida - cantDespachada))
        txtConcenFaltante.Text = Format(cantFaltante, "##,##.00")
        txtConcenSobrante.Text = Format(cantSobrante, "##,##.00")
    End Sub
    Sub asignarValoresDespachados()
        txtcantidadDepachada.Text = Format(objDespachoPem.cantidadDespachada, "##,##.00")
        If dgvInsumos.Equals(obtenerGrillaActual()) Then
            objDespachoPem.ConcentracionDespachada = 0
        End If
        txtConcetDespachada.Text = Format(objDespachoPem.ConcentracionDespachada, "##,##.00")
        calcularCantidadDeDespacho()
    End Sub
    Function mostarPanel(ByVal Consulta As String,
                         ByRef dt As DataTable,
                         Optional ByVal consultaPreparacion As String = "",
                         Optional ByRef tablaPreparacion As DataTable = Nothing) As Boolean

        Dim valorRetornado As Boolean = True
        txtBusqueda.ResetText()
        panelBodegas.BringToFront()

        If panelBodegas.Visible = True Then
            panelBodegas.Visible = False
        Else
            Dim dgvActual As DataGridView = obtenerGrillaActual()
            Dim filaActual As Integer = getFilaActualDgv()
            Dim codigoFilaActual As Integer = getCodigoFilaActual()
            Dim nombreTabla As String = objDespachoPem.nombrarTabla(codigoFilaActual, filaActual, If(dgvActual.Equals(dgvMedicamentos), Constantes.GRILLA_MEDICAMENTOS, Constantes.GRILLA_INSUMOS))
            If objDespachoPem.tblLotes.Tables.Contains(nombreTabla) Then
                configurarDgvLotesDisponiblesBodegaComercial(objDespachoPem.tblLotes.Tables(nombreTabla))
                objDespachoPem.calcularConcentracionesDespachada(filaActual, codigoFilaActual, If(dgvActual.Equals(dgvMedicamentos), Constantes.GRILLA_MEDICAMENTOS, Constantes.GRILLA_INSUMOS))
                asignarValoresDespachados()
                deshabiliarContorlesPanelDespacho()
                valorRetornado = False
            Else
                configurarDgvLotesDisponiblesBodegaComercial()
                configurarDgvLotesDisponiblesBodegaPreparacion()
                dt.Clear()
                cargarLotesDisponible(Consulta, dt, "", consultaPreparacion, tablaPreparacion)
                habiliarContorlesPanelDespacho()
            End If
            configuracionTamañoPanel()
            panelBodegas.BringToFront()
            panelBodegas.Visible = True
        End If
        Return valorRetornado
    End Function
    Sub deshabiliarContorlesPanelDespacho()
        txtBusqueda.ReadOnly = True
    End Sub
    Sub configuracionTamañoPanel()
        If Constantes.GRILLA_MEDICAMENTOS = objDespachoPem.swtGrilla Then
            definirMedicamentosTamañoNormal()
        Else
            definirSoloInsumos()
        End If
    End Sub
    Sub habiliarContorlesPanelDespacho()
        txtBusqueda.ReadOnly = False
    End Sub
    Sub cargarLotesDisponible(ByVal consulta As String,
                              ByRef dt As DataTable,
                              Optional Busqueda As String = "",
                              Optional ByVal consultaPreparacion As String = "",
                              Optional ByRef tablaPreparacion As DataTable = Nothing)

        Dim params As New List(Of String)
        Dim cadenaParametros As String = ""
        Dim filas As DataRow()
        Dim tablaTemp As New DataTable

        params.Add(Busqueda)
        params.Add(getCodigoFilaActual)
        'params.Add(SesionActual.codigoEP)
        params.Add(permisoGeneral)
        params.Add(SesionActual.codigoPerfil)

        filas = dt.Select("CantidadDespachada > 0", "")
        tablaTemp = dt.Clone
        cadenaParametros = obtenerCodigosUtilizados(filas, tablaTemp, "RegLote")


        params.Add(If(cadenaParametros = "", " ", cadenaParametros))
        General.llenarTabla(consulta, params, dt)
        dt.Merge(tablaTemp, True)

        If consultaPreparacion <> "" Then
            cadenaParametros = ""
            tablaTemp.Reset()
            tablaTemp = tablaPreparacion.Clone()
            filas = tablaPreparacion.Select("concentracionDesp > 0", "")
            cadenaParametros = obtenerCodigosUtilizados(filas, tablaTemp, "RegLote")

            params.Clear()
            params.Add(Busqueda)
            params.Add(SesionActual.codigoEP)
            params.Add(objDespachoPem.puntoBodegaBuscar)
            params.Add(cadenaParametros)
            params.Add(Constantes.MEDICAMENTO)
            General.llenarTabla(consultaPreparacion, params, tablaPreparacion)
            tablaPreparacion.Merge(tablaTemp, True)

            Dim swt As Boolean = False
            For indiceHijo = 0 To objDespachoPem.tablaSobranteMed.Rows.Count - 1
                For indiceFilaPadre = 0 To dt.Rows.Count - 1
                    Dim filaActualPadre As DataRow = dt.Rows(indiceFilaPadre)
                    If objDespachoPem.tablaSobranteMed.Rows(indiceHijo).Item("RegLote") = filaActualPadre.Item("RegLote") AndAlso objDespachoPem.tablaSobranteMed.Rows(indiceHijo).Item("codigoP") = filaActualPadre.Item("codigo") Then
                        swt = True
                    End If
                Next
                If swt = False Then
                    tablaPreparacion.ImportRow(objDespachoPem.tablaSobranteMed.Rows(indiceHijo))
                End If
            Next

            'tablaPreparacion.Merge(objDespachoPem.tablaSobranteMed)
        End If
    End Sub
    Function obtenerCodigosUtilizados(filas As DataRow(), ByRef tablaTemp As DataTable, ByVal campo As String) As String
        Dim cadenaParametros As String = ""
        For Each fila As DataRow In filas
            tablaTemp.ImportRow(fila)
            If cadenaParametros = "" Then
                cadenaParametros = fila(campo)
            Else
                cadenaParametros &= "," & fila(campo)
            End If
        Next
        Return cadenaParametros
    End Function
    Sub consolidarPems()
        cmbAreas.Enabled = False
        CkbPendientes.Enabled = False
        BtnConsolidar.Enabled = False
        objDespachoPem.codigoPEMInicio = txtPemInicio.Text
        objDespachoPem.codigoPemFin = txtPemFinal.Text
        llenarInsumosConsolidados()
        llenarMedicamentosConsolidados()
        llenarDetalladoPem()
        dgvInsumos.ReadOnly = True
        dgvMedicamentos.ReadOnly = True
    End Sub
    Sub llenarInsumosConsolidados()
        Dim params As New List(Of String)
        params.Add(objDespachoPem.codigoPEMInicio)
        params.Add(objDespachoPem.codigoPemFin)
        General.llenarTabla(Consultas.DESPACHO_PEM_CARGAR_INSUMOS, params, objDespachoPem.tablainsumos)
    End Sub
    Sub llenarMedicamentosConsolidados()
        Dim params As New List(Of String)
        params.Add(objDespachoPem.codigoPEMInicio)
        params.Add(objDespachoPem.codigoPemFin)
        General.llenarTabla(Consultas.DESPACHO_PEM_CARGAR_MEDICAMENTOS, params, objDespachoPem.tablaMedicamentos)
    End Sub
    Sub llenarDetalladoPem()
        Dim params As New List(Of String)
        params.Add(objDespachoPem.codigoPEMInicio)
        params.Add(objDespachoPem.codigoPemFin)
        params.Add(getTipoPedido())
        General.llenarTabla(Consultas.DESPACHO_PEM_CARGAR_DETALLADO_PEM, params, objDespachoPem.tablaListadoDetalladoPEM)
    End Sub
    Sub BuscarPemFinal()
        Dim params As New List(Of String)
        params.Add(Constantes.PENDIENTE)
        params.Add(SesionActual.codigoEP)
        params.Add(txtPemInicio.Text)
        params.Add(cmbAreas.SelectedValue)
        Dim cadena As String

        If cmbTipoPedido.SelectedValue = 2 Then
            cadena = Consultas.DESPACHO_PEM_CARGAR_PEMS_FINALES_EXT
            params.Add(True)
        Else
            cadena = Consultas.DESPACHO_PEM_CARGAR_PEMS_FINALES
            params.Add(getTipoPedido().ToString)
        End If
        General.buscarElemento(If(CkbPendientes.Checked, Consultas.DESPACHO_PEM_CARGAR_PEMS_FINALES_PENDIENTES, cadena),
                               params,
                               AddressOf asignarPemFinal,
                               TitulosForm.BUSQUEDA_PEMS,
                               False,
                               Constantes.TAMANO_MEDIANO,
                               True)
    End Sub
    Sub asignarPemFinal(ByVal codigoPemFin As String)
        objDespachoPem.codigoPemFin = codigoPemFin
        txtPemFinal.Text = objDespachoPem.codigoPemFin
    End Sub
    Sub buscarPemInicio()
        Dim area As String = cmbAreas.SelectedValue
        Dim params As New List(Of String)
        params.Add(Constantes.PENDIENTE)
        params.Add(SesionActual.codigoEP)
        params.Add(area)


        Dim cadena As String

        If cmbTipoPedido.SelectedValue = 2 Then
            cadena = Consultas.DESPACHO_PEM_CARGAR_PEMS_INICIOS_EXT
            params.Add(True)
        Else
            cadena = Consultas.DESPACHO_PEM_CARGAR_PEMS_INICIOS
            params.Add(getTipoPedido().ToString)
        End If

        General.buscarElemento(If(CkbPendientes.Checked, Consultas.DESPACHO_PEM_CARGAR_PEMS_INICIOS_PENDIENTES, cadena),
                               params,
                               AddressOf asignarPemInicio,
                               TitulosForm.BUSQUEDA_PEMS,
                               False,
                               Constantes.TAMANO_MEDIANO,
                               True)
    End Sub
    Sub asignarPemInicio(ByVal codigoPemInicio As String)
        objDespachoPem.codigoPEMInicio = codigoPemInicio
        txtPemInicio.Text = objDespachoPem.codigoPEMInicio
    End Sub
    Sub inicializarForm()
        objDespachoPem = New DespachoPEM
        permisoGeneral = perG.buscarPermisoGeneral(Name)
        pNuevo = permisoGeneral & "pp" & "01"
        pEditar = permisoGeneral & "pp" & "02"
        pAnular = permisoGeneral & "pp" & "03"
        pBuscar = permisoGeneral & "pp" & "04"
        pConsolidar = permisoGeneral & "pp" & "05"
        PnlDetallado.Visible = True
        PnlDetallado.Visible = False
        cargarCombos()


        General.comboSoloEleccion(cmbTipoPedido)
        General.comboSoloEleccion(cmbAreas)
        configurarDgvs()
        llenarCodigoReporte()

        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Sub cargarCombos()
        llenarComboArea()
        llenarComboTipoPedido()
    End Sub
    Sub llenarComboTipoPedido()
        cmbTipoPedido.DataSource = objDespachoPem.tablaTipoPedido
        cmbTipoPedido.ValueMember = "Codigo"
        cmbTipoPedido.DisplayMember = "Descripcion"
    End Sub
    Sub llenarCodigoReporte()
        objDespachoPem.tablahas.Add(Constantes.REPORTE_ETIQUETAS_MEDICAMENTOS, New rptEtiquetaMedicamentos)
        objDespachoPem.tablahas.Add(Constantes.REPORTE_ETIQUETAS_INFUSIONES, New rptEtiquetasInfusiones)
        objDespachoPem.tablahas.Add(Constantes.REPORTE_ETIQUETAS_MEDICAMENTOS_EXTERNO, New rptEtiquetaMedicamentosExterno)
    End Sub
    Sub llenarComboArea()
        Dim params As New List(Of String)
        params.Add(SesionActual.idUsuario)
        params.Add(SesionActual.codigoEP)
        params.Add(Nothing)
        Dim tbl As New DataTable
        General.llenarTabla(Consultas.PROC_AREA_SERVICIO_EMPLEADO_LLENAR, params, tbl)
        tbl.Rows.Add(-2, "TODOS")

        cmbAreas.DataSource = tbl
        cmbAreas.ValueMember = "Código"
        cmbAreas.DisplayMember = "Descripción"
    End Sub
    Sub configurarDgvs()
        configurarDgvInsumos()
        configurarDgvMedicamentos()
        configurarDgvLotesDisponiblesBodegaComercial()
    End Sub
    Sub configurarDgvInsumos()
        With dgvInsumos
            .Columns("Codigo_InternoIns").ReadOnly = True
            .Columns("Codigo_InternoIns").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigo_InternoIns").DataPropertyName = "Codigo_Interno"
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").DataPropertyName = "Descripcion"
            .Columns("CantidadSolicitadaIns").ReadOnly = True
            .Columns("CantidadSolicitadaIns").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantidadSolicitadaIns").DataPropertyName = "CantidadPedida"
            .Columns("CantidadDespIns").ReadOnly = True
            .Columns("CantidadDespIns").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantidadDespIns").DataPropertyName = "CantidadDespachada"
            .Columns("CantidadFaltanteIns").ReadOnly = True
            .Columns("CantidadFaltanteIns").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantidadFaltanteIns").DataPropertyName = "CantidadFaltante"
            .ReadOnly = True
            .AutoGenerateColumns = False
            .DataSource = objDespachoPem.tablainsumos
        End With
        General.diseñoDGV(dgvInsumos)
    End Sub
    Sub configurarDgvMedicamentos()
        With dgvMedicamentos
            .Columns("Codigo_internoMed").ReadOnly = True
            .Columns("Codigo_internoMed").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigo_internoMed").DataPropertyName = "Codigo_Interno"
            .Columns("DescripcionMed").ReadOnly = True
            .Columns("DescripcionMed").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("DescripcionMed").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DescripcionMed").DataPropertyName = "Descripcion"
            .Columns("ConcentracionMedicamento").ReadOnly = True
            .Columns("ConcentracionMedicamento").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("ConcentracionMedicamento").DataPropertyName = "ConcentracionMedicamento"
            .Columns("ConcentracionPedida").ReadOnly = True
            .Columns("ConcentracionPedida").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("ConcentracionPedida").DataPropertyName = "Concen_Ped"
            .Columns("CantidadPedida").ReadOnly = True
            .Columns("CantidadPedida").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantidadPedida").DataPropertyName = "Cant_Ped"
            .Columns("Siglas").ReadOnly = True
            .Columns("Siglas").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Siglas").DataPropertyName = "Unidad"
            .Columns("UnidadesDespachadas").ReadOnly = True
            .Columns("UnidadesDespachadas").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("UnidadesDespachadas").DataPropertyName = "Cant_Desp"
            .Columns("ConcentracionDespachada").ReadOnly = True
            .Columns("ConcentracionDespachada").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("ConcentracionDespachada").DataPropertyName = "Concen_Desp"
            .Columns("ConcentracionSobrante").ReadOnly = True
            .Columns("ConcentracionSobrante").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("ConcentracionSobrante").DataPropertyName = "Concen_Sob"
            .Columns("ConcentracionFaltante").ReadOnly = True
            .Columns("ConcentracionFaltante").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("ConcentracionFaltante").DataPropertyName = "Concen_Falt"
            .ReadOnly = True
            .AutoGenerateColumns = False
            .DataSource = objDespachoPem.tablaMedicamentos
        End With
        General.diseñoDGV(dgvMedicamentos)
    End Sub
    Sub configurarDgvDetallado()
        With dgvPemDetallados
            .DataSource = objDespachoPem.tablaListadoDetalladoPEM
            If dgvPemDetallados.ColumnCount > 0 Then
                .Columns("Concentración Pedida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Cantidad Despachada").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Concentración Pedida").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("Paciente").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("Cantidad Despachada").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("Descripción").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                If dgvPemDetallados.Columns.Contains("Cantidad Fantante") Then
                    .Columns("Cantidad Fantante").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End If
                If dgvPemDetallados.Columns.Contains("Tipo") Then
                    .Columns("Tipo").Visible = False
                End If
                .ReadOnly = True
            End If

        End With
        For indiceColumna = 0 To dgvPemDetallados.ColumnCount - 1
            dgvPemDetallados.Columns(indiceColumna).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        General.diseñoDGV(dgvPemDetallados)
    End Sub
    Sub configurarDgvLotesDisponiblesBodegaComercial(Optional tabla As DataTable = Nothing)
        With dgvLotesDisponiblesbodegaComercial
            .DataSource = Nothing
            .Columns("CodigoProductoCom").ReadOnly = True
            .Columns("CodigoProductoCom").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CodigoProductoCom").DataPropertyName = "Codigo"
            .Columns("DescripcionProductoCom").ReadOnly = True
            .Columns("DescripcionProductoCom").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DescripcionProductoCom").DataPropertyName = "Descripcion"
            .Columns("CopncentracionDisponible").ReadOnly = True
            .Columns("CopncentracionDisponible").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CopncentracionDisponible").DataPropertyName = "Concentracion"
            .Columns("BodegaCom").ReadOnly = True
            .Columns("BodegaCom").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("BodegaCom").DataPropertyName = "Bodega"
            .Columns("LoteCom").ReadOnly = True
            .Columns("LoteCom").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("LoteCom").DataPropertyName = "Lote"
            .Columns("Fecha").ReadOnly = True
            .Columns("Fecha").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Fecha").DataPropertyName = "Fecha"
            .Columns("stockLoteCom").ReadOnly = True
            .Columns("stockLoteCom").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("stockLoteCom").DataPropertyName = "Stock"
            .Columns("CantidadDespLoteCom").ReadOnly = True
            .Columns("CantidadDespLoteCom").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantidadDespLoteCom").DataPropertyName = "CantidadDespachada"
            .ReadOnly = True
            .AutoGenerateColumns = False
            .DataSource = If(tabla Is Nothing, objDespachoPem.tablaBusqueda, tabla)
        End With
        General.diseñoDGV(dgvPemDetallados)
    End Sub
    Sub configurarDgvLotesDisponiblesBodegaPreparacion(Optional tabla As DataTable = Nothing)
        With dgvBodegasPreparaciones
            .DataSource = Nothing
            .Columns("CodigoP").ReadOnly = True
            .Columns("CodigoP").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CodigoP").DataPropertyName = "CodigoP"
            .Columns("DescripcionP").ReadOnly = True
            .Columns("DescripcionP").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DescripcionP").DataPropertyName = "DescripcionP"
            .Columns("ConcentracionP").ReadOnly = True
            .Columns("ConcentracionP").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("ConcentracionP").DataPropertyName = "Concentracion"
            .Columns("ConcentracionDispP").ReadOnly = True
            .Columns("ConcentracionDispP").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("ConcentracionDispP").DataPropertyName = "ConcentracionDispP"
            .Columns("Bodega").ReadOnly = True
            .Columns("Bodega").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Bodega").DataPropertyName = "Bodega"
            .Columns("Lote").ReadOnly = True
            .Columns("Lote").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Lote").DataPropertyName = "Lote"
            .Columns("Fecha_vence").ReadOnly = True
            .Columns("Fecha_vence").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Fecha_vence").DataPropertyName = "Fecha"
            .Columns("concentracionDesp").ReadOnly = True
            .Columns("concentracionDesp").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("concentracionDesp").DataPropertyName = "concentracionDesp"
            .Columns("Tipo").ReadOnly = True
            .Columns("Tipo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Tipo").DataPropertyName = "Tipo"
            .ReadOnly = True
            .AutoGenerateColumns = False
            .DataSource = If(tabla Is Nothing, objDespachoPem.tablaBusquedaPreparacion, tabla)
        End With
        General.diseñoDGV(dgvBodegasPreparaciones)
    End Sub
    Sub ColocarFilaEnCero(ByVal dgv As DataGridView,
                          ByVal filaActual As Integer,
                          ByRef tbl As DataTable)

        objDespachoPem.quitarTabla(objDespachoPem.nombrarTabla(getCodigoFilaActual(), filaActual, If(dgv.Equals(dgvMedicamentos), Constantes.GRILLA_MEDICAMENTOS, Constantes.GRILLA_INSUMOS)))
        If objDespachoPem.swtGrilla = Constantes.GRILLA_MEDICAMENTOS Then
            objDespachoPem.tablaMedicamentos.Rows(filaActual).Item("Cant_Desp") = 0
            objDespachoPem.tablaMedicamentos.Rows(filaActual).Item("Concen_Desp") = 0
        Else
            objDespachoPem.tablainsumos.Rows(filaActual).Item("CantidadDespachada") = 0
        End If
        retirarCantidadesDespachadas(filaActual, objDespachoPem.swtGrilla)
        tbl.AcceptChanges()
    End Sub
    Sub bloquarCelda(ByRef e As DataGridViewCellEventArgs)
        dgvLotesDisponiblesbodegaComercial.ReadOnly = False
        Dim swt As Boolean = dgvLotesDisponiblesbodegaComercial.DataSource.Equals(objDespachoPem.tablaBusqueda)
        If Funciones.verificacionPosicionActual(dgvLotesDisponiblesbodegaComercial, e, "CantidadDespLoteCom") AndAlso swt AndAlso txtCodigo.Text = "" Then
            dgvLotesDisponiblesbodegaComercial.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
        Else
            If Funciones.filaValida(e.RowIndex) Then
                dgvLotesDisponiblesbodegaComercial.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            End If
        End If
    End Sub
    Sub bloquearCeldaPreparacion(ByRef e As DataGridViewCellEventArgs)
        dgvBodegasPreparaciones.ReadOnly = False
        Dim swt As Boolean = dgvBodegasPreparaciones.DataSource.Equals(objDespachoPem.tablaBusquedaPreparacion)
        If Funciones.verificacionPosicionActual(dgvBodegasPreparaciones, e, "concentracionDesp") AndAlso swt AndAlso txtCodigo.Text = "" Then
            dgvBodegasPreparaciones.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
        Else
            If Funciones.filaValida(e.RowIndex) Then
                dgvBodegasPreparaciones.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            End If
        End If
    End Sub
    Sub configuracionPanelDespacho(ByVal fila As Integer, ByRef tabla As DataTable, ByVal nombreColunmaCantidad As String, Optional ByVal nombreColumnaConcentracion As String = "")
        valoresDefaulTexboxCalculos()
        txtCantidadPedida.Text = Format(tabla.Rows(fila).Item(nombreColunmaCantidad), "##,##.00")
        If nombreColumnaConcentracion <> "" Then
            txtConcePed.Text = Format(tabla.Rows(fila).Item(nombreColumnaConcentracion), "##,##.00")
        End If
        lblProducto.Text = tabla.Rows(fila).Item("Descripcion").ToString.ToUpper
        calcularCantidadDeDespacho()
    End Sub
    Sub retirarLascantidadesEditadas(ByVal idConcidencia As Integer, ByRef tipo As Integer, ByVal regLote As Integer)
        Dim dtFilas As DataRowCollection = objDespachoPem.tablaBodegaVirtual.Rows

        For indiceFila = 0 To dtFilas.Count - 1
            If dtFilas(indiceFila).Item("id") = idConcidencia AndAlso dtFilas(indiceFila).Item("reglote") = regLote AndAlso dtFilas(indiceFila).Item("Tipo") = tipo Then
                dtFilas.RemoveAt(indiceFila)
                Exit For
            End If
        Next
    End Sub
    Sub retirarLascantidadesEditadasPre(ByVal idConcidencia As Integer, ByRef tipo As Integer, ByVal regLote As Integer)
        Dim dtFilas As DataRowCollection = objDespachoPem.tablaBodegaVirtualPreparacion.Rows

        For indiceFila = 0 To dtFilas.Count - 1
            If dtFilas(indiceFila).Item("id") = idConcidencia AndAlso dtFilas(indiceFila).Item("reglote") = regLote Then
                dtFilas.RemoveAt(indiceFila)
                Exit For
            End If
        Next
    End Sub
    Sub retirarCantidadesDespachadas(ByVal idConcidencia As Integer, ByRef tipo As Integer)
        Dim dtFilas As DataRowCollection = objDespachoPem.tablaBodegaVirtual.Rows
        Dim tblPrincipal As DataTable = objDespachoPem.tablaBodegaVirtual
        Dim tblTemp1, tblTemp2 As New DataTable
        tblTemp1 = tblPrincipal.Clone
        tblTemp2 = tblPrincipal.Clone

        Dim filas1 As DataRow()
        filas1 = tblPrincipal.Select("tipo <> '" & tipo & "'")

        Dim filas2 As DataRow()
        filas2 = tblPrincipal.Select("id <> '" & idConcidencia & "'")

        For Each fila In filas1
            tblTemp1.ImportRow(fila)
        Next
        For Each fila In filas2
            tblTemp2.ImportRow(fila)
        Next

        tblPrincipal.Clear()

        tblPrincipal.Merge(tblTemp1)
        tblPrincipal.Merge(tblTemp2)
        'For indiceFila = 0 To dtFilas.Count - 1
        '    If dtFilas(indiceFila).Item("id") = idConcidencia Then
        '        dtFilas.RemoveAt(indiceFila)
        '        Exit For
        '    End If
        'Next
    End Sub
#End Region
#Region "Funciones"
    Function validarForm() As Boolean
        Dim result As Boolean = True
        If objDespachoPem.tablaMedicamentos.Select("Cant_Desp = 0").Count = objDespachoPem.tablaMedicamentos.Rows.Count AndAlso objDespachoPem.tablainsumos.Select("CantidadDespachada = 0").Count = objDespachoPem.tablainsumos.Rows.Count Then
            MsgBox(Mensajes.MEDICAMENTOS_INSUMOS_FALTANTES_DESPACHO_PEM, MsgBoxStyle.Exclamation)
            result = False
        End If
        Return result
    End Function
    Function obtenerStockActualBodegaVirtual(ByVal codigoProducto As Integer,
                                             ByVal regLote As Integer) As Integer
        Dim stock As Integer = 0
        Dim tabla As DataTable = objDespachoPem.tablaBodegaVirtual
        For indice = 0 To tabla.Rows.Count - 1
            If tabla.Rows(indice).Item("Codigo") = codigoProducto AndAlso tabla.Rows(indice).Item("RegLote") = regLote Then
                stock = tabla.Rows(indice).Item("Stock")
            End If
        Next
        Return stock
    End Function
    Function obtenerStockActualBodegaVirtualPre(ByVal codigoProducto As Integer,
                                             ByVal regLote As Integer) As Integer
        Dim stock As Integer = 0
        Dim tabla As DataTable = objDespachoPem.tablaBodegaVirtualPreparacion
        For indice = 0 To tabla.Rows.Count - 1
            If tabla.Rows(indice).Item("CodigoP") = codigoProducto AndAlso tabla.Rows(indice).Item("RegLote") = regLote Then
                stock = tabla.Rows(indice).Item("ConcentracionDispP")
            End If
        Next
        Return stock
    End Function
    Function obtenerCantidadDespachadaAnteriormente(ByVal codigoProducto As Integer,
                                                    ByVal regLote As Integer) As Integer
        Dim cantidad As Integer = 0
        Dim tabla As DataTable = objDespachoPem.tablaBodegaVirtual
        Dim accion As String = "sum(CantidadDespachada)"
        Dim filtro As String = "Codigo='" & codigoProducto & "' and RegLote ='" & regLote & "'"
        cantidad = If(IsDBNull(tabla.Compute(accion, filtro)), 0, tabla.Compute(accion, filtro))
        Return cantidad
    End Function
    Function obtenerCantidadDespachadaAnteriormentePre(ByVal codigoProducto As Integer,
                                                       ByVal regLote As Integer) As Integer
        Dim cantidad As Integer = 0
        Dim tabla As DataTable = objDespachoPem.tablaBodegaVirtualPreparacion
        Dim accion As String = "sum(ConcentracionDesp)"
        Dim filtro As String = "CodigoP='" & codigoProducto & "' and RegLote ='" & regLote & "'"
        cantidad = If(IsDBNull(tabla.Compute(accion, filtro)), 0, tabla.Compute(accion, filtro))
        Return cantidad
    End Function
    Function verificarStockBodegaVirtual(ByVal codigoProducto As Integer,
                                         ByVal cantidad As Integer,
                                         ByVal regLote As Integer,
                                         Optional idConcidencia As String = Nothing) As Boolean
        If Not IsNothing(idConcidencia) Then
            retirarLascantidadesEditadas(idConcidencia, objDespachoPem.swtGrilla, regLote)
        End If
        Dim cantidadDespachada As Double = obtenerCantidadDespachadaAnteriormente(codigoProducto, regLote)
        Dim stock As Integer = obtenerStockActualBodegaVirtual(codigoProducto, regLote)
        If stock = 0 And cantidadDespachada = 0 Then
            Return True
        End If
        If (stock - cantidadDespachada) < cantidad Then
            Return False
        End If
        Return True
    End Function
    Function verificarStockBodegaVirtualPreparacion(ByVal codigoProducto As Integer,
                                                    ByVal cantidad As Double,
                                                    ByVal regLote As Integer,
                                                    Optional idConcidencia As String = Nothing) As Boolean
        If Not IsNothing(idConcidencia) Then
            retirarLascantidadesEditadasPre(idConcidencia, objDespachoPem.swtGrilla, regLote)
        End If
        Dim cantidadDespachada As Integer = obtenerCantidadDespachadaAnteriormentePre(codigoProducto, regLote)
        Dim stock As Integer = obtenerStockActualBodegaVirtualPre(codigoProducto, regLote)
        If stock = 0 AndAlso cantidadDespachada = 0 Then
            Return True
        End If
        If (stock - cantidadDespachada) < cantidad Then
            Return False
        End If
        Return True
    End Function
    Function obtenerGrillaActual() As DataGridView
        Return If(objDespachoPem.swtGrilla = Constantes.GRILLA_MEDICAMENTOS, dgvMedicamentos, dgvInsumos)
    End Function
    Function getFilaActualDgv() As Integer
        Return If(objDespachoPem.swtGrilla = Constantes.GRILLA_MEDICAMENTOS, dgvMedicamentos.CurrentRow.Index, dgvInsumos.CurrentRow.Index)
    End Function
    Function getCodigoFilaActual() As Integer
        Dim filaActual As Integer = getFilaActualDgv()
        Return If(objDespachoPem.swtGrilla = Constantes.GRILLA_MEDICAMENTOS, objDespachoPem.tablaMedicamentos.Rows(filaActual).Item("Codigo_Interno"), objDespachoPem.tablainsumos.Rows(filaActual).Item("Codigo_Interno"))
    End Function
    Function verificarSeleccionPems() As Boolean
        Dim respuesta As Boolean = True
        If txtPemInicio.Text = "" Then
            MsgBox("Debe seleccionar el PEM de inicio !", MsgBoxStyle.Exclamation)
            respuesta = False
        ElseIf txtPemFinal.Text = "" Then
            MsgBox("Debe seleccionar el PEM Final !", MsgBoxStyle.Exclamation)
            respuesta = False
        End If
        Return respuesta
    End Function
#End Region
#Region "Eventos de los datagridview"
    Private Sub dgvLotesDisponiblesbodegaComercial_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvLotesDisponiblesbodegaComercial.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
    End Sub
    Private Sub dgvBodegasPreparaciones_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvBodegasPreparaciones.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
    End Sub
    Private Sub dgvMedicamentos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMedicamentos.CellContentClick

        If Funciones.verificacionPosicionActual(dgvMedicamentos, e, "DescpachoMed") Then
            configuracionPanelDespacho(e.RowIndex, objDespachoPem.tablaMedicamentos, "Cant_Ped", "Concen_Ped")
            If txtCodigo.Text = "" Then
                objDespachoPem.puntoBodegaBuscar = SesionActual.codigoEP
                mostarPanel(Consultas.DESPACHO_PEM_CARGAR_MEDICAMENTOS_LOTES_DISPONIBLES_BODEGA_COMERCIAL,
                            objDespachoPem.tablaBusqueda,
                            Consultas.DESPACHO_PEM_CARGAR_MEDICAMENTOS_LOTES_DISPONIBLES_BODEGA_PREPARACION,
                            objDespachoPem.tablaBusquedaPreparacion)
            Else
                llenarLotesGuardados(Consultas.DESPACHO_PEM_CARGAR_MEDICAMENTOS_LOTES_GUARDADOS, objDespachoPem.tablaMedicamentos, Constantes.GRILLA_MEDICAMENTOS, "Cant_Ped", "Concen_Ped")
            End If
        End If
    End Sub
    Private Sub dgvInsumos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInsumos.CellContentClick
        If Funciones.verificacionPosicionActual(dgvInsumos, e, "DescpachoIns") Then
            configuracionPanelDespacho(e.RowIndex, objDespachoPem.tablainsumos, "CantidadPedida")
            If txtCodigo.Text = "" Then
                mostarPanel(Consultas.DESPACHO_PEM_CARGAR_INSUMOS_LOTES_DISPONIBLES_BODEGA_COMERCIAL, objDespachoPem.tablaBusqueda)
            Else
                llenarLotesGuardados(Consultas.DESPACHO_PEM_CARGAR_INSUMOS_LOTES_GUARDADOS, objDespachoPem.tablainsumos, Constantes.GRILLA_INSUMOS, "CantidadPedida")
            End If
        End If
    End Sub
    Private Sub dgvMedicamentos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvMedicamentos.DataError
    End Sub
    Private Sub dgvMedicamentos_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMedicamentos.CellContentDoubleClick
        If Funciones.verificacionPosicionActual(dgvMedicamentos, e, "QuitarMed") AndAlso btguardar.Enabled = True Then
            If MsgBox(Mensajes.QUITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ColocarFilaEnCero(dgvMedicamentos, e.RowIndex, objDespachoPem.tablaMedicamentos)
                objDespachoPem.distribucionDeConcentracionesDeapchadasPem(getCodigoFilaActual(), objDespachoPem.tablaMedicamentos.Rows(getFilaActualDgv()).Item("Concen_Desp"), False)
                dgvMedicamentos.Rows(e.RowIndex).Tag = Nothing
            End If
        End If
    End Sub
    Private Sub dgvInsumos_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInsumos.CellContentDoubleClick
        If Funciones.verificacionPosicionActual(dgvInsumos, e, "QuitarInf") AndAlso btguardar.Enabled = True Then
            If MsgBox(Mensajes.QUITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ColocarFilaEnCero(dgvInsumos, e.RowIndex, objDespachoPem.tablainsumos)
                objDespachoPem.distribucionDeConcentracionesDeapchadasPem(getCodigoFilaActual(), objDespachoPem.tablainsumos.Rows(getFilaActualDgv()).Item("CantidadDespachada"), False)
                dgvInsumos.Rows(e.RowIndex).Tag = Nothing
            End If
        End If
    End Sub
    Private Sub dgvLotesDisponiblesbodegaComercial_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvLotesDisponiblesbodegaComercial.DataError
        e.Cancel = False
        MsgBox(Mensajes.CANTIDAD_VALIDA, MsgBoxStyle.Exclamation)
    End Sub
    Private Sub dgvBodegasPreparaciones_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBodegasPreparaciones.CellClick
        bloquearCeldaPreparacion(e)
    End Sub
    Private Sub dgvBodegasPreparaciones_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBodegasPreparaciones.CellEnter
        bloquearCeldaPreparacion(e)
    End Sub
    Private Sub dgvLotesDisponiblesbodegaComercial_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLotesDisponiblesbodegaComercial.CellClick
        bloquarCelda(e)
    End Sub
    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        panelBodegaDiferente.Visible = False
    End Sub
    Private Sub dgvLotesDisponiblesbodegaComercial_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLotesDisponiblesbodegaComercial.CellEnter
        bloquarCelda(e)
    End Sub

    Private Sub ImprimirDespachoPEMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirDespachoPEMToolStripMenuItem.Click
        If txtCodigo.Text = "" Then
            MsgBox("Debe elegir un despacho para imprimir !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        Else
            Try
                Cursor = Cursors.WaitCursor
                Dim rprte As New rptDespachoPem
                Funciones.getReporteNoFTP(rprte, "{VISTA_EMPRESAS.Id_empresa}=" & SesionActual.idEmpresa &
                                                 " And {VISTA_DESPACHO_PEM_CANTIDADES_DESPACHADAS.Codigo_Despacho_PEM} = " & objDespachoPem.codigoDespachoPEM, "DespachoPem")

                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
                General.manejoErrores(ex)
            End Try
        End If
    End Sub

    Private Sub dgvLotesDisponiblesbodegaComercial_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLotesDisponiblesbodegaComercial.CellEndEdit
        Dim tblTemp = objDespachoPem.tablaBusqueda
        Dim filaActual As DataRow = tblTemp.Rows(e.RowIndex)
        If Funciones.verificacionPosicionActual(dgvLotesDisponiblesbodegaComercial, e, "CantidadDespLoteCom") AndAlso filaActual.Item("CantidadDespachada").ToString <> "" Then
            confirmarCambiosEnGrillas()
            Dim codigoFilaActual = getCodigoFilaActual()
            Dim filaGrillaPadre = getFilaActualDgv()
            Dim dgvActual = obtenerGrillaActual()
            tblTemp.AcceptChanges()

            If verificarStockBodegaVirtual(filaActual.Item("Codigo"),
                                           filaActual.Item("CantidadDespachada"),
                                           filaActual.Item("RegLote"), filaGrillaPadre) = False OrElse
                objDespachoPem.validarCantidadPermitida(filaActual.Item("Stock"),
                                                        filaActual.Item("CantidadDespachada")) = False Then

                filaActual.Item("CantidadDespachada") = 0
                MsgBox(Mensajes.DESPACHO_CANTIDAD_MAYOR_A_STOCK, MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim tipoGrilla As Integer = If(objDespachoPem.swtGrilla = Constantes.GRILLA_MEDICAMENTOS, Constantes.GRILLA_MEDICAMENTOS, Constantes.GRILLA_INSUMOS)


            objDespachoPem.agregarProductoDespachado(tblTemp, e.RowIndex, codigoFilaActual, filaGrillaPadre)
            objDespachoPem.guardarDespachoTemporal(filaGrillaPadre, codigoFilaActual, CInt(txtCantidadPedida.Text), CDbl(txtConcePed.Text), tipoGrilla)
            objDespachoPem.calcularConcentracionesDespachada(filaGrillaPadre, codigoFilaActual, tipoGrilla)
            asignarValoresDespachados()
            aceptarCambiosDgvLotes(filaGrillaPadre, codigoFilaActual)
        Else
            filaActual.Item("CantidadDespachada") = 0
        End If
    End Sub
    Private Sub dgvBodegasPreparaciones_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBodegasPreparaciones.CellEndEdit
        Dim tblTemp = objDespachoPem.tablaBusquedaPreparacion
        Dim filaActual As DataRow = tblTemp.Rows(e.RowIndex)
        If Funciones.verificacionPosicionActual(dgvBodegasPreparaciones, e, "concentracionDesp") AndAlso filaActual.Item("concentracionDesp").ToString <> "" Then
            confirmarCambiosEnGrillas()
            Dim codigoFilaActual = getCodigoFilaActual()
            Dim filaGrillaPadre = getFilaActualDgv()
            Dim dgvActual = obtenerGrillaActual()
            objDespachoPem.tablaBusquedaPreparacion.AcceptChanges()
            If verificarStockBodegaVirtualPreparacion(filaActual.Item("CodigoP"),
                                                      filaActual.Item("concentracionDesp"),
                                                      filaActual.Item("RegLote"), filaGrillaPadre) = False OrElse
                    objDespachoPem.validarCantidadPermitida(filaActual.Item("ConcentracionDispP"),
                                                            filaActual.Item("concentracionDesp")) = False Then

                filaActual.Item("ConcentracionDesp") = 0
                MsgBox(Mensajes.DESPACHO_CANTIDAD_MAYOR_A_STOCK, MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim grillaActual As Integer = If(objDespachoPem.swtGrilla = Constantes.GRILLA_MEDICAMENTOS, Constantes.GRILLA_MEDICAMENTOS, Constantes.GRILLA_INSUMOS)
            objDespachoPem.agregarProductoDespachadoPre(objDespachoPem.tablaBusquedaPreparacion, e.RowIndex, codigoFilaActual, filaGrillaPadre)
            objDespachoPem.guardarDespachoTemporalPre(filaGrillaPadre, codigoFilaActual, CInt(txtCantidadPedida.Text), CDbl(txtConcePed.Text), grillaActual)
            objDespachoPem.calcularConcentracionesDespachada(filaGrillaPadre, codigoFilaActual, grillaActual)
            asignarValoresDespachados()
            aceptarCambiosDgvLotes(filaGrillaPadre, codigoFilaActual)
        Else
            filaActual.Item("concentracionDesp") = 0
        End If
    End Sub
    Private Sub dgvMedicamentos_Click(sender As Object, e As EventArgs) Handles dgvMedicamentos.Click
        objDespachoPem.swtGrilla = Constantes.GRILLA_MEDICAMENTOS
    End Sub
    Private Sub dgvInsumos_Click(sender As Object, e As EventArgs) Handles dgvInsumos.Click
        objDespachoPem.swtGrilla = Constantes.GRILLA_INSUMOS
    End Sub
    Private Sub dgvBodegasDiferentes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBodegasDiferentes.CellDoubleClick
        If Funciones.filaValida(e.RowIndex) Then
            objDespachoPem.puntoBodegaBuscar = dgvBodegasDiferentes.Rows(e.RowIndex).Cells("codigo_EP").Value
            panelBodegas.Visible = False
            mostarPanel(Consultas.DESPACHO_PEM_CARGAR_MEDICAMENTOS_LOTES_DISPONIBLES_BODEGA_COMERCIAL, objDespachoPem.tablaBusqueda)
            panelBodegaDiferente.Visible = False
        End If
    End Sub
#End Region
End Class