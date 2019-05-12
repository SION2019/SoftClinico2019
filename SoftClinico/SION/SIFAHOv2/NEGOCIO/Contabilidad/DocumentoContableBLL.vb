Public Class DocumentoContableBLL

    Public Sub guardarDocumentoContable(objTipoDocumentoContable As DocumentoContable, pUsuario As Integer)
        Dim documentoDAL As New DocumentoContableDAL

        If String.IsNullOrEmpty(objTipoDocumentoContable.codigo) Then
            documentoDAL.crearDocumentoContable(objTipoDocumentoContable, pUsuario)
        Else
            documentoDAL.actualizarDocumentoContable(objTipoDocumentoContable, pUsuario)
        End If

    End Sub

End Class
