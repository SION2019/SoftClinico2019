
Public Class Form_Pemisos
    Dim enLoad, Cargando, btnuevo1, menuDate, Canselando, txtBusCambia As Boolean
    Dim dateFechaPermisoTrc As DateTime
    Dim objPermiso_D As New PermisoLaboralBLL
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, PPermisoEspecial, PAsignarPermisosPropio As String
    Dim dtPermiso, dtconvencion, dttipo, dtinfoper, dtmesper, dtPE As New DataTable
    Dim Terceros, TercerosVisibles, NumEmpleados As String
    Dim HorIndice As Integer
    Dim simbTurno, simbPermiso, simbNope, simbPE As SimbPerEstado
    Dim ds As New DataSet
    Dim actualPermiso As Permiso
    Dim objPermiso As New Permiso
    Dim diccPermisos As New Dictionary(Of String, Permiso)
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private WithEvents timerRuedaFecha As New Timer() With {.Interval = 245}

    Private Sub Form_Pemisos_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        enLoad = True
        simbolizar()
        iniciar_permisos()
        General.deshabilitarControles(Me)
        General.deshabilitarBotones(ToolStrip1)
        ' dateFechaPermiso.Enabled = True
        iniciar_dgvPermiso()
        objPermiso_D.enlazarTablaInfoPermiso(dtinfoper)
        objPermiso_D.enlazarTablaMesPer(dtmesper)
        objPermiso_D.enlazarDataSet(ds, dtPermiso, dtinfoper, dtmesper, dtPE)
        cargar_convenciones()
        cargar_tpermisos()
        SiglaDias()
        cargarEmp()
        EnlceDtaPer.DataSource = dtPermiso
        dgvPermiso.DataSource = EnlceDtaPer.DataSource
        colorTodasLasConvenciones()
        bteditar.Enabled = True
        btbuscar.Enabled = True
        btcancelar.Enabled = False
        enLoad = False
    End Sub

    Sub colorTodasLasConvenciones()
        For Each Row As DataGridViewRow In dgvPermiso.Rows
            For Each Cell In Row.Cells
                Dim indexCol = Cell.ColumnIndex
                Dim Col = dgvPermiso.Columns(indexCol)
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
        For Each dw As DataRow In dtconvencion.Rows
            If dw.Item("Simbolo").ToString = pSimbolo _
                Then rConvencionColorMM.Minutos = dw.Item("Minutos") : _
                     rConvencionColorMM.Color = Color.FromArgb(dw.Item("Simbolo_Color")) : _
                Return rConvencionColorMM
        Next
        rConvencionColorMM.Minutos = -1 : rConvencionColorMM.Color = Color.Empty
        Return rConvencionColorMM
    End Function
    Sub simbolizar()
        simbTurno = New SimbPerEstado("    ", My.Resources.eye_icon)
        simbPermiso = New SimbPerEstado("    ", My.Resources.OK)
        simbNope = New SimbPerEstado("    ", My.Resources.nuls, (55 - 1 - 16) / 2)
        simbPE = New SimbPerEstado("   ", My.Resources.pe, (40 - 1 - 16) / 2)
    End Sub
    Sub iniciar_permisos()
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        PPermisoEspecial = permiso_general & "pp" & "05"
        PAsignarPermisosPropio = permiso_general & "pp" & "06"
    End Sub
    Sub iniciar_dgvPermiso()
        lbEmpleados.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9, FontStyle.Bold)
        NumEmpleados = "   Empleados:  {0}   "
        dgvPermiso.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        dgvPermiso.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        dgvPermiso.AlternatingRowsDefaultCellStyle.BackColor = Color.White : dgvPermiso.GridColor = Color.FromArgb(224, 224, 224) : dgvPermiso.DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255) : dgvPermiso.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical : colPermisoEspecial.Width = 40 : colPermisoEspecial.Frozen = False : colPermisoEspecial.Visible = True : colPermisoEspecial.DisplayIndex = colDia31.DisplayIndex
        For Each Col As DataGridViewColumn In dgvPermiso.Columns
            If Col.Index <> 0 Then Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter : _
            If Col.Name.Contains("Dia") Then Col.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7, FontStyle.Regular)
            Col.SortMode = DataGridViewColumnSortMode.NotSortable
            If Col.Index >= 6 And Col.Index <= 35 Then dgvPermiso.Columns(Col.Index).Width = 30
        Next
        If SesionActual.tienePermiso(PPermisoEspecial) Then
            dgvPermiso.Columns("colPermisoEspecial").Visible = True
        Else
            dgvPermiso.Columns("colPermisoEspecial").Visible = False
        End If
        dgvPermiso.Columns("colPermisoEspecial").HeaderCell.Style.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 6.5)
        dgvPermiso.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPermiso.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7)
        objPermiso_D.enlazarTablaPerDetalle(dgvPermiso, colNombrePer, colCargoPer, dtPermiso, EnlceDtaPer)
    End Sub
    Sub cargar_convenciones()
        General.llenarTablaYdgv(String.Format(Consultas.CARGAR_CONVENCION, SesionActual.idEmpresa, SesionActual.idUsuario), dtconvencion)
        dtconvencion.PrimaryKey = New DataColumn() {dtconvencion.Columns("key")}
    End Sub
    Sub cargar_tpermisos()
        General.llenarTablaYdgv(String.Format(Consultas.CARGAR_TIPOS_PERMISO, SesionActual.idUsuario, SesionActual.idEmpresa), dttipo)
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            btnuevo1 = True
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            dgvPermiso.ReadOnly = True
            btnuevo1 = False
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
            dgvPermiso.ReadOnly = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub bteditar_EnabledChanged(sender As Object, e As EventArgs) Handles bteditar.EnabledChanged
        btimprimir.Enabled = bteditar.Enabled
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        Canselando = True
        Try
            If General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar) Then
                dateFechaPermiso.Value = dateFechaPermisoTrc
                cargarEmp()
                bteditar.Enabled = True
                btbuscar.Enabled = True
                btcancelar.Enabled = False
                colorTodasLasConvenciones()
            End If
        Finally
            Canselando = False
        End Try
    End Sub

    Private Sub dateFechaPermiso_EnabledChanged(sender As Object, e As EventArgs) Handles dateFechaPermiso.EnabledChanged
        dateFechaPermiso.Enabled = True
    End Sub

    Private Sub dateFechaPermiso_DropDown(sender As Object, e As EventArgs) Handles dateFechaPermiso.DropDown
        menuDate = True
    End Sub

    Private Sub dateFechaPermiso_CloseUp(sender As Object, e As EventArgs) Handles dateFechaPermiso.CloseUp
        menuDate = False
        dateFechaPermiso_ValueChanged(sender, e)
    End Sub

    Private Sub dateFechaPermiso_ValueChanged(sender As Object, e As EventArgs) Handles dateFechaPermiso.ValueChanged
        If Cargando OrElse enLoad OrElse menuDate OrElse Canselando OrElse dateFechaPermisoTrc.ToString("yyyyMM") = dateFechaPermiso.Value.ToString("yyyyMM") Then Return
        dateFechaPermisoTrc = dateFechaPermiso.Value
        objPermiso.fechaInicio = Exec.primerDiaMes(dateFechaPermiso.Value)
        objPermiso.fechaFin = Exec.ultimoDiaMes(dateFechaPermiso.Value)
        objPermiso.cargarFestivosMes()
        SiglaDias()
        cargarEmp()
        colorTodasLasConvenciones()
    End Sub

    Private Sub dateFechaPermiso_MouseWheel(sender As Object, e As MouseEventArgs) Handles dateFechaPermiso.MouseWheel
        timerRuedaFecha.Tag = e.Delta : timerRuedaFecha.Stop() : timerRuedaFecha.Start()
    End Sub

    Private Sub timerRuedaFecha_Tick(sender As Object, e As EventArgs) Handles timerRuedaFecha.Tick
        timerRuedaFecha.Stop()
        dateFechaPermiso.Value = dateFechaPermiso.Value.AddMonths(If(IsNumeric(timerRuedaFecha.Tag) AndAlso timerRuedaFecha.Tag < 0, 1, -1))
    End Sub

    Sub SiglaDias()
        GroupBox6.Text = "Permisos Del Mes De: " &
            StrConv(dateFechaPermiso.Value.ToString("MMMM"), 3)
        Dim datemp As New Date
        Dim Nombre As String = ""
        Dim ultDiaMes = DateTime.DaysInMonth(dateFechaPermiso.Value.Year, dateFechaPermiso.Value.Month)
        For i = 0 To dgvPermiso.Columns.Count - 1
            dgvPermiso.Columns(i).HeaderCell.Style.ForeColor = Color.Black
            If dgvPermiso.Columns(i).Name.Contains("Dia") Then
                Dim Dia As Integer = Replace(dgvPermiso.Columns(i).Name, "colDia", "")
                If Dia > ultDiaMes Then
                    dgvPermiso.Columns(i).Visible = False
                Else
                    dgvPermiso.Columns(i).Visible = True
                    datemp = Dia.ToString("00") & dateFechaPermiso.Value.ToString("/MM/yyyy")
                    Nombre = UCase(Strings.Left(Format(datemp, "dddd"), 2))
                    If Nombre = "SÁ" Then
                        Nombre = "SA"
                    Else
                        If Nombre = "DO" Then
                            dgvPermiso.EnableHeadersVisualStyles = False
                            dgvPermiso.Columns(i).HeaderCell.Style.ForeColor = Color.Red
                        Else
                            Dim busqueda = objPermiso.dtFestivos.Select("DiaF='" & Dia & "'", "")
                            If busqueda.Count > 0 Then
                                dgvPermiso.Columns(i).HeaderCell.Style.ForeColor = Color.Red
                            End If
                        End If
                    End If
                End If
                dgvPermiso.Columns(i).HeaderText = Nombre + vbCrLf + Strings.Right(" " & Dia, 2)
            End If
        Next
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Dim caso1 As Boolean = (dgvPermiso.CurrentCell.Value = simbNope.Valor)
        AsignarPermisoEspecialToolStripMenuItem.Enabled = caso1
        QuitarPermisoEspecialToolStripMenuItem.Enabled = Not caso1
    End Sub

    Private Sub AsignarPermisoEspecialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignarPermisoEspecialToolStripMenuItem.Click
        If MsgBox("¿Desea asignar permiso especial?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If actualPermiso.Enlistado = False Then
                diccPermisos.Add(actualPermiso.key, actualPermiso)
                actualPermiso.Enlistado = True
            ElseIf actualPermiso.EsViejoPE Then
                actualPermiso.Anulado = False
            End If
            actualPermiso.PermisoEspecial = True
            dgvPermiso.CurrentCell.Value = simbPE.Valor
        End If
    End Sub

    Private Sub QuitarPermisoEspecialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarPermisoEspecialToolStripMenuItem.Click
        If actualPermiso IsNot Nothing Then
            If actualPermiso.EsViejoPE = False OrElse MsgBox("¿Desea anular este permiso especial?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If actualPermiso.EsViejoPE Then
                    actualPermiso.Anulado = True
                Else
                    diccPermisos.Remove(actualPermiso.key)
                    actualPermiso.Enlistado = False
                    actualPermiso.PermisoEspecial = False
                End If
                dgvPermiso.CurrentCell.Value = simbNope.Valor
            End If
        End If
    End Sub

    Private Sub MasEmpleadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasEmpleadosToolStripMenuItem.Click
        buildTerceros()
        Dim sql = Consultas.CARGAR_EMPLEADOS_HOR & SesionActual.idEmpresa & ", '" & Terceros & "', '" & dateFechaPermiso.Value.ToString("yyyyMM01") & "'"
        Exec.buscarConOculrEx(sql, AddressOf cargarEmp4PE, TitulosForm.BUSQUEDA_EMPLEADO_HC, {"Id_tercero", "Agregar", "Anulado"}.ToList)
    End Sub

    Private Sub btHacerCuadro_Click(sender As Object, e As EventArgs) Handles btHacerCuadro.Click
        MasEmpleadosToolStripMenuItem_Click(sender, e)
    End Sub

    Sub buildTerceros()
        Terceros = ""
        For Each dw As DataRow In dtPermiso.Rows
            Try
                Terceros &= "," & dw.Item("Id_tercero").ToString
            Catch ex As Exception
            End Try
        Next
        Terceros = Terceros.Trim(",")
    End Sub

    Private Sub dgvPermiso_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvPermiso.CellMouseDown
        If e.RowIndex >= 0 Then
            If SesionActual.tienePermiso(PAsignarPermisosPropio) = False And dgvPermiso.Rows(e.RowIndex).Cells(1).Value = SesionActual.idUsuario Then
                MsgBox("No puede Asignar Permiso a este Usuario", MsgBoxStyle.Exclamation)
            Else
                If e.Button = MouseButtons.Right Then
                    Select Case -1
                        Case e.RowIndex, e.ColumnIndex
                        Case Else
                            dgvPermiso.CurrentCell = dgvPermiso.Rows(e.RowIndex).Cells(e.ColumnIndex)
                            If dgvPermiso.CurrentCell.ColumnIndex > 4 Then
                                trggAccion()
                            End If
                    End Select
                End If
            End If
        End If
    End Sub

    Private Sub dgvPermiso_DoubleClick(sender As Object, e As EventArgs) Handles dgvPermiso.DoubleClick
        If dgvPermiso.CurrentCell.ColumnIndex > 4 Then
            trggAccion()
        End If
    End Sub

    Private Sub trggAccion()
        If dgvPermiso.CurrentCell IsNot Nothing Then _
            If mostrarMenuPermisoEspecial() = False Then AplicarCambioPermiso()
    End Sub

    Private Function mostrarMenuPermisoEspecial() As Boolean
        If btcancelar.Enabled AndAlso dgvPermiso.CurrentCell.OwningColumn.Name = colPermisoEspecial.Name Then _
        ContextMenuStrip1.Show(MousePosition) : Return True Else Return False
    End Function

    Sub AplicarCambioPermiso()
        Dim Cell = dgvPermiso.CurrentCell
        Select Case MostrarConfiguracionPermiso(Cell.Value)
            Case EditarPermiso.Actualizar
                'Cell.Value = simbPermiso.Valor
                If actualPermiso.Enlistado = False Then
                    diccPermisos.Add(actualPermiso.key, actualPermiso)
                    actualPermiso.Enlistado = True
                End If
                If actualPermiso.Tipo = "2" Then dgvPermiso.CurrentCell.Style.BackColor = Color.DodgerBlue Else
                If actualPermiso.Tipo = "4" Then dgvPermiso.CurrentCell.Style.BackColor = Color.Olive Else _
                If actualPermiso.Tipo = "5" Or actualPermiso.Tipo = "6" Then dgvPermiso.CurrentCell.Style.BackColor = Color.Red
            Case EditarPermiso.AnularEnDB
                dgvPermiso.CurrentCell.Style.BackColor = Color.White
            Case EditarPermiso.Quitar
                'Cell.Value = simbTurno.Valor
                diccPermisos.Remove(actualPermiso.key)
                actualPermiso.Enlistado = False
                dgvPermiso.CurrentCell.Style.BackColor = Color.White
            Case EditarPermiso.DeshacerAnul
                'Cell.Value = simbPermiso.Valor
                dgvPermiso.CurrentCell.Style.BackColor = Color.White
        End Select
    End Sub

    Function MostrarConfiguracionPermiso(pValor As Object) As Integer
        Select Case pValor.ToString
            Case <> simbPermiso.Valor
                If btcancelar.Enabled And Not IsDBNull(pValor) Then
                    Using form1 As New Form_dia_permiso(actualPermiso)
                        Dim key = SesionActual.idEmpresa & "|" & actualPermiso.Convencion
                        form1.dttipo = dttipo
                        form1.dwConvencion = dtconvencion.Rows.Find(key)
                        Dim minutos As Integer = dtconvencion.Rows.Find(key).Item("Minutos")
                        form1.habltrCntrls = btcancelar.Enabled
                        If String.IsNullOrEmpty(actualPermiso.Convencion) = False And minutos <> 0 Then
                            form1.ShowDialog()
                        End If
                        Return form1.PostAcc
                    End Using
                End If
        End Select
        Return EditarPermiso.CasoContrario
    End Function

    Private Sub dgvPermiso_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs) Handles dgvPermiso.CellPainting
        If e.Value IsNot DBNull.Value Then
            Select Case e.Value
                Case simbTurno.Valor
                'dgvPermiso.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Yellow
                Case simbPermiso.Valor
                    If e.ColumnIndex > 5 Then
                        dgvPermiso.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Tomato 'paintiado(simbPermiso, e)
                    End If
                Case simbNope.Valor
                    paintiado(simbNope, e)
                Case simbPE.Valor
                    paintiado(simbPE, e)
            End Select
        End If
    End Sub

    Private Sub paintiado(ByVal sender As SimbPerEstado, ByVal e As DataGridViewCellPaintingEventArgs)
        e.Paint(e.CellBounds, DataGridViewPaintParts.All)
        e.Graphics.DrawImage(sender.Imagen, e.CellBounds.Left + sender.lx, e.CellBounds.Top + 3)
        e.Handled = True
    End Sub

    Private Sub dgvPermiso_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPermiso.CellEnter
        Dim datemp As New Date
        Dim Dia As Integer
        'Dim idEmpleado As Integer
        'idEmpleado = dgvPermiso.Rows(e.RowIndex).Cells("colIDTerceroPer").Value.ToString
        'Dim dtCopia As New DataTable
        'dtCopia = dtPermiso.Copy
        'Dim fila As DataRow = dtCopia.Select("Id_Tercero='" & idEmpleado & "'")(0)
        'Dim indiceFila = dtCopia.Rows.IndexOf(fila)
        'dtPermiso.Rows(indiceFila).Item("Id_Tercero").ToString()
        objPermiso.imprimirPermisoXEmpleado = dgvPermiso.Rows(e.RowIndex).Cells("colIDTerceroPer").Value.ToString
        If IsDBNull(dgvPermiso.CurrentCell.Value) = False Then
            Select Case dgvPermiso.CurrentCell.Value
                Case <> simbTurno.Valor, <> simbPermiso.Valor
                    If dgvPermiso.CurrentCell.ColumnIndex = 5 Then
                        actualPermiso = getPermisoExistenciaPE()
                    Else
                        actualPermiso = getPermisoExistencia()
                    End If
                Case simbNope.Valor, simbPE.Valor
                    actualPermiso = getPermisoExistenciaPE()
            End Select
            If e.ColumnIndex > 5 Then
                Dia = Replace(dgvPermiso.Columns(e.ColumnIndex).Name, "colDia", "")
                datemp = Dia.ToString("00") & dateFechaPermiso.Value.ToString("/MM/yyyy")
                Dim cantidad As Integer = dtPE.Select("Id_Empleado='" & objPermiso.imprimirPermisoXEmpleado & "' AND Fecha='" & datemp & "'").Count
                If cantidad > 0 Then
                    Dim fila As DataRow = dtPE.Select("Id_Empleado='" & objPermiso.imprimirPermisoXEmpleado & "' AND Fecha='" & datemp & "'")(0)
                    TextBox1.Text = fila(2)
                End If

            End If
        Else
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyCode = Keys.Enter And Not txtBusCambia And txtBuscar.Text <> "" Then
            Try
                HorIndice = If(dgvPermiso.SelectedCells IsNot Nothing, dgvPermiso.SelectedCells(0).RowIndex, -1)
            Catch ex As Exception
            End Try
            'buscar()
            filtrar()
        End If
        txtBusCambia = False
    End Sub

    Function getPermisoExistencia() As Permiso
        Dim Cell = dgvPermiso.CurrentCell
        Dim Row = Cell.OwningRow
        Dim Col = Cell.OwningColumn
        Dim IDtercero As String = Row.Cells(colIDTerceroPer.Name).Value
        If Col.Index > 5 Then
            Dim StrDia = Strings.Right(Col.Name, 2)
            Dim key = IDtercero & "|" & StrDia
            Dim permiso1 As Permiso = Nothing
            If diccPermisos.TryGetValue(key, permiso1) = False Then
                permiso1 = New Permiso()
                permiso1.id_tercero = IDtercero
                permiso1.Empleado = Row.Cells(colNombrePer.Name).Value
                permiso1.Fecha = Exec.varcharDate(dateFechaPermiso.Value.ToString("yyyyMM") & StrDia)
                permiso1.Convencion = Row.Cells(Col.Name).Value
                permiso1.key = key
            End If
            Return permiso1
        End If
    End Function

    Function getPermisoExistenciaPE() As Permiso ' Carga los permiso especial
        Dim Cell = dgvPermiso.CurrentCell
        Dim Row = Cell.OwningRow
        Dim Col = Cell.OwningColumn
        Dim IDtercero As String = Row.Cells(colIDTerceroPer.Name).Value
        Dim key = IDtercero & "|PE"
        Dim permiso1 As Permiso = Nothing
        If diccPermisos.TryGetValue(key, permiso1) = False Then
            permiso1 = New Permiso()
            permiso1.id_tercero = IDtercero
            permiso1.Empleado = Row.Cells(colNombrePer.Name).Value
            permiso1.key = key
        End If
        Return permiso1
    End Function

    Private Sub EnlceDtaPer_ListChanged(sender As Object, e As System.ComponentModel.ListChangedEventArgs) Handles EnlceDtaPer.ListChanged
        Dim NumEmp = EnlceDtaPer.Count
        If (NumEmp > 0) Then : lbEmpleados.Text = String.Format(NumEmpleados, NumEmp) : ToolStripSeparator10.Visible = True
        Else : lbEmpleados.Text = "" : ToolStripSeparator10.Visible = False
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        txtBuscar.Text = ""
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        objPermiso.codPE = 0
        If txtBuscar.Text.Trim = "" Then
            dgvPermiso.ClearSelection()
            PictureBox3.Visible = False
            filtrar()
            cargarEmp()
            colorTodasLasConvenciones()
            Return
        Else
            PictureBox3.Image = My.Resources.borrartxt
            PictureBox3.Visible = True
        End If
        txtBusCambia = True
        'buscar()
        filtrar()
        cargarEmp()
        colorTodasLasConvenciones()
    End Sub

    Private Sub txtBuscar_ReadOnlyChanged(sender As Object, e As EventArgs) Handles txtBuscar.ReadOnlyChanged
        txtBuscar.ReadOnly = False
    End Sub

    Sub buscar()
        Dim text As String = txtBuscar.Text.Trim.ToUpper()
        Dim len As Integer = text.Length
        Dim ContSpac = text.Contains(" ")
        For Each row As DataGridViewRow In dgvPermiso.Rows
            For Each cell In {row.Cells(4), row.Cells(0)}
                If validarCoincidencia(cell.Value.ToString(), text, len, ContSpac) And cell.RowIndex > HorIndice Then
                    dgvPermiso.ClearSelection()
                    row.Selected = True
                    HorIndice = -1
                    row.Visible = True
                    dgvPermiso.CurrentCell = dgvPermiso.Rows(row.Index).Cells(0)
                    Return
                End If
            Next
        Next
        If HorIndice > -1 Then
            HorIndice = -1
            buscar()
        Else
            dgvPermiso.ClearSelection()
        End If
    End Sub
    Private Sub filtrar()
        EnlceDtaPer.Filter = "Nombre like '%" & txtBuscar.Text & "%' " &
                                      "Or Cargo Like '%" & txtBuscar.Text & "%' " &
                                      "Or Permiso_Especial like '%" & txtBuscar.Text & "%'"
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

    Private Sub Form_Pemisos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
            If validarRazonGuardar() OrElse dtPermiso.Rows.Count = 0 Then
                MsgBox("¡ No existen cambios en el cuadro de permisos laborales que guardar !", MsgBoxStyle.Exclamation)
            Else
                Dim pemiso As New Permiso(diccPermisos)
                pemiso.horario = dtPermiso.Rows(0).Item("Codigo_Horario").ToString
                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    If objPermiso_D.guardar(pemiso, diccPermisos) = True Then
                        dgvPermiso.CurrentCell = Nothing
                        MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                        General.deshabilitarControles(Me)
                        General.habilitarBotones(Me.ToolStrip1)
                        btguardar.Enabled = False
                        btcancelar.Enabled = False
                    End If
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Function validarRazonGuardar() As Boolean
        For Each kvp As KeyValuePair(Of String, Permiso) In diccPermisos
            If kvp.Value.Codigo Is Nothing OrElse kvp.Value.Editado OrElse kvp.Value.Anulado Then Return False
        Next kvp
        Return True
    End Function

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim vConsulta = String.Format(Consultas.BUSCAR_PERMISO, dateFechaPermiso.Value, SesionActual.idEmpresa)
            Dim vTitulo = String.Format("Busqueda de permiso en el mes de: {0:MMMM}", dateFechaPermiso.Value)
            General.buscarElemento(vConsulta,
                                   Nothing,
                                   AddressOf cargar,
                                   vTitulo,
                                   False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If txtBuscar.Text = "" Then
            objPermiso.imprimirPermisoXEmpleado = ""
        End If
        Dim rptPermisoConsolidado1 As New rptPermisoConsolidado()
        rptPermisoConsolidado1.SetParameterValue("@pUsuario", SesionActual.idUsuario)
        rptPermisoConsolidado1.SetParameterValue("@pEmpresa", SesionActual.idEmpresa)
        rptPermisoConsolidado1.SetParameterValue("@pFchInicio", Exec.primerDiaMes(Me.dateFechaPermiso.Value))
        rptPermisoConsolidado1.SetParameterValue("@pFchFin", Exec.ultimoDiaMes(Me.dateFechaPermiso.Value))
        rptPermisoConsolidado1.SetParameterValue("@pEmpleado", If(objPermiso.imprimirPermisoXEmpleado IsNot Nothing, objPermiso.imprimirPermisoXEmpleado.ToString, ""))

        Dim ext = ".pdf"
        Exec.getReport(rptPermisoConsolidado1, Nothing, "PermisoC", ext)
    End Sub


    Private Sub TimerSegirCargando_Tick(sender As Object, e As EventArgs) Handles TimerSegirCargando.Tick
        TimerSegirCargando.Stop()
        AplicarCambioPermiso()
    End Sub
    Public Sub cargar(pCodigo As String)
        dgvPermiso.CurrentCell = Nothing
        For Each kvp As KeyValuePair(Of String, Permiso) In diccPermisos
            If kvp.Value.Codigo = pCodigo Then
                Try
                    For Each Row As DataGridViewRow In dgvPermiso.Rows
                        If Row.Cells(colIDTerceroPer.Name).Value.ToString = kvp.Value.id_tercero Then
                            dgvPermiso.CurrentCell = Row.Cells("colDia" & kvp.Value.Fecha.Day.ToString("00"))
                            Exit For
                        End If
                    Next
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
                Exit For
            End If
        Next
    End Sub

    Public Sub cargarEmp()
        Cargando = True
        dgvPermiso.CurrentCell = Nothing
        If btguardar.Enabled = False Then
            Dim sql As String
            sql = Consultas.CARGAR_EMPLEADOS_PER & SesionActual.idEmpresa & ", '" & dateFechaPermiso.Value.ToString("yyyyMMdd") & "'"
            General.llenarDataSet(sql, ds)

            diccPermisos.Clear()
            For Each dw As DataRow In dtmesper.Rows
                Dim permiso1 As New Permiso(dw)
                Try
                    diccPermisos.Add(permiso1.key, permiso1)
                    permiso1.Enlistado = True
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            Next
        End If

        For Each Row As DataGridViewRow In dgvPermiso.Rows
            For Each kvp As KeyValuePair(Of String, Permiso) In diccPermisos
                If Row.Cells(colIDTerceroPer.Name).Value.ToString = kvp.Value.id_tercero Then
                    Try
                        If kvp.Value.Tipo = 1 Then Row.Cells(colPermisoEspecial.Name).Value = If(kvp.Value.Anulado, simbNope.Valor, simbPE.Valor) _
                        Else If Row.Cells("colDia" & kvp.Value.Fecha.Day.ToString("00")).Value.ToString <> simbPermiso.Valor _
                        Then Row.Cells("colDia" & kvp.Value.Fecha.Day.ToString("00")).Value = kvp.Value.Convencion
                        If kvp.Value.Tipo = 2 Then Row.Cells("colDia" & kvp.Value.Fecha.Day.ToString("00")).Style.BackColor = Color.DodgerBlue _
                        Else If kvp.Value.Tipo = 4 Then Row.Cells("colDia" & kvp.Value.Fecha.Day.ToString("00")).Style.BackColor = Color.Olive _
                        Else If kvp.Value.Tipo = 5 Or kvp.Value.Tipo = 6 Then Row.Cells("colDia" & kvp.Value.Fecha.Day.ToString("00")).Style.BackColor = Color.Red
                    Catch ex As Exception
                        General.manejoErrores(ex)
                    End Try
                End If
            Next
        Next
        Cargando = False
    End Sub

    Public Sub cargarEmp4PE(pCodigo As String)
        Dim sql = String.Format(Consultas.CARGAR_EMPLEADO_PERMISO_EP, SesionActual.idEmpresa, dateFechaPermiso.Value.ToString("yyyyMM01"), pCodigo)
        Using dt = dtPermiso.Clone
            General.llenarTablaYdgv(sql, dt)
            dtPermiso.ImportRow(dt(0))
        End Using
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub

    Private Class SimbPerEstado
        Property Valor As String : Property Imagen As Bitmap : Property lx As Integer : Property ly As Integer
        Sub New(pValor As String, pImagen As Bitmap, Optional pX As Integer = 3 + 4)
            Valor = pValor
            Imagen = New Bitmap(pImagen)
            lx = pX
        End Sub
    End Class
End Class
