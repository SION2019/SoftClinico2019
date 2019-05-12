Public Class CuentasPorCobrarBLL
    Dim objCuentasPorCobrarDal As New CuentasPorCobrarDAL
    Public Sub guardarCuentaPorCobrar(ByVal objCuentaPorCobrar As CuentasPorCobrar,
                                         ByVal pUsuario As Integer)
        If String.IsNullOrEmpty(objCuentaPorCobrar.identificador) Then
            objCuentasPorCobrarDal.CuentaPorCobrar(objCuentaPorCobrar, pUsuario)
        Else
            objCuentasPorCobrarDal.actualizarcuentasCXP(objCuentaPorCobrar, pUsuario)
        End If
    End Sub
    Public Sub guardarNuevaRadicacion(ByVal objCuentaPorCobrar As CuentasPorCobrar)
        objCuentasPorCobrarDal.guardarNuevaFechaRadicacion(objCuentaPorCobrar)
    End Sub
    Public Sub guardarExoneracion(ByVal objCuentaPorCobrar As CuentasPorCobrar)
        objCuentasPorCobrarDal.guardarFactExonerada(objCuentaPorCobrar)
    End Sub
End Class
