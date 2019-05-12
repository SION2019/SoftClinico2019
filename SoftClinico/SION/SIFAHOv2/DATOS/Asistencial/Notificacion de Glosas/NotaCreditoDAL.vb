Public Class NotaCreditoDAL
    Public Function CrearNotaCredito(ByVal objNotaCredito As NotaCredito) As String

        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_NOTA_CREDITO_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@Factura", SqlDbType.NVarChar)).Value = objNotaCredito.Factura
                dbCommand.Parameters.Add(New SqlParameter("@fechaRadicacion", SqlDbType.Date)).Value = objNotaCredito.fechaRadicacion
                dbCommand.Parameters.Add(New SqlParameter("@fechaDevolucion", SqlDbType.Date)).Value = objNotaCredito.fechaDevolucion
                dbCommand.Parameters.Add(New SqlParameter("@idEmpresa", SqlDbType.Int)).Value = objNotaCredito.idEmpresa
                dbCommand.Parameters.Add(New SqlParameter("@concepto", SqlDbType.NVarChar)).Value = objNotaCredito.concepto
                dbCommand.Parameters.Add(New SqlParameter("@usuarioCreacion", SqlDbType.Int)).Value = objNotaCredito.usuarioCreacion
                dbCommand.Parameters.Add(New SqlParameter("@OpcRadicacion", SqlDbType.Bit)).Value = objNotaCredito.OpcionFechaRadicacion
                dbCommand.Parameters.Add(New SqlParameter("@OpcDevolucion", SqlDbType.Bit)).Value = objNotaCredito.OpcionFechaDevolucion
                objNotaCredito.Id_Nota = CType(dbCommand.ExecuteScalar, Integer)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objNotaCredito.Id_Nota
    End Function

    Public Sub actualizarNotaCredito(ByVal objNotaCredito As NotaCredito)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_NOTA_CREDITO_ACTUALIZAR"
                dbCommand.Parameters.Add(New SqlParameter("@CODNOTA", SqlDbType.NVarChar)).Value = objNotaCredito.Id_Nota
                dbCommand.Parameters.Add(New SqlParameter("@fechaRadicacion", SqlDbType.Date)).Value = objNotaCredito.fechaRadicacion
                dbCommand.Parameters.Add(New SqlParameter("@fechaDevolucion", SqlDbType.Date)).Value = objNotaCredito.fechaDevolucion
                dbCommand.Parameters.Add(New SqlParameter("@idEmpresa", SqlDbType.Int)).Value = objNotaCredito.idEmpresa
                dbCommand.Parameters.Add(New SqlParameter("@concepto", SqlDbType.NVarChar)).Value = objNotaCredito.concepto
                dbCommand.Parameters.Add(New SqlParameter("@usuarioCreacion", SqlDbType.Int)).Value = objNotaCredito.usuarioActualizacion
                dbCommand.Parameters.Add(New SqlParameter("@OpcRadicacion", SqlDbType.Bit)).Value = objNotaCredito.OpcionFechaRadicacion
                dbCommand.Parameters.Add(New SqlParameter("@OpcDevolucion", SqlDbType.Bit)).Value = objNotaCredito.OpcionFechaDevolucion
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
