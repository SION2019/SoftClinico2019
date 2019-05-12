Public Class CotizacionBLL
    Dim cmd As New CotizacionDAL
    Public Sub persistirDatos(ByVal obj As Cotizacion,
                              ByVal usuario As Integer)
        cmd.definirTipoDePersistenciaDeDatos(obj, usuario)
    End Sub
    Public Function verificarAnular(ByVal codigo As Integer) As Boolean
        Return cmd.verificarAnular(codigo)
    End Function
    Public Function verificarAnularIndividual(ByVal codigo As Integer) As Boolean
        Return cmd.verificarAnularIndividual(codigo)
    End Function
End Class
