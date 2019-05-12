Public Class FormParto
    Dim objParto As New PartoRecienNacido
    Dim vFormPadre As Form_Historia_clinica
    Dim modulo As String
    Dim reporte As New ftp_reportes
    Private Sub FormParto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.deshabilitarControles(gbDatos)
        General.deshabilitarControles(gbInformacion)
        General.cargarCombo(Consultas.SEXO_LISTAR, "Descripción genero", "Código", cbSexo)
    End Sub

    Private Sub cargarInfoIngreso(pCodigo As String)
        Try
            objParto.nRegistro = pCodigo
            txtRegistro.Text = objParto.nRegistro
            objParto.cargarDetalle()
            objParto.codigoEP = SesionActual.codigoEP
            cargarDatosInfoIngresoNeonato()
            txtVIH.Clear()

            If Not SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
                objParto.usuarioReal = SesionActual.idUsuario
            End If
            cargarDiagnosticosImpresion()
            cargarAntecedentesMadre()
            General.deshabilitarControles(gbInformacion)
            General.deshabilitarControles(gbDatos)
            General.deshabilitarBotones(ToolStrip1)
            btnuevo.Enabled = True
            btbuscar.Enabled = True
            btanular.Enabled = True
            bteditar.Enabled = True
            btimprimir.Enabled=True
        Catch ex As Exception
            MsgBox("No se encontraron datos.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atención")
        End Try
    End Sub
    Private Sub cargarAntecedentesMadre()
        Dim objPartoTemporal As PartoRecienNacido
        objPartoTemporal = GeneralHC.fabricaHC.crear(ConstantesHC.IDENTIFICADOR_INFO_INGRESO_PARTO & modulo)
        objPartoTemporal.nRegistro = objParto.nRegistroPadre
        objPartoTemporal.cargarDetalle()
        cargarDatosInfoIngresoMadre(objPartoTemporal)
    End Sub
    Private Sub cargarDatosInfoIngresoMadre(pObjParto As PartoRecienNacido)
        If IsNothing(pObjParto.vih) Then Exit Sub
        txtVIH.Text = pObjParto.vih
        txtEdadGestN.Text = pObjParto.edadGestacional
        txtFumN.Text = pObjParto.fumador
        txtObstetricosN.Text = pObjParto.antecedentesObstetricos
        txtHemMN.Text = pObjParto.hemoclasificacionMadre
        txtHemPN.Text = pObjParto.hemoclasificacionPadre
        txtControlPN.Text = pObjParto.control
        txtMedDurEmbN.Text = pObjParto.medicamentos
        txtHabitosN.Text = pObjParto.habito
        txtInfeccionesN.Text = pObjParto.infeccion
        txtDiabeteGN.Text = pObjParto.diabeteG
        txtDiabeteMN.Text = pObjParto.diabeteM
        txtHiperGN.Text = pObjParto.hipertencion
        txtPreeclampciaN.Text = pObjParto.preclampcia
        txtEnferTN.Text = pObjParto.enfermedad
        txtVacunacionN.Text = pObjParto.vacunacion
        txtTorch.Text = pObjParto.torch
    End Sub

    Private Sub cargarDiagnosticosImpresion()
        objParto.cargarDetalleImpresion()

        dgvImpresionN.DataSource = objParto.dtDiagImpresion
        dgvImpresionN.Columns("Estado").Visible = False
            dgvImpresionN.Columns("Observacion").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            dgvImpresionN.Columns("Observacion").Width = 250
            dgvImpresionN.Columns("Observacion").HeaderText = "Observación"
            dgvImpresionN.Columns("anulardiagevoN").DisplayIndex = 4
            dgvImpresionN.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvImpresionN.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        For i = 0 To dgvImpresionN.ColumnCount - 1
            dgvImpresionN.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        For I = 0 To objParto.dtDiagImpresion.Rows.Count - 1
            objParto.dtDiagImpresion.Rows(I).Item("Estado") = Constantes.ITEM_CARGADO
        Next
    End Sub
    Private Sub cargarDatosInfoIngresoNeonato()
        If objParto.nRegistro = Constantes.VALOR_PREDETERMINADO Then Exit Sub
        dateFechaParto.Value = objParto.fechaParto
        cbSexo.SelectedValue = objParto.sexo
        txtNombre.Text = objParto.nombre
        txtPeso.Text = objParto.peso
        txtAnamnesisN.Text = objParto.motivo
        txtTipoParto.Text = objParto.tParto
        txtTRupturaM.Text = objParto.tRupturaM
        txtInduccionP.Text = objParto.induccionParto
        txtCaractLiquidoN.Text = objParto.caracteristicasLiquidas
        txtApgar1N.Text = objParto.apgar1
        txtApgar2.Text = objParto.apgar5
        txtRmacionN.Text = objParto.reanimacion
        txtVIH.Text = objParto.vih
        txtEdadGestN.Text = objParto.edadGestacional
        txtFumN.Text = objParto.fumador
        txtObstetricosN.Text = objParto.antecedentesObstetricos
        txtHemMN.Text = objParto.hemoclasificacionMadre
        txtHemPN.Text = objParto.hemoclasificacionPadre
        txtControlPN.Text = objParto.control
        txtMedDurEmbN.Text = objParto.medicamentos
        txtHabitosN.Text = objParto.habito
        txtInfeccionesN.Text = objParto.infeccion
        txtDiabeteGN.Text = objParto.diabeteG
        txtDiabeteMN.Text = objParto.diabeteM
        txtHiperGN.Text = objParto.hipertencion
        txtPreeclampciaN.Text = objParto.preclampcia
        txtEnferTN.Text = objParto.enfermedad
        txtVacunacionN.Text = objParto.vacunacion
        txtTorch.Text = objParto.torch
        txtHemoclasificacionN.Text = objParto.hemoclasificacion
        txtVDRLN.Text = objParto.vdrl
        txtTSHN.Text = objParto.tsh
        txtGlucometriasN.Text = objParto.glucometria
        txtGeneralesN.Text = objParto.generales
        txtSig_vitalesN.Text = objParto.signosVitales
        txtCab_cuelloN.Text = objParto.cabezaYCuello
        txtToraxN.Text = objParto.torax
        txtCardioN.Text = objParto.cardio
        txtAbdomenN.Text = objParto.abdomen
        txtGenitoN.Text = objParto.gentoUrinario
        txtExtremidadesN.Text = objParto.extremidades
        txtS_NervN.Text = objParto.sistemaNervioso
        txtAnalisisN.Text = objParto.analisis
        txtPronosticoN.Text = objParto.pronostico
        txtNombreUsuarioINFN.Text = objParto.usuarioCreacion
        txtNombreUsuarioINFN.ReadOnly = True
    End Sub
    Public Sub iniciarDatos(ByRef form_Historia_clinica As Form_Historia_clinica, pModulo As String)
        vFormPadre = form_Historia_clinica
        objParto = GeneralHC.fabricaHC.crear(ConstantesHC.IDENTIFICADOR_INFO_INGRESO_PARTO & pModulo)
        Me.modulo = pModulo
        txtHC.Text = vFormPadre.txtHC.Text
        objParto.nRegistroPadre = vFormPadre.txtRegistro.Text
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        habilitarCampos()
    End Sub
    Private Sub habilitarCampos()
        objParto.dtDiagImpresion.Rows.Add()

        General.habilitarControles(gbDatos)
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(gbInformacion)
        General.deshabilitarControles(GroupBox24)
        txtPeso.ReadOnly = False
        txtNombre.ReadOnly = False
        cbSexo.Enabled = True
        btguardar.Enabled = True
        btcancelar.Enabled = True
        dateFechaParto.Enabled = True
        dgvImpresionN.ReadOnly = True
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Dim params As New List(Of String)
        params.Add(Nothing)
        params.Add(objParto.nRegistroPadre)
        General.buscarElemento(ConsultasHC.BUSQUEDA_ADMISION_PARTO,
                                   params,
                                   AddressOf cargarInfoIngreso,
                                   TitulosForm.BUSQUEDA_ADMISION,
                                   False, 0, True)

    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        txtJustificacionN_Leave(sender, e)
        Try
            guardarInfoIngreso()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Private Sub guardarInfoIngreso()
        If txtNombre.Text = "" Then
            MsgBox("Por favor digite el nombre del recién nacido.", MsgBoxStyle.Exclamation)
            txtNombre.Focus()
        ElseIf cbSexo.SelectedIndex < 1 Then
            MsgBox("Por favor seleccione el sexo del recién nacido.", MsgBoxStyle.Exclamation)
            cbSexo.Focus()
        ElseIf txtPeso.Text = "" OrElse CDbl(txtPeso.Text) <= Constantes.PESO_GRAMO_MINIMO Then
            MsgBox("Por favor digite el peso del recién nacido.", MsgBoxStyle.Exclamation)
            txtPeso.Focus()
        ElseIf txtAnamnesisN.Text = "" Then
            MsgBox("Por favor digite la anamnesis del recién nacido.", MsgBoxStyle.Exclamation)
            txtAnamnesisN.Focus()
        ElseIf dgvImpresionN.RowCount <= 1 Then
            MsgBox("Por favor ingrese impresión diagnóstica del recién nacido.", MsgBoxStyle.Exclamation)
            dgvImpresionN.Focus()
        ElseIf txtTipoParto.Text = "" Then
            MsgBox("Por favor ingrese tipo de parto.", MsgBoxStyle.Exclamation)
            txtTipoParto.Focus()
        ElseIf txtTRupturaM.Text = "" Then
            MsgBox("Por favor ingrese tipo de ruptura membr.", MsgBoxStyle.Exclamation)
            txtTRupturaM.Focus()
        ElseIf txtInduccionP.Text = "" Then
            MsgBox("Por favor ingrese indución parto.", MsgBoxStyle.Exclamation)
            txtInduccionP.Focus()
        ElseIf txtCaractLiquidoN.Text = "" Then
            MsgBox("Por favor ingrese caracteristicas líquidas.", MsgBoxStyle.Exclamation)
            txtCaractLiquidoN.Focus()
        ElseIf txtApgar1N.Text = "" Then
            MsgBox("Por favor ingrese apgar 1.", MsgBoxStyle.Exclamation)
            txtApgar1N.Focus()
        ElseIf txtApgar2.Text = "" Then
            MsgBox("Por favor ingrese apgar 5.", MsgBoxStyle.Exclamation)
            txtApgar2.Focus()
        ElseIf txtRmacionN.Text = "" Then
            MsgBox("Por favor ingrese r/mación al nacer.", MsgBoxStyle.Exclamation)
            txtRmacionN.Focus()

        ElseIf txtHemoclasificacionN.Text = "" Then
            MsgBox("Por favor ingrese hemoclasificación.", MsgBoxStyle.Exclamation)
            txtHemoclasificacionN.Focus()
        ElseIf txtVDRLN.Text = "" Then
            MsgBox("Por favor ingrese VDRL.", MsgBoxStyle.Exclamation)
            txtVDRLN.Focus()
        ElseIf txtTSHN.Text = "" Then
            MsgBox("Por favor ingrese TSH.", MsgBoxStyle.Exclamation)
            txtTSHN.Focus()
        ElseIf txtGlucometriasN.Text = "" Then
            MsgBox("Por favor ingrese glucometrias.", MsgBoxStyle.Exclamation)
            txtGlucometriasN.Focus()
        ElseIf txtGeneralesN.Text = "" Then
            MsgBox("Por favor ingrese exámenes físicos generales.", MsgBoxStyle.Exclamation)
            txtGeneralesN.Focus()
        ElseIf txtSig_vitalesN.Text = "" Then
            MsgBox("Por favor ingrese signos vitales.", MsgBoxStyle.Exclamation)
            txtSig_vitalesN.Focus()
        ElseIf txtCab_cuelloN.Text = "" Then
            MsgBox("Por favor ingrese cabeza y cuello.", MsgBoxStyle.Exclamation)
            txtCab_cuelloN.Focus()
        ElseIf txtToraxN.Text = "" Then
            MsgBox("Por favor ingrese tórax.", MsgBoxStyle.Exclamation)
            txtToraxN.Focus()
        ElseIf txtCardioN.Text = "" Then
            MsgBox("Por favor ingrese cardio-pulmonar.", MsgBoxStyle.Exclamation)
            txtCardioN.Focus()
        ElseIf txtAbdomenN.Text = "" Then
            MsgBox("Por favor ingrese abdomen.", MsgBoxStyle.Exclamation)
            txtAbdomenN.Focus()
        ElseIf txtGenitoN.Text = "" Then
            MsgBox("Por favor ingrese genito-urinario.", MsgBoxStyle.Exclamation)
            txtGenitoN.Focus()
        ElseIf txtExtremidadesN.Text = "" Then
            MsgBox("Por favor ingrese extremidades.", MsgBoxStyle.Exclamation)
            txtExtremidadesN.Focus()
        ElseIf txtS_NervN.Text = "" Then
            MsgBox("Por favor ingrese S. Nerv. Central.", MsgBoxStyle.Exclamation)
            txtS_NervN.Focus()
        ElseIf txtAnalisisN.Text = "" Then
            MsgBox("Por favor ingrese análisis.", MsgBoxStyle.Exclamation)
            txtAnalisisN.Focus()
        ElseIf txtPronosticoN.Text = "" Then
            MsgBox("Por favor ingrese pronóstico.", MsgBoxStyle.Exclamation)
            txtPronosticoN.Focus()
        ElseIf MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            guardarInfoIngresoAN()
            MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            cargarInfoIngreso(objParto.nRegistro)
        End If
    End Sub
    Private Sub guardarInfoIngresoAN()
        Try
            btimprimir.Enabled = False
            objParto.usuario = SesionActual.idUsuario
            objParto.codigoEP = SesionActual.codigoEP
            precargarDatosInfoIngresoNeonato()
            objParto.guardarDetalle()
            txtRegistro.Text = objParto.nRegistro
        Catch ex As Exception
            Throw ex
        End Try
        btimprimir.Enabled = True
    End Sub
    Private Sub precargarDatosInfoIngresoNeonato()
        objParto.peso = txtPeso.Text
        objParto.nombre = txtNombre.Text
        objParto.sexo = cbSexo.SelectedValue
        objParto.fechaParto = dateFechaParto.Value
        objParto.motivo = txtAnamnesisN.Text
        objParto.tParto = txtTipoParto.Text
        objParto.tRupturaM = txtTRupturaM.Text
        objParto.induccionParto = txtInduccionP.Text
        objParto.caracteristicasLiquidas = txtCaractLiquidoN.Text
        objParto.apgar1 = txtApgar1N.Text
        objParto.apgar5 = txtApgar2.Text
        objParto.reanimacion = txtRmacionN.Text

        objParto.hemoclasificacion = txtHemoclasificacionN.Text
        objParto.vdrl = txtVDRLN.Text
        objParto.tsh = txtTSHN.Text
        objParto.glucometria = txtGlucometriasN.Text
        objParto.generales = txtGeneralesN.Text
        objParto.signosVitales = txtSig_vitalesN.Text
        objParto.cabezaYCuello = txtCab_cuelloN.Text
        objParto.torax = txtToraxN.Text
        objParto.cardio = txtCardioN.Text
        objParto.abdomen = txtAbdomenN.Text
        objParto.gentoUrinario = txtGenitoN.Text
        objParto.extremidades = txtExtremidadesN.Text
        objParto.sistemaNervioso = txtS_NervN.Text
        objParto.analisis = txtAnalisisN.Text
        objParto.pronostico = txtPronosticoN.Text
    End Sub
    Private Sub txtJustificacionN_Leave(sender As Object, e As EventArgs) Handles txtJustificacionN.Leave
        Try
            If PanelJustificacionN.Visible = True Then
                PanelJustificacionN.Visible = False
                dgvImpresionN.Rows(dgvImpresionN.CurrentRow.Index).Cells("Observacion").Value = txtJustificacionN.Text
                txtJustificacionN.Clear()
                objParto.dtDiagImpresion.AcceptChanges()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub dgvn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvImpresionN.KeyPress
        General.abrirJustificacion(dgvImpresionN, objParto.dtDiagImpresion, PanelJustificacionN, txtJustificacionN, "Observacion", Not btguardar.Enabled, e.KeyChar)
    End Sub
    Private Sub dgvImpresionN_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvImpresionN.KeyDown
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 And objParto.dtDiagImpresion.Rows(dgvImpresionN.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            General.agregarDiagnosticosCIE(dgvImpresionN, objParto.dtDiagImpresion)
        End If
    End Sub
    Private Sub dgvImpresionN_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvImpresionN.CellDoubleClick
        General.abrirJustificacion(dgvImpresionN, objParto.dtDiagImpresion, PanelJustificacionN, txtJustificacionN, "Observacion", Not btguardar.Enabled)
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        If (dgvImpresionN.Rows(dgvImpresionN.CurrentCell.RowIndex).Cells("Código").Selected = True Or dgvImpresionN.Rows(dgvImpresionN.CurrentCell.RowIndex).Cells("Descripción").Selected = True) And objParto.dtDiagImpresion.Rows(dgvImpresionN.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            General.agregarDiagnosticosCIE(dgvImpresionN, objParto.dtDiagImpresion)
        ElseIf dgvImpresionN.Rows(dgvImpresionN.CurrentCell.RowIndex).Cells("anulardiagevoN").Selected = True And objParto.dtDiagImpresion.Rows(dgvImpresionN.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            If objParto.dtDiagImpresion.Rows(dgvImpresionN.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_NUEVO Then
                objParto.dtDiagImpresion.Rows.RemoveAt(e.RowIndex)
            ElseIf objParto.dtDiagImpresion.Rows(dgvImpresionN.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_CARGADO Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    objParto.dtDiagImpresion.Rows.RemoveAt(dgvImpresionN.CurrentCell.RowIndex)
                End If
            End If
        End If
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
            Dim tbl As DataRow = Nothing
            Dim params As New List(Of String)
            params.Add(Constantes.LISTA_CARGO_INFO_INGRESO)
            params.Add(SesionActual.idEmpresa)
            Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
            tbl = formBusqueda.rowResultados
            If tbl IsNot Nothing Then
                objParto.usuarioReal = tbl(0)
                txtNombreUsuarioInforme.Text = tbl(1)
            Else
                MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        Else
            objParto.usuarioReal = SesionActual.idUsuario
            txtNombreUsuarioInforme.Text = SesionActual.nombreCompleto

        End If
        objParto.nRegistro = Constantes.VALOR_PREDETERMINADO
        cargarInfoIngreso(objParto.nRegistro)
        habilitarCampos()
        cargarAntecedentesMadre()
        txtHC.Text = vFormPadre.txtHC.Text
    End Sub
    Private Sub Form_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.No Then
            Exit Sub
        End If
        txtJustificacionN.Clear()
        PanelJustificacionN.Visible = False

        cargarInfoIngreso(objParto.nRegistro)
        General.deshabilitarControles(gbDatos)
        General.deshabilitarControles(gbInformacion)
        General.deshabilitarBotones(ToolStrip1)
        bteditar.Enabled = True
        btnuevo.Enabled = True
    End Sub
    Private Sub txtNombreUsuarioInf_MouseDoubleClick(sender As Object, e As EventArgs) Handles txtNombreUsuarioINFN.MouseDoubleClick
        If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) AndAlso btguardar.Enabled = True AndAlso MsgBox("¿Desea cambiar el empleado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            cambiarUsuario(Constantes.LISTA_CARGO_ORDEN_MEDICA, objParto.usuarioReal)
        End If
    End Sub
    Private Sub cambiarUsuario(listaCargo As String, ByRef usuario As Object)
        Dim tbl As DataRow = Nothing
        Dim params As New List(Of String)
        params.Add(listaCargo)
        params.Add(SesionActual.idEmpresa)
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
        tbl = formBusqueda.rowResultados
        If tbl IsNot Nothing Then
            usuario = tbl(0)
            txtNombreUsuarioInforme.Text = tbl(1)
        End If

    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Try
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                objParto.anularParto()
                General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If btguardar.Enabled = True Then
            MsgBox("Por favor guarde la información ", MsgBoxStyle.Information)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try
            Dim ruta, area, nombreArchivo As String
            area = ConstantesHC.NOMBRE_PDF_PARTO
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtRegistro.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            guardarSonda()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub guardarSonda()
        Try

            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_PARTO, txtRegistro.Text, New rptParto,
                                    txtRegistro.Text, "{VISTA_EMBAZARO_Y_PARTO.N_registro} = " & txtRegistro.Text & "",
                                    ConstantesHC.NOMBRE_PDF_PARTO, IO.Path.GetTempPath)

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
End Class