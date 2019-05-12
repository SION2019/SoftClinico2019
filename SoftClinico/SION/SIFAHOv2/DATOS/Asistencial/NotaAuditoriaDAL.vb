Public Class NotaAuditoriaDAL
    Public Shared Function guardarNotaAuditoria(objNotaAuditoria As NotaAuditoria)
        'Try
        Using comando = New SqlCommand()
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.Clear()
                comando.CommandText = Consultas.NOTA_AUDITORIA_CREAR
                comando.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.NVarChar)).Value = objNotaAuditoria.codigoNota
                comando.Parameters.Add(New SqlParameter("@Regisro", SqlDbType.Int)).Value = objNotaAuditoria.registro
                comando.Parameters.Add(New SqlParameter("@ID_Responsable_Dirg", SqlDbType.Int)).Value = objNotaAuditoria.idResponsableDirig
                comando.Parameters.Add(New SqlParameter("@ID_Responsable_Encarg", SqlDbType.Int)).Value = objNotaAuditoria.idResponsableEncargado
                comando.Parameters.Add(New SqlParameter("@ID_Coordinador", SqlDbType.Int)).Value = objNotaAuditoria.idCoordinador
                comando.Parameters.Add(New SqlParameter("@Titulo", SqlDbType.NVarChar)).Value = objNotaAuditoria.titulo
                comando.Parameters.Add(New SqlParameter("@Nota", SqlDbType.NVarChar)).Value = objNotaAuditoria.nota
                comando.Parameters.Add(New SqlParameter("@fecha_Registro", SqlDbType.DateTime)).Value = objNotaAuditoria.dtFecha
                comando.Parameters.Add(New SqlParameter("@ID_Usuario", SqlDbType.Int)).Value = SesionActual.idUsuario
            comando.Parameters.Add(New SqlParameter("@revisado", SqlDbType.Bit)).Value = objNotaAuditoria.revisado
            comando.Parameters.Add(New SqlParameter("@codigoNotarevisada", SqlDbType.NVarChar)).Value = objNotaAuditoria.codigoNotaRevisada
            objNotaAuditoria.codigoNota = CType(comando.ExecuteScalar, String)
            End Using
            'Catch ex As Exception
            '    Throw
            'End Try
            Return objNotaAuditoria
    End Function
End Class
