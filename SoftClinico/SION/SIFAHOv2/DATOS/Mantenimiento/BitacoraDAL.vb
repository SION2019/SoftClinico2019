Imports System.Data.SqlClient
Public Class BitacoraDAL
    Public Shared Sub guardarBitacora(objBitacora As Bitacora)
        Try
            Using comando = New SqlCommand
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = FormPrincipal.cnxion
                comando.CommandText = "PROC_EQUIPOS_CREAR"
                comando.Parameters.Add(New SqlParameter("@codigoep", SqlDbType.Int)).Value = objBitacora.codigoEp
                comando.Parameters.Add(New SqlParameter("@usuario", SqlDbType.Int)).Value = objBitacora.usuario
                comando.Parameters.Add(New SqlParameter("@fecha", SqlDbType.Date)).Value = objBitacora.fecha
                comando.Parameters.Add(New SqlParameter("@Detalle", SqlDbType.Structured)).Value = objBitacora.dtBitacora
                comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub guardarBitacoraBiomedico(objBitacora As Bitacora)
        Try
            Using comando = New SqlCommand
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = FormPrincipal.cnxion
                comando.CommandText = "PROC_BIOMEDICOS_CREAR"
                comando.Parameters.Add(New SqlParameter("@codigoep", SqlDbType.Int)).Value = objBitacora.codigoEp
                comando.Parameters.Add(New SqlParameter("@usuario", SqlDbType.Int)).Value = objBitacora.usuario
                comando.Parameters.Add(New SqlParameter("@fecha", SqlDbType.Date)).Value = objBitacora.fecha
                comando.Parameters.Add(New SqlParameter("@Detalle", SqlDbType.Structured)).Value = objBitacora.dtBitacora
                comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
