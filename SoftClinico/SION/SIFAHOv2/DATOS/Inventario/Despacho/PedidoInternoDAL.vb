Imports System.Data.SqlClient
Public Class PedidoInternoDAL
    Sub definirGuardado(ByRef objPedido As PedidoInterno, ByVal usuario As Integer, ByVal codigoPunto As Integer)
        If objPedido.codigoPedidoPunto = "" Then
            guardarPedido(objPedido, usuario, codigoPunto)
        Else
            actualizarPedido(objPedido, usuario, codigoPunto)
        End If
    End Sub
    Public Function verificarExistenciaPedidoInterno(ByRef objPedido As PedidoInterno) As Boolean
        Using consulta As New SqlCommand("[PROC_PEDIDO_VERIFICACION] '" & objPedido.codigoPedido & "'", FormPrincipal.cnxion)
            Using lector = consulta.ExecuteReader
                If lector.HasRows Then
                    Return True
                Else
                    Return False
                End If
            End Using
        End Using

    End Function
    Public Sub actualizarPedido(ByRef objPedido As PedidoInterno, ByVal usuario As Integer, ByVal codigoPunto As Integer)
        Try
            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure


                    Dim tablaProductos As New DataTable
                    tablaProductos = objPedido.tblProductos.Copy
                    quitarColumna(tablaProductos)

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_PEDIDO_ACTUALIZAR]"
                    consulta.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.Int)).Value = objPedido.codigoPedido
                    consulta.Parameters.Add(New SqlParameter("@Codigo_Bodega_Origen", SqlDbType.Int)).Value = objPedido.codigoBodegaSolicitante
                    consulta.Parameters.Add(New SqlParameter("@Codigo_Bodega_Destino", SqlDbType.Int)).Value = objPedido.codigoBodegaSolicitada
                    consulta.Parameters.Add(New SqlParameter("@usuario_actualizacion", SqlDbType.NVarChar)).Value = usuario
                    consulta.Parameters.Add(New SqlParameter("@Fecha_Pedido", SqlDbType.DateTime)).Value = objPedido.fechaPedido
                    consulta.Parameters.Add(New SqlParameter("@esExterno", SqlDbType.Bit)).Value = objPedido.esExterno
                    consulta.ExecuteNonQuery()

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_PEDIDO_CREAR_DETALLE]"
                    consulta.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.Int)).Value = objPedido.codigoPedido
                    consulta.Parameters.Add(New SqlParameter("@TBL", SqlDbType.Structured)).Value = tablaProductos
                    consulta.ExecuteNonQuery()

                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub guardarPedido(ByRef objPedido As PedidoInterno, ByVal usuario As Integer, ByVal codigoPunto As Integer)
        Try
            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure

                    Dim tablaProductos As New DataTable
                    tablaProductos = objPedido.tblProductos.Copy
                    quitarColumna(tablaProductos)

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_PEDIDO_CREAR]"
                    consulta.Parameters.Add(New SqlParameter("@Codigo_EP", SqlDbType.NVarChar)).Value = codigoPunto
                    consulta.Parameters.Add(New SqlParameter("@Codigo_Bodega_Origen", SqlDbType.Int)).Value = objPedido.codigoBodegaSolicitante
                    consulta.Parameters.Add(New SqlParameter("@Codigo_Bodega_Destino", SqlDbType.Int)).Value = objPedido.codigoBodegaSolicitada
                    consulta.Parameters.Add(New SqlParameter("@usuario_cracion", SqlDbType.NVarChar)).Value = usuario
                    consulta.Parameters.Add(New SqlParameter("@Fecha_Pedido", SqlDbType.DateTime)).Value = objPedido.fechaPedido
                    consulta.Parameters.Add(New SqlParameter("@esExterno", SqlDbType.Bit)).Value = objPedido.esExterno
                    objPedido.codigoPedido = CType(consulta.ExecuteScalar, String)

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_PEDIDO_CREAR_DETALLE]"
                    consulta.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.Int)).Value = objPedido.codigoPedido
                    consulta.Parameters.Add(New SqlParameter("@TBL", SqlDbType.Structured)).Value = tablaProductos
                    consulta.ExecuteNonQuery()


                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_PEDIDO_INTERNO_ACTUALIZAR_CONSECUTIVO_PUNTO]"
                    consulta.Parameters.Add(New SqlParameter("@pCodigo_EP", SqlDbType.Int)).Value = codigoPunto
                    consulta.Parameters.Add(New SqlParameter("@pTipo", SqlDbType.Int)).Value = Constantes.CONSECUTIVO_PEDIDO_INTERNO
                    consulta.Parameters.Add(New SqlParameter("@CodigoOrdenInterno", SqlDbType.Int)).Value = objPedido.codigoPedido
                    objPedido.codigoPedidoPunto = CType(consulta.ExecuteScalar, String)


                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub quitarColumna(ByRef tablaProductos As DataTable)
        If tablaProductos.Columns.Contains("Stock Solicitante") Then
            tablaProductos.Columns.Remove("Stock Solicitante")
        End If
    End Sub
    Public Sub AnularPedido(ByRef objPedido As PedidoInterno, ByVal usuario As Integer)
        Try
            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure
                    consulta.Parameters.Clear()

                    consulta.CommandText = "[PROC_PEDIDO_ANULAR]"
                    consulta.Parameters.Add(New SqlParameter("@codigo", SqlDbType.Int))
                    consulta.Parameters("@codigo").Value = objPedido.codigoPedido
                    consulta.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.NVarChar))
                    consulta.Parameters("@Usuario").Value = usuario
                    consulta.ExecuteNonQuery()
                    trnsccion.Commit()

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
