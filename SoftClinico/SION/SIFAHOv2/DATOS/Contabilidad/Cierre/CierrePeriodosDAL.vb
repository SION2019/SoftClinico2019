Public Class CierrePeriodosDAL
    Public Sub cerrarMes(ByVal objcierre As CierrePeriodos)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_CIERRE_MES_CERRAR"
                dbCommand.Parameters.Add(New SqlParameter("@cierreMes", SqlDbType.Structured)).Value = objcierre.dtCierre
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

End Class
