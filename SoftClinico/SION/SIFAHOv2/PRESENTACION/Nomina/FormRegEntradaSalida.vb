Public Class FormRegEntradaSalida
    Dim objRegEntradaSalida As New RegEntradaSalidaAsistencia
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormRegEntradaSalida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarBarra()
        objRegEntradaSalida.lbFecha.Text = "Hoy es " & Format(Convert.ToDateTime(Funciones.Fecha(23)), "dddd dd MMMMM yyyy")
        objRegEntradaSalida.idEmpresa = SesionActual.idEmpresa
        objRegEntradaSalida.codigoEp = SesionActual.codigoEP
        objRegEntradaSalida.fechaActual = Funciones.Fecha(23)
        General.deshabilitarControles(GbEmpleado)
        PrimerDiaMes(dtFecInicio.Value)
        btbuscarEmpleado.Enabled = True
        btCancelar.Enabled = True
        validardgvRegEntradaSalidaCons()
        validardgvRegEntradaSalidaSeguimiento()
        validarTabControl()
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscarEmpleado.Click
        General.buscarElemento(Consultas.BUSQUEDA_BUSCAR_EMPLEADO & objRegEntradaSalida.idEmpresa,
                               Nothing,
                               AddressOf cargarEmpleado,
                               TitulosForm.BUSQUEDA_EMPLEADO_HC,
                               False,, True)
    End Sub
    Private Sub cargarEmpleado(pCodigo As Integer)
        Dim dFila As DataRow
        Dim params As New List(Of String)
        objRegEntradaSalida.idEmpleado = pCodigo
        params.Add(pCodigo)
        dFila = General.cargarItem(ConsultasNom.EMPLEADO_NOMINA_CARGAR, params)
        txtNombre.Text = dFila.Item("Nombre")
        validarTabControl()
        btCancelar.Visible = True
    End Sub
    Private Sub PrimerDiaMes(ByRef dtfech As Date)
        Dim fechaInicial As New Date
        fechaInicial = Date.Now
        dtfech = dtfech.AddDays(-fechaInicial.Day + 1)
    End Sub
    Private Sub validardgvRegEntradaSalidaCons()
        With dgvConsolidado
            .Columns("dgMes").DataPropertyName = "Dia"
            .Columns("dgMes").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("dgNombreCon").DataPropertyName = "Nombre"
            .Columns("dgNombreCon").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("dgCargoCon").DataPropertyName = "Cargo"
            .Columns("dgCargoCon").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("dgHorarioCon").DataPropertyName = "Horario"
            .Columns("dgHorarioCon").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("dgTurnProgram").DataPropertyName = "Turnos_Programados"
            .Columns("dgTurnProgram").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("dgTurnoReal").DataPropertyName = "Turnos_Realizados"
            .Columns("dgTurnoReal").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("dgHorasReal").DataPropertyName = "Horas_Realizadas"
            .Columns("dgHorasReal").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("dgHorasComp").DataPropertyName = "Horas_Compensadas"
            .Columns("dgHorasComp").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("dgHorasPerdidas").DataPropertyName = "Horas_Perdidas"
            .Columns("dgHorasPerdidas").SortMode = DataGridViewColumnSortMode.NotSortable
            .DataSource = objRegEntradaSalida.dtRegConsolidado
            .AutoGenerateColumns = False
        End With
    End Sub
    Private Sub validardgvRegEntradaSalidaSeguimiento()
        With dgvSiguimiento
            .Columns("dgFechaIngreso").DataPropertyName = "Dia"
            .Columns("dgFechaIngreso").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("dgCargoSis").DataPropertyName = "Cargo"
            .Columns("dgCargoSis").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("dgMaquina").DataPropertyName = "Maquina"
            .Columns("dgMaquina").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("dgAccion").DataPropertyName = "movimiento"
            .Columns("dgAccion").SortMode = DataGridViewColumnSortMode.NotSortable
            .DataSource = objRegEntradaSalida.dtSeguimiento
            .AutoGenerateColumns = False
        End With
    End Sub
    Private Sub dgvEntradaSalida_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvEntradaSalida.CellFormatting
        If objRegEntradaSalida.dtRegEntrada.Rows.Count > 0 Then
            If Format(objRegEntradaSalida.dtRegEntrada(e.RowIndex).Item("Fecha"), "MMMM dd") <> Format(objRegEntradaSalida.fechaActual, "MMMM dd") Then
                e.CellStyle.BackColor = Color.Aquamarine
            End If
        End If
    End Sub
    Private Sub dtFecFin_ValueChanged(sender As Object, e As EventArgs) Handles dtFecInicio.ValueChanged, dtFecFin.ValueChanged
        If tabcontrolReg.SelectedIndex <> 0 Then
            validarTabControl()
        End If
    End Sub
    Private Sub inicializarBarra()
        objRegEntradaSalida.lbRegistros.AutoSize = 3
        objRegEntradaSalida.lbBalance.AutoSize = 2
        objRegEntradaSalida.lbEstado.AutoSize = 3
        objRegEntradaSalida.lbEntrada.AutoSize = 3
        objRegEntradaSalida.lbFecha.AutoSize = 3
        StatusBar1.Panels.Clear()
        TabPage3.Parent = Nothing
        StatusBar1.Panels.Add(objRegEntradaSalida.lbRegistros)
        StatusBar1.Panels.Add(objRegEntradaSalida.lbEstado)
        StatusBar1.Panels.Add(objRegEntradaSalida.lbBalance)
        StatusBar1.Panels.Add(objRegEntradaSalida.lbEntrada)
        StatusBar1.Panels.Add(objRegEntradaSalida.lbFecha)
    End Sub
    Private Sub dgvEntradaSalida_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEntradaSalida.CellContentClick
        If objRegEntradaSalida.dtRegEntrada.Rows.Count > 0 Then
            verConverncion(e.ColumnIndex)
        End If
    End Sub
    Private Sub dgvEntradaEm_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEntradaEm.CellClick
        If objRegEntradaSalida.dtRegEntradaEmpleado.Rows.Count > 0 Then
            verConverncion(e.ColumnIndex)
        End If
    End Sub
    Private Sub tabcontrolReg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabcontrolReg.SelectedIndexChanged
        validarTabControl()
    End Sub
    Private Sub validarTabControl()
        Dim fechaInicio As Date
        General.habilitarControles(gpFecha)
        btbuscarEmpleado.Enabled = True

        tabcontrolReg.Dock = DockStyle.None

        Select Case tabcontrolReg.SelectedIndex
            Case 0
                tabcontrolReg.Dock = DockStyle.Fill
                tabcontrolReg.BringToFront()
                General.deshabilitarControles(gpFecha)
                btbuscarEmpleado.Enabled = False
                objRegEntradaSalida.CargarDatosRegEntradaSalida()
                fechaInicio = objRegEntradaSalida.dtRegEntrada.Rows(0).Item("Fecha")
                objRegEntradaSalida.lbEntrada.Text = "En la fecha " & Format(fechaInicio, "dd MMMM yyyy") &
                                                     " se registran " & objRegEntradaSalida.dtRegEntrada.Compute("COUNT(Entrada)", "Entrada <> ''").ToString &
                                                     " entradas y " & objRegEntradaSalida.dtRegEntrada.Compute("COUNT(Salida)", "Salida <> ''").ToString & " salidas"
                dgvEntradaSalida.DataSource = objRegEntradaSalida.dtRegEntrada
                validarDgv()
            Case 1
                objRegEntradaSalida.CargarDatosRegEntradaSalidaEmpleado(Format(dtFecInicio.Value, Constantes.FORMATO_FECHA_GEN),
                                                                        Format(dtFecFin.Value, Constantes.FORMATO_FECHA_GEN))
                dgvEntradaEm.DataSource = objRegEntradaSalida.dtRegEntradaEmpleado
            Case 3
                objRegEntradaSalida.CargarDatosRegEntradaSalidaConsolidado(Format(dtFecInicio.Value, Constantes.FORMATO_FECHA_GEN),
                                                                        Format(dtFecFin.Value, Constantes.FORMATO_FECHA_GEN))
            Case 2
                If Not String.IsNullOrEmpty(txtNombre.Text) Then
                    objRegEntradaSalida.CargarDatosRegEntradaSalidaSeguimiento(Format(dtFecInicio.Value, Constantes.FORMATO_FECHA_GEN),
                                                                                        Format(dtFecFin.Value, Constantes.FORMATO_FECHA_GEN))
                    dgvSiguimiento.DataSource = objRegEntradaSalida.dtSeguimiento

                End If
        End Select
    End Sub
    Private Sub validarDgv()
        With dgvEntradaSalida
            .Columns("Dia").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Turno").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Empleado").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Entrada").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descanso").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Retorno").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Salida").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Punto").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Dia").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns("Turno").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns("Empleado").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns("Entrada").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns("Descanso").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns("Retorno").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns("Salida").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns("Punto").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns("Fecha").Visible = False
            .Columns("Punto").Visible = False
            .AutoGenerateColumns = False
        End With
    End Sub
    Private Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        objRegEntradaSalida.idEmpleado = Nothing
        txtNombre.Clear()
        objRegEntradaSalida.dtRegConsolidado.Clear()
        objRegEntradaSalida.dtRegEntradaEmpleado.Clear()
        objRegEntradaSalida.dtSeguimiento.Clear()
        PanelDetalle.Visible = False
        validarTabControl()
        btCancelar.Visible = False
    End Sub

    Public Function extraeNumero(cadena As String) As String
        Dim i As Integer
        Dim SoloNumeros As String = Nothing

        For i = 1 To Len(cadena)

            If Mid$(cadena, i, 1) Like "#" Then _
            SoloNumeros = CLng(SoloNumeros & Mid$(cadena, i, 1))

        Next i

        Return SoloNumeros

    End Function

    Private Sub dgvSiguimiento_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSiguimiento.CellClick
        If objRegEntradaSalida.dtSeguimiento.Rows.Count > 0 Then
            If e.ColumnIndex = 0 Then
                PictureBox2.Image = Celer.My.Resources.Resources.clock_icon2
                txtNotaDetalle.Text = objRegEntradaSalida.dtSeguimiento.Rows(dgvSiguimiento.CurrentCell.RowIndex).Item("movimiento").ToString
                    dfDia.Value = objRegEntradaSalida.dtSeguimiento.Rows(dgvSiguimiento.CurrentCell.RowIndex).Item("Dia").ToString
                    txtMaquina.Text = objRegEntradaSalida.dtSeguimiento.Rows(dgvSiguimiento.CurrentCell.RowIndex).Item("Maquina").ToString
                    PanelDetalle.Visible = True
                End If
            End If
    End Sub

    Private Sub btGuardarySalir_Click(sender As Object, e As EventArgs) Handles btGuardarySalir.Click
        PanelDetalle.Visible = False
    End Sub
    Private Sub verConverncion(Columna As Integer)
        If dgvEntradaSalida.Focused = True Then
            If Columna = 2 Then
                objRegEntradaSalida.lbBalance.Text = Funciones.consultaConvencion(dgvEntradaSalida.Rows(dgvEntradaSalida.CurrentCell.RowIndex).Cells(Columna).Value)
            End If
        ElseIf dgvEntradaEm.Focused = True Then
            If Columna = 1 Then
                objRegEntradaSalida.lbBalance.Text = Funciones.consultaConvencion(dgvEntradaEm.Rows(dgvEntradaEm.CurrentCell.RowIndex).Cells(Columna).Value)
            End If
        End If
    End Sub

    Private Sub dgvEntradaEm_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvEntradaEm.CellFormatting
        If objRegEntradaSalida.dtRegEntradaEmpleado.Rows.Count > 0 Then
            If objRegEntradaSalida.dtRegEntradaEmpleado.Rows(e.RowIndex).Item("Turno") = Constantes.PENDIENTE.ToString Then
                dgvEntradaEm.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Coral
            End If
        End If
    End Sub
End Class