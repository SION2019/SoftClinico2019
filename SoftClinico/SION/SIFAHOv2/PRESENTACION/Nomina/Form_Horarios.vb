
Public Class Form_Horarios
    Dim p7, FocoCombo, enLoad, AgregandoEmpleados, txtBusCambia, Cargando As Boolean
    Dim objHorarios_D As New HorarioLaboralBLL
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, PAsignar, PEditarTurnosPasados, PEditarTurnosPropios, Cadena As String
    Dim dtPnl, dthorario, dthorarioCopia, dthorario_del, dtpuntodia, dtpuntodia_aux, dttempopunto, dtconvencion, dtcopia, dtpegarpunto, dtinfohor As New DataTable ' pasar al objeto
    Dim EnlceDtaPnl As New BindingSource
    Dim Terceros, TercerosVisibles, NumEmpleados, folderTmp, NomArchCopia As String
    Dim cadenaZero = "select top(0) ''"
    Dim HorIndice As Integer
    Dim objHorario As New Horario
    Dim tempCelda As DataGridViewCell
    Private WithEvents timerRuedaFecha As New Timer() With {.Interval = 245}
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form_Horarios_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        enLoad = True
        iniciar_permisos()
        cadena = ConsultasNom.LISTA_NOMINA_PUNTOS & SesionActual.idEmpresa
        cargarCombos(Cadena, "Nombre", "Codigo", comboPuntoServicio, "- - - Todos los Puntos- - -")
        cargarCombos(cadenaZero, "Nombre", "Codigo", comboAreaServicio, "- - - Todas las Areas- - -")
        Cadena = Consultas.LISTA_HORARIO_CARGO & SesionActual.idEmpresa
        cargarCombos(Cadena, "Nombre", "Codigo", comboCargo, "- - - Todos los Cargos- - -")
        General.deshabilitarControles(Me)
        Dim params As New List(Of String)
        params.Add("-2")
        params.Add(objHorario.puntoE)
        General.llenarTabla(Consultas.HORARIOPUNTO_CARGAR, params, dthorario)
        EnlceDtaHor.DataSource = dthorario
        dgvHorario.DataSource = EnlceDtaHor.DataSource
        iniciar_dgvHorario()
        iniciar_dgvpuntodia()
        objHorarios_D.enlazarTablaInfoHorario(dtinfohor)
        identificarNovedades()
        objHorarios_D.enlazarDataSet(objHorario.ds, dtinfohor, dthorario, dthorario_del, dtpuntodia)
        cargar_convenciones()
        objHorario.fechaInicio = Exec.primerDiaMes(dateFechaHorario.Value)
        objHorario.fechaFin = Exec.ultimoDiaMes(dateFechaHorario.Value)
        objHorario.cargarFestivosMes()
        SiglaDias()
        enLoad = False
        dgvHorario.Columns(0).ReadOnly = True
        dgvHorario.Columns(1).ReadOnly = True
        dgvHorario.Columns(2).ReadOnly = True
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
    End Sub

    Sub iniciar_permisos()
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        PEditarTurnosPasados = permiso_general & "pp" & "05"
        PEditarTurnosPropios = permiso_general & "pp" & "06"
    End Sub
    Sub iniciar_dgvHorario()
        lbEmpleados.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9, FontStyle.Bold)
        NumEmpleados = "   Empleados:  {0}   "
        dgvHorario.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        dgvHorario.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        dgvHorario.AlternatingRowsDefaultCellStyle.BackColor = Color.White : dgvHorario.GridColor = Color.FromArgb(224, 224, 224) : dgvHorario.DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255) : dgvHorario.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical
        For Each Col As DataGridViewColumn In dgvHorario.Columns
            If Col.Index <> 0 Then Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter : _
            If Col.Name.Contains("Dia") Then Col.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7, FontStyle.Regular)
            Col.SortMode = DataGridViewColumnSortMode.NotSortable
            If Col.Index >= 4 And Col.Index <= 34 Then dgvHorario.Columns(Col.Index).Width = 30
        Next
        dgvHorario.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvHorario.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7)
        dgvHorario.Columns(0).Width = 194
        dgvHorario.Columns(1).Width = 100
        dgvHorario.Columns(35).Width = 38
        dgvHorario.Columns(1).Frozen = True
        dgvHorario.Columns(2).Visible = False
        dgvHorario.Columns(3).Visible = False
        dgvHorario.Columns(38).Visible = False
        dgvHorario.Columns(39).Visible = False
        dgvHorario.Columns(40).Visible = False
        dgvHorario.Columns(35).ReadOnly = True
    End Sub
    Sub iniciar_dgvpuntodia()
        dgvPuntoDia.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        objHorarios_D.enlazarTablaPunto(dgvPuntoDia, dtpuntodia, dtpuntodia_aux, EnlceDtaPuntoDia)
        objHorarios_D.enlazarTablaCopia(dtcopia)
        objHorarios_D.enlazarTablaPega(dtpegarpunto)
        validarArchivoCopia()
        cargarArchivoCopia()
    End Sub
    Public Sub cargarArchivoCopia()
        Dim Archivos As String() = Directory.GetFiles(folderTmp, "*.xml")
        If Archivos.Length > 0 AndAlso Strings.Left(Path.GetFileNameWithoutExtension(Archivos(0)), NomArchCopia.Length) = NomArchCopia _
        Then dtcopia.Clear() : dtcopia.TableName = "tabla_copia" : dtcopia.ReadXml(Archivos(0))
    End Sub
    Public Sub salvarArchivoCopia()
        Dim NombreXml = folderTmp & "\" & NomArchCopia & "-" & Process.GetCurrentProcess().Id & ".xml"
        dtcopia.TableName = "tabla_copia" : dtcopia.WriteXml(NombreXml)
    End Sub
    Public Sub borrarArchivoCopia()
        Dim Archivos As String() = Directory.GetFiles(folderTmp, "*.xml")
        For Each archivo In Archivos
            If Strings.Left(Path.GetFileNameWithoutExtension(archivo), NomArchCopia.Length) = NomArchCopia Then File.Delete(archivo)
        Next
    End Sub
    Public Sub validarArchivoCopia()
        Dim nombre As String = Path.GetFileNameWithoutExtension(Reflection.Assembly.GetEntryAssembly().Location)
        folderTmp = Path.GetTempPath() & nombre : NomArchCopia = "CopiaTurno"

        If Directory.Exists(folderTmp) Then
            Dim ProcesosLocales = Process.GetProcessesByName(nombre).Union(Process.GetProcessesByName(nombre + ".vshost"))
            Dim strValiNom As String = ""
            For Each proceso In ProcesosLocales
                strValiNom &= NomArchCopia & "-" & proceso.Id & "|"
            Next
            Dim arrayValiNom = strValiNom.Trim.TrimStart("|").TrimEnd("|").Split("|")
            Dim Archivos As String() = Directory.GetFiles(folderTmp, "*.xml")

            For Each archivo In Archivos
                Dim NomArchivoFor = Path.GetFileNameWithoutExtension(archivo)
                If Strings.Left(NomArchivoFor, NomArchCopia.Length) = NomArchCopia AndAlso Not arrayValiNom.Contains(NomArchivoFor) _
                Then File.Delete(archivo)
            Next
        Else : Directory.CreateDirectory(folderTmp)
        End If
    End Sub
    Sub cargar_convenciones()
        General.llenarTablaYdgv(String.Format(Consultas.CARGAR_CONVENCION, SesionActual.idUsuario, SesionActual.idEmpresa), dtconvencion)
        llenar_menuconvenciones()
    End Sub
    Private Sub llenar_menuconvenciones()
        ContextMenuStrip2.Items.Clear()
        ContextMenuStrip2.Items.Add(ConvencionesToolStripMenuItem)
        ContextMenuStrip2.Items.Add(ToolStripSeparator8)
        Dim mnuOpcion As ToolStripItem
        For Each drFila As DataRow In dtconvencion.Rows
            mnuOpcion = New ToolStripMenuItem(drFila("Nombre").ToString())
            mnuOpcion.Tag = drFila("Simbolo").ToString & "|" & drFila("Simbolo_Color").ToString
            RemoveHandler mnuOpcion.Paint, AddressOf ToolStripItem1_Paint
            AddHandler mnuOpcion.Paint, AddressOf ToolStripItem1_Paint
            ContextMenuStrip2.Items.Add(mnuOpcion)
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

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            objHorario.opcionCancelar = True
            objHorario.dtFestivos.Clear()
            dtpuntodia.Clear()
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            txtcodigo.Clear()
            dgvHorario.ReadOnly = False
            dthorario.Clear()
            General.deshabilitarBotones(ToolStrip1)
            btguardar.Enabled = True
            btcancelar.Enabled = True
            dateFechaHorario.Value = CDate(Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)).Date.AddMonths(1)
            dgvHorario.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            dgvHorario.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            dgvHorario.AlternatingRowsDefaultCellStyle.BackColor = Color.White : dgvHorario.GridColor = Color.FromArgb(224, 224, 224) : dgvHorario.DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255) : dgvHorario.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical
            objHorario.fechaInicio = Exec.primerDiaMes(dateFechaHorario.Value)
            objHorario.fechaFin = Exec.ultimoDiaMes(dateFechaHorario.Value)
            objHorario.cargarFestivosMes()
            dgvHorario.Columns(0).ReadOnly = True
            dgvHorario.Columns(1).ReadOnly = True
            dgvHorario.Columns(2).ReadOnly = True
            dgvPuntoDia.ReadOnly = True
            dttempopunto = dtpuntodia_aux.Clone
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            objHorario.opcionCancelar = False
            General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
            dthorario.AcceptChanges()
            identificarNovedades()
            colorTodasLasConvenciones()
            'PuntosEmpleadosSinHorario()
            dgvHorario.Columns(0).ReadOnly = True
            dgvHorario.Columns(1).ReadOnly = True
            dgvHorario.Columns(35).ReadOnly = True
            dgvHorario.Columns(37).ReadOnly = True
            dateFechaHorario.Enabled = False
            dttempopunto = dtpuntodia_aux.Clone
            dthorarioCopia = dthorario.Copy
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub bteditar_EnabledChanged(sender As Object, e As EventArgs) Handles bteditar.EnabledChanged
        btimprimir.Enabled = bteditar.Enabled
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        objHorario.opcionCancelar = True
        If General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar) = True Then
            btguardar.Enabled = False
            dthorario.Clear()
            objHorario.dtEliminarPunto.Clear()
        Else
            objHorario.opcionCancelar = False
        End If
    End Sub

    Private Sub btcancelar_EnabledChanged(sender As Object, e As EventArgs) Handles btcancelar.EnabledChanged
        Try
            PnlInfo.Visible = False
            cbAceptarCopiarPegar.Checked = btcancelar.Enabled
            dgvHorario.Columns(36).Visible = Not btcancelar.Enabled
            dgvHorario.Columns(37).Visible = btcancelar.Enabled
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Sub dateFechaHorario_ValueChanged(sender As Object, e As EventArgs) Handles dateFechaHorario.ValueChanged
        If Cargando Then Return
        GroupBox6.Text = "Cuadro De Turnos Para El Mes De: " & StrConv(dateFechaHorario.Value.ToString("MMMM"), 3)
        SiglaDias()
        For Each Row In dgvHorario.Rows
            calcTiempoTotal(Row, -1)
        Next
        If dthorario.Columns.Count > 0 Then
            If String.IsNullOrEmpty(txtcodigo.Text) Then
                General.llenarTablaYdgv(Consultas.CARGAR_EMPLEADOS_HOR & SesionActual.idEmpresa & ",'', '" & dateFechaHorario.Value.ToString("yyyyMM01") & "'", dtPnl)
                buildTerceros()
                AgregarEmpleados()
            End If

        End If

    End Sub

    Private Sub dateFechaHorario_MouseWheel(sender As Object, e As MouseEventArgs) Handles dateFechaHorario.MouseWheel
        timerRuedaFecha.Tag = e.Delta : timerRuedaFecha.Stop() : timerRuedaFecha.Start()
    End Sub

    Private Sub timerRuedaFecha_Tick(sender As Object, e As EventArgs) Handles timerRuedaFecha.Tick
        timerRuedaFecha.Stop()
        dateFechaHorario.Value = dateFechaHorario.Value.AddMonths(If(IsNumeric(timerRuedaFecha.Tag) AndAlso timerRuedaFecha.Tag < 0, 1, -1))
    End Sub

    Sub SiglaDias()
        Dim datemp As New Date
        Dim Nombre As String = ""
        Dim ultDiaMes = DateTime.DaysInMonth(dateFechaHorario.Value.Year, dateFechaHorario.Value.Month)
        For i = 0 To dgvHorario.Columns.Count - 1
            dgvHorario.Columns(i).HeaderCell.Style.ForeColor = Color.Black
            If dgvHorario.Columns(i).Name.Contains("Dia") Then
                Dim Dia As Integer = Replace(dgvHorario.Columns(i).Name, "Dia", "")
                If Dia > ultDiaMes Then
                    dgvHorario.Columns(i).Visible = False
                Else
                    dgvHorario.Columns(i).Visible = True
                    datemp = Dia.ToString("00") & dateFechaHorario.Value.ToString("/MM/yyyy")
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
            End If
        Next
    End Sub
    Private Sub AgregarEmpleados()
        dthorario.Clear()
        For i As Integer = (dtPnl.Rows.Count - 1) To 0 Step -1
            dtPnl.Rows(i).Item(5) = True
            If dtPnl.Rows(i).Item(5) = True Then
                Dim busqueda = dthorario.Select("Id_tercero='" & dtPnl.Rows(i).Item(1).ToString & "'", "")
                Dim dw = dtPnl.Rows(i)
                If (busqueda.Count > 0) Then
                    dthorario.ImportRow(busqueda(0))
                    dthorario.Rows.Remove(busqueda(0))
                Else
                    dthorario.ImportRow(dw)
                End If
                dtPnl.Rows.Remove(dw)
            End If
        Next
        buildTerceros()
        comboPuntoServicio.SelectedIndex = 0 : comboAreaServicio.SelectedIndex = 0 : comboCargo.SelectedIndex = 0
        EnlceDtaHor.Filter = ""
        objHorarios_D.llenarTablaPunto(dtpuntodia, dtpuntodia_aux, Terceros, txtcodigo.Text)
        EnlceDtaPuntoDia.DataSource = dtpuntodia
        dgvPuntoDia.DataSource = EnlceDtaPuntoDia.DataSource
        colorTodasLasConvenciones()
        dgvHorario.DataSource = dthorario

        dgvHorario.CurrentCell = Nothing : dgvHorario.ClearSelection()
    End Sub

    Private Sub dgvHorario_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHorario.CellEnter
        If AgregandoEmpleados Then Return
        Try
            Dim EP As String = String.Empty
            Dim id_empdtHorario As Integer
            If e.ColumnIndex >= 4 And e.ColumnIndex <= 34 Then
                'filtro = String.Format("(([id_empleado]={0}) AND ([dia]='{1}'))",
                '                   dgvHorario.Rows(e.RowIndex).Cells(2).Value.ToString,
                '                   CInt(Replace(dgvHorario.Columns(e.ColumnIndex).Name, "Dia", "")))
                EnlceDtaPuntoDia.Sort = "Codigo_punto"
                EnlceDtaPuntoDia.Filter = ""  'Muestra la grilla para escoger los puntos.
                id_empdtHorario = dgvHorario.Rows(e.RowIndex).Cells(2).Value.ToString
                If objHorario.dtDetallePunto.Rows.Count > 0 Then

                    Dim PuntoEmpl = objHorario.dtDetallePunto.Select("ID_EMPLEADO='" & id_empdtHorario & "'")
                    EP = PuntoEmpl(0)(e.ColumnIndex - 3).ToString
                    For fila = 0 To dtpuntodia.Rows.Count - 1
                        If dtpuntodia.Rows(fila).Item(3).ToString = EP Then
                            Try
                                dtpuntodia.Rows(fila).Item(5) = 1
                                dgvPuntoDia.Rows(fila).Selected = True
                                dgvPuntoDia.CurrentCell = dgvPuntoDia.Rows(fila).Cells(3)
                            Catch ex As Exception
                                general.manejoErrores(ex)
                            End Try
                        Else
                            Try
                                dtpuntodia.Rows(fila).Item(5) = 0
                            Catch ex As Exception
                                general.manejoErrores(ex)
                            End Try
                        End If
                    Next
                Else
                    Dim PuntoEmpl = dttempopunto.Select("id_empleado='" & id_empdtHorario & "' and dia='" & (e.ColumnIndex - 3) & "'")
                    If PuntoEmpl.Count = 0 Then
                        For fila = 0 To dtpuntodia.Rows.Count - 1
                            Try
                                dtpuntodia.Rows(fila).Item(5) = 0
                            Catch ex As Exception
                                general.manejoErrores(ex)
                            End Try
                        Next
                    Else
                        EP = PuntoEmpl(0)(3).ToString
                        For fila = 0 To dtpuntodia.Rows.Count - 1
                            If dtpuntodia.Rows(fila).Item(3).ToString = EP Then
                                Try
                                    dtpuntodia.Rows(fila).Item(5) = 1
                                Catch ex As Exception
                                    general.manejoErrores(ex)
                                End Try
                            Else
                                Try
                                    dtpuntodia.Rows(fila).Item(5) = 0
                                Catch ex As Exception
                                    general.manejoErrores(ex)
                                End Try
                            End If
                        Next
                    End If
                End If
            End If
            If bteditar.Enabled = True Then
                dgvPuntoDia.ReadOnly = True
                Exit Sub
            Else
                dgvPuntoDia.ReadOnly = False
                If dgvHorario.RowCount > 0 Then
                    Dim ColumnaFecha As String = Strings.Right(dgvHorario.Columns(e.ColumnIndex).Name, 2) & Strings.Right(Me.dateFechaHorario.Value, 8)
                    Dim ColumnaHora As DataRow() = dtconvencion.Select("Simbolo='" & dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & "'")
                    Dim horaCol As String
                    Dim FechaActual As String
                    Dim HoraActual As String
                    FechaActual = DateTime.Now.ToString("dd/MM/yyyy")
                    HoraActual = DateTime.Now.ToString("HH:MM:ss")
                    If ColumnaHora.Count > 0 Then
                        horaCol = ColumnaHora(0)(7).ToString
                        If (CDate(FechaActual) > CDate(ColumnaFecha)) Or (CDate(FechaActual) = CDate(ColumnaFecha)) Then 'And HoraActual > horaCol) Then
                            If SesionActual.tienePermiso(PEditarTurnosPasados) = False Or (SesionActual.tienePermiso(PEditarTurnosPropios) = False And dgvHorario.Rows(e.RowIndex).Cells(2).Value = SesionActual.idUsuario) Then
                                MsgBox("No se puede Modificar este dia en el horario", MsgBoxStyle.Exclamation)
                                dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
                                dgvPuntoDia.ReadOnly = True
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Sub dgvHorario_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHorario.CellEndEdit
        Dim Col = dgvHorario.Columns(e.ColumnIndex)
        Dim id_empdtHorario As Integer
        Dim crow As Integer
        If Col.Name.Contains("Dia") Then
            PnlInfo.Visible = False
            Dim Row = dgvHorario.Rows(e.RowIndex)
            Dim vMMDia = calcTiempoTotal(Row, e.ColumnIndex)
            Dim Cell = Row.Cells(e.ColumnIndex)
            If String.IsNullOrEmpty(LTrim(Cell.Value.ToString)) = False AndAlso vMMDia > 0 Then
                If comboPuntoServicio.SelectedIndex = 0 Then
                    If dgvPuntoDia.RowCount = 1 Then
                        dgvPuntoDia.Rows(0).Cells(colAsignadoPuntoDia.Name).Value = True
                    ElseIf dgvPuntoDia.RowCount > 1 AndAlso validarPuntoAsignado() = False Then
                        TimerSinPunto.Stop()
                        TimerSinPunto.Tag = "Por favor asigne un punto para " & Row.Cells(0).Value & ", Dia: " & Replace(Col.Name, "Dia", "")
                        TimerSinPunto.Start()
                    End If
                Else
                    'dgvPuntoDia.Rows(comboPuntoServicio.SelectedValue).Cells(colAsignadoPuntoDia.Name).Value = True
                End If
            Else
                dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Nothing
                id_empdtHorario = dgvHorario.Rows(e.RowIndex).Cells(2).Value.ToString
                Dim fila As DataRow = objHorario.dtDetallePunto.Select("ID_EMPLEADO='" & id_empdtHorario & "'")(0)
                Dim PuntoEmpl = objHorario.dtDetallePunto.Rows.IndexOf(fila)
                Dim Dia As Integer = Replace(Col.Name, "Dia", "")
                Dim fecha As String = Dia.ToString("00") & dateFechaHorario.Value.ToString("/MM/yyyy")
                crow = objHorario.dtEliminarPunto.Rows.Count
                objHorario.dtEliminarPunto.Rows.Add()
                objHorario.dtEliminarPunto.Rows(crow).Item("Codigo_Horario") = Me.txtcodigo.Text
                objHorario.dtEliminarPunto.Rows(crow).Item("Fecha") = fecha
                objHorario.dtEliminarPunto.Rows(crow).Item("id_empleado") = id_empdtHorario
                objHorario.dtEliminarPunto.Rows(crow).Item("Codigo_punto") = objHorario.dtDetallePunto.Rows(PuntoEmpl).Item(e.ColumnIndex - 3)
                objHorario.dtDetallePunto.Rows(PuntoEmpl).Item(e.ColumnIndex - 3) = DBNull.Value
            End If
        End If
    End Sub

    Function calcTiempoTotal(ByRef Row As DataGridViewRow, ByVal pCurrentCol As Integer) As Int64
        Dim total As Int64 = 0
        Dim vMMDia As Int64 = 0
        For Each Cell As DataGridViewCell In Row.Cells
            Dim indexCol = Cell.ColumnIndex
            Dim Col = dgvHorario.Columns(indexCol)
            Dim vSimbolo = Cell.Value.ToString.Trim.ToUpper
            If Col.Visible AndAlso Col.Name.Contains("Dia") AndAlso vSimbolo <> "" Then
                Dim vConvencionColorMM = buscConvencion(vSimbolo)
                If (vConvencionColorMM.Minutos = -1) Then
                    mostrarInfo("error: no existe la convencion: '" + vSimbolo + "'", Color.White, Color.Tomato)
                    Cell.Value = dthorarioCopia.Rows(Cell.RowIndex).Item(Cell.ColumnIndex)
                Else
                    total += vConvencionColorMM.Minutos
                End If
                Cell.Style.ForeColor = vConvencionColorMM.Color
                If pCurrentCol = indexCol Then vMMDia = vConvencionColorMM.Minutos
            End If
        Next
        Row.Cells(38).Value = total 'minutos programados
        Row.Cells(37).Value = Math.Truncate(Math.Round(total / 60, 1) * 10) / 10 ' horas programadas
        Row.Cells(35).Value = (total / 60 / 12 * 10) / 10 ' turnos programados
        Return pCurrentCol
    End Function
    Sub identificarNovedades()
        Dim conv As String
        'If dgvHorario.RowCount = 0 Then
        '    dgvHorario.DataSource = EnlceDtaHor
        '    EnlceDtaHor.Filter = Nothing
        'End If
        For fila = 0 To objHorario.dtNovedades.Rows.Count - 1
            For columnaactual = 4 To 34
                If objHorario.dtNovedades.Rows(fila).Item(columnaactual - 3).ToString = ConstantesNom.NOVEDAD_HORARIO_INDETERMINADO Then
                    Try
                        Dim cell As New DataGridViewButtonCell

                        If dgvHorario.RowCount >= 0 Then
                            Dim idEmpleado As Integer = objHorario.dtNovedades.Rows(fila).Item(0)
                            Dim filaempleado As Integer
                            For indice = 0 To dgvHorario.RowCount - 1
                                If dgvHorario.Rows(indice).Cells(2).Value = idEmpleado Then
                                    filaempleado = indice
                                    Exit For
                                End If
                            Next
                            conv = dgvHorario.Rows(filaempleado).Cells(columnaactual).Value.ToString
                            If String.IsNullOrEmpty(conv) Then
                                dgvHorario.Rows(filaempleado).Cells(columnaactual) = cell
                                dgvHorario.Rows(filaempleado).Cells(columnaactual).Tag = ConstantesNom.NOVEDAD_HORARIO_INDETERMINADO
                                dgvHorario.Rows(filaempleado).Cells(columnaactual).Value = ""
                            End If
                        End If
                    Catch ex As Exception
                        general.manejoErrores(ex)
                    End Try
                End If
            Next
        Next

    End Sub
    Private Function ind(ByVal text As String) As Integer
        For i = 0 To dgvHorario.Columns.Count - 1
            If "Dia" & text = dgvHorario.Columns(i).DataPropertyName Then
                Return dgvHorario.Columns(i).Index
            End If
        Next
        Return -1
    End Function

    Function buscConvencion(pSimbolo As String) As Horario.ConvencionColorMM
        Dim rConvencionColorMM As New Horario.ConvencionColorMM
        For Each dw As DataRow In dtconvencion.Rows
            If dw.Item("Simbolo").ToString = pSimbolo _
                Then rConvencionColorMM.Minutos = dw.Item("Minutos") : _
                     rConvencionColorMM.Color = Color.FromArgb(dw.Item("Simbolo_Color")) : _
                Return rConvencionColorMM
        Next
        rConvencionColorMM.Minutos = -1 : rConvencionColorMM.Color = Color.Empty
        Return rConvencionColorMM
    End Function

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

    Function validarPuntoAsignado() As Boolean
        For Each Row As DataGridViewRow In dgvPuntoDia.Rows
            If Row.Cells(colAsignadoPuntoDia.Name).Value = True Then Return True
        Next
        Return False
    End Function

    Private Sub TimerSinPunto_Tick(sender As Object, e As EventArgs) Handles TimerSinPunto.Tick
        TimerSinPunto.Stop()
        If dgvPuntoDia.ContainsFocus Then Return
        mostrarInfo(TimerSinPunto.Tag, Color.Black, SystemColors.Info)
    End Sub

    Sub mostrarInfo(pSmg As String, pColorFuenteLetra As Color, pColorFondoPanel As Color)
        lbinfo.Text = pSmg.ToUpper : lbinfo.ForeColor = pColorFuenteLetra : PictureBox2.Image = My.Resources.info
        TimerOcultarInfo.Stop() : PnlInfo.BackColor = pColorFondoPanel : PnlInfo.BringToFront() : PnlInfo.Visible = True
        '  System.Media.SystemSounds.Asterisk.Play()
        TimerOcultarInfo.Start()
    End Sub

    Private Sub TimerOcultarInfo_Tick(sender As Object, e As EventArgs) Handles TimerOcultarInfo.Tick
        TimerOcultarInfo.Stop() : PnlInfo.Visible = False : lbinfo.Text = ""
    End Sub

    Private Sub dgvHorario_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvHorario.EditingControlShowing
        RemoveHandler e.Control.KeyPress, AddressOf Cell_KeyPress
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

    End Sub

    Private Sub EnlceDtaHor_ListChanged(sender As Object, e As System.ComponentModel.ListChangedEventArgs) Handles EnlceDtaHor.ListChanged
        Dim NumEmp = EnlceDtaHor.Count
        If (NumEmp > 0) Then : lbEmpleados.Text = String.Format(NumEmpleados, NumEmp) : ToolStripSeparator10.Visible = True
        Else : lbEmpleados.Text = "" : ToolStripSeparator10.Visible = False
        End If
    End Sub

    Private Sub dgvPuntoDia_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPuntoDia.CellClick
        'TimerFocodgvHorario.Stop()
        'TimerFocodgvHorario.Start()
        Try
            Dim idEmpleado As Integer

            idEmpleado = dgvHorario.CurrentRow.Cells(2).Value
            Dim Columnaempleadoa As Integer = dgvHorario.CurrentCell.ColumnIndex
            Dim filaEmpleadoDgv As Integer = dgvHorario.CurrentCell.RowIndex
            If String.IsNullOrEmpty(dgvHorario.Rows(filaEmpleadoDgv).Cells(Columnaempleadoa).Value.ToString) OrElse Columnaempleadoa < 4 OrElse dgvPuntoDia.ReadOnly = True Then
                Exit Sub
            End If
            Dim filaempleado As Integer

            If objHorario.dtDetallePunto.Rows.Count > 0 Then
                For indice = 0 To objHorario.dtDetallePunto.Rows.Count - 1
                    If objHorario.dtDetallePunto.Rows(indice).Item("Id_empleado") = idEmpleado Then
                        filaempleado = indice
                        objHorario.dtDetallePunto.Rows(filaempleado).Item(Columnaempleadoa - 3) = dgvPuntoDia.CurrentRow.Cells(4).Value
                    End If
                Next


            End If

            Dim nuevafila = dttempopunto.NewRow
            Dim bndaux As Integer = 0
            If dttempopunto.Rows.Count > 0 Then
                For indice = 0 To dttempopunto.Rows.Count - 1
                    If dttempopunto.Rows(indice).Item("Id_empleado") = idEmpleado And dttempopunto.Rows(indice).Item("dia") = Columnaempleadoa - 3 Then
                        dttempopunto.Rows(indice).Item("Codigo_Punto") = dgvPuntoDia.CurrentRow.Cells(4).Value
                        dttempopunto.Rows(indice).Item("Nombre") = dgvPuntoDia.CurrentRow.Cells(3).Value
                        bndaux = 1
                        Exit For
                    End If
                Next
            End If
            If bndaux = 0 Then
                nuevafila.Item("id_empleado") = idEmpleado
                nuevafila.Item("id_empresa") = SesionActual.idEmpresa
                nuevafila.Item("dia") = Columnaempleadoa - 3
                nuevafila.Item("Codigo_Punto") = dgvPuntoDia.CurrentRow.Cells(4).Value
                nuevafila.Item("Nombre") = dgvPuntoDia.CurrentRow.Cells(3).Value
                nuevafila.Item("Dia_Asignado") = 1
                dttempopunto.Rows.Add(nuevafila)
            End If

        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Sub dgvPuntoDia_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvPuntoDia.CurrentCellDirtyStateChanged
        ' Referenciamos el control DataGridViewCheckBoxCell actual 
        ' 
        Dim cb As DataGridViewCheckBoxCell =
            TryCast(Me.dgvPuntoDia.CurrentCell, DataGridViewCheckBoxCell)

        ' Si es Nothing, abandonamos el procedimiento.
        '
        If (cb Is Nothing) Then Return

        For Each row As DataGridViewRow In dgvPuntoDia.Rows

            ' Si es la fila actual, continuamos el bucle
            If (dgvPuntoDia.CurrentRow Is row) Then Continue For

            ' Desmarcamos la celda tipo DataGridViewCheckBoxCell,
            ' que en el ejemplo se comprende que es la segunda celda.
            '
            Dim checkBox As DataGridViewCheckBoxCell = DirectCast(row.Cells(5), DataGridViewCheckBoxCell)

            checkBox.Value = False

            ' Confirmammos los cambios efectuados en la celda actual 
            ' 
            If dgvPuntoDia.IsCurrentCellDirty Then dgvPuntoDia.CommitEdit(DataGridViewDataErrorContexts.Commit)
            PnlInfo.Visible = False
        Next

    End Sub

    Private Sub TimerFocodgvHorario_Tick(sender As Object, e As EventArgs) Handles TimerFocodgvHorario.Tick
        TimerFocodgvHorario.Stop()
        If dgvPuntoDia.CurrentCell.ColumnIndex = colAsignadoPuntoDia.Index Then dgvHorario.Focus()
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

    Private Sub CopiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiarToolStripMenuItem.Click
        If Not IsNothing(dgvHorario.SelectedCells) Then
            dtcopia.Clear()
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
                dtcopia.Rows.Add(ID, Dia, Cell.Value.ToString, "")
            Next
            dtcopia = dtcopia.Select("", "Dia").CopyToDataTable()
            vDias = vDias.Trim.TrimEnd("|")
            buscarPuntosdelDia(vDias)
            borrarArchivoCopia()
            salvarArchivoCopia()
        End If
    End Sub

    Sub buscarPuntosdelDia(pDias As String)
        Dim vDias As String() = pDias.Split("|")
        Dim vEstadoBusqueda As Integer = 0

        Select Case dtcopia.Rows.Count
            Case 0
                For Each dw1 As DataRow In dtpuntodia.Rows
                    If dw1.Item("Dia_Asignado").ToString = True Then
                        vEstadoBusqueda = 1
                        For Each dw2 As DataRow In dtcopia.Rows
                            Dim vPuntos As String = dw2.Item("Puntos").ToString & "|" & dw1.Item("Codigo_punto").ToString
                            dw2.Item("Puntos") = vPuntos.Trim.TrimStart("|").TrimEnd("|")
                        Next
                    ElseIf vEstadoBusqueda = 1 Then : Exit For
                    End If
                Next
            Case 1
                For Each dw1 As DataRow In dtpuntodia.Rows
                    If dw1.Item("Dia_asignado").ToString = True Then
                        vEstadoBusqueda = 1
                        'Dim Dia = dw1.Item("Dia").ToString
                        'If vDias.Contains(Dia) Then
                        For Each dw2 As DataRow In dtcopia.Rows
                            If dw2.Item("Puntos") = "" Then
                                Dim vPuntos As String = dw2.Item("Puntos").ToString & "|" & dw1.Item("Codigo_punto").ToString
                                dw2.Item("Puntos") = vPuntos.Trim.TrimStart("|").TrimEnd("|")
                            End If
                        Next
                        'End If
                    ElseIf vEstadoBusqueda = 1 Then : Exit For
                    End If
                Next
            Case Else
                For Each dw2 As DataRow In dtcopia.Rows
                    Dim id = dw2.Item("Id_empleado").ToString
                    Dim dia = dw2.Item("dia")
                    Dim CopyPoint = objHorario.dtDetallePunto.Select("Id_empleado='" & id & "'")
                    If dw2.Item("Puntos") = "" Then
                        Dim vPuntos As String = dw2.Item("Puntos").ToString & "|" & CopyPoint(0).Item(dia).ToString
                        dw2.Item("Puntos") = vPuntos.Trim.TrimStart("|").TrimEnd("|")
                    End If
                Next
        End Select
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
            Dim ID = Row.Cells(2).Value.ToString
            vIDs &= ID & "|"
        Next
        Dim arrayIDs = vIDs.Trim.TrimStart("|").TrimEnd("|").Split("|")
        Dim selecCells = dgvHorario.SelectedCells
        Dim UltIndiceDwCell As Integer = If(dtcopia.Rows.Count > selecCells.Count, selecCells.Count, dtcopia.Rows.Count) - 1
        dtpegarpunto.Clear()

        For Each Row As DataGridViewRow In dgvHorario.Rows
            Dim ID = Row.Cells(2).Value.ToString
            Dim indiceDW As Integer = 0

            If arrayIDs.Length = 0 Then : Exit For
            ElseIf arrayIDs.Contains(ID) Then
                For Each Cell As DataGridViewCell In Row.Cells
                    If Cell.Selected Then
                        If indiceDW <= UltIndiceDwCell Then
                            Dim dw = dtcopia.Rows(indiceDW)
                            Dim valor = dw.Item("Valor").ToString
                            Dim puntos = dw.Item("Puntos").ToString
                            Cell.Value = valor
                            Dim Col = dgvHorario.Columns(Cell.ColumnIndex)
                            Dim Dia = Replace(Col.Name, "Dia", "")
                            If Dia < 10 Then Dia = Replace(Col.Name, "Dia0", "")
                            If valor <> "" AndAlso puntos <> "" Then
                                For Each puntoAsignado In puntos.Split("|")
                                    dtpegarpunto.Rows.Add(ID, Dia, puntoAsignado)
                                Next
                            End If
                            indiceDW += 1
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
        Dim ID = Row.Cells(2).Value.ToString
        Dim indiceCol = Cell.ColumnIndex
        Dim indiceDW = 0
        Dim UltIndiceDw = (dtcopia.Rows.Count - 1)
        dtpegarpunto.Clear()

        While (dgvHorario.Columns(indiceCol).Name.Contains("Dia") And indiceDW <= UltIndiceDw)
            If dgvHorario.Columns(indiceCol).Visible = True Then
                Dim dw = dtcopia.Rows(indiceDW)
                Dim valor = dw.Item("Valor").ToString
                Dim puntos = dw.Item("Puntos").ToString
                Row.Cells(indiceCol).Value = valor
                Dim Col = dgvHorario.Columns(indiceCol)
                Dim Dia = Replace(Col.Name, "Dia", "")
                If Dia < 10 Then Dia = Replace(Col.Name, "Dia0", "")
                If valor <> "" AndAlso puntos <> "" Then
                    For Each punto In puntos.Split("|")
                        dtpegarpunto.Rows.Add(ID, Dia, punto)
                    Next
                End If
            End If
            indiceCol += 1 : indiceDW += 1
        End While
        calcTiempoTotal(Row, -1)
        buscarPuntosdeDias()
    End Sub

    Sub buscarPuntosdeDias()
        If cbAceptarCopiarPegar.Checked = False OrElse dtpegarpunto.Rows.Count = 0 Then Return
        For ptem As Integer = 0 To dtpegarpunto.Rows.Count - 1
            Dim nuevafila = dttempopunto.NewRow
            nuevafila.Item("id_empleado") = dtpegarpunto.Rows(ptem).Item("id_empleado").ToString
            nuevafila.Item("id_empresa") = SesionActual.idEmpresa
            nuevafila.Item("dia") = dtpegarpunto.Rows(ptem).Item("dia").ToString
            nuevafila.Item("Codigo_Punto") = dtpegarpunto.Rows(ptem).Item("Punto").ToString
            Dim NombrePunto = dtpuntodia.Select("Codigo_Punto='" & dtpegarpunto.Rows(ptem).Item("Punto").ToString & "'")
            nuevafila.Item("Nombre") = NombrePunto(0)(4)
            nuevafila.Item("Dia_Asignado") = 1
            dttempopunto.Rows.Add(nuevafila)
        Next ptem
        Dim MyView As DataView = New DataView(dttempopunto)
        Dim dtSinDuplicados As DataTable
        dtSinDuplicados = MyView.ToTable(True, "id_empleado", "id_empresa", "dia", "Codigo_punto", "Nombre", "Dia_Asignado")
        dttempopunto = dtSinDuplicados.Copy
        Dim ultDwPunto = (dtpegarpunto.Rows.Count - 1)

        For indicePunto As Integer = 0 To ultDwPunto
            Dim dw = dttempopunto.Rows(indicePunto)
            Dim ID = dw.Item("id_empleado").ToString
            Dim Dia = dw.Item("Dia").ToString
            Dim vStrWhr = String.Format("[id_empleado] = '{0}' AND [Dia] = '{1}'", ID, Dia)
            Dim DwsPegar = dtpegarpunto.Select(vStrWhr, "")
            Dim edpunto = objHorario.dtDetallePunto.Select("id_empleado='" & dtpegarpunto.Rows(indicePunto).Item("id_empleado").ToString & "'")
            Dim rowsIndex = objHorario.dtDetallePunto.Rows.IndexOf(edpunto(0))

            For fila = 0 To dtpuntodia.Rows.Count - 1

                If dtpuntodia.Rows(fila).Item(3).ToString = dtpegarpunto.Rows(indicePunto).Item("Punto").ToString Then
                    Try
                        dtpuntodia.Rows(fila).Item(5) = 1
                        objHorario.dtDetallePunto.Rows(rowsIndex).Item("Dia" & dtpegarpunto.Rows(indicePunto).Item("dia")) = dtpegarpunto.Rows(indicePunto).Item("Punto").ToString
                    Catch ex As Exception
                        general.manejoErrores(ex)
                    End Try
                Else
                    Try
                        dtpuntodia.Rows(fila).Item(5) = 0
                    Catch ex As Exception
                        general.manejoErrores(ex)
                    End Try
                End If
            Next
            'If dtpegarpunto.Rows.Count = 0 Then : Exit For
            'ElseIf DwsPegar.Length <> 0 Then
            '    Dim punto = dw.Item("Codigo_punto").ToString
            '    dw.Item("Dia_Asignado") = False

            '    For indicePegar As Integer = (DwsPegar.Length - 1) To 0 Step -1
            '        Dim _dw = DwsPegar(indicePegar)
            '        If _dw.Item("Punto").ToString = punto Then
            '            dw.Item("Dia_Asignado") = True
            '        End If
            '        If indicePegar = 0 AndAlso indicePunto <> ultDwPunto Then
            '            Dim proxInd = (indicePunto + 1)
            '            Dim proxDw = dtpuntodia.Rows(proxInd)
            '            Dim proxID = proxDw.Item("id_empleado").ToString
            '            Dim proxDia = proxDw.Item("Dia").ToString
            '            If (proxDia <> Dia) OrElse (proxID <> ID) _
            '                Then dtpegarpunto.Rows.Remove(_dw)
            '        End If
            '    Next
            '    dtpegarpunto.AcceptChanges()
            'End If
        Next

    End Sub

    Sub asignarigualpuntosmes()
        Dim puntos As String = ""
        'For Each Row As DataGridViewRow In dgvPuntoDia.Rows
        '    If Row.Cells(colAsignadoPuntoDia.Name).Value = True Then puntos &= Row.Cells(colCodigoPuntoDia.Name).Value.ToString & "|"
        'Next
        Dim arrayPuntos As String() = puntos.Trim.TrimStart("|").TrimEnd("|").Split("|")
        Dim ID = dgvHorario.CurrentRow.Cells(2).Value.ToString
        Dim vEstadoBusqueda As Integer = 0

        For Each dw1 As DataRow In dtpuntodia.Rows
            If dw1.Item("id_empleado").ToString = ID Then
                vEstadoBusqueda = 1
                Dim punto = dw1.Item("Codigo_punto").ToString
                dw1.Item("Dia_Asignado") = arrayPuntos.Contains(punto)
            ElseIf vEstadoBusqueda = 1 Then : Exit For
            End If
        Next
    End Sub

    Private Sub QuitarEmpleadoHelperToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarEmpleadoHelperToolStripMenuItem.Click
        MsgBox("Para poder quitar un empleado presiona clic derecho del mouse sobre el nombre del empleado", MsgBoxStyle.Information, "Atencion")
    End Sub

    Private Sub QuitarEmpleadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarEmpleadoToolStripMenuItem.Click
        Try
            dthorario.AcceptChanges()
            Dim dw = dgvHorario.CurrentRow.DataBoundItem.Row
            dthorario_del.ImportRow(dw)
            dthorario.Rows.Remove(dw)
            dthorario.AcceptChanges()
            colorTodasLasConvenciones()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LinkAsignarIgualTodoElMes_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkAsignarIgualTodoElMes.LinkClicked
        If btcancelar.Enabled AndAlso validarPuntoAsignado() Then
            If MsgBox("Usted va a asignar los mismos puntos de este dia 
                       para todo el resto del mes para el empleado:" &
                       dgvHorario.CurrentRow.Cells(0).Value.ToString + "
                      ¿Desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Atencion") = MsgBoxResult.Ok Then
                asignarigualpuntosmes()
            End If
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        txtBuscar.Text = ""
    End Sub

    Private Sub btAceptaCopiarPegar_Click(sender As Object, e As EventArgs) Handles btAceptaCopiarPegar.Click
        If cbAceptarCopiarPegar.Enabled Then cbAceptarCopiarPegar.Checked = Not cbAceptarCopiarPegar.Checked
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        ContextMenuStrip1.Items.Clear()
        If btcancelar.Enabled AndAlso dgvHorario.CurrentCell IsNot Nothing Then
            Dim Cell = dgvHorario.CurrentCell
            Dim Col = dgvHorario.Columns(Cell.ColumnIndex)

            If Col.Index = 0 Then
                ContextMenuStrip1.Items.Add(QuitarEmpleadoToolStripMenuItem)
            ElseIf Col.Name.Contains("Dia") Then
                validarCeldasSeleccionadas()
                If (Not IsNothing(dgvHorario.SelectedCells) AndAlso (dgvHorario.SelectedCells.Count > 1)) Then
                    CopiarToolStripMenuItem.Text = "Copiar Seleccion"
                    PegarToolStripMenuItem.Text = "Pegar Sobre Seleccionados"
                Else
                    CopiarToolStripMenuItem.Text = "Copiar"
                    PegarToolStripMenuItem.Text = "Pegar"
                End If
                ContextMenuStrip1.Items.Add(CopiarToolStripMenuItem)
                cargarArchivoCopia()
                If dtcopia.Rows.Count > 0 Then ContextMenuStrip1.Items.Add(PegarToolStripMenuItem)
                ContextMenuStrip1.Items.Add(ToolStripSeparator9)
                ContextMenuStrip1.Items.Add(QuitarEmpleadoHelperToolStripMenuItem)
            End If
        End If
        e.Cancel = Not (ContextMenuStrip1.Items.Count > 0)
    End Sub

    Private Sub comboPuntoServicio_SelectedValueChanged(sender As Object, e As EventArgs) Handles comboPuntoServicio.SelectedValueChanged
        If btguardar.Enabled = True Then
            If Not IsNumeric(comboPuntoServicio.SelectedValue) Then
                Exit Sub
            End If
            filtrar_dgvhorario()
            Exit Sub
        End If
        If String.IsNullOrEmpty(comboPuntoServicio.ValueMember) = False Then
            objHorario.puntoE = comboPuntoServicio.SelectedValue
        End If
        If FocoCombo Or enLoad Or AgregandoEmpleados Then Return
        If String.IsNullOrEmpty(Me.txtcodigo.Text) = False Then cargarXpunto(Me.txtcodigo.Text)
        listar_empleados_visibles()
        Cadena = ConsultasNom.LISTA_NOMINA_AREA & objHorario.puntoE
        cargarCombos(Cadena, sender.DisplayMember, sender.ValueMember, comboAreaServicio, "- - - Todas las Areas- - -")
        'EnlceDtaHor.Filter = "1=2"
        TimerFiltrar.Stop()
        TimerFiltrar.Start()
        identificarNovedades()
        colorTodasLasConvenciones()
    End Sub

    Private Sub comboCargo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboCargo.SelectedIndexChanged
        If btguardar.Enabled = True Then
            If Not IsNumeric(comboCargo.SelectedValue) Then
                Exit Sub
            End If
            filtrar_dgvhorario()
            objHorario.cargarNovedades()
            identificarNovedades()
            colorTodasLasConvenciones()
            Exit Sub
        End If
        If String.IsNullOrEmpty(comboPuntoServicio.ValueMember) = False Then
            objHorario.puntoE = comboPuntoServicio.SelectedValue
        End If
        If FocoCombo Or enLoad Or AgregandoEmpleados Then Return
        If String.IsNullOrEmpty(Me.txtcodigo.Text) = False Then cargarXpunto(Me.txtcodigo.Text)
        'EnlceDtaHor.Filter = "1=2"
        TimerFiltrar.Stop()
        TimerFiltrar.Start()
        If btguardar.Enabled = True Then btanular.Enabled = False
        identificarNovedades()
        colorTodasLasConvenciones()
    End Sub

    Private Sub comboAreaServicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboAreaServicio.SelectedIndexChanged
        If btguardar.Enabled = True Then
            If Not IsNumeric(comboAreaServicio.SelectedValue) Then
                Exit Sub
            End If
            filtrar_dgvhorario()
            objHorario.cargarNovedades()
            identificarNovedades()
            colorTodasLasConvenciones()
            Exit Sub
        End If
        If String.IsNullOrEmpty(comboPuntoServicio.ValueMember) = False Then
            objHorario.puntoE = comboPuntoServicio.SelectedValue
        End If
        If FocoCombo Or enLoad Or AgregandoEmpleados Then Return
        If String.IsNullOrEmpty(Me.txtcodigo.Text) = False Then cargarXpunto(Me.txtcodigo.Text)
        'EnlceDtaHor.Filter = "1=2"
        TimerFiltrar.Stop()
        TimerFiltrar.Start()
        identificarNovedades()
        colorTodasLasConvenciones()
    End Sub

    Private Sub comboPuntoServicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboPuntoServicio.SelectedIndexChanged

    End Sub

    Private Sub comboAreaServicio_SelectedValueChanged(sender As Object, e As EventArgs) Handles comboAreaServicio.SelectedValueChanged
        FocoCombo = True
        Dim cadena As String = ""
        If dgvHorario.RowCount > 0 Then
            listar_empleados_visibles()
            cadena = ConsultasNom.LISTA_NOMINA_CARGO & comboAreaServicio.SelectedValue.ToString
        Else
            cadena = cadenaZero
        End If
        cargarCombos(cadena, sender.DisplayMember, sender.ValueMember, comboCargo, "- - - Todos los Cargos- - -")
        FocoCombo = False
    End Sub

    Private Sub Form_Horarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub comboAreaServicio_Enter(sender As Object, e As EventArgs) Handles comboAreaServicio.Enter
        'FocoCombo = True
        'Dim cadena As String = ""
        'If dgvHorario.RowCount > 0 Then
        '    listar_empleados_visibles()
        '    cadena = ConsultasNom.LISTA_NOMINA_AREA & objHorario.puntoE
        'Else
        '    cadena = cadenaZero
        'End If
        'cargarCombos(cadena, sender.DisplayMember, sender.ValueMember, comboAreaServicio, "- - - Todas las Areas- - -")
        'FocoCombo = False
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
            If btnuevo.Enabled Then
                MsgBox("Actualmente el formulario de horario no se encuentra en modo operacional (Editando/Creando Horario)", 48, "Atencion")
            Else
                objHorario.ColDia = Replace(dgvHorario.Columns(e.ColumnIndex).Name, "Dia", "")
                dia = Strings.Right(dgvHorario.Columns(e.ColumnIndex).Name, 2)
                set_determinado(dgvHorario.Rows(e.RowIndex).Cells(2).Value, e.RowIndex, e.ColumnIndex, dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag, dia)
            End If
        End If
    End Sub

    Private Sub set_determinado(ByVal cedula As String, filas As Int32, columnas As Int32, convAnt As String, Dia As String)
        Dim Form_Determinar As New Form_Determinar()
        Dim dw_novedad As DataRow() = dthorario_del.Select("Cedula1_Empleado1='" & cedula & "'and Dia='" & Dia & "'", "")
        If dw_novedad.Count = 0 Then Exit Sub
        Dim fila As DataRow = dw_novedad(0)
        Dim indiceFila As Integer = dthorario_del.Rows.IndexOf(fila)

        Form_Determinar.comboconvencion.DataSource = dtconvencion
        Form_Determinar.comboconvencion.DisplayMember = "Simbolo"
        Form_Determinar.comboconvencion.ValueMember = "Nombre"
        Form_Determinar.datetimeEntrada.Value = dthorario_del.Rows(indiceFila).Item(5)
        If IsDBNull(dthorario_del.Rows(indiceFila).Item(6)) Then
            Form_Determinar.datetimeSalida.Format = 8
            Form_Determinar.datetimeSalida.CustomFormat = " "
        Else
            Form_Determinar.datetimeSalida.Value = dthorario_del.Rows(indiceFila).Item(6)
        End If
        Select Case Form_Determinar.ShowDialog()'actualiza y guarda la convencion
            Case Windows.Forms.DialogResult.OK
                Dim id As String = dw_novedad(0).Item("Cedula1_Empleado1")
                Dim turno As String = Form_Determinar.comboconvencion.Text
                Dim fecha As String = Form_Determinar.datetimeEntrada.Value.ToString("yyyy-MM-dd")
                objHorario.codigo = txtcodigo.Text
                objHorario.ConvencionAnt = convAnt
                objHorario.ConvencionNue = Strings.Left(turno, 2)
                objHorario.fechaNovedad = fecha
                objHorario.Id_Empleado = id
                Dim cell As New DataGridViewTextBoxCell
                dgvHorario.Rows(filas).Cells(columnas) = cell
                dgvHorario.Rows(filas).Cells(columnas).Value = objHorario.ConvencionNue
                dgvHorario.Rows(filas).Cells(columnas).Style.BackColor = Color.Yellow
                colorTodasLasConvenciones()
            Case Windows.Forms.DialogResult.Retry 'elimina la convencion
            Case Else
        End Select
    End Sub

    Private Sub dgvHorario_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvHorario.CellFormatting
        Dim Puntos As String
        If Me.txtcodigo.Text = "" Then Exit Sub
        If e.RowIndex <= (objHorario.dtNovedades.Rows.Count - 1) Then
            If e.ColumnIndex = 35 Then
                e.CellStyle.Format = "00"
            End If
            If e.ColumnIndex >= 4 AndAlso e.ColumnIndex <= 34 Then
                If String.IsNullOrEmpty(dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString) = False And dgvHorario.Rows(e.RowIndex).Cells(2).Value = objHorario.dtNovedades.Rows(e.RowIndex).Item(0).ToString Then
                    Try
                        Dim datemp As New Date

                        Dim Dia As Integer = Replace(dgvHorario.Columns(e.ColumnIndex).Name, "Dia", "")
                        Dim FechaActual As String = DateTime.Now.ToString("dd/MM/yyyy")
                        datemp = Dia.ToString("00") & dateFechaHorario.Value.ToString("/MM/yyyy")

                        Dim idEmpleado As Integer = objHorario.dtNovedades.Rows(e.RowIndex).Item(0)
                        Dim filaempleado As Integer
                        For indice = 0 To dgvHorario.RowCount - 1
                            If dgvHorario.Rows(indice).Cells(2).Value = idEmpleado Then
                                filaempleado = indice
                                Exit For
                            End If
                        Next
                        If objHorario.dtNovedades.Rows(e.RowIndex).Item(e.ColumnIndex - 3).ToString = ConstantesNom.NOVEDAD_AUSENCIA_LABORAL And dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).Value <> "D" Then
                            If datemp < FechaActual Then
                                dgvHorario.Rows(filaempleado).Cells(e.ColumnIndex).Style.BackColor = Color.Tomato
                            End If
                        ElseIf objHorario.dtNovedades.Rows(e.RowIndex).Item(e.ColumnIndex - 3).ToString = ConstantesNom.NOVEDAD_DIA_LABORADO_SIN_TURNO Then
                            dgvHorario.Rows(filaempleado).Cells(e.ColumnIndex).Style.BackColor = Color.Yellow
                        ElseIf objHorario.dtNovedades.Rows(e.RowIndex).Item(e.ColumnIndex - 3).ToString = ConstantesNom.NOVEDAD_CAMBIO_TURNO Then
                            dgvHorario.Rows(filaempleado).Cells(e.ColumnIndex).Style.BackColor = Color.MediumVioletRed
                        End If
                    Catch ex As Exception
                        general.manejoErrores(ex)
                    End Try
                End If
                If comboPuntoServicio.SelectedValue = -1 OrElse objHorario.dtDetallePunto.Rows.Count = 0 Then Exit Sub
                Puntos = objHorario.dtDetallePunto.Rows(e.RowIndex).Item(e.ColumnIndex - 3).ToString
                If Puntos <> comboPuntoServicio.SelectedValue And String.IsNullOrEmpty(Puntos) = False Then
                    'If PnlInfo.Visible = False Then
                    dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
                    'End If
                    e.CellStyle.BackColor = Color.LightGray
                    e.CellStyle.ForeColor = Color.Gray
                Else
                    If dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True Then
                        dgvHorario.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
                    End If
                End If
            End If
        End If
    End Sub

    Sub validarCeldasSeleccionadas()
        If (Not IsNothing(dgvHorario.SelectedCells) AndAlso (dgvHorario.SelectedCells.Count > 1)) Then
            For Each Cell As DataGridViewCell In dgvHorario.SelectedCells
                Dim Col = dgvHorario.Columns(Cell.ColumnIndex)
                If Not Col.Name.Contains("Dia") Then Cell.Selected = False
            Next
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

    Sub buildTerceros()
        Terceros = "''"
        For Each dw As DataRow In dthorario.Rows
            Try
                Terceros &= String.Format(",'{0}'", dw.Item("Id_tercero").ToString)
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub comboPuntoServicio_Enter(sender As Object, e As EventArgs) Handles comboPuntoServicio.Enter
        'FocoCombo = True
        'Dim selValor = sender.SelectedValue
        'Dim cadena As String = ""
        'If dgvHorario.RowCount > 0 Then
        '    cadena = ConsultasNom.LISTA_NOMINA_PUNTOS & SesionActual.idEmpresa
        'Else
        '    cadena = cadenaZero
        'End If
        'cargarCombos(cadena, sender.DisplayMember, sender.ValueMember, comboPuntoServicio, "- - - Todos los Puntos- - -")
        'If selValor IsNot Nothing Then sender.SelectedValue = selValor
        'FocoCombo = False
    End Sub

    Sub cargarCombos(ByVal cadena As String, ByVal vlrDisplayMember As String, vlrValueMember As String, ByVal nmbreCombo As Object, ByVal CadenaDisplay As String)
        General.cargarCombo(cadena, vlrDisplayMember, vlrValueMember, nmbreCombo)

        If vlrDisplayMember <> "" Then
            nmbreCombo.DataSource.Rows(0).Item(vlrDisplayMember) = CadenaDisplay
        End If
    End Sub

    Private Sub TimerFiltrar_Tick(sender As Object, e As EventArgs) Handles TimerFiltrar.Tick
        TimerFiltrar.Stop()
        filtrar_dgvhorario()
    End Sub

    Sub filtrar_dgvhorario()
        If Terceros Is Nothing Then Terceros = "''"
        Dim cadena = "PROC_HORARIO_FILTRO_TERCERO"
        Dim params As New List(Of String)
        Dim tercero2 As String
        tercero2 = Replace(Replace(Terceros, "''", "'-1'"), "'", "")
        params.Add(SesionActual.idEmpresa)
        params.Add(tercero2)
        params.Add(comboPuntoServicio.SelectedValue)
        params.Add(comboAreaServicio.SelectedValue)
        params.Add(comboCargo.SelectedValue)
        Dim dtTerceros As New DataTable()   ' objHorarios_D.filtrardgvHorario(cadena)
        General.llenarTabla(cadena, params, dtTerceros)
        Dim filtroTerceros As String = "''"
        For Each dw As DataRow In dtTerceros.Rows
            filtroTerceros &= String.Format(",'{0}'", dw.Item("Id_Tercero").ToString)
        Next
        EnlceDtaHor.Filter = "[Id_Tercero] IN (" & filtroTerceros & ")"
        dgvHorario.DataSource = EnlceDtaHor.DataSource
        objHorario.Terceros = Strings.Replace(filtroTerceros, "','", "-")
        objHorario.Terceros = Strings.Replace(objHorario.Terceros, "'", "")
        colorTodasLasConvenciones()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        If txtBuscar.Text.Trim = "" Then
            dgvHorario.ClearSelection()
            PictureBox3.Visible = False
            Return
        Else
            PictureBox3.Image = My.Resources.borrartxt
            PictureBox3.Visible = True
        End If
        txtBusCambia = True
        buscar()
    End Sub

    Private Sub txtBuscar_ReadOnlyChanged(sender As Object, e As EventArgs) Handles txtBuscar.ReadOnlyChanged
        txtBuscar.ReadOnly = False
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyCode = Keys.Enter And Not txtBusCambia And txtBuscar.Text <> "" Then
            Try
                HorIndice = If(dgvHorario.SelectedCells IsNot Nothing, dgvHorario.SelectedCells(0).RowIndex, -1)
            Catch ex As Exception
            End Try

            buscar()
        End If
        txtBusCambia = False
    End Sub

    Sub buscar()
        Dim text As String = txtBuscar.Text.Trim.ToUpper()
        Dim len As Integer = text.Length
        Dim ContSpac = text.Contains(" ")
        For Each row As DataGridViewRow In dgvHorario.Rows

            For Each cell In {row.Cells(3), row.Cells(0)}
                If validarCoincidencia(cell.Value.ToString(), text, len, ContSpac) And cell.RowIndex > HorIndice Then
                    dgvHorario.ClearSelection()
                    row.Selected = True
                    HorIndice = -1
                    row.Visible = True
                    dgvHorario.CurrentCell = dgvHorario.Rows(row.Index).Cells(0)
                    Return
                End If
            Next
        Next
        If HorIndice > -1 Then
            HorIndice = -1
            buscar()
        Else
            dgvHorario.ClearSelection()
        End If
    End Sub

    Function validarCoincidencia(pA As String, pB As String, pBlen As Integer, pBspc As Boolean) As Boolean
        If String.Equals(Strings.Left(pA, pBlen), pB, 5) OrElse (pBspc AndAlso pA.Contains(pB)) Then Return True
        For Each Sil In pA.Split(" ")
            If String.Equals(Strings.Left(Sil, pBlen), pB, 5) Then
                Return True
            End If
        Next
        Return False
    End Function

    Sub listar_empleados_visibles()
        TercerosVisibles = "''"
        For Each Row As DataGridViewRow In dgvHorario.Rows
            Try
                TercerosVisibles &= String.Format(",'{0}'", Row.Cells(2).Value.ToString)
            Catch ex As Exception
            End Try
        Next
    End Sub

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
            Dim horario As New Horario
            dgvHorario.EndEdit()
            dthorario.AcceptChanges()
            objHorario.dtPuntoDias.AcceptChanges()
            objHorario.dtEliminarPunto.AcceptChanges()
            'horario = objHorario
            horario.codigo = txtcodigo.Text
            horario.fecha = vFecha
            horario.empresa = SesionActual.idEmpresa
            horario.punto = SesionActual.codigoEP
            horario.usuario = SesionActual.idUsuario
            horario.descripcion = GroupBox6.Text.Replace(":", "")
            If objHorarios_D.validarmes(horario) Then
                MsgBox("¡ Ya existe un Cuadro de Turnos Para este mes de este año !", MsgBoxStyle.Exclamation)
            Else
                Dim con As Integer = 0

                For Each dw As DataRow In dthorario.Rows
                    If String.IsNullOrEmpty(dw.Item("Turnos").ToString) = False Then
                        If dw.Item("Turnos").ToString <> 0 Then
                            dw.Item("Anulado") = False
                        End If
                    End If
                    horario.agregarDetalle(dw)
                Next

                For Each dw As DataRow In dttempopunto.Rows
                    horario.agregarPuntoDias(dw)
                Next

                horario.dtDetallePunto = objHorario.dtDetallePunto.Copy
                horario.dtEliminarPunto = objHorario.dtEliminarPunto.Copy
                comboPuntoServicio.SelectedIndex = 0
                comboAreaServicio.SelectedIndex = 0
                comboCargo.SelectedIndex = 0
                Dim mensaje As String = ""
                For filaAux = 0 To horario.dtDetalle.Rows.Count - 1
                    For columnaAux = 2 To 32

                        If String.IsNullOrEmpty(horario.dtDetalle.Rows(filaAux).Item(columnaAux).ToString) = False AndAlso
                                                        horario.dtDetalle.Rows(filaAux).Item(columnaAux).ToString <> "D" Then
                            Dim dia As String = ""
                            dia = columnaAux - 1
                            Dim CANTIDAD As Integer
                            CANTIDAD = horario.dtDetallePunto.Select("id_empleado=" & horario.dtDetalle.Rows(filaAux).Item(1) & " and (CONVERT(Dia" & dia & ",'System.String')='' or Dia" & dia & " is null)", "").Count
                            If CANTIDAD > 0 Then
                                If String.IsNullOrEmpty(mensaje) Then
                                    mensaje = "¡Existen convenciones sin punto asignado, por favor seleccione el punto.!" & vbCrLf & "Empleado:  " &
                                                nombreEmpleado(horario.dtDetalle.Rows(filaAux).Item(1).ToString) & ", dia: " & columnaAux - 1
                                Else
                                    mensaje = mensaje & vbCrLf & "Empleado: " & nombreEmpleado(horario.dtDetalle.Rows(filaAux).Item(1).ToString) & ", dia: " & columnaAux - 1
                                End If
                            End If
                        End If
                    Next
                Next
                If Not String.IsNullOrEmpty(mensaje) Then
                    MsgBox(mensaje, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    If horario.dtDetalle.Rows.Count > 0 Then
                        If objHorarios_D.guardar(horario) = True Then
                            txtcodigo.Text = horario.codigo
                            MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                            General.deshabilitarControles(Me)
                            General.habilitarBotones(Me.ToolStrip1)
                            horario.dtEliminarPunto.Clear
                            btguardar.Enabled = False
                            btcancelar.Enabled = False
                            cargar(Me.txtcodigo.Text)
                        End If
                    Else
                        MsgBox("El Horario no tiene convenciones asignada", MsgBoxStyle.Exclamation)
                    End If
                End If
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Function nombreEmpleado(idEmpleado) As String
        For indice = 0 To dgvHorario.RowCount - 1
            If dgvHorario.Rows(indice).Cells(2).Value = idEmpleado Then
                Return dgvHorario.Rows(indice).Cells(0).Value
            End If
        Next
    End Function


    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Try
            If SesionActual.tienePermiso(Panular) Then
                Dim FechaActual As String = DateTime.Now.ToString("dd/MM/yyyy")
                If FechaActual > CDate(Me.dateFechaHorario.Value) Then
                    MsgBox("El Horario no se puede Anular")
                Else
                    If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                        If General.anularRegistro(Consultas.HORARIO_ANULAR & txtcodigo.Text & ", " & SesionActual.idUsuario) = True Then
                            objHorario.opcionCancelar = True
                            General.limpiarControles(Me)
                            General.deshabilitarControles(Me)
                            General.deshabilitarBotones(ToolStrip1)
                            btnuevo.Enabled = True
                            btbuscar.Enabled = True
                            MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                        End If
                    End If
                End If
            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)(New String() {SesionActual.codigoEP,
                                                            SesionActual.idEmpresa,
                                                            String.Empty})
            General.buscarElemento(Consultas.BUSQUEDA_HORARIO,
                                   params,
                                   AddressOf cargar,
                                   TitulosForm.BUSQUEDA_HORARIO,
                                   False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If txtcodigo.Text = "" Then btimprimir.Enabled = False : Return
        listar_empleados_visibles()
        Dim rptHorario1 As New rptHorario()
        rptHorario1.SetParameterValue("@Codigo", txtcodigo.Text)
        rptHorario1.SetParameterValue("@Terceros", TercerosVisibles.Replace("'", ""))
        rptHorario1.SetParameterValue("@Usuario", SesionActual.idUsuario)
        rptHorario1.SetParameterValue("Npunto", comboPuntoServicio.Text)
        rptHorario1.SetParameterValue("Narea", comboAreaServicio.Text)
        rptHorario1.SetParameterValue("Ncargo", comboCargo.Text)
        Exec.getReport(rptHorario1, Nothing, "Horario")
    End Sub

    Public Sub cargar(pCodigo As String)
        Dim params As New List(Of String)
        Cargando = True
        objHorario.opcionCancelar = False
        dgvHorario.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        dgvHorario.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        dgvHorario.AlternatingRowsDefaultCellStyle.BackColor = Color.White : dgvHorario.GridColor = Color.FromArgb(224, 224, 224) : dgvHorario.DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255) : dgvHorario.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical
        objHorario.codigo = pCodigo
        objHorario.cargarHorario()
        buildTerceros()
        txtcodigo.Text = pCodigo
        dateFechaHorario.Value = dtinfohor.Rows(0).Item("Fecha_Horario")
        objHorario.fechaInicio = Exec.primerDiaMes(dateFechaHorario.Value)
        objHorario.fechaFin = Exec.ultimoDiaMes(dateFechaHorario.Value)
        objHorario.cargarFestivosMes()
        dgvHorario.CurrentCell = Nothing : dgvHorario.ClearSelection()
        Cargando = False
        dateFechaHorario_ValueChanged(Nothing, Nothing)
        comboPuntoServicio.Enabled = True : comboAreaServicio.Enabled = True : comboCargo.Enabled = True
        comboPuntoServicio.SelectedIndex = 0 : comboAreaServicio.SelectedIndex = 0 : comboCargo.SelectedIndex = 0
        EnlceDtaHor.Filter = ""
        objHorarios_D.llenarTablaPunto(dtpuntodia, dtpuntodia_aux, Terceros, txtcodigo.Text)
        EnlceDtaPuntoDia.DataSource = dtpuntodia
        dgvPuntoDia.DataSource = EnlceDtaPuntoDia.DataSource
        identificarNovedades()
        colorTodasLasConvenciones()
        dgvHorario.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7)
        filtrar_dgvhorario()
        objHorario.cargarNovedades()
        params.Add(pCodigo)
        General.llenarTabla(Consultas.HORARIOPUNTOASIGNADO_CARGAR, params, objHorario.dtDetallePunto)
        bteditar.Enabled = True
        btcancelar.Enabled = False
        btanular.Enabled = True
        dttempopunto.Clear()
    End Sub

    Public Sub cargarXpunto(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        'If btguardar.Enabled = True Then Exit Sub

        General.llenarTabla(Consultas.HORARIOPUNTOASIGNADO_CARGAR, params, objHorario.dtDetallePunto)
        params.Add(objHorario.puntoE)
        Cargando = True
        If comboCargo.SelectedValue = -1 Then
            If objHorario.puntoE = -1 Then
                cargar(pCodigo)
            Else
                General.llenarTabla(Consultas.HORARIOPUNTO_CARGAR, params, dthorario)
            End If
        End If
        'dgvHorario.DataSource = Nothing
        EnlceDtaHor.DataSource = dthorario
        dgvHorario.DataSource = EnlceDtaHor.DataSource

        objHorario.fechaInicio = Exec.primerDiaMes(dateFechaHorario.Value)
        objHorario.fechaFin = Exec.ultimoDiaMes(dateFechaHorario.Value)
        objHorario.cargarFestivosMes()
        buildTerceros()
        txtcodigo.Text = pCodigo
        dgvHorario.CurrentCell = Nothing : dgvHorario.ClearSelection()
        btanular.Enabled = True
        Cargando = False
        dateFechaHorario_ValueChanged(Nothing, Nothing)
        dgvHorario.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7)
        filtrar_dgvhorario()
        objHorario.cargarNovedades()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub
End Class