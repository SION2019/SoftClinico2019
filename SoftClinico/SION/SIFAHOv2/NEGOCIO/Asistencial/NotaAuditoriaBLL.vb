Public Class NotaAuditoriaBLL
    Public Shared Function guardarNotaAuditoria(objNotaAuditoria As NotaAuditoria)
        NotaAuditoriaDAL.guardarNotaAuditoria(objNotaAuditoria)
        Return objNotaAuditoria
    End Function
End Class
