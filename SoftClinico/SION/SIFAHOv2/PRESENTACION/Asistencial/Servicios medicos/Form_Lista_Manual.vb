Public Class Form_Lista_Manual
    Dim cmd As New Lista_Manual_D
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form_Lista_Manual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True '--Nuevo--
        btbuscar.Enabled = True '--Buscar--
        General.deshabilitarControles(Me)
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            txtnombre.Focus()
            GroupBox3.Enabled = True
            General.cargarCombo(ConsultasAsis.MANUAL_CUPS_LISTAR, Nothing, "Descripción", "Código", cbManual)
            cbManual.SelectedIndex = 0
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Try
            If SesionActual.tienePermiso(Panular ) Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    cmd.anular_MANUAL(txtcodigo.Text)
                    General.limpiarControles(Me)
                    General.deshabilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information,)

                End If
            Else
               MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            If txtnombre.Text = "" Then
                MsgBox("¡Por favor digite el nombre del manual!", MsgBoxStyle.OkOnly And MsgBoxStyle.Exclamation)
                txtnombre.Focus()
            ElseIf ValoresM.Checked = True AndAlso cbManual.SelectedIndex = 0 Then
                MsgBox("¡Por favor seleccione el manual a duplicar!", MsgBoxStyle.OkOnly And MsgBoxStyle.Exclamation)
                cbManual.Focus()
            Else
                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

                    cmd.guardar_MANUAL(txtcodigo, txtnombre.Text, ValoresM.Checked, cbManual.SelectedValue)
                    General.deshabilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    bteditar.Enabled = True
                    btanular.Enabled = True
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information,)

                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub ToolStripSeparator3_Click(sender As Object, e As EventArgs) Handles ToolStripSeparator3.Click

    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If txtcodigo.Text = 0 Then
            MsgBox("No se puede editar el Manual General", MsgBoxStyle.Information)
            Exit Sub
        End If
        If SesionActual.tienePermiso(Peditar) Then
            General.deshabilitarBotones(ToolStrip1)
            General.habilitarControles(Me)
            btcancelar.Enabled = True '--Cancelar--
            btguardar.Enabled = True '--Guardar--
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Valores0_CheckedChanged(sender As Object, e As EventArgs) Handles Valores0.CheckedChanged

        cbManual.Enabled = Not Valores0.Checked
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Try
            General.buscarElemento(Consultas.MANUAL_BUSCAR, Nothing, AddressOf cargarManual,
                                                         TitulosForm.BUSQUEDA_MANUAL, True, 0, True)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub cargarManual(codigo As Integer)
        Dim dtCarga As New DataTable
        Dim params As New List(Of String)
        params.Add(codigo)
        General.llenarTabla(Consultas.CARGA_LISTA_MANUAL, params, dtCarga)
        txtcodigo.Text = codigo
        txtnombre.Text = dtCarga.Rows(0).Item(0)
        General.habilitarBotones(ToolStrip1)
        btguardar.Enabled = False
        btcancelar.Enabled = False
        GroupBox3.Enabled = False
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