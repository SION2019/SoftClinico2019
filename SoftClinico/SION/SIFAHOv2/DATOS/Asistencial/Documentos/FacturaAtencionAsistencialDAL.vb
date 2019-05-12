Public Class FacturaAtencionAsistencialDAL
    Public Shared Sub guardarFactura(ByRef objFactura As FacturaAtencionAsistencial)
        Try
            Using comando = New SqlCommand()
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "[PROC_HC_FACTURA_ATENCION_GUARDAR]"
                comando.Parameters.Add(New SqlParameter("@codigo_factura", SqlDbType.NVarChar)).Value = objFactura.codigoFactura
                comando.Parameters.Add(New SqlParameter("@ctc", SqlDbType.Bit)).Value = objFactura.CTC
                comando.Parameters.Add(New SqlParameter("@registro", SqlDbType.Int)).Value = objFactura.registroAFacturar
                comando.Parameters.Add(New SqlParameter("@contrato", SqlDbType.Int)).Value = objFactura.CodigoContrato
                comando.Parameters.Add(New SqlParameter("@id_empresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                comando.Parameters.Add(New SqlParameter("@fecha_factura", SqlDbType.DateTime)).Value = objFactura.fechaFactura
                comando.Parameters.Add(New SqlParameter("@fecha_vence", SqlDbType.DateTime)).Value = objFactura.fechaVencimiento
                comando.Parameters.Add(New SqlParameter("@total_factura", SqlDbType.Float)).Value = objFactura.totalFactura
                comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objFactura.usuario
                comando.Parameters.Add(New SqlParameter("@TablaEST", SqlDbType.Structured)).Value = objFactura.dtEstancias
                comando.Parameters.Add(New SqlParameter("@TablaTRA", SqlDbType.Structured)).Value = objFactura.dtTraslados
                comando.Parameters.Add(New SqlParameter("@TablaOXI", SqlDbType.Structured)).Value = objFactura.dtOxigenos
                comando.Parameters.Add(New SqlParameter("@TablaPAR", SqlDbType.Structured)).Value = objFactura.dtParaclinicos
                comando.Parameters.Add(New SqlParameter("@TablaHEM", SqlDbType.Structured)).Value = objFactura.dtHemoderivados
                comando.Parameters.Add(New SqlParameter("@TablaPRO", SqlDbType.Structured)).Value = objFactura.dtProcedimientos
                comando.Parameters.Add(New SqlParameter("@TablaMED", SqlDbType.Structured)).Value = objFactura.dtMedicamentos
                comando.Parameters.Add(New SqlParameter("@TablaINS", SqlDbType.Structured)).Value = objFactura.dtInsumos
                objFactura.codigoFactura = CType(comando.ExecuteScalar, String)

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Shared Sub guardarFacturaCapita(ByRef objFactura As FacturaAtencionCapitada)
        Try
            Using comando = New SqlCommand()
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "[PROC_HC_FACTURA_CAPITA_GUARDAR]"
                comando.Parameters.Add(New SqlParameter("@codigo_factura", SqlDbType.NVarChar)).Value = objFactura.codigoFactura
                comando.Parameters.Add(New SqlParameter("@OBSERVACION", SqlDbType.NVarChar)).Value = objFactura.observacion
                comando.Parameters.Add(New SqlParameter("@periodo", SqlDbType.Date)).Value = objFactura.fechaInicio
                comando.Parameters.Add(New SqlParameter("@contrato", SqlDbType.Int)).Value = objFactura.CodigoContrato
                comando.Parameters.Add(New SqlParameter("@id_empresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                comando.Parameters.Add(New SqlParameter("@fecha_factura", SqlDbType.DateTime)).Value = objFactura.fechaFactura
                comando.Parameters.Add(New SqlParameter("@fecha_vence", SqlDbType.DateTime)).Value = objFactura.fechaVencimiento
                comando.Parameters.Add(New SqlParameter("@total_factura", SqlDbType.Float)).Value = objFactura.totalFactura
                comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objFactura.usuario
                objFactura.codigoFactura = CType(comando.ExecuteScalar, String)

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
