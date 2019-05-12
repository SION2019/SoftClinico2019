Imports System.Data.SqlClient
Public Class FormParametroExamConfiguracion
    Dim objConfParametroBLL As New ProcedimientoParametroConfigBLL
    Dim objParametro As New ConfigParametroExam
    Dim EnlceDta As BindingSource = New BindingSource
    Private Sub Form_configuracion_procedimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        llenarCombo()
        bteditar.Enabled = True
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Combogrupos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboArea.SelectedIndexChanged
        If ComboArea.ValueMember <> Nothing Then
            cargarParametroExam()
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, bteditar, bteditar)
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
        cargarParametroExam()
        btcancelar.Enabled = True
        btguardar.Enabled = True
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgvprocedimientos.EndEdit()
        dgvprocedimientos.CommitEdit(DataGridViewDataErrorContexts.Commit)

        If ComboArea.SelectedIndex = 0 Then
            Exec.SavingMsg("¡ Favor seleccionar un Tipo Examen !", ComboArea)
        ElseIf objParametro.dtParamsExam.Select("[Seleccionar] = True").Count = 0 Then
            Exec.SavingMsg("¡ Favor seleccionar algún item !", dgvprocedimientos)
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Try
                    Me.Cursor = Cursors.WaitCursor
                    objConfParametroBLL.guardarParametro(objParametro)
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
    Public Sub llenarCombo()
        General.cargarCombo(Consultas.PARAMETRO_EXAM_CONFIGURACION_LISTA, "Descripcion", "Codigo", ComboArea)
    End Sub
    Private Sub datosGrilla()
        EnlceDta.DataSource = objParametro.dtParamsExam
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
    Public Sub cargarParametroExam()
        Cursor.Current = Cursors.WaitCursor
        datosGrilla()
        objParametro.CodigoTipo = ComboArea.SelectedValue
        objParametro.llenarTabla()
        lbCantidad.Text = "Cantidad de items: " & objParametro.dtParamsExam.Rows.Count
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub textbusqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbusqueda.KeyDown
        If e.KeyCode = Keys.Enter Then
            EnlceDta.Filter = "[Descripcion] LIKE '%" + Replace(txtbusqueda.Text.Trim(), "'", "") + "%' OR [Codigo] LIKE '%" + Replace(txtbusqueda.Text.Trim(), "'", "") + "%'  "
        End If
    End Sub
    Private Sub textbusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtbusqueda.TextChanged
        If String.IsNullOrEmpty(txtbusqueda.Text) Then
            EnlceDta.Filter = "[Descripcion] LIKE '%" + Replace(txtbusqueda.Text.Trim(), "'", "") + "%' OR [Codigo] LIKE '%" + Replace(txtbusqueda.Text.Trim(), "'", "") + "%'  "
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
    Private Sub btParametro_Click(sender As Object, e As EventArgs) Handles btParametro.Click
        Dim formParamsExam As New FormParametros
        formParamsExam.parametroExamen = Me
        formParamsExam.ShowDialog()
    End Sub
    Private Sub BtExamen_Click(sender As Object, e As EventArgs) Handles BtExamen.Click
        Dim formTipoExam As New FormTipoExamen
        formTipoExam.parametroExamen = Me
        formTipoExam.ShowDialog()
    End Sub
End Class