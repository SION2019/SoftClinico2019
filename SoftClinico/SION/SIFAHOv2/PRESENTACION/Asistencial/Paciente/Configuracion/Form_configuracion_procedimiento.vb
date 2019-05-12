Public Class Form_configuracion_procedimiento
    Dim EnlceDta As BindingSource = New BindingSource
    Dim objConfProcedimientoBLL As New ProcedimientoConfigBLL
    Dim objConfProcedimiento As New ConfiguracionProcedimientoCups
    Private Sub Form_configuracion_procedimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        bteditar.Enabled = True
        General.cargarCombo(objConfProcedimiento.consulta(1), "Descripcion", "Codigo", Combogrupos)
        objConfProcedimiento.codigoPunto = SesionActual.codigoEP
        objConfProcedimiento.usuario = SesionActual.idUsuario
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Combogrupos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combogrupos.SelectedIndexChanged
        If Combogrupos.ValueMember <> Nothing Then
            cargarProcedimiento()
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, bteditar, bteditar)
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        General.habilitarControles(Me)
        General.deshabilitarBotones(ToolStrip1)
        cargarProcedimiento()
        btcancelar.Enabled = True
        btguardar.Enabled = True
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgvprocedimientos.EndEdit()
        dgvprocedimientos.CommitEdit(DataGridViewDataErrorContexts.Commit)

        If Combogrupos.SelectedIndex = 0 Then
            Exec.SavingMsg("¡ Favor seleccionar un grupo !", Combogrupos)
        ElseIf objConfProcedimiento.dtProcedimiento.Select("[Seleccionar] = True").Count = 0 Then
            Exec.SavingMsg("¡ Favor seleccionar algún item !", dgvprocedimientos)
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

                Try
                    Cursor.Current = Cursors.WaitCursor
                    objConfProcedimientoBLL.guardarProcedimiento(objConfProcedimiento)
                    General.deshabilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    General.limpiarControles(Me)
                    bteditar.Enabled = True
                    Cursor.Current = Cursors.Default
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub
    Private Sub Form__FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub OtrasConfiguracionesToolStripMenuItem_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles OtrasConfiguracionesToolStripMenuItem.DropDownItemClicked
        objConfProcedimientoBLL.llamarOtrasConfiguraciones(OtrasConfiguracionesToolStripMenuItem.DropDownItems, objConfProcedimiento)
    End Sub
    Private Sub validarDgv()
        EnlceDta.DataSource = objConfProcedimiento.dtProcedimiento
        With dgvprocedimientos
            .DataSource = EnlceDta.DataSource
            .Columns("Codigo").ReadOnly = True
            .Columns("Descripcion").ReadOnly = True
            .Columns("Seleccionar").ReadOnly = False
            .Columns("Descripcion").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With
        dgvprocedimientos.AutoGenerateColumns = False
    End Sub
    Private Sub dgvprocedimientos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvprocedimientos.CellClick
        If e.ColumnIndex = 2 Then
            If Combogrupos.SelectedIndex = 0 Then
                MsgBox(Mensajes.SELECCIONAR_ITEM, MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If
    End Sub
    Private Sub cargarProcedimiento()
        Cursor.Current = Cursors.WaitCursor
        objConfProcedimiento.CodigoTipo = Combogrupos.SelectedValue
        objConfProcedimiento.llenarTabla()
        validarDgv()
        lbCantidad.Text = "Cantidad de items: " & objConfProcedimiento.dtProcedimiento.Rows.Count
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub textbusqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles textbusqueda.KeyDown
        If e.KeyCode = Keys.Enter Then
            textbusqueda.Text = Funciones.validarComillaSimple(textbusqueda.Text)
            EnlceDta.Filter = "[Descripcion] LIKE '%" + textbusqueda.Text.Trim() + "%' OR [Codigo] LIKE '%" + textbusqueda.Text.Trim() + "%'  "
        End If
    End Sub
    Private Sub textbusqueda_TextChanged(sender As Object, e As EventArgs) Handles textbusqueda.TextChanged
        If String.IsNullOrEmpty(textbusqueda.Text) Then
            textbusqueda.Text = Funciones.validarComillaSimple(textbusqueda.Text)
            EnlceDta.Filter = "[Descripcion] LIKE '%" + textbusqueda.Text.Trim() + "%' OR [Codigo] LIKE '%" + textbusqueda.Text.Trim() + "%'  "
        End If
    End Sub
End Class