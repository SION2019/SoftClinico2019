Public Class FormEstadisticasCartera
    Dim dt As New DataTable
    Dim idCliente As Integer
    Private Sub construirGrafica()
        Dim dif As Double
        llenarDatos(obtenerDatosGrafica(ComboConcepto.SelectedValue))
        For i = 0 To dt.Rows.Count - 1
            Chart1.Series.Add(dt.Rows(i).Item(3))
            Chart1.Series(i).IsValueShownAsLabel = True
            Chart1.Series(i).BorderWidth = 3
            Chart1.Series(i).Color = Color.SkyBlue
            Chart1.Series(i).Font = New Font(Me.Font.Name, 12, FontStyle.Regular)
            Chart1.Series(i).ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Next
        'Chart1.Series(0).Points(0).LabelBorderColor = Color.Yellow
        Chart1.Series(0).YValueMembers = dt.Columns(2).ColumnName.ToString
        Chart1.Series(0).XValueMember = dt.Columns(3).ColumnName.ToString
        Chart1.ChartAreas(0).AxisY2.Maximum = 100
        Chart1.Series(0).LabelFormat = "c"
        Chart1.DataSource = dt
        Label5.Text = Label5.Text & " " & dt.Rows(0).Item(1)
        porcentajeCartera.Text = porcentajeCartera.Text & " " & dt.Rows(0).Item(1)
        periodo.Text = periodo.Text & " " & Format(CDate(fechafinal.Text), "dd MMMM yyyy")
        Label2.Text = Math.Round(dt.Rows(dt.Rows.Count - 2).Item(2) * 100 / dt.Rows(dt.Rows.Count - 1).Item(2), 1) & "%"
        dif = dt.Rows(0).Item(2) - dt.Rows(0).Item(2)
        Label3.Text = Math.Round(dif * 100 / dt.Rows(0).Item(2), 1)
        If Label3.Text > 0 Then
            PictureBox2.Visible = False
            PictureBox3.Visible = True
        Else
            PictureBox3.Visible = True
            PictureBox2.Visible = False
        End If
        Label3.Text = Math.Round(dif * 100 / dt.Rows(0).Item(2), 1) & "%"

    End Sub
    Private Sub llenarDatos(consulta As String)
        Dim dtNuevo As New DataTable
        dt.Reset()
        Dim params As New List(Of String)
        params.Add(Format(CDate(fechainicio.Value), Constantes.FORMATO_FECHA_GEN))
        params.Add(Format(CDate(fechafinal.Value), Constantes.FORMATO_FECHA_GEN))
        params.Add(idCliente)
        General.llenarTabla(consulta, params, dtNuevo)
        dt = dtNuevo.Copy()

    End Sub
    Private Sub escogerEstiloGrafica(item As Integer)
        Select Case item
            Case 1
                Chart1.Series.Clear()
                construirGrafica()
            Case 2
                Chart1.Series.Clear()
                construirGraficaPuntos()
            Case 3
                Chart1.Series.Clear()
                Chart2.Series.Clear()
                construirGraficaProyeccion()
                construirGraficaComparativa()
        End Select
    End Sub
    Private Sub construirGraficaProyeccion()
        llenarDatos(obtenerDatosGrafica(ComboConcepto.SelectedValue))
        Chart1.DataBindTable(dt.DefaultView, dt.Columns(3).ColumnName.ToString)
        Chart1.DataSource = dt
        Chart1.Series(0).Palette = DataVisualization.Charting.ChartColorPalette.BrightPastel
        Chart1.Series(0).LabelFormat = "N"
    End Sub
    Private Function obtenerDatosGrafica(item As Integer)
        Dim htItemCmbox As New Hashtable
        htItemCmbox.Add(1, Consultas.HISTORICO_CARTERA_RECAUDO_VENTAS)
        htItemCmbox.Add(2, Consultas.FACTURACION_PARETO_CARTERA_EPS)
        htItemCmbox.Add(3, Consultas.EVALUACION_EPS_X_AÑOS)
        Return htItemCmbox.Item(item)
    End Function
    Private Sub construirGraficaComparativa()
        llenarDatos(Consultas.EVALUACION_EPS_X_MESES)
        If dt.Rows.Count > 0 Then
            Chart2.DataSource = Nothing
            Chart2.DataBindCrossTable(dt.DefaultView, dt.Columns(4).ColumnName.ToString, dt.Columns(2).ColumnName.ToString, dt.Columns(3).ColumnName.ToString, "")
            'Chart2.Series("porcentaje").BackHatchStyle = DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal
            For i = 0 To Chart2.Series.Count - 1
                Chart2.Series(i).IsValueShownAsLabel = True
                Chart2.Series(i).LabelFormat = "N"
                Chart2.Series(i).SmartLabelStyle.Enabled = False
                Chart2.Series(i).MarkerSize = -30
                Chart2.Series(i).LabelAngle = -90
            Next
            'Chart2.Series("porcentaje").IsValueShownAsLabel = True
            'Chart2.Series("porcentaje").YAxisType = DataVisualization.Charting.AxisType.Secondary
            'Chart2.Series("porcentaje").ChartType = DataVisualization.Charting.SeriesChartType.Line
            'Chart2.Series("porcentaje").LabelFormat = "#\%"
            'Chart2.Series("porcentaje").MarkerStyle = DataVisualization.Charting.MarkerStyle.Diamond
            'Chart2.Series("porcentaje").MarkerColor = Color.Red
            'Chart2.Series("porcentaje").BorderWidth = 2
            'Chart2.Series("porcentaje").MarkerSize = 10
            'Chart2.ChartAreas(0).AxisY2.LabelStyle.Format = "#\%"

        End If
    End Sub
    Private Sub construirGraficaPuntos()
        llenarDatos(obtenerDatosGrafica(ComboConcepto.SelectedValue))
        Chart1.DataBindTable(dt.DefaultView, dt.Columns(0).ColumnName.ToString)
            Chart1.DataSource = dt
            Chart1.Series(0).Palette = DataVisualization.Charting.ChartColorPalette.BrightPastel
            Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.Series(1).YAxisType = DataVisualization.Charting.AxisType.Secondary
            Chart1.Series(1).MarkerStyle = DataVisualization.Charting.MarkerStyle.Diamond
            Chart1.Series(1).MarkerColor = Color.Red
            Chart1.Series(1).Color = Color.Red
            Chart1.Series(1).BorderWidth = 2
            Chart1.Series(1).MarkerSize = 10
            Chart1.Series(0).LabelFormat = "N"
            Chart1.Series(1).LabelFormat = "#\%"
            Chart1.ChartAreas(0).AxisX.IntervalAutoMode = DataVisualization.Charting.IntervalAutoMode.VariableCount
            Chart1.Series(0).IsValueShownAsLabel = True
        Chart1.Series(1).IsValueShownAsLabel = True
    End Sub
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
        dtConcepto.Rows(1).Item("Nombre") = "Historico cartera Recaudo/Ventas"
        dtConcepto.Rows.Add()
        dtConcepto.Rows(2).Item("Codigo") = 2
        dtConcepto.Rows(2).Item("Nombre") = "Pareto facturacion clientes"
        dtConcepto.Rows.Add()
        dtConcepto.Rows(3).Item("Codigo") = 3
        dtConcepto.Rows(3).Item("Nombre") = "Evaluacion"
        ComboConcepto.DataSource = Nothing
        ComboConcepto.DataSource = dtConcepto
        ComboConcepto.DisplayMember = "Nombre"
        ComboConcepto.ValueMember = "Codigo"
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btBusquedaCuenta_Click(sender As Object, e As EventArgs) Handles btBusquedaCuenta.Click
        Dim params As New List(Of String)
        params.Add("")
        params.Add(SesionActual.idEmpresa)
        Dim consulta As String = ""
        consulta = Consultas.BUSQUEDA_CLIENTES
        General.buscarElemento(consulta,
                               params,
                               AddressOf cargarTercero,
                               TitulosForm.BUSQUEDA_TERCERO,
                               True, 0, True)

    End Sub
    Public Sub cargarTercero(pCodigo)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.TERCERO_CONTABILIDAD_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            idCliente = dt.Rows(0).Item("Id_tercero").ToString()
            textnombretercero.Text = dt.Rows(0).Item("Tercero").ToString()
        End If
    End Sub

    Private Sub FormEstadisticasCartera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCombo()
    End Sub

    Private Sub ComboConcepto_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboConcepto.SelectedValueChanged
        If ComboConcepto.SelectedIndex > 0 Then
            If ComboConcepto.SelectedValue = 3 Then
                btBusquedaCuenta.Visible = True
                textnombretercero.Visible = True
            Else
                btBusquedaCuenta.Visible = False
                textnombretercero.Visible = False
            End If
        End If
    End Sub

    Private Sub btGenerar_Click(sender As Object, e As EventArgs) Handles btGenerar.Click
        If ComboConcepto.SelectedValue = 0 Then
            MsgBox("Debe eligir un item de la lista", MsgBoxStyle.Exclamation)
            ComboConcepto.Focus()
        ElseIf (ComboConcepto.SelectedValue = 3 And textnombretercero.Text = "") Then
            MsgBox("Debe escoger un cliente", MsgBoxStyle.Exclamation)
            btBusquedaCuenta.Focus()
        ElseIf ComboConcepto.SelectedValue = 3 Then
            nombreInforme.Text = "EVALUCION " + textnombretercero.Text
            nombreInforme.Visible = True
            escogerEstiloGrafica(ComboConcepto.SelectedValue)
            PictureBox2.Visible = True
            PictureBox3.Visible = True
        Else
            nombreInforme.Text = ComboConcepto.Text
            nombreInforme.Visible = True
            escogerEstiloGrafica(ComboConcepto.SelectedValue)
            PictureBox2.Visible = True
            PictureBox3.Visible = True
        End If
    End Sub
End Class