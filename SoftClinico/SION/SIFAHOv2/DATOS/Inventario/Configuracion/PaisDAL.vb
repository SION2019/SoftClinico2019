Imports System.Data.SqlClient
Public Class PaisDAL
    Public Sub guardar(ByRef objPais As Pais)
        Try
            Using sentencia = New SqlCommand
                sentencia.Connection = FormPrincipal.cnxion
                sentencia.CommandType = CommandType.StoredProcedure
                sentencia.Parameters.Clear()
                sentencia.CommandText = "[PROC_PAIS_CREAR]"
                sentencia.Parameters.Add(New SqlParameter("@nombre", SqlDbType.NVarChar)).Value = objPais.nombre
                objPais.codigo = CType(sentencia.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub actualizar(ByRef objPais As Pais)
        Try
            Using sentencia = New SqlCommand
                sentencia.Connection = FormPrincipal.cnxion
                sentencia.CommandType = CommandType.StoredProcedure
                sentencia.Parameters.Clear()
                sentencia.CommandText = "[PROC_PAIS_ACTUALIZAR]"
                sentencia.Parameters.Add(New SqlParameter("@nombre", SqlDbType.NVarChar)).Value = objPais.nombre
                sentencia.Parameters.Add(New SqlParameter("CODIGO", SqlDbType.Int)).Value = objPais.codigo
                sentencia.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub anular(ByRef objPais As Pais)
        Try
            Using sentencia = New SqlCommand
                sentencia.Connection = FormPrincipal.cnxion
                sentencia.CommandType = CommandType.StoredProcedure
                sentencia.Parameters.Clear()
                sentencia.CommandText = "[PROC_PAIS_ANULAR]"
                sentencia.Parameters.Add(New SqlParameter("CODIGO", SqlDbType.Int)).Value = objPais.codigo
                sentencia.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class
