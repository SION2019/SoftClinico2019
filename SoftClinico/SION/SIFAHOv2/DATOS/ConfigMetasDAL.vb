Public Class ConfigMetasDAL
    Public Shared Function guardarMeta(objSeguimiento As FacturacionDiaria)
        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction()
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.CommandType = CommandType.StoredProcedure
                    comando.CommandText = objSeguimiento.sqlGuardarMeta
                    comando.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.NVarChar)).Value = objSeguimiento.usuario
                    comando.Parameters.Add(New SqlParameter("@TablaMeta", SqlDbType.Structured)).Value = objSeguimiento.dtAsignarMetas
                    comando.ExecuteNonQuery()
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objSeguimiento
    End Function
End Class
