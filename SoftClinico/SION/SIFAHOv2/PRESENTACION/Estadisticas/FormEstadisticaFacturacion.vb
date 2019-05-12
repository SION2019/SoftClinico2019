Public Class FormEstadisticaFacturacion
    Dim dt As New DataTable
    Dim codigoEp As Integer
    Dim opcion As Integer
    Public Const PORCENTAJE_PARETO = 83
    Public Sub llenarCombo()
        Dim dtConcepto As New DataTable
        ComboConcepto.DataSource = Nothing
        dtConcepto.Columns.Add("Codigo")
        dtConcepto.Columns.Add("Nombre")
        dtConcepto.Rows.Add()
        dtConcepto.Rows(0).Item("Codigo") = 0
        dtConcepto.Rows(0).Item("Nombre") = "-- Seleccione --"
        dtConcepto.Rows.Add()
        dtConcepto.Rows(1).Item("Codigo") = 1
        dtConcepto.Rows(1).Item("Nombre") = "Ventas acumuladas"
        dtConcepto.Rows.Add()
        dtConcepto.Rows(2).Item("Codigo") = 2
        dtConcepto.Rows(2).Item("Nombre") = "Pareto ventas clientes"
        dtConcepto.Rows.Add()
        dtConcepto.Rows(3).Item("Codigo") = 3
        dtConcepto.Rows(3).Item("Nombre") = "Pareto ventas cliente por eventos"
        dtConcepto.Rows.Add()
        dtConcepto.Rows(4).Item("Codigo") = 4
        dtConcepto.Rows(4).Item("Nombre") = "ventas (frecuencia-severidad)"
        dtConcepto.Rows.Add()
        dtConcepto.Rows(5).Item("Codigo") = 5
        dtConcepto.Rows(5).Item("Nombre") = "ventas (frecuencia-severidad)por pacientes"
        dtConcepto.Rows.Add()
        dtConcepto.Rows(6).Item("Codigo") = 6
        dtConcepto.Rows(6).Item("Nombre") = "Variación y proyección por valor facturado"
        dtConcepto.Rows.Add()
        dtConcepto.Rows(7).Item("Codigo") = 7
        dtConcepto.Rows(7).Item("Nombre") = "Variación y proyección por número de facturas"
        dtConcepto.Rows.Add()
        dtConcepto.Rows(8).Item("Codigo") = 8
        dtConcepto.Rows(8).Item("Nombre") = "Promedio variación y proyección valor facturado por paciente"
        dtConcepto.Rows.Add()
        dtConcepto.Rows(9).Item("Codigo") = 9
        dtConcepto.Rows(9).Item("Nombre") = "Promedio ventas paciente comparativo mes"
        dtConcepto.Rows.Add()
        dtConcepto.Rows(10).Item("Codigo") = 10
        dtConcepto.Rows(10).Item("Nombre") = "Promedio ventas paciente comparativo mes por paciente"
        dtConcepto.Rows.Add()
        dtConcepto.Rows(11).Item("Codigo") = 11
        dtConcepto.Rows(11).Item("Nombre") = "Promedio ventas paciente comparativo mes por paciente dia"
        dtConcepto.Rows.Add()
        dtConcepto.Rows(12).Item("Codigo") = 12
        dtConcepto.Rows(12).Item("Nombre") = "Promedio ventas paciente por mes"
        dtConcepto.Rows.Add()
        dtConcepto.Rows(13).Item("Codigo") = 13
        dtConcepto.Rows(13).Item("Nombre") = "Promedio ventas paciente dia por mes"
        dtConcepto.Rows.Add()
        dtConcepto.Rows(14).Item("Codigo") = 14
        dtConcepto.Rows(14).Item("Nombre") = "Promedio de pacientes facturados por mes"
        dtConcepto.Rows.Add()
        dtConcepto.Rows(15).Item("Codigo") = 15
        dtConcepto.Rows(15).Item("Nombre") = "Promedio N° dias de estancia por mes"

        ComboConcepto.DataSource = Nothing
        ComboConcepto.DataSource = dtConcepto
        ComboConcepto.DisplayMember = "Nombre"
        ComboConcepto.ValueMember = "Codigo"
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Function obtenerDatosGrafica(item As Integer)
        Dim htItemCmbox As New Hashtable
        htItemCmbox.Add(1, Consultas.FACTURACION_ACUMULADA)
        htItemCmbox.Add(2, Consultas.FACTURACION_PARETO_FACTURACION_EPS)
        htItemCmbox.Add(3, Consultas.FACTURACION_PARETO_EVENTO_EPS)
        htItemCmbox.Add(4, Consultas.FACTURACION_FRECUENCIA_SEVERIDAD_VALOR)
        htItemCmbox.Add(5, Consultas.FACTURACION_FRECUENCIA_SEVERIDAD_VALOR_POR_PACIENTE)
        htItemCmbox.Add(6, Consultas.PROYECCION_VARIACION_FACTURAS_VALOR)
        htItemCmbox.Add(7, Consultas.PROYECCION_VARIACION_FACTURAS_EVENTOS)
        htItemCmbox.Add(8, Consultas.PROYECCION_VARIACION_FACTURAS_POR_PACIENTE)
        htItemCmbox.Add(9, Consultas.COMPARATIVO_PROMEDIO_MES_ACUMULADO)
        htItemCmbox.Add(10, Consultas.COMPARATIVO_PROMEDIO_MES_ACUMULADO_POR_PACIENTE)
        htItemCmbox.Add(11, Consultas.COMPARATIVO_PROMEDIO_MES_ACUMULADO_POR_PACIENTE_DIA)
        htItemCmbox.Add(12, Consultas.PROMEDIO_FACTURACION_PACIENTE_POR_MES)
        htItemCmbox.Add(13, Consultas.PROMEDIO_FACTURACION_ESTANCIA_DIA_POR_MES)
        htItemCmbox.Add(14, Consultas.PROMEDIO_FACTURACION_POR_EVENTOS_POR_MES)
        htItemCmbox.Add(15, Consultas.FACTURACION_COMPORTAMIENTO_PROMEDIO_DIA_MES)
        Return htItemCmbox.Item(item)
    End Function
    Private Sub construirGraficaProyeccion()
        llenarDatos(obtenerDatosGrafica(ComboConcepto.SelectedValue))
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                Chart1.Series.Add(dt.Rows(i).Item(1))
                Chart1.Series(i).IsValueShownAsLabel = True
                Chart1.Series(i).BorderWidth = 3
                Chart1.Series(i).LegendText = dt.Rows(i).Item(1)
                Chart1.Series(i).Font = New Font(Me.Font.Name, 9, FontStyle.Bold)
            Next
            Chart1.Series(0).Palette = DataVisualization.Charting.ChartColorPalette.BrightPastel
            Chart1.Series(0).XValueMember = dt.Columns(1).ColumnName.ToString
            Chart1.Series(0).YValueMembers = dt.Columns(2).ColumnName.ToString
            Chart1.Series(0).LabelFormat = "N0"
            Chart1.DataSource = dt
            Chart1.ChartAreas(0).AxisX.LabelStyle.Angle = 0
        End If
    End Sub
    Private Sub construirGraficaComparativa()
        llenarDatos(obtenerDatosGrafica(ComboConcepto.SelectedValue))
        If dt.Rows.Count > 0 Then
            Chart1.DataSource = Nothing
            Chart1.DataBindCrossTable(dt.DefaultView, dt.Columns(1).ColumnName.ToString, dt.Columns(3).ColumnName.ToString, dt.Columns(2).ColumnName.ToString, "")
            Chart1.Series("porcentaje").BackHatchStyle = DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal
            For i = 0 To Chart1.Series.Count - 1
                Chart1.Series(i).IsValueShownAsLabel = True
                Chart1.Series(i).LabelFormat = "N0"
                Chart1.Series(i).Font = New Font(Me.Font.Name, 9, FontStyle.Bold)
            Next
            Chart1.Series("porcentaje").IsValueShownAsLabel = True
            Chart1.Series("porcentaje").YAxisType = DataVisualization.Charting.AxisType.Secondary
            Chart1.Series("porcentaje").ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.Series("porcentaje").LabelFormat = "#\%"
            Chart1.Series("porcentaje").MarkerStyle = DataVisualization.Charting.MarkerStyle.Diamond
            Chart1.Series("porcentaje").MarkerColor = Color.OrangeRed
            Chart1.Series("porcentaje").Color = Color.OrangeRed
            Chart1.Series("porcentaje").LabelForeColor = Color.OrangeRed
            Chart1.Series("porcentaje").BorderWidth = 2
            Chart1.Series("porcentaje").MarkerSize = 10
            Chart1.ChartAreas(0).AxisY2.LabelStyle.Format = "#\%"
            Chart1.ChartAreas(0).AxisX.LabelStyle.Angle = 0
            Chart1.Series("porcentaje").Font = New Font(Me.Font.Name, 9, FontStyle.Bold)
        End If
    End Sub
    Private Sub construirGraficaPuntos()
        Dim valorItem As Int64
        Dim porcentaje As Int64
        Dim dtTorta As New DataTable
        Try
            llenarDatos(obtenerDatosGrafica(ComboConcepto.SelectedValue))
            If ComboConcepto.SelectedValue = 1 Then
                If dt.Rows.Count >= 2 Then
                    If dt.Rows.Count = 2 Then
                        dt.Rows.RemoveAt(1)
                    End If
                    Chart1.Series.Add(0)
                    Chart1.Series(0).YValueMembers = dt.Columns(1).ColumnName
                    'Chart1.ChartAreas(0).AxisY2.Maximum = 100
                    For i = 0 To dt.Rows.Count - 1
                        If i > 0 Then
                            Chart1.Series.Add(i)
                        End If
                        Chart1.Series(i).LegendText = dt.Rows(i).Item(0)
                        Chart1.Series(i).ChartType = DataVisualization.Charting.SeriesChartType.Column
                    Next
                    'Chart1.DataBindTable(dt.DefaultView, dt.Columns(0).ColumnName.ToString)
                    Chart1.DataSource = dt
                    Chart1.Series.Add("PORCENTAJE")
                    Chart1.Series("PORCENTAJE").YValueMembers = dt.Columns(2).ColumnName
                    Chart1.Series(0).Palette = DataVisualization.Charting.ChartColorPalette.BrightPastel
                    Chart1.Series("PORCENTAJE").ChartType = DataVisualization.Charting.SeriesChartType.Line
                    Chart1.Series("PORCENTAJE").YAxisType = DataVisualization.Charting.AxisType.Secondary
                    Chart1.Series("PORCENTAJE").MarkerStyle = DataVisualization.Charting.MarkerStyle.Diamond
                    Chart1.Series("PORCENTAJE").MarkerColor = Color.ForestGreen
                    Chart1.Series("PORCENTAJE").Color = Color.ForestGreen
                    Chart1.Series("PORCENTAJE").LabelForeColor = Color.DarkGreen
                    Chart1.Series("PORCENTAJE").BorderWidth = 2
                    Chart1.Series("PORCENTAJE").MarkerSize = 10
                    Chart1.Series(0).LabelFormat = "N0"
                    Chart1.Series("PORCENTAJE").LabelFormat = "#\%"
                    Chart1.ChartAreas(0).AxisX.IntervalAutoMode = DataVisualization.Charting.IntervalAutoMode.VariableCount
                    Chart1.Series(0).IsValueShownAsLabel = True
                    Chart1.Series("PORCENTAJE").IsValueShownAsLabel = True
                    Chart1.Series(0).Font = New Font(Me.Font.Name, 9, FontStyle.Bold)
                    Chart1.Series("PORCENTAJE").Font = New Font(Me.Font.Name, 9, FontStyle.Bold)
                Else
                    MsgBox("No existen valores para mostrar en esta fecha", MsgBoxStyle.Exclamation)
                End If
            ElseIf ComboConcepto.SelectedValue = 2 Or ComboConcepto.SelectedValue = 3 Then
                Dim valorPorcentaje As Int64
                Dim itemTorta As Int64
                Chart1.Series.Add(0)
                Chart1.Series(0).YValueMembers = dt.Columns(1).ColumnName
                'Chart1.ChartAreas(0).AxisY2.Maximum = 100
                For i = 0 To dt.Rows.Count - 1
                    If i > 0 Then
                        Chart1.Series.Add(i)
                    End If
                    Chart1.Series(i).LegendText = dt.Rows(i).Item(0)
                    Chart1.Series(i).ChartType = DataVisualization.Charting.SeriesChartType.Column

                    If dt.Rows(i).Item(2) < PORCENTAJE_PARETO Then
                        valorItem += dt.Rows(i).Item(1)
                        porcentaje = dt.Rows(i).Item(2)
                    End If
                Next
                dtTorta = dt.Clone
                dtTorta.Rows.Add()
                dtTorta.Rows(0).Item(0) = porcentaje & "%"
                dtTorta.Rows(0).Item(1) = valorItem
                dtTorta.Rows(0).Item(2) = porcentaje
                dtTorta.Rows.Add()
                valorPorcentaje = (dt.Rows(dt.Rows.Count - 1).Item(2) - porcentaje)
                itemTorta = dt.Rows(dt.Rows.Count - 1).Item(1)
                dtTorta.Rows(1).Item(0) = (dt.Rows(dt.Rows.Count - 1).Item(2) - porcentaje)
                dtTorta.Rows(1).Item(1) = itemTorta
                dtTorta.Rows(1).Item(2) = valorPorcentaje

                Chart1.DataSource = dt
                Chart1.Series.Add("ACUMULADO")
                Chart1.Series("ACUMULADO").YValueMembers = dt.Columns(2).ColumnName
                Chart1.Series(0).Palette = DataVisualization.Charting.ChartColorPalette.BrightPastel
                Chart1.Series("ACUMULADO").ChartType = DataVisualization.Charting.SeriesChartType.Line
                Chart1.Series("ACUMULADO").YAxisType = DataVisualization.Charting.AxisType.Secondary
                Chart1.Series("ACUMULADO").MarkerStyle = DataVisualization.Charting.MarkerStyle.Diamond
                Chart1.Series("ACUMULADO").MarkerColor = Color.ForestGreen
                Chart1.Series("ACUMULADO").Color = Color.ForestGreen
                Chart1.Series("ACUMULADO").LabelForeColor = Color.ForestGreen
                Chart1.Series("ACUMULADO").BorderWidth = 2
                Chart1.Series("ACUMULADO").MarkerSize = 10
                Chart1.Series(0).LabelFormat = "N0"
                Chart1.ChartAreas(0).AxisX.IntervalAutoMode = DataVisualization.Charting.IntervalAutoMode.VariableCount

                Chart1.Series("ACUMULADO").LabelFormat = "#\%"
                Chart1.Series(0).IsValueShownAsLabel = True
                Chart1.Series("ACUMULADO").IsValueShownAsLabel = True
                Chart1.Series(0).Font = New Font(Me.Font.Name, 9, FontStyle.Bold)
                Chart1.Series("ACUMULADO").Font = New Font(Me.Font.Name, 9, FontStyle.Bold)

                Chart2.Series(0).IsValueShownAsLabel = True
                Chart2.Series(0).YValueMembers = "Total"
                Chart2.DataSource = dtTorta
                Chart2.Series(0).XValueMember = "Acumulado"
                Chart2.Series(0).XValueType = DataVisualization.Charting.ChartValueType.Auto
                Chart2.Series(0).LabelFormat = "N0"
                Chart2.Series(0).Font = New Font(Me.Font.Name, 9, FontStyle.Bold)
            Else
                Chart1.Series.Add(0)
                Chart1.Series(0).YValueMembers = dt.Columns(1).ColumnName
                'Chart1.ChartAreas(0).AxisY2.Maximum = 100
                For i = 0 To dt.Rows.Count - 1
                    If i > 0 Then
                        Chart1.Series.Add(i)
                    End If
                    Chart1.Series(i).LegendText = dt.Rows(i).Item(0)
                    Chart1.Series(i).ChartType = DataVisualization.Charting.SeriesChartType.Column

                Next
                Chart1.DataSource = dt
                Chart1.Series.Add("ACUMULADO")
                Chart1.Series("ACUMULADO").YValueMembers = dt.Columns(2).ColumnName
                Chart1.Series(0).Palette = DataVisualization.Charting.ChartColorPalette.BrightPastel
                Chart1.Series("ACUMULADO").ChartType = DataVisualization.Charting.SeriesChartType.Line
                Chart1.Series("ACUMULADO").YAxisType = DataVisualization.Charting.AxisType.Secondary
                Chart1.Series("ACUMULADO").MarkerStyle = DataVisualization.Charting.MarkerStyle.Diamond
                Chart1.Series("ACUMULADO").MarkerColor = Color.ForestGreen
                Chart1.Series("ACUMULADO").Color = Color.ForestGreen
                Chart1.Series("ACUMULADO").LabelForeColor = Color.ForestGreen
                Chart1.Series("ACUMULADO").BorderWidth = 2
                Chart1.Series("ACUMULADO").MarkerSize = 10
                Chart1.Series(0).LabelFormat = "N0"
                Chart1.ChartAreas(0).AxisX.IntervalAutoMode = DataVisualization.Charting.IntervalAutoMode.VariableCount
                Chart1.Series("ACUMULADO").LabelFormat = "#"
                Chart1.Series(0).IsValueShownAsLabel = True
                Chart1.Series("ACUMULADO").IsValueShownAsLabel = True
                Chart1.Series(0).Font = New Font(Me.Font.Name, 9, FontStyle.Bold)
                Chart1.Series("ACUMULADO").Font = New Font(Me.Font.Name, 9, FontStyle.Bold)
                Chart1.Series(0).SmartLabelStyle.Enabled = False
                Chart1.Series(0).LabelAngle = -90
            End If
            Chart1.ChartAreas(0).AxisY2.Maximum = IIf(dt.Rows(0).Item(2) > 100, dt.Rows(0).Item(2) + (dt.Rows(0).Item(2) * 0.2), 100)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub llenarDatos(consulta As String)
        Dim dtNuevo As New DataTable
        dt.Reset()
        Dim params As New List(Of String)
        params.Add(Format(CDate(fechainicio.Value), Constantes.FORMATO_FECHA_GEN))
        params.Add(Format(CDate(fechafinal.Value), Constantes.FORMATO_FECHA_GEN))
        params.Add(codigoEp)
        params.Add(opcion)
        General.llenarTabla(consulta, params, dtNuevo)
        If ComboConcepto.SelectedValue >= 9 And ComboConcepto.SelectedValue <= 11 Then
            If Math.Round(dtNuevo.Rows(0).Item(2)) = Math.Round(dtNuevo.Rows(dtNuevo.Rows.Count - 3).Item(2)) Then
                For i = 0 To dtNuevo.Rows.Count - 1
                    If dtNuevo.Rows(i).Item("Area") = "UCI TOTAL" Then
                        dtNuevo.Rows(i).Delete()
                    End If
                Next
                dtNuevo.AcceptChanges()
            End If
        End If
        dt = dtNuevo.Copy()
        Chart1.Series.Clear()
    End Sub
    Private Sub construirGraficaMatrix()
        llenarDatos(obtenerDatosGrafica(ComboConcepto.SelectedValue))
        Chart1.ResetAutoValues()
        Chart1.DataBindCrossTable(dt.DefaultView, dt.Columns(1).ColumnName.ToString, dt.Columns(3).ColumnName.ToString, dt.Columns(2).ColumnName.ToString, "")
        Chart1.Series(0).BackHatchStyle = DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal
        For i = 0 To Chart1.Series.Count - 1
            Chart1.Series(i).IsValueShownAsLabel = True
            Chart1.Series(i).SmartLabelStyle.Enabled = False
            Chart1.Series(i).LabelAngle = -90
            Chart1.Series(i).Font = New Font(Me.Font.Name, 9, FontStyle.Bold)
            Chart1.Series(i).LabelForeColor = Color.Black
            Chart1.Series(i).LabelFormat = "N0"
        Next
        Chart1.ChartAreas(0).AxisY.LabelStyle.Format = "N0"
    End Sub
    'Private Sub construirGraficaCirculos()
    '    llenarDatos(obtenerDatosGrafica(ComboConcepto.SelectedValue))
    '    For i = 0 To dt.Rows.Count - 1
    ''        Chart1.Series.Add(dt.Rows(i).Item(1))
    '        Chart1.Series(i).IsValueShownAsLabel = True
    '        Chart1.Series(i).BorderWidth = 3
    '        Chart1.Series(i).Color = Color.Blue
    '        Chart1.Series(i).LegendText = dt.Rows(i).Item(1)
    '        Chart1.Series(i).Font = New Font(Me.Font.Name, 12, FontStyle.Regular)
    '        Chart1.Series(i).ChartType = DataVisualization.Charting.SeriesChartType.Line
    '        Chart1.Series(i).MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
    '        Chart1.Series(i).MarkerColor = Color.Red
    '        Chart1.Series(i).MarkerSize = 10
    '    Next
    '    Chart1.Series(0).XValueMember = dt.Columns(1).ColumnName.ToString
    '    Chart1.Series(0).YValueMembers = dt.Columns(2).ColumnName.ToString
    '    Chart1.Series(0).LabelFormat = "N0"
    '    Chart1.DataSource = dt
    'End Sub
    Private Sub ComboConcepto_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboConcepto.SelectedValueChanged
        If ComboConcepto.SelectedIndex > 0 Then
            obtenerDatosGrafica(ComboConcepto.SelectedValue)
            nombreInforme.Visible = False
            EstablecerRangoFecha(ComboConcepto.SelectedValue)
        End If
    End Sub
    Private Sub escogerEstiloGrafica(item As Integer)
        Select Case item
            Case 1 To 5
                construirGraficaPuntos()
            Case 6 To 8
                construirGraficaProyeccion()
            Case 9 To 11
                construirGraficaComparativa()
            Case Else
                construirGraficaMatrix()
        End Select
    End Sub
    Private Sub EstablecerRangoFecha(item As Integer)
        Dim primerDia As Date = "01-01-" & fechafinal.Value.Year
        Dim anhoAnterior As Date = "01-01-" & fechafinal.Value.Year - 1
        Select Case item
            Case 1
                fechainicio.Value = "01-01-2011"
            Case 2 To 5
                fechainicio.Value = primerDia
            Case 6 To 8
                fechainicio.Value = anhoAnterior
            Case 9 To 11
                fechainicio.Value = anhoAnterior
            Case Else
                fechainicio.Value = primerDia
        End Select
    End Sub
    Private Sub btGenerar_Click(sender As Object, e As EventArgs) Handles btGenerar.Click
        Cursor = Cursors.WaitCursor
        If ComboConcepto.SelectedValue = 0 Then
            MsgBox("Debe eligir un item de la lista", MsgBoxStyle.Exclamation)
            ComboConcepto.Focus()
        ElseIf (ComboConcepto.SelectedValue > 5 And ComboConcepto.SelectedValue < 9) And fechainicio.Value.Year = fechafinal.Value.Year Then
            MsgBox("El año de fecha inicial y fecha final no debe ser igual", MsgBoxStyle.Exclamation)
            fechainicio.Focus()
        ElseIf fechainicio.Value >= fechafinal.Value Then
            MsgBox("La fecha final no debe de ser Igual o menor a la fecha Inicio", MsgBoxStyle.Exclamation)
        Else
            nombreInforme.Visible = True
            If ComboConcepto.SelectedValue = 1 Or ComboConcepto.SelectedValue = 7 Or ComboConcepto.SelectedValue = 8 Or ComboConcepto.SelectedValue = 9 Then
                nombreInforme.Text = ComboConcepto.Text & " por UEN de " & Format(fechainicio.Value, "MMMM  yyyy") & " a " & Format(fechafinal.Value, "MMMM  yyyy") & " expresado en 000"
            ElseIf ComboConcepto.SelectedValue = 14 Or ComboConcepto.SelectedValue = 15 Or ComboConcepto.SelectedValue = 2 Or ComboConcepto.SelectedValue = 3 Or ComboConcepto.SelectedValue = 4 Or ComboConcepto.SelectedValue = 5 Then
                nombreInforme.Text = ComboConcepto.Text & " de " & Format(fechainicio.Value, "MMMM  yyyy") & " a " & Format(fechafinal.Value, "MMMM  yyyy")
            ElseIf ComboConcepto.SelectedValue = 6 Or ComboConcepto.SelectedValue = 7 Or ComboConcepto.SelectedValue = 8 Then
                nombreInforme.Text = ComboConcepto.Text & " " & Format(fechainicio.Value, "yyyy") & " VS " & Format(fechafinal.Value, "yyyy")
            Else
                nombreInforme.Text = ComboConcepto.Text & " de " & Format(fechainicio.Value, "MMMM  yyyy") & " a " & Format(fechafinal.Value, "MMMM  yyyy")
            End If
            escogerEstiloGrafica(ComboConcepto.SelectedValue)
        End If
        If ComboConcepto.SelectedValue = 2 Or ComboConcepto.SelectedValue = 3 Then
            Chart2.Visible = True
            porcentaje1.Visible = True
            porcentaje2.Visible = True
        Else
            Chart2.Visible = False
            porcentaje1.Visible = False
            porcentaje2.Visible = False
        End If
        Cursor = Cursors.Default
    End Sub
    Private Sub rbSabanalarga_CheckedChanged(sender As Object, e As EventArgs) Handles rbSabanalarga.CheckedChanged
        If rbSabanalarga.Checked = True Then
            codigoEp = 4
            opcion = 1
        End If
    End Sub
    Private Sub rbSede50_CheckedChanged(sender As Object, e As EventArgs) Handles rbSede50.CheckedChanged
        If rbSede50.Checked = True Then
            codigoEp = 5
            opcion = 2
        End If
    End Sub
    Private Sub FormEstadisticaFacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCombo()
    End Sub

    Private Sub rbConsolidado_CheckedChanged(sender As Object, e As EventArgs) Handles rbConsolidado.CheckedChanged
        codigoEp = 4
        opcion = 3
    End Sub
End Class