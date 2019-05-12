Public Class CuentasPorCobrarDAL
    Public Sub CuentaPorCobrar(ByVal objcuentasCXP As CuentasPorCobrar, pUSuario As Integer)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_CUENTAS_POR_COBRAR_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@Codigo_factura", SqlDbType.NVarChar)).Value = objcuentasCXP.factura
                dbCommand.Parameters.Add(New SqlParameter("@id_empresa", SqlDbType.Int)).Value = objcuentasCXP.idEmpresa
                dbCommand.Parameters.Add(New SqlParameter("@Codigo_Documento", SqlDbType.Int)).Value = objcuentasCXP.codigoDocumento
                dbCommand.Parameters.Add(New SqlParameter("@id_tercero", SqlDbType.Int)).Value = objcuentasCXP.idCliente
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_Recibo", SqlDbType.Date)).Value = objcuentasCXP.fechaRecibo
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_Vence", SqlDbType.Date)).Value = objcuentasCXP.fechaVence
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_Doc", SqlDbType.Date)).Value = objcuentasCXP.fechaDoc
                dbCommand.Parameters.Add(New SqlParameter("@valor_debito", SqlDbType.Decimal)).Value = objcuentasCXP.valorDebito
                dbCommand.Parameters.Add(New SqlParameter("@valor_credito", SqlDbType.Decimal)).Value = objcuentasCXP.valorCredito
                dbCommand.Parameters.Add(New SqlParameter("@detalle_carteracxc", SqlDbType.Structured)).Value = objcuentasCXP.dtCuentas
                dbCommand.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.Int)).Value = pUSuario
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub actualizarcuentasCXP(ByVal objcuentasCXP As CuentasPorCobrar, pUSuario As Integer)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_CUENTAS_POR_COBRAR_ACTUALIZAR"
                dbCommand.Parameters.Add(New SqlParameter("@Codigo_factura", SqlDbType.NVarChar)).Value = objcuentasCXP.identificador
                dbCommand.Parameters.Add(New SqlParameter("@Codigo_Documento", SqlDbType.Int)).Value = objcuentasCXP.codigoDocumento
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_Recibo", SqlDbType.Date)).Value = objcuentasCXP.fechaRecibo
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_Vence", SqlDbType.Date)).Value = objcuentasCXP.fechaVence
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_Doc", SqlDbType.Date)).Value = objcuentasCXP.fechaDoc
                dbCommand.Parameters.Add(New SqlParameter("@valor_debito", SqlDbType.Decimal)).Value = objcuentasCXP.valorDebito
                dbCommand.Parameters.Add(New SqlParameter("@valor_credito", SqlDbType.Decimal)).Value = objcuentasCXP.valorCredito
                dbCommand.Parameters.Add(New SqlParameter("@detalle_carteracxc", SqlDbType.Structured)).Value = objcuentasCXP.dtCuentas
                dbCommand.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.Int)).Value = pUSuario
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub guardarNuevaFechaRadicacion(ByVal objcuentasCXP As CuentasPorCobrar)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_CUENTAS_POR_COBRAR_NRAD_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@Codigo_factura", SqlDbType.NVarChar)).Value = objcuentasCXP.identificador
                dbCommand.Parameters.Add(New SqlParameter("id_Empresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                dbCommand.Parameters.Add(New SqlParameter("@Cod_Parametro", SqlDbType.NVarChar)).Value = Constantes.NEW_RADICACION
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_NRad", SqlDbType.Date)).Value = objcuentasCXP.fechaNRad
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub guardarFactExonerada(ByVal objcuentasCXP As CuentasPorCobrar)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_CUENTAS_POR_COBRAR_NRAD_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@Codigo_factura", SqlDbType.NVarChar)).Value = objcuentasCXP.factura
                dbCommand.Parameters.Add(New SqlParameter("id_Empresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                dbCommand.Parameters.Add(New SqlParameter("@Cod_Parametro", SqlDbType.NVarChar)).Value = Constantes.FACT_EXONERADA
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_NRad", SqlDbType.NVarChar)).Value = objcuentasCXP.observacion
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
