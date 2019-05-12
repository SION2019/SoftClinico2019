Imports System.Data.SqlClient
Public Class FormReferenciaExamConf
    Dim objConfProcedimientoBLL As New ProcedimientoReferenciaConfigBLL
    Public Property objParaclinico As ParaclinicoLaboratorio
    Dim objReferencia As New ConfigReferenciaExam
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
        btcancelar.Enabled = True
        btguardar.Enabled = True
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If ComboArea.SelectedIndex = 0 Then
            Exec.SavingMsg("¡ Favor seleccionar un Examén !", ComboArea)
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Try
                    dgvprocedimientos.CommitEdit(DataGridViewDataErrorContexts.Commit)
                    Me.Cursor = Cursors.WaitCursor
                    objConfProcedimientoBLL.guardarReferencia(objReferencia)
                    General.deshabilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    General.limpiarControles(Me)
                    bteditar.Enabled = True
                    Me.Cursor = Cursors.Default
                    If General.verificar_formulario(FormExamenParaclinicosNuevo) = True Then
                        objParaclinico.CargarParametros()
                    End If
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub
    Public Sub llenarCombo()
        General.cargarCombo(Consultas.PROCEDIMIENTOS_CUPS_PARACLINICOS_LISTAR, "Descripcion", "Codigo", ComboArea)
        General.cargarCombo(Consultas.SEXO_LISTAR, "Descripción genero", "Código", cbGenero)
    End Sub
    Private Sub datosGrilla()
        EnlceDta.DataSource = objReferencia.dtReferenciaExam
        With dgvprocedimientos
            .DataSource = EnlceDta.DataSource
            .Columns("Codigo").Visible = False
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("Referencia").ReadOnly = False
            .Columns("Unidad").ReadOnly = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With
        dgvprocedimientos.AutoGenerateColumns = False
    End Sub
    Private Sub cargarProcedimiento()
        Cursor.Current = Cursors.WaitCursor
        datosGrilla()
        objReferencia.CodigoTipo = ComboArea.SelectedValue
        objReferencia.CodigoGenero = cbGenero.SelectedValue
        objReferencia.llenarTabla()
        lbCantidad.Text = "Cantidad de items: " & objReferencia.dtReferenciaExam.Rows.Count
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub textbusqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbusqueda.KeyDown
        If e.KeyCode = Keys.Enter Then
            EnlceDta.Filter = "[Descripcion] LIKE '%" + txtbusqueda.Text.Trim() + "%' OR [Codigo] LIKE '%" + txtbusqueda.Text.Trim() + "%'  "
        End If
    End Sub
    Private Sub textbusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtbusqueda.TextChanged
        If String.IsNullOrEmpty(txtbusqueda.Text) Then
            EnlceDta.Filter = "[Descripcion] LIKE '%" + txtbusqueda.Text.Trim() + "%' OR [Codigo] LIKE '%" + txtbusqueda.Text.Trim() + "%'  "
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
    Private Sub ComboArea_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboArea.SelectedValueChanged
        If ComboArea.ValueMember <> Nothing Then
            cargarProcedimiento()
        End If
    End Sub
    Private Sub cbGenero_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbGenero.SelectedValueChanged
        If cbGenero.ValueMember <> Nothing Then
            cargarProcedimiento()
        End If
    End Sub
    Private Sub BtExamen_Click(sender As Object, e As EventArgs) Handles BtExamen.Click
        Dim formParametroParac As New FormParametroExamConfiguracion
        formParametroParac.ShowDialog()
    End Sub
End Class