Public Class FormInconveniente
    Public objHistorial As New HistorialBuzon
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim perG As New Buscar_Permisos_generales

    Private Sub FormInconveniente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Peditar = permiso_general & "pp" & "01"

        cargarHistorial()
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Public Sub cargarHistorialRealizado()
        objHistorial.cargarHistorialRealizado()
        dgvHistorial.DataSource = objHistorial.dtHistorial
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

                objHistorial.guardarRespuesta()
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                General.deshabilitarControles(Me)
                btguardar.Enabled = False
                cargarHistorial()
                bteditar.Enabled = True
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Sub dgvHistorial_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHistorial.CellContentClick

    End Sub

    Private Sub dgvHistorial_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHistorial.CellDoubleClick
        General.abrirJustificacion(dgvHistorial, dgvHistorial.DataSource, PanelJustificacionConcurrencia, txtJustificacionParaclinico, "Respuesta", Not btguardar.Enabled)
        General.abrirJustificacion(dgvHistorial, dgvHistorial.DataSource, PanelJustificacionConcurrencia, txtJustificacionParaclinico, "Mensaje", Not btguardar.Enabled)
    End Sub

    Private Sub dgvHistorial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvHistorial.KeyPress
        General.abrirJustificacion(dgvHistorial, dgvHistorial.DataSource, PanelJustificacionConcurrencia, txtJustificacionParaclinico, "Respuesta", Not btguardar.Enabled, e.KeyChar)
        General.abrirJustificacion(dgvHistorial, dgvHistorial.DataSource, PanelJustificacionConcurrencia, txtJustificacionParaclinico, "Mensaje", Not btguardar.Enabled, e.KeyChar)
    End Sub

    Private Sub txtJustificacionParaclinico_Leave(sender As Object, e As EventArgs) Handles txtJustificacionParaclinico.Leave
        Try
            If PanelJustificacionConcurrencia.Visible = True Then
                PanelJustificacionConcurrencia.Visible = False
                If dgvHistorial.Rows(dgvHistorial.CurrentRow.Index).Cells("Respuesta").Selected = True Then
                    dgvHistorial.Rows(dgvHistorial.CurrentRow.Index).Cells("Respuesta").Value = txtJustificacionParaclinico.Text
                ElseIf dgvHistorial.Rows(dgvHistorial.CurrentRow.Index).Cells("Mensaje").Selected = True Then
                    dgvHistorial.Rows(dgvHistorial.CurrentRow.Index).Cells("Mensaje").Value = txtJustificacionParaclinico.Text
                End If
                txtJustificacionParaclinico.Clear()
                dgvHistorial.EndEdit()
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Public Sub cargarHistorial()
        If IsNothing(dgvHistorial.DataSource) Then

            With dgvHistorial

                .Columns("empleado").ReadOnly = True
                .Columns.Item("empleado").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("empleado").DataPropertyName = "Empleado"

                .Columns("cargo").ReadOnly = True
                .Columns.Item("cargo").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("cargo").DataPropertyName = "Cargo"

                .Columns("fecha").ReadOnly = True
                .Columns.Item("fecha").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("fecha").DataPropertyName = "Fecha"

                .Columns("mensaje").ReadOnly = True
                .Columns.Item("mensaje").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("mensaje").DataPropertyName = "Mensaje recibido"

                .Columns("respuesta").ReadOnly = True
                .Columns.Item("respuesta").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("respuesta").DataPropertyName = "Respuesta"

                .Columns("fecha1").ReadOnly = True
                .Columns.Item("fecha1").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("fecha1").DataPropertyName = "Fecha respuesta"

            End With
        End If
        objHistorial.cargarHistorial()
        dgvHistorial.DataSource = objHistorial.dtHistorial
        dgvHistorial.Columns("Código").Visible = False
    End Sub

    Private Sub FormInconveniente_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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


    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            cargarHistorialRealizado()
        Else
            cargarHistorial()
        End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            General.habilitarControles(Me)
            btguardar.Enabled = True
            bteditar.Enabled = False
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub
End Class