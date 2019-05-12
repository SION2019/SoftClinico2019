Public Class Form_SOAT
    Dim objManualSOAT As New ManualSOAT
    Dim cups As New SoatBLL
    Dim perG As New Buscar_Permisos_generales
    Dim colCodigo, colDescripcion As Integer
    Public permiso_general, Pnuevo, Peditar, Panular, Pgrupoqx, Pgrupo, Pcapitulo, Particulo, Pseccion, Psala, PCarticulo As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            llenar_dgv()
            Editar()
            objManualSOAT.dtProcedimiento.Rows.Add()
            objManualSOAT.dtProcedimiento.AcceptChanges()
            dgvprocedimiento.DataSource = objManualSOAT.enlceData
            dgvprocedimiento.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvprocedimiento.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            objManualSOAT.enlceData.Filter = ""
            dgvprocedimiento.CommitEdit(DataGridViewDataErrorContexts.Commit)
            dgvprocedimiento.Focus()
            dgvprocedimiento.CurrentCell = dgvprocedimiento(dgvprocedimiento.Columns("Código").Index, dgvprocedimiento.RowCount - 1)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        dgvprocedimiento.CancelEdit()
        General.formCancelar(Me, ToolStrip1, btnuevo, Nothing)
        btnuevo.Enabled = False
        BUSCARMAN.Enabled = True
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                If dgvprocedimiento.CurrentRow.Index <> dgvprocedimiento.RowCount - 1 Or dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Codigo_Oculto").Value.ToString <> "" Then
                    dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Eliminación").Value = True
                    dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Tomato
                End If
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles btOpcionGrupoQX.Click
        If SesionActual.tienePermiso(Pgrupoqx ) Then
            Dim grupo As New Form_GRUPOQX_SOAT
            grupo.ShowDialog()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btOpcionGrupo.Click
        If SesionActual.tienePermiso(Pgrupo ) Then
            Dim grupos As New Form_GRUPO_SOAT
            grupos.ShowDialog()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btOpcionCapitulo.Click
        If SesionActual.tienePermiso(Pcapitulo ) Then
            Dim capitulo As New Form_CAPITULO_SOAT
            capitulo.ShowDialog()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btOpcionSeccion.Click
        If SesionActual.tienePermiso(Pseccion ) Then
            Dim seccion As New Form_SECCION_SOAT
            seccion.ShowDialog()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btOpcionSala.Click
        If SesionActual.tienePermiso(Psala ) Then
            Dim sala As New Form_SALA_SOAT
            sala.ShowDialog()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btOpcionCapArticulo.Click
        If SesionActual.tienePermiso(PCarticulo ) Then
            Dim cArticulo As New Form_CARTICULO_SOAT
            cArticulo.ShowDialog()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub dgvprocedimiento_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvprocedimiento.EditingControlShowing
        If dgvprocedimiento.CurrentCell.ColumnIndex = 8 Or dgvprocedimiento.CurrentCell.ColumnIndex = 9 Then
            AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
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

    Private Sub btbuscarrepresentante_Click(sender As Object, e As EventArgs) Handles BUSCARMAN.Click

        General.buscarElemento(Consultas.MANUAL_BUSCAR,
                               Nothing,
                               AddressOf cargarManual,
                               TitulosForm.BUSQUEDA_MANUAL,
                               False, 0, True)


    End Sub
    Public Sub cargarManual(pCodigo As String)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)

        drFila = General.cargarItem(Consultas.MANUAL_CARGAR, params)

        txtCodigo.Text = pCodigo
        objManualSOAT.codigoManual = pCodigo
        DESCRIPCION.Text = drFila.Item(0).ToString

        ToolStrip1.Enabled = True
        TextBox1.Enabled = True
        btnuevo.Enabled = True
        bteditar.Enabled = True
        llenar_dgv()
        TextBox1.ReadOnly = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btOpcionArticulo.Click
        If SesionActual.tienePermiso(Particulo ) Then
            Dim articulo As New Form_ARTICULO_SOAT
            articulo.ShowDialog()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub dgvprocedimiento_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvprocedimiento.DataError
        MsgBox(Mensajes.CANTIDAD_VALIDA, MsgBoxStyle.Exclamation)
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        dgvprocedimiento.EndEdit()
        If cups.guardar(dgvprocedimiento, txtCodigo.Text) = True Then
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
        If dgvprocedimiento.CurrentCell.ColumnIndex = 4 Then
            If verificar_existencia() Then
                MsgBox(Mensajes.CODIGO_EXISTE, MsgBoxStyle.Critical)
                If dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Codigo_Oculto").Value.ToString.ToUpper <> "" Then
                    dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Código").Value = dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Codigo_Oculto").Value.ToString.ToUpper
                Else
                    dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Código").Value = ""
                End If
                Exit Sub
            End If
        End If
        If dgvprocedimiento.CurrentRow.Index = dgvprocedimiento.RowCount - 1 And dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Codigo_Oculto").Value.ToString = "" Then
            dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Inserción").Value = True
            dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192) 'Verde
            objManualSOAT.dtProcedimiento.Rows.Add()
        Else
            If dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Inserción").Value = False Then
                If dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Eliminación").Value = False Then
                    dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Edición").Value = True
                    dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192) 'Color.Yellow
                End If
            End If
        End If
    End Sub
    Private Function verificar_existencia() As Boolean
        Return objManualSOAT.dtProcedimiento.Select("Código='" & dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Código").Value.ToString & "'", "").Count > 0 And
                dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Codigo_Oculto").Value.ToString.ToUpper <> dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Código").Value.ToString.ToUpper
    End Function
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.Text = Funciones.validarComillaSimple(TextBox1.Text)
        objManualSOAT.enlceData.Filter = "[Código] LIKE '%" + TextBox1.Text.Trim() + "%' or [Descripción] LIKE '%" + TextBox1.Text.Trim() + "%' or [Grupo QX] LIKE '%" + TextBox1.Text.Trim() + "%' or [Descripción QX] LIKE '%" + TextBox1.Text.Trim() + "%'  or [Grupo] LIKE '%" + TextBox1.Text.Trim() + "%'  or [Descripción grupo] LIKE '%" + TextBox1.Text.Trim() + "%' or [Capitulo] LIKE '%" + TextBox1.Text.Trim() + "%' or [Descripción capitulo] LIKE '%" + TextBox1.Text.Trim() + "%' or [Articulo] LIKE '%" + TextBox1.Text.Trim() + "%' or [Descripción articulo] LIKE '%" + TextBox1.Text.Trim() + "%'"


    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                Editar()
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub



    Private Sub dgvprocedimiento_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvprocedimiento.CellDoubleClick
        If btguardar.Enabled = True Then
            If e.ColumnIndex = 6 Or e.ColumnIndex = 7 Or e.ColumnIndex = 10 Or e.ColumnIndex = 11 Or e.ColumnIndex = 12 Or e.ColumnIndex = 13 Or e.ColumnIndex = 14 Or e.ColumnIndex = 15 Then

                Dim consulta As String = String.Empty
                Dim titulo As String = String.Empty

                If dgvprocedimiento.CurrentCell.ColumnIndex = 6 Or dgvprocedimiento.CurrentCell.ColumnIndex = 7 Then
                    consulta = "EXEC [PROC_GRUPOQX_SOAT_BUSCAR] ''"
                    titulo = "Busqueda de GRUPOS QX"
                    colCodigo = 6
                    colDescripcion = 7
                ElseIf dgvprocedimiento.CurrentCell.ColumnIndex = 10 Or dgvprocedimiento.CurrentCell.ColumnIndex = 11 Then
                    consulta = "EXEC [PROC_GRUPO_SOAT_BUSCAR] ''"
                    titulo = "Busqueda de GRUPOS"
                    colCodigo = 10
                    colDescripcion = 11
                ElseIf dgvprocedimiento.CurrentCell.ColumnIndex = 12 Or dgvprocedimiento.CurrentCell.ColumnIndex = 13 Then
                    consulta = "EXEC [PROC_CAPITULO_SOAT_BUSCAR] ''"
                    titulo = "Busqueda de CAPITULOS"
                    colCodigo = 12
                    colDescripcion = 13
                ElseIf dgvprocedimiento.CurrentCell.ColumnIndex = 14 Or dgvprocedimiento.CurrentCell.ColumnIndex = 15 Then
                    consulta = "EXEC [PROC_ARTICULO_SOAT_BUSCAR] ''"
                    titulo = "Busqueda de ARTICULOS"
                    colCodigo = 14
                    colDescripcion = 15
                End If

                General.buscarItem(consulta,
                                    Nothing,
                                    AddressOf cargarQX,
                                    titulo,
                                    False)

                dgvprocedimiento_CellEndEdit(sender, e)
            End If
        End If
    End Sub

    Public Sub cargarQX(pFila As DataRow)
        dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells(colCodigo).Value = pFila.Item(0)
        dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells(colDescripcion).Value = pFila.Item(1)
    End Sub

    Private Sub Editar()
        dgvprocedimiento.MultiSelect = False : dgvprocedimiento.Rows(0).Cells("Código").Selected = True
        dgvprocedimiento.ReadOnly = False
        dgvprocedimiento.MultiSelect = False
        dgvprocedimiento.Columns(7).ReadOnly = True
        dgvprocedimiento.Columns(6).ReadOnly = True
        dgvprocedimiento.Columns(10).ReadOnly = True
        dgvprocedimiento.Columns(11).ReadOnly = True
        dgvprocedimiento.Columns(12).ReadOnly = True
        dgvprocedimiento.Columns(13).ReadOnly = True
        dgvprocedimiento.Columns(14).ReadOnly = True
        dgvprocedimiento.Columns(15).ReadOnly = True
        TextBox1.ReadOnly = False
        General.habilitarBotones(ToolStrip1)
        bteditar.Enabled = False
        btnuevo.Enabled = False
    End Sub

    Private Sub Form_SOAT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        Pgrupoqx = permiso_general & "pp" & "04"
        Pgrupo = permiso_general & "pp" & "05"
        Pcapitulo = permiso_general & "pp" & "06"
        Particulo = permiso_general & "pp" & "07"
        Pseccion = permiso_general & "pp" & "08"
        Psala = permiso_general & "pp" & "09"
        PCarticulo = permiso_general & "pp" & "10"
        ToolStrip1.Enabled = False
        TextBox1.Enabled = False

    End Sub

    Public Sub llenar_dgv()
        TextBox1.Clear()
        objManualSOAT.cargarDetalle()
        dgvprocedimiento.DataSource = objManualSOAT.enlceData.DataSource
        dgvprocedimiento.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvprocedimiento.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        dgvprocedimiento.ReadOnly = True
        If objManualSOAT.dtProcedimiento.Rows.Count > 0 Then
            For i = 0 To dgvprocedimiento.Columns.Count - 1
                dgvprocedimiento.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                dgvprocedimiento.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                dgvprocedimiento.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            dgvprocedimiento.Columns(dgvprocedimiento.Columns.Count - 11).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            dgvprocedimiento.Columns(dgvprocedimiento.Columns.Count - 5).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            dgvprocedimiento.Columns(dgvprocedimiento.Columns.Count - 7).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            dgvprocedimiento.Columns(dgvprocedimiento.Columns.Count - 8).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            dgvprocedimiento.Columns(dgvprocedimiento.Columns.Count - 9).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            dgvprocedimiento.Columns("Código").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvprocedimiento.Columns("Descripción").AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            dgvprocedimiento.Columns("Código").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvprocedimiento.Columns("Descripción").Width = "800"
            dgvprocedimiento.Columns(7).Width = "100"
            dgvprocedimiento.Columns(8).Width = "80"
            dgvprocedimiento.Columns(13).Width = "200"
            dgvprocedimiento.Columns(11).Width = "200"
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
        Funciones.validarCantidadCaracteresDGV(dgvprocedimiento, "Código", 9)
        Funciones.validarCantidadCaracteresDGV(dgvprocedimiento, "Descripción", 600)
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub

End Class