Imports System.Data.SqlClient
Imports System.IO
Public Class Profesion_c
    Public Sub guardar_profesion(ByRef txtCodigo As Object, ByVal descripcion As String)
        Try
            If txtCodigo.text = "" Then
                Using Consulta As New SqlCommand("SP_PROFESION_CREAR")
                    Consulta.CommandType = CommandType.StoredProcedure
                    Consulta.Connection = form_principal.cnxion
                    Consulta.Parameters.Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar))
                    Consulta.Parameters("@DESCRIPCION").Value = descripcion
                    Consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.NVarChar))
                    Consulta.Parameters("@USUARIO").Value = form_principal.usuarioActual
                    txtCodigo.text = CType(Consulta.ExecuteScalar, String)
                End Using
            Else
                Using Consulta As New SqlCommand("SP_PROFESION_ACTUALIZAR")
                    Consulta.CommandType = CommandType.StoredProcedure
                    Consulta.Connection = form_principal.cnxion
                    Consulta.Parameters.Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar))
                    Consulta.Parameters("@DESCRIPCION").Value = descripcion
                    Consulta.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.NVarChar))
                    Consulta.Parameters("@CODIGO").Value = txtCodigo.text
                    Consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.NVarChar))
                    Consulta.Parameters("@USUARIO").Value = form_principal.usuarioActual
                    Consulta.ExecuteNonQuery()
                End Using
            End If

        Catch ex As Exception
            Throw ex
        End Try


    End Sub
    Public Sub anular_profesion(ByVal codigo As String)
        Try
            Using Consulta As New SqlCommand("SP_PROFESION_ANULAR")
                Consulta.CommandType = CommandType.StoredProcedure
                Consulta.Connection = form_principal.cnxion
                Consulta.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.Int))
                Consulta.Parameters("@CODIGO").Value = CInt(codigo)
                Consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.NVarChar))
                Consulta.Parameters("@USUARIO").Value = form_principal.usuarioActual
                Consulta.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class

