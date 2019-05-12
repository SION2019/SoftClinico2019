Public Class ConfiguracionConceptosDianDAL
    Public Sub crearConfiguracion(ByVal objConceptoDian As ConfiguracionConceptosDian)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_CONFIGURACION_CONCEPTOS_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@codigoConcepto", SqlDbType.NVarChar)).Value = objConceptoDian.codigoConcepto
                dbCommand.Parameters.Add(New SqlParameter("@Conceptos", SqlDbType.Structured)).Value = objConceptoDian.dtCuentas
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
