Imports System.Threading
Public Class FormAtencionLaboratorio
    Dim perG As New Buscar_Permisos_generales
    Dim objAtencion As New AtencionLaboratorio
    Dim reporte As New ftp_reportes
    Dim objLista As New ListaAtencion
    Dim objPrincipal As New Principal
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, codigoTemporal, codigoOrden, ModuloImg As String
    Public esHijo As Boolean = False
    Private respuesta As Boolean
    Private Sub btbuscarPaciente_Click(sender As Object, e As EventArgs) Handles btbuscarPaciente.Click
        Dim params As New List(Of String)
        params.Add(Nothing)
        General.buscarElemento(Consultas.PACIENTE_EXTERNOS_BUSCAR,
                             params,
                             AddressOf cargarPacienteAM,
                             TitulosForm.BUSQUEDA_PACIENTE,
                             True, 0, True)
    End Sub
    Public Sub cargarParaclinicosCita()
        objAtencion.codigoCita = txtCitaMedica.Text
        objAtencion.cargarParaclinicosCitas()
        dgvParaclinicos.DataSource = objAtencion.dtParaclinicos
        objAtencion.dtParaclinicos.Rows.Add()
        verificarResultados()
    End Sub
    Public Sub verificarResultados()
        For I = 0 To dgvParaclinicos.DataSource.Rows.Count - 1
            If Not IsDBNull(dgvParaclinicos.DataSource.Rows(I).Item("Resultado")) Then
                If dgvParaclinicos.DataSource.Rows(I).Item("Resultado") = 1 Then
                    dgvParaclinicos.Rows(I).Cells("dgResultadoPara").Value = My.Resources.OK
                Else
                    dgvParaclinicos.Rows(I).Cells("dgResultadoPara").Value = My.Resources._new
                End If
            Else
                dgvParaclinicos.Rows(I).Cells("dgResultadoPara").Value = My.Resources._new
            End If
        Next
        dgvParaclinicos.Columns("Resultado").Visible = False
    End Sub

    Public Sub cargarProcedimientosCita()
        objAtencion.codigoCita = txtCitaMedica.Text
        objAtencion.cargarProcedimientosCitas()
        dgvProcedimiento.DataSource = objAtencion.dtProcedimiento
        objAtencion.dtProcedimiento.Rows.Add()
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btsolitudLab_Click(sender As Object, e As EventArgs) Handles btsolitudLab.Click
        Dim formlab As New FormSolicitudLab
        objAtencion.modulo = Tag.modulo
        formlab.iniciarForm(objAtencion)
        formlab.ShowDialog()
    End Sub
    Private Sub FormAtencionLaboratorio_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub FormAtencionLaboratorio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        If ModuloImg = Nothing Then
            ModuloImg = Tag.modulo
        End If
        If Not esHijo Then
            objAtencion = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_VISTA_PREVIA_ATENCION)
        End If

        permiso_general = perG.buscarPermisoGeneral(Name, ModuloImg)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        btbuscarPaciente.Enabled = False
        btBuscarCitaM.Enabled = False
        fechaAtencion.Text = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        deshabilitarControles()
        objAtencion.establecerDGVParaclinico(dgvParaclinicos)
        objAtencion.establecerDGVprocedimientos(dgvProcedimiento)
        objAtencion.establecerDGVhemoderivados(dgvHemoderivado)
        objAtencion.establecerDGVmedicamentos(dgvMedicamentos)
        objAtencion.establecerDGVinsumos(dgvInsumos)
        dgvMedicamentos.Columns("dgcodigooculto").Visible = False
        dgvInsumos.Columns("dgcodigoin").Visible = False
        dgvParaclinicos.Columns("Resultado").Visible = False
        verificarResultados()
        objAtencion.tipo = Constantes.Tipo_documento
    End Sub
    Public Sub cargarDatos(ByVal modulo As String, ByVal codigoAtencion As Integer)
        ModuloImg = modulo
        objAtencion.establecerDGVParaclinico(dgvParaclinicos)
        objAtencion.establecerDGVprocedimientos(dgvProcedimiento)
        objAtencion.establecerDGVhemoderivados(dgvHemoderivado)
        objAtencion.establecerDGVmedicamentos(dgvMedicamentos)
        objAtencion.establecerDGVinsumos(dgvInsumos)
        dgvMedicamentos.Columns("dgcodigooculto").Visible = False
        dgvInsumos.Columns("dgcodigoin").Visible = False
        cargarPaciente(codigoAtencion)
    End Sub
    Public Sub cargarPacienteAM(pCodigo As String)
        Dim drFila As DataRow
        Dim params As New List(Of String)

        params.Add(pCodigo)
        drFila = General.cargarItem(ConsultasAmbu.PACIENTE_CARGAR_AM, params)
        objAtencion.identipaciente = drFila.Item(0)
        textPaciente.Text = drFila.Item(1)
        textNombre.Text = drFila.Item(2)
        TextSexo.Text = drFila.Item(3)
        textEPS.Text = drFila.Item(4)
        textedad.Text = drFila.Item(5)
        TextCodEPS.Text = drFila.Item(6)
        objAtencion.idEps = drFila.Item(7)
        objAtencion.identipaciente = pCodigo
        CmbEPS.Enabled = True
        cargarComboCliente()
        btBuscarCitaM.Enabled = False
    End Sub
    Public Sub cargarPacienteCitas(pCodigo As String)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        drFila = General.cargarItem(ConsultasAmbu.PACIENTE_CITA_MEDICA_CARGAR, params)
        If drFila IsNot Nothing Then
            objAtencion.identipaciente = drFila.Item(0)
            textPaciente.Text = drFila.Item(1)
            textNombre.Text = drFila.Item(2)
            TextSexo.Text = drFila.Item(3)
            textEPS.Text = drFila.Item(4)
            textedad.Text = drFila.Item(5)
            TextCodEPS.Text = drFila.Item(6)
            objAtencion.idEps = drFila.Item(7)
            txtCitaMedica.Text = pCodigo
            CmbEPS.Enabled = True
            cargarComboCliente()
            cargarParaclinicosCita()
            cargarProcedimientosCita()
            btbuscarPaciente.Enabled = False
        End If
    End Sub
    Private Sub cargarComboCliente()
        'llena combobox a facturar
        Dim params As New List(Of String)
        params.Add(objAtencion.idEps)
        params.Add(SesionActual.codigoEP)
        General.cargarCombo(ConsultasAmbu.EPS_CONTRATO, params, "RazonSocial", "Codigo", CmbEPS)

    End Sub
    Public Sub deshabilitarControles()
        txtobservacion.ReadOnly = True
        textNombre.ReadOnly = True
        TextCodEPS.ReadOnly = True
        textedad.ReadOnly = True
        textEPS.ReadOnly = True
        textPaciente.ReadOnly = True
        txtCodigo.ReadOnly = True
        txtCitaMedica.ReadOnly = True
        txtEstado.ReadOnly = True
        TextSexo.ReadOnly = True
        CmbEPS.Enabled = False
        fechaAtencion.Enabled = False
        dgvParaclinicos.Columns(0).ReadOnly = True
        dgvParaclinicos.Columns("dgDescripcionp").ReadOnly = True
        dgvParaclinicos.Columns("dgcantidadp").ReadOnly = True
        dgvProcedimiento.Columns(0).ReadOnly = True
        dgvProcedimiento.Columns(1).ReadOnly = True
        dgvProcedimiento.Columns("dgcantidadps").ReadOnly = True
        dgvHemoderivado.Columns(0).ReadOnly = True
        dgvHemoderivado.Columns(1).ReadOnly = True
        dgvHemoderivado.Columns("dgcantidadh").ReadOnly = True
        dgvMedicamentos.Columns(1).ReadOnly = True
        dgvMedicamentos.Columns(2).ReadOnly = True
        dgvMedicamentos.Columns("dgcantidad").ReadOnly = True
        dgvInsumos.Columns(1).ReadOnly = True
        dgvInsumos.Columns(2).ReadOnly = True
        dgvInsumos.Columns("dgcantidadi").ReadOnly = True
        btsolitudLab.Enabled = False
    End Sub
    Public Sub habilitarControles()
        dgvParaclinicos.Columns("dgcantidadp").ReadOnly = False
        dgvProcedimiento.Columns("dgcantidadps").ReadOnly = False
        dgvHemoderivado.Columns("dgcantidadh").ReadOnly = False
        dgvMedicamentos.Columns("dgcantidad").ReadOnly = False
        dgvInsumos.Columns("dgcantidadi").ReadOnly = False
        fechaAtencion.Enabled = True
    End Sub
    Public Sub limpiarControles()
        txtobservacion.Clear()
        textNombre.Clear()
        TextCodEPS.Clear()
        textedad.Clear()
        textEPS.Clear()
        textPaciente.Clear()
        txtCodigo.Clear()
        txtCitaMedica.Clear()
        txtEstado.Clear()
        TextSexo.Clear()
        CmbEPS.SelectedValue = -1
        objAtencion.dtHemoderivados.Clear()
        objAtencion.dtInsumo.Clear()
        objAtencion.dtMedicamentos.Clear()
        objAtencion.dtParaclinicos.Clear()
        objAtencion.dtProcedimiento.Clear()
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            btnuevo.Enabled = False
            btguardar.Enabled = True
            TabPaciente.SelectedIndex = 0
            objAtencion.dtImagen.Clear()
            btcancelar.Enabled = True
            btbuscar.Enabled = False
            bteditar.Enabled = False
            btimprimir.Enabled = False
            btanular.Enabled = False
            bteditar.Visible = True
            btanular.Visible = True
            fechaAtencion.Text = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
            btbuscarPaciente.Enabled = True
            btBuscarCitaM.Enabled = True
            txtobservacion.ReadOnly = False
            btbuscarPaciente.Enabled = True
            limpiarControles()
            habilitarControles()
            dgvParaclinicos.Columns("dgcantidadp").ReadOnly = False
            objAtencion.dtParaclinicos.Rows.Add()
            objAtencion.dtProcedimiento.Rows.Add()
            objAtencion.dtHemoderivados.Rows.Add()
            objAtencion.dtMedicamentos.Rows.Add()
            objAtencion.dtInsumo.Rows.Add()
            dgvParaclinicos.Rows(dgvParaclinicos.Rows.Count - 1).Cells("dgResultadoPara").Value = My.Resources._new
            dgvMedicamentos.Columns("dgcodigooculto").Visible = False
            dgvInsumos.Columns("dgcodigoin").Visible = False
            btOpcionChequeo.Enabled = False
            btOpcionChequeo.Image = Global.Celer.My.Resources.check_nada_23
            btOpcionChequeo.BackColor = Color.Transparent
            btOpcionChequeo.ForeColor = Color.Black
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub cargarParaclinicos()
        objAtencion.codigoAtencion = txtCodigo.Text
        objAtencion.cargarParaclinicos()
        dgvParaclinicos.DataSource = objAtencion.dtParaclinicos
        verificarResultados()
    End Sub
    Public Sub cargarProcedimientos()
        objAtencion.codigoAtencion = txtCodigo.Text
        objAtencion.cargarProcedimientos()
        dgvProcedimiento.DataSource = objAtencion.dtProcedimiento
    End Sub
    Public Sub cargarHemoderivados()
        objAtencion.codigoAtencion = txtCodigo.Text
        objAtencion.cargarHemoderivados()
        dgvHemoderivado.DataSource = objAtencion.dtHemoderivados
    End Sub
    Public Sub cargarMedicamentos()
        objAtencion.codigoAtencion = txtCodigo.Text
        objAtencion.cargarMedicamentos()
        dgvMedicamentos.DataSource = objAtencion.dtMedicamentos
    End Sub
    Public Sub cargarInsumos()
        objAtencion.codigoAtencion = txtCodigo.Text
        objAtencion.cargarInsumos()
        dgvInsumos.DataSource = objAtencion.dtInsumo
    End Sub

    Private Sub dgvExamenParaclinicos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvParaclinicos.CellDoubleClick
        If txtCodigo.Text <> "" AndAlso Funciones.filaValida(e.RowIndex) AndAlso e.ColumnIndex = dgvParaclinicos.Columns("dgResultadoPara").Index Then
            Try
                Dim paraclinicoLab As New AtencionParaclinicoLaboratorio
                paraclinicoLab.codigoOrden = txtCodigo.Text
                paraclinicoLab.codigoProcedimiento = dgvParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Cells("dgCodigo").Value
                paraclinicoLab.cargarNombrePDF()
                paraclinicoLab.areaExamen = "A"
                paraclinicoLab.imprimir()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
        If btguardar.Enabled = False OrElse e.RowIndex < 0 Then
            Exit Sub
        End If
        If (dgvParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Cells("dgdescripcionp").Selected = True _
                OrElse dgvParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Cells("dgCodigo").Selected = True) _
                And objAtencion.dtParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Item("Codigo").ToString = "" Then
            Dim params As New List(Of String)
            objAtencion.codigoContrato = CmbEPS.SelectedValue
            params.Add(objAtencion.codigoContrato)
            params.Add(ConstantesAsis.CODIGO_TARIFA_LABORATORIO)
            params.Add(Constantes.GRUPO_PARACLINICO)
            General.busquedaItems(ConsultasAsis.BUSQUEDA_GRUPO_CUPS_FACT, params, TitulosForm.BUSQUEDA_PARACLINICO, dgvParaclinicos,
                                  objAtencion.dtParaclinicos, 0, 1, dgvParaclinicos.Columns("dgdescripcionp").Index,, True, 0)
            For i = 0 To dgvParaclinicos.Rows.Count - 1
                If String.IsNullOrEmpty(dgvParaclinicos.Rows(i).Cells("Resultado").Value.ToString) Then
                    dgvParaclinicos.Rows(i).Cells("dgResultadoPara").Value = My.Resources._new
                End If
            Next
        ElseIf dgvParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Cells("dgAnular").Selected = True _
            And objAtencion.dtParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Item("Codigo").ToString <> "" Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                dgvParaclinicos.DataSource.Rows.RemoveAt(dgvParaclinicos.CurrentCell.RowIndex)
            End If

        End If
    End Sub

    Private Sub DataGridView2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHemoderivado.CellDoubleClick
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        If (dgvHemoderivado.Rows(dgvHemoderivado.CurrentCell.RowIndex).Cells("dgDescripcionh").Selected = True _
                OrElse dgvHemoderivado.Rows(dgvHemoderivado.CurrentCell.RowIndex).Cells("dgCodigoh").Selected = True) _
                And objAtencion.dtHemoderivados.Rows(dgvHemoderivado.CurrentCell.RowIndex).Item("Codigo").ToString = "" Then
            Dim params As New List(Of String)
            objAtencion.codigoContrato = CmbEPS.SelectedValue
            params.Add(objAtencion.codigoContrato)
            params.Add(ConstantesAsis.CODIGO_TARIFA_PROCEDIMIENTOS)
            params.Add(Constantes.GRUPO_HEMODERIVADO & "," & Constantes.GRUPO_TRANSFUSION)
            General.busquedaItems(ConsultasAsis.BUSQUEDA_GRUPO_CUPS_FACT, params, TitulosForm.BUSQUEDA_HEMODERIVADO, dgvHemoderivado,
                                  objAtencion.dtHemoderivados, 0, 1, dgvHemoderivado.Columns("dgDescripcionh").Index,
                                  False, True, 0)
        ElseIf dgvHemoderivado.Rows(dgvHemoderivado.CurrentCell.RowIndex).Cells("dgAnularh").Selected = True _
            And objAtencion.dtHemoderivados.Rows(dgvHemoderivado.CurrentCell.RowIndex).Item("Codigo").ToString <> "" Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                dgvHemoderivado.DataSource.Rows.RemoveAt(dgvHemoderivado.CurrentCell.RowIndex)
            End If
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea cancelar este registro?", 32 + 1, "cancelar") = 1 Then
            fechaAtencion.Text = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
            btcancelar.Enabled = False
            btnuevo.Enabled = True
            btbuscar.Enabled = True
            bteditar.Enabled = False
            btanular.Enabled = False
            btguardar.Enabled = False
            btbuscarPaciente.Enabled = False
            btBuscarCitaM.Enabled = False
            txtEstado.Clear()
            CmbEPS.Enabled = False
            fechaAtencion.Text = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
            limpiarControles()
            deshabilitarControles()
            btimprimir.Enabled = False
            btOpcionChequeo.Enabled = False
            btOpcionChequeo.Image = Global.Celer.My.Resources.check_nada_23
            btOpcionChequeo.BackColor = Color.Transparent
            btOpcionChequeo.ForeColor = Color.Black
        End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then

            btguardar.Enabled = True
            bteditar.Enabled = False
            btbuscar.Enabled = False
            btanular.Enabled = False
            btnuevo.Enabled = False
            btcancelar.Enabled = True
            btimprimir.Enabled = False
            CmbEPS.Enabled = True
            habilitarControles()
            objAtencion.dtParaclinicos.Rows.Add()
            objAtencion.dtProcedimiento.Rows.Add()
            objAtencion.dtHemoderivados.Rows.Add()
            objAtencion.dtMedicamentos.Rows.Add()
            objAtencion.dtInsumo.Rows.Add()
            dgvParaclinicos.Rows(dgvParaclinicos.Rows.Count - 1).Cells("dgResultadoPara").Value = My.Resources._new
            txtobservacion.ReadOnly = False
            dgvMedicamentos.Columns("dgcodigooculto").Visible = False
            dgvInsumos.Columns("dgcodigoin").Visible = False
            btOpcionChequeo.Enabled = False
            btOpcionChequeo.Image = Global.Celer.My.Resources.check_nada_23
            btsolitudLab.Enabled = False
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add(Nothing)
            params.Add(SesionActual.codigoEP)
            General.buscarElemento(Consultas.ATENCION_LAB_BUSCAR,
                             params,
                             AddressOf cargarPaciente,
                             TitulosForm.BUSQUEDA_PACIENTE,
                             True, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Public Sub cargarPaciente(pCodigo As String)
        Dim drFila As DataRow
        Dim params As New List(Of String)

        params.Add(pCodigo)
        drFila = General.cargarItem(Consultas.ATENCION_LAB_CARGAR, params)
        If Not drFila Is Nothing Then
            btsolitudLab.Enabled = True
            txtCodigo.Text = drFila.Item(0)
            textPaciente.Text = drFila.Item(1)
            textNombre.Text = drFila.Item(2)
            TextCodEPS.Text = drFila.Item(3)
            textEPS.Text = drFila.Item(4)
            textedad.Text = drFila.Item(5)
            TextSexo.Text = drFila.Item(6)
            objAtencion.idEps = drFila.Item(8)
            txtobservacion.Text = drFila.Item(9)
            cargarComboCliente()
            CmbEPS.SelectedValue = drFila.Item(7)
            txtCitaMedica.Text = drFila.Item(10)
            fechaAtencion.Text = drFila.Item(11)
            CmbEPS.Enabled = False
            cargarParaclinicos()
            cargarInsumos()
            cargarMedicamentos()
            cargarProcedimientos()
            cargarHemoderivados()
            dgvMedicamentos.Columns("dgcodigooculto").Visible = False
            dgvInsumos.Columns("dgcodigoin").Visible = False
            bteditar.Enabled = True
            btcancelar.Enabled = False
            btimprimir.Enabled = True
            btanular.Enabled = True

            Dim param As New List(Of String)
            param.Add(txtCodigo.Text)
            If General.getEstadoVF(Consultas.ATENCION_LAB_VERIFICAR, params) Then
                txtEstado.Text = Constantes.LABPENDIENTE
                bteditar.Visible = True
                btanular.Visible = True
                ToolStripSeparator7.Visible = True
                ToolStripSeparator5.Visible = True
            Else
                txtEstado.Text = Constantes.LABFACTURADO
                bteditar.Visible = False
                btanular.Visible = False
                ToolStripSeparator7.Visible = False
                ToolStripSeparator5.Visible = False
            End If
            btguardarimagen.Enabled = True
            btexaminar.Enabled = True
            combodescripciondocu.Enabled = True
            cargarDocumentos()
            combodescripciondocu.Visible = False
            btguardarimagen.Enabled = False
            Labeltipodoc.Visible = False
        End If
        txtCodigo.Text = pCodigo
        objLista.codigoAtencion = txtCodigo.Text
        btOpcionChequeo.Enabled = True
        btConsolidado.Enabled = True
        cargarLista()
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim params As New List(Of String)
                params.Add(txtCodigo.Text)
                params.Add(SesionActual.idUsuario)
                General.ejecutarSQL(Consultas.ATENCION_LAB_ANULAR, params)
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                btanular.Enabled = False
                btguardar.Enabled = False
                bteditar.Enabled = False
                btnuevo.Enabled = True
                txtEstado.Clear()
                btbuscar.Enabled = True
                btimprimir.Enabled = False
                btcancelar.Enabled = False
                General.deshabilitarControles(Me)
                General.limpiarControles(Me)
                dgvMedicamentos.Columns("dgcodigooculto").Visible = False
                dgvInsumos.Columns("dgcodigoin").Visible = False
                btOpcionChequeo.Enabled = False
                btOpcionChequeo.Image = Global.Celer.My.Resources.check_nada_23
                btOpcionChequeo.BackColor = Color.Transparent
                btOpcionChequeo.ForeColor = Color.Black
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If btguardar.Enabled = True Then
            MsgBox("Por favor guarde la información atencion laboratorio", MsgBoxStyle.Information)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try
            Dim ruta, area, nombreArchivo As String
            area = ConstantesHC.NOMBRE_PDF_ATENCION_LAB
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtCodigo.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            guardarLaboratorio()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub guardarLaboratorio()
        Try

            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_ATENCION_LAB, txtCodigo.Text, New rptAtencionLab,
                                    txtCodigo.Text, "{VISTA_ATENCION_LABORATORIO.Codigo} = " & txtCodigo.Text & "",
                                    ConstantesHC.NOMBRE_PDF_ATENCION_LAB, IO.Path.GetTempPath)

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub dgvParaclinicos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvParaclinicos.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivo
    End Sub

    Private Sub dgvProcedimiento_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvProcedimiento.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivo
    End Sub

    Private Sub dgvHemoderivado_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvHemoderivado.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivo
    End Sub

    Private Sub dgvMedicamentos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvMedicamentos.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivo
    End Sub

    Private Sub dgvInsumos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvInsumos.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivo
    End Sub

    Private Sub btBuscarCitaM_Click(sender As Object, e As EventArgs) Handles btBuscarCitaM.Click
        Dim params As New List(Of String)
        params.Add(Nothing)
        params.Add(SesionActual.codigoEP)
        General.buscarElemento(Consultas.PACIENTE_CITA_MEDICA_BUSCAR,
                             params,
                             AddressOf cargarPacienteCitas,
                             TitulosForm.BUSQUEDA_PACIENTE,
                             True, 0, True)
    End Sub

    Private Sub TabPaciente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabPaciente.SelectedIndexChanged
        If TabPaciente.SelectedIndex = 1 Then
            If String.IsNullOrEmpty(txtCodigo.Text) Then
                MsgBox("Solo se puede agregar documentos a un paciente previamente guardado", MsgBoxStyle.Exclamation, "Informacion")
                TabPaciente.SelectedIndex = 0
            End If
            General.cargarCombo(Consultas.TIPO_DOCUMENTO_EXTERNO, "descripcion", "codigo_doc", combodescripciondocu)
        End If
    End Sub

    Private Sub dgvdocumentos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdocumentos.CellContentClick
        If dgvdocumentos.Rows.Count > 0 Then
            Dim bites() As Byte = dgvdocumentos.SelectedCells(3).Value
            Dim ms As New MemoryStream(bites)
            With picturedocu
                If objAtencion.dtImagen.Rows(dgvdocumentos.CurrentCell.RowIndex).Item("Extension_Doc").ToString = Constantes.FORMATO_PDF Then
                    .Image = My.Resources.picpdf
                Else
                    .Image = Image.FromStream(ms)
                    .SizeMode = PictureBoxSizeMode.Zoom
                    .BorderStyle = BorderStyle.None
                End If
            End With
        End If
    End Sub

    Private Sub btexaminar_Click(sender As Object, e As EventArgs) Handles btexaminar.Click
        General.subirimagen(picturedocu, openimagen, True)

        If IsNothing(picturedocu.Image) Then
            btguardarimagen.Enabled = False
            combodescripciondocu.Visible = False
            Labeltipodoc.Visible = False
        Else
            btguardarimagen.Enabled = True
            combodescripciondocu.Visible = True
            Labeltipodoc.Visible = True
            combodescripciondocu.Enabled = True
            combodescripciondocu.Focus()
        End If
    End Sub

    Public Function crearDocumento() As AtencionLaboratorio
        Dim objAtencion As New AtencionLaboratorio
        Dim arrFile() As Byte
        Dim ms As New MemoryStream
        picturedocu.Image.Save(ms, Imaging.ImageFormat.Jpeg)
        arrFile = File.ReadAllBytes(openimagen.FileName)
        objAtencion.codigoAtencion = txtCodigo.Text
        objAtencion.tipoDocumento = combodescripciondocu.SelectedValue
        objAtencion.imagen = arrFile
        objAtencion.extensionDoc = Path.GetExtension(openimagen.FileName).ToLower()
        objAtencion.tipo = Constantes.Tipo_documento
        Return objAtencion
    End Function

    Public Sub cargarDocumentos()
        objAtencion.codigoAtencion = txtCodigo.Text
        objAtencion.tipo = Constantes.Tipo_documento
        objAtencion.cargarDocumentos()
        dgvdocumentos.DataSource = objAtencion.dtImagen
        asignarImagenDatagrid()
    End Sub
    Private Sub asignarImagenDatagrid()
        For indice = 0 To objAtencion.dtImagen.Rows.Count - 1
            If objAtencion.dtImagen.Rows(indice).Item("Extension_Doc").ToString = Constantes.FORMATO_PDF Or IsDBNull(objAtencion.dtImagen.Rows(indice).Item("Extension_Doc")) Then
                dgvdocumentos.Rows(indice).Cells(3).Value = My.Resources.picpdf
            End If
        Next
    End Sub
    Private Sub dgvdocumentos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdocumentos.CellDoubleClick
        If e.ColumnIndex = 0 Then
            Try
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    Dim params As New List(Of String)
                    params.Add(dgvdocumentos.Rows(dgvdocumentos.CurrentCell.RowIndex).Cells(1).Value)
                    params.Add(Constantes.Tipo_documento)
                    General.ejecutarSQL(Consultas.ELIMINAR_DOCUMENTO, params)
                    cargarDocumentos()
                    picturedocu.Image = Nothing
                End If
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        ElseIf e.ColumnIndex = 3 Then
            verArchivo()
        End If
    End Sub
    Private Sub verArchivo()
        Dim params As New List(Of String)
        Dim dt As New DataTable
        params.Add(dgvdocumentos.Rows(dgvdocumentos.CurrentRow.Index).Cells(1).Value.ToString())
        params.Add(Constantes.Tipo_documento)
        Dim tempfileurl As String = System.IO.Path.GetTempPath + DateTime.Now.ToString("yyyyMMdd_HHmmss")
        General.llenarTabla(Consultas.DOCUMENTO_PACIENTE_EXTERNO_CARGAR, params, dt)

        If objAtencion.dtImagen.Rows(dgvdocumentos.CurrentCell.RowIndex).Item("Extension_Doc") = Constantes.FORMATO_PDF Then
            tempfileurl += "-tempdocu" + Constantes.FORMATO_PDF
            My.Computer.FileSystem.WriteAllBytes(tempfileurl, dt.Rows(0).Item("Imagen"), True)
            Process.Start("file://" + tempfileurl)
        Else
            tempfileurl += "-tempimg.png"
            picturedocu.Image.Save(tempfileurl, Imaging.ImageFormat.Png)
            Process.Start("file://" + tempfileurl)
        End If
    End Sub

    Private Sub btguardarimagen_Click(sender As Object, e As EventArgs) Handles btguardarimagen.Click
        If combodescripciondocu.SelectedIndex < 1 Then
            MsgBox("Por favor seleccione el tipo de documento que desea subir", MsgBoxStyle.Exclamation)
            combodescripciondocu.Focus()
        Else
            guardarDocumentos()
        End If
    End Sub

    Public Function crearDocumentos() As AtencionLaboratorio
        Dim objAtencion As New AtencionLaboratorio
        Dim arrFile() As Byte
        Dim ms As New MemoryStream
        picturedocu.Image.Save(ms, Imaging.ImageFormat.Jpeg)
        arrFile = File.ReadAllBytes(openimagen.FileName)
        objAtencion.codigoAtencion = txtCodigo.Text
        objAtencion.tipoDocumento = combodescripciondocu.SelectedValue
        objAtencion.imagen = arrFile
        objAtencion.extensionDoc = Path.GetExtension(openimagen.FileName).ToLower()
        objAtencion.tipo = Constantes.Tipo_documento
        Return objAtencion
    End Function
    Private Sub guardarDocumentos()
        Dim objAtencion As New AtencionLaboratorio
        Dim dtDocumento As New DataTable

        Try

            objAtencion.guardarDocumentos(crearDocumentos())

            btguardarimagen.Enabled = False
            combodescripciondocu.Visible = False
            Labeltipodoc.Visible = False
            cargarDocumentos()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub dgvdocumentos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvdocumentos.DataError

    End Sub
    Public Sub cargarLista()
        objLista.codigoAtencion = txtCodigo.Text
        objLista.cargarMenu()
        verificarListas()
    End Sub
    Public Sub verificarListas()

        For i = 0 To objLista.dsLista.Tables("Table1").Rows.Count - 1
            If objLista.dsLista.Tables("Table1").Rows(i).Item("indice") = 0 Then
                btOpcionChequeo.BackColor = Color.Transparent
                btOpcionChequeo.ForeColor = Color.Black
                btOpcionChequeo.Image = Global.Celer.My.Resources.Resources.atencion
                Exit Sub
            Else
                btOpcionChequeo.BackColor = Color.SeaGreen
                btOpcionChequeo.ForeColor = Color.White
                btOpcionChequeo.Image = Global.Celer.My.Resources.check_nada_23
            End If
        Next
    End Sub
    Private Sub btOpcionChequeo_Click(sender As Object, e As EventArgs) Handles btOpcionChequeo.Click
        Dim form As New FormListaAtencion

        form.registro(objLista, txtCodigo.Text, textNombre.Text, fechaAtencion.Text, textEPS.Text)
        FormPrincipal.Cursor = Cursors.WaitCursor
        form.ShowDialog()
        If form.WindowState = FormWindowState.Minimized Then
            form.WindowState = FormWindowState.Normal
        End If
        verificarListas()
        FormPrincipal.Cursor = Cursors.Default
    End Sub

    Private Sub dgvParaclinicos_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvParaclinicos.CellContentDoubleClick
        If dgvParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Cells("dgResultadoPara").Selected = True _
            AndAlso String.IsNullOrEmpty(dgvParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Cells("Resultado").ToString) _
            AndAlso dgvParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Cells("Resultado").ToString > 0 Then

        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btConsolidado.Click
        'If SesionActual.tienePermiso(pConsolidado) Then
        Cursor = Cursors.WaitCursor
        btConsolidado.Enabled = False
        btConsolidado.Text = "Generando..."
        Try

            objAtencion.crearConsolidado()
            Dim dgv As DataGridView
            If Visible Then
                pnlConsolidado.Visible = True
                dgv = dgvConsolidado
            Else
                'fPadre.pnlConsolidado.Visible = True
                'dgv = fPadre.dgvConsolidado
                'fPadre.GroupBox1.Enabled = False
            End If

            For i = 0 To objAtencion.dtParaclinicos.Rows.Count - 1
                objAtencion.codigoProcedimiento.Add(objAtencion.dtParaclinicos.Rows(i).Item("Codigo"))
            Next


            dgv.DataSource = objAtencion.objConsolidado.dtProcesos
            dgv.Enabled = False
            dgv.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            dgv.Columns(0).Width = 150
            dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            dgv.Columns(1).Width = 71
            btOpcionConsolidado.Enabled = True
            objAtencion.objConsolidado.iniciarProcesos()
            Dim guardarEn2doPlano As Thread
            guardarEn2doPlano = New Thread(AddressOf generarVistaPrevia)
            guardarEn2doPlano.Name = "Generar Vista Previa"
            guardarEn2doPlano.SetApartmentState(ApartmentState.STA)
            guardarEn2doPlano.Start()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
        'Else
        '    MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        'End If
    End Sub

    Private Sub generarVistaPrevia()
        Try
            Dim formPlataforma As New FormVisorPlataformaDoc
            formPlataforma.consolidado(objPrincipal)

            objAtencion.generarVistaPrevia(SesionActual.idUsuario, textNombre.Text, formPlataforma)
            If Not objAtencion.objConsolidado.errorGeneracion Then
                Application.Run(formPlataforma)
            End If
            If Not String.IsNullOrEmpty(objAtencion.mostrarErrores()) Then
                General.mensajeCritico("Hubo errores al generar algunos soportes. " & ConstantesError.COMUNICAR_SISTEMA, objAtencion.mostrarErrores())
            End If

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        If Visible Then
            pnlConsolidado.Visible = False
            btConsolidado.Text = "Consolidado"
            btConsolidado.Enabled = True
        Else
            'fPadre.pnlConsolidado.Visible = False
        End If
    End Sub

    Private Sub btOpcionCitas_Click(sender As Object, e As EventArgs) Handles btOpcionCitas.Click
        Dim formCitaM As New FormCitaMedica
        formCitaM.fechaHora = Convert.ToDateTime(Funciones.Fecha(23))
        formCitaM.Tag = Tag
        formCitaM.ShowDialog()

    End Sub


    Private Sub dgvProcedimiento_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProcedimiento.CellDoubleClick
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        If (dgvProcedimiento.Rows(dgvProcedimiento.CurrentCell.RowIndex).Cells("dgDescripcionPs").Selected = True _
             OrElse dgvProcedimiento.Rows(dgvProcedimiento.CurrentCell.RowIndex).Cells("dgCodigoP").Selected = True) _
                And objAtencion.dtProcedimiento.Rows(dgvProcedimiento.CurrentCell.RowIndex).Item("Codigo").ToString = "" Then
            Dim params As New List(Of String)
            objAtencion.codigoContrato = CmbEPS.SelectedValue
            params.Add(objAtencion.codigoContrato)
            params.Add(ConstantesAsis.CODIGO_TARIFA_PROCEDIMIENTOS)
            params.Add(Constantes.GRUPO_PROCEDIMIENTO & "," & Constantes.GRUPO_TERAPIA & "," & Constantes.GRUPO_HEMODIALISIS & "," & Constantes.GRUPO_QUIRURGICO)
            General.busquedaItems(ConsultasAsis.BUSQUEDA_GRUPO_CUPS_FACT, params, TitulosForm.BUSQUEDA_PROCEDIMIENTO, dgvProcedimiento,
                                  objAtencion.dtProcedimiento, 0, 1, dgvProcedimiento.Columns("dgDescripcionPs").Index,
                                  False, True, 0)
        ElseIf dgvProcedimiento.Rows(dgvProcedimiento.CurrentCell.RowIndex).Cells("dganularps").Selected = True _
            And objAtencion.dtProcedimiento.Rows(dgvProcedimiento.CurrentCell.RowIndex).Item("Codigo").ToString <> "" Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                dgvProcedimiento.DataSource.Rows.RemoveAt(dgvProcedimiento.CurrentCell.RowIndex)
            End If
        End If
    End Sub

    Private Sub dgvMedicamentos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMedicamentos.CellDoubleClick

        If btguardar.Enabled = False Then
            Exit Sub
        End If
        If (dgvMedicamentos.Rows(dgvMedicamentos.CurrentCell.RowIndex).Cells("dgDescripcionM").Selected = True _
             OrElse dgvMedicamentos.Rows(dgvMedicamentos.CurrentCell.RowIndex).Cells("dgCodigom").Selected = True) _
                And objAtencion.dtMedicamentos.Rows(dgvMedicamentos.CurrentCell.RowIndex).Item("Codigo").ToString = "" Then
            Dim params As New List(Of String)
            objAtencion.codigoContrato = CmbEPS.SelectedValue
            params.Add(objAtencion.codigoContrato)
            params.Add(Constantes.LINEA_MEDICAMENTO & "," & Constantes.LINEA_INSUMO_Y_MEDICAMENTO)
            General.busquedaItems(ConsultasAsis.BUSQUEDA_MEDICAMENTO_FACT, params, TitulosForm.BUSQUEDA_MEDICAMENTO, dgvMedicamentos,
                                  objAtencion.dtMedicamentos, 0, 2, dgvMedicamentos.Columns("dgDescripcionM").Index,
                                  True, True, 0)
        ElseIf dgvMedicamentos.Rows(dgvMedicamentos.CurrentCell.RowIndex).Cells("dganularm").Selected = True _
            And objAtencion.dtMedicamentos.Rows(dgvMedicamentos.CurrentCell.RowIndex).Item("Codigo").ToString <> "" Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                dgvMedicamentos.DataSource.Rows.RemoveAt(dgvMedicamentos.CurrentCell.RowIndex)
            End If
        End If
    End Sub

    Private Sub dgvInsumos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInsumos.CellDoubleClick
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        If (dgvInsumos.Rows(dgvInsumos.CurrentCell.RowIndex).Cells("dgDescripcionI").Selected = True _
             OrElse dgvInsumos.Rows(dgvInsumos.CurrentCell.RowIndex).Cells("dgCodigoi").Selected = True) _
                And objAtencion.dtInsumo.Rows(dgvInsumos.CurrentCell.RowIndex).Item("Codigo").ToString = "" Then
            Dim params As New List(Of String)
            objAtencion.codigoContrato = CmbEPS.SelectedValue
            params.Add(objAtencion.codigoContrato)
            params.Add(Constantes.LINEA_INSUMO & "," & Constantes.LINEA_INSUMO_Y_MEDICAMENTO & "," & Constantes.LINEA_LIQUIDO_GRAN_VOLUMEN)
            General.busquedaItems(ConsultasAsis.BUSQUEDA_MEDICAMENTO_FACT, params, TitulosForm.BUSQUEDA_MEDICAMENTO, dgvInsumos,
                                  objAtencion.dtInsumo, 0, 2, dgvInsumos.Columns("dgDescripcionI").Index,
                                  True, True, 0)
        ElseIf dgvInsumos.Rows(dgvInsumos.CurrentCell.RowIndex).Cells("dganulari").Selected = True _
            And objAtencion.dtInsumo.Rows(dgvInsumos.CurrentCell.RowIndex).Item("Codigo").ToString <> "" Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                dgvInsumos.DataSource.Rows.RemoveAt(dgvInsumos.CurrentCell.RowIndex)
            End If
        End If
    End Sub
    Public Function validarControles()
        If String.IsNullOrEmpty(textNombre.Text) Then
            MsgBox("Debe seleccionar el paciente", MsgBoxStyle.Exclamation)
            textNombre.Focus()
            Return False
        ElseIf CmbEPS.SelectedValue = -1 Then
            MsgBox("Debe seleccionar a quien se debe facturar", MsgBoxStyle.Exclamation)
            CmbEPS.Focus()
            Return False
        ElseIf Funciones.castFromDbItem(objAtencion.dtParaclinicos.Rows.Count = 1) AndAlso
            Funciones.castFromDbItem(objAtencion.dtProcedimiento.Rows.Count = 1) AndAlso
              Funciones.castFromDbItem(objAtencion.dtHemoderivados.Rows.Count = 1) AndAlso
            Funciones.castFromDbItem(objAtencion.dtMedicamentos.Rows.Count = 1) AndAlso
             Funciones.castFromDbItem(objAtencion.dtInsumo.Rows.Count = 1) Then
            MsgBox("No puedes guardar sin hacer algun movimiento", MsgBoxStyle.Exclamation)
            Return False
        ElseIf objAtencion.dtParaclinicos.Select("cantidad=0 and codigo <> ''", "").Count Then
            MsgBox("Debe digitar la cantidad de los paraclinicos", MsgBoxStyle.Exclamation)
            TabControl1.SelectedIndex = 0
            Return False
        ElseIf objAtencion.dtProcedimiento.Select("cantidad=0 and codigo <> ''", "").Count Then
            MsgBox("Debe digitar la cantidad de los procedimientos", MsgBoxStyle.Exclamation)
            TabControl1.SelectedIndex = 1
            Return False
        ElseIf objAtencion.dtHemoderivados.Select("cantidad=0 and codigo <> ''", "").Count Then
            MsgBox("Debe digitar la cantidad de los hemoderivados", MsgBoxStyle.Exclamation)
            TabControl1.SelectedIndex = 2
            Return False
        ElseIf objAtencion.dtMedicamentos.Select("cantidad=0 and codigo <> ''", "").Count Then
            MsgBox("Debe digitar la cantidad de los medicamentos", MsgBoxStyle.Exclamation)
            TabControl1.SelectedIndex = 3
            Return False
        ElseIf objAtencion.dtInsumo.Select("cantidad=0 and codigo <> ''", "").Count Then
            MsgBox("Debe digitar la cantidad de los insumos", MsgBoxStyle.Exclamation)
            TabControl1.SelectedIndex = 4
            Return False
        End If
        Return True
    End Function
    Public Sub guardarAtencion()
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                objAtencion.codigoContrato = CmbEPS.SelectedValue
                objAtencion.fecha = fechaAtencion.Value
                objAtencion.codigoAtencion = txtCodigo.Text
                objAtencion.observacion = txtobservacion.Text
                objAtencion.usuario = SesionActual.idUsuario
                objAtencion.codigoEP = SesionActual.codigoEP
                objAtencion.codigoCita = If(String.IsNullOrEmpty(txtCitaMedica.Text), Nothing, txtCitaMedica.Text)
                objAtencion.guardarAtencion()
                txtCodigo.Text = objAtencion.codigoAtencion
                Dim params As New List(Of String)
                params.Add(txtCodigo.Text)
                If General.getEstadoVF(Consultas.ATENCION_LAB_VERIFICAR, params) Then
                    txtEstado.Text = Constantes.LABPENDIENTE
                End If
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                btguardar.Enabled = False
                bteditar.Enabled = True
                btcancelar.Enabled = False
                btnuevo.Enabled = True
                btanular.Enabled = True
                btbuscar.Enabled = True
                deshabilitarControles()
                btimprimir.Enabled = True
                txtobservacion.ReadOnly = True
                btbuscarPaciente.Enabled = False
                btBuscarCitaM.Enabled = False
                cargarHemoderivados()
                cargarInsumos()
                cargarMedicamentos()
                cargarParaclinicos()
                cargarProcedimientos()
                btOpcionChequeo.Enabled = False
                btOpcionChequeo.Image = Global.Celer.My.Resources.check_nada_23
                btOpcionChequeo.BackColor = Color.Transparent
                btOpcionChequeo.ForeColor = Color.Black
                btsolitudLab.Enabled = True
                btOpcionChequeo.Enabled = True
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgvParaclinicos.EndEdit()
        dgvProcedimiento.EndEdit()
        dgvHemoderivado.EndEdit()
        dgvMedicamentos.EndEdit()
        dgvInsumos.EndEdit()
        objAtencion.dtParaclinicos.AcceptChanges()

        If validarControles() Then
            guardarAtencion()
        End If
    End Sub
End Class