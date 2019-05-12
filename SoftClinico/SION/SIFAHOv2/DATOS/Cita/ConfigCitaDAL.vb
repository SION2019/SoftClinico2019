Imports System.Data.SqlClient
Public Class ConfigCitaDAL
    Public Shared Function guardarConfigCita(objConfiguracion As ConfigCita)
        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction()
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.CommandType = CommandType.StoredProcedure
                    comando.Parameters.Clear()
                    comando.CommandText = "[PROC_CONFI_CITA_CREAR]"
                    comando.Parameters.Add(New SqlParameter("@idEmpleado", SqlDbType.Int)).Value = objConfiguracion.idEmpleado
                    comando.Parameters.Add(New SqlParameter("@CantidadCita", SqlDbType.Int)).Value = objConfiguracion.cantidadCita
                    comando.Parameters.Add(New SqlParameter("@CantidadTiempo", SqlDbType.Int)).Value = objConfiguracion.tiempo
                    comando.ExecuteNonQuery()
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objConfiguracion
    End Function

End Class
