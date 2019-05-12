Public Class Form_IndicadoresGraficoMortalidad
    Public Property objIndicadorGM As Indicadores
    Dim dt As DataTable = New DataTable
    Private Sub Form_IndicadoresGraficoMortalidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Lblindicador.Text = "% de Mortalidad" Then
            Lblindicador.Text = "Porcentaje de Mortalidad"
        End If
        LLenarDt("%(s)%", "-1", 0, 200)
        LLenarGraficoG()
        LLenarDt("%(s)%", "0", 0, 200)
        LLenarGraficoM()
        LLenarDt("%(s)%", "1", 0, 200)
        LLenarGraficoF()
    End Sub

    Private Sub TabControl1_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TabControl1.Selecting
        If TabControl1.SelectedIndex = 0 Then
            LLenarDt("%(s)%", "-1", 0, 200)
            LLenarGraficoG()
            LLenarDt("%(s)%", "0", 0, 200)
            LLenarGraficoM()
            LLenarDt("%(s)%", "1", 0, 200)
            LLenarGraficoF()
        ElseIf TabControl1.SelectedIndex = 1 Then
            LLenarDt("%mes(s)%", "-1", 0, 12)
            LLenarGraficoG()
            LLenarDt("%mes(s)%", "0", 0, 12)
            LLenarGraficoM()
            LLenarDt("%mes(s)%", "1", 0, 12)
            LLenarGraficoF()
        ElseIf TabControl1.SelectedIndex = 2 Then
            LLenarDt("%año(s)%", "-1", 1, 1)
            LLenarGraficoG()
            LLenarDt("%año(s)%", "0", 1, 1)
            LLenarGraficoM()
            LLenarDt("%año(s)%", "1", 1, 1)
            LLenarGraficoF()
        ElseIf TabControl1.SelectedIndex = 3 Then
            LLenarDt("%año(s)%", "-1", 2, 4)
            LLenarGraficoG()
            LLenarDt("%año(s)%", "0", 2, 4)
            LLenarGraficoM()
            LLenarDt("%año(s)%", "1", 2, 4)
            LLenarGraficoF()
        ElseIf TabControl1.SelectedIndex = 4 Then
            LLenarDt("%año(s)%", "-1", 5, 19)
            LLenarGraficoG()
            LLenarDt("%año(s)%", "0", 5, 19)
            LLenarGraficoM()
            LLenarDt("%año(s)%", "1", 5, 19)
            LLenarGraficoF()
        ElseIf TabControl1.SelectedIndex = 5 Then
            LLenarDt("%año(s)%", "-1", 20, 39)
            LLenarGraficoG()
            LLenarDt("%año(s)%", "0", 20, 39)
            LLenarGraficoM()
            LLenarDt("%año(s)%", "1", 20, 39)
            LLenarGraficoF()
        ElseIf TabControl1.SelectedIndex = 6 Then
            LLenarDt("%año(s)%", "-1", 40, 59)
            LLenarGraficoG()
            LLenarDt("%año(s)%", "0", 40, 59)
            LLenarGraficoM()
            LLenarDt("%año(s)%", "1", 40, 59)
            LLenarGraficoF()
        ElseIf TabControl1.SelectedIndex = 7 Then
            LLenarDt("%año(s)%", "-1", 60, 200)
            LLenarGraficoG()
            LLenarDt("%año(s)%", "0", 60, 200)
            LLenarGraficoM()
            LLenarDt("%año(s)%", "1", 60, 200)
            LLenarGraficoF()
        End If
    End Sub

    Public Sub LLenarDt(edadTexto As String, sexo As String, edadRI As Integer, edadRF As Integer)
        Dim param As New List(Of String)
        param.Add(LblAño.Text)
        param.Add(edadTexto)
        param.Add(sexo)
        param.Add(edadRI)
        param.Add(edadRF)
        General.llenarTabla(Consultas.CALCULAR_INDICADORES_MORTALIDAD, param, dt)
    End Sub
    Public Sub LLenarGraficoG()
        objIndicadorGM.dtGrafico.Reset()
        objIndicadorGM.dtGrafico.Columns.Add("Mes")
        objIndicadorGM.dtGrafico.Columns.Add("Resultado")
        objIndicadorGM.dtGrafico.Columns.Add("Meta")
        If LblPeriodo.Text = "Año" Then
            objIndicadorGM.dtGrafico.Rows.Add("Ene", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(0)), 20)
            objIndicadorGM.dtGrafico.Rows.Add("Feb", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(1)), 20)
            objIndicadorGM.dtGrafico.Rows.Add("Mar", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(2)), 20)
            objIndicadorGM.dtGrafico.Rows.Add("Abr", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(3)), 20)
            objIndicadorGM.dtGrafico.Rows.Add("May", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(4)), 20)
            objIndicadorGM.dtGrafico.Rows.Add("Jun", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(5)), 20)
            objIndicadorGM.dtGrafico.Rows.Add("Jul", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(6)), 20)
            objIndicadorGM.dtGrafico.Rows.Add("Ago", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(7)), 20)
            objIndicadorGM.dtGrafico.Rows.Add("Sep", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(8)), 20)
            objIndicadorGM.dtGrafico.Rows.Add("Oct", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(9)), 20)
            objIndicadorGM.dtGrafico.Rows.Add("Nov", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(10)), 20)
            objIndicadorGM.dtGrafico.Rows.Add("Dic", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(11)), 20)
        ElseIf LblPeriodo.Text = "Primer Semestre" Then
            objIndicadorGM.dtGrafico.Rows.Add("Ene", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(0)), 20)
            objIndicadorGM.dtGrafico.Rows.Add("Feb", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(1)), 20)
            objIndicadorGM.dtGrafico.Rows.Add("Mar", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(2)), 20)
            objIndicadorGM.dtGrafico.Rows.Add("Abr", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(3)), 20)
            objIndicadorGM.dtGrafico.Rows.Add("May", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(4)), 20)
            objIndicadorGM.dtGrafico.Rows.Add("Jun", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(5)), 20)
        ElseIf LblPeriodo.Text = "Segundo Semestre" Then
            objIndicadorGM.dtGrafico.Rows.Add("Jul", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(6)), 20)
            objIndicadorGM.dtGrafico.Rows.Add("Ago", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(7)), 20)
            objIndicadorGM.dtGrafico.Rows.Add("Sep", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(8)), 20)
            objIndicadorGM.dtGrafico.Rows.Add("Oct", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(9)), 20)
            objIndicadorGM.dtGrafico.Rows.Add("Nov", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(10)), 20)
            objIndicadorGM.dtGrafico.Rows.Add("Dic", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(11)), 20)
        End If
        If TabControl1.SelectedIndex = 0 Then
            Chart1.Series(2).Points.Add()
            Chart1.Series(0).Points.Add()
            Chart1.Series(2).IsValueShownAsLabel = True
            Chart1.Series(0).IsValueShownAsLabel = True
            Chart1.Series(1).IsVisibleInLegend = False
            Chart1.Series(2).BorderWidth = 3
            Chart1.Series(0).BorderWidth = 1
            Chart1.Series(2).Color = Color.Blue
            Chart1.Series(0).Color = Color.Red
            Chart1.Series(0).LegendText = "% Aceptable"
            Chart1.Series(0).XValueMember = "Mes"
            Chart1.Series(0).YValueMembers = "Meta"
            Chart1.Series(2).LegendText = "% " + "General"
            Chart1.Series(2).XValueMember = "Mes"
            Chart1.Series(2).YValueMembers = "Resultado"
            Chart1.DataSource = objIndicadorGM.dtGrafico
            Chart1.Series(0).LabelFormat = "#\%"
            Chart1.Series(1).LabelFormat = "#\%"
            Chart1.Series(2).LabelFormat = "#\%"
        ElseIf TabControl1.SelectedIndex = 1 Then
            Chart6.Series(2).Points.Add()
            Chart6.Series(2).IsValueShownAsLabel = True
            Chart6.Series(1).IsVisibleInLegend = False
            Chart6.Series(0).IsVisibleInLegend = False
            Chart6.Series(2).BorderWidth = 3
            Chart6.Series(2).Color = Color.Blue
            Chart6.Series(2).LegendText = "% " + "general"
            Chart6.Series(2).XValueMember = "Mes"
            Chart6.Series(2).YValueMembers = "Resultado"
            Chart6.DataSource = objIndicadorGM.dtGrafico
            Chart6.Series(1).LabelFormat = "#\%"
            Chart6.Series(2).LabelFormat = "#\%"
        ElseIf TabControl1.SelectedIndex = 2 Then
            Chart9.Series(2).Points.Add()
            Chart9.Series(2).IsValueShownAsLabel = True
            Chart9.Series(0).IsValueShownAsLabel = True
            Chart9.Series(1).IsVisibleInLegend = False
            Chart9.Series(0).IsVisibleInLegend = False
            Chart9.Series(2).BorderWidth = 3
            Chart9.Series(2).Color = Color.Blue
            Chart9.Series(2).LegendText = "% " + "general"
            Chart9.Series(2).XValueMember = "Mes"
            Chart9.Series(2).YValueMembers = "Resultado"
            Chart9.DataSource = objIndicadorGM.dtGrafico
            Chart9.Series(1).LabelFormat = "#\%"
            Chart9.Series(2).LabelFormat = "#\%"
        ElseIf TabControl1.SelectedIndex = 3 Then
            Chart12.Series(2).Points.Add()
            Chart12.Series(2).IsValueShownAsLabel = True
            Chart12.Series(0).IsValueShownAsLabel = True
            Chart12.Series(1).IsVisibleInLegend = False
            Chart12.Series(0).IsVisibleInLegend = False
            Chart12.Series(2).BorderWidth = 3
            Chart12.Series(2).Color = Color.Blue
            Chart12.Series(2).LegendText = "% " + "general"
            Chart12.Series(2).XValueMember = "Mes"
            Chart12.Series(2).YValueMembers = "Resultado"
            Chart12.DataSource = objIndicadorGM.dtGrafico
            Chart12.Series(1).LabelFormat = "#\%"
            Chart12.Series(2).LabelFormat = "#\%"
        ElseIf TabControl1.SelectedIndex = 4 Then
            Chart15.Series(2).Points.Add()
            Chart15.Series(2).IsValueShownAsLabel = True
            Chart15.Series(0).IsValueShownAsLabel = True
            Chart15.Series(1).IsVisibleInLegend = False
            Chart15.Series(0).IsVisibleInLegend = False
            Chart15.Series(2).BorderWidth = 3
            Chart15.Series(2).Color = Color.Blue
            Chart15.Series(2).LegendText = "% " + "general"
            Chart15.Series(2).XValueMember = "Mes"
            Chart15.Series(2).YValueMembers = "Resultado"
            Chart15.DataSource = objIndicadorGM.dtGrafico
            Chart15.Series(1).LabelFormat = "#\%"
            Chart15.Series(2).LabelFormat = "#\%"
        ElseIf TabControl1.SelectedIndex = 5 Then
            Chart18.Series(2).Points.Add()
            Chart18.Series(2).IsValueShownAsLabel = True
            Chart18.Series(0).IsValueShownAsLabel = True
            Chart18.Series(1).IsVisibleInLegend = False
            Chart18.Series(0).IsVisibleInLegend = False
            Chart18.Series(2).BorderWidth = 3
            Chart18.Series(2).Color = Color.Blue
            Chart18.Series(2).LegendText = "% " + "general"
            Chart18.Series(2).XValueMember = "Mes"
            Chart18.Series(2).YValueMembers = "Resultado"
            Chart18.DataSource = objIndicadorGM.dtGrafico
            Chart18.Series(1).LabelFormat = "#\%"
            Chart18.Series(2).LabelFormat = "#\%"
        ElseIf TabControl1.SelectedIndex = 6 Then
            Chart21.Series(2).Points.Add()
            Chart21.Series(2).IsValueShownAsLabel = True
            Chart21.Series(0).IsValueShownAsLabel = True
            Chart21.Series(1).IsVisibleInLegend = False
            Chart21.Series(0).IsVisibleInLegend = False
            Chart21.Series(2).BorderWidth = 3
            Chart21.Series(2).Color = Color.Blue
            Chart21.Series(2).LegendText = "% " + "general"
            Chart21.Series(2).XValueMember = "Mes"
            Chart21.Series(2).YValueMembers = "Resultado"
            Chart21.DataSource = objIndicadorGM.dtGrafico
            Chart21.Series(1).LabelFormat = "#\%"
            Chart21.Series(2).LabelFormat = "#\%"
        ElseIf TabControl1.SelectedIndex = 7 Then
            Chart24.Series(2).Points.Add()
            Chart24.Series(2).IsValueShownAsLabel = True
            Chart24.Series(0).IsValueShownAsLabel = True
            Chart24.Series(1).IsVisibleInLegend = False
            Chart24.Series(0).IsVisibleInLegend = False
            Chart24.Series(2).BorderWidth = 3
            Chart24.Series(2).Color = Color.Blue
            Chart24.Series(2).LegendText = "% " + "general"
            Chart24.Series(2).XValueMember = "Mes"
            Chart24.Series(2).YValueMembers = "Resultado"
            Chart24.DataSource = objIndicadorGM.dtGrafico
            Chart24.Series(1).LabelFormat = "#\%"
            Chart24.Series(2).LabelFormat = "#\%"
        End If
    End Sub
    Public Sub LLenarGraficoM()
        objIndicadorGM.dtGraficoM.Reset()
        objIndicadorGM.dtGraficoM.Columns.Add("Mes")
        objIndicadorGM.dtGraficoM.Columns.Add("Resultado")
        objIndicadorGM.dtGraficoM.Columns.Add("Meta")
        If LblPeriodo.Text = "Año" Then
            objIndicadorGM.dtGraficoM.Rows.Add("Ene", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(0)), 20)
            objIndicadorGM.dtGraficoM.Rows.Add("Feb", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(1)), 20)
            objIndicadorGM.dtGraficoM.Rows.Add("Mar", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(2)), 20)
            objIndicadorGM.dtGraficoM.Rows.Add("Abr", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(3)), 20)
            objIndicadorGM.dtGraficoM.Rows.Add("May", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(4)), 20)
            objIndicadorGM.dtGraficoM.Rows.Add("Jun", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(5)), 20)
            objIndicadorGM.dtGraficoM.Rows.Add("Jul", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(6)), 20)
            objIndicadorGM.dtGraficoM.Rows.Add("Ago", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(7)), 20)
            objIndicadorGM.dtGraficoM.Rows.Add("Sep", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(8)), 20)
            objIndicadorGM.dtGraficoM.Rows.Add("Oct", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(9)), 20)
            objIndicadorGM.dtGraficoM.Rows.Add("Nov", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(10)), 20)
            objIndicadorGM.dtGraficoM.Rows.Add("Dic", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(11)), 20)
        ElseIf LblPeriodo.Text = "Primer Semestre" Then
            objIndicadorGM.dtGraficoM.Rows.Add("Ene", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(0)), 20)
            objIndicadorGM.dtGraficoM.Rows.Add("Feb", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(1)), 20)
            objIndicadorGM.dtGraficoM.Rows.Add("Mar", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(2)), 20)
            objIndicadorGM.dtGraficoM.Rows.Add("Abr", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(3)), 20)
            objIndicadorGM.dtGraficoM.Rows.Add("May", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(4)), 20)
            objIndicadorGM.dtGraficoM.Rows.Add("Jun", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(5)), 20)
        ElseIf LblPeriodo.Text = "Segundo Semestre" Then
            objIndicadorGM.dtGraficoM.Rows.Add("Jul", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(6)), 20)
            objIndicadorGM.dtGraficoM.Rows.Add("Ago", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(7)), 20)
            objIndicadorGM.dtGraficoM.Rows.Add("Sep", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(8)), 20)
            objIndicadorGM.dtGraficoM.Rows.Add("Oct", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(9)), 20)
            objIndicadorGM.dtGraficoM.Rows.Add("Nov", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(10)), 20)
            objIndicadorGM.dtGraficoM.Rows.Add("Dic", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(11)), 20)
        End If
        If TabControl1.SelectedIndex = 0 Then
            Chart2.Series(2).Points.Add()
            Chart2.Series(2).IsValueShownAsLabel = True
            Chart2.Series(1).IsVisibleInLegend = False
            Chart2.Series(0).IsVisibleInLegend = False
            Chart2.Series(2).BorderWidth = 3
            Chart2.Series(2).Color = Color.Green
            Chart2.Series(2).LegendText = "% " + "Masculino"
            Chart2.Series(2).XValueMember = "Mes"
            Chart2.Series(2).YValueMembers = "Resultado"
            Chart2.DataSource = objIndicadorGM.dtGraficoM
            Chart2.Series(1).LabelFormat = "#\%"
            Chart2.Series(2).LabelFormat = "#\%"
        ElseIf TabControl1.SelectedIndex = 1 Then
            Chart5.Series(2).Points.Add()
            Chart5.Series(2).IsValueShownAsLabel = True
            Chart5.Series(1).IsVisibleInLegend = False
            Chart5.Series(0).IsVisibleInLegend = False
            Chart5.Series(2).BorderWidth = 3
            Chart5.Series(2).Color = Color.Green
            Chart5.Series(2).LegendText = "% " + "Masculino"
            Chart5.Series(2).XValueMember = "Mes"
            Chart5.Series(2).YValueMembers = "Resultado"
            Chart5.DataSource = objIndicadorGM.dtGraficoM
            Chart5.Series(1).LabelFormat = "#\%"
            Chart5.Series(2).LabelFormat = "#\%"
        ElseIf TabControl1.SelectedIndex = 2 Then
            Chart8.Series(2).Points.Add()
            Chart8.Series(2).IsValueShownAsLabel = True
            Chart8.Series(0).IsValueShownAsLabel = True
            Chart8.Series(1).IsVisibleInLegend = False
            Chart8.Series(0).IsVisibleInLegend = False
            Chart8.Series(2).BorderWidth = 3
            Chart8.Series(2).Color = Color.Green
            Chart8.Series(2).LegendText = "% " + "Masculino"
            Chart8.Series(2).XValueMember = "Mes"
            Chart8.Series(2).YValueMembers = "Resultado"
            Chart8.DataSource = objIndicadorGM.dtGraficoM
            Chart8.Series(1).LabelFormat = "#\%"
            Chart8.Series(2).LabelFormat = "#\%"
        ElseIf TabControl1.SelectedIndex = 3 Then
            Chart11.Series(2).Points.Add()
            Chart11.Series(2).IsValueShownAsLabel = True
            Chart11.Series(0).IsValueShownAsLabel = True
            Chart11.Series(1).IsVisibleInLegend = False
            Chart11.Series(0).IsVisibleInLegend = False
            Chart11.Series(2).BorderWidth = 3
            Chart11.Series(2).Color = Color.Green
            Chart11.Series(2).LegendText = "% " + "Masculino"
            Chart11.Series(2).XValueMember = "Mes"
            Chart11.Series(2).YValueMembers = "Resultado"
            Chart11.DataSource = objIndicadorGM.dtGraficoM
            Chart11.Series(1).LabelFormat = "#\%"
            Chart11.Series(2).LabelFormat = "#\%"
        ElseIf TabControl1.SelectedIndex = 4 Then
            Chart14.Series(2).Points.Add()
            Chart14.Series(2).IsValueShownAsLabel = True
            Chart14.Series(0).IsValueShownAsLabel = True
            Chart14.Series(1).IsVisibleInLegend = False
            Chart14.Series(0).IsVisibleInLegend = False
            Chart14.Series(2).BorderWidth = 3
            Chart14.Series(2).Color = Color.Green
            Chart14.Series(2).LegendText = "% " + "Masculino"
            Chart14.Series(2).XValueMember = "Mes"
            Chart14.Series(2).YValueMembers = "Resultado"
            Chart14.DataSource = objIndicadorGM.dtGraficoM
            Chart14.Series(1).LabelFormat = "#\%"
            Chart14.Series(2).LabelFormat = "#\%"
        ElseIf TabControl1.SelectedIndex = 5 Then
            Chart17.Series(2).Points.Add()
            Chart17.Series(2).IsValueShownAsLabel = True
            Chart17.Series(0).IsValueShownAsLabel = True
            Chart17.Series(1).IsVisibleInLegend = False
            Chart17.Series(0).IsVisibleInLegend = False
            Chart17.Series(2).BorderWidth = 3
            Chart17.Series(2).Color = Color.Green
            Chart17.Series(2).LegendText = "% " + "Masculino"
            Chart17.Series(2).XValueMember = "Mes"
            Chart17.Series(2).YValueMembers = "Resultado"
            Chart17.DataSource = objIndicadorGM.dtGraficoM
            Chart17.Series(1).LabelFormat = "#\%"
            Chart17.Series(2).LabelFormat = "#\%"
        ElseIf TabControl1.SelectedIndex = 6 Then
            Chart20.Series(2).Points.Add()
            Chart20.Series(2).IsValueShownAsLabel = True
            Chart20.Series(0).IsValueShownAsLabel = True
            Chart20.Series(1).IsVisibleInLegend = False
            Chart20.Series(0).IsVisibleInLegend = False
            Chart20.Series(2).BorderWidth = 3
            Chart20.Series(2).Color = Color.Green
            Chart20.Series(2).LegendText = "% " + "Masculino"
            Chart20.Series(2).XValueMember = "Mes"
            Chart20.Series(2).YValueMembers = "Resultado"
            Chart20.DataSource = objIndicadorGM.dtGraficoM
            Chart20.Series(1).LabelFormat = "#\%"
            Chart20.Series(2).LabelFormat = "#\%"
        ElseIf TabControl1.SelectedIndex = 7 Then
            Chart23.Series(2).Points.Add()
            Chart23.Series(2).IsValueShownAsLabel = True
            Chart23.Series(0).IsValueShownAsLabel = True
            Chart23.Series(1).IsVisibleInLegend = False
            Chart23.Series(0).IsVisibleInLegend = False
            Chart23.Series(2).BorderWidth = 3
            Chart23.Series(2).Color = Color.Green
            Chart23.Series(2).LegendText = "% " + "Masculino"
            Chart23.Series(2).XValueMember = "Mes"
            Chart23.Series(2).YValueMembers = "Resultado"
            Chart23.DataSource = objIndicadorGM.dtGraficoM
            Chart23.Series(1).LabelFormat = "#\%"
            Chart23.Series(2).LabelFormat = "#\%"
        End If

    End Sub
    Public Sub LLenarGraficoF()
        objIndicadorGM.dtGraficoF.Reset()
        objIndicadorGM.dtGraficoF.Columns.Add("Mes")
        objIndicadorGM.dtGraficoF.Columns.Add("Resultado")
        objIndicadorGM.dtGraficoF.Columns.Add("Meta")
        If LblPeriodo.Text = "Año" Then
            objIndicadorGM.dtGraficoF.Rows.Add("Ene", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(0)), 20)
            objIndicadorGM.dtGraficoF.Rows.Add("Feb", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(1)), 20)
            objIndicadorGM.dtGraficoF.Rows.Add("Mar", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(2)), 20)
            objIndicadorGM.dtGraficoF.Rows.Add("Abr", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(3)), 20)
            objIndicadorGM.dtGraficoF.Rows.Add("May", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(4)), 20)
            objIndicadorGM.dtGraficoF.Rows.Add("Jun", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(5)), 20)
            objIndicadorGM.dtGraficoF.Rows.Add("Jul", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(6)), 20)
            objIndicadorGM.dtGraficoF.Rows.Add("Ago", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(7)), 20)
            objIndicadorGM.dtGraficoF.Rows.Add("Sep", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(8)), 20)
            objIndicadorGM.dtGraficoF.Rows.Add("Oct", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(9)), 20)
            objIndicadorGM.dtGraficoF.Rows.Add("Nov", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(10)), 20)
            objIndicadorGM.dtGraficoF.Rows.Add("Dic", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(11)), 20)
        ElseIf LblPeriodo.Text = "Primer Semestre" Then
            objIndicadorGM.dtGraficoF.Rows.Add("Ene", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(0)), 20)
            objIndicadorGM.dtGraficoF.Rows.Add("Feb", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(1)), 20)
            objIndicadorGM.dtGraficoF.Rows.Add("Mar", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(2)), 20)
            objIndicadorGM.dtGraficoF.Rows.Add("Abr", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(3)), 20)
            objIndicadorGM.dtGraficoF.Rows.Add("May", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(4)), 20)
            objIndicadorGM.dtGraficoF.Rows.Add("Jun", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(5)), 20)
        ElseIf LblPeriodo.Text = "Segundo Semestre" Then
            objIndicadorGM.dtGraficoF.Rows.Add("Jul", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(6)), 20)
            objIndicadorGM.dtGraficoF.Rows.Add("Ago", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(7)), 20)
            objIndicadorGM.dtGraficoF.Rows.Add("Sep", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(8)), 20)
            objIndicadorGM.dtGraficoF.Rows.Add("Oct", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(9)), 20)
            objIndicadorGM.dtGraficoF.Rows.Add("Nov", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(10)), 20)
            objIndicadorGM.dtGraficoF.Rows.Add("Dic", If(dt.Rows.Count = 0, 0, dt.Rows(0).Item(11)), 20)
        End If
        If TabControl1.SelectedIndex = 0 Then
            Chart3.Series(2).Points.Add()
            Chart3.Series(2).IsValueShownAsLabel = True
            Chart3.Series(1).IsVisibleInLegend = False
            Chart3.Series(0).IsVisibleInLegend = False
            Chart3.Series(2).BorderWidth = 3
            Chart3.Series(2).Color = Color.LightCoral
            Chart3.Series(2).LegendText = "% " + "Femenino"
            Chart3.Series(2).XValueMember = "Mes"
            Chart3.Series(2).YValueMembers = "Resultado"
            Chart3.DataSource = objIndicadorGM.dtGraficoF
            Chart3.Series(1).LabelFormat = "#\%"
            Chart3.Series(2).LabelFormat = "#\%"
        ElseIf TabControl1.SelectedIndex = 1 Then
            Chart4.Series(2).Points.Add()
            Chart4.Series(2).IsValueShownAsLabel = True
            Chart4.Series(1).IsVisibleInLegend = False
            Chart4.Series(0).IsVisibleInLegend = False
            Chart4.Series(2).BorderWidth = 3
            Chart4.Series(2).Color = Color.LightCoral
            Chart4.Series(2).LegendText = "% " + "Femenino"
            Chart4.Series(2).XValueMember = "Mes"
            Chart4.Series(2).YValueMembers = "Resultado"
            Chart4.DataSource = objIndicadorGM.dtGraficoF
            Chart4.Series(1).LabelFormat = "#\%"
            Chart4.Series(2).LabelFormat = "#\%"
        ElseIf TabControl1.SelectedIndex = 2 Then
            Chart7.Series(2).Points.Add()
            Chart7.Series(2).IsValueShownAsLabel = True
            Chart7.Series(0).IsValueShownAsLabel = True
            Chart7.Series(1).IsVisibleInLegend = False
            Chart7.Series(0).IsVisibleInLegend = False
            Chart7.Series(2).BorderWidth = 3
            Chart7.Series(2).Color = Color.LightCoral
            Chart7.Series(2).LegendText = "% " + "Femenino"
            Chart7.Series(2).XValueMember = "Mes"
            Chart7.Series(2).YValueMembers = "Resultado"
            Chart7.DataSource = objIndicadorGM.dtGraficoF
            Chart7.Series(1).LabelFormat = "#\%"
            Chart7.Series(2).LabelFormat = "#\%"
        ElseIf TabControl1.SelectedIndex = 3 Then
            Chart10.Series(2).Points.Add()
            Chart10.Series(2).IsValueShownAsLabel = True
            Chart10.Series(0).IsValueShownAsLabel = True
            Chart10.Series(1).IsVisibleInLegend = False
            Chart10.Series(0).IsVisibleInLegend = False
            Chart10.Series(2).BorderWidth = 3
            Chart10.Series(2).Color = Color.LightCoral
            Chart10.Series(2).LegendText = "% " + "Femenino"
            Chart10.Series(2).XValueMember = "Mes"
            Chart10.Series(2).YValueMembers = "Resultado"
            Chart10.DataSource = objIndicadorGM.dtGraficoF
            Chart10.Series(1).LabelFormat = "#\%"
            Chart10.Series(2).LabelFormat = "#\%"
        ElseIf TabControl1.SelectedIndex = 4 Then
            Chart13.Series(2).Points.Add()
            Chart13.Series(2).IsValueShownAsLabel = True
            Chart13.Series(0).IsValueShownAsLabel = True
            Chart13.Series(1).IsVisibleInLegend = False
            Chart13.Series(0).IsVisibleInLegend = False
            Chart13.Series(2).BorderWidth = 3
            Chart13.Series(2).Color = Color.LightCoral
            Chart13.Series(2).LegendText = "% " + "Femenino"
            Chart13.Series(2).XValueMember = "Mes"
            Chart13.Series(2).YValueMembers = "Resultado"
            Chart13.DataSource = objIndicadorGM.dtGraficoF
            Chart13.Series(1).LabelFormat = "#\%"
            Chart13.Series(2).LabelFormat = "#\%"
        ElseIf TabControl1.SelectedIndex = 5 Then
            Chart16.Series(2).Points.Add()
            Chart16.Series(2).IsValueShownAsLabel = True
            Chart16.Series(0).IsValueShownAsLabel = True
            Chart16.Series(1).IsVisibleInLegend = False
            Chart16.Series(0).IsVisibleInLegend = False
            Chart16.Series(2).BorderWidth = 3
            Chart16.Series(2).Color = Color.LightCoral
            Chart16.Series(2).LegendText = "% " + "Femenino"
            Chart16.Series(2).XValueMember = "Mes"
            Chart16.Series(2).YValueMembers = "Resultado"
            Chart16.DataSource = objIndicadorGM.dtGraficoF
            Chart16.Series(1).LabelFormat = "#\%"
            Chart16.Series(2).LabelFormat = "#\%"
        ElseIf TabControl1.SelectedIndex = 6 Then
            Chart19.Series(2).Points.Add()
            Chart19.Series(2).IsValueShownAsLabel = True
            Chart19.Series(0).IsValueShownAsLabel = True
            Chart19.Series(1).IsVisibleInLegend = False
            Chart19.Series(0).IsVisibleInLegend = False
            Chart19.Series(2).BorderWidth = 3
            Chart19.Series(2).Color = Color.LightCoral
            Chart19.Series(2).LegendText = "% " + "Femenino"
            Chart19.Series(2).XValueMember = "Mes"
            Chart19.Series(2).YValueMembers = "Resultado"
            Chart19.DataSource = objIndicadorGM.dtGraficoF
            Chart19.Series(1).LabelFormat = "#\%"
            Chart19.Series(2).LabelFormat = "#\%"
        ElseIf TabControl1.SelectedIndex = 7 Then
            Chart22.Series(2).Points.Add()
            Chart22.Series(2).IsValueShownAsLabel = True
            Chart22.Series(0).IsValueShownAsLabel = True
            Chart22.Series(1).IsVisibleInLegend = False
            Chart22.Series(0).IsVisibleInLegend = False
            Chart22.Series(2).BorderWidth = 3
            Chart22.Series(2).Color = Color.LightCoral
            Chart22.Series(2).LegendText = "% " + "Femenino"
            Chart22.Series(2).XValueMember = "Mes"
            Chart22.Series(2).YValueMembers = "Resultado"
            Chart22.DataSource = objIndicadorGM.dtGraficoF
            Chart22.Series(1).LabelFormat = "#\%"
            Chart22.Series(2).LabelFormat = "#\%"
        End If
    End Sub
End Class