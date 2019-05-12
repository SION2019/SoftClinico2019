Public Class AfilicacionBLL
    Public Shared Function guardarAfiliacion(objConfiguracion As ConfiguracionGeneral)
        AfiliacionDAL.guardarAfiliacion(objConfiguracion)
        Return objConfiguracion
    End Function
End Class