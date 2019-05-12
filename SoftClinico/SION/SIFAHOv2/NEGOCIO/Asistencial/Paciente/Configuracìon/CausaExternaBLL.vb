Public Class CausaExternaBLL
    Public Shared Function guardarCausaexterna(objConfiguracion As ConfiguracionGeneral)
        CausaExternaDAL.guardarCausaexterna(objConfiguracion)
        Return objConfiguracion
    End Function
End Class