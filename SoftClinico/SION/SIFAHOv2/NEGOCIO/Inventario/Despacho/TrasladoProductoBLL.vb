Public Class TrasladoProductoBLL
    Dim cmd As New TrasladoProductoDAL

    Public Sub ReestablecerEquivalencia(ByRef objTraslado As TrasladoProducto,
                                        ByRef dgv As DataGridView)
        If objTraslado.tblProductos.Rows(dgv.CurrentRow.Index).Item("Agregada").ToString = Constantes.ITEM_NUEVO Then
            objTraslado.tblProductos.Rows(dgv.CurrentRow.Index - 1).Item("CantPed") += objTraslado.tblProductos.Rows(dgv.CurrentRow.Index).Item("CantPed")

        End If
    End Sub
    Public Sub dividirEquivalencia(ByRef objTraslado As TrasladoProducto,
                                    ByRef dgv As DataGridView)
        If objTraslado.codigoTraslado = "" Then
            Dim num_productos As Integer = 0
            num_productos = cmd.numeros_productos(objTraslado.tblProductos.Rows(dgv.CurrentRow.Index).Item("Codigo_Interno"))

            If num_productos >= 2 Then
                If objTraslado.tblProductos.Rows(dgv.CurrentRow.Index).Item("Codigo").ToString = "" Then
                    Dim a As String = InputBox("Digite Cantidad del producto a despachar : " + CStr(objTraslado.tblProductos.Rows(dgv.CurrentRow.Index).Item("CantPed")) +
                                               " División de cantidad del equivalencia")

                    If a <> "" AndAlso IsNumeric(a) Then
                        If a < objTraslado.tblProductos.Rows(dgv.CurrentRow.Index).Item("CantPed") Then
                            objTraslado.tblProductos.Rows(dgv.CurrentRow.Index).Item("CantPed") -= a
                            Dim dr As DataRow = objTraslado.tblProductos.NewRow
                            dr("Codigo_Interno") = objTraslado.tblProductos.Rows(dgv.CurrentRow.Index).Item("Codigo_Interno")
                            dr("Nombre_equi") = objTraslado.tblProductos.Rows(dgv.CurrentRow.Index).Item("Nombre_equi")
                            dr("Stock") = objTraslado.tblProductos.Rows(dgv.CurrentRow.Index).Item("Stock")
                            dr("CantPed") = a  '-- aqui se coloca la que se le va a colocar a la nueva fila
                            dr("CPQ") = objTraslado.tblProductos.Rows(dgv.CurrentRow.Index).Item("CPQ")
                            dr("Agregada") = "Agregada"
                            objTraslado.tblProductos.Rows.InsertAt(dr, dgv.CurrentRow.Index + 1)
                            dgv.EndEdit()
                            objTraslado.tblProductos.EndInit()
                        Else
                            MsgBox("la cantidad no puede ser mayor o igual a la cantidad pedida !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                        End If
                    Else
                        MsgBox("la cantidad tiene que ser un valor númerico !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                    End If
                Else
                    MsgBox("No puede dividir la cantidad de la equivalencia debe quitar el producto primero !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                End If
            Else
                MsgBox("Esta equivalencia no se puede dividir por que solo tiene un producto o no tiene porducto asignado !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Public Function numeros_productos(ByVal codigo_interno As Integer) As Integer
        Return cmd.numeros_productos(codigo_interno)
    End Function
    Public Sub cargarLotesDespachar(ByVal nombre_tabla As String, ByVal codigo_producto As String, ByVal codigo_bodega As Integer, ByVal objTraslado As TrasladoProducto)
        cmd.cargarLotesDespachar(nombre_tabla, codigo_producto, codigo_bodega, objTraslado)
    End Sub
    Public Sub GuardarTraslado(ByRef objTraslado As TrasladoProducto, ByRef punto As Integer, ByRef usuario As Integer)
        Try
            cmd.GuardarTraslado(objTraslado, punto, usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub cargarLotesDespachados(ByVal nombreTabla As String,
                                      ByVal codigoProducto As String,
                                      ByRef objTraslado As TrasladoProducto)
        cmd.cargarLotesDespachados(nombreTabla, codigoProducto, objTraslado)
    End Sub
    Public Sub anular(ByRef objTraslado As TrasladoProducto, ByVal usuario As Integer)
        Try
            cmd.anular(objTraslado, usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function verificacionTrasladoAnular(ByVal codigo As Integer) As Boolean
        Return cmd.verificacionTrasladoAnular(codigo)
    End Function
    Public Function verificarAnularProducto(ByVal codigoTraslado As Integer, ByVal codigoProducto As Integer) As Boolean
        Return cmd.verificarAnularProducto(codigoTraslado, codigoProducto)
    End Function
    Public Sub anularProducto(ByVal codigoTraslado As Integer,
                              ByVal codigoInterno As Integer,
                              ByVal codigoProducto As Integer,
                              ByVal codigoPedido As Integer,
                              ByVal codigoBodega As Integer,
                              ByVal usuario As Integer)
        Try
            cmd.anularProducto(codigoTraslado, codigoInterno, codigoProducto, codigoPedido, codigoBodega, usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub calcularTotales(ByRef objTraslado As TrasladoProducto,
                               ByRef LblCostoTotal As ToolStripLabel,
                               ByRef LblCantidad_productos As ToolStripLabel)

        If IsDBNull(objTraslado.tblProductos.Compute("SUM(Total_P)", "")) Then
            LblCostoTotal.Text = "TOTAL VALOR DESPACHO : " & Format(0, "c2")
        Else
            LblCostoTotal.Text = "TOTAL VALOR DESPACHO : " & Format(objTraslado.tblProductos.Compute("SUM(Total_P)", ""), "c2")
        End If

        If IsDBNull(objTraslado.tblProductos.Select("Codigo<>''", "").Count) Then
            LblCantidad_productos.Text = "PRODUCTOS : " & 0
        Else
            LblCantidad_productos.Text = "PRODUCTOS : " & objTraslado.tblProductos.Select("Codigo<>''", "").Count
        End If
    End Sub
    Public Sub calcular_lotes(ByRef objTraslado As TrasladoProducto,
                              ByRef dgvLotes As DataGridView,
                              ByRef dgvproductos As DataGridView,
                              ByRef cantidad As TextBox)

        Dim nombreTabla As String
        nombreTabla = objTraslado.nombrarTabla(objTraslado.tblProductos.Rows(dgvproductos.CurrentRow.Index).Item("Codigo"), dgvproductos.CurrentRow.Index)
        If IsDBNull(objTraslado.tblLotes.Tables(nombreTabla).Rows(dgvLotes.CurrentRow.Index).Item("Cantidad")) Then
            objTraslado.tblLotes.Tables(nombreTabla).Rows(dgvLotes.CurrentRow.Index).Item("Cantidad") = 0
        End If


        Dim sumatoria As Integer = objTraslado.tblLotes.Tables(nombreTabla).Compute("SUM(Cantidad)", "")
        If Funciones.filaValida(dgvLotes.CurrentRow.Index) Then
            If sumatoria > CInt(cantidad.Text) Then
                objTraslado.tblLotes.Tables(nombreTabla).Rows(dgvLotes.CurrentRow.Index).Item("Cantidad") = 0
                MsgBox("La sumatoria de los lotes no puedes ser mayor a la cantidad pedida !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            ElseIf objTraslado.tblLotes.Tables(nombreTabla).Rows(dgvLotes.CurrentRow.Index).Item("Cantidad") > objTraslado.tblLotes.Tables(nombreTabla).Rows(dgvLotes.CurrentRow.Index).Item("stock") Then
                objTraslado.tblLotes.Tables(nombreTabla).Rows(dgvLotes.CurrentRow.Index).Item("Cantidad") = 0
                MsgBox("La cantidad del a trasladar del lote no puede superar el stock existente !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            End If
            objTraslado.tblProductos.Rows(dgvproductos.CurrentRow.Index).Item("CantEnt") = objTraslado.tblLotes.Tables(nombreTabla).Compute("SUM(Cantidad)", "")
            objTraslado.tblLotes.AcceptChanges()
            objTraslado.tblProductos.Rows(dgvproductos.CurrentRow.Index).Item("Total_P") = objTraslado.tblLotes.Tables(nombreTabla).Compute("SUM(Total)", "")
            objTraslado.tblProductos.EndInit()
            dgvproductos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub
End Class
