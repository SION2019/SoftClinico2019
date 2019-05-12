
Public Class Area_Servicio
    Dim aservicio As New AreaServicioDAL
    Dim perG As New Buscar_Permisos_generales
    Public permiso_general, Pnuevo, Peditar, Panular, PBuscar, PAsignar, PProductoyServicio As String
    Private Sub Area_Servicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        PAsignar = permiso_general & "pp" & "05"
        PProductoyServicio = permiso_general & "pp" & "06"
        General.cargarCombo(Consultas.MENU_BUSCAR, "Nombre", "Código", cbMenues)
        General.deshabilitarControles(Me)
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            btcolor.Enabled = True
            panelColor.BackColor = Color.PowderBlue
            txtnombre.Focus()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
            btcolor.Enabled = True
            txtnombre.Focus()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
        btcolor.Enabled = False
    End Sub


    Private Sub Area_Servicio_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

    Private Sub btcolor_Click(sender As Object, e As EventArgs) Handles btcolor.Click
        If ColorDialog1.ShowDialog() Then
            panelColor.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub btOpcionModulos_Click(sender As Object, e As EventArgs) Handles btOpcionModulos.Click
        If SesionActual.tienePermiso(PProductoyServicio ) Then
            If txtcodigo.Text <> "" Then
                FormAreaServicioConfig.txtcodigo.Text = txtcodigo.Text
                FormAreaServicioConfig.txtnombre.Text = txtnombre.Text
                General.cargarForm(FormAreaServicioConfig)
            Else
                MsgBox(Mensajes.SELECCIONE_PUNTO_ASIGNADO, MsgBoxStyle.Exclamation)
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            If (txtnombre.Text = "") Then
                MsgBox("¡ Por favor digite el nombre del area de servicio!", MsgBoxStyle.Exclamation)
                txtnombre.Focus()
            Else
                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

                    aservicio.guardar(txtcodigo, txtnombre.Text, observaciones.Text, cbMenues.SelectedValue, cbneonatal.Checked, panelColor.BackColor.ToArgb)
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    General.deshabilitarControles(Me)
                    General.habilitarBotones(Me.ToolStrip1)
                    btguardar.Enabled = False
                    btcancelar.Enabled = False
                    btcolor.Enabled = False
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Try
            If SesionActual.tienePermiso(Panular) Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    aservicio.anular(txtcodigo)
                    If txtcodigo.Text = Nothing Then
                        MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                        General.limpiarControles(Me)
                        General.deshabilitarControles(Me)
                        General.deshabilitarBotones(ToolStrip1)
                        btnuevo.Enabled = True
                        btcolor.Enabled = False
                        btbuscar.Enabled = True
                    End If
                End If
            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try


    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Try
                Dim params As New List(Of String)
                params.Add(SesionActual.codigoEP)
                General.buscarElemento(Consultas.BUSQUEDA_AREA_SERVICIO, params, AddressOf cargarArea,
                                                         TitulosForm.BUSQUEDA_AREA_SERVICIO, True, 0, True)
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargarArea(codigo As Integer)
        Dim dtCarga As New DataTable
        Dim params As New List(Of String)
        params.Add(codigo)
        params.Add(SesionActual.codigoEP)
        General.llenarTabla(Consultas.CARGA_AREA_SERVICIO, params, dtCarga)

        txtcodigo.Text = dtCarga.Rows(0).Item(0)
        txtnombre.Text = dtCarga.Rows(0).Item(1)
        observaciones.Text = dtCarga.Rows(0).Item(2)
        cbMenues.SelectedValue = dtCarga.Rows(0).Item(3)
        cbneonatal.Checked = dtCarga.Rows(0).Item(4)
        panelColor.BackColor = Color.FromArgb(dtCarga.Rows(0).Item(5))
        bteditar.Enabled = True
        btanular.Enabled = True

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub
End Class