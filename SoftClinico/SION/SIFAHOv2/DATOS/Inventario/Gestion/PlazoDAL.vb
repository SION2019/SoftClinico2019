Imports System.Data.SqlClient
Public Class PlazoDAL
    Public Sub guardar(ByRef objPlazo As Plazo,
                       ByVal usuario As String)
        Try
            Using sentencia = New SqlCommand
                sentencia.Connection = FormPrincipal.cnxion
                sentencia.CommandType = CommandType.StoredProcedure
                sentencia.Parameters.Clear()
                sentencia.CommandText = "[PROC_PLAZO_CREAR]"
                sentencia.Parameters.Add(New SqlParameter("@dia", SqlDbType.Int)).Value = objPlazo.nombre
                objPlazo.codigo = CType(sentencia.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub actualizar(ByRef objPlazo As Plazo,
                          ByVal usuario As String)
        Try
            Using sentencia = New SqlCommand
                sentencia.Connection = FormPrincipal.cnxion
                sentencia.CommandType = CommandType.StoredProcedure
                sentencia.Parameters.Clear()
                sentencia.CommandText = "[PROC_PLAZO_ACTUALIZAR]"
                sentencia.Parameters.Add(New SqlParameter("@codigo", SqlDbType.Int)).Value = objPlazo.codigo
                sentencia.Parameters.Add(New SqlParameter("@dia", SqlDbType.Int)).Value = objPlazo.nombre
                sentencia.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub anular(ByRef objPlazo As Plazo,
                      ByVal usuario As String)
        Try
            Using sentencia = New SqlCommand
                sentencia.Connection = FormPrincipal.cnxion
                sentencia.CommandType = CommandType.StoredProcedure
                sentencia.Parameters.Clear()
                sentencia.CommandText = "[PROC_PLAZO_ANULAR]"
                sentencia.Parameters.Add(New SqlParameter("@codigo", SqlDbType.Int)).Value = objPlazo.codigo
                sentencia.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
