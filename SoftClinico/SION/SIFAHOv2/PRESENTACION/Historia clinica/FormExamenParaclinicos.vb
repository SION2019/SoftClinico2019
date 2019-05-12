Imports System.Threading
Public Class FormExamenParaclinicos
    Dim objExamenParaclinico As ExamenLaboratorio
    Public Property HistoriaClinica As Form_Historia_clinica
    Private Sub FormExamenParaclinicos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objExamenParaclinico.codigoEP = SesionActual.codigoEP
        objExamenParaclinico.usuario = SesionActual.idUsuario
        objExamenParaclinico.idEmpresa = SesionActual.idEmpresa
        verificarTipoExamen()
    End Sub
    Public Function cargarRegistroExamen(codigoTipoExamen As String, modulo As String, codigoOrden As Integer,
                              codigoExamen As String) As Boolean
        Dim resultado As Boolean

        objExamenParaclinico = GeneralHC.fabricaHC.crear(modulo)
        objExamenParaclinico.CodigoTipoExamen = codigoTipoExamen
        objExamenParaclinico.codigoOrden = codigoOrden
        objExamenParaclinico.CodigoExamen = codigoExamen
        objExamenParaclinico.modulo = modulo

        If objExamenParaclinico.verificarExistencia() = Constantes.PENDIENTE Then
            resultado = BuscarUsuarioReal()
        Else
            resultado = True
        End If

        If resultado = True Then
            objExamenParaclinico.instanciaObjeto()
            ocultarPestañas()
            cargarPaciente()
            relacionarPestañaDatos(codigoTipoExamen)
        End If

        Return resultado

    End Function
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            objExamenParaclinico.usuarioReal = IIf(String.IsNullOrEmpty(objExamenParaclinico.usuarioReal),
                                                   objExamenParaclinico.usuario, objExamenParaclinico.usuarioReal)
            objExamenParaclinico.fechaReal = dtfecha.Value
            dgvExamen.EndEdit()
            dgvHemocultivo.EndEdit()
            cargarObjetos()
            Try
                guardarExamenes()
                HistoriaClinica.cargarParaclinico()
                guardarSegundoPlano()
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub guardarExamenes()
        ExamenLaboratorioBLL.guardarExamen(objExamenParaclinico)
        General.habilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btguardar.Enabled = False
        btcancelar.Enabled = False
    End Sub
    Private Sub guardarSegundoPlano()
        Dim reporteSegundoPlano As Thread
        reporteSegundoPlano = New Thread(AddressOf guardarReporte)
        reporteSegundoPlano.Name = "Guardar Examen Paraclinico"
        reporteSegundoPlano.SetApartmentState(ApartmentState.STA)
        reporteSegundoPlano.Start()
    End Sub
    Private Sub guardarReporte()
        Try
            objExamenParaclinico.generarReporteLab()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If BuscarUsuarioReal() = True Then
            General.deshabilitarBotones(ToolStrip1)
            General.habilitarControles(Me)
            General.deshabilitarControles(GroupDatos)
            dtfecha.Enabled = True
            btguardar.Enabled = True
            btcancelar.Enabled = True
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dispose()
        End If
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            objExamenParaclinico.anulaExamen()
            HistoriaClinica.cargarParaclinico()
            MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
            Dispose()
        End If
    End Sub
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Dim reporte As New ftp_reportes
        Dim nombreArchivo, ruta As String
        Try
            nombreArchivo = objExamenParaclinico.areaReporte & ConstantesHC.NOMBRE_PDF_SEPARADOR & objExamenParaclinico.codigoOrden & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            ftp_reportes.llamarArchivo(ruta, nombreArchivo, objExamenParaclinico.codigoOrden, objExamenParaclinico.areaReporte)

            Process.Start(ruta)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FormExamenParaclinicos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
#Region "Procedimientos"
    Private Sub verificarTipoExamen()
        General.deshabilitarBotones(ToolStrip1)
        If objExamenParaclinico.verificarExistencia() = Constantes.PENDIENTE Then
            General.deshabilitarControles(GroupDatos)
            General.habilitarControles(TabExamen)
            dtfecha.Enabled = True
            btguardar.Enabled = True
            btcancelar.Enabled = True
        Else
            General.deshabilitarControles(Me)
            bteditar.Enabled = True
            btimprimir.Enabled = True
            btanular.Enabled = True
        End If
    End Sub
    Private Sub ocultarPestañas()
        TabPage1.Parent = Nothing
        TabPage2.Parent = Nothing
        TabPage3.Parent = Nothing
        TabPage4.Parent = Nothing
        TabPage5.Parent = Nothing
        TabPage6.Parent = Nothing
        TabPage7.Parent = Nothing
        TabPage8.Parent = Nothing
        TabPage9.Parent = Nothing
        TabPage10.Parent = Nothing
        TabPage11.Parent = Nothing
    End Sub
    Private Sub validarDgv(grilla As DataGridView)
        With grilla
            .Columns(0).ReadOnly = True
            .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(1).ReadOnly = True
            .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        End With
    End Sub
    Private Sub cargarObjetos()
        objExamenParaclinico.fechaReal = dtfecha.Value
        Select Case objExamenParaclinico.CodigoTipoExamen
            Case ConstantesHC.CODIGO_UROCULTIVO
                CargarObjetoUrocultivo()
            Case ConstantesHC.CODIGO_UROANALISIS
                CargarObjetoUroanalisis()
            Case ConstantesHC.CODIGO_COPROLOGICO
                CargarObjetoCoprologico()
            Case ConstantesHC.CODIGO_SEROLOGIA
                CargarObjetoSerologia()
            Case ConstantesHC.CODIGO_TINTA_CHINA
                CargarObjetoTinta()
            Case ConstantesHC.CODIGO_LIQ_CEFALORAQUIDEO
                cargarObjetoLiqCefaloraquideo()
            Case ConstantesHC.CODIGO_KOH
                cargarObjetoKOH()
            Case ConstantesHC.CODIGO_BACILOSCOPIA
                cargarObjetoBaciloscopia()
            Case ConstantesHC.CODIGO_CULTIVO_CUALQ_MUESTRA
                cargarObjetoCultCualMuestra()
        End Select
    End Sub
    Private Sub cargarPaciente()
        Dim dFila As DataRow
        dFila = objExamenParaclinico.cargarPacienteExamen()
        txtidentificacion.Text = dFila.Item("identificacion")
        txtpaciente.Text = dFila.Item("NombrePaciente")
        txtfechaingreso.Text = dFila.Item("Fecha_Admision")
        dtFechaOrden.Text = dFila.Item("Fecha_Orden")
        lblentorno.Text = dFila.Item("Sala")
        txtsexo.Text = dFila.Item("Genero")
        txtedad.Text = dFila.Item("Edad")
        txtcama.Text = dFila.Item("Cama")
        txtregistro.Text = dFila.Item("N_Registro")
        txtcodigocontrato.Text = dFila.Item("Codigo_Contrato")
        txtcontrato.Text = dFila.Item("Contrato")
        objExamenParaclinico.codigoGenero = dFila.Item("CodGenero")
        objExamenParaclinico.registro = txtregistro.Text
    End Sub
    Private Sub relacionarPestañaDatos(CodigoTipoExamen As Integer)
        Select Case CodigoTipoExamen
            Case ConstantesHC.CODIGO_ELECTROLITO
                validarGgvDatosExamenes()
            Case ConstantesHC.CODIGO_HEMOGRAMA
                validarGgvDatosExamenes()
            Case ConstantesHC.CODIGO_QUIMICA_SANGUINEA
                validarGgvDatosExamenes()
            Case ConstantesHC.CODIGO_GRUPO_TORCH
                validarGgvDatosExamenes()
            Case ConstantesHC.CODIGO_GASES_ARTERIALES
                validarGgvDatosExamenes()
            Case ConstantesHC.CODIGO_HEMOCULTIVO
                TabPage2.Parent = TabExamen
                cargarDatosHemocultivo()
            Case ConstantesHC.CODIGO_UROCULTIVO
                TabPage3.Parent = TabExamen
                CargarRegistroUrocultivo()
            Case ConstantesHC.CODIGO_UROANALISIS
                TabPage4.Parent = TabExamen
                cargarRegistroUroanalisis()
            Case ConstantesHC.CODIGO_COPROLOGICO
                TabPage5.Parent = TabExamen
                CargarRegistroCoprologico()
            Case ConstantesHC.CODIGO_SEROLOGIA
                TabPage6.Parent = TabExamen
                CargarRegistroSerologia()
            Case ConstantesHC.CODIGO_TINTA_CHINA
                TabPage7.Parent = TabExamen
                CargarRegistroTinta()
            Case ConstantesHC.CODIGO_LIQ_CEFALORAQUIDEO
                TabPage8.Parent = TabExamen
                cargarRegistroLiqCefaloraquideo()
            Case ConstantesHC.CODIGO_KOH
                TabPage9.Parent = TabExamen
                cargarRegistroKOH()
            Case ConstantesHC.CODIGO_BACILOSCOPIA
                TabPage10.Parent = TabExamen
                cargarRegistroBaciloscopia()
            Case ConstantesHC.CODIGO_CULTIVO_CUALQ_MUESTRA
                TabPage11.Parent = TabExamen
                cargarRegistroCultCualMuestra()
        End Select
    End Sub
    Private Sub validarGgvDatosExamenes()
        TabPage1.Parent = TabExamen
        objExamenParaclinico.cargarDatosExamenes()
        dgvExamen.DataSource = objExamenParaclinico.dtExamen
        validarDgv(dgvExamen)
        TabExamen.TabPages.Item(0).Text = objExamenParaclinico.titulo
    End Sub
    Private Function BuscarUsuarioReal() As Boolean
        Dim verificarUsuarioReal As Boolean = True
        If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
            Dim tbl As DataRow = Nothing
            Dim params As New List(Of String)
            params.Add(Constantes.LISTA_CARGO_ORDEN_MEDICA)
            params.Add(SesionActual.idEmpresa)
            Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True)
            tbl = formBusqueda.rowResultados
            If tbl IsNot Nothing Then
                objExamenParaclinico.usuarioReal = tbl(0)
            Else
                MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                verificarUsuarioReal = False
            End If
        End If
        Return verificarUsuarioReal
    End Function
#End Region
#Region "Examenes: Eletrolitos,Hemograma,Quimica Sanguinea, Grupo Torch Gases Arteriales"
    Private Sub dgvExamen_DoubleClick(sender As Object, e As EventArgs) Handles dgvExamen.DoubleClick
        ExamenLaboratorioBLL.abrirJustificacion(dgvExamen, objExamenParaclinico.dtExamen, Panel7, txtComentario, "Comentario")
    End Sub
    Private Sub dgvExamen_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvExamen.EditingControlShowing
        If dgvExamen.Rows(dgvExamen.CurrentCell.RowIndex).Cells("Resultado").Selected = True Then
            AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
        Else
            AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarAlfanumerico
        End If
    End Sub
    Private Sub txtComentario_Leave(sender As Object, e As EventArgs) Handles txtComentario.Leave
        Try
            If Panel7.Visible = True Then
                Panel7.Visible = False
                dgvExamen.Rows(dgvExamen.CurrentRow.Index).Cells("Comentario").Value = txtComentario.Text
                txtComentario.Clear()
                objExamenParaclinico.dtExamen.AcceptChanges()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgvExamen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvExamen.KeyPress
        If btguardar.Enabled = False Then Exit Sub
        ExamenLaboratorioBLL.abrirJustificacion(dgvExamen, objExamenParaclinico.dtExamen, Panel7, txtComentario, "Comentario")
    End Sub
#End Region
#Region "Hemocultivo"
    Private Sub btAgregarFila_Click(sender As Object, e As EventArgs) Handles btAgregarFila.Click
        If btguardar.Enabled = False Then Exit Sub
        ExamenLaboratorioBLL.agregarFilaHemocultivo(objExamenParaclinico.dtHemocultivo)
    End Sub
    Private Sub dgvHemocultivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvHemocultivo.KeyPress
        If btguardar.Enabled = False Then Exit Sub
        ExamenLaboratorioBLL.abrirJustificacion(dgvHemocultivo, objExamenParaclinico.dtHemocultivo, Panel2, txtcomentarioHemo, "Comentario")
    End Sub
    Private Sub txtcomentarioHemo_Leave(sender As Object, e As EventArgs) Handles txtcomentarioHemo.Leave
        Try
            If Panel2.Visible = True Then
                Panel2.Visible = False
                dgvHemocultivo.Rows(dgvHemocultivo.CurrentRow.Index).Cells("Comentario").Value = txtcomentarioHemo.Text
                txtcomentarioHemo.Clear()
                objExamenParaclinico.dtHemocultivo.AcceptChanges()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cargarDatosHemocultivo()
        objExamenParaclinico.cargarHemocultivo()
        dgvHemocultivo.DataSource = objExamenParaclinico.dtHemocultivo
        With dgvHemocultivo
            .Columns("Codigo").ReadOnly = True
            .Columns("Codigo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Muestra").ReadOnly = False
            .Columns("Muestra").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Resultado").ReadOnly = False
            .Columns("Resultado").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Resultado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("comentario").ReadOnly = False
            .Columns("comentario").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("dgQuitar").DisplayIndex = 4
        End With
    End Sub
#End Region
#Region "Urocultivo"
    Public Sub CargarObjetoUrocultivo()
        objExamenParaclinico.objUrocultivo.reporte24 = Hora24.Text
        objExamenParaclinico.objUrocultivo.reporte48 = Hora48.Text
        objExamenParaclinico.objUrocultivo.muestra = txtTipoMuestra.Text
        objExamenParaclinico.objUrocultivo.resultado = txtResultadoGramUro.Text
        objExamenParaclinico.fechaReal = dtfecha.Value
    End Sub
    Public Sub CargarRegistroUrocultivo()
        Dim dFila As DataRow
        dFila = objExamenParaclinico.objUrocultivo.cargarRegistro(objExamenParaclinico.codigoOrden)
        If Not IsNothing(dFila) Then
            Hora24.Text = dFila.Item("Reporte24")
            Hora48.Text = dFila.Item("Reporte48")
            txtTipoMuestra.Text = dFila.Item("Muestra")
            txtResultadoGramUro.Text = dFila.Item("Resultado")
            dtfecha.Value = dFila.Item("Fecha")
        End If
    End Sub
#End Region
#Region "Uroanalisis"
    Public Sub CargarObjetoUroanalisis()
        objExamenParaclinico.objUroanalisis.color = textColor.Text
        objExamenParaclinico.objUroanalisis.aspecto = TextAspecto.Text
        objExamenParaclinico.objUroanalisis.PH = textPH_uro.Text
        objExamenParaclinico.objUroanalisis.bacteria = textBacterias_Sed.Text
        objExamenParaclinico.objUroanalisis.densidad = textdensidad.Text
        objExamenParaclinico.objUroanalisis.urobilinogenos = textUrobilinogeno.Text
        objExamenParaclinico.objUroanalisis.cetona = textCetona.Text
        objExamenParaclinico.objUroanalisis.otroUro = textOtroUro.Text
        objExamenParaclinico.objUroanalisis.proteina = textProteinas.Text
        objExamenParaclinico.objUroanalisis.glucosa = TextGlucosa.Text
        objExamenParaclinico.objUroanalisis.sangre = TextSangre.Text
        objExamenParaclinico.objUroanalisis.bilirubina = textBilirubina.Text
        objExamenParaclinico.objUroanalisis.nitrito = textNitritos.Text
        objExamenParaclinico.objUroanalisis.celEpi = textCelEpite.Text
        objExamenParaclinico.objUroanalisis.hematies = TextHematies_Uro.Text
        objExamenParaclinico.objUroanalisis.cilindro = TextCilindros.Text
        objExamenParaclinico.objUroanalisis.cristale = textCristales.Text
        objExamenParaclinico.objUroanalisis.otroUroSet = TextOtros_Uro_Sedimento.Text
        objExamenParaclinico.objUroanalisis.leucocito = textLecocitos_Sed.Text
        objExamenParaclinico.objUroanalisis.cilindro = textBacterias_Sed.Text
        objExamenParaclinico.objUroanalisis.plocito = textPlocitos.Text
        objExamenParaclinico.fechaReal = dtfecha.Value
    End Sub
    Private Sub cargarRegistroUroanalisis()
        Dim dFila As DataRow
        dFila = objExamenParaclinico.objUroanalisis.cargarRegistro(objExamenParaclinico.codigoOrden)
        If Not IsNothing(dFila) Then
            textColor.Text = dFila.Item("color")
            TextAspecto.Text = dFila.Item("aspecto")
            textPH_uro.Text = dFila.Item("PH")
            textBacterias_Sed.Text = dFila.Item("bacterias")
            textdensidad.Text = dFila.Item("densidad")
            textUrobilinogeno.Text = dFila.Item("urobilinogeno")
            textCetona.Text = dFila.Item("cetona")
            textOtroUro.Text = dFila.Item("Otros_Orina")
            textProteinas.Text = dFila.Item("proteinas")
            TextGlucosa.Text = dFila.Item("glucosa")
            TextSangre.Text = dFila.Item("sangre")
            textBilirubina.Text = dFila.Item("bilirubina")
            textNitritos.Text = dFila.Item("nitritos")
            textCelEpite.Text = dFila.Item("Cel_Epitelial")
            TextHematies_Uro.Text = dFila.Item("hematies")
            TextCilindros.Text = dFila.Item("cilindro")
            textCristales.Text = dFila.Item("cristales")
            TextOtros_Uro_Sedimento.Text = dFila.Item("Otros_sedimento")
            textLecocitos_Sed.Text = dFila.Item("leucocitos")
            textPlocitos.Text = dFila.Item("plocitos")
            dtfecha.Value = dFila.Item("Fecha")
        End If
    End Sub
#End Region
#Region "Coprologico"
    Public Sub CargarObjetoCoprologico()
        objExamenParaclinico.objCoprologico.color = color.Text
        objExamenParaclinico.objCoprologico.consistencia = consistencia.Text
        objExamenParaclinico.objCoprologico.sangreOculta = txtSangreOculta.Text
        objExamenParaclinico.objCoprologico.moco = txtMoco.Text
        objExamenParaclinico.objCoprologico.PH = txtPh.Text
        objExamenParaclinico.objCoprologico.azucareReductores = txtAzucareReduct.Text
        objExamenParaclinico.objCoprologico.coli = txtColi.Text
        objExamenParaclinico.objCoprologico.histolitico = txtHistolica.Text
        objExamenParaclinico.objCoprologico.nana = txtNana.Text
        objExamenParaclinico.objCoprologico.lodomoeba = txtLodomoeba.Text
        objExamenParaclinico.objCoprologico.griardia = txtGiardia.Text
        objExamenParaclinico.objCoprologico.otro = otros.Text
        objExamenParaclinico.objCoprologico.ascari = txtAscaris.Text
        objExamenParaclinico.objCoprologico.tricocefalo = txtTricocefalo.Text
        objExamenParaclinico.objCoprologico.uncinaria = txtUncinaria.Text
        objExamenParaclinico.objCoprologico.Hymenolepi = txtHymeno.Text
        objExamenParaclinico.objCoprologico.teniaGP = txtTenia.Text
        objExamenParaclinico.objCoprologico.hongo = txtHongo.Text
        objExamenParaclinico.objCoprologico.leucocito = txtleucocito.Text
        objExamenParaclinico.fechaReal = dtfecha.Value
    End Sub
    Public Sub CargarRegistroCoprologico()
        Dim dFila As DataRow
        dFila = objExamenParaclinico.objCoprologico.cargarRegistro(objExamenParaclinico.codigoOrden)
        If Not IsNothing(dFila) Then
            color.Text = dFila.Item("color")
            consistencia.Text = dFila.Item("consistencia")
            txtSangreOculta.Text = dFila.Item("Sangre")
            txtMoco.Text = dFila.Item("moco")
            txtPh.Text = dFila.Item("PH")
            txtAzucareReduct.Text = dFila.Item("azucares")
            txtColi.Text = dFila.Item("coli")
            txtHistolica.Text = dFila.Item("histolitica")
            txtNana.Text = dFila.Item("nana")
            txtLodomoeba.Text = dFila.Item("iodomoeba")
            txtGiardia.Text = dFila.Item("giardia")
            otros.Text = dFila.Item("otros")
            txtAscaris.Text = dFila.Item("ascaris")
            txtTricocefalo.Text = dFila.Item("tricocefalo")
            txtUncinaria.Text = dFila.Item("uncinaria")
            txtHymeno.Text = dFila.Item("hymenolepis")
            txtTenia.Text = dFila.Item("gp")
            txtHongo.Text = dFila.Item("hongos")
            txtleucocito.Text = dFila.Item("leucocitos")
            dtfecha.Value = dFila.Item("Fecha")
        End If
    End Sub

#End Region
#Region "Serologia"
    Public Sub CargarObjetoSerologia()
        objExamenParaclinico.objSerologia.VDRL = txtvdrl.Text
        objExamenParaclinico.objSerologia.ASTO = txtasto.Text
        objExamenParaclinico.objSerologia.PCR = txtpcr.Text
        objExamenParaclinico.objSerologia.RATES = txtrates.Text
        objExamenParaclinico.objSerologia.HIV = txtVIH.Text
        objExamenParaclinico.objSerologia.Hepatitis_A = txthepatitisA.Text
        objExamenParaclinico.objSerologia.Hepatitis_B = txthepatitisB.Text
        objExamenParaclinico.objSerologia.Hepatitis_C = txthepatitisC.Text
        objExamenParaclinico.objSerologia.Taxoplasma_IGG = txtTXPIGG.Text
        objExamenParaclinico.objSerologia.Taxoplasma_IGM = txtTXPIGM.Text
        objExamenParaclinico.objSerologia.GX_sangre = txtGXSANGRE.Text
        objExamenParaclinico.objSerologia.Tifoidea_O = txtifoideaO.Text
        objExamenParaclinico.objSerologia.Tifoidea_H = txttifoideaH.Text
        objExamenParaclinico.objSerologia.Paratifoidea_A = txtparatifoideaA.Text
        objExamenParaclinico.objSerologia.Paratifoidea_B = txtparatifoideaB.Text
        objExamenParaclinico.objSerologia.Brucella = txtBrucella.Text
        objExamenParaclinico.objSerologia.Proteus_OX = TxtProteus.Text
        objExamenParaclinico.objSerologia.Observacion = txtobservacion.Text
        objExamenParaclinico.fechaReal = dtfecha.Value
    End Sub
    Public Sub CargarRegistroSerologia()
        Dim dFila As DataRow
        dFila = objExamenParaclinico.objSerologia.cargarRegistro(objExamenParaclinico.codigoOrden)
        If Not IsNothing(dFila) Then
            txtvdrl.Text = dFila.Item("VDRL")
            txtasto.Text = dFila.Item("ASTO")
            txtpcr.Text = dFila.Item("PCR")
            txtrates.Text = dFila.Item("RATES")
            txtVIH.Text = dFila.Item("HIV")
            txthepatitisA.Text = dFila.Item("Hepatitis_A")
            txthepatitisB.Text = dFila.Item("Hepatitis_B")
            txthepatitisC.Text = dFila.Item("Hepatitis_C")
            txtTXPIGG.Text = dFila.Item("Taxoplasma_IGM")
            txtTXPIGM.Text = dFila.Item("Taxoplasma_IGG")
            txtGXSANGRE.Text = dFila.Item("GX_sangre")
            txtifoideaO.Text = dFila.Item("Tifoidea_O")
            txttifoideaH.Text = dFila.Item("Tifoidea_H")
            txtparatifoideaA.Text = dFila.Item("Paratifoidea_A")
            txtparatifoideaB.Text = dFila.Item("Paratifoidea_B")
            txtBrucella.Text = dFila.Item("Brucella")
            TxtProteus.Text = dFila.Item("Proteus_OX")
            txtobservacion.Text = dFila.Item("Observacion")
            dtfecha.Value = dFila.Item("Fecha")
        End If
    End Sub
#End Region
#Region "Tinta China"
    Public Sub CargarObjetoTinta()
        objExamenParaclinico.objTintaChina.muestra = txtMuestra.Text
        objExamenParaclinico.objTintaChina.resultado = txtResultado.Text
        objExamenParaclinico.fechaReal = dtfecha.Value
    End Sub
    Public Sub CargarRegistroTinta()
        Dim dFila As DataRow
        dFila = objExamenParaclinico.objTintaChina.cargarRegistro(objExamenParaclinico.codigoOrden)
        If Not IsNothing(dFila) Then
            txtMuestra.Text = dFila.Item("muestra")
            txtResultado.Text = dFila.Item("resultado")
            dtfecha.Value = dFila.Item("Fecha")
        End If
    End Sub
#End Region
#Region "Liquido Cefaloraquideo"
    Private Sub cargarObjetoLiqCefaloraquideo()
        objExamenParaclinico.objLiqCefaloraquideo.color = Textcolor_Raq.Text
        objExamenParaclinico.objLiqCefaloraquideo.aspecto = Textaspecto_Raq.Text
        objExamenParaclinico.objLiqCefaloraquideo.ph = Textph_Raq.Text
        objExamenParaclinico.objLiqCefaloraquideo.densidad = Textdensidad_Raq.Text
        objExamenParaclinico.objLiqCefaloraquideo.proteina = TextProteinas_Raq.Text
        objExamenParaclinico.objLiqCefaloraquideo.glucosa = Textglucosa_Raq.Text
        objExamenParaclinico.objLiqCefaloraquideo.bacteria = TextbacteriasGram_Raq.Text
        objExamenParaclinico.objLiqCefaloraquideo.pmn = TextPMN_Raq.Text
        objExamenParaclinico.objLiqCefaloraquideo.hematies = TextHematies_Raq.Text
        objExamenParaclinico.objLiqCefaloraquideo.leucocitos = Textleucocitos_Raq.Text
        objExamenParaclinico.objLiqCefaloraquideo.bacteriaFresco = TextBacterias_Raq.Text
        objExamenParaclinico.objLiqCefaloraquideo.neutrofilos = TextNeutrofilos_Raq.Text
        objExamenParaclinico.objLiqCefaloraquideo.linfocitos = TextLinfocitos_Raq.Text
        objExamenParaclinico.fechaReal = dtfecha.Value
    End Sub
    Private Sub cargarRegistroLiqCefaloraquideo()
        Dim dFila As DataRow
        dFila = objExamenParaclinico.objLiqCefaloraquideo.cargarRegistro(objExamenParaclinico.codigoOrden)
        If Not IsNothing(dFila) Then
            Textcolor_Raq.Text = dFila.Item("Color")
            Textaspecto_Raq.Text = dFila.Item("Aspecto")
            Textph_Raq.Text = dFila.Item("ph")
            Textdensidad_Raq.Text = dFila.Item("Densidad")
            TextProteinas_Raq.Text = dFila.Item("Proteinas")
            Textglucosa_Raq.Text = dFila.Item("Glucosa")
            TextbacteriasGram_Raq.Text = dFila.Item("Bacterias_Gram")
            TextPMN_Raq.Text = dFila.Item("pmn")
            TextHematies_Raq.Text = dFila.Item("Hematies")
            Textleucocitos_Raq.Text = dFila.Item("Leucocitos")
            TextBacterias_Raq.Text = dFila.Item("Bacterias")
            TextNeutrofilos_Raq.Text = dFila.Item("Neutrofilos")
            TextLinfocitos_Raq.Text = dFila.Item("Linfocitos")
            dtfecha.Value = dFila.Item("Fecha_Examen")
        End If
    End Sub
#End Region
#Region "Baciloscopia"
    Private Sub cargarObjetoBaciloscopia()
        objExamenParaclinico.objBaciloscopia.aspecto1 = txtAspecto1.Text
        objExamenParaclinico.objBaciloscopia.aspecto2 = txtAspecto2.Text
        objExamenParaclinico.objBaciloscopia.aspecto3 = txtAspecto3.Text
        objExamenParaclinico.objBaciloscopia.resultado1 = Resultado1.Text
        objExamenParaclinico.objBaciloscopia.resultado2 = Resultado2.Text
        objExamenParaclinico.objBaciloscopia.resultado3 = Resultado3.Text
        objExamenParaclinico.fechaReal = dtfecha.Value
    End Sub
    Private Sub cargarRegistroBaciloscopia()
        Dim dFila As DataRow
        dFila = objExamenParaclinico.objBaciloscopia.cargarRegistro(objExamenParaclinico.codigoOrden)
        If Not IsNothing(dFila) Then
            txtAspecto1.Text = dFila.Item("aspecto_muestra1")
            txtAspecto2.Text = dFila.Item("aspecto_muestra2")
            txtAspecto3.Text = dFila.Item("aspecto_muestra3")
            Resultado1.Text = dFila.Item("Resultado")
            Resultado2.Text = dFila.Item("Resultado2")
            Resultado3.Text = dFila.Item("Resultado3")
            dtfecha.Value = dFila.Item("Fecha")
        End If
    End Sub
#End Region
#Region "Cultivo para Cualquier Muestra"
    Private Sub cargarObjetoCultCualMuestra()
        objExamenParaclinico.objCultivoCualMuestra.reporte24 = TextCualquierM24.Text
        objExamenParaclinico.objCultivoCualMuestra.reporte48 = TextCualquierM48.Text
        objExamenParaclinico.objCultivoCualMuestra.reporte72 = TextCualquierM72.Text
        objExamenParaclinico.objCultivoCualMuestra.muestra = TextCualquierM.Text
        objExamenParaclinico.objCultivoCualMuestra.resultado = TextCualquierMresultado.Text
        objExamenParaclinico.fechaReal = dtfecha.Value
    End Sub
    Private Sub cargarRegistroCultCualMuestra()
        Dim dFila As DataRow
        dFila = objExamenParaclinico.objCultivoCualMuestra.cargarRegistro(objExamenParaclinico.codigoOrden)
        If Not IsNothing(dFila) Then
            TextCualquierM24.Text = dFila.Item("Reporte24")
            TextCualquierM48.Text = dFila.Item("Reporte48")
            TextCualquierM72.Text = dFila.Item("Reporte72")
            TextCualquierM.Text = dFila.Item("Muestra")
            TextCualquierMresultado.Text = dFila.Item("Resultado")
            dtfecha.Value = dFila.Item("Fecha")
        End If
    End Sub
#End Region
#Region "KOH"
    Private Sub cargarObjetoKOH()
        objExamenParaclinico.objKOH.muestra = txtKOH_Orina.Text
        objExamenParaclinico.fechaReal = dtfecha.Value
    End Sub
    Private Sub cargarRegistroKOH()
        Dim dFila As DataRow
        dFila = objExamenParaclinico.objKOH.cargarRegistro(objExamenParaclinico.codigoOrden)
        If Not IsNothing(dFila) Then
            txtKOH_Orina.Text = dFila.Item("Prueba_Orina")
            dtfecha.Value = dFila.Item("Fecha_Examen")
        End If
    End Sub
#End Region
End Class