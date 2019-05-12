Imports System.Threading

Public Class FormSabanaAplicacionMed
    Private CodigoTemporal, modulo As String
    Dim objSabanaAplicacion As New SabanaAplicacionMed
    Dim guardarEn2doPlano As Thread
    Private Sub cargarDescripcion()
        Cursor = Cursors.WaitCursor
        objSabanaAplicacion.cargarDetalle()
        If modulo = Constantes.CODIGO_MENU_HISTC Then
            GeneralHC.enlaceDgvSabana(dgvSignosV, objSabanaAplicacion.dtHorasabana)
            GeneralHC.enlaceDgvSabana(dgvSilverman, objSabanaAplicacion.dtHoraSabanaSilverman)
            GeneralHC.enlaceDgvSabana(dgvValoracionN, objSabanaAplicacion.dtHoraSabanaValoracion)
            GeneralHC.enlaceDgvSabana(dgvIngresos, objSabanaAplicacion.dtHoraSabanaIngreso)
            GeneralHC.enlaceDgvSabana(dgvEgresos, objSabanaAplicacion.dtHoraSabanaEgreso)
            GeneralHC.enlaceDgvBalance(dgvBalance, objSabanaAplicacion.dtHoraSabanaBalance)
            GeneralHC.enlaceDgvSabana(dgvAplicacionM, objSabanaAplicacion.dtHoraSabanaMedicamento)
            GeneralHC.enlaceDgvSabana(dgvAplicacionNPT, objSabanaAplicacion.dtHoraSabanaNPT)
            GeneralHC.enlaceDgvSabana(dgvGoteo, objSabanaAplicacion.dtHorasabanaGoteo)
        Else
            GeneralHC.enlaceDgvSabana(dgvSignosVAud, objSabanaAplicacion.dtHorasabana)
            GeneralHC.enlaceDgvSabana(dgvIngresosAud, objSabanaAplicacion.dtHoraSabanaIngreso)
            GeneralHC.enlaceDgvSabana(dgvEgresosAud, objSabanaAplicacion.dtHoraSabanaEgreso)
            GeneralHC.enlaceDgvBalance(dgvBalanceAud, objSabanaAplicacion.dtHoraSabanaBalance)
            GeneralHC.enlaceDgvSabana(dgvAplicacionMAud, objSabanaAplicacion.dtHoraSabanaMedicamento)
            GeneralHC.enlaceDgvSabana(dgvAplicacionNPTAud, objSabanaAplicacion.dtHoraSabanaNPT)
            GeneralHC.enlaceDgvSabana(dgvGoteoAud, objSabanaAplicacion.dtHorasabanaGoteo)
        End If

    End Sub

    Private Sub dgv_RowPostPaint(dgv As DataGridView, e As DataGridViewRowPostPaintEventArgs) Handles dgvSignosV.RowPostPaint, dgvSilverman.RowPostPaint,
                                                                                    dgvValoracionN.RowPostPaint, dgvIngresos.RowPostPaint,
                                                                                    dgvEgresos.RowPostPaint, dgvBalance.RowPostPaint,
                                                                                    dgvAplicacionM.RowPostPaint, dgvAplicacionNPT.RowPostPaint,
                                                                                    dgvGoteo.RowPostPaint, dgvSignosVAud.RowPostPaint, dgvIngresosAud.RowPostPaint,
                                                                                    dgvEgresosAud.RowPostPaint, dgvBalanceAud.RowPostPaint,
                                                                                    dgvAplicacionMAud.RowPostPaint, dgvAplicacionNPTAud.RowPostPaint,
                                                                                    dgvGoteoAud.RowPostPaint

        Using Pinceles As New SolidBrush(dgv.RowHeadersDefaultCellStyle.ForeColor)
            Dim nombre As String
            If dgv.DataSource.Rows(e.RowIndex).Item("Nombre").ToString.Length > 85 Then

                If dgv.Name.Contains("Goteo") Then
                    nombre = dgv.DataSource.Rows(e.RowIndex).Item("Nombre").ToString.Substring(0, 58)
                Else
                    nombre = dgv.DataSource.Rows(e.RowIndex).Item("Nombre").ToString.Substring(0, 85)
                End If
            Else
                nombre = dgv.DataSource.Rows(e.RowIndex).Item("Nombre").ToString
            End If

            e.Graphics.DrawString(nombre,
            dgv.Rows(e.RowIndex).Cells(0).InheritedStyle.Font,
            Pinceles, e.RowBounds.Location.X + 12, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Public Sub cargarDatosPaciente(ByRef pHistoriaClinica As HistoriaClinica, pTag As Object, disenoAuditoria As Boolean)
        Dim params As New List(Of String)
        Dim dr As DataRow
        Dim fechaServidor As DateTime = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        objSabanaAplicacion = pHistoriaClinica.objSabanaAplicacion
        Tag = pTag
        modulo = Tag
        General.deshabilitarControles(GroupDatos)
        txtpesoact.Enabled = True
        txtpesoact.ReadOnly = False
        Try
            cargarFormulario()
            disenoHemodinamia(disenoAuditoria)
            params.Add(objSabanaAplicacion.nRegistro)
            dr = General.cargarItem(objSabanaAplicacion.sqlDatoPacienteCarga, params)
            txtregistro.Text = objSabanaAplicacion.nRegistro
            txtidentificacion.Text = dr.Item(0).ToString
            txtpaciente.Text = dr.Item(1).ToString
            txtsexo.Text = dr.Item(2).ToString
            txtedad.Text = dr.Item(3).ToString
            txtcama.Text = dr.Item(4).ToString
            txtfechaingreso.Text = Format(CDate(dr.Item(5).ToString), Constantes.FORMATO_FECHA_HORA_GEN3)
            txtcodigocontrato.Text = dr.Item(6).ToString
            txtcontrato.Text = dr.Item(7).ToString
            txtServicio.Text = dr.Item(8).ToString
            dtFecha.Value = Format(CDate(dr.Item(9).ToString), Constantes.FORMATO_FECHA_HORA_GEN3)
            dtFechaEgreso.Text = Format(CDate(dr.Item(9).ToString), Constantes.FORMATO_FECHA_HORA_GEN3)
            dtFecha.Enabled = True
            cargarSabanaFecha()

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub disenoHemodinamia(disenoAuditoria As Boolean)
        If Not disenoAuditoria Then Exit Sub
        GroupBox4.Visible = False
        GroupBox6.Visible = False
        Dim altura As Integer
        altura = GroupBox7.Location.Y - GroupBox4.Location.Y
        GroupBox7.Location = New Point(GroupBox7.Location.X, GroupBox7.Location.Y - altura)
        GroupBox9.Location = New Point(GroupBox9.Location.X, GroupBox9.Location.Y - altura)
    End Sub

    Private Sub cargarFormulario()
        If modulo = Constantes.CODIGO_MENU_HISTC Then
            contenedorSabana.Panel1Collapsed = False
            contenedorSabana.Panel2Collapsed = True
            tsImprimirSignos.Visible = False
        Else
            contenedorSabana.Panel2Collapsed = False
            contenedorSabana.Panel1Collapsed = True
        End If
        If objSabanaAplicacion.servicioNeonatal = False Then
            unidadPAnterior.Text = "Kgramos"
            unidadPActual.Text = "Kgramos"
            unidadPGanado.Text = "Kgramos"
        End If
        Select Case modulo
            Case Constantes.HC
                Label1.Text = Label1.Text & ": HISTORIA CLÍNICA"
                contenedorSabana.Panel1Collapsed = False
                contenedorSabana.Panel2Collapsed = True
            Case Constantes.AM
                Label1.Text = Label1.Text & ": AUDITORÍA MÉDICA"
                contenedorSabana.Panel2Collapsed = False
                contenedorSabana.Panel1Collapsed = True
            Case Constantes.AF
                Label1.Text = Label1.Text & ": AUDITORÍA FACTURACIÓN"
                contenedorSabana.Panel2Collapsed = False
                contenedorSabana.Panel1Collapsed = True
            Case Else
                Label1.Text = Label1.Text & ": HISTORIA CLÍNICA"
                contenedorSabana.Panel1Collapsed = False
                contenedorSabana.Panel2Collapsed = True
        End Select
    End Sub

    Private Sub cargarSabanaFecha()
        objSabanaAplicacion.fechaReal = dtFecha.Value.Date
        objSabanaAplicacion.fechaIngreso = txtfechaingreso.Text
        objSabanaAplicacion.fechaEgreso = dtFechaEgreso.Text

        objSabanaAplicacion.cargarCodigoSabana()
        txtCodigoSabana.Text = objSabanaAplicacion.codigoSabana
        objSabanaAplicacion.cargarPesoYBalanceSabana()
        cargarDescripcion()
        calcularPesoGanado()
        cargarColoresHoraSabana()
        calcularBalanceHora()
        Cursor = Cursors.Default
    End Sub
    Private Sub calcularBalanceHora()
        objSabanaAplicacion.calcularBalanceHora()
        If modulo = Constantes.CODIGO_MENU_HISTC Then
            textIngresoTotal.Text = objSabanaAplicacion.ingresoTotal
            textEgresoTotal.Text = objSabanaAplicacion.egresoTotal
            textBalanceAnterior.Text = objSabanaAplicacion.balanceAnterior
            textGastoUrinario.Text = objSabanaAplicacion.gastoUrinario
            textBalanceAcumulado.Text = objSabanaAplicacion.balanceAcumulado
        Else
            txtIngresoTotalAud.Text = objSabanaAplicacion.ingresoTotal
            txtEgresoTotalAud.Text = objSabanaAplicacion.egresoTotal
            txtBalanceAud.Text = objSabanaAplicacion.balanceAnterior
            txtPvAud.Text = objSabanaAplicacion.gastoUrinario
            txtBalanceAcum.Text = objSabanaAplicacion.balanceAcumulado
        End If
    End Sub
    Private Sub calcularPesoGanado()
        objSabanaAplicacion.calcularPesoGanado()
        txtpeso_ant.Value = objSabanaAplicacion.pesoAnterior
        txtpesoact.Value = objSabanaAplicacion.pesoActual
        txtpesogana.Value = objSabanaAplicacion.pesoGanado
    End Sub

    Private Sub cargarColoresHoraSabana()
        If modulo = Constantes.CODIGO_MENU_HISTC Then
            GeneralHC.colorRegistroCargar(dgvSignosV, objSabanaAplicacion, ConstantesHC.ID_COLUMNA_SIGNOS_VITALES)
            GeneralHC.colorRegistroCargar(dgvSilverman, objSabanaAplicacion, ConstantesHC.ID_COLUMNA_SILVERMAN)
            GeneralHC.colorRegistroCargar(dgvValoracionN, objSabanaAplicacion, ConstantesHC.ID_COLUMNA_VALORACION_NUTRICIONAL)
            GeneralHC.colorRegistroCargar(dgvIngresos, objSabanaAplicacion, ConstantesHC.ID_COLUMNA_INGRESO)
            GeneralHC.colorFiLaDgv(dgvIngresos, dgvIngresos.RowCount - 1, Color.Red)
            GeneralHC.colorRegistroCargar(dgvEgresos, objSabanaAplicacion, ConstantesHC.ID_COLUMNA_EGRESO)
            GeneralHC.colorFiLaDgv(dgvEgresos, dgvEgresos.RowCount - 1, Color.Red)
            GeneralHC.colorFiLaDgv(dgvBalance, dgvBalance.RowCount - 2, Color.Blue)
            GeneralHC.colorFiLaDgv(dgvBalance, dgvBalance.RowCount - 1, Color.Red)
            GeneralHC.colorRegistroCargarAplicacionMed(dgvAplicacionM, objSabanaAplicacion, ConstantesHC.ID_COLUMNA_APLICACION)
            GeneralHC.colorRegistroCargarAplicacionMed(dgvAplicacionNPT, objSabanaAplicacion, ConstantesHC.ID_COLUMNA_NPT)
            GeneralHC.colorRegistroCargarAplicacionGoteo(dgvGoteo, objSabanaAplicacion, ConstantesHC.ID_COLUMNA_GOTEO)
            GeneralHC.filaDGVSoloLectura(dgvValoracionN, ConstantesHC.POSICION_FILA_GLASGOW)
        Else
            GeneralHC.colorRegistroCargar(dgvSignosVAud, objSabanaAplicacion, ConstantesHC.ID_COLUMNA_SIGNOS_VITALES_AUD)
            GeneralHC.colorRegistroCargar(dgvIngresosAud, objSabanaAplicacion, ConstantesHC.ID_COLUMNA_INGRESO_AUD)
            GeneralHC.colorFiLaDgv(dgvIngresosAud, dgvIngresosAud.RowCount - 1, Color.Red)
            GeneralHC.colorRegistroCargar(dgvEgresosAud, objSabanaAplicacion, ConstantesHC.ID_COLUMNA_EGRESO_AUD)
            GeneralHC.colorFiLaDgv(dgvEgresosAud, dgvEgresosAud.RowCount - 1, Color.Red)
            GeneralHC.colorFiLaDgv(dgvBalanceAud, dgvBalanceAud.RowCount - 2, Color.Blue)
            GeneralHC.colorFiLaDgv(dgvBalanceAud, dgvBalanceAud.RowCount - 1, Color.Red)
            GeneralHC.colorRegistroCargarAplicacionMed(dgvAplicacionMAud, objSabanaAplicacion, ConstantesHC.ID_COLUMNA_APLICACION_AUD)
            GeneralHC.colorRegistroCargarAplicacionMed(dgvAplicacionNPTAud, objSabanaAplicacion, ConstantesHC.ID_COLUMNA_NPT_AUD)
            GeneralHC.colorRegistroCargarAplicacionGoteo(dgvGoteoAud, objSabanaAplicacion, ConstantesHC.ID_COLUMNA_GOTEO_AUD)
        End If
    End Sub


    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Cursor = Cursors.WaitCursor
        If validarDGV() = True AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Try
                objSabanaAplicacion.estadoGuardando = True
                tsImprimir.Enabled = False
                tsImprimirSignos.Enabled = False
                Timer1.Start()
                calcularBalanceHora()
                terminarEdicion()
                objSabanaAplicacion.guardarDetalle()
                txtCodigoSabana.Text = objSabanaAplicacion.codigoSabana
                cargarColoresHoraSabana()

                'guardarInforme()
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            Catch ex As Exception
                objSabanaAplicacion.codigoSabana = txtCodigoSabana.Text
                General.manejoErrores(ex)
            End Try
        End If
        tsImprimir.Enabled = True
        tsImprimirSignos.Enabled = True
        Cursor = Cursors.Default
    End Sub
    Private Sub guardarInforme()
        Try
            guardarEn2doPlano = New Thread(AddressOf objSabanaAplicacion.guardarReporte2doPlano)
            guardarEn2doPlano.Name = "Guardar Sabana"
            guardarEn2doPlano.SetApartmentState(ApartmentState.STA)
            guardarEn2doPlano.Start()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub terminarEdicion()
        dgvSignosV.EndEdit()
        dgvSilverman.EndEdit()
        dgvValoracionN.EndEdit()
        dgvIngresos.EndEdit()
        dgvEgresos.EndEdit()
        dgvBalance.EndEdit()
        dgvGoteo.EndEdit()

        dgvSignosVAud.EndEdit()
        dgvIngresosAud.EndEdit()
        dgvEgresosAud.EndEdit()
        dgvBalanceAud.EndEdit()
        dgvGoteoAud.EndEdit()
        objSabanaAplicacion.codigoEP = SesionActual.codigoEP
        objSabanaAplicacion.pesoActual = txtpesoact.Value
        If modulo = Constantes.CODIGO_MENU_HISTC Then
            objSabanaAplicacion.ingresoTotal = textIngresoTotal.Text
            objSabanaAplicacion.egresoTotal = textEgresoTotal.Text
            objSabanaAplicacion.balanceAnterior = textBalanceAnterior.Text
            objSabanaAplicacion.gastoUrinario = textGastoUrinario.Text
            objSabanaAplicacion.balanceAnterior = textBalanceAcumulado.Text
        Else
            objSabanaAplicacion.ingresoTotal = txtIngresoTotalAud.Text
            objSabanaAplicacion.egresoTotal = txtEgresoTotalAud.Text
            objSabanaAplicacion.balanceAnterior = txtBalanceAud.Text
            objSabanaAplicacion.gastoUrinario = txtPvAud.Text
            objSabanaAplicacion.balanceAnterior = txtBalanceAcum.Text
        End If
    End Sub

    Private Function validarDGV() As Boolean

        If (objSabanaAplicacion.servicioNeonatal AndAlso txtpesoact.Value <= Constantes.PESO_GRAMO_MINIMO) OrElse
            (Not objSabanaAplicacion.servicioNeonatal AndAlso txtpesoact.Value <= Constantes.PESO_KILOGRAMO_MINIMO) Then
            MsgBox(Mensajes.DIGITE_PESO_PACIENTE, MsgBoxStyle.Exclamation)
            txtpesoact.Focus()
            txtpesoact.Select(0, txtpesoact.Text.Length)
            Return False
        ElseIf dgvIngresos.RowCount = 0 AndAlso dgvIngresosAud.RowCount = 0 Then
            If GeneralHC.verificarFechaMaxMinSeleccionSabana(dtFecha, objSabanaAplicacion) Then
                cargarSabanaFecha()
            End If
            Return False
        End If
        Return True
    End Function
    Private Sub grillasignos_vitales_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSignosV.CellEndEdit, dgvSignosVAud.CellEndEdit
        Try
            If sender.CurrentCell.RowIndex = ConstantesHC.POSICION_FILA_TEMPERATURA Then
                If IsNumeric(sender.Rows(ConstantesHC.POSICION_FILA_TEMPERATURA).Cells(sender.CurrentCell.ColumnIndex).Value.ToString) = False OrElse sender.Rows(ConstantesHC.POSICION_FILA_TEMPERATURA).Cells(sender.CurrentCell.ColumnIndex).Value.ToString.Trim < ConstantesHC.TEMPERATURA_MINIMA_VALIDA OrElse
                    sender.Rows(ConstantesHC.POSICION_FILA_TEMPERATURA).Cells(sender.CurrentCell.ColumnIndex).Value.ToString.Trim > ConstantesHC.TEMPERATURA_MAXIMA_VALIDA Then
                    MsgBox(Mensajes.TEMPERATURA_NO_VALIDA & "valores entre: " & CStr(ConstantesHC.TEMPERATURA_MINIMA_VALIDA) & " - " & ConstantesHC.TEMPERATURA_MAXIMA_VALIDA, MsgBoxStyle.Exclamation)
                    sender.Rows(ConstantesHC.POSICION_FILA_TEMPERATURA).Cells(sender.CurrentCell.ColumnIndex).Value = ConstantesHC.TEMPERATURA_MINIMA_VALIDA
                End If
            End If
            Dim dgvRws As DataGridViewRowCollection = sender.Rows
            Dim sistolico, diastolico As Integer
            If String.IsNullOrEmpty(dgvRws(ConstantesHC.POSICION_SISTOLICA).Cells(e.ColumnIndex).Value.ToString.Trim) = True OrElse Not IsNumeric(dgvRws(ConstantesHC.POSICION_SISTOLICA).Cells(e.ColumnIndex).Value.ToString.Trim) Then
                sistolico = 0
                dgvRws(ConstantesHC.POSICION_SISTOLICA).Cells(e.ColumnIndex).Value = 0
            Else
                sistolico = dgvRws(ConstantesHC.POSICION_SISTOLICA).Cells(e.ColumnIndex).Value.ToString
            End If
            If String.IsNullOrEmpty(dgvRws(ConstantesHC.POSICION_DIASTOLICA).Cells(e.ColumnIndex).Value.ToString.Trim) = True OrElse Not IsNumeric(dgvRws(ConstantesHC.POSICION_DIASTOLICA).Cells(e.ColumnIndex).Value.ToString.Trim) Then
                diastolico = 0
                dgvRws(ConstantesHC.POSICION_DIASTOLICA).Cells(e.ColumnIndex).Value = 0
            Else
                diastolico = dgvRws(ConstantesHC.POSICION_DIASTOLICA).Cells(e.ColumnIndex).Value.ToString
            End If
            dgvRws(ConstantesHC.POSICION_PRESION_MEDIA).Cells(e.ColumnIndex).Value = Format(((2 * diastolico) + sistolico) / 3, "0") ''FORMULA PARA HALLAR LA PRESION MEDIA
        Catch ex As Exception
            MsgBox(Mensajes.CANTIDAD_VALIDA, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub dtFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtFecha.ValueChanged

        If (IsNothing(dgvIngresos.DataSource) = False OrElse IsNothing(dgvIngresosAud.DataSource) = False) AndAlso GeneralHC.verificarFechaMaxMinSeleccionSabana(dtFecha, objSabanaAplicacion) Then
            cargarSabanaFecha()
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        dtFecha.Value = dtFecha.Value.AddDays(-1)
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        dtFecha.Value = dtFecha.Value.AddDays(1)
    End Sub
    Private Sub ingreso(sender As Object, e As EventArgs) Handles irIngreso.Click, irIngreso2.Click
        dtFecha.Value = CDate(txtfechaingreso.Text).Date
    End Sub
    Private Sub egreso(sender As Object, e As EventArgs) Handles irEgreso.Click, irEgreso2.Click
        dtFecha.Value = CDate(dtFechaEgreso.Text).Date
    End Sub
    Private Sub tsRecargar_Click(sender As Object, e As EventArgs) Handles tsRecargar.Click
        If GeneralHC.verificarFechaMaxMinSeleccionSabana(dtFecha, objSabanaAplicacion) AndAlso MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.Yes Then
            cargarSabanaFecha()
        End If
    End Sub

    Private Sub txtpesoact_ValueChanged(sender As Object, e As EventArgs) Handles txtpesoact.ValueChanged
        objSabanaAplicacion.pesoActual = txtpesoact.Value
        calcularPesoGanado()
        calcularBalanceHora()
    End Sub
    Private Sub dgv_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvSignosV.EditingControlShowing,
            dgvIngresos.EditingControlShowing, dgvEgresos.EditingControlShowing,
            dgvEgresos.EditingControlShowing, dgvGoteo.EditingControlShowing,
            dgvIngresosAud.EditingControlShowing, dgvEgresosAud.EditingControlShowing,
            dgvEgresos.EditingControlShowing, dgvSignosVAud.EditingControlShowing, dgvGoteoAud.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos

    End Sub

    Private Sub dgv_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvIngresos.CellValueChanged, dgvEgresos.CellValueChanged,
                                                                                               dgvIngresosAud.CellValueChanged, dgvEgresosAud.CellValueChanged,
                                                                                               dgvGoteo.CellValueChanged, dgvGoteoAud.CellValueChanged
        If Not IsNothing(dgvSignosV.DataSource) OrElse Not IsNothing(dgvSignosVAud.DataSource) Then
            calcularBalanceHora()
        End If
    End Sub

    Private Sub sabana_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If tsImprimir.Enabled = True Then
            If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
                Me.Dispose()
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
            MsgBox(Mensajes.CAMBIOS_2DO_SIN_GUARDAR, MsgBoxStyle.Critical)
        End If
    End Sub
    Private Sub dgv_CellDoubleClick(dgv As DataGridView, e As DataGridViewCellEventArgs) Handles dgvSignosV.CellDoubleClick, dgvSilverman.CellDoubleClick,
                                                                                                dgvValoracionN.CellDoubleClick, dgvIngresos.CellDoubleClick,
                                                                                                dgvEgresos.CellDoubleClick, dgvSignosVAud.CellDoubleClick,
                                                                                                dgvIngresosAud.CellDoubleClick, dgvEgresosAud.CellDoubleClick
        If dgv.RowCount > 0 AndAlso e.ColumnIndex >= 0 Then
            If dgvValoracionN.Focused = True AndAlso e.RowIndex = ConstantesHC.POSICION_FILA_GLASGOW AndAlso dgvValoracionN.Rows(e.RowIndex - 2).Cells(e.ColumnIndex).ReadOnly = False Then
                Dim pGlasgow As New Glasgow
                Dim fFormGlasgow As New FormGlasgow
                fFormGlasgow.iniciarForm(pGlasgow)
                fFormGlasgow.ShowDialog()
                dgvValoracionN.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = pGlasgow.sumaTotal
            ElseIf dgvValoracionN.Focused = True AndAlso e.RowIndex = ConstantesHC.POSICION_FILA_ASCE AndAlso dgvValoracionN.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).ReadOnly = False Then
                Dim pASCE As New ValoracionASCE
                Dim fFormASCE As New FormValoracionASCE
                fFormASCE.iniciarForm(pASCE)
                fFormASCE.ShowDialog()
                dgvValoracionN.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = pASCE.seleccion
            Else
                GeneralHC.RegistroEditar(dgv, objSabanaAplicacion)
            End If
            If modulo = Constantes.CODIGO_MENU_HISTC Then
                dgvValoracionN.Rows(ConstantesHC.POSICION_FILA_GLASGOW).Cells(e.ColumnIndex).ReadOnly = True
                dgvIngresos.Rows(dgvIngresos.Rows.Count - 1).Cells(e.ColumnIndex).ReadOnly = True
                dgvEgresos.Rows(dgvEgresos.Rows.Count - 1).Cells(e.ColumnIndex).ReadOnly = True
            Else
                dgvIngresosAud.Rows(dgvIngresosAud.Rows.Count - 1).Cells(e.ColumnIndex).ReadOnly = True
                dgvEgresosAud.Rows(dgvEgresosAud.Rows.Count - 1).Cells(e.ColumnIndex).ReadOnly = True
            End If
        End If
    End Sub

    Private Sub dgvAplicacion_KeyDown(dgv As DataGridView, e As KeyEventArgs) Handles dgvAplicacionM.KeyDown,
                                                                                      dgvAplicacionNPT.KeyDown,
                                                                                      dgvAplicacionMAud.KeyDown,
                                                                                      dgvAplicacionNPTAud.KeyDown
        If e.KeyCode = Keys.Delete Then
            GeneralHC.RegistroDesaplicar(dgv, objSabanaAplicacion)
        End If
    End Sub

    Private Sub tsImprimirHoja_Click(sender As Object, e As EventArgs) Handles tsImprimirHoja.Click, tsImprimirTodas.Click
        Try
            If (String.IsNullOrEmpty(txtCodigoSabana.Text) And Not tsImprimirTodas.Pressed) Then Exit Sub
            Cursor = Cursors.WaitCursor
            Dim mostrarSigno As Integer
            If modulo = Constantes.HC Then
                mostrarSigno = ConstantesHC.SABANA_CON_TODO
            Else
                mostrarSigno = ConstantesHC.SABANA_SIN_SIGNOS
            End If
            objSabanaAplicacion.imprimirHoja(tsImprimirTodas.Pressed, mostrarSigno)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvGoteo_CellEndEdit(dgv As DataGridView, e As DataGridViewCellEventArgs) Handles dgvGoteo.CellEndEdit, dgvGoteoAud.CellEndEdit, dgvEgresos.CellEndEdit, dgvEgresosAud.CellEndEdit
        If Not IsNumeric(dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
            dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
        Else
            dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = CDbl(dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
        End If
        If dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value >= 10000 Then
            MsgBox("¡Por favor digite una cantidad válida!", MsgBoxStyle.Exclamation)
            dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
        End If
    End Sub

    Private Sub dgvGoteoAud_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvGoteo.CellFormatting, dgvIngresos.CellFormatting, dgvEgresos.CellFormatting,
                                                                                                               dgvGoteoAud.CellFormatting, dgvIngresosAud.CellFormatting, dgvEgresosAud.CellFormatting
        If Not String.IsNullOrEmpty(e.Value.ToString) AndAlso e.Value = ConstantesHC.IDENTIFICADOR_SABANA_GOTEO_SUSPENDIDO Then
            e.Value = Format(ConstantesHC.IDENTIFICADOR_SABANA_SUSPENDIDO, "")
        ElseIf Not String.IsNullOrEmpty(e.Value.ToString) AndAlso e.Value = ConstantesHC.IDENTIFICADOR_SABANA_GOTEO_MODIFICADO Then
            e.Value = Format(ConstantesHC.IDENTIFICADOR_SABANA_MODIFICADO, "")
        ElseIf Not String.IsNullOrEmpty(e.Value.ToString) AndAlso e.Value = ConstantesHC.IDENTIFICADOR_SABANA_GOTEO_NO_APLICADO Then
            e.Value = Format("", "")
        ElseIf IsNumeric(e.Value) Then
            If CInt(e.Value) <> e.Value Then
                e.Value = CDbl(e.Value).ToString("N1")
            End If
        End If
    End Sub

    Private Sub PictureBox_MouseHover(sender As Object, e As EventArgs) Handles PictureBox3.MouseHover, PictureBox2.MouseHover, irEgreso.MouseHover, irEgreso2.MouseHover, irIngreso.MouseHover, irIngreso2.MouseHover
        Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox3.MouseLeave, PictureBox2.MouseLeave, irEgreso.MouseLeave, irEgreso2.MouseLeave, irIngreso.MouseLeave, irIngreso2.MouseLeave
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvSignosV_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvSignosV.DataError, dgvSilverman.DataError,
                                                                                                dgvValoracionN.DataError, dgvIngresos.DataError,
                                                                                                dgvEgresos.DataError, dgvSignosVAud.DataError,
                                                                                                dgvIngresosAud.DataError, dgvEgresosAud.DataError
        MsgBox(Mensajes.CANTIDAD_VALIDA, MsgBoxStyle.Critical)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click, ToolStripMenuItem2.Click
        Try
            If String.IsNullOrEmpty(txtCodigoSabana.Text) Then Exit Sub
            Cursor = Cursors.WaitCursor
            objSabanaAplicacion.imprimirHoja(ToolStripMenuItem2.Pressed, 2)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub FormSabanaAplicacionMed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not objSabanaAplicacion.estadoGuardando Then
            tsImprimir.Enabled = True
            tsImprimirSignos.Enabled = True
            Timer1.Stop()
        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click, ToolStripMenuItem4.Click
        Try
            If String.IsNullOrEmpty(txtCodigoSabana.Text) Then Exit Sub
            Cursor = Cursors.WaitCursor
            objSabanaAplicacion.imprimirHoja(ToolStripMenuItem4.Pressed, 3)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvAplicacion_CellDoubleClick(dgv As DataGridView, e As DataGridViewCellEventArgs) Handles dgvAplicacionM.CellDoubleClick,
                                                                                                           dgvAplicacionNPT.CellDoubleClick,
                                                                                                           dgvAplicacionMAud.CellDoubleClick,
                                                                                                           dgvAplicacionNPTAud.CellDoubleClick
        If dgv.RowCount > 0 AndAlso e.ColumnIndex >= 0 Then
            GeneralHC.RegistroAplicar(dgv, objSabanaAplicacion)
        End If

    End Sub

End Class