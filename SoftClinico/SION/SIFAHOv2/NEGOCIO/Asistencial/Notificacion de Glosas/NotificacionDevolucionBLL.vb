Public Class NotificacionDevolucionBLL
    Dim objNotificacionDevolucionDAL As New NotificacionDevolucionDAL
    Public Function guardarNotificacionDevolucion(ByVal objNotificacionDevolucion As NotificacionDevolucion)
        If String.IsNullOrEmpty(objNotificacionDevolucion.identificador) Then
            Return objNotificacionDevolucionDAL.crearNotificacionDevolucion(objNotificacionDevolucion)
        Else
            objNotificacionDevolucionDAL.actualizarNotificacionDevolucion(objNotificacionDevolucion)
        End If
        Return objNotificacionDevolucion.identificador
    End Function
End Class
