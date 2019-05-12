Imports System.Data.SqlClient
Public Class VencimientoDAL
    Public Shared Sub GuardarAactualizar(objVencimiento As DiaVencimiento)
        Try

            If Not String.IsNullOrEmpty(objVencimiento.codigo) Then
                Using consulta As New SqlCommand("PROC_DIA_VENCIMIENTO_ACTUALIZAR")
                    consulta.CommandType = CommandType.StoredProcedure
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Parameters.Add(New SqlParameter("@codigo", SqlDbType.Int))
                    consulta.Parameters("@codigo").Value = objVencimiento.codigo
                    consulta.Parameters.Add(New SqlParameter("@dias", SqlDbType.Int))
                    consulta.Parameters("@dias").Value = objVencimiento.nombre
                    consulta.ExecuteNonQuery()
                End Using
            Else
                Using consulta As New SqlCommand("PROC_DIA_VENCIMIENTO_CREAR")
                    consulta.CommandType = CommandType.StoredProcedure
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Parameters.Add(New SqlParameter("@dias", SqlDbType.Int))
                    consulta.Parameters("@dias").Value = objVencimiento.nombre
                    objVencimiento.codigo = CType(consulta.ExecuteScalar, String)
                End Using
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
