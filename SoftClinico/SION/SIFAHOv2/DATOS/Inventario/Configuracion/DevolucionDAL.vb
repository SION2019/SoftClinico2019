Imports System.Data.SqlClient
Public Class DevolucionDAL
    Public Shared Sub GuardarAactualizar(objDevolucion As DiaDevolucion)

        Try

            If Not String.IsNullOrEmpty(objDevolucion.codigo) Then
                Using consulta As New SqlCommand("PROC_DIA_DEVOLUCION_ACTUALIZAR")
                    consulta.CommandType = CommandType.StoredProcedure
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Parameters.Add(New SqlParameter("@codigo", SqlDbType.Int))
                    consulta.Parameters("@codigo").Value = objDevolucion.codigo
                    consulta.Parameters.Add(New SqlParameter("@dias", SqlDbType.Int))
                    consulta.Parameters("@dias").Value = objDevolucion.nombre
                    consulta.ExecuteNonQuery()

                End Using
            Else
                Using consulta As New SqlCommand("PROC_DIA_DEVOLUCION_CREAR")
                    consulta.CommandType = CommandType.StoredProcedure
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Parameters.Add(New SqlParameter("@dias", SqlDbType.Int))
                    consulta.Parameters("@dias").Value = objDevolucion.nombre
                    objDevolucion.codigo = CType(consulta.ExecuteScalar, String)

                End Using
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
