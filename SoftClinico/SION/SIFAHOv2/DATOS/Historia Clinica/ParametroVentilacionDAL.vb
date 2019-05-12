
Public Class ParametroVentilacionDAL
    Public Shared Sub guardarParametroVentilacionHC(objParametro As ParametroVentilacion)
        Using comando = New SqlCommand()
            comando.Connection = FormPrincipal.cnxion
            comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.Clear()
                comando.CommandText = "[PROC_PARAMETRO_VENTILACION_CREAR]"
                comando.Parameters.Add(New SqlParameter("@Fecha_Real", SqlDbType.DateTime)).Value = objParametro.fechaReal
                comando.Parameters.Add(New SqlParameter("@Regitro", SqlDbType.Int)).Value = objParametro.nRegistro
                comando.Parameters.Add(New SqlParameter("@Usuario_Real", SqlDbType.Int)).Value = objParametro.usuarioReal
                comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objParametro.usuario
                comando.Parameters.Add(New SqlParameter("@CODIGO_EP", SqlDbType.Int)).Value = objParametro.codigoEP
                comando.Parameters.Add(New SqlParameter("@TablaSign", SqlDbType.Structured)).Value = objParametro.dtHorasabana
                objParametro.codigoSabana = CType(comando.ExecuteScalar, String)
            End Using
    End Sub
    Public Shared Sub guardarParametroVentilacionAM(objParametro As ParametroVentilacionR)
        Using comando = New SqlCommand()
            comando.Connection = FormPrincipal.cnxion
            comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.Clear()
                comando.CommandText = "[PROC_PARAMETRO_VENTILACION_CREAR_R]"
                comando.Parameters.Add(New SqlParameter("@IDPARAMS", SqlDbType.Int)).Value = objParametro.codigoSabana
                comando.Parameters.Add(New SqlParameter("@Fecha_Real", SqlDbType.DateTime)).Value = objParametro.fechaReal
                comando.Parameters.Add(New SqlParameter("@Regitro", SqlDbType.Int)).Value = objParametro.nRegistro
                comando.Parameters.Add(New SqlParameter("@Usuario_Real", SqlDbType.Int)).Value = objParametro.usuarioReal
                comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objParametro.usuario
                comando.Parameters.Add(New SqlParameter("@CODIGO_EP", SqlDbType.Int)).Value = objParametro.codigoEP
                comando.Parameters.Add(New SqlParameter("@TablaSign", SqlDbType.Structured)).Value = objParametro.dtHorasabana
                objParametro.codigoSabana = CType(comando.ExecuteScalar, String)
            End Using
    End Sub
    Public Shared Sub guardarParametroVentilacionAF(objParametro As ParametroVentilacionRR)
        Using comando = New SqlCommand()
            comando.Connection = FormPrincipal.cnxion
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Clear()
            comando.CommandText = "[PROC_PARAMETRO_VENTILACION_CREAR_RR]"
            comando.Parameters.Add(New SqlParameter("@IDPARAMS", SqlDbType.Int)).Value = objParametro.codigoSabana
            comando.Parameters.Add(New SqlParameter("@Fecha_Real", SqlDbType.DateTime)).Value = objParametro.fechaReal
            comando.Parameters.Add(New SqlParameter("@Regitro", SqlDbType.Int)).Value = objParametro.nRegistro
            comando.Parameters.Add(New SqlParameter("@Usuario_Real", SqlDbType.Int)).Value = objParametro.usuarioReal
            comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objParametro.usuario
            comando.Parameters.Add(New SqlParameter("@TablaSign", SqlDbType.Structured)).Value = objParametro.dtHorasabana
            objParametro.codigoSabana = CType(comando.ExecuteScalar, String)
        End Using
    End Sub
    Public Shared Sub actualizarParametroVentilacionHC(objParametro As ParametroVentilacion)
        Using comando = New SqlCommand()
            comando.Connection = FormPrincipal.cnxion
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Clear()
            comando.CommandText = "[PROC_PARAMETRO_VENTILACION_ACTUALIZAR]"
            comando.Parameters.Add(New SqlParameter("@IDPARAMS", SqlDbType.Int)).Value = objParametro.codigoSabana
            comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objParametro.usuario
            comando.Parameters.Add(New SqlParameter("@CODIGO_EP", SqlDbType.Int)).Value = objParametro.codigoEP
            comando.Parameters.Add(New SqlParameter("@TablaSign", SqlDbType.Structured)).Value = objParametro.dtHorasabana
            comando.ExecuteNonQuery()
        End Using

    End Sub
    Public Shared Sub actualizarParametroVentilacionAM(objParametro As ParametroVentilacionR)
        Using comando = New SqlCommand()
            comando.Connection = FormPrincipal.cnxion
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Clear()
            comando.CommandText = "[PROC_PARAMETRO_VENTILACION_ACTUALIZAR_R]"
            comando.Parameters.Add(New SqlParameter("@IDPARAMS", SqlDbType.Int)).Value = objParametro.codigoSabana
            comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objParametro.usuario
            comando.Parameters.Add(New SqlParameter("@editado", SqlDbType.Int)).Value = objParametro.editado
            comando.Parameters.Add(New SqlParameter("@CODIGO_EP", SqlDbType.Int)).Value = objParametro.codigoEP
            comando.Parameters.Add(New SqlParameter("@TablaSign", SqlDbType.Structured)).Value = objParametro.dtHorasabana
            comando.ExecuteNonQuery()
        End Using
    End Sub
    Public Shared Sub actualizarParametroVentilacionAF(objParametro As ParametroVentilacionRR)
        Using comando = New SqlCommand()
            comando.Connection = FormPrincipal.cnxion
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Clear()
            comando.CommandText = "[PROC_PARAMETRO_VENTILACION_ACTUALIZAR_RR]"
            comando.Parameters.Add(New SqlParameter("@IDPARAMS", SqlDbType.Int)).Value = objParametro.codigoSabana
            comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objParametro.usuario
            comando.Parameters.Add(New SqlParameter("@editado", SqlDbType.Int)).Value = objParametro.editado
            comando.Parameters.Add(New SqlParameter("@TablaSign", SqlDbType.Structured)).Value = objParametro.dtHorasabana
            comando.ExecuteNonQuery()
        End Using
    End Sub
End Class
