Imports System.Data.SqlClient
Public Class GrupoConfiguracionAuditoriaDAL
    Public Function guardarConfiguracion(objConfigAuditoria As GrupoConfiguracionAuditoria) As String
        Try

            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.Parameters.Clear()
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_GRUPO_CONFIGURACION_AUDITORIA_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@codigoGrupo", SqlDbType.NVarChar))
                dbCommand.Parameters("@codigoGrupo").Value = objConfigAuditoria.codigoGrupo
                dbCommand.Parameters.Add(New SqlParameter("@grupoAuditoria", SqlDbType.Structured))
                dbCommand.Parameters("@grupoAuditoria").Value = objConfigAuditoria.dtGrupoConfiguracion
                objConfigAuditoria.codigoGrupo = CType(dbCommand.ExecuteScalar, Integer)
            End Using
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Return objConfigAuditoria.codigoGrupo
    End Function
End Class
