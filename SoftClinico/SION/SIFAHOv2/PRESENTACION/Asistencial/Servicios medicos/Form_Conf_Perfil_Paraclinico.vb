Public Class Form_Conf_Perfil_Paraclinico
    Dim EnlceDta As BindingSource = New BindingSource
    Dim objConfPP As New ConfiguracionPerfilParaclinico
    Dim objConfPerfilPBLL As New PerfilParaclinicoBLL
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, PCrear As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If General.formCancelar(Me, ToolStrip1, bteditar, bteditar) = True Then
            objConfPP.dtProcedimiento.Clear()
            cmbGrupos.SelectedValue = -1
            cmbAreaServicio.SelectedValue = -1
            btbuscar.Enabled = True
            btnuevo.Enabled = True
            btguardar.Enabled = False
            bteditar.Enabled = False
            txtbusqueda.ReadOnly = True
        End If

    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            General.habilitarControles(Me)
            General.deshabilitarBotones(ToolStrip1)
            txtbusqueda.ReadOnly = False
            cmbAreaServicio.Enabled = False
            cmbGrupos.Enabled = False
            btcancelar.Enabled = True
            btguardar.Enabled = True
        End If
    End Sub
    Private Sub cargarProcedimiento()
        Cursor.Current = Cursors.WaitCursor
        objConfPP.CodigoTipo = cmbGrupos.SelectedValue
        objConfPP.codigoAreaServicio = cmbAreaServicio.SelectedValue
        objConfPP.llenarTabla()
        validarDgv()
        lbCantidad.Text = "Cantidad de items: " & objConfPP.dtProcedimiento.Rows.Count
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub validarDgv()
        EnlceDta.DataSource = objConfPP.dtProcedimiento
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
    Private Sub Form_Conf_Perfil_Paraclinico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        PCrear = permiso_general & "pp" & "05"
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        btnActualizar.Enabled = True
        General.cargarCombo(Consultas.PERFIL_PARACLINICO_AREA_SERVICIO_BUSCAR, "Descripcion", "Codigo", cmbAreaServicio)
        General.cargarCombo(Consultas.PERFIL_PARACLINICO_G_BUSCAR, "Descripcion", "Codigo", cmbGrupos)
        objConfPP.codigoPunto = SesionActual.codigoEP
        objConfPP.usuario = SesionActual.idUsuario
        If SesionActual.tienePermiso(PCrear) Then
            btOpcionConfiguracionHorario.Visible = True
        End If
    End Sub

    Private Sub txtbusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtbusqueda.TextChanged
        If String.IsNullOrEmpty(txtbusqueda.Text) Then
            txtbusqueda.Text = Funciones.validarComillaSimple(txtbusqueda.Text)
            EnlceDta.Filter = "[Descripcion] LIKE '%" + txtbusqueda.Text.Trim() + "%' OR [Codigo] LIKE '%" + txtbusqueda.Text.Trim() + "%'  "
        End If
    End Sub

    Private Sub txtbusqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbusqueda.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtbusqueda.Text = Funciones.validarComillaSimple(txtbusqueda.Text)
            EnlceDta.Filter = "[Descripcion] LIKE '%" + txtbusqueda.Text.Trim() + "%' OR [Codigo] LIKE '%" + txtbusqueda.Text.Trim() + "%'  "
        End If
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            cmbGrupos.SelectedValue = -1
            cmbAreaServicio.SelectedValue = -1
            objConfPP.dtProcedimiento.Clear()
            cmbGrupos.Enabled = True
            cmbAreaServicio.Enabled = False
            btguardar.Enabled = True
            btcancelar.Enabled = True
            btnuevo.Enabled = False
            btbuscar.Enabled = False
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Dim tbl As DataRow = Nothing
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        If SesionActual.tienePermiso(PBuscar) Then
            Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(objConfPP.sqlBuscarPerfilParaclinico, params, TitulosForm.BUSQUEDA_PERFIL_PARACLINICO, False)
            tbl = formBusqueda.rowResultados
            If tbl IsNot Nothing Then
                cargarPerfilParaclinico(tbl)
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub cmbGrupos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGrupos.SelectedIndexChanged
        If cmbGrupos.ValueMember <> Nothing Then
            If cmbGrupos.SelectedValue <> "-1" Then
                cmbAreaServicio.Enabled = True
                If cmbAreaServicio.SelectedValue <> "-1" Then
                    cargarProcedimiento()
                    txtbusqueda.ReadOnly = False
                End If
            End If
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        General.cargarCombo(Consultas.PERFIL_PARACLINICO_G_BUSCAR, "Descripcion", "Codigo", cmbGrupos)
    End Sub

    Private Sub Form_Conf_Perfil_Paraclinico_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Try
                    objConfPP.AnularPerfilParaclinico()
                    General.deshabilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    General.limpiarControles(Me)
                    btbuscar.Enabled = True
                    btnuevo.Enabled = True
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                Catch ex As Exception

                End Try
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgvprocedimientos.EndEdit()
        dgvprocedimientos.CommitEdit(DataGridViewDataErrorContexts.Commit)

        If cmbGrupos.SelectedIndex = 0 Then
            Exec.SavingMsg("¡ Favor seleccionar un grupo !", cmbGrupos)
        ElseIf cmbAreaServicio.SelectedIndex = 0 Then
            Exec.SavingMsg("¡ Favor seleccionar un Area de Servicio !", cmbAreaServicio)
        ElseIf objConfPP.dtProcedimiento.Select("[Seleccionar] = True").Count = 0 Then
            Exec.SavingMsg("¡ Favor seleccionar algún item !", dgvprocedimientos)
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Try
                    Cursor.Current = Cursors.WaitCursor
                    objConfPerfilPBLL.guardarConfPerfilParaclinicoBLL(objConfPP)
                    General.deshabilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    General.limpiarControles(Me)
                    objConfPP.dtProcedimiento.Clear()
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    Cursor.Current = Cursors.Default
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub

    Private Sub cmbAreaServicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAreaServicio.SelectedIndexChanged
        If cmbAreaServicio.ValueMember <> Nothing Then
            If cmbGrupos.ValueMember <> Nothing Then
                cargarProcedimiento()
                txtbusqueda.ReadOnly = False
                dgvprocedimientos.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub btOpcionConfiguracionHorario_Click(sender As Object, e As EventArgs) Handles btOpcionConfiguracionHorario.Click
        Dim ConfPP As New Form_Perfil_Paraclinico
        ConfPP.ShowDialog()
    End Sub
    Private Sub cargarPerfilParaclinico(tb As DataRow)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(tb.Item(1))
        params.Add(tb.Item(0))
        Try
            dFila = General.cargarItem(objConfPP.sqlCargarPerfilParaclinico, params)
            'objPerfilP.codigo = pCodigo
            cmbGrupos.SelectedValue = tb.Item(1)
            cmbAreaServicio.SelectedValue = tb.Item(0)
            'txtDescripcion.Text = dFila.Item(1)
            General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
End Class