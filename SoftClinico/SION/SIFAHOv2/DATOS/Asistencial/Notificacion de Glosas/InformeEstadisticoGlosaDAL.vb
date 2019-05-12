Public Class InformeEstadisticoGlosaDAL
    Public Sub guardarInformeGlosa(ByVal objInformeGlosa As InformeDetalleGlosa)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_INFORME_GLOSA_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@InformeDetalleGlosa", SqlDbType.Structured)).Value = objInformeGlosa.dtGlosa
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
