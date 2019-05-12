Imports System.Data.SqlClient
Imports System.IO
Public Class cargos_C
    Public Sub guardarCargo(ByRef objCargos As Cargo,
                             ByVal usuario As Integer)
        Try
            Using sentencia = New SqlCommand
                sentencia.Connection = form_principal.cnxion
                sentencia.CommandType = CommandType.StoredProcedure
                sentencia.Parameters.Clear()
                sentencia.CommandText = "[SP_CARGO_CREAR]"
                sentencia.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.NVarChar)).Value = objCargos.nombre
                sentencia.Parameters.Add(New SqlParameter("@Usuario_creacion", SqlDbType.Int)).Value = usuario
                objCargos.Codigo = CType(sentencia.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub actualizar(ByRef objCargos As Cargo,
                   ByVal usuario As Integer)
        Try
            Using sentencia = New SqlCommand
                sentencia.Connection = form_principal.cnxion
                sentencia.CommandType = CommandType.StoredProcedure
                sentencia.Parameters.Clear()
                sentencia.CommandText = "[SP_CARGO_ACTUALIZAR]"
                sentencia.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.Int)).Value = objCargos.Codigo
                sentencia.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.NVarChar)).Value = objCargos.nombre
                sentencia.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = usuario
                sentencia.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub anular(ByRef objCargos As Cargo,
                      ByVal usuario As Integer)
        Try
            Using sentencia = New SqlCommand
                sentencia.Connection = form_principal.cnxion
                sentencia.CommandType = CommandType.StoredProcedure
                sentencia.Parameters.Clear()
                sentencia.CommandText = "[SP_CARGO_ANULAR]"
                sentencia.Parameters.Add(New SqlParameter("@codigo", SqlDbType.Int)).Value = objCargos.Codigo
                sentencia.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = usuario
                sentencia.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



End Class
