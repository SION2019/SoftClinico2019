Imports System.Data.SqlClient

Public Class RecepcionTecnicaTrasladoDAL
    Public Sub guardarRecepcionTralado(ByVal objRecepcion As RecepcionTecnicaTraslado, ByVal usuario As Integer, ByVal punto As Integer)
        Dim nombreTabla As String
        Dim consecutivo, codigoBodega As Integer
        nombreTabla = ""

        Try
            Using consultor_consecutivo As New SqlCommand()
                consultor_consecutivo.Connection = FormPrincipal.cnxion
                consultor_consecutivo.CommandType = CommandType.StoredProcedure
                consultor_consecutivo.Parameters.Clear()
                consultor_consecutivo.CommandText = "[PROC_LOTE_ULTIMO_CONSECUTIVO]"
                consecutivo = consultor_consecutivo.ExecuteScalar
                consecutivo += 1
            End Using

            Using consultor_consecutivo As New SqlCommand()
                consultor_consecutivo.Connection = FormPrincipal.cnxion
                consultor_consecutivo.CommandType = CommandType.Text
                consultor_consecutivo.Parameters.Clear()
                consultor_consecutivo.CommandText = "select dbo.FN_BODEGA_PEDIDO (" & objRecepcion.codigoTraslado & ") "
                codigoBodega = consultor_consecutivo.ExecuteScalar
            End Using

            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction

                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_RECEPCION_TECNICA_TRASLADO_CREAR]"
                    consulta.Parameters.Add(New SqlParameter("@Traslado", SqlDbType.Int)).Value = objRecepcion.codigoTraslado
                    consulta.Parameters.Add(New SqlParameter("@codigo_EP", SqlDbType.Int)).Value = punto
                    consulta.Parameters.Add(New SqlParameter("@Fecha_Recepcion_Traslado", SqlDbType.DateTime)).Value = objRecepcion.fechaRecepcion
                    consulta.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.NVarChar)).Value = usuario
                    objRecepcion.codigoRecepcion = CType(consulta.ExecuteScalar, String)



                    For indiceProducto = 0 To objRecepcion.tblProdcutos.Rows.Count - 1
                        If objRecepcion.tblProdcutos.Rows(indiceProducto).Item("Confirmacion") = True Then

                            nombreTabla = objRecepcion.nombrarTabla(objRecepcion.tblProdcutos.Rows(indiceProducto).Item("Codigo_Producto"), indiceProducto)
                            Dim tblLotes As DataTableCollection = objRecepcion.tblLotes.Tables
                            '---------   Guardar lotes -------------
                            If objRecepcion.verificarExistenciaTabla(nombreTabla) Then
                                For indiceLotes = 0 To tblLotes(nombreTabla).Rows.Count - 1

                                    consulta.Parameters.Clear()
                                    consulta.CommandText = "[PROC_LOTES_CREAR]"
                                    consulta.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.Int)).Value = consecutivo
                                    consulta.Parameters.Add(New SqlParameter("@N_LOTE", SqlDbType.NVarChar)).Value = tblLotes(nombreTabla).Rows(indiceLotes).Item("Num_lote")
                                    consulta.Parameters.Add(New SqlParameter("@FECHA_VENCE", SqlDbType.Date)).Value = tblLotes(nombreTabla).Rows(indiceLotes).Item("Fecha_vence")
                                    consulta.Parameters.Add(New SqlParameter("@STOCK", SqlDbType.Int)).Value = tblLotes(nombreTabla).Rows(indiceLotes).Item("CantEnv")
                                    consulta.Parameters.Add(New SqlParameter("@CODIGO_BODEGA", SqlDbType.Int)).Value = codigoBodega
                                    consulta.Parameters.Add(New SqlParameter("@CODIGO_PRODUCTO", SqlDbType.Int)).Value = objRecepcion.tblProdcutos.Rows(indiceProducto).Item("Codigo_Producto")
                                    consulta.Parameters.Add(New SqlParameter("@RECEP", SqlDbType.NVarChar)).Value = ""
                                    consulta.Parameters.Add(New SqlParameter("@RECEP_T", SqlDbType.NVarChar)).Value = objRecepcion.codigoRecepcion
                                    consulta.Parameters.Add(New SqlParameter("@CONTEO", SqlDbType.NVarChar)).Value = ""
                                    consulta.Parameters.Add(New SqlParameter("@exep", SqlDbType.Bit)).Value = tblLotes(nombreTabla).Rows(indiceLotes).Item("Excepcion")
                                    consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.NVarChar)).Value = usuario
                                    consulta.ExecuteNonQuery()

                                    '---------   Guardar detalle de la recepcion -------------

                                    consulta.Parameters.Clear()
                                    consulta.CommandText = "[PROC_RECEPCION_TECNICA_TRASLADO_CREAR_DETALLE]"
                                    consulta.Parameters.Add(New SqlParameter("@Codigo_Recepcion", SqlDbType.Int)).Value = objRecepcion.codigoRecepcion
                                    consulta.Parameters.Add(New SqlParameter("@Codigo_Producto", SqlDbType.Int)).Value = objRecepcion.tblProdcutos.Rows(indiceProducto).Item("Codigo_Producto")
                                    consulta.Parameters.Add(New SqlParameter("@Reg_lote", SqlDbType.Int)).Value = tblLotes(nombreTabla).Rows(indiceLotes).Item("Reg_lote")
                                    consulta.Parameters.Add(New SqlParameter("@Reg_lote_tras", SqlDbType.Int)).Value = consecutivo
                                    consulta.Parameters.Add(New SqlParameter("@Cant", SqlDbType.Int)).Value = tblLotes(nombreTabla).Rows(indiceLotes).Item("CantEnv")
                                    consulta.Parameters.Add(New SqlParameter("@costo", SqlDbType.Float)).Value = tblLotes(nombreTabla).Rows(indiceLotes).Item("Costo")
                                    consulta.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.NVarChar)).Value = usuario
                                    consulta.ExecuteNonQuery()

                                    '---------   Guardar el movimiento en  kaxdex -------------
                                    consulta.Parameters.Clear()
                                    consulta.CommandText = "[PROC_LOTES_KARDEX_CREAR]"
                                    consulta.Parameters.Add(New SqlParameter("@Codigo_Bodega", SqlDbType.Int)).Value = codigoBodega
                                    consulta.Parameters.Add(New SqlParameter("@Codigo_Producto", SqlDbType.Int)).Value = objRecepcion.tblProdcutos.Rows(indiceProducto).Item("Codigo_Producto")
                                    consulta.Parameters.Add(New SqlParameter("@Reg_lote", SqlDbType.Int)).Value = consecutivo
                                    consulta.Parameters.Add(New SqlParameter("@Cant_Entrada", SqlDbType.Int)).Value = tblLotes(nombreTabla).Rows(indiceLotes).Item("CantEnv")
                                    consulta.Parameters.Add(New SqlParameter("@Cant_Salida", SqlDbType.Int)).Value = 0
                                    consulta.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.NVarChar)).Value = usuario
                                    consulta.Parameters.Add(New SqlParameter("@Origen", SqlDbType.NVarChar)).Value = "S"
                                    consulta.Parameters.Add(New SqlParameter("@Codigo_movimiento", SqlDbType.NVarChar)).Value = objRecepcion.codigoRecepcion
                                    consulta.ExecuteNonQuery()

                                    consecutivo += 1
                                Next
                            End If
                        End If
                    Next

                    trnsccion.Commit()

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        devolverCantidadesNoRecepcionadas(objRecepcion)
        actualizarEstadoTraslado(objRecepcion)
    End Sub
    Sub actualizarEstadoTraslado(ByRef obj As RecepcionTecnicaTraslado)
        Using consultor As New SqlCommand()
            consultor.Connection = FormPrincipal.cnxion
            consultor.CommandType = CommandType.StoredProcedure
            consultor.Parameters.Clear()
            consultor.CommandText = "[PROC_RECEPCION_TECNICA_TRASLADO_ACTUALIZAR_ESTADO]"
            consultor.Parameters.Add(New SqlParameter("@Traslado", SqlDbType.Int)).Value = obj.codigoTraslado
            consultor.ExecuteNonQuery()
        End Using
    End Sub
    Sub devolverCantidadesNoRecepcionadas(ByVal objRecepcion As RecepcionTecnicaTraslado)
        Using consultor As New SqlCommand()
            consultor.Connection = FormPrincipal.cnxion
            consultor.CommandType = CommandType.StoredProcedure
            consultor.Parameters.Clear()
            consultor.CommandText = "[PROC_DEVOLVER_CANTIDADES_NO_RECEPCIONADAS]"
            consultor.Parameters.Add(New SqlParameter("@pCodigoRecepcion", SqlDbType.Int)).Value = objRecepcion.codigoRecepcion
            consultor.ExecuteNonQuery()
        End Using
    End Sub
    Public Function verificacion_anular_recepcion(ByVal codigo As Integer) As Boolean
        Dim resp As String

        Using consultor As New SqlCommand()
            consultor.Connection = FormPrincipal.cnxion
            consultor.CommandType = CommandType.StoredProcedure
            consultor.Parameters.Clear()
            consultor.CommandText = "[PROC_RECEPCION_TRASLADO_VERIFICAR_ANULAR]"
            consultor.Parameters.Add(New SqlParameter("@CODIGO_RECEPCION_TRASLADO ", SqlDbType.Int))
            consultor.Parameters("@CODIGO_RECEPCION_TRASLADO ").Value = codigo
            resp = CType(consultor.ExecuteScalar, String)
        End Using


        If resp = "Se puede anular" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function anular(ByVal codigo_recepcion As Integer) As Boolean
        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.CommandType = CommandType.StoredProcedure
                    comando.Parameters.Clear()

                    comando.CommandText = "[PROC_RECEPCION_TRASLADO_ANULAR]"
                    comando.Parameters.Add(New SqlParameter("@codigo", SqlDbType.Int))
                    comando.Parameters("@codigo").Value = codigo_recepcion
                    comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.NVarChar))
                    comando.Parameters("@Usuario").Value = SesionActual.idUsuario
                    comando.ExecuteNonQuery()

                    Try
                        trnsccion.Commit()
                        Return True
                    Catch ex As Exception
                        Return False
                        trnsccion.Rollback()
                        general.manejoErrores(ex) 
                    End Try
                End Using
            End Using
        Catch ex As Exception
            general.manejoErrores(ex) 
            Return False
        End Try
    End Function

End Class
