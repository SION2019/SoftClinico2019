Public Class PedidoFarmaciaBLL
    Dim objPedidoFarmaciaDALL As New PedidoFarmaciaDAL
    Public Sub guardarPedido(ByRef objPedidoFarmacia As PedidoFarmacia,
                             ByVal usuario As Integer,
                             ByVal codigoEP As Integer)
        objPedidoFarmaciaDALL.guardarPedido(objPedidoFarmacia, usuario, codigoEP)
    End Sub
    Public Sub anularPedido(ByRef objPedidoFarmacia As PedidoFarmacia,
                            ByVal usuario As Integer)
        Try
            objPedidoFarmaciaDALL.anularPedido(objPedidoFarmacia, usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function verificarEstadoActualPaciente(ByRef nRegistro As Integer,
                                                   ByVal codigoEstadonIniciado As Integer) As Boolean
        Dim respuesta As Boolean = False
        Try
            Dim objPedidoFarmacaDAL As New PedidoFarmaciaDAL
            respuesta = objPedidoFarmacaDAL.verificarEstadoActualPaciente(nRegistro, codigoEstadonIniciado)
        Catch ex As Exception
            Throw ex
        End Try
        Return respuesta
    End Function
    Public Function verificarPedidoCargado(ByRef objPedido As PedidoFarmacia) As Boolean
        Dim respuesta As Boolean = False
        Try
            Dim objPedidoFarmacaDAL As New PedidoFarmaciaDAL
            respuesta = objPedidoFarmacaDAL.verificarPedidoCargado(objPedido)
        Catch ex As Exception
            Throw ex
        End Try
        Return respuesta
    End Function
End Class
