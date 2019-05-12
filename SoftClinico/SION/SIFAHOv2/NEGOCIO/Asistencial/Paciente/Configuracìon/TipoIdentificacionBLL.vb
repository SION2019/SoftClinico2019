Public Class TipoIdentificacionBLL
    Public Shared Function guardarTipoIdentificacion(objConfiguracion As ConfiguracionGeneral)
        IdentificacionTipoDAL.guardarIdentificacion(objConfiguracion)
        Return objConfiguracion
    End Function

End Class