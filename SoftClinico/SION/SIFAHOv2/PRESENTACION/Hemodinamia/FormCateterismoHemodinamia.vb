Imports System.Threading
Public Class FormCateterismoHemodinamia
    Dim respuesta, activoAM, activoAF As Boolean
    Dim perG As New Buscar_Permisos_generales
    Dim guardarEn2doPlano As Thread
    Dim objCateterismo As CateterismoCardiaco
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, codigoTemporal As String
    Public Property objHistoriaClinica As HistoriaClinica
    Public Property objFormHistoriaClinica As Form_Historia_clinica
    Private moduloTemporal As String
    Property codigoExamen As String
    Property codigoOrden As Integer
    Private Sub FormCateterismoHemodinamia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        inicializarForm()
    End Sub
    Private Sub habilitarControles()
        txtfecha.Enabled = True
        comboPuncion.Enabled = True
        ComboMedico.Enabled = True
        cmbCargo.Enabled = True
        txtcomentarioHemo.ReadOnly = False
    End Sub
    Private Sub cmbCargo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCargo.SelectedValueChanged
        If cmbCargo.SelectedIndex > 0 Then
            cargarComboMedico()
        Else
            ComboMedico.DataSource = Nothing
        End If
    End Sub
    Private Sub cargarComboMedico()
        Dim params As New List(Of String)
        params.Add(cmbCargo.SelectedValue)
        params.Add(SesionActual.idEmpresa)
        General.cargarCombo(ConsultasAmbu.CARGO_AM_BUSCAR, params, "Empleado", "Id_empleado", ComboMedico)
        cmbCargo.DropDownHeight = 150
        cmbCargo.AutoCompleteMode = AutoCompleteMode.None
        cmbCargo.AutoCompleteSource = AutoCompleteSource.None
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function

    Private Sub Form__FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If btguardar.Enabled = True And IsNothing(objFormHistoriaClinica) Then
            e.Cancel = True
            MsgBox(Mensajes.CAMBIOS_SIN_GUARDAR, MsgBoxStyle.Critical)
            Exit Sub
        End If
        If IsNothing(objFormHistoriaClinica) Then
            If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
                Me.Dispose()
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try

            objCateterismo.codigoCateterismo = Textcodigo.Text
            objCateterismo.imprimir()

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        ' If SesionActual.tienePermiso(PBuscar) Then
        Dim params As New List(Of String)
        params.Add("")
        params.Add(SesionActual.codigoEP)
        General.buscarItem(objCateterismo.buscarInformeCateterismo,
                               params,
                               AddressOf cargarInformeCateterismo,
                               TitulosForm.BUSQUEDA_CATETERISMO,
                               True, True, Constantes.TAMANO_MEDIANO)
        'Else
        '    MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        'End If
    End Sub

    Private Function validarInformacion()
        If cmbCargo.SelectedIndex < 1 Then
            MsgBox("¡Por favor elija el cargo!", MsgBoxStyle.Exclamation)
            cmbCargo.Focus()
            Return False
        ElseIf ComboMedico.SelectedIndex < 1 Then
            MsgBox("¡Por favor elija el médico!", MsgBoxStyle.Exclamation)
            ComboMedico.Focus()
            Return False
        ElseIf comboPuncion.SelectedIndex < 1 Then
            MsgBox("¡Por favor elija el tipo de puncion!", MsgBoxStyle.Exclamation)
            comboPuncion.Focus()
            Return False
        End If
        Return True
    End Function
    Public Sub crearInformeCateterismo()

        objCateterismo.codigoCateterismo = Textcodigo.Text
        objCateterismo.codigoProcedimiento = objCateterismo.codigoExamen
        objCateterismo.codigoOrden = objCateterismo.codigoOrden
        objCateterismo.fechaCateterismo = (Format(txtfecha.Value, Constantes.FORMATO_FECHA_HORA_GEN))
        objCateterismo.idAnestesiologo = ComboMedico.SelectedValue
        objCateterismo.usuario = SesionActual.idUsuario
        objCateterismo.tblResultadosInforme = objCateterismo.dtInformeCateterismo.Copy
        objCateterismo.tblResultadosInforme.Columns.RemoveAt(1)
    End Sub
    Private Sub guardarCateterismo()
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Try
                btimprimir.Enabled = False
                dgvResultados.EndEdit()
                recargarGrilla(objCateterismo.dtInformeCateterismo, txtcomentarioHemo)
                crearInformeCateterismo()
                objCateterismo.guardarCateterismo()
                Textcodigo.Text = objCateterismo.codigoCateterismo
                txtcomentarioHemo.Clear()
                codigoTemporal = Textcodigo.Text
                General.deshabilitarControles(Me)
                General.habilitarBotones(Me.ToolStrip1)
                btguardar.Enabled = False
                btcancelar.Enabled = False
                btimprimir.Enabled = False
                'verificarActivoYEdicion()
                If Not IsNothing(objFormHistoriaClinica) Then
                    objFormHistoriaClinica.cargarOrdenMedica()
                End If
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
            btimprimir.Enabled = True
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarInformacion() Then
            dgvResultados.EndEdit()
            objCateterismo.dtInformeCateterismo.AcceptChanges()
            guardarCateterismo()
        End If
    End Sub
    Private Sub dgvResultados_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvResultados.KeyPress
        If btguardar.Enabled = False Then Exit Sub
        abrirTexto(dgvResultados, objCateterismo.tblResultadosInforme, Panel2, txtcomentarioHemo, "Resultado")
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Try
            '  If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                objCateterismo.anularCateterismo(activoAM, activoAF)
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                General.limpiarControles(Me)
                General.deshabilitarBotones(ToolStrip1)
                btnuevo.Enabled = True
                btbuscar.Enabled = True
            End If
            'End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
#Region "Metodos"
    Sub inicializarForm()
        If IsNothing(objHistoriaClinica) Then
            moduloTemporal = Tag.Modulo
        Else
            moduloTemporal = objHistoriaClinica.modulo
        End If
        ' permisoFormulario(moduloTemporal)
        instanciarObjeto()
        Label3.Text = objCateterismo.titulo
        iniciarCombos()
        If validacionInicial() = True Then
            With dgvResultados
                .DataSource = objCateterismo.dtInformeCateterismo
                .AutoGenerateColumns = False
            End With
            General.diseñoDGV(dgvResultados)
            dgvResultados.ReadOnly = True
        Else
            Close()
        End If
    End Sub
    Private Function validacionInicial() As Boolean
        Dim banderaAuxi As Boolean = False
        Dim params As New List(Of String)
        Dim dFila As DataRow
        Dim dParams As DataTable
        If Not IsNothing(objHistoriaClinica) Then
            dParams = New DataTable
            dParams.Columns.Add("codigoOrden")
            dParams.Columns.Add("codigoProcedimiento")
            dParams.Rows.Add()
            dParams.Rows(0).Item("codigoOrden") = codigoOrden
            dParams.Rows(0).Item("codigoProcedimiento") = codigoExamen
            dFila = dParams.Rows(0)
            If cargarInformeCateterismo(dFila) = False Then
                If buscarResponsable() = True Then
                    cargarPaciente(dFila)
                    txtregistro.Text = objHistoriaClinica.nRegistro
                    objCateterismo.registro = objHistoriaClinica.nRegistro
                    banderaAuxi = True
                    btbuscarPaciente.Enabled = False
                End If
            Else
                banderaAuxi = True
            End If
        Else
            General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
            banderaAuxi = True
        End If

        Return banderaAuxi

    End Function
    Private Sub permisoFormulario(modulo As String)
        permiso_general = perG.buscarPermisoGeneral(Name, modulo)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
    End Sub
    Private Sub instanciarObjeto()
        objCateterismo = GeneralHC.fabricaHC.crear(Constantes.CODIGO_CATETERISMO & moduloTemporal)
        activoAM = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AM & "'")
        activoAF = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AF & "'")
    End Sub
    Private Sub iniciarCombos()
        Dim params As New List(Of String)
        params.Add("")
        General.cargarCombo(Consultas.TIPO_PUNCION_LISTAR, "Descripción", "Código", comboPuncion)
        General.cargarCombo(Consultas.CARGO_LISTAR, params, "Descripción cargo", "Código", cmbCargo)
        cargarComboMedico()
    End Sub
    Private Sub validarCodigo()
        Select Case objCateterismo.codigoExamen
            Case Constantes.CODIGO_EXAMEN_CATETERISMO
                objCateterismo.titulo = Constantes.NOMBRE_CATETERISMO
                RadioFallida.Visible = False
                RadioStent.Visible = False
            Case Else
                objCateterismo.titulo = Constantes.NOMBRE_ANGIOPLASTIA_STENT
                RadioFallida.Visible = True
                RadioStent.Visible = True
        End Select
    End Sub
    Private Sub abrirTexto(dgv As DataGridView, dt As DataTable, panel As Panel, texto As TextBox, nombreColumna As String)
        recargarGrilla(dt, texto)
        texto.Text = dgv.Rows(dgv.CurrentRow.Index).Cells(nombreColumna).Value.ToString
        objCateterismo.codigoDescripcion = dgv.Rows(dgv.CurrentRow.Index).Cells("Codigo").Value.ToString
        texto.Focus()
        texto.SelectionStart = texto.TextLength
    End Sub
    Private Sub recargarGrilla(dt As DataTable, texto As TextBox)
        If Not IsNothing(objCateterismo.codigoDescripcion) And
            Not String.IsNullOrEmpty(txtcomentarioHemo.Text) And btguardar.Enabled = True Then
            For Fila = 0 To dt.Rows.Count - 1
                If dt.Rows(Fila).Item("Codigo") = objCateterismo.codigoDescripcion Then
                    dt.Rows(Fila).Item("Resultado") = texto.Text
                End If
            Next
        End If
    End Sub
    Private Sub dgvResultados_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultados.CellClick
        If dgvResultados.RowCount > 0 Then
            abrirTexto(dgvResultados, objCateterismo.dtInformeCateterismo, Panel2, txtcomentarioHemo, "Resultado")
        End If
    End Sub
    Public Sub cargarItemsInforme()
        Dim params As New List(Of String)
        params.Add(objCateterismo.codigoExamen)
        params.Add(comboPuncion.SelectedValue)
        General.llenarTabla(Consultas.CONSULTA_ITEMS_DE_PROCEDIMIENTO, params, objCateterismo.dtInformeCateterismo)
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        'If SesionActual.tienePermiso(Pnuevo) Then
        Dim tbl As DataRow = buscarUsuarioReal()
        If tbl IsNot Nothing Then
            General.deshabilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            General.limpiarControles(Me)
            btguardar.Enabled = True
            btcancelar.Enabled = True
            btbuscarPaciente.Enabled = True
            habilitarControles()
            objCateterismo.usuarioReal = tbl(0)
            TextNombreUsuario.Text = tbl(1)
        Else
            MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        'Else
        '    MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        'End If
    End Sub
    Private Function buscarUsuarioReal() As DataRow
        Dim params As New List(Of String)
        params.Add(Constantes.LISTA_CARGO_ORDEN_MEDICA)
        params.Add(SesionActual.idEmpresa)
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC,
                                                                          params,
                                                                          TitulosForm.BUSQUEDA_EMPLEADO_HC,
                                                                          True,, True)
        Return formBusqueda.rowResultados
    End Function

    Private Sub btbuscarPaciente_Click(sender As Object, e As EventArgs) Handles btbuscarPaciente.Click
        Dim params As New List(Of String)
        params.Add(String.Empty)
        params.Add(SesionActual.codigoEP)
        General.buscarItem(objCateterismo.sqlPacienteBuscar,
                               params,
                               AddressOf cargarPaciente,
                               TitulosForm.BUSQUEDA_PACIENTE,
                               False, True, Constantes.TAMANO_MEDIANO)
    End Sub

    Public Sub cargarPaciente(pCodigo As DataRow)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        Try
            params.Add(pCodigo.Item(0))
            params.Add(pCodigo.Item(1))
            dFila = General.cargarItem(objCateterismo.sqlPacienteCargar, params)
            If Not IsNothing(dFila) Then
                txtregistro.Text = dFila.Item("N_Registro")
                txtidentificacion.Text = dFila.Item("Documento")
                txtnombre.Text = dFila.Item("Paciente")
                txtedad.Text = dFila.Item("Edad")
                txtfecha.Value = dFila.Item("Fecha")
                txtremitido.Text = dFila.Item("Entidad")
                txtDx.Text = dFila.Item("DX")
                txtProcedimiento.Text = dFila.Item("Estudio")
                objCateterismo.codigoExamen = pCodigo.Item(1)
                objCateterismo.codigoOrden = pCodigo.Item(0)
                objCateterismo.registro = dFila.Item("N_Registro")
                validarCodigo()
                habilitarControles()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function cargarInformeCateterismo(dFila As DataRow) As Boolean
        Dim dt As New DataTable
        Dim params As New List(Of String)
        Dim Existente As Boolean = False
        params.Add(dFila(1))
        params.Add(dFila(0))
        General.llenarTabla(objCateterismo.cargarInformeCateterismo, params, dt)
        If dt.Rows.Count > 0 Then
            txtregistro.Text = dt.Rows(0).Item("N_Registro").ToString()
            txtidentificacion.Text = dt.Rows(0).Item("Identificacion").ToString()
            txtedad.Text = dt.Rows(0).Item("Edad").ToString()
            txtnombre.Text = dt.Rows(0).Item("Paciente").ToString()
            txtDx.Text = dt.Rows(0).Item("Descripcion").ToString()
            txtremitido.Text = dt.Rows(0).Item("EPS").ToString()
            TextNombreUsuario.Text = dt.Rows(0).Item("Usuario").ToString()
            comboPuncion.SelectedValue = dt.Rows(0).Item("Codigo_Puncion").ToString()
            cmbCargo.SelectedValue = dt.Rows(0).Item("Codigo_cargo").ToString()
            ComboMedico.SelectedValue = dt.Rows(0).Item("Id_Anestesiologo").ToString()
            Textcodigo.Text = dt.Rows(0).Item("Codigo_Informe").ToString()
            objCateterismo.registro = dt.Rows(0).Item("N_Registro").ToString()
            txtProcedimiento.Text = dt.Rows(0).Item("Estudio").ToString()
            txtfecha.Value = dt.Rows(0).Item("Fecha_Informe").ToString()
            objCateterismo.codigoExamen = dt.Rows(0).Item("Codigo_Procedimiento").ToString()
            objCateterismo.codigoCateterismo = Textcodigo.Text
            validarCodigo()
            cargarDatosDetalle(Textcodigo.Text)
            txtcomentarioHemo.Text = objCateterismo.dtInformeCateterismo.Rows(1).Item("Resultado")
            dgvResultados.Rows(1).Cells(1).Selected = True
            objCateterismo.banderaGuardar = True
            General.deshabilitarControles(Me)
            General.habilitarBotones(ToolStrip1)
            btguardar.Enabled = False
            btcancelar.Enabled = False
            Existente = True
        Else
            General.deshabilitarBotones(ToolStrip1)
            btguardar.Enabled = True
            btcancelar.Enabled = True
            txtcomentarioHemo.ReadOnly = False
        End If
        Return Existente
    End Function
    Private Sub cargarDatosDetalle(codigo As Integer)
        Dim params As New List(Of String)
        params.Add(codigo)
        General.llenarTabla(objCateterismo.sqlCargarDetalle, params, objCateterismo.dtInformeCateterismo)
        dgvResultados.DataSource = objCateterismo.dtInformeCateterismo
    End Sub
    Private Sub comboPuncion_SelectedValueChanged(sender As Object, e As EventArgs) Handles comboPuncion.SelectedValueChanged
        If comboPuncion.SelectedIndex > 0 Then
            objCateterismo.codigoProcedimiento = objCateterismo.codigoExamen
            objCateterismo.tipoPuncion = comboPuncion.SelectedValue
            cargarItemsInforme()
        Else
            objCateterismo.dtInformeCateterismo.Clear()
        End If
        txtcomentarioHemo.Clear()
    End Sub
#End Region
#Region "Botones"
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        '   If SesionActual.tienePermiso(Peditar) Then
        If objCateterismo.modulo <> Constantes.HC Then
            If buscarResponsable() = False Then
                Exit Sub
            End If
        End If
        General.deshabilitarBotones(ToolStrip1)
        btguardar.Enabled = True
        btcancelar.Enabled = True
        habilitarControles()
        'Else
        '    MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        'End If
    End Sub
    Private Function buscarResponsable() As Boolean
        Dim auxBandera As Boolean
        Dim tbl As DataRow = Nothing
        Dim params As New List(Of String)
        params.Add(Constantes.LISTA_CARGO_ORDEN_MEDICA)
        params.Add(SesionActual.idEmpresa)
        Dim formBusqueda As Form_BusquedaGeneral =
            General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC,
                                   params,
                                   TitulosForm.BUSQUEDA_EMPLEADO_HC,
                                   True,,
                                   True)
        tbl = formBusqueda.rowResultados
        If tbl IsNot Nothing Then
            objCateterismo.usuarioReal = tbl(0)
            TextNombreUsuario.Text = tbl(1)
            auxBandera = True
        Else
            MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
        End If
        Return auxBandera
    End Function
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
        txtcomentarioHemo.Clear()
    End Sub
    Private Sub RadioFallida_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioFallida.CheckedChanged
        If RadioFallida.Checked = True Then
            objCateterismo.titulo = Constantes.NOMBRE_ANGIOPLASTIA_FALLIDA
        Else
            objCateterismo.titulo = Constantes.NOMBRE_ANGIOPLASTIA_STENT
        End If
    End Sub
#End Region
End Class