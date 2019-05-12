Imports System.Data.SqlClient
Imports System.IO
Public Class Caja_C
    Public Function guardar_caja(ByVal codigo_in As String,
                                 ByVal descripcion As String, ByVal usuario As String) As String
        Dim codigo As String = ""
        Try
            If codigo_in = "" Then
                Using Consulta As New SqlCommand("SP_CAJA_CREAR")
                    Consulta.CommandType = CommandType.StoredProcedure
                    Consulta.Connection = form_principal.cnxion
                    Consulta.Parameters.Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar))
                    Consulta.Parameters("@DESCRIPCION").Value = descripcion
                    Consulta.Parameters.Add(New SqlParameter("@Usuario_creacion", SqlDbType.NVarChar))
                    Consulta.Parameters("@Usuario_creacion").Value = usuario
                    codigo = CType(Consulta.ExecuteScalar, String)
                End Using
            Else
                Using Consulta As New SqlCommand("SP_CAJA_ACTUALIZAR")
                    Consulta.CommandType = CommandType.StoredProcedure
                    Consulta.Connection = form_principal.cnxion
                    Consulta.Parameters.Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar))
                    Consulta.Parameters("@DESCRIPCION").Value = descripcion
                    Consulta.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.NVarChar))
                    Consulta.Parameters("@CODIGO").Value = codigo_in
                    Consulta.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.NVarChar))
                    Consulta.Parameters("@Usuario").Value = usuario
                    Consulta.ExecuteNonQuery()
                    codigo = codigo_in
                End Using
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return codigo
    End Function

End Class
