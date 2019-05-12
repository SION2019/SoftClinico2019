Public Class DespachoPedidoServicioBLL
    Dim despachoC As New PedidoServicioDAL
    Public Sub guardar(ByVal objDespachoPedido As DespachoPedidoServicio,
                       ByVal usuario As String)

        Dim dttemp As New DataTable
        crearTablaTemporal(dttemp)

        For Each tabla As DataTable In objDespachoPedido.tblLotes.Tables
            For indiceFila As Int16 = 0 To tabla.Rows.Count - 1
                If tabla.Rows(indiceFila).Item("Cantidad") > 0 Then
                    dttemp.ImportRow(tabla.Rows(indiceFila))
                End If
            Next
        Next
        ' MsgBox("listo !")
        despachoC.guardar(objDespachoPedido, dttemp, usuario)
    End Sub
    Public Sub anular(ByRef objDespachoPedido As DespachoPedidoServicio,
                      ByVal usuario As String)
        despachoC.anular(objDespachoPedido, usuario)
    End Sub

    Public Sub enlazarTablas(ByRef dgvDetalle As DataGridView, ByRef tblBodega As DataTable, ByRef tblDetalle As DataTable)
        With dgvDetalle
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").DataPropertyName = "Descripcion"
            .Columns("CantidadPed").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantidadPed").DataPropertyName = "CantidadPedida"
            .Columns("CantidadEnt").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantidadEnt").DataPropertyName = "CantidadDespachada"
        End With
        dgvDetalle.AutoGenerateColumns = False
        dgvDetalle.DataSource = tblDetalle
        dgvDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDetalle.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 8)
    End Sub
    Public Sub enlazarTablasLotes(ByRef dgvLotes As DataGridView,
                                  ByVal objDespachoPedido As DespachoPedidoServicio,
                                  ByVal nombreTabla As String)



        If Funciones.contarColumnasTablas(objDespachoPedido.tblLotes.Tables(nombreTabla)) = 0 Then
            Dim columLote As New DataColumn("Reg_lote", Type.GetType("System.String"))

            objDespachoPedido.tblLotes.Tables(nombreTabla).Columns.Add("Codigo_Interno", Type.GetType("System.String"))
            objDespachoPedido.tblLotes.Tables(nombreTabla).Columns.Add("Codigo_Bodega", Type.GetType("System.String"))
            objDespachoPedido.tblLotes.Tables(nombreTabla).Columns.Add("Bodega", Type.GetType("System.String"))
            objDespachoPedido.tblLotes.Tables(nombreTabla).Columns.Add("Codigo_Producto", Type.GetType("System.String"))
            objDespachoPedido.tblLotes.Tables(nombreTabla).Columns.Add("Producto", Type.GetType("System.String"))
            objDespachoPedido.tblLotes.Tables(nombreTabla).Columns.Add("Marca", Type.GetType("System.String"))
            objDespachoPedido.tblLotes.Tables(nombreTabla).Columns.Add(columLote)
            objDespachoPedido.tblLotes.Tables(nombreTabla).PrimaryKey = New DataColumn() {columLote}
            objDespachoPedido.tblLotes.Tables(nombreTabla).Columns.Add("Num_lote", Type.GetType("System.String"))
            objDespachoPedido.tblLotes.Tables(nombreTabla).Columns.Add("Fecha_Vence", Type.GetType("System.DateTime"))
            objDespachoPedido.tblLotes.Tables(nombreTabla).Columns.Add("Stock", Type.GetType("System.String"))
            objDespachoPedido.tblLotes.Tables(nombreTabla).Columns.Add("Cantidad", Type.GetType("System.Int32"))

        End If

        With dgvLotes
            .Columns("BodegaLote").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("BodegaLote").DataPropertyName = "Bodega"
            .Columns("Producto").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Producto").DataPropertyName = "Producto"
            .Columns("Marca").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Marca").DataPropertyName = "Marca"
            .Columns("Lote").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Lote").DataPropertyName = "Num_lote"
            .Columns("Fecha_vence").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Fecha_vence").DataPropertyName = "Fecha_Vence"
            .Columns("Stock").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Stock").DataPropertyName = "Stock"
            .Columns("Cantidad_Des").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cantidad_Des").DataPropertyName = "Cantidad"
        End With

        dgvLotes.AutoGenerateColumns = False
        dgvLotes.DataSource = objDespachoPedido.tblLotes.Tables(nombreTabla)
        dgvLotes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvLotes.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 8)
    End Sub
    Public Sub crearTablaTemporal(ByRef tbl As DataTable)
        tbl.Columns.Add("Codigo_Interno", Type.GetType("System.String"))
        tbl.Columns.Add("Codigo_Bodega", Type.GetType("System.String"))
        tbl.Columns.Add("Bodega", Type.GetType("System.String"))
        tbl.Columns.Add("Codigo_Producto", Type.GetType("System.String"))
        tbl.Columns.Add("Producto", Type.GetType("System.String"))
        tbl.Columns.Add("Marca", Type.GetType("System.String"))
        tbl.Columns.Add("Reg_lote", Type.GetType("System.String"))
        tbl.Columns.Add("Num_lote", Type.GetType("System.String"))
        tbl.Columns.Add("Fecha_Vence", Type.GetType("System.DateTime"))
        tbl.Columns.Add("Stock", Type.GetType("System.String"))
        tbl.Columns.Add("Cantidad", Type.GetType("System.Int32"))

    End Sub
End Class
