Imports System.Data.SqlClient
Public Class ProductoLineaDAL
    Public Sub guardar(ByRef objlinea As Linea,
                       ByVal usuario As Integer)
        Try
            Using sentencia = New SqlCommand
                sentencia.Connection = FormPrincipal.cnxion
                sentencia.CommandType = CommandType.StoredProcedure
                sentencia.Parameters.Clear()
                sentencia.CommandText = "[PROC_LINEAS_CREAR]"
                sentencia.Parameters.Add(New SqlParameter("@nombre", SqlDbType.NVarChar)).Value = objlinea.nombre
                sentencia.Parameters.Add(New SqlParameter("@activo", SqlDbType.Bit)).Value = objlinea.aplicaViaAdministracion
                sentencia.Parameters.Add(New SqlParameter("@usuario_creacion", SqlDbType.Int)).Value = usuario
                objlinea.codigo = CType(sentencia.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub actualizar(ByRef objlinea As Linea,
                          ByVal usuario As Integer)
        Try
            Using sentencia = New SqlCommand
                sentencia.Connection = FormPrincipal.cnxion
                sentencia.CommandType = CommandType.StoredProcedure
                sentencia.Parameters.Clear()
                sentencia.CommandText = "[PROC_LINEAS_ACTUALIZAR]"
                sentencia.Parameters.Add(New SqlParameter("@nombre", SqlDbType.NVarChar)).Value = objlinea.nombre
                sentencia.Parameters.Add(New SqlParameter("@activo", SqlDbType.Bit)).Value = objlinea.aplicaViaAdministracion
                sentencia.Parameters.Add(New SqlParameter("@usuario_actualizacion", SqlDbType.Int)).Value = usuario
                sentencia.Parameters.Add(New SqlParameter("@codigo_linea", SqlDbType.Int)).Value = objlinea.codigo
                sentencia.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub anular(ByRef linea As Linea,
                      ByVal usuario As String)
        Try
            Using sentencia = New SqlCommand
                sentencia.Connection = FormPrincipal.cnxion
                sentencia.CommandType = CommandType.StoredProcedure
                sentencia.Parameters.Clear()
                sentencia.CommandText = "[PROC_LINEAS_ANULAR]"
                sentencia.Parameters.Add(New SqlParameter("@codigo_linea", SqlDbType.Int)).Value = linea.codigo
                sentencia.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = usuario
                sentencia.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
