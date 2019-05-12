Public Class FormDeducciones
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim perG As New Buscar_Permisos_generales
    Dim objDeduccion As New Deduccion
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form_antici_decucci_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarControles(Me)
        cargarCombos()
        objDeduccion.codigo = -1
        objDeduccion.cargarDeduccionAnticipo()
        objDeduccion.cargarDeduccionExcepcion()
        cargarObjeto()
        objDeduccion.calcularMovimientos()
        dgvhistorico.DataSource = objDeduccion.dtMovimientos
        dgvAnticipoDeuda.DataSource = objDeduccion.dtAnticipoDeuda
        dgvExceptuarMes.DataSource = objDeduccion.dtExceptuarMes
        dgvHistorialPago.DataSource = objDeduccion.dtHistorialPagos
        dgvhistorico.Columns("Fecha").Width = 70
        dgvhistorico.Columns("Cuota").Width = 40
        dgvhistorico.Columns("Dias").Width = 40
        dgvhistorico.Columns("Nómina").Width = 130
        dgvhistorico.Columns("Tipo").Visible = False
        For i = 0 To dgvhistorico.Columns.Count - 1
            If i < 3 Then
                dgvhistorico.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ElseIf i < dgvhistorico.Columns.Count - 2 Then
                dgvhistorico.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Else
                dgvhistorico.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End If
        Next
        dgvAnticipoDeuda.Columns("Código").Width = 60
        dgvAnticipoDeuda.Columns("Fecha").Width = 70
        dgvAnticipoDeuda.Columns("Movimiento").Width = 200
        dgvAnticipoDeuda.Columns("Tipo_Movimiento").Visible = False
        dgvAnticipoDeuda.Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvAnticipoDeuda.Columns("Valor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgvExceptuarMes.Columns("Fecha").Width = 70
        dgvExceptuarMes.Columns("Base").Width = 40
        dgvExceptuarMes.Columns("Interes").Width = 40
        dgvExceptuarMes.Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgvhistorico.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvAnticipoDeuda.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvExceptuarMes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cambiarFechaCobro()
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            rbsaldo.Checked = True
            objDeduccion.codigo = "-1"
            General.deshabilitarControles(gbRefinanciar)
            General.deshabilitarControles(gbTipoInteres)
            General.deshabilitarControles(gbGeneral)
            btBuscarEmpleado.Enabled = True
            fechaNomina.Enabled = True
            combotipo.Enabled = True
            numSaldo.Enabled = False
            numSaldo.ReadOnly = True
            numMora.Enabled = False
            numMora.ReadOnly = True
            General.deshabilitarControles(tcMovimientos)
            btguardar.Enabled = False
            txtRespuesta.Visible = False
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
            General.deshabilitarControles(gbGeneral)
            General.deshabilitarControles(gbPrestamo)
            If objDeduccion.saldo = objDeduccion.Valor Then
                fechaDeduccion.Enabled = True
                numValorPrestamo.Enabled = True
                numValorPrestamo.ReadOnly = False
                numCuotas.Enabled = True
                numCuotas.ReadOnly = False
                General.habilitarControles(gbTipoInteres)
            Else
                btRefinanciar.Enabled = True
            End If
            dgvhistorico.ReadOnly = True
            dgvAnticipoDeuda.ReadOnly = True
            dgvExceptuarMes.ReadOnly = True
            dgvHistorialPago.ReadOnly = True
            reiniciarAnticipo()
            reiniciarExcepcionMes()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub bteditar_EnabledChanged(sender As Object, e As EventArgs) Handles bteditar.EnabledChanged

    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        Try
            If General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar) Then
                btbuscar.Enabled = True
                btcancelar.Enabled = False
                btRefinanciar.Image = My.Resources.Calculator_iconref
                txtRespuesta.Visible = False
            End If
        Catch ex As SqlException
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            If (combotipo.SelectedIndex <= 0) Then
                MsgBox("¡Por favor seleccione el tipo de deduccion!", MsgBoxStyle.Exclamation)
                combotipo.Focus()
            ElseIf (CInt(numValorPrestamo.Value) <= 0) Then
                MsgBox("¡Por favor digite el valor de la deduccion!", MsgBoxStyle.Exclamation)
                numValorPrestamo.Focus()
            ElseIf Exec.primerDiaMes(fechaDeduccion.value) > Exec.primerDiaMes(fechaNomina.value) Then
                MsgBox("¡Por favor seleccione mes de cobro igual o mayor al de la deducción!", MsgBoxStyle.Exclamation)
            ElseIf MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                cargarObjeto()
                objDeduccion.guardar()
                txtcodigo.Text = objDeduccion.codigo
                cargar(objDeduccion.codigo)
                General.habilitarBotones(ToolStrip1)
                General.deshabilitarControles(Me)
                btguardar.Enabled = False
                btcancelar.Enabled = False
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Try
            If SesionActual.tienePermiso(Panular) Then
                If objDeduccion.Valor = objDeduccion.saldo Then
                    If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                        objDeduccion.anular()
                        General.limpiarControles(Me)
                        General.deshabilitarControles(Me)
                        General.deshabilitarBotones(ToolStrip1)
                        btnuevo.Enabled = True
                        btbuscar.Enabled = True
                        MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                        txtRespuesta.Visible = False
                    End If
                Else
                    MsgBox(Mensajes.IMPOSIBLE_ANULAR_DEDUCCION, MsgBoxStyle.Exclamation)
                End If
            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.idEmpresa)
            params.Add(Nothing)
            General.buscarElemento(objDeduccion.sqlBuscarDeduccion,
                                   params,
                                   AddressOf cargar,
                                   TitulosForm.BUSQUEDA_DEDUCCION,
                                   False, Constantes.TAMANO_MEDIANO, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargar(pCodigo As Integer)
        Cursor = Cursors.WaitCursor
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(pCodigo)
        Try

            General.limpiarControles(dgvhistorico)
            General.limpiarControles(dgvAnticipoDeuda)
            General.limpiarControles(dgvExceptuarMes)
            objDeduccion.dtMovimientos.Clear()
            objDeduccion.dtAnticipoDeuda.Clear()
            objDeduccion.dtExceptuarMes.Clear()
            dFila = General.cargarItem(objDeduccion.sqlCargarDeduccion, params)
            objDeduccion.codigo = pCodigo
            txtcodigo.Text = objDeduccion.codigo
            objDeduccion.Valor = dFila(4)
            objDeduccion.tipo = dFila.Item(0)
            numValorPrestamo.Value = objDeduccion.Valor

            objDeduccion.id_empleado = dFila.Item(1)
            objDeduccion.Valor = dFila(4)
            objDeduccion.Fecha_Deduccion = dFila(5)
            objDeduccion.Fecha_cobro = dFila(6)
            objDeduccion.cuotas = dFila(7)
            objDeduccion.tasa_Interes = dFila(8)
            objDeduccion.Tipo_Interes = dFila(9).ToString
            objDeduccion.estado = dFila(10)
            objDeduccion.id_empresa_prestadora = dFila(11).ToString
            objDeduccion.mesesHistorial = ConstantesNom.MESES_ESTUDIO_PAGO
            numPagos.Value = objDeduccion.mesesHistorial
            objDeduccion.cargarHistorialPagos()
            combotipo.SelectedValue = objDeduccion.tipo
            aplicarDiseñoPagos()
            If objDeduccion.tipo = ConstantesNom.TIPO_LIBRANZA Then
                objDeduccion.cargarDeduccionAnticipo()
                objDeduccion.cargarDeduccionExcepcion()
                objDeduccion.calcularMovimientos()
            End If
            objDeduccion.interesMora = dFila(14)
            objDeduccion.calcularSaldo()
            numSaldo.Value = objDeduccion.saldo
            aplicarDiseño()

            textcedula.Text = dFila.Item(2)
            txtNombre.Text = dFila.Item(3)
            numValorPrestamo.Value = objDeduccion.Valor
            'objDeduccion.Fecha_Deduccion = dFila(5) ''lo debo repetir por conflictos con el control numValorPrestamo
            'objDeduccion.cuotas = dFila(7)

            General.deshabilitarControles(gbTipoInteres)

            numCuotas.Value = objDeduccion.cuotas
            objDeduccion.tasa_Interes = dFila(8)
            numtasainteres.Value = objDeduccion.tasa_Interes
            'objDeduccion.Fecha_cobro = dFila(6)
            fechaNomina.Value = objDeduccion.Fecha_cobro
            'numCuotas.Value = objDeduccion.cuotas
            txtNit.Text = dFila(12).ToString
            txtRazonSocial.Text = dFila(13).ToString
            numMora.Value = dFila(14)
            fechaDeduccion.Value = objDeduccion.Fecha_Deduccion
            If objDeduccion.Tipo_Interes = ConstantesNom.TIPO_INTERES_SALDO Then
                rbbase.Checked = False
                rbsaldo.Checked = True
            Else
                rbbase.Checked = True
                rbsaldo.Checked = False
            End If
            numCuotas.Enabled = False
            numCuotas.ReadOnly = True
            bteditar.Enabled = True
            btanular.Enabled = True
            btAnticipo.Enabled = False
            btExceptuarMes.Enabled = False

        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub aplicarDiseño()
        Dim indiceNomina As Integer = dgvhistorico.Columns("Nómina").Index
        For i = 0 To dgvhistorico.RowCount - 1
            If dgvhistorico.Rows(i).Cells(indiceNomina).Value.ToString <> Constantes.PENDIENTE_LETRA Then
                dgvhistorico.Rows(i).Cells(indiceNomina).Style.BackColor = Color.FromArgb(192, 255, 192)
                dgvhistorico.Rows(i).Cells(indiceNomina).Style.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO_ARIAL, 8)
            End If
        Next
        dgvhistorico.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO_ARIAL, 8)
        dgvhistorico.ReadOnly = True
        dgvAnticipoDeuda.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO_ARIAL, 8)
        dgvAnticipoDeuda.ReadOnly = True
        dgvExceptuarMes.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO_ARIAL, 8)
        dgvExceptuarMes.ReadOnly = True
    End Sub

    Private Sub Form_antici_decucci_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub fechaNomina_ValueChanged(sender As Object, e As EventArgs) Handles fechaNomina.ValueChanged
        If (CDbl(fechaNomina.Value.ToString("yyyyMM")) < CDbl(fechaDeduccion.Value.ToString("yyyyMM"))) Then
            If btguardar.Enabled = False Then Exit Sub
            fechaNomina.Value = fechaDeduccion.Value
            Dim descripcion = gbPrestamo.Text.Trim.Split(" ")(0)
            Dim msg = String.Format("error: mes de cobro no permitido, es menor a fecha {0}: ' {1:MMMM / yyyy} '", descripcion, fechaDeduccion.Value)
            MsgBox(msg, MsgBoxStyle.Information)
        Else
            calcularMovimientos()
        End If
    End Sub

    Private Sub fechaDeduccion_ValueChanged(sender As Object, e As EventArgs) Handles fechaDeduccion.ValueChanged
        cambiarFechaCobro()
        calcularMovimientos()
    End Sub
    Private Sub cambiarFechaCobro()
        If Visible = False Or btguardar.Enabled = False Then Exit Sub
        Dim fechaCobro As Date = New DateTime(fechaDeduccion.Value.Year, fechaDeduccion.Value.Month, 1)
        fechaNomina.Value = fechaCobro
    End Sub
    Private Sub calcular_CheckedChanged(sender As Object, e As EventArgs) Handles numValorPrestamo.ValueChanged,
                                                                                  rbbase.CheckedChanged,
                                                                                  numCuotas.ValueChanged,
                                                                                  numtasainteres.ValueChanged
        calcularMovimientos()
    End Sub

    Sub calcularMovimientos()
        Try
            If numValorPrestamo.Value > 0 Then
                If btguardar.Enabled = True Then
                    cargarObjeto()
                End If

                Select Case objDeduccion.tipo
                    Case ConstantesNom.TIPO_LIBRANZA

                        objDeduccion.calcularMovimientos()
                        aplicarDiseño()

                End Select
                numSaldo.Value = objDeduccion.saldo
                realizarEstudioDeCredito()
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Sub cargarObjeto()
        objDeduccion.codigo = If(String.IsNullOrEmpty(txtcodigo.Text), -1, txtcodigo.Text)
        objDeduccion.cuotas = numCuotas.Value
        objDeduccion.Valor = numValorPrestamo.Value
        objDeduccion.saldo = numSaldo.Value
        objDeduccion.Fecha_cobro = Exec.primerDiaMes(fechaNomina.Value)
        objDeduccion.Fecha_Deduccion = fechaDeduccion.Value
        objDeduccion.tasa_Interes = numtasainteres.Value
        objDeduccion.Tipo_Interes = If(rbbase.Checked = True, ConstantesNom.TIPO_INTERES_BASE, ConstantesNom.TIPO_INTERES_SALDO)
        objDeduccion.cuotas_Refinanciadas = numValorRefinanciar.Value
        objDeduccion.Adicional_Refinanciado = numCuotasRefinanciar.Value
    End Sub

    Sub cargarCombos()
        Dim sqlTip = String.Format(Consultas.CARGAR_TIPOS_DEDUCCION, SesionActual.idUsuario, SesionActual.idEmpresa, SesionActual.codigoPerfil)
        'Dim sqlEmp = Consultas.CARGAR_EMPLEADOS_HOR & SesionActual.idEmpresa & ", '" & fechaNomina.Value.ToString("yyyyMMdd") & "', ''"
        General.cargarCombo(sqlTip, "Nombre", "Codigo", combotipo)
    End Sub

#Region "Tab Ajustes"
    Private Sub btrealizaranticipo_Click(sender As Object, e As EventArgs) Handles btAnticipo.Click
        If objDeduccion.anticipo Then
            objDeduccion.anticipo = False
            reiniciarAnticipo()
        Else
            btAnticipo.Image = My.Resources.cancelarr3
            objDeduccion.anticipo = True
            numValorAnticiparDeuda.Enabled = True
            numValorAnticiparDeuda.ReadOnly = False
            gbMedioPago.Enabled = True
            btAnticipo.Text = "Cancelar"
            btAgregarAnticipo.Enabled = True
            btQuitarAnticipo.Enabled = True
            rbProNomina.Checked = True
            numValorAnticiparDeuda.Focus()
            rbProNomina.Enabled = True
            rbEfectivo.Enabled = True
        End If
    End Sub

    Private Sub reiniciarAnticipo()
        btAnticipo.Image = My.Resources.payment_icon
        numValorAnticiparDeuda.Value = 0
        numValorAnticiparDeuda.Enabled = False
        numValorAnticiparDeuda.ReadOnly = True
        gbMedioPago.Enabled = False
        btAnticipo.Text = "Abono"
        btAgregarAnticipo.Enabled = False
        btQuitarAnticipo.Enabled = False
        objDeduccion.cargarDeduccionAnticipo()
        calcularMovimientos()
    End Sub

    Private Sub btagregaranticipo_Click(sender As Object, e As EventArgs) Handles btAgregarAnticipo.Click
        If numValorAnticiparDeuda.Value = 0 Then
            Dim msg = "El valor del abono no puede ser cero!"
            MsgBox(msg, MsgBoxStyle.Exclamation)
        ElseIf numValorAnticiparDeuda.Value > numSaldo.value Then
            Dim msg = "El valor del abono no puede ser mayor al saldo actual de la deuda!"
            MsgBox(msg, MsgBoxStyle.Exclamation)
        Else
            Dim fechaAnticipo As Date
            If rbProNomina.Checked Then
                fechaAnticipo = Exec.primerDiaMes(General.fechaActualServidor)
                For Each dw As DataRow In objDeduccion.dtExceptuarMes.Rows
                    If dw("Fecha") = fechaAnticipo Then
                        Dim msg = String.Format("[{0:MMMM | yyyy}] Ya tiene excepción.", fechaAnticipo)
                        MsgBox(msg, MsgBoxStyle.Exclamation)
                        Return
                    End If
                Next
                For Each dw As DataRow In objDeduccion.dtAnticipoDeuda.Rows
                    If dw("Fecha") = fechaAnticipo And dw("Tipo_Movimiento") = 0 Then
                        Dim msg = String.Format("[{0:MMMM | yyyy}] Ya tiene un anticipo para la próxima nómina.", fechaAnticipo)
                        MsgBox(msg, MsgBoxStyle.Exclamation)
                        Return
                    End If
                Next
            Else
                fechaAnticipo = General.fechaActualServidor.Date
                For Each dw As DataRow In objDeduccion.dtAnticipoDeuda.Rows
                    If Format(dw("Fecha"), "yyyy-MM") = Format(fechaAnticipo, "yyyy-MM") And dw("Tipo_Movimiento") = 1 Then
                        Dim msg = String.Format("[{0:MMMM | yyyy}] Ya tiene un abono en efectivo.", fechaAnticipo)
                        MsgBox(msg, MsgBoxStyle.Exclamation)
                        Return
                    End If
                Next

            End If
            objDeduccion.dtAnticipoDeuda.Rows.Add("", fechaAnticipo, numValorAnticiparDeuda.Value,
                                                  If(rbProNomina.Checked, ConstantesNom.MOVIMIENTO_PROXIMA_NOMINA, ConstantesNom.MOVIMIENTO_EFECTIVO),
                                                  If(rbProNomina.Checked, ConstantesNom.MOVIMIENTO_DESCRIPCION_PROXIMA_NOMINA,
                                                  ConstantesNom.MOVIMIENTO_DESCRIPCION_EFECTIVO))
            calcularMovimientos()
        End If
    End Sub

    Private Sub btquitaranticipo_Click(sender As Object, e As EventArgs) Handles btQuitarAnticipo.Click
        If objDeduccion.dtAnticipoDeuda.Rows.Count = 0 Then Exit Sub
        If verificarFechaAnular(CDate(objDeduccion.dtAnticipoDeuda.Rows(dgvAnticipoDeuda.CurrentRow.Index).Item("Fecha")).Date) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                objDeduccion.dtAnticipoDeuda.Rows.RemoveAt(dgvAnticipoDeuda.CurrentRow.Index)
                calcularMovimientos()
                MsgBox(Mensajes.GUARDE_ANTES_PARA_EFECTUAR, MsgBoxStyle.Information)
            End If
        Else
            MsgBox(Mensajes.IMPOSIBLE_ANULAR_MOVIMIENTO, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Function verificarFechaAnular(pFecha As Date)
        If Format(CDate(pFecha).Date, "yyyy-MM") >= Format(CDate(General.fechaActualServidor()).Date, "yyyy-MM") Then
            Return True
        End If
        Return False
    End Function

    Private Sub btexceptuarmes_Click(sender As Object, e As EventArgs) Handles btExceptuarMes.Click
        If objDeduccion.exceptuar Then
            objDeduccion.exceptuar = False
            reiniciarExcepcionMes()
        Else
            btExceptuarMes.Image = My.Resources.cancelarr3
            objDeduccion.exceptuar = True
            btAgregarExceptuo.Enabled = True
            btQuitarExceptuo.Enabled = True
            btExceptuarMes.Text = "Cancelar"
            cbBase.Enabled = True
            cbInteres.Enabled = True
            cbBase.Checked = True
            cbInteres.Checked = True
            fechaExceptuarMes.Enabled = True
            fechaExceptuarMes.Focus()
        End If
    End Sub

    Private Sub reiniciarExcepcionMes()
        btExceptuarMes.Image = My.Resources.coin_delete_icon
        btExceptuarMes.Text = "Exceptuar Cobro"
        btAgregarExceptuo.Enabled = False
        btQuitarExceptuo.Enabled = False
        cbBase.Enabled = False
        cbInteres.Enabled = False
        cbBase.Checked = False
        cbInteres.Checked = False
        fechaExceptuarMes.Enabled = False
        objDeduccion.cargarDeduccionExcepcion()
        calcularMovimientos()
    End Sub

    Private Sub dgvhistorico_CellFormatting(dgv As DataGridView, e As DataGridViewCellFormattingEventArgs) Handles dgvhistorico.CellFormatting
        If e.ColumnIndex > 2 And e.ColumnIndex < dgv.ColumnCount - 2 Then
            If IsDBNull(e.Value) Then
                e.Value = 0
            End If
            e.Value = CDbl(e.Value).ToString("c2")
        End If
    End Sub

    Private Sub dgvAnticipoDeuda_CellFormatting(dgv As DataGridView, e As DataGridViewCellFormattingEventArgs) Handles dgvAnticipoDeuda.CellFormatting
        If e.ColumnIndex = 2 Then
            e.Value = CDbl(e.Value).ToString("c2")
        End If
    End Sub

    Private Sub btRefinanciar_Click(sender As Object, e As EventArgs) Handles btRefinanciar.Click
        If objDeduccion.refinanciar Then
            objDeduccion.refinanciar = False
            btRefinanciar.Image = My.Resources.Calculator_iconref
            numCuotasRefinanciar.Value = 1
            numValorRefinanciar.Value = 0
            numCuotasRefinanciar.Enabled = False
            numCuotasRefinanciar.ReadOnly = True
            numValorRefinanciar.Enabled = False
            numValorRefinanciar.ReadOnly = True
            btRefinanciar.Text = "Refinanciar"
        Else
            General.mensajeProximante()
            btRefinanciar.Image = My.Resources.cancelarr
            objDeduccion.refinanciar = True
            numCuotasRefinanciar.Enabled = True
            numCuotasRefinanciar.ReadOnly = False
            numValorRefinanciar.Enabled = True
            numValorRefinanciar.ReadOnly = False
            btRefinanciar.Text = "Cancelar"
        End If


    End Sub

    Private Sub btagregarexceptuo_Click(sender As Object, e As EventArgs) Handles btAgregarExceptuo.Click
        Dim vMes = Exec.primerDiaMes(fechaExceptuarMes.Value)
        If validarMes(vMes) Then

            objDeduccion.dtExceptuarMes.Rows.Add(vMes, cbBase.Checked, cbInteres.Checked)
            fechaExceptuarMes.Value = vMes.AddMonths(1)
            calcularMovimientos()
        End If

    End Sub

    Private Sub numValorRefinanciar_ValueChanged(sender As Object, e As EventArgs) Handles numValorRefinanciar.ValueChanged
        calcularMovimientos()
    End Sub

    Private Sub numCuotasRefinanciar_ValueChanged(sender As Object, e As EventArgs) Handles numCuotasRefinanciar.ValueChanged
        calcularMovimientos()
    End Sub

    Private Sub combotipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combotipo.SelectedIndexChanged
        If combotipo.SelectedIndex > 0 Then
            objDeduccion.tipo = combotipo.SelectedValue
            habilitarDisenoVentana()
            gbMovimiento.Enabled = True
        Else
            gbMovimiento.Enabled = False
        End If
    End Sub

    Private Sub habilitarDisenoVentana()
        Select Case objDeduccion.tipo
            Case ConstantesNom.TIPO_ANTICIPO_SALARIAL, ConstantesNom.TIPO_TELEFONIA, ConstantesNom.TIPO_EXEQUIAS
                habilitarAnticipoYCobrosMensualesConstantes()
            Case ConstantesNom.TIPO_PRESTAMO
                habilitarPrestamos()
            Case ConstantesNom.TIPO_LIBRANZA
                habilitarLibranza()
        End Select
    End Sub

    Private Sub habilitarLibranza()
        General.habilitarControles(gbTipoInteres)
        habilitarPagina()
        numtasainteres.Value = ConstantesNom.INTERES_DEFECTO
        numPagos.Value = ConstantesNom.MESES_ESTUDIO_PAGO
        If String.IsNullOrEmpty(txtcodigo.Text) Then
            btAnticipo.Enabled = True
            btExceptuarMes.Enabled = True
        End If
    End Sub

    Private Sub habilitarPrestamos()
        deshabilitarPagina()
        numCuotas.Minimum = 1
        numCuotas.Value = 1
        numCuotas.Enabled = True
        numCuotas.ReadOnly = False
        General.deshabilitarControles(gbTipoInteres)
        numtasainteres.Value = 0
        numSaldo.Value = numValorPrestamo.Value
    End Sub

    Private Sub habilitarAnticipoYCobrosMensualesConstantes()
        deshabilitarPagina()
        General.deshabilitarControles(gbTipoInteres)
        numtasainteres.Value = 0
        numCuotas.Minimum = 0
        numCuotas.Value = 0
        numSaldo.Value = numValorPrestamo.Value
    End Sub

    Private Sub deshabilitarPagina()
        numCuotas.Enabled = False
        numCuotas.ReadOnly = True
        TabPage1.Parent = Nothing
        TabPage2.Parent = Nothing
    End Sub
    Private Sub habilitarPagina()
        numCuotas.Minimum = 1
        numCuotas.Value = 1
        numCuotas.Enabled = True
        numCuotas.ReadOnly = False
        TabPage2.Parent = Nothing
        TabPage3.Parent = Nothing
        TabPage1.Parent = tcMovimientos
        TabPage2.Parent = tcMovimientos
        TabPage3.Parent = tcMovimientos
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btBuscarEmpleado.Click
        Dim params As New List(Of String)
        params.Add(Nothing)
        params.Add(SesionActual.idUsuario)
        General.buscarElemento(ConsultasNom.ESTADO_MENSUAL_TRABAJADOR_BUSCAR,
                                   params,
                                   AddressOf cargarEmpleado,
                                   TitulosForm.BUSQUEDA_TERCERO, False, 0, True)
    End Sub

    Private Sub cargarEmpleado(pCodigo)
        Dim dtTercero As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(ConsultasNom.ESTADO_MENSUAL_EMPLEADO_CARGAR, params, dtTercero)
        If dtTercero.Rows.Count > 0 Then
            textcedula.Text = dtTercero.Rows(0).Item("Nit")
            txtNombre.Text = dtTercero.Rows(0).Item("Tercero")
            Dim fecha As Date = General.fechaActualServidor
            fecha = Format(fecha.Date.AddMonths(1), Constantes.FORMATO_FECHA_GEN)
            fechaNomina.Value = fecha
            objDeduccion.codigo_Contrato = pCodigo
            objDeduccion.id_empleado = dtTercero.Rows(0).Item("Id_Empleado")
            numPagos.Value = objDeduccion.mesesHistorial
            cambiarFechaCobro()
            objDeduccion.Fecha_Deduccion = fechaDeduccion.Value
            numPagos.Value = objDeduccion.mesesHistorial
            objDeduccion.cargarHistorialPagos()
            aplicarDiseñoPagos()
            numPagos.Enabled = True
            numPagos.ReadOnly = False
            cargarEmpresa(ConstantesNom.ID_EMPRESA_PRESTADORA) '' por ahora esta quedama la empresa 1
            btguardar.Enabled = True
        End If
    End Sub

    Private Sub btBuscarEmpresa_Click(sender As Object, e As EventArgs) Handles btBuscarEmpresa.Click
        Dim params As New List(Of String)
        params.Add(Nothing)
        General.buscarElemento(Consultas.BUSQUEDA_EMPRESA,
                               params,
                               AddressOf cargarEmpresa,
                               TitulosForm.BUSQUEDA_EMPRESA,
                               True, 0, True)
    End Sub
    Public Sub cargarEmpresa(pCodigo As String)
        Dim drEmpresa As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)

        drEmpresa = General.cargarItem(Consultas.BUSQUEDA_EMPRESA_CARGAR, params)
        objDeduccion.id_empresa_prestadora = pCodigo
        txtNit.Text = drEmpresa.Item("NIT").ToString
        txtRazonSocial.Text = drEmpresa.Item("Razon_social").ToString
    End Sub

    Private Sub numPagos_ValueChanged(sender As Object, e As EventArgs) Handles numPagos.ValueChanged
        realizarEstudioDeCredito()
    End Sub

    Private Sub realizarEstudioDeCredito()
        If btguardar.Enabled = True And Visible = True Then
            txtRespuesta.Visible = True
            aplicarDiseñoPagos()
            objDeduccion.mesesHistorial = numPagos.Value
            objDeduccion.cargarHistorialPagos()
            Dim mensaje As String
            mensaje = "Cuota óptima: " & CDbl(objDeduccion.minimaCuota).ToString("c2") & "  -  " &
                                         CDbl(objDeduccion.maximaCuota).ToString("c2")
            If (objDeduccion.Valor / If(objDeduccion.cuotas = 0, 1, objDeduccion.cuotas)) +
                ((objDeduccion.Valor * objDeduccion.tasa_Interes) / 100) < objDeduccion.maximaCuota Then
                txtRespuesta.Text = "ACEPTADO."
                txtRespuesta.ForeColor = Color.Green
            Else
                txtRespuesta.Text = "RECHAZADO."
                txtRespuesta.ForeColor = Color.Red
            End If
            txtRespuesta.Text = txtRespuesta.Text & vbCrLf & mensaje
        End If
    End Sub

    Private Sub aplicarDiseñoPagos()
        dgvHistorialPago.Columns("Nómina Mes").Width = 90
        dgvHistorialPago.Columns("Neto Pago").Width = 120
        dgvHistorialPago.Columns("Nómina Mes").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvHistorialPago.Columns("Neto Pago").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvHistorialPago.Sort(dgvHistorialPago.Columns("Nómina Mes"), System.ComponentModel.ListSortDirection.Descending)
    End Sub

    Private Sub dgvHistorialPago_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvHistorialPago.CellFormatting
        If e.ColumnIndex = 1 Then
            e.Value = CDbl(e.Value).ToString("c2")
        End If
    End Sub
    Private Function validarMes(vMes As Date) As Boolean

        For Each dw As DataRow In objDeduccion.dtExceptuarMes.Rows
            If dw("Fecha") = vMes Then
                Dim msg = String.Format("Ya esta agregado el mes: [{0:MMMM | yyyy}]", vMes)
                MsgBox(msg, MsgBoxStyle.Exclamation)
                Return False
            End If
        Next
        For Each dw As DataRow In objDeduccion.dtAnticipoDeuda.Rows
            If dw("Fecha") = vMes And dw("Tipo_Movimiento") = 0 Then
                Dim msg = String.Format("[{0:MMMM | yyyy}] Tiene Movimientos en Anticipos.", vMes)
                MsgBox(msg, MsgBoxStyle.Exclamation)
                Return False
            End If
        Next
        If cbBase.Checked = False And cbInteres.Checked = False Then
            MsgBox("Por favor seleccione base y/o interés", MsgBoxStyle.Exclamation)
            Return False
        End If
        Dim vFechaMinima As Date
        vFechaMinima = Exec.primerDiaMes(General.fechaActualServidor)
        If vFechaMinima > vMes Then
            Dim objNomina As New Nomina
            objNomina.mes = vMes.AddMonths(1)
            If objNomina.verificaNominaAnterior = True Then
                MsgBox("Por favor seleccione una fecha mayor o igual al mes actual", MsgBoxStyle.Exclamation)
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub btquitarexceptuo_Click(sender As Object, e As EventArgs) Handles btQuitarExceptuo.Click
        If objDeduccion.dtExceptuarMes.Rows.Count = 0 Then Exit Sub
        If verificarFechaAnular(CDate(objDeduccion.dtExceptuarMes.Rows(dgvExceptuarMes.CurrentRow.Index).Item("Fecha")).Date) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                objDeduccion.dtExceptuarMes.Rows.RemoveAt(dgvExceptuarMes.CurrentRow.Index)
                calcularMovimientos()
                MsgBox(Mensajes.GUARDE_ANTES_PARA_EFECTUAR, MsgBoxStyle.Information)
            End If
        Else
            MsgBox(Mensajes.IMPOSIBLE_ANULAR_MOVIMIENTO, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub fechaExceptuarMes_ValueChanged(sender As Object, e As EventArgs) Handles fechaExceptuarMes.ValueChanged

    End Sub

    Private Sub dgvExceptuarMes_Click(sender As Object, e As EventArgs) Handles dgvExceptuarMes.Click
        btQuitarExceptuo.Enabled = (btcancelar.Enabled AndAlso dgvExceptuarMes.SelectedRows.Count > 0)
    End Sub

#End Region
End Class