Public Class Form_CUPS
    Dim objManualCUPS As New ManualCUPS
    Dim cups As New CUPS_D
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, Pcategoria, Psubgrupo, Pgrupo, Pcapitulo, Pseccion As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            llenardgv()
            Editar()
            objManualCUPS.dtProcedimiento.Rows.Add()
            objManualCUPS.dtProcedimiento.AcceptChanges()
            dgvprocedimiento.DataSource = objManualCUPS.enlceData
            dgvprocedimiento.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvprocedimiento.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            objManualCUPS.enlceData.Filter = ""
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

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        dgvprocedimiento.EndEdit()
        Try
            If cups.guardar(dgvprocedimiento, txtCodigo.Text) = True Then
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information,)
                btguardar.Enabled = False
                btanular.Enabled = False
                bteditar.Enabled = True
                btcancelar.Enabled = False
                btnuevo.Enabled = True
                txtBusqueda.Clear()
                llenardgv()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
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
            objManualCUPS.dtProcedimiento.Rows.Add()
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
        Return objManualCUPS.dtProcedimiento.Select("Código='" & dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Código").Value.ToString & "'", "").Count > 0 And
                dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Codigo_Oculto").Value.ToString.ToUpper <> dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Código").Value.ToString.ToUpper
    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtBusqueda.TextChanged
        txtBusqueda.Text = Funciones.validarComillaSimple(txtBusqueda.Text)
        objManualCUPS.enlceData.Filter = "[Código] LIKE '%" + txtBusqueda.Text.Trim() + "%' or [Descripción] LIKE '%" + txtBusqueda.Text.Trim() + "%' or [Categoria] LIKE '%" + txtBusqueda.Text.Trim() + "%' or [Descripción Categoria] LIKE '%" + txtBusqueda.Text.Trim() + "%'"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btOpcionSubGrupo.Click
        If SesionActual.tienePermiso(Psubgrupo ) Then
            Dim subgrupo As New Form_SUBGRUPO_CUPS
            subgrupo.ShowDialog()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btOpcionGrupo.Click
        If SesionActual.tienePermiso(Pgrupo ) Then
            Dim grupo As New Form_GRUPO_CUPS
            grupo.ShowDialog()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btOpcionCapitulo.Click
        If SesionActual.tienePermiso(Pcapitulo ) Then
            Dim capitulo As New Form_CAPITULO_CUPS
            capitulo.ShowDialog()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub BUSCARMAN_Click(sender As Object, e As EventArgs) Handles BUSCARMAN.Click
        buscarManualSoat()
    End Sub
    Sub buscarManualSoat()

        General.buscarElemento(Consultas.MANUAL_BUSCAR,
                         Nothing,
                         AddressOf cargarManual,
                         TitulosForm.BUSQUEDA_MANUAL,
                         False, 0, True)
    End Sub
    Sub cargarManual(ByVal pCodigo As String)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)

        drFila = General.cargarItem(Consultas.MANUAL_CARGAR, params)

        txtCodigo.Text = pCodigo
        objManualCUPS.codigoManual = pCodigo
        DESCRIPCION.Text = drFila.Item(0).ToString

        ToolStrip1.Enabled = True
        txtBusqueda.Enabled = True
        btnuevo.Enabled = True
        bteditar.Enabled = True
        llenardgv()
        txtBusqueda.ReadOnly = False
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btOpcionSeccion.Click
        If SesionActual.tienePermiso(Pseccion ) Then
            Dim seccion As New Form_SECCION_CUPS
            seccion.ShowDialog()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub dgvprocedimiento_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvprocedimiento.DataError
        MsgBox(Mensajes.CANTIDAD_VALIDA, MsgBoxStyle.Exclamation)
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                Editar()
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub dgvprocedimiento_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvprocedimiento.CellDoubleClick
        If btguardar.Enabled = True Then
            If e.ColumnIndex = 6 Or e.ColumnIndex = 7 Then
                General.buscarElemento(Consultas.CATEGORIA_CUPS_BUSCAR,
                             Nothing,
                             AddressOf cargar,
                             TitulosForm.BUSQUEDA_CATEGORIAS_CUPS,
                             True)
            End If
        End If
    End Sub
    Sub cargar(ByVal pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        Dim fila As DataRow = General.cargarItem(Consultas.CATEGORIA_CUPS_CARGAR, params)
        dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells(6).Value = fila(0)
        dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells(7).Value = fila(1)
    End Sub
    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles btOpcionCategoria.Click
        If SesionActual.tienePermiso(Pcategoria ) Then
            Dim categoria As New Form_CATEGORIA_CUPS
            categoria.ShowDialog()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
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
        BUSCARMAN.Enabled = False
    End Sub

    Private Sub Form_CUPS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        Pcategoria = permiso_general & "pp" & "04"
        Psubgrupo = permiso_general & "pp" & "05"
        Pgrupo = permiso_general & "pp" & "06"
        Pcapitulo = permiso_general & "pp" & "07"
        Pseccion = permiso_general & "pp" & "08"
        ToolStrip1.Enabled = False
        txtBusqueda.Enabled = False

    End Sub

    Public Sub llenardgv()
        txtBusqueda.Clear()
        objManualCUPS.cargarDetalle()
        dgvprocedimiento.DataSource = objManualCUPS.enlceData.DataSource
        dgvprocedimiento.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvprocedimiento.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        dgvprocedimiento.ReadOnly = True
        If objManualCUPS.dtProcedimiento.Rows.Count > 0 Then
            For i As Integer = 0 To dgvprocedimiento.Columns.Count - 1
                dgvprocedimiento.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                dgvprocedimiento.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                dgvprocedimiento.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            dgvprocedimiento.Columns(dgvprocedimiento.Columns.Count - 5).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
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
        Funciones.validarCantidadCaracteresDGV(dgvprocedimiento, "Código", 9)
        Funciones.validarCantidadCaracteresDGV(dgvprocedimiento, "Descripción", 500)
        BUSCARMAN.Enabled = True
        btanular.Enabled = False
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub


End Class