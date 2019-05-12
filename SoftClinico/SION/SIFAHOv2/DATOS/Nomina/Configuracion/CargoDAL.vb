Imports System.Data.SqlClient
Imports System.IO
Public Class CargoDAL
    Public Function crearCargo(ByRef objCargo As Cargo)
        Try
            Using dbCommand = New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.Parameters.Clear()
                dbCommand.CommandText = "[PROC_CARGO_CREAR]"
                dbCommand.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.NVarChar)).Value = objCargo.descripcion
                dbCommand.Parameters.Add(New SqlParameter("@Usuario_creacion", SqlDbType.Int)).Value = objCargo.usuario
                objCargo.codigo = CType(dbCommand.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objCargo.codigo
    End Function
    Sub actualizarCargo(ByRef objCargo As Cargo)
        Try
            Using dbCommand = New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.Parameters.Clear()
                dbCommand.CommandText = "[PROC_CARGO_ACTUALIZAR]"
                dbCommand.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.Int)).Value = objCargo.codigo
                dbCommand.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.NVarChar)).Value = objCargo.descripcion
                dbCommand.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objCargo.usuario
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function anularCargo(ByRef objCargo As Cargo) As Boolean
        Try
            Using dbCommand = New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.Parameters.Clear()
                dbCommand.CommandText = "[PROC_CARGO_ANULAR]"
                dbCommand.Parameters.Add(New SqlParameter("@codigo", SqlDbType.Int)).Value = objCargo.Codigo
                dbCommand.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objCargo.usuario
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return True
    End Function


End Class
