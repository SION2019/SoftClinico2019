Public Class ConsolidadoComidasBLL
    Public Sub enlazardgv(ByRef dgv As DataGridView,
                             ByRef dt As DataTable,
                             ByVal parasm As List(Of String))

        With dgv
            .Columns(parasm.Item(0)).DataPropertyName = "Nombre"
            .Columns(parasm.Item(0)).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(parasm.Item(1)).DataPropertyName = "Cantidad"
            .Columns(parasm.Item(1)).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(parasm.Item(2)).DataPropertyName = "Valor"
            .Columns(parasm.Item(2)).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(parasm.Item(3)).DataPropertyName = "Valor_total"
            .Columns(parasm.Item(3)).SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .AutoGenerateColumns = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .DataSource = dt
        End With
    End Sub
    Public Sub guardar(ByVal objConsolidadoComida As ConsolidadoComida, ByVal usuario As String)
        Dim objConsolidadoComidaMod As New ConsolidadoComidaDAL
        objConsolidadoComidaMod.guardar(objConsolidadoComida, usuario)
    End Sub


End Class
