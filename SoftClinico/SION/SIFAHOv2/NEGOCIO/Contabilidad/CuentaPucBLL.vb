Public Class CuentaPucBLL


    Public Sub guardarCuentaPUC(ByVal objCuentaPUC As CuentaPUC,
                                     ByVal pUsuario As Integer)

        CuentaPucDAL.crearCuentaPUC(objCuentaPUC, pUsuario)
    End Sub

    Public Sub cargarCuentas(ByVal pCodidogPUC As String,
                             ByRef dsCuentas As DataSet)

        CuentaPucDAL.cargarCuentasPadre(pCodidogPUC, dsCuentas)
        CuentaPucDAL.cargarCuentasHijas(pCodidogPUC, dsCuentas)

    End Sub

End Class
