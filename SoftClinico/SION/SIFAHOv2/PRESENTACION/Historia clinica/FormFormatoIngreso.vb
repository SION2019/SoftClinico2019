Imports System.Threading
Public Class FormFormatoIngreso
    Dim servicioNeonatal As Boolean
    Dim objFormato As FormatoIngreso
    Dim codigo As String = String.Empty
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    'Private Sub desHabilitarDgview()
    '    dgvImpresion.ReadOnly = True
    '    dgvImpresionN.ReadOnly = True
    '    dgvParaclinico.ReadOnly = True
    '    dgvMedicamento.ReadOnly = True
    '    dgvDiagPrincipal.ReadOnly = True
    'End Sub
    Private Sub comboMedicamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbServicio.SelectedIndexChanged
        If cbServicio.SelectedIndex <> 0 Then
            panelControl.Visible = True
            servicioNeonatal = If(cbServicio.SelectedIndex = Constantes.VALOR_PREDETERMINADO,
                                   False, cbServicio.DataSource.rows(cbServicio.SelectedIndex).item("Neonatal"))
            verificarYCargarOpcDefecto()
        Else
            panelControl.Visible = False
        End If
    End Sub
    Private Sub verificarYCargarOpcDefecto()
        If servicioNeonatal = False Then
            contenedor.Panel1Collapsed = False
            contenedor.Panel2Collapsed = True
        Else
            contenedor.Panel2Collapsed = False
            contenedor.Panel1Collapsed = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGenero.SelectedIndexChanged
        If cbGenero.SelectedIndex <> 0 Then
            If cbGenero.SelectedValue = 0 Then
                antecedentegineco.Enabled = False
            Else
                antecedentegineco.Enabled = True ''si es femenino
            End If
        End If
    End Sub

    Private Sub Form_Formato_Ingreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            objFormato = New FormatoIngreso
            panelControl.Visible = False
            General.cargarCombo(Consultas.SEXO_LISTAR, "Descripción genero", "Código", cbGenero)
            General.cargarCombo(Consultas.BUSQUEDA_AREA_SERVICIO_FORMATO & "" & SesionActual.codigoEP, "Descripcion", "Codigo", cbServicio)
            validarDgv(dgvImpresion, objFormato.dtDiagImpresion)
            validarDgv(dgvImpresionN, objFormato.dtDiagImpresion)
            validarDgv(dgvDiagPrincipal, objFormato.dtDiagPrincipales)
            validarDgv(dgvMedicamento, objFormato.dtMedicamento)
            validarDgv(dgvParaclinico, objFormato.dtParaclinico)
            General.deshabilitarControles(Me)
            General.deshabilitarBotones(ToolStrip1)
            btnuevo.Enabled = True
            btbuscar.Enabled = True
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        General.deshabilitarBotones(ToolStrip1)
        General.limpiarControles(Me)
        General.habilitarControles(Me)
        codigo = String.Empty
        dgvDiagPrincipal.ReadOnly = True
        hablitarColumna(dgvImpresion)
        hablitarColumna(dgvImpresionN)
        hablitarColumna(dgvMedicamento)
        hablitarColumna(dgvParaclinico)
        objFormato.dtDiagImpresion.Rows.Add()
        objFormato.dtDiagPrincipales.Rows.Add()
        objFormato.dtParaclinico.Rows.Add()
        objFormato.dtMedicamento.Rows.Add()
        btguardar.Enabled = True
        btcancelar.Enabled = True
    End Sub

    Private Sub dgvImpresionN_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvImpresionN.CellDoubleClick
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        If (dgvImpresionN.Rows(dgvImpresionN.CurrentCell.RowIndex).Cells("Código").Selected = True Or dgvImpresionN.Rows(dgvImpresionN.CurrentCell.RowIndex).Cells("Descripción").Selected = True) And
            objFormato.dtDiagImpresion.Rows(dgvImpresionN.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            General.agregarDiagnosticosCIE(dgvImpresionN, objFormato.dtDiagImpresion)
        ElseIf dgvImpresionN.Rows(dgvImpresionN.CurrentCell.RowIndex).Cells("anulardiagevoN").Selected = True And objFormato.dtDiagImpresion.Rows(dgvImpresionN.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            If objFormato.dtDiagImpresion.Rows(dgvImpresionN.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_NUEVO Then
                objFormato.dtDiagImpresion.Rows.RemoveAt(e.RowIndex)
            ElseIf objFormato.dtDiagImpresion.Rows(dgvImpresionN.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_CARGADO Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    objFormato.dtDiagImpresion.Rows.RemoveAt(dgvImpresionN.CurrentCell.RowIndex)
                End If
            End If
        End If
    End Sub

    Private Sub dgvImpresion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvImpresion.CellDoubleClick
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        If (dgvImpresion.Rows(dgvImpresion.CurrentCell.RowIndex).Cells("Código").Selected = True Or dgvImpresion.Rows(dgvImpresion.CurrentCell.RowIndex).Cells("Descripción").Selected = True) And
            objFormato.dtDiagImpresion.Rows(dgvImpresion.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            General.agregarDiagnosticosCIE(dgvImpresion, objFormato.dtDiagImpresion)
        ElseIf dgvImpresion.Rows(dgvImpresion.CurrentCell.RowIndex).Cells("anulardiagevoA").Selected = True And objFormato.dtDiagImpresion.Rows(dgvImpresion.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            If objFormato.dtDiagImpresion.Rows(dgvImpresion.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_NUEVO Then
                objFormato.dtDiagImpresion.Rows.RemoveAt(e.RowIndex)
            ElseIf objFormato.dtDiagImpresion.Rows(dgvImpresion.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_CARGADO Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    objFormato.dtDiagImpresion.Rows.RemoveAt(dgvImpresion.CurrentCell.RowIndex)
                End If
            End If
        End If
    End Sub

    Private Sub validarDgv(ByVal dgview As DataGridView, dtTable As DataTable)
        Dim posicion As Integer
        posicion = dtTable.Columns.Count

        Try
            With dgview
                .DataSource = dtTable
                .AutoGenerateColumns = False
                .Columns(0).DisplayIndex = posicion
                .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("Estado").Visible = False
            End With
        Catch ex As Exception
            Throw
        End Try

    End Sub
    Private Sub hablitarColumna(ByVal dgview As DataGridView)
        With dgview
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True
            .Columns(3).ReadOnly = False
        End With
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.Yes Then
            General.deshabilitarBotones(ToolStrip1)
            codigo = String.Empty
            General.limpiarControles(Me)
            General.deshabilitarControles(Me)
            btnuevo.Enabled = True
            btbuscar.Enabled = True
        End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If objFormato.dtDiagPrincipales.Rows.Count - 1 = 0 Then
            MsgBox("¡ Favor seleccionar un diagnostico principal !", MsgBoxStyle.Exclamation)
            dgvDiagPrincipal.Focus()
        ElseIf servicioNeonatal = 1 And IsDate(txtFumN.Text) Then
            MsgBox("¡ Favor Digitar una fecha valida !", MsgBoxStyle.Exclamation)
            txtFumN.Focus()
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Try
                    cargarObjeto()

                    dgvImpresion.EndEdit()
                    dgvImpresionN.EndEdit()
                    dgvMedicamento.EndEdit()
                    dgvParaclinico.EndEdit()

                    FormatoIngresoBLL.guardarFormatoIngreso(objFormato)
                    General.habilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    codigo = objFormato.codigo
                    btguardar.Enabled = False
                    btcancelar.Enabled = False
                    cargarDiagnosticoPrincipal(codigo)
                    cargarDiagnosticoImpresion(codigo)
                    cargarParaclinico(codigo)
                    cargarMedicamento(codigo)
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub

    Private Sub dgvDiagPrincipal_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDiagPrincipal.CellDoubleClick
        If btguardar.Enabled = False _
            OrElse cbServicio.SelectedIndex = 0 Then
            Exit Sub
        End If
        If (dgvDiagPrincipal.Rows(dgvDiagPrincipal.CurrentCell.RowIndex).Cells("Código").Selected = True Or dgvDiagPrincipal.Rows(dgvDiagPrincipal.CurrentCell.RowIndex).Cells("Descripción").Selected = True) And
            objFormato.dtDiagPrincipales.Rows(dgvDiagPrincipal.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            General.agregarDiagnosticosFormatoIngreso(dgvDiagPrincipal,
                                                      objFormato.dtDiagPrincipales,
                                                      cbServicio.SelectedValue,
                                                      cbGenero.SelectedValue)
        ElseIf dgvDiagPrincipal.Rows(dgvDiagPrincipal.CurrentCell.RowIndex).Cells("dgquitardiag").Selected = True And objFormato.dtDiagPrincipales.Rows(dgvDiagPrincipal.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            If objFormato.dtDiagPrincipales.Rows(dgvDiagPrincipal.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_NUEVO Then
                objFormato.dtDiagPrincipales.Rows.RemoveAt(e.RowIndex)
            ElseIf objFormato.dtDiagPrincipales.Rows(dgvDiagPrincipal.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_CARGADO Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    objFormato.dtDiagPrincipales.Rows.RemoveAt(dgvDiagPrincipal.CurrentCell.RowIndex)
                End If
            End If
        End If
    End Sub
    Private Sub cargarObjeto()
        objFormato.anamnesis = If(servicioNeonatal = True, txtAnamnesisN.Text, txtAnamnesis.Text)
        objFormato.medico = txtAnteM.Text
        objFormato.quirurgico = txtAnteQ.Text
        objFormato.traumatico = txtAnteT.Text
        objFormato.transfuncionales = txtAnteTr.Text
        objFormato.alergico = txtAnteA.Text
        objFormato.toxico = txtAnteTo.Text
        objFormato.antFamiliares = txtAnteF.Text
        objFormato.revisionSistema = txtRevision.Text
        objFormato.signoVitales = If(servicioNeonatal = True, txtSig_vitalesN.Text, txtInfoSigV.Text)
        objFormato.cabezaCuello = If(servicioNeonatal = True, txtCab_cuelloN.Text, txtInfoCabCu.Text)
        objFormato.torax = If(servicioNeonatal = True, txtToraxN.Text, txtInfoTorax.Text)
        objFormato.cardioPulmonar = If(servicioNeonatal = True, txtCardioN.Text, txtInfoCardio.Text)
        objFormato.abdomen = If(servicioNeonatal = True, txtAbdomenN.Text, txtInfoAbdomen.Text)
        objFormato.gestionUrinaria = If(servicioNeonatal = True, txtGenitoN.Text, txtInfoGenito.Text)
        objFormato.extremidades = If(servicioNeonatal = True, txtExtremidadesN.Text, txtInfoExtrem.Text)
        objFormato.nervioCentral = If(servicioNeonatal = True, txtS_NervN.Text, txtInfoSNerv.Text)
        objFormato.paraclinico = txtInfoParaclinico.Text
        objFormato.analisis = If(servicioNeonatal = True, txtAnalisisN.Text, txtInfoAnalisis.Text)
        objFormato.pronostico = If(servicioNeonatal = True, txtPronosticoN.Text, txtInfoPronos.Text)
        objFormato.tipoParto = txtTipoParto.Text
        objFormato.rubtura = txtTRupturaM.Text
        objFormato.inducionParto = txtInduccionP.Text
        objFormato.apgar1 = txtApgar1N.Text
        objFormato.apgar5 = txtApgar2.Text
        objFormato.reanimacionNacer = txtRmacionN.Text
        objFormato.edadMadre = txtEdadMadreN.Text
        objFormato.edadGestacional = txtEdadGestN.Text
        objFormato.fum = txtFumN.Text
        objFormato.obstetrico = txtObstetricosN.Text
        objFormato.hemograsificacionMadre = txtHemMN.Text
        objFormato.hemograsificacionPadre = txtHemPN.Text
        objFormato.controlPrenatal = txtControlPN.Text
        objFormato.medDuranteEmbarazo = txtMedDurEmbN.Text
        objFormato.habitos = txtHabitosN.Text
        objFormato.infeccionEmb = txtInfeccionesN.Text
        objFormato.diabGestional = txtDiabeteGN.Text
        objFormato.diabMellitud = txtDiabeteMN.Text
        objFormato.hiperGestional = txtHiperGN.Text
        objFormato.preclampcia = txtPreeclampciaN.Text
        objFormato.vacunacion = txtVacunacionN.Text
        objFormato.tiroidea = txtEnferTN.Text
        objFormato.torch = txtTorch.Text
        objFormato.hemogracificacionNcido = txtHemoclasificacionN.Text
        objFormato.VDRL = txtVDRLN.Text
        objFormato.TSH = txtTSHN.Text
        objFormato.glucometria = txtGlucometriasN.Text
        objFormato.generales = txtGeneralesN.Text
        objFormato.caracteristicaLiquido = txtCaractLiquidoN.Text
        objFormato.codigoArea = cbServicio.SelectedValue
        objFormato.codigoGenero = cbGenero.SelectedValue
        objFormato.codigo = codigo
        objFormato.usuario = SesionActual.idUsuario
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
            General.deshabilitarBotones(ToolStrip1)
            General.habilitarControles(Me)
            objFormato.dtDiagImpresion.Rows.Add()
            objFormato.dtDiagPrincipales.Rows.Add()
            objFormato.dtParaclinico.Rows.Add()
            objFormato.dtMedicamento.Rows.Add()
            btguardar.Enabled = True
            btcancelar.Enabled = True
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click

        General.buscarItem(objFormato.sqlBuscarRegistro,
                               Nothing,
                               AddressOf cargarFormatoIngreso,
                               TitulosForm.BUSQUEDA_FORMATO_INGRESO,
                               True)
    End Sub
    Private Sub cargarFormatoIngreso(dContenido As DataRow)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        codigo = dContenido.Item(0)
        params.Add(codigo)
        Try
            dFila = General.cargarItem(objFormato.sqlCargarRegistro, params)
            txtAnamnesisN.Text = dFila.Item("Anamnesis")
            txtAnamnesis.Text = dFila.Item("Anamnesis")
            txtAnteM.Text = dFila.Item("Medico")
            txtAnteQ.Text = dFila.Item("Quirurgico")
            txtAnteT.Text = dFila.Item("Traumatico")
            txtAnteTr.Text = dFila.Item("Transfucionales")
            txtAnteA.Text = dFila.Item("Alergico")
            txtAnteTo.Text = dFila.Item("Toxico")
            txtAnteF.Text = dFila.Item("Ant_Familiares")
            txtRevision.Text = dFila.Item("Revision_Sistema")
            txtSig_vitalesN.Text = dFila.Item("Signo_Vitales")
            txtInfoSigV.Text = dFila.Item("Signo_Vitales")
            txtCab_cuelloN.Text = dFila.Item("Cabeza_Cuello")
            txtInfoCabCu.Text = dFila.Item("Cabeza_Cuello")
            txtToraxN.Text = dFila.Item("Torax")
            txtInfoTorax.Text = dFila.Item("Torax")
            txtCardioN.Text = dFila.Item("Cardio_Pulmonar")
            txtInfoCardio.Text = dFila.Item("Cardio_Pulmonar")
            txtAbdomenN.Text = dFila.Item("Abdomen")
            txtInfoAbdomen.Text = dFila.Item("Abdomen")
            txtGenitoN.Text = dFila.Item("Gestion_Urinaria")
            txtInfoGenito.Text = dFila.Item("Gestion_Urinaria")
            txtExtremidadesN.Text = dFila.Item("Extremidades")
            txtInfoExtrem.Text = dFila.Item("Extremidades")
            txtS_NervN.Text = dFila.Item("Nervio_Central")
            txtInfoSNerv.Text = dFila.Item("Nervio_Central")
            txtInfoParaclinico.Text = dFila.Item("Paraclinico")
            txtAnalisisN.Text = dFila.Item("Analisis").ToString
            txtInfoAnalisis.Text = dFila.Item("Analisis")
            txtPronosticoN.Text = dFila.Item("Pronostico")
            txtInfoPronos.Text = dFila.Item("Pronostico")
            txtTipoParto.Text = dFila.Item("Tipo_Parto")
            txtTRupturaM.Text = dFila.Item("Ruptura_Memb")
            txtInduccionP.Text = dFila.Item("Induccion_Parto")
            txtApgar1N.Text = dFila.Item("Apgar1")
            txtApgar2.Text = dFila.Item("Apgar5")
            txtRmacionN.Text = dFila.Item("Reanimacion_Nacer")
            txtEdadMadreN.Text = dFila.Item("Edad_Madre")
            txtEdadGestN.Text = dFila.Item("Edad_Gestacional")
            txtFumN.Text = dFila.Item("Fum")
            txtObstetricosN.Text = dFila.Item("Obstetrico")
            txtHemMN.Text = dFila.Item("Hemo_Madre")
            txtHemPN.Text = dFila.Item("Hemo_Padre")
            txtControlPN.Text = dFila.Item("Control_Prenatal")
            txtMedDurEmbN.Text = dFila.Item("Med_Durante_Emb")
            txtHabitosN.Text = dFila.Item("Habitos")
            txtInfeccionesN.Text = dFila.Item("Infecciones_Emb")
            txtDiabeteGN.Text = dFila.Item("Diab_Gestional")
            txtDiabeteMN.Text = dFila.Item("Diab_Mellitud")
            txtHiperGN.Text = dFila.Item("Hiper_Gestional")
            txtPreeclampciaN.Text = dFila.Item("Preclampcia")
            txtVacunacionN.Text = dFila.Item("Vacunacion")
            txtEnferTN.Text = dFila.Item("Tiroidea")
            txtTorch.Text = dFila.Item("Torch")
            txtHemoclasificacionN.Text = dFila.Item("Hemo_Menor")
            txtVDRLN.Text = dFila.Item("VDRL")
            txtTSHN.Text = dFila.Item("TSH")
            txtGlucometriasN.Text = dFila.Item("Glucometria")
            txtGeneralesN.Text = dFila.Item("Generales")
            txtCaractLiquidoN.Text = dFila.Item("Caract_Liquido")
            cbServicio.SelectedValue = If(IsDBNull(dFila.Item("Codigo_Servicio")), String.Empty, dFila.Item("Codigo_Servicio"))
            cbGenero.SelectedValue = If(IsDBNull(dFila.Item("Codigo_Genero")), String.Empty, dFila.Item("Codigo_Genero"))
            cargarDiagnosticoPrincipal(codigo)
            cargarDiagnosticoImpresion(codigo)
            cargarParaclinico(codigo)
            cargarMedicamento(codigo)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
    End Sub
    Private Sub cargarDiagnosticoPrincipal(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(objFormato.sqlCargarDiagnoticoPrincipal, params, objFormato.dtDiagPrincipales)
        dgvDiagPrincipal.DataSource = objFormato.dtDiagPrincipales
        dgvDiagPrincipal.AutoGenerateColumns = False
    End Sub
    Private Sub cargarDiagnosticoImpresion(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(objFormato.sqlCargarDiagnoticoImpresion, params, objFormato.dtDiagImpresion)
        dgvImpresion.DataSource = objFormato.dtDiagImpresion
        dgvImpresion.AutoGenerateColumns = False
    End Sub
    Private Sub cargarParaclinico(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(objFormato.sqlCargarParaclinicos, params, objFormato.dtParaclinico)
        dgvParaclinico.DataSource = objFormato.dtParaclinico
        dgvParaclinico.AutoGenerateColumns = False
    End Sub
    Private Sub cargarMedicamento(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(objFormato.sqlCargarMedicamentos, params, objFormato.dtMedicamento)
        dgvMedicamento.DataSource = objFormato.dtMedicamento
        dgvMedicamento.AutoGenerateColumns = False
    End Sub
    Private Sub dgvParaclinico_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvParaclinico.CellDoubleClick
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        If (dgvParaclinico.Rows(dgvParaclinico.CurrentCell.RowIndex).Cells("Codigo").Selected = True Or dgvParaclinico.Rows(dgvParaclinico.CurrentCell.RowIndex).Cells("Procedimiento").Selected = True) And
            objFormato.dtParaclinico.Rows(dgvParaclinico.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            General.agregarItems(Consultas.LISTA_PROCEDIMIENTOS_CUPS & Constantes.VALOR_PREDETERMINADO & ConstantesHC.NOMBRE_PDF_SEPARADOR3, TitulosForm.BUSQUEDA_PROCEDIMIENTOS_CUPS, dgvParaclinico, objFormato.dtParaclinico)
        ElseIf dgvParaclinico.Rows(dgvParaclinico.CurrentCell.RowIndex).Cells("dgAnularPara").Selected = True And objFormato.dtParaclinico.Rows(dgvParaclinico.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            If objFormato.dtParaclinico.Rows(dgvParaclinico.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_NUEVO Then
                objFormato.dtParaclinico.Rows.RemoveAt(e.RowIndex)
            ElseIf objFormato.dtParaclinico.Rows(dgvParaclinico.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_CARGADO Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    objFormato.dtParaclinico.Rows.RemoveAt(dgvParaclinico.CurrentCell.RowIndex)
                End If
            End If
        End If
    End Sub

    Private Sub dgvMedicamento_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMedicamento.CellDoubleClick
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        If (dgvMedicamento.Rows(dgvMedicamento.CurrentCell.RowIndex).Cells("Codigo").Selected = True Or
            dgvMedicamento.Rows(dgvMedicamento.CurrentCell.RowIndex).Cells("Medicamento").Selected = True) And
            objFormato.dtMedicamento.Rows(dgvMedicamento.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            General.agregarItemsFormatIngreso(Consultas.BUSQUEDA_MEDICAMENTO & "-1" & ConstantesHC.NOMBRE_PDF_SEPARADOR3 &
                                              Constantes.LINEA_MEDICAMENTO &
                                              ConstantesHC.NOMBRE_PDF_SEPARADOR3,
                                              TitulosForm.BUSQUEDA_MEDICAMENTO,
                                              dgvMedicamento,
                                              objFormato.dtMedicamento)
        ElseIf dgvMedicamento.Rows(dgvMedicamento.CurrentCell.RowIndex).Cells("dgAnularMed").Selected = True _
            And objFormato.dtMedicamento.Rows(dgvMedicamento.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            If objFormato.dtMedicamento.Rows(dgvMedicamento.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_NUEVO Then
                objFormato.dtMedicamento.Rows.RemoveAt(e.RowIndex)
            ElseIf objFormato.dtMedicamento.Rows(dgvMedicamento.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_CARGADO Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    objFormato.dtMedicamento.Rows.RemoveAt(dgvMedicamento.CurrentCell.RowIndex)
                End If
            End If
        End If
    End Sub

    Private Sub FormFormatoIngreso_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Try
                If General.anularRegistro(Consultas.FORMATO_INGRESO_ANULAR &
                                           codigo &
                                           ConstantesHC.NOMBRE_PDF_SEPARADOR3 &
                                           objFormato.usuario) = True Then
                    General.deshabilitarBotones(ToolStrip1)
                    General.limpiarControles(Me)
                    General.deshabilitarControles(Me)
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                Else
                    MsgBox(Mensajes.NO_ANULAR_DESTINO, MsgBoxStyle.Information)
                End If
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
End Class