Imports System.Data.SqlClient
Public Class PerfilParaclinicoDAL
    Public Shared Function guardarPerfilParaclinico(objPerfilP As PerfilParaclinico)
        Try
            Using comando = New SqlCommand()
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = objPerfilP.sqlGuardarPerfilParaclinico
                comando.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.NVarChar)).Value = objPerfilP.codigo
                comando.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.NVarChar)).Value = objPerfilP.Descripcion
                comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objPerfilP.Usuario
                objPerfilP.codigo = CType(comando.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objPerfilP
    End Function

    Public Shared Function GuardarconfiguracionprocedimientosDAL(objConfPP As ConfiguracionPerfilParaclinico)
        Try
            Using comando As New SqlCommand()
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = FormPrincipal.cnxion
                comando.CommandText = objConfPP.sqlCrearProcedimientoParaclinico
                comando.Parameters.Add(New SqlParameter("@CODIGO_GRUP", SqlDbType.Int)).Value = objConfPP.CodigoTipo
                comando.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.NVarChar)).Value = objConfPP.usuario
                comando.Parameters.Add(New SqlParameter("@CODIGO_AREA_SERVICIO", SqlDbType.Int)).Value = objConfPP.codigoAreaServicio
                comando.Parameters.Add(New SqlParameter("@TABLA", SqlDbType.Structured)).Value = objConfPP.dtProcedimiento
                comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw
        End Try
        Return objConfPP
    End Function
End Class
