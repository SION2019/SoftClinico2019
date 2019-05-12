Imports System.Data.SqlClient
Public Class ConsolidadoComidaDetalladoDAL
    Public Sub Guardar(objconsolidadoComidaDetallado As ConsolidadoComidaDetallado)
        Try
            Using sentencia = New SqlCommand
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    sentencia.Connection = FormPrincipal.cnxion
                    sentencia.Transaction = trnsccion
                    sentencia.CommandType = CommandType.StoredProcedure

                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "[PROC_INSERTAR_TABLA_TEMP_COMIDA_DETALLADO]"
                    sentencia.Parameters.Add(New SqlParameter("@tabla", SqlDbType.Structured)).Value = objconsolidadoComidaDetallado.tblDetalleDias
                    sentencia.ExecuteNonQuery()


                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
