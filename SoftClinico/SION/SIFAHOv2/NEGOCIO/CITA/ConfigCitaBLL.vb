Public Class ConfigCitaBLL
    Public Shared Function guardarConfigCita(objConfiguracion As ConfigCita)
        ConfigCitaDAL.guardarConfigCita(objConfiguracion)
        Return objConfiguracion
    End Function
End Class