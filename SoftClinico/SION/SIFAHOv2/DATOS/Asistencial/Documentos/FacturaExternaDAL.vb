Public Class FacturaExternaDAL
    Public Shared Sub guardarFactura(ByRef objFactura As FacturaExterna)
        Try
            Using comando = New SqlCommand()
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "[PROC_HC_FACTURA_EXTERNA_GUARDAR]"
                comando.Parameters.Add(New SqlParameter("@codigo_factura", SqlDbType.NVarChar)).Value = objFactura.codigoFactura
                comando.Parameters.Add(New SqlParameter("@CONTRATO", SqlDbType.Int)).Value = objFactura.CodigoContrato
                comando.Parameters.Add(New SqlParameter("@id_empresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                comando.Parameters.Add(New SqlParameter("@OBSERVACION", SqlDbType.NVarChar)).Value = objFactura.observacion
                comando.Parameters.Add(New SqlParameter("@fecha_factura", SqlDbType.DateTime)).Value = objFactura.fechaFactura
                comando.Parameters.Add(New SqlParameter("@fecha_vence", SqlDbType.DateTime)).Value = objFactura.fechaVencimiento
                comando.Parameters.Add(New SqlParameter("@FECHA_INICIO", SqlDbType.DateTime)).Value = objFactura.fechaInicio
                comando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.DateTime)).Value = objFactura.fechaFin
                comando.Parameters.Add(New SqlParameter("@total_factura", SqlDbType.Float)).Value = objFactura.totalFactura
                comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objFactura.usuario
                comando.Parameters.Add(New SqlParameter("@TablaPAR", SqlDbType.Structured)).Value = objFactura.dtParaclinicos
                comando.Parameters.Add(New SqlParameter("@TablaHEM", SqlDbType.Structured)).Value = objFactura.dtHemoderivados
                comando.Parameters.Add(New SqlParameter("@TablaPRO", SqlDbType.Structured)).Value = objFactura.dtProcedimientos
                comando.Parameters.Add(New SqlParameter("@TablaMED", SqlDbType.Structured)).Value = objFactura.dtMedicamentos
                comando.Parameters.Add(New SqlParameter("@TablaINS", SqlDbType.Structured)).Value = objFactura.dtInsumos
                comando.Parameters.Add(New SqlParameter("@TablaDetalle", SqlDbType.Structured)).Value = objFactura.dtConsolidadoPaciente
                comando.Parameters.Add(New SqlParameter("@Tabla", SqlDbType.Structured)).Value = objFactura.dtAFacturar
                objFactura.codigoFactura = CType(comando.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Shared Sub cargarPendientes(ByRef objFactura As FacturaExterna)
        Try
            ' Create the SelectCommand.
            Dim command As SqlCommand = New SqlCommand()
            command.Connection = FormPrincipal.cnxion
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = objFactura.sqlbuscarRegistroAFacturar
            command.Parameters.Add(New SqlParameter("@CODIGO_CONTRATO", SqlDbType.Int)).Value = objFactura.CodigoContrato
            command.Parameters.Add(New SqlParameter("@fecha_ini", SqlDbType.Date)).Value = objFactura.fechaInicio
            command.Parameters.Add(New SqlParameter("@fecha_fin", SqlDbType.Date)).Value = objFactura.fechaFin
            command.Parameters.Add(New SqlParameter("@COnsolidado", SqlDbType.Bit)).Value = objFactura.consolidado
            command.Parameters.Add(New SqlParameter("@Tabla", SqlDbType.Structured)).Value = objFactura.dtAFacturar

            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)

            adapter.Fill(objFactura.dtPendiente)

        Catch ex As SqlException
            Throw ex
        End Try
    End Sub
    Public Shared Sub cargarInsumoPendientes(objFactura As FacturaExterna)
        Try
            ' Create the SelectCommand.
            Dim command As SqlCommand = New SqlCommand()
            command.Connection = FormPrincipal.cnxion
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = objFactura.sqlPrecargarInsumos
            command.Parameters.Add(New SqlParameter("@Tabla", SqlDbType.Structured)).Value = objFactura.dtAFacturar
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
            adapter.Fill(objFactura.dtInsumos)

        Catch ex As SqlException
            Throw ex
        End Try
    End Sub

    Public Shared Sub cargarMedicamentoPendientes(objFactura As FacturaExterna)
        Try
            ' Create the SelectCommand.
            Dim command As SqlCommand = New SqlCommand()
            command.Connection = FormPrincipal.cnxion
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = objFactura.sqlPrecargarMedicamentos
            command.Parameters.Add(New SqlParameter("@Tabla", SqlDbType.Structured)).Value = objFactura.dtAFacturar
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
            adapter.Fill(objFactura.dtMedicamentos)

        Catch ex As SqlException
            Throw ex
        End Try
    End Sub
    Public Shared Sub cargarParaclinicoPendientes(objFactura As FacturaExterna)
        Try
            ' Create the SelectCommand.
            Dim command As SqlCommand = New SqlCommand()
            command.Connection = FormPrincipal.cnxion
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = objFactura.sqlPrecargarParaclinicos
            command.Parameters.Add(New SqlParameter("@Tabla", SqlDbType.Structured)).Value = objFactura.dtAFacturar
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
            adapter.Fill(objFactura.dtParaclinicos)

        Catch ex As SqlException
            Throw ex
        End Try
    End Sub

    Public Shared Sub cargarProcedimientoPendientes(objFactura As FacturaExterna)
        Try
            ' Create the SelectCommand.
            Dim command As SqlCommand = New SqlCommand()
            command.Connection = FormPrincipal.cnxion
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = objFactura.sqlPrecargarProcedimientos
            command.Parameters.Add(New SqlParameter("@Tabla", SqlDbType.Structured)).Value = objFactura.dtAFacturar
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
            adapter.Fill(objFactura.dtProcedimientos)

        Catch ex As SqlException
            Throw ex
        End Try
    End Sub
    Public Shared Sub cargarHemoderivadoPendientes(objFactura As FacturaExterna)
        Try
            ' Create the SelectCommand.
            Dim command As SqlCommand = New SqlCommand()
            command.Connection = FormPrincipal.cnxion
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = objFactura.sqlPrecargarHemoderivados
            command.Parameters.Add(New SqlParameter("@Tabla", SqlDbType.Structured)).Value = objFactura.dtAFacturar
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
            adapter.Fill(objFactura.dtHemoderivados)

        Catch ex As SqlException
            Throw ex
        End Try
    End Sub
End Class
