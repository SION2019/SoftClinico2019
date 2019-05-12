Public Class Form_paciente
    Dim objPaciente As New Paciente
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Public Property formAdmisiones As FormAdmision
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Try
                    If General.anularConValidacion(Consultas.PACIENTES_ANULAR & txtCodigo.Text &
                                               ConstantesHC.NOMBRE_PDF_SEPARADOR3 &
                                               objPaciente.usuario) = True Then
                        General.deshabilitarBotones(ToolStrip1)
                        General.deshabilitarControles(Me)
                        General.limpiarControles(Me)
                        objPaciente.documentoPaciente = String.Empty
                        btnuevo.Enabled = True
                        btbuscar.Enabled = True
                        MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    Else
                        MsgBox(Mensajes.NO_ANULAR_PACIENTE, MsgBoxStyle.Information)
                    End If
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                General.deshabilitarBotones(ToolStrip1)
                General.habilitarControles(Me)
                textedad.ReadOnly = True
                btguardar.Enabled = True
                btcancelar.Enabled = True
                TextnombreEPS.ReadOnly = True
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            objPaciente.documentoPaciente = String.Empty
            textidentificacion.Focus()
            textedad.ReadOnly = True
            TextnombreEPS.ReadOnly = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar) = True Then
            objPaciente.documentoPaciente = String.Empty
            PictImagVer.Visible = False

        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        'poseidon
        '09-08-2017---modificación
        'Guardar pacientes 
        If validarCampos() Then
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Try
                    cargarObjeto()
                    PacienteBLL.guardarPaciente(objPaciente)
                    txtCodigo.Text = objPaciente.codigo
                    General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                    If Not IsNothing(formAdmisiones) Then
                        formAdmisiones.cargarDatosPaciente()
                        Dispose()
                    End If
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub
    Private Function validarCampos() As Boolean
        Dim validacion As Boolean
        Dim fechaActual As Date = Funciones.Fecha(23)

        If textidentificacion.Text = "" Then
            Exec.SavingMsg("Favor digitar el Nº de identificación", textidentificacion)
        ElseIf combotipoident.SelectedIndex < 1 Then
            Exec.SavingMsg("Seleccionar el tipo de identificación", combotipoident)
        ElseIf textpapellido.Text = "" Then
            Exec.SavingMsg("Favor digitar el primer apellido", textpapellido)
        ElseIf textsapellido.Text = "" Then
            Exec.SavingMsg("Favor digitar el segundo apellido", textsapellido)
        ElseIf textpnombre.Text = "" Then
            Exec.SavingMsg("Favor digitar el primer nombre", textpnombre)
        ElseIf Not IsDate(dtfecha.Text) Then
            Exec.SavingMsg("Favor digitar correctamente la fecha de nacimiento", dtfecha)
        ElseIf combosexo.SelectedIndex < 1 Then
            Exec.SavingMsg("Seleccionar el sexo del paciente", combosexo)
        ElseIf String.IsNullOrEmpty(TextnombreEPS.text) Then
            Exec.SavingMsg("Seleccionar la administradora", TextnombreEPS)
        ElseIf Combopais_nac.SelectedIndex < 1 Then
            Exec.SavingMsg("Seleccionar el pais de nacimiento", Combopais_nac)
        ElseIf combodepnac.SelectedIndex < 1 Then
            Exec.SavingMsg("Seleccionar el departamento de nacimiento", combodepnac)
        ElseIf combomunac.SelectedIndex < 1 Then
            Exec.SavingMsg("Seleccionar el municipio de nacimiento", combomunac)
        ElseIf comboregimen.SelectedIndex < 1 Then
            Exec.SavingMsg("Seleccionar tipo de regimen", comboregimen)
        ElseIf comboafiliacion.SelectedIndex < 1 Then
            Exec.SavingMsg("Seleccionar la afiliacion", comboafiliacion)
        ElseIf comboestrato.SelectedIndex < 1 Then
            Exec.SavingMsg("Seleccionar el estrato", comboestrato)
        ElseIf Combopais_resid.SelectedIndex < 1 Then
            Exec.SavingMsg("Seleccionar el pais de residencia", Combopais_resid)
        ElseIf Combodepartamento.SelectedIndex < 1 Then
            Exec.SavingMsg("Seleccionar el departamento de residencia", Combodepartamento)
        ElseIf combociudad.SelectedIndex < 1 Then
            Exec.SavingMsg("Seleccionar el municipio de residencia", combociudad)
        ElseIf textdireccion.Text = "" Then
            Exec.SavingMsg("Favor digitar la dirección", textdireccion)
        ElseIf textcelular.Text = "" Then
            Exec.SavingMsg("Favor digitar un numero celular", textcelular)
        ElseIf dtfecha.Value > DateTime.Now Then
            Exec.SavingMsg("Favor digitar una fecha de nacimiento valida", dtfecha)
        ElseIf CDate(dtfecha.Value).Date > fechaActual.Date Then
            Exec.SavingMsg(" la fecha no puede ser mayor a la fecha actual ", dtfecha)
        ElseIf objPaciente.documentoPaciente <> textidentificacion.Text And
                   PacienteBLL.verificarDocumentoExistencia(textidentificacion.Text) Then
            Exec.SavingMsg(Mensajes.VERIFICACION_DOCUMENTO & textidentificacion.Text, textidentificacion)
        ElseIf Not String.IsNullOrEmpty(txtEmail.Text) Then
            If General.validarCorreo(txtEmail.Text) = False Then
                Exec.SavingMsg("¡ Favor, colocar un correo valido !", txtEmail)
                Return False
            Else
                validacion = True
            End If
        Else
                validacion = True
        End If

        Return validacion
    End Function

    Private Sub Form_paciente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objPaciente.usuario = SesionActual.idUsuario
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btnuevo.Enabled = True
        btbuscar.Enabled = True

        General.cargarCombo(Consultas.BUSQUEDA_TIPO_DOCUMENTO, "Descripción", "Código", combotipoident)
        General.cargarCombo(Consultas.SEXO_LISTAR, "Descripción genero", "Código", combosexo)
        General.cargarCombo(Consultas.PAIS_LISTAR, "Nombre", "Código", Combopais_nac)
        General.cargarCombo(Consultas.PAIS_LISTAR, "Nombre", "Código", Combopais_exp)
        General.cargarCombo(Consultas.ZONA_LISTAR, "Descripcion_Zona", "Codigo_Zona", combozona)
        General.cargarCombo(Consultas.PAIS_LISTAR, "Nombre", "Código", Combopais_resid)
        General.cargarCombo(Consultas.ESTADO_LISTAR, "Estado Civil", "Codigo", comboestado)
        General.cargarCombo(Consultas.TIPO_REGIMEN_BUSCAR, "Descripcion_Regimen", "Codigo_Regimen", comboregimen)
        General.cargarCombo(Consultas.OCUPACION_LISTAR, "Ocupaciones", "Codigo", comboocupacion)
        General.cargarCombo(Consultas.ESTRATO_LISTAR, "Clase Social", "Codigo", comboestrato)
        '-------
        General.cargarCombo(Consultas.DPTO_LISTAR & "'" & Combopais_exp.SelectedValue.ToString & "'", "Nombre", "Codigo_Departamento", combodepexp)
        General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & combodepexp.SelectedValue.ToString & "'", "Nombre", "Codigo_Municipio", combomunexp)
        General.cargarCombo(Consultas.DPTO_LISTAR & "'" & Combopais_nac.SelectedValue.ToString & "'", "Nombre", "Codigo_Departamento", combodepnac)
        General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & combodepnac.SelectedValue.ToString & "'", "Nombre", "Codigo_Municipio", combomunac)
        General.cargarCombo(Consultas.DPTO_LISTAR & "'" & Combopais_resid.SelectedValue.ToString & "'", "Nombre", "Codigo_Departamento", Combodepartamento)
        General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & Combodepartamento.SelectedValue.ToString & "'", "Nombre", "Codigo_Municipio", combociudad)
        General.cargarCombo(Consultas.AFILIACION_LISTAR & "'" & comboregimen.SelectedValue.ToString & "'", "Descripcion_Afiliacion", "Codigo_Afiliacion", comboafiliacion)
    End Sub

    Private Sub combodepexp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combodepexp.SelectedIndexChanged
        If combodepexp.ValueMember <> "" Then
            General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & combodepexp.SelectedValue & "'", "Nombre", "Codigo_Municipio", combomunexp)
        End If
    End Sub

    Private Sub Combopais_exp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combopais_exp.SelectedIndexChanged
        If Combopais_exp.ValueMember <> "" Then
            General.cargarCombo(Consultas.DPTO_LISTAR & "'" & Combopais_exp.SelectedValue & "'", "Nombre", "Codigo_Departamento", combodepexp)
        End If
    End Sub

    Private Sub combodepnac_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combodepnac.SelectedIndexChanged
        If combodepnac.ValueMember <> "" Then
            General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & combodepnac.SelectedValue & "'", "Nombre", "Codigo_Municipio", combomunac)
        End If
    End Sub

    Private Sub Combopais_nac_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combopais_nac.SelectedIndexChanged
        If Combopais_nac.ValueMember <> "" Then
            General.cargarCombo(Consultas.DPTO_LISTAR & "'" & Combopais_nac.SelectedValue & "'", "Nombre", "Codigo_Departamento", combodepnac)
        End If
    End Sub

    Private Sub Combopais_resid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combopais_resid.SelectedIndexChanged
        If Combopais_resid.ValueMember <> "" Then
            General.cargarCombo(Consultas.DPTO_LISTAR & "'" & Combopais_resid.SelectedValue & "'", "Nombre", "Codigo_Departamento", Combodepartamento)
        End If
    End Sub

    Private Sub Combodepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combodepartamento.SelectedIndexChanged
        If Combodepartamento.ValueMember <> "" Then
            General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & Combodepartamento.SelectedValue & "'", "Nombre", "Codigo_Municipio", combociudad)
        End If
    End Sub

    Private Sub comboregimen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboregimen.SelectedIndexChanged
        If comboregimen.ValueMember <> "" Then
            General.cargarCombo(Consultas.AFILIACION_LISTAR & "'" & comboregimen.SelectedValue & "'", "Descripcion_Afiliacion", "Codigo_Afiliacion", comboafiliacion)
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        General.buscarElemento(Consultas.PACIENTE_BUSQUEDA,
                               Nothing,
                               AddressOf cargarPaciente,
                               TitulosForm.BUSQUEDA_PACIENTE,
                               True, 0, True)
    End Sub

    Public Sub cargarPaciente(pCodigo As String)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        txtCodigo.Text = pCodigo
        Try
            drFila = General.cargarItem(Consultas.PACIENTE_CARGAR, params)
            textidentificacion.Text = drFila.Item("Documento_paciente")
            combotipoident.SelectedValue = drFila.Item("Codigo_Identificacion")
            Combopais_exp.SelectedValue = drFila.Item("Codigo_Pais_Exp")
            combodepexp.SelectedValue = drFila.Item("Codigo_Departamento_Exp")
            combomunexp.SelectedValue = drFila.Item("Codigo_Municipio_Exp")
            dtfecha.Text = drFila.Item("Fecha_Nacimiento")
            textedad.Text = drFila.Item("Edad")
            textpapellido.Text = drFila.Item("Primer_Apellido")
            textsapellido.Text = drFila.Item("Segundo_Apellido")
            textsnombre.Text = If(IsDBNull(drFila.Item("Segundo_Nombre")), "", drFila.Item("Segundo_Nombre"))
            textpnombre.Text = drFila.Item("Primer_Nombre")
            Combopais_nac.SelectedValue = drFila.Item("Codigo_Pais_Nac")
            combodepnac.SelectedValue = drFila.Item("Codigo_Departamento_Nac")
            combomunac.SelectedValue = drFila.Item("Codigo_Municipio_Nac")
            comboregimen.SelectedValue = drFila.Item("Codigo_Regimen")
            comboafiliacion.SelectedValue = drFila.Item("Codigo_Tipo_Afiliacion")
            comboestado.SelectedValue = If(IsDBNull(drFila.Item("Codigo_Estado_Civil")), Constantes.VALOR_PREDETERMINADO, drFila.Item("Codigo_Estado_Civil"))
            combosexo.SelectedValue = drFila.Item("Codigo_Genero")
            cargarEPS(drFila.Item("ID_EPS"))
            comboocupacion.SelectedValue = If(IsDBNull(drFila.Item("Codigo_Ocupacion")), Constantes.VALOR_PREDETERMINADO, drFila.Item("Codigo_Ocupacion"))
            comboestrato.SelectedValue = drFila.Item("Codigo_Clase_Social")
            combozona.SelectedValue = If(IsDBNull(drFila.Item("Codigo_Zona")), Constantes.VALOR_PREDETERMINADO, drFila.Item("Codigo_Zona"))
            textdireccion.Text = drFila.Item("Direccion")
            Combopais_resid.SelectedValue = drFila.Item("Codigo_Pais_Res")
            Combodepartamento.SelectedValue = drFila.Item("Codigo_Departamento_Res")
            combociudad.SelectedValue = drFila.Item("Codigo_Municipio_Res")
            texttelefono.Text = If(IsDBNull(drFila.Item("Telefono")), "", drFila.Item("Telefono"))
            textcelular.Text = drFila.Item("Celular")
            txtEmail.Text = If(IsDBNull(drFila.Item("correo")), String.Empty, drFila.Item("correo"))
            objPaciente.documentoPaciente = textidentificacion.Text
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
    End Sub

    Private Sub bttipoafiliacion_Click(sender As Object, e As EventArgs) Handles bttipoafiliacion.Click
        Dim afiliacion As New Form_afiliados
        afiliacion.formPaciente = Me
        afiliacion.ShowDialog()
    End Sub

    Private Sub Btocupacion_Click(sender As Object, e As EventArgs) Handles Btocupacion.Click
        Dim ocupaciones As New Form_ocupaciones
        ocupaciones.formPaciente = Me
        ocupaciones.ShowDialog()
    End Sub

    Private Sub Btestadocivil_Click(sender As Object, e As EventArgs) Handles Btestadocivil.Click
        Dim estadoCivil As New Form_estado_civil
        estadoCivil.formPaciente = Me
        estadoCivil.ShowDialog()
    End Sub

    Private Sub bteps_Click(sender As Object, e As EventArgs) Handles bteps.Click
        Dim eps As New form_eps
        eps.ShowDialog()
    End Sub

    Private Sub Bttipoidentificacion_Click(sender As Object, e As EventArgs) Handles Bttipoidentificacion.Click
        Dim identificacion As New Form_Tiposidentificacion
        identificacion.formPaciente = Me
        identificacion.ShowDialog()
    End Sub

    Private Sub textnombrepunto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles _
            textpnombre.KeyPress, textsnombre.KeyPress, textpapellido.KeyPress
        ValidacionDigitacion.validarAlfabetico(e)
    End Sub

    Private Sub texttelefono_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles texttelefono.KeyPress
        ValidacionDigitacion.validarNumerosTelefono(e)
    End Sub
    Private Sub dtfecha_ValueChanged(sender As Object, e As EventArgs) Handles dtfecha.ValueChanged
        textedad.Text = PacienteBLL.calcularEdadPaciente(dtfecha.Value)
    End Sub
    Private Sub textidentificacion_TextChanged(sender As Object, e As EventArgs) Handles textidentificacion.TextChanged
        Try
            If objPaciente.documentoPaciente <> textidentificacion.Text Then
                If btguardar.Enabled = False Then Return
                PictImagVer.Visible = True
                If PacienteBLL.verificarDocumentoExistencia(textidentificacion.Text) Then
                    PictImagVer.Image = My.Resources.TimeBad.ToBitmap
                    objPaciente.msj.Show("¡ Este paciente se encuentra en uso !", PictImagVer)
                Else
                    PictImagVer.Image = My.Resources.TimeGood2.ToBitmap
                    objPaciente.msj.Hide(PictImagVer)
                End If
            Else
                PictImagVer.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub textcelular_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles textcelular.KeyPress
        ValidacionDigitacion.validarNumerosTelefono(e)
    End Sub

    Private Sub btbuscarEPS_Click(sender As Object, e As EventArgs) Handles btbuscarEPS.Click
        Dim params As New List(Of String)
        params.Add(Nothing)
        General.buscarElemento(Consultas.EPS_LISTAR,
                             params,
                             AddressOf cargarEPS,
                             TitulosForm.BUSQUEDA_CONTRATO,
                             False, 0, True)
    End Sub
    Private Sub cargarEPS(pCodigo As Integer)
        Dim dtEps As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.EPS_CARGAR, params, dtEps)
        TextnombreEPS.Text = dtEps.Rows(0).Item("Nombre_EPS").ToString()
        objPaciente.codEPS = pCodigo
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
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
    Private Sub cargarObjeto()
        objPaciente.codigo = txtCodigo.Text
        objPaciente.documentoPaciente = textidentificacion.Text
        objPaciente.codIdentificacion = combotipoident.SelectedValue
        objPaciente.codPaisExp = Combopais_exp.SelectedValue
        objPaciente.codDepartamentoExp = combodepexp.SelectedValue
        objPaciente.codMunicipioExp = combomunexp.SelectedValue
        objPaciente.fechaNacimiento = dtfecha.Value
        objPaciente.codPaisNac = Combopais_nac.SelectedValue
        objPaciente.codDepartamentoNac = combodepnac.SelectedValue
        objPaciente.codMunicipioNac = combomunac.SelectedValue
        objPaciente.edadPaciente = textedad.Text
        objPaciente.primerApellido = textpapellido.Text
        objPaciente.segundoApellido = textsapellido.Text
        objPaciente.primerNombre = textpnombre.Text
        objPaciente.segundoNombre = textsnombre.Text
        objPaciente.codEstadoCivil = comboestado.SelectedValue
        objPaciente.codGenero = combosexo.SelectedValue

        objPaciente.codTipoAfiliacion = comboafiliacion.SelectedValue
        objPaciente.codOcupacion = comboocupacion.SelectedValue
        objPaciente.codClaseSocial = comboestrato.SelectedValue
        objPaciente.codZona = combozona.SelectedValue
        objPaciente.direccionPaciente = textdireccion.Text
        objPaciente.codPaisRes = Combopais_resid.SelectedValue
        objPaciente.codDepartamentoRes = Combodepartamento.SelectedValue
        objPaciente.codMunicipioRes = combociudad.SelectedValue
        objPaciente.telefonoPaciente = texttelefono.Text
        objPaciente.celularPaciente = textcelular.Text
        objPaciente.correo = If(String.IsNullOrEmpty(txtEmail.Text), Nothing, txtEmail.Text)
    End Sub
    Private Sub textidentificacion_LostFocus(sender As Object, e As EventArgs) Handles textidentificacion.LostFocus
        If objPaciente.documentoPaciente <> textidentificacion.Text Then
            If btguardar.Enabled = False Then Return
            If PacienteBLL.verificarDocumentoExistencia(textidentificacion.Text) Then
                textidentificacion.Focus()
                textidentificacion.SelectionStart = Focus()
            Else
                PictImagVer.Visible = False
                objPaciente.msj.Hide(PictImagVer)
            End If
        End If
    End Sub
End Class