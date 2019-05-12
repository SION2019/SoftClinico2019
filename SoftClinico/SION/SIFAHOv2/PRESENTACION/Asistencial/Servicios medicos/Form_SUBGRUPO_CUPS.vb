Public Class Form_SUBGRUPO_CUPS
    Dim enlce_dta As BindingSource = New BindingSource
    Dim i, c As Integer
    Dim cups As New SGCUPS_D
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
        If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Or dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Codigo_Oculto").Value.ToString <> "" Then
            If dgvprocedimiento.CurrentRow.Index <> dgvprocedimiento.RowCount - 1 Then
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
        Dim vSGCUPS = buildSGCUPS()
        If ((vSGCUPS IsNot Nothing) AndAlso (cups.guardar(vSGCUPS) = True)) Then
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
    Private Function buildSGCUPS() As SGCUPS
        Dim vSGCUPS As New SGCUPS
        Dim i, j, l, indcdor, clmna_inicio, clmna_fin, cmpo_inicio, cmpo_fin As Integer
        Dim cdna, cadena, cdna_insert, cdna_update, cdna_delete, valor As String
        Dim bndra As Boolean


        vSGCUPS.dt_delete = New DataTable() : vSGCUPS.dt_update = New DataTable()

        cdna_insert = "" : cdna_update = "" : cdna_delete = "" : indcdor = 0 : bndra = True

        clmna_inicio = 4 : clmna_fin = 6 : cmpo_inicio = 4 : cmpo_fin = 9
        cdna_insert = "INSERT INTO M_SUBGRUPOS_CUPS(Codigo_SubGrupo,Descripcion ,Codigo_Grupo) VALUES("
        cdna_update = "UPDATE M_SUBGRUPOS_CUPS SET Codigo_SubGrupo='_valor1',Descripcion='_valor2',Codigo_Grupo='_valor3' WHERE Codigo_SubGrupo='_condicion'"
        cdna_delete = "DELETE M_SUBGRUPOS_CUPS WHERE Codigo_SubGrupo='_condicion'"


        For i = 0 To dgvprocedimiento.RowCount - 1

            If (IsDBNull(dgvprocedimiento.Rows(i).Cells("Inserción").Value) = True Or dgvprocedimiento.Rows(i).Cells("Código").Value.ToString = "") And i <> dgvprocedimiento.RowCount - 1 Then
                MsgBox("error al validar dgv, falta información", MsgBoxStyle.Critical)
                Return Nothing
                Exit For
            ElseIf (IsDBNull(dgvprocedimiento.Rows(i).Cells("Inserción").Value) = True Or dgvprocedimiento.Rows(i).Cells("Código").Value.ToString = "") And i = dgvprocedimiento.RowCount - 1 Then
                Exit For
            End If
            If dgvprocedimiento.Rows(i).Cells("Inserción").Value = True Then
                bndra = Validar_dgv(i, clmna_inicio, clmna_fin)
                If bndra Then

                    Return Nothing
                Else
                    If indcdor <> 0 Then
                        cdna_insert = cdna_insert & ",("
                    End If
                    For j = clmna_inicio To clmna_fin
                        If dgvprocedimiento.Rows(i).Cells(j).ValueType.ToString = "System.String" Then
                            valor = dgvprocedimiento.Rows(i).Cells(j).Value.ToString()
                        Else
                            If IsDBNull(dgvprocedimiento.Rows(i).Cells(j).Value) Then
                                valor = "False"
                            Else
                                valor = "True"
                            End If
                        End If
                        If j <> 7 Then
                            If j = clmna_fin Then
                                cdna_insert = cdna_insert & "'" & valor & "'"
                            Else
                                cdna_insert = cdna_insert & "'" & valor & "'"
                            End If

                            If j <> clmna_fin Then
                                cdna_insert = cdna_insert & ","
                            End If
                        End If
                    Next
                    cdna_insert = cdna_insert & ")"
                    indcdor = indcdor + 1
                End If
            ElseIf dgvprocedimiento.Rows(i).Cells("Edición").Value = True Then
                bndra = Validar_dgv(i, clmna_inicio, clmna_fin)
                If bndra Then

                    Return Nothing
                Else
                    l = 1
                    cdna = cdna_update
                    For j = clmna_inicio To clmna_fin
                        cadena = "_valor" & CStr(l)
                        If dgvprocedimiento.Rows(i).Cells(j).ValueType.ToString = "System.String" Then
                            valor = dgvprocedimiento.Rows(i).Cells(j).Value.ToString()
                        Else
                            valor = dgvprocedimiento.Rows(i).Cells(j).Value.ToString()
                        End If

                        If j = clmna_fin Then
                            cdna = Replace(cdna, cadena, valor)
                        Else
                            cdna = Replace(cdna, cadena, valor)
                        End If
                        l = l + 1
                    Next
                    cdna = Replace(cdna, "_condicion", dgvprocedimiento.Rows(i).Cells(clmna_inicio - 1).Value.ToString())
                    If vSGCUPS.dt_update.Columns.Count <= 0 Then
                        vSGCUPS.dt_update.Columns.Add("Consulta")
                    End If
                    vSGCUPS.dt_update.Rows.Add()
                    vSGCUPS.dt_update.Rows(vSGCUPS.dt_update.Rows.Count - 1).Item(0) = cdna
                End If
            ElseIf dgvprocedimiento.Rows(i).Cells("Eliminación").Value = True Then
                cdna_delete = Replace(cdna_delete, "_condicion", dgvprocedimiento.Rows(i).Cells(clmna_inicio - 1).Value.ToString())
                If vSGCUPS.dt_delete.Columns.Count <= 0 Then
                    vSGCUPS.dt_delete.Columns.Add("Consulta")
                End If
                vSGCUPS.dt_delete.Rows.Add()
                vSGCUPS.dt_delete.Rows(vSGCUPS.dt_delete.Rows.Count - 1).Item(0) = cdna_delete
            End If
        Next

        vSGCUPS.indcdor = indcdor
        vSGCUPS.cdna_insert = cdna_insert

        Return vSGCUPS
    End Function
    Private Function Validar_dgv(fila_actual As Integer, clmna_inicio As Integer, clmna_fin As Integer) As Boolean
        Dim bndra As Boolean
        Dim i As Integer

        bndra = False

        For i = clmna_inicio To clmna_fin
            If dgvprocedimiento.Rows(fila_actual).Cells(i).ValueType = Type.GetType("System.String") Then
                If String.IsNullOrEmpty(dgvprocedimiento.Rows(fila_actual).Cells(i).Value.ToString) Or String.IsNullOrWhiteSpace(dgvprocedimiento.Rows(fila_actual).Cells(i).Value.ToString) Then
                    bndra = True
                    MsgBox("Hace falta un dato", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Advertencia")
                    dgvprocedimiento.Rows(fila_actual).Cells(i).Selected = True
                    Exit For
                End If
            End If
        Next
        Return bndra
    End Function
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
                General.buscarElemento(Consultas.BUSQUEDA_SGCUPS, Nothing, AddressOf cargar, TitulosForm.BUSQUEDA_SGCUPS, True)
                dgvprocedimiento_CellEndEdit(sender, e)
            End If
        End If
    End Sub

    Sub cargar(pcodigo As String)
        dgvprocedimiento.CurrentRow.Cells(6).Value = pcodigo.Split("|")(0)
        dgvprocedimiento.CurrentRow.Cells(7).Value = pcodigo.Split("|")(1)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.Text = Funciones.validarComillaSimple(TextBox1.Text)
        enlce_dta.Filter = "[Código] LIKE '%" + TextBox1.Text.Trim() + "%' or [Descripción] LIKE '%" + TextBox1.Text.Trim() + "%' or [Grupo] LIKE '%" + TextBox1.Text.Trim() + "%' or [Descripción grupo] LIKE '%" + TextBox1.Text.Trim() + "%'"
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

    Private Sub Form_CATEGORIA_CUPS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_dgv()
    End Sub

    Public Sub llenar_dgv()

        dt = cups.llenar_dgv(TextBox1.Text)
        Dim i As Integer
        enlce_dta.DataSource = dt
        dgvprocedimiento.DataSource = enlce_dta.DataSource
        dgvprocedimiento.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvprocedimiento.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
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