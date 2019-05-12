Public Class HojaRutaDAL
    Public Shared Function guardarHojaRuta(objHojaRuta As HojaRuta)
        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction()
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.CommandType = CommandType.StoredProcedure
                    comando.Parameters.Clear()

                    comando.CommandText = objHojaRuta.sqlGuardarHojaRuta

                    comando.Parameters.Add(New SqlParameter("@Registro", SqlDbType.Int)).Value = objHojaRuta.registro
                    comando.Parameters.Add(New SqlParameter("@FechaDia", SqlDbType.Date)).Value = objHojaRuta.fechaActual
                    comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objHojaRuta.usuario
                    comando.Parameters.Add(New SqlParameter("@Tabla", SqlDbType.Structured)).Value = objHojaRuta.dtHojaRuta

                    comando.ExecuteNonQuery()

                    trnsccion.Commit()

                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
        Return objHojaRuta
    End Function
    Public Shared Sub guardarTareasProgramas(objHojaRuta As HojaRuta)
        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction()
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.CommandType = CommandType.StoredProcedure
                    comando.Parameters.Clear()
                    comando.CommandText = objHojaRuta.sqlGuardarTareasProgram
                    comando.Parameters.Add(New SqlParameter("@Registro", SqlDbType.Int)).Value = objHojaRuta.registro
                    comando.Parameters.Add(New SqlParameter("@FechaDia", SqlDbType.Date)).Value = objHojaRuta.fechaActual
                    comando.Parameters.Add(New SqlParameter("@id_Empleado", SqlDbType.Int)).Value = objHojaRuta.idEmpleado
                    comando.Parameters.Add(New SqlParameter("@ID_Usuario", SqlDbType.Int)).Value = SesionActual.idUsuario
                    comando.Parameters.Add(New SqlParameter("@TablaProgram", SqlDbType.Structured)).Value = objHojaRuta.dtProgram
                    comando.ExecuteNonQuery()
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
