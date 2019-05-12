Public Class FormPromedioDiaEstancias
    Dim modulo2 As Object
    Dim moduloHC As String
    Public objSeguimiento As New FacturacionDiaria
    Dim dt As New DataTable
    Dim dt2 As New DataTable
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal strParametro As String)
        Me.New()
        modulo2 = strParametro
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormPromedioDiaEstancias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dgvFactura.AutoGenerateColumns = False
            objSeguimiento.modulo = modulo2
            objSeguimiento.moduloConf = modulo2
            If objSeguimiento.moduloConf Is Nothing Then
                objSeguimiento.moduloConf = Tag.modulo
            End If
            Dim objConfigMeta As New ConfigMetaEmpleado
            Dim thisDay As DateTime = General.fechaActualServidor()
            Dim dTent As DateTime = thisDay.AddMonths(-1)
            If dTent > thisDay Then
                dtpDesde.Value = DateSerial(Year(thisDay), Month(thisDay), 1)
                dtpHasta.Value = dTent.AddDays(-1)
            Else
                dtpDesde.Value = DateSerial(Year(thisDay), Month(thisDay), 1)
                dtpHasta.Value = DateSerial(Year(thisDay), Month(thisDay) + 1, 0)
            End If

            If modulo2 = Constantes.AM Or modulo2 = Constantes.AF Then
                moduloHC = Constantes.HC
            Else
                moduloHC = modulo2
            End If
            chkAtendidos.Checked = True
            enlazarDgvFatura()
            enlazarDgvTotalG()
            objSeguimiento.cargarConfigDiaFact()
            If objSeguimiento.dtConfigDiaFactura.Rows.Count > 0 Then
                Dim cadenaarea As String = objSeguimiento.dtConfigDiaFactura.Rows(0).Item(1)
                Dim indicearea As Integer = cadenaarea.IndexOf("-") + 2
                Dim params As New List(Of String)
                params.Add(objSeguimiento.dtConfigDiaFactura.Rows(0).Item(1))
                params.Add(SesionActual.codigoEP)
                General.llenarTabla(Consultas.CARGA_AREA_SERVICIO, params, dt)
                General.llenarTabla(Consultas.MENU_ATENCION_BUSCAR, Nothing, dt2)
                dt2.Rows.Add()
                dt2.Rows(dt2.Rows.Count - 1).Item(0) = "ac"
                dt2.Rows(dt2.Rows.Count - 1).Item(1) = "AUDITORIA M."
                dt2.Rows.Add()
                dt2.Rows(dt2.Rows.Count - 1).Item(0) = "ad"
                dt2.Rows(dt2.Rows.Count - 1).Item(1) = "AUDITORIA F."
                If objSeguimiento.dtConfigDiaFactura.Rows(0).Item(1) < 0 Then
                    Label7.Text = "TODAS"
                Else
                    Label7.Text = dt.Rows(0).Item(1)
                End If
                If objSeguimiento.dtConfigDiaFactura.Rows(1).Item(1) = "-1" Then
                    Label8.Text = "TODOS"
                Else
                    Dim resultado() As DataRow = dt2.Select("Código = '" & objSeguimiento.dtConfigDiaFactura.Rows(1).Item(1).ToString & "'", "Nombre")
                    Label8.Text = resultado(0)(1).ToString
                End If
                    cargarDatos()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Public Sub enlazarDgvFatura()
        With dgvFactura
            .Columns("Area").ReadOnly = True
            .Columns("Area").DataPropertyName = "Area"
            .Columns("Area").Frozen = True
            .Columns("Modulo").ReadOnly = True
            .Columns("Modulo").DataPropertyName = "Modulo"
            .Columns("Modulo").Frozen = True
            .Columns("NPaciente").ReadOnly = True
            .Columns("NPaciente").DataPropertyName = "N_Pacientes"
            .Columns("NPaciente").Frozen = True
            .Columns("nRegistro").DataPropertyName = "N_Registro"
            .Columns("Fecha").ReadOnly = True
            .Columns("Fecha").DataPropertyName = "Fecha"
            .Columns("Fecha").Frozen = True
            .Columns("E").ReadOnly = True
            .Columns("E").DataPropertyName = "E"
            .Columns("T").ReadOnly = True
            .Columns("T").DataPropertyName = "T"
            .Columns("O").ReadOnly = True
            .Columns("O").DataPropertyName = "O"
            .Columns("P").ReadOnly = True
            .Columns("P").DataPropertyName = "P"
            .Columns("H").ReadOnly = True
            .Columns("H").DataPropertyName = "H"
            .Columns("PR").ReadOnly = True
            .Columns("PR").DataPropertyName = "PR"
            .Columns("M").ReadOnly = True
            .Columns("M").DataPropertyName = "M"
            .Columns("I").ReadOnly = True
            .Columns("I").DataPropertyName = "I"
            .Columns("Valor").ReadOnly = True
            .Columns("Valor").DataPropertyName = "Valor"
            .Columns("Meta").ReadOnly = True
            .Columns("Meta").DataPropertyName = "Meta"
        End With
        dgvFactura.DataSource = objSeguimiento.navegadorPromedio.DataSource
    End Sub
    Public Sub enlazarDgvTotalG()
        With dgvTotalGeneral
            .Columns("AreaTG").ReadOnly = True
            .Columns("AreaTG").DataPropertyName = "Area"
            .Columns("AreaTG").Frozen = True
            .Columns("ModuloTG").ReadOnly = True
            .Columns("ModuloTG").DataPropertyName = "Modulo"
            .Columns("ModuloTG").Frozen = True
            .Columns("NPacienteTG").ReadOnly = True
            .Columns("NPacienteTG").DataPropertyName = "N_Pacientes"
            .Columns("NPacienteTG").Frozen = True
            .Columns("nRegistroTG").DataPropertyName = "N_Registro"
            .Columns("FechaTG").ReadOnly = True
            .Columns("FechaTG").DataPropertyName = "Fecha"
            .Columns("FechaTG").Frozen = True
            .Columns("ETG").ReadOnly = True
            .Columns("ETG").DataPropertyName = "E"
            .Columns("TTG").ReadOnly = True
            .Columns("TTG").DataPropertyName = "T"
            .Columns("OTG").ReadOnly = True
            .Columns("OTG").DataPropertyName = "O"
            .Columns("PTG").ReadOnly = True
            .Columns("PTG").DataPropertyName = "P"
            .Columns("HTG").ReadOnly = True
            .Columns("HTG").DataPropertyName = "H"
            .Columns("PRTG").ReadOnly = True
            .Columns("PRTG").DataPropertyName = "PR"
            .Columns("MTG").ReadOnly = True
            .Columns("MTG").DataPropertyName = "M"
            .Columns("ITG").ReadOnly = True
            .Columns("ITG").DataPropertyName = "I"
            .Columns("ValorTG").ReadOnly = True
            .Columns("ValorTG").DataPropertyName = "Valor"
            .Columns("MetaTG").ReadOnly = True
            .Columns("MetaTG").DataPropertyName = "Meta"
        End With
        dgvTotalGeneral.DataSource = objSeguimiento.navegadorPromedioTG.DataSource
    End Sub
    Private Sub dtpHastaCambio(sender As Object, e As EventArgs) Handles dtpHasta.ValueChanged, dtpDesde.ValueChanged, rbDiario.CheckedChanged,
                                                                         rbPromedio.CheckedChanged, chkAtendidos.CheckedChanged
        dtpHasta.Value = dtpDesde.Value.AddMonths(1).AddDays(-1)
        If objSeguimiento.dtConfigDiaFactura.Rows.Count > 0 Then
            cargarDatos()
        End If
    End Sub
    Public Sub cargarDatos()
        Timer1.Stop()
        Cursor = Cursors.WaitCursor
        cargarObjetos()
        If Mid(objSeguimiento.dtConfigDiaFactura.Rows(2).Item(1), 1, 1) = 0 And (Mid(objSeguimiento.dtConfigDiaFactura.Rows(2).Item(1), 1, 1) >= 0) Then
            dgvFactura.Columns("NPaciente").Width = 60
            dgvFactura.Columns("NPaciente").HeaderText = "Pacientes"
        Else
            dgvFactura.Columns("NPaciente").Width = 150
            dgvFactura.Columns("NPaciente").HeaderText = "EPS"
        End If
        If rbDiario.Checked Then
            cargarDias()
        End If
        If dgvFactura.Rows.Count > 0 Then
            Calcular()
            dgvFactura.Columns("Modulo").Visible = True
            dgvTotalGeneral.Columns("ModuloTG").Visible = True
        End If
        Cursor = Cursors.Default
        Timer1.Start()
    End Sub
    Private Sub cargarObjetos()
        objSeguimiento.fechaDesde = DateSerial(Year(dtpDesde.Value.Date), Month(dtpDesde.Value.Date), 1)
        objSeguimiento.fechaHasta = DateSerial(Year(dtpDesde.Value.Date), Month(dtpDesde.Value.Date) + 1, 0)
        objSeguimiento.cadenaFiltro = Mid(objSeguimiento.dtConfigDiaFactura.Rows(2).Item(1), 1, 1)

        objSeguimiento.modulo = objSeguimiento.dtConfigDiaFactura.Rows(1).Item(1)
        If Date.Today() < objSeguimiento.fechaHasta Then
            objSeguimiento.fechaHasta = Date.Today()
        End If
        objSeguimiento.codigoArea = objSeguimiento.dtConfigDiaFactura.Rows(0).Item(1)

    End Sub
    Public Sub cargarPromedios()
        objSeguimiento.cargarPromedioxEPS()
        dgvFactura.Columns("NPaciente").HeaderText = "Nombre EPS"
    End Sub
    Public Sub cargarDias()
        objSeguimiento.cargarDia()
    End Sub
    Private Sub Calcular()
        Dim dtaux As New DataTable
        Dim i As Integer

        aplicarFormatoDgv(dgvFactura, "Fecha")
        objSeguimiento.dtPromedioTG.Clear()


        dtaux = dgvFactura.DataSource
        If dgvFactura.Rows.Count > 0 Then
            Dim query = (From row In dtaux.AsEnumerable() Select row.Field(Of String)("Modulo")).Distinct()
            Dim NomModulo(query.Count - 1) As String

            For i = 0 To query.Count - 1
                NomModulo(i) = query(i)
            Next
            Dim nombreArea As String
            If objSeguimiento.dtConfigDiaFactura.Rows(0).Item(1) < 0 Then
                nombreArea = "TODAS"
            Else
                nombreArea = Label7.Text
            End If

            For i = 0 To query.Count - 1
                objSeguimiento.dtPromedioTG.Rows.Add()
                objSeguimiento.dtPromedioTG.Rows(i).Item("Area") = nombreArea
                objSeguimiento.dtPromedioTG.Rows(i).Item("Modulo") = NomModulo(i)
                objSeguimiento.dtPromedioTG.Rows(i).Item("N_Pacientes") = dtaux.Rows(0).Item("TOTAL")
                objSeguimiento.dtPromedioTG.Rows(i).Item("Fecha") = dtaux.Rows(0).Item("Fecha")
                objSeguimiento.dtPromedioTG.Rows(i).Item("E") = IIf(IsDBNull(dtaux.Compute("Sum(E)", "E Is Not Null and Modulo = '" & NomModulo(i) & "'")), 0, dtaux.Compute("Sum(E)", "E Is Not Null and Modulo = '" & NomModulo(i) & "'"))
                objSeguimiento.dtPromedioTG.Rows(i).Item("T") = IIf(IsDBNull(dtaux.Compute("Sum(T)", "T Is Not Null and Modulo = '" & NomModulo(i) & "'")), 0, dtaux.Compute("Sum(T)", "T Is Not Null and Modulo = '" & NomModulo(i) & "'"))
                objSeguimiento.dtPromedioTG.Rows(i).Item("O") = IIf(IsDBNull(dtaux.Compute("Sum(O)", "O Is Not Null and Modulo = '" & NomModulo(i) & "'")), 0, dtaux.Compute("Sum(O)", "O Is Not Null and Modulo = '" & NomModulo(i) & "'"))
                objSeguimiento.dtPromedioTG.Rows(i).Item("P") = IIf(IsDBNull(dtaux.Compute("Sum(P)", "P Is Not Null and Modulo = '" & NomModulo(i) & "'")), 0, dtaux.Compute("Sum(P)", "P Is Not Null and Modulo = '" & NomModulo(i) & "'"))
                objSeguimiento.dtPromedioTG.Rows(i).Item("H") = IIf(IsDBNull(dtaux.Compute("Sum(H)", "H Is Not Null and Modulo = '" & NomModulo(i) & "'")), 0, dtaux.Compute("Sum(H)", "H Is Not Null and Modulo = '" & NomModulo(i) & "'"))
                objSeguimiento.dtPromedioTG.Rows(i).Item("PR") = IIf(IsDBNull(dtaux.Compute("Sum(PR)", "PR Is Not Null and Modulo = '" & NomModulo(i) & "'")), 0, dtaux.Compute("Sum(PR)", "PR Is Not Null and Modulo = '" & NomModulo(i) & "'"))
                objSeguimiento.dtPromedioTG.Rows(i).Item("M") = IIf(IsDBNull(dtaux.Compute("Sum(M)", "M Is Not Null and Modulo = '" & NomModulo(i) & "'")), 0, dtaux.Compute("Sum(M)", "M Is Not Null and Modulo = '" & NomModulo(i) & "'"))
                objSeguimiento.dtPromedioTG.Rows(i).Item("I") = IIf(IsDBNull(dtaux.Compute("Sum(I)", "I Is Not Null and Modulo = '" & NomModulo(i) & "'")), 0, dtaux.Compute("Sum(I)", "I Is Not Null and Modulo = '" & NomModulo(i) & "'"))
                objSeguimiento.dtPromedioTG.Rows(i).Item("Valor") = IIf(IsDBNull(dtaux.Compute("Sum(Valor)", "Valor Is Not Null and Modulo = '" & NomModulo(i) & "'")), 0, dtaux.Compute("Sum(Valor)", "Valor Is Not Null and Modulo = '" & NomModulo(i) & "'"))
                objSeguimiento.dtPromedioTG.Rows(i).Item("Meta") = IIf(IsDBNull(dtaux.Compute("Sum(Meta)", "Meta Is Not Null and Modulo = '" & NomModulo(i) & "'")), 0, dtaux.Compute("Sum(Meta)", "Meta Is Not Null and Modulo = '" & NomModulo(i) & "'"))
            Next
            lbtEgresos.Text = " Pacientes: " & Math.Round(dtaux.Rows.Count / 3)
            lbtUciAdulto.Text = ""
        End If

    End Sub
    Private Sub dgvFactura_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvFactura.CellFormatting
        If e.ColumnIndex > 4 Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), "c2")
            Else
                e.Value = Format(Val(e.Value), "c2")
            End If
        End If
    End Sub
    Private Sub aplicarFormatoDgv(dgvGeneral As DataGridView, Campo As String)
        If dgvGeneral.RowCount > 0 Then
            Dim colorA As Color = Nothing
            Dim colorB As Color = Color.LightCyan
            dgvGeneral.AlternatingRowsDefaultCellStyle.BackColor = Nothing
            Dim dgvPrimeraFila = dgvGeneral.Rows(0)
            Dim ultimoRegistro As String = Funciones.castFromDbItem(dgvPrimeraFila.Cells(Campo).Value)

            For Each dgvFila As DataGridViewRow In dgvGeneral.Rows
                Dim colorActual As Color
                If dgvFila Is dgvPrimeraFila Then
                    colorActual = colorA
                Else
                    Dim actualRegistro As String = dgvFila.Cells(Campo).Value.ToString
                    If actualRegistro <> String.Empty AndAlso actualRegistro <> ultimoRegistro Then
                        colorActual = If(colorActual = colorA, colorB, colorA)
                        ultimoRegistro = actualRegistro
                    End If
                End If
                dgvFila.DefaultCellStyle.BackColor = colorActual
            Next
        End If
    End Sub

    Private Sub dgvTotalGeneral_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvTotalGeneral.CellFormatting
        If e.ColumnIndex > 4 Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), "c2")
            Else
                e.Value = Format(Val(e.Value), "c2")
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        cargarDatos()
    End Sub

    Private Sub FormPromedioDiaEstancias_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Timer1.Stop()
    End Sub

    Private Sub dgvFactura_ColumnWidthChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles dgvFactura.ColumnWidthChanged
        If dgvTotalGeneral.Columns.Contains(e.Column.Name + "TG") Then
            dgvTotalGeneral.Columns(e.Column.Name + "TG").Width = e.Column.Width
        End If
    End Sub

    Private Sub dgvTotalGeneral_Scroll(sender As Object, e As ScrollEventArgs) Handles dgvTotalGeneral.Scroll
        dgvFactura.HorizontalScrollingOffset = dgvTotalGeneral.HorizontalScrollingOffset
    End Sub

    Private Sub chkResumido_CheckedChanged(sender As Object, e As EventArgs) Handles chkResumido.CheckedChanged
        Dim I As Integer
        'If objSeguimiento.dtConfigDiaFactura.Rows(0).Item(1) > "-1" Then
        For I = 5 To 12
            dgvFactura.Columns(I).Visible = Not chkResumido.Checked
            dgvTotalGeneral.Columns(I).Visible = Not chkResumido.Checked
        Next
        'End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim configurar As New FormConfigPromedioDiaEstancias(objSeguimiento.moduloConf)

        If configurar.ShowDialog() = DialogResult.OK Then
            objSeguimiento.cargarConfigDiaFact()
            If objSeguimiento.dtConfigDiaFactura.Rows.Count > 0 Then
                Dim cadenaarea As String = objSeguimiento.dtConfigDiaFactura.Rows(0).Item(1)
                Dim indicearea As Integer = cadenaarea.IndexOf("-") + 2

                Dim params As New List(Of String)
                params.Add(objSeguimiento.dtConfigDiaFactura.Rows(0).Item(1))
                params.Add(SesionActual.codigoEP)
                General.llenarTabla(Consultas.CARGA_AREA_SERVICIO, params, dt)
                If objSeguimiento.dtConfigDiaFactura.Rows(0).Item(1) < 0 Then
                    Label7.Text = "TODAS"
                Else
                    Label7.Text = dt.Rows(0).Item(1)
                End If

                If objSeguimiento.dtConfigDiaFactura.Rows(1).Item(1) = "-1" Then
                    Label8.Text = "TODOS"
                Else
                    Dim resultado() As DataRow = dt2.Select("Código = '" & objSeguimiento.dtConfigDiaFactura.Rows(1).Item(1).ToString & "'", "Nombre")
                    Label8.Text = resultado(0)(1).ToString
                End If
                cargarDatos()
            End If
        End If

    End Sub
End Class