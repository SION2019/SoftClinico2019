
Public Class Contratos_Amb
    Public buscar_camb As Boolean
    Public idrepresentante As Integer
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, Tmanual As String
    Dim ContratoAmb_c As New Object
    Dim objContratoAM As ContratosAM

    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Contratos_Amb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim params As New List(Of String)

        objContratoAM = New ContratosAM
        'permisos de uso de boton
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        'carga de combos
        General.cargarCombo(Consultas.PAIS_LISTAR, "Nombre", "Código", Combopais)
        Combopais.SelectedIndex = 0
        General.cargarCombo(Consultas.DPTO_LISTAR & "'" & Combopais.SelectedValue.ToString & "'", "Nombre", "Codigo_Departamento", Combodepartamento)
        General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & Combodepartamento.SelectedValue.ToString & "'", "Nombre", "Codigo_Municipio", Combociudad)
        General.cargarCombo(Consultas.MANUAL_EPS_LISTAR, "Nombre_EPS", "Codigo", Combo_administradora)
        General.cargarCombo(Consultas.PLAZO_LLENAR_COMBO, "Descripción", "Código", CmbPlazo)
        General.cargarCombo(ConsultasAmbu.MANUAL_TARIFARIO_AM_BUSCAR & SesionActual.idEmpresa, "Nombre", "Codigo", Combomanual)
        params.Add(1)
        General.cargarCombo(ConsultasAmbu.CONTRATO_AM_TARIFA_CARGAR, params, "Descripción tarifa", "Código", cmbTarifaProce)
        params.Clear()
        params.Add(2)
        General.cargarCombo(ConsultasAmbu.CONTRATO_AM_TARIFA_CARGAR, params, "Descripción tarifa", "Código", cmbTarifaProceSOAT)
        General.deshabilitarControles(Me)
        General.deshabilitarBotones(ToolStrip1)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        dgvTraslados.DataSource = objContratoAM.dtTraslados
        dgvTraslados.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTraslados.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 8)
        dgvTraslados.Columns(1).DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7)
        dgvTraslados.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvTraslados.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvTraslados.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvTraslados.Columns(4).Width = 40
        objContratoAM.dtTraslados.Clear()
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs)
        General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
        Textnombre.Focus()
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs)
        If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
            General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
            Textnombre.Focus()
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs)
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub

    Private Sub bttercero_Click(sender As Object, e As EventArgs)
        General.cargarForm(FormTercero)
    End Sub

    Private Sub btbuscarcliente_Click(sender As Object, e As EventArgs) Handles btbuscarcliente.Click
        Dim params As New List(Of String)
        params.Add(Nothing)
        params.Add(SesionActual.codigoEP)
        If SesionActual.tienePermiso(PBuscar ) Then
            General.buscarElemento(Consultas.BUSQUEDA_CLIENTES_CONTRATO,
                                             params,
                                             AddressOf cargarCliente,
                                             TitulosForm.BUSQUEDA_CLIENTES,
                                             True, 0, True)

        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub cargarCodigoHabilitacion(rCodigo As Integer)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(rCodigo)
        Try
            dFila = General.cargarItem(ObjContratoAM.sqlBuscarCodigoHab, params)
            Textcod_adminis.Text = If(IsDBNull(dFila.Item(0)), "", dFila.Item(0))
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Try
            If SesionActual.tienePermiso(Pnuevo) Then
                General.buscarElemento(objContratoAM.sqlBuscarManualTarifarioCON,
                                  Nothing,
                                  AddressOf cargarManualTarifarioCON,
                                  TitulosForm.BUSQUEDA_MANUAL_TARIFARIO,
                                  False)
            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub cargarCliente(pCodigo)
        Dim dr As DataRow
        Dim params As New List(Of String)
        General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
        params.Add(pCodigo)
        dr = General.cargarItem(Consultas.CARGAR_CLIENTES,
                                              params)

        Textnit.Text = dr.Item(0)
        Textdv.Text = dr.Item(1)
        Textnombre.Text = dr.Item(2)
        Combopais.SelectedValue = dr.Item(3)
        Combodepartamento.SelectedValue = dr.Item(4)
        Combociudad.SelectedValue = dr.Item(5)
        Textdireccion.Text = dr.Item(6)
        Texttelfijo.Text = dr.Item(7)
        Textcelular.Text = dr.Item(8)
        Textidcliente.Text = pCodigo
        General.deshabilitarControles(GpInfBasica)
        btbuscarcliente.Enabled = True
        llenarTraslados()
    End Sub
    Private Sub llenarTraslados()
        objContratoAM.llenarTraslados()
        If btguardar.Enabled = True Then
            dgvTraslados.Columns(0).ReadOnly = True
            dgvTraslados.Columns(1).ReadOnly = True
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RbSOAT.CheckedChanged
        GpSOAT.Enabled = True
        General.limpiarControles(GpISS)
        Tmanual = 2
        GpISS.Enabled = False
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RbISS.CheckedChanged
        GpISS.Enabled = True
        General.limpiarControles(GpSOAT)
        Tmanual = 1
        GpSOAT.Enabled = False
        llenarTraslados()
    End Sub

    Private Sub btcancelar_Click_1(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.Yes Then
            General.deshabilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            General.limpiarControles(Me)
            btnuevo.Enabled = True
            btbuscar.Enabled = True
        End If
    End Sub

    Private Sub btguardar_Click_1(sender As Object, e As EventArgs) Handles btguardar.Click
        If ValidarDatos() = True Then Exit Sub
        'Guarda en base de datos de contratos ambulancia
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Try
                cargarObjetoContratoAM()
                ContratoAmBLL.guardarContratoAM(objContratoAM)
                General.habilitarBotones(ToolStrip1)
                General.deshabilitarControles(Me)
                btguardar.Enabled = False
                btcancelar.Enabled = False
                txtcodigo.Text = objContratoAM.codigoContrato
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub

    Private Sub btbuscar_Click_1(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.idEmpresa)
            General.buscarElemento(objContratoAM.sqlBuscarContratoAM,
                              params,
                              AddressOf cargarContratoAM,
                              TitulosForm.BUSQUEDA_CONTRATO_AM,
                              False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub Modulos_perfil_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
    Private Function ValidarDatos() As Boolean
        Dim res As Boolean
        If String.IsNullOrEmpty(Textcedula.Text) Then
            Textcedula.Focus()
            MsgBox("La identificación esta en Blanco...", MsgBoxStyle.Exclamation)
            res = True
        ElseIf String.IsNullOrEmpty(Textnombrerepresentante.Text) Then
            Textnombrerepresentante.Focus()
            MsgBox("El Nombre Representante esta en Blanco...", MsgBoxStyle.Exclamation)
            res = True
        ElseIf String.IsNullOrEmpty(textnumcontrato.Text) Then
            textnumcontrato.Focus()
            MsgBox("El numero de Contrato esta en Blanco...", MsgBoxStyle.Exclamation)
            res = True
        ElseIf Combo_administradora.SelectedValue = -1 Or Combo_administradora.SelectedIndex = -1 Then
            Combo_administradora.Focus()
            MsgBox("La EPS esta en Blanco o no Es Valida...", MsgBoxStyle.Exclamation)
            res = True
        ElseIf String.IsNullOrEmpty(Textcod_adminis.Text) Then
            Textcod_adminis.Focus()
            MsgBox("Codigo Habilitación EPS esta en Blanco...", MsgBoxStyle.Exclamation)
            res = True
        ElseIf CmbPlazo.SelectedValue = -1 Then
            CmbPlazo.Focus()
            MsgBox("El plazo esta en Blanco...", MsgBoxStyle.Exclamation)
            res = True
        ElseIf Tmanual = Nothing Then
            Combomanual.Focus()
            MsgBox("No ha Seleccionado un Manual Tarifario...", MsgBoxStyle.Exclamation)
            res = True
        Else
            If Tmanual = 2 Then
                If cmbTarifaProceSOAT.SelectedValue = -1 Then
                    cmbTarifaProceSOAT.Focus()
                    MsgBox("No ha Seleccionado un Tarifa Institucional...", MsgBoxStyle.Exclamation)
                    res = True
                ElseIf Combomanual.SelectedValue = -1 Then
                    Combomanual.Focus()
                    MsgBox("No ha Seleccionado una Tarifa de Servicio...", MsgBoxStyle.Exclamation)
                    res = True
                End If
            Else
                If cmbTarifaProce.SelectedValue = -1 Then
                    cmbTarifaProce.Focus()
                    MsgBox("No ha Seleccionado un Tarifa ISS...", MsgBoxStyle.Exclamation)
                    res = True
                End If
            End If
        End If
        Return res
    End Function
    Sub cargarContratoAM(pCodigo As Integer)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(pCodigo)
        Try
            dFila = General.cargarItem(objContratoAM.sqlCargarContratoAM, params)
            objContratoAM.codigoContrato = pCodigo
            objContratoAM.idCliente = dFila.Item(0)
            cargarCliente(objContratoAM.idCliente)
            dtFecha.Value = dFila.Item(1)
            dtFechaFin.Value = dFila.Item(2)
            Textcedula.Text = If(IsDBNull(dFila.Item(3)), Nothing, dFila.Item(3))
            Textnombrerepresentante.Text = If(IsDBNull(dFila.Item(4)), "", dFila.Item(4))
            textnumcontrato.Text = dFila.Item(5)
            Combo_administradora.SelectedValue = If(IsDBNull(dFila.Item(6)), -1, dFila.Item(6))
            Textcod_adminis.Text = IIf(IsDBNull(dFila.Item(7)), "", dFila.Item(7))
            CmbPlazo.SelectedValue = If(IsDBNull(dFila.Item(8)), -1, dFila.Item(8))
            asignar.Checked = dFila.Item(9)
            Tmanual = dFila.Item(11)
            If Tmanual = 1 Then
                RbSOAT.Checked = False
                RbISS.Checked = True
                cmbTarifaProce.SelectedValue = If(IsDBNull(dFila.Item(10)), -1, dFila.Item(10))
            Else
                RbISS.Checked = False
                RbSOAT.Checked = True
                cmbTarifaProceSOAT.SelectedValue = If(IsDBNull(dFila.Item(10)), -1, dFila.Item(10))
                Combomanual.SelectedValue = dFila.Item(12)
            End If
            Observaciones.Text = dFila.Item(13)
            txtcodigo.Text = pCodigo
            llenarTraslados()
            General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub bteditar_Click_1(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            'Edita en base de datos los valores del Manual Tarifario Ambulancia
            General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
            General.deshabilitarControles(GpInfBasica)
            dgvTraslados.Columns(0).ReadOnly = True
            dgvTraslados.Columns(1).ReadOnly = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btanular_Click_1(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Try
                    objContratoAM.AnularContratoAM()
                    General.deshabilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    General.limpiarControles(Me)
                    btbuscar.Enabled = True
                    btnuevo.Enabled = True
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                Catch ex As Exception

                End Try
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Sub cargarObjetoContratoAM()
        objContratoAM.codigoContrato = txtcodigo.Text
        objContratoAM.idEmpresa = SesionActual.idEmpresa
        objContratoAM.idCliente = Textidcliente.Text
        objContratoAM.idEPS = Combo_administradora.SelectedValue
        objContratoAM.codigoAdmin = Textcod_adminis.Text
        objContratoAM.numContrato = textnumcontrato.Text
        objContratoAM.codigoPais = Combopais.SelectedValue
        objContratoAM.codigoDpto = Combodepartamento.SelectedValue
        objContratoAM.codigoMunicipio = Combociudad.SelectedValue
        objContratoAM.idRepresentante = IIf(Textcedula.Text = "", Nothing, Textcedula.Text)
        objContratoAM.NombreRep = Textnombrerepresentante.Text
        objContratoAM.fecha = dtFecha.Value
        objContratoAM.fechaVencimento = dtFechaFin.Value
        objContratoAM.plazo = CmbPlazo.SelectedValue
        objContratoAM.estado = asignar.Checked
        objContratoAM.Observaciones = Observaciones.Text
        objContratoAM.TipoCodRef = Tmanual
        If Tmanual = 1 Then
            objContratoAM.CodigoHA = cmbTarifaProce.SelectedValue
        Else
            objContratoAM.CodigoHA = Nothing
        End If
        objContratoAM.codigoManual = Combomanual.SelectedValue
        objContratoAM.Usuario = SesionActual.idUsuario
    End Sub

    Private Sub btterminar_Click(sender As Object, e As EventArgs) Handles btterminar.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            If MsgBox(Mensajes.TERMINAR_CONTRATO, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.TERMINAR) = MsgBoxResult.Yes Then
                Try
                    objContratoAM.TerminarContratoAM()
                    General.deshabilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    General.limpiarControles(Me)
                    btbuscar.Enabled = True
                    btnuevo.Enabled = True
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                Catch ex As Exception

                End Try
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btOpcionTarifa_Click(sender As Object, e As EventArgs) Handles btOpcionTarifa.Click
        Dim tarifa As New Form_Tarifas_Servicios
        'objFormContrato.Combotarifaimag = Combotarifaimag
        'objFormContrato.Combotarifalab = Combotarifalab
        'objFormContrato.Combotarifalab = Combotarifalab
        'objFormContrato.ShowDialog()
    End Sub

    Private Sub dgvTraslados_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvTraslados.CellFormatting
        If e.ColumnIndex > 1 And Not IsDBNull(dgvTraslados.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
            e.Value = CDbl(e.Value).ToString("C2")
        Else
            e.Value = If(e.ColumnIndex > 1, CDbl(0).ToString("C2"), e.Value)
        End If
    End Sub

    Private Sub dgvTraslados_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvTraslados.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
    End Sub

    Private Sub dtFechaFin_CloseUp(sender As Object, e As EventArgs) Handles dtFechaFin.CloseUp
        If dtFechaFin.Value < dtFecha.Value Then
            MsgBox("La fecha de Fin del Contrato no puede ser menor a la Fecha de Inicio de Contrato..", MsgBoxStyle.Critical)
            dtFechaFin.Value = dtFecha.Value
            Return
        End If
    End Sub

    Private Sub dtFecha_CloseUp(sender As Object, e As EventArgs) Handles dtFecha.CloseUp
        If dtFecha.Value > dtFechaFin.Value Then
            MsgBox("La fecha de Inicio del Contrato no puede ser Mayor a la Fecha de Fin de Contrato", MsgBoxStyle.Critical)
            dtFecha.Value = dtFechaFin.Value
            Return
        End If
    End Sub

    Private Sub Textcedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Textcedula.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cargarManualTarifarioCON(pCodigo As Integer)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(pCodigo)
        Try
            dFila = General.cargarItem(objContratoAM.sqlCargarManualTarifarioCON, params)
            Combomanual.SelectedValue = dFila(0)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub Combopais_SelectedValueChanged(sender As Object, e As EventArgs) Handles Combopais.SelectedValueChanged
        If Combodepartamento.ValueMember <> String.Empty Then
            General.cargarCombo(Consultas.DPTO_LISTAR & "'" & Combopais.SelectedValue & "'", "Nombre", "Codigo_Departamento", Combodepartamento)
        End If
    End Sub
    Private Sub SelectedValueChanged(sender As Object, e As EventArgs) Handles Combodepartamento.SelectedValueChanged
        If Combociudad.ValueMember <> String.Empty Then
            General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & Combodepartamento.SelectedValue & "'", "Nombre", "Codigo_Municipio", Combociudad)
        End If
    End Sub

    Private Sub btnuevo_Click_1(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.limpiarControles(Me)
            General.deshabilitarBotones(ToolStrip1)
            General.habilitarControles(GpInfBasica)
            btcancelar.Enabled = True
            GpInfBasica.Enabled = True
            Textnit.ReadOnly = True
            Textdv.ReadOnly = True
            Textdireccion.ReadOnly = True
            Textnombre.ReadOnly = True
            Texttelfijo.ReadOnly = True
            Textcelular.ReadOnly = True
            Combopais.Enabled = False
            Combodepartamento.Enabled = False
            Combociudad.Enabled = False
            GpSOAT.Enabled = False
            GpISS.Enabled = False
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Combo_administradora_SelectedValueChanged(sender As Object, e As EventArgs) Handles Combo_administradora.SelectedValueChanged
        If Combo_administradora.SelectedIndex > 0 Then
            cargarCodigoHabilitacion(Combo_administradora.SelectedValue)
        Else
            Textcod_adminis.Clear()
        End If
    End Sub
End Class