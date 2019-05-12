Public Class CuentaPorPagarDAL
    Public Sub CuentaPorPagar(ByVal objcuentasCXP As CuentasPorPagar, pUSuario As Integer)
        Try
            Using dbCommand As New SqlCommand
                objcuentasCXP.comprobante = FuncionesContables.verificarConsecutivo(SesionActual.idEmpresa, objcuentasCXP.codigoDocumento)
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_CUENTAS_POR_PAGAR_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@Comprobante", SqlDbType.NVarChar)).Value = objcuentasCXP.comprobante
                dbCommand.Parameters.Add(New SqlParameter("@id_empresa", SqlDbType.Int)).Value = objcuentasCXP.idEmpresa
                dbCommand.Parameters.Add(New SqlParameter("@Codigo_Documento", SqlDbType.Int)).Value = objcuentasCXP.codigoDocumento
                dbCommand.Parameters.Add(New SqlParameter("@Codigo_Entrada", SqlDbType.NVarChar)).Value = objcuentasCXP.factura
                dbCommand.Parameters.Add(New SqlParameter("@id_tercero", SqlDbType.Int)).Value = objcuentasCXP.idProveedor
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_Recibo", SqlDbType.Date)).Value = objcuentasCXP.fechaRecibo
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_Vence", SqlDbType.Date)).Value = objcuentasCXP.fechaVence
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_Doc", SqlDbType.Date)).Value = objcuentasCXP.fechaDoc
                dbCommand.Parameters.Add(New SqlParameter("@Observacion", SqlDbType.NVarChar)).Value = objcuentasCXP.observacion
                dbCommand.Parameters.Add(New SqlParameter("@valor_debito", SqlDbType.Decimal)).Value = objcuentasCXP.valorDebito
                dbCommand.Parameters.Add(New SqlParameter("@valor_credito", SqlDbType.Decimal)).Value = objcuentasCXP.valorCredito
                dbCommand.Parameters.Add(New SqlParameter("@valor_Iva", SqlDbType.Decimal)).Value = objcuentasCXP.valorIva
                dbCommand.Parameters.Add(New SqlParameter("@valor_rete", SqlDbType.Decimal)).Value = objcuentasCXP.valorRete
                dbCommand.Parameters.Add(New SqlParameter("@detalle_carteracxp", SqlDbType.Structured)).Value = objcuentasCXP.dtCuentas
                dbCommand.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.Int)).Value = pUSuario
                dbCommand.ExecuteNonQuery()
                FuncionesContables.aumentarConsecutivo(objcuentasCXP.idEmpresa, objcuentasCXP.codigoDocumento)
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub actualizarcuentasCXP(ByVal objcuentasCXP As CuentasPorPagar, pUSuario As Integer)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_FACTURA_PROVEEDOR_ACTUALIZAR"
                dbCommand.Parameters.Add(New SqlParameter("@comprobante", SqlDbType.NVarChar)).Value = objcuentasCXP.identificador
                dbCommand.Parameters.Add(New SqlParameter("@FechaDoc", SqlDbType.Date)).Value = objcuentasCXP.fechaDoc
                dbCommand.Parameters.Add(New SqlParameter("@Observacion", SqlDbType.NVarChar)).Value = objcuentasCXP.observacion
                dbCommand.Parameters.Add(New SqlParameter("@valor_debito", SqlDbType.Decimal)).Value = objcuentasCXP.valorDebito
                dbCommand.Parameters.Add(New SqlParameter("@valor_credito", SqlDbType.Decimal)).Value = objcuentasCXP.valorCredito
                dbCommand.Parameters.Add(New SqlParameter("@valor_Iva", SqlDbType.Decimal)).Value = objcuentasCXP.valorIva
                dbCommand.Parameters.Add(New SqlParameter("@valor_rete", SqlDbType.Decimal)).Value = objcuentasCXP.valorRete
                dbCommand.Parameters.Add(New SqlParameter("@detalle_carteracxp", SqlDbType.Structured)).Value = objcuentasCXP.dtCuentas
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
