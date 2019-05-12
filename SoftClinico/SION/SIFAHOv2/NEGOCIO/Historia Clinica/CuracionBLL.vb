Public Class CuracionBLL
    Dim objCuracionC As New CuracionDAL
    Public Function crearCuracion(objCuracion As Curacion)
        If String.IsNullOrEmpty(objCuracion.codigoCuracion) Then
            Return objCuracionC.crearCuracion(objCuracion)
        Else
            Return objCuracionC.actualizarCuracion(objCuracion)
        End If
        Return objCuracion
    End Function
End Class
