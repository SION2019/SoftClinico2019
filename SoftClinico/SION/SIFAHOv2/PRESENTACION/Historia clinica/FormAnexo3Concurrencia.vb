Public Class FormAnexo3Concurrencia
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormAnexo3Concurrencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            cargarDenominadores()
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Public Sub cargarDenominadores()
        Dim dt As New DataTable
        Dim parans As New List(Of String)
        parans.Add(comboAreaServicio.SelectedValue)
        parans.Add(txtfecha.Text)
        General.llenarTabla(Consultas.CONCURRENCIA_DENOMINADORES_BUSCAR, parans, dt)
        dgvDiag.DataSource = dt
        ndenominadores.Text = dt.Rows.Count

        Dim vm, cc, cu, pac As Integer
        vm = 0
        cc = 0
        cu = 0
        pac = 0
        For i = 0 To dgvDiag.RowCount - 1
            vm = vm + CInt(dgvDiag.Rows(i).Cells(1).Value)
            cc = cc + CInt(dgvDiag.Rows(i).Cells(2).Value)
            cu = cu + CInt(dgvDiag.Rows(i).Cells(3).Value)
            pac = pac + CInt(dgvDiag.Rows(i).Cells(4).Value)
        Next
        TextBox1.Text = vm
        TextBox2.Text = cc
        TextBox3.Text = cu
        TextBox4.Text = pac
    End Sub

    Private Sub FormAnexo3Concurrencia_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub txtfecha_ValueChanged_1(sender As Object, e As EventArgs) Handles txtfecha.ValueChanged
        cargarDenominadores()
    End Sub

    Private Sub comboAreaServicio_SelectedValueChanged(sender As Object, e As EventArgs) Handles comboAreaServicio.SelectedValueChanged
        If comboAreaServicio.SelectedIndex > 0 Then
            cargarDenominadores()
        End If
    End Sub
End Class