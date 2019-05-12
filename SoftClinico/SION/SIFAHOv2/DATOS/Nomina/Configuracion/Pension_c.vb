Imports System.Data.SqlClient
Imports System.IO
Public Class Pension_c
    Public Function guardar_pension(ByVal codigo_in As String, ByVal descripcion As String) As String
        Dim codigo As String = ""
        Try
            If codigo_in = "" Then
                Using Consulta As New SqlCommand("SP_PENSION_CREAR")
                    Consulta.CommandType = CommandType.StoredProcedure
                    Consulta.Connection = form_principal.cnxion
                    Consulta.Parameters.Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar))
                    Consulta.Parameters("@DESCRIPCION").Value = descripcion
                    Consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.NVarChar))
                    Consulta.Parameters("@USUARIO").Value = form_principal.usuarioActual
                    codigo = CType(Consulta.ExecuteScalar, String)
                End Using
            Else
                Using Consulta As New SqlCommand("SP_PENSION_ACTUALIZAR")
                    Consulta.CommandType = CommandType.StoredProcedure
                    Consulta.Connection = form_principal.cnxion
                    Consulta.Parameters.Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar))
                    Consulta.Parameters("@DESCRIPCION").Value = descripcion
                    Consulta.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.NVarChar))
                    Consulta.Parameters("@CODIGO").Value = codigo_in
                    Consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.NVarChar))
                    Consulta.Parameters("@USUARIO").Value = form_principal.usuarioActual
                    Consulta.ExecuteNonQuery()
                    codigo = codigo_in
                End Using
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return codigo
    End Function
    Public Function anular_pension(ByVal codigo As String) As Boolean
        Try
            Using Consulta As New SqlCommand("SP_PENSION_ANULAR")
                Consulta.CommandType = CommandType.StoredProcedure
                Consulta.Connection = form_principal.cnxion
                Consulta.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.Int))
                Consulta.Parameters("@CODIGO").Value = CInt(codigo)
                Consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.NVarChar))
                Consulta.Parameters("@USUARIO").Value = form_principal.usuarioActual
                Consulta.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function


End Class
