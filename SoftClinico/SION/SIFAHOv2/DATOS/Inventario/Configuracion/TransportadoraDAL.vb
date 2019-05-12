Imports System.Data.SqlClient
Public Class TransportadoraDAL

    Public Sub guardartrans(ByVal codigo As Object, ByVal nombre As String, ByVal usuario As String)

        Try
            If codigo.text = "" Then
                Using consulta As New SqlCommand("PROC_TRANSPORTADORA_CREAR")
                    consulta.CommandType = CommandType.StoredProcedure
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Parameters.Add(New SqlParameter("@descripcion", SqlDbType.NVarChar))
                    consulta.Parameters("@descripcion").Value = nombre
                    consulta.Parameters.Add(New SqlParameter("@usuario", SqlDbType.NVarChar))
                    consulta.Parameters("@usuario").Value = usuario
                    codigo.text = CType(consulta.ExecuteScalar, String)
                End Using
            Else
                Using consulta As New SqlCommand("PROC_TRANSPORTADORA_ACTUALIZAR")
                    consulta.CommandType = CommandType.StoredProcedure
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Parameters.Add(New SqlParameter("@codigo", SqlDbType.NVarChar))
                    consulta.Parameters("@codigo").Value = codigo.text
                    consulta.Parameters.Add(New SqlParameter("@descripcion", SqlDbType.NVarChar))
                    consulta.Parameters("@descripcion").Value = nombre
                    consulta.Parameters.Add(New SqlParameter("@usuario", SqlDbType.NVarChar))
                    consulta.Parameters("@usuario").Value = usuario
                    consulta.ExecuteNonQuery()

                End Using
            End If

        Catch ex As Exception
            general.manejoErrores(ex) 

        End Try
    End Sub

    Public Function transaAnular(ByVal codigo As String, ByVal usuario As String) As Boolean
        Try
            Using consulta As New SqlCommand("PROC_TRANSPORTADORA_ANULAR")
                consulta.CommandType = CommandType.StoredProcedure
                consulta.Connection = FormPrincipal.cnxion
                consulta.Parameters.Add(New SqlParameter("@codigo", SqlDbType.NVarChar))
                consulta.Parameters("@codigo").Value = codigo
                consulta.Parameters.Add(New SqlParameter("@usuario", SqlDbType.NVarChar))
                consulta.Parameters("@usuario").Value = usuario
                consulta.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            general.manejoErrores(ex) 
            Return False
        End Try
    End Function

End Class
