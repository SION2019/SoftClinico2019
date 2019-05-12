Public Class FacturaAmbulanciaDAL
    Public Shared Sub guardarFactura(ByRef objFactura As FacturaAtencionAmbulancia)
        Try
            Using comando = New SqlCommand()
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "[PROC_HC_FACTURA_AMBULANCIA_GUARDAR]"
                comando.Parameters.Add(New SqlParameter("@codigo_factura", SqlDbType.NVarChar)).Value = objFactura.codigoFactura
                comando.Parameters.Add(New SqlParameter("@traslado", SqlDbType.Int)).Value = objFactura.registroAFacturar
                comando.Parameters.Add(New SqlParameter("@id_empresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                comando.Parameters.Add(New SqlParameter("@fecha_factura", SqlDbType.DateTime)).Value = objFactura.fechaFactura
                comando.Parameters.Add(New SqlParameter("@fecha_vence", SqlDbType.DateTime)).Value = objFactura.fechaVencimiento
                comando.Parameters.Add(New SqlParameter("@total_factura", SqlDbType.Float)).Value = objFactura.totalFactura
                comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objFactura.usuario
                comando.Parameters.Add(New SqlParameter("@PrecioTraslado", SqlDbType.Float)).Value = objFactura.precioTraslado
                comando.Parameters.Add(New SqlParameter("@CantidadKMS", SqlDbType.Float)).Value = objFactura.cantidadKMS
                comando.Parameters.Add(New SqlParameter("@PrecioKMS", SqlDbType.Float)).Value = objFactura.precioKMS
                comando.Parameters.Add(New SqlParameter("@CantidadHH", SqlDbType.Float)).Value = objFactura.cantidadHH
                comando.Parameters.Add(New SqlParameter("@PrecioHH", SqlDbType.Float)).Value = objFactura.precioHH
                comando.Parameters.Add(New SqlParameter("@PrecioRN", SqlDbType.Float)).Value = objFactura.precioRN
                comando.Parameters.Add(New SqlParameter("@observacion", SqlDbType.NVarChar)).Value = objFactura.observacion
                objFactura.codigoFactura = CType(comando.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
