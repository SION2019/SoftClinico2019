Public Class ParametroBLL
    Public Shared Function guardarParametro(objConfiguracion As ConfiguracionGeneral)
        ParametroDAL.guardarparametro(objConfiguracion)
        Return objConfiguracion
    End Function

End Class