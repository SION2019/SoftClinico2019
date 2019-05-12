Public Class NotificacionGlosaDAL
    Public Function crearNotificacionGlosa(ByVal objNotificacionGlosa As NotificacionGlosa)
        Dim codigo As String = String.Empty
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_NOTIFICACION_GLOSA_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@notificacionGlosa", SqlDbType.Structured)).Value = objNotificacionGlosa.dtGlosa
                codigo = CType(dbCommand.ExecuteScalar, Integer)
            End Using
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
        Return codigo
    End Function

    Public Sub actualizarNotificacionGlosa(ByVal objNotificacionGlosa As NotificacionGlosa)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_NOTIFICACION_GLOSA_ACTUALIZAR"
                dbCommand.Parameters.Add(New SqlParameter("@codigoGlosa", SqlDbType.Int)).Value = objNotificacionGlosa.identificador
                dbCommand.Parameters.Add(New SqlParameter("@notificacionGlosa", SqlDbType.Structured)).Value = objNotificacionGlosa.dtGlosa
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
