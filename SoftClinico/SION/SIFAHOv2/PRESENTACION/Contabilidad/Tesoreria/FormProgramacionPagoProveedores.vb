Public Class FormProgramacionPagoProveedores
    Private consolidado As New PagoProveedorConsolidado
    Private programacionPago As New ProgramacionPagoProveedor

    Private Sub FormProgramacionPagoProveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)

        configurarPanelTotales()
    End Sub

    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)

        General.buscarElemento("PROC_PROGRAMACION_PROVEEDOR_BUSCAR",
                               params,
                               AddressOf cargarProgramacionProveedor,
                               "Programacion de Pagos",
                               False,
                               Constantes.TAMANO_MEDIANO, True)
    End Sub

    Private Sub cargarProgramacionProveedor(pCodigo As String)
        Dim dtProgramacionProveedor As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)


        General.llenarTabla("PROC_PROGRAMACION_PROVEEDOR_CARGAR",
                            params,
                            dtProgramacionProveedor)

        dgvFacturaProveedor.DataSource = dtProgramacionProveedor
        configurarDgvFactura(dgvFacturaProveedor)
        dgvFacturaProveedor.Columns("Pagado").Visible = False
        dgvFacturaProveedor.Columns("Medio Pago").Visible = False
        General.posBuscarForm(Me, ToolStrip1, btnuevo, bteditar, btanular, btbuscar)
        tsImprimir.Enabled = True
        programacionPago.codigoProgramacion = pCodigo
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)

        General.cargarCombo("PROC_PROGRAMACION_PROVEEDOR_LISTA_PP",
                            params,
                            "razon_social",
                            "id_proveedor",
                            cbProveedor)

        General.formNuevo(Me, ToolStrip1, Nothing, btcancelar)
    End Sub

    Private Sub cbProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProveedor.SelectedIndexChanged
        If cbProveedor.SelectedIndex = 0 Then
            Return
        End If

        Dim proveedor As New Proveedor()
        proveedor.idProveedor = cbProveedor.SelectedValue.ToString

        Dim dtProgramacionProveedor As New DataTable
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        params.Add(proveedor.idProveedor)

        General.llenarTabla("PROC_PROGRAMACION_PROVEEDOR_CREAR_NUEVA",
                            params,
                            dtProgramacionProveedor)

        dgvFacturaProveedor.DataSource = dtProgramacionProveedor
        configurarDgvFactura(dgvFacturaProveedor)
        dgvFacturaProveedor.Columns("Abono").ReadOnly = False
        dgvFacturaProveedor.Columns("Pagado").Visible = True
        'dgvFacturaProveedor.Columns("Id Proveedor").Visible = False
        'dgvFacturaProveedor.Columns("Medio Pago").Visible = False
        'dgvFacturaProveedor.Columns("Pagado").Visible = True


    End Sub


    Public Sub configurarDgvFactura(ByRef dgvFactura As DataGridView)

        dgvFacturaProveedor.AlternatingRowsDefaultCellStyle = Nothing
        General.setDgvColumnsReadonly(dgvFacturaProveedor)
        dgvFacturaProveedor.Columns("Id Proveedor").Visible = False
        dgvFacturaProveedor.Columns("Nit").Visible = False
        dgvFacturaProveedor.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvFacturaProveedor.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvFacturaProveedor.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvFacturaProveedor.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvFacturaProveedor.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvFacturaProveedor.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvFacturaProveedor.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvFacturaProveedor.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvFacturaProveedor.Columns(8).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvFacturaProveedor.Columns(9).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvFacturaProveedor.Columns(10).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvFacturaProveedor.Columns(11).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvFacturaProveedor.Columns(12).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvFacturaProveedor.Columns(13).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvFacturaProveedor.Columns(14).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvFacturaProveedor.Columns(15).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvFacturaProveedor.Columns(16).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvFacturaProveedor.Columns(17).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvFacturaProveedor.Columns(18).SortMode = DataGridViewColumnSortMode.NotSortable

        dgvFacturaProveedor.Columns("Nombre Proveedor").Width = 220
        dgvFacturaProveedor.Columns("Comprobante").Width = 180
        dgvFacturaProveedor.Columns("Observacion").Width = 400
        dgvFacturaProveedor.Columns("Nombre Proveedor").Frozen = True
        'dgvFacturaProveedor.Columns("Nit").Frozen = True

        aplicarFormatoDgv(dgvFactura)
        dgvFactura.ClearSelection()
        actualizarPanelTotales()
    End Sub

    Private Sub dgvFacturaProveedor_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvFacturaProveedor.CellFormatting

        'Se valida el desbordamiento de indice, esto se presenta cuando se da click sobre el encabezado de la grilla
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then
            Return
        End If

        Dim nombreColumna As String
        nombreColumna = dgvFacturaProveedor.Columns(e.ColumnIndex).Name

        Select Case nombreColumna
            Case "Valor Factura",
                 "Descuento",
                 "Total Notas",
                 "Total Comprobantes",
                 "Subtotal",
                 "Total",
                 "Abono"

                e.Value = Funciones.formatMoneda(e.Value.ToString)
        End Select

    End Sub

    Private Sub dgvFacturaProveedor_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvFacturaProveedor.CellPainting
        Dim indiceFilaActual As Integer = e.RowIndex
        Dim indiceColumnaActual As Integer = e.ColumnIndex
        Dim indiceUltimaFila As Integer = dgvFacturaProveedor.RowCount - 1
        Dim nombreColumna As String = dgvFacturaProveedor.Columns(indiceColumnaActual).Name

        'Se valida el desbordamiento de indice, esto se presenta cuando se da click sobre el encabezado de la grilla
        If indiceFilaActual < 0 Or indiceColumnaActual < 0 Then
            Return
        End If

        Select Case nombreColumna
            Case "Nombre Proveedor",
                 "Nit", "Total"

                e.CellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 8, FontStyle.Bold)
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                If e.Value.ToString = String.Empty AndAlso
                   indiceFilaActual < indiceUltimaFila AndAlso
                    dgvFacturaProveedor.Rows(e.RowIndex + 1).Cells("Nit").Value.ToString = String.Empty Then
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None
                    e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None
                ElseIf e.Value.ToString <> String.Empty AndAlso
                       indiceFilaActual < indiceUltimaFila AndAlso
                       dgvFacturaProveedor.Rows(e.RowIndex + 1).Cells("Nit").Value.ToString = String.Empty Then
                    e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None
                End If

        End Select

    End Sub

    'Alterna color para cada fila de la grilla
    'cada vez que aparezca un proveedor diferente
    Private Sub aplicarFormatoDgv(dgvGeneral As DataGridView)
        Dim colorA As Color = Color.FromArgb(253, 233, 217)
        Dim colorB As Color = Color.FromArgb(218, 238, 243)

        Dim dgvPrimeraFila = dgvFacturaProveedor.Rows(0)
        Dim nitUltimoProveedor As String = Funciones.castFromDbItem(dgvPrimeraFila.Cells("Nit").Value)

        consolidado = New PagoProveedorConsolidado()
        consolidado.numFacturas = dgvFacturaProveedor.RowCount
        For Each dgvFila As DataGridViewRow In dgvGeneral.Rows
            Dim colorActual As Color

            If dgvFila Is dgvPrimeraFila Then
                colorActual = colorA
            Else
                Dim nitActualProveedor As String = dgvFila.Cells("Nit").Value.ToString
                If nitActualProveedor <> String.Empty AndAlso nitActualProveedor <> nitUltimoProveedor Then
                    colorActual = If(colorActual = colorA, colorB, colorA)
                    nitUltimoProveedor = nitActualProveedor
                    consolidado.numProveedores += 1
                End If
            End If
            consolidado.totalFacturas += dgvFila.Cells("Subtotal").Value
            If IsNumeric(dgvFila.Cells("Abono").Value) Then
                consolidado.totalAbono += dgvFila.Cells("Abono").Value
            End If
            dgvFila.DefaultCellStyle.BackColor = colorActual
        Next

    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        General.formEditar(Me, ToolStrip1, Nothing, btcancelar)
        dgvFacturaProveedor.Columns("Pagado").Visible = True
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar) Then
            consolidado = New PagoProveedorConsolidado
            actualizarPanelTotales()
        End If
    End Sub

    Public Sub configurarPanelTotales()
        Dim sbpNumFacturas As New StatusBarPanel
        Dim sbpNumProveedores As New StatusBarPanel
        Dim sbpTotalFacturas As New StatusBarPanel
        Dim sbpTotalAbono As New StatusBarPanel
        Dim sbpTotalDiferencia As New StatusBarPanel

        sbpNumFacturas.AutoSize = StatusBarPanelAutoSize.Contents
        sbpNumFacturas.BorderStyle = StatusBarPanelBorderStyle.Raised

        sbpNumProveedores.AutoSize = StatusBarPanelAutoSize.Spring
        sbpNumProveedores.Alignment = HorizontalAlignment.Right

        sbpTotalFacturas.AutoSize = StatusBarPanelAutoSize.Contents
        sbpTotalAbono.AutoSize = StatusBarPanelAutoSize.Contents
        sbpTotalDiferencia.AutoSize = StatusBarPanelAutoSize.Contents

        sbTotales.Panels.Clear()
        sbTotales.Panels.Add(sbpNumFacturas)
        sbTotales.Panels.Add(sbpNumProveedores)
        sbTotales.Panels.Add(sbpTotalFacturas)
        sbTotales.Panels.Add(sbpTotalAbono)
        'sbTotales.Panels.Add(sbpTotalDiferencia)
        actualizarPanelTotales()

    End Sub

    Private Sub actualizarPanelTotales()
        sbTotales.Panels.Item(0).Text = "Facturas: " & consolidado.numFacturas
        sbTotales.Panels.Item(1).Text = "Proveedores: " & consolidado.numProveedores
        sbTotales.Panels.Item(2).Text = "Total: " & Funciones.formatMoneda(consolidado.totalFacturas)
        sbTotales.Panels.Item(3).Text = "T. Abono: " & Funciones.formatMoneda(consolidado.totalAbono)
        'sbTotales.Panels.Item(4).Text = consolidado.totalDiferencia
    End Sub

    Private Sub dgvFacturaProveedor_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFacturaProveedor.CellClick
        Dim esEditable As Boolean = Not btguardar.Enabled
        General.visualizarPanel(dgvFacturaProveedor, pnlObservacion, esEditable, txtObservacion, "Observacion")
    End Sub

    Private Sub txtObservacion_Leave(sender As Object, e As EventArgs) Handles txtObservacion.Leave
        Try
            If pnlObservacion.Visible = True Then
                pnlObservacion.Visible = False
                txtObservacion.Clear()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub dgvFacturaProveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvFacturaProveedor.KeyPress
        Dim esEditable As Boolean = Not btguardar.Enabled
        General.visualizarPanel(dgvFacturaProveedor, pnlObservacion, esEditable, txtObservacion, "Observacion")
    End Sub

    Private Sub dgvFacturaProveedor_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFacturaProveedor.CellContentClick
        If e.RowIndex = -1 OrElse e.ColumnIndex = -1 Then Return

        Dim columnaActual As DataGridViewColumn = dgvFacturaProveedor.Columns(e.ColumnIndex)
        Dim celdasFilaActual As DataGridViewCellCollection = dgvFacturaProveedor.CurrentRow.Cells
        Dim celdaActual As DataGridViewCell = celdasFilaActual(e.ColumnIndex)

        If columnaActual.Name = "Pagado" Then
            If celdaActual.Value <> 0 Then
                celdaActual.Value = 0
                consolidado.totalAbono -= celdasFilaActual("Abono").Value
                celdasFilaActual("Abono").Value = DBNull.Value
            Else
                celdaActual.Value = 1
                celdasFilaActual("Abono").Value = celdasFilaActual("Subtotal").Value
                consolidado.totalAbono += celdasFilaActual("Abono").Value
            End If
        End If

        btguardar.Enabled = existenFacturasSeleccionadas()
        actualizarPanelTotales()

    End Sub

    Private Sub dgvFacturaProveedor_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFacturaProveedor.CellEndEdit
        Dim celdasFilaActual As DataGridViewCellCollection = dgvFacturaProveedor.CurrentRow.Cells
        Dim celdaActual As DataGridViewCell = dgvFacturaProveedor.CurrentCell
        Dim abono As String = Funciones.castFromDbItem(celdasFilaActual("Abono").Value)
        Dim subtotal As String = Funciones.castFromDbItem(celdasFilaActual("Subtotal").Value)

        If Not IsNumeric(abono) OrElse celdaActual.Value = 0 Then
            celdaActual.Value = DBNull.Value
            celdasFilaActual("Pagado").Value = 0
        Else
            If CDbl(abono) >= CDbl(subtotal) Then
                celdasFilaActual("Abono").Value = celdasFilaActual("Subtotal").Value
                celdasFilaActual("Pagado").Value = 1
            Else
                celdasFilaActual("Pagado").Value = 2
            End If
        End If

        btguardar.Enabled = existenFacturasSeleccionadas()
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If FuncionesContables.verificarFecha(dtpFechaDoc.Value) Then
            MsgBox(Mensajes.PERIODO_CONTABLE_CERRADO, MsgBoxStyle.Critical)
            Return
        End If

        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Try
                Dim nuevaProgramacion As ProgramacionPagoProveedor
                nuevaProgramacion = crearProgramacion()

                ProgramacionPagoProveedorBLL.guardarProgramacion(nuevaProgramacion, dtFechaCorte.Value, dtpFechaDoc.Value)
                General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                cargarProgramacionProveedor(nuevaProgramacion.codigoProgramacion)
                tsImprimir.Enabled = True
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub

    Private Function crearProgramacion() As ProgramacionPagoProveedor
        Dim programacionPago As New ProgramacionPagoProveedor

        programacionPago.detalleProgramacion = dgvFacturaProveedor.DataSource
        programacionPago.codigoCuentaCredito = "110505"
        programacionPago.numeroCheque = "10"
        Return programacionPago
    End Function

    Private Function generarReporte() As rptProgramacionProveedores
        Cursor = Cursors.WaitCursor
        Dim rptProgramacion As New rptProgramacionProveedores

        Cursor = Cursors.WaitCursor
        rptProgramacion.SetParameterValue("IdEmpresa", SesionActual.idEmpresa)
        rptProgramacion.SetParameterValue("codigoProgramacion", programacionPago.codigoProgramacion)

        Cursor = Cursors.Default

        Return rptProgramacion

    End Function

    Public Function existenFacturasSeleccionadas() As Boolean
        Dim dtFacturaProveedor As DataTable = dgvFacturaProveedor.DataSource
        'dtFacturaProveedor.AcceptChanges()
        'aplicarFormatoDgv(dgvFacturaProveedor)

        Return dtFacturaProveedor.Select("Pagado=True", "").Count > 0
    End Function

    Private Sub dgvFacturaProveedor_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFacturaProveedor.CellLeave
        btguardar.Enabled = existenFacturasSeleccionadas()
    End Sub

    Private Sub tsImprimirHoja_Click(sender As Object, e As EventArgs) Handles tsImprimirHoja.Click
        If Not String.IsNullOrEmpty(programacionPago.codigoProgramacion) Then
            Try
                Dim nombreRpt As String = "Archivo de Transacciones"
                Dim dtReporte As New DataTable
                Dim params As New List(Of String)

                Cursor = Cursors.WaitCursor
                params.Add(programacionPago.codigoProgramacion)
                General.llenarTabla("PROC_PROGRAMACION_PROVEEDOR_REPORTE_LLENAR", params, dtReporte)
                Dim ruta As String = FuncionesExcel.exportarDataTable(dtReporte, nombreRpt)

                Process.Start(ruta)
            Catch ex As Exception
                General.manejoErrores(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        Else
            MsgBox(Mensajes.IMPOSIBLE_GUARDAR_NOMINA, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub ReportePDFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportePDFToolStripMenuItem.Click
        Funciones.getReporteNoFTP(generarReporte(), Nothing, "ProgramacionProveedor01")
    End Sub
End Class