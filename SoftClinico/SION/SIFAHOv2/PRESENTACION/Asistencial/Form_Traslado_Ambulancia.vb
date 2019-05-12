Public Class Form_Traslado_Ambulancia
    Dim fprincipal As New PrincipalDAL
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Private respuesta As Boolean
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
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
    Private Sub Form_Traslado_Ambulancia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        Dim cadena As String = ""
        General.deshabilitarControles(Me)
        General.cargarCombo(Consultas.EPS_LISTAR & "'" & cadena & "'", "Nombre", "Código", Combocliente)
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            General.habilitarControles(Me)
            textdescripcion.ReadOnly = True
            Combocliente.Focus()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Function validarInformacion()
        If Textcodigocups.Text = "" Then
            MsgBox("Por favor cargue un procedimiento de traslado", MsgBoxStyle.Information)
            Return False
            textdescripcion.Focus()
        ElseIf Combocliente.SelectedIndex < 1 Then
            MsgBox("Favor seleccionar la eps", 48, "Atencion")
            Combocliente.Focus()
            Return False
        ElseIf Textvalor.Text = "" Then
            MsgBox("Por favor digite el valor del traslado", MsgBoxStyle.Information)
            Return False
            Textvalor.Focus()
        End If
        Return True

    End Function
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarInformacion() Then
            guardarTraslado()
        End If
    End Sub

    Private Sub Textvalor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Textvalor.KeyPress
        ValidacionDigitacion.validarValoresNumericos(e)
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
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            General.buscarElemento(Consultas.BUSQUEDA_CONSULTAR_PROCEDIMIENTO_TRASLADOS,
                                   Nothing,
                                   AddressOf cargarTraslado,
                                   TitulosForm.BUSQUEDA_TRASLADOS,
                                   True, Constantes.TAMANO_MEDIANO, True)

        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Public Sub cargarTraslado(pCodigo As String)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        Txtcodigo.Text = pCodigo
        drFila = General.cargarItem(Consultas.BUSQUEDA_TRASLADOS_CARGAR, params)
        textdescripcion.Text = drFila.Item("Descripcion")
        Combocliente.SelectedValue = drFila.Item("id_eps")
        Textvalor.Text = drFila.Item("Precio")
        Textcodigocups.Text = drFila.Item("Codigo_procedimiento")

        General.deshabilitarControles(Me)
        General.habilitarBotones(Me.ToolStrip1)
        btguardar.Enabled = False
        btcancelar.Enabled = False

    End Sub
    Private Sub btbuscartraslado_Click(sender As Object, e As EventArgs) Handles btbuscartraslado.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            General.buscarElemento(Consultas.BUSQUEDA_PROCEDIMIENTO_CUPS_TRASLADOS_BUSCAR,
                                   Nothing,
                                   AddressOf cargarProcedimientosCUPS,
                                   TitulosForm.BUSQUEDA_PROCEDIMIENTO_TRASLADOS,
                                   False)

        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub cargarProcedimientosCUPS(pCodigo As String)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(0)
        drFila = General.cargarItem(Consultas.PROCEDIMIENTOS_CUPS_CARGAR, params)

        Textcodigocups.Text = pCodigo
        textdescripcion.Text = drFila.Item(1)

    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
        btbuscartraslado.Focus()
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                respuesta = General.anularRegistro(Consultas.ANULAR_PROCEDIMIENTO_TRASLADO & "'" & CInt(Txtcodigo.Text) & "','" & SesionActual.idUsuario & "'")
                If respuesta = True Then
                    General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                End If
            End If
        End If
    End Sub
    Public Function crearTrasladoAmbulancia() As TrasladoAmbulancia
        Dim objTrasladoAmbulancia As New TrasladoAmbulancia
        objTrasladoAmbulancia.codigo = Txtcodigo.Text
        objTrasladoAmbulancia.codigocups = Textcodigocups.Text
        objTrasladoAmbulancia.idCliente = Combocliente.SelectedValue
        objTrasladoAmbulancia.valorTraslado = Textvalor.Text
        objTrasladoAmbulancia.usuario = SesionActual.idUsuario
        Return objTrasladoAmbulancia
    End Function
    Private Sub guardarTraslado()
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Dim objTrasladoAmbulancia As New Traslado_Ambulancia_D
            Try
                Txtcodigo.Text = objTrasladoAmbulancia.guardarTraslado(crearTrasladoAmbulancia())
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                General.deshabilitarControles(Me)
                General.habilitarBotones(Me.ToolStrip1)
                btguardar.Enabled = False
                btcancelar.Enabled = False
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
End Class