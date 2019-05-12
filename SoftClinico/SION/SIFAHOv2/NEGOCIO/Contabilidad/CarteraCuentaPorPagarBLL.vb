Public Class CarteraCuentaPorPagarBLL
    Dim objcartera_CXP As New CarteraCuentaPorPagarDAL
    Public Sub guardarCarteraCXP(ByVal objcarteraCXP As CarteraCXP)
        If String.IsNullOrEmpty(objcarteraCXP.identificador) Then
            objcartera_CXP.crearCarteraCXP(objcarteraCXP)
        Else
            objcartera_CXP.actualizarCarteraCXP(objcarteraCXP)
        End If

    End Sub
End Class
