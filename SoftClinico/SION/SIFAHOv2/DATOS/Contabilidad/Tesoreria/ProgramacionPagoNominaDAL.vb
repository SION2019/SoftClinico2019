Public Class ProgramacionPagoNominaDAL
    Public Sub crearProgramacionPagoNomina(ByVal objProgramacionPagoNomina As ProgramacionPagoNomina)
        Try
            Using dbCommand As New SqlCommand

                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_PROGRAMACION_NOMINA_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@programacionNomina", SqlDbType.Structured)).Value = objProgramacionPagoNomina.dtNomina
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
