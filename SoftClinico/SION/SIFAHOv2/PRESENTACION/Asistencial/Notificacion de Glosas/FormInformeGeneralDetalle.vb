Public Class FormInformeGeneralDetalle
    Dim dtGlosa As New DataTable
    Private Sub FormInformeGeneralGlosa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cadena As String = ""
        cargarComboEps(Consultas.NOTIFICACION_GLOSA_BUSCAR_CLIENTES & "'" & cadena & "'" & "," & "'" & SesionActual.idEmpresa & "'", "Cliente", "Id_Cliente", Comboeps)
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form__FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub cargarComboEps(ByVal consulta As String,
                                  ByVal vlrDisplayMember As String,
                                  ByVal vlrValueMember As String,
                                  ByVal cbCombo As ComboBox)
        Dim dtTabla As New DataTable
        Try

            Dim drFila As DataRow = dtTabla.NewRow()
            dtTabla.Columns.Add(vlrValueMember)
            dtTabla.Columns.Add(vlrDisplayMember)
            drFila.Item(0) = "-1"
            drFila.Item(1) = " - - - Seleccione - - -"
            dtTabla.Rows.Add(drFila)
            dtTabla.Rows.Add("", "------------ TODAS -----------")
            Using da = New SqlDataAdapter(consulta, FormPrincipal.cnxion)
                da.Fill(dtTabla)
            End Using
            cbCombo.DataSource = dtTabla
            cbCombo.DisplayMember = vlrDisplayMember
            cbCombo.ValueMember = vlrValueMember
            If TypeOf cbCombo Is ComboBox Then
                If dtTabla.Rows.Count > 10 Then
                    cbCombo.DropDownStyle = ComboBoxStyle.DropDown
                    cbCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                    cbCombo.AutoCompleteSource = AutoCompleteSource.ListItems
                Else
                    cbCombo.AutoCompleteMode = AutoCompleteMode.None
                    cbCombo.AutoCompleteSource = AutoCompleteSource.None
                    cbCombo.DropDownStyle = ComboBoxStyle.DropDownList
                End If
            End If
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
    End Sub
    Public Sub llenarDvgGlosas(fechaIni As Date, fechaFin As Date, eps As String)

        Dim params As New List(Of String)
        params.Add(fechaIni)
        params.Add(fechaFin)
        params.Add(eps)
        params.Add(SesionActual.idEmpresa)

        General.llenarTabla(Consultas.INFORME_GENERAL, params, dtGlosa)

        dgvDetalleGlosa.DataSource = dtGlosa
        dgvDetalleGlosa.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDetalleGlosa.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDetalleGlosa.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDetalleGlosa.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDetalleGlosa.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDetalleGlosa.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDetalleGlosa.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDetalleGlosa.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDetalleGlosa.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDetalleGlosa.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDetalleGlosa.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDetalleGlosa.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        calcularValores()
    End Sub
    Private Sub calcularValores()
        Dim totalFactura, valorObjecion, valorGlosaDefinitiva, totalLevantado, totalConciliar, totalDevolucion, totalDevAceptada As Double
        totalFactura = 0
        valorObjecion = 0
        valorGlosaDefinitiva = 0
        totalLevantado = 0
        totalConciliar = 0
        For indice = 0 To dtGlosa.Rows.Count - 1
            If IsNumeric(dtGlosa.Rows(indice).Item(1)) Then
                totalFactura = totalFactura + CDbl(dtGlosa.Rows(indice).Item(1))
            End If
            If IsNumeric(dtGlosa.Rows(indice).Item(2)) Then
                valorObjecion = valorObjecion + CDbl(dtGlosa.Rows(indice).Item(2))
            End If
            If IsNumeric(dtGlosa.Rows(indice).Item(3)) Then
                valorGlosaDefinitiva = valorGlosaDefinitiva + CDbl(dtGlosa.Rows(indice).Item(3))
            End If
            If IsNumeric(dtGlosa.Rows(indice).Item(4)) Then
                totalLevantado = totalLevantado + CDbl(dtGlosa.Rows(indice).Item(4))
            End If
            If IsNumeric(dtGlosa.Rows(indice).Item(5)) Then
                totalConciliar = totalConciliar + CDbl(dtGlosa.Rows(indice).Item(5))
            End If
            If IsNumeric(dtGlosa.Rows(indice).Item(8)) Then
                totalDevolucion = totalDevolucion + CDbl(dtGlosa.Rows(indice).Item(8))
            End If
            If IsNumeric(dtGlosa.Rows(indice).Item(9)) Then
                totalDevAceptada = totalDevAceptada + CDbl(dtGlosa.Rows(indice).Item(9))
            End If
        Next
        TexttotalFactura.Text = Format(totalFactura, "C0")
        TextValorObjecion.Text = Format(valorObjecion, "C0")
        TextGlosaDefinitiva.Text = Format(valorGlosaDefinitiva, "C0")
        TextValorLevantado.Text = Format(totalLevantado, "C0")
        TextPorcentajeObjec.Text = Format((valorObjecion / totalFactura), "P2")
        TextPorcentajeGlosa.Text = Format((valorGlosaDefinitiva / totalFactura), "P2")
        TextValorConciliacion.Text = Format(totalConciliar, "C0")
        TextValorDevolucion.Text = Format(totalDevolucion, "C0")
        TextValorDevAceptada.Text = Format(totalDevAceptada, "C0")
    End Sub
    Private Sub Comboeps_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Comboeps.SelectedIndexChanged
        If Comboeps.SelectedIndex <> 0 Then
            llenarDvgGlosas(CDate(fechainicio.Value).Date, CDate(fechafinal.Value).Date, Comboeps.SelectedValue)
        Else
            dtGlosa.Clear()
        End If
    End Sub

    Private Sub dgvDetalleGlosa_CellFormatting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvDetalleGlosa.CellFormatting
        If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 3 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5 Or e.ColumnIndex = 8 Or e.ColumnIndex = 9 Then
            If IsNumeric(e.Value) Then
                e.Value = Format(Val(e.Value), "C0")
            End If
        ElseIf e.ColumnIndex = 6 Or e.ColumnIndex = 7 Then
            If IsNumeric(e.Value) Then
                e.Value = Format(Val(e.Value) / 100, "P2")
            End If
        End If
    End Sub

    'Private Sub fechainicio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles fechainicio.ValueChanged
    '    If Comboeps.SelectedIndex <> 0 And Comboeps.SelectedIndex <> 0 Then
    '        llenarDvgGlosas(CDate(fechainicio.Value).Date, CDate(fechafinal.Value).Date, Comboeps.SelectedValue)
    '    Else
    '        dtGlosa.Clear()
    '    End If
    'End Sub

    'Private Sub fechafinal_ValueChanged(sender As System.Object, e As System.EventArgs) Handles fechafinal.ValueChanged
    '    If Comboeps.SelectedIndex <> 0 Then
    '        llenarDvgGlosas(CDate(fechainicio.Value).Date, CDate(fechafinal.Value).Date, Comboeps.SelectedValue)
    '    Else
    '        dtGlosa.Clear()
    '    End If
    'End Sub
    Private Sub fechainicio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles fechainicio.KeyPress
        If e.KeyChar = Chr(13) Then
            If Comboeps.SelectedIndex <> 0 Then
                llenarDvgGlosas(CDate(fechainicio.Value).Date, CDate(fechafinal.Value).Date, Comboeps.SelectedValue)
            Else
                dtGlosa.Clear()
            End If
        End If
    End Sub
    Private Sub fechafinal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles fechafinal.KeyPress
        If e.KeyChar = Chr(13) Then
            If Comboeps.SelectedIndex <> 0 Then
                llenarDvgGlosas(CDate(fechainicio.Value).Date, CDate(fechafinal.Value).Date, Comboeps.SelectedValue)
            Else
                dtGlosa.Clear()
            End If
        End If
    End Sub
    Private Sub btestadistica_Click(sender As Object, e As EventArgs)
        MsgBox("Hola! " & (FormPrincipal.Textnombre_completo.Text.ToLower()) & " esta función se encuentra en desarrollo, para mayor información visite la página www.celerteam.com", MsgBoxStyle.Information)
    End Sub

    Private Sub btexcel_Click(sender As Object, e As EventArgs)
        MsgBox("Hola! " & (FormPrincipal.Textnombre_completo.Text.ToLower()) & " esta función se encuentra en desarrollo, para mayor información visite la página www.celerteam.com", MsgBoxStyle.Information)

    End Sub
End Class