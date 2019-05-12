Public Class institucionesBLL

    Public Shared Function guardarInstitucion(objConfiguracion As ConfiguracionGeneral)
        InstitucionDAL.guardarInstitucion(objConfiguracion)
        Return objConfiguracion
    End Function

End Class