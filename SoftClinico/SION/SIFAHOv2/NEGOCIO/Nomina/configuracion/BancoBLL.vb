Public Class BancoBLL
    Dim objBancoDAL As New BancoDAL
    Public Function guardarBanco(ByVal objBanco As Banco) As String
        If String.IsNullOrEmpty(objBanco.codigoBanco) Then
            Return objBancoDAL.CrearBanco(objBanco)
        Else
            objBancoDAL.actualizarBanco(objBanco)
        End If
        Return objBanco.codigoBanco
    End Function
    Public Function anularBanco(ByVal objBanco As Banco) As Boolean
        If objBancoDAL.anularBanco(objBanco) = True Then
            Return True
        Else
            Return False
        End If
    End Function
End Class

