Public Class NotificacionDevolucionDAL
    Public Function crearNotificacionDevolucion(ByVal objNotificacionDevolucion As NotificacionDevolucion)
        Dim codigo As String = String.Empty
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_NOTIFICACION_DEVOLUCION_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@notificacionDev", SqlDbType.Structured)).Value = objNotificacionDevolucion.dtDevolucion
                codigo = CType(dbCommand.ExecuteScalar, Integer)
            End Using
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
        Return codigo
    End Function

    Public Sub actualizarNotificacionDevolucion(ByVal objNotificacionDevolucion As NotificacionDevolucion)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_NOTIFICACION_DEVOLUCION_ACTUALIZAR"
                dbCommand.Parameters.Add(New SqlParameter("@codigoDevolucion", SqlDbType.Int)).Value = objNotificacionDevolucion.identificador
                dbCommand.Parameters.Add(New SqlParameter("@notificacionDev", SqlDbType.Structured)).Value = objNotificacionDevolucion.dtDevolucion
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
