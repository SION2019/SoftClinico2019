Public Class FormHojaRuta
    Dim objHojaRuta As HojaRuta
    Dim modulo As String
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Peditar, PTarea, PVerHC, PVerAM, PVerAF, pAnular As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormHojaRuta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        modulo = Tag.Modulo
        objHojaRuta = GeneralHC.fabricaHC.crear(Constantes.CODIGO_HOJA_RUTA & modulo)
        cargarPermiso(modulo)
        ocultarColumnasModulo()
        Label1.Text = objHojaRuta.titulo
        objHojaRuta.codigoEP = SesionActual.codigoEP
        objHojaRuta.idEmpresa = SesionActual.idEmpresa
        validarDgv()
        validarDgvTareaProgram()
        General.cargarCombo(Consultas.AREA_SERVICIO_LISTAR_CONTRATO & "" & SesionActual.codigoEP & ",'','" & Constantes.VALOR_PREDETERMINADO & "',''", "Descripción", "Código", comboAreaServicio)
    End Sub
    Private Sub dtFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtFecha.ValueChanged
        Dim fechaActual As Date = Funciones.Fecha(23)
        If CDate(dtFecha.Value).Date > fechaActual And
            Not String.IsNullOrEmpty(comboAreaServicio.ValueMember) Then
            MsgBox(Mensajes.FECHA_NO_VALIDA, MsgBoxStyle.Exclamation)
            dtFecha.ResetText()
            Exit Sub
        End If

        If Not String.IsNullOrEmpty(comboAreaServicio.ValueMember) Then
            If comboAreaServicio.SelectedIndex <> 0 Then
                cargarHojaRuta(busquedaPaciente.Text)
            End If
        End If

    End Sub
    Private Sub comboAreaServicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboAreaServicio.SelectedIndexChanged,
                                                                                                 selCerrados.CheckedChanged,
                                                                                                 selAtendidos.CheckedChanged
        If comboAreaServicio.SelectedIndex <> 0 Then
            dtFecha_ValueChanged(sender, e)
        End If
    End Sub
    Private Sub dgvElemento_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvElemento.RowPostPaint
        Using Pinceles As New SolidBrush(dgvElemento.RowHeadersDefaultCellStyle.ForeColor)
            Dim nombre As String
            nombre = objHojaRuta.dtElementos.Rows(e.RowIndex).Item("Num")
            e.Graphics.DrawString(nombre, dgvElemento.Rows(e.RowIndex).Cells("dgNum").InheritedStyle.Font, Pinceles, e.RowBounds.Location.X + 14, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
    Private Sub dgvProgram_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvTareasProgram.RowPostPaint
        Dim nombre As String
        Using Pinceles As New SolidBrush(dgvTareasProgram.RowHeadersDefaultCellStyle.ForeColor)
            nombre = objHojaRuta.dtProgram.Rows(e.RowIndex).Item("Num")
            e.Graphics.DrawString(nombre, dgvTareasProgram.Rows(e.RowIndex).Cells("dgNumP").InheritedStyle.Font,
                                  Pinceles, e.RowBounds.Location.X + 14,
                                  e.RowBounds.Location.Y + 4)
        End Using
    End Sub
    Private Sub dgvHojaRuta_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHojaRuta.CellClick
        If dgvHojaRuta.RowCount > 0 Then
            objHojaRuta.registro = objHojaRuta.dtHojaRuta(dgvHojaRuta.CurrentCell.RowIndex).Item("N_Registro")
            dgvElemento.DataSource = Nothing
            validarFuncionesDgv(e.ColumnIndex, e.RowIndex)
        End If
    End Sub
    Private Sub txtComentario_Leave(sender As Object, e As EventArgs) Handles txtComentario.Leave
        validarCargarTxt(dgvHojaRuta.Columns(dgvHojaRuta.CurrentCell.ColumnIndex).Name,
                         txtComentario, dgvHojaRuta, Panel7)
    End Sub
    Private Sub dgvHojaRuta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvHojaRuta.KeyPress
        '-- Poseidon
        '--- 29-08-2017
        '--- activa el evento para abrir la justificacion de la observacion 
        '--- se activa al presionar una tecla 

        Select Case dgvHojaRuta.CurrentCell.ColumnIndex
            Case 10
                HojaRutaBLL.abrirJustificacion(dgvHojaRuta, objHojaRuta.dtHojaRuta, Panel7, txtComentario, "dgObsMedica", False)
            Case 11
                HojaRutaBLL.abrirJustificacion(dgvHojaRuta, objHojaRuta.dtHojaRuta, Panel7, txtComentario, "dgObsRevisoria", True)
            Case 12
                HojaRutaBLL.abrirJustificacion(dgvHojaRuta, objHojaRuta.dtHojaRuta, Panel7, txtComentario, "dgObsFacturacion", True)
        End Select
    End Sub
    Private Sub validarFuncionesDgv(posicion As Integer, fila As Integer)
        Panel1.Visible = False
        Select Case posicion
            Case 7 '----------------- Abre el panel donde se muestran los diagnosticos
                Panel1.Visible = True
                cargarDiagnostico()
                Panel1.Focus()
            Case 8 '------------------ Abre el panel donde se muestra el manejo del paciente segun la fecha 
                Panel1.Visible = True
                cargarManejo()
                Panel1.Focus()
            Case 9
                If SesionActual.tienePermiso(PTarea) Then
                    panelTareaProgram.Visible = True
                    General.deshabilitarControles(Me)
                    General.habilitarControles(panelTareaProgram)
                    General.limpiarControles(panelTareaProgram)
                    txtEmpleado.ReadOnly = True
                    cargarTareasProgram()
                    panelTareaProgram.Focus()
                Else
                    MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
                End If
            Case 10 '------------------ Abre el panel para digitar la observacio segun el historia clinica
                HojaRutaBLL.abrirJustificacion(dgvHojaRuta, objHojaRuta.dtHojaRuta, Panel7, txtComentario, "dgObsMedica", True)
            Case 11 '------------------ Abre el panel para digitar la observacio medica segun el auditoria medica
                HojaRutaBLL.abrirJustificacion(dgvHojaRuta, objHojaRuta.dtHojaRuta, Panel7, txtComentario, "dgObsRevisoria", True)
            Case 12 '------------------ Abre el panel para digitar la observacio facturación segun el auditoria facturación
                HojaRutaBLL.abrirJustificacion(dgvHojaRuta, objHojaRuta.dtHojaRuta, Panel7, txtComentario, "dgObsFacturacion", True)
        End Select
    End Sub
    Private Sub validarCargarTxt(nombreColumna As String, txt As RichTextBox, dgv As DataGridView, panel As Panel)
        Try
            If panel.Visible = True Then
                panel.Visible = False

                If Not String.IsNullOrWhiteSpace(txt.Text) Then
                    dgv.Rows(dgv.CurrentRow.Index).Cells(nombreColumna).Value = txt.Text
                Else
                    dgv.Rows(dgv.CurrentRow.Index).Cells(nombreColumna).Value = Nothing
                End If

                dgv.Rows(dgv.CurrentRow.Index).Cells(nombreColumna).Selected = True
                txt.Clear()
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub
    Private Sub validarDgvElementos()
        With dgvElemento
            .ReadOnly = True
            .Columns("dgNum").DataPropertyName = "Num"
            .Columns("dgDescripcion").DataPropertyName = "Descripcion"
        End With
    End Sub
    Private Sub validarDgvTareaProgram()
        With dgvTareasProgram
            .ReadOnly = True
            .Columns("dgNumP").DataPropertyName = "Num"
            .Columns("dgIdProgramada").DataPropertyName = "id_programacion"
            .Columns("dgDescripcionP").DataPropertyName = "Descripcion"
            .Columns("dgHC").DataPropertyName = "HC"
            .Columns("dgAM").DataPropertyName = "AM"
            .Columns("dgAF").DataPropertyName = "AF"
            .Columns("dgComentario").DataPropertyName = "comentario"
            .Columns("dgRealizada").DataPropertyName = "Realizado"
            .DataSource = objHojaRuta.dtProgram
            .AutoGenerateColumns = False
        End With
    End Sub
    Private Sub cargarObjeto()
        objHojaRuta.codigoArea = comboAreaServicio.SelectedValue
        objHojaRuta.usuario = SesionActual.idUsuario
        objHojaRuta.fechaActual = CDate(dtFecha.Value).Date
        objHojaRuta.codigoEstado = HojaRutaBLL.codigoEstadoAtencion(selAtendidos,
                                                                    selCerrados)
    End Sub
    Public Sub cargarDiagnostico()
        objHojaRuta.cargarDiagnostico()
        validarDgvElementos()
        dgvElemento.DataSource = objHojaRuta.dtElementos
        lbTitulo.Text = TitulosForm.DIAGNOTICOS
        dgvElemento.Columns("dgDescripcion").HeaderText = Constantes.TITULO_COLUMNA_DIAG
        dgvElemento.AutoGenerateColumns = False
    End Sub
    Public Sub cargarManejo()
        objHojaRuta.cargarManejo()
        validarDgvElementos()
        dgvElemento.DataSource = objHojaRuta.dtElementos
        lbTitulo.Text = TitulosForm.MANEJO
        dgvElemento.Columns("dgDescripcion").HeaderText = Constantes.TITULO_COLUMNA_MANEJO
        dgvElemento.AutoGenerateColumns = False
    End Sub
    Public Sub cargarHojaRuta(txt As String)
        cargarObjeto()
        ocultarPanel()
        objHojaRuta.cargarHojaRuta(txt)
        dgvHojaRuta.DataSource = objHojaRuta.dtHojaRuta
        lbNumeroPaciente.Text = objHojaRuta.dtHojaRuta.Rows.Count
        dgvHojaRuta.AutoGenerateColumns = False
        HojaRutaBLL.identificarRegistros(dgvHojaRuta, objHojaRuta.dtHojaRuta)
    End Sub
    Public Sub cargarTareasProgram()
        objHojaRuta.cargarTareasProgram()
        validarDgvTareaProgram()
        cargarEmpleadoRegistrado()
        lbTituloTarea.Text = TitulosForm.TITULO_HOJA_PROGRAMAR_TAREA &
                                    objHojaRuta.dtHojaRuta.Rows(dgvHojaRuta.CurrentCell.RowIndex).Item("Nombre")
    End Sub
    Private Sub cargarEmpleadoRegistrado()
        Dim params As New List(Of String)
        Dim fila As DataRow
        params.Add(objHojaRuta.registro)
        params.Add(objHojaRuta.fechaActual.Date)
        fila = General.cargarItem("[PROC_HOJA_RUTA_EMPLEADO_CARGAR]", params)
        If Not IsNothing(fila) Then
            objHojaRuta.idEmpleado = fila(0)
            txtEmpleado.Text = fila(1)
            btanular.Enabled = True
        Else
            btanular.Enabled = False
        End If
    End Sub
    Private Sub validarDgv()
        With dgvHojaRuta
            .ReadOnly = True
            .Columns("dgRevisado").DisplayIndex = 0
            .Columns("dgNumRegistro").DataPropertyName = "N_Registro"
            .Columns("dgNombre").DataPropertyName = "Nombre"
            .Columns("dgEdad").DataPropertyName = "Edad"
            .Columns("dgGenero").DataPropertyName = "Genero"
            .Columns("dgFechaIngreso").DataPropertyName = "Fecha_Ingreso"
            .Columns("dgestancia").DataPropertyName = "Estancia"
            .Columns("dgDiagnostico").DataPropertyName = "Diagnostico"
            .Columns("dgManejo").DataPropertyName = "Manejo"
            .Columns("dgObsMedica").DataPropertyName = "Obser_medica"
            .Columns("dgObsRevisoria").DataPropertyName = "Obser_Revisoria"
            .Columns("dgObsFacturacion").DataPropertyName = "Obser_Facturacion"
            .Columns("dgTareaPendiente").DataPropertyName = "Tarea_Pendiente"
            .Columns("dgEstado").DataPropertyName = "Estado"
        End With
    End Sub
    Private Sub ocultarPanel()
        Panel7.Visible = False
        Panel1.Visible = False
    End Sub
    Private Sub ocultarColumnasModulo()
        objHojaRuta.validarOcultoDgv(SesionActual.tienePermiso(PVerHC),
                                     SesionActual.tienePermiso(PVerAM),
                                     SesionActual.tienePermiso(PVerAF))
        With dgvHojaRuta
            .Columns("dgObsMedica").Visible = objHojaRuta.columnaHC
            .Columns("dgObsRevisoria").Visible = objHojaRuta.columnaAM
            .Columns("dgObsFacturacion").Visible = objHojaRuta.columnaAF
        End With

        With dgvTareasProgram
            .Columns("dgHC").Visible = objHojaRuta.columnaHC
            .Columns("dgAM").Visible = objHojaRuta.columnaAM
            .Columns("dgAF").Visible = objHojaRuta.columnaAF
        End With

    End Sub
    Private Sub FormHojaRuta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub dgvTareasProgram_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTareasProgram.CellClick
        If objHojaRuta.dtProgram.Rows.Count > 0 Then
            Select Case e.ColumnIndex
                Case 3
                    If verificarPermisoEdicion(e.ColumnIndex) = False Then Exit Sub
                    HojaRutaBLL.abrirJustificacion(dgvTareasProgram, objHojaRuta.dtProgram, Panel2, TextJustificacionTarea, "dgHC", False)
                Case 4
                    If verificarPermisoEdicion(e.ColumnIndex) = False Then Exit Sub
                    HojaRutaBLL.abrirJustificacion(dgvTareasProgram, objHojaRuta.dtProgram, Panel2, TextJustificacionTarea, "dgAM", False)
                Case 5
                    If verificarPermisoEdicion(e.ColumnIndex) = False Then Exit Sub
                    HojaRutaBLL.abrirJustificacion(dgvTareasProgram, objHojaRuta.dtProgram, Panel2, TextJustificacionTarea, "dgAF", False)
                Case 6
                    HojaRutaBLL.abrirJustificacion(dgvTareasProgram, objHojaRuta.dtProgram, Panel2, TextJustificacionTarea, "dgComentario", False)
            End Select
        End If
    End Sub
    Private Sub TextJustificacionTarea_Leave(sender As Object, e As EventArgs) Handles TextJustificacionTarea.Leave
        If dgvHojaRuta.ColumnCount > 0 Then
            validarCargarTxt(dgvTareasProgram.Columns(dgvTareasProgram.CurrentCell.ColumnIndex).Name,
                                                            TextJustificacionTarea, dgvTareasProgram, Panel2)
        End If
    End Sub
    Private Sub btCerrar_Click(sender As Object, e As EventArgs) Handles btGuardarySalir.Click
        If btguardar_Click() = True Then
            General.habilitarControles(Me)
            panelTareaProgram.Visible = False
            cargarHojaRuta(busquedaPaciente.Text)
            btGuardarHoja_Click()
        End If
    End Sub
    Private Function btguardar_Click() As Boolean
        Dim existencia As Boolean = False
        If objHojaRuta.dtProgram.Rows.Count > 0 Then
            dgvTareasProgram.EndEdit()
            dgvTareasProgram.CommitEdit(DataGridViewDataErrorContexts.Commit)
            Try
                HojaRutaBLL.guardarTareasProgramas(objHojaRuta)
                existencia = True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        Return existencia
    End Function
    Private Sub busquedaPaciente_TextChanged(sender As Object, e As EventArgs) Handles busquedaPaciente.TextChanged
        dtFecha_ValueChanged(sender, e)
    End Sub
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Dim area, nombreArchivo, ruta As String
        Dim reporte As New ftp_reportes
        If objHojaRuta.dtHojaRuta.Rows.Count > 0 Then

            Cursor = Cursors.WaitCursor

            area = objHojaRuta.nombrePdf
            objHojaRuta.codigoArea = comboAreaServicio.SelectedValue

            Try

                nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & Format(DateTime.Now, "yyyyMMdd") & ConstantesHC.EXTENSION_ARCHIVO_PDF

                ruta = IO.Path.GetTempPath() & nombreArchivo
                reporte.crearReportePDF(area, Format(Date.Now, "yyyyMMdd"),
                                               New rptHojaRuta,
                                               Format(Date.Now, "yyyyMMdd"),
                                               "{VISTA_HOJA_RUTA.Fecha}='" & Format(Date.Now, "yyyy-MM-dd") &
                                               "' AND  {VISTA_HOJA_RUTA.Codigo_Servicio}=" & objHojaRuta.codigoArea,
                                               area,
                                               IO.Path.GetTempPath)
            Catch ex As Exception
                general.manejoErrores(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Sub btbuscarpaciente_Click(sender As Object, e As EventArgs) Handles btbuscarpaciente.Click
        Dim params As New List(Of String)
        params.Add(Constantes.LISTA_CARGO_ORDEN_MEDICA)
        params.Add(objHojaRuta.idEmpresa)
        General.buscarItem(Consultas.BUSQUEDA_EMPLEADO_HC,
                                              params,
                                               AddressOf cargardatosEmpleado,
                                              TitulosForm.BUSQUEDA_EMPLEADO_HC,
                                              False)
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Dim params As New List(Of String)
        If SesionActual.tienePermiso(pAnular) Then
            If MsgBox("Desea Eliminar el registro ", 32 + 1, "Eliminar") = 1 Then
                params.Add(objHojaRuta.registro)
                params.Add(objHojaRuta.fechaActual.Date)
                General.ejecutarSQL(Consultas.ANULAR_HOJA_RUTA, params)
                General.habilitarControles(Me)
                cargarHojaRuta(busquedaPaciente.Text)
                panelTareaProgram.Visible = False
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargardatosEmpleado(pFila As DataRow)
        objHojaRuta.idEmpleado = pFila.Item(0)
        txtEmpleado.Text = pFila.Item(1)
    End Sub
    Private Sub btGuardarHoja_Click()
        If dgvHojaRuta.Rows.Count > 0 Then
            dgvHojaRuta.CommitEdit(DataGridViewDataErrorContexts.Commit)
            dgvHojaRuta.EndEdit()
            Try
                HojaRutaBLL.guardarHojaRuta(objHojaRuta)
            Catch ex As Exception
                general.manejoErrores(ex)
            End Try
        End If
    End Sub
    Private Sub Panel1_Leave(sender As Object, e As EventArgs) Handles Panel1.Leave
        Panel1.Visible = False
    End Sub
    Private Sub cargarPermiso(Modulo As String)
        permiso_general = perG.buscarPermisoGeneral(Name, Modulo)
        Peditar = permiso_general & "pp" & "01"
        PTarea = permiso_general & "pp" & "02"
        PVerHC = permiso_general & "pp" & "03"
        PVerAM = permiso_general & "pp" & "04"
        PVerAF = permiso_general & "pp" & "05"
        pAnular = permiso_general & "pp" & "06"
    End Sub

    Private Function verificarPermisoEdicion(posicion As Integer)
        Dim banderaVerEdicion As Boolean
        If posicion = 3 Or
            posicion = 4 Or
            posicion Or
            posicion = 5 Then
            If SesionActual.tienePermiso(Peditar) Then
                banderaVerEdicion = True
            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        End If
        Return banderaVerEdicion
    End Function
End Class