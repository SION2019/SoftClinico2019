Public Class PedidoInternoBLL
    Dim cmd As New PedidoInternoDAL
    Public Function verificarExistenciaPedidoInterno(ByRef objPedido As PedidoInterno) As Boolean
        Return cmd.verificarExistenciaPedidoInterno(objPedido)
    End Function
    Public Sub guardarPedido(ByVal objPedidoInterno As PedidoInterno, ByRef usuario As Integer, ByVal codigoPunto As Integer)
        Try
            cmd.definirGuardado(objPedidoInterno, usuario, codigoPunto)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub AnularPedido(ByRef objPedido As PedidoInterno, ByVal usuario As Integer)
        Try
            cmd.AnularPedido(objPedido, usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
