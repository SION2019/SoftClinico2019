Public Class FormFacturacionDiaria
    Private objSeguimiento As New FacturacionDiaria
    Dim data As New DataView
    Dim rec As Rectangle
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormFacturacionDiaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objSeguimiento.modulo = Tag.modulo
        If objSeguimiento.modulo <> "ac" AndAlso objSeguimiento.modulo <> "ad" Then
            dgvFactura.Height = 398
            dgvTotalGeneral.Height = 42
            dgvTotalGeneral.Top = 421
        ElseIf objSeguimiento.modulo = "ac" Then
            dgvFactura.Height = 380
            dgvTotalGeneral.Height = 60
            dgvTotalGeneral.Top = 403
        ElseIf objSeguimiento.modulo = "ad" Then
            dgvFactura.Height = 362
            dgvTotalGeneral.Height = 78
            dgvTotalGeneral.Top = 385
        End If
        General.limpiarControles(Me)
        Dim objConfigMeta As New ConfigMetaEmpleado
        objConfigMeta.cargarMetaGeneral()
        Dim thisDay As DateTime = General.fechaActualServidor()
        Dim dTent As DateTime = thisDay.AddDays(thisDay.Day * -1 + objConfigMeta.diaCorte + 1)
        If dTent > thisDay Then
            dtpDesde.Value = thisDay.AddMonths(-1).AddDays(thisDay.Day * -1 + objConfigMeta.diaCorte + 1)
            dtpHasta.Value = dTent.AddDays(-1)
        Else
            dtpDesde.Value = dTent
            dtpHasta.Value = thisDay.AddMonths(1).AddDays(thisDay.Day * -1 + objConfigMeta.diaCorte)
        End If
        With dgvFactura
            .Columns("no").ReadOnly = True
            .Columns("no").DataPropertyName = "No"
            .Columns("no").Frozen = True
            .Columns("nRegistro").DataPropertyName = "N_Registro"
            .Columns("Modulo").ReadOnly = True
            .Columns("Modulo").DataPropertyName = "Modulo"
            .Columns("Modulo").Frozen = True
            .Columns("paciente").ReadOnly = True
            .Columns("paciente").DataPropertyName = "Paciente"
            .Columns("Paciente").Frozen = True
            .Columns("identificacion").ReadOnly = True
            .Columns("identificacion").DataPropertyName = "Identificación"
            .Columns("documento").ReadOnly = True
            .Columns("documento").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("documento").DataPropertyName = "Tipo_Documento"
            .Columns("Area").ReadOnly = True
            .Columns("Area").DataPropertyName = "Area"
            .Columns("eps").ReadOnly = True
            .Columns("eps").DataPropertyName = "EPS"
            .Columns("DiasEstancia").ReadOnly = True
            .Columns("DiasEstancia").DataPropertyName = "DiasEstancia"
            .Columns("factura").ReadOnly = True
            .Columns("factura").DataPropertyName = "Factura"
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
            .Columns("PromedioDia").ReadOnly = True
            .Columns("PromedioDia").DataPropertyName = "PromedioDia"
            .Columns("PromedioMeta").ReadOnly = True
            .Columns("PromedioMeta").DataPropertyName = "PromedioMeta"
            .Columns("Diferencia").ReadOnly = True
            .Columns("Diferencia").DataPropertyName = "Diferencia"
            .Columns("Colores").DataPropertyName = "Color"
        End With
        With dgvTotalGeneral
            .Columns("noG").ReadOnly = True
            .Columns("noG").DataPropertyName = "No"
            .Columns("noG").Frozen = True
            .Columns("nRegistroG").DataPropertyName = "N_Registro"
            .Columns("ModuloG").ReadOnly = True
            .Columns("ModuloG").DataPropertyName = "Modulo"
            .Columns("ModuloG").Frozen = True
            .Columns("pacienteG").ReadOnly = True
            .Columns("pacienteG").DataPropertyName = "Paciente"
            .Columns("PacienteG").Frozen = True
            .Columns("identificacionG").ReadOnly = True
            .Columns("identificacionG").DataPropertyName = "Identificación"
            .Columns("documentoG").ReadOnly = True
            .Columns("documentoG").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("documentoG").DataPropertyName = "Tipo_Documento"
            .Columns("AreaG").ReadOnly = True
            .Columns("AreaG").DataPropertyName = "Area"
            .Columns("epsG").ReadOnly = True
            .Columns("epsG").DataPropertyName = "EPS"
            .Columns("DiasEstanciaG").ReadOnly = True
            .Columns("DiasEstanciaG").DataPropertyName = "DiasEstancia"
            .Columns("facturaG").ReadOnly = True
            .Columns("facturaG").DataPropertyName = "Factura"
            .Columns("EG").ReadOnly = True
            .Columns("EG").DataPropertyName = "E"
            .Columns("TG").ReadOnly = True
            .Columns("TG").DataPropertyName = "T"
            .Columns("OG").ReadOnly = True
            .Columns("OG").DataPropertyName = "O"
            .Columns("PG").ReadOnly = True
            .Columns("PG").DataPropertyName = "P"
            .Columns("HG").ReadOnly = True
            .Columns("HG").DataPropertyName = "H"
            .Columns("PRG").ReadOnly = True
            .Columns("PRG").DataPropertyName = "PR"
            .Columns("MG").ReadOnly = True
            .Columns("MG").DataPropertyName = "M"
            .Columns("IG").ReadOnly = True
            .Columns("IG").DataPropertyName = "I"
            .Columns("ValorG").ReadOnly = True
            .Columns("ValorG").DataPropertyName = "Valor"
            .Columns("PromedioDiaG").ReadOnly = True
            .Columns("PromedioDiaG").DataPropertyName = "PromedioDia"
            .Columns("PromedioMetaG").ReadOnly = True
            .Columns("PromedioMetaG").DataPropertyName = "PromedioMeta"
            .Columns("DiferenciaG").ReadOnly = True
            .Columns("DiferenciaG").DataPropertyName = "Diferencia"
        End With
        Me.comboOpcion.SelectedIndex = 0
        Me.dtpDesde.Enabled = False : Me.dtpHasta.Enabled = False
        enlazarDgvMetas()
        enlazarDgvDetalleFatura()
        dgvFactura.DataSource = objSeguimiento.navegador.DataSource
        dgvTotalGeneral.DataSource = objSeguimiento.navegadorTotalesG.DataSource
        dgvFactura.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7)

        cargarObjetos()
        cargarfacturas()
        dgvFactura.Refresh()
        Calcular()
        PictureBox2.Image = Global.Celer.My.Resources.Resources.chart_add_icon
    End Sub
    Public Sub enlazarDgvMetas()
        With dgvMetas
            .Columns("dgModulo").DataPropertyName = "Descripcion_Area_Servicio"
            .Columns("dgHC").DataPropertyName = "HC"
            .Columns("dgAM").DataPropertyName = "AM"
            .Columns("dgAF").DataPropertyName = "AF"
            .AutoGenerateColumns = False
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        dgvMetas.DataSource = objSeguimiento.dtAsignarMetas
    End Sub
    Public Sub enlazarDgvDetalleFatura()
        With dgvDetallePacientes
            .Columns("noDP").ReadOnly = True
            .Columns("noDP").DataPropertyName = "dia"
            .Columns("noDP").Frozen = True
            .Columns("nRegistroDP").DataPropertyName = "N_Registro"
            .Columns("ModuloDP").ReadOnly = True
            .Columns("ModuloDP").DataPropertyName = "Modulo"
            .Columns("ModuloDP").Frozen = True
            .Columns("pacienteDP").ReadOnly = True
            .Columns("pacienteDP").DataPropertyName = "Paciente"
            .Columns("PacienteDP").Frozen = True
            .Columns("identificacionDP").ReadOnly = True
            .Columns("identificacionDP").DataPropertyName = "Identificación"
            .Columns("documentoDP").ReadOnly = True
            .Columns("documentoDP").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("documentoDP").DataPropertyName = "Tipo_Documento"
            .Columns("AreaDP").ReadOnly = True
            .Columns("AreaDP").DataPropertyName = "Area"
            .Columns("epsDP").ReadOnly = True
            .Columns("epsDP").DataPropertyName = "EPS"
            .Columns("DiasEstanciaDP").ReadOnly = True
            .Columns("DiasEstanciaDP").DataPropertyName = "DiasEstancia"
            .Columns("facturaDP").ReadOnly = True
            .Columns("facturaDP").DataPropertyName = "Factura"
            .Columns("EDP").ReadOnly = True
            .Columns("EDP").DataPropertyName = "E"
            .Columns("TDP").ReadOnly = True
            .Columns("TDP").DataPropertyName = "T"
            .Columns("ODP").ReadOnly = True
            .Columns("ODP").DataPropertyName = "O"
            .Columns("PDP").ReadOnly = True
            .Columns("PDP").DataPropertyName = "P"
            .Columns("HDP").ReadOnly = True
            .Columns("HDP").DataPropertyName = "H"
            .Columns("PRDP").ReadOnly = True
            .Columns("PRDP").DataPropertyName = "PR"
            .Columns("MDP").ReadOnly = True
            .Columns("MDP").DataPropertyName = "M"
            .Columns("IDP").ReadOnly = True
            .Columns("IDP").DataPropertyName = "I"
            .Columns("ValorDP").ReadOnly = True
            .Columns("ValorDP").DataPropertyName = "Valor"
            .Columns("PromedioDiaDP").ReadOnly = True
            .Columns("PromedioDiaDP").DataPropertyName = "PromedioDia"
        End With
        dgvDetallePacientes.DataSource = objSeguimiento.navegadorDetalle.DataSource
    End Sub
    Private Sub colorXArea()
        If comboOpcion.SelectedIndex = 0 And selAtendidos.Checked = True Then
            For j As Int32 = 0 To dgvFactura.Rows.Count - 1
                dgvFactura.Rows(j).DefaultCellStyle.BackColor = Color.FromArgb(dgvFactura.Rows(j).Cells("Colores").Value)
            Next
        End If
        lbtFacturas.BackColor = Color.FromArgb(-5185306)
        lbtSinFacturas.BackColor = Color.FromArgb(-4128832)
        lbtRadicadas.BackColor = Color.FromArgb(-8000)
    End Sub
    Private Sub cargarObjetos()
        objSeguimiento.fechaDesde = dtpDesde.Value.Date
        objSeguimiento.fechaHasta = dtpHasta.Value.Date
        objSeguimiento.condicion = comboOpcion.SelectedIndex
        If selAtendidos.Checked Then
            objSeguimiento.codigoEstado = Constantes.ESTADO_ATENCION_INICIADO
        ElseIf selPrefacturado.Checked Then
            objSeguimiento.codigoEstado = Constantes.ESTADO_ATENCION_PREFACTURADO
        ElseIf selFacturados.Checked Then
            objSeguimiento.codigoEstado = Constantes.ESTADO_ATENCION_FACTURADO
        End If
        objSeguimiento.ctc = cbCTC.Checked
    End Sub
    Public Sub cargarfacturas()
        objSeguimiento.cargarPacienteFactura()
        Dim columna As DataGridViewColumnCollection = dgvFactura.Columns
        Dim columna2 As DataGridViewColumnCollection = dgvTotalGeneral.Columns
        If objSeguimiento.codigoEstado <> Constantes.ESTADO_ATENCION_FACTURADO Then
            columna("Paciente").Visible = True
            columna("factura").Visible = False
            columna2("PacienteG").Visible = True
            columna2("facturaG").Visible = False
        Else
            columna("factura").Visible = True
            columna2("facturaG").Visible = True
        End If
    End Sub
    Public Sub cargarfacturasEPS()
        objSeguimiento.cargarEPSFactura()
        Dim columna As DataGridViewColumnCollection = dgvFactura.Columns
        Dim columna2 As DataGridViewColumnCollection = dgvTotalGeneral.Columns
        If objSeguimiento.codigoEstado <> Constantes.ESTADO_ATENCION_FACTURADO Then
            columna("Paciente").Visible = False
            columna("factura").Visible = False
            columna2("PacienteG").Visible = False
            columna2("facturaG").Visible = False
        Else
            columna("factura").Visible = True
            columna2("facturaG").Visible = True
        End If
    End Sub
    Private Sub aplicarFormatoDgv(dgvGeneral As DataGridView, Campo As String)
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
    End Sub
    Private Sub dgvFactura_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvFactura.CellFormatting
        If e.ColumnIndex > 9 Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), "c2")
            Else
                e.Value = Format(Val(e.Value), "c2")
            End If
            If e.ColumnIndex = 19 And Not IsDBNull(dgvFactura.Rows(e.RowIndex).Cells(20).Value) Then
                Select Case dgvFactura.Rows(e.RowIndex).Cells(1).Value
                    'Case "U.C.I.", "Hospitalización"
                    '    If e.Value <= dgvFactura.Rows(e.RowIndex).Cells(20).Value Then
                    '        dgvFactura.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Green
                    '    Else
                    '        dgvFactura.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Red
                    '    End If
                    Case "Auditoría M.", "Auditoria F."
                        If e.Value > dgvFactura.Rows(e.RowIndex).Cells(20).Value Then
                            dgvFactura.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Green
                        Else
                            dgvFactura.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Red
                        End If
                    Case Else
                        If e.Value <= dgvFactura.Rows(e.RowIndex).Cells(20).Value Then
                            dgvFactura.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Green
                        Else
                            dgvFactura.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Red
                        End If
                End Select
            ElseIf e.ColumnIndex = 21 Then
                Select Case dgvFactura.Rows(e.RowIndex).Cells(1).Value
                    'Case "U.C.I.", "Hospitalización"
                    '    If e.Value >= 0 Then
                    '        dgvFactura.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Green
                    '    Else
                    '        dgvFactura.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Red
                    '    End If
                    Case "Auditoría M.", "Auditoria F."
                        If e.Value < 0 Then
                            dgvFactura.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Green
                        Else
                            dgvFactura.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Red
                        End If
                    Case Else
                        If e.Value >= 0 Then
                            dgvFactura.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Green
                        Else
                            dgvFactura.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Red
                        End If
                End Select

            End If
        End If
    End Sub

    Private Sub cargarDatos()
        cargarObjetos()
        If comboOpcion.SelectedIndex = 0 Then
            dgvFactura.Columns(6).HeaderText = "Area"
            cargarfacturas()
        ElseIf comboOpcion.SelectedIndex = 1 Then
            dgvFactura.Columns(6).HeaderText = "No.Pacientes"
            cargarfacturasEPS()
        End If
        Calcular()
    End Sub
    Private Sub Calcular()
        Dim dtaux As New DataTable
        Dim VarModulo, i As Integer
        Dim DifAM, DifAF As Double
        Dim PorcentajeAM, PorcentajeAF As Integer

        objSeguimiento.dtTotalesG.Clear()

        dtaux = dgvFactura.DataSource
        If dgvFactura.RowCount > 0 Then
            Dim query = (From row In dtaux.AsEnumerable() Select row.Field(Of String)("Modulo")).Distinct()
            Dim NomModulo(query.Count - 1) As String


            For i = 0 To query.Count - 1
                NomModulo(i) = query(i)
            Next
            VarModulo = query.Count - 1
            If data.RowFilter <> "" Then
                dgvFactura.DataSource = data.ToTable
            End If
            If selAtendidos.Checked = False Then
                aplicarFormatoDgv(dgvFactura, "nRegistro")
            Else
                colorXArea()
            End If
            For i = 0 To VarModulo
                objSeguimiento.dtTotalesG.Rows.Add()
                objSeguimiento.dtTotalesG.Rows(i).Item("Modulo") = NomModulo(i)
                If comboOpcion.SelectedIndex = 0 Then
                    objSeguimiento.dtTotalesG.Rows(i).Item("Paciente") = "TOTALES"
                    objSeguimiento.dtTotalesG.Rows(i).Item("Area") = ""
                Else
                    objSeguimiento.dtTotalesG.Rows(i).Item("Area") = "TOTALES"
                    objSeguimiento.dtTotalesG.Rows(i).Item("Paciente") = ""
                End If
                objSeguimiento.dtTotalesG.Rows(i).Item("N_Registro") = i
                objSeguimiento.dtTotalesG.Rows(i).Item("DiasEstancia") = IIf(IsDBNull(dtaux.Compute("Sum(DiasEstancia)", "DiasEstancia Is Not Null And Modulo = '" & NomModulo(i) & "'")), 0, dtaux.Compute("Sum(DiasEstancia)", "DiasEstancia Is Not Null and Modulo = '" & NomModulo(i) & "'"))
                objSeguimiento.dtTotalesG.Rows(i).Item("E") = IIf(IsDBNull(dtaux.Compute("Sum(E)", "E Is Not Null and Modulo = '" & NomModulo(i) & "'")), 0, dtaux.Compute("Sum(E)", "E Is Not Null and Modulo = '" & NomModulo(i) & "'"))
                objSeguimiento.dtTotalesG.Rows(i).Item("T") = IIf(IsDBNull(dtaux.Compute("Sum(T)", "T Is Not Null and Modulo = '" & NomModulo(i) & "'")), 0, dtaux.Compute("Sum(T)", "T Is Not Null and Modulo = '" & NomModulo(i) & "'"))
                objSeguimiento.dtTotalesG.Rows(i).Item("O") = IIf(IsDBNull(dtaux.Compute("Sum(O)", "O Is Not Null and Modulo = '" & NomModulo(i) & "'")), 0, dtaux.Compute("Sum(O)", "O Is Not Null and Modulo = '" & NomModulo(i) & "'"))
                objSeguimiento.dtTotalesG.Rows(i).Item("P") = IIf(IsDBNull(dtaux.Compute("Sum(P)", "P Is Not Null and Modulo = '" & NomModulo(i) & "'")), 0, dtaux.Compute("Sum(P)", "P Is Not Null and Modulo = '" & NomModulo(i) & "'"))
                objSeguimiento.dtTotalesG.Rows(i).Item("H") = IIf(IsDBNull(dtaux.Compute("Sum(H)", "H Is Not Null and Modulo = '" & NomModulo(i) & "'")), 0, dtaux.Compute("Sum(H)", "H Is Not Null and Modulo = '" & NomModulo(i) & "'"))
                objSeguimiento.dtTotalesG.Rows(i).Item("PR") = IIf(IsDBNull(dtaux.Compute("Sum(PR)", "PR Is Not Null and Modulo = '" & NomModulo(i) & "'")), 0, dtaux.Compute("Sum(PR)", "PR Is Not Null and Modulo = '" & NomModulo(i) & "'"))
                objSeguimiento.dtTotalesG.Rows(i).Item("M") = IIf(IsDBNull(dtaux.Compute("Sum(M)", "M Is Not Null and Modulo = '" & NomModulo(i) & "'")), 0, dtaux.Compute("Sum(M)", "M Is Not Null and Modulo = '" & NomModulo(i) & "'"))
                objSeguimiento.dtTotalesG.Rows(i).Item("I") = IIf(IsDBNull(dtaux.Compute("Sum(I)", "I Is Not Null and Modulo = '" & NomModulo(i) & "'")), 0, dtaux.Compute("Sum(I)", "I Is Not Null and Modulo = '" & NomModulo(i) & "'"))
                objSeguimiento.dtTotalesG.Rows(i).Item("Valor") = IIf(IsDBNull(dtaux.Compute("Sum(Valor)", "Valor Is Not Null and Modulo = '" & NomModulo(i) & "'")), 0, dtaux.Compute("Sum(Valor)", "Valor Is Not Null and Modulo = '" & NomModulo(i) & "'"))
                objSeguimiento.dtTotalesG.Rows(i).Item("PromedioDia") = objSeguimiento.dtTotalesG.Rows(i).Item("Valor") / objSeguimiento.dtTotalesG.Rows(i).Item("DiasEstancia")
                objSeguimiento.dtTotalesG.Rows(i).Item("PromedioMeta") = IIf(IsDBNull(dtaux.Compute("Max(PromedioMeta)", "PromedioMeta Is Not Null and Modulo = '" & NomModulo(i) & "'")), 0, dtaux.Compute("Max(PromedioMeta)", "PromedioMeta Is Not Null and Modulo = '" & NomModulo(i) & "'"))
                objSeguimiento.dtTotalesG.Rows(i).Item("Diferencia") = objSeguimiento.dtTotalesG.Rows(i).Item("PromedioDia") - objSeguimiento.dtTotalesG.Rows(i).Item("PromedioMeta")
            Next
            If comboOpcion.SelectedIndex = 0 Then
                lbtFacturas.Visible = True
                Dim auxmod As Integer = 1
                auxmod = query.Count
                lbtEgresos.Text = " Pacientes: " & Math.Round(dtaux.Rows.Count / auxmod)
                lbtFacturas.Text = ""
                Dim queryArea = (From row In dtaux.AsEnumerable() Select row.Field(Of String)("Area")).Distinct()
                For i = 0 To queryArea.Count - 1
                    lbtFacturas.Text += " " & queryArea(i) & ": " & Math.Round(dtaux.Select("Area = '" & queryArea(i) & "'").Count / auxmod) & " - "
                Next
                objSeguimiento.cargarTotales()
                If objSeguimiento.modulo = "ad" Then

                    DifAM = objSeguimiento.dtTotalesG.Rows(objSeguimiento.dtTotalesG.Rows.Count - 2 - IIf(selFacturados.Checked, 1, 0)).Item("Valor") - objSeguimiento.dtTotalesG.Rows(objSeguimiento.dtTotalesG.Rows.Count - 3 - IIf(selFacturados.Checked, 1, 0)).Item("Valor")
                    DifAF = objSeguimiento.dtTotalesG.Rows(objSeguimiento.dtTotalesG.Rows.Count - 1 - IIf(selFacturados.Checked, 1, 0)).Item("Valor") - objSeguimiento.dtTotalesG.Rows(objSeguimiento.dtTotalesG.Rows.Count - 2 - IIf(selFacturados.Checked, 1, 0)).Item("Valor")
                    PorcentajeAM = Math.Round(((objSeguimiento.dtTotalesG.Rows(objSeguimiento.dtTotalesG.Rows.Count - 2 - IIf(selFacturados.Checked, 1, 0)).Item("Valor") * 100) / objSeguimiento.dtTotalesG.Rows(objSeguimiento.dtTotalesG.Rows.Count - 2).Item("Valor")) - 100)
                    PorcentajeAF = Math.Round(((objSeguimiento.dtTotalesG.Rows(objSeguimiento.dtTotalesG.Rows.Count - 1 - IIf(selFacturados.Checked, 1, 0)).Item("Valor") * 100) / objSeguimiento.dtTotalesG.Rows(objSeguimiento.dtTotalesG.Rows.Count - 2).Item("Valor")) - 100)
                    lbtTotalAM.Text = "Diferencia AM: " & Format(Val(DifAM), "C2") & " para un: " & PorcentajeAM & "%"
                    lbtTotalAF.Text = "Diferencia AF: " & Format(Val(DifAF), "C2") & " para un: " & PorcentajeAF & "%"
                ElseIf objSeguimiento.modulo = "ac" Then
                    DifAM = objSeguimiento.dtTotalesG.Rows(objSeguimiento.dtTotalesG.Rows.Count - 1 - IIf(selFacturados.Checked, 1, 0)).Item("Valor") - objSeguimiento.dtTotalesG.Rows(objSeguimiento.dtTotalesG.Rows.Count - 2 - IIf(selFacturados.Checked, 1, 0)).Item("Valor")
                    PorcentajeAM = Math.Round(((objSeguimiento.dtTotalesG.Rows(objSeguimiento.dtTotalesG.Rows.Count - 1 - IIf(selFacturados.Checked, 1, 0)).Item("Valor") * 100) / objSeguimiento.dtTotalesG.Rows(objSeguimiento.dtTotalesG.Rows.Count - 2 - IIf(selFacturados.Checked, 1, 0)).Item("Valor")) - 100)
                    lbtTotalAM.Text = "Diferencia AM: " & Format(Val(DifAM), "C2") & " para un: " & PorcentajeAM & "%"
                    lbtTotalAF.Visible = False
                Else
                    lbtTotalAM.Visible = False
                    lbtTotalAF.Visible = False
                End If
            Else
                lbtEgresos.Text = " EPS: " & dtaux.Rows.Count
                lbtFacturas.Visible = False
                lbtSinFacturas.Visible = False
                lbtRadicadas.Visible = False
            End If


            aplicarFormatoDgv(dgvTotalGeneral, "nRegistroG")
        Else
            lbtEgresos.Text = "Pacientes: 0"
            lbtFacturas.Text = "Areas: 0 "
        End If

    End Sub
    Private Sub dtpHastaCambio(sender As Object, e As EventArgs) Handles dtpHasta.ValueChanged, dtpDesde.ValueChanged, comboOpcion.SelectedIndexChanged,
                                                                         cbCTC.CheckedChanged, selPrefacturado.CheckedChanged, selFacturados.CheckedChanged
        If comboOpcion.SelectedIndex >= 0 Then
            cargarDatos()
        Else
            objSeguimiento.dtFacturacion.Clear()
        End If
        If selAtendidos.Checked = False Then
            dtpHasta.Enabled = True : dtpDesde.Enabled = True
        Else
            dtpHasta.Enabled = False : dtpDesde.Enabled = False
        End If
    End Sub

    Private Sub busquedaPaciente_TextChanged(sender As Object, e As EventArgs) Handles busquedaPaciente.TextChanged
        Dim cadena As String
        If objSeguimiento.dtFacturacion.Columns.Count > 0 Then
            cadena = "Paciente like '%" & Me.busquedaPaciente.Text & "%'" & " OR Identificación like '%" & Me.busquedaPaciente.Text & "%'" & " OR Area like '%" & Me.busquedaPaciente.Text & "%'" &
                     " OR EPS like '%" & Me.busquedaPaciente.Text & "%'" & " OR Factura like '%" & Me.busquedaPaciente.Text & "%'"
            data = objSeguimiento.dtFacturacion.DefaultView
            objSeguimiento.navegador.Filter = cadena
            data.RowFilter = cadena
            cargarDatos()
        End If
    End Sub

    Private Sub dgvTotalGeneral_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvTotalGeneral.CellFormatting
        If e.ColumnIndex > 9 Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), "c2")
            Else
                e.Value = Format(Val(e.Value), "c2")
            End If
            If e.ColumnIndex = 19 And Not IsDBNull(dgvTotalGeneral.Rows(e.RowIndex).Cells(20).Value) Then
                Select Case dgvTotalGeneral.Rows(e.RowIndex).Cells(1).Value
                    'Case "U.C.I.", "Hospitalización"
                    '    If e.Value <= dgvTotalGeneral.Rows(e.RowIndex).Cells(20).Value Then
                    '        dgvTotalGeneral.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Green
                    '    Else
                    '        dgvTotalGeneral.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Red
                    '    End If
                    Case "Auditoría M.", "Auditoria F."
                        If e.Value > dgvTotalGeneral.Rows(e.RowIndex).Cells(20).Value Then
                            dgvTotalGeneral.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Green
                        Else
                            dgvTotalGeneral.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Red
                        End If
                    Case Else
                        If e.Value <= dgvTotalGeneral.Rows(e.RowIndex).Cells(20).Value Then
                            dgvTotalGeneral.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Green
                        Else
                            dgvTotalGeneral.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Red
                        End If
                End Select
            ElseIf e.ColumnIndex = 21 And Not IsDBNull(dgvTotalGeneral.Rows(e.RowIndex).Cells(21).Value) Then
                Select Case dgvTotalGeneral.Rows(e.RowIndex).Cells(1).Value
                    'Case "U.C.I.", "Hospitalización"
                    '    If e.Value >= 0 Then
                    '        dgvTotalGeneral.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Red
                    '    Else
                    '        dgvTotalGeneral.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Green
                    '    End If
                    Case "Auditoría M.", "Auditoria F."
                        If e.Value >= 0 Then
                            dgvTotalGeneral.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Green
                        Else
                            dgvTotalGeneral.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Red
                        End If
                    Case Else
                        If e.Value >= 0 Then
                            dgvTotalGeneral.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Red
                        Else
                            dgvTotalGeneral.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Green
                        End If
                End Select
            End If
        End If
    End Sub

    Private Sub dgvFactura_ColumnWidthChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles dgvFactura.ColumnWidthChanged
        If dgvTotalGeneral.Columns.Contains(e.Column.Name + "G") Then
            dgvTotalGeneral.Columns(e.Column.Name + "G").Width = e.Column.Width
        End If
    End Sub

    Private Sub dgvTotalGeneral_Scroll(sender As Object, e As ScrollEventArgs) Handles dgvTotalGeneral.Scroll
        dgvFactura.HorizontalScrollingOffset = dgvTotalGeneral.HorizontalScrollingOffset
    End Sub

    Private Sub btOpcionParametroV_Click(sender As Object, e As EventArgs) Handles btOpcionParametroV.Click
        pnlMeta.BringToFront()
        pnlMeta.Visible = True
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsCancelar.Click
        pnlMeta.Visible = False
        objSeguimiento.dtAsignarMetas.Clear()
    End Sub

    Private Sub tsAgregar_Click(sender As Object, e As EventArgs) Handles tsAgregar.Click
        objSeguimiento.cargarMetas()
    End Sub

    Private Sub dgvMetas_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvMetas.CellFormatting
        If e.ColumnIndex > 0 Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), "c2")
            Else
                e.Value = Format(Val(e.Value), "c2")
            End If
        End If
    End Sub

    Private Sub tsGuardar_Click(sender As Object, e As EventArgs) Handles tsGuardar.Click
        dgvMetas.EndEdit()
        objSeguimiento.dtAsignarMetas.AcceptChanges()
        Try
            If validarMeta() AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                ConfigMetasBLL.guardarMeta(objSeguimiento)
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                pnlMeta.Visible = False
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try

    End Sub

    Private Function validarMeta()
        Dim i, j As Integer
        For i = 0 To objSeguimiento.dtAsignarMetas.Rows.Count - 1
            For j = 2 To 4
                If objSeguimiento.dtAsignarMetas.Rows(i).Item(j) = 0 Then
                    MsgBox("Valor en Cero($0) en el Area: " & objSeguimiento.dtAsignarMetas.Rows(i).Item(1) & " Modulo : " & objSeguimiento.dtAsignarMetas.Columns(j).ColumnName)
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    Private Sub dgvFactura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFactura.CellDoubleClick
        If dgvFactura.Rows.Count > 0 Then
            Dim cdgv As Integer
            objSeguimiento.codigoPaciente = dgvFactura.Rows(e.RowIndex).Cells("nRegistro").Value
            Select Case dgvFactura.Rows(e.RowIndex).Cells(1).Value
                Case "U.C.I.", "Hospitalización"
                    objSeguimiento.moduloDetalle = "ab"
                Case "Auditoría M."
                    objSeguimiento.moduloDetalle = "ac"
                Case "Auditoria F."
                    objSeguimiento.moduloDetalle = "ad"
                Case Else
                    objSeguimiento.moduloDetalle = "ab"
            End Select
            objSeguimiento.cargarPacienteFacturaDetallado()
            cdgv = dgvDetallePacientes.Rows.Count - 1
            dgvDetallePacientes.Rows(cdgv).DefaultCellStyle.BackColor = Color.LightGray
            Panel1.Height = 336
            dgvDetallePacientes.Height = 331
            Panel1.BringToFront()
            Panel1.Visible = True
            dgvDetallePacientes.Focus()
        End If
    End Sub

    Private Sub dgvDetallePacientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetallePacientes.CellDoubleClick
        Panel1.Visible = False
    End Sub

    Private Sub dgvDetallePacientes_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDetallePacientes.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Panel1.Visible = False
        End If
    End Sub

    Private Sub dgvDetallePacientes_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvDetallePacientes.CellFormatting
        If e.ColumnIndex > 9 Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), "c2")
            Else
                e.Value = Format(Val(e.Value), "c2")
            End If
        End If
    End Sub

    Private Sub dgvFactura_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvFactura.ColumnHeaderMouseClick
        colorXArea()
    End Sub

    Private Sub btnPromedioEstancia_Click(sender As Object, e As EventArgs) Handles btnPromedioEstancia.Click
        Dim promedioEstancia As New FormPromedioDiaEstancias(objSeguimiento.modulo)
        promedioEstancia.Show()
    End Sub

    Private Sub FormFacturacionDiaria_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        dgvFactura.Sort(dgvFactura.Columns("Area"), System.ComponentModel.ListSortDirection.Ascending)
        colorXArea()
    End Sub
End Class