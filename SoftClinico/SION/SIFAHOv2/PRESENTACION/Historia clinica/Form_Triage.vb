Public Class Form_Triage
    Dim objTriage As New Triage
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Peditar, Panular, PConsolidado,
        PRecetario, PCerrarAtencion, PTrasladar, PIngreso, PAntecendetes, PExamenFisico As String
    Public Property listaInformacionPaciente As List(Of String)
    Private Sub Form_Triage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarForm()
    End Sub
#Region "Funciones"
    Function validarFormulario() As Boolean
        Dim dtTemp As New DataTable
        dtTemp.Columns.Add("campo", Type.GetType("System.Object"))
        dtTemp.Columns.Add("mensaje", Type.GetType("System.String"))
        If Combotriage.SelectedValue = 2 Then
            MsgBox("Debe seleccionar el triage!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            Exec.SacudirCrtl(Combotriage)
            Combotriage.Focus()
            Return False
        ElseIf objTriage.tblParametros.Select("Resultado = '' or Resultado is null").Count > 0 Then
            MsgBox("Debe llenar todos los signos vitales!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            dgvParametros.Focus()
            Return False
        End If

        Dim respuestaAnteAdulto As Boolean = False
        Dim respuestaAnteNeo As Boolean = False
        Dim respuestaExamenFisico As Boolean = False

        If Not IsNothing(Antecedentes_Adulto.Parent) Then
            dtTemp.Rows.Add(txtAnteM, "Debe ingresar antecedentes médico")
            dtTemp.Rows.Add(txtAnteQ, "Debe ingresar antecedentes quimicos")
            dtTemp.Rows.Add(txtAnteT, "Debe ingresar antecedentes traumaticos")
            dtTemp.Rows.Add(txtAnteTr, "Debe ingresar antecedentes transfusionales")
            dtTemp.Rows.Add(txtAnteA, "Debe ingresar antecedentes alérgicos")
            dtTemp.Rows.Add(txtAnteTo, "Debe ingresar antecedentes tóxicos")
            dtTemp.Rows.Add(txtAnteF, "Debe ingresar antecedentes familiares")
            respuestaAnteAdulto = Not validarCajaTextos(dtTemp, 1)
        Else
            respuestaAnteAdulto = True
        End If
        If Not IsNothing(Antecedentes_Neo.Parent) Then
            dtTemp.Rows.Add(txtEdadMadreN, "Debe ingresar la edad de la madre !")
            dtTemp.Rows.Add(txtEdadGestN, "Debe ingresar la edad gestacional de la madre !")
            dtTemp.Rows.Add(txtFumN, "Debe ingresar la fecha de la ultima mestruación !")
            dtTemp.Rows.Add(txtObstetricosN, "Debe ingresar antecedentes obstétricos !")
            dtTemp.Rows.Add(txtHemMN, "Debe ingresar antecedentes de hemoclasificación de la  madre !")
            dtTemp.Rows.Add(txtHemPN, "Debe ingresar antecedentes de hemoclasificación del padre !")
            dtTemp.Rows.Add(txtControlPN, "Debe ingresar el control parental !")
            dtTemp.Rows.Add(txtMedDurEmbN, "Debe ingresar la duración del embarazo !")
            dtTemp.Rows.Add(txtHabitosN, "Debe ingresar antecedentes de hábitos !")
            dtTemp.Rows.Add(txtInfeccionesN, "Debe ingresar las infecciones de embarazo !")
            dtTemp.Rows.Add(txtDiabeteGN, "Debe ingresar diabetes gestacional !")
            dtTemp.Rows.Add(txtDiabeteMN, "Debe ingresar diabetes mellitus !")
            dtTemp.Rows.Add(txtHiperGN, "Debe ingresar hipertención gestacional")
            dtTemp.Rows.Add(txtPreeclampciaN, "Debe ingresar preclancia !")
            dtTemp.Rows.Add(txtEnferTN, "Debe ingresar enfermedad tiroidea !")
            dtTemp.Rows.Add(txtVacunacionN, "Debe ingresar antecedente vacunación !")
            dtTemp.Rows.Add(txtTorch, "Debe ingresar antecedente torch !")
            dtTemp.Rows.Add(txtHemoclasificacionN, "Debe ingresar hemoclasificación del recien nacido !")
            dtTemp.Rows.Add(txtVDRLN, "Debe ingresar VDRL !")
            dtTemp.Rows.Add(txtTSHN, "Debe ingresar TSH !")
            dtTemp.Rows.Add(txtGlucometriasN, "Debe ingresar glucometrias !")
            respuestaAnteNeo = Not validarCajaTextos(dtTemp, 1)
        Else
            respuestaAnteNeo = True
        End If
        If Not IsNothing(Examen_Fisico.Parent) AndAlso (respuestaAnteAdulto AndAlso respuestaAnteNeo) Then
            dtTemp.Rows.Add(txtInfoTorax, "Debe ingresar el examen físico Tórax !")
            dtTemp.Rows.Add(txtInfoCabCu, "Debe ingresar el examen físico cabeza y cuello !")
            dtTemp.Rows.Add(txtInfoAbdomen, "Debe ingresar el examen físico abdomen !")
            dtTemp.Rows.Add(txtInfoCardio, "Debe ingresar el examen físico cardio - pulmonar !")
            dtTemp.Rows.Add(txtInfoExtrem, "Debe ingresar el examen físico extremidades !")
            dtTemp.Rows.Add(txtInfoSNerv, "Debe ingresar sistema nervioso central !")
            dtTemp.Rows.Add(txtInfoGenito, "Debe ingresar el genito urinario !")
            respuestaExamenFisico = Not validarCajaTextos(dtTemp, 2)
        Else
            respuestaExamenFisico = True
        End If

        If Not respuestaAnteAdulto OrElse Not respuestaAnteNeo OrElse Not respuestaExamenFisico Then
            Return False
        End If

        Return True
    End Function
    Function validarCajaTextos(ByRef listaTxt As DataTable,
                               ByVal indice As Integer) As Boolean
        For Each item In listaTxt.Rows
            If item("campo").text = "" Then
                tabControles.SelectedIndex = indice
                MsgBox(item("mensaje"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exec.SacudirCrtl(item("campo"))
                item("campo").focus
                Return True
            End If
        Next
        Return False
    End Function
#End Region
#Region "Metodos"
    Sub inicializarForm()
        General.cargarCombo(Consultas.TRIAGE_BUSCAR, "Descripcion", "Codigo_Triage", Combotriage)
        Dim tbl As New DataTable
        tbl = Combotriage.DataSource
        tbl.Rows.RemoveAt(0)
        tbl.Rows.RemoveAt(0)
        objTriage.llenarParametrosSignos()
        mostrarTabPorPermiso()
        configuraciongrilla()
        Combotriage.SelectedValue = objTriage.nivelTriage
        varificarExistenciaTriage()
        General.posLoadForm(Me, ToolStrip1, bteditar, Nothing)
        btnCerrarAtencion.Enabled = True
        btnRecetario.Enabled = True
        verificarTrasladar()
        btnCerrarAtencion.Enabled = puedeCerrarAtencion()
        btnTrasladar.Enabled = puedeTrasladar()
    End Sub
    Function puedeCerrarAtencion() As Boolean
        If objTriage.codigoAreaServicio <> -1 Then
            btnCerrarAtencion.Enabled = False
            Return False
        End If
        Return True
    End Function
    Function puedeTrasladar() As Boolean
        Dim params As New List(Of String)
        params.Add(objTriage.registro)
        Dim filaResultado As DataRow
        filaResultado = General.cargarItem(Consultas.BUSQUEDA_ADMISION_CARGAR, params)

        If Not IsNothing(filaResultado) Then
            If Constantes.ESTADO_ATENCION_INICIADO = filaResultado.Item("Codigo_estado_atencion") Then
                Return True
            End If
        End If
        Return False
    End Function
    Sub colocarparametroEdad()
        For indiceFila = 0 To objTriage.tblParametros.Rows.Count - 1
            If Constantes.PESO_TRIAGE = objTriage.tblParametros.Rows(indiceFila).Item("Codigo") Then
                'objTriage.tblParametros.Rows(indiceFila).Item("Descripcion") = 
            End If
        Next
    End Sub
    Sub verificarTrasladar()
        btnTrasladar.Enabled = False
        If objTriage.codigoTriage <> "" AndAlso Not IsNothing(objTriage.codigoTriage) Then
            btnTrasladar.Enabled = True
        End If
    End Sub
    Function varificarExistenciaTriage() As Boolean
        Dim params As New List(Of String)
        params.Add(objTriage.registro)
        Dim fila As DataRow = General.cargarItem(Consultas.TRIAGE_VERIFICAR_EXISTENCIA, params)
        If Not IsNothing(fila) Then
            objTriage.codigoTriage = fila.Item("Codigo_Triage")
            objTriage.registro = fila.Item("N_registro")
            objTriage.esNeonatal = fila.Item("EsNeonatal")
            objTriage.fecha = fila.Item("Fecha")
            objTriage.codigoAreaServicio = fila.Item("Codigo_Area_Servicio")
            lblAreaServicioTraslado.Text = "Trasladado a: " & fila.Item("Descripcion_Area_Servicio")
            objTriage.descripcionAreaTraslado = fila.Item("Descripcion_Area_Servicio")
            If objTriage.esNeonatal Then
                params.Clear()
                params.Add(objTriage.registro)
                fila = General.cargarItem(Consultas.TRIAGE_CARGAR_DETALLE_INGRE_NEONATAL, params)
                If Not IsNothing(fila) Then
                    objTriage.motivoConsulta = fila.Item("motivo_ingreso")
                    objTriage.edadMadre = fila.Item("edad_madre")
                    objTriage.obstetricos = fila.Item("ant_obstetrico")
                    objTriage.fum = fila.Item("fum")
                    objTriage.edadGestacional = fila.Item("edad_gesta")
                    objTriage.hemM = fila.Item("hemoc_maternal")
                    objTriage.hemP = fila.Item("hemoc_paternal")
                    objTriage.controlPrenatal = fila.Item("control_prenatal")
                    objTriage.medDurantembarazo = fila.Item("medc_durat_embarazo")
                    objTriage.habitos = fila.Item("habito")
                    objTriage.infeccEmb = fila.Item("infecc_embarazo")
                    objTriage.diabGestacional = fila.Item("diabete_gest")
                    objTriage.diabMellitus = fila.Item("diabete_mellitus")
                    objTriage.hiperGestacional = fila.Item("hipertenc_gesta")
                    objTriage.preclancia = fila.Item("preclampcia")
                    objTriage.enfermTiroidea = fila.Item("enferm_tiroidea")
                    objTriage.vacunacion = fila.Item("vacunacion")
                    objTriage.torch = fila.Item("torch")
                    objTriage.hemoclasificacion = fila.Item("hemoclasificacion")
                    objTriage.vdrl = fila.Item("vdrl")
                    objTriage.tsh = fila.Item("tsh")
                    objTriage.glucometria = fila.Item("glucometria")
                    objTriage.cabCue = fila.Item("Cab_Cuello")
                    objTriage.torax = fila.Item("Torax")
                    objTriage.cardioPulmonar = fila.Item("Card_Pulm")
                    objTriage.abdomen = fila.Item("Abdom")
                    objTriage.genitoUrinario = fila.Item("Genturinario")
                    objTriage.extremidades = fila.Item("Extrem")
                    objTriage.sisNervCen = fila.Item("S_Nerv_Central")
                End If
            Else
                params.Clear()
                params.Add(objTriage.registro)
                fila = General.cargarItem(Consultas.TRIAGE_CARGAR_DETALLE_INGRE_ADULTO, params)
                If Not IsNothing(fila) Then
                    objTriage.motivoConsulta = fila.Item("motivo_ingreso")
                    objTriage.medicos = fila.Item("Ant_Medico")
                    objTriage.quirurgicos = fila.Item("Ant_Quirurgico")
                    objTriage.trasnfucionales = fila.Item("Ant_Transfuncionales")
                    objTriage.alergicos = fila.Item("Ant_Alergicos")
                    objTriage.traumaticos = fila.Item("Ant_Traumaticos")
                    objTriage.toxico = fila.Item("Ant_Toxicos")
                    objTriage.anteFamiliares = fila.Item("Ant_Familiares")
                    objTriage.cabCue = fila.Item("Cab_Cuello")
                    objTriage.torax = fila.Item("Torax")
                    objTriage.cardioPulmonar = fila.Item("Card_Pulm")
                    objTriage.abdomen = fila.Item("Abdom")
                    objTriage.genitoUrinario = fila.Item("Genturinario")
                    objTriage.extremidades = fila.Item("Extrem")
                    objTriage.sisNervCen = fila.Item("S_Nerv_Central").ToString
                End If

            End If

            llenarDisenio()
            params.Clear()
            params.Add(objTriage.codigoTriage)
            General.llenarTabla(Consultas.TRIAGE_CARGAR_DETALLE_PARAMETROS, params, objTriage.tblParametros)
            params.Clear()
            params.Add(objTriage.registro)
            General.llenarTabla(Consultas.TRIAGE_CARGAR_DETALLE_DIAGNOSTICOS, params, objTriage.tblDiagnostico)
            Return True
        End If
        Return False
    End Function
    Sub mostrarTabPorPermiso()
        Antecedentes_Adulto.Parent = Nothing
        Antecedentes_Neo.Parent = Nothing
        Examen_Fisico.Parent = Nothing
        Datos_ingreso.Parent = Nothing
        visualizarTab(PIngreso, Datos_ingreso)
        If chkNeonatal.Checked Then
            visualizarTab(PAntecendetes, Antecedentes_Neo)
        Else
            visualizarTab(PAntecendetes, Antecedentes_Adulto)
        End If
        visualizarTab(PExamenFisico, Examen_Fisico)
    End Sub
    Sub visualizarTab(ByVal perminso As String,
                      ByRef tab As TabPage)
        If SesionActual.tienePermiso(perminso) Then
            tab.Parent = tabControles
            tab.Visible = True
        End If
    End Sub
    Sub configuraciongrilla()
        General.diseñoDGV(dgvdiagRem)
        General.diseñoDGV(dgvParametros)
        dgvdiagRem.DataSource = objTriage.tblDiagnostico
        dgvParametros.DataSource = objTriage.tblParametros

        If dgvParametros.RowCount > 0 Then
            dgvParametros.Columns(0).Visible = False
            dgvParametros.Columns(0).ReadOnly = True
            dgvParametros.Columns(1).ReadOnly = True
            dgvParametros.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If
        dgvParametros.MultiSelect = False

        If dgvdiagRem.ColumnCount > 0 Then
            dgvdiagRem.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If
        If Not dgvdiagRem.Columns.Contains("Quitar") Then
            Dim column As New DataGridViewImageColumn
            column.Image = My.Resources.trash_icon1
            column.Name = "Quitar"
            column.HeaderText = "Quitar"
            dgvdiagRem.Columns.Add(column)
        End If
        dgvdiagRem.MultiSelect = False

        deshabilitarOrdenGrilla(dgvdiagRem)
        deshabilitarOrdenGrilla(dgvParametros)
    End Sub
    Sub deshabilitarOrdenGrilla(ByRef dgv As DataGridView)
        For indeceColumna = 0 To dgv.ColumnCount - 1
            dgv.Columns(indeceColumna).SortMode = Windows.Forms.SortOrder.None
        Next
        dgv.AllowUserToOrderColumns = False
    End Sub
    Sub controlesSoloLectura()
        txtRegistro.ReadOnly = True
        txtHC.ReadOnly = True
        txtSexo.ReadOnly = True
        txtEdad.ReadOnly = True
        txtAdmision.ReadOnly = True
        txtNombre.ReadOnly = True
        txtContrato.ReadOnly = True
        txtNombreContrato.ReadOnly = True
        textTraslado.ReadOnly = True
        dgvdiagRem.Columns(0).ReadOnly = True
        dgvdiagRem.Columns(1).ReadOnly = True
        dgvParametros.Columns(1).ReadOnly = True
    End Sub
    Public Sub cargarPermisos(ByVal modulo As String)
        Me.Tag = modulo
        permiso_general = perG.buscarPermisoGeneral(Name, modulo)
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PCerrarAtencion = permiso_general & "pp" & "04"
        PRecetario = permiso_general & "pp" & "05"
        PTrasladar = permiso_general & "pp" & "06"
        PIngreso = permiso_general & "pp" & "07"
        PAntecendetes = permiso_general & "pp" & "08"
        PExamenFisico = permiso_general & "pp" & "09"
    End Sub
    Public Sub datosPrincipales(ByVal params As List(Of String),
                                ByRef form As Form)
        listaInformacionPaciente = params
        objTriage.nivelTriage = params.Item(0)
        objTriage.registro = params.Item(2)
        txtRegistro.Text = params.Item(2)
        txtAdmision.Text = params.Item(2)
        txtHC.Text = params.Item(3)
        txtNombre.Text = params.Item(4)
        txtAdmision.Text = params.Item(5)
        txtContrato.Text = params.Item(7)
        txtNombreContrato.Text = params.Item(8)
        txtSexo.Text = params.Item(9)
        txtEdad.Text = params.Item(10)
    End Sub
    Sub mostrarTab(ByRef tabOcul As TabPage,
                   ByRef tabMos As TabPage)
        tabOcul.Parent = Nothing
        tabMos.Parent = tabControles
        tabMos.Visible = True
        If btguardar.Enabled Then
            General.habilitarControles(tabMos)
        End If
        If tabControles.TabPages.Count > 2 Then
            tabControles.TabPages.Item(0) = Datos_ingreso
            tabControles.TabPages.Item(1) = tabMos
            tabControles.TabPages.Item(2) = Examen_Fisico
        End If
        tabControles.Refresh()
    End Sub
    Private Sub cargarArea(pCodigo As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(SesionActual.codigoEP)
        General.llenarTabla(Consultas.CARGA_AREA_SERVICIO, params, dt)
        objTriage.codigoAreaServicio = pCodigo
        If dt.Rows.Count > 0 Then
            textTraslado.Text = dt.Rows(0).Item("Descripción").ToString()
            btLimpiar.Visible = True
            btLimpiar.Enabled = True
        End If
    End Sub
    Sub llenarObjeto()
        objTriage.esNeonatal = chkNeonatal.Checked
        objTriage.nivelTriage = Combotriage.SelectedValue
        objTriage.registro = txtRegistro.Text
        objTriage.fecha = dtpFecha.Value
        objTriage.motivoConsulta = txtMotivoConsulta.Text
        objTriage.medicos = txtAnteM.Text
        objTriage.quirurgicos = txtAnteQ.Text
        objTriage.traumaticos = txtAnteT.Text
        objTriage.trasnfucionales = txtAnteTr.Text
        objTriage.alergicos = txtAnteA.Text
        objTriage.toxico = txtAnteTo.Text
        objTriage.anteFamiliares = txtAnteF.Text
        objTriage.edadMadre = txtEdadMadreN.Text
        objTriage.edadGestacional = txtEdadGestN.Text
        objTriage.fum = txtFumN.Text
        objTriage.obstetricos = txtObstetricosN.Text
        objTriage.hemM = txtHemMN.Text
        objTriage.hemP = txtHemPN.Text
        objTriage.controlPrenatal = txtControlPN.Text
        objTriage.medDurantembarazo = txtMedDurEmbN.Text
        objTriage.habitos = txtHabitosN.Text
        objTriage.infeccEmb = txtInfeccionesN.Text
        objTriage.diabGestacional = txtDiabeteGN.Text
        objTriage.diabMellitus = txtDiabeteMN.Text
        objTriage.hiperGestacional = txtHiperGN.Text
        objTriage.preclancia = txtPreeclampciaN.Text
        objTriage.enfermTiroidea = txtEnferTN.Text
        objTriage.vacunacion = txtVacunacionN.Text
        objTriage.torch = txtTorch.Text
        objTriage.hemoclasificacion = txtHemoclasificacionN.Text
        objTriage.tsh = txtTSHN.Text
        objTriage.vdrl = txtVDRLN.Text
        objTriage.glucometria = txtGlucometriasN.Text
        objTriage.torax = txtInfoTorax.Text
        objTriage.cabCue = txtInfoCabCu.Text
        objTriage.abdomen = txtInfoAbdomen.Text
        objTriage.cardioPulmonar = txtInfoCardio.Text
        objTriage.extremidades = txtInfoExtrem.Text
        objTriage.sisNervCen = txtInfoSNerv.Text
        objTriage.genitoUrinario = txtInfoGenito.Text
    End Sub
    Sub llenarDisenio()
        chkNeonatal.Checked = objTriage.esNeonatal
        Combotriage.SelectedValue = objTriage.nivelTriage
        txtRegistro.Text = objTriage.registro
        dtpFecha.Value = objTriage.fecha
        txtMotivoConsulta.Text = objTriage.motivoConsulta
        txtAnteM.Text = objTriage.medicos
        txtAnteQ.Text = objTriage.quirurgicos
        txtAnteT.Text = objTriage.traumaticos
        txtAnteTr.Text = objTriage.trasnfucionales
        txtAnteA.Text = objTriage.alergicos
        txtAnteTo.Text = objTriage.toxico
        txtAnteF.Text = objTriage.anteFamiliares
        txtEdadMadreN.Text = objTriage.edadMadre
        txtEdadGestN.Text = objTriage.edadGestacional
        txtFumN.Text = objTriage.fum
        txtObstetricosN.Text = objTriage.obstetricos
        txtHemMN.Text = objTriage.hemM
        txtHemPN.Text = objTriage.hemP
        txtControlPN.Text = objTriage.controlPrenatal
        txtMedDurEmbN.Text = objTriage.medDurantembarazo
        txtHabitosN.Text = objTriage.habitos
        txtInfeccionesN.Text = objTriage.infeccEmb
        txtDiabeteGN.Text = objTriage.diabGestacional
        txtDiabeteMN.Text = objTriage.diabMellitus
        txtHiperGN.Text = objTriage.hiperGestacional
        txtPreeclampciaN.Text = objTriage.preclancia
        txtEnferTN.Text = objTriage.enfermTiroidea
        txtVacunacionN.Text = objTriage.vacunacion
        txtTorch.Text = objTriage.torch
        txtHemoclasificacionN.Text = objTriage.hemoclasificacion
        txtTSHN.Text = objTriage.tsh
        txtVDRLN.Text = objTriage.vdrl
        txtGlucometriasN.Text = objTriage.glucometria
        txtInfoTorax.Text = objTriage.torax
        txtInfoCabCu.Text = objTriage.cabCue
        txtInfoAbdomen.Text = objTriage.abdomen
        txtInfoCardio.Text = objTriage.cardioPulmonar
        txtInfoExtrem.Text = objTriage.extremidades
        txtInfoSNerv.Text = objTriage.sisNervCen
        txtInfoGenito.Text = objTriage.genitoUrinario
    End Sub
#End Region
#Region "Botones"
    Private Sub btnTrasladar_Click(sender As Object, e As EventArgs) Handles btnTrasladar.Click
        If SesionActual.tienePermiso(PTrasladar) Then
            If objTriage.descripcionAreaTraslado <> "" AndAlso objTriage.codigoAreaServicio <> Constantes.VALOR_PREDETERMINADO Then
                textTraslado.Text = objTriage.descripcionAreaTraslado
            End If
            pnlTraslado.Visible = Not pnlTraslado.Visible
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub dgvParametros_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvParametros.EditingControlShowing
        If dgvParametros.Rows(dgvParametros.CurrentRow.Index).Cells(0).Value = Constantes.PESO_TRIAGE Then
            AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivo
        Else
            RemoveHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivo
        End If

    End Sub

    Private Sub Form_Triage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If btguardar.Enabled = True Then
            e.Cancel = True
            MsgBox(Mensajes.CAMBIOS_SIN_GUARDAR, MsgBoxStyle.Critical)
            Exit Sub
        End If

        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            btnTrasladar.Enabled = True
            btnCerrarAtencion.Enabled = True
            btnRecetario.Enabled = True
            e.Cancel = True
        End If
    End Sub
    'Private Sub dgvParametros_Click(sender As Object, e As EventArgs) Handles dgvParametros.Click
    '    If dgvParametros.Rows(dgvParametros.CurrentRow.Index).Cells(0).Value = Constantes.PESO_TRIAGE Then
    '        dgvParametros.Rows(dgvParametros.CurrentRow.Index).Cells(dgvParametros.CurrentCell.ColumnIndex).ReadOnly = True
    '    End If
    'End Sub
    'Private Sub dgvParametros_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvParametros.CellEnter
    '    If dgvParametros.Rows(dgvParametros.CurrentRow.Index).Cells(0).Value = Constantes.PESO_TRIAGE Then
    '        dgvParametros.Rows(dgvParametros.CurrentRow.Index).Cells(dgvParametros.CurrentCell.ColumnIndex).ReadOnly = True
    '    End If
    'End Sub
    Private Sub dgvdiagRem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdiagRem.CellDoubleClick
        If btguardar.Enabled AndAlso Funciones.filaValida(e.RowIndex) Then
            If e.ColumnIndex = 2 Then
                If e.RowIndex < dgvdiagRem.RowCount - 1 AndAlso MsgBox(Mensajes.QUITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim params As New List(Of String)
                    params.Add(txtRegistro.Text)
                    params.Add(dgvdiagRem.Rows(e.RowIndex).Cells("Codigo").Value)
                    General.ejecutarSQL(Consultas.INGRESO_UCI_ANULAR_DIAG, params)
                    objTriage.tblDiagnostico.Rows.RemoveAt(e.RowIndex)
                End If
            Else
                If e.RowIndex = dgvdiagRem.RowCount - 1 Then
                    General.agregarDiagnosticosCIE(dgvdiagRem, objTriage.tblDiagnostico)
                End If
            End If
        End If
    End Sub
    Private Sub btnCerrarAtencion_Click(sender As Object, e As EventArgs) Handles btnCerrarAtencion.Click
        If SesionActual.tienePermiso(PCerrarAtencion) Then
            If MsgBox("¿ Esta seguro que quiere cerrar la atención del paciente " & txtNombre.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim params As New List(Of String)
                params.Add(objTriage.registro)
                Try
                    General.ejecutarSQL(Consultas.TRIAGE_CERRAR_ATENCION, params)
                    MsgBox("Atención Cerrada!", MsgBoxStyle.Exclamation)
                    Me.Close()
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub chkNeonatal_CheckedChanged(sender As Object, e As EventArgs) Handles chkNeonatal.CheckedChanged
        objTriage.codigoAreaServicio = Constantes.VALOR_PREDETERMINADO
        textTraslado.ResetText()
        lblAreaServicioTraslado.ResetText()
        If chkNeonatal.Checked Then
            mostrarTab(Antecedentes_Adulto, Antecedentes_Neo)
        Else
            mostrarTab(Antecedentes_Neo, Antecedentes_Adulto)
        End If
    End Sub
    Private Sub btBuscarEPROC_Click(sender As Object, e As EventArgs) Handles btBuscarEsp.Click
        Dim params As New List(Of String)
        params.Add(Nothing)
        params.Add(txtContrato.Text)
        params.Add(chkNeonatal.Checked)
        params.Add(objTriage.registro)

        General.buscarElemento(
                               Consultas.TRIAGE_BUSCAR_AREAS,
                               params,
                               AddressOf cargarArea,
                               TitulosForm.BUSQUEDA_AREA_SERVICIO,
                               False,
                               0,
                               True
                              )
    End Sub
    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        objTriage.codigoAreaServicio = Constantes.VALOR_PREDETERMINADO
        textTraslado.Clear()
        btLimpiar.Visible = False
    End Sub
    Private Sub btnRecetario_Click(sender As Object, e As EventArgs) Handles btnRecetario.Click
        If SesionActual.tienePermiso(PRecetario) Then
            Dim tbl As DataRow = Nothing
            Dim params As New List(Of String)
            params.Add(Constantes.LISTA_CARGO_ORDEN_MEDICA)
            params.Add(SesionActual.idEmpresa)
            Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True,, True)
            tbl = formBusqueda.rowResultados
            If tbl IsNot Nothing Then
                Dim formRecetario As New Form_Recetario
                formRecetario.cargarModulo(Me.Tag)
                General.limpiarControles(formRecetario)
                formRecetario.cargarDatos(txtRegistro.Text, txtHC.Text, txtSexo.Text, txtNombre.Text, txtEdad.Text, txtContrato.Text, txtNombreContrato.Text, tbl(0))
                formRecetario.ShowDialog()
                formRecetario.Activate()
            Else
                MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        llenarObjeto()
        If validarFormulario() AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                objTriage.guardarTriage()
                General.deshabilitarBotones(ToolStrip1)
                General.deshabilitarControles(Me)
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                bteditar.Enabled = True
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If General.fnFormEditar(Me, ToolStrip1, btguardar, btcancelar) Then
                General.deshabilitarBotones(ToolStrip1)
                btguardar.Enabled = True
                btcancelar.Enabled = True
                General.habilitarControles(Me)
                If objTriage.tblDiagnostico.Rows.Count = 0 OrElse objTriage.tblDiagnostico.Rows(objTriage.tblDiagnostico.Rows.Count - 1).Item("Codigo").ToString <> "" Then
                    objTriage.tblDiagnostico.Rows.Add()
                End If
                controlesSoloLectura()
                verificarTrasladar()
                btnCerrarAtencion.Enabled = puedeCerrarAtencion()
                btnTrasladar.Enabled = puedeTrasladar()
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            General.deshabilitarControles(tabControles)
            General.deshabilitarBotones(ToolStrip1)
            General.limpiarControles(GroupBox3)
            General.limpiarControles(GroupBox7)
            bteditar.Enabled = True
            chkNeonatal.Checked = False
            chkNeonatal.Enabled = False
            dtpFecha.Enabled = False
            Combotriage.Enabled = False
            varificarExistenciaTriage()
        End If
    End Sub
#End Region
End Class