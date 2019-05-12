Imports System.Threading
Public Class FormListaExamen
    Dim moduloAreaServicio As String
    Private cargaSegundoPlano As Threading.Thread
    Dim objFormCargar As FormCargando
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormListaExamen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Dim params As New List(Of String)
        General.deshabilitarBotones(ToolStrip1)
        btConsultado.Enabled = True
        dgvmanual.ReadOnly = True
        Try
            params.Add(SesionActual.idUsuario)
            params.Add(SesionActual.codigoEP)
            params.Add(moduloAreaServicio)
            General.cargarCombo(Consultas.PROC_AREA_SERVICIO_EMPLEADO_LLENAR, params, "Descripción", "Código", comboAreaServicio)
            agregarFilaCombo()
            params.Clear()
            params.Add(SesionActual.idEmpresa)
            General.cargarCombo("[PROC_LISTA_LABORATORIO]", params, "Laboratorio", "codigo", cbLaboratorio)
            cbLaboratorio.SelectedValue = If(SesionActual.codigoEP = Constantes.UCI_LA_50,
                                             Constantes.CODIGO_LABORATORIO_50,
                                             Constantes.CODIGO_LABORATORIO_SAIS)
            cargarRegistros()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub agregarFilaCombo()
        Dim dtNuevo As DataTable
        dtNuevo = comboAreaServicio.DataSource.Clone()
        comboAreaServicio.DataSource.rows(0).delete()
        dtNuevo.Rows.Add()
        dtNuevo.Rows(dtNuevo.Rows.Count - 1).Item(0) = Constantes.ITEM_DGV_SELECCIONE_VALOR
        dtNuevo.Rows(dtNuevo.Rows.Count - 1).Item(1) = "TODOS"
        For Each dfila As DataRow In comboAreaServicio.DataSource.Rows
            dtNuevo.ImportRow(dfila)
        Next
        comboAreaServicio.DataSource = dtNuevo
    End Sub
    Public Sub cargarRegistros()
        Dim params As New List(Of String)
        If Not String.IsNullOrEmpty(comboAreaServicio.ValueMember) Then
            params.Add(txtBuscarConsildado.Text)
            params.Add(Format(dtFcehaIniCons.Value, Constantes.FORMATO_FECHA2))
            params.Add(Format(dtFechaFinCons.Value, Constantes.FORMATO_FECHA2))
            params.Add(If(chPendiente.Checked = True, 0, 1))
            params.Add(cbLaboratorio.SelectedValue)
            params.Add(SesionActual.idEmpresa)
            params.Add(If(comboAreaServicio.SelectedValue = Constantes.COMBO_VALOR_PREDETERMINADO, Nothing, comboAreaServicio.SelectedValue))
            General.llenardgv("[PROC_LISTA_EXAMENES_CARGAR]", dgvmanual, params)
            validarDGV()
            lbTitulo.Text = "Cantidad de Examen: "
            npaciente.Text = dgvmanual.RowCount
        End If
    End Sub
    Public Sub cargarRegistrosConsolidado()
        Dim params As New List(Of String)
        Dim dt As New DataTable
        If Not String.IsNullOrEmpty(cbLaboratorio.ValueMember) Then
            params.Add(txtBuscarConsildado.Text)
            params.Add(Format(dtFcehaIniCons.Value, Constantes.FORMATO_FECHA2))
            params.Add(Format(dtFechaFinCons.Value, Constantes.FORMATO_FECHA2))
            params.Add(SesionActual.idEmpresa)
            params.Add(cbLaboratorio.SelectedValue)
            General.llenardgv("[PROC_LISTA_EXAMENES_CONSOLIDADO_CARGAR]", dgvConsolidadoExam, params)
            validarDgvConsolidado()
            dt = dgvConsolidadoExam.DataSource.Copy
            lbTitulo.Text = "Total de Examen:"
            General.deshabilitarBotones(ToolStrip1)
            If dgvConsolidadoExam.RowCount = 0 Then
                btConsultado.Enabled = True
                limpiarCampos()
            Else
                btConsultado.Enabled = True
                btVistaPrevia.Enabled = True
                desHabilitarImpresion()
                VistaPreviaToolStripMenuItem.Enabled = True
                lbSub.Text = Format(dt.Compute("SUM(Precio)", ""), "C")
                lbTotal.Text = Format(dt.Compute("SUM(Total)", ""), "C")
                npaciente.Text = dt.Compute("SUM(Cantidad)", "")
            End If
        End If
    End Sub
    Private Sub limpiarCampos()
        npaciente.Text = Constantes.PENDIENTE
        lbSub.Text = Constantes.PENDIENTE
        lbTotal.Text = Constantes.PENDIENTE
    End Sub
    Private Sub validarDGV()
        If dgvmanual.ColumnCount > 0 Then
            With dgvmanual
                .Columns("Codigo_Tipo_Examen").Visible = False
                .Columns("Orden").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("Codigo").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("Fecha").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("Paciente").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("Servicio").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("Examen").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns("dgResultado").DisplayIndex = 7
            End With
        End If
    End Sub
    Private Sub validarDgvConsolidado()
        If dgvConsolidadoExam.ColumnCount > Constantes.PENDIENTE Then
            With dgvConsolidadoExam
                .ReadOnly = True
                .Columns("Examen").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns("Cantidad").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("Precio").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("Total").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
        End If
    End Sub
    Private Sub dgvmanual_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvmanual.CellClick
        Dim respuestaExamen As Boolean
        If dgvmanual.RowCount > Constantes.PENDIENTE Then
            If e.ColumnIndex = Constantes.PENDIENTE Then
                Dim Form = New FormExamenParaclinicosNuevo
                respuestaExamen = Form.cargarPaciente(dgvmanual.Rows(dgvmanual.CurrentCell.RowIndex).Cells("Orden").Value,
                                      dgvmanual.Rows(dgvmanual.CurrentCell.RowIndex).Cells("Codigo").Value,
                                      Tag.Modulo, If(chPendiente.Checked = True, 0, 1),
                                      Constantes.TipoEXAM)
                If respuestaExamen = False Then
                    Form.ShowDialog()
                Else
                    MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End If
        End If
    End Sub
    Private Sub txtBuscarConsildado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarConsildado.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvConsolidadoExam.RowCount > 0 OrElse
                dgvmanual.RowCount > 0 Then
                validarCargarRegistro()
            End If
        End If
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        General.limpiarControles(TabControl1)
        General.deshabilitarBotones(ToolStrip1)
        btConsultado.Enabled = True
        limpiarCampos()
        Select Case TabControl1.SelectedIndex
            Case 0
                gbEstadoAtencion.Enabled = True
                comboAreaServicio.Enabled = True
                gbCodigo.Visible = False
            Case 1
                gbEstadoAtencion.Enabled = False
                comboAreaServicio.Enabled = False
                comboAreaServicio.SelectedIndex = 0
                gbCodigo.Visible = True
                chRealizado.Checked = True
                btbuscar.Enabled = True
        End Select
    End Sub
    Private Sub validarCargarRegistro()
        Select Case TabControl1.SelectedIndex
            Case 0
                cargarRegistros()
            Case 1
                cargarRegistrosConsolidado()
        End Select
        Cursor = Cursors.Default
        objFormCargar.Dispose()
        Enabled = True
    End Sub
    Private Sub dgvConsolidadoExam_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvConsolidadoExam.CellFormatting
        If dgvConsolidadoExam.RowCount > 0 Then
            If e.ColumnIndex = 2 Or e.ColumnIndex = 3 Then
                e.Value = If(Not IsDBNull(e.Value), Format(Val(e.Value), "c2"), 0)
            End If
        End If
    End Sub
    Private Sub VistaPreviaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VistaPreviaToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        objFormCargar = New FormCargando
        objFormCargar.Show()
        cargaSegundoPlano = New Threading.Thread(AddressOf impresionConsolidado)
        cargaSegundoPlano.Start()
    End Sub
    Private Sub btConsultado_Click(sender As Object, e As EventArgs) Handles btConsultado.Click
        Dim fechaInicio, fechaFin As Date
        fechaInicio = Format(dtFcehaIniCons.Value, Constantes.FORMATO_FECHA2)
        fechaFin = Format(dtFechaFinCons.Value, Constantes.FORMATO_FECHA2)
        If fechaInicio <= fechaFin Then
            Cursor = Cursors.WaitCursor
            Enabled = False
            objFormCargar = New FormCargando
            objFormCargar.Show()
            cargaSegundoPlano = New Threading.Thread(AddressOf validarCargarRegistro)
            cargaSegundoPlano.Start()
        Else
            MsgBox(Mensajes.FECHA_FINAL_MAYOR, MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub desHabilitarImpresion()
        VistaPreviaToolStripMenuItem.Enabled = False
        FacturaToolStripMenuItem.Enabled = False
    End Sub
    Private Sub impresionConsolidado()
        Dim reporte As New ftp_reportes
        Dim nombreArchivo, ruta As String
        Dim params As New List(Of String)
        Dim cadena As String
        Dim rprte As ReportClass
        Try
            nombreArchivo = "Consolidado" & ConstantesHC.NOMBRE_PDF_SEPARADOR &
                             cbLaboratorio.SelectedValue.ToString & ConstantesHC.NOMBRE_PDF_SEPARADOR &
                             Format(dtFcehaIniCons.Value, Constantes.FORMATO_FECHA_HORA_GEN) & ConstantesHC.NOMBRE_PDF_SEPARADOR &
                             Format(dtFechaFinCons.Value, Constantes.FORMATO_FECHA_HORA_GEN) &
                             ConstantesHC.EXTENSION_ARCHIVO_PDF
            nombreArchivo = Replace(nombreArchivo, "/", "_").Replace(":", "_").Replace(" ", "_")
            ruta = IO.Path.GetTempPath() & nombreArchivo
            rprte = New rptConsolidadoLab
            cadena = "{VISTA_EMPRESAS.Id_empresa} = " & SesionActual.idEmpresa
            params.Add(txtBuscarConsildado.Text)
            params.Add(Format(dtFcehaIniCons.Value, Constantes.FORMATO_FECHA2))
            params.Add(Format(dtFechaFinCons.Value, Constantes.FORMATO_FECHA2))
            params.Add(SesionActual.idEmpresa)
            params.Add(cbLaboratorio.SelectedValue)
            reporte.reportePDF(ruta, cbLaboratorio.SelectedValue, cadena, "Consolidado", rprte,, params)
            Process.Start(ruta)
            objFormCargar.Dispose()
            Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If dgvConsolidadoExam.RowCount > 0 Then

        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        'Dim params As New List(Of String)
        'params.Add(String.Empty)
        'General.buscarItem("[PROC_CONSOLIDADO_LAB_BUSCAR]",
        '                   params,
        '                   AddressOf cargarPacientes,
        '                   TitulosForm.BUSQUEDA_CONSOLIDADO_LAB,
        '                   False,
        '                   True,
        '                   Constantes.TAMANO_MEDIANO)
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click

    End Sub
End Class