Public Class PedidoComidaBLL
    Dim pedidoComidaCMD As New PedidoComidaDAL
    Public Sub guardar(ByRef objpedidoComida As PedidoComida, ByVal ususario As String)
        If objpedidoComida.codigo = "" Then
            pedidoComidaCMD.guardar(objpedidoComida, ususario)
        Else
            pedidoComidaCMD.actualizar(objpedidoComida, ususario)
        End If
    End Sub
    Public Sub anular(ByRef objpedidoComida As PedidoComida, ByVal ususario As String)
        Try
            pedidoComidaCMD.anular(objpedidoComida, ususario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function verificarExixtencia(ByRef objpedidoComida As PedidoComida) As Boolean
        Return pedidoComidaCMD.verificarExixtencia(objpedidoComida)
    End Function
    Public Sub anularComida(ByRef objPedidoComida As PedidoComida, ByVal filaActual As Integer, ByVal ususario As String)
        Try
            pedidoComidaCMD.anularComida(objPedidoComida, filaActual, ususario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
