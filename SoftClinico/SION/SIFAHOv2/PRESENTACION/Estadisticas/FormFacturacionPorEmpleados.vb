Public Class FormFacturacionPorEmpleados
    Dim objMeta As New MetaEmpleado
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, pConfig, pGuardar As String
    Private Sub btOpcionPedidoFarm_Click(sender As Object, e As EventArgs) Handles btOpcionMeta.Click
        If SesionActual.tienePermiso(pConfig) Then
            FormPrincipal.Cursor = Cursors.WaitCursor
            FormConfigMetaEmpleado.MdiParent = FormPrincipal
            General.limpiarControles(FormConfigMetaEmpleado)
            FormConfigMetaEmpleado.iniciarForm(Me)
            FormConfigMetaEmpleado.Show()
            FormConfigMetaEmpleado.cargarEmpleado()
            FormConfigMetaEmpleado.Focus()
            FormPrincipal.Cursor = Cursors.Default
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub
    Public Sub cargarEmpleadoMeta()
        If IsNumeric(cbCargo.SelectedValue) Then
            If cbCargo.SelectedIndex = 0 Then
                objMeta.dtConsolidado.Clear()
                objMeta.dtConsolidadoPeriodo.Clear()
                objMeta.diferencia = 0
                objMeta.porcentaje = 0
            Else
                btHistoricoMeta.Enabled = Not cbTodo.Checked
                objMeta.fechaInicio = fechaInicio.Value
                objMeta.fechaFin = fechaFin.Value
                objMeta.CTC = cbCTC.Checked
                objMeta.todo = cbTodo.Checked
                objMeta.CodigoCargo = cbCargo.SelectedValue
                objMeta.cargarMeta()
            End If
            textbusqueda1.Clear()
            colorear()
            colorearDetalle()
        End If
    End Sub
    Private Sub colorear()
        lblDiferencia.Text = CDbl(objMeta.diferencia).ToString("c0")
        lblPorcentaje.Text = CDbl(objMeta.porcentaje / 100).ToString("p2")
        If objMeta.diferencia >= 0 Then
            lblPorcentaje.ForeColor = Color.Green
            lblDiferencia.ForeColor = Color.Green
        Else
            lblPorcentaje.ForeColor = Color.Red
            lblDiferencia.ForeColor = Color.Red
        End If

    End Sub
    Public Sub colorearDetalle()
        For i = 0 To dgvMetas.RowCount - 1
            dgvMetas.Rows(i).Cells("dgTotal").Style.ForeColor = Color.Black
            If String.IsNullOrEmpty(dgvMetas.Rows(i).Cells("dgMetaAlcanzada").Value.ToString) Then
                dgvMetas.Rows(i).Cells("dgTotal").Style.BackColor = Color.Red
                dgvMetas.Rows(i).Cells("dgTotal").Style.ForeColor = Color.White
            ElseIf (dgvMetas.Rows(i).Cells("dgMetaAlcanzada").Value.ToString) = 1 Then
                dgvMetas.Rows(i).Cells("dgTotal").Style.BackColor = Color.Orange
            Else
                dgvMetas.Rows(i).Cells("dgTotal").Style.BackColor = Color.LightGreen
            End If
        Next

    End Sub

    Private Sub cb_CheckedChanged(sender As Object, e As EventArgs) Handles cbTodo.CheckedChanged, cbCTC.CheckedChanged, fechaInicio.ValueChanged,
                                                                           fechaFin.ValueChanged, cbCargo.SelectedIndexChanged
        cargarEmpleadoMeta()
    End Sub

    Private Sub FormFacturacionPorEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        pConfig = permiso_general & "pp" & "01"
        pGuardar = permiso_general & "pp" & "02"
        cargarDiaCorte()
        enlazarTabla()
        enlazarTablaDetalle()
        enlazarTablaDetalleDia()
        enlazarTablaPeriodo()
        Dim params As New List(Of String)
        params.Add(Nothing)
        General.cargarCombo(Consultas.CARGO_LISTAR, params, "Descripción cargo", "Código", cbCargo)
        Dim dtNuevo As DataTable
        dtNuevo = cbCargo.DataSource.copy
        dtNuevo.Rows.Add()
        dtNuevo.Rows(dtNuevo.Rows.Count - 1).Item(0) = Constantes.ITEM_DGV_SELECCIONE_VALOR
        dtNuevo.Rows(dtNuevo.Rows.Count - 1).Item(1) = "TODOS"
        cbCargo.DataSource = dtNuevo
        cbCargo.SelectedIndex = cbCargo.Items.Count - 1
        dgvMetas.ReadOnly = True
        dgvDetalle.ReadOnly = True
        dgvDetalleDia.ReadOnly = True
        dgvPeriodo.ReadOnly = True
        cbCTC.Checked = True
        pnlDetalle.Visible = False

    End Sub
    Private Sub enlazarTabla()
        With dgvMetas
            .Columns("dgIdEmpleado").DataPropertyName = "Id_Empleado"
            .Columns("dgEmpleado").DataPropertyName = "Empleado"
            .Columns("dgEstancia").DataPropertyName = "AporteEstancia"
            .Columns("dgTraslados").DataPropertyName = "AporteTraslados"
            .Columns("dgOxigeno").DataPropertyName = "AporteOxigeno"
            .Columns("dgParaclinicos").DataPropertyName = "AporteParaclinicos"
            .Columns("dgHemoderivados").DataPropertyName = "AporteHemoderivados"
            .Columns("dgProcedimientos").DataPropertyName = "AporteProcedimientos"
            .Columns("dgMedicamentos").DataPropertyName = "AporteMedicamentos"
            .Columns("dgInsumos").DataPropertyName = "AporteInsumos"
            .Columns("dgTotal").DataPropertyName = "TotalAportes"
            .Columns("dgPorcentaje").DataPropertyName = "% Aporte"
            .Columns("dgMetaAlcanzada").DataPropertyName = "Meta_Alcanzada"
            .AutoGenerateColumns = False
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        dgvMetas.DataSource = objMeta.bsMeta.DataSource
    End Sub
    Private Sub enlazarTablaPeriodo()
        With dgvPeriodo
            .Columns("dgModuloP").DataPropertyName = "Bandera"
            .Columns("dgEstanciaP").DataPropertyName = "AporteEstancia"
            .Columns("dgTrasladosP").DataPropertyName = "AporteTraslados"
            .Columns("dgOxigenoP").DataPropertyName = "AporteOxigeno"
            .Columns("dgParaclinicosP").DataPropertyName = "AporteParaclinicos"
            .Columns("dgHemoderivadosP").DataPropertyName = "AporteHemoderivados"
            .Columns("dgProcedimientosP").DataPropertyName = "AporteProcedimientos"
            .Columns("dgMedicamentosP").DataPropertyName = "AporteMedicamentos"
            .Columns("dgInsumosP").DataPropertyName = "AporteInsumos"
            .Columns("dgTotalP").DataPropertyName = "TotalAportes"
            .AutoGenerateColumns = False
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        dgvPeriodo.DataSource = objMeta.dtConsolidadoPeriodo
    End Sub

    Private Sub enlazarTablaDetalle()
        With dgvDetalle
            .Columns("dgModulo").DataPropertyName = "Bandera"
            .Columns("dgIdEmpleadoD").DataPropertyName = "Id_Empleado"
            .Columns("dgEmpleadoD").DataPropertyName = "Empleado"
            .Columns("dgEstanciaD").DataPropertyName = "AporteEstancia"
            .Columns("dgTrasladosD").DataPropertyName = "AporteTraslados"
            .Columns("dgOxigenoD").DataPropertyName = "AporteOxigeno"
            .Columns("dgParaclinicosD").DataPropertyName = "AporteParaclinicos"
            .Columns("dgHemoderivadosD").DataPropertyName = "AporteHemoderivados"
            .Columns("dgProcedimientosD").DataPropertyName = "AporteProcedimientos"
            .Columns("dgMedicamentosD").DataPropertyName = "AporteMedicamentos"
            .Columns("dgInsumosD").DataPropertyName = "AporteInsumos"
            .Columns("dgTotalD").DataPropertyName = "TotalAportes"
            .AutoGenerateColumns = False
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        dgvDetalle.DataSource = objMeta.bsMetaDetalle.DataSource

    End Sub
    Private Sub enlazarTablaDetalleDia()
        With dgvDetalleDia
            .Columns("dgModuloD").DataPropertyName = "Bandera"
            .Columns("dgIdEmpleadoDD").DataPropertyName = "Id_Empleado"
            .Columns("dgEmpleadoDD").DataPropertyName = "Empleado"
            .Columns("dgPaciente").DataPropertyName = "Paciente"
            .Columns("dgFecha").DataPropertyName = "Fecha"
            .Columns("dgEstanciaDD").DataPropertyName = "AporteEstancia"
            .Columns("dgTrasladosDD").DataPropertyName = "AporteTraslados"
            .Columns("dgOxigenoDD").DataPropertyName = "AporteOxigeno"
            .Columns("dgParaclinicoDD").DataPropertyName = "AporteParaclinicos"
            .Columns("dgHemoderivadosDD").DataPropertyName = "AporteHemoderivados"
            .Columns("dgProcedimientosDD").DataPropertyName = "AporteProcedimientos"
            .Columns("dgMedicamentosPOS").DataPropertyName = "AporteMedicamentos"
            .Columns("dgMedicamentosNoPOS").DataPropertyName = "AporteMedicamentosN"
            .Columns("dgInsumosDD").DataPropertyName = "AporteInsumos"
            .Columns("dgTotalDD").DataPropertyName = "TotalAportes"
            .AutoGenerateColumns = False
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        dgvDetalleDia.DataSource = objMeta.bsMetaDetalleDia.DataSource

    End Sub
    Private Sub textbusqueda1_TextChanged(sender As Object, e As EventArgs) Handles textbusqueda1.TextChanged
        objMeta.bsMeta.Filter = "Empleado like '%" & textbusqueda1.Text & "%'"
        colorearDetalle()
    End Sub

    Private Sub dgvMetas_CellFormatting(sender As DataGridView, e As DataGridViewCellFormattingEventArgs) Handles dgvMetas.CellFormatting
        If IsNumeric(e.Value) Then
            If e.ColumnIndex = dgvMetas.Columns("dgPorcentaje").Index Then
                e.Value = Format(Val(e.Value), "p2")
            Else
                e.Value = Format(Val(e.Value), "c0")

            End If

        End If
    End Sub

    Private Sub dgvMetasdetalleF(sender As DataGridView, e As DataGridViewCellFormattingEventArgs) Handles dgvDetalle.CellFormatting,
                                                                                                           dgvDetalleDia.CellFormatting,
                                                                                                           dgvPeriodo.CellFormatting
        If IsNumeric(e.Value) Then
            e.Value = Format(Val(e.Value), "c0")
        End If
    End Sub

    Private Sub dgvMetas_CellContentDOUBLEClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMetas.CellDoubleClick
        If e.ColumnIndex <> dgvMetas.Columns("dgMetas").Index Then
            detalleMostrar(e.RowIndex)
        End If
    End Sub
    Private Sub dgvMetas_CellClick(sender As DataGridView, e As DataGridViewCellEventArgs) Handles dgvMetas.CellClick
        If e.ColumnIndex = dgvMetas.Columns("dgMetas").Index Then
            objMeta.cargarMetaDetalle(dgvMetas.Rows(e.RowIndex).Cells("dgIdEmpleado").Value.ToString)
            Dim formMetasEmp As New FormMetas
            Dim tamanoAporte As Integer
            Dim porcentajeAumento As Double
            Dim dtMeta As New DataTable
            dtMeta = objMeta.calcularDimensiones(dgvMetas.Rows(e.RowIndex).Cells("dgTotal").Value.ToString, dgvMetas.Rows(e.RowIndex).Cells("dgIdEmpleado").Value.ToString).COPY
            If dtMeta.Rows.Count > 2 Then
                If dtMeta.Rows(dtMeta.Rows.Count - 1).Item("Superada") = False Then
                    For i = dtMeta.Rows.Count - 2 To 0 Step -1
                        porcentajeAumento = ((dtMeta.Rows(0).Item("Localizacion") - (dtMeta.Rows(i + 1).Item("Localizacion"))) * 100) / 407
                        If dtMeta.Rows(i).Item("Superada") = True Then
                            Exit For
                        End If
                        porcentajeAumento = ((dtMeta.Rows(0).Item("Localizacion") - (dtMeta.Rows(i).Item("Localizacion"))) * 100) / 407
                    Next
                    If porcentajeAumento = 0 Then
                        porcentajeAumento = (50 * 100) / 407
                    End If
                Else
                    porcentajeAumento = (dgvMetas.Rows(e.RowIndex).Cells("dgTotal").Value.ToString * 100) / (objMeta.dtMetas.Rows(objMeta.dtMetas.Rows.Count - 1).Item("Valor"))
                End If
            Else
                porcentajeAumento = (dgvMetas.Rows(e.RowIndex).Cells("dgTotal").Value.ToString * 100) / (objMeta.dtMetas.Rows(objMeta.dtMetas.Rows.Count - 1).Item("Valor"))
            End If
            tamanoAporte = (porcentajeAumento * 407) / 100
            If tamanoAporte > 469 Then
                tamanoAporte = 469
            End If
            Dim diasCorridos, diasFaltantes As Integer
            If CDate(objMeta.fechaFin).Date < CDate(General.fechaActualServidor).Date Then
                diasCorridos = DateDiff(DateInterval.Day, objMeta.fechaInicio, CDate(objMeta.fechaFin).Date) + 1
                diasFaltantes = 0
            Else
                diasCorridos = DateDiff(DateInterval.Day, objMeta.fechaInicio, CDate(General.fechaActualServidor).Date) + 1
                diasFaltantes = DateDiff(DateInterval.Day, CDate(General.fechaActualServidor).Date, CDate(objMeta.fechaFin).Date) + 1
            End If

            formMetasEmp.llenarDt(dtMeta, tamanoAporte, dgvMetas.Rows(e.RowIndex).Cells("dgEmpleado").Value,
                                   dgvMetas.Rows(e.RowIndex).Cells("dgTotal").Value, diasCorridos, diasFaltantes)
            formMetasEmp.ShowDialog()
        End If
    End Sub
    Private Sub dgvDetalle_CellContentDOUBLEClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellClick
        If e.ColumnIndex = dgvDetalle.Columns("dgDetalle").Index Then
            detalleMostrarDia(e.RowIndex)
        End If
    End Sub
    Private Sub detalleMostrar(Optional fila As Integer = 0)
        If pnlDetalle.Visible = True Then
            pnlDetalle.Visible = False
        Else
            pnlDetalle.Visible = True
            objMeta.bsMetaDetalle.Filter = "Empleado = '" & dgvMetas.Rows(fila).Cells("dgEmpleado").Value.ToString & "'"
            dgvDetalle.Focus()
            gbDetalle.Text = "Detalle por Módulo para: " & dgvMetas.Rows(fila).Cells("dgEmpleado").Value.ToString
            pnlDetalle.BackColor = Label2.ForeColor
        End If
    End Sub

    Private Sub detalleMostrarDia(Optional fila As Integer = 0)
        If pnlDetalleDia.Visible = True Then
            pnlDetalleDia.Visible = False
            GroupBox1.Enabled = True
            detalleMostrar(dgvMetas.CurrentRow.Index)
        Else
            Dim modulo As String
            Select Case dgvDetalle.Rows(fila).Cells("dgModulo").Value.ToString
                Case "HC"
                    modulo = Constantes.CODIGO_MENU_HISTC
                Case "AM"
                    modulo = Constantes.CODIGO_MENU_AUDM
                Case "AF"
                    modulo = Constantes.CODIGO_MENU_AUDF
            End Select
            pnlDetalleDia.Visible = True
            objMeta.bsMetaDetalleDia.Filter = "Empleado like '%" & dgvDetalle.Rows(fila).Cells("dgEmpleadoD").Value.ToString & "%' and Bandera ='" & modulo & "'"
            dgvDetalleDia.Focus()
            gbDia.Text = "Detalle dia a dia en " & dgvDetalle.Rows(fila).Cells("dgModulo").Value.ToString & " para: " & dgvDetalle.Rows(fila).Cells("dgEmpleadoD").Value.ToString
            GroupBox1.Enabled = False
        End If
        dgvDetalleDia.Columns("dgIdEmpleadoDD").Visible = False
        btOpcionMeta.Enabled = Not pnlDetalleDia.Visible
        btOpcionHistorico.Enabled = Not pnlDetalleDia.Visible
        If Not cbTodo.Checked Then
            btHistoricoMeta.Enabled = Not pnlDetalleDia.Visible
        End If
        dgvDetalleDia.Columns("dgMedicamentosNoPOS").Visible = cbCTC.Checked
    End Sub

    Private Sub dgvDetalle_Leave(sender As Object, e As EventArgs) Handles dgvDetalle.Leave
        detalleMostrar()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        detalleMostrarDia()
    End Sub
    Private Sub Form__FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub btOpcionHistorico_Click(sender As Object, e As EventArgs) Handles btOpcionHistorico.Click
        If SesionActual.tienePermiso(pConfig) Then
            Dim formMetasHist As New FormMetaHistorico
            formMetasHist.ShowDialog()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub btHistoricoMeta_Click(sender As Object, e As EventArgs) Handles btHistoricoMeta.Click
        Try
            Dim objConfigMeta As New ConfigMetaEmpleado
            objConfigMeta.cargarMetaGeneral()
            Dim thisDay As DateTime = General.fechaActualServidor()
            If thisDay.Day = 31 Then
                thisDay = "" & thisDay.Year & " / " & thisDay.Month & " / 30 Then"
            End If
            Dim fechaFinCorte As Date = thisDay.AddDays(thisDay.Day * -1 + objConfigMeta.diaCorte)
            Dim fechaInicioCorte As Date = thisDay.AddMonths(-1).AddDays(thisDay.Day * -1 + objConfigMeta.diaCorte + 1)

            If CDate(fechaFin.Value).Date > CDate(thisDay.Date).Date Then
                MsgBox("La fecha final supera a la actual" + Chr(13) + Chr(13) + Format(fechaFin.Value.Date, Constantes.FORMATO_FECHA2) +
                       " es mayor a " + Format(thisDay.Date, Constantes.FORMATO_FECHA2), MsgBoxStyle.Information)
            ElseIf CDate(fechaFin.Value.Date).Date <> CDate(fechaFinCorte).Date Or CDate(fechaInicio.Value.Date) <> CDate(fechaInicioCorte).Date Then
                MsgBox("Las fechas no coinciden con el periodo." + Chr(13) + Chr(13) + "Las fechas deberian ser: " +
                       Format(CDate(fechaInicioCorte).Date, Constantes.FORMATO_FECHA2) +
                       "  hasta " + Format(CDate(fechaFinCorte).Date, Constantes.FORMATO_FECHA2), MsgBoxStyle.Information)
            ElseIf thisDay.Day.ToString = objConfigMeta.diaCorte Then
                MsgBox("La fecha de cierre no ha terminado" + Chr(13) + Chr(13) + "La fecha de cierre es el: " +
                       Format(fechaFinCorte, Constantes.FORMATO_FECHA2), MsgBoxStyle.Information)
            Else
                Dim filas As DataRow()
                Dim tblTemp As New DataTable
                tblTemp = objMeta.dtConsolidado.Clone
                filas = objMeta.dtConsolidado.Select("Meta_Alcanzada <> '' and Meta_Alcanzada <> '1' ", "")
                For Each fila As DataRow In filas
                    tblTemp.ImportRow(fila)
                Next
                If tblTemp.Rows.Count > 0 Then
                    tblTemp.Columns.Remove("Empleado")
                    objMeta.guardarMeta(tblTemp)
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                Else
                    MsgBox("¡No hay metas superadas!", MsgBoxStyle.Information)
                End If

            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try

    End Sub

    Private Sub dgvMetas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMetas.CellClick

    End Sub

    Private Sub FormFacturacionPorEmpleados_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        colorearDetalle()
    End Sub

    Private Sub dgvMetas_Sorted(sender As Object, e As EventArgs) Handles dgvMetas.Sorted
        colorearDetalle()
    End Sub

    Public Sub cargarDiaCorte()
        Dim objConfigMeta As New ConfigMetaEmpleado
        objConfigMeta.cargarMetaGeneral()
        Dim thisDay As DateTime = General.fechaActualServidor()
        Dim dTent As DateTime = thisDay.AddDays(thisDay.Day * -1 + objConfigMeta.diaCorte + 1)
        If dTent > thisDay Then
            fechaInicio.Value = thisDay.AddMonths(-1).AddDays(thisDay.Day * -1 + objConfigMeta.diaCorte + 1)
            fechaFin.Value = dTent.AddDays(-1)
        Else
            fechaInicio.Value = dTent
            fechaFin.Value = thisDay.AddMonths(1).AddDays(thisDay.Day * -1 + objConfigMeta.diaCorte)
        End If
    End Sub

    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
End Class