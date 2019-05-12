Imports System.Data.SqlClient
Public Class ConteoDAL
    Public Sub verificarTipoGuardado(ByVal objConteo As Conteo, ByVal usuario As Integer)
        If objConteo.codigoConteo = "" Then
            guardarConteoAuxiliar(objConteo, usuario)
        Else
            actualizarConteoAuxiliar(objConteo, usuario)
        End If
    End Sub
    Public Sub guardarConteoAuxiliar(ByVal objConteo As Conteo, ByVal usuario As Integer)
        Try

            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure
                    consulta.Parameters.Clear()

                    ' Se inserta el encabezado del conteo auxiliar
                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_CONTEO_AUXILIAR_CREAR]"
                    consulta.Parameters.Add(New SqlParameter("@pCodigo_Bodega", SqlDbType.Int)).Value = objConteo.codigoBodega
                    consulta.Parameters.Add(New SqlParameter("@pObservaciones", SqlDbType.NVarChar)).Value = objConteo.observacion
                    consulta.Parameters.Add(New SqlParameter("@pFecha", SqlDbType.DateTime)).Value = objConteo.fechaConteo
                    consulta.Parameters.Add(New SqlParameter("@pUsuario_Creacion", SqlDbType.NVarChar)).Value = usuario
                    objConteo.codigoConteo = CType(consulta.ExecuteScalar, String)

                    ' Se inserta el detalle del conteo auxiliar
                    Dim nombreTabla As String = ""
                    Dim lotes As DataTableCollection = objConteo.tblLotes.Tables
                    For indiceProducto = 0 To objConteo.tblProductos.Rows.Count - 1
                        nombreTabla = objConteo.nombrarTabla(objConteo.tblProductos.Rows(indiceProducto).Item("Codigo"))
                        If objConteo.verificarExistenciaTabla(nombreTabla) Then
                            For indiceLote = 0 To lotes(nombreTabla).Rows.Count - 1
                                If lotes(nombreTabla).Rows(indiceLote).Item("LoteNum") <> "" Then
                                    consulta.Parameters.Clear()
                                    consulta.CommandText = "[PROC_CONTEO_AUXILIAR_CREAR_DETALLE]"
                                    consulta.Parameters.Add(New SqlParameter("@pCodigo_Conteo", SqlDbType.Int)).Value = objConteo.codigoConteo
                                    consulta.Parameters.Add(New SqlParameter("@codigo_Producto", SqlDbType.Int)).Value = objConteo.tblProductos.Rows(indiceProducto).Item("Codigo")
                                    consulta.Parameters.Add(New SqlParameter("@pReg_Lote", SqlDbType.NVarChar)).Value = lotes(nombreTabla).Rows(indiceLote).Item("Reg_lote").ToString
                                    consulta.Parameters.Add(New SqlParameter("@pNumero_Lote", SqlDbType.NVarChar)).Value = lotes(nombreTabla).Rows(indiceLote).Item("LoteNum").ToString
                                    consulta.Parameters.Add(New SqlParameter("@pFechaVence", SqlDbType.DateTime)).Value = lotes(nombreTabla).Rows(indiceLote).Item("FechaVence")
                                    consulta.Parameters.Add(New SqlParameter("@pStock", SqlDbType.Int)).Value = lotes(nombreTabla).Rows(indiceLote).Item("StockLote")
                                    consulta.Parameters.Add(New SqlParameter("@pConteo", SqlDbType.Int)).Value = lotes(nombreTabla).Rows(indiceLote).Item("ConteoLote")
                                    consulta.Parameters.Add(New SqlParameter("@pCosto", SqlDbType.Float)).Value = lotes(nombreTabla).Rows(indiceLote).Item("Costo")
                                    consulta.Parameters.Add(New SqlParameter("@exep", SqlDbType.Bit)).Value = lotes(nombreTabla).Rows(indiceLote).Item("Excepcion")
                                    consulta.ExecuteNonQuery()
                                    If lotes(nombreTabla).Rows(indiceLote).Item("Reg_lote").ToString = "" Then
                                        consulta.Parameters.Clear()
                                        consulta.CommandText = "[PROC_CONTEO_AUXILIAR_CREAR_DETALLE_NUEVO_LOTE]"
                                        consulta.Parameters.Add(New SqlParameter("@codigoConteo", SqlDbType.Int)).Value = objConteo.codigoConteo
                                        consulta.Parameters.Add(New SqlParameter("@codigoProducto", SqlDbType.Int)).Value = objConteo.tblProductos.Rows(indiceProducto).Item("Codigo")
                                        consulta.Parameters.Add(New SqlParameter("@RegLote", SqlDbType.NVarChar)).Value = lotes(nombreTabla).Rows(indiceLote).Item("Reg_lote").ToString
                                        consulta.Parameters.Add(New SqlParameter("@NumeroLote", SqlDbType.NVarChar)).Value = lotes(nombreTabla).Rows(indiceLote).Item("LoteNum").ToString
                                        consulta.Parameters.Add(New SqlParameter("@FechaVence", SqlDbType.DateTime)).Value = lotes(nombreTabla).Rows(indiceLote).Item("FechaVence")
                                        consulta.Parameters.Add(New SqlParameter("@Conteo", SqlDbType.Int)).Value = lotes(nombreTabla).Rows(indiceLote).Item("ConteoLote")
                                        consulta.Parameters.Add(New SqlParameter("@Costo", SqlDbType.Float)).Value = lotes(nombreTabla).Rows(indiceLote).Item("Costo")
                                        consulta.Parameters.Add(New SqlParameter("@exep", SqlDbType.Bit)).Value = lotes(nombreTabla).Rows(indiceLote).Item("Excepcion")
                                        consulta.ExecuteNonQuery()
                                    End If
                                End If
                            Next
                        End If
                    Next
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub actualizarConteoAuxiliar(ByVal objConteo As Conteo, ByVal usuario As Integer)
        Try

            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure
                    consulta.Parameters.Clear()

                    ' Se actualiza el encabezado del conteo auxiliar

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_CONTEO_AUXILIAR_MODIFICAR]"
                    consulta.Parameters.Add(New SqlParameter("@pCodigo", SqlDbType.Int)).Value = objConteo.codigoBodega
                    consulta.Parameters.Add(New SqlParameter("@pCodigo_Bodega", SqlDbType.Int)).Value = objConteo.codigoBodega
                    consulta.Parameters.Add(New SqlParameter("@pObservaciones", SqlDbType.NVarChar)).Value = objConteo.observacion
                    consulta.Parameters.Add(New SqlParameter("@pFecha", SqlDbType.DateTime)).Value = objConteo.fechaConteo
                    consulta.Parameters.Add(New SqlParameter("@pUsuario_Creacion", SqlDbType.Int)).Value = usuario
                    consulta.ExecuteNonQuery()

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_CONTEO_AUXILIAR_ELIMINAR_DETALLE]"
                    consulta.Parameters.Add(New SqlParameter("@pCodigo_Conteo", SqlDbType.Int)).Value = objConteo.codigoConteo
                    consulta.ExecuteNonQuery()
                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_CONTEO_AUXILIAR_ELIMINAR_DETALLE_LOTES_NUEVOS]"
                    consulta.Parameters.Add(New SqlParameter("@pCodigo_Conteo", SqlDbType.Int)).Value = objConteo.codigoConteo
                    consulta.ExecuteNonQuery()


                    ' Se actualiza el detalle del conteo auxiliar
                    Dim nombreTabla As String = ""
                    Dim lotes As DataTableCollection = objConteo.tblLotes.Tables
                    For indiceProducto = 0 To objConteo.tblProductos.Rows.Count - 1
                        nombreTabla = objConteo.nombrarTabla(objConteo.tblProductos.Rows(indiceProducto).Item("Codigo"))
                        If objConteo.verificarExistenciaTabla(nombreTabla) And objConteo.tblProductos.Rows(indiceProducto).Item("Conteo").ToString >= 0 Then
                            For indiceLote = 0 To lotes(nombreTabla).Rows.Count - 1
                                If lotes(nombreTabla).Rows(indiceLote).Item("LoteNum").ToString <> "" Then
                                    consulta.Parameters.Clear()
                                    consulta.CommandText = "[PROC_CONTEO_AUXILIAR_CREAR_DETALLE]"
                                    consulta.Parameters.Add(New SqlParameter("@pCodigo_Conteo", SqlDbType.Int)).Value = objConteo.codigoConteo
                                    consulta.Parameters.Add(New SqlParameter("@codigo_Producto", SqlDbType.Int)).Value = objConteo.tblProductos.Rows(indiceProducto).Item("Codigo")
                                    consulta.Parameters.Add(New SqlParameter("@pReg_Lote", SqlDbType.NVarChar)).Value = lotes(nombreTabla).Rows(indiceLote).Item("Reg_lote").ToString
                                    consulta.Parameters.Add(New SqlParameter("@pNumero_Lote", SqlDbType.NVarChar)).Value = lotes(nombreTabla).Rows(indiceLote).Item("LoteNum").ToString
                                    consulta.Parameters.Add(New SqlParameter("@pFechaVence", SqlDbType.DateTime)).Value = lotes(nombreTabla).Rows(indiceLote).Item("FechaVence")
                                    consulta.Parameters.Add(New SqlParameter("@pStock", SqlDbType.Int)).Value = lotes(nombreTabla).Rows(indiceLote).Item("StockLote")
                                    consulta.Parameters.Add(New SqlParameter("@pConteo", SqlDbType.Int)).Value = lotes(nombreTabla).Rows(indiceLote).Item("ConteoLote")
                                    consulta.Parameters.Add(New SqlParameter("@pCosto", SqlDbType.Float)).Value = lotes(nombreTabla).Rows(indiceLote).Item("Costo")
                                    consulta.Parameters.Add(New SqlParameter("@exep", SqlDbType.Bit)).Value = lotes(nombreTabla).Rows(indiceLote).Item("Excepcion")
                                    consulta.ExecuteNonQuery()
                                    If lotes(nombreTabla).Rows(indiceLote).Item("Reg_lote").ToString = "" Then
                                        consulta.Parameters.Clear()
                                        consulta.CommandText = "[PROC_CONTEO_AUXILIAR_CREAR_DETALLE_NUEVO_LOTE]"
                                        consulta.Parameters.Add(New SqlParameter("@codigoConteo", SqlDbType.Int)).Value = objConteo.codigoConteo
                                        consulta.Parameters.Add(New SqlParameter("@codigoProducto", SqlDbType.Int)).Value = objConteo.tblProductos.Rows(indiceProducto).Item("Codigo")
                                        consulta.Parameters.Add(New SqlParameter("@RegLote", SqlDbType.NVarChar)).Value = lotes(nombreTabla).Rows(indiceLote).Item("Reg_lote").ToString
                                        consulta.Parameters.Add(New SqlParameter("@NumeroLote", SqlDbType.NVarChar)).Value = lotes(nombreTabla).Rows(indiceLote).Item("LoteNum").ToString
                                        consulta.Parameters.Add(New SqlParameter("@FechaVence", SqlDbType.DateTime)).Value = lotes(nombreTabla).Rows(indiceLote).Item("FechaVence")
                                        consulta.Parameters.Add(New SqlParameter("@Conteo", SqlDbType.Int)).Value = lotes(nombreTabla).Rows(indiceLote).Item("ConteoLote")
                                        consulta.Parameters.Add(New SqlParameter("@Costo", SqlDbType.Float)).Value = lotes(nombreTabla).Rows(indiceLote).Item("Costo")
                                        consulta.Parameters.Add(New SqlParameter("@exep", SqlDbType.Bit)).Value = lotes(nombreTabla).Rows(indiceLote).Item("Excepcion")
                                        consulta.ExecuteNonQuery()
                                    End If

                                End If
                            Next
                        End If
                    Next
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub guardarConteo(ByRef objConteo As Conteo, ByVal usuario As Integer)
        Dim consecutivo As Integer
        Dim codigoConteoAuxiliar As String
        Using consultor_consecutivo As New SqlCommand()
            consultor_consecutivo.Connection = FormPrincipal.cnxion
            consultor_consecutivo.CommandType = CommandType.StoredProcedure
            consultor_consecutivo.Parameters.Clear()
            consultor_consecutivo.CommandText = "[PROC_LOTE_ULTIMO_CONSECUTIVO]"
            consecutivo = consultor_consecutivo.ExecuteScalar
            If consecutivo >= 0 Then
                consecutivo += 1
            End If
        End Using

        codigoConteoAuxiliar = objConteo.codigoConteo

        Try
            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure
                    ' Se inserta el encabezado del conteo auxiliar

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_CONTEO_CREAR]"
                    consulta.Parameters.Add(New SqlParameter("@pCodigo_Bodega", SqlDbType.Int)).Value = objConteo.codigoBodega
                    consulta.Parameters.Add(New SqlParameter("@pObservaciones", SqlDbType.NVarChar)).Value = objConteo.observacion
                    consulta.Parameters.Add(New SqlParameter("@pFecha", SqlDbType.DateTime)).Value = objConteo.fechaConteo
                    consulta.Parameters.Add(New SqlParameter("@pUsuario_Creacion", SqlDbType.NVarChar)).Value = usuario
                    objConteo.codigoConteo = CType(consulta.ExecuteScalar, String)


                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_CONTEO_AUXILIAR_ELIMINAR_DETALLE]"
                    consulta.Parameters.Add(New SqlParameter("@pCodigo_Conteo", SqlDbType.NVarChar)).Value = codigoConteoAuxiliar
                    consulta.ExecuteNonQuery()

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_CONTEO_AUXILIAR_ELIMINAR]"
                    consulta.Parameters.Add(New SqlParameter("@pCodigo_Conteo", SqlDbType.NVarChar)).Value = codigoConteoAuxiliar
                    consulta.ExecuteNonQuery()

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_CONTEO_AUXILIAR_ELIMINAR_DETALLE_LOTES_NUEVOS]"
                    consulta.Parameters.Add(New SqlParameter("@pCodigo_Conteo", SqlDbType.NVarChar)).Value = codigoConteoAuxiliar
                    consulta.ExecuteNonQuery()

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_LOTES_REESTABLECER]"
                    consulta.Parameters.Add(New SqlParameter("@pCodigoBodega", SqlDbType.Int)).Value = objConteo.codigoBodega
                    consulta.Parameters.Add(New SqlParameter("@pCodigo", SqlDbType.Int)).Value = objConteo.codigoConteo
                    consulta.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = usuario
                    consulta.ExecuteNonQuery()



                    Dim nombreTabla As String = ""
                    Dim lotes As DataTableCollection = objConteo.tblLotes.Tables

                    For indiceProducto = 0 To objConteo.tblProductos.Rows.Count - 1
                        nombreTabla = objConteo.nombrarTabla(objConteo.tblProductos.Rows(indiceProducto).Item("Codigo"))
                        If objConteo.verificarExistenciaTabla(nombreTabla) Then
                            For indiceLote = 0 To lotes(nombreTabla).Rows.Count - 1
                                If lotes(nombreTabla).Rows(indiceLote).Item("LoteNum").ToString <> "" AndAlso lotes(nombreTabla).Rows(indiceLote).Item("ConteoLote") >= 0 Then
                                    If lotes(nombreTabla).Rows(indiceLote).Item("Reg_lote").ToString = "" Then
                                        consulta.Parameters.Clear()
                                        consulta.CommandText = "[PROC_LOTES_CREAR]"
                                        consulta.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.Int)).Value = consecutivo
                                        consulta.Parameters.Add(New SqlParameter("@N_LOTE", SqlDbType.NVarChar)).Value = lotes(nombreTabla).Rows(indiceLote).Item("LoteNum")
                                        consulta.Parameters.Add(New SqlParameter("@FECHA_VENCE", SqlDbType.Date)).Value = lotes(nombreTabla).Rows(indiceLote).Item("FechaVence")
                                        consulta.Parameters.Add(New SqlParameter("@STOCK", SqlDbType.Int)).Value = lotes(nombreTabla).Rows(indiceLote).Item("ConteoLote")
                                        consulta.Parameters.Add(New SqlParameter("@CODIGO_BODEGA", SqlDbType.Int)).Value = objConteo.codigoBodega
                                        consulta.Parameters.Add(New SqlParameter("@CODIGO_PRODUCTO", SqlDbType.Int)).Value = objConteo.tblProductos.Rows(indiceProducto).Item("Codigo")
                                        consulta.Parameters.Add(New SqlParameter("@RECEP", SqlDbType.NVarChar)).Value = ""
                                        consulta.Parameters.Add(New SqlParameter("@RECEP_T", SqlDbType.NVarChar)).Value = ""
                                        consulta.Parameters.Add(New SqlParameter("@CONTEO", SqlDbType.NVarChar)).Value = objConteo.codigoConteo
                                        consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.NVarChar)).Value = usuario
                                        consulta.Parameters.Add(New SqlParameter("@exep", SqlDbType.Bit)).Value = lotes(nombreTabla).Rows(indiceLote).Item("Excepcion")
                                        consulta.ExecuteNonQuery()
                                    Else
                                        consulta.Parameters.Clear()
                                        consulta.CommandText = "[PROC_LOTES_ACTUALIZAR_STOCK]"
                                        consulta.Parameters.Add(New SqlParameter("@pCodigoProducto", SqlDbType.Int)).Value = objConteo.tblProductos.Rows(indiceProducto).Item("Codigo")
                                        consulta.Parameters.Add(New SqlParameter("@pregLote", SqlDbType.Int)).Value = lotes(nombreTabla).Rows(indiceLote).Item("Reg_lote")
                                        consulta.Parameters.Add(New SqlParameter("@pCodigoBodega", SqlDbType.Int)).Value = objConteo.codigoBodega
                                        consulta.Parameters.Add(New SqlParameter("@pCantidad", SqlDbType.Int)).Value = lotes(nombreTabla).Rows(indiceLote).Item("ConteoLote")
                                        consulta.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = usuario
                                        consulta.ExecuteNonQuery()
                                    End If

                                    consulta.Parameters.Clear()
                                    consulta.CommandText = "[PROC_LOTES_KARDEX_CREAR]"
                                    consulta.Parameters.Add(New SqlParameter("@Codigo_Bodega", SqlDbType.Int)).Value = objConteo.codigoBodega
                                    consulta.Parameters.Add(New SqlParameter("@Codigo_Producto", SqlDbType.Int)).Value = objConteo.tblProductos.Rows(indiceProducto).Item("Codigo")
                                    consulta.Parameters.Add(New SqlParameter("@Reg_lote", SqlDbType.Int)).Value = If(lotes(nombreTabla).Rows(indiceLote).Item("Reg_lote").ToString = "", consecutivo, lotes(nombreTabla).Rows(indiceLote).Item("Reg_lote"))
                                    consulta.Parameters.Add(New SqlParameter("@Cant_Entrada", SqlDbType.Int)).Value = lotes(nombreTabla).Rows(indiceLote).Item("ConteoLote")
                                    consulta.Parameters.Add(New SqlParameter("@Cant_Salida", SqlDbType.Int)).Value = 0
                                    consulta.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.NVarChar)).Value = usuario
                                    consulta.Parameters.Add(New SqlParameter("@Origen", SqlDbType.NVarChar)).Value = "C"
                                    consulta.Parameters.Add(New SqlParameter("@Codigo_movimiento", SqlDbType.NVarChar)).Value = objConteo.codigoConteo
                                    consulta.ExecuteNonQuery()

                                    consulta.Parameters.Clear()
                                    consulta.CommandText = "[PROC_CONTEO_CREAR_DETALLE]"
                                    consulta.Parameters.Add(New SqlParameter("@pCodigo_Conteo", SqlDbType.Int)).Value = objConteo.codigoConteo
                                    consulta.Parameters.Add(New SqlParameter("@pReg_Lote", SqlDbType.Int)).Value = If(lotes(nombreTabla).Rows(indiceLote).Item("Reg_lote").ToString = "", consecutivo, lotes(nombreTabla).Rows(indiceLote).Item("Reg_lote"))
                                    consulta.Parameters.Add(New SqlParameter("@pStock", SqlDbType.Int)).Value = lotes(nombreTabla).Rows(indiceLote).Item("StockLote")
                                    consulta.Parameters.Add(New SqlParameter("@pConte", SqlDbType.Int)).Value = lotes(nombreTabla).Rows(indiceLote).Item("ConteoLote")
                                    consulta.Parameters.Add(New SqlParameter("@pCosto", SqlDbType.Int)).Value = lotes(nombreTabla).Rows(indiceLote).Item("Costo")
                                    consulta.Parameters.Add(New SqlParameter("@pUsuario_Creacion", SqlDbType.Int)).Value = usuario
                                    consulta.ExecuteNonQuery()

                                    If lotes(nombreTabla).Rows(indiceLote).Item("Reg_lote").ToString = "" Then
                                        consecutivo += 1
                                    End If

                                End If
                            Next
                        End If
                    Next
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub anularConteo(ByRef objConteo As Conteo)
        Try
            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure
                    ' Se inserta el encabezado del conteo auxiliar

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_CONTEO_AUXILIAR_ELIMINAR_DETALLE]"
                    consulta.Parameters.Add(New SqlParameter("@pCodigo_Conteo", SqlDbType.NVarChar)).Value = objConteo.codigoConteo
                    consulta.ExecuteNonQuery()

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_CONTEO_AUXILIAR_ELIMINAR]"
                    consulta.Parameters.Add(New SqlParameter("@pCodigo_Conteo", SqlDbType.NVarChar)).Value = objConteo.codigoConteo
                    consulta.ExecuteNonQuery()

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_CONTEO_AUXILIAR_ELIMINAR_DETALLE_LOTES_NUEVOS]"
                    consulta.Parameters.Add(New SqlParameter("@pCodigo_Conteo", SqlDbType.NVarChar)).Value = objConteo.codigoConteo
                    consulta.ExecuteNonQuery()

                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
