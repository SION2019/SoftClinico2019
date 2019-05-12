Imports System.Data.SqlClient
Imports System.Threading
Public Class Form_Medicamentos_NoPos
    Dim dtDiagnostico As New DataTable
    Dim perG As New Buscar_Permisos_generales
    Dim objMedicamentos As New SolicitudMedicamentosNoPos
    Public modulo, codigoEquivalenciaUno As String
    Dim reporte As New ftp_reportes
    Dim guardarEn2doPlano As Thread
    Dim activoAM, activoAF, respuestan As Boolean
    Dim consulta, codigoEquivalenciaDos, permisoGeneral, pNuevo, pEditar, pBuscar, pAnular As String
    Private usuarioInforme, contadorDiag, CodigoTemporal, nRegistro, usuarioActual As Integer
    Dim vFormPadre As Form_Historia_clinica
    Private tipoDetalleOM As Integer = -1
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form_Medicamentos_NoPos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If modulo = Nothing Then
            modulo = Tag.modulo
        End If

        Select Case modulo
            Case Constantes.AM
                Label1.Text = "SOLICITUD DE MEDICAMENTOS NO POS: AUDITORÍA MÉDICA"
            Case Constantes.AF
                Label1.Text = "SOLICITUD DE MEDICAMENTOS NO POS: AUDITORÍA FACTURACIÓN"
            Case Else
                Label1.Text = "SOLICITUD DE MEDICAMENTOS NO POS: HISTORIA CLÍNICA"
        End Select
        fechaSolicitud.Text = Funciones.Fecha(Constantes.FORMATO_FECHA)
        activoAM = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AM & "'")
        activoAF = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AF & "'")

        cargarPermisos()
        dgvDiagnostico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        If btbuscar.Enabled = True Then
            General.deshabilitarControles(TabPage2)
        End If
        usuarioActual = SesionActual.idUsuario
    End Sub
    Private Sub cargarPermisos()
        permisoGeneral = perG.buscarPermisoGeneral(Name, modulo)
        pNuevo = permisoGeneral & "pp" & "01"
        pEditar = permisoGeneral & "pp" & "02"
        pBuscar = permisoGeneral & "pp" & "03"
        pAnular = permisoGeneral & "pp" & "04"
    End Sub

    Private Sub Form_Medicamentos_NOPos_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If String.IsNullOrEmpty(txtCodigo.Text) AndAlso Not IsNothing(vFormPadre) Then
            Select Case tipoDetalleOM

                Case Constantes.OM_MEDICAMENTO
                    If IsNothing(vFormPadre.dgvMedicamento.Rows(vFormPadre.dgvMedicamento.CurrentRow.Index).Cells("dgCodigoMed").Tag) = False Then
                        Visible = False
                        e.Cancel = True
                        Exit Sub
                    End If
                Case Constantes.OM_IMPREGNACION
                    If IsNothing(vFormPadre.dgvImpregnacion.Rows(vFormPadre.dgvImpregnacion.CurrentRow.Index).Cells("dgCodigoImpre").Tag) = False Then
                        Visible = False
                        e.Cancel = True
                        Exit Sub
                    End If
                Case Constantes.OM_INFUSION
                    If IsNothing(vFormPadre.dgvInfusion.Rows(vFormPadre.dgvInfusion.CurrentRow.Index).Cells("dgCodigoInfu").Tag) = False Then
                        Visible = False
                        e.Cancel = True
                        Exit Sub
                    End If
                Case Constantes.OM_MEZCLA
                    If IsNothing(vFormPadre.dgvMezcla.Rows(vFormPadre.dgvMezcla.CurrentRow.Index).Cells("dgCodigoMezcla").Tag) = False Then
                        Visible = False
                        e.Cancel = True
                        Exit Sub
                    End If
            End Select


        End If

        If (btbuscar.Enabled = True Or Not String.IsNullOrEmpty(txtCodigo.Text)) Then

            If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
        If String.IsNullOrEmpty(txtCodigo.Text) And btguardar.Enabled = True Then

            If MsgBox(Mensajes.QUITAR_MEDICAMENTO, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
            Else
                quitarMedicamentoOM()
            End If
        End If

    End Sub

    Private Sub quitarMedicamentoOM()
        Select Case tipoDetalleOM
            Case Constantes.OM_MEDICAMENTO
                vFormPadre.eliminaFilaDt(vFormPadre.dgvMedicamento.DataSource, vFormPadre.dgvMedicamento.CurrentRow.Index)
            Case Constantes.OM_IMPREGNACION
                vFormPadre.eliminaFilaDt(vFormPadre.dgvImpregnacion.DataSource, vFormPadre.dgvImpregnacion.CurrentRow.Index)
            Case Constantes.OM_INFUSION
                vFormPadre.eliminaFilaDt(vFormPadre.dgvInfusion.DataSource, vFormPadre.dgvInfusion.CurrentRow.Index)
            Case Constantes.OM_MEZCLA
                Dim NombreTablaMezcla As String
                NombreTablaMezcla = HistoriaClinicaBLL.nombreTabla(vFormPadre.dgvInfusion.DataSource, vFormPadre.dgvInfusion.DataSource)
                vFormPadre.eliminaFilaDt(vFormPadre.dgvMezcla.DataSource, vFormPadre.dgvMezcla.CurrentRow.Index)
        End Select
    End Sub

    Public Sub cargarPacienteH()
        objMedicamentos.registro = txtregistro.Text
        objMedicamentos.cargarPacienteh()
        txtidentificacion.Text = objMedicamentos.identificacion
        txtcama.Text = objMedicamentos.cama
        txtsexo.Text = objMedicamentos.sexo
        txtpaciente.Text = objMedicamentos.nombrePaciente
        txtedad.Text = objMedicamentos.edad
        txtcodigocontrato.Text = objMedicamentos.codigoContrato
        txtcontrato.Text = objMedicamentos.contrato
        lblentorno.Text = objMedicamentos.entorno
        txtdatosingreso.Text = objMedicamentos.datosIngreso
        txtregistro.Text = objMedicamentos.registro
    End Sub

    Private Sub cargarPacientes()
        objMedicamentos.Codigo = txtCodigo.Text
        objMedicamentos.modulo = Tag.modulo
        objMedicamentos.cargarPaciente()
        txtidentificacion.Text = objMedicamentos.identificacion
        txtcama.Text = objMedicamentos.cama
        txtsexo.Text = objMedicamentos.sexo
        txtpaciente.Text = objMedicamentos.nombrePaciente
        txtedad.Text = objMedicamentos.edad
        txtcodigocontrato.Text = objMedicamentos.codigoContrato
        txtcontrato.Text = objMedicamentos.contrato
        lblentorno.Text = objMedicamentos.entorno
        txtdatosingreso.Text = objMedicamentos.datosIngreso
        txtregistro.Text = objMedicamentos.registro
    End Sub

    Private Sub cargarMedico()
        objMedicamentos.usuarioInforme = usuarioInforme
        objMedicamentos.cargarMedico()
        txtDr.Text = objMedicamentos.dr
        txtRegMed.Text = objMedicamentos.registroMedico
        txtEspecialidad.Text = objMedicamentos.especialidad
    End Sub

    Private Sub txtnombre_medicamento_KeyDown(sender As Object, e As KeyEventArgs) Handles txtnombre_medicamento.KeyDown
        If e.KeyCode = Keys.F3 And btguardar.Enabled = True Then
            If txtnombre_medicamento.Text <> "" Then
                If MsgBox(Mensajes.MEDICAMENTO_REEMPLAZAR, MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    buscarMedicamento()
                End If
            Else
                buscarMedicamento()
            End If
        End If
    End Sub
    Private Sub buscarMedicamento()

        Dim tbl As DataRow = Nothing
        Dim params As New List(Of String)
        params.Add(Constantes.LINEA_INSUMO & "," & Constantes.LINEA_MEDICAMENTO & "," & Constantes.LINEA_INSUMO_Y_MEDICAMENTO)
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_MED_E_INSUMO_POS, params, TitulosForm.BUSQUEDA_MED_E_INSUMO_POS, True)
        tbl = formBusqueda.rowResultados
        If tbl IsNot Nothing Then
            codigoEquivalenciaDos = tbl(0)
            txtnombre_medicamento.Text = tbl(1)
        End If

    End Sub

    Private Sub txtnombre_medicamento_DoubleClick(sender As Object, e As EventArgs) Handles txtnombre_medicamento.DoubleClick
        If txtnombre_medicamento.Text <> "" Then
            If MsgBox(Mensajes.MEDICAMENTO_REEMPLAZAR, MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                buscarMedicamento()
            End If
        End If
    End Sub

    Private Function ValidaControles()
        dgvDiagnostico.EndEdit()
        objMedicamentos.dtDiagnosticos.AcceptChanges()
        If objMedicamentos.dtDiagnosticos.Select("Seleccion=1", "").Count = 0 Then
            TabControl1.SelectedTab = TabPage1
            MsgBox("Debe seleccionar algun Diagnostico", MsgBoxStyle.Exclamation)
            dgvDiagnostico.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtresumen.Text) Then
            TabControl1.SelectedTab = TabPage2
            MsgBox("El campo resumen de la historia clinica esta vacio", MsgBoxStyle.Exclamation)
            txtresumen.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtefecto.Text = "") Then
            TabControl1.SelectedTab = TabPage2
            MsgBox("El campo efecto se encuentra vacio", MsgBoxStyle.Exclamation)
            txtefecto.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtnombre_medicamento.Text) And rdsi.Checked = True Then
            TabControl1.SelectedTab = TabPage2
            MsgBox("El campo medicamento a reemplazar se encuentra vacio", MsgBoxStyle.Exclamation)
            txtnombre_medicamento.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtndosis.Text) Then
            TabControl1.SelectedTab = TabPage2
            MsgBox("El campo dosis se encuentra vacio", MsgBoxStyle.Exclamation)
            txtndosis.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtinicioefecto.Text) Then
            TabControl1.SelectedTab = TabPage2
            MsgBox("El campo inicio de efecto se encuentra vacio", MsgBoxStyle.Exclamation)
            txtinicioefecto.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtexplicarazon.Text) And Not String.IsNullOrEmpty(txtnombre_medicamento.Text) Then
            TabControl1.SelectedTab = TabPage2
            MsgBox("El campo explicar razon se encuentra vacio", MsgBoxStyle.Exclamation)
            txtexplicarazon.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If ValidaControles() Then
            If String.IsNullOrEmpty(txtCodigo.Text) Then
                Select Case tipoDetalleOM
                    Case Constantes.OM_MEDICAMENTO
                        vFormPadre.dgvMedicamento.Rows(vFormPadre.dgvMedicamento.CurrentRow.Index).Cells("dgCodigoMed").Tag = Me
                    Case Constantes.OM_IMPREGNACION
                        vFormPadre.dgvImpregnacion.Rows(vFormPadre.dgvImpregnacion.CurrentRow.Index).Cells("dgCodigoImpre").Tag = Me
                    Case Constantes.OM_INFUSION
                        vFormPadre.dgvInfusion.Rows(vFormPadre.dgvInfusion.CurrentRow.Index).Cells("dgCodigoInfu").Tag = Me
                    Case Constantes.OM_MEZCLA
                        vFormPadre.dgvMezcla.Rows(vFormPadre.dgvMezcla.CurrentRow.Index).Cells("dgCodigoMezcla").Tag = Me
                End Select

                Visible = False
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                Exit Sub
            Else
                guardarMedicamentosNoPos()
            End If
        End If
    End Sub

    Public Sub guardarMedicamentosNoPos(Optional pSegundoPlano As Boolean = False)
        Try
            If (pSegundoPlano = False AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes) OrElse pSegundoPlano = True Then
                dgvDiagnostico.EndEdit()
                dtDiagnostico.AcceptChanges()
                objMedicamentos.modulo = modulo
                objMedicamentos.Codigo = txtCodigo.Text
                objMedicamentos.codigoPuntoActual = SesionActual.codigoEP
                objMedicamentos.registro = txtregistro.Text
                objMedicamentos.fechaSolicitud = fechasolicitud.Text
                objMedicamentos.codigoEquivalenciaUno = codigoEquivalenciaUno
                objMedicamentos.codigoEquivalenciaDos = codigoEquivalenciaDos
                objMedicamentos.resumen = txtresumen.Text
                objMedicamentos.rdsi = rdsi.Checked
                objMedicamentos.rdno = rdno.Checked
                objMedicamentos.respuesta = txtrespuesta.Text
                objMedicamentos.efecto = txtefecto.Text
                objMedicamentos.inicioefecto = txtinicioefecto.Text
                objMedicamentos.explicarazon = txtexplicarazon.Text
                objMedicamentos.cbocriterio = cbocriterio.SelectedIndex
                objMedicamentos.cbocriterio2 = cbocriterio2.SelectedIndex
                objMedicamentos.precaucion = txtprecaucion.Text
                objMedicamentos.pelipaciente = txtpelipaciente.Text
                objMedicamentos.cboposibilidad = cboposibilidadt.SelectedIndex
                objMedicamentos.reacciones = txtreacciones.Text
                objMedicamentos.contraindicaciones = txtcontraindicaciones.Text
                objMedicamentos.duraciontratamiento = txtduraciontratamiento.Text
                objMedicamentos.dosis = dosis.Text
                objMedicamentos.frecuencia = frecuencia.Text
                objMedicamentos.ndosis = txtndosis.Text
                objMedicamentos.usuarioInforme = usuarioInforme
                objMedicamentos.dtDiagnosticos = dgvDiagnostico.DataSource
                objMedicamentos.guardarMedicamentos()
                txtCodigo.Text = objMedicamentos.Codigo
                If txtCodigo.Text <> "" Then

                    CodigoTemporal = txtCodigo.Text
                    nRegistro = txtregistro.Text
                    usuarioActual = SesionActual.idUsuario
                    If pSegundoPlano = False Then
                        MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                        General.deshabilitarControles(Me)
                        General.habilitarBotones(Me.ToolStrip1)
                        btguardar.Enabled = False
                        btcancelar.Enabled = False
                        cargarDiagnosticosSolicitud()
                    End If
                    'guardarSegundoPlano()
                End If
            End If

        Catch ex As Exception
            general.manejoErrores(ex)
        End Try

    End Sub

    Private Sub deshabilitarControles()
        txtpaciente.ReadOnly = True
        txtidentificacion.ReadOnly = True
        txtedad.ReadOnly = True
        txtcontrato.ReadOnly = True
        txtsexo.ReadOnly = True
        lblentorno.ReadOnly = True
        txtcodigocontrato.ReadOnly = True
        txtnombre_medicamento.ReadOnly = True
        txtCodigo.ReadOnly = True
        txtregistro.ReadOnly = True
        txtDr.ReadOnly = True
        txtdatosingreso.ReadOnly = True
        txtEspecialidad.ReadOnly = True
        txtNombreMed_NoPOS.ReadOnly = True
        txtRegMed.ReadOnly = True
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(pEditar) Then
            btcancelar.Enabled = True
            btguardar.Enabled = True
            btimprimir.Enabled = False
            bteditar.Enabled = False
            btbuscar.Enabled = False
            btanular.Enabled = False
            cargarDiagnosticosSolicitud()
            General.habilitarControles(Me)
            dgvDiagnostico.Columns(0).ReadOnly = True
            dgvDiagnostico.Columns(1).ReadOnly = True
            dgvDiagnostico.Columns(2).ReadOnly = False
            deshabilitarControles()
            txtnombre_medicamento.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea cancelar este registro?", 32 + 1, "cancelar") = 1 Then
            General.deshabilitarControles(Me)
            btcancelar.Enabled = False
            bteditar.Enabled = False
            btanular.Enabled = False
            btimprimir.Enabled = False
            btbuscar.Enabled = True
            btguardar.Enabled = False
            General.limpiarControles(Me)
        End If
    End Sub

    Private Sub dgvDiagnostico_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDiagnostico.CellDoubleClick

    End Sub

    Private Sub rdno_CheckedChanged(sender As Object, e As EventArgs) Handles rdno.CheckedChanged
        If rdno.Checked = True Then
            txtnombre_medicamento.ReadOnly = True
            txtexplicarazon.ReadOnly = True
            txtexplicarazon.Clear()
            codigoEquivalenciaDos = ""
            txtnombre_medicamento.Clear()
        Else
            txtnombre_medicamento.ReadOnly = True
            txtexplicarazon.ReadOnly = False
        End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(pAnular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then


                If modulo = Constantes.AM Then
                    respuestan = General.anularRegistro(Consultas.ANULAR_SOLICITUD_MED_NOPOS_R & txtCodigo.Text & "," & SesionActual.idUsuario & "," & SesionActual.codigoEP)
                ElseIf modulo = Constantes.AF Then
                    respuestan = General.anularRegistro(Consultas.ANULAR_SOLICITUD_MED_NOPOS_RR & txtCodigo.Text & "," & SesionActual.idUsuario)
                Else
                    respuestan = General.anularRegistro(Consultas.ANULAR_SOLICITUD_MED_NOPOS & txtCodigo.Text & "," & SesionActual.idUsuario & "," & SesionActual.codigoEP)
                End If
                If respuestan = True Then
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    btanular.Enabled = False
                    General.limpiarControles(Me)
                    General.deshabilitarControles(Me)
                    btguardar.Enabled = False
                    bteditar.Enabled = False
                    btcancelar.Enabled = False
                    btimprimir.Enabled = False
                End If
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub CargarSolicMedicamentosNoPos()
        cargarPacientes()
        cargarDiagnosticosSolicitud()
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click

        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try

            objMedicamentos.registro = txtregistro.Text
            objMedicamentos.Codigo = txtCodigo.Text
            objMedicamentos.imprimirReporte()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub txtndosis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtndosis.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub

    Private Sub txtduraciontratamiento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtduraciontratamiento.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub

    Private Sub dosis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dosis.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub

    Private Sub rdsi_CheckedChanged(sender As Object, e As EventArgs) Handles rdsi.CheckedChanged
    End Sub

    Private Sub frecuencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles frecuencia.KeyPress

    End Sub


    Private Sub cargarDatosAutomaticos()
        objMedicamentos.codigoEquivalenciaUno = codigoEquivalenciaUno
        objMedicamentos.cargarDatosAutomaticos()
        codigoEquivalenciaDos = objMedicamentos.codigoEquivalenciaDos
        txtnombre_medicamento.Text = objMedicamentos.nombreMedicamento
        txtresumen.Text = objMedicamentos.resumen
        txtexplicarazon.Text = objMedicamentos.explicarazon
        txtefecto.Text = objMedicamentos.efecto
        txtinicioefecto.Text = objMedicamentos.inicioefecto
        'txtpresentacion.Text = objMedicamentos.presentacion
        txtduraciontratamiento.Text = objMedicamentos.duraciontratamiento
        txtndosis.Text = objMedicamentos.ndosis
        rdsi.Checked = objMedicamentos.rdsi
        rdno.Checked = objMedicamentos.rdno

    End Sub

    Private Sub cargarInvima()
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(codigoEquivalenciaUno)
        General.llenarTabla(Consultas.SOLIC_MED_NOPOS_CARGAR_INVIMA, params, dt)
        If dt.Rows.Count > 0 Then
            txtregistro_invima.Text = dt.Rows(0).Item("Registro sanitario")
            txtpresentacion.Text = dt.Rows(0).Item("Presentacion")
        End If
    End Sub

    Private Sub cargarDiagnosticosEvo()
        objMedicamentos.modulo = modulo
        objMedicamentos.registro = txtregistro.Text
        objMedicamentos.cargarDiagnosticoEvo()
        dgvDiagnostico.DataSource = objMedicamentos.dtDiagnosticos
        dgvDiagnostico.Columns("Codigo_Evo").Visible = False
    End Sub

    Private Sub cargarDemasRegistros()
        objMedicamentos.Codigo = txtCodigo.Text
        objMedicamentos.modulo = modulo
        objMedicamentos.cargarDemasRegistro()
        txtrespuesta.Text = objMedicamentos.respuesta
        txtefecto.Text = objMedicamentos.efecto
        txtinicioefecto.Text = objMedicamentos.inicioefecto
        txtexplicarazon.Text = objMedicamentos.explicarazon
        cbocriterio.SelectedItem = objMedicamentos.cbocriterio
        cbocriterio2.SelectedItem = objMedicamentos.cbocriterio2
        txtprecaucion.Text = objMedicamentos.precaucion
        txtpelipaciente.Text = objMedicamentos.pelipaciente
        cboposibilidadt.SelectedItem = objMedicamentos.cboposibilidad
        txtreacciones.Text = objMedicamentos.reacciones
        txtcontraindicaciones.Text = objMedicamentos.contraindicaciones
        txtduraciontratamiento.Text = objMedicamentos.duraciontratamiento
        dosis.Text = objMedicamentos.dosis
        frecuencia.Text = objMedicamentos.frecuencia
        txtndosis.Text = objMedicamentos.ndosis
        txtpresentacion.Text = objMedicamentos.presentacion
        txtregistro_invima.Text = objMedicamentos.registroInvima
        fechasolicitud.Text = objMedicamentos.fechaSolicitud
        usuarioInforme = objMedicamentos.usuarioInforme
        rdsi.Checked = objMedicamentos.rdsi
        rdno.Checked = objMedicamentos.rdno
        txtresumen.Text = objMedicamentos.resumen
    End Sub

    Private Sub cargarDiagnosticosSolicitud()
        objMedicamentos.Codigo = txtCodigo.Text
        objMedicamentos.modulo = modulo
        objMedicamentos.cargarDiagnosticoSolicitud()
        If objMedicamentos.dtDiagnosticos.Rows.Count > 0 Then
            dgvDiagnostico.DataSource = objMedicamentos.dtDiagnosticos
            dgvDiagnostico.Columns("Codigo_Evo").Visible = False
        End If
    End Sub

    Public Sub habilitarControles()
        txtresumen.ReadOnly = False
        txtrespuesta.ReadOnly = False
        txtreacciones.ReadOnly = False
        txtpelipaciente.ReadOnly = False
        txtprecaucion.ReadOnly = False
        dosis.ReadOnly = False
        txtndosis.ReadOnly = False
        frecuencia.ReadOnly = False
        txtefecto.ReadOnly = False
        txtexplicarazon.ReadOnly = False
        cbocriterio.Enabled = True
        cbocriterio2.Enabled = True
        cboposibilidadt.Enabled = True
        txtinicioefecto.ReadOnly = False
        txtcontraindicaciones.ReadOnly = False
        rdno.Enabled = True
        rdsi.Enabled = True
        txtnombre_medicamento.ReadOnly = False
    End Sub

    Public Sub cargarMedicamento(pCodigo As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        Dim consultaCargar As String
        If modulo = Constantes.AM Then
            consultaCargar = Consultas.SOLICITUD_MEDICAMENTO_NOPOS_CARGAR_R
        ElseIf modulo = Constantes.AF Then
            consultaCargar = Consultas.SOLICITUD_MEDICAMENTO_NOPOS_CARGAR_RR
        Else
            consultaCargar = Consultas.SOLICITUD_MEDICAMENTO_NOPOS_CARGAR
        End If
        General.llenarTabla(consultaCargar, params, dt)
        If dt.Rows.Count > 0 Then
            txtCodigo.Text = dt.Rows(0).Item("codigo").ToString
            txtregistro.Text = dt.Rows(0).Item("Numero Registro").ToString
            txtNombreMed_NoPOS.Text = dt.Rows(0).Item("Medicamento no POS").ToString
            txtnombre_medicamento.Text = dt.Rows(0).Item("Medicamento a Reemplazar").ToString
            codigoEquivalenciaUno = dt.Rows(0).Item("Codigo Interno 1").ToString
            codigoEquivalenciaDos = dt.Rows(0).Item("Codigo Interno 2").ToString

            If txtCodigo.Text <> "" Then
                cargarPacientes()
                CargarSolicMedicamentosNoPos()
                cargarDemasRegistros()
                cargarMedico()
                cargarDiagnosticosSolicitud()
                bteditar.Enabled = True
                btimprimir.Enabled = True
                btcancelar.Enabled = False
                btanular.Enabled = True


                General.deshabilitarControles(Me)
                txtnombre_medicamento.Enabled = True
            End If
        End If
    End Sub


    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(pBuscar) Then
            Dim params As New List(Of String)
            params.Add(Nothing)
            params.Add(SesionActual.codigoEP)
            Dim consultaCargar As String
            If modulo = Constantes.AM Then
                consultaCargar = Consultas.SOLICITUD_MEDICAMENTO_NOPOS_R
            ElseIf modulo = Constantes.AF Then
                consultaCargar = Consultas.SOLICITUD_MEDICAMENTO_NOPOS_RR
            Else
                consultaCargar = Consultas.SOLICITUD_MEDICAMENTO_NOPOS
            End If
            General.buscarElemento(consultaCargar, params,
                         AddressOf cargarMedicamento,
                         TitulosForm.BUSQUEDA_SOLICITUD_MEDICAMENTO_NOPOS, False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Public Sub cargarDatosParaSolicitud(usuario As Integer, equivalencia As Integer, nombreEquivalencia As String, tipo As Integer, ByRef vFormPadre As Form_Historia_clinica)
        General.limpiarControles(Me)
        txtregistro.Text = vFormPadre.txtRegistro.Text
        usuarioInforme = usuario
        tipoDetalleOM = tipo
        codigoEquivalenciaUno = equivalencia
        txtNombreMed_NoPOS.Text = nombreEquivalencia
        Me.vFormPadre = vFormPadre
        modulo = vFormPadre.Tag.Modulo
        cargarInvima()

        If String.IsNullOrEmpty(txtNombreMed_NoPOS.Text) Then
            Dispose()
            Exit Sub
        End If
        cargarPacienteH()
        cargarDiagnosticosEvo()
        cargarDatosAutomaticos()
        cargarMedico()
        txtCodigo.Clear()
        cbocriterio.SelectedIndex = 0
        cbocriterio2.SelectedIndex = 0
        cboposibilidadt.SelectedIndex = 0

        btguardar.Enabled = True
        btbuscar.Enabled = False
        bteditar.Enabled = False
        btanular.Enabled = False
        btcancelar.Enabled = False

        General.habilitarControles(Me)

        deshabilitarControles()
        habilitarControles()

        fechasolicitud.Text = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        txtnombre_medicamento.ReadOnly = True
        dgvDiagnostico.ReadOnly = False
        txtpresentacion.ReadOnly = True
        txtregistro_invima.ReadOnly = True
        dgvDiagnostico.Columns(0).ReadOnly = True
        dgvDiagnostico.Columns(1).ReadOnly = True
        dgvDiagnostico.Columns(2).ReadOnly = False

        ShowDialog()
    End Sub
End Class