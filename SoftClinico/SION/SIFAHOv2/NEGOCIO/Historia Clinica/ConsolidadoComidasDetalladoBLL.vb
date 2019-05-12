Public Class ConsolidadoComidasDetalladoBLL
    Public Sub guardar(objConsolidadoComidaDetallado As ConsolidadoComidaDetallado)
        Dim objConsolidadoComidaDetalladoDAL As New ConsolidadoComidaDetalladoDAL
        objConsolidadoComidaDetalladoDAL.Guardar(objConsolidadoComidaDetallado)
    End Sub

    Public Sub enlazarDgv(ByRef objConsolidadoComidasDetallado As ConsolidadoComidaDetallado,
                          ByRef dgv As DataGridView)

        With dgv
            .Columns("Area").DataPropertyName = "Area"
            .Columns("Area").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Fecha").DataPropertyName = "Fecha"
            .Columns("Fecha").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DesayunoA").DataPropertyName = "CantidadD"
            .Columns("DesayunoA").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DesayunoA").Width = 60
            .Columns("AlmuerzoA").DataPropertyName = "cantidadA"
            .Columns("AlmuerzoA").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("AlmuerzoA").Width = 60
            .Columns("CenaA").DataPropertyName = "cantidadC"
            .Columns("CenaA").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CenaA").Width = 60

            .ReadOnly = True
            .AutoGenerateColumns = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7)
            .DataSource = objConsolidadoComidasDetallado.tblDetalleDias
        End With

    End Sub
End Class
