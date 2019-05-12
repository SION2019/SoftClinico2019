Public Class DestinoBLL
    Public Shared Function guardarDestino(objConfiguracion As ConfiguracionGeneral)
        DestinoDAL.guardarDestino(objConfiguracion)
        Return objConfiguracion
    End Function
End Class