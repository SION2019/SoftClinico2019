Public Class ConfiguracionAuditoriaBLL
    Dim objConfAuditoriaDAL As New ConfAuditoriaDAL
    Public Function guardarConfAuditoria(ByVal objConfAuditoria As ConfiguracionAuditoria) As String
        Return objConfAuditoriaDAL.guardarConfiguracion(objConfAuditoria)
        Return objConfAuditoria.idConfig
    End Function

End Class
