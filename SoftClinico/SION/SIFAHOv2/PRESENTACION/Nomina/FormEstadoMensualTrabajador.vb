Public Class FormEstadoMensualTrabajador
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, PBuscar, pPestañas As String
    Dim fecha As Date = General.fechaActualServidor
    Dim idEmpleado, Contrato As Integer
    Dim objMeta As New MetaEmpleado
    Dim sw As Boolean = 0
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form_antici_decucci_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
        sw = 0
    End Sub
    Public Sub llenarDgvHorario(pUsuario, pPunto, pFecha)
        Dim dtHorario As New DataTable
        General.llenarTablaYdgv(ConsultasNom.ENTRADA_SALIDA_EMPLEADO_LISTAR & "(" & pUsuario & "," & pPunto & ",'" & pFecha & "')", dtHorario)
        If dtHorario.Rows.Count > 0 Then
            dgvhorario.DataSource = dtHorario
            dgvhorario.ReadOnly = True
            dgvhorario.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvhorario.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvhorario.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvhorario.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvhorario.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvhorario.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvhorario.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvhorario.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvhorario.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            'dgvhorario.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvhorario.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            General.diseñoDGV(dgvhorario)
            calcularTiempoPerdido(idEmpleado, pFecha)
        Else
            dgvhorario.DataSource = Nothing
            textbalance.Clear()
        End If
    End Sub

    Private Sub llenarDgvNotas(consulta As String, datagrid As DataGridView)
        Dim dtAutor As New DataTable
        Dim params As New List(Of String)
        params.Add(idEmpleado)
        params.Add(Format(fechaNomina.Value, Constantes.FORMATO_FECHA_AÑO_MES) & "-01")
        params.Add(Format(fechaNomina.Value, Constantes.FORMATO_FECHA_GEN))
        datagrid.DataSource = Nothing
        General.llenarTabla(consulta, params, dtAutor)
        datagrid.DataSource = dtAutor
        If dtAutor.Rows.Count > 0 Then
            With datagrid
                .Columns("Porcentaje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Notas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Pacientes").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Promedio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Porcentaje").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("Notas").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("Pacientes").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("Promedio").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
        End If
    End Sub

    Public Sub calcularTiempoPerdido(pUsuario, pFecha)
        Dim dtTiempo As New DataTable
        General.llenarTablaYdgv(ConsultasNom.MINUTOS_PERDIDOS & "(" & pUsuario & ",'" & pFecha & "')", dtTiempo)
        If dtTiempo.Rows.Count > 0 Then
            Dim tiempoPerdido As Double
            tiempoPerdido = dtTiempo.Rows(0).Item(0).ToString()
            textbalance.Text = String.Format("{0:%d} dd, {0:%h} hh, {0:%m} mm", TimeSpan.FromHours(tiempoPerdido))
            If tiempoPerdido > 0 Then
                textbalance.Text = "- " + textbalance.Text
                picturebalancebueno.Visible = False
                picturebalancemalo.Visible = True
                picturebalancemalo.Image = My.Resources.TimeBad.ToBitmap
            Else
                textbalance.Text = String.Format("{0:%d} dd, {0:%h} hh, {0:%m} mm", TimeSpan.FromHours(0))
                textbalance.Text = "+ " + textbalance.Text
                picturebalancebueno.Visible = True
                picturebalancebueno.Image = My.Resources.TimeGood2.ToBitmap
                picturebalancemalo.Visible = False
            End If
        Else
            textbalance.Clear()
        End If
    End Sub
    Private Sub FormEstadoMensualTrabajador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sw = 1
        permiso_general = perG.buscarPermisoGeneral("FormEstadoMensualTrabajador")
        PBuscar = permiso_general & "pp" & "01"
        pPestañas = permiso_general & "pp" & "02"
        'fechaNomina.Value = General.fechaActualServidor
        cargarDiaCorte()
        enlazarTablaDetalle()
        enlazarTablaDetalleDia()
        idEmpleado = SesionActual.idUsuario
        'cargarNombreEmpleado(idEmpleado)
        cargarContratoEmpleado(idEmpleado)
        dgvDetalleDia.ReadOnly = True
        ocultarPestañas()
        fechaInicio.Enabled = True
        fechaFin.Enabled = True
    End Sub

    Private Sub enlazarTablaDetalle()
        With dgvDetalle
            .Columns("dgModulo").DataPropertyName = "Bandera"
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
    Function obtenerUltimoDiaDelMes(ByVal dtmFecha As Date) As Date
        obtenerUltimoDiaDelMes = DateSerial(Year(dtmFecha), Month(dtmFecha) + 1, 0)
    End Function
    Private Sub ocultarPestañas()
        If SesionActual.idUsuario = -1 OrElse SesionActual.tienePermiso(pPestañas) Then
            'TabPage2.Parent = TabControl1
            'TabPage3.Parent = TabControl1
            fechaNomina.Enabled = True
        Else
            'TabPage2.Parent = Nothing
            'TabPage3.Parent = Nothing
            fechaNomina.Enabled = False
        End If
    End Sub
    'Private Sub cargarNombreEmpleado(pCodigo)
    '    Dim dtnombreTercero As New DataTable
    '    Dim params As New List(Of String)
    '    params.Add(pCodigo)
    '    General.llenarTabla(Consultas.CONTA_TERCERO_CARGAR, params, dtnombreTercero)
    '    If dtnombreTercero.Rows.Count > 0 Then
    '        textcedula.Text = dtnombreTercero.Rows(0).Item("Nit")
    '        txtNombre.Text = dtnombreTercero.Rows(0).Item("Tercero")
    '        'dateDiaInicio.Text = StrConv(fecha.ToString("MMMM"), VbStrConv.ProperCase)
    '    End If

    'End Sub
    Public Sub cargarContratoEmpleado(pCodigo As String)
        Dim dtContrato As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(SesionActual.idEmpresa)
        General.llenarTabla(ConsultasNom.ESTADO_MENSUAL_CONTRATO_EMPLEADO_CARGAR, params, dtContrato)
        If dtContrato.Rows.Count > 0 Then
            cargarEmpleado(dtContrato.Rows(0).Item(0).ToString)
        End If
    End Sub

    Private Sub cargarEmpleado(pCodigo)
        Dim dtTercero As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(ConsultasNom.ESTADO_MENSUAL_EMPLEADO_CARGAR, params, dtTercero)
        If dtTercero.Rows.Count > 0 Then
            textcedula.Text = dtTercero.Rows(0).Item("Nit")
            txtNombre.Text = dtTercero.Rows(0).Item("Tercero")
            idEmpleado = dtTercero.Rows(0).Item("Id_Empleado").ToString
            llenarDgvHorario(idEmpleado, SesionActual.codigoEP, Format(fechaNomina.Value, Constantes.FORMATO_FECHA_GEN2))
            cargarNomina(pCodigo, SesionActual.idEmpresa, Format(fechaNomina.Value, Constantes.FORMATO_FECHA_GEN2))
            TabControl2.SelectedIndex = 0
            llenarDgvPrestamos(dtTercero.Rows(0).Item("Id_Empleado"))
            cargarPermisoEspecial()
            ocultarPestañas()
            Contrato = pCodigo
            cargarMetas()
            llenarDgvNotas(Consultas.ESTADO_MENSUAL_NOTA_AUDITORIA_AUTOR, dgvNotaCreada)
            llenarDgvNotas(Consultas.ESTADO_MENSUAL_NOTA_AUDITORIA_RESPONSABLE, dgvNotaResponsable)
        End If
        General.deshabilitarControles(gbAporte)
        fechaInicio.Enabled = True
        fechaFin.Enabled = True
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

    Private Sub cb_CheckedChanged(sender As Object, e As EventArgs) Handles fechaInicio.ValueChanged,
                                                                           fechaFin.ValueChanged
        cargarMetas()
    End Sub

    Private Sub cargarMetas()
        If String.IsNullOrEmpty(txtNombre.Text) Then
            objMeta.dtConsolidado.Clear()
        Else
            objMeta.fechaInicio = fechaInicio.Value
            objMeta.fechaFin = fechaFin.Value
            objMeta.CTC = True
            objMeta.todo = False
            objMeta.idEmpleado = idEmpleado
            objMeta.cargarMeta()
        End If
        If objMeta.dtConsolidado.Rows.Count = 0 Then
            txtEstancia.Text = CDbl(0).ToString("C0")
            txtTraslados.Text = CDbl(0).ToString("C0")
            txtOxigeno.Text = CDbl(0).ToString("C0")
            txtParaclinico.Text = CDbl(0).ToString("C0")
            txtHemoderivado.Text = CDbl(0).ToString("C0")
            txtProcedimiento.Text = CDbl(0).ToString("C0")
            txtMedicamentos.Text = CDbl(0).ToString("C0")
            txtInsumos.Text = CDbl(0).ToString("C0")
            txtTotalAporte.Text = CDbl(0).ToString("C0")
            objMeta.dtConsolidadoModulo.Clear()
            txtTotalAporte.BackColor = Color.FromArgb(228, 6, 19)
            txtTotalAporte.ForeColor = Color.White
        Else
            txtEstancia.Text = CDbl(objMeta.dtConsolidado.Rows(0).Item("AporteEstancia")).ToString("C0")
            txtTraslados.Text = CDbl(objMeta.dtConsolidado.Rows(0).Item("AporteTraslados")).ToString("C0")
            txtOxigeno.Text = CDbl(objMeta.dtConsolidado.Rows(0).Item("AporteOxigeno")).ToString("C0")
            txtParaclinico.Text = CDbl(objMeta.dtConsolidado.Rows(0).Item("AporteParaclinicos")).ToString("C0")
            txtHemoderivado.Text = CDbl(objMeta.dtConsolidado.Rows(0).Item("AporteHemoderivados")).ToString("C0")
            txtProcedimiento.Text = CDbl(objMeta.dtConsolidado.Rows(0).Item("AporteProcedimientos")).ToString("C0")
            txtMedicamentos.Text = CDbl(objMeta.dtConsolidado.Rows(0).Item("AporteMedicamentos")).ToString("C0")
            txtInsumos.Text = CDbl(objMeta.dtConsolidado.Rows(0).Item("AporteInsumos")).ToString("C0")
            txtTotalAporte.Text = CDbl(objMeta.dtConsolidado.Rows(0).Item("TotalAportes")).ToString("C0")

            txtTotalAporte.ForeColor = Color.Black
            If String.IsNullOrEmpty(objMeta.dtConsolidado.Rows(0).Item("Meta_Alcanzada").ToString) Then
                txtTotalAporte.BackColor = Color.FromArgb(228, 6, 19)
                txtTotalAporte.ForeColor = Color.White
            ElseIf (objMeta.dtConsolidado.Rows(0).Item("Meta_Alcanzada").ToString) = 1 Then
                txtTotalAporte.BackColor = Color.Orange
            Else
                txtTotalAporte.BackColor = Color.LightGreen
            End If
        End If
    End Sub
    Public Sub llenarDgvPrestamos(pCodigo)
        Dim formatoMoneda As Globalization.CultureInfo = Application.CurrentCulture.Clone()
        formatoMoneda.NumberFormat.CurrencyNegativePattern = 2
        Dim dtPrestamos As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(2)
        params.Add(0)
        General.llenarTabla(ConsultasNom.DEDUCCIONES_LISTAR, params, dtPrestamos)
        dgvPrestamos.DataSource = dtPrestamos
        dgvPrestamos.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvPrestamos.Columns(1).Visible = False
        dgvPrestamos.Columns(2).Visible = False
        dgvPrestamos.Columns(3).Visible = False
        dgvPrestamos.Columns(4).Visible = False
        dgvPrestamos.Columns(5).Visible = False
        dgvPrestamos.Columns(6).Visible = False
        dgvPrestamos.Columns(7).Visible = False
        dgvPrestamos.Columns(8).Visible = False
        dgvPrestamos.Columns(9).Visible = False
        dgvPrestamos.Columns(10).Visible = False
        dgvPrestamos.Columns(11).Visible = False
        dgvPrestamos.Columns(12).Visible = False
        dgvPrestamos.Columns(13).Visible = False
        dgvPrestamos.Columns(14).Visible = False
        dgvPrestamos.Columns(15).Visible = False
        dgvPrestamos.Columns(16).Visible = False
        dgvPrestamos.Columns(17).Visible = False
        dgvPrestamos.Columns(18).Visible = False
        dgvPrestamos.Columns(19).Visible = False
        General.diseñoDGV(dgvPrestamos)
        dgvPrestamos.ReadOnly = True

        If IsDBNull(dtPrestamos.Compute("Sum(saldo)", "")) Then
            Textsaldototal.Text = String.Empty
        Else
            Textsaldototal.Text = CDec(dtPrestamos.Compute("SUM(saldo)", "")).ToString("C0", formatoMoneda)
        End If
        If IsDBNull(dtPrestamos.Compute("SUM(valor)-SUM(saldo)", "")) Then
            Texttotalpagado.Text = String.Empty
        Else
            Texttotalpagado.Text = CDec(dtPrestamos.Compute("SUM(valor)-SUM(saldo)", "")).ToString("C0", formatoMoneda)
        End If
    End Sub
    Public Sub llenarDgvPrestamosPagados(pCodigo)
        Dim formatoMoneda As Globalization.CultureInfo = Application.CurrentCulture.Clone()
        formatoMoneda.NumberFormat.CurrencyNegativePattern = 2
        Dim dtPrestamosPagados As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(2)
        params.Add(1)
        General.llenarTabla(ConsultasNom.DEDUCCIONES_LISTAR, params, dtPrestamosPagados)
        dgvpresamosPagados.DataSource = dtPrestamosPagados
        dgvpresamosPagados.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvpresamosPagados.Columns(1).Visible = False
        dgvpresamosPagados.Columns(2).Visible = False
        dgvpresamosPagados.Columns(3).Visible = False
        dgvpresamosPagados.Columns(4).Visible = False
        dgvpresamosPagados.Columns(5).Visible = False
        dgvpresamosPagados.Columns(6).Visible = False
        dgvpresamosPagados.Columns(7).Visible = False
        dgvpresamosPagados.Columns(8).Visible = False
        dgvpresamosPagados.Columns(9).Visible = False
        dgvpresamosPagados.Columns(10).Visible = False
        dgvpresamosPagados.Columns(11).Visible = False
        dgvpresamosPagados.Columns(12).Visible = False
        dgvpresamosPagados.Columns(13).Visible = False
        dgvpresamosPagados.Columns(14).Visible = False
        dgvpresamosPagados.Columns(15).Visible = False
        dgvpresamosPagados.Columns(16).Visible = False
        dgvpresamosPagados.Columns(17).Visible = False
        dgvpresamosPagados.Columns(18).Visible = False
        dgvpresamosPagados.Columns(19).Visible = False
        General.diseñoDGV(dgvpresamosPagados)
        dgvpresamosPagados.ReadOnly = True

        If IsDBNull(dtPrestamosPagados.Compute("Sum(saldo)", "")) Then
            Textsaldototal.Text = String.Empty
        Else
            Textsaldototal.Text = CDec(dtPrestamosPagados.Compute("SUM(saldo)", "")).ToString("C0", formatoMoneda)
        End If
        If IsDBNull(dtPrestamosPagados.Compute("SUM(valor)-SUM(saldo)", "")) Then
            Texttotalpagado.Text = String.Empty
        Else
            Texttotalpagado.Text = CDec(dtPrestamosPagados.Compute("SUM(valor)-SUM(saldo)", "")).ToString("C0", formatoMoneda)
        End If
    End Sub
    Sub limpiarPrestamo()
        texttipoprestamo.Clear()
        textvalorprestamo.Clear()
        txtInteres.Clear()
        textsaldoprestamo.Clear()
        Textpagado.Clear()
        Textcuotaspagadas.Clear()
        dgvMovimientos.DataSource = Nothing
        dgvMovimientos.Columns.Clear()
    End Sub
    Private Sub dgvPrestamos_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPrestamos.SelectionChanged
        If dgvPrestamos.SelectedRows.Count > 0 Then
            cargarLibranza(dgvPrestamos.Rows(dgvPrestamos.CurrentRow.Index).Cells(1).Value)
        Else
            limpiarPrestamo()
        End If
    End Sub
    Private Sub dgvpresamosPagados_SelectionChanged(sender As Object, e As EventArgs) Handles dgvpresamosPagados.SelectionChanged
        If dgvpresamosPagados.SelectedRows.Count > 0 Then
            cargarLibranza(dgvpresamosPagados.Rows(dgvpresamosPagados.CurrentRow.Index).Cells(1).Value)
        Else
            limpiarPrestamo()
        End If
    End Sub
    Private Sub cargarLibranza(pCodigo)
        Dim formatoMoneda As Globalization.CultureInfo = Application.CurrentCulture.Clone()
        formatoMoneda.NumberFormat.CurrencyNegativePattern = 2
        Dim dtLibranza As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(ConsultasNom.DEDUCCIONES_CARGAR, params, dtLibranza)
        If dtLibranza.Rows.Count > 0 Then
            Dim tipoInteres As String = dtLibranza.Rows(0).Item("Base_Interes").ToString
            Select Case tipoInteres
                Case "S"
                    texttipoprestamo.Text = "Saldo"
                Case Else
                    texttipoprestamo.Text = "Base"
            End Select
            txtInteres.Text = dtLibranza.Rows(0).Item("interes").ToString
            textvalorprestamo.Text = CDec(dtLibranza.Rows(0).Item("valor")).ToString("C0", formatoMoneda)
            textsaldoprestamo.Text = CDec(dtLibranza.Rows(0).Item("Saldo")).ToString("C0", formatoMoneda)
            Textpagado.Text = CDec((dtLibranza.Rows(0).Item("valor").ToString - dtLibranza.Rows(0).Item("Saldo").ToString)).ToString("C0", formatoMoneda)
            Textcuotaspagadas.Text = dtLibranza.Rows(0).Item("Cuotas_pagadas").ToString
            cargarLibranzaDetalle(pCodigo)
        End If
    End Sub
    Private Sub cargarLibranzaDetalle(pCodigo)
        Dim dtMovimientos As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(ConsultasNom.DEDUCCIONES_DETALLE_EM_CARGAR, params, dtMovimientos)
        dgvMovimientos.DataSource = dtMovimientos
        dgvMovimientos.Columns(0).Visible = False
        dgvMovimientos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvMovimientos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvMovimientos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMovimientos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMovimientos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMovimientos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMovimientos.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMovimientos.Columns(8).Visible = False
        General.diseñoDGV(dgvMovimientos)
        dgvMovimientos.ReadOnly = True
    End Sub
    Private Sub dgvMovimientos_CellFormatting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvMovimientos.CellFormatting
        If e.ColumnIndex = 3 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5 Or e.ColumnIndex = 6 Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), "c2")
            Else
                e.Value = Format(Val(e.Value), "c2")
            End If
        ElseIf e.ColumnIndex = 7 Then
            If dgvMovimientos.Rows(e.RowIndex).Cells(7).Value = Constantes.ESTADO_PENDIENTE Then
                e.CellStyle.BackColor = Color.Pink
            Else
                e.CellStyle.BackColor = Color.FromArgb(192, 255, 192)
            End If
        End If
    End Sub

    Private Sub cargarNomina(pCodigo, pEmpresa, fecha)
        Dim formatoMoneda As Globalization.CultureInfo = Application.CurrentCulture.Clone()
        formatoMoneda.NumberFormat.CurrencyNegativePattern = 2
        Dim dtNomina As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(pEmpresa)
        params.Add(fecha)
        dtNomina.Clear()
        General.llenarTabla(ConsultasNom.ESTADO_MENSUAL_TRABAJADOR_CARGAR, params, dtNomina)
        If dtNomina.Rows.Count > 0 Then
            Me.Cursor = Cursors.WaitCursor
            Dim contrato As String = dtNomina.Rows(0).Item("Contrato").ToString
            Select Case contrato
                Case "L"
                    textsalario.Text = CDec(dtNomina.Rows(0).Item("Salario")).ToString("C0", formatoMoneda)
                    textprestacionserv.Text = CDec(0).ToString("C0", formatoMoneda)
                    textbasico.Text = CDec(dtNomina.Rows(0).Item("Salario")).ToString("C0", formatoMoneda)
                Case "P"
                    textprestacionserv.Text = CDec(dtNomina.Rows(0).Item("SalarioPrestacion")).ToString("C0", formatoMoneda)
                    textsalario.Text = CDec(0).ToString("C0", formatoMoneda)
                    textbasico.Text = CDec(0).ToString("C0", formatoMoneda)
            End Select
            textvalorturno.Text = CDec(dtNomina.Rows(0).Item("Turno")).ToString("C0", formatoMoneda)
            textbonificacion.Text = CDec(dtNomina.Rows(0).Item("Bonificacion")).ToString("C0", formatoMoneda)
            textturnopro.Text = dtNomina.Rows(0).Item("TurnosProgramados").ToString()
            texthorapro.Text = dtNomina.Rows(0).Item("HorasProgramadas").ToString()
            textturnotrabaj.Text = dtNomina.Rows(0).Item("TurnosTrabajados").ToString()
            texthoratrabaj.Text = dtNomina.Rows(0).Item("HorasTrabajadas").ToString()
            'dateDiaInicio.Text = dtNomina.Rows(0).Item("Fecha").ToString()
            textvalorhora.Text = CDec(dtNomina.Rows(0).Item("ValorHora")).ToString("C0", formatoMoneda)
            textliquidado.Text = CDec(dtNomina.Rows(0).Item("TotalLiquido")).ToString("C0", formatoMoneda)
            textcelular.Text = CDec(dtNomina.Rows(0).Item("Celular")).ToString("C0", formatoMoneda)
            textanticipo.Text = CDec(dtNomina.Rows(0).Item("Anticipo")).ToString("C0", formatoMoneda)
            textprestamo.Text = CDec(dtNomina.Rows(0).Item("Prestamo")).ToString("C0", formatoMoneda)
            textlibranza.Text = CDec(dtNomina.Rows(0).Item("Libranza")).ToString("C0", formatoMoneda)
            texttotaldeducciones.Text = CDec(dtNomina.Rows(0).Item("TotalDeducciones")).ToString("C0", formatoMoneda)
            textnetopago.Text = CDec(dtNomina.Rows(0).Item("NetoPago")).ToString("C0", formatoMoneda)
            textsalud.Text = CDec(dtNomina.Rows(0).Item("Pension")).ToString("C0", formatoMoneda)
            textpension.Text = CDec(dtNomina.Rows(0).Item("Pension")).ToString("C0", formatoMoneda)
            textauxtransporte.Text = CDec(dtNomina.Rows(0).Item("Transporte")).ToString("C0", formatoMoneda)
            textdevengado.Text = CDec(dtNomina.Rows(0).Item("TotalDevengado")).ToString("C0", formatoMoneda)
            Textprogramhoy.Text = dtNomina.Rows(0).Item("Prog_Hasta_hoy").ToString()
            textmeta.Text = CDec(dtNomina.Rows(0).Item("Meta")).ToString("C0", formatoMoneda)
            Textsubtotal.Text = CDec(dtNomina.Rows(0).Item("SubTotal")).ToString("C0", formatoMoneda)


            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub cargarPermisoEspecial()
        Dim dtpermiso As New DataTable
        Dim params As New List(Of String)
        params.Add(idEmpleado)
        params.Add(SesionActual.idEmpresa)
        General.llenarTabla(ConsultasNom.ESTADO_MENSUAL_PERMISO_ESPECIAL, params, dtpermiso)
        If dtpermiso.Rows.Count > 0 Then
            picturepermiso.Visible = True
            picturepermiso.Image = My.Resources.usuario_permiso
        Else
            picturepermiso.Visible = False
            picturepermiso.Image = My.Resources.blanco
        End If
    End Sub

    Private Sub btOpcionMeta_Click(sender As Object, e As EventArgs) Handles btOpcionMeta.Click
        If objMeta.dtConsolidado.Rows.Count = 0 Then Exit Sub
        objMeta.cargarMetaDetalle(idEmpleado)
        Dim formMetasEmp As New FormMetas
        Dim tamanoAporte As Integer
        Dim porcentajeAumento As Double
        Dim dtMeta As New DataTable
        dtMeta = objMeta.calcularDimensiones(CDbl(txtTotalAporte.Text), idEmpleado).COPY
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
            End If
        Else
            porcentajeAumento = (CDbl(txtTotalAporte.Text) * 100) / (objMeta.dtMetas.Rows(objMeta.dtMetas.Rows.Count - 1).Item("Valor"))
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

        formMetasEmp.llenarDt(objMeta.calcularDimensiones(CDbl(txtTotalAporte.Text), idEmpleado), tamanoAporte, txtNombre.Text,
                                   CDbl(txtTotalAporte.Text), diasCorridos, diasFaltantes)
        formMetasEmp.ShowDialog()

    End Sub

    Private Sub dgvDetalle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        If e.RowIndex >= 0 Then
            detalleMostrarDia(e.RowIndex)
        End If
    End Sub
    Private Sub detalleMostrarDia(Optional fila As Integer = 0)
        pnlDetalleDia.BringToFront()
        If pnlDetalleDia.Visible = True Then
            pnlDetalleDia.Visible = False
            GroupBox1.Enabled = True
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
            objMeta.bsMetaDetalleDia.Filter = "Bandera ='" & modulo & "'"
            dgvDetalleDia.Focus()
            gbDia.Text = "Detalle dia a dia en " & dgvDetalle.Rows(fila).Cells("dgModulo").Value.ToString & " para: " & txtNombre.Text
            GroupBox1.Enabled = False
        End If
        dgvDetalleDia.Columns("dgMedicamentosNoPOS").Visible = True
        dgvDetalleDia.Columns("dgModuloD").Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        detalleMostrarDia()
    End Sub
    Private Sub dgvMetasdetalleF(sender As DataGridView, e As DataGridViewCellFormattingEventArgs) Handles dgvDetalle.CellFormatting,
                                                                                                           dgvDetalleDia.CellFormatting
        If IsNumeric(e.Value) Then
            e.Value = Format(Val(e.Value), "c0")
        End If
    End Sub


    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl2.SelectedIndex = 3 Then
            cargarMetas()
            llenarDgvNotas(Consultas.ESTADO_MENSUAL_NOTA_AUDITORIA_AUTOR, dgvNotaCreada)
            llenarDgvNotas(Consultas.ESTADO_MENSUAL_NOTA_AUDITORIA_RESPONSABLE, dgvNotaResponsable)
        End If
    End Sub

    Private Sub fechaNomina_ValueChanged(sender As Object, e As EventArgs) Handles fechaNomina.ValueChanged
        If sw = 0 Then
            Exit Sub
        End If
        cargarNomina(Contrato, SesionActual.idEmpresa, Format(fechaNomina.Value, Constantes.FORMATO_FECHA_GEN2))
        llenarDgvHorario(idEmpleado, SesionActual.codigoEP, Format(fechaNomina.Value, Constantes.FORMATO_FECHA_GEN2))
        llenarDgvNotas(Consultas.ESTADO_MENSUAL_NOTA_AUDITORIA_AUTOR, dgvNotaCreada)
        llenarDgvNotas(Consultas.ESTADO_MENSUAL_NOTA_AUDITORIA_RESPONSABLE, dgvNotaResponsable)
    End Sub

    Private Sub TabControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl2.SelectedIndexChanged
        If TabControl2.SelectedIndex = 0 Then
            dgvMovimientos.DataSource = Nothing
            llenarDgvPrestamos(idEmpleado)
        ElseIf TabControl2.SelectedIndex = 1 Then
            dgvMovimientos.DataSource = Nothing
            llenarDgvPrestamosPagados(idEmpleado)
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Dim params As New List(Of String)
        params.Add("")
        params.Add(SesionActual.idUsuario)

        General.buscarElemento(ConsultasNom.ESTADO_MENSUAL_TRABAJADOR_BUSCAR,
                                   params,
                                   AddressOf cargarEmpleado,
                                   TitulosForm.BUSQUEDA_TERCERO,
                                   False, 0, True)

    End Sub
End Class