Imports System.Data.SqlClient
Public Class FormOtraConfiguracion
    Dim objConfProcedimientoBLL As New ProcedimientoEstanciaConfigBLL
    Dim objProcedimiento As New ConfiguracionProcedimientoCups
    Dim EnlceDta As BindingSource = New BindingSource
    Private Sub Form_configuracion_procedimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        bteditar.Enabled = True
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Combogrupos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboArea.SelectedIndexChanged
        If ComboArea.ValueMember <> Nothing Then
            cargarProcedimientos()
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, bteditar, bteditar)
        cargarProcedimientos()
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
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        General.habilitarControles(Me)
        General.deshabilitarBotones(ToolStrip1)
        cargarProcedimientos()
        btcancelar.Enabled = True
        btguardar.Enabled = True
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If ComboArea.SelectedIndex = 0 Then
            Exec.SavingMsg("¡ Favor seleccionar un grupo !", ComboArea)
        ElseIf objProcedimiento.dtProcedimiento.Select("[Seleccionar] = True").Count = 0 Then
            Exec.SavingMsg("¡ Favor seleccionar algún item !", dgvprocedimientos)
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Try
                    dgvprocedimientos.CommitEdit(DataGridViewDataErrorContexts.Commit)
                    Me.Cursor = Cursors.WaitCursor
                    objConfProcedimientoBLL.guardarProcedimiento(objProcedimiento)
                    General.deshabilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    General.limpiarControles(Me)
                    bteditar.Enabled = True
                    Me.Cursor = Cursors.Default
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub
    Public Sub llenarCombo(codigoConfig As Integer)
        objProcedimiento.codigoConfig = codigoConfig
        General.cargarCombo(objProcedimiento.consulta(1) & "", "Descripcion", "Codigo", ComboArea)
    End Sub
    Private Sub datosGrilla()
        EnlceDta.DataSource = objProcedimiento.dtProcedimiento
        With dgvprocedimientos
            .DataSource = EnlceDta.DataSource
            .Columns("Codigo").ReadOnly = True
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("Seleccionar").ReadOnly = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With
        dgvprocedimientos.AutoGenerateColumns = False
    End Sub
    Private Sub cargarProcedimientos()
        Cursor.Current = Cursors.WaitCursor
        datosGrilla()
        objProcedimiento.CodigoTipo = ComboArea.SelectedValue
        objProcedimiento.llenarTabla()
        lbCantidad.Text = "Cantidad de items: " & objProcedimiento.dtProcedimiento.Rows.Count
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub textbusqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbusqueda.KeyDown
        If e.KeyCode = Keys.Enter Then
            EnlceDta.Filter = "[Descripcion] LIKE '%" + Replace(txtbusqueda.Text.Trim(), "'", String.Empty) + "%' OR [Codigo] LIKE '%" + Replace(txtbusqueda.Text.Trim(), "'", String.Empty) + "%'  "
        End If
    End Sub
    Private Sub textbusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtbusqueda.TextChanged
        If String.IsNullOrEmpty(txtbusqueda.Text) Then
            EnlceDta.Filter = "[Descripcion] LIKE '%" + Replace(txtbusqueda.Text.Trim(), "'", String.Empty) + "%' OR [Codigo] LIKE '%" + Replace(txtbusqueda.Text.Trim(), "'", String.Empty) + "%'  "
        End If
    End Sub
    Private Sub dgvprocedimientos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvprocedimientos.CellClick
        If e.ColumnIndex = 2 Then
            If ComboArea.SelectedIndex = 0 Then
                MsgBox(Mensajes.SELECCIONAR_ITEM, MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btExamens_Click(sender As Object, e As EventArgs) Handles btOpcionExamens.Click
        If objProcedimiento.codigoConfig = Constantes.GRUPO_PARACLINICO Then
            Dim formTipoExamen As New FormTipoExamen
            formTipoExamen.ShowDialog()
        End If
    End Sub

    Private Sub btOpcionPerfil_Click(sender As Object, e As EventArgs)
        General.mensajeProximante()
    End Sub


End Class