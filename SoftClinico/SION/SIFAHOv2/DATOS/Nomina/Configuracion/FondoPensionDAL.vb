Imports System.Data.SqlClient
Imports System.IO
Public Class FondoPensionDAL
    Public Sub guardar_pension(ByRef codigo_in As TextBox, ByVal descripcion As String)
        Try
            If codigo_in.Text = "" Then
                Using Consulta As New SqlCommand("PROC_PENSION_CREAR")
                    Consulta.CommandType = CommandType.StoredProcedure
                    Consulta.Connection = FormPrincipal.cnxion
                    Consulta.Parameters.Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar))
                    Consulta.Parameters("@DESCRIPCION").Value = descripcion
                    Consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.NVarChar))
                    Consulta.Parameters("@USUARIO").Value = SesionActual.idUsuario
                    codigo_in.Text = CType(Consulta.ExecuteScalar, String)
                End Using
            Else
                Using Consulta As New SqlCommand("PROC_PENSION_ACTUALIZAR")
                    Consulta.CommandType = CommandType.StoredProcedure
                    Consulta.Connection = FormPrincipal.cnxion
                    Consulta.Parameters.Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar))
                    Consulta.Parameters("@DESCRIPCION").Value = descripcion
                    Consulta.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.NVarChar))
                    Consulta.Parameters("@CODIGO").Value = codigo_in.Text
                    Consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.NVarChar))
                    Consulta.Parameters("@USUARIO").Value = SesionActual.idUsuario
                    Consulta.ExecuteNonQuery()
                End Using
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function anular_pension(ByVal codigo As String) As Boolean
        Try
            Using Consulta As New SqlCommand("PROC_PENSION_ANULAR")
                Consulta.CommandType = CommandType.StoredProcedure
                Consulta.Connection = FormPrincipal.cnxion
                Consulta.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.Int))
                Consulta.Parameters("@CODIGO").Value = CInt(codigo)
                Consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.NVarChar))
                Consulta.Parameters("@USUARIO").Value = SesionActual.idUsuario
                Consulta.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            general.manejoErrores(ex) 
            Return False
        End Try
    End Function


End Class
