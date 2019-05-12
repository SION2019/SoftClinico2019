Imports System.Data.SqlClient
Public Class Regimen_C
    Public Function GuardarAactualizar(ByVal codigo As String, ByVal descripcion As String) As String
        Dim codigoe As String = ""
        Try

            If codigo <> "" Then
                Using consulta As New SqlCommand("PROC_TIPO_REGIMEN_ACTUALIZAR")
                    consulta.CommandType = CommandType.StoredProcedure
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Parameters.Add(New SqlParameter("@codigo", SqlDbType.Int))
                    consulta.Parameters("@codigo").Value = CDbl(codigo)
                    consulta.Parameters.Add(New SqlParameter("@descripcion", SqlDbType.Int))
                    consulta.Parameters("@descripcion").Value = descripcion
                    consulta.ExecuteNonQuery()
                    codigoe = codigo
                End Using
            Else
                Using consulta As New SqlCommand("PROC_TIPO_REGIMEN_CREAR")
                    consulta.CommandType = CommandType.StoredProcedure
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Parameters.Add(New SqlParameter("@descripcion", SqlDbType.Int))
                    consulta.Parameters("@descripcion").Value = descripcion
                    codigoe = CType(consulta.ExecuteScalar, String)

                End Using
            End If

        Catch ex As Exception
            general.manejoErrores(ex) 
            codigoe = ""

        End Try
        Return codigoe
    End Function
    Public Function devoAnular(ByVal codigo As String) As Boolean
        Try
            Using consulta As New SqlCommand("PROC_TIPO_REGIMEN_ANULAR")
                consulta.CommandType = CommandType.StoredProcedure
                consulta.Connection = FormPrincipal.cnxion
                consulta.Parameters.Add(New SqlParameter("@codigo", SqlDbType.Int))
                consulta.Parameters("@codigo").Value = codigo
                consulta.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            general.manejoErrores(ex) 
            Return False
        End Try
    End Function


End Class
