Imports System.Data.SqlClient

Public Class ProductoPresentacionDAL
    Public Sub guardar(ByRef present As Presentacion,
                       ByVal usuario As String)
        Try
            Using sentencia = New SqlCommand
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    sentencia.Connection = FormPrincipal.cnxion
                    sentencia.Transaction = trnsccion
                    sentencia.CommandType = CommandType.StoredProcedure

                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "[PROC_PRESENTACION_CREAR]"
                    sentencia.Parameters.Add(New SqlParameter("@nombre", SqlDbType.NVarChar)).Value = present.Descripcion
                    sentencia.Parameters.Add(New SqlParameter("@usuario", SqlDbType.Int)).Value = usuario
                    present.Codigo = CType(sentencia.ExecuteScalar, String)

                    trnsccion.Commit()

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub actualizar(ByRef present As Presentacion,
                          ByVal usuario As String)
        Try
            Using sentencia = New SqlCommand
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    sentencia.Connection = FormPrincipal.cnxion
                    sentencia.Transaction = trnsccion
                    sentencia.CommandType = CommandType.StoredProcedure

                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "[PROC_PRESENTACION_ACTUALIZAR]"
                    sentencia.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.Int)).Value = present.Codigo
                    sentencia.Parameters.Add(New SqlParameter("@nombre", SqlDbType.NVarChar)).Value = present.Descripcion
                    sentencia.Parameters.Add(New SqlParameter("@usuario", SqlDbType.Int)).Value = usuario
                    sentencia.ExecuteNonQuery()

                    trnsccion.Commit()

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub anular(ByRef present As Presentacion,
                          ByVal usuario As String)
        Try
            Using sentencia = New SqlCommand
                sentencia.Connection = FormPrincipal.cnxion
                sentencia.CommandType = CommandType.StoredProcedure
                sentencia.Parameters.Clear()
                sentencia.CommandText = "[PROC_PRESENTACION_ANULAR]"
                sentencia.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.Int)).Value = present.Codigo
                sentencia.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = usuario
                sentencia.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
