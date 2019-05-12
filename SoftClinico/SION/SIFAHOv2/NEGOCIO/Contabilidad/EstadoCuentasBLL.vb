Public Class EstadoCuentasBLL
    Dim objEstadoCuentasDAL As New EstadoCuentasDAL
    Public Sub guardarEstadoCuentas(ByVal objEstadoCuentas As EstadoDeCuentas)
        objEstadoCuentasDAL.crearEstadoCuentas(objEstadoCuentas)
    End Sub
End Class
