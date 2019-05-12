Public Class EstadoAtencionBLL
    Public Shared Function guardarEstadoAtencion(objConfiguracion As ConfiguracionGeneral)
        EstadoAtencionDAL.guardarEstadoAtencion(objConfiguracion)
        Return objConfiguracion
    End Function

End Class