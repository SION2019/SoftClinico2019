Imports System.Data.SqlClient
Public Class CuentaCobroDAL
    Public Sub guardarCompra(ByRef objCuentaCobro As CuentaCobro,
                             ByVal usuario As Integer)
        Try

            Using sentencia = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    sentencia.Connection = FormPrincipal.cnxion
                    sentencia.Transaction = trnsccion
                    sentencia.CommandType = CommandType.StoredProcedure

                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "[PROC_CUENTA_COBRO_CREAR]"
                    sentencia.Parameters.Add(New SqlParameter("@pCodigoOrdenCompra", SqlDbType.Int)).Value = objCuentaCobro.codigoOrden
                    sentencia.Parameters.Add(New SqlParameter("@pConsecutivo", SqlDbType.Int)).Value = objCuentaCobro.consecutivoInterno
                    sentencia.Parameters.Add(New SqlParameter("@pFechaCuentaCobro", SqlDbType.DateTime)).Value = objCuentaCobro.fechaCuentaCobro
                    sentencia.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.NVarChar)).Value = usuario
                    sentencia.Parameters.Add(New SqlParameter("@pTabla", SqlDbType.Structured)).Value = objCuentaCobro.tablaCuentaCobro
                    objCuentaCobro.codigoCuentaCobro = CType(sentencia.ExecuteScalar, String)

                    Try
                        trnsccion.Commit()
                    Catch ex As Exception
                        trnsccion.Rollback()
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub actualizarCompra(ByRef objCuentaCobro As CuentaCobro,
                                ByVal usuario As Integer)
        Try

            Using sentencia = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    sentencia.Connection = FormPrincipal.cnxion
                    sentencia.Transaction = trnsccion
                    sentencia.CommandType = CommandType.StoredProcedure

                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "[PROC_CUENTA_COBRO_ACTUALIZAR]"
                    sentencia.Parameters.Add(New SqlParameter("@pCodigo", SqlDbType.Int)).Value = objCuentaCobro.codigoCuentaCobro
                    sentencia.Parameters.Add(New SqlParameter("@pFechaCuentaCobro", SqlDbType.DateTime)).Value = objCuentaCobro.fechaCuentaCobro
                    sentencia.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.NVarChar)).Value = usuario
                    sentencia.Parameters.Add(New SqlParameter("@pTabla", SqlDbType.Structured)).Value = objCuentaCobro.tablaCuentaCobro
                    sentencia.ExecuteNonQuery()

                    Try
                        trnsccion.Commit()
                    Catch ex As Exception
                        trnsccion.Rollback()
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub anularCuentaCobro(ByRef objCuentaCobro As CuentaCobro,
                                 ByVal usuario As Integer)
        Try
            Using consulta = New SqlCommand()
                consulta.Connection = FormPrincipal.cnxion
                consulta.CommandType = CommandType.StoredProcedure
                consulta.Parameters.Clear()

                consulta.CommandText = "[PROC_CUENTA_COBRO_ANULAR]"
                consulta.Parameters.Add(New SqlParameter("@codigo", SqlDbType.Int)).Value = objCuentaCobro.codigoCuentaCobro
                consulta.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = usuario
                consulta.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
