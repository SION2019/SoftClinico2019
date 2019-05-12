Imports System.Data.SqlClient
Public Class ViasAdministracion
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Private Sub ViasAdministracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objViaAdministracion_D As New ViaAdministracionBLL
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        objViaAdministracion_D.cargarComboTipoVia(ComboTipoVia)
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        General.deshabilitarControles(Me)
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If txtnombre.Text = "" Then
            MsgBox("¡ Por favor digite el nombre de Via admin !", MsgBoxStyle.Exclamation)
            txtnombre.Focus()
        ElseIf ComboTipoVia.SelectedIndex = Constantes.VALOR_PREDETERMINADO Then
            MsgBox("¡ Por seleccionar el tipo de via !", MsgBoxStyle.Exclamation)
            ComboTipoVia.Focus()
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Dim objViaAdministracion_D As New ViaAdministracionBLL
                Dim objViaAdministracion As New ViaAdministracion
                Try
                    objViaAdministracion_D.guardarViaAdministracion(crearViaAdministracion())

                    General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub
    Public Function crearViaAdministracion() As ViaAdministracion
        Dim objViaAdministracion As New ViaAdministracion
        objViaAdministracion.codigo = txtcodigo.Text
        objViaAdministracion.nombre = txtnombre.Text
        objViaAdministracion.codigoTipo = ComboTipoVia.SelectedValue.ToString
        objViaAdministracion.usuario = SesionActual.idUsuario
        Return objViaAdministracion
    End Function
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click

        Try
            If SesionActual.tienePermiso(Panular) Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    Dim params As New List(Of String)
                    params.Add(txtcodigo.Text)
                    params.Add(SesionActual.idUsuario)
                    General.ejecutarSQL(Consultas.VIAS_ADMINISTRACION_ANULAR, params)


                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    General.limpiarControles(Me)
                    btanular.Enabled = False
                    bteditar.Enabled = False
                    btcancelar.Enabled = False
                End If
            End If

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            txtnombre.Focus()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub
    Private Sub cargarDatos(pCodigo As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        txtcodigo.Text = pCodigo
        General.llenarTabla(Consultas.VIAS_ADMINISTRACION_CARGAR, params, dt)
        txtnombre.Text = dt.Rows(0).Item("Nombre").ToString()
        ComboTipoVia.SelectedValue = dt.Rows(0).Item("tipo").ToString()
        General.habilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btguardar.Enabled = False
        btcancelar.Enabled = False
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            General.buscarElemento(Consultas.VIAS_ADMINISTRACION_BUSCAR,
                              Nothing,
                              AddressOf cargarDatos,
                              TitulosForm.BUSQUEDA_VIA,
                              False, 0, True)

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

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            General.deshabilitarBotones(ToolStrip1)
            General.habilitarControles(Me)
            btcancelar.Enabled = True
            btguardar.Enabled = True
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
End Class