Public Class UsuarioEnvioCorreoBLL
    Dim objUsuarioEnvioDAL As New UsuarioEnvioCorreoDAL
    Function verificarExistenciaUsuarioEnvioCorreo() As Boolean
        Return objUsuarioEnvioDAL.verificarExistenciaUsuarioEnvioCorreo
    End Function
    Public Sub guardarConfiguracion(ByRef objConfiguracionEnvioCorreos As UsuarioEnvioCorreo,
                                    ByVal usuario As Integer)
        Try
            objUsuarioEnvioDAL.guardarConfiguracion(objConfiguracionEnvioCorreos, usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub anularConfiguracion(ByRef objConfiguracionEnvioCorreos As UsuarioEnvioCorreo,
                            ByVal usuario As Integer)
        Try
            objUsuarioEnvioDAL.anularConfiguracion(objConfiguracionEnvioCorreos, usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
