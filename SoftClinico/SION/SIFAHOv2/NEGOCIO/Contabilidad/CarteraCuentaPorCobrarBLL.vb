Public Class CarteraCuentaPorCobrarBLL
    Dim objcartera_CXC As New CarteraCuentaPorCobrarDAL
    Public Sub guardarCarteraCXC(ByVal objCarteraCXC As CarteraCXC)
        If String.IsNullOrEmpty(objCarteraCXC.identificador) Then
            objcartera_CXC.crearCarteraCXC(objCarteraCXC)
        Else
            objcartera_CXC.actualizarCarteraCXC(objCarteraCXC)
        End If

    End Sub
End Class