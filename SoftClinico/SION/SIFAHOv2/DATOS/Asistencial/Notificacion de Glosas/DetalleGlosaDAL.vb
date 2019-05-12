Public Class DetalleGlosaDAL
    Public Function crearDetalleGlosa(ByVal objDetalleGlosa As DetalleGlosa)
        Dim codigo As String = String.Empty
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_DETALLE_GLOSA_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@DetalleGlosa", SqlDbType.Structured)).Value = objDetalleGlosa.dtGlosa
                codigo = CType(dbCommand.ExecuteScalar, Integer)
            End Using
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
        Return codigo
    End Function

End Class
