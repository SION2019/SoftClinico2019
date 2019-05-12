Public Class ViaIngresoBLL
    Public Shared Function guardarViaIngreso(objConfiguracion As ConfiguracionGeneral)
        ViaIngresoDAL.guardarViaIngreso(objConfiguracion)
        Return objConfiguracion
    End Function

End Class