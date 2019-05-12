Public Class Form_CARTICULO_SOAT
    Dim enlce_dta As BindingSource = New BindingSource
    Dim i, c As Integer
    Dim cups As New CARTICULO_D
    Dim dt As New DataTable

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        TextBox1.Clear()
        llenar_dgv()
        Editar()
        dt.Rows.Add()
        dt.AcceptChanges()
        dgvprocedimiento.DataSource = enlce_dta
        dgvprocedimiento.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvprocedimiento.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        enlce_dta.Filter = ""
        dgvprocedimiento.CommitEdit(DataGridViewDataErrorContexts.Commit)
        dgvprocedimiento.Focus()
        dgvprocedimiento.CurrentCell = dgvprocedimiento(dgvprocedimiento.Columns("Código").Index, dgvprocedimiento.RowCount - 1)

    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, bteditar)
        TextBox1.ReadOnly = False
        llenar_dgv()
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
            If dgvprocedimiento.CurrentRow.Index <> dgvprocedimiento.RowCount - 1 Or dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Codigo_Oculto").Value.ToString <> "" Then
                dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Eliminación").Value = True
                dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Tomato
            End If
        End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        dgvprocedimiento.EndEdit()
        If cups.guardar(Me) = True Then
            MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information,)
            btguardar.Enabled = False
            btanular.Enabled = False
            bteditar.Enabled = True
            btcancelar.Enabled = False
            btnuevo.Enabled = True
            TextBox1.Clear()
            llenar_dgv()
        End If
    End Sub

    Private Sub dgvprocedimiento_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvprocedimiento.CellEndEdit
        If dgvprocedimiento.CurrentRow.Index = dgvprocedimiento.RowCount - 1 And dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Codigo_Oculto").Value.ToString = "" Then
            dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Inserción").Value = True
            dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192) 'Verde
            dt.Rows.Add()
        Else
            If dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Inserción").Value = False Then
                If dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Eliminación").Value = False Then
                    dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Edición").Value = True
                    dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192) 'Color.Yellow
                End If
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.Text = Funciones.validarComillaSimple(TextBox1.Text)
        enlce_dta.Filter = "[Código] LIKE '%" + TextBox1.Text.Trim() + "%' or [Descripción] LIKE '%" + TextBox1.Text.Trim() + "%'  "
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
            TextBox1.Clear()
            Editar()
        End If
    End Sub

    Private Sub Editar()
        dgvprocedimiento.MultiSelect = False : dgvprocedimiento.Rows(0).Cells("Código").Selected = True
        dgvprocedimiento.ReadOnly = False
        dgvprocedimiento.MultiSelect = False
        General.habilitarBotones(ToolStrip1)
        bteditar.Enabled = False
        btnuevo.Enabled = False
    End Sub

    Private Sub Form_CARTICULO_SOAT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_dgv()
    End Sub

    Public Sub llenar_dgv()
        dt = cups.llenar_dgv(TextBox1.Text)
        Dim i As Integer
        enlce_dta.DataSource = dt
        dgvprocedimiento.DataSource = enlce_dta.DataSource
        dgvprocedimiento.ReadOnly = True
        If dt.Rows.Count > 0 Then
            For i = 0 To dgvprocedimiento.Columns.Count - 1
                dgvprocedimiento.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                dgvprocedimiento.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                dgvprocedimiento.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            dgvprocedimiento.Columns(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            dgvprocedimiento.Columns("Código").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvprocedimiento.Columns("Descripción").AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            dgvprocedimiento.Columns("Código").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvprocedimiento.Columns("Descripción").Width = "940"
            dgvprocedimiento.Columns(4).Width = "80"
            dgvprocedimiento.Columns("codigo_oculto").Visible = False
            dgvprocedimiento.Columns("Inserción").Visible = False
            dgvprocedimiento.Columns("Edición").Visible = False
            dgvprocedimiento.Columns("Eliminación").Visible = False
            dgvprocedimiento.Columns("codigo_oculto").Frozen = True
            dgvprocedimiento.Columns("Inserción").Frozen = True
            dgvprocedimiento.Columns("Edición").Frozen = True
            dgvprocedimiento.Columns("Eliminación").Frozen = True
            dgvprocedimiento.Columns("Código").Frozen = True

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
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub
End Class