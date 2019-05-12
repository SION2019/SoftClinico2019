
Public Class BajaProductoBLL
    Dim cmd As New BajaProductoDAL
    Public Sub guardarBajaProducto(ByRef objBaja As BajaProducto,
                                   ByVal usuario As Integer,
                                   ByVal Punto As Integer)
        Try
            cmd.guardarBajaProducto(objBaja, usuario, Punto)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub anularBajaProdcuto(ByRef objBaja As BajaProducto,
                                   ByVal usuario As Integer)
        Try
            cmd.anuularBajaProdcuto(objBaja, usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
