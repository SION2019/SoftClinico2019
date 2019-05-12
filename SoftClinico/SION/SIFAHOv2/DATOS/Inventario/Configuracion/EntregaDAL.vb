Imports System.Data.SqlClient
Public Class EntregaDAL
    Public Sub GuardarAactualizar_PLAZA(ByVal codigo As Object, ByVal dia As String)

        Try

            If codigo.text <> "" Then
                Using consulta As New SqlCommand("PROC_ENTREGA_ACTUALIZAR")
                    consulta.CommandType = CommandType.StoredProcedure
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Parameters.Add(New SqlParameter("@codigo", SqlDbType.Int))
                    consulta.Parameters("@codigo").Value = CDbl(codigo.text)
                    consulta.Parameters.Add(New SqlParameter("@dia", SqlDbType.Int))
                    consulta.Parameters("@dia").Value = dia
                    consulta.ExecuteNonQuery()

                End Using
            Else
                Using consulta As New SqlCommand("PROC_ENTREGA_CREAR")
                    consulta.CommandType = CommandType.StoredProcedure
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Parameters.Add(New SqlParameter("@dia", SqlDbType.Int))
                    consulta.Parameters("@dia").Value = dia
                    codigo.text = CType(consulta.ExecuteScalar, String)

                End Using
            End If

        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
    End Sub

End Class
