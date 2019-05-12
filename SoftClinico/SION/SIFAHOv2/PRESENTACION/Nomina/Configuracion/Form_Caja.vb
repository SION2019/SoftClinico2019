Public Class Form_Caja
    Dim buscarCaja As Boolean
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim comboCaja As ComboBox
    Private Sub Form_Caja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        txtnombre.ReadOnly = True

    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            txtnombre.Focus()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Dim respuesta As Boolean
        Try
            If SesionActual.tienePermiso(Panular ) Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    respuesta = General.anularRegistro(Consultas.ANULAR_CAJA_COMPENSACION & CInt(txtcodigo.Text) & "," & SesionActual.idUsuario & "")
                    If respuesta = True Then
                        General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                    End If
                End If
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub
    Public Function crearCajaCompensacion() As CajaCompensacion
        Dim objCajaCompensacion As New CajaCompensacion
        objCajaCompensacion.codigo = txtcodigo.Text
        objCajaCompensacion.descripcion = txtnombre.Text
        objCajaCompensacion.usuario = SesionActual.idUsuario
        Return objCajaCompensacion
    End Function
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If txtnombre.Text.Trim = "" Then
            MsgBox("Debe colocar el nombre de la caja de compensacion antes de guardar !!", MsgBoxStyle.Information And MsgBoxStyle.OkOnly)
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Dim objCajaBLL As New CajaCompensacionBLL
                txtcodigo.Text = objCajaBLL.guardarCajaCompensacion(crearCajaCompensacion())
                General.habilitarBotones(ToolStrip1)
                    btguardar.Enabled = False
                    btcancelar.Enabled = False
                    txtnombre.ReadOnly = True
                    If Not IsNothing(comboCaja) Then
                        General.cargarCombo(Consultas.CAJA_LISTAR, "Descripción caja", "Código", comboCaja)
                    End If
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)

            End If
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                General.deshabilitarBotones(ToolStrip1)
                btguardar.Enabled = True
                btcancelar.Enabled = True
                txtnombre.ReadOnly = False
                txtnombre.ReadOnly = False
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargarDatos(pCodigo As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        txtcodigo.Text = pCodigo
        General.llenarTabla(Consultas.CAJA_CARGAR, params, dt)
        txtnombre.Text = dt.Rows(0).Item("Descripcion_Caja").ToString()
        General.habilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btguardar.Enabled = False
        btcancelar.Enabled = False
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            General.buscarElemento(Consultas.CAJA_LISTAR,
                              Nothing,
                              AddressOf cargarDatos,
                              TitulosForm.BUSQUEDA_CAJA_COMPENSACION,
                              True, 0, True)

        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub form_Caja_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
End Class