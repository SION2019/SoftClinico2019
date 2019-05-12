Public Class FormCitaMedica
    Dim perG As New Buscar_Permisos_generales
    Dim objCita As New ProgramCitaMedica
    Dim reporte As New ftp_reportes
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Property objFormularioProgram As FormProgramacionCita
    Property fechaHora As DateTime
    Public Property bandera As Boolean
    Private Sub btbuscarPaciente_Click(sender As Object, e As EventArgs) Handles btbuscarPaciente.Click
        Dim params As New List(Of String)
        params.Add(Nothing)
        General.buscarElemento(Consultas.PACIENTE_EXTERNOS_BUSCAR,
                             params,
                             AddressOf cargarPacienteAM,
                             TitulosForm.BUSQUEDA_PACIENTE,
                             True, 0, True)
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
    Private Sub asignarPermisos()
        permiso_general = perG.buscarPermisoGeneral(Name, Tag.modulo)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
    End Sub
    Private Sub FormAtencionLaboratorio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        asignarPermisos()
        objCita.establecerDGVParaclinico(dgvParaclinicos)
        objCita.establecerDGVprocedimientos(dgvProcedimiento)
        General.deshabilitarControles(Me)
        General.deshabilitarBotones(ToolStrip1)
        btPaciente.Enabled = True
        btConfigCita.Enabled = True
        deshabilitarControles()
        validacionCampoFecha()
        If bandera = True Then
            If txtEstado.Text = Constantes.LABPENDIENTE Then
                botonesIniciales()
                btCancelarCita.Enabled = True
            End If
        Else
            cargarComboMedico()
            cargarComboMinuto()
            btnuevo.Enabled = True
        End If
        dgvParaclinicos.Columns("Resultado").Visible = False
    End Sub
    Private Sub validacionCampoFecha()
        If Not IsNothing(objFormularioProgram) Then
            If objFormularioProgram.comboAreaServicio.SelectedIndex = 0 Then
                validarControlesFechaDia()
            Else
                validarControlesFechaOtros()
            End If
        Else
            validarControlesFechaOtros()
        End If
    End Sub
    Private Sub botonesIniciales()
        btimprimir.Enabled = True
        btanular.Enabled = True
        btnuevo.Enabled = True
        bteditar.Enabled = True
    End Sub
    Public Sub cargarPacienteAM(pCodigo As String)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        drFila = General.cargarItem(ConsultasAmbu.PACIENTE_CARGAR_AM, params)
        objCita.identipaciente = drFila.Item(0)
        textPaciente.Text = drFila.Item(1)
        textNombre.Text = drFila.Item(2)
        TextSexo.Text = drFila.Item(3)
        textEPS.Text = drFila.Item(4)
        textedad.Text = drFila.Item(5)
        TextCodEPS.Text = drFila.Item(6)
        objCita.idEps = drFila.Item(7)
        objCita.celular = drFila.Item(9)
        objCita.identipaciente = pCodigo
        txtfecha.Text = Format(fechaHora, "dd/MM/yyyy HH").ToString
        habilitarControles()
        cbMedico.Enabled = True
        ComboMinuto.Enabled = True
        txtobservacion.ReadOnly = False
    End Sub
    Public Sub cargarComboMedico()
        Dim params As New List(Of String)
        params.Add(Constantes.LISTA_CARGO_CITAS)
        params.Add(SesionActual.idEmpresa)
        General.cargarCombo("[PROC_LISTA_EMPLEADO_CARGO_CITA_BUSCAR] '',", params, "Empleado", "Id_empleado", cbMedico)
    End Sub
    Public Sub deshabilitarControles()
        With dgvParaclinicos
            .ReadOnly = False
            .Columns(0).ReadOnly = True
            .Columns("dgCodigo").ReadOnly = True
            .Columns("dgDescripcionp").ReadOnly = True
            .Columns("dgcantidadp").ReadOnly = True
        End With
        With dgvProcedimiento
            .ReadOnly = False
            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns("dgCodigop").ReadOnly = True
            .Columns("dgcantidadps").ReadOnly = True
        End With
    End Sub
    Public Sub habilitarControles()
        With dgvParaclinicos
            .ReadOnly = False
            .Columns(0).ReadOnly = True
            .Columns("dgDescripcionp").ReadOnly = True
            .Columns("dgcantidadp").ReadOnly = False
        End With
        With dgvProcedimiento
            .ReadOnly = False
            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns("dgcantidadps").ReadOnly = False
        End With
        txtobservacion.ReadOnly = False
        cbMedico.Enabled = True
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.deshabilitarBotones(ToolStrip1)
            General.limpiarControles(Me)
            txtfecha.Text = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
            btguardar.Enabled = True
            btcancelar.Enabled = True
            btbuscarPaciente.Enabled = True
            dtFecha.Enabled = True
            objCita.dtParaclinicos.Rows.Add()
            objCita.dtProcedimiento.Rows.Add()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Public Sub cargarParaclinicos()
        objCita.codigoAtencion = txtCodigo.Text
        objCita.cargarParaclinicos()
        dgvParaclinicos.DataSource = objCita.dtParaclinicos
        dgvParaclinicos.Columns("Resultado").Visible = False
    End Sub
    Public Sub cargarProcedimientos()
        objCita.codigoAtencion = txtCodigo.Text
        objCita.cargarProcedimientos()
        dgvProcedimiento.DataSource = objCita.dtProcedimiento
    End Sub
    Private Sub dgvExamenParaclinicos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvParaclinicos.CellDoubleClick
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        If (dgvParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Cells("dgdescripcionp").Selected = True _
                OrElse dgvParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Cells("dgCodigo").Selected = True) _
                And objCita.dtParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Item("Codigo").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(Constantes.GRUPO_PARACLINICO)
            General.busquedaItems(ConsultasAsis.BUSQUEDA_GRUPO_CUPS_CITA, params, TitulosForm.BUSQUEDA_PARACLINICO, dgvParaclinicos,
                                  objCita.dtParaclinicos, 0, 1, dgvParaclinicos.Columns("dgdescripcionp").Index,
         , True, 0)
        ElseIf dgvParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Cells("dgAnular").Selected = True _
            And objCita.dtParaclinicos.Rows(dgvParaclinicos.CurrentCell.RowIndex).Item("Codigo").ToString <> "" Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                dgvParaclinicos.DataSource.Rows.RemoveAt(dgvParaclinicos.CurrentCell.RowIndex)
            End If
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea cancelar este registro?", 32 + 1, "cancelar") = 1 Then
            General.deshabilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            General.limpiarControles(Me)
            deshabilitarControles()
            txtfecha.Text = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
            btnuevo.Enabled = True
            btbuscar.Enabled = True
            btPaciente.Enabled = True
            btConfigCita.Enabled = True
        End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            General.deshabilitarBotones(ToolStrip1)
            habilitarControles()
            objCita.dtParaclinicos.Rows.Add()
            objCita.dtProcedimiento.Rows.Add()
            ComboMinuto.Enabled = True
            btguardar.Enabled = True
            btcancelar.Enabled = True
            dtFecha.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add(Nothing)
            params.Add(SesionActual.codigoEP)
            General.buscarElemento(Consultas.CITA_MEDICA_BUSCAR,
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
        Dim dt As New DataTable
        params.Add(pCodigo)
        drFila = General.cargarItem(Consultas.CITA_MEDICA_CARGAR, params)
        Try
            If bandera = True Then
                cargarComboMedico()
                objCita.establecerDGVParaclinico(dgvParaclinicos)
                objCita.establecerDGVprocedimientos(dgvProcedimiento)
            End If
            txtCodigo.Text = drFila.Item(0)
            textPaciente.Text = drFila.Item(1)
            textNombre.Text = drFila.Item(2)
            TextCodEPS.Text = drFila.Item(3)
            textEPS.Text = drFila.Item(4)
            textedad.Text = drFila.Item(5)
            TextSexo.Text = drFila.Item(6)
            objCita.idEps = drFila.Item(7)
            txtobservacion.Text = drFila.Item(8)
            dtFecha.Value = Format(drFila.Item(9), "dd/MM/yyyy HH:mm")
            txtfecha.Text = Format(drFila.Item(9), "dd/MM/yyyy HH").ToString
            fechaHora = Convert.ToDateTime(drFila.Item(9))
            cbMedico.SelectedValue = drFila.Item(10).ToString
            ComboMinuto.Text = Format(drFila.Item(9), "mm").ToString
            txtEstado.Text = drFila.Item(11)
            cargarParaclinicos()
            cargarProcedimientos()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim params As New List(Of String)
                params.Add(txtCodigo.Text)
                params.Add(SesionActual.idUsuario)
                General.ejecutarSQL(Consultas.CITA_MEDICA_ANULAR, params)
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                If Not IsNothing(objFormularioProgram) Then
                    objFormularioProgram.validarControles()
                End If
                General.deshabilitarBotones(ToolStrip1)
                General.deshabilitarControles(Me)
                General.limpiarControles(Me)
                btnuevo.Enabled = True
                btbuscar.Enabled = True
                If bandera = True Then
                    Close()
                End If
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try
            Dim ruta, area, nombreArchivo As String
            area = "Reporte_Cita_medica"
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtCodigo.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            reporte.crearReportePDF(area, objCita.identipaciente,
                                               New rptCitaMedical, txtCodigo.Text,
                                               "{VISTA_REPORTE_CITA_MEDICA.Codigo_Cita}= " & txtCodigo.Text &
                                               " and {VISTA_EMPRESAS.Id_empresa}= " & SesionActual.idEmpresa,
                                               area,
                                               IO.Path.GetTempPath)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvParaclinicos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvParaclinicos.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivo
    End Sub

    Private Sub dgvProcedimiento_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvProcedimiento.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivo
    End Sub

    Private Sub dgvHemoderivado_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivo
    End Sub

    Private Sub dgvMedicamentos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivo
    End Sub

    Private Sub dgvInsumos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivo
    End Sub

    Private Sub btPaciente_Click(sender As Object, e As EventArgs) Handles btPaciente.Click
        Dim formPaciente As New Form_paciente
        formPaciente.ShowDialog()
    End Sub
    Private Sub btCancelarCita_Click(sender As Object, e As EventArgs) Handles btCancelarCita.Click
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox("¿Desea cancelar la cita de este registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancelar Cita") = MsgBoxResult.Yes Then
                Dim params As New List(Of String)
                params.Add(1) '--- cancelar por paciente
                params.Add(txtCodigo.Text)
                params.Add(SesionActual.idUsuario)
                General.ejecutarSQL(Consultas.CITA_MEDICA_CANCELAR_CITA, params)
                MsgBox("Cita Cancelada", MsgBoxStyle.Information)
                If Not IsNothing(objFormularioProgram) Then
                    objFormularioProgram.validarControles()
                End If
                General.deshabilitarBotones(ToolStrip1)
                General.deshabilitarControles(Me)
                General.limpiarControles(Me)
                btnuevo.Enabled = True
                btbuscar.Enabled = True
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub cbMedico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMedico.SelectedIndexChanged
        If Not String.IsNullOrEmpty(cbMedico.ValueMember) And bandera = False Then
            validarConfigMedic()
        End If
    End Sub

    Private Sub dgvProcedimiento_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProcedimiento.CellDoubleClick
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        If (dgvProcedimiento.Rows(dgvProcedimiento.CurrentCell.RowIndex).Cells("dgDescripcionPs").Selected = True _
             OrElse dgvProcedimiento.Rows(dgvProcedimiento.CurrentCell.RowIndex).Cells("dgCodigoP").Selected = True) _
                And objCita.dtProcedimiento.Rows(dgvProcedimiento.CurrentCell.RowIndex).Item("Codigo").ToString = "" Then
            Dim params As New List(Of String)
            params.Add(Constantes.GRUPO_PROCEDIMIENTO & "," & Constantes.GRUPO_TERAPIA & "," & Constantes.GRUPO_HEMODIALISIS & "," & Constantes.GRUPO_QUIRURGICO)
            General.busquedaItems(ConsultasAsis.BUSQUEDA_GRUPO_CUPS_CITA, params, TitulosForm.BUSQUEDA_PROCEDIMIENTO, dgvProcedimiento,
                                  objCita.dtProcedimiento, 0, 1, dgvProcedimiento.Columns("dgDescripcionPs").Index,
                                  False, True, 0)
        ElseIf dgvProcedimiento.Rows(dgvProcedimiento.CurrentCell.RowIndex).Cells("dganularps").Selected = True _
            And objCita.dtProcedimiento.Rows(dgvProcedimiento.CurrentCell.RowIndex).Item("Codigo").ToString <> "" Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                dgvProcedimiento.DataSource.Rows.RemoveAt(dgvProcedimiento.CurrentCell.RowIndex)
            End If
        End If
    End Sub

    Public Function validarControles()

        If String.IsNullOrEmpty(textNombre.Text) Then
            MsgBox("Debe seleccionar el paciente", MsgBoxStyle.Exclamation)
            textNombre.Focus()
            Return False
        ElseIf cbMedico.SelectedIndex = 0 Then
            MsgBox("Favor seleccionar el medico", MsgBoxStyle.Exclamation)
            cbMedico.Focus()
            Return False
        ElseIf Funciones.castFromDbItem(objCita.dtParaclinicos.Rows.Count = 1) AndAlso
            Funciones.castFromDbItem(objCita.dtProcedimiento.Rows.Count = 1) Then
            MsgBox("No puedes guardar sin hacer algun movimiento", MsgBoxStyle.Exclamation)
            Return False
        ElseIf objCita.dtParaclinicos.Select("cantidad=0 and codigo <> ''", "").Count Then
            MsgBox("Debe digitar la cantidad de los paraclinicos", MsgBoxStyle.Exclamation)
            TabControl1.SelectedIndex = 0
            Return False
        ElseIf objCita.dtProcedimiento.Select("cantidad=0 and codigo <> ''", "").Count Then
            MsgBox("Debe digitar la cantidad de los procedimientos", MsgBoxStyle.Exclamation)
            TabControl1.SelectedIndex = 1
            Return False
        End If
        Return True
    End Function
    Private Sub cargarObjeto()
        Dim minuto As String
        minuto = ComboMinuto.Text
        objCita.codigoIdMedico = cbMedico.SelectedValue
        objCita.fecha = Format(CDate(If(dtFecha.Visible = True,
                            dtFecha.Value, Convert.ToDateTime(txtfecha.Text & ":" & minuto))), Constantes.FORMATO_FECHA_HORA_ACTUAL)
        objCita.codigoAtencion = txtCodigo.Text
        objCita.observacion = txtobservacion.Text
        objCita.usuario = SesionActual.idUsuario
        objCita.codigoEP = SesionActual.codigoEP
    End Sub

    Private Sub btConfigCita_Click(sender As Object, e As EventArgs) Handles btConfigCita.Click
        Dim formConfigCita As New FormConfigMedicCita
        formConfigCita.formCitaMedica = Me
        formConfigCita.ShowDialog()
    End Sub

    Public Sub guardarCita()
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                cargarObjeto()
                objCita.guardarCitaMedica()
                txtCodigo.Text = objCita.codigoAtencion
                cargarParaclinicos()
                cargarProcedimientos()
                General.habilitarBotones(ToolStrip1)
                General.deshabilitarControles(Me)
                btguardar.Enabled = False
                txtEstado.Text = Constantes.LABPENDIENTE
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                If Not IsNothing(objFormularioProgram) Then
                    objFormularioProgram.validarControles()
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgvParaclinicos.EndEdit()
        dgvProcedimiento.EndEdit()
        objCita.dtParaclinicos.AcceptChanges()
        objCita.dtProcedimiento.AcceptChanges()

        If validarControles() Then
            guardarCita()
        End If

    End Sub
    Private Sub validarConfigMedic()
        Dim params As New List(Of String)
        Dim fila As DataRow
        params.Add(cbMedico.SelectedValue.ToString)
        params.Add(CDate(fechaHora).Date)
        fila = General.cargarItem("[PROC_CONFIGURACION_MEDIC_CITA_CARGAR]", params)
        If Not IsNothing(fila) Then
            If fila.Item("cant_Program") >= fila.Item("cant_actual") Then
                If dtFecha.Visible = False Then
                    If cargarComboMinuto() = False Then
                        MsgBox("¡Este medico a esta hora no tiene cupo disponible ! ", MsgBoxStyle.Information)
                        cbMedico.SelectedIndex = 0
                        Exit Sub
                    End If
                End If
            Else
                MsgBox("¡ No se puedén, asignar mas citas a este medico en esta fecha ! ", MsgBoxStyle.Information)
            End If
        End If
    End Sub
    Private Function cargarComboMinuto() As Boolean
        Dim params As New List(Of String)
        Dim bandera As Boolean
        params.Add(cbMedico.SelectedValue.ToString)
        params.Add(Format(fechaHora, "dd/MM/yyyy"))
        params.Add(Format(fechaHora, "HH"))
        params.Add(SesionActual.codigoEP)
        bandera = UtlidadCitaBLL.cargarCombo("[PROC_MINUTO_MEDICO_CITA]", params, "minutos", "id", ComboMinuto)
        Return bandera
    End Function
    Private Sub validarControlesFechaDia()
        txtfecha.Visible = True
        ComboMinuto.Visible = True
        lmnts.Visible = True
        dtFecha.Visible = False
    End Sub
    Private Sub validarControlesFechaOtros()
        txtfecha.Visible = False
        ComboMinuto.Visible = False
        lmnts.Visible = False
        dtFecha.Visible = True
    End Sub
End Class