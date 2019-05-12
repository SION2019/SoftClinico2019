Public Class CasoProblemaDAL
    Public Shared Function guardarCasoProblema(objCasoProblema As CasoProblema) As CasoProblema
        Try
            Using comando As New SqlCommand
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = FormPrincipal.cnxion
                comando.CommandText = "[PROC_CASO_PROBLEMA_CREAR]"
                comando.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.NVarChar))
                comando.Parameters("@Codigo").Value = objCasoProblema.codigo
                comando.Parameters.Add(New SqlParameter("@Registro", SqlDbType.Int))
                comando.Parameters("@Registro").Value = objCasoProblema.nRegistro
                comando.Parameters.Add(New SqlParameter("@Observacion", SqlDbType.NVarChar))
                comando.Parameters("@Observacion").Value = objCasoProblema.Observacion
                comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int))
                comando.Parameters("@Usuario").Value = SesionActual.idUsuario
                comando.Parameters.Add(New SqlParameter("@UsuarioReal", SqlDbType.Int))
                comando.Parameters("@UsuarioReal").Value = objCasoProblema.codigoEmpleado
                objCasoProblema.codigo = (comando.ExecuteScalar)
            End Using
        Catch ex As Exception
            Throw
        End Try
        Return objCasoProblema
    End Function
End Class
