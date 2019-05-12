
Public Class Form_Tipo_Documentos
    Dim fprincipal As New PrincipalDAL
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, tipoDocumento As String

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
    Private Sub Form_Form_Documento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
    End Sub
    Public Sub cargarDatos()
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarControles(Me)
        If Comboservicio.Visible = True Then
            General.cargarCombo(Consultas.AREA_SERVICIO_LISTAR_CONTRATO & "" & SesionActual.codigoEP & ",'','-1',''", "Descripción", "Código", Comboservicio)
        End If
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        'If Sesion.idTercero = -1 OrElse SesionActual.tienePermiso(Pnuevo ) Then
        General.deshabilitarBotones(ToolStrip1)
        General.limpiarControles(Me)
        textdescripcion.ReadOnly = False
            Comboservicio.Enabled = True
            btguardar.Enabled = True
            btcancelar.Enabled = True
            textdescripcion.Focus()
        'Else
        '   MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        'End If
    End Sub
    Private Sub asignarTipoDocumento()
        Select Case True
            Case rbempresa.Checked
                tipoDocumento = Constantes.DOCUMENTO_EMPRESA
            Case rbempledo.Checked
                tipoDocumento = Constantes.DOCUMENTO_EMPLEADO
            Case rbpaciente.Checked
                tipoDocumento = Constantes.DOCUMENTO_PACIENTE
        End Select
    End Sub
    Private Function validarInformacion()
        If textdescripcion.Text = "" Then
            MsgBox("Por favor digite la descripción del documento", MsgBoxStyle.Information)
            textdescripcion.Focus()
            Return False
        ElseIf Comboservicio.SelectedIndex = 0 And rbpaciente.Checked = True Then
            MsgBox("Favor seleccionar el área de servicio", 48, "Atencion")
            Comboservicio.Focus()
            Return False
        ElseIf rbempledo.Visible = True Then
            rbempledo.Checked = True
        ElseIf rbempresa.Visible = True Then
            rbempresa.Checked = True
        ElseIf rbpaciente.Visible = True Then
            rbpaciente.Checked = True
        End If
        Return True
    End Function
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarInformacion() Then
            guardarTipoDocumentos()
        End If

    End Sub
    Public Function crearTipoDocumentos() As TipoDocumentos
        Dim servicioSeleccionado As Integer
        asignarTipoDocumento()
        servicioSeleccionado = IIf(Comboservicio.SelectedValue = Constantes.COMBO_VALOR_PREDETERMINADO, 0, Comboservicio.SelectedValue)
        Dim objTipoDocumentos As New TipoDocumentos
        objTipoDocumentos.codigo = Txtcodigo.Text
        objTipoDocumentos.descripcion = textdescripcion.Text
        objTipoDocumentos.tipoDocumento = tipoDocumento
        objTipoDocumentos.areaServicio = servicioSeleccionado
        objTipoDocumentos.usuario = SesionActual.idUsuario
        Return objTipoDocumentos
    End Function
    Private Sub guardarTipoDocumentos()


        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

            Dim objTipoDocumentoBLL As New AdmisionTipoDocumentoBLL
            Try
                Txtcodigo.Text = objTipoDocumentoBLL.guardarDocumento(crearTipoDocumentos())
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

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        'If Sesion.idTercero = -1 OrElse SesionActual.tienePermiso(Peditar ) Then
        General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
        'Else
        '   MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        'End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        'If Sesion.idTercero = -1 OrElse SesionActual.tienePermiso(PBuscar ) Then

        Dim params As New List(Of String)
            params.Add(Constantes.COMBO_VALOR_PREDETERMINADO)
        General.buscarElemento(Consultas.BUSQUEDA_DOCUMENTOS,
                                   params,
                                   AddressOf cargarDocumento,
                                   TitulosForm.BUSQUEDA_DOCUMENTOS,
                                   False, 0, True)

        'Else
        '   MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        'End If
    End Sub
    Public Sub cargarDocumento(pCodigo As String)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)

        Txtcodigo.Text = pCodigo
        drFila = General.cargarItem(Consultas.BUSQUEDA_DOCUMENTOS_CARGAR, params)

        textdescripcion.Text = drFila.Item("Descripcion")
        Comboservicio.SelectedValue = drFila.Item("Codigo_Area_Servicio")

        Dim tipo As String = drFila.Item("Tipo")
        Select Case tipo
            Case "I"
                rbempresa.Checked = True
            Case "E"
                rbempledo.Checked = True
            Case "P"
                rbpaciente.Checked = True
        End Select

        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)

    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Dim respuesta As Boolean
        'If Sesion.idTercero = -1 OrElse SesionActual.tienePermiso(Panular ) Then
        If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                respuesta = General.anularRegistro(Consultas.ANULAR_DOCUMENTO & "'" & CInt(Txtcodigo.Text) & "'," & SesionActual.idUsuario)
                If respuesta = True Then
                General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
            End If
            End If
        'End If
    End Sub
End Class