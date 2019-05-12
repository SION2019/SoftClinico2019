Imports System.Data.SqlClient
Public Class DepartamentoDAL
    Public Function guardar_depar(ByVal codigo_in As String, ByVal descripcion As String, ByVal pais As String) As String
        Dim codigo As String = ""
        Try

            Using Consulta As New SqlCommand("PROC_DEPARTAMENTOS_GUARDAR")
                Consulta.CommandType = CommandType.StoredProcedure
                Consulta.Connection = FormPrincipal.cnxion
                Consulta.Parameters.Add(New SqlParameter("@descripcion", SqlDbType.NVarChar))
                Consulta.Parameters("@descripcion").Value = descripcion
                Consulta.Parameters.Add(New SqlParameter("@pais", SqlDbType.NVarChar))
                Consulta.Parameters("@pais").Value = pais
                Consulta.Parameters.Add(New SqlParameter("@codigo", SqlDbType.NVarChar))
                Consulta.Parameters("@codigo").Value = codigo_in
                Consulta.ExecuteNonQuery()
                codigo = codigo_in
            End Using
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try

        Return codigo
    End Function
    Public Function anular_depar(ByVal codigo As String, ByVal pais As String) As Boolean
        Try
            Using Consulta As New SqlCommand("PROC_DEPARTAMENTOS_ANULAR")
                Consulta.CommandType = CommandType.StoredProcedure
                Consulta.Connection = FormPrincipal.cnxion
                Consulta.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.NVarChar))
                Consulta.Parameters("@CODIGO").Value = codigo
                Consulta.Parameters.Add(New SqlParameter("@pais", SqlDbType.NVarChar))
                Consulta.Parameters("@pais").Value = pais
                Consulta.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            general.manejoErrores(ex) 
            Return False
        End Try
    End Function
End Class
