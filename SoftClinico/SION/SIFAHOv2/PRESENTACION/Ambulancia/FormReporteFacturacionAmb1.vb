Public Class FormReporteFacturacionAmb
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Panular, PBuscar As String
    Dim objReporteFacAM As ReporteFacturacionAM
    Dim source1, source2, source3 As New BindingSource
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub TabControl1_Selected(sender As Object, e As TabControlEventArgs) Handles TabControl1.Selected
        If e.TabPageIndex = 0 Then
            lbregistros.Text = "Total Registros: " + dgvTraslados.RowCount.ToString
        ElseIf e.TabPageIndex = 1 Then
            lbregistros.Text = "Total Registros: " + dgvDetalle.RowCount.ToString
        ElseIf e.TabPageIndex = 2 Then
            lbregistros.Text = "Total Registros: " + dgvConsolidado.RowCount.ToString
        End If
        dgvTraslados.ClearSelection()
        dgvDetalle.ClearSelection()
        dgvConsolidado.ClearSelection()
        camb_tab_vr(e.TabPageIndex)
    End Sub
    Private Sub Modulos_perfil_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub dataRangoA1_CloseUp(sender As Object, e As EventArgs) Handles dataRangoA1.CloseUp
        dataRangoA2.Value = dataRangoA1.Value
        dataRangoA3.Value = dataRangoA1.Value
        If dataRangoA1.Value > dataRangoB1.Value Then
            dataRangoB1.Value = dataRangoA1.Value
            dataRangoB2.Value = dataRangoA2.Value
            dataRangoB3.Value = dataRangoA3.Value
        End If
        llenardgvDetalle()
        llenardgvConsolidado()
        llenardgvTraslado()
    End Sub

    Private Sub dataRangoB1_CloseUp(sender As Object, e As EventArgs) Handles dataRangoB1.CloseUp
        dataRangoB2.Value = dataRangoB1.Value
        dataRangoB3.Value = dataRangoB1.Value
        If dataRangoB1.Value < dataRangoA1.Value Then
            dataRangoA1.Value = dataRangoB1.Value
            dataRangoA2.Value = dataRangoB2.Value
            dataRangoA3.Value = dataRangoB3.Value
        End If
        llenardgvDetalle()
        llenardgvConsolidado()
        llenardgvTraslado()
    End Sub

    Private Sub txtBusqueda1_TextChanged(sender As Object, e As EventArgs) Handles txtBusqueda1.TextChanged
        txtBusqueda1.Text = Funciones.validarComillaSimple(txtBusqueda1.Text)
        If txtBusqueda1.Text.Trim <> "" Or objReporteFacAM.dtTablaTraslado.Columns.Count < 1 Then
            llenardgvTraslado()
        End If
    End Sub

    Private Sub btBorrar1_Click(sender As Object, e As EventArgs)
        txtBusqueda1.Focus()
        txtBusqueda1.Text = ""
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs)
        If SesionActual.tienePermiso(Pnuevo ) Then
            If TabControl1.SelectedIndex = 1 Then
                General.limpiarControles(Me)
            Else
                TabControl1.SelectedIndex = 1
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub dataRangoA2_CloseUp(sender As Object, e As EventArgs) Handles dataRangoA2.CloseUp
        dataRangoA1.Value = dataRangoA2.Value
        dataRangoA3.Value = dataRangoA2.Value
        If dataRangoA2.Value > dataRangoB2.Value Then
            dataRangoB2.Value = dataRangoA2.Value
            dataRangoB1.Value = dataRangoA1.Value
            dataRangoB3.Value = dataRangoA3.Value
        End If
        llenardgvConsolidado()
        llenardgvTraslado()
        llenardgvDetalle()
    End Sub

    Private Sub camb_tab_vr(ByVal tab As Integer)
        If StatusBar1.Panels.Contains(lbVrTraslados) Then StatusBar1.Panels.Remove(lbVrTraslados)
        If StatusBar1.Panels.Contains(lbVrDetalle) Then StatusBar1.Panels.Remove(lbVrDetalle)
        If StatusBar1.Panels.Contains(lbVrDetalle1) Then StatusBar1.Panels.Remove(lbVrDetalle1)
        If StatusBar1.Panels.Contains(lbVrDetalle2) Then StatusBar1.Panels.Remove(lbVrDetalle2)
        If StatusBar1.Panels.Contains(lbVrDetalle3) Then StatusBar1.Panels.Remove(lbVrDetalle3)
        If StatusBar1.Panels.Contains(lbVrDetalle4) Then StatusBar1.Panels.Remove(lbVrDetalle4)
        If StatusBar1.Panels.Contains(lbVrDetalle5) Then StatusBar1.Panels.Remove(lbVrDetalle5)
        If StatusBar1.Panels.Contains(lbVrDetalle6) Then StatusBar1.Panels.Remove(lbVrDetalle6)
        If StatusBar1.Panels.Contains(lbVrConsolidado) Then StatusBar1.Panels.Remove(lbVrConsolidado)
        Select Case tab
            Case 0
                StatusBar1.Panels.Insert(1, lbVrTraslados)
            Case 1
                StatusBar1.Panels.Insert(1, lbVrDetalle)
                StatusBar1.Panels.Insert(2, lbVrDetalle1)
                StatusBar1.Panels.Insert(3, lbVrDetalle2)
                StatusBar1.Panels.Insert(4, lbVrDetalle3)
                StatusBar1.Panels.Insert(5, lbVrDetalle4)
                StatusBar1.Panels.Insert(6, lbVrDetalle5)
                StatusBar1.Panels.Insert(7, lbVrDetalle6)
            Case 2
                StatusBar1.Panels.Insert(1, lbVrConsolidado)
        End Select
    End Sub

    Private Sub dataRangoA3_CloseUp(sender As Object, e As EventArgs) Handles dataRangoA3.CloseUp
        dataRangoA1.Value = dataRangoA3.Value
        dataRangoA2.Value = dataRangoA3.Value
        If dataRangoA3.Value > dataRangoB3.Value Then
            dataRangoB3.Value = dataRangoA3.Value
            dataRangoB1.Value = dataRangoA1.Value
            dataRangoB2.Value = dataRangoA2.Value
        End If
        llenardgvDetalle()
        llenardgvTraslado()
        llenardgvConsolidado()
    End Sub

    Private Sub FormReporteFacturacionAmb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            objReporteFacAM = New ReporteFacturacionAM
            objReporteFacAM.usuario = SesionActual.idUsuario
            'permisos de uso de boton
            permiso_general = perG.buscarPermisoGeneral(Name)
            Pnuevo = permiso_general & "pp" & "01"
            Panular = permiso_general & "pp" & "02"
            PBuscar = permiso_general & "pp" & "03"
            'asociar dgv con datatable
            dgvTraslados.DataSource = objReporteFacAM.dtTablaTraslado
            dgvTraslados.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvTraslados.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            inicializar_barra()
            dgvDetalle.DataSource = objReporteFacAM.dtTablaDetalle
            dgvDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvDetalle.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            dgvConsolidado.DataSource = objReporteFacAM.dtTablaConsolidado
            dgvConsolidado.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvConsolidado.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            lbfecha.Text = "Hoy es " + StrConv(DateTime.Now.ToString("dddd, dd MMMM yyyy"), 3)
            Dim hoy = DateTime.Now
            dataRangoA1.Value = hoy.AddDays(-(hoy.Day - 1))
            dataRangoA2.Value = dataRangoA1.Value
            dataRangoA3.Value = dataRangoA1.Value
            dataRangoB1.Value = dataRangoA1.Value.AddDays(DateTime.DaysInMonth(hoy.Year, hoy.Month) - 1)
            dataRangoB2.Value = dataRangoB1.Value
            dataRangoB3.Value = dataRangoB1.Value
            llenardgvTraslado()
            ValidarDgvDetalles()
            llenardgvDetalle()
            llenardgvConsolidado()
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
    End Sub
    Private Sub ValidarDgvDetalles()
        With dgvDetalle
            .Columns(0).DataPropertyName = "No."
            .Columns(1).DataPropertyName = "Fecha"
            .Columns(2).DataPropertyName = "Hora Salida"
            .Columns(3).DataPropertyName = "Hora Llegada"
            .Columns(4).DataPropertyName = "Hora Salida2"
            .Columns(5).DataPropertyName = "Hora Regreso"
            .Columns(6).DataPropertyName = "Paciente"
            .Columns(7).DataPropertyName = "Documento"
            .Columns(8).DataPropertyName = "Diagnostico"
            .Columns(9).DataPropertyName = "Tipo"
            .Columns(10).DataPropertyName = "Origen1"
            .Columns(11).DataPropertyName = "Destino"
            .Columns(12).DataPropertyName = "Origen2"
            .Columns(13).DataPropertyName = "Administrativo"
            .Columns(14).DataPropertyName = "MÉDICO"
            .Columns(15).DataPropertyName = "Auxiliar"
            .Columns(16).DataPropertyName = "Fisioterapeuta"
            .Columns(17).DataPropertyName = "Conductor"
            .Columns(18).DataPropertyName = "Contacto"
            .Columns(19).DataPropertyName = "EPS"
            .Columns(20).DataPropertyName = "Cliente"
            .Columns(21).DataPropertyName = "Factura"
            .DataSource = objReporteFacAM.dtTablaDetalle
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .AutoGenerateColumns = False
        End With
    End Sub

    Private Sub dataRangoB2_CloseUp(sender As Object, e As EventArgs) Handles dataRangoB2.CloseUp
        dataRangoB1.Value = dataRangoB2.Value
        dataRangoB3.Value = dataRangoB2.Value
        If dataRangoB2.Value < dataRangoA2.Value Then
            dataRangoA2.Value = dataRangoB2.Value
            dataRangoA1.Value = dataRangoB1.Value
            dataRangoA3.Value = dataRangoB3.Value
        End If
        llenardgvConsolidado()
        llenardgvTraslado()
        llenardgvDetalle()
    End Sub

    Private Sub dataRangoB3_CloseUp(sender As Object, e As EventArgs) Handles dataRangoB3.CloseUp
        dataRangoB1.Value = dataRangoB3.Value
        dataRangoB2.Value = dataRangoB3.Value
        If dataRangoB3.Value < dataRangoA3.Value Then
            dataRangoA3.Value = dataRangoB3.Value
            dataRangoA2.Value = dataRangoB2.Value
            dataRangoA1.Value = dataRangoB1.Value
        End If
        llenardgvDetalle()
        llenardgvTraslado()
        llenardgvConsolidado()
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs)
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.buscarElemento(objReporteFacAM.sqlBuscarReporteInfAM,
                              Nothing,
                              AddressOf cargarReporteInfAM,
                              TitulosForm.BUSQUEDA_REPORTE_INF_AM,
                              False)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargarReporteInfAM()

    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs)
        'Guarda en base de datos del Reporte Informativo Ambulancia
        Dim fData As Integer
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            fData = objReporteFacAM.dtTablaDetalle.Rows.Count
            cargarObjetoReporteInfoAM()

            ' objAtencionAM.dtTablaDiagnostico.Rows.RemoveAt(objAtencionAM.dtTablaDiagnostico.Rows.Count - 1)
            Try
                'AtencionAmBLL.guardarAtencionAM(objAtencionAM)
                'General.habilitarBotones(ToolStrip1)
                'General.deshabilitarControles(Me)
                'btguardar.Enabled = False
                'btcancelar.Enabled = False
                'textCodTraslado.Text = objAtencionAM.codAtencion
                'MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            Catch ex As Exception
                general.manejoErrores(ex) 
            End Try
        End If
    End Sub
    Sub cargarObjetoReporteInfoAM()
        objReporteFacAM.diaInicial = dataRangoA2.Value
        objReporteFacAM.diaFinal = dataRangoB2.Value
        objReporteFacAM.cantidad = lbregistros.Text
        objReporteFacAM.valorTotal = lbVrDetalle.Text
    End Sub

    Private Sub TxtBusqueda2_TextChanged(sender As Object, e As EventArgs) Handles TxtBusqueda2.TextChanged
        TxtBusqueda2.Text = Funciones.validarComillaSimple(TxtBusqueda2.Text)
        If TxtBusqueda2.Text.Trim <> "" Or objReporteFacAM.dtTablaDetalle.Columns.Count < 1 Then
            llenardgvDetalle()
        End If
    End Sub

    Private Sub TxtBusqueda3_TextChanged(sender As Object, e As EventArgs) Handles TxtBusqueda3.TextChanged
        TxtBusqueda3.Text = Funciones.validarComillaSimple(TxtBusqueda3.Text)
        If TxtBusqueda3.Text.Trim <> "" Or objReporteFacAM.dtTablaConsolidado.Columns.Count < 1 Then
            llenardgvConsolidado()
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If TabControl1.SelectedTab.TabIndex = 0 Then
            Dim rptRFacturacion As New rptReporteFactura2()
            rptRFacturacion.SetParameterValue("@FECHA1", dataRangoA3.Value)
            rptRFacturacion.SetParameterValue("@FECHA2", dataRangoB3.Value)
            rptRFacturacion.SetParameterValue("@CADENA", TxtBusqueda3.Text)
            Exec.getReport(rptRFacturacion, "{VISTA_EMPRESAS.Id_empresa}=" & SesionActual.idEmpresa, "Reporte Facturación")
        ElseIf TabControl1.SelectedTab.TabIndex = 1 Then

        ElseIf TabControl1.SelectedTab.TabIndex = 2 Then
            Dim rptRFacturacion As New rptReporteFacturacion()
            rptRFacturacion.SetParameterValue("@FECHA1", dataRangoA3.Value)
            rptRFacturacion.SetParameterValue("@FECHA2", dataRangoB3.Value)
            rptRFacturacion.SetParameterValue("@CADENA", TxtBusqueda3.Text)
            Exec.getReport(rptRFacturacion, "{VISTA_EMPRESAS.Id_empresa}=" & SesionActual.idEmpresa, "Reporte Facturación")
        End If
        'If txtcodigo.Text = "" Then btnImprimir.Enabled = False : Return

    End Sub

    Dim lbregistros, lbVrTraslados, lbVrDetalle, lbVrDetalle1, lbVrDetalle2, lbVrDetalle3, lbVrDetalle4, lbVrDetalle5, lbVrDetalle6, lbVrConsolidado, lbfecha As New StatusBarPanel()
    Private Sub inicializar_barra()
        lbregistros.AutoSize = 3
        lbVrTraslados.AutoSize = 2
        lbVrDetalle.AutoSize = 3
        lbVrDetalle1.AutoSize = 3
        lbVrDetalle2.AutoSize = 3
        lbVrDetalle3.AutoSize = 3
        lbVrDetalle4.AutoSize = 3
        lbVrDetalle5.AutoSize = 3
        lbVrDetalle6.AutoSize = 2
        lbVrConsolidado.AutoSize = 2
        lbfecha.AutoSize = 3
        StatusBar1.Panels.Clear()
        StatusBar1.Panels.Add(lbregistros)
        StatusBar1.Panels.Add(lbVrTraslados)
        StatusBar1.Panels.Add(lbfecha)
    End Sub
    Private Sub llenardgvTraslado()
        Dim params As New List(Of String)
        params.Add(CDate(dataRangoA1.Value).Date)
        params.Add(CDate(dataRangoB1.Value).Date)
        params.Add(txtBusqueda1.Text)
        General.llenarTabla(ConsultasAmbu.FACTURA_TRASLADO_AM_CARGAR, params, objReporteFacAM.dtTablaTraslado)
        lbregistros.Text = "Total Registros: " + dgvTraslados.RowCount.ToString
        If dgvTraslados.RowCount = 0 Then
            dgvTraslados.BackgroundColor = SystemColors.AppWorkspace
            lbVrTraslados.Text = "Valor Total $ 0"
        Else
            dgvTraslados.BackgroundColor = Color.White
            Dim VlrTotal = objReporteFacAM.dtTablaTraslado.Compute("SUM([Valor])", source1.Filter)
            lbVrTraslados.Text = "Valor Total " + CDec(If(IsNumeric(VlrTotal), VlrTotal, 0)).ToString("C0")
        End If
    End Sub
    Private Sub llenardgvDetalle()
        Dim params As New List(Of String)
        params.Add(CDate(dataRangoA2.Value).Date)
        params.Add(CDate(dataRangoB2.Value).Date)
        params.Add(TxtBusqueda2.Text)
        General.llenarTabla(ConsultasAmbu.FACTURA_TRASLADO_DETALLE_AM_CARGAR, params, objReporteFacAM.dtTablaDetalle)
        lbregistros.Text = "Total Registros: " + dgvDetalle.RowCount.ToString
        If dgvDetalle.RowCount = 0 Then
            dgvDetalle.BackgroundColor = SystemColors.AppWorkspace
        Else
            dgvDetalle.BackgroundColor = Color.White
            General.llenarTabla(ConsultasAmbu.FACTURA_TRASLADO_PIE_DETALLE_AM_CARGAR, params, objReporteFacAM.dtTablaPIEDetalle)
            lbVrDetalle.Text = objReporteFacAM.dtTablaPIEDetalle(0)(0)
            lbVrDetalle1.Text = objReporteFacAM.dtTablaPIEDetalle(0)(1)
            lbVrDetalle2.Text = objReporteFacAM.dtTablaPIEDetalle(0)(2)
            lbVrDetalle3.Text = objReporteFacAM.dtTablaPIEDetalle(0)(3)
            lbVrDetalle4.Text = objReporteFacAM.dtTablaPIEDetalle(0)(4)
            lbVrDetalle5.Text = objReporteFacAM.dtTablaPIEDetalle(0)(5)
            lbVrDetalle6.Text = objReporteFacAM.dtTablaPIEDetalle(0)(6)
        End If
    End Sub
    Private Sub llenardgvConsolidado()
        Dim params As New List(Of String)
        params.Add(CDate(dataRangoA3.Value).Date)
        params.Add(CDate(dataRangoB3.Value).Date)
        params.Add(TxtBusqueda3.Text)
        General.llenarTabla(ConsultasAmbu.FACTURA_TRASLADO_CONSOLIDADO_AM_CARGAR, params, objReporteFacAM.dtTablaConsolidado)
        lbregistros.Text = "Total Registros: " + dgvConsolidado.RowCount.ToString
        If dgvConsolidado.RowCount = 0 Then
            dgvConsolidado.BackgroundColor = SystemColors.AppWorkspace
            lbVrConsolidado.Text = "Valor Total $ 0"
        Else
            dgvConsolidado.BackgroundColor = Color.White
            Dim VlrTotal = objReporteFacAM.dtTablaConsolidado.Compute("SUM([valorTotal])", source3.Filter)
            lbVrConsolidado.Text = "Valor Total " + CDec(If(IsNumeric(VlrTotal), VlrTotal, 0)).ToString("C0")
        End If
    End Sub
End Class