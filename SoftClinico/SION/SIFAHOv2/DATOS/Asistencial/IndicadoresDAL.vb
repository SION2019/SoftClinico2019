Public Class IndicadoresDAL
    Public Shared Function guardarIndicadoresMetas(objIndicadorMeta As Indicadores)
        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction()
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.CommandType = CommandType.StoredProcedure
                    comando.CommandText = objIndicadorMeta.sqlGuardarIndicadorMeta
                    comando.Parameters.Add(New SqlParameter("@Periodo", SqlDbType.NVarChar)).Value = objIndicadorMeta.periodo
                    comando.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.Int)).Value = objIndicadorMeta.usuario
                    comando.Parameters.Add(New SqlParameter("@TablaMeta", SqlDbType.Structured)).Value = objIndicadorMeta.dtCapacidad
                    objIndicadorMeta.codigo = CType(comando.ExecuteScalar, String)
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
        Return objIndicadorMeta
    End Function
End Class
