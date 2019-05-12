Public Class GrupoConfiguracionAuditoriaBLL
    Dim objConfAuditoriaDAL As New GrupoConfiguracionAuditoriaDAL
    Public Function guardarConfAuditoria(ByVal objConfAuditoria As GrupoConfiguracionAuditoria) As String
        Return objConfAuditoriaDAL.guardarConfiguracion(objConfAuditoria)
        Return objConfAuditoria.codigoGrupo
    End Function
End Class
