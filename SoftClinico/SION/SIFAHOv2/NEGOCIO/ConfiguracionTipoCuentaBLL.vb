Public Class ConfiguracionTipoCuentaBLL
    Dim objConfiguracionTipoCuentaDAL As New ConfiguracionTipoCuentaDAL
    Public Sub guardar(ByVal objConfiguracionTipoCuenta As ConfiguracionTipoCuenta)
        Me.objConfiguracionTipoCuentaDAL.crearConfiguracion(objConfiguracionTipoCuenta)
    End Sub
End Class
