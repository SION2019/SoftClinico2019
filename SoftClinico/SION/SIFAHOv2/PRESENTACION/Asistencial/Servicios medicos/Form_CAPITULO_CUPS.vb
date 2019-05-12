Public Class Form_CAPITULO_CUPS
    Public buscar_C As Boolean
    Dim enlce_dta As BindingSource = New BindingSource
    Dim i, c As Integer
    Dim cups As New CCUPS_D
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

        Try
            dgvprocedimiento.EndEdit()
            If cups.guardar(dgvprocedimiento) = True Then
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information,)
                btguardar.Enabled = False
                btanular.Enabled = False
                bteditar.Enabled = True
                btcancelar.Enabled = False
                btnuevo.Enabled = True
                TextBox1.Clear()
                llenar_dgv()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

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

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
            TextBox1.Clear()
            Editar()
        End If
    End Sub

    Private Sub dgvprocedimiento_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvprocedimiento.CellDoubleClick
        If btguardar.Enabled = True Then
            If e.ColumnIndex = 6 Or e.ColumnIndex = 7 Then
                General.buscarElemento(Consultas.BUSQUEDA_CAPITULO_CUPS2, Nothing,
                                       AddressOf cargarCups,
                                       TitulosForm.BUSQUEDA_CAPITULO_CUPS2,
                                       False)

                dgvprocedimiento_CellEndEdit(sender, e)
            End If
        End If
    End Sub

    Public Sub cargarCups(pCodigo As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.BUSQUEDA_CAPITULO_CUPS_CARGAR, params, dt)

        dgvprocedimiento.Rows(dgvprocedimiento.CurrentCell.RowIndex).Cells(6).Value = dt.Rows(0).Item("Capitulo")
        dgvprocedimiento.Rows(dgvprocedimiento.CurrentCell.RowIndex).Cells(7).Value = dt.Rows(0).Item("Descripción")
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.Text = Funciones.validarComillaSimple(TextBox1.Text)
        enlce_dta.Filter = "[Código] LIKE '%" + TextBox1.Text.Trim() + "%' or [Descripción] LIKE '%" + TextBox1.Text.Trim() + "%' or [Seccion] LIKE '%" + TextBox1.Text.Trim() + "%' or [Descripción seccion] LIKE '%" + TextBox1.Text.Trim() + "%'"
    End Sub

    Private Sub Editar()
        dgvprocedimiento.MultiSelect = False : dgvprocedimiento.Rows(0).Cells("Código").Selected = True
        dgvprocedimiento.ReadOnly = False
        dgvprocedimiento.MultiSelect = False
        dgvprocedimiento.Columns(7).ReadOnly = True
        dgvprocedimiento.Columns(6).ReadOnly = True
        General.habilitarBotones(ToolStrip1)
        bteditar.Enabled = False
        btnuevo.Enabled = False
    End Sub

    Private Sub Form_CAPITULO_CUPS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_dgv()
    End Sub

    Public Sub llenar_dgv()
        Dim params As New List(Of String)
        Dim i As Integer
        params.Add(TextBox1.Text)
        General.llenarTabla(Consultas.CARGAR_CAPCUPS, params, dt)

        enlce_dta.DataSource = dt
        dgvprocedimiento.DataSource = enlce_dta.DataSource
        dgvprocedimiento.ReadOnly = True
        dgvprocedimiento.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvprocedimiento.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
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
            dgvprocedimiento.Columns("Descripción").Width = "800"
            dgvprocedimiento.Columns(7).Width = "500"
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