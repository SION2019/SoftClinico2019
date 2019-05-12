Public Class CamaBLL
    Public Shared Function guardarCama(objCama As ConfiguracionCama)
        CamaDAL.guardarCama(objCama)
        Return objCama
    End Function
End Class
