Public Class BalanceComprobacionBLL
    Private objBalanceComprobacionDAL As New BalanceComprobacionDAL

    Public Sub calcularBalanceComprobacion(params As BalanceComprobacionParams)
        objBalanceComprobacionDAL.calcularBalanceComprobacion(params)
    End Sub

End Class
