Public Class OrdenCompraBLL
    Dim objOrdenCompraDAL As New OrdenCompraDAL
    Public Sub configurarGrillaProductos(ByRef tablaProductos As DataTable,
                                         ByRef dgvProductos As DataGridView)
        With dgvProductos
            .Columns("Codigo").ReadOnly = True
            .Columns("Codigo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigo").DataPropertyName = "Codigo"
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").DataPropertyName = "Descripcion"
            .Columns("Presentacion").ReadOnly = True
            .Columns("Presentacion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Presentacion").DataPropertyName = "Presentacion"
            .Columns("Marca").ReadOnly = True
            .Columns("Marca").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Marca").DataPropertyName = "Marca"
            .Columns("Stock").ReadOnly = True
            .Columns("Stock").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Stock").DataPropertyName = "Stock"
            .Columns("StockEqui").ReadOnly = True
            .Columns("StockEqui").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("StockEqui").DataPropertyName = "StockEqui"
            .Columns("Iva").ReadOnly = True
            .Columns("Iva").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Iva").DataPropertyName = "Iva"
            .Columns("Costo").ReadOnly = True
            .Columns("Costo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Costo").DataPropertyName = "Costo"
            .Columns("Descuento").ReadOnly = False
            .Columns("Descuento").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descuento").DataPropertyName = "Descuento"
            .Columns("CPM").ReadOnly = True
            .Columns("CPM").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CPM").DataPropertyName = "CPM"
            .Columns("Cantidad").ReadOnly = False
            .Columns("Cantidad").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cantidad").DataPropertyName = "Cantidad"
            .Columns("Total").ReadOnly = True
            .Columns("Total").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Total").DataPropertyName = "Total"
            .AutoGenerateColumns = False
            .DataSource = tablaProductos
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With
    End Sub
    Public Sub guardarCompra(ByRef objOrdenCompra As Compra, ByVal usuario As Integer, ByVal punto As Integer)
        If objOrdenCompra.codigoCompraPunto = "" Then
            objOrdenCompraDAL.guardarCompra(objOrdenCompra, usuario, punto)
        Else
            objOrdenCompraDAL.actualizar(objOrdenCompra, usuario)
        End If

    End Sub

    Public Function anularCompra(ByVal objOrdenCompra As Compra,
                                 ByVal usuario As Integer) As Boolean
        If isTerminada(objOrdenCompra) Then
            objOrdenCompraDAL.anularCompra(objOrdenCompra, usuario)
            Return True
        End If
        Return False
    End Function
    Public Function isTerminada(ByRef objOrdenCompra As Compra) As Boolean
        Return objOrdenCompraDAL.isTerminada(objOrdenCompra)
    End Function
    Public Function ContadorProdcutos(ByRef tablaRef As DataTable) As Integer
        Return tablaRef.Select("Codigo <> ''").Count
    End Function
End Class

