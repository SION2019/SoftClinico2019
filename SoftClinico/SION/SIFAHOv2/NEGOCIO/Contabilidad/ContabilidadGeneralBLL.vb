Public Class ContabilidadGeneralBLL
    Dim objcontabilidadGeneral_C As New ContabilidadGeneralDAL
    Public Function guardarContaGeneral(ByVal objcontaGeneral As ContabilidadGeneral,
                                         ByVal pUsuario As Integer)
        If String.IsNullOrEmpty(objcontaGeneral.identificador) Then
            Return objcontabilidadGeneral_C.crearContabilidadGeneral(objcontaGeneral, pUsuario)
        Else
            objcontabilidadGeneral_C.actualizarContabilidadGeneral(objcontaGeneral, pUsuario)
        End If
        Return objcontaGeneral.comprobante
    End Function
End Class
