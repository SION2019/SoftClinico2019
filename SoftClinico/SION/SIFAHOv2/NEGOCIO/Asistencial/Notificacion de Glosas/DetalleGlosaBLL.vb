Public Class DetalleGlosaBLL
    Dim objDetalleGlosaDAL As New DetalleGlosaDAL
    Public Function guardarDetalleGlosa(ByVal objDetalleGlosa As DetalleGlosa)
        Return objDetalleGlosaDAL.crearDetalleGlosa(objDetalleGlosa)
        Return Nothing
    End Function
End Class
