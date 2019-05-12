Public Class FormValoracionASCE
    Dim vASCE As ValoracionASCE
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim seleccion As String
        If cbAletra.Checked = True Then
            seleccion = cbAletra.Text.Substring(0, 1)
        ElseIf cbSomnoliento.Checked = True Then
            seleccion = cbSomnoliento.Text.Substring(0, 1)
        ElseIf cbComa.Checked = True Then
            seleccion = cbComa.Text.Substring(0, 1)
        ElseIf cbEstupuroso.Checked = True Then
            seleccion = cbEstupuroso.Text.Substring(0, 1)
        Else
            seleccion = cbBajoSedacion.Text.Substring(0, 2)
        End If
        vASCE.seleccion = seleccion
        Close()
    End Sub
    Public Sub iniciarForm(ByRef pASCE As ValoracionASCE)
        vASCE = pASCE
    End Sub
End Class