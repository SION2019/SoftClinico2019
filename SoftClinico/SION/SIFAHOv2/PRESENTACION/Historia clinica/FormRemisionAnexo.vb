Public Class FormRemisionAnexo
    Dim objRemision As New Remision
    Dim reporteParams As New ReporteParams
    Dim vFormPadre As Form_Historia_clinica

    Public Sub cargarDatosParaSolicitud(ByRef vFormPadre As Form_Historia_clinica, codEps As String,
                                        descripcionArea As String, pUsuarioInforme As Integer,
                                        objHistoriaClinica As HistoriaClinica)

        General.limpiarControles(Me)
        General.cargarCombo(Consultas.PRIORIDAD_COMPLEJIDAD_LISTAR, "Descripción", "Código", Comboprioridad)
        General.cargarCombo(Consultas.PRIORIDAD_COMPLEJIDAD_LISTAR, "Descripción", "Código", Combocomplejidad)
        General.cargarCombo(Consultas.ESPECIALIDAD_LISTAR, "Descripción", "Código", Comboespecialidad)
        General.cargarCombo(Consultas.BUSQUEDA_INDICACION & "''", "Descripción", "Código", Combomodalidad)
        General.cargarCombo(Consultas.BUSQUEDA_PROCEDIMIENTO_TRASLADOS & vFormPadre.txtRegistro.Text &
                            "," & codEps & ",''", "Descripción", "Código traslado", Combotraslados)
        Me.vFormPadre = vFormPadre
        Tag = vFormPadre.Tag
        reporteParams.moduloTemporal = Tag.modulo
        reporteParams.nRegistro = vFormPadre.txtRegistro.Text
        reporteParams.usuarioActual = SesionActual.idUsuario
        General.deshabilitarControles(Me)
        objRemision = objHistoriaClinica.objRemision
        objRemision.usuarioReal = objHistoriaClinica.objOrdenMedica.usuarioReal
        objRemision.usuario = SesionActual.idUsuario
        lblentorno.Text = descripcionArea
        cargarDatos(objHistoriaClinica)
        General.habilitarControles(gbGeneral)
        Comboespecialidad.Enabled = False
        Combotraslados.Enabled = False
        fechaRemision.Enabled = True
        ShowDialog()
    End Sub
    Private Sub cargarDatos(objHistoriaClinica As HistoriaClinica)
        objRemision.codigoRemision = ""
        txtregistro.Text = vFormPadre.txtRegistro.Text
        txtidentificacion.Text = vFormPadre.txtHC.Text
        txtfechaingreso.Text = vFormPadre.txtAdmision.Text
        txtpaciente.Text = vFormPadre.txtNombreContrato.Text
        txtsexo.Text = vFormPadre.txtSexo.Text
        txtedad.Text = vFormPadre.txtEdad.Text
        txtcodigocontrato.Text = vFormPadre.txtContrato.Text
        txtcontrato.Text = vFormPadre.txtNombreContrato.Text
        txtcama.Text = If(String.IsNullOrEmpty(vFormPadre.txtCama.Text), vFormPadre.txtCamaN.Text, vFormPadre.txtCama.Text)
        txtCodigoProcedimiento.Text = vFormPadre.dgvProcedimiento.DataSource.Rows(vFormPadre.dgvProcedimiento.CurrentRow.Index).item("Código").ToString
        Txtexamen.Text = vFormPadre.dgvProcedimiento.DataSource.Rows(vFormPadre.dgvProcedimiento.CurrentRow.Index).item("Descripción").ToString
        fechaRemision.Text = Format(vFormPadre.fechaOrdenMedica.Value, Constantes.FORMATO_FECHA_HORA_GEN)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(txtregistro.Text)
        General.llenarTabla(objHistoriaClinica.objEvolucionMedica.consultaUltimaEvolucion, params, dt)
        If dt.Rows.Count = 0 Then Exit Sub
        params.Clear()
        params.Add(dt.Rows(0).Item("Codigo_Evo").ToString())
        dt = New DataTable
        General.llenarTabla(objHistoriaClinica.objEvolucionMedica.evolucionCargar, params, dt)
        If dt.Rows.Count = 0 Then Exit Sub
        txtdatos.Text = dt.Rows(0).Item("Subjetivo").ToString() & vbCrLf &
                        dt.Rows(0).Item("Sig_Vitales").ToString() & vbCrLf &
                        dt.Rows(0).Item("Cab_Cuello").ToString() & vbCrLf &
                        dt.Rows(0).Item("Torax").ToString() & vbCrLf &
                        dt.Rows(0).Item("Card_Pulm").ToString() & vbCrLf &
                        dt.Rows(0).Item("Abdom").ToString() & vbCrLf &
                        dt.Rows(0).Item("Genturinario").ToString() & vbCrLf &
                        dt.Rows(0).Item("Extrem").ToString() & vbCrLf &
                        dt.Rows(0).Item("S_Nerv_Central").ToString() & vbCrLf &
                        dt.Rows(0).Item("Analisis").ToString() & vbCrLf &
                        dt.Rows(0).Item("Plan_Trtmnto").ToString() & vbCrLf
    End Sub
    Private Sub Form_hemodialisis_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If String.IsNullOrEmpty(txtCodigoRemision.Text) AndAlso Not IsNothing(vFormPadre) Then
            If IsNothing(vFormPadre.dgvProcedimiento.Rows(vFormPadre.dgvProcedimiento.CurrentRow.Index).Cells("dgCodigoProce").Tag) = False Then
                Visible = False
                e.Cancel = True
                Exit Sub
            End If
        End If
        If MsgBox(Mensajes.QUITAR_PROCEDIMIENTO, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            e.Cancel = True
        Else
            vFormPadre.eliminaFilaDt(vFormPadre.dgvProcedimiento.DataSource, vFormPadre.dgvProcedimiento.CurrentRow.Index)
        End If
    End Sub
    Private Function validarRemision() As Boolean
        If (Not IsDate(fechaRemision.Text)) Then
            MsgBox("La fecha de la remisión no es valida. Por favor, corrijala.", MsgBoxStyle.Exclamation)
            fechaRemision.Focus()
            Return False
        ElseIf Comboprioridad.SelectedIndex = 0 Then
            MsgBox("Por favor seleccione la prioridad.", MsgBoxStyle.Exclamation)
            Comboprioridad.Focus()
            Return False
        ElseIf Combocomplejidad.SelectedIndex = 0 Then
            MsgBox("Por favor seleccione la complejidad.", MsgBoxStyle.Exclamation)
            Combocomplejidad.Focus()
            Return False
        ElseIf Combomodalidad.SelectedIndex = 0 Then
            MsgBox("Por favor seleccione la modalidad de apoyo o motivo de solicitud.", MsgBoxStyle.Exclamation)
            Combomodalidad.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtantecedentes.Text) Then
            MsgBox("Debe digitar los antecedentes del paciente.", MsgBoxStyle.Exclamation)
            txtantecedentes.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtglasgow.Text) Then
            MsgBox("Debe digitar valores en glasgow.", MsgBoxStyle.Exclamation)
            txtglasgow.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtdescripglasgow.Text) Then
            MsgBox("Debe digitar la descripción de glasgow.", MsgBoxStyle.Exclamation)
            txtdescripglasgow.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtpresionsis.Text) Then
            MsgBox("Debe digitar información de la presión sistólica.", MsgBoxStyle.Exclamation)
            txtpresionsis.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtpresiondias.Text) Then
            MsgBox("Debe digitar información de la presión diastólica.", MsgBoxStyle.Exclamation)
            txtpresiondias.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtfreccar.Text) Then
            MsgBox("Debe digitar información de frecuencia cardíaca.", MsgBoxStyle.Exclamation)
            txtfreccar.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtfrecresp.Text) Then
            MsgBox("Debe digitar información frecuencia cardíaca.", MsgBoxStyle.Exclamation)
            txtfrecresp.Focus()
            Return False
        ElseIf rbambuSI.Checked = True And Combotraslados.SelectedIndex = 0 Then
            MsgBox("Debe seleccionar el servicio de traslado.", MsgBoxStyle.Exclamation)
            Combotraslados.Focus()
            Return False
        ElseIf rboxigenoSI.Checked = True And Comboespecialidad.SelectedIndex = 0 Then
            MsgBox("Debe seleccionar especialidad oxigeno.", MsgBoxStyle.Exclamation)
            Comboespecialidad.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtdatos.Text) Then
            MsgBox("Debe digitar datos médicos.", MsgBoxStyle.Exclamation)
            txtdatos.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub rboxigenoSI_CheckedChanged(sender As Object, e As EventArgs) Handles rboxigenoSI.CheckedChanged
        If rboxigenoSI.Checked = True Then
            Comboespecialidad.Enabled = True
        Else
            Comboespecialidad.SelectedIndex = 0
            Comboespecialidad.Enabled = False
        End If
    End Sub
    Private Sub rbambuSI_CheckedChanged(sender As Object, e As EventArgs) Handles rbambuSI.CheckedChanged
        If rbambuSI.Checked = True Then
            Combotraslados.Enabled = True
        Else
            Combotraslados.SelectedIndex = 0
            Combotraslados.Enabled = False
        End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            If validarRemision() = False Then Exit Sub
            Dim filaActual As DataGridViewRow = vFormPadre.dgvProcedimiento.CurrentRow
            filaActual.Cells("dgCodigoProce").Tag = Me
            Visible = False
            MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)

        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub
    Public Sub guardarInforme(Optional pSegundoPlano As Boolean = False,
                              Optional pCodigoOrden As Integer = Constantes.VALOR_PREDETERMINADO)
        objRemision.codigoEP = SesionActual.codigoEP
        objRemision.codigoRemision = txtCodigoRemision.Text
        objRemision.nRegistro = txtregistro.Text
        objRemision.modalidad = Combomodalidad.SelectedValue
        objRemision.datosMedicos = txtdatos.Text
        objRemision.fechaRemision = fechaRemision.Text
        objRemision.prioridad = Comboprioridad.SelectedValue
        objRemision.complejidad = Combocomplejidad.SelectedValue
        objRemision.otras = txtotras.Text
        objRemision.antecedentes = txtantecedentes.Text
        objRemision.glasgow = txtglasgow.Text
        objRemision.descripglasgow = txtdescripglasgow.Text
        objRemision.presionsis = txtpresionsis.Text
        objRemision.presiondias = txtpresiondias.Text
        objRemision.freccar = txtfreccar.Text
        objRemision.frecresp = txtfrecresp.Text
        objRemision.ambulancia = If(rbambuSI.Checked = True, 1, 0)
        objRemision.traslados = Combotraslados.SelectedValue
        objRemision.oxigeno = If(rboxigenoSI.Checked = True, 1, 0)
        objRemision.especialidad = Comboespecialidad.SelectedValue
        objRemision.codigoOrden = pCodigoOrden
        objRemision.guardarRemision()

    End Sub
End Class