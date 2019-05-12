Public Class CierreDocumentosDAL
    Public Sub crearCierreDocumento(ByVal objCierreDocumento As CierreDocumentos, pUSuario As Integer)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_CIERRE_DOCUMENTOS_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@Comprobante", SqlDbType.NVarChar)).Value = objCierreDocumento.comprobante
                dbCommand.Parameters.Add(New SqlParameter("@id_empresa", SqlDbType.Int)).Value = objCierreDocumento.idEmpresa
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_Inicio", SqlDbType.Date)).Value = objCierreDocumento.fechaInicio
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_Fin", SqlDbType.Date)).Value = objCierreDocumento.fechaFin
                dbCommand.Parameters.Add(New SqlParameter("@valor_debito", SqlDbType.Decimal)).Value = objCierreDocumento.valorDebito
                dbCommand.Parameters.Add(New SqlParameter("@valor_credito", SqlDbType.Decimal)).Value = objCierreDocumento.valorCredito
                dbCommand.Parameters.Add(New SqlParameter("@detalle_carteracxp", SqlDbType.Structured)).Value = objCierreDocumento.dtCierre
                dbCommand.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.Int)).Value = pUSuario
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub actualizarCierreDocumento(ByVal objCierreDocumento As CierreDocumentos, pUSuario As Integer)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_CIERRE_DOCUMENTOS_ACTUALIZAR"
                dbCommand.Parameters.Add(New SqlParameter("@comprobante", SqlDbType.NVarChar)).Value = objCierreDocumento.comprobante
                dbCommand.Parameters.Add(New SqlParameter("@detalle_carteracxp", SqlDbType.Structured)).Value = objCierreDocumento.dtCierre
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
