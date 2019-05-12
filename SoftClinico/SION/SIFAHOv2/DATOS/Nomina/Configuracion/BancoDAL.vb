Imports System.Data.SqlClient
Imports System.IO
Public Class BancoDAL
    Public Function crearBanco(objBanco As Banco) As String
        Try

            Using dbCommand As New SqlCommand("PROC_BANCO_CREAR")
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.Parameters.Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar))
                dbCommand.Parameters("@DESCRIPCION").Value = objBanco.descripcionBanco
                dbCommand.Parameters.Add(New SqlParameter("@Usuario_creacion", SqlDbType.NVarChar))
                dbCommand.Parameters("@Usuario_creacion").Value = objBanco.usuario
                objBanco.codigoBanco = CType(dbCommand.ExecuteScalar, String)
            End Using

        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try

        Return objBanco.codigoBanco
    End Function
    Public Sub actualizarBanco(objBanco As Banco)
        Try
            Using dbCommand As New SqlCommand("PROC_BANCO_ACTUALIZAR")
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.Parameters.Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar))
                dbCommand.Parameters("@DESCRIPCION").Value = objBanco.descripcionBanco
                dbCommand.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.NVarChar))
                dbCommand.Parameters("@CODIGO").Value = objBanco.codigoBanco
                dbCommand.Parameters.Add(New SqlParameter("@Usuario_Actualizacion", SqlDbType.NVarChar))
                dbCommand.Parameters("@Usuario_Actualizacion").Value = objBanco.usuario
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
    End Sub
    Public Function anularBanco(objBanco As Banco) As Boolean
        Try
            Using dbCommand As New SqlCommand("PROC_BANCO_ANULAR")
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.Int))
                dbCommand.Parameters("@CODIGO").Value = CInt(objBanco.codigoBanco)
                dbCommand.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.Int))
                dbCommand.Parameters("@USUARIO").Value = objBanco.usuario
                dbCommand.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            general.manejoErrores(ex) 
            Return False
        End Try
    End Function

End Class


