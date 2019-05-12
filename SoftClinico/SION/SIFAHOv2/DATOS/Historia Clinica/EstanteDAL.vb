Public Class EstanteDAL
    Public Shared Function guardarEstante(objEstante As Estante)
        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction()
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.CommandType = CommandType.StoredProcedure
                    comando.Parameters.Clear()
                    comando.CommandText = objEstante.sqlGuardar
                    comando.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.NVarChar)).Value = objEstante.codigoEstante
                    comando.Parameters.Add(New SqlParameter("@Estante", SqlDbType.NVarChar)).Value = objEstante.estante
                    comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objEstante.usuario
                    comando.ExecuteNonQuery()
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objEstante
    End Function
End Class
