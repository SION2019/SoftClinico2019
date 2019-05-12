Public Class Form_Indicadores
    Dim thisDay As DateTime = DateTime.Today
    Dim anho = thisDay.Year
    Dim objIndicador As New Indicadores
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function

    Private Sub Form_Indicadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With dgvIndicadores
            .Columns.Add("Nombre", "Nombre")
            .Columns.Add("Meta", "Meta")
            .Columns.Add("EneRes", "Resultado")
            .Columns.Add("EneBre", "Brecha")
            .Columns.Add("FebRes", "Resultado")
            .Columns.Add("FebBre", "Brecha")
            .Columns.Add("MarRes", "Resultado")
            .Columns.Add("MarBre", "Brecha")
            .Columns.Add("AbrRes", "Resultado")
            .Columns.Add("AbrBre", "Brecha")
            .Columns.Add("MayRes", "Resultado")
            .Columns.Add("MayBre", "Brecha")
            .Columns.Add("JunRes", "Resultado")
            .Columns.Add("JunBre", "Brecha")
            .Columns.Add("JulRes", "Resultado")
            .Columns.Add("JulBre", "Brecha")
            .Columns.Add("AgoRes", "Resultado")
            .Columns.Add("AgoBre", "Brecha")
            .Columns.Add("SepRes", "Resultado")
            .Columns.Add("SepBre", "Brecha")
            .Columns.Add("OctRes", "Resultado")
            .Columns.Add("OctBre", "Brecha")
            .Columns.Add("NovRes", "Resultado")
            .Columns.Add("NovBre", "Brecha")
            .Columns.Add("DicRes", "Resultado")
            .Columns.Add("DicBre", "Brecha")
            .Columns.Add("Tmetas", "Meta")
            .Columns.Add("TmRes", "Resultado")
            .Columns.Add("TmBre", "Brecha")
            Dim Boton As DataGridViewButtonColumn = New DataGridViewButtonColumn()
            .Columns.Add(Boton)
            Boton.HeaderText = "Graficas"
            Boton.Name = "Ver"
            For j As Integer = 1 To .Columns.Count - 1
                .Columns(j).Width = 100
            Next
            .Columns(0).Width = 250
            .Columns(29).Width = 70
            .Columns(0).Frozen = True
            .Columns(1).Frozen = True
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        End With
        AjustarPropiedadesGrid()
        enlazarDgvIndicadores()
        Me.rdbSemestre1.Checked = True
        Me.rdbGlobal.Checked = True
        objIndicador.CAP = 0
        cargarAños()
        General.cargarCombo(Consultas.PERFIL_PARACLINICO_AREA_SERVICIO_BUSCAR, "Descripcion", "Codigo", cmbArea)
        If cmbArea.SelectedIndex >= 0 Then
            llenadDgvindicadores()
        End If
        cargarCapacidades()
        PictureBox2.Image = Global.Celer.My.Resources.Resources.medical_bed_icon
        PictureBox3.Image = Global.Celer.My.Resources.Resources.medical_bed_icon
        PictureBox4.Image = Global.Celer.My.Resources.Resources.ley
    End Sub
    Sub cargarAños()
        Dim dtAño As New DataTable
        Dim i As Integer
        dtAño.Columns.Add("Año")
        For i = anho To 2014 Step -1
            dtAño.Rows.Add(i)
        Next
        cmbAño.DataSource = Nothing
        cmbAño.DataSource = dtAño
        cmbAño.DisplayMember = "Año"
    End Sub
    Public Sub enlazarDgvIndicadores()
        With dgvIndicadores
            .Columns("Nombre").DataPropertyName = "Nombre"
            .Columns("Meta").DataPropertyName = "Meta"
            .Columns("EneRes").DataPropertyName = "Resultado1"
            .Columns("EneBre").DataPropertyName = "Brecha1"
            .Columns("FebRes").DataPropertyName = "Resultado2"
            .Columns("FebBre").DataPropertyName = "Brecha2"
            .Columns("MarRes").DataPropertyName = "Resultado3"
            .Columns("MarBre").DataPropertyName = "Brecha3"
            .Columns("AbrRes").DataPropertyName = "Resultado4"
            .Columns("AbrBre").DataPropertyName = "Brecha4"
            .Columns("MayRes").DataPropertyName = "Resultado5"
            .Columns("MayBre").DataPropertyName = "Brecha5"
            .Columns("JunRes").DataPropertyName = "Resultado6"
            .Columns("JunBre").DataPropertyName = "Brecha6"
            .Columns("JulRes").DataPropertyName = "Resultado7"
            .Columns("JulBre").DataPropertyName = "Brecha7"
            .Columns("AgoRes").DataPropertyName = "Resultado8"
            .Columns("AgoBre").DataPropertyName = "Brecha8"
            .Columns("SepRes").DataPropertyName = "Resultado9"
            .Columns("SepBre").DataPropertyName = "Brecha9"
            .Columns("OctRes").DataPropertyName = "Resultado10"
            .Columns("OctBre").DataPropertyName = "Brecha10"
            .Columns("NovRes").DataPropertyName = "Resultado11"
            .Columns("NovBre").DataPropertyName = "Brecha11"
            .Columns("DicRes").DataPropertyName = "Resultado12"
            .Columns("DicBre").DataPropertyName = "Brecha12"
            .Columns("Tmetas").DataPropertyName = "Meta_con"
            .Columns("TmRes").DataPropertyName = "Resultado13"
            .Columns("TmBre").DataPropertyName = "Brecha13"
        End With
        dgvIndicadores.DataSource = objIndicador.dtIndicador
    End Sub
    Private Sub rdbAnual_CheckedChanged(sender As Object, e As EventArgs) Handles rdbAnual.CheckedChanged
        With dgvIndicadores
            .Columns("EneRes").Visible = True
            .Columns("EneBre").Visible = True
            .Columns("FebRes").Visible = True
            .Columns("FebBre").Visible = True
            .Columns("MarRes").Visible = True
            .Columns("MarBre").Visible = True
            .Columns("AbrRes").Visible = True
            .Columns("AbrBre").Visible = True
            .Columns("MayRes").Visible = True
            .Columns("MayBre").Visible = True
            .Columns("JunRes").Visible = True
            .Columns("JunBre").Visible = True
            .Columns("JulRes").Visible = True
            .Columns("JulBre").Visible = True
            .Columns("AgoRes").Visible = True
            .Columns("AgoBre").Visible = True
            .Columns("SepRes").Visible = True
            .Columns("SepBre").Visible = True
            .Columns("OctRes").Visible = True
            .Columns("OctBre").Visible = True
            .Columns("NovRes").Visible = True
            .Columns("NovBre").Visible = True
            .Columns("DicRes").Visible = True
            .Columns("DicBre").Visible = True
        End With
        With DataGridView1
            .Columns(0).Visible = True
            .Columns(1).Visible = True
            .Columns(2).Visible = True
            .Columns(3).Visible = True
            .Columns(4).Visible = True
            .Columns(5).Visible = True
            .Columns(6).Visible = True
            .Columns(7).Visible = True
            .Columns(8).Visible = True
            .Columns(9).Visible = True
            .Columns(10).Visible = True
            .Columns(11).Visible = True
            .Columns(12).Visible = True
            .Columns(13).Visible = True
            .Columns(14).Visible = True
        End With
        objIndicador.periodo = 365
        objIndicador.Nivel = 3
    End Sub

    Private Sub rdbSemestre1_CheckedChanged(sender As Object, e As EventArgs) Handles rdbSemestre1.CheckedChanged
        With dgvIndicadores
            .Columns("EneRes").Visible = True
            .Columns("EneBre").Visible = True
            .Columns("FebRes").Visible = True
            .Columns("FebBre").Visible = True
            .Columns("MarRes").Visible = True
            .Columns("MarBre").Visible = True
            .Columns("AbrRes").Visible = True
            .Columns("AbrBre").Visible = True
            .Columns("MayRes").Visible = True
            .Columns("MayBre").Visible = True
            .Columns("JunRes").Visible = True
            .Columns("JunBre").Visible = True
            .Columns("JulRes").Visible = False
            .Columns("JulBre").Visible = False
            .Columns("AgoRes").Visible = False
            .Columns("AgoBre").Visible = False
            .Columns("SepRes").Visible = False
            .Columns("SepBre").Visible = False
            .Columns("OctRes").Visible = False
            .Columns("OctBre").Visible = False
            .Columns("NovRes").Visible = False
            .Columns("NovBre").Visible = False
            .Columns("DicRes").Visible = False
            .Columns("DicBre").Visible = False
        End With
        With DataGridView1
            .Columns(0).Visible = True
            .Columns(1).Visible = True
            .Columns(2).Visible = True
            .Columns(3).Visible = True
            .Columns(4).Visible = True
            .Columns(5).Visible = True
            .Columns(6).Visible = True
            .Columns(7).Visible = False
            .Columns(8).Visible = False
            .Columns(9).Visible = False
            .Columns(10).Visible = False
            .Columns(11).Visible = False
            .Columns(12).Visible = False
            .Columns(13).Visible = True
            .Columns(14).Visible = True
        End With
        objIndicador.periodo = 182
        objIndicador.Nivel = 1
    End Sub

    Private Sub rdbSemestre2_CheckedChanged(sender As Object, e As EventArgs) Handles rdbSemestre2.CheckedChanged
        With dgvIndicadores
            .Columns("EneRes").Visible = False
            .Columns("EneBre").Visible = False
            .Columns("FebRes").Visible = False
            .Columns("FebBre").Visible = False
            .Columns("MarRes").Visible = False
            .Columns("MarBre").Visible = False
            .Columns("AbrRes").Visible = False
            .Columns("AbrBre").Visible = False
            .Columns("MayRes").Visible = False
            .Columns("MayBre").Visible = False
            .Columns("JunRes").Visible = False
            .Columns("JunBre").Visible = False
            .Columns("JulRes").Visible = True
            .Columns("JulBre").Visible = True
            .Columns("AgoRes").Visible = True
            .Columns("AgoBre").Visible = True
            .Columns("SepRes").Visible = True
            .Columns("SepBre").Visible = True
            .Columns("OctRes").Visible = True
            .Columns("OctBre").Visible = True
            .Columns("NovRes").Visible = True
            .Columns("NovBre").Visible = True
            .Columns("DicRes").Visible = True
            .Columns("DicBre").Visible = True
        End With
        With DataGridView1
            .Columns(0).Visible = True
            .Columns(1).Visible = False
            .Columns(2).Visible = False
            .Columns(3).Visible = False
            .Columns(4).Visible = False
            .Columns(5).Visible = False
            .Columns(6).Visible = False
            .Columns(7).Visible = True
            .Columns(8).Visible = True
            .Columns(9).Visible = True
            .Columns(10).Visible = True
            .Columns(11).Visible = True
            .Columns(12).Visible = True
            .Columns(13).Visible = True
            .Columns(14).Visible = True
        End With
        objIndicador.periodo = 182
        objIndicador.Nivel = 2
    End Sub

    Private Sub AjustarPropiedadesGrid()
        dgvIndicadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        'Alto de los headers, se coloca el doble del alto para poder adicionar los nuevos headers
        dgvIndicadores.ColumnHeadersHeight = dgvIndicadores.ColumnHeadersHeight * 2
        dgvIndicadores.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        dgvIndicadores.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvIndicadores.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    End Sub

    Private Sub btnHAtencion_Click(sender As Object, e As EventArgs) Handles btnHAtencion.Click
        Dim HistorialAtencion As New Form_historial_atencion
        HistorialAtencion.ShowDialog()
    End Sub

    Private Sub btnMetas_Click(sender As Object, e As EventArgs) Handles btnMetas.Click
        Dim Metas As New Form_IndicadoresMetas
        Metas.ShowDialog()
    End Sub

    Private Sub cmbArea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbArea.SelectedIndexChanged
        rdbBasico.Enabled = True
        seleccionarCodigoCups()
    End Sub

    Private Sub seleccionarCodigoCups()
        If cmbArea.SelectedIndex > 0 Then
            If cmbArea.SelectedValue <> 9 Then
                rdbBasico.Enabled = False
            End If

            If cmbArea.SelectedValue = 7 And rdbIntensivo.Checked = True Then
                objIndicador.codEstancia = "S12103"
            ElseIf cmbArea.SelectedValue = 7 And rdbIntermedio.Checked = True Then
                objIndicador.codEstancia = "S12203"
            ElseIf cmbArea.SelectedValue = 10 And rdbIntensivo.Checked = True Then
                objIndicador.codEstancia = "S12102"
            ElseIf cmbArea.SelectedValue = 10 And rdbIntermedio.Checked = True Then
                objIndicador.codEstancia = "S12202"
            ElseIf cmbArea.SelectedValue = 9 And rdbIntensivo.Checked = True Then
                objIndicador.codEstancia = "S12101"
            ElseIf cmbArea.SelectedValue = 9 And rdbIntermedio.Checked = True Then
                objIndicador.codEstancia = "S12201"
            ElseIf rdbBasico.Checked = True Then
                objIndicador.codEstancia = "S12403"
            End If
        Else
            objIndicador.codEstancia = "S12103"
        End If
    End Sub

    Private Sub cmbAño_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAño.SelectedIndexChanged
        If cmbArea.SelectedIndex >= 0 Then
            llenadDgvindicadores()
        End If
    End Sub

    Sub llenadDgvindicadores()
        seleccionarCodigoCups()
        Dim param As New List(Of String)
        param.Add(cmbAño.SelectedItem(0))
        param.Add(cmbArea.SelectedValue)
        param.Add(objIndicador.periodo)
        param.Add(objIndicador.codEstancia)
        param.Add(objIndicador.Nivel)
        param.Add(objIndicador.CAP)
        General.llenarTabla(Consultas.CALCULAR_INDICADORES, param, objIndicador.dtIndicador)
        llenar_Graficos()
    End Sub
    Private Sub llenar_Graficos()
        If dgvIndicadores.RowCount = 0 Then Exit Sub
        Dim dt, dt2, dt3, dt4 As New DataTable
        Try

            dt.Columns.Add("Estado")
            dt.Columns.Add("Resultado")
            dt.Rows.Add("% de Ocupación", dgvIndicadores.Rows(8).Cells(27).Value)
            dt.Rows.Add("% de Desocupación", dgvIndicadores.Rows(10).Cells(27).Value)
            Chart2.Series(0).IsValueShownAsLabel = True
            Chart2.Series(0).LabelFormat = "#\%"
            Chart2.Series(0).YValueMembers = "Resultado"
            Chart2.DataSource = dt
            Chart2.Series(0).XValueMember = "Estado"
            dt3.Columns.Add("Estado")
            dt3.Columns.Add("Resultado")
            dt3.Columns.Add("Meta")

            dt3.Rows.Add(dgvIndicadores.Rows(14).Cells(1).Value, dgvIndicadores.Rows(14).Cells(28).Value, dgvIndicadores.Rows(14).Cells(27).Value)
        Catch ex As Exception

        End Try

        Chart3.Series(0).IsValueShownAsLabel = True
        Chart3.Series(1).IsValueShownAsLabel = True
        Chart3.Series(0).XValueMember = "Estado"
        Chart3.Series(0).YValueMembers = "Resultado"
        Chart3.Series(0).LegendText = "Total Atendidos"
        Chart3.Series(1).XValueMember = "Estado"
        Chart3.Series(1).YValueMembers = "Meta"
        Chart3.Series(1).LegendText = "Meta"
        Chart3.DataSource = dt3
        Chart3.Series(0).LabelFormat = "#\%"
    End Sub
    Sub cargarCapacidades()
        Dim rw As DataRow
        Dim param As New List(Of String)
        Dim area As Integer
        If cmbArea.SelectedValue = -1 Then
            area = 7
        Else
            area = cmbArea.SelectedValue
        End If
        param.Add(area)
        rw = General.cargarItem(Consultas.CAPACIDADES, param)
        If rw IsNot Nothing Then
            txtIntensivo.Text = rw(0)
            txtIntermedio.Text = rw(1)
            txtBasico.Text = rw(2)
            txtPorIntencivo.Text = rw(3)
            txtPorIntermedio.Text = rw(4)
            txtPorBasico.Text = rw(5)
        Else
            txtIntensivo.Text = ""
            txtIntermedio.Text = ""
            txtBasico.Text = ""
            txtPorIntencivo.Text = ""
            txtPorIntermedio.Text = ""
            txtPorBasico.Text = ""
        End If
    End Sub

    Private Sub dgvIndicadores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvIndicadores.CellContentClick
        If e.ColumnIndex = 0 Then
            Dim Graficas As New Form_IndicadoresGrafico
            Dim GraficasMort As New Form_IndicadoresGraficoMortalidad
            Graficas.LblEntorno.Text = IIf(cmbArea.Text = " - - - Seleccione - - - ", "TODOS", cmbArea.Text)
            GraficasMort.LblEntorno.Text = IIf(cmbArea.Text = " - - - Seleccione - - - ", "TODOS", cmbArea.Text)
            objIndicador.dtGrafico.Reset()
            If rdbIntensivo.Checked = True Then
                Graficas.LblEstancia.Text = "Intensivo"
                GraficasMort.LblEstancia.Text = "Intensivo"
            ElseIf rdbIntermedio.Checked = True Then
                Graficas.LblEstancia.Text = "Intermedio"
                GraficasMort.LblEstancia.Text = "Intermedio"
            ElseIf rdbBasico.Checked = True Then
                Graficas.LblEstancia.Text = "Basico"
                GraficasMort.LblEstancia.Text = "Basico"
            Else
                Graficas.LblEstancia.Text = "Todos"
                GraficasMort.LblEstancia.Text = "Todos"
            End If
            objIndicador.dtGrafico.Columns.Add("Mes")
            objIndicador.dtGrafico.Columns.Add("Resultado")
            objIndicador.dtGrafico.Columns.Add("Meta Mínima Aceptable")
            objIndicador.dtGrafico.Columns.Add("Meta Óptima")
            If rdbAnual.Checked = True Then
                Graficas.LblPeriodo.Text = "Año"
                GraficasMort.LblPeriodo.Text = "Año"
                objIndicador.dtGrafico.Rows.Add("Ene", dgvIndicadores.Rows(e.RowIndex).Cells(3).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
                objIndicador.dtGrafico.Rows.Add("Feb", dgvIndicadores.Rows(e.RowIndex).Cells(5).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
                objIndicador.dtGrafico.Rows.Add("Mar", dgvIndicadores.Rows(e.RowIndex).Cells(7).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
                objIndicador.dtGrafico.Rows.Add("Abr", dgvIndicadores.Rows(e.RowIndex).Cells(9).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
                objIndicador.dtGrafico.Rows.Add("May", dgvIndicadores.Rows(e.RowIndex).Cells(11).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
                objIndicador.dtGrafico.Rows.Add("Jun", dgvIndicadores.Rows(e.RowIndex).Cells(13).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
                objIndicador.dtGrafico.Rows.Add("Jul", dgvIndicadores.Rows(e.RowIndex).Cells(15).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
                objIndicador.dtGrafico.Rows.Add("Ago", dgvIndicadores.Rows(e.RowIndex).Cells(17).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
                objIndicador.dtGrafico.Rows.Add("Sep", dgvIndicadores.Rows(e.RowIndex).Cells(19).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
                objIndicador.dtGrafico.Rows.Add("Oct", dgvIndicadores.Rows(e.RowIndex).Cells(21).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
                objIndicador.dtGrafico.Rows.Add("Nov", dgvIndicadores.Rows(e.RowIndex).Cells(23).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
                objIndicador.dtGrafico.Rows.Add("Dic", dgvIndicadores.Rows(e.RowIndex).Cells(25).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
            ElseIf rdbSemestre1.Checked = True Then
                Graficas.LblPeriodo.Text = "Primer Semestre"
                GraficasMort.LblPeriodo.Text = "Primer Semestre"
                objIndicador.dtGrafico.Rows.Add("Ene", dgvIndicadores.Rows(e.RowIndex).Cells(3).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
                objIndicador.dtGrafico.Rows.Add("Feb", dgvIndicadores.Rows(e.RowIndex).Cells(5).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
                objIndicador.dtGrafico.Rows.Add("Mar", dgvIndicadores.Rows(e.RowIndex).Cells(7).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
                objIndicador.dtGrafico.Rows.Add("Abr", dgvIndicadores.Rows(e.RowIndex).Cells(9).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
                objIndicador.dtGrafico.Rows.Add("May", dgvIndicadores.Rows(e.RowIndex).Cells(11).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
                objIndicador.dtGrafico.Rows.Add("Jun", dgvIndicadores.Rows(e.RowIndex).Cells(13).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
            ElseIf rdbSemestre2.Checked = True Then
                Graficas.LblPeriodo.Text = "Segundo Semestre"
                GraficasMort.LblPeriodo.Text = "Segundo Semestre"
                objIndicador.dtGrafico.Rows.Add("Jul", dgvIndicadores.Rows(e.RowIndex).Cells(15).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
                objIndicador.dtGrafico.Rows.Add("Ago", dgvIndicadores.Rows(e.RowIndex).Cells(17).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
                objIndicador.dtGrafico.Rows.Add("Sep", dgvIndicadores.Rows(e.RowIndex).Cells(19).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
                objIndicador.dtGrafico.Rows.Add("Oct", dgvIndicadores.Rows(e.RowIndex).Cells(21).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
                objIndicador.dtGrafico.Rows.Add("Nov", dgvIndicadores.Rows(e.RowIndex).Cells(23).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
                objIndicador.dtGrafico.Rows.Add("Dic", dgvIndicadores.Rows(e.RowIndex).Cells(25).Value, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value - 10, dgvIndicadores.Rows(e.RowIndex).Cells(2).Value)
            End If

            If dgvIndicadores.Rows(e.RowIndex).Cells(1).Value = "% de Mortalidad" Then
                GraficasMort.LblAño.Text = cmbAño.Text
                GraficasMort.Lblindicador.Text = dgvIndicadores.Rows(e.RowIndex).Cells(1).Value
                GraficasMort.objIndicadorGM = objIndicador
                GraficasMort.ShowDialog()
            Else
                Graficas.LblAño.Text = cmbAño.Text
                Graficas.Lblindicador.Text = dgvIndicadores.Rows(e.RowIndex).Cells(1).Value
                Graficas.objIndicadorG = objIndicador
                Graficas.ShowDialog()
            End If
        End If
    End Sub

    Private Sub dgvIndicadores_Scroll(sender As Object, e As ScrollEventArgs) Handles dgvIndicadores.Scroll
        DataGridView1.HorizontalScrollingOffset = dgvIndicadores.HorizontalScrollingOffset
    End Sub

    Private Sub cmbArea_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbArea.SelectionChangeCommitted
        If cmbArea.SelectedIndex >= 0 Then
            llenadDgvindicadores()
        End If
        cargarCapacidades()
    End Sub

    Private Sub rdbIntensivo_Click(sender As Object, e As EventArgs) Handles rdbIntensivo.Click
        objIndicador.CAP = 1
        If cmbArea.SelectedIndex >= 0 Then
            llenadDgvindicadores()
        End If
        cargarCapacidades()
    End Sub

    Private Sub rdbIntermedio_Click(sender As Object, e As EventArgs) Handles rdbIntermedio.Click
        objIndicador.CAP = 2
        If cmbArea.SelectedIndex >= 0 Then
            llenadDgvindicadores()
        End If
        cargarCapacidades()
    End Sub

    Private Sub rdbBasico_Click(sender As Object, e As EventArgs) Handles rdbBasico.Click
        objIndicador.CAP = 3
        If cmbArea.SelectedIndex >= 0 Then
            llenadDgvindicadores()
        End If
        cargarCapacidades()
    End Sub

    Private Sub rdbGlobal_Click(sender As Object, e As EventArgs) Handles rdbGlobal.Click
        objIndicador.CAP = 0
        If cmbArea.SelectedIndex >= 0 Then
            llenadDgvindicadores()
        End If
        cargarCapacidades()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If cmbArea.SelectedIndex >= 0 Then
            llenadDgvindicadores()
        End If
        cargarCapacidades()
    End Sub

    Private Sub rdbAnual_Click(sender As Object, e As EventArgs) Handles rdbAnual.Click
        If cmbArea.SelectedIndex >= 0 Then
            llenadDgvindicadores()
        End If
        cargarCapacidades()
    End Sub

    Private Sub rdbSemestre1_Click(sender As Object, e As EventArgs) Handles rdbSemestre1.Click
        If cmbArea.SelectedIndex >= 0 Then
            llenadDgvindicadores()
        End If
        cargarCapacidades()
    End Sub

    Private Sub rdbSemestre2_Click(sender As Object, e As EventArgs) Handles rdbSemestre2.Click
        If cmbArea.SelectedIndex >= 0 Then
            llenadDgvindicadores()
        End If
        cargarCapacidades()
    End Sub
End Class