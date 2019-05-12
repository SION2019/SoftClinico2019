Public Class RecaudoDAL
    Public Shared Function guardarRecaudo(objRecaudo As Recaudo)
        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction()
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.CommandType = CommandType.StoredProcedure
                    comando.Parameters.Clear()
                    comando.CommandText = objRecaudo.sqlGuardarRecaudo
                    comando.Parameters.Add(New SqlParameter("@Comprobante", SqlDbType.NVarChar)).Value = objRecaudo.comprobante
                    comando.Parameters.Add(New SqlParameter("@CodigoDocumento", SqlDbType.Int)).Value = objRecaudo.codigoDocumento
                    comando.Parameters.Add(New SqlParameter("@CodigoEp", SqlDbType.Int)).Value = objRecaudo.codigoep
                    comando.Parameters.Add(New SqlParameter("@CodigoTercero", SqlDbType.Int)).Value = objRecaudo.codigoTercero
                    comando.Parameters.Add(New SqlParameter("@FechaRecibo", SqlDbType.DateTime)).Value = objRecaudo.fechaDocum
                    comando.Parameters.Add(New SqlParameter("@DetalleMov", SqlDbType.NVarChar)).Value = objRecaudo.Movimiento
                    comando.Parameters.Add(New SqlParameter("@ValorDebito", SqlDbType.Money)).Value = objRecaudo.valorDebito
                    comando.Parameters.Add(New SqlParameter("@ValorCredito", SqlDbType.Money)).Value = objRecaudo.valorCredito
                    comando.Parameters.Add(New SqlParameter("@ValorSubTotal", SqlDbType.Money)).Value = objRecaudo.valorSubTotal
                    comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objRecaudo.usuario
                    comando.Parameters.Add(New SqlParameter("@tabla", SqlDbType.Structured)).Value = objRecaudo.dtDetalle
                    comando.ExecuteNonQuery()
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objRecaudo
    End Function
End Class
