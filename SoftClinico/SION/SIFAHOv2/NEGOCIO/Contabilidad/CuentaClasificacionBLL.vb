Public Class CuentaClasificacionBLL

    Public Sub guardarCuentaUCI(objClasificacionCuentaHC As ClasificacionCuentaHC)
        CuentaClasificacionDAL.actualizarClasificacionCuentas(objClasificacionCuentaHC)
    End Sub

End Class
