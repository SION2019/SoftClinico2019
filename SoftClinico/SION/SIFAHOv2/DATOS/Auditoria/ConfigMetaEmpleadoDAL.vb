Public Class ConfigMetaEmpleadoDAL
    Public Shared Sub guardarMeta(ByRef objMeta As ConfigMetaEmpleado)
        Try
            Using comando = New SqlCommand()
                objMeta.dtEmpleadoMeta.EndInit()
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = objMeta.consultaMetaGuardar
                comando.Parameters.Add(New SqlParameter("@DIACIERRE", SqlDbType.Int)).Value = objMeta.diaCorte
                comando.Parameters.Add(New SqlParameter("@METAHC", SqlDbType.Float)).Value = objMeta.meta1
                comando.Parameters.Add(New SqlParameter("@METAAM", SqlDbType.Float)).Value = objMeta.meta2
                comando.Parameters.Add(New SqlParameter("@METAAF", SqlDbType.Float)).Value = objMeta.meta3
                comando.Parameters.Add(New SqlParameter("@PUSUARIO", SqlDbType.Int)).Value = SesionActual.idUsuario
                comando.Parameters.Add(New SqlParameter("@CODIGO_EP", SqlDbType.Int)).Value = SesionActual.codigoEP
                comando.Parameters.Add(New SqlParameter("@tblEmpleado", SqlDbType.Structured)).Value = objMeta.dtEmpleado
                comando.Parameters.Add(New SqlParameter("@tblEmpleadoD", SqlDbType.Structured)).Value = objMeta.dtEmpleadoMeta
                comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
