Public Class CuentaPorPagarBLL
    Dim objCuentaPorPagarDal As New CuentaPorPagarDAL
    Public Sub guardarCuentaPorPagar(ByVal objCuentaPorPagar As CuentasPorPagar,
                                         ByVal pUsuario As Integer)
        If String.IsNullOrEmpty(objCuentaPorPagar.identificador) Then
            objCuentaPorPagarDal.CuentaPorPagar(objCuentaPorPagar, pUsuario)
        Else
            objCuentaPorPagarDal.actualizarcuentasCXP(objCuentaPorPagar, pUsuario)
        End If
        
    End Sub
End Class
