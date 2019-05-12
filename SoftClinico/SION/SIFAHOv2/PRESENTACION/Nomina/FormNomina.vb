Public Class FormNomina
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, PCausar, PanularCausacion As String
    Dim objNomina As New Nomina
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            Try
                dateFechaNomina.Value = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
                cambiarFechaHasta()
                objNomina.codigo = ""
                General.limpiarControles(Me)
                General.deshabilitarBotones(ToolStrip1)
                General.habilitarControles(Me)
                btcancelar.Enabled = True
                btguardar.Enabled = True
                cbHuellero.Checked = True
                btCausaNomina.Visible = False
                txtcodigo.ReadOnly = True
                txtResponsable.ReadOnly = True
                dtFechaHasta.Enabled = False
                rbTotal.Checked = True
                cambiarFechaHasta()
                cbOpcion.Enabled = True
                cbOpcion.SelectedIndex = 0
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If


    End Sub
    Private Sub FormormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If btguardar.Enabled = True Then
            e.Cancel = True
            MsgBox(Mensajes.CAMBIOS_SIN_GUARDAR, MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            Try
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    If Not objNomina.anular() Then
                        MsgBox(Mensajes.IMPOSIBLE_ANULAR_NOMINA, MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    dateFechaNomina.Value = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
                    cambiarFechaHasta()
                    objNomina.codigo = ""
                    General.limpiarControles(Me)
                    General.deshabilitarBotones(ToolStrip1)
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    cbHuellero.Checked = True
                    btCausaNomina.Visible = False

                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                End If
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub
    'If e.ColumnIndex > 4 And Not (e.ColumnIndex = 11 Or e.ColumnIndex = 12 Or e.ColumnIndex = 14 Or e.ColumnIndex = 15 Or e.ColumnIndex = 16) And Not IsDBNull(e.Value) Then
    '        e.Value = CDbl(e.Value).ToString("c2")
    '    ElseIf (e.ColumnIndex = 11 Or e.ColumnIndex = 12 Or e.ColumnIndex = 14 Or e.ColumnIndex = 15 Or e.ColumnIndex = 16) And Not IsDBNull(e.Value) Then
    '        e.Value = Format(e.Value, "###0.00")
    '    ElseIf e.ColumnIndex = 4 Then
    'If e.Value = "ZZZZZZZZZZ" Then
    '            e.Value = Format("", "")
    '        End If
    'End If

    'If e.ColumnIndex = dgvHorario.Columns("Neto Pago").Index AndAlso e.RowIndex <> dgvHorario.Rows.Count - 1 Then
    'If IsDBNull(e.Value) = False AndAlso e.Value >= 0 Then
    '            dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.DeepSkyBlue
    '        Else
    '            dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Red
    '        End If
    'End If

    Private Sub dgvHorario_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvHorario.CellFormatting
        If e.ColumnIndex > 5 And Not (e.ColumnIndex = 12 Or e.ColumnIndex = 13 Or e.ColumnIndex = 15 Or e.ColumnIndex = 16 Or e.ColumnIndex = 17) And Not IsDBNull(e.Value) Then
            e.Value = CDbl(e.Value).ToString("c2")
        ElseIf (e.ColumnIndex = 12 Or e.ColumnIndex = 13 Or e.ColumnIndex = 15 Or e.ColumnIndex = 16 Or e.ColumnIndex = 17) And Not IsDBNull(e.Value) Then
            e.Value = Format(e.Value, "###0.00")
        ElseIf e.ColumnIndex = 5 Then
            If e.Value = "ZZZZZZZZZZ" Then
                e.Value = Format("", "")
            End If
        End If

        If e.ColumnIndex = dgvHorario.Columns("Neto Pago").Index AndAlso e.RowIndex <> dgvHorario.Rows.Count - 1 Then
            If IsDBNull(e.Value) = False AndAlso e.Value >= 0 Then
                If Not dgvHorario.Rows(e.RowIndex).Cells("Pago").Value Then
                    dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Salmon
                Else
                    dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.DeepSkyBlue
                End If
            Else
                If Not dgvHorario.Rows(e.RowIndex).Cells("Pago").Value Then
                    dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Salmon
                Else
                    dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Red
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(dgvHorario.Rows(e.RowIndex).Cells("Contrato").Value.ToString) Then
            If Not dgvHorario.Rows(e.RowIndex).Cells("Pago").Value Then
                dgvHorario.Rows(e.RowIndex).Cells("Contrato").Style.BackColor = Color.Salmon
                dgvHorario.Rows(e.RowIndex).Cells("nombre").Style.BackColor = Color.Salmon
            Else
                dgvHorario.Rows(e.RowIndex).Cells("Contrato").Style.BackColor = dgvHorario.Rows(e.RowIndex).Cells("cargo").Style.BackColor
                dgvHorario.Rows(e.RowIndex).Cells("nombre").Style.BackColor = dgvHorario.Rows(e.RowIndex).Cells("cargo").Style.BackColor
            End If
        End If


        If e.ColumnIndex = dgvHorario.Columns("total devengado").Index Then
            If IsDBNull(e.Value) = False AndAlso e.Value <= 0 AndAlso dgvHorario.Rows(e.RowIndex).Cells("Contrato").Value.ToString <> objNomina.dtEmpleados.Rows(0).Item("Contrato").ToString Then
                dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Salmon
                dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex - 1).Style.BackColor = Color.Salmon
                dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex - 2).Style.BackColor = Color.Salmon
                dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex - 4).Style.BackColor = Color.Salmon
            Else
                dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = dgvHorario.Rows(e.RowIndex).Cells("Cargo").Style.BackColor
                dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex - 1).Style.BackColor = dgvHorario.Rows(e.RowIndex).Cells("Cargo").Style.BackColor
                dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex - 2).Style.BackColor = dgvHorario.Rows(e.RowIndex).Cells("Cargo").Style.BackColor
                dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex - 4).Style.BackColor = dgvHorario.Rows(e.RowIndex).Cells("Cargo").Style.BackColor
            End If
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        txtBuscar.Text = Funciones.validarComillaSimple(txtBuscar.Text)
        objNomina.filtro.Filter = " [Contrato] LIKE '%" + txtBuscar.Text.Trim() + "%' or [Nombre] LIKE '%" + txtBuscar.Text.Trim() + "%'  or [Identificación] LIKE '%" + txtBuscar.Text.Trim() + "%' or [Cargo] LIKE '%" + txtBuscar.Text.Trim() + "%'"
        If txtBuscar.Text.Length = 0 Then
            objNomina.filtro.Filter = ""
            aplicarDiseño()
        End If

    End Sub

    Private Sub verificarSalario()
        For i = 0 To dgvHorario.RowCount - 1
            If dgvHorario.Rows(i).Cells("Bonificación").Value > 0 AndAlso dgvHorario.Rows(i).Cells("Salario").Value = 0 AndAlso
                            Not dgvHorario.Rows(i).Cells("Salario").Style.BackColor = Color.Salmon Then
                dgvHorario.Rows(i).Cells("Salario").Style.BackColor = Color.Salmon
            ElseIf dgvHorario.Rows(i).Cells("Bonificación").Value > 0 AndAlso dgvHorario.Rows(i).Cells("Salario").Value > 0 AndAlso
                    Not dgvHorario.Rows(i).Cells("Salario").Style.BackColor = dgvHorario.Rows(i).Cells("Cargo").Style.BackColor Then
                dgvHorario.Rows(i).Cells("Salario").Style.BackColor = dgvHorario.Rows(i).Cells("Cargo").Style.BackColor
            End If
        Next
    End Sub

    Private Sub FormNomina_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        PCausar = permiso_general & "pp" & "05"
        PanularCausacion = permiso_general & "pp" & "06"
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        General.cargarCombo(ConsultasNom.LISTA_NOMINA_PUNTOS, params, "Nombre", "Codigo", comboPuntoServicio)
        comboPuntoServicio.DataSource.rows.add("-2", "-- TODOS --")
        cbHuellero.Checked = True
        objNomina.cargarDetalle()
        dgvHorario.DataSource = objNomina.filtro
        dgvCausacion.DataSource = objNomina.dtCausacion
        For i = 0 To dgvHorario.Columns.Count - 1
            dgvHorario.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            If i > 5 Then
                dgvHorario.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        objNomina.dtEmpleados.Clear()
        dgvHorario.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7)
        dgvHorario.Columns(0).Frozen = True
        dgvHorario.Columns(1).Frozen = True
        dgvHorario.Columns(2).Frozen = True
        dgvHorario.Columns(3).Frozen = True
        dgvHorario.Columns("Valor Turno").Visible = False
        dgvHorario.Columns("Turnos Programados").Visible = False
        dgvHorario.Columns("Turnos Trabajados").Visible = False
        dgvHorario.Columns("Horas Programadas").Visible = False
        dgvHorario.Columns("Compensadas").Visible = False
        dgvHorario.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cambiarFechaHasta()
        btCalcular.Enabled = False
    End Sub

    Private Sub cambiarFechaHasta()
        Dim fechaInicio As Date = New DateTime(dateFechaNomina.Value.Year, dateFechaNomina.Value.Month, 1)
        Dim fechaFin As Date = New DateTime(dateFechaNomina.Value.Year, dateFechaNomina.Value.Month, DateTime.DaysInMonth(dateFechaNomina.Value.Year, dateFechaNomina.Value.Month))
        If fechaFin.Date < dtFechaHasta.MaxDate.Date Then
            dtFechaHasta.MinDate = fechaInicio
            dtFechaHasta.MaxDate = fechaFin.AddDays(1).AddSeconds(-1)
        Else
            dtFechaHasta.MaxDate = fechaFin.AddDays(1).AddSeconds(-1)
            dtFechaHasta.MinDate = fechaInicio
        End If
        dtFechaHasta.Value = fechaFin
        objNomina.mes = fechaInicio
        objNomina.hasta = dtFechaHasta.Value

    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            If objNomina.dtEmpleados.Rows.Count > 1 Then
                Dim dtErrorEmpleado As New DataTable
                objNomina.dtEmpleados.AcceptChanges()
                dtErrorEmpleado = objNomina.dtEmpleados.Copy
                verificarSalario()
                If dtErrorEmpleado.Select("[Total Devengado]=0 and Pago =True", "").Count > 1 OrElse dtErrorEmpleado.Select("[Salario]=0 and Bonificación > 0  and Pago =True", "").Count > 0 Then
                    MsgBox(Mensajes.IMPOSIBLE_GUARDAR_NOMINA_EMPLEADO_ERROR, MsgBoxStyle.Exclamation)
                    Exit Sub
                ElseIf objNomina.verificaNominaAnterior = False Then
                    MsgBox(Mensajes.IMPOSIBLE_GUARDAR_NOMINA_ANTERIOR_EXISTENTE, MsgBoxStyle.Exclamation)
                    Exit Sub
                ElseIf CDate(Exec.primerDiaMes(dateFechaNomina.Value)).Date > CDate(Exec.primerDiaMes(General.fechaActualServidor())).Date Then
                    MsgBox(Mensajes.IMPOSIBLE_GUARDAR_NOMINA_SUPERIOR, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    guardar()
                End If
                Else
                    MsgBox(Mensajes.IMPOSIBLE_GUARDAR_NOMINA, MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Private Sub guardar()
        dgvHorario.EndEdit()
        objNomina.causada = False
        txtBuscar.Clear()
        objNomina.guardar()
        txtcodigo.Text = objNomina.codigo
        General.deshabilitarControles(Me)
        General.habilitarBotones(ToolStrip1)
        If objNomina.verificaNominaTotal Then
            verificarCausacion()
            btCausaNomina.Enabled = True
        End If
        btguardar.Enabled = False
        btcancelar.Enabled = False
        tsImprimir.Enabled = True
        MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub

    Private Sub rbHasta_CheckedChanged(sender As Object, e As EventArgs) Handles rbHasta.CheckedChanged
        objNomina.dtEmpleados.Clear()
        dtFechaHasta.Enabled = rbHasta.Checked
        If Not dtFechaHasta.Enabled Then
            cambiarFechaHasta()
        End If

    End Sub

    Private Sub dateFechaNomina_ValueChanged(sender As Object, e As EventArgs) Handles dateFechaNomina.ValueChanged
        objNomina.dtEmpleados.Clear()
        cambiarFechaHasta()

    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Return
        End If
        Try
            comboPuntoServicio.SelectedIndex = 0
            dateFechaNomina.Value = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
            cambiarFechaHasta()
            General.limpiarControles(Me)
            General.deshabilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            rbTotal.Checked = True
            cambiarFechaHasta()
            objNomina.codigo = ""
            'Parametros pBoton1 y pBoton2 son opcionales, se valida si vienen vacios
            btnuevo.Enabled = True
            btbuscar.Enabled = True
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub cargarNominaNueva()

        If btguardar.Enabled = False AndAlso btcancelar.Enabled = False Then Exit Sub
        Cursor = Cursors.WaitCursor
        If comboPuntoServicio.SelectedIndex < 1 Then
            objNomina.dtEmpleados.Clear()
        Else
            objNomina.opcion = cbOpcion.SelectedIndex
            objNomina.mes = dateFechaNomina.Value.Date
            objNomina.hasta = dtFechaHasta.Value.Date
            objNomina.aplicaHuellero = cbHuellero.Checked
            objNomina.codigoEP = comboPuntoServicio.SelectedValue
            'If Not objNomina.verificaNominaTotalMes Then
            objNomina.cargarDetalleNuevo()
            ' Else
            'objNomina.dtEmpleados.Clear()
            'End If
            calcular()
        End If
        aplicarDiseño()
        Cursor = Cursors.Default

    End Sub

    Private Sub dtFechaHasta_ValueChanged(sender As Object, e As EventArgs) Handles dtFechaHasta.ValueChanged

    End Sub

    Private Sub tsImprimirHoja_Click(sender As Object, e As EventArgs) Handles tsImprimirHoja.Click
        If Not String.IsNullOrEmpty(txtcodigo.Text) Then
            Try
                Dim nombreRpt As String = "Archivo de Transacciones"
                Dim dtReporte As New DataTable
                Dim params As New List(Of String)

                Cursor = Cursors.WaitCursor
                params.Add(objNomina.codigo)
                General.llenarTabla(ConsultasNom.NOMINA_REPORTE_TRANSACCIONES, params, dtReporte)
                Dim ruta As String = FuncionesExcel.exportarDataTable(dtReporte, nombreRpt)

                Process.Start(ruta)
            Catch ex As Exception
                General.manejoErrores(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        Else
            MsgBox(Mensajes.IMPOSIBLE_IMPRIMIR_NOMINA, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btCausaNomina_Click(sender As Object, e As EventArgs) Handles btCausaNomina.Click
        If SesionActual.tienePermiso(PCausar) Then
            panelCausacion.BringToFront()
            Try
                If objNomina.causada Then
                    cbParafiscales.Enabled = False
                    cargarCausacionNomina()
                Else
                    cbParafiscales.Enabled = True
                    cbParafiscales.Checked = False
                    cargarCausacionNominaNueva()
                    If objNomina.dtCausacion.Rows.Count = 0 Then tsGuardar.Enabled = False
                End If
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub
    Private Sub cargarCausacionNominaNueva()
        Cursor = Cursors.WaitCursor
        objNomina.aplicaParafiscales = cbParafiscales.Checked
        objNomina.cargarCausacionNueva()
        aplicarDiseñoCausacion()
        aplicarFormatoTotales()
        For i = 0 To objNomina.dtCausacion.Rows.Count - 1
            objNomina.dtCausacion.Rows(i).Item("Orden") = i + 1
        Next
        Cursor = Cursors.Default
    End Sub
    Private Sub cargarCausacionNomina()
        Cursor = Cursors.WaitCursor
        objNomina.cargarCausacion()
        aplicarDiseñoCausacion()
        txtComprobanteInicial.Text = objNomina.comprobante
        txtComprobanteFinal.Text = objNomina.comprobante
        fechadoc.Value = objNomina.fechaDoc
        aplicarFormatoTotales()
        Cursor = Cursors.Default
    End Sub
    Private Sub aplicarFormatoTotales()
        txtDebito.Text = CDbl(objNomina.totalDebito).ToString("c2")
        txtCredito.Text = CDbl(objNomina.totalCredito).ToString("c2")
        txtDiferencia.Text = CDbl(objNomina.diferencia).ToString("c2")
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles tsCancelar.Click
        limpiarCausacion()
    End Sub

    Private Sub limpiarCausacion()
        objNomina.dtCausacion.Clear()
        btCausaNomina.Enabled = True
        panelCausacion.Visible = False
        ToolStrip1.Enabled = True
        gbTotal.Enabled = True
        txtComprobanteInicial.Clear()
        txtComprobanteFinal.Clear()
        fechadoc.Value = Now
    End Sub

    Private Sub tsGuardar_Click(sender As Object, e As EventArgs) Handles tsGuardar.Click
        Try
            objNomina.calcularTotalesCausacion()
            If validar() Then
                objNomina.fechaDoc = fechadoc.Value.Date
                objNomina.guardarCausacion()
                txtComprobanteInicial.Text = objNomina.comprobante
                txtComprobanteFinal.Text = objNomina.comprobante
                MsgBox(Mensajes.GUARDADO & " Comprobante: " & objNomina.comprobante, MsgBoxStyle.Information)
                limpiarCausacion()
                verificarCausacion()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Private Function validar()
        If objNomina.dtCausacionDif.Rows.Count > 0 Then
            MsgBox(Mensajes.IMPOSIBLE_GUARDAR_CAUSACION_NOMINA_NO_CUENTA, MsgBoxStyle.Exclamation)
            Return False
        ElseIf FuncionesContables.verificarFecha(fechadoc.Value) Then
            MsgBox(Mensajes.PERIODO_CONTABLE_CERRADO, MsgBoxStyle.Exclamation)
            fechadoc.Focus()
            Return False
        ElseIf objNomina.diferencia <> 0 Then
            MsgBox(Mensajes.IMPOSIBLE_GUARDAR_CAUSACION_NOMINA, MsgBoxStyle.Exclamation)
            Return False
        End If
        Return True
    End Function

    Private Sub tsAnular_Click(sender As Object, e As EventArgs) Handles tsAnular.Click
        If SesionActual.tienePermiso(PanularCausacion) Then
            Try
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    objNomina.anularCausacion()
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    limpiarCausacion()
                    verificarCausacion()
                End If
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            Dim params As New List(Of String)
            params.Add(Nothing)
            params.Add(SesionActual.idEmpresa)
            General.buscarElemento(objNomina.sqlBuscarNomina,
                              params,
                              AddressOf cargarNomina,
                              TitulosForm.BUSQUEDA_NOMINA,
                              False, Constantes.TAMANO_MEDIANO, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub cbParafiscales_CheckedChanged(sender As Object, e As EventArgs) Handles cbParafiscales.CheckedChanged
        cargarCausacionNominaNueva()
    End Sub

    Private Sub dgvCausacion_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvCausacion.CellFormatting
        If e.ColumnIndex > 4 Then
            If IsDBNull(e.Value) Then
                e.Value = 0
            End If
            e.Value = CDbl(e.Value).ToString("c2")
        End If
    End Sub

    Private Sub dgvHorario_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHorario.CellDoubleClick
        If dgvHorario.RowCount > 0 Then
            If e.RowIndex < 0 Then Exit Sub
            If btguardar.Enabled AndAlso e.ColumnIndex = 0 AndAlso Not String.IsNullOrEmpty(dgvHorario.Rows(e.RowIndex).Cells("Codigo_Horario").Value.ToString) Then
                If MsgBox(Mensajes.CAMBIAR_PAGO, MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    dgvHorario.Rows(e.RowIndex).Cells("Pago").Value = Not dgvHorario.Rows(e.RowIndex).Cells("Pago").Value
                    dgvHorario.Rows(e.RowIndex).Selected = False
                    dgvHorario.Rows(e.RowIndex - 1).Selected = True
                End If
                calcular()
            End If
        End If

    End Sub
    Private Sub calcular()
        Dim totalPagar, totalPagarLibranza As Double
        Dim pagarContrato, pagarLibranza As Double
        For col = 5 To objNomina.dtEmpleados.Columns.Count - 2
            pagarContrato = 0
            pagarLibranza = 0
            totalPagar = 0
            Dim indiceCol As Integer
            indiceCol = 0
            If SesionActual.idEmpresa <> 1 Then ''ESTO ES PARA LA EMPRESA AMBULANCIA, ESTO NO SE DEBE TENEREN CUENTA EN FUTURAS EMPRESAS
                indiceCol = 1
            End If
            For i = indiceCol To objNomina.dtEmpleados.Rows.Count - 2
                If objNomina.dtEmpleados.Rows(i).Item("Pago") Then
                    If objNomina.dtEmpleados.Columns(col).ColumnName = "Libranza" Then
                        pagarLibranza = objNomina.dtEmpleados.Rows(i).Item(col)
                        If pagarLibranza > 0 Then
                            totalPagarLibranza += pagarLibranza
                        End If
                    Else
                        pagarContrato = objNomina.dtEmpleados.Rows(i).Item(col)
                        If pagarContrato > 0 Then
                            totalPagar += pagarContrato
                        End If
                    End If
                End If
            Next
            objNomina.dtEmpleados.Rows(objNomina.dtEmpleados.Rows.Count - 1).Item(col) = totalPagar
        Next
        If SesionActual.idEmpresa <> 1 Then ''ESTO ES PARA LA EMPRESA AMBULANCIA, ESTO NO SE DEBE TENEREN CUENTA EN FUTURAS EMPRESAS
            objNomina.dtEmpleados.Rows(0).Item("Neto Pago") = CLng(totalPagarLibranza)
        End If

        objNomina.dtEmpleados.Rows(objNomina.dtEmpleados.Rows.Count - 1).Item("Neto Pago") += CLng(totalPagarLibranza)
        objNomina.dtEmpleados.Rows(objNomina.dtEmpleados.Rows.Count - 1).Item("Libranza") = CLng(totalPagarLibranza)
    End Sub
    Private Sub dgvHorario_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHorario.CellContentClick

    End Sub

    Private Sub dgvCausacion_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvCausacion.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
    End Sub

    Private Sub dgvCausacion_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvCausacion.DataError
        MsgBox(Mensajes.CANTIDAD_VALIDA, MsgBoxStyle.Exclamation)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btCalcular.Click
        cargarNominaNueva()
    End Sub

    Private Sub gbTotal_Enter(sender As Object, e As EventArgs) Handles gbTotal.Enter

    End Sub

    Private Sub cbOpcion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOpcion.SelectedIndexChanged
        If btnuevo.Enabled Then Exit Sub
        btguardar.Enabled = cbOpcion.SelectedIndex = 0
        objNomina.dtEmpleados.Clear()
    End Sub


    Private Sub comboPuntoServicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboPuntoServicio.SelectedIndexChanged
        objNomina.dtEmpleados.Clear()
    End Sub

    Private Sub dgvCausacion_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCausacion.CellEndEdit
        objNomina.calcularTotalesCausacion()
        aplicarFormatoTotales()
    End Sub

    Private Sub cargarNomina(pCodigo As Integer)
        Cursor = Cursors.WaitCursor
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(pCodigo)
        params.Add(SesionActual.idEmpresa)
        Try
            dFila = General.cargarItem(objNomina.sqlCargarNomina, params)

            objNomina.codigo = pCodigo
            objNomina.mes = dFila.Item(0)
            objNomina.codigoEP = If(IsDBNull(dFila.Item(1)), "-2", dFila.Item(1))
            objNomina.hasta = dFila(2)
            objNomina.aplicaHuellero = dFila(3)
            txtResponsable.Text = dFila(4)
            objNomina.causada = dFila(5)
            If objNomina.causada Then
                objNomina.comprobante = dFila(7)
            Else
                objNomina.comprobante = ""
            End If
            objNomina.fechaDoc = dFila(8)

            If dFila(6) = True Then
                rbTotal.Checked = True
                rbHasta.Checked = False
            Else
                rbTotal.Checked = False
                rbHasta.Checked = True
            End If
            txtcodigo.Text = objNomina.codigo
            dateFechaNomina.Value = objNomina.mes
            comboPuntoServicio.SelectedValue = objNomina.codigoEP
            dtFechaHasta.Value = objNomina.hasta
            cbHuellero.Checked = objNomina.aplicaHuellero
            verificarCausacion()
            btCausaNomina.Visible = dFila(6)
            objNomina.cargarDetalle()
            objNomina.filtro.Filter = ""
            dgvHorario.CommitEdit(DataGridViewDataErrorContexts.Commit)
            aplicarDiseño()

            bteditar.Enabled = True
            btanular.Enabled = True
            tsImprimir.Enabled = True
            txtBuscar.ReadOnly = False
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub verificarCausacion()
        btCausaNomina.Visible = True
        btCausaNomina.Enabled = True
        If objNomina.causada Then
            btCausaNomina.Text = "Nómina Causada"
            btCausaNomina.Image = My.Resources.Ok_icon1
        Else
            btCausaNomina.Text = "Generar Causación"
            btCausaNomina.Image = My.Resources._04_Save_icon1
        End If
    End Sub
    Private Sub aplicarDiseño()
        Dim indiceNetoPago As Integer = dgvHorario.Columns("Neto Pago").Index
        Dim ultimaFila As Integer = dgvHorario.Rows.Count - 1
        If dgvHorario.Rows.Count = 0 Then Exit Sub
        dgvHorario.Columns(indiceNetoPago).DefaultCellStyle.BackColor = Color.DeepSkyBlue
        For i = 6 To dgvHorario.ColumnCount - 1
            dgvHorario.Rows(ultimaFila).Cells(i).Style.BackColor = Color.SkyBlue
            dgvHorario.Rows(ultimaFila).Cells(i).Style.ForeColor = Color.Red
            If i > indiceNetoPago Then
                dgvHorario.Columns(i).Visible = False
            End If
        Next
        dgvHorario.ReadOnly = True
        dgvHorario.Columns(1).Visible = False
        dgvHorario.Rows(ultimaFila).Cells(indiceNetoPago).Style.BackColor = Color.Red
        dgvHorario.Rows(ultimaFila).Cells(indiceNetoPago).Style.ForeColor = Color.White
        dgvHorario.Rows(ultimaFila).Cells(indiceNetoPago).Style.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO_ARIAL, 9, FontStyle.Bold)
        dgvHorario.Rows(ultimaFila).Cells(1).Style.BackColor = Color.SkyBlue
        dgvHorario.Rows(ultimaFila).Cells(1).Style.ForeColor = Color.Red
        dgvHorario.Rows(ultimaFila).Cells(1).Style.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO_ARIAL, 9)
        dgvHorario.Columns(0).Visible = String.IsNullOrEmpty(txtcodigo.Text)
        verificarSalario()
    End Sub


    Private Sub aplicarDiseñoCausacion()
        dgvCausacion.ReadOnly = False
        dgvCausacion.Columns("Id_empleado").Visible = False
        dgvCausacion.Columns("Orden").Visible = False
        dgvCausacion.Columns("Codigo Cuenta").ReadOnly = True
        dgvCausacion.Columns("Descripcion").ReadOnly = True
        dgvCausacion.Columns("Nombre").ReadOnly = True
        dgvCausacion.Columns("Documento").ReadOnly = True
        dgvCausacion.Columns("Crédito").ReadOnly = objNomina.causada
        dgvCausacion.Columns("Débito").ReadOnly = objNomina.causada
        dgvCausacion.Columns("Codigo Cuenta").DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO_ARIAL, 8)
        dgvCausacion.Columns("Descripcion").DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO_ARIAL, 8)
        dgvCausacion.Columns("Nombre").DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO_ARIAL, 8)
        dgvCausacion.Columns("Documento").DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO_ARIAL, 8)
        dgvCausacion.Columns("Nombre").Frozen = True
        dgvCausacion.Columns("Documento").Frozen = True
        For i = 0 To dgvCausacion.Columns.Count - 1
            If i > 1 Then
                dgvCausacion.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Else
                dgvCausacion.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End If
            If i > 4 Then
                dgvCausacion.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        btCausaNomina.Enabled = False
        panelCausacion.Visible = True
        If objNomina.dtCausacionDif.Columns.Count > 0 Then
            For i = 0 To dgvCausacion.RowCount - 1
                If objNomina.dtCausacionDif.Select("Id_empleado=" & objNomina.dtCausacion.Rows(i).Item("Id_empleado"), "").Count > 0 Then
                    dgvCausacion.Rows(i).DefaultCellStyle.BackColor = Color.Salmon
                End If
            Next
        End If
        ToolStrip1.Enabled = False
        gbTotal.Enabled = False
        cbParafiscales.Enabled = Not objNomina.causada
        tsGuardar.Enabled = Not objNomina.causada
        fechadoc.Enabled = Not objNomina.causada
        txtComprobanteInicial.ReadOnly = True
        txtComprobanteFinal.ReadOnly = True
        txtDebito.ReadOnly = True
        txtCredito.ReadOnly = True
        txtDiferencia.ReadOnly = True
        tsCancelar.Enabled = True
        tsAnular.Enabled = objNomina.causada
    End Sub
End Class
