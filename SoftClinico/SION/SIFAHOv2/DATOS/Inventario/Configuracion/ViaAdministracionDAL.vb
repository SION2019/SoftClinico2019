Imports System.Data.SqlClient
Public Class ViaAdministracionDAL
    Public Function crearViaAdministracion(ByVal objViaAdministracion As ViaAdministracion) As String
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_VIASADMINISTRATIVA_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.NVarChar)).Value = objViaAdministracion.nombre
                dbCommand.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objViaAdministracion.usuario
                dbCommand.Parameters.Add(New SqlParameter("@Tipo", SqlDbType.NVarChar)).Value = objViaAdministracion.codigoTipo
                ViasAdministracion.txtcodigo.Text = CType(dbCommand.ExecuteScalar, Integer)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objViaAdministracion.codigo
    End Function

    Public Sub actualizarViaAdministracion(ByVal objViaAdministracion As ViaAdministracion)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_VIASADMINISTRATIVA_ACTUALIZAR"
                dbCommand.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.NVarChar)).Value = objViaAdministracion.codigo
                dbCommand.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.NVarChar)).Value = objViaAdministracion.nombre
                dbCommand.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objViaAdministracion.usuario
                dbCommand.Parameters.Add(New SqlParameter("@Tipo", SqlDbType.NVarChar)).Value = objViaAdministracion.codigoTipo
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
