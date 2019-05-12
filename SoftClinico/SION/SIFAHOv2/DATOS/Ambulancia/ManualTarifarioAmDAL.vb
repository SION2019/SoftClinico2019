Public Class ManualTarifarioAmDAL
    Public Shared Function guardarManualTarifario(objManualTarifa As ManualTarifarioAM)
        Try
            Using comando = New SqlCommand()
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = objManualTarifa.sqlGuardarManualTarifario
                comando.Parameters.Add(New SqlParameter("@Codigo_Manual", SqlDbType.NVarChar)).Value = objManualTarifa.CodigoManual
                comando.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.NVarChar)).Value = objManualTarifa.Descripcion
                comando.Parameters.Add(New SqlParameter("@Id_EPS", SqlDbType.Int)).Value = objManualTarifa.IdTercero
                comando.Parameters.Add(New SqlParameter("@Id_Empresa", SqlDbType.Int)).Value = objManualTarifa.IdEmpresa
                comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objManualTarifa.Usuario
                comando.Parameters.Add(New SqlParameter("@TablaLPre", SqlDbType.Structured)).Value = objManualTarifa.dtTablaManualTarifario
                objManualTarifa.CodigoManual = CType(comando.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            Throw
        End Try
        Return objManualTarifa
    End Function
End Class
