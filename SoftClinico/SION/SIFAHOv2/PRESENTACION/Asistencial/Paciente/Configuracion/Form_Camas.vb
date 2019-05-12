Public Class Form_Camas
    Dim perG As New Buscar_Permisos_generales
    Dim objCama As New ConfiguracionCama
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Tiposidentificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objCama.usuario = SesionActual.idUsuario
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True '--Nuevo--
        btbuscar.Enabled = True '--Buscar--
        General.deshabilitarControles(Me)
        General.cargarCombo(Consultas.AREA_SERVICIO_LISTAR_CONTRATO & "" & SesionActual.codigoEP & ",'','-1',''", "Descripción", "Código", Comboarea)
    End Sub
    Private Function validarCampo() As Boolean
        Dim bdra As Boolean
        If String.IsNullOrWhiteSpace(txtnombre.Text) Then
            Exec.SavingMsg("Digite la cama", txtnombre)
        ElseIf Comboarea.SelectedIndex = 0 Then
            Exec.SavingMsg("Seleccione el area de servicio", Comboarea)
        ElseIf String.IsNullOrEmpty(textEspecialidad.Text) Then
            Exec.SavingMsg("Seleccione la especialidad", textEspecialidad)
        ElseIf String.IsNullOrWhiteSpace(Textpiso.Text) Then
            Exec.SavingMsg("Digite el piso", Textpiso)
        ElseIf String.IsNullOrWhiteSpace(Texthabitacion.Text) Then
            Exec.SavingMsg("Digite la habitación", Texthabitacion)
        Else
            bdra = True
        End If

        Return bdra
    End Function
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        'descripcion guarda los documentos y actualiza: 
        'Autor: poseidon
        'fecha_creacion: 11/11/2016

        If validarCampo() = True Then
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Try
                    cargarObjeto()
                    CamaBLL.guardarCama(objCama)
                    txtcodigo.Text = objCama.codigo
                    General.deshabilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    bteditar.Enabled = True
                    btanular.Enabled = True
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    If General.verificar_formulario(FormAdmision) = True Then
                        If FormAdmision.Comboservicio.SelectedIndex <> 0 Then
                            General.cargarCombo(Consultas.CAMAS_DISPONIBLES & "'" & FormAdmision.Comboservicio.SelectedValue & "','" & SesionActual.codigoEP & "','" & FormAdmision.Txtcodigo.Text & "'", "Cama", "Id", FormAdmision.Combocama)
                        End If
                    End If
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        'descripcion Anula un registro: 
        'Autor: poseidon
        'fecha_creacion: 11/11/2016

        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR & ":" & txtnombre.Text.ToString & "", MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Try
                    If General.anularConValidacion(Consultas.CAMA_ANULAR &
                                               txtcodigo.Text &
                                               ConstantesHC.NOMBRE_PDF_SEPARADOR3 &
                                               objCama.usuario) = True Then
                        General.deshabilitarBotones(ToolStrip1)
                        General.limpiarControles(Me)
                        General.deshabilitarControles(Me)
                        btnuevo.Enabled = True
                        btbuscar.Enabled = True
                        MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    Else
                        MsgBox(Mensajes.NO_ANULAR_CAMA, MsgBoxStyle.Information)
                    End If
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            textEspecialidad.ReadOnly = True
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                General.deshabilitarBotones(ToolStrip1)
                General.habilitarControles(Me)
                btcancelar.Enabled = True '--Cancelar--
                btguardar.Enabled = True '--Guardar--
                textEspecialidad.ReadOnly = True
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then

            Dim params As New List(Of String)
            params.Add(SesionActual.codigoEP)

            General.buscarElemento(Consultas.CAMA_BUSQUEDA,
                                   params,
                                   AddressOf cargarCama,
                                   TitulosForm.BUSQUEDA_CAMA,
                                   False, 0, True)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btBuscarEPROC_Click(sender As Object, e As EventArgs) Handles btBuscarEsp.Click
        Dim params As New List(Of String)
        General.buscarElemento(Consultas.ESPECIALIDAD_LISTAR,
                             Nothing,
                             AddressOf cargarEspecialidad,
                             TitulosForm.BUSQUEDA_CONTRATO,
                             False, 0, True)
    End Sub
    Private Sub cargarEspecialidad(pCodigo As Integer)
        Dim dtEspecialidad As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.BUSQUEDA_ESPECIALIDADES_CARGAR, params, dtEspecialidad)
        If dtEspecialidad.Rows.Count > 0 Then
            objCama.codigoEspecialidad = pCodigo
            textEspecialidad.Text = dtEspecialidad.Rows(0).Item("Descripción").ToString()
        End If
    End Sub

    Public Sub cargarCama(pCodigo As String)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        params.Add(CInt(pCodigo))

        drFila = General.cargarItem(Consultas.CAMA_CARGAR, params)
        txtcodigo.Text = pCodigo

        txtnombre.Text = drFila.Item("Descripcion_Cama")
        Comboarea.SelectedValue = drFila.Item("Codigo_Area_Servicio")
        cargarEspecialidad(drFila.Item("Codigo_Especialidad"))
        Textpiso.Text = drFila.Item("Piso")
        Texthabitacion.Text = drFila.Item("Habitacion")
        Textobservacion.Text = If(IsDBNull(drFila.Item("Observaciones")), "", drFila.Item("Observaciones"))

        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
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
    Private Sub cargarObjeto()
        objCama.codigo = txtcodigo.Text
        objCama.codigoArea = Comboarea.SelectedValue
        objCama.descripcion = txtnombre.Text
        objCama.piso = Textpiso.Text
        objCama.habitacion = Texthabitacion.Text
        objCama.observacion = Textobservacion.Text
    End Sub
End Class