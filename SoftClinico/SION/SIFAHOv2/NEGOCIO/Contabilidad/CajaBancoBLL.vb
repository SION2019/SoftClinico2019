Public Class CajaBancoBLL
    Dim objcajaBanco_C As New CajaBancoDAL
    Public Function guardarCajaBanco(ByVal objcajaBanco As CajaBanco,
                                         ByVal pUsuario As Integer)
        If String.IsNullOrEmpty(objcajaBanco.identificador) Then
            Return objcajaBanco_C.crearCajaBanco(objcajaBanco, pUsuario)
        Else
            objcajaBanco_C.actualizarCajaBanco(objcajaBanco, pUsuario)
        End If
        Return objcajaBanco.comprobante
    End Function
End Class
