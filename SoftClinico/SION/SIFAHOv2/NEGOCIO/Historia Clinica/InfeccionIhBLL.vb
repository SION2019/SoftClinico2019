Public Class InfeccionIhBLL
    Dim objInfeccionIH_C As New InfeccionIntrahospitalariaDAL
    Public Function guardarInfeccionIH(ByVal objInfeccionIH As InfeccionIH,
                                         ByVal pUsuario As Integer)
        If String.IsNullOrEmpty(objInfeccionIH.codigoSolicitud) Then
            Return objInfeccionIH_C.crearInfeccionIH(objInfeccionIH, pUsuario)
        Else
            objInfeccionIH_C.actualizarInfeccionIH(objInfeccionIH, pUsuario)
        End If
        Return objInfeccionIH.codigoSolicitud
    End Function

End Class
