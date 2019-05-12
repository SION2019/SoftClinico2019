Imports System.Data.SqlClient
Public Class PedidoComidaDAL
    Public Sub guardar(ByRef objpedidoComida As PedidoComida, ByVal ususario As String)
        Try
            Using sentencia = New SqlCommand
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    sentencia.Connection = FormPrincipal.cnxion
                    sentencia.Transaction = trnsccion
                    sentencia.CommandType = CommandType.StoredProcedure

                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "[PROC_PEDIDO_COMIDA_CREAR]"
                    sentencia.Parameters.Add(New SqlParameter("@pCodigo_proveedor", SqlDbType.Int)).Value = objpedidoComida.codigoProveedor
                    sentencia.Parameters.Add(New SqlParameter("@pAreaServicio", SqlDbType.Int)).Value = objpedidoComida.areaServicio
                    sentencia.Parameters.Add(New SqlParameter("@pTipo_Comida", SqlDbType.Int)).Value = objpedidoComida.tipoComida
                    sentencia.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = ususario
                    sentencia.Parameters.Add(New SqlParameter("@tabla", SqlDbType.Structured)).Value = objpedidoComida.tblComida
                    sentencia.Parameters.Add(New SqlParameter("@fecha", SqlDbType.DateTime)).Value = objpedidoComida.fechaPedido
                    objpedidoComida.codigo = CType(sentencia.ExecuteScalar, String)
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub actualizar(ByRef objpedidoComida As PedidoComida, ByVal ususario As String)
        Try
            Using sentencia = New SqlCommand
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    sentencia.Connection = FormPrincipal.cnxion
                    sentencia.Transaction = trnsccion
                    sentencia.CommandType = CommandType.StoredProcedure
                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "[PROC_PEDIDO_COMIDA_ACTUALIZAR]"
                    sentencia.Parameters.Add(New SqlParameter("@pCodigo", SqlDbType.Int)).Value = objpedidoComida.codigo
                    sentencia.Parameters.Add(New SqlParameter("@pTipo_Comida", SqlDbType.Int)).Value = objpedidoComida.tipoComida
                    sentencia.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = ususario
                    sentencia.Parameters.Add(New SqlParameter("@tabla", SqlDbType.Structured)).Value = objpedidoComida.tblComida
                    sentencia.ExecuteNonQuery()
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub anular(ByRef objpedidoComida As PedidoComida, ByVal ususario As String)
        Try
            Using sentencia = New SqlCommand
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    sentencia.Connection = FormPrincipal.cnxion
                    sentencia.Transaction = trnsccion
                    sentencia.CommandType = CommandType.StoredProcedure

                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "[PROC_PEDIDO_COMIDA_ANULAR]"
                    sentencia.Parameters.Add(New SqlParameter("@pCodigo", SqlDbType.Int)).Value = objpedidoComida.codigo
                    sentencia.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = ususario
                    sentencia.ExecuteNonQuery()
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub anularComida(ByRef objPedidoComida As PedidoComida, ByVal filaActual As Integer, ByVal ususario As String)
        Try
            Using sentencia = New SqlCommand
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    sentencia.Connection = FormPrincipal.cnxion
                    sentencia.Transaction = trnsccion
                    sentencia.CommandType = CommandType.StoredProcedure

                    sentencia.Parameters.Clear()
                    sentencia.CommandText = "[PROC_PEDIDO_COMIDA_ANULAR_COMIDA]"
                    sentencia.Parameters.Add(New SqlParameter("@pCodigo", SqlDbType.Int)).Value = objPedidoComida.codigo
                    sentencia.Parameters.Add(New SqlParameter("@pCodigoOrden", SqlDbType.Int)).Value = objPedidoComida.tblComida.Rows(filaActual).Item("Codigo_orden").ToString
                    sentencia.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = ususario
                    sentencia.ExecuteNonQuery()
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function verificarExixtencia(ByRef objpedidoComida As PedidoComida) As Boolean
        Try
            Using senetncia As New SqlCommand(Consultas.VERIFICAR_EXISTENCIA_PEDIDO_COMIDA & objpedidoComida.tipoComida & "," & objpedidoComida.areaServicio & ",'" & objpedidoComida.fechaPedido.Date & "'", FormPrincipal.cnxion)
                Using lector = senetncia.ExecuteReader
                    If lector.HasRows Then
                        Return True
                    Else
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
