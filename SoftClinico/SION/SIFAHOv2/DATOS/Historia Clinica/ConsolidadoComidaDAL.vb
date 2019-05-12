Imports System.Data.SqlClient
Public Class ConsolidadoComidaDAL
    Public Sub guardar(ByRef objConsolidadoComida As ConsolidadoComida, ByVal ususario As String)
        Try
            Using sentencia = New SqlCommand
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    sentencia.Connection = FormPrincipal.cnxion
                    sentencia.Transaction = trnsccion
                    sentencia.CommandType = CommandType.StoredProcedure

                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "[PROC_LIMPIAR_TABLA_TEMP_COMIDA]"
                    sentencia.ExecuteNonQuery()

                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "[PROC_INSERTAR_TABLA_TEMP_COMIDA]"
                    sentencia.Parameters.Add(New SqlParameter("@pTipoComida", SqlDbType.Int)).Value = Constantes.DESAYUNO
                    sentencia.Parameters.Add(New SqlParameter("@tabla", SqlDbType.Structured)).Value = objConsolidadoComida.tblDesayunos
                    sentencia.Parameters.Add(New SqlParameter("@empresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                    sentencia.ExecuteNonQuery()

                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "[PROC_INSERTAR_TABLA_TEMP_COMIDA]"
                    sentencia.Parameters.Add(New SqlParameter("@pTipoComida", SqlDbType.Int)).Value = Constantes.ALMUERZO
                    sentencia.Parameters.Add(New SqlParameter("@tabla", SqlDbType.Structured)).Value = objConsolidadoComida.tblAlmuerzos
                    sentencia.Parameters.Add(New SqlParameter("@empresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                    sentencia.ExecuteNonQuery()

                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "[PROC_INSERTAR_TABLA_TEMP_COMIDA]"
                    sentencia.Parameters.Add(New SqlParameter("@pTipoComida", SqlDbType.Int)).Value = Constantes.CENA
                    sentencia.Parameters.Add(New SqlParameter("@tabla", SqlDbType.Structured)).Value = objConsolidadoComida.tblCenas
                    sentencia.Parameters.Add(New SqlParameter("@empresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                    sentencia.ExecuteNonQuery()

                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
