Public Class FormInformeGeneralGlosa
    Dim dtGlosa As New DataTable
    Public Property formulario As Integer = 0
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
            General.manejoErrores(ex) 
        End Try
    End Sub
    Public Sub llenarDvgGlosas(fechaIni As Date, fechaFin As Date, eps As String)
        Cursor = Cursors.WaitCursor
        Dim consulta As String
        Dim params As New List(Of String)
        params.Add(fechaIni)
        params.Add(fechaFin)
        params.Add(eps)
        If formulario = 1 Then
            consulta = Consultas.INFORME_GENERAL_DEVOLUCION
        Else
            consulta = Consultas.INFORME_DETALLADO_GLOSA
        End If
        General.llenarTabla(consulta, params, dtGlosa)
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
        dgvDetalleGlosa.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDetalleGlosa.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDetalleGlosa.Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDetalleGlosa.Columns(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDetalleGlosa.Columns(14).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDetalleGlosa.Columns(15).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDetalleGlosa.Columns(16).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDetalleGlosa.Columns(17).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDetalleGlosa.Columns(18).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDetalleGlosa.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        calcularValores()
        Cursor = Cursors.Default
    End Sub
    Private Sub calcularValores()
        Dim valorFactura, valorObjecion, valorGlosa, valorLevantado As Double
        valorFactura = 0
        valorObjecion = 0
        valorGlosa = 0
        valorLevantado = 0
        For indiceDtGlosa = 0 To dtGlosa.Rows.Count - 1
            If IsNumeric(dtGlosa.Rows(indiceDtGlosa).Item(3)) Then
                valorFactura = valorFactura + CDbl(dtGlosa.Rows(indiceDtGlosa).Item(3))
            End If
            If IsNumeric(dtGlosa.Rows(indiceDtGlosa).Item(4)) Then
                valorObjecion = valorObjecion + CDbl(dtGlosa.Rows(indiceDtGlosa).Item(4))
            End If
            If IsNumeric(dtGlosa.Rows(indiceDtGlosa).Item(5)) Then
                valorGlosa = valorGlosa + CDbl(dtGlosa.Rows(indiceDtGlosa).Item(5))
            End If
            If IsNumeric(dtGlosa.Rows(indiceDtGlosa).Item(6)) Then
                valorLevantado = valorLevantado + CDbl(dtGlosa.Rows(indiceDtGlosa).Item(6))
            End If
        Next
        Textvalorfactura.Text = Format(valorFactura, "C0")
        Textvalorobjecion.Text = Format(valorObjecion, "C0")
        Textvalorglosa.Text = Format(valorGlosa, "C0")
        Textvalorlevantado.Text = Format(valorLevantado, "C0")
        Lnumfactura.Text = dtGlosa.Rows.Count
    End Sub
    Private Sub Comboeps_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Comboeps.SelectedIndexChanged
        If Comboeps.SelectedIndex <> 0 Then
            llenarDvgGlosas(CDate(fechainicio.Value).Date, CDate(fechafinal.Value).Date, Comboeps.SelectedValue)
        Else
            dtGlosa.Clear()
        End If
    End Sub
    Private Sub dgvDetalleGlosa_CellFormatting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvDetalleGlosa.CellFormatting
        If e.ColumnIndex = 3 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5 Or e.ColumnIndex = 6 Or e.ColumnIndex = 11 Or e.ColumnIndex = 12 Then
            If IsNumeric(e.Value) Then
                e.Value = Format(Val(e.Value), "C0")
            End If
        ElseIf e.ColumnIndex = 9 Or e.ColumnIndex = 10 Then
            If IsNumeric(e.Value) Then
                e.Value = Format(Val(e.Value) / 100, "P2")
            End If
        End If
    End Sub

    'Private Sub fechainicio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles fechainicio.KeyPress
    '    If e.KeyChar = Chr(13) Then
    '        If Comboeps.SelectedIndex <> 0 Then
    '            llenarDvgGlosas(CDate(fechainicio.Value).Date, CDate(fechafinal.Value).Date, Comboeps.SelectedValue)
    '        Else
    '            dtGlosa.Clear()
    '        End If
    '    End If
    'End Sub
    'Private Sub fechafinal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles fechafinal.KeyPress
    '    If e.KeyChar = Chr(13) Then
    '        If Comboeps.SelectedIndex <> 0 Then
    '            llenarDvgGlosas(CDate(fechainicio.Value).Date, CDate(fechafinal.Value).Date, Comboeps.SelectedValue)
    '        Else
    '            dtGlosa.Clear()
    '        End If
    '    End If
    'End Sub
    Public Function crearObjeto() As InformeDetalleGlosa
        Dim objDetalleGlosa As New InformeDetalleGlosa
        objDetalleGlosa.dtGlosa.Clear()
        For Each drFila As DataRow In dtGlosa.Rows
            Dim drCuenta As DataRow = objDetalleGlosa.dtGlosa.NewRow
            drCuenta.Item("mes") = drFila.Item("mes")
            drCuenta.Item("eps") = drFila.Item("Nombre eps")
            drCuenta.Item("factura") = drFila.Item("factura")
            drCuenta.Item("valor") = drFila.Item("valor factura")
            drCuenta.Item("objecion") = drFila.Item("Valor objeción")
            drCuenta.Item("glosa") = drFila.Item("Valor glosa")
            drCuenta.Item("levantada") = drFila.Item("Valor levantado")
            drCuenta.Item("fecha_c") = drFila.Item("fecha de conciliación")
            drCuenta.Item("fecha_r") = drFila.Item("fecha de Radicación")
            drCuenta.Item("porc_obj") = drFila.Item("% objeción")
            drCuenta.Item("porc_glosa") = drFila.Item("% glosa definitiva")
            drCuenta.Item("devolucion") = drFila.Item("Valor devolución")
            drCuenta.Item("devolucion_aceptada") = drFila.Item("Valor devolución aceptado")
            objDetalleGlosa.dtGlosa.Rows.Add(drCuenta)
        Next
        Return objDetalleGlosa
    End Function
    Private Sub guardar()
        Dim objInformeGlosaBll As New InformeEstadisticoGlosaBLL
        objInformeGlosaBll.guardarNotificacionGlosa(crearObjeto())
    End Sub

    Private Sub btestadistica_Click(sender As Object, e As EventArgs) Handles btestadistica.Click
        MsgBox("Hola! " & (FormPrincipal.Textnombre_completo.Text.ToLower()) & " esta función se encuentra en desarrollo, para mayor información comuniquese a la linea 01 8000 777 422 ó visitenos en www.celerteam.com", MsgBoxStyle.Information)
        'guardar()
        'Dim rptInformeGlosa As New rptInformeGlosa
        'Try
        '    Cursor = Cursors.WaitCursor
        '    Funciones.getReporteNoFTP(rptInformeGlosa, "{VISTA_EMPRESAS.Id_empresa}=" & SesionActual.idEmpresa & "", "Informe Glosa", Constantes.FORMATO_PDF)
        '    Cursor = Cursors.Default
        'Catch ex As Exception
        '    General.manejoErrores(ex)
        'End Try
        'Cursor = Cursors.Default
    End Sub
    Private Sub btexcel_Click(sender As Object, e As EventArgs) Handles btexcel.Click
        btexcel.Enabled = False
        'Cursor = Cursors.WaitCursor
        Try
            Dim nombreRpt As String = "Informe Detallado"
            'Dim dtInforme As New DataTable
            'Dim params As New List(Of String)
            'params.Add(CDate(fechainicio.Value).Date)
            'params.Add(CDate(fechafinal.Value).Date)
            'params.Add(Comboeps.SelectedValue)
            Cursor = Cursors.WaitCursor
            'General.llenarTabla(Consultas.INFORME_DETALLADO_GLOSA, params, dtInforme)
            Dim rutaArchivo As String = FuncionesExcel.exportarDataTable(dtGlosa, nombreRpt)
            Process.Start("file:///" & rutaArchivo)
        Catch ex As Exception
            general.manejoErrores(ex)
        Finally

        End Try
        Cursor = Cursors.Default
        btexcel.Enabled = True
    End Sub


    Private Sub btGenerar_Click(sender As Object, e As EventArgs) Handles btGenerar.Click
        If Comboeps.SelectedIndex <> 0 Then
            llenarDvgGlosas(CDate(fechainicio.Value).Date, CDate(fechafinal.Value).Date, Comboeps.SelectedValue)
        Else
            dtGlosa.Clear()
        End If
    End Sub
End Class