Imports System.Data.SqlClient
Public Class ClasificacionExamenDAL

    Public Shared Sub guardarExamen(objExamen As ClasificacionExamen)
        Try
            Using comando As New SqlCommand
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "PROC_CLASIFICACION_EXAMEN_CREAR"
                comando.Parameters.Add(New SqlParameter("@codigo", SqlDbType.Int)).Value = objExamen.codigoExamen
                comando.Parameters.Add(New SqlParameter("@idproveedor", SqlDbType.Int)).Value = objExamen.codigoProveedor
                comando.Parameters.Add(New SqlParameter("@idempresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
