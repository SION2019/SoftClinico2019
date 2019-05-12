Public Class EspecialidadBLL
    Public Shared Function guardarEspecialidades(objConfiguracion As ConfiguracionGeneral)
        EspecialidadDAL.guardarEspecialidades(objConfiguracion)
        Return objConfiguracion
    End Function
End Class