Public Class CuentaCobroBLL
    Dim objCuentaCobroDAL As New CuentaCobroDAL
    Public Sub guardarCuentaCobro(ByRef objCuentaCobro As CuentaCobro, ByVal usuario As Integer)
        Try
            If objCuentaCobro.codigoCuentaCobro = "" Then
                objCuentaCobroDAL.guardarCompra(objCuentaCobro, usuario)
            Else
                objCuentaCobroDAL.actualizarCompra(objCuentaCobro, usuario)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub anularCuentaCobro(ByRef objCuentaCobro As CuentaCobro, ByVal usuario As Integer)
        Try
            objCuentaCobroDAL.anularCuentaCobro(objCuentaCobro, usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
