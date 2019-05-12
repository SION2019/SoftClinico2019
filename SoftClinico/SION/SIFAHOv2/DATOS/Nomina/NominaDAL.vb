Public Class NominaDAL
    Public Shared Sub guardar(ByRef objFactura As Nomina)
        Try
            Using comando = New SqlCommand()
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "[PROC_NOMINA_GUARDAR]"
                comando.Parameters.Add(New SqlParameter("@mes", SqlDbType.Date)).Value = objFactura.mes
                comando.Parameters.Add(New SqlParameter("@hasta", SqlDbType.Date)).Value = objFactura.hasta
                comando.Parameters.Add(New SqlParameter("@APLICA_HUELLERO", SqlDbType.Bit)).Value = objFactura.aplicaHuellero
                comando.Parameters.Add(New SqlParameter("@id_empresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                comando.Parameters.Add(New SqlParameter("@codigoEP", SqlDbType.Int)).Value = objFactura.codigoEP
                comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = SesionActual.idUsuario
                comando.Parameters.Add(New SqlParameter("@Tabla", SqlDbType.Structured)).Value = objFactura.dtEmpleados
                objFactura.codigo = CType(comando.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Shared Sub guardarCausacion(ByRef objFactura As Nomina)
        Try
            Using comando = New SqlCommand()
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "PROC_NOMINA_CAUSACION_GUARDAR"
                comando.Parameters.Add(New SqlParameter("@CODIGO_NOMINA", SqlDbType.Int)).Value = objFactura.codigo
                comando.Parameters.Add(New SqlParameter("@FECHA_DOC", SqlDbType.Date)).Value = objFactura.fechaDoc
                comando.Parameters.Add(New SqlParameter("@SIGLA_DOCUMENTO", SqlDbType.Int)).Value = Constantes.COMPROBANTE_DE_CAUSACION
                comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = SesionActual.idUsuario
                comando.Parameters.Add(New SqlParameter("@Tabla", SqlDbType.Structured)).Value = objFactura.dtCausacion
                objFactura.comprobante = CType(comando.ExecuteScalar, String)

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
