Public Class Bienvenido
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SesionActual.idUsuario = -1
        FormPrincipal.Show()
        Form_Empresas.MdiParent = FormPrincipal
        Form_Empresas.Show()
        Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dispose()
        InicioSesion.Close()
        Inicio.Close()

    End Sub

    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover, Label2.MouseHover, Panel1.MouseHover
        Label2.ForeColor = Color.White
        Label3.ForeColor = Color.Black
    End Sub

    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover, Label3.MouseHover, Panel2.MouseHover
        Label3.ForeColor = Color.White
        Label2.ForeColor = Color.Black
    End Sub


    Private Sub Bienvenido_MouseHover(sender As Object, e As EventArgs) Handles MyBase.MouseHover, PictureBox1.MouseHover, Label1.MouseHover
        Label2.ForeColor = Color.Black
        Label3.ForeColor = Color.Black
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Button1_Click(sender, e)
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Button2_Click(sender, e)
    End Sub
End Class