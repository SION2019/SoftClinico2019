Public Class FacturaRadicacionDAL
    Public Shared Sub calcularFacturaRadicacion(params As FacturaRadicacionParams)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "[PROC_FACTURA_REPORTE]"

                dbCommand.Parameters.Add(New SqlParameter("@FECHAINICIO", SqlDbType.Date)).Value = Format(params.fechaInicio, Constantes.FORMATO_FECHA_GEN)
                dbCommand.Parameters.Add(New SqlParameter("@FECHAFIN", SqlDbType.Date)).Value = Format(params.fechaFin, Constantes.FORMATO_FECHA_GEN)
                dbCommand.Parameters.Add(New SqlParameter("@IDCLIENTE", SqlDbType.Int)).Value = IIf(params.idTercero = Nothing,
                                                                                                        DBNull.Value,
                                                                                                        params.idTercero)
                dbCommand.Parameters.Add(New SqlParameter("@TIPOFACT", SqlDbType.Int)).Value = params.TipoFactura
                dbCommand.Parameters.Add(New SqlParameter("@id_empresa", SqlDbType.Int)).Value = params.idEmpresa


                dbCommand.ExecuteNonQuery()
                params.resultado = True

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
