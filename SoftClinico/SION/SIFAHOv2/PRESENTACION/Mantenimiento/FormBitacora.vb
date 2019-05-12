Public Class FormBitacora

    Dim objBitacora As New Bitacora
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim perG As New Buscar_Permisos_generales
    Private Sub FormBitacora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Peditar = permiso_general & "pp" & "01"

        objBitacora.usuario = SesionActual.idUsuario
        objBitacora.codigoEp = SesionActual.codigoEP
        objBitacora.fecha = fechaMantenimiento.Value.Date
        cargarEquipos()
        General.deshabilitarControles(Me)
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Public Sub establecerFecha()

    End Sub

    Private Sub cargarEquipos()
        objBitacora.opcionBiomedico = rbiomedico.Checked
        objBitacora.opcionComputo = rcomputo.Checked
        objBitacora.textBusqueda = busquedaEquipos.Text
        objBitacora.fecha = fechaMantenimiento.Value.Date
        objBitacora.cargarEquipos()
        dgEquipos.ReadOnly = True
        If IsNothing(dgEquipos.DataSource) Then
            With dgEquipos
                .Columns("Equipo").ReadOnly = True
                .Columns.Item("Equipo").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("Equipo").DataPropertyName = "Equipo"

                .Columns("Marca").ReadOnly = True
                .Columns.Item("Marca").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("Marca").DataPropertyName = "Marca"

                .Columns("Modelo").ReadOnly = True
                .Columns.Item("Modelo").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("Modelo").DataPropertyName = "Modelo"

                .Columns("ubicacion").ReadOnly = True
                .Columns.Item("ubicacion").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("ubicacion").DataPropertyName = "Ubicacion"

                .Columns("preventivo").ReadOnly = True
                .Columns.Item("preventivo").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("preventivo").DataPropertyName = "Preventivo"

                .Columns("correctivo").ReadOnly = True
                .Columns.Item("correctivo").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("correctivo").DataPropertyName = "Correctivo"

                .Columns("falla").ReadOnly = True
                .Columns.Item("falla").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("falla").DataPropertyName = "Falla reportada"

                .Columns("trabajo").ReadOnly = True
                .Columns.Item("trabajo").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("trabajo").DataPropertyName = "Trabajo realizado"

                .Columns("observacion").ReadOnly = True
                .Columns.Item("observacion").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("observacion").DataPropertyName = "Observacion"

            End With
        End If

        dgEquipos.DataSource = objBitacora.dtBitacora
        dgEquipos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgEquipos.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)


        nequipos.Text = dgEquipos.DataSource.Rows.Count
        dgEquipos.Columns("Código").Visible = False


    End Sub

    Private Sub FormBitacora_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub rcomputo_CheckedChanged(sender As Object, e As EventArgs) Handles rcomputo.CheckedChanged
        cargarEquipos()
        bteditar.Enabled = True
        btguardar.Enabled = False
    End Sub

    Private Sub rbiomedico_CheckedChanged(sender As Object, e As EventArgs) Handles rbiomedico.CheckedChanged
        cargarEquipos()
        bteditar.Enabled = True
        btguardar.Enabled = False
    End Sub

    Private Sub dgEquipos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgEquipos.DataError

    End Sub

    Private Sub dgEquipos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgEquipos.CellDoubleClick
        General.abrirJustificacion(dgEquipos, dgEquipos.DataSource, PanelJustificacionConcurrencia, txtJustificacionParaclinico, "Falla", Not btguardar.Enabled)
        General.abrirJustificacion(dgEquipos, dgEquipos.DataSource, PanelJustificacionConcurrencia, txtJustificacionParaclinico, "Trabajo", Not btguardar.Enabled)
        General.abrirJustificacion(dgEquipos, dgEquipos.DataSource, PanelJustificacionConcurrencia, txtJustificacionParaclinico, "Observacion", Not btguardar.Enabled)
    End Sub

    Private Sub dgEquipos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgEquipos.KeyPress
        General.abrirJustificacion(dgEquipos, dgEquipos.DataSource, PanelJustificacionConcurrencia, txtJustificacionParaclinico, "Falla", Not btguardar.Enabled, e.KeyChar)
        General.abrirJustificacion(dgEquipos, dgEquipos.DataSource, PanelJustificacionConcurrencia, txtJustificacionParaclinico, "Trabajo", Not btguardar.Enabled, e.KeyChar)
        General.abrirJustificacion(dgEquipos, dgEquipos.DataSource, PanelJustificacionConcurrencia, txtJustificacionParaclinico, "Observacion", Not btguardar.Enabled, e.KeyChar)
    End Sub

    Private Sub txtJustificacionParaclinico_Leave(sender As Object, e As EventArgs) Handles txtJustificacionParaclinico.Leave
        Try
            If PanelJustificacionConcurrencia.Visible = True Then
                PanelJustificacionConcurrencia.Visible = False
                If dgEquipos.Rows(dgEquipos.CurrentRow.Index).Cells("Falla").Selected = True Then
                    dgEquipos.Rows(dgEquipos.CurrentRow.Index).Cells("Falla").Value = txtJustificacionParaclinico.Text
                ElseIf dgEquipos.Rows(dgEquipos.CurrentRow.Index).Cells("Trabajo").Selected = True Then
                    dgEquipos.Rows(dgEquipos.CurrentRow.Index).Cells("Trabajo").Value = txtJustificacionParaclinico.Text
                ElseIf dgEquipos.Rows(dgEquipos.CurrentRow.Index).Cells("Observacion").Selected = True Then
                    dgEquipos.Rows(dgEquipos.CurrentRow.Index).Cells("Observacion").Value = txtJustificacionParaclinico.Text
                    txtJustificacionParaclinico.Clear()
                    dgEquipos.EndEdit()
                End If
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Sub busquedaEquipos_TextChanged(sender As Object, e As EventArgs) Handles busquedaEquipos.TextChanged
        cargarEquipos()
    End Sub

    Private Sub dgEquipos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgEquipos.CellClick
        If dgEquipos.Columns("Detalle").Index = e.ColumnIndex Then
            Dim objHistorial As New HistorialEquipos
            Dim form As New FormHistorialEquipos
            objHistorial.codigo = dgEquipos.Rows(e.RowIndex).Cells("Código").Value
            objHistorial.checkComputo = rcomputo.Checked
            form.cargarHistorial(objHistorial)
            form.ShowDialog()
        End If
    End Sub



    Public Sub deshabilitarControles()
        dgEquipos.Columns("equipo").ReadOnly = True
        dgEquipos.Columns("marca").ReadOnly = True
        dgEquipos.Columns("modelo").ReadOnly = True
        dgEquipos.Columns("ubicacion").ReadOnly = True
        dgEquipos.Columns("falla").ReadOnly = True
        dgEquipos.Columns("trabajo").ReadOnly = True
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        'If SesionActual.tienePermiso(Peditar ) Then
        If rbiomedico.Checked = True Then
                General.habilitarControles(Me)
                deshabilitarControles()
                btcancelar.Enabled = True
                btguardar.Enabled = True
                bteditar.Enabled = False
                GroupBox2.Enabled = True
                dgEquipos.Columns("modelo").ReadOnly = False
                dgEquipos.Columns("ubicacion").ReadOnly = False
            Else
                General.habilitarControles(Me)
                deshabilitarControles()
                btcancelar.Enabled = True
                btguardar.Enabled = True
                bteditar.Enabled = False
                dgEquipos.Columns("Falla").ReadOnly = True
                dgEquipos.Columns("correctivo").ReadOnly = False
                GroupBox2.Enabled = True
            End If

        'Else
        '    MsgBox(Mensajes.SINPERMISO)
        'End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgEquipos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        dgEquipos.EndEdit()
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                If rbiomedico.Checked = True Then
                    objBitacora.guardarBiomedico()
                Else
                    objBitacora.guardar()
                End If

                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                General.deshabilitarControles(Me)
                btguardar.Enabled = False
                btcancelar.Enabled = True
                bteditar.Enabled = True

            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub fechaMantenimiento_ValueChanged(sender As Object, e As EventArgs) Handles fechaMantenimiento.ValueChanged
        cargarEquipos()
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea cancelar este registro?", 32 + 1, "cancelar") = 1 Then
            General.deshabilitarControles(Me)
            btcancelar.Enabled = False
            bteditar.Enabled = True
            btguardar.Enabled = False
            objBitacora.dtBitacora.Clear()
            rbiomedico.Checked = False
            rcomputo.Checked = False
        End If
    End Sub
End Class