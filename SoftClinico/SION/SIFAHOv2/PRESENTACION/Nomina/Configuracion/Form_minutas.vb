Public Class Form_minutas
    Dim tempfileurl As String
    Dim objminutas_D As New MinutaLaboralBLL
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form_minutas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        Dim dtTabla As New DataTable
        dtTabla.Columns.Add("Valor")
        dtTabla.Columns.Add("Descripcion")
        Dim drFila As DataRow = dtTabla.NewRow()

        drFila.Item(0) = "-1"
        drFila.Item(1) = " - - - Seleccione - - - "
        dtTabla.Rows.Add(drFila)

        drFila = dtTabla.NewRow()
        drFila.Item(0) = "L"
        drFila.Item(1) = "Laboral"
        dtTabla.Rows.Add(drFila)

        drFila = dtTabla.NewRow()
        drFila.Item(0) = "P"
        drFila.Item(1) = "Prestación de servicio"
        dtTabla.Rows.Add(drFila)

        drFila = dtTabla.NewRow()
        drFila.Item(0) = "A"
        drFila.Item(1) = "Aprendizaje"
        dtTabla.Rows.Add(drFila)

        drFila = dtTabla.NewRow()
        drFila.Item(0) = "V"
        drFila.Item(1) = "Voluntario"
        dtTabla.Rows.Add(drFila)

        combotipo.DataSource = dtTabla
        combotipo.DisplayMember = "Descripcion"
        combotipo.ValueMember = "Valor"
        combotipo.SelectedIndex = 0
        General.deshabilitarControles(Me)
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.limpiarControles(Me)
            General.habilitarControles(Me)
            General.deshabilitarBotones(ToolStrip1)
            btguardar.Enabled = True
            btcancelar.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                General.deshabilitarBotones(ToolStrip1)
                General.habilitarControles(Me)
                btguardar.Enabled = True
                btcancelar.Enabled = True
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                'metodo de anular
                Try
                    objminutas_D.anular_minuta(Txtcodigo)
                    General.deshabilitarBotones(ToolStrip1)
                    General.limpiarControles(Me)
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                Catch ex As Exception
                    general.manejoErrores(ex)
                End Try
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub Form_minutas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If combotipo.SelectedIndex < 1 Then
            MsgBox("Seleccione el tipo de contrato", MsgBoxStyle.Information)
            TextNombre.Focus()
            Return
        ElseIf TextNombre.Text.Trim = "" Then
            MsgBox("Digite el nombre de la Minuta", MsgBoxStyle.Information)
            TextNombre.Focus()
            Return
        ElseIf rbTextMinuta.Text Is Nothing Then
            MsgBox("La minuta que desea guardar esta vacia", MsgBoxStyle.Information)
            rbTextMinuta.Focus()
            Return
        ElseIf MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) <> MsgBoxResult.Yes Then
            Return
        End If
        Try
            objminutas_D.guardar_minuta(Me)
            General.habilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            btguardar.Enabled = False
            btcancelar.Enabled = False
            MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add(Nothing)
            General.buscarElemento(Consultas.BUSQUEDA_MINUTA,
                                             params,
                                             AddressOf cargar,
                                             TitulosForm.BUSQUEDA_MINUTA,
                                             True,
                                             0,
                                             True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub cargar(pcodigo As String)
        Cursor = Cursors.WaitCursor
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(pcodigo)
        Try
            dFila = General.cargarItem(ConsultasNom.MINUTA_CARGAR, params)
            Txtcodigo.Text = pcodigo
            TextNombre.Text = dFila.Item(1)
            combotipo.SelectedValue = dFila.Item(2)
            chActivo.Checked = dFila.Item(3)
            rbTextMinuta.Rtf = dFila.Item(4)
            General.habilitarBotones(ToolStrip1)
            btguardar.Enabled = False
            btcancelar.Enabled = False
        Catch ex As Exception
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End Try
        Cursor = Cursors.Default
    End Sub

End Class