Public Class FormConcurrencia
    Dim dtConcurrencia As New DataTable
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim perG As New Buscar_Permisos_generales
    Dim reporte As New ftp_reportes
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormConcurrencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name, Tag.modulo)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"

        establecerDatagriew()

        With dgConcurrencia
            .Columns("fechaadmi").ReadOnly = True
            .Columns.Item("fechaadmi").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("fechaadmi").DataPropertyName = "Fecha admision"

            .Columns("Paciente").ReadOnly = True
            .Columns.Item("Paciente").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Paciente").DataPropertyName = "paciente"

            .Columns("Cama").ReadOnly = True
            .Columns.Item("Cama").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cama").DataPropertyName = "cama"

            .Columns("Edad").ReadOnly = True
            .Columns.Item("Edad").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Edad").DataPropertyName = "edad"

            .Columns("estanciah").ReadOnly = True
            .Columns.Item("estanciah").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("estanciah").DataPropertyName = "Estancia hoy"

            .Columns("Area").ReadOnly = True
            .Columns.Item("Area").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Area").DataPropertyName = "area"

            .Columns("EPS").ReadOnly = True
            .Columns.Item("EPS").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("EPS").DataPropertyName = "EPS"

            .Columns("dias").ReadOnly = True
            .Columns.Item("dias").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("dias").DataPropertyName = "Dias estancias"

            .Columns("MAH").ReadOnly = True
            .Columns.Item("MAH").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("MAH").DataPropertyName = "MAH"

            .Columns("CT").ReadOnly = True
            .Columns.Item("CT").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CT").DataPropertyName = "CT"

            .Columns("SV").ReadOnly = True
            .Columns.Item("SV").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("SV").DataPropertyName = "SV"

            .Columns("ToT").ReadOnly = True
            .Columns.Item("ToT").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("ToT").DataPropertyName = "TOT"

            .Columns("CUR").ReadOnly = True
            .Columns.Item("CUR").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CUR").DataPropertyName = "CUR"

            .Columns("Diagnosticos").ReadOnly = True
            .Columns.Item("Diagnosticos").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Diagnosticos").DataPropertyName = "diagnosticos"

            .Columns("Pendiente").ReadOnly = True
            .Columns.Item("Pendiente").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Pendiente").DataPropertyName = "pendiente"

            .Columns("Correcciones").ReadOnly = True
            .Columns.Item("Correcciones").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Correcciones").DataPropertyName = "Correcciones"

            .Columns("generalr").ReadOnly = True
            .Columns.Item("generalr").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("generalr").DataPropertyName = "Generalidades R"

            .Columns("generalv").ReadOnly = True
            .Columns.Item("generalv").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("generalv").DataPropertyName = "Generalidades V"

            .Columns("observaciones").ReadOnly = True
            .Columns.Item("observaciones").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("observaciones").DataPropertyName = "observacion auditoria"
        End With
        dgConcurrencia.DataSource = dtConcurrencia
        Try
            Dim params As New List(Of String)
            params.Add(SesionActual.idUsuario)
            params.Add(SesionActual.codigoEP)
            params.Add(Nothing)
            General.cargarCombo(Consultas.PROC_AREA_SERVICIO_EMPLEADO_LLENAR, params, "Descripción", "Código", comboAreaServicio)
            Dim dtNuevo As DataTable
            dtNuevo = comboAreaServicio.DataSource.copy
            dtNuevo.Rows(0).Item(1) = "TODOS"
            comboAreaServicio.DataSource = dtNuevo
            cargarConcurrenciaPaciente()
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
        deshabilitarDG()
        btvia.Enabled = True
        btenfermedades.Enabled = True
    End Sub

    Public Sub establecerDatagriew()
        Dim dt, dt2, dt3, dt4, dt5, dt6, dt7, dt8, dt9, dt10,
            dt11, dt12, dt13, dt14, dt15, dt16, dt17, dt18, dt19 As New DataColumn

        dt.ColumnName = "Fecha admision"
        dt.DataType = Type.GetType("System.String")
        dtConcurrencia.Columns.Add(dt)

        dt2.ColumnName = "Paciente"
        dt2.DataType = Type.GetType("System.String")
        dtConcurrencia.Columns.Add(dt2)

        dt3.ColumnName = "Cama"
        dt3.DataType = Type.GetType("System.String")
        dtConcurrencia.Columns.Add(dt3)

        dt4.ColumnName = "Edad"
        dt4.DataType = Type.GetType("System.String")
        dtConcurrencia.Columns.Add(dt4)

        dt5.ColumnName = "Estancia hoy"
        dt5.DataType = Type.GetType("System.String")
        dtConcurrencia.Columns.Add(dt5)

        dt6.ColumnName = "Area"
        dt6.DataType = Type.GetType("System.String")
        dtConcurrencia.Columns.Add(dt6)

        dt7.ColumnName = "EPS"
        dt7.DataType = Type.GetType("System.String")
        dtConcurrencia.Columns.Add(dt7)

        dt8.ColumnName = "Dias estancias"
        dt8.DataType = Type.GetType("System.String")
        dtConcurrencia.Columns.Add(dt8)

        dt9.ColumnName = "MAH"
        dt9.DataType = Type.GetType("System.Boolean")
        dtConcurrencia.Columns.Add(dt9)

        dt10.ColumnName = "CT"
        dt10.DataType = Type.GetType("System.Boolean")
        dtConcurrencia.Columns.Add(dt10)

        dt11.ColumnName = "SV"
        dt11.DataType = Type.GetType("System.Boolean")
        dtConcurrencia.Columns.Add(dt11)

        dt12.ColumnName = "ToT"
        dt12.DataType = Type.GetType("System.Boolean")
        dtConcurrencia.Columns.Add(dt12)

        dt19.ColumnName = "CUR"
        dt19.DataType = Type.GetType("System.Boolean")
        dtConcurrencia.Columns.Add(dt19)

        dt13.ColumnName = "Diagnosticos"
        dt13.DataType = Type.GetType("System.String")
        dtConcurrencia.Columns.Add(dt13)

        dt14.ColumnName = "Pendiente"
        dt14.DataType = Type.GetType("System.String")
        dtConcurrencia.Columns.Add(dt14)

        dt15.ColumnName = "Correcciones"
        dt15.DataType = Type.GetType("System.String")
        dtConcurrencia.Columns.Add(dt15)

        dt16.ColumnName = "Generalidades R"
        dt16.DataType = Type.GetType("System.String")
        dtConcurrencia.Columns.Add(dt16)

        dt17.ColumnName = "Generalidades V"
        dt17.DataType = Type.GetType("System.String")
        dtConcurrencia.Columns.Add(dt17)

        dt18.ColumnName = "Observacion auditoria"
        dt18.DataType = Type.GetType("System.String")
        dtConcurrencia.Columns.Add(dt18)

        dt = Nothing : dt2 = Nothing : dt3 = Nothing : dt4 = Nothing : dt5 = Nothing
        dt6 = Nothing : dt7 = Nothing : dt8 = Nothing : dt9 = Nothing : dt10 = Nothing
        dt11 = Nothing : dt12 = Nothing : dt13 = Nothing : dt14 = Nothing : dt15 = Nothing
        dt16 = Nothing : dt17 = Nothing : dt18 = Nothing
    End Sub

    Public Function crearConcurrencia() As ConcurrenciaPaciente
        Dim objConcurrencias = New ConcurrenciaPaciente
        For Each drFila As DataRow In dtConcurrencia.Rows
            Dim drRespuesta As DataRow = objConcurrencias.dtConcurrencia.NewRow
            drRespuesta.Item("fecha") = drFila.Item("Fecha admision")
            drRespuesta.Item("codigo_cama") = drFila.Item("codigo_cama")
            drRespuesta.Item("N_Registro") = drFila.Item("Registro")
            drRespuesta.Item("tot") = drFila.Item("TOT")
            drRespuesta.Item("sv") = drFila.Item("SV")
            drRespuesta.Item("ct") = drFila.Item("CT")
            drRespuesta.Item("mah") = drFila.Item("MAH")
            drRespuesta.Item("cur") = drFila.Item("CUR")
            drRespuesta.Item("pendientes") = drFila.Item("pendiente")
            drRespuesta.Item("correcciones") = drFila.Item("correcciones")
            drRespuesta.Item("generalidades_r") = drFila.Item("Generalidades R")
            drRespuesta.Item("generalidades_v") = drFila.Item("Generalidades V")
            drRespuesta.Item("observaciones_auditoria") = drFila.Item("observacion auditoria")
            drRespuesta.Item("usuario_creacion") = SesionActual.idUsuario
            objConcurrencias.dtConcurrencia.Rows.Add(drRespuesta)
        Next
        Return objConcurrencias
    End Function

    Public Sub guardarConcurrencia()
        Dim objConcurrenciaBLL As New ConcurrenciaBLL
        Dim objConcurrencia As New ConcurrenciaPaciente
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                objConcurrencia = crearConcurrencia()
                objConcurrenciaBLL.guardarConcurrencia(objConcurrencia, fecha.Text)
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                deshabilitarDG()
                btguardar.Enabled = False
                btcancelar.Enabled = False
                bteditar.Enabled = True
                btimprimir.Enabled = True
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Public Sub cargarConcurrenciaPaciente()

        If Not comboAreaServicio.SelectedIndex < 0 Then

            Dim params As New List(Of String)
            params.Add(fecha.Text)
            params.Add(comboAreaServicio.SelectedValue)
            params.Add(SesionActual.codigoEP)
            params.Add(busquedaPaciente.Text)
            General.llenarTabla(Consultas.CONCURRENCIA_BUSCAR, params, dtConcurrencia)
            If dtConcurrencia.Rows.Count > 0 Then
                dgConcurrencia.Columns("Codigo Area").Visible = False
                dgConcurrencia.Columns("Registro").Visible = False
                dgConcurrencia.Columns("codigo_cama").Visible = False
            End If
        End If

        If comboAreaServicio.SelectedIndex = 0 Then
            btimprimir.Enabled = False
        Else
            If dgConcurrencia.RowCount = 0 Then
                btimprimir.Enabled = False
            Else
                btimprimir.Enabled = True
            End If

        End If
        npaciente.Text = dgConcurrencia.RowCount
    End Sub

    Private Sub comboAreaServicio_SelectedVALUEChanged(sender As Object, e As EventArgs) Handles comboAreaServicio.SelectedValueChanged
        If IsNumeric(comboAreaServicio.SelectedValue) Then
            cargarConcurrenciaPaciente()
        End If
    End Sub

    Private Sub fecha_ValueChanged(sender As Object, e As EventArgs) Handles fecha.ValueChanged
        cargarConcurrenciaPaciente()
        If dgConcurrencia.Rows.Count = 0 Then
            btguardar.Enabled = False
        ElseIf dgConcurrencia.Rows.Count <> 0 And bteditar.Enabled = False Then
            btguardar.Enabled = True
        End If
    End Sub

    Private Sub dgConcurrencia_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgConcurrencia.DataError

    End Sub

    Private Sub dgConcurrencia_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgConcurrencia.CellDoubleClick
        General.abrirJustificacion(dgConcurrencia, dtConcurrencia, PanelJustificacionConcurrencia, txtJustificacionParaclinico, "pendiente", Not btguardar.Enabled)
        General.abrirJustificacion(dgConcurrencia, dtConcurrencia, PanelJustificacionConcurrencia, txtJustificacionParaclinico, "correcciones", Not btguardar.Enabled)
        General.abrirJustificacion(dgConcurrencia, dtConcurrencia, PanelJustificacionConcurrencia, txtJustificacionParaclinico, "generalr", Not btguardar.Enabled)
        General.abrirJustificacion(dgConcurrencia, dtConcurrencia, PanelJustificacionConcurrencia, txtJustificacionParaclinico, "generalv", Not btguardar.Enabled)
        General.abrirJustificacion(dgConcurrencia, dtConcurrencia, PanelJustificacionConcurrencia, txtJustificacionParaclinico, "observaciones", Not btguardar.Enabled)
    End Sub

    Public Sub cargarDiagnosticos()
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(dgConcurrencia.Rows(dgConcurrencia.CurrentCell.RowIndex).Cells("Registro").Value)
        General.llenarTabla(Consultas.CARGAR_DIAGNOSTICOS_ADMISION, params, dt)
        dgvDiag.DataSource = dt
        dgvDiag.Columns(2).Visible = False
    End Sub

    Private Sub dgConcurrencia_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgConcurrencia.CellClick
        If dtConcurrencia.Rows.Count > 0 Then
            If e.ColumnIndex = 13 Then
                If dgConcurrencia.Rows(dgConcurrencia.CurrentCell.RowIndex).Cells("Diagnosticos").Selected = True Then
                    Panel2.Visible = True
                    cargarDiagnosticos()
                Else
                    Panel2.Visible = False
                End If
            End If
        End If
    End Sub

    Private Sub BtSalirlOTES_Click(sender As Object, e As EventArgs) Handles BtSalirlOTES.Click
        Panel2.Visible = False
    End Sub

    Private Sub btOpcionPresentacion_Click(sender As Object, e As EventArgs) Handles btenfermedades.Click
        General.cargarForm(FormEstadisticaEnfermedades)
    End Sub

    Private Sub btvia_Click(sender As Object, e As EventArgs) Handles btvia.Click
        General.cargarForm(FormAnexo3Concurrencia)
    End Sub

    Private Sub dgConcurrencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgConcurrencia.KeyPress
        General.abrirJustificacion(dgConcurrencia, dtConcurrencia, PanelJustificacionConcurrencia, txtJustificacionParaclinico, "pendiente", Not btguardar.Enabled, e.KeyChar)
        General.abrirJustificacion(dgConcurrencia, dtConcurrencia, PanelJustificacionConcurrencia, txtJustificacionParaclinico, "correcciones", Not btguardar.Enabled, e.KeyChar)
        General.abrirJustificacion(dgConcurrencia, dtConcurrencia, PanelJustificacionConcurrencia, txtJustificacionParaclinico, "generalr", Not btguardar.Enabled, e.KeyChar)
        General.abrirJustificacion(dgConcurrencia, dtConcurrencia, PanelJustificacionConcurrencia, txtJustificacionParaclinico, "generalv", Not btguardar.Enabled, e.KeyChar)
        General.abrirJustificacion(dgConcurrencia, dtConcurrencia, PanelJustificacionConcurrencia, txtJustificacionParaclinico, "observaciones", Not btguardar.Enabled, e.KeyChar)
    End Sub

    Private Sub txtJustificacionParaclinico_Leave(sender As Object, e As EventArgs) Handles txtJustificacionParaclinico.Leave
        Try
            If PanelJustificacionConcurrencia.Visible = True Then
                PanelJustificacionConcurrencia.Visible = False
                If dgConcurrencia.Rows(dgConcurrencia.CurrentRow.Index).Cells("pendiente").Selected = True Then
                    dgConcurrencia.Rows(dgConcurrencia.CurrentRow.Index).Cells("pendiente").Value = txtJustificacionParaclinico.Text
                ElseIf dgConcurrencia.Rows(dgConcurrencia.CurrentRow.Index).Cells("correcciones").Selected = True Then
                    dgConcurrencia.Rows(dgConcurrencia.CurrentRow.Index).Cells("correcciones").Value = txtJustificacionParaclinico.Text
                ElseIf dgConcurrencia.Rows(dgConcurrencia.CurrentRow.Index).Cells("generalr").Selected = True Then
                    dgConcurrencia.Rows(dgConcurrencia.CurrentRow.Index).Cells("generalr").Value = txtJustificacionParaclinico.Text
                ElseIf dgConcurrencia.Rows(dgConcurrencia.CurrentRow.Index).Cells("generalv").Selected = True Then
                    dgConcurrencia.Rows(dgConcurrencia.CurrentRow.Index).Cells("generalv").Value = txtJustificacionParaclinico.Text
                ElseIf dgConcurrencia.Rows(dgConcurrencia.CurrentRow.Index).Cells("observaciones").Selected = True Then
                    dgConcurrencia.Rows(dgConcurrencia.CurrentRow.Index).Cells("observaciones").Value = txtJustificacionParaclinico.Text
                End If
                txtJustificacionParaclinico.Clear()
                dgConcurrencia.EndEdit()
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea cancelar este registro?", 32 + 1, "cancelar") = 1 Then
            deshabilitarDG()
            btcancelar.Enabled = False
            bteditar.Enabled = True
            btguardar.Enabled = False
            btimprimir.Enabled = False
        End If

    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If btguardar.Enabled = True Then
            MsgBox("Por favor guarde la información del cateter", MsgBoxStyle.Information)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try
            Dim ruta, area, nombreArchivo As String
            area = ConstantesHC.NOMBRE_PDF_CONCURRENCIA
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & dgConcurrencia.Rows(dgConcurrencia.CurrentCell.RowIndex).Cells("Registro").Value & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo

            guardarReportecateter()
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub guardarReportecateter()
        Try
            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_CONCURRENCIA, dgConcurrencia.Rows(dgConcurrencia.CurrentCell.RowIndex).Cells("Registro").Value, New rptConcurrenciaEnfermeria,
                                   dgConcurrencia.Rows(dgConcurrencia.CurrentCell.RowIndex).Cells("Registro").Value, "{VISTA_CONCURRENCIA.Fecha} = '" & Format(fecha.Value.Date, "yyyy-MM-dd") & "' and {VISTA_CONCURRENCIA.Codigo_Area_Servicio} =" & comboAreaServicio.SelectedValue & "",
                                    ConstantesHC.NOMBRE_PDF_CONCURRENCIA, IO.Path.GetTempPath)

        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Sub FormConcurrencia_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub busquedaPaciente_TextChanged(sender As Object, e As EventArgs) Handles busquedaPaciente.TextChanged
        cargarConcurrenciaPaciente()
    End Sub



    Private Sub deshabilitarDG()
        dgConcurrencia.Columns(0).ReadOnly = True
        dgConcurrencia.Columns("paciente").ReadOnly = True
        dgConcurrencia.Columns("cama").ReadOnly = True
        dgConcurrencia.Columns("area").ReadOnly = True
        dgConcurrencia.Columns("edad").ReadOnly = True
        dgConcurrencia.Columns("eps").ReadOnly = True
        dgConcurrencia.Columns("mah").ReadOnly = True
        dgConcurrencia.Columns("ct").ReadOnly = True
        dgConcurrencia.Columns("sv").ReadOnly = True
        dgConcurrencia.Columns("tot").ReadOnly = True
        dgConcurrencia.Columns("cur").ReadOnly = True
    End Sub

    Private Sub habilitarDG()

        dgConcurrencia.Columns("mah").ReadOnly = False
        dgConcurrencia.Columns("ct").ReadOnly = False
        dgConcurrencia.Columns("sv").ReadOnly = False
        dgConcurrencia.Columns("tot").ReadOnly = False
        dgConcurrencia.Columns("cur").ReadOnly = False

    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        'If SesionActual.tienePermiso(Peditar ) Then

        habilitarDG()
        btcancelar.Enabled = True
            btguardar.Enabled = True
        bteditar.Enabled = False
        comboAreaServicio.Enabled = True
        fecha.Enabled = True
        'Else
        '    MsgBox(Mensajes.SINPERMISO)
        'End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgConcurrencia.CommitEdit(DataGridViewDataErrorContexts.Commit)
        dgConcurrencia.EndEdit()
        guardarConcurrencia()
    End Sub
End Class