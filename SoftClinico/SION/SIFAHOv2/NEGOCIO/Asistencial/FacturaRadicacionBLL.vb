Public Class FacturaRadicacionBLL
    Public Shared Sub calcularFacturaRadicacion(params As FacturaRadicacionParams)
        FacturaRadicacionDAL.calcularFacturaRadicacion(params)
    End Sub
    Public Shared Function obtenerTerceroByNit(ByVal nit As String) As Integer
        Return TerceroDAL.getIdTercero(nit)
    End Function
End Class
