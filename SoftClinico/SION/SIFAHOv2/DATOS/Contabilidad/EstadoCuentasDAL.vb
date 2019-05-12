Public Class EstadoCuentasDAL
    Public Sub crearEstadoCuentas(ByVal objEstadoCuentas As EstadoDeCuentas)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_ESTADO_CUENTAS_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@EstadoCuentas", SqlDbType.Structured)).Value = objEstadoCuentas.dtCuentas
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class
