Imports System.Data.SqlClient
Public Class BuzonDAL
    Public Shared Sub guardarBuzon(objBuzon As Buzon)
        Try
            Using comando = New SqlCommand
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = FormPrincipal.cnxion
                comando.CommandText = "PROC_BUZON_CREAR"
                comando.Parameters.Add(New SqlParameter("@codigo", SqlDbType.Int)).Value = objBuzon.codigo
                comando.Parameters.Add(New SqlParameter("@usuario", SqlDbType.Int)).Value = objBuzon.usuario
                comando.Parameters.Add(New SqlParameter("@id_empresa", SqlDbType.Int)).Value = objBuzon.idEmpresa
                comando.Parameters.Add(New SqlParameter("@fecha", SqlDbType.Date)).Value = objBuzon.fecha
                comando.Parameters.Add(New SqlParameter("@observacion", SqlDbType.NVarChar)).Value = objBuzon.observacion
                comando.Parameters.Add(New SqlParameter("@asunto", SqlDbType.NVarChar)).Value = objBuzon.asunto
                comando.Parameters.Add(New SqlParameter("@Cargo", SqlDbType.Structured)).Value = objBuzon.dtCargos
                comando.Parameters.Add(New SqlParameter("@empleado", SqlDbType.Structured)).Value = objBuzon.dtEmpleado
                objBuzon.codigo = CType(comando.ExecuteScalar, Integer)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub guardarBuzonRespuesta(objBuzon As HistorialBuzon)
        Try
            Using comando = New SqlCommand
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = FormPrincipal.cnxion
                comando.CommandText = "PROC_BUZON_RESPUESTA_CREAR"
                comando.Parameters.Add(New SqlParameter("@detalle", SqlDbType.Structured)).Value = objBuzon.dtHistorial
                comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
