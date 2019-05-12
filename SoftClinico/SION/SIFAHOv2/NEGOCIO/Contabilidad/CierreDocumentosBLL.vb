Public Class CierreDocumentosBLL
    Dim objCierreDocumentosDal As New CierreDocumentosDAL
    Public Sub guardarCiereDocumentos(ByVal objCierreDocumentos As CierreDocumentos,
                                         ByVal pUsuario As Integer)
        If String.IsNullOrEmpty(objCierreDocumentos.identificador) Then
            objCierreDocumentosDal.crearCierreDocumento(objCierreDocumentos, pUsuario)
        Else
            objCierreDocumentosDal.actualizarCierreDocumento(objCierreDocumentos, pUsuario)
        End If
    End Sub
End Class
