Public Class LiquidacionContratoDAL
    Public Sub crearLiquidacionContrato(ByVal objLiquidacionContrato As LiquidacionContrato)
        Try
            Using dbCommand As New SqlCommand

                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_LIQUIDACION_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@Liquidacion", SqlDbType.Structured)).Value = objLiquidacionContrato.dtLiquidacion
                dbCommand.Parameters.Add(New SqlParameter("@usuario", SqlDbType.Int))
                dbCommand.Parameters("@usuario").Value = objLiquidacionContrato.usuario
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
