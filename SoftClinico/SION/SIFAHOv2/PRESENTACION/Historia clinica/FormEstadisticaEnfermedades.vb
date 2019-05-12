Public Class FormEstadisticaEnfermedades
    Private Sub FormEstadisticaEnfermedades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim params As New List(Of String)
            params.Add(SesionActual.idUsuario)
            params.Add(SesionActual.codigoEP)
            params.Add(Nothing)
            General.cargarCombo(Consultas.PROC_AREA_SERVICIO_EMPLEADO_LLENAR, params, "Descripción", "Código", comboAreaServicio)
            Dim dtNuevo As DataTable
            dtNuevo = comboAreaServicio.DataSource.copy
            dtNuevo.Rows.Add("-2", "TODOS")
            comboAreaServicio.DataSource = dtNuevo
            comboAreaServicio.SelectedValue = "-2"
            cargarEnfermedades()
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Public Sub cargarEnfermedades()
        If comboAreaServicio.SelectedIndex > 0 Then
            Dim dt As New DataTable
            Dim params As New List(Of String)
            params.Add(inicio.Text)
            params.Add(fin.Text)
            params.Add(comboAreaServicio.SelectedValue)
            General.llenarTabla(Consultas.CONCURRENCIA_ENFERMEDADES_BUSCAR, params, dt)
            dgvDiag.DataSource = dt
            nenfermedades.Text = dt.Rows.Count
        End If
    End Sub

    Private Sub inicio_ValueChanged(sender As Object, e As EventArgs) Handles inicio.ValueChanged
        cargarEnfermedades()
    End Sub

    Private Sub fin_ValueChanged(sender As Object, e As EventArgs) Handles fin.ValueChanged
        cargarEnfermedades()
    End Sub

    Private Sub FormEstadisticaEnfermedades_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub comboAreaServicio_SelectedValueChanged(sender As Object, e As EventArgs) Handles comboAreaServicio.SelectedValueChanged
        If comboAreaServicio.SelectedIndex > 0 Then
            cargarEnfermedades()
        End If
    End Sub
End Class