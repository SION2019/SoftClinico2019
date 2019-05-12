Public Class ConfiguracionTipoCuentaDAL
    Public Sub crearConfiguracion(ByVal objConfiguracionTipoCuenta As ConfiguracionTipoCuenta)
        Try
            Using dbCommand As New SqlCommand

                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_TIPO_CUENTA_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@TipoCuenta", SqlDbType.Structured)).Value = objConfiguracionTipoCuenta.dtCuentas
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
