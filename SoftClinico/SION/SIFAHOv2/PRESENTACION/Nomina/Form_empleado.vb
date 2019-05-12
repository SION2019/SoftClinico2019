Public Class Form_empleado
    Private btnuevodocu1 As Boolean
    Private huella1 As DPFP.Template
    Private perG As New Buscar_Permisos_generales
    Private dtDocumentos As New DataTable
    Private frmGenerico As Windows.Forms.Form
    Private permiso_general, Pnuevo, Peditar, Panular, PBuscar, Pcargo, Pprofesion,
        Pespecialidad, Pbanco, Peps, Parp, PCaja, Ppension, PinfoProf, Pssybanco,
        Pusuario, Ppuntos, Pareas, Pcomites, Pdocumentos, PadminSalarios, PverSalarios, PadminPerfiles,
        PadminEstadoUsuario As String

    Dim adminEmpleado As AdminEmpleado
    Private idEmpleado As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub bttomar_Click(sender As Object, e As EventArgs) Handles bttomar.Click
        adminEmpleado.esOtraHuella = True
        btHuella_Click(sender, e)
        If Not huella1 Is Nothing AndAlso idEmpleado.Trim <> "" Then
            If EmpleadoBLL.tomarHuella(idEmpleado.Trim, huella1) = True Then
                tabcontrolidentificar.SelectedTab = tabhuella
                MessageBox.Show("Se insertado el documento correctamente", "El Sistema informa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Public Sub tomarImagen(vImagen As Image)
        pictureFirma.Image = vImagen
        adminEmpleado.esOtraFirma = True
    End Sub

    Private Sub btfirma_Click(sender As Object, e As EventArgs) Handles btfirma.Click

        'Dim objfirma As New Form_firmas
        'objfirma.iniciarForm(Me)
        'objfirma.crearImagen(Constantes.ID_EMPLEADOS, idEmpleado, pictureFirma)
        'objfirma.ShowDialog()
        'picturedocu.Image = pictureFirma.Image
        'redimencionarImagen(pictureFirma)
        llamarFormularioFirma(idEmpleado, Constantes.ID_EMPLEADOS)
    End Sub
    Private Sub llamarFormularioFirma(codigo As Integer, idTipo As String)
        Dim objfirma As Object
        Dim tableta As New Topaz.SigPlusNET
        Dim conectada As Boolean = tableta.TabletConnectQuery
        Try
            If conectada = True Then
                objfirma = New FormFirmaDigitalEmple
                objfirma.formEmpleado = Me
                objfirma.ShowDialog()
            Else
                objfirma = New Form_firmas
                objfirma.iniciarForm(Me)
                objfirma.crearImagen(idTipo, codigo, pictureFirma)
                objfirma.ShowDialog()
            End If
            picturedocu.Image = pictureFirma.Image
            adminEmpleado.esOtraFirma = True
            redimencionarImagen(pictureFirma)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Btfirma_sello_Click(sender As Object, e As EventArgs) Handles Btfirma_sello.Click
        With openimagen
            .InitialDirectory = ""
            .Filter = "Todos los archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif|JPEG|*.jpeg;*.jpg|BMP|*.bmp|GIF|*.gif|PNG|*.png"
            .Title = "Seleccionar imagen de Firma"
        End With
        If openimagen.ShowDialog() = Windows.Forms.DialogResult.OK Then
            With picturedocu
                .Image = Image.FromFile(openimagen.FileName)
                .SizeMode = PictureBoxSizeMode.Zoom ' .SizeMode = PictureBoxSizeMode.CenterImage
                .BorderStyle = BorderStyle.None ' .BorderStyle = BorderStyle.Fixed3D
            End With
            redimencionarImagen(pictureFirma)
            adminEmpleado.esOtraFirma = True
        Else
            adminEmpleado.esOtraFirma = False
        End If
    End Sub

    Private Sub btHuella_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btHuella.Click
        Try
            Dim form_tomar_huella As New Form_tomar_huella()
            form_tomar_huella.ShowDialog()
            huella1 = form_tomar_huella.huella
        Catch ex As Exception
            MessageBox.Show("No fue encontrado el dispositivo de captura de huella.", "Error con lector de huella!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        If Not huella1 Is Nothing Then
            picturedocu.Image = My.Resources.huella
            picturedocu.SizeMode = PictureBoxSizeMode.Zoom
            picturedocu.BorderStyle = BorderStyle.None
            picturehuella.Image = My.Resources.huella
            btHuella.Enabled = False
            btAgregarDocu.Enabled = True
        Else
            btHuella.Enabled = False
            btnuevodocu.Enabled = True
            btguardar.Enabled = True
            combodescripciondocu.SelectedIndex = 0
        End If
    End Sub

    Private Sub agregarPuntos()
        If chlPuntosDisponibles.CheckedItems.Count <> 0 Then
            For Each itemChecked In chlPuntosDisponibles.CheckedItems
                Me.chlPuntosAsignados.Items.Add(itemChecked)
            Next
        Else
            MsgBox("Seleccione un elemento de la lista!", MsgBoxStyle.Exclamation)
        End If
        If chlPuntosAsignados.Items.Count <> 0 Then
            For Each itemChecked1 In chlPuntosAsignados.Items
                Me.chlPuntosDisponibles.Items.Remove(itemChecked1)
            Next
        End If
    End Sub
    Private Sub agregarAreas()
        If chlAreasDisponibles.CheckedItems.Count <> 0 Then
            For Each itemChecked In chlAreasDisponibles.CheckedItems
                Me.chlAreasAsignadas.Items.Add(itemChecked)
            Next
        Else
            MsgBox("Seleccione un elemento de la lista!", MsgBoxStyle.Exclamation)
        End If
        If chlAreasAsignadas.Items.Count <> 0 Then
            For Each itemChecked1 In chlAreasAsignadas.Items
                Me.chlAreasDisponibles.Items.Remove(itemChecked1)
            Next
        End If
    End Sub

    Private Sub quitarAreas()
        If chlAreasAsignadas.CheckedItems.Count <> 0 Then
            For Each itemChecked In chlAreasAsignadas.CheckedItems
                Me.chlAreasDisponibles.Items.Add(itemChecked)
            Next
        Else
            MsgBox("Seleccione un elemento de la lista!", MsgBoxStyle.Exclamation)
        End If

        If chlAreasDisponibles.Items.Count <> 0 Then
            For Each itemChecked1 In chlAreasDisponibles.Items
                Me.chlAreasAsignadas.Items.Remove(itemChecked1)
            Next
        End If
    End Sub

    Private Sub bteditarusuario_Click(sender As Object, e As EventArgs) Handles btEditarUsuario.Click
        If (txtUsuario.ReadOnly OrElse Not txtClave.Enabled) Then
            txtUsuario.Enabled = True
            txtUsuario.ReadOnly = False
            txtClave.ReadOnly = False
            txtClave.Clear()
            txtClave.Enabled = True
        Else
            txtUsuario.Enabled = False
            txtUsuario.ReadOnly = True
            txtClave.ReadOnly = True
            txtClave.Text = "**********"
        End If
    End Sub

    Private Sub textusuario_ReadOnlyChanged(sender As Object, e As EventArgs) Handles txtUsuario.ReadOnlyChanged, txtClave.EnabledChanged
        btEditarUsuario.Text = If(txtUsuario.ReadOnly OrElse Not txtClave.Enabled, "Editar o cambiar", TitulosForm.CANCELAR)
    End Sub

    Private Sub Form_empleado_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

    Private Sub quitarPuntos()
        If chlPuntosAsignados.CheckedItems.Count <> 0 Then
            For Each itemChecked In chlPuntosAsignados.CheckedItems
                Me.chlPuntosDisponibles.Items.Add(itemChecked)
            Next
        Else
            MsgBox("Seleccione un elemento de la lista!", MsgBoxStyle.Exclamation)
        End If

        If chlPuntosDisponibles.Items.Count <> 0 Then
            For Each itemChecked1 In chlPuntosDisponibles.Items
                Me.chlPuntosAsignados.Items.Remove(itemChecked1)
            Next
        End If
    End Sub

    Private Sub btImagen_Click(sender As Object, e As EventArgs) Handles btImagen.Click
        If (idEmpleado = "") Then
            MsgBox("¡ Por favor seleccione un empleado!", MsgBoxStyle.Exclamation)
            tabcontrolpunto.SelectedTab = tabprofesion
            btbuscartercero.Focus()
        Else
            With openimagen
                .InitialDirectory = ""
                .Filter = "Todos los archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.pdf;*.doc;*.docx;*.xls;*.xlsx|JPEG|*.jpeg;*.jpg|BMP|*.bmp|GIF|*.gif|PNG|*.png"
                .Title = "Seleccionar imagen de " + combodescripciondocu.Text
            End With
            If openimagen.ShowDialog() = Windows.Forms.DialogResult.OK Then
                With picturedocu
                    Dim ext1 As String = Path.GetExtension(openimagen.FileName).ToLower
                    If ext1 = ConstantesHC.EXTENSION_ARCHIVO_PDF Then
                        .Image = My.Resources.picpdf
                    ElseIf ext1 = ".doc" Or ext1 = ".docx" Then
                        .Image = My.Resources.picdoc
                    ElseIf ext1 = ".xls" Or ext1 = ".xlsx" Then
                        .Image = My.Resources.picxls
                    Else
                        openimagen.FileName = Nothing
                        .Image = Image.FromFile(openimagen.FileName)
                    End If
                    .SizeMode = PictureBoxSizeMode.Zoom
                    .BorderStyle = BorderStyle.None
                    '.................................
                    btAgregarDocu.Enabled = True
                End With
            End If
        End If
    End Sub

    Private Sub btnuevodocu_Click(sender As Object, e As EventArgs) Handles btnuevodocu.Click
        If (idEmpleado <> "") Then
            btnuevodocu1 = True
            btguardar.Enabled = False
            btnuevodocu.Enabled = False
            dgvDocumentos.Enabled = False
            dgvDocumentos.ClearSelection()
            picturedocu.Image = My.Resources.color
            picturedocu.SizeMode = PictureBoxSizeMode.StretchImage
            picturedocu.BorderStyle = BorderStyle.None

            ocultarTabs()

            combodescripciondocu.Enabled = True
            combodescripciondocu.BackColor = Color.FromArgb(255, 254, 215)
            combodescripciondocu.Focus()
            btImagen.Enabled = True
        Else
            MsgBox("¡ Por favor seleccione un empleado!", MsgBoxStyle.Exclamation)
            tabcontrolpunto.SelectedTab = tabprofesion
            btbuscartercero.Focus()
        End If
    End Sub
    Sub cbcargos_SelectionChangeCommitted()
        frmGenerico.Close()
    End Sub

    Private Sub btnuevocomite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cbcargos As ComboBox

        Me.frmGenerico = New Windows.Forms.Form()
        Dim opcion As New Label
        cbcargos = New ComboBox()
        AddHandler cbcargos.SelectionChangeCommitted, AddressOf cbcargos_SelectionChangeCommitted

        With Me.frmGenerico
            With cbcargos
                .Items.AddRange(New Object() {" - - Seleccione - - ", "Gerente", "Presidente", "Secretario", "Invitado", "Médico", "Enfermera"})
                .Location = New Point(65, 45)
                .Size = New Size(120, 21)
                .SelectedIndex = 0
                .DropDownStyle = ComboBoxStyle.DropDownList
            End With
            With opcion
                .Text = "Por favor, seleccione el cargo del comité:"
                .Location = New Point(13, 20)
                .Size = New Size(210, 21)
            End With

            .ClientSize = New Size(250, 80)
            .FormBorderStyle = FormBorderStyle.FixedDialog
            .StartPosition = FormStartPosition.CenterScreen
            .BackColor = Color.SandyBrown
            .Controls.Add(cbcargos)
            .Controls.Add(opcion)
            .ShowDialog()
        End With
        If cbcargos.SelectedIndex = 0 Then Exit Sub
        Dim personal1 As String = InputBox("Digite la descripcion del Nuevo Comite ", "Crear comité para el cargo : " & cbcargos.SelectedItem, "Nuevo Comité").Trim
        If Not personal1 = "" Then
            Dim codigo As String = ""
        End If
    End Sub

    Sub normalizarTXTsMoney(ByVal editing As Boolean)
        Try
            RemoveHandler txtValorSalario.TextChanged, AddressOf textsalario_TextChanged
            RemoveHandler valorTurno.TextChanged, AddressOf textturno_TextChanged

            Dim numsalario As Decimal = If(IsNumeric(txtValorSalario.Text), txtValorSalario.Text, 0)
            Dim numturno As Decimal = If(IsNumeric(valorTurno.Text), valorTurno.Text, 0)
            Dim numauxtransporte As Decimal = If(IsNumeric(valorAuxTransporte.Text), valorAuxTransporte.Text, 0)
            Dim numviaticos As Decimal = If(IsNumeric(valorViatico.Text), valorViatico.Text, 0)
            If editing Then
                If numturno > numsalario Then
                    txtValorSalario.Enabled = False
                    txtValorSalario.Text = "(Por Turnos)"
                Else
                    txtValorSalario.Text = numsalario.ToString("N0").Replace(".", "")
                End If
                valorTurno.Text = numturno.ToString("N0").Replace(".", "")
                valorAuxTransporte.Text = numauxtransporte.ToString("N0").Replace(".", "")
                valorViatico.Text = numviaticos.ToString("N0").Replace(".", "")
            Else
                If numturno > numsalario Then
                    txtValorSalario.Text = "(Por Turnos)"
                Else
                    txtValorSalario.Text = numsalario.ToString("C0")
                End If
                valorTurno.Text = numturno.ToString("C0")
                valorAuxTransporte.Text = numauxtransporte.ToString("C0")
                valorViatico.Text = numviaticos.ToString("C0")
            End If

        Catch ex As Exception
            MsgBox(ex.Message + " -normalizar_txtsmoney")
        Finally
            RemoveHandler txtValorSalario.TextChanged, AddressOf textsalario_TextChanged
            RemoveHandler valorTurno.TextChanged, AddressOf textturno_TextChanged
            AddHandler txtValorSalario.TextChanged, AddressOf textsalario_TextChanged
            AddHandler valorTurno.TextChanged, AddressOf textturno_TextChanged
        End Try
    End Sub
    Private Sub Form_empleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim col1, col2, col3 As New DataColumn

        col1.ColumnName = "Doc"
        col1.DataType = Type.GetType("System.String")
        dtDocumentos.Columns.Add(col1)

        col2.ColumnName = "Descripcion"
        col2.DataType = Type.GetType("System.String")
        col2.DefaultValue = ""
        dtDocumentos.Columns.Add(col2)

        col3.ColumnName = "Imagen"
        col3.DataType = Type.GetType("System.Byte[]")
        dtDocumentos.Columns.Add(col3)

        With dgvDocumentos
            .Columns.Item(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(0).DataPropertyName = "Doc"

            .Columns.Item(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(1).DataPropertyName = "Descripcion"

            .Columns.Item(2).DataPropertyName = "Imagen"
        End With

        dgvDocumentos.AutoGenerateColumns = False
        dgvDocumentos.DataSource = dtDocumentos

        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        Pcargo = permiso_general & "pp" & "05"
        Pprofesion = permiso_general & "pp" & "06"
        Pespecialidad = permiso_general & "pp" & "07"
        Pbanco = permiso_general & "pp" & "08"
        Peps = permiso_general & "pp" & "09"
        Parp = permiso_general & "pp" & "10"
        PCaja = permiso_general & "pp" & "11"
        Ppension = permiso_general & "pp" & "12"
        PinfoProf = permiso_general & "pp" & "13"
        Pssybanco = permiso_general & "pp" & "14"
        Pusuario = permiso_general & "pp" & "15"
        Ppuntos = permiso_general & "pp" & "16"
        Pareas = permiso_general & "pp" & "17"
        Pcomites = permiso_general & "pp" & "18"
        Pdocumentos = permiso_general & "pp" & "19"
        PadminSalarios = permiso_general & "pp" & "20"
        PverSalarios = permiso_general & "pp" & "21"
        PadminPerfiles = permiso_general & "pp" & "22"
        PadminEstadoUsuario = permiso_general & "pp" & "23"
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True
        btbuscar.Enabled = True

        General.cargarCombo(Consultas.PAIS_LISTAR, "Nombre", "Código", cbPaisNac)
        cbPaisNac.SelectedIndex = 0
        General.cargarCombo(Consultas.PAIS_LISTAR, "Nombre", "Código", cbPaisExp)
        cbPaisExp.SelectedIndex = 0
        General.cargarCombo(Consultas.PAIS_LISTAR, "Nombre", "Código", cbPaisRes)
        cbPaisRes.SelectedIndex = 0
        General.cargarCombo(Consultas.SEXO_LISTAR, "Descripción genero", "Código", cbGenero)
        General.cargarCombo(Consultas.PROFESION_LISTAR, "Descripción profesión", "Código", cbProfesion)
        Dim params As New List(Of String)
        params.Add(Nothing)
        General.cargarCombo(Consultas.CARGO_LISTAR, params, "Descripción cargo", "Código", cbCargo)
        General.cargarCombo(Consultas.ESPECIALIDAD_LISTAR, "Descripción", "Código", cbEspecialidad)
        General.cargarCombo(Consultas.TCUENTA_LISTAR, "Descripción", "Código", cbTipoCuenta)

        Dim retefuenteParams As New List(Of String)
        Dim codigoPuc As String = FuncionesContables.obtenerPucActivo

        retefuenteParams.Add(codigoPuc)
        General.cargarCombo(Consultas.RETEFUENTE_LISTAR, retefuenteParams, "Nombre", "Código", Comboretefuente)

        General.cargarCombo(Consultas.BANCO_LISTAR, "Descripción", "Código", cbBanco)
        General.cargarCombo(Consultas.CAJA_LISTAR, "Descripción caja", "Código", cbCajaCompensacion)

        Dim paramsEps As New List(Of String)
        paramsEps.Add(Nothing)
        General.cargarCombo(Consultas.EPS_LISTAR, paramsEps, "Nombre", "Código", cbEps)
        General.cargarCombo(Consultas.PENSION_LISTAR, "Descripción pensión", "Código", cbPension)
        General.cargarCombo(Consultas.ARP_LISTAR, "Descripción ARP", "Código", cbArp)
        General.cargarCombo(Consultas.PEFIL_LISTAR & SesionActual.idEmpresa & "", "Nombre perfil", "Código", cbPerfil)
        General.cargarCombo(Consultas.TIPO_DOCUMENTO_EMPLEADO_LISTAR & "'" & Constantes.DOCUMENTO_EMPLEADO & "'" & Constantes.DOCUMENTO_SOLO_EMPLEADO_Y_EMPRESA, "Descripción", "Código", combodescripciondocu)
        'cbEstadoUsuario.SelectedValue = Constantes.COMBO_VALOR_PREDETERMINADO

        llenarComboestadoUsuario()

        cbRh.SelectedIndex = 0
        General.deshabilitarControles(Me)
        If Not SesionActual.tienePermiso(PinfoProf) Then
            tabprofesion.Enabled = False
        End If
        If Not SesionActual.tienePermiso(Pssybanco) Then
            tabssscuentabanco.Enabled = False
        End If
        If Not SesionActual.tienePermiso(Pusuario) Then
            tabusuariopuntoservicio.Enabled = False
        End If
        If Not SesionActual.tienePermiso(Ppuntos) Then
            tabpuntoservicio.Enabled = False
        End If
        If Not SesionActual.tienePermiso(Pareas) Then
            tabareservicio.Enabled = False
        End If
        If Not SesionActual.tienePermiso(Pdocumentos) Then
            tabdocumentos.Enabled = False
        End If
        If Not SesionActual.tienePermiso(PverSalarios) Then
            panelSalarios.Visible = False
        End If
        If Not SesionActual.tienePermiso(PadminSalarios) Then
            txtValorSalario.Enabled = False
            valorTurno.Enabled = False
            valorViatico.Enabled = False
        End If
        If Not SesionActual.tienePermiso(PadminEstadoUsuario) Then
            cbEstadoUsuario.Enabled = False
        End If
    End Sub

    Private Sub Combopais_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbPaisNac.SelectedValueChanged
        If cbPaisNac.ValueMember <> String.Empty Then
            General.cargarCombo(Consultas.DPTO_LISTAR & "'" & cbPaisNac.SelectedValue & "'", "Nombre", "Codigo_Departamento", cbDptoNac)
        End If
    End Sub
    Private Sub SelectedValueChanged(sender As Object, e As EventArgs) Handles cbDptoNac.SelectedValueChanged
        If cbDptoNac.ValueMember <> String.Empty Then
            General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & cbDptoNac.SelectedValue & "'", "Nombre", "Codigo_Municipio", cpMunicipioNac)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If tabcontrolpunto.TabPages.Count < 2 Then
            btnuevodocu1 = False
            btImagen.Enabled = False
            btHuella.Enabled = False
            btnuevodocu.Enabled = True
            btAgregarDocu.Enabled = False
            dgvDocumentos.Enabled = True
            dgvDocumentos.ClearSelection()
            combodescripciondocu.Enabled = False
            combodescripciondocu.SelectedIndex = 0
            huella1 = Nothing
            openimagen.FileName = Nothing
            openimagen.FileName = Nothing
            btguardar.Enabled = True
            mostrarTabs()
        Else
            General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
        End If

    End Sub

    Private Sub Combopaisexp_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbPaisExp.SelectedValueChanged
        If cbPaisExp.ValueMember <> String.Empty Then
            General.cargarCombo(Consultas.DPTO_LISTAR & "'" & cbPaisExp.SelectedValue & "'", "Nombre", "Codigo_Departamento", cbDptoExp)
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btOpcionProfesion.Click
        If SesionActual.tienePermiso(Pprofesion) Then
            Dim profesion As New Form_Profesion
            profesion.comboProfesion = cbProfesion
            profesion.ShowDialog()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles btOpcionEspecialidad.Click
        If SesionActual.tienePermiso(Pespecialidad) Then
            Dim especialidad As New Form_especialidades
            especialidad.comboEspecialidad = cbEspecialidad
            especialidad.ShowDialog()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles btOpcionBanco.Click
        If SesionActual.tienePermiso(Pbanco) Then
            Dim banco As New Form_Banco
            banco.ShowDialog()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles btOpcionEPS.Click
        If SesionActual.tienePermiso(Peps) Then
            Dim eps As New form_eps
            eps.comboeps = cbEps
            eps.ShowDialog()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles btOpcionARL.Click
        If SesionActual.tienePermiso(Parp) Then
            Dim arp As New Form_ARP

            arp.comboarp = cbArp
            arp.ShowDialog()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles btOpcionCaja.Click
        If SesionActual.tienePermiso(PCaja) Then
            Dim caja As New Form_Caja
            caja.ShowDialog()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles btOpcionPension.Click
        If SesionActual.tienePermiso(Ppension) Then
            Dim pension As New Form_Pension
            pension.comboPension = cbPension
            pension.ShowDialog()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btBuscarTercero_Click(sender As Object, e As EventArgs) Handles btbuscartercero.Click
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        params.Add(Nothing)

        General.buscarItem(Consultas.BUSQUEDA_EMPLEADO_TERCERO,
                               params,
                               AddressOf visualizarInformacionTercero,
                               TitulosForm.BUSQUEDA_TERCERO,
                               False)
    End Sub
    Private Sub visualizarInformacionTercero(pFila As DataRow)
        Dim tercero As New Tercero
        tercero.idTercero = pFila.Item(0)

        tercero = EmpleadoBLL.consultarDatosTercero(tercero)

        adminEmpleado.idEmpresa = SesionActual.idEmpresa
        adminEmpleado.tercero = tercero

        Dim nuevoEmpleado As New Empleado
        nuevoEmpleado.idEmpresa = SesionActual.idEmpresa
        nuevoEmpleado.idEmpleado = tercero.idTercero
        idEmpleado = nuevoEmpleado.idEmpleado
        listarPuntosDisponibles(AdminEmpleado.obtenerPuntosDisponbiles(nuevoEmpleado))
        listarAreasDisponibles(AdminEmpleado.obtenerAreasDisponibles(nuevoEmpleado))

        configurarListas()
        visualizarDatosTercero(adminEmpleado.tercero, adminEmpleado.terceroCuenta)
    End Sub
    Private Sub combodptoexp_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbDptoExp.SelectedValueChanged
        If cbDptoExp.ValueMember <> String.Empty Then
            General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & cbDptoExp.SelectedValue & "'", "Nombre", "Codigo_Municipio", cbMunicipioExp)
        End If
    End Sub

    Private Sub btfoto_Click(sender As Object, e As EventArgs) Handles btfoto.Click
        adminEmpleado.esOtraFoto = True
        With openimagen
            .InitialDirectory = ""
            .Filter = "Todos los archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif|JPEG|*.jpeg;*.jpg|BMP|*.bmp|GIF|*.gif|PNG|*.png"
            .Title = "Seleccionar imagen de Foto Fondo Azul"
        End With
        If openimagen.ShowDialog() = Windows.Forms.DialogResult.OK Then
            With picturedocu
                .Image = Image.FromFile(openimagen.FileName)
                .SizeMode = PictureBoxSizeMode.Zoom ' .SizeMode = PictureBoxSizeMode.CenterImage
                .BorderStyle = BorderStyle.None ' .BorderStyle = BorderStyle.Fixed3D
            End With
            redimencionarImagen(pictureFoto)

        End If
    End Sub

    Private Sub redimencionarImagen(pImagen As PictureBox)
        If IsNothing(picturedocu.Image) Then Exit Sub
        Dim filename As String = openimagen.FileName
        ' Cree un mapa de bits del contenido del control de fileUpload en la memoria
        Dim originalBMP As Bitmap = New Bitmap(picturedocu.Image)
        ' Calcule las nuevas dimensiones de imagen
        Dim origWidth As Integer = originalBMP.Width
        Dim origHeight As Integer = originalBMP.Height
        Dim sngRatio As Double
        Dim newHeight As Integer
        Dim newWidth As Integer
        If origHeight > origWidth AndAlso origHeight > Constantes.TAMANO_VERTICAL_IMAGEN_PIX Then
            sngRatio = origHeight / origWidth
            newHeight = Constantes.TAMANO_VERTICAL_IMAGEN_PIX
            newWidth = newHeight / sngRatio
        ElseIf origHeight < origWidth AndAlso origWidth > Constantes.TAMANO_HORIZONTAL_IMAGEN_PIX Then
            sngRatio = origWidth / origHeight
            newWidth = Constantes.TAMANO_HORIZONTAL_IMAGEN_PIX
            newHeight = newWidth / sngRatio
        Else
            pImagen.Image = picturedocu.Image
            Exit Sub
        End If
        ' Cree un nuevo mapa de bits que sostendrá el mapa de bits anterior redimensionado
        Dim newBMP As New Bitmap(originalBMP, newWidth, newHeight)
        ' Cree un gráfico basado en el nuevo mapa de bits
        Dim oGraphics As Graphics = Graphics.FromImage(newBMP)
        ' Ponga las propiedades para el nuevo archivo gráfico
        oGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        oGraphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        ' Dibuje el nuevo gráfico basado en el mapa de bits redimensionado
        oGraphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight)
        ' Guearde el nuevo archivo gráfico al servidor
        Dim direccion As String
        direccion = Path.GetTempPath & "imagen" & Format(Now, "HH'h'mm'm'ss's'") & ".png"
        Try
            newBMP.Save(direccion)
            pImagen.Image = Image.FromFile(direccion)
            'Una vez terminado con los objetos de mapa de bits, los desasignamos.

            originalBMP.Dispose()
            newBMP.Dispose()
            oGraphics.Dispose()
        Catch ex As Exception
            MsgBox("ha ocurrido un error, por favor vuelva a intentarlo.", MsgBoxStyle.Critical)
        End Try

    End Sub
    Private Sub btAgregarDocu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAgregarDocu.Click
        If (idEmpleado = "") Then
            MsgBox("¡ Por favor seleccione un empleado!", MsgBoxStyle.Exclamation)
            tabcontrolpunto.SelectedTab = tabprofesion
            btbuscartercero.Focus()

        ElseIf (combodescripciondocu.SelectedIndex = 0) Then
            MsgBox("¡ Por favor seleccione la descripcion del documento !", MsgBoxStyle.Exclamation)
            combodescripciondocu.Focus()

        Else
            If MsgBox("¿Desea agregar el documento?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

                Dim ms As New MemoryStream
                picturedocu.Image.Save(ms, picturedocu.Image.RawFormat)
                Dim arrFile() As Byte = ms.GetBuffer

                If EmpleadoBLL.guardarDocumento(idEmpleado.Trim, combodescripciondocu.SelectedValue, arrFile) = True Then
                    MessageBox.Show("Se insertado el documento correctamente", "El Sistema informa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dtDocumentos = llenarDgv()
                End If
            Else
                MessageBox.Show("No se inserto el documento", "El Sistema informa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            btnuevodocu1 = False
            btImagen.Enabled = False
            btHuella.Enabled = False
            btnuevodocu.Enabled = True
            btAgregarDocu.Enabled = False
            dgvDocumentos.Enabled = True
            dgvDocumentos.ClearSelection()
            combodescripciondocu.Enabled = False
            combodescripciondocu.SelectedIndex = 0
            huella1 = Nothing
            openimagen.FileName = Nothing
            btguardar.Enabled = True
            Call mostrarTabs()
        End If
    End Sub

    Function llenarDgv(Optional ByVal parcial As Boolean = False)
        Dim dtDocumentos As New DataTable

        Dim cadena = "SELECT a.codigo_doc Doc,b.Descripcion,a.Imagen FROM D_EMPLEADO_DOCUMENTO a join G_TIPO_DOCUMENTO b on a.codigo_doc=b.codigo_doc " +
                     "WHERE id_empleado='" & idEmpleado.Trim & "' Order By Descripcion"
        General.llenarTabla(cadena, Nothing, dtDocumentos)

        Return dtDocumentos
    End Function

    Sub ocultarTabs()
        tabcontrolpunto.Controls.Remove(tabprofesion)
        tabcontrolpunto.Controls.Remove(tabssscuentabanco)
        tabcontrolpunto.Controls.Remove(tabusuariopuntoservicio)
        tabcontrolpunto.Controls.Remove(tabpuntoservicio)
        tabcontrolpunto.Controls.Remove(tabareservicio)
    End Sub
    Sub mostrarTabs()
        If tabcontrolpunto.TabCount > 1 Then Return
        tabcontrolpunto.TabPages.Insert(0, tabareservicio)
        tabcontrolpunto.TabPages.Insert(0, tabpuntoservicio)
        tabcontrolpunto.TabPages.Insert(0, tabusuariopuntoservicio)
        tabcontrolpunto.TabPages.Insert(0, tabssscuentabanco)
        tabcontrolpunto.TabPages.Insert(0, tabprofesion)
    End Sub

    Private Sub CombopaisnRES_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbPaisRes.SelectedValueChanged
        General.cargarCombo(Consultas.DPTO_LISTAR & "'" & cbPaisRes.SelectedValue?.ToString & "'", "Nombre", "Codigo_Departamento", cbDptoRes)
    End Sub
    Private Sub combodptonRES_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbDptoRes.SelectedValueChanged
        General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & cbDptoRes.SelectedValue?.ToString & "'", "Nombre", "Codigo_Municipio", cbCiudadRes)
    End Sub
    Private Sub btpuntos_Click(sender As Object, e As EventArgs) Handles btOpcionCargo.Click
        If SesionActual.tienePermiso(Pcargo) Then
            Dim cargo As New Form_Cargos
            cargo.ShowDialog()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.limpiarControles(Me)
            General.habilitarControles(Me)
            General.deshabilitarBotones(ToolStrip1)
            btguardar.Enabled = True
            btcancelar.Enabled = True
            btbuscartercero.Enabled = True
            cbPaisNac.Focus()

            txtNumeroCuenta.ReadOnly = False
            txtCuentaCC.ReadOnly = False
            txtUsuario.Enabled = True
            txtClave.Enabled = True
            cbPerfil.Enabled = Not (SesionActual.tienePermiso(PadminEstadoUsuario))
            cbEstadoUsuario.Enabled = Not (SesionActual.tienePermiso(PadminEstadoUsuario))

            adminEmpleado = New AdminEmpleado()
            adminEmpleado.idEmpresa = SesionActual.idEmpresa

            deshabilitarControles()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btagregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btagregar.Click
        agregarPuntos()
    End Sub

    Public Sub deshabilitarControles()
        txtTipoId.ReadOnly = True
        txtIdentificacion.ReadOnly = True
        txtDv.ReadOnly = True
        txtNombre.ReadOnly = True
        txtSnombre.ReadOnly = True
        txtApellido.ReadOnly = True
        txtSapellido.ReadOnly = True
        txtTelefono1.ReadOnly = True
        txtTelefono2.ReadOnly = True
        txtWhatsapp.ReadOnly = True
        txtEmail.ReadOnly = True
        cbPaisRes.Enabled = False
        cbDptoRes.Enabled = False
        cbCiudadRes.Enabled = False
        txtDireccion.ReadOnly = True

        txtTipoId.Enabled = False
        txtIdentificacion.Enabled = False
        txtDv.Enabled = False
        txtNombre.Enabled = False
        txtSnombre.Enabled = False
        txtApellido.Enabled = False
        txtSapellido.Enabled = False
        txtTelefono1.Enabled = False
        txtTelefono2.Enabled = False
        txtWhatsapp.Enabled = False
        txtEmail.Enabled = False
        txtDireccion.Enabled = False


    End Sub

    Private Sub btquitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btquitar.Click
        quitarPuntos()
    End Sub

    Private Sub btagregararea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btagregararea.Click
        agregarAreas()
    End Sub

    Private Sub btquitararea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btquitararea.Click
        quitarAreas()
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarFormulario() = False Then
            Return
        End If

        If MsgBox(Mensajes.GUARDAR,
                  MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            guardarCambios()
            General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
        End If
    End Sub

    Public Sub guardarCambios()
        Dim textauxtransporte1 As String
        Dim textviaticos1 As String
        Dim retencion As String

        If IsNothing(pictureFoto.Image) Then pictureFoto.Image = My.Resources.blanco

        Dim foto() As Byte
        Using bmp As New Bitmap(pictureFoto.Image), ms As New MemoryStream()
            bmp.Save(ms, pictureFoto.Image.RawFormat)
            foto = ms.GetBuffer
        End Using

        If IsNothing(pictureFirma.Image) Then pictureFirma.Image = My.Resources.blanco

        Dim firma() As Byte
        Using bmp As New Bitmap(pictureFirma.Image), ms As New MemoryStream()
            bmp.Save(ms, Imaging.ImageFormat.Png)
            firma = ms.GetBuffer
        End Using

        textauxtransporte1 = Exec.ToDbl(valorAuxTransporte.Text.Trim).ToString.Replace(",", ".")
        textviaticos1 = Exec.ToDbl(valorViatico.Text.Trim).ToString.Replace(",", ".")
        retencion = If(cbretefuente.Checked, Comboretefuente.SelectedValue, "")

        'nuevo empleado
        If adminEmpleado.esNuevoEmpleado Then
            adminEmpleado.inicializarNuevoEmpleado()
        End If

        adminEmpleado = crearAdminEmpleado()
        EmpleadoBLL.guardarCambiosEmpleado(adminEmpleado)
        adminEmpleado.esOtraFirma = False
    End Sub


    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            General.buscarElemento(Consultas.BUSQUEDA_BUSCAR_EMPLEADO & SesionActual.idEmpresa,
                                   Nothing,
                                   AddressOf cargarEmpleado,
                                   TitulosForm.BUSQUEDA_EMPLEADO_HC,
                                   True,
                                   Constantes.TAMANO_MEDIANO, True)
            General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
        End If
    End Sub

    Private Sub cargarEmpleado(pCodigo)
        Dim drInfoEmpleado As DataRow
        Dim params As New List(Of String)

        params.Add(SesionActual.idEmpresa)
        params.Add(pCodigo)
        drInfoEmpleado = General.cargarItem(Consultas.CARGAR_EMPLEADO, params)

        adminEmpleado = New AdminEmpleado(drInfoEmpleado)
        visualizarDatosEmpleado(adminEmpleado)
        deshabilitarControles()

    End Sub


    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                editar()
                normalizarTXTsMoney(True)
                btnuevo.Enabled = False
                btguardar.Enabled = True
                btcancelar.Enabled = True
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub editar()
        General.deshabilitarBotones(ToolStrip1)
        General.habilitarControles(Me)
        txtCuentaPuc.ReadOnly = True
        txtCodigoCIIU.ReadOnly = True
        txtClave.Enabled = False
        txtUsuario.Enabled = False
        If txtValorSalario.Text = "(Por Turnos)" Then
            txtValorSalario.Enabled = False
            valorTurno.Enabled = True
        Else
            Dim salario As Integer = If(IsNumeric(txtValorSalario.Text), txtValorSalario.Text, 0)
            Dim turno As Integer = If(IsNumeric(valorTurno.Text), valorTurno.Text, 0)
            txtValorSalario.ReadOnly = Not (salario >= turno)
            valorTurno.ReadOnly = Not (salario <= turno)
        End If
        valorAuxTransporte.ReadOnly = False
        valorViatico.ReadOnly = False
        cbPerfil.Enabled = False
        cbEstadoUsuario.Enabled = False
        If idEmpleado <> "0" Then
            cbPerfil.Enabled = True
            cbEstadoUsuario.Enabled = True
        Else
            cbPerfil.SelectedIndex = 1
            cbEstadoUsuario.SelectedIndex = 1
        End If
        txtNumeroCuenta.ReadOnly = False
        txtCuentaCC.ReadOnly = False

        General.habilitarControles(Me)

    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR & ":" & txtNombre.Text.ToString & "", MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then

                Dim params As New List(Of String)
                params.Add(idEmpleado)
                params.Add(SesionActual.idEmpresa)
                params.Add(SesionActual.idUsuario)

                General.ejecutarSQL(Consultas.ANULAR_EMPLEADO, params)
                General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub textsalario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValorSalario.KeyPress, valorTurno.KeyPress, valorAuxTransporte.KeyPress, valorViatico.KeyPress
        'si el caracter es Letra
        If Char.IsDigit(e.KeyChar) Then
            'acepta el cracter
            e.Handled = False
            'si es un caracter de control como Enter
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
            'si es un espacio en blanco
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            If e.KeyChar = "." Then e.KeyChar = ","
            e.Handled = False
            'si es un espacio en blanco
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            ' de lo contario al poner e.handled en True
            'cancelamos la pulsación.
            e.Handled = True
        End If
    End Sub

    Private Sub textsalario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValorSalario.TextChanged
        Dim stt As String = New StackTrace().GetFrame(6).GetMethod().Name
        If stt <> "textturno_TextChanged" And stt <> "limpiar_controles" Then
            If txtValorSalario.Enabled = True And txtValorSalario.Text.Trim = "" Then
                valorTurno.Enabled = True
                valorTurno.Text = "0"
            ElseIf txtValorSalario.Enabled = True Then
                valorTurno.Enabled = False
                Try
                    valorTurno.Text = ((CDec(txtValorSalario.Text) / 30)).ToString("C2")
                Catch
                End Try
            End If
        End If
    End Sub

    Private Sub textturno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles valorTurno.TextChanged
        Dim stt As String = New StackTrace().GetFrame(6).GetMethod().Name
        If stt <> "textsalario_TextChanged" And stt <> "limpiar_controles" Then
            If valorTurno.Enabled = True And valorTurno.Text.Trim = "" Then
                txtValorSalario.Enabled = True
                txtValorSalario.Text = "0"
            ElseIf valorTurno.Enabled = True Then
                txtValorSalario.Enabled = False
                txtValorSalario.Text = "(Por Turnos)"
            End If
        End If
        txtValorSalario.Focus()
    End Sub
    Private Sub combocargo_EnabledChanged(sender As System.Object, e As System.EventArgs) Handles cbCargo.EnabledChanged
        btpuc.Enabled = cbCargo.Enabled
        btciiu.Enabled = cbCargo.Enabled
    End Sub

    Private Sub btpuc_Click(sender As System.Object, e As System.EventArgs) Handles btpuc.Click
        Dim codigoPuc As String = FuncionesContables.obtenerPucActivo

        Dim params As New List(Of String)
        params.Add(codigoPuc)
        params.Add(Nothing)

        General.buscarItem(Consultas.BUSQUEDA_CUENTAS_PUC,
                            params,
                            AddressOf cargarPuc,
                            TitulosForm.BUSQUEDA_PUC,
                            False)
    End Sub

    Private Sub btciiu_Click(sender As System.Object, e As System.EventArgs) Handles btciiu.Click
        Dim params = {String.Empty}.ToList
        General.buscarItem(Consultas.BUSQUEDA_CIIU,
                        params,
                        AddressOf cargarCiiu,
                        TitulosForm.BUSQUEDA_CIIU,
                        False)
    End Sub
    Private Sub cargarPuc(pFila As DataRow)
        txtCuentaPuc.Text = pFila.Item(0)
    End Sub
    Private Sub cargarCiiu(pFila As DataRow)
        txtCodigoCIIU.Text = pFila.Item(0)
    End Sub

    Private Sub textpuc_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCuentaPuc.KeyDown
        If btpuc.Enabled Then
            If e.KeyCode = Keys.F2 Then
                btpuc.PerformClick()
            ElseIf e.KeyCode = Keys.Delete Then
                txtCuentaPuc.Text = ""
            End If
        End If
    End Sub

    Private Sub textciiu_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoCIIU.KeyDown
        If btciiu.Enabled Then
            If e.KeyCode = Keys.F2 Then
                btciiu.PerformClick()
            ElseIf e.KeyCode = Keys.Delete Then
                txtCodigoCIIU.Text = ""
            End If
        End If
    End Sub

    Private Sub cbretefuente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbretefuente.CheckedChanged
        If cbretefuente.Checked = True Then
            Comboretefuente.Enabled = True
        Else
            Comboretefuente.SelectedIndex = 0
            Comboretefuente.Enabled = False
        End If
    End Sub

    Private Function validarEditable(control As Control) As Boolean
        Return (Not Exec.IsInaccesible(control))
    End Function

#Region "Construccion del objeto principal AdminEmpleado"
    Public Function crearEmpleado() As Empleado
        Dim empleado As Empleado = adminEmpleado.empleado

        empleado.iniciales = txtiniciales.Text
        empleado.registroMedico = TxtRegistro.Text

        chRefuerzo.Checked = IIf(empleado.tipoempleado = Constantes.EMPLEADO_TIPO_REFUERZO, True, False)
        empleado.fechaExpedicion = dtpFechaExp.Value.Date
        empleado.fechaIngreso = dtpFechaIngreso.Value.Date
        empleado.fechaRetiro = dtpFechaRetiro.Value.Date
        empleado.fechaNacimiento = dtpFechaNac.Value.Date
        empleado.codigoCargo = cbCargo.SelectedValue
        empleado.codigoGenero = cbGenero.SelectedValue
        empleado.codigoPaisExp = cbPaisExp.SelectedValue
        empleado.codigoDepartamentoExp = cbDptoExp.SelectedValue
        empleado.codigoMunicipioExp = cbMunicipioExp.SelectedValue
        empleado.codigoPaisNac = cbPaisNac.SelectedValue
        empleado.codigoDepartamentoNac = cbDptoNac.SelectedValue
        empleado.codigoMunicipioNac = cpMunicipioNac.SelectedValue
        empleado.codigoEspecialidad = cbEspecialidad.SelectedValue
        empleado.codigoProfesion = cbProfesion.SelectedValue
        empleado.idEps = cbEps.SelectedValue
        empleado.codigoArp = cbArp.SelectedValue
        empleado.codigoCaja = cbCajaCompensacion.SelectedValue
        empleado.codigoPension = cbPension.SelectedValue
        empleado.tipoRH = cbRh.SelectedItem

        Return empleado
    End Function

    Public Function crearCuentaBancaria() As EmpleadoCuentaBancaria
        Dim cuentaBancaria As EmpleadoCuentaBancaria = adminEmpleado.cuentaBancaria
        Dim nuevaCuentaBancaria As New EmpleadoCuentaBancaria

        nuevaCuentaBancaria.codigoTipoCuenta = cbTipoCuenta.SelectedValue
        nuevaCuentaBancaria.idEmpresa = SesionActual.idEmpresa
        nuevaCuentaBancaria.idEmpleado = idEmpleado
        nuevaCuentaBancaria.numerocuenta = txtNumeroCuenta.Text
        nuevaCuentaBancaria.ccCuenta = txtCuentaCC.Text
        nuevaCuentaBancaria.CodigoBanco = cbBanco.SelectedValue
        Return nuevaCuentaBancaria
    End Function

    Public Function crearTurno() As EmpleadoTurno
        Dim turno As EmpleadoTurno = adminEmpleado.turno

        If valorTurno.Text <> turno.valor Then
            adminEmpleado.esOtroTurno = True
            turno.valor = valorTurno.Text
        End If


        Return turno
    End Function

    Public Function crearSalario() As EmpleadoSalario
        Dim salario As EmpleadoSalario = adminEmpleado.salario

        Dim nuevoSalario As New EmpleadoSalario

        nuevoSalario.idEmpleado = salario.idEmpleado
        nuevoSalario.idEmpresa = salario.idEmpresa
        nuevoSalario.idSalario = salario.idSalario
        nuevoSalario.valor = IIf(txtValorSalario.Text = "(Por Turnos)", Nothing, txtValorSalario.Text)

        If nuevoSalario.valor <> salario.valor Then
            adminEmpleado.esOtroSalario = True
        End If

        Return nuevoSalario
    End Function

    Private Sub pictureFoto_DoubleClick(pImagen As PictureBox, e As EventArgs) Handles pictureFoto.DoubleClick, pictureFirma.DoubleClick
        If btguardar.Enabled AndAlso Not IsNothing(pImagen.Image) AndAlso
            MsgBox("¿Desea redimencionar esta imagen?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            picturedocu.Image = pImagen.Image
            redimencionarImagen(pImagen)
        End If
    End Sub

    Public Function crearFirma() As EmpleadoFirma
        Dim firma As New EmpleadoFirma

        If pictureFirma.Image IsNot Nothing Then
            firma.idEmpleado = adminEmpleado.empleado.idEmpleado
            firma.imagen = pictureFirma.Image

            adminEmpleado.firma = firma
        End If

        Return firma
    End Function

    Public Function crearFoto() As EmpleadoFoto
        Dim foto As EmpleadoFoto = adminEmpleado.foto

        foto.foto = pictureFoto.Image
        Return foto
    End Function

    Public Function crearViatico() As EmpleadoViatico
        Dim viatico As EmpleadoViatico = adminEmpleado.viatico
        viatico.valor = valorViatico.Text
        Return viatico
    End Function

    Public Function crearAuxilio() As EmpleadoAuxilio
        Dim auxilio As EmpleadoAuxilio = adminEmpleado.auxilio
        auxilio.valor = valorAuxTransporte.Text

        Return auxilio
    End Function

    Public Function crearEmpleadoDetalle(empleado As Empleado) As TerceroDetalle
        Dim terceroDetalle As TerceroDetalle = adminEmpleado.terceroCuenta
        terceroDetalle.idEmpresa = SesionActual.idEmpresa
        terceroDetalle.idTercero = empleado.idEmpleado
        terceroDetalle.cuentaEmpleado = IIf(txtCuentaPuc.Text = String.Empty, Nothing, txtCuentaPuc.Text)
        terceroDetalle.codigoCIIU = IIf(txtCodigoCIIU.Text = String.Empty, Nothing, txtCodigoCIIU.Text)

        Return terceroDetalle
    End Function

    Public Function crearUsuario() As TerceroUsuario
        Dim terceroUsuario As TerceroUsuario = adminEmpleado.usuario

        terceroUsuario.usuario = txtUsuario.Text
        terceroUsuario.clave = IIf(txtClave.Enabled, txtClave.Text, Nothing)
        terceroUsuario.codigoPerfil = cbPerfil.SelectedValue
        terceroUsuario.estado = cbEstadoUsuario.SelectedValue

        Return terceroUsuario
    End Function

    Public Function crearAdminEmpleado() As AdminEmpleado
        Dim empleado As Empleado = crearEmpleado()
        Dim nuevaCuentaBancaria As EmpleadoCuentaBancaria = crearCuentaBancaria()
        Dim nuevoSalario As EmpleadoSalario = crearSalario()
        Dim nuevoTurno As EmpleadoTurno = crearTurno()
        Dim nuevaFirma As EmpleadoFirma = crearFirma()
        Dim nuevaFoto As EmpleadoFoto = crearFoto()
        Dim nuevoViatico As EmpleadoViatico = crearViatico()
        Dim nuevoAuxilio As EmpleadoAuxilio = crearAuxilio()
        Dim nuevoUsuario As TerceroUsuario = crearUsuario()
        Dim nuevoTerceroCuenta As TerceroDetalle = crearEmpleadoDetalle(empleado)

        adminEmpleado.esOtraCuenta = Not adminEmpleado.cuentaBancaria.Equals(nuevaCuentaBancaria)
        'adminEmpleado.esOtroSalario = adminEmpleado.salario.Equals(nuevoSalario)
        adminEmpleado.esOtroTurno = adminEmpleado.turno.Equals(nuevoTurno)
        adminEmpleado.esOtraFoto = adminEmpleado.foto.Equals(nuevaFoto)
        'adminEmpleado.esOtroViatico = adminEmpleado.viatico.Equals(nuevoViatico)
        adminEmpleado.esOtroAuxilio = adminEmpleado.auxilio.Equals(nuevoAuxilio)
        adminEmpleado.esOtroUsuario = adminEmpleado.usuario.Equals(nuevoUsuario) OrElse btEditarUsuario.Enabled

        adminEmpleado.empleado = empleado
        adminEmpleado.cuentaBancaria = nuevaCuentaBancaria
        adminEmpleado.salario = nuevoSalario
        adminEmpleado.turno = nuevoTurno
        adminEmpleado.foto = nuevaFoto
        'adminEmpleado.viatico = nuevoViatico
        adminEmpleado.auxilio = nuevoAuxilio
        adminEmpleado.usuario = nuevoUsuario
        adminEmpleado.terceroCuenta = nuevoTerceroCuenta

        adminEmpleado.puntosAsignados = crearPuntosAsignados()
        adminEmpleado.areasAsignadas = crearAreasAsignadas()

        Return adminEmpleado
    End Function

    Public Function crearPuntosAsignados() As List(Of EmpresaPunto)
        Dim puntosAsignados As New List(Of EmpresaPunto)

        For Each item As EmpresaPunto In chlPuntosAsignados.Items
            Dim punto As New EmpresaPunto
            punto = item

            puntosAsignados.Add(punto)
        Next

        Return puntosAsignados
    End Function

    Public Function crearAreasAsignadas() As List(Of EmpleadoAreaServicio)
        Dim areasAsignadas As New List(Of EmpleadoAreaServicio)

        For Each item As EmpleadoAreaServicio In chlAreasAsignadas.Items
            Dim area As New EmpleadoAreaServicio
            area = item

            areasAsignadas.Add(area)
        Next

        Return areasAsignadas
    End Function

#End Region
#Region "Dibujar componentes desde la entidad"
    Public Sub visualizarDatosEmpleado(adminEmpleado As AdminEmpleado)

        visualizarDatosBasicos(adminEmpleado.empleado)
        visualizarDatosTercero(adminEmpleado.tercero, adminEmpleado.terceroCuenta)
        visualizarDatosCuentaBancaria(adminEmpleado.cuentaBancaria)
        visualizarDatosPrestaciones(adminEmpleado.turno,
                                    adminEmpleado.salario,
                                    adminEmpleado.viatico,
                                    adminEmpleado.auxilio)
        visualizarImagenesEmpleado(adminEmpleado.foto, adminEmpleado.firma)
        visualizarDatosUsuario(adminEmpleado.usuario, adminEmpleado.perfil)

        listarPuntosDisponibles(adminEmpleado.puntosDisponibles)
        listarPuntosAsignados(adminEmpleado.puntosAsignados)
        listarAreasDisponibles(adminEmpleado.areasDisponibles)
        listarAreasAsignadas(adminEmpleado.areasAsignadas)


    End Sub

    Public Sub visualizarDatosBasicos(empleado As Empleado)
        idEmpleado = empleado.idEmpleado
        txtiniciales.Text = empleado.iniciales
        TxtRegistro.Text = empleado.registroMedico

        chRefuerzo.Checked = IIf(empleado.tipoempleado = Constantes.EMPLEADO_TIPO_REFUERZO, True, False)
        General.formatDatePicker(dtpFechaExp, empleado.fechaExpedicion)
        General.formatDatePicker(dtpFechaIngreso, empleado.fechaIngreso)
        General.formatDatePicker(dtpFechaRetiro, empleado.fechaRetiro)
        General.formatDatePicker(dtpFechaNac, empleado.fechaNacimiento)

        cbCargo.SelectedValue = Funciones.formatComboItem(empleado.codigoCargo)
        cbGenero.SelectedValue = Funciones.formatComboItem(empleado.codigoGenero)
        cbPaisExp.SelectedValue = Funciones.formatComboItem(empleado.codigoPaisExp)
        cbDptoExp.SelectedValue = Funciones.formatComboItem(empleado.codigoDepartamentoExp)
        cbMunicipioExp.SelectedValue = Funciones.formatComboItem(empleado.codigoMunicipioExp)
        cbPaisNac.SelectedValue = Funciones.formatComboItem(empleado.codigoPaisNac)
        cbDptoNac.SelectedValue = Funciones.formatComboItem(empleado.codigoDepartamentoNac)
        cpMunicipioNac.SelectedValue = Funciones.formatComboItem(empleado.codigoMunicipioNac)
        cbEspecialidad.SelectedValue = Funciones.formatComboItem(empleado.codigoEspecialidad)
        cbProfesion.SelectedValue = Funciones.formatComboItem(empleado.codigoProfesion)
        cbEps.SelectedValue = Funciones.formatComboItem(empleado.idEps)
        cbArp.SelectedValue = Funciones.formatComboItem(empleado.codigoArp)
        cbCajaCompensacion.SelectedValue = Funciones.formatComboItem(empleado.codigoCaja)
        cbPension.SelectedValue = Funciones.formatComboItem(empleado.codigoPension)
        cbRh.SelectedItem = Funciones.formatComboItem(empleado.tipoRH)
    End Sub

    Public Sub visualizarDatosTercero(tercero As Tercero, terceroDetalle As TerceroDetalle)
        txtTipoId.Text = tercero.codigoTipoIdentificacion
        txtIdentificacion.Text = tercero.nit
        txtDv.Text = tercero.dv
        txtNombre.Text = tercero.nombre
        txtSnombre.Text = tercero.sNombre
        txtApellido.Text = tercero.apellido
        txtSapellido.Text = tercero.sApellido
        txtTelefono1.Text = tercero.telefono1
        txtTelefono2.Text = tercero.telefono2
        txtWhatsapp.Text = tercero.whatsapp
        txtDireccion.Text = tercero.direccion
        txtEmail.Text = tercero.email
        cbPaisRes.SelectedValue = Funciones.formatComboItem(tercero.codigoPais)
        cbDptoRes.SelectedValue = Funciones.formatComboItem(tercero.codigoDepartamento)
        cbCiudadRes.SelectedValue = Funciones.formatComboItem(tercero.codigoMunicipio)

        txtCuentaPuc.Text = terceroDetalle?.cuentaEmpleado
        txtCodigoCIIU.Text = terceroDetalle?.codigoCIIU
    End Sub

    Public Sub visualizarDatosCuentaBancaria(cuenta As EmpleadoCuentaBancaria)
        txtNumeroCuenta.Text = cuenta.numerocuenta
        txtCuentaCC.Text = cuenta.ccCuenta
        cbTipoCuenta.SelectedValue = Funciones.formatComboItem(cuenta.codigoTipoCuenta)
        cbBanco.SelectedValue = Funciones.formatComboItem(cuenta.CodigoBanco)
    End Sub

    Public Sub visualizarDatosPrestaciones(turno As EmpleadoTurno,
                                           salario As EmpleadoSalario,
                                           viatico As EmpleadoViatico,
                                           auxilio As EmpleadoAuxilio)
        valorTurno.Text = turno.valor
        txtValorSalario.Text = salario.valor
        valorViatico.Text = viatico.valor
        valorAuxTransporte.Text = auxilio.valor
    End Sub

    Public Sub visualizarImagenesEmpleado(foto As EmpleadoFoto, firma As EmpleadoFirma)
        pictureFoto.Image = foto.foto
        pictureFirma.Image = firma.imagen
    End Sub

    Public Sub visualizarDatosUsuario(usuario As TerceroUsuario, perfil As TerceroPerfil)
        cbPerfil.SelectedValue = Funciones.formatComboItem(perfil.codigoPerfil)
        cbEstadoUsuario.SelectedValue = Funciones.formatComboItem(usuario.estado)
        txtUsuario.Text = usuario.usuario
        txtClave.Text = Constantes.CONTRASEÑA
    End Sub

    Public Sub listarPuntosAsignados(puntos As List(Of EmpresaPunto))
        chlPuntosAsignados.Items.Clear()

        For Each punto As EmpresaPunto In puntos
            chlPuntosAsignados.Items.Add(punto)
        Next

        chlPuntosAsignados.DisplayMember = "Nombre"
        chlPuntosAsignados.ValueMember = "codigoEP"
    End Sub

    Public Sub configurarListas()
        chlPuntosAsignados.DisplayMember = "Nombre"
        chlPuntosAsignados.ValueMember = "codigoEP"

        chlPuntosDisponibles.DisplayMember = "Nombre"
        chlPuntosDisponibles.ValueMember = "codigoEP"

        chlAreasDisponibles.DisplayMember = "areaDescripcion"
        chlAreasDisponibles.ValueMember = "Codigo"

        chlAreasAsignadas.DisplayMember = "areaDescripcion"
        chlAreasAsignadas.ValueMember = "Codigo"
    End Sub

    Public Sub listarPuntosDisponibles(puntos As List(Of EmpresaPunto))
        chlPuntosDisponibles.Items.Clear()

        For Each punto As EmpresaPunto In puntos
            chlPuntosDisponibles.Items.Add(punto)
        Next

        chlPuntosDisponibles.DisplayMember = "Nombre"
        chlPuntosDisponibles.ValueMember = "codigoEP"
    End Sub

    Public Sub listarAreasDisponibles(areas As List(Of EmpleadoAreaServicio))
        chlAreasDisponibles.Items.Clear()

        For Each area As EmpleadoAreaServicio In areas
            chlAreasDisponibles.Items.Add(area)
        Next

        chlAreasDisponibles.DisplayMember = "areaDescripcion"
        chlAreasDisponibles.ValueMember = "Codigo"
    End Sub

    Public Sub listarAreasAsignadas(areas As List(Of EmpleadoAreaServicio))
        chlAreasAsignadas.Items.Clear()

        For Each area As EmpleadoAreaServicio In areas
            chlAreasAsignadas.Items.Add(area)
        Next

        chlAreasAsignadas.DisplayMember = "areaDescripcion"
        chlAreasAsignadas.ValueMember = "Codigo"
    End Sub

#End Region
#Region "Validacion de datos de ingreso en el formulario"
    Public Function validarFormulario()
        normalizarTXTsMoney(False)

        Dim esCorrecto As Boolean = False

        If txtIdentificacion.Text = "" Then
            Exec.SavingMsg("¡ Por favor seleccione un tercero!", btbuscartercero)
        ElseIf dtpFechaExp.Value.Date = CDate(Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)).Date Then
            Exec.SavingMsg("¡ Por favor digite una fecha de expedición del documento valida!", dtpFechaExp)
        ElseIf cbPaisExp.SelectedIndex < 1 Then
            Exec.SavingMsg("¡ Por favor seleccione pais de expedición del documento!", cbPaisExp)
        ElseIf cbDptoExp.SelectedIndex < 1 Then
            Exec.SavingMsg("¡ Por favor seleccione departamento de expedición del documento!", cbDptoExp)
        ElseIf cbMunicipioExp.SelectedIndex < 1 Then
            Exec.SavingMsg("¡ Por favor seleccione ciudad de expedición del documento!", cbMunicipioExp)
        ElseIf cbGenero.SelectedIndex < 1 Then
            Exec.SavingMsg("¡ Por favor seleccione sexo del empleado!", cbGenero)
        ElseIf cbRh.SelectedIndex < 1 Then
            Exec.SavingMsg("¡ Por favor seleccione tipo de sangre del empleado!", cbRh)
        ElseIf cbPaisNac.SelectedIndex < 1 Then
            Exec.SavingMsg("¡ Por favor seleccione pais de nacimiento del empleado!", cbPaisNac)
        ElseIf cbDptoNac.SelectedIndex < 1 Then
            Exec.SavingMsg("¡ Por favor seleccione departamento de nacimiento del empleado!", cbDptoNac)
        ElseIf cpMunicipioNac.SelectedIndex < 1 Then
            Exec.SavingMsg("¡ Por favor seleccione ciudad de nacimiento del empleado!", cpMunicipioNac)
        ElseIf dtpFechaNac.Value.Date = CDate(Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)).Date Then
            Exec.SavingMsg("¡ Por favor digite una fecha de nacimiento valida!", dtpFechaNac)
        ElseIf cbProfesion.SelectedIndex < 1 Then
            Exec.SavingMsg("¡ Por favor seleccione profesión del empleado!", cbProfesion)
        ElseIf cbCargo.SelectedIndex < 1 Then
            Exec.SavingMsg("¡ Por favor seleccione cargo del empleado!", cbCargo)
        ElseIf cbEspecialidad.SelectedIndex < 1 Then
            Exec.SavingMsg("¡ Por favor seleccione especialidad del empleado!", cbEspecialidad)
        ElseIf (valorTurno.Text = Nothing) Then
            Exec.SavingMsg("¡ Por favor digite un salario o valor del turno valido!", valorTurno)
        ElseIf (cbretefuente.Checked = True AndAlso Comboretefuente.SelectedIndex = 0) Then
            Exec.SavingMsg("¡ Por favor seleccione la cuenta retefuente del empleado!", Comboretefuente)
        ElseIf (txtNumeroCuenta.Text = "") Then
            Exec.SavingMsg("¡ Por favor digite la cuenta bancaria del empleado!", txtNumeroCuenta)
        ElseIf (txtCuentaCC.Text = "") Then
            Exec.SavingMsg("¡ Por favor digite el numero de cedula del titular de la cuenta!", txtCuentaCC)
        ElseIf (cbBanco.SelectedIndex < 1) Then
            Exec.SavingMsg("¡ Por favor seleccione el banco de la cuenta!", cbBanco)
        ElseIf (cbTipoCuenta.SelectedIndex < 1) Then
            Exec.SavingMsg("¡  Por favor seleccione el tipo de cuenta!", cbTipoCuenta)
        ElseIf (cbEps.SelectedIndex < 1) Then
            Exec.SavingMsg("¡  Por favor seleccione la eps del empleado!", cbEps)
        ElseIf (cbCajaCompensacion.SelectedIndex < 1) Then
            Exec.SavingMsg("¡ Por favor seleccione la caja de compensación del empleado!", cbCajaCompensacion)
        ElseIf (cbPension.SelectedIndex < 1) Then
            Exec.SavingMsg("¡  Por favor seleccione la pensión del empleado!", cbPension)
        ElseIf (cbArp.SelectedIndex < 1) Then
            Exec.SavingMsg("¡  Por favor seleccione la eps del empleado!", cbArp)
        ElseIf (validarEditable(txtUsuario) AndAlso txtUsuario.Text = "") Then
            Exec.SavingMsg("¡ Por favor digite el nombre de usuario!", txtUsuario)
        ElseIf (txtUsuario.Text.Length < 5 Or txtUsuario.Text.Length > 15) Then
            Exec.SavingMsg("¡ Por favor digite el nombre de usuario (entre 6-15 caracteres)!", txtUsuario)
        ElseIf (txtClave.Text = "") Then
            Exec.SavingMsg("¡ Por favor digite la contraseña de usuario!", txtClave)
        ElseIf (txtClave.Text.Length < 4 Or txtClave.Text.Length > 15) Then
            Exec.SavingMsg("¡ Por favor digite una contraseña de usuario válida (entre 6-15 caracteres)!", txtClave)
        ElseIf (validarEditable(cbPerfil) AndAlso cbPerfil.SelectedIndex < 1) Then
            Exec.SavingMsg("¡ Por favor seleccione el perfil del empleado!", cbPerfil)
        ElseIf (validarEditable(cbEstadoUsuario) AndAlso cbEstadoUsuario.SelectedIndex < 1) Then
            Exec.SavingMsg("¡ Por favor seleccione el estado de usuario!", cbEstadoUsuario)
        ElseIf (chlPuntosDisponibles.Items.Count <> 0 AndAlso chlPuntosAsignados.Items.Count = 0) Then
            Exec.SavingMsg("¡ Por favor escoja por lo menos 1 punto de servicio !", chlPuntosDisponibles)
        ElseIf (chlAreasDisponibles.Items.Count <> 0 AndAlso chlAreasAsignadas.Items.Count = 0) Then
            Exec.SavingMsg("¡ Por favor escoja por lo menos 1 area de servicio !", chlAreasDisponibles)
        Else
            esCorrecto = True
        End If

        Return esCorrecto
    End Function

    Public Sub llenarComboestadoUsuario()
        Dim slEstadoUsuario As New SortedList

        slEstadoUsuario.Add(Constantes.COMBO_TEXTO_PREDETERMINADO, Constantes.COMBO_VALOR_PREDETERMINADO)
        slEstadoUsuario.Add("Activo", 1)
        slEstadoUsuario.Add("Inactivo", 0)


        Dim bsCombo As New BindingSource
        bsCombo.DataSource = slEstadoUsuario

        cbEstadoUsuario.Items.Clear()
        cbEstadoUsuario.DataSource = bsCombo
        cbEstadoUsuario.ValueMember = "value"
        cbEstadoUsuario.DisplayMember = "key"

    End Sub
#End Region



End Class