Imports System.Data.SqlClient
Imports System.IO
Public Class ArpDAL
    Public Function crearARP(ByRef objARL As ARL)
        Try
            Using Consulta As New SqlCommand("PROC_ARL_CREAR")
                Consulta.CommandType = CommandType.StoredProcedure
                Consulta.Connection = FormPrincipal.cnxion
                Consulta.Parameters.Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar))
                Consulta.Parameters("@DESCRIPCION").Value = objARL.descripcionARL
                Consulta.Parameters.Add(New SqlParameter("@Usuario_creacion", SqlDbType.NVarChar))
                Consulta.Parameters("@Usuario_creacion").Value = objARL.usuario
                objARL.codigoARL = CType(Consulta.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objARL.codigoARL
    End Function
    Public Sub actualizarARP(ByRef objARL As ARL)
        Try
            Using Consulta As New SqlCommand("PROC_ARL_ACTUALIZAR")
                Consulta.CommandType = CommandType.StoredProcedure
                Consulta.Connection = FormPrincipal.cnxion
                Consulta.Parameters.Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar))
                Consulta.Parameters("@DESCRIPCION").Value = objARL.descripcionARL
                Consulta.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.Int))
                Consulta.Parameters("@CODIGO").Value = objARL.codigoARL
                Consulta.Parameters.Add(New SqlParameter("@Usuario_Actualizacion", SqlDbType.NVarChar))
                Consulta.Parameters("@Usuario_Actualizacion").Value = objARL.usuario
                Consulta.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub anularARP(ByRef objARL As ARL)
        Try
            Using Consulta As New SqlCommand("PROC_ARL_ANULAR")
                Consulta.CommandType = CommandType.StoredProcedure
                Consulta.Connection = FormPrincipal.cnxion
                Consulta.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.Int))
                Consulta.Parameters("@CODIGO").Value = CInt(objARL.codigoARL)
                Consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.Int))
                Consulta.Parameters("@USUARIO").Value = objARL.usuario
                Consulta.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
