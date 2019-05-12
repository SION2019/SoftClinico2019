Imports System.Data.SqlClient
Public Class PedidoServicioDAL
    Public Sub guardar(ByRef objDespachoPedido As DespachoPedidoServicio,
                       ByVal dttemp As DataTable,
                       ByVal usuario As String)
        Try
            Using sentencia = New SqlCommand
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    sentencia.Connection = FormPrincipal.cnxion
                    sentencia.Transaction = trnsccion
                    sentencia.CommandType = CommandType.StoredProcedure

                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "[PROC_DESPACHO_PEDIDO_SERVICIO_CREAR]"
                    sentencia.Parameters.Add(New SqlParameter("@pCodigoPedido", SqlDbType.Int)).Value = objDespachoPedido.codigoPedido
                    sentencia.Parameters.Add(New SqlParameter("@pfechaDespacho", SqlDbType.DateTime)).Value = objDespachoPedido.fechaDespacho
                    sentencia.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = usuario
                    objDespachoPedido.codigoDespacho = CType(sentencia.ExecuteScalar, String)

                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "[PROC_DESPACHO_PEDIDO_SERVICIO_CREAR_D]"
                    sentencia.Parameters.Add(New SqlParameter("@IDCODIGO", SqlDbType.Int)).Value = objDespachoPedido.codigoDespacho
                    sentencia.Parameters.Add(New SqlParameter("@tabla", SqlDbType.Structured)).Value = dttemp
                    sentencia.Parameters.Add(New SqlParameter("@pCodigoPedido", SqlDbType.Int)).Value = objDespachoPedido.codigoPedido
                    sentencia.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = usuario
                    sentencia.Parameters.Add(New SqlParameter("@pExterno", SqlDbType.Int)).Value = objDespachoPedido.externo
                    sentencia.ExecuteNonQuery()


                    trnsccion.Commit()

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub anular(ByRef objDespachoPedido As DespachoPedidoServicio,
                      ByVal usuario As String)
        Try
            Using sentencia = New SqlCommand
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    sentencia.Connection = FormPrincipal.cnxion
                    sentencia.Transaction = trnsccion
                    sentencia.CommandType = CommandType.StoredProcedure

                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "[PROC_DESPACHO_PEDIDO_SERVCIO_ANULAR]"
                    sentencia.Parameters.Add(New SqlParameter("@pCodigo", SqlDbType.Int)).Value = objDespachoPedido.codigoDespacho
                    sentencia.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = usuario
                    sentencia.ExecuteNonQuery()

                    trnsccion.Commit()

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
