Public Class Form_IndicadoresGrafico
    Public Property objIndicadorG As Indicadores
    Private Sub Form_IndicadoresGrafico_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Lblindicador.Text = "% de Mortalidad" Then
            Lblindicador.Text = "Porcentaje de Mortalidad"
        ElseIf Lblindicador.Text = "% de Desocupación" Then
            Lblindicador.Text = "Porcentaje de Desocupacion"
        ElseIf Lblindicador.Text = "% de Ocupación" Then
            Lblindicador.Text = "Porcentaje de Ocupación"
        End If
        If Lblindicador.Text = "Porcentaje de Ocupación" Or Lblindicador.Text = "Porcentaje de Desocupacion" Or Lblindicador.Text = "Porcentaje de Mortalidad" Then
            Chart1.Series(0).Points.Add()
            Chart1.Series(1).Points.Add()
            Chart1.Series(2).Points.Add()
            Chart1.Series(1).IsValueShownAsLabel = True
            Chart1.Series(1).Color = Color.Orange
            Chart1.Series(0).IsValueShownAsLabel = True
            Chart1.Series(2).Color = Color.Green
            Chart1.Series(2).IsValueShownAsLabel = True
            Chart1.Series(2).BorderWidth = 5
            Chart1.Series(0).BorderWidth = 3
            Chart1.Series(1).BorderWidth = 3
            Chart1.Series(0).Color = Color.Red
            Chart1.Series(2).LegendText = Lblindicador.Text
            Chart1.Series(2).XValueMember = "Mes"
            Chart1.Series(2).YValueMembers = "Resultado"
            Chart1.Series(0).LegendText = "Meta Óptima"
            Chart1.Series(0).XValueMember = "Mes"
            Chart1.Series(0).YValueMembers = "Meta Óptima"
            Chart1.Series(1).LegendText = "Meta Mínima Aceptable"
            Chart1.Series(1).XValueMember = "Mes"
            Chart1.Series(1).YValueMembers = "Meta Mínima Aceptable"
            Chart1.Series(0).LabelFormat = "#\%"
            Chart1.Series(1).LabelFormat = "#\%"
            Chart1.Series(2).LabelFormat = "#\%"
            If Lblindicador.Text = "Porcentaje de Desocupación" Or Lblindicador.Text = "Porcentaje de Mortalidad" Then
                Chart1.Series(1).LegendText = "Meta Máxima Aceptable"

            End If
        Else
            Chart1.Series(0).Points.Add()
            Chart1.Series(1).Points.Add()
            Chart1.Series(0).IsValueShownAsLabel = True
            Chart1.Series(1).Color = Color.Green
            Chart1.Series(1).IsValueShownAsLabel = True
            Chart1.Series(1).BorderWidth = 5
            Chart1.Series(0).BorderWidth = 3
            Chart1.Series(0).Color = Color.Red
            Chart1.Series(1).LegendText = Lblindicador.Text
            Chart1.Series(2).IsVisibleInLegend = False
            Chart1.Series(1).XValueMember = "Mes"
            Chart1.Series(1).YValueMembers = "Resultado"
            Chart1.Series(1).MarkerStyle = DataVisualization.Charting.MarkerStyle.Diamond
            Chart1.Series(1).MarkerStep = 1
            Chart1.Series(1).MarkerSize = 6
            Chart1.Series(0).LegendText = "Meta Óptima"
            Chart1.Series(0).XValueMember = "Mes"
            Chart1.Series(0).YValueMembers = "Meta Óptima"
        End If
        Chart1.DataSource = objIndicadorG.dtGrafico
    End Sub


End Class