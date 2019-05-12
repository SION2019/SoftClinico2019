Public Class ConfiguracionCentroDeCostosDAL
    Public Sub crearConfiguracion(ByVal objCentroCosto As ConfiguracionCentroDeCostos)
        Try
            Using dbCommand As New SqlCommand

                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_CONFIGURACION_CENTROS_COSTO_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@CentroCostos", SqlDbType.Structured)).Value = objCentroCosto.dtCuentas
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
