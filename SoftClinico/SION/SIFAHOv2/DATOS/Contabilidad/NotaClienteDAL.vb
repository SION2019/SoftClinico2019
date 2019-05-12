Public Class NotaClienteDAL
    Public Sub crearNotaCliente(ByVal objNotaCliente As NotaCliente, pUSuario As Integer)
        Try
            Using dbCommand As New SqlCommand
                objNotaCliente.comprobante = FuncionesContables.verificarConsecutivo(SesionActual.idEmpresa, objNotaCliente.codigoDocumento)
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_NOTA_CLIENTE_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@Comprobante", SqlDbType.NVarChar)).Value = objNotaCliente.comprobante
                dbCommand.Parameters.Add(New SqlParameter("@id_empresa", SqlDbType.Int)).Value = objNotaCliente.idEmpresa
                dbCommand.Parameters.Add(New SqlParameter("@id_tercero", SqlDbType.Int)).Value = objNotaCliente.idCliente
                dbCommand.Parameters.Add(New SqlParameter("@CodigoDoc", SqlDbType.Int)).Value = objNotaCliente.codigoDoc
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_Recibo", SqlDbType.Date)).Value = objNotaCliente.fechaRecibo
                dbCommand.Parameters.Add(New SqlParameter("@Observacion", SqlDbType.NVarChar)).Value = objNotaCliente.detalleMov
                dbCommand.Parameters.Add(New SqlParameter("@valor_debito", SqlDbType.Decimal)).Value = objNotaCliente.valorDebito
                dbCommand.Parameters.Add(New SqlParameter("@valor_credito", SqlDbType.Decimal)).Value = objNotaCliente.valorCredito
                dbCommand.Parameters.Add(New SqlParameter("@valor_sub", SqlDbType.Decimal)).Value = objNotaCliente.valorSubtotal
                dbCommand.Parameters.Add(New SqlParameter("@detalleNota", SqlDbType.Structured)).Value = objNotaCliente.dtCuentas
                dbCommand.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.Int)).Value = pUSuario
                dbCommand.ExecuteNonQuery()
                FuncionesContables.aumentarConsecutivo(objNotaCliente.idEmpresa, objNotaCliente.codigoDocumento)
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub actualizarNotaCliente(ByVal objNotaCliente As NotaCliente, pUSuario As Integer)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_NOTA_CLIENTE_ACTUALIZAR"
                dbCommand.Parameters.Add(New SqlParameter("@comprobante", SqlDbType.NVarChar)).Value = objNotaCliente.identificador
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_Recibo", SqlDbType.Date)).Value = objNotaCliente.fechaRecibo
                dbCommand.Parameters.Add(New SqlParameter("@Observacion", SqlDbType.NVarChar)).Value = objNotaCliente.detalleMov
                dbCommand.Parameters.Add(New SqlParameter("@valor_debito", SqlDbType.Decimal)).Value = objNotaCliente.valorDebito
                dbCommand.Parameters.Add(New SqlParameter("@valor_credito", SqlDbType.Decimal)).Value = objNotaCliente.valorCredito
                dbCommand.Parameters.Add(New SqlParameter("@valor_sub", SqlDbType.Decimal)).Value = objNotaCliente.valorSubtotal
                dbCommand.Parameters.Add(New SqlParameter("@detalleNotaCliente", SqlDbType.Structured)).Value = objNotaCliente.dtCuentas
                dbCommand.Parameters.Add(New SqlParameter("@Usuario_Actualizacion", SqlDbType.Int)).Value = pUSuario
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
