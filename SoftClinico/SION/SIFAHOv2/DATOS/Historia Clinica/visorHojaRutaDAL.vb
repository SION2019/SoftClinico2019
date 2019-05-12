Public Class visorHojaRutaDAL
    Public Shared Sub guardarHojaRutaVisor(objVisor As VisorNotificacion)
        Dim dtNotificacion As New DataTable
        objVisor.dtNotificacion.AcceptChanges()
        dtNotificacion = objVisor.dtNotificacion.Copy
        dtNotificacion.Columns.Remove("Fecha")
        dtNotificacion.Columns.Remove("Autor")
        dtNotificacion.Columns.Remove("Descripcion")
        dtNotificacion.Columns.Remove("Fecha Realizacion")
        dtNotificacion.Columns.Remove("Responsable")
        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction()
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.CommandType = CommandType.StoredProcedure
                    comando.Parameters.Clear()
                    comando.CommandText = objVisor.sqlConsultaGuardar
                    comando.Parameters.Add(New SqlParameter("@Registro", SqlDbType.Int)).Value = objVisor.registro
                    comando.Parameters.Add(New SqlParameter("@FechaDia", SqlDbType.Date)).Value = objVisor.fecha
                    comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = SesionActual.idUsuario
                    comando.Parameters.Add(New SqlParameter("@Tabla", SqlDbType.Structured)).Value = dtNotificacion
                    comando.ExecuteNonQuery()
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
