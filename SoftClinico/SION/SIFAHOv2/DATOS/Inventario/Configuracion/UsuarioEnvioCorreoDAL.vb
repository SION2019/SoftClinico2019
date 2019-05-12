Imports System.Data.SqlClient

Public Class UsuarioEnvioCorreoDAL

    Function verificarExistenciaUsuarioEnvioCorreo() As Boolean
        Dim resp As Boolean = False

        Using consultor2 As New SqlCommand("[PROC_VERIFICAR_EXISTENCIA_USUARIO] @IdEmpresa='" & SesionActual.idEmpresa & "'", FormPrincipal.cnxion)
            resp = consultor2.ExecuteScalar
        End Using
        Return resp
    End Function
    Public Sub guardarConfiguracion(ByRef objConfiguracionEnvioCorreos As UsuarioEnvioCorreo,
                                    ByVal usuario As Integer)

        Try

            Using sentencia = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    sentencia.Connection = FormPrincipal.cnxion
                    sentencia.Transaction = trnsccion
                    sentencia.CommandType = CommandType.StoredProcedure

                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "PROC_USUARIO_ENVIA_CORREO_CREAR"
                    sentencia.Parameters.Add(New SqlParameter("@idCodigoConfiguracion", SqlDbType.NVarChar)).Value = objConfiguracionEnvioCorreos.CodigoConfiguracion
                    sentencia.Parameters.Add(New SqlParameter("@Codigo_EP", SqlDbType.Int)).Value = SesionActual.codigoEP
                    sentencia.Parameters.Add(New SqlParameter("@UsuarioCorreo", SqlDbType.NVarChar)).Value = objConfiguracionEnvioCorreos.email
                    sentencia.Parameters.Add(New SqlParameter("@pass", SqlDbType.NVarChar)).Value = objConfiguracionEnvioCorreos.contreseña
                    sentencia.Parameters.Add(New SqlParameter("@usuario", SqlDbType.Int)).Value = usuario
                    sentencia.Parameters.Add(New SqlParameter("@Tabla", SqlDbType.Structured)).Value = objConfiguracionEnvioCorreos.tblFormularios
                    sentencia.Parameters.Add(New SqlParameter("@pTerceroAsigando", SqlDbType.Int)).Value = objConfiguracionEnvioCorreos.idTerceroAsignado
                    sentencia.Parameters.Add(New SqlParameter("@pAsunto", SqlDbType.NVarChar)).Value = objConfiguracionEnvioCorreos.asunto
                    objConfiguracionEnvioCorreos.CodigoConfiguracion = CType(sentencia.ExecuteScalar, String)



                    Try
                        trnsccion.Commit()
                    Catch ex As Exception
                        trnsccion.Rollback()
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub anularConfiguracion(ByRef objConfiguracionEnvioCorreos As UsuarioEnvioCorreo,
                            ByVal usuario As Integer)
        Try
            Using consulta = New SqlCommand()
                consulta.Connection = FormPrincipal.cnxion
                consulta.CommandType = CommandType.StoredProcedure
                consulta.Parameters.Clear()

                consulta.CommandText = "[PROC_USUARIO_ENVIA_CORREO_ANULAR]"
                consulta.Parameters.Add(New SqlParameter("@idCodigoConfiguracion", SqlDbType.Int)).Value = objConfiguracionEnvioCorreos.CodigoConfiguracion
                consulta.Parameters.Add(New SqlParameter("@usuario", SqlDbType.NVarChar)).Value = usuario
                consulta.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
