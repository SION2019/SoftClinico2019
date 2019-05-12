Public Class TipoRegimenBLL
    Public Shared Function guardarTipoRegimen(objConfiguracion As ConfiguracionGeneral)
        RegimenTipoDAL.guardarOcupaciones(objConfiguracion)
        Return objConfiguracion
    End Function

End Class