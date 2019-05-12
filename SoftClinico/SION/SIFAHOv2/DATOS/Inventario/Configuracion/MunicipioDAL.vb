Imports System.Data.SqlClient
Public Class MunicipioDAL
    Public Function guardar_muni(ByVal codigo_in As String, ByVal descripcion As String, ByVal pais As String, ByVal departamento As String) As String
        Dim codigo As String = ""
        Try

            Using Consulta As New SqlCommand("PROC_MUNICIPIOS_GUARDAR")
                Consulta.CommandType = CommandType.StoredProcedure
                Consulta.Connection = FormPrincipal.cnxion
                Consulta.Parameters.Add(New SqlParameter("@descripcion", SqlDbType.NVarChar))
                Consulta.Parameters("@descripcion").Value = descripcion
                Consulta.Parameters.Add(New SqlParameter("@pais", SqlDbType.NVarChar))
                Consulta.Parameters("@pais").Value = pais
                Consulta.Parameters.Add(New SqlParameter("@codigo", SqlDbType.NVarChar))
                Consulta.Parameters("@codigo").Value = codigo_in
                Consulta.Parameters.Add(New SqlParameter("@departamento", SqlDbType.NVarChar))
                Consulta.Parameters("@departamento").Value = departamento
                Consulta.ExecuteNonQuery()
                codigo = codigo_in
            End Using
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try

        Return codigo
    End Function
    Public Function anular_muni(ByVal codigo As String, ByVal pais As String, ByVal departamento As String) As Boolean
        Try
            Using Consulta As New SqlCommand("PROC_MUNICIPIOS_ANULAR")
                Consulta.CommandType = CommandType.StoredProcedure
                Consulta.Connection = FormPrincipal.cnxion
                Consulta.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.NVarChar))
                Consulta.Parameters("@CODIGO").Value = codigo
                Consulta.Parameters.Add(New SqlParameter("@pais", SqlDbType.NVarChar))
                Consulta.Parameters("@pais").Value = pais
                Consulta.Parameters.Add(New SqlParameter("@departamento", SqlDbType.NVarChar))
                Consulta.Parameters("@departamento").Value = departamento
                Consulta.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            general.manejoErrores(ex) 
            Return False
        End Try
    End Function
End Class
