Public Class RemisionInventarioBLL
    Dim cmd As New RemisionProductoDAL
    Public Sub guardar(obj As RemisionProducto)
        cmd.guardar(obj)
    End Sub
    Public Sub anular(obj As RemisionProducto)
        cmd.anular(obj)
    End Sub
End Class

