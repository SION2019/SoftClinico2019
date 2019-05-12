Imports System.Data.SqlClient
Public Class TrasladoProductoDAL
    Public Function Buscar_bodegas() As DataTable
        Using dt As New DataTable
            Using consultor As New SqlDataAdapter("[PROC_TRASLADOS_BUSCAR_BODEGA]", FormPrincipal.cnxion)
                consultor.Fill(dt)
            End Using
            Return dt
        End Using
    End Function
    Public Function Buscar_transportadoras() As DataTable
        Using dt As New DataTable
            dt.Columns.Add("Codigo_transportadora")
            dt.Columns.Add("Descripcion")
            dt.Rows.Add("--", "-- Seleccione transportadora --")
            Using consultor As New SqlDataAdapter("[PROC_TRASLADOS_BUSCAR_TRANSPORTADORAS]", FormPrincipal.cnxion)
                consultor.Fill(dt)
            End Using
            Return dt
        End Using
    End Function
    Public Function numeros_productos(ByVal codigo_interno As Integer) As Integer
        Using cmd As New SqlCommand("[PROC_TRASLADOS_VERIFICAR_NUMERO_PRODUCTOS] " & codigo_interno, FormPrincipal.cnxion)
            Return cmd.ExecuteScalar()
        End Using
    End Function
    Public Sub cargarLotesDespachar(ByVal nombre_tabla As String, ByVal codigo_producto As Integer, ByVal codigo_bodega As Integer, ByRef objTraslado As TrasladoProducto)
        Try
            Dim params As New List(Of String)
            params.Add(codigo_producto)
            params.Add(codigo_bodega)
            General.llenarTabla(Consultas.BUSCAR_EXISTENCIA_LOTES, params, objTraslado.tblLotes.Tables(nombre_tabla))
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Public Sub cargarLotesDespachados(ByVal nombreTabla As String,
                                      ByVal codigoProducto As Integer,
                                      ByRef objTraslado As TrasladoProducto)
        Try
            Dim params As New List(Of String)
            params.Add(objTraslado.codigoTraslado)
            params.Add(codigoProducto)
            params.Add(objTraslado.bodegaSolicitada)
            General.llenarTabla(Consultas.TRASLADOS_CARGAR_LOTES_PRODUCTOS_TRASLADADOS, params, objTraslado.tblLotes.Tables(nombreTabla))
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Public Sub GuardarTraslado(ByRef objTraslado As TrasladoProducto, ByRef punto As Integer, ByRef usuario As Integer)

        Dim codigo As String = ""
        Dim codigoLote As String = ""
        Dim nombreTabla As String = ""


        Try

            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure



                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_TRASLADOS_CREAR]"
                    consulta.Parameters.Add(New SqlParameter("@codigo_pedido", SqlDbType.Int)).Value = objTraslado.codigoPedido
                    consulta.Parameters.Add(New SqlParameter("@codigo_EP", SqlDbType.Int)).Value = punto
                    consulta.Parameters.Add(New SqlParameter("@porcentaje", SqlDbType.Float)).Value = objTraslado.porcentaje
                    consulta.Parameters.Add(New SqlParameter("@Nguia", SqlDbType.NVarChar)).Value = objTraslado.noGuia
                    consulta.Parameters.Add(New SqlParameter("@Codigo_Transportadora", SqlDbType.Int)).Value = objTraslado.trasnportadora
                    consulta.Parameters.Add(New SqlParameter("@Fecha_Traslado", SqlDbType.DateTime)).Value = objTraslado.fechaTraslado
                    consulta.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.NVarChar)).Value = usuario
                    objTraslado.codigoTraslado = CType(consulta.ExecuteScalar, String)


                    'Dim filas As DataRow()
                    'Dim tblTemp As New DataTable
                    'tblTemp = objTraslado.tblProductos.Clone
                    'filas = objTraslado.tblProductos.Select("Codigo <> ''", "")
                    'For Each fila As DataRow In filas
                    '    tblTemp.ImportRow(fila)
                    'Next
                    'objTraslado.tblProductos.Clear()
                    'objTraslado.tblProductos.Merge(tblTemp)

                    Dim lotes As DataTableCollection
                    lotes = objTraslado.tblLotes.Tables
                    '-------------------- Recorremos cada uno de los items del traslado 
                    For indiceProducto = 0 To objTraslado.tblProductos.Rows.Count - 1
                        If objTraslado.tblProductos.Rows(indiceProducto).Item("Codigo").ToString <> "" Then


                            '---------------- Asignamos el nombre a cada una de las tablas del (dataset)
                            nombreTabla = objTraslado.nombrarTabla(objTraslado.tblProductos.Rows(indiceProducto).Item("Codigo").ToString, indiceProducto)
                            '---------------- Validamos si exite la tabla en el (dataset)
                            If objTraslado.verificarExistenciaTabla(nombreTabla) Then
                                '------------ Recorremos cada uno de los items de la tabla contenida en el (dataset)
                                For indiceLote = 0 To lotes(nombreTabla).Rows.Count - 1
                                    '-------- Validamos si la fila que contine la tabla del (dataset) es mayor a 0 para su debido descuento de la bodega 
                                    '-------- demla cual vamos a despachar
                                    If lotes(nombreTabla).Rows(indiceLote).Item("Cantidad") > 0 Then

                                        '----------------------- Aqui se ingresa el detalle del traslado 
                                        consulta.Parameters.Clear()
                                        consulta.CommandText = "[PROC_TRASLADOS_CREAR_DETALLE]"
                                        consulta.Parameters.Add(New SqlParameter("@ID_TRASLADO", SqlDbType.Int)).Value = objTraslado.codigoTraslado
                                        consulta.Parameters.Add(New SqlParameter("@Codigo_Interno", SqlDbType.NVarChar)).Value = objTraslado.tblProductos.Rows(indiceProducto).Item("Codigo_Interno")
                                        consulta.Parameters.Add(New SqlParameter("@Usuario_creacion ", SqlDbType.Int)).Value = usuario
                                        consulta.Parameters.Add(New SqlParameter("@Codigo_Producto ", SqlDbType.Int)).Value = objTraslado.tblProductos.Rows(indiceProducto).Item("Codigo")
                                        consulta.Parameters.Add(New SqlParameter("@Reg_lote", SqlDbType.Int)).Value = lotes(nombreTabla).Rows(indiceLote).Item("Reg_lote")
                                        consulta.Parameters.Add(New SqlParameter("@Stock", SqlDbType.Int)).Value = objTraslado.tblProductos.Rows(indiceProducto).Item("Stock")
                                        consulta.Parameters.Add(New SqlParameter("@stock_Solicitante", SqlDbType.Int)).Value = objTraslado.tblProductos.Rows(indiceProducto).Item("Stock_solicitante")
                                        consulta.Parameters.Add(New SqlParameter("@StockLote", SqlDbType.Int)).Value = lotes(nombreTabla).Rows(indiceLote).Item("stock")
                                        consulta.Parameters.Add(New SqlParameter("@CantPed", SqlDbType.Int)).Value = objTraslado.tblProductos.Rows(indiceProducto).Item("CantPed")
                                        consulta.Parameters.Add(New SqlParameter("@CantEnv", SqlDbType.Int)).Value = lotes(nombreTabla).Rows(indiceLote).Item("Cantidad")
                                        consulta.Parameters.Add(New SqlParameter("@CantFal", SqlDbType.Int)).Value = objTraslado.tblProductos.Rows(indiceProducto).Item("CantFalt")
                                        consulta.Parameters.Add(New SqlParameter("@Costo", SqlDbType.Float)).Value = lotes(nombreTabla).Rows(indiceLote).Item("Costo")
                                        consulta.ExecuteNonQuery()

                                        '----------------------- Aqui se descuenta cada uno de los lotes que se van a trasladar 
                                        consulta.Parameters.Clear()
                                        consulta.CommandText = "[PROC_TRASLADOS_DESCONTAR_LOTES]"
                                        consulta.Parameters.Add(New SqlParameter("@cantidad", SqlDbType.Int)).Value = lotes(nombreTabla).Rows(indiceLote).Item("Cantidad")
                                        consulta.Parameters.Add(New SqlParameter("@reg_lote", SqlDbType.Int)).Value = lotes(nombreTabla).Rows(indiceLote).Item("Reg_lote")
                                        consulta.Parameters.Add(New SqlParameter("@Codigo_Producto", SqlDbType.Int)).Value = objTraslado.tblProductos.Rows(indiceProducto).Item("Codigo")
                                        consulta.Parameters.Add(New SqlParameter("@Codigo_Bodega", SqlDbType.Int)).Value = objTraslado.bodegaSolicitada
                                        consulta.Parameters.Add(New SqlParameter("@traslado", SqlDbType.Int)).Value = objTraslado.codigoTraslado
                                        consulta.Parameters.Add(New SqlParameter("@Usuario_creacion", SqlDbType.Int)).Value = usuario
                                        consulta.ExecuteNonQuery()

                                        '----------------------- Aqui se ingresa el detalle del movimiento de los lotes en LOTES_KARDEX
                                        consulta.Parameters.Clear()
                                        consulta.CommandText = "[PROC_LOTES_KARDEX_CREAR]"
                                        consulta.Parameters.Add(New SqlParameter("@Codigo_Bodega", SqlDbType.Int)).Value = objTraslado.bodegaSolicitada
                                        consulta.Parameters.Add(New SqlParameter("@Codigo_Producto", SqlDbType.Int)).Value = objTraslado.tblProductos.Rows(indiceProducto).Item("Codigo")
                                        consulta.Parameters.Add(New SqlParameter("@Reg_lote", SqlDbType.Int)).Value = lotes(nombreTabla).Rows(indiceLote).Item("Reg_lote")
                                        consulta.Parameters.Add(New SqlParameter("@Cant_Entrada", SqlDbType.Int)).Value = 0
                                        consulta.Parameters.Add(New SqlParameter("@Cant_Salida", SqlDbType.Int)).Value = lotes(nombreTabla).Rows(indiceLote).Item("Cantidad")
                                        consulta.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.NVarChar)).Value = usuario
                                        consulta.Parameters.Add(New SqlParameter("@Origen", SqlDbType.NVarChar)).Value = "T"
                                        consulta.Parameters.Add(New SqlParameter("@Codigo_movimiento", SqlDbType.Int)).Value = objTraslado.codigoTraslado
                                        consulta.ExecuteNonQuery()

                                    End If
                                Next
                            End If
                        End If
                    Next

                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_TRASLADO_ACTUALIZAR_CONSECUTIVO_PUNTO]"
                    consulta.Parameters.Add(New SqlParameter("@pCodigo_EP", SqlDbType.Int)).Value = punto
                    consulta.Parameters.Add(New SqlParameter("@pTipo", SqlDbType.Int)).Value = Constantes.CONSECUTIVO_TRASLADO
                    consulta.Parameters.Add(New SqlParameter("@CodigoOrdenInterno", SqlDbType.Int)).Value = objTraslado.codigoTraslado
                    objTraslado.codigoTrasladoPunto = CType(consulta.ExecuteScalar, String)
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        If objTraslado.activarPrincial = False Then
            actualizarEstadoTraslado(objTraslado)
        End If

    End Sub
    Sub actualizarEstadoTraslado(ByRef objTraslado As TrasladoProducto)
        Using consulta = New SqlCommand()
            consulta.Connection = FormPrincipal.cnxion
            consulta.CommandType = CommandType.StoredProcedure
            consulta.Parameters.Clear()
            consulta.CommandText = "[PROC_ACTUALIZAR_ESTADO_TRASLADO]"
            consulta.Parameters.Add(New SqlParameter("@CODIGOTRASLADO", SqlDbType.Int)).Value = objTraslado.codigoTraslado
            consulta.ExecuteNonQuery()
        End Using
    End Sub
    Public Sub cargar_traslado(ByVal objTraslado As TrasladoProducto)
        'Using consultor As New SqlCommand("[PROC_TRASLADO_CARGAR_ENCABEZADO] " & objTraslado.codigoTraslado, FormPrincipal.cnxion)
        '    Using lector = consultor.ExecuteReader
        '        If lector.HasRows = True Then
        '            lector.Read()
        '            Form_traslado.txtcodigo.Text = codigo
        '            Form_traslado.txtGuia.Text = lector.Item("No_Guia")
        '            Form_traslado.MTxtfecha.Text = Format(lector.Item("Fecha_Traslado"), Constantes.FORMATO_FECHA_HORA_GEN)
        '            Form_traslado.txtEstado.Text = lector.Item("Estado")
        '            Form_traslado.CmbTransportadora.SelectedValue = lector.Item("Codigo_Transportadora")
        '            Form_traslado.ChkAumento.Checked = CBool(lector.Item("Porcen"))
        '            Form_traslado.txtCodigoPedido.Text = lector.Item("Codigo_Pedido")
        '            Form_traslado.CmbBodSolicitante.SelectedValue = lector.Item("Codigo_Bodega_Origen")
        '            Form_traslado.CmbBodSolicitada.SelectedValue = lector.Item("Codigo_Bodega_Destino")
        '        End If
        '    End Using
        'End Using
        'Form_traslado.tblProductos.Clear()
        'Using consultor2 As New SqlDataAdapter("[PROC_TRASLADO_CARGAR_DETALLE]" & codigo, FormPrincipal.cnxion)
        '    consultor2.Fill(Form_traslado.tblProductos)
        'End Using
        'Form_traslado.tblProductos.AcceptChanges()
    End Sub
    Public Sub anular(ByRef objTraslado As TrasladoProducto, ByVal usuario As Integer)
        Try
            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure
                    consulta.Parameters.Clear()
                    consulta.CommandText = "[PROC_TRASLADOS_ANULAR]"
                    consulta.Parameters.Add(New SqlParameter("@CODIGO_TRASLADO", SqlDbType.Int)).Value = objTraslado.codigoTraslado
                    consulta.Parameters.Add(New SqlParameter("@CODIGO_PEDIDO", SqlDbType.Int)).Value = objTraslado.codigoPedido
                    consulta.Parameters.Add(New SqlParameter("@CODIGO_BODEGA", SqlDbType.Int)).Value = objTraslado.bodegaSolicitada
                    consulta.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.NVarChar)).Value = usuario
                    consulta.ExecuteNonQuery()
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function verificacionTrasladoAnular(ByVal codigo As Integer) As Boolean
        Dim resp As Integer

        Using consultor As New SqlCommand()
            consultor.Connection = FormPrincipal.cnxion
            consultor.CommandType = CommandType.StoredProcedure
            consultor.Parameters.Clear()
            consultor.CommandText = "[PROC_TRASLADO_VERIFICAR_ANULAR]"
            consultor.Parameters.Add(New SqlParameter("@CODIGO_TRASLADO", SqlDbType.Int))
            consultor.Parameters("@CODIGO_TRASLADO").Value = codigo
            'consultor.ExecuteNonQuery()
            resp = consultor.ExecuteScalar
        End Using


        If resp = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function verificarAnularProducto(ByVal codigoTraslado As Integer, ByVal codigoProducto As Integer) As Boolean
        Dim cantidad As Integer = 0
        Using consultor As New SqlCommand("[PROC_TRASLADOS_VERIFICAR_ANULAR_PRODUCTO] " & codigoTraslado & "," & codigoProducto, FormPrincipal.cnxion)
            cantidad = CInt(consultor.ExecuteScalar)
        End Using
        If cantidad = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub anularProducto(ByVal codigoTraslado As Integer, ByVal codigoInterno As Integer, ByVal codigoProducto As Integer, ByVal codigoPedido As Integer, ByVal codigoBodega As Integer, ByVal usuario As Integer)
        Try
            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure
                    consulta.Parameters.Clear()

                    consulta.CommandText = "[PROC_TRASLADOS_PRODUCTOS_ANULAR]"
                    consulta.Parameters.Add(New SqlParameter("@CODIGO_TRASLADO", SqlDbType.Int)).Value = codigoTraslado
                    consulta.Parameters.Add(New SqlParameter("@CODIGO_INTERNO", SqlDbType.Int)).Value = codigoInterno
                    consulta.Parameters.Add(New SqlParameter("@CODGIO_PRODUCTO", SqlDbType.Int)).Value = codigoProducto
                    consulta.Parameters.Add(New SqlParameter("@CODIGO_PEDIDO", SqlDbType.Int)).Value = codigoPedido
                    consulta.Parameters.Add(New SqlParameter("@CODIGO_BODEGA", SqlDbType.Int)).Value = codigoBodega
                    consulta.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.NVarChar)).Value = usuario
                    consulta.ExecuteNonQuery()

                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
