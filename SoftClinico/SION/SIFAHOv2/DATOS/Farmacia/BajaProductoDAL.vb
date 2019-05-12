Imports System.Data.SqlClient
Public Class BajaProductoDAL
    Public Sub guardarBajaProducto(ByRef objBaja As BajaProducto,
                                   ByVal usuario As Integer,
                                   ByVal Punto As Integer)

        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.CommandType = CommandType.StoredProcedure

                    comando.Parameters.Clear()
                    comando.CommandText = "[PROC_BAJA_PRODUCTO_CREAR]"
                    comando.Parameters.Add(New SqlParameter("@PCodigo_EP", SqlDbType.Int)).Value = Punto
                    comando.Parameters.Add(New SqlParameter("@PCodigo_Bodega", SqlDbType.Int)).Value = objBaja.codigoBodega
                    comando.Parameters.Add(New SqlParameter("@PCodigo_Motivo", SqlDbType.Int)).Value = objBaja.motivo
                    comando.Parameters.Add(New SqlParameter("@PUsuario_Creacion", SqlDbType.Int)).Value = usuario
                    objBaja.codigoBaja = CStr(comando.ExecuteScalar)



                    For i = 0 To objBaja.tblProductos.Rows.Count - 1
                        comando.Parameters.Clear()
                        comando.CommandText = "[PROC_BAJA_PRODUCTO_CREAR_DETALLE]"
                        comando.Parameters.Add(New SqlParameter("@PIDCODIGO", SqlDbType.Int)).Value = objBaja.codigoBaja
                        comando.Parameters.Add(New SqlParameter("@PReg_lote", SqlDbType.Int)).Value = objBaja.tblProductos.Rows(i).Item("Reg_Lote")
                        comando.Parameters.Add(New SqlParameter("@PStock", SqlDbType.Int)).Value = objBaja.tblProductos.Rows(i).Item("Stock")
                        comando.Parameters.Add(New SqlParameter("@PCant_Sale", SqlDbType.Int)).Value = objBaja.tblProductos.Rows(i).Item("Cantidad")
                        comando.Parameters.Add(New SqlParameter("@PCosto_Unitario", SqlDbType.Int)).Value = objBaja.tblProductos.Rows(i).Item("Costo")
                        comando.ExecuteNonQuery()


                        comando.Parameters.Clear()
                        comando.CommandText = "[PROC_LOTES_DESCONTAR_STOCK]"
                        comando.Parameters.Add(New SqlParameter("@pCantidad", SqlDbType.Int)).Value = objBaja.tblProductos.Rows(i).Item("Cantidad")
                        comando.Parameters.Add(New SqlParameter("@pCodigo_producto", SqlDbType.Int)).Value = objBaja.tblProductos.Rows(i).Item("Codigo_Producto")
                        comando.Parameters.Add(New SqlParameter("@pCodigo_Bodega", SqlDbType.Int)).Value = objBaja.codigoBodega
                        comando.Parameters.Add(New SqlParameter("@pReg_lote", SqlDbType.Int)).Value = objBaja.tblProductos.Rows(i).Item("Reg_Lote")
                        comando.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = usuario
                        comando.ExecuteNonQuery()

                        comando.Parameters.Clear()
                        comando.CommandText = "[PROC_LOTES_KARDEX_CREAR]"
                        comando.Parameters.Add(New SqlParameter("@Codigo_Bodega", SqlDbType.Int)).Value = objBaja.codigoBodega
                        comando.Parameters.Add(New SqlParameter("@Codigo_Producto", SqlDbType.Int)).Value = objBaja.tblProductos.Rows(i).Item("Codigo_Producto")
                        comando.Parameters.Add(New SqlParameter("@Reg_lote", SqlDbType.Int)).Value = objBaja.tblProductos.Rows(i).Item("Reg_Lote")
                        comando.Parameters.Add(New SqlParameter("@Cant_Entrada", SqlDbType.Int)).Value = 0
                        comando.Parameters.Add(New SqlParameter("@Cant_Salida", SqlDbType.Int)).Value = objBaja.tblProductos.Rows(i).Item("Cantidad")
                        comando.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.Int)).Value = SesionActual.idUsuario
                        comando.Parameters.Add(New SqlParameter("@Origen", SqlDbType.NVarChar)).Value = "B"
                        comando.Parameters.Add(New SqlParameter("@Codigo_movimiento", SqlDbType.Int)).Value = objBaja.codigoBodega
                        comando.ExecuteNonQuery()
                    Next

                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub anuularBajaProdcuto(ByRef objBaja As BajaProducto,
                                   ByVal usuario As Integer)
        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.CommandType = CommandType.StoredProcedure

                    comando.Parameters.Clear()
                    comando.CommandText = "[PROC_BAJA_PRODUCTO_ANULAR]"
                    comando.Parameters.Add(New SqlParameter("@pCodigo", SqlDbType.Int)).Value = objBaja.codigoBaja
                    comando.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = SesionActual.codigoEP
                    comando.ExecuteNonQuery()

                    For i = 0 To objBaja.tblProductos.Rows.Count - 1
                        comando.Parameters.Clear()
                        comando.CommandText = "[PROC_LOTES_AUMENTAR_STOCK]"
                        comando.Parameters.Add(New SqlParameter("@pCantidad", SqlDbType.Int)).Value = objBaja.tblProductos.Rows(i).Item("Cantidad")
                        comando.Parameters.Add(New SqlParameter("@pCodigo_producto", SqlDbType.Int)).Value = objBaja.tblProductos.Rows(i).Item("Codigo_Producto")
                        comando.Parameters.Add(New SqlParameter("@pCodigo_Bodega", SqlDbType.Int)).Value = objBaja.codigoBodega
                        comando.Parameters.Add(New SqlParameter("@pReg_lote", SqlDbType.Int)).Value = objBaja.tblProductos.Rows(i).Item("Reg_lote")
                        comando.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = usuario
                        comando.ExecuteNonQuery()
                    Next
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
