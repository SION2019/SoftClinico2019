Public Class Comidas_D
    Dim cmd As New ComidaDAL
    Public Sub guardarComida(obj As Comida)
        cmd.guardarComida(obj)
    End Sub
    Public Sub actualizarComida(obj As Comida)
        cmd.actualizarComida(obj)
    End Sub
End Class
