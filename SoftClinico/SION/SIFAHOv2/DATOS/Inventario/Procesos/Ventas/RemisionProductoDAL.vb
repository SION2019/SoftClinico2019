Imports System.Data.SqlClient

Public Class RemisionProductoDAL
    Public Sub guardar(obj As RemisionProducto)
        Try
            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_REMISION_INV_CREAR]"
                    consulta.Parameters.Add(New SqlParameter("@pCliente", SqlDbType.Int)).Value = obj.codigoCliente
                    consulta.Parameters.Add(New SqlParameter("@pCodigo_EP", SqlDbType.Int)).Value = SesionActual.codigoEP
                    consulta.Parameters.Add(New SqlParameter("@pCotizacion", SqlDbType.NVarChar)).Value = obj.codigoCotizacion
                    consulta.Parameters.Add(New SqlParameter("@pFecha", SqlDbType.DateTime)).Value = obj.fechaRemision
                    consulta.Parameters.Add(New SqlParameter("@pObservacion", SqlDbType.NVarChar)).Value = obj.observacionRemision
                    consulta.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = SesionActual.idUsuario
                    consulta.Parameters.Add(New SqlParameter("@pCodigoContrato", SqlDbType.Int)).Value = obj.codigoContrato

                    obj.codigoRemision = CType(consulta.ExecuteScalar, String)


                    For indiceFila = 0 To obj.tblMedicamentos.Rows.Count - 2

                        obj.nombreTabla = Constantes.MEDICAMENTO & obj.tblMedicamentos.Rows(indiceFila).Item("Codigo") & indiceFila

                        If obj.tblLotesMedIns.Tables.Contains(obj.nombreTabla) Then
                            For indiceSubTabla = 0 To obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows.Count - 1
                                consulta.Parameters.Clear()
                                consulta.CommandText = "[PROC_REMISION_INV_CREAR_DETALLE]"
                                consulta.Parameters.Add(New SqlParameter("@pCodigo_Remision", SqlDbType.Int)).Value = obj.codigoRemision
                                consulta.Parameters.Add(New SqlParameter("@pCodigo_Producto", SqlDbType.Int)).Value = obj.tblMedicamentos.Rows(indiceFila).Item("Codigo")
                                consulta.Parameters.Add(New SqlParameter("@pCodigo_Bodega", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Bodega")
                                consulta.Parameters.Add(New SqlParameter("@pReg_lote", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Reg_lote")
                                consulta.Parameters.Add(New SqlParameter("@pStock", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Stock")
                                consulta.Parameters.Add(New SqlParameter("@pCant", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Cantidad")
                                consulta.Parameters.Add(New SqlParameter("@pPrecio", SqlDbType.Float)).Value = obj.tblMedicamentos.Rows(indiceFila).Item("Precio")
                                consulta.Parameters.Add(New SqlParameter("@tipo", SqlDbType.Int)).Value = Constantes.MEDICAMENTO
                                consulta.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = SesionActual.idUsuario
                                consulta.ExecuteNonQuery()


                                consulta.Parameters.Clear()
                                consulta.CommandText = "[PROC_LOTES_DESCONTAR_STOCK]"
                                consulta.Parameters.Add(New SqlParameter("@pCantidad", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Cantidad")
                                consulta.Parameters.Add(New SqlParameter("@pCodigo_producto", SqlDbType.Int)).Value = obj.tblMedicamentos.Rows(indiceFila).Item("Codigo")
                                consulta.Parameters.Add(New SqlParameter("@pCodigo_Bodega", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Bodega")
                                consulta.Parameters.Add(New SqlParameter("@pReg_lote", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Reg_lote")
                                consulta.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = SesionActual.idUsuario
                                consulta.ExecuteNonQuery()

                                consulta.Parameters.Clear()
                                consulta.CommandText = "[PROC_LOTES_KARDEX_CREAR]"
                                consulta.Parameters.Add(New SqlParameter("@Codigo_Bodega", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Bodega")
                                consulta.Parameters.Add(New SqlParameter("@Codigo_Producto", SqlDbType.Int)).Value = obj.tblMedicamentos.Rows(indiceFila).Item("Codigo")
                                consulta.Parameters.Add(New SqlParameter("@Reg_lote", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Reg_lote")
                                consulta.Parameters.Add(New SqlParameter("@Cant_Entrada", SqlDbType.Int)).Value = 0
                                consulta.Parameters.Add(New SqlParameter("@Cant_Salida", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Cantidad")
                                consulta.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.NVarChar)).Value = SesionActual.idUsuario
                                consulta.Parameters.Add(New SqlParameter("@Origen", SqlDbType.NVarChar)).Value = "V"
                                consulta.Parameters.Add(New SqlParameter("@Codigo_movimiento", SqlDbType.Int)).Value = obj.codigoRemision
                                consulta.ExecuteNonQuery()
                            Next
                        End If
                    Next

                    For indiceFila = 0 To obj.tblInsumos.Rows.Count - 2

                        obj.nombreTabla = Constantes.INSUMO & obj.tblInsumos.Rows(indiceFila).Item("CodigoI") & indiceFila

                        If obj.tblLotesMedIns.Tables.Contains(obj.nombreTabla) Then
                            For indiceSubTabla = 0 To obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows.Count - 1
                                If obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Cantidad") > 0 Then

                                    consulta.Parameters.Clear()
                                    consulta.CommandText = "[PROC_REMISION_INV_CREAR_DETALLE]"
                                    consulta.Parameters.Add(New SqlParameter("@pCodigo_Remision", SqlDbType.Int)).Value = obj.codigoRemision
                                    consulta.Parameters.Add(New SqlParameter("@pCodigo_Producto", SqlDbType.Int)).Value = obj.tblInsumos.Rows(indiceFila).Item("CodigoI")
                                    consulta.Parameters.Add(New SqlParameter("@pCodigo_Bodega", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Bodega")
                                    consulta.Parameters.Add(New SqlParameter("@pReg_lote", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Reg_lote")
                                    consulta.Parameters.Add(New SqlParameter("@pStock", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Stock")
                                    consulta.Parameters.Add(New SqlParameter("@pCant", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Cantidad")
                                    consulta.Parameters.Add(New SqlParameter("@pPrecio", SqlDbType.Float)).Value = obj.tblInsumos.Rows(indiceFila).Item("PrecioI")
                                    consulta.Parameters.Add(New SqlParameter("@tipo", SqlDbType.Int)).Value = Constantes.INSUMO
                                    consulta.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = SesionActual.idUsuario
                                    consulta.ExecuteNonQuery()

                                    consulta.Parameters.Clear()
                                    consulta.CommandText = "[PROC_LOTES_DESCONTAR_STOCK]"
                                    consulta.Parameters.Add(New SqlParameter("@pCantidad", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Cantidad")
                                    consulta.Parameters.Add(New SqlParameter("@pCodigo_producto", SqlDbType.Int)).Value = obj.tblInsumos.Rows(indiceFila).Item("CodigoI")
                                    consulta.Parameters.Add(New SqlParameter("@pCodigo_Bodega", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Bodega")
                                    consulta.Parameters.Add(New SqlParameter("@pReg_lote", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Reg_lote")
                                    consulta.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = SesionActual.idUsuario
                                    consulta.ExecuteNonQuery()

                                    consulta.Parameters.Clear()
                                    consulta.CommandText = "[PROC_LOTES_KARDEX_CREAR]"
                                    consulta.Parameters.Add(New SqlParameter("@Codigo_Bodega", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Bodega")
                                    consulta.Parameters.Add(New SqlParameter("@Codigo_Producto", SqlDbType.Int)).Value = obj.tblInsumos.Rows(indiceFila).Item("CodigoI")
                                    consulta.Parameters.Add(New SqlParameter("@Reg_lote", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Reg_lote")
                                    consulta.Parameters.Add(New SqlParameter("@Cant_Entrada", SqlDbType.Int)).Value = 0
                                    consulta.Parameters.Add(New SqlParameter("@Cant_Salida", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Cantidad")
                                    consulta.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.NVarChar)).Value = SesionActual.idUsuario
                                    consulta.Parameters.Add(New SqlParameter("@Origen", SqlDbType.NVarChar)).Value = "V"
                                    consulta.Parameters.Add(New SqlParameter("@Codigo_movimiento", SqlDbType.Int)).Value = obj.codigoRemision
                                    consulta.ExecuteNonQuery()

                                End If
                            Next
                        End If
                    Next


                    For indiceFila = 0 To obj.tblProcedimientos.Rows.Count - 2
                        consulta.Parameters.Clear()
                        consulta.CommandText = "[PROC_REMISION_INV_CREAR_DETALLE_PROCEDIMIENTOS]"
                        consulta.Parameters.Add(New SqlParameter("@Codigo_Remision", SqlDbType.Int)).Value = obj.codigoRemision
                        consulta.Parameters.Add(New SqlParameter("@Codigo_procedimiento", SqlDbType.NVarChar)).Value = obj.tblProcedimientos.Rows(indiceFila).Item("CodigoPro")
                        consulta.Parameters.Add(New SqlParameter("@Cant", SqlDbType.Int)).Value = obj.tblProcedimientos.Rows(indiceFila).Item("CantidadPro")
                        consulta.Parameters.Add(New SqlParameter("@Precio", SqlDbType.Int)).Value = obj.tblProcedimientos.Rows(indiceFila).Item("PrecioPro")
                        consulta.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = SesionActual.idUsuario
                        consulta.ExecuteNonQuery()
                    Next

                    If Not IsNothing(obj.codigoCliente) Then
                        consulta.Parameters.Clear()
                        consulta.CommandText = "[PROC_REMISION_INV_ACTUALIZAR_ESTADO]"
                        consulta.Parameters.Add(New SqlParameter("@pRemision", SqlDbType.Int)).Value = obj.codigoRemision
                        consulta.Parameters.Add(New SqlParameter("@pCotizacion", SqlDbType.NVarChar)).Value = obj.codigoCotizacion
                        consulta.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = SesionActual.idUsuario
                        consulta.Parameters.Add(New SqlParameter("@estado", SqlDbType.Int)).Value = Constantes.TERMINADO
                        consulta.ExecuteNonQuery()
                    End If


                    Try
                        trnsccion.Commit()
                    Catch ex As Exception
                        trnsccion.Rollback()
                        Throw ex
                    End Try

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub anular(obj As RemisionProducto)
        Try
            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_REMISION_INV_ANULAR]"
                    consulta.Parameters.Add(New SqlParameter("@pCodigo", SqlDbType.Int)).Value = obj.codigoRemision
                    consulta.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = SesionActual.idUsuario
                    consulta.ExecuteNonQuery()




                    For indiceFila = 0 To obj.tblMedicamentos.Rows.Count - 1
                        obj.nombreTabla = Constantes.MEDICAMENTO & obj.tblMedicamentos.Rows(indiceFila).Item("Codigo") & indiceFila
                        If obj.tblLotesMedIns.Tables.Contains(obj.nombreTabla) Then
                            For indiceSubTabla = 0 To obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows.Count - 1

                                consulta.Parameters.Clear()
                                consulta.CommandText = "[PROC_LOTES_KARDEX_CREAR]"
                                consulta.Parameters.Add(New SqlParameter("@Codigo_Bodega", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Bodega")
                                consulta.Parameters.Add(New SqlParameter("@Codigo_Producto", SqlDbType.Int)).Value = obj.tblMedicamentos.Rows(indiceFila).Item("Codigo")
                                consulta.Parameters.Add(New SqlParameter("@Reg_lote", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Reg_lote")
                                consulta.Parameters.Add(New SqlParameter("@Cant_Entrada", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Cantidad")
                                consulta.Parameters.Add(New SqlParameter("@Cant_Salida", SqlDbType.Int)).Value = 0
                                consulta.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.NVarChar)).Value = SesionActual.idUsuario
                                consulta.Parameters.Add(New SqlParameter("@Origen", SqlDbType.NVarChar)).Value = "V"
                                consulta.Parameters.Add(New SqlParameter("@Codigo_movimiento", SqlDbType.Int)).Value = obj.codigoRemision
                                consulta.ExecuteNonQuery()

                                consulta.Parameters.Clear()
                                consulta.CommandText = "[PROC_LOTES_AUMENTAR_STOCK]"
                                consulta.Parameters.Add(New SqlParameter("@pCantidad", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Cantidad")
                                consulta.Parameters.Add(New SqlParameter("@pCodigo_producto", SqlDbType.Int)).Value = obj.tblMedicamentos.Rows(indiceFila).Item("Codigo")
                                consulta.Parameters.Add(New SqlParameter("@pCodigo_Bodega", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Bodega")
                                consulta.Parameters.Add(New SqlParameter("@pReg_lote", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Reg_lote")
                                consulta.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = SesionActual.idUsuario
                                consulta.ExecuteNonQuery()
                            Next
                        End If
                    Next


                    For indiceFila = 0 To obj.tblInsumos.Rows.Count - 1

                        obj.nombreTabla = Constantes.INSUMO & obj.tblInsumos.Rows(indiceFila).Item("CodigoI") & indiceFila

                        If obj.tblLotesMedIns.Tables.Contains(obj.nombreTabla) Then
                            For indiceSubTabla = 0 To obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows.Count - 1
                                If obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Cantidad") > 0 Then

                                    consulta.Parameters.Clear()
                                    consulta.CommandText = "[PROC_LOTES_KARDEX_CREAR]"
                                    consulta.Parameters.Add(New SqlParameter("@Codigo_Bodega", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Bodega")
                                    consulta.Parameters.Add(New SqlParameter("@Codigo_Producto", SqlDbType.Int)).Value = obj.tblInsumos.Rows(indiceFila).Item("CodigoI")
                                    consulta.Parameters.Add(New SqlParameter("@Reg_lote", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Reg_lote")
                                    consulta.Parameters.Add(New SqlParameter("@Cant_Entrada", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Cantidad")
                                    consulta.Parameters.Add(New SqlParameter("@Cant_Salida", SqlDbType.Int)).Value = 0
                                    consulta.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.NVarChar)).Value = SesionActual.idUsuario
                                    consulta.Parameters.Add(New SqlParameter("@Origen", SqlDbType.NVarChar)).Value = "V"
                                    consulta.Parameters.Add(New SqlParameter("@Codigo_movimiento", SqlDbType.Int)).Value = obj.codigoRemision
                                    consulta.ExecuteNonQuery()

                                    consulta.Parameters.Clear()
                                    consulta.CommandText = "[PROC_LOTES_AUMENTAR_STOCK]"
                                    consulta.Parameters.Add(New SqlParameter("@pCantidad", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Cantidad")
                                    consulta.Parameters.Add(New SqlParameter("@pCodigo_producto", SqlDbType.Int)).Value = obj.tblInsumos.Rows(indiceFila).Item("CodigoI")
                                    consulta.Parameters.Add(New SqlParameter("@pCodigo_Bodega", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Bodega")
                                    consulta.Parameters.Add(New SqlParameter("@pReg_lote", SqlDbType.Int)).Value = obj.tblLotesMedIns.Tables(obj.nombreTabla).Rows(indiceSubTabla).Item("Reg_lote")
                                    consulta.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = SesionActual.idUsuario
                                    consulta.ExecuteNonQuery()
                                End If
                            Next
                        End If
                    Next

                    If Not IsNothing(obj.codigoCliente) Then
                        consulta.Parameters.Clear()
                        consulta.CommandText = "[PROC_REMISION_INV_ACTUALIZAR_ESTADO]"
                        consulta.Parameters.Add(New SqlParameter("@pRemision", SqlDbType.Int)).Value = obj.codigoRemision
                        consulta.Parameters.Add(New SqlParameter("@pCotizacion", SqlDbType.NVarChar)).Value = obj.codigoCotizacion
                        consulta.Parameters.Add(New SqlParameter("@pUsuario", SqlDbType.Int)).Value = SesionActual.idUsuario
                        consulta.Parameters.Add(New SqlParameter("@estado", SqlDbType.Int)).Value = Constantes.PENDIENTE
                        consulta.ExecuteNonQuery()
                    End If

                    Try
                        trnsccion.Commit()
                    Catch ex As Exception
                        trnsccion.Rollback()
                        Throw ex
                    End Try

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
