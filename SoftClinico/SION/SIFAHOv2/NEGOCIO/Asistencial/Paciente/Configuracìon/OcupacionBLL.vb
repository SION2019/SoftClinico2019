Public Class OcupacionBLL
    Public Shared Function guardarOcupaciones(objConfiguracion As ConfiguracionGeneral)
        OcupacionDAL.guardarOcupaciones(objConfiguracion)
        Return objConfiguracion
    End Function

End Class