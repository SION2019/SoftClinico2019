Public Class EmpleadoMesDAL

    Public Shared Sub guardarEmpleado(objEmpleado As EmpleadoMes)
        Try
            Using comando = New SqlCommand
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "PROC_EMPLEADO_MES_GUARDAR"
                comando.Parameters.Add(New SqlParameter("@idEmpleado", SqlDbType.Int)).Value = objEmpleado.idEmpleado
                comando.Parameters.Add(New SqlParameter("@fecha", SqlDbType.Date)).Value = objEmpleado.fecha
                comando.Parameters.Add(New SqlParameter("@codigoep", SqlDbType.Int)).Value = objEmpleado.codigoEp
                comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
