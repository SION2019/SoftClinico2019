Public Class NotificacionGlosaBLL
    Dim objNotificacionGlosaDAL As New NotificacionGlosaDAL
    Public Function guardarNotificacionGlosa(ByVal objNotificacionGlosa As NotificacionGlosa)
        If String.IsNullOrEmpty(objNotificacionGlosa.identificador) Then
            Return objNotificacionGlosaDAL.crearNotificacionGlosa(objNotificacionGlosa)
        Else
            objNotificacionGlosaDAL.actualizarNotificacionGlosa(objNotificacionGlosa)
        End If
        Return objNotificacionGlosa.identificador
    End Function
End Class
