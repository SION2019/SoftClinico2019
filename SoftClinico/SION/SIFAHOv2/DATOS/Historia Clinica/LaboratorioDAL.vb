Public Class LaboratorioDAL
    Public Shared Function guardarSolicitud(objSolicitud As SolicitudLaboratorio)
        Try
            Using comando = New SqlCommand()
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.Clear()
                comando.CommandText = objSolicitud.sqlGenerarLaboratorio
                comando.Parameters.Add(New SqlParameter("@CODIGO_SOLIC", SqlDbType.NVarChar)).Value = objSolicitud.codigoSolicitud
                comando.Parameters.Add(New SqlParameter("@CodigoOrden", SqlDbType.Int)).Value = objSolicitud.codigoOrden
                comando.Parameters.Add(New SqlParameter("@codigo", SqlDbType.Int)).Value = objSolicitud.codigoLab
                comando.Parameters.Add(New SqlParameter("@codigoEp", SqlDbType.Int)).Value = objSolicitud.codigoEp
                comando.Parameters.Add(New SqlParameter("@tipoExamen", SqlDbType.NVarChar)).Value = objSolicitud.tipoExamen
                comando.Parameters.Add(New SqlParameter("@usuario", SqlDbType.Int)).Value = objSolicitud.Usuario
                comando.Parameters.Add(New SqlParameter("@usuarioReal", SqlDbType.Int)).Value = objSolicitud.UsuarioReal
                comando.Parameters.Add(New SqlParameter("@Tabla", SqlDbType.Structured)).Value = objSolicitud.dtExamen
                objSolicitud.codigoSolicitud = CType(comando.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objSolicitud
    End Function
End Class
