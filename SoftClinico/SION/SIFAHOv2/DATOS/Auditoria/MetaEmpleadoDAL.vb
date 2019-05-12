Public Class MetaEmpleadoDAL
    Public Shared Sub guardarMeta(ByRef dtMetaAlcanzada As DataTable, fechaMeta As Date)
        Try
            Using comando = New SqlCommand()
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = ConsultasNom.EMPLEADO_META_PERIODO_GUARDAR
                comando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = Format(fechaMeta, Constantes.FORMATO_FECHA2)
                comando.Parameters.Add(New SqlParameter("@CODIGO_EP", SqlDbType.Int)).Value = SesionActual.codigoEP
                comando.Parameters.Add(New SqlParameter("@tblEmpleado", SqlDbType.Structured)).Value = dtMetaAlcanzada
                comando.Parameters.Add(New SqlParameter("@Pusuario", SqlDbType.Int)).Value = SesionActual.idUsuario
                comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
