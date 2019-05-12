Imports Celer

Public Class FacturaRemisionDAL

    Public Shared Sub cargarPendientes(ByRef objFactura As FacturaRemision)
        Try
            ' Create the SelectCommand.
            Dim command As SqlCommand = New SqlCommand()
            command.Connection = FormPrincipal.cnxion
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = objFactura.sqlbuscarRegistroAFacturar
            command.Parameters.Add(New SqlParameter("@ID_CLIENTE", SqlDbType.Int)).Value = objFactura.idCliente
            command.Parameters.Add(New SqlParameter("@CODIGO_EP", SqlDbType.Int)).Value = SesionActual.codigoEP
            command.Parameters.Add(New SqlParameter("@Tabla", SqlDbType.Structured)).Value = objFactura.dtAFacturar

            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)

            adapter.Fill(objFactura.dtPendiente)

        Catch ex As SqlException
            Throw ex
        End Try
    End Sub

    Public Shared Sub cargarInsumoPendientes(objFactura As FacturaRemision)
        Try
            ' Create the SelectCommand.
            Dim command As SqlCommand = New SqlCommand()
            command.Connection = FormPrincipal.cnxion
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = objFactura.sqlPrecargarMedicamentos
            command.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.Int)).Value = Constantes.INSUMO
            command.Parameters.Add(New SqlParameter("@Tabla", SqlDbType.Structured)).Value = objFactura.dtAFacturar

            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)

            adapter.Fill(objFactura.dtInsumos)

        Catch ex As SqlException
            Throw ex
        End Try
    End Sub

    Public Shared Sub cargarMedicamentoPendientes(objFactura As FacturaRemision)
        Try
            ' Create the SelectCommand.
            Dim command As SqlCommand = New SqlCommand()
            command.Connection = FormPrincipal.cnxion
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = objFactura.sqlPrecargarMedicamentos
            command.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.Int)).Value = Constantes.MEDICAMENTO
            command.Parameters.Add(New SqlParameter("@Tabla", SqlDbType.Structured)).Value = objFactura.dtAFacturar
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
            adapter.Fill(objFactura.dtMedicamentos)

        Catch ex As SqlException
            Throw ex
        End Try
    End Sub

    Public Shared Sub guardarFactura(ByRef objFactura As FacturaRemision)
        Try
            Using comando = New SqlCommand()
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "[PROC_HC_FACTURA_REMISION_GUARDAR]"
                comando.Parameters.Add(New SqlParameter("@codigo_factura", SqlDbType.NVarChar)).Value = objFactura.codigoFactura
                comando.Parameters.Add(New SqlParameter("@id_empresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                comando.Parameters.Add(New SqlParameter("@OBSERVACION", SqlDbType.NVarChar)).Value = objFactura.observacion
                comando.Parameters.Add(New SqlParameter("@fecha_factura", SqlDbType.DateTime)).Value = objFactura.fechaFactura
                comando.Parameters.Add(New SqlParameter("@fecha_vence", SqlDbType.DateTime)).Value = objFactura.fechaVencimiento
                comando.Parameters.Add(New SqlParameter("@total_factura", SqlDbType.Float)).Value = objFactura.totalFactura
                comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objFactura.usuario
                comando.Parameters.Add(New SqlParameter("@Tabla", SqlDbType.Structured)).Value = objFactura.dtAFacturar
                objFactura.codigoFactura = CType(comando.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
