Public Class InformeEstadisticoGlosaBLL
    Dim objInformeDAL As New InformeEstadisticoGlosaDAL
    Public Sub guardarNotificacionGlosa(ByVal objInformeGlosa As InformeDetalleGlosa)
        objInformeDAL.guardarInformeGlosa(objInformeGlosa)
    End Sub
End Class
