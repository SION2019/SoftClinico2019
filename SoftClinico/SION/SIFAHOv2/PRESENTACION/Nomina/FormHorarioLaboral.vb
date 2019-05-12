Public Class FormHorarioLaboral
    Dim objHorarios_D As New HorarioLaboralBLL
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, PAsignar, PEditarTurnosPasados, PEditarTurnosPropios As String
    Dim objHorario As New HorarioLaboral
    Dim fechaActual As Date

    Private Sub FormHorarioLaboral_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        fechaActual = General.fechaActualServidor
        iniciar_permisos()
        cargarCombosIniciales()
        General.deshabilitarControles(Me)
        objHorario.fecha = Exec.primerDiaMes(dateFechaHorario.Value)
        objHorario.soloCarga = True
        objHorario.cargarHorario()
        objHorario.cargarConvenciones()
        iniciar_dgvHorario()
        objHorario.fechaInicio = Exec.primerDiaMes(dateFechaHorario.Value)
        objHorario.fechaFin = Exec.ultimoDiaMes(dateFechaHorario.Value)
        objHorario.cargarFestivosMes()
        SiglaDias()
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        llenar_menuconvenciones()
        objHorario.dtFestivos.Clear()
        objHorario.dtHorario.Clear()
        objHorario.dtPuntoDias.Clear()
        objHorario.dtpegarpunto.Clear()
        objHorario.dtcopia.Clear()
        validarArchivoCopia()
    End Sub
    Private Sub iniciar_permisos()
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        PEditarTurnosPasados = permiso_general & "pp" & "05"
        PEditarTurnosPropios = permiso_general & "pp" & "06"
    End Sub

    Private Sub SiglaDias()
        Dim datemp As New Date
        Dim Nombre As String = ""
        Dim ultDiaMes = DateTime.DaysInMonth(dateFechaHorario.Value.Year, dateFechaHorario.Value.Month)
        For i = 4 To 34
            dgvHorario.Columns(i).HeaderCell.Style.ForeColor = Color.Black
            Dim Dia As Integer = Replace(dgvHorario.Columns(i).Name, "Dia", "")
            If Dia > ultDiaMes Then
                dgvHorario.Columns(i).Visible = False
            Else
                dgvHorario.Columns(i).Visible = True
                datemp = CDate(Dia.ToString("00") & dateFechaHorario.Value.ToString("/MM/yyyy")).Date
                Nombre = UCase(Strings.Left(Format(datemp, "dddd"), 2))
                If Nombre = "SÁ" Then
                    Nombre = "SA"
                Else
                    If Nombre = "DO" Then
                        dgvHorario.EnableHeadersVisualStyles = False
                        dgvHorario.Columns(i).HeaderCell.Style.ForeColor = Color.Red
                    Else
                        Dim busqueda = objHorario.dtFestivos.Select("DiaF='" & Dia & "'", "")
                        If busqueda.Count > 0 Then
                            dgvHorario.Columns(i).HeaderCell.Style.ForeColor = Color.Red
                        End If
                    End If
                End If
            End If
            dgvHorario.Columns(i).HeaderText = Nombre + vbCrLf + Strings.Right(" " & Dia, 2)
        Next
    End Sub
    Private Sub cargarCombosIniciales()
        General.cargarCombo(ConsultasNom.HORARIO_PUNTOS_LISTAR, "Nombre", "Codigo", comboPuntoServicio)
        General.cargarCombo(ConsultasNom.HORARIO_PUNTOS_LISTAR, "Nombre", "Codigo", comboPuntoServicioD)
        Dim params As New List(Of String)
        params.Add(Constantes.VALOR_PREDETERMINADO)
        General.cargarCombo(ConsultasNom.LISTA_NOMINA_AREA, params, "Nombre", "Codigo", comboAreaServicio)
        General.cargarCombo(ConsultasNom.HORARIO_PUNTOS_LISTAR, "Nombre", "Codigo", cbPuntoServicio)
    End Sub

    Sub iniciar_dgvHorario()
        dgvHorario.DataSource = objHorario.bsHorario.DataSource
        lbEmpleados.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9, FontStyle.Bold)
        dgvHorario.AlternatingRowsDefaultCellStyle.BackColor = Color.White
        dgvHorario.GridColor = Color.FromArgb(224, 224, 224)
        dgvHorario.DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255)
        dgvHorario.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical
        For Each Col As DataGridViewColumn In dgvHorario.Columns
            If Col.Index <> 0 AndAlso Col.Index <> 1 Then
                Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
            If Col.Index >= 4 And Col.Index <= 34 Then
                dgvHorario.Columns(Col.Index).Width = 30
            End If
            Col.SortMode = DataGridViewColumnSortMode.NotSortable
            Col.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7, FontStyle.Regular)
        Next
        dgvHorario.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvHorario.Columns(0).Width = 170
        dgvHorario.Columns(1).Width = 100
        dgvHorario.Columns(35).Width = 38
        dgvHorario.Columns(1).Frozen = True
        dgvHorario.Columns(2).Visible = False
        dgvHorario.Columns(3).Visible = False
        dgvHorario.Columns(38).Visible = False
        dgvHorario.Columns(39).Visible = False
        dgvHorario.Columns(40).Visible = False
        dgvHorario.Columns(41).Visible = False
        dgvHorario.Columns(42).Visible = False
        dgvHorario.Columns(43).Visible = False
        dgvHorario.Columns(35).Visible = False
        dgvHorario.Columns(36).Visible = False
    End Sub

    Private Sub cargarCantidadEmpleados()
        Dim NumEmp = dgvHorario.RowCount
        If (NumEmp > 0) Then : lbEmpleados.Text = String.Format(" Empleados:  {0} ", NumEmp) : ToolStripSeparator10.Visible = True
        Else : lbEmpleados.Text = "" : ToolStripSeparator10.Visible = False
        End If
    End Sub
    Private Sub identificarNovedades()
        Dim dtView As New DataView
        dtView = objHorario.bsHorario.DataSource.DefaultView()
        '===============================================
        Dim conv As String
        'Dim dtCopia As New DataTable
        'dtCopia = objHorario.dtNovedades.Copy
        'Dim dtCopiaD As New DataTable
        'dtCopiaD = objHorario.dtNovedadesDetalle.Copy

        Dim idEmpleado As Integer
        Dim filaempleado As Integer
        Dim dw_novedad As DataRow()
        Dim filaEmpleadoRow As DataRow
        Dim Dia As String
        If dtView.Count >= 0 And Not String.IsNullOrEmpty(txtcodigo.Text) Then
            For fila = 0 To dtView.Count - 1
                idEmpleado = dtView.Item(fila).Item("Id_Empleado").ToString
                For columnaactual = 4 To 34
                    If String.IsNullOrEmpty(dtView.Item(fila).Item(columnaactual).ToString) Then
                        Try
                            dw_novedad = objHorario.dtNovedades.Select("Id_Empleado='" & idEmpleado & "'", "")
                            If dw_novedad.Count = 0 Then Exit Sub
                            filaEmpleadoRow = dw_novedad(0)
                            filaempleado = objHorario.dtNovedades.Rows.IndexOf(filaEmpleadoRow)
                            conv = objHorario.dtNovedades.Rows(filaempleado).Item(columnaactual).ToString

                            If Not String.IsNullOrEmpty(conv) AndAlso conv <> Constantes.VALOR_PREDETERMINADO Then
                                Dia = Strings.Right(dtView.Table.Columns(columnaactual).ColumnName, 2)
                                If objHorario.dtNovedadesDetalle.Select("Id_Empleado='" & idEmpleado & "' and Dia='" & Dia & "'", "").Count <> 0 Then
                                    Dim cell As New DataGridViewButtonCell
                                    Dim celdaActual As DataGridViewCellCollection = dgvHorario.Rows(fila).Cells
                                    'Dim filaActual As DataGridViewRow = dgvHorario.Rows(fila)
                                    celdaActual(columnaactual) = cell
                                    celdaActual(columnaactual).Tag = ConstantesNom.NOVEDAD_HORARIO_INDETERMINADO
                                    celdaActual(columnaactual).Value = ""
                                End If
                            End If
                        Catch ex As Exception
                            General.manejoErrores(ex)
                        End Try
                    End If
                Next
            Next
        End If
    End Sub
    Private Sub dgvHorario_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvHorario.CellPainting
        If Funciones.filaValida(e.RowIndex) Then
            If dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag <> "" AndAlso Strings.Right(dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag, 1) <> "1" Then
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                Dim imagen As Image = My.Resources.eye_icon
                e.Graphics.DrawImage(imagen, e.CellBounds.Left + 7, e.CellBounds.Top + 4)
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub dgvHorario_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHorario.CellContentClick
        Dim dia As String
        If e.RowIndex >= 0 AndAlso TypeOf dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex) Is DataGridViewButtonCell Then
            dia = Strings.Right(dgvHorario.Columns(e.ColumnIndex).Name, 2)
            correcionLaboradoSinTurno(dgvHorario.Rows(e.RowIndex).Cells("Id_Empleado").Value, e.RowIndex, e.ColumnIndex, dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag, dia)
            If TypeOf (dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex)) Is DataGridViewTextBoxCell Then
                dgvHorario_CellDoubleClick(sender, e)
            End If
        End If
    End Sub
    Private Sub correcionLaboradoSinTurno(ByVal idEmpleado As String, filaActual As Int32, columnaActual As Int32, convAnt As String, Dia As String)
        Dim FormDeterminar As New Form_Determinar()
        Dim dw_novedad As DataRow() = objHorario.dtNovedadesDetalle.Select("Id_Empleado='" & idEmpleado & "' and Dia='" & Dia & "'", "")
        Dim totalHoras As String
        Dim params As New List(Of String)
        params.Add(idEmpleado)
        params.Add(Format(CDate(dateFechaHorario.Value.Year & "-" & dateFechaHorario.Value.Month & "-" & Dia).Date, Constantes.FORMATO_FECHA_GEN))
        totalHoras = General.getValorConsulta(ConsultasNom.HORARIO_HORA_TRABAJADA, params)
        If dw_novedad.Count = 0 Then Exit Sub
        Dim fila As DataRow = dw_novedad(0)
        Dim indiceFila As Integer = objHorario.dtNovedadesDetalle.Rows.IndexOf(fila)
        FormDeterminar.comboconvencion.DataSource = objHorario.dtConvenciones
        FormDeterminar.datetimeEntrada.Value = objHorario.dtNovedadesDetalle.Rows(indiceFila).Item("Entrada_Turno")
        FormDeterminar.txtCantHora.Text = totalHoras
        FormDeterminar.txtPuntoServicio.Text = objHorario.dtNovedadesDetalle.Rows(indiceFila).Item("Punto")
        FormDeterminar.txtCantHora.TextAlign = HorizontalAlignment.Center
        FormDeterminar.txtPuntoServicio.TextAlign = HorizontalAlignment.Center
        FormDeterminar.btaceptar.Visible = btguardar.Enabled
        FormDeterminar.bteliminar.Visible = False
        FormDeterminar.comboconvencion.Visible = btguardar.Enabled
        If IsDBNull(objHorario.dtNovedadesDetalle.Rows(indiceFila).Item("Entrada_Descanso")) Then
            FormDeterminar.datetimeEntradaD.Format = 8
            FormDeterminar.datetimeEntradaD.CustomFormat = " "
        Else
            FormDeterminar.datetimeEntradaD.Value = objHorario.dtNovedadesDetalle.Rows(indiceFila).Item("Entrada_Descanso")
        End If
        If IsDBNull(objHorario.dtNovedadesDetalle.Rows(indiceFila).Item("Salida_Descanso")) Then
            FormDeterminar.datetimeSalidaD.Format = 8
            FormDeterminar.datetimeSalidaD.CustomFormat = " "
        Else
            FormDeterminar.datetimeSalidaD.Value = objHorario.dtNovedadesDetalle.Rows(indiceFila).Item("Salida_Descanso")
        End If
        If IsDBNull(objHorario.dtNovedadesDetalle.Rows(indiceFila).Item("Salida_Turno")) Then
            FormDeterminar.datetimeSalida.Format = 8
            FormDeterminar.datetimeSalida.CustomFormat = " "
        Else
            FormDeterminar.datetimeSalida.Value = objHorario.dtNovedadesDetalle.Rows(indiceFila).Item("Salida_Turno")
        End If
        Select Case FormDeterminar.ShowDialog()'actualiza y guarda la convencion
            Case Windows.Forms.DialogResult.OK
                Dim convencionNueva As String = FormDeterminar.comboconvencion.SelectedValue
                Dim cell As New DataGridViewTextBoxCell
                dgvHorario.Rows(filaActual).Cells(columnaActual) = cell
                dgvHorario.Rows(filaActual).Cells(columnaActual).Value = convencionNueva
                dgvHorario.Rows(filaActual).Cells(columnaActual).Style.BackColor = Color.Yellow
                colorTodasLasConvenciones()
                cbPuntoServicio.SelectedValue = objHorario.dtNovedadesDetalle.Rows(indiceFila).Item("Codigo_EP")
                asignarPuntoServicio()
            Case Windows.Forms.DialogResult.Retry 'elimina la convencion
            Case Else
        End Select
    End Sub
    Sub colorTodasLasConvenciones()
        For Each Row As DataGridViewRow In dgvHorario.Rows
            For Each Cell In Row.Cells
                Dim indexCol = Cell.ColumnIndex
                Dim Col = dgvHorario.Columns(indexCol)
                Dim vSimbolo = Cell.Value.ToString.Trim.ToUpper
                If Col.Visible AndAlso Col.Name.contains("Dia") AndAlso vSimbolo <> "" Then
                    Dim vConvencionColorMM = buscConvencion(vSimbolo)
                    Cell.Style.ForeColor = vConvencionColorMM.Color
                End If
            Next
        Next
    End Sub
    Function buscConvencion(pSimbolo As String) As Horario.ConvencionColorMM

        Dim rConvencionColorMM As New Horario.ConvencionColorMM
        'Dim dtCopia As New DataTable
        'dtCopia = objHorario.dtConvenciones.Copy
        Dim fila As DataRow
        If objHorario.dtConvenciones.Select("Simbolo='" & pSimbolo & "'").Count > 0 Then
            fila = objHorario.dtConvenciones.Select("Simbolo='" & pSimbolo & "'")(0)
        End If
        If (Not IsNothing(fila)) AndAlso fila.ItemArray.Count > 0 Then
            rConvencionColorMM.Minutos = fila.Item("Minutos")
            rConvencionColorMM.Color = Color.FromArgb(fila.Item("Simbolo_Color"))
            rConvencionColorMM.Anulado = fila.Item("Anulado")
            rConvencionColorMM.fechaActualizacion = CDate(IIf(String.IsNullOrEmpty(fila.Item("Fecha_Actualizacion").ToString),
                                                              fechaActual,
                                                              fila.Item("Fecha_Actualizacion").ToString)).Date
            Return rConvencionColorMM
        End If
        rConvencionColorMM.Minutos = -1 : rConvencionColorMM.Color = Color.Empty
        Return rConvencionColorMM
    End Function

    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form_Horarios_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            Dim vFecha = Exec.primerDiaMes(dateFechaHorario.Value)

            If cbPuntoServicio.Focused Then
                dgvHorario.Focus()
            End If
            dgvHorario.EndEdit()
            objHorario.dtHorario.AcceptChanges()
            objHorario.dtPuntoDias.AcceptChanges()
            objHorario.codigo = txtcodigo.Text
            objHorario.fecha = vFecha
            objHorario.descripcion = "Cuadro De Turnos Para El Mes De " & StrConv(dateFechaHorario.Value.ToString("MMMM"), 3)
            txtBuscar.Clear()
            filtrar()
            terminarEdicionCalculos()
            If objHorarios_D.validarMesHorario(objHorario) Then
                MsgBox(Mensajes.HORARIO_EXISTENTE, MsgBoxStyle.Exclamation)
            Else
                Dim mensaje As String = ""
                mensaje = verificarHorario()
                If Not String.IsNullOrEmpty(mensaje) Then
                    MsgBox(mensaje, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    guardarHorario()
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub terminarEdicionCalculos()
        For Each Row In dgvHorario.Rows
            calcTiempoTotal(Row, -1)
        Next
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            filtrar()
        End If
    End Sub
    Private Sub filtrar()
        If comboCargo.DisplayMember = Nothing Then Exit Sub
        Dim puntoServicio, AreaServicio, cargoLaboral As String
        If comboPuntoServicioD.SelectedIndex > 0 Then
            puntoServicio = comboPuntoServicioD.Text
        End If
        If comboAreaServicio.SelectedIndex > 0 Then
            AreaServicio = comboAreaServicio.Text
        End If
        If comboCargo.SelectedIndex > 0 Then
            cargoLaboral = comboCargo.Text
        End If
        objHorario.bsHorario.Filter = ""
        Dim soloGuardados As String
        If btguardar.Enabled = False And Not String.IsNullOrEmpty(txtcodigo.Text) Then
            soloGuardados = "And Guardado='True' "
        End If
        objHorario.bsHorario.Filter = "Nombre like '%" & txtBuscar.Text & "%' " &
                                      "And Convert(Cargo,'System.String') Like '%" & cargoLaboral & "%' " &
                                      "And (Convert(Areas,'System.String') Like '%" & AreaServicio & "%' or Areas is null) " &
                                      "And (Convert(Puntos,'System.String') Like '%" & puntoServicio & "%' or Puntos is null) " & soloGuardados

        '" AND AreaServicio like '%" & AreaServicio & "%'
        identificarNovedades()
        colorTodasLasConvenciones()
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        limpiarForm()
    End Sub
    Private Sub limpiarForm()
        objHorario.cargando = True
        objHorario.bsHorario.DataSource.Clear()
        objHorario.dtPuntoDias.Clear()
        objHorario.dtHorario.Clear()
        objHorario.dtpegarpunto.Clear()
        objHorario.dtcopia.Clear()
        General.limpiarControles(Me)
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btguardar.Enabled = False
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        objHorario.cargando = False
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Try
            If SesionActual.tienePermiso(Panular) Then
                Dim FechaActual As String = DateTime.Now.ToString("dd/MM/yyyy")
                If CDate(FechaActual).Date > CDate(Me.dateFechaHorario.Value).Date Then
                    MsgBox(Mensajes.PROHIBIDO_ANULAR_HORARIO, MsgBoxStyle.Information)
                Else
                    If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                        If General.anularRegistro(Consultas.HORARIO_LABORAL_ANULAR & txtcodigo.Text & ", " & SesionActual.idUsuario) = True Then
                            limpiarForm()
                            MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                        End If
                    End If
                End If
            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then

            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            txtcodigo.Clear()
            objHorario.dtFestivos.Clear()
            objHorario.dtPuntoDias.Clear()
            objHorario.dtHorario.Clear()
            objHorario.dtpegarpunto.Clear()
            objHorario.dtcopia.Clear()
            cargarHorarioLaboral(txtcodigo.Text)
            General.deshabilitarBotones(ToolStrip1)
            btguardar.Enabled = True
            btcancelar.Enabled = True
            cbPuntoServicio.SelectedIndex = 0
            cbPuntoServicio.Enabled = False
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)(New String() {SesionActual.codigoEP,
                                                            SesionActual.idEmpresa,
                                                            String.Empty})
            General.buscarElemento(Consultas.HORARIO_LABORAL_BUSCAR,
                                   params,
                                   AddressOf cargarHorarioLaboral,
                                   TitulosForm.BUSQUEDA_HORARIO,
                                   False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub cbPuntoServicio_Leave(sender As Object, e As EventArgs) Handles cbPuntoServicio.Leave
        Try
            If cbPuntoServicio.SelectedIndex < 1 Then
                If cbPuntoServicio.Enabled Then
                    MsgBox(Mensajes.ASIGNE_PUNTO_DE_SERVICIO, MsgBoxStyle.Information)
                End If
                Exit Sub
            Else
                btguardar.Enabled = True
            End If

            asignarPuntoServicio()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub asignarPuntoServicio()
        Dim idEmpleado As Integer = dgvHorario.CurrentRow.Cells(2).Value

        Dim columnaEmpleadoA As Integer = dgvHorario.CurrentCell.ColumnIndex
        dgvHorario.EndEdit()
        If objHorario.dtPuntoDias.Rows.Count > 0 Then
            For indice = 0 To objHorario.dtPuntoDias.Rows.Count - 1
                If objHorario.dtPuntoDias.Rows(indice).Item("Id_empleado") = idEmpleado Then
                    objHorario.dtPuntoDias.Rows(indice).Item(columnaEmpleadoA) = cbPuntoServicio.SelectedValue
                End If
            Next
        End If
        'falta ahora para el codigo de horario
    End Sub

    Private Sub dateFechaHorario_ValueChanged(sender As Object, e As EventArgs) Handles dateFechaHorario.ValueChanged
        If dgvHorario.ColumnCount > 37 Then
            For Each Row In dgvHorario.Rows
                calcTiempoTotal(Row, -1)
            Next

            cargarHorarioLaboral(txtcodigo.Text)
        End If
    End Sub
    Private Sub dgvHorario_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHorario.CellEndEdit
        Dim id_empdtHorario As Integer
        If e.ColumnIndex >= 4 AndAlso e.ColumnIndex <= 34 Then
            Dim Row = dgvHorario.Rows(e.RowIndex)
            Dim vMMDia = calcTiempoTotal(Row, e.ColumnIndex)
            Dim Cell = Row.Cells(e.ColumnIndex)
            id_empdtHorario = dgvHorario.Rows(e.RowIndex).Cells(2).Value.ToString
            'Dim dtCopia As New DataTable
            'dtCopia = objHorario.dtPuntoDias.Copy
            Dim fila As DataRow = objHorario.dtPuntoDias.Select("ID_EMPLEADO='" & id_empdtHorario & "'")(0)
            Dim PuntoEmpl = objHorario.dtPuntoDias.Rows.IndexOf(fila)
            Dim fila2 As DataRow = objHorario.dtNovedades.Select("ID_EMPLEADO='" & id_empdtHorario & "'")(0)
            Dim HorarioEmpl = objHorario.dtNovedades.Rows.IndexOf(fila2)
            If String.IsNullOrEmpty(LTrim(Cell.Value.ToString)) = False AndAlso vMMDia > 0 Then
                If String.IsNullOrEmpty(objHorario.dtPuntoDias.Rows(PuntoEmpl).Item(e.ColumnIndex).ToString) OrElse objHorario.dtPuntoDias.Rows(PuntoEmpl).Item(e.ColumnIndex).ToString = "0" Then
                    'MsgBox(Mensajes.ASIGNE_PUNTO_DE_SERVICIO, MsgBoxStyle.Information)
                    cbPuntoServicio.SelectedIndex = 0
                    cbPuntoServicio.Enabled = True
                    If comboPuntoServicioD.SelectedIndex > 0 Then
                        objHorario.dtPuntoDias.Rows(PuntoEmpl).Item(e.ColumnIndex) = comboPuntoServicioD.SelectedValue
                    End If
                End If
            Else
                cbPuntoServicio.SelectedIndex = 0
                cbPuntoServicio.Enabled = False
                dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Nothing
                objHorario.dtPuntoDias.Rows(PuntoEmpl).Item(e.ColumnIndex) = DBNull.Value
            End If
        End If
    End Sub
    Private Sub dgvHorario_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHorario.CellEnter
        If dgvHorario.RowCount > 0 Then

            Dim EP As String = String.Empty
            Dim id_empdtHorario As Integer
            dgvHorario.ReadOnly = False
            dgvHorario.Rows(e.RowIndex).Cells("Nombre").ReadOnly = True
            dgvHorario.Rows(e.RowIndex).Cells("Cargo").ReadOnly = True
            dgvHorario.Rows(e.RowIndex).Cells("Turnos").ReadOnly = True

            Try
                If e.ColumnIndex >= 4 And e.ColumnIndex <= 34 Then
                    id_empdtHorario = dgvHorario.Rows(e.RowIndex).Cells(2).Value.ToString
                    If objHorario.dtPuntoDias.Rows.Count > 0 Then
                        Dim PuntoEmpl = objHorario.dtPuntoDias.Select("Id_Empleado='" & id_empdtHorario & "'")
                        EP = PuntoEmpl(0)(e.ColumnIndex).ToString
                        If Not String.IsNullOrEmpty(EP) Then
                            cbPuntoServicio.SelectedValue = EP
                        Else
                            cbPuntoServicio.SelectedIndex = 0
                        End If
                        If dgvHorario.Rows(e.RowIndex).Cells("Estado").Value.ToString = Constantes.EDITADO And
                            Not String.IsNullOrEmpty(dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString) And
                            (dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor <> Color.DarkGray OrElse Not IsNumeric(dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString)) Then
                            cbPuntoServicio.Enabled = True
                        Else
                            cbPuntoServicio.Enabled = False
                        End If
                    End If
                    If btguardar.Enabled = False Then
                        cbPuntoServicio.Enabled = False
                        dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
                    Else
                        Dim ColumnaFecha As String = Strings.Right(dgvHorario.Columns(e.ColumnIndex).Name, 2) & Strings.Right(Me.dateFechaHorario.Value, 8)
                        If dgvHorario.Rows(e.RowIndex).Cells("Estado").Value.ToString = Constantes.EDITADO Then
                            If dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor <> Color.DarkGray Then
                                dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
                                If (CDate(fechaActual).Date > CDate(ColumnaFecha).Date) Or (CDate(fechaActual).Date = CDate(ColumnaFecha).Date) Then
                                    If SesionActual.tienePermiso(PEditarTurnosPasados) = False Or (SesionActual.tienePermiso(PEditarTurnosPropios) = False And dgvHorario.Rows(e.RowIndex).Cells(2).Value = SesionActual.idUsuario) Then
                                        MsgBox(Mensajes.PROHIBIDO_EDITAR_HORARIO, MsgBoxStyle.Exclamation)
                                        dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
                                        cbPuntoServicio.Enabled = False
                                    End If
                                End If
                            Else
                                dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
                            End If
                        Else
                            dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
                            cbPuntoServicio.Enabled = False
                        End If
                    End If
                End If
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
    Private Sub dgvHorario_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvHorario.CellFormatting

        If e.ColumnIndex = dgvHorario.Columns("Turnos").Index Then
            e.Value = Format(CDbl(IIf(IsDBNull(e.Value), 0, e.Value)).ToString("N4"))
        End If
        ' Dim dtCopia As New DataTable
        ' dtCopia = objHorario.dtHorario.Copy
        Dim Dia As Integer = e.ColumnIndex - 3
        Dim idEmpleado As Integer = dgvHorario.Rows(e.RowIndex).Cells("Id_Empleado").Value.ToString
        Dim dw_Horario As DataRow() = objHorario.dtNovedades.Select("Id_Empleado='" & idEmpleado & "'", "")
        If dw_Horario.Count = 0 Then Exit Sub
        Dim fila As DataRow = dw_Horario(0)
        Dim indiceFila As Integer = objHorario.dtNovedades.Rows.IndexOf(fila)
        If e.ColumnIndex >= 4 AndAlso e.ColumnIndex <= 34 Then
            If String.IsNullOrEmpty(objHorario.dtNovedades.Rows(indiceFila).Item(e.ColumnIndex).ToString) = False AndAlso
                objHorario.dtNovedades.Rows(indiceFila).Item(e.ColumnIndex).ToString <> "0" AndAlso
                objHorario.dtNovedades.Rows(indiceFila).Item(e.ColumnIndex).ToString <> objHorario.codigo Then
                Try
                    Dim datemp As New Date
                    Dim FechaActual As String = DateTime.Now.ToString("dd/MM/yyyy")
                    datemp = Dia.ToString("00") & dateFechaHorario.Value.ToString("/MM/yyyy")
                    Select Case objHorario.dtNovedades.Rows(indiceFila).Item(e.ColumnIndex).ToString
                        Case ConstantesNom.NOVEDAD_AUSENCIA_LABORAL
                            If Not String.IsNullOrEmpty(dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString) AndAlso
                                dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString <> "D" AndAlso CDate(datemp).Date < CDate(FechaActual).Date Then
                                dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Tomato
                            End If
                        Case ConstantesNom.NOVEDAD_DIA_LABORADO_SIN_TURNO
                            dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Yellow
                        Case ConstantesNom.NOVEDAD_CAMBIO_TURNO
                            dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.MediumVioletRed
                        Case > 0
                            dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.DarkGray
                            dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.White
                    End Select
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
            If dgvHorario.Rows(e.RowIndex).Cells("Estado").Value.ToString = Constantes.EDITADO Then
                dgvHorario.Rows(e.RowIndex).Cells("Nombre").Style.BackColor = Color.LightGreen
                dgvHorario.Rows(e.RowIndex).Cells("Cargo").Style.BackColor = Color.LightGreen
                If dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor.Name = Color.FromArgb(0, 0, 0, 0).Name Then
                    dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.LightGreen
                End If
            End If

            If comboPuntoServicio.SelectedValue = -1 OrElse objHorario.dtPuntoDias.Rows.Count = 0 Then Exit Sub
            Dim codigoEP As String
            codigoEP = objHorario.dtPuntoDias.Rows(indiceFila).Item(e.ColumnIndex).ToString
            If codigoEP <> comboPuntoServicio.SelectedValue And Not String.IsNullOrEmpty(codigoEP) Then
                e.CellStyle.BackColor = Color.DarkGray
                e.CellStyle.ForeColor = Color.LightGray
            End If
        End If
    End Sub
    Private Sub dgvHorario_CellMouseDown(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvHorario.CellMouseDown
        If e.Button = MouseButtons.Right AndAlso e.RowIndex > -1 AndAlso e.ColumnIndex > -1 Then
            Dim Cell = dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex)
            Dim Col = dgvHorario.Columns(e.ColumnIndex)
            If Col.Index = 0 Then
                dgvHorario.ClearSelection()
                Cell.Selected = True
                dgvHorario.CurrentCell = Cell
            ElseIf IsNothing(dgvHorario.SelectedCells) OrElse (dgvHorario.SelectedCells.Count <= 1) Then
                dgvHorario.CurrentCell = Cell
            End If
        End If
    End Sub
    Private Sub dgvHorario_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvHorario.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf Cell_KeyPress
        e.Control.ContextMenuStrip = Me.ContextMenuStrip2
    End Sub
    Private Sub Cell_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
        ValidacionDigitacion.validarAlfabetico(e)
        Select Case Asc(e.KeyChar)
            Case 32 'no permite insertar un espacio en blanco
                e.Handled = True
        End Select
        Dim texto As String
        If e.KeyChar = vbBack AndAlso sender.text.length > 0 Then
            texto = sender.text.ToString.Substring(0, sender.text.length - 1)
        ElseIf Not e.KeyChar = vbBack Then
            texto = sender.text.ToString + IIf(IsNumeric(e.KeyChar.ToString), "", e.KeyChar.ToString)
        Else
            texto = ""
        End If

        cbPuntoServicio.Enabled = texto.Length > 0
    End Sub
    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        ContextMenuStrip1.Visible = False
        ContextMenuStrip1.Items.Clear()
        If btcancelar.Enabled AndAlso dgvHorario.CurrentCell IsNot Nothing Then
            Dim Cell = dgvHorario.CurrentCell
            Dim Col = dgvHorario.Columns(Cell.ColumnIndex)
            If dgvHorario.Rows(Cell.RowIndex).Cells("Estado").Value <> 1 Then
                ContextMenuStrip1.Visible = False
                Exit Sub
            Else
                ContextMenuStrip1.Visible = True
            End If
            If Col.Index = 0 Then
                ContextMenuStrip1.Items.Add(QuitarEmpleadoToolStripMenuItem)
            ElseIf Col.Name.Contains("Dia") Then
                validarCeldasSeleccionadas()
                If (Not IsNothing(dgvHorario.SelectedCells) AndAlso (dgvHorario.SelectedCells.Count > 1)) Then
                    CopiarToolStripMenuItem.Text = "Copiar Selección"
                    PegarToolStripMenuItem.Text = "Pegar Sobre Seleccionados"
                Else
                    CopiarToolStripMenuItem.Text = "Copiar"
                    PegarToolStripMenuItem.Text = "Pegar"
                End If
                ContextMenuStrip1.Items.Add(CopiarToolStripMenuItem)
                cargarArchivoCopia()
                If objHorario.dtcopia.Rows.Count > 0 Then ContextMenuStrip1.Items.Add(PegarToolStripMenuItem)
            End If
        End If
        e.Cancel = Not (ContextMenuStrip1.Items.Count > 0)
    End Sub
    Public Sub cargarArchivoCopia()
        Dim Archivos As String() = Directory.GetFiles(objHorario.folderTmp, "*.xml")
        If Archivos.Length > 0 AndAlso Strings.Left(Path.GetFileNameWithoutExtension(Archivos(0)), objHorario.NomArchCopia.Length) = objHorario.NomArchCopia _
        Then objHorario.dtcopia.Clear() : objHorario.dtcopia.TableName = "tabla_copia" : objHorario.dtcopia.ReadXml(Archivos(0))
    End Sub
    Public Sub salvarArchivoCopia()
        Dim NombreXml = objHorario.folderTmp & "\" & objHorario.NomArchCopia & "-" & Process.GetCurrentProcess().Id & ".xml"
        objHorario.dtcopia.TableName = "tabla_copia"
        objHorario.dtcopia.WriteXml(NombreXml)
    End Sub
    Public Sub borrarArchivoCopia()
        Dim Archivos As String() = Directory.GetFiles(objHorario.folderTmp, "*.xml")
        For Each archivo In Archivos
            If Strings.Left(Path.GetFileNameWithoutExtension(archivo), objHorario.NomArchCopia.Length) = objHorario.NomArchCopia Then File.Delete(archivo)
        Next
    End Sub
    Public Sub validarArchivoCopia()
        Dim nombre As String = Path.GetFileNameWithoutExtension(Reflection.Assembly.GetEntryAssembly().Location)
        objHorario.folderTmp = Path.GetTempPath() & nombre
        objHorario.NomArchCopia = "CopiaTurno"

        If Directory.Exists(objHorario.folderTmp) Then
            Dim ProcesosLocales = Process.GetProcessesByName(nombre).Union(Process.GetProcessesByName(nombre + ".vshost"))
            Dim strValiNom As String = ""
            For Each proceso In ProcesosLocales
                strValiNom &= objHorario.NomArchCopia & "-" & proceso.Id & "|"
            Next
            Dim arrayValiNom = strValiNom.Trim.TrimStart("|").TrimEnd("|").Split("|")
            Dim Archivos As String() = Directory.GetFiles(objHorario.folderTmp, "*.xml")

            For Each archivo In Archivos
                Dim NomArchivoFor = Path.GetFileNameWithoutExtension(archivo)
                If Strings.Left(NomArchivoFor, objHorario.NomArchCopia.Length) = objHorario.NomArchCopia AndAlso Not arrayValiNom.Contains(NomArchivoFor) _
                Then File.Delete(archivo)
            Next
        Else
            Directory.CreateDirectory(objHorario.folderTmp)
        End If
    End Sub

    Private Sub CopiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiarToolStripMenuItem.Click
        If Not IsNothing(dgvHorario.SelectedCells) Then
            objHorario.dtcopia.Clear()
            Dim vDias As String = ""
            Dim vIDsw As String = ""
            validarPrimerID()
            For Each Cell As DataGridViewCell In dgvHorario.SelectedCells
                Dim Row = dgvHorario.Rows(Cell.RowIndex)
                Dim ID = Row.Cells(2).Value.ToString
                If vIDsw = "" Then vIDsw = ID
                If vIDsw <> ID Then Exit For
                Dim Col = dgvHorario.Columns(Cell.ColumnIndex)
                Dim Dia = Replace(Col.Name, "Dia", "")
                If Dia < 10 Then Dia = Replace(Col.Name, "Dia0", "")
                vDias &= Dia & "|"
                objHorario.dtcopia.Rows.Add(ID, Dia, Cell.Value.ToString, "")
            Next
            objHorario.dtcopia = objHorario.dtcopia.Select("", "Dia").CopyToDataTable()
            vDias = vDias.Trim.TrimEnd("|")
            buscarPuntosdelDia(vDias)
            borrarArchivoCopia()
            salvarArchivoCopia()
        End If
    End Sub
    Sub validarPrimerID()
        Dim vPrimerID As Integer = dgvHorario.SelectedCells(0).RowIndex
        For Each Cell As DataGridViewCell In dgvHorario.SelectedCells
            If Cell.RowIndex < vPrimerID Then vPrimerID = Cell.RowIndex
        Next
        For Each Cell As DataGridViewCell In dgvHorario.SelectedCells
            If vPrimerID <> Cell.RowIndex Then Cell.Selected = False
        Next
    End Sub
    Sub buscarPuntosdelDia(pDias As String)
        Dim vDias As String() = pDias.Split("|")
        Dim vEstadoBusqueda As Integer = 0
        For Each dw2 As DataRow In objHorario.dtcopia.Rows
            Dim id = dw2.Item("Id_empleado").ToString
            Dim dia = dw2.Item("dia").ToString
            Dim CopyPoint = objHorario.dtPuntoDias.Select("Id_empleado=" & id & "")
            If dia < 10 Then
                dia = "Dia0" & dia
            Else
                dia = "Dia" & dia
            End If
            dw2.Item("Puntos") = CopyPoint(0).Item(dia)
        Next
    End Sub
    Private Sub PegarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PegarToolStripMenuItem.Click
        If (Not IsNothing(dgvHorario.SelectedCells)) Then
            If (dgvHorario.SelectedCells.Count > 1) Then
                pegarSobreSeleccion()
            ElseIf (dgvHorario.SelectedCells.Count = 1) Then
                pegarDesdeSeleCero()
            End If
        End If
    End Sub

    Private Sub pegarSobreSeleccion()
        Dim vIDs As String = ""
        For Each Cell As DataGridViewCell In dgvHorario.SelectedCells
            Dim Row = dgvHorario.Rows(Cell.RowIndex)
            Dim ID = Row.Cells("Id_Empleado").Value.ToString
            vIDs &= ID & "|"
        Next
        Dim arrayIDs = vIDs.Trim.TrimStart("|").TrimEnd("|").Split("|")
        Dim selecCells = dgvHorario.SelectedCells
        Dim UltIndiceDwCell As Integer = If(objHorario.dtcopia.Rows.Count > selecCells.Count, selecCells.Count, objHorario.dtcopia.Rows.Count) - 1
        objHorario.dtpegarpunto.Clear()

        For Each Row As DataGridViewRow In dgvHorario.Rows
            Dim ID = Row.Cells("Id_Empleado").Value.ToString
            Dim indiceDW As Integer = 0

            If arrayIDs.Length = 0 Then : Exit For
            ElseIf arrayIDs.Contains(ID) Then
                For Each Cell As DataGridViewCell In Row.Cells
                    If Cell.Selected Then
                        If indiceDW <= UltIndiceDwCell Then
                            If Cell.Style.BackColor = Color.LightGreen Then
                                Dim dw = objHorario.dtcopia.Rows(indiceDW)
                                Dim valor = dw.Item("Valor").ToString
                                Dim puntos = dw.Item("Puntos").ToString
                                Cell.Value = valor
                                Dim Col = dgvHorario.Columns(Cell.ColumnIndex)
                                Dim Dia = Replace(Col.Name, "Dia", "")
                                If Dia < 10 Then Dia = Replace(Col.Name, "Dia0", "")
                                If valor <> "" AndAlso puntos <> "" Then
                                    objHorario.dtpegarpunto.Rows.Add(ID, Dia, puntos)
                                End If
                                indiceDW += 1
                            End If
                        Else : Exit For
                        End If
                    End If
                Next
                arrayIDs = arrayIDs.Except(New String() {ID}).ToArray
                calcTiempoTotal(Row, -1)
            End If
        Next
        buscarPuntosdeDias()
    End Sub

    Private Sub pegarDesdeSeleCero()
        Dim Cell = dgvHorario.SelectedCells(0)
        Dim Row = dgvHorario.Rows(Cell.RowIndex)
        Dim ID = Row.Cells("Id_Empleado").Value.ToString
        Dim indiceCol = Cell.ColumnIndex
        Dim indiceDW = 0
        Dim UltIndiceDw = (objHorario.dtcopia.Rows.Count - 1)
        objHorario.dtpegarpunto.Clear()

        While (dgvHorario.Columns(indiceCol).Name.Contains("Dia") And indiceDW <= UltIndiceDw)
            If dgvHorario.Columns(indiceCol).Visible = True Then
                If Row.Cells(indiceCol).Style.BackColor = Color.LightGreen Then
                    Dim dw = objHorario.dtcopia.Rows(indiceDW)
                    Dim valor = dw.Item("Valor").ToString
                    Dim puntos = dw.Item("Puntos").ToString
                    Row.Cells(indiceCol).Value = valor
                    Dim Col = dgvHorario.Columns(indiceCol)
                    Dim Dia = Replace(Col.Name, "Dia", "")
                    If Dia < 10 Then Dia = Replace(Col.Name, "Dia0", "")
                    If valor <> "" AndAlso puntos <> "" Then
                        objHorario.dtpegarpunto.Rows.Add(ID, Dia, puntos)
                    End If
                End If
            End If
            indiceCol += 1 : indiceDW += 1
        End While
        calcTiempoTotal(Row, -1)
        buscarPuntosdeDias()
    End Sub

    Sub buscarPuntosdeDias()
        For indicePunto As Integer = 0 To objHorario.dtpegarpunto.Rows.Count - 1
            Dim dw = objHorario.dtpegarpunto.Rows(indicePunto)
            Dim idEmpleado = dw.Item("Id_empleado").ToString
            Dim dia = dw.Item("Dia").ToString
            ' Dim dtCopia As New DataTable
            ' dtCopia = objHorario.dtPuntoDias.Copy
            Dim edpunto = objHorario.dtPuntoDias.Select("id_empleado='" & idEmpleado & "'")
            Dim rowsIndex = objHorario.dtPuntoDias.Rows.IndexOf(edpunto(0))
            Dim columnaDia = IIf(objHorario.dtpegarpunto.Rows(indicePunto).Item("dia") < 10, "Dia0", "Dia") & objHorario.dtpegarpunto.Rows(indicePunto).Item("dia")
            objHorario.dtPuntoDias.Rows(rowsIndex).Item(columnaDia) = objHorario.dtpegarpunto.Rows(indicePunto).Item("Punto").ToString
        Next
    End Sub

    Private Sub QuitarEmpleadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarEmpleadoToolStripMenuItem.Click
        Try
            'Dim dtCopia As New DataTable
            'dtCopia = objHorario.dtHorario.Copy
            Dim dw_horario As DataRow() = objHorario.dtHorario.Select("Id_Empleado='" & dgvHorario.Rows(dgvHorario.CurrentCell.RowIndex).Cells("Id_Empleado").Value & "'", "")
            If dw_horario.Count = 0 Then Exit Sub
            Dim fila As DataRow = dw_horario(0)
            Dim indiceFila As Integer = objHorario.dtHorario.Rows.IndexOf(fila)
            For i = 4 To 34
                objHorario.dtHorario.Rows(indiceFila).Item(i) = ""
                objHorario.dtPuntoDias.Rows(indiceFila).Item(i) = ""
            Next
            objHorario.dtHorario.AcceptChanges()
            colorTodasLasConvenciones()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub llenar_menuconvenciones()
        ContextMenuStrip2.Items.Clear()
        ContextMenuStrip2.Items.Add(ConvencionesToolStripMenuItem)
        ContextMenuStrip2.Items.Add(ToolStripSeparator8)
        Dim mnuOpcion As ToolStripItem
        For Each drFila As DataRow In objHorario.dtConvenciones.Rows
            If Not drFila("Anulado") Then
                mnuOpcion = New ToolStripMenuItem(drFila("Nombre").ToString())
                mnuOpcion.Tag = drFila("Simbolo").ToString & "|" & drFila("Simbolo_Color").ToString
                RemoveHandler mnuOpcion.Paint, AddressOf ToolStripItem1_Paint
                AddHandler mnuOpcion.Paint, AddressOf ToolStripItem1_Paint
                ContextMenuStrip2.Items.Add(mnuOpcion)
            End If
        Next
    End Sub

    Private Sub ContextMenuStrip2_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ContextMenuStrip2.ItemClicked
        dgvHorario.CurrentCell.Value = e.ClickedItem.Tag.ToString.Split("|")(0)
        dgvHorario.EndEdit(True)
    End Sub

    Private Sub ToolStripItem1_Paint(sender As Object, e As PaintEventArgs)
        Dim nombre As String() = sender.Tag.ToString.Split("|")
        Using b As New SolidBrush(Color.FromArgb(CInt(nombre(1))))
            Dim fuente As Font = dgvHorario.Columns(5).DefaultCellStyle.Font
            e.Graphics.DrawString(nombre(0), fuente, b, e.ClipRectangle.X + 2, e.ClipRectangle.Y + 1)
        End Using
    End Sub
    Private Sub validarCeldasSeleccionadas()
        If (Not IsNothing(dgvHorario.SelectedCells) AndAlso (dgvHorario.SelectedCells.Count > 1)) Then
            For Each Cell As DataGridViewCell In dgvHorario.SelectedCells
                Dim Col = dgvHorario.Columns(Cell.ColumnIndex)
                If Not Col.Name.Contains("Dia") Then Cell.Selected = False
            Next
        End If
    End Sub
    Function calcTiempoTotal(ByRef Row As DataGridViewRow, ByVal pCurrentCol As Integer) As Int64
        Dim total As Int64 = 0
        Dim vMMDia As Int64 = 0
        For Each Cell As DataGridViewCell In Row.Cells
            Dim indexCol = Cell.ColumnIndex
            Dim Col = dgvHorario.Columns(indexCol)
            Dim vSimbolo = Cell.Value.ToString.Trim.ToUpper
            If Col.Visible AndAlso Col.Name.Contains("Dia") AndAlso vSimbolo <> "" And Not IsNumeric(vSimbolo) Then
                Dim vConvencionColorMM = buscConvencion(vSimbolo)
                Dim fecha As Date
                fecha = CDate(dateFechaHorario.Value.Year & "-" & dateFechaHorario.Value.Month & "-" & Col.Name.Substring(3, 2))
                If Row.Cells("Estado").Value = Constantes.EDITADO AndAlso btguardar.Enabled = True AndAlso
                    ((vConvencionColorMM.Minutos = -1) OrElse (vConvencionColorMM.Anulado <> 0 And
                     CDate(fecha).Date > CDate(vConvencionColorMM.fechaActualizacion).Date)) Then
                    MsgBox("Error: no existe la convención: '" + vSimbolo + "'", MsgBoxStyle.Critical)
                    Cell.Value = ""
                Else
                    total += vConvencionColorMM.Minutos
                    End If
                    Cell.Style.ForeColor = vConvencionColorMM.Color
                    If pCurrentCol = indexCol Then vMMDia = vConvencionColorMM.Minutos
                End If
        Next
        Row.Cells("Minutos_Programados").Value = total 'minutos programados
        Row.Cells("Horas").Value = Math.Truncate(Math.Round(total / 60, 1) * 10) / 10 ' horas programadas
        Row.Cells("Turnos").Value = (total / 60 / 12 * 10) / 10 ' turnos programados
        Return pCurrentCol
    End Function
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If txtcodigo.Text = "" Then btimprimir.Enabled = False : Return
        Dim rptHorario1 As New rptHorario()
        rptHorario1.SetParameterValue("@Codigo", txtcodigo.Text)
        rptHorario1.SetParameterValue("@Terceros", listar_empleados_visibles.Replace("'", ""))
        rptHorario1.SetParameterValue("@Usuario", SesionActual.idUsuario)
        rptHorario1.SetParameterValue("Npunto", comboPuntoServicio.Text)
        rptHorario1.SetParameterValue("Narea", comboAreaServicio.Text)
        rptHorario1.SetParameterValue("Ncargo", comboCargo.Text)
        Exec.getReport(rptHorario1, Nothing, "Horario")
    End Sub

    Private Sub comboPuntoServicio_SelectedIndexChanged(combo As ComboBox, e As EventArgs) Handles comboPuntoServicio.SelectedIndexChanged,
                                                                                                   comboPuntoServicioD.SelectedIndexChanged,
                                                                                                  comboAreaServicio.SelectedIndexChanged,
        comboCargo.SelectedIndexChanged

        'If (combo.DropDownStyle <> ComboBoxStyle.DropDown) Then
        filtrar()
        'End If

    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
            For i = 0 To dgvHorario.Rows.Count - 1
                For J = 4 To 34
                    dgvHorario.Rows(i).Cells(J).ReadOnly = True
                Next
            Next
            dateFechaHorario.Enabled = False
            cbPuntoServicio.Enabled = False
            filtrar()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btAceptaCopiarPegar_Click(sender As Object, e As EventArgs) Handles btOpcionConvenciones.Click
        objHorario.cargarConvenciones()
        llenar_menuconvenciones()
    End Sub

    Private Sub comboPuntoServicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboPuntoServicioD.SelectedIndexChanged, comboCargo.SelectedIndexChanged, comboAreaServicio.SelectedIndexChanged, comboPuntoServicio.SelectedIndexChanged

    End Sub


    Private Sub dgvHorario_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvHorario.KeyDown
        If e.KeyCode = Keys.Delete AndAlso btguardar.Enabled = True AndAlso dgvHorario.Rows(dgvHorario.CurrentCell.RowIndex).Cells("Estado").Value.ToString = Constantes.EDITADO Then
            If dgvHorario.CurrentCell.ColumnIndex >= 4 And dgvHorario.CurrentCell.ColumnIndex <= 34 Then
                If IsNumeric(dgvHorario.Rows(dgvHorario.CurrentCell.RowIndex).Cells(dgvHorario.CurrentCell.ColumnIndex).Value.ToString) AndAlso
                             dgvHorario.Rows(dgvHorario.CurrentCell.RowIndex).Cells(dgvHorario.CurrentCell.ColumnIndex).Style.BackColor = Color.DarkGray Then
                    If MsgBox(Mensajes.SUPRIMIR_CONVENCION, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Dim id_empdtHorario As Integer
                        id_empdtHorario = dgvHorario.Rows(dgvHorario.CurrentCell.RowIndex).Cells(2).Value.ToString
                        Dim fila As DataRow = objHorario.dtPuntoDias.Select("ID_EMPLEADO='" & id_empdtHorario & "'")(0)
                        Dim PuntoEmpl = objHorario.dtPuntoDias.Rows.IndexOf(fila)
                        Dim fila2 As DataRow = objHorario.dtNovedades.Select("ID_EMPLEADO='" & id_empdtHorario & "'")(0)
                        Dim HorarioEmpl = objHorario.dtNovedades.Rows.IndexOf(fila2)
                        cbPuntoServicio.SelectedIndex = 0
                        cbPuntoServicio.Enabled = False
                        dgvHorario.Rows(dgvHorario.CurrentCell.RowIndex).Cells(dgvHorario.CurrentCell.ColumnIndex).Value = Nothing
                        objHorario.dtPuntoDias.Rows(PuntoEmpl).Item(dgvHorario.CurrentCell.ColumnIndex) = DBNull.Value
                        objHorario.dtNovedades.Rows(HorarioEmpl).Item(dgvHorario.CurrentCell.ColumnIndex) = DBNull.Value
                        dgvHorario.Rows(dgvHorario.CurrentCell.RowIndex).Cells(dgvHorario.CurrentCell.ColumnIndex).Style.BackColor = Color.LightGreen
                        dgvHorario.Rows(dgvHorario.CurrentCell.RowIndex).Cells(dgvHorario.CurrentCell.ColumnIndex).ReadOnly = False
                    Else
                        dgvHorario.Rows(dgvHorario.CurrentCell.RowIndex).Cells(dgvHorario.CurrentCell.ColumnIndex).ReadOnly = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgvHorario_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHorario.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        If btguardar.Enabled Then
            'Dim dtCopia As New DataTable
            'dtCopia = objHorario.dtHorario.Copy
            Dim idEmpleado As Integer = dgvHorario.Rows(e.RowIndex).Cells("Id_Empleado").Value.ToString
            Dim dw_Horario As DataRow() = objHorario.dtHorario.Select("Id_Empleado='" & idEmpleado & "'", "")
            If dw_Horario.Count = 0 Then Exit Sub
            Dim fila As DataRow = dw_Horario(0)
            Dim indiceFila As Integer = objHorario.dtHorario.Rows.IndexOf(fila)
            objHorario.dtHorario.Rows(indiceFila).Item("Estado") = Constantes.EDITADO

            dw_Horario = objHorario.dtNovedades.Select("Id_Empleado='" & idEmpleado & "'", "")
            If dw_Horario.Count = 0 Then Exit Sub
            fila = dw_Horario(0)
            indiceFila = objHorario.dtNovedades.Rows.IndexOf(fila)
            objHorario.dtNovedades.Rows(indiceFila).Item("Estado") = Constantes.EDITADO

            dw_Horario = objHorario.dtPuntoDias.Select("Id_Empleado='" & idEmpleado & "'", "")
            If dw_Horario.Count = 0 Then Exit Sub
            fila = dw_Horario(0)
            indiceFila = objHorario.dtPuntoDias.Rows.IndexOf(fila)
            objHorario.dtPuntoDias.Rows(indiceFila).Item("Estado") = Constantes.EDITADO
            If e.ColumnIndex >= 4 And e.ColumnIndex <= 34 Then
                dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
                If Not String.IsNullOrEmpty(dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString) And
                            dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor <> Color.DarkGray Then
                    cbPuntoServicio.Enabled = True
                ElseIf dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.DarkGray Then

                    dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
                End If
            Else
                dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            End If
        Else
            dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
        End If
    End Sub

    Private Function listar_empleados_visibles() As String
        Dim TercerosVisibles As String = "''"
        For Each Row As DataGridViewRow In dgvHorario.Rows
            Try
                TercerosVisibles &= String.Format(",'{0}'", Row.Cells(2).Value.ToString)
            Catch ex As Exception
            End Try
        Next
        Return TercerosVisibles
    End Function
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub
    Private Sub guardarHorario()
        Try
            If objHorario.redisenarTabla() Then
                objHorario.guardarHorario()
                If Not IsNumeric(objHorario.codigo) Then
                    MsgBox(objHorario.codigo, MsgBoxStyle.Critical)
                    Exit Sub
                End If
                txtcodigo.Text = objHorario.codigo
                General.deshabilitarControles(Me)
                General.habilitarBotones(Me.ToolStrip1)
                btguardar.Enabled = False
                btcancelar.Enabled = False
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                cargarHorarioLaboral(txtcodigo.Text)
            Else
                MsgBox(Mensajes.IMPOSIBLE_GUARDAR_HORARIO, MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub cargarHorarioLaboral(pCodigo As String)
        If objHorario.cargando = True Then Exit Sub
        limpiarForm()
        Try
            objHorario.cargando = True
            objHorario.codigo = pCodigo
            objHorario.cargarFechaHorario()
            If objHorario.dtDatosHorario.Rows.Count > 0 Then
                objHorario.fecha = objHorario.dtDatosHorario.Rows(0).Item("Fecha_Horario")
                dateFechaHorario.Value = CDate(objHorario.fecha).Date
            Else
                dateFechaHorario.Value = CDate(objHorario.cargarFechaNuevoHorario()).Date
                objHorario.fecha = Exec.primerDiaMes(dateFechaHorario.Value)
            End If
            objHorario.fechaInicio = Exec.primerDiaMes(dateFechaHorario.Value)
            objHorario.fechaFin = Exec.ultimoDiaMes(dateFechaHorario.Value)
            objHorario.cargarFestivosMes()

            objHorario.soloCarga = False
            objHorario.cargarHorario()
            txtcodigo.Text = pCodigo
            dateFechaHorario.Value = objHorario.fecha
            SiglaDias()

            dgvHorario.CurrentCell = Nothing : dgvHorario.ClearSelection()
            comboPuntoServicio.Enabled = True : comboPuntoServicioD.Enabled = True : comboAreaServicio.Enabled = True : comboCargo.Enabled = True
            comboPuntoServicio.SelectedIndex = 0 : comboPuntoServicioD.SelectedIndex = 0 : comboAreaServicio.SelectedIndex = 0
            txtBuscar.ReadOnly = False
            objHorario.bsHorario.Filter = ""
            cargarCargos()

            'identificarNovedades()
            ' colorTodasLasConvenciones()

            For i = 0 To dgvHorario.Rows.Count - 1
                For J = 4 To 34
                    dgvHorario.Rows(i).Cells(J).ReadOnly = True
                Next
            Next
            If btguardar.Enabled = False Then
                General.habilitarBotones(ToolStrip1)
                btguardar.Enabled = False
                btcancelar.Enabled = False
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

        objHorario.cargando = False
    End Sub
    Private Sub cargarCargos()
        Dim distinctDT As DataTable = objHorario.dtHorario.DefaultView.ToTable(True, "Cargo")
        distinctDT.Rows.Add(Constantes.SELECCION)
        Dim view As DataView = New DataView(distinctDT)
        view.Sort = "Cargo"
        comboCargo.DisplayMember = Nothing
        comboCargo.DataSource = view
        comboCargo.DisplayMember = "Cargo"
        comboCargo.DropDownStyle = ComboBoxStyle.Simple
        comboCargo.SelectedIndex = 0
        comboCargo.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Function verificarHorario() As String
        comboPuntoServicioD.SelectedIndex = 0
        comboPuntoServicio.SelectedIndex = 0
        comboAreaServicio.SelectedIndex = 0
        comboCargo.SelectedIndex = 0
        Dim mensaje As String = ""
        For filaAux = 0 To objHorario.dtHorario.Rows.Count - 1
            For columnaAux = 4 To 34
                If String.IsNullOrEmpty(objHorario.dtHorario.Rows(filaAux).Item(columnaAux).ToString) = False AndAlso
                                        objHorario.dtHorario.Rows(filaAux).Item(columnaAux).ToString <> "D" AndAlso objHorario.dtHorario.Rows(filaAux).Item("Estado").ToString = 1 Then
                    Dim dia As String = ""
                    dia = columnaAux - 3
                    If dia < 10 Then
                        dia = "0" & dia
                    End If
                    Dim cantidad As Integer
                    cantidad = objHorario.dtPuntoDias.Select("id_empleado=" & objHorario.dtHorario.Rows(filaAux).Item("Id_Empleado") & " and (CONVERT(Dia" & dia & ",'System.String')='' or Dia" & dia & " is null or CONVERT(Dia" & dia & ",'System.String')='0' )", "").Count
                    If cantidad > 0 Then
                        If String.IsNullOrEmpty(mensaje) Then
                            mensaje = "¡Existen convenciones sin punto asignado, por favor seleccione el punto.!" & vbCrLf & "Empleado:  " &
                                      objHorario.dtHorario.Rows(filaAux).Item("Nombre") &
                                      ", dia: " & dia
                        Else
                            mensaje = mensaje & vbCrLf & "Empleado: " &
                                      objHorario.dtHorario.Rows(filaAux).Item("Nombre") &
                                      ", dia: " & dia
                        End If
                    End If
                End If
            Next
        Next
        Return mensaje
    End Function
End Class