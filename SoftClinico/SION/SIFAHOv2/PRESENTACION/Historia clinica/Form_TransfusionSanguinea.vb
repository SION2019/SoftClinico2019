Imports System.Threading
Imports Celer

Public Class Form_TransfusionSanguinea
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim pTrabajarMedico, pTrabajarLab, pTrabajarEnfer As String
    Private codigoOrden, cantidad As Integer
    Private codigoProcedimiento As String
    Dim perG As New Buscar_Permisos_generales
    Dim dtLaboratorio As New DataTable
    Dim dtEnfermeria As New DataTable
    Dim dtEnfermeria2 As New DataTable
    Private moduloTemporal, modulo As String
    Dim guardarEn2doPlano As Thread
    Private comboboxColumn3, comboboxColumn, comboboxColumn2, comboboxColumn4 As Object
    Dim usuarioInforme, contadorDiag, CodigoTemporal, nRegistro, usuarioActual As Integer
    Dim activoAM, activoAF, respuestan As Boolean
    Dim consulta As String
    Dim vFormPadre As Form_Historia_clinica


    Public Sub datosPrincipales(form_Historia_clinica As Form_Historia_clinica, nRegistro As Integer)
        Me.vFormPadre = form_Historia_clinica
        Me.nRegistro = nRegistro
    End Sub

    Private Sub Form_TransfusionSanguinea_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        moduloTemporal = modulo
        activoAM = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AM & "'")
        activoAF = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AF & "'")
        Select Case modulo
            Case Constantes.HC
                Label1.Text = "SOLICITUD DE TRANSFUSIÓN DE SANGRE Y/O SUS COMPONENTES: HISTORIA CLÍNICA"
            Case Constantes.AM
                Label1.Text = "SOLICITUD DE TRANSFUSIÓN DE SANGRE Y/O SUS COMPONENTES: AUDITORÍA MÉDICA"
                lblmedico.Visible = True
                ComboMedico.Visible = True
                lblbacteriologo.Visible = True
                ComboBacteriologo.Visible = True


                If ComboMedico.DataSource = Nothing Then
                    Dim params As New List(Of String)
                    params.Add(Constantes.CARGO_MEDICO_GENERAL_UCI & "," & Constantes.CARGO_MEDICO_ESPECIALISTA & "," & Constantes.CARGO_NEFROLOGO & "," & Constantes.CARGO_NEONATALOGO & "," & Constantes.CARGO_NEUROLOGO & "," & Constantes.CARGO_INTENSIVISTA & "," & Constantes.CARGO_INTERNISTA)
                    params.Add(SesionActual.idEmpresa)
                    General.cargarCombo(ConsultasAmbu.CARGO_AM_BUSCAR, params, "Empleado", "Id_empleado", ComboMedico)
                End If
                If ComboBacteriologo.DataSource = Nothing Then
                    Dim params As New List(Of String)
                    params.Add(Constantes.CARGO_BACTERIOLOGO)
                    params.Add(SesionActual.idEmpresa)
                    General.cargarCombo(ConsultasAmbu.CARGO_AM_BUSCAR, params, "Empleado", "Id_empleado", ComboBacteriologo)
                End If
                If ComboEnfermera.DataSource = Nothing Then
                    Dim params As New List(Of String)
                    params.Add(Constantes.CARGO_AUXILIAR_DE_ENFERMERIA & "," & Constantes.CARGO_JEFE_DE_ENFERMERIA)
                    params.Add(SesionActual.idEmpresa)
                    General.cargarCombo(ConsultasAmbu.CARGO_AM_BUSCAR, params, "Empleado", "Id_empleado", ComboEnfermera)
                End If
            Case Constantes.AF
                Label1.Text = "SOLICITUD DE TRANSFUSIÓN DE SANGRE Y/O SUS COMPONENTES: AUDITORÍA FACTURACIÓN"
                lblmedico.Visible = True
                ComboMedico.Visible = True
                lblbacteriologo.Visible = True
                ComboBacteriologo.Visible = True


                If ComboMedico.DataSource = Nothing Then
                    Dim params As New List(Of String)
                    params.Add(Constantes.CARGO_MEDICO_GENERAL_UCI & "," & Constantes.CARGO_MEDICO_ESPECIALISTA & "," & Constantes.CARGO_NEFROLOGO & "," & Constantes.CARGO_NEONATALOGO & "," & Constantes.CARGO_NEUROLOGO & "," & Constantes.CARGO_INTENSIVISTA & "," & Constantes.CARGO_INTERNISTA)
                    params.Add(SesionActual.idEmpresa)
                    General.cargarCombo(ConsultasAmbu.CARGO_AM_BUSCAR, params, "Empleado", "Id_empleado", ComboMedico)
                End If
                If ComboBacteriologo.DataSource = Nothing Then
                    Dim params As New List(Of String)
                    params.Add(Constantes.CARGO_BACTERIOLOGO)
                    params.Add(SesionActual.idEmpresa)
                    General.cargarCombo(ConsultasAmbu.CARGO_AM_BUSCAR, params, "Empleado", "Id_empleado", ComboBacteriologo)
                End If
                If ComboEnfermera.DataSource = Nothing Then
                    Dim params As New List(Of String)
                    params.Add(Constantes.CARGO_AUXILIAR_DE_ENFERMERIA & "," & Constantes.CARGO_JEFE_DE_ENFERMERIA)
                    params.Add(SesionActual.idEmpresa)
                    General.cargarCombo(ConsultasAmbu.CARGO_AM_BUSCAR, params, "Empleado", "Id_empleado", ComboEnfermera)
                End If
            Case Else
                Label1.Text = "SOLICITUD DE TRANSFUSIÓN DE SANGRE Y/O SUS COMPONENTES: HISTORIA CLÍNICA"
        End Select
        If dtLaboratorio.Columns.Count = 0 Then
            permiso_general = perG.buscarPermisoGeneral(Name, moduloTemporal)
            Pnuevo = permiso_general & "pp" & "01"
            Peditar = permiso_general & "pp" & "02"
            Panular = permiso_general & "pp" & "03"
            PBuscar = permiso_general & "pp" & "04"
            pTrabajarMedico = permiso_general & "pp" & "05"
            pTrabajarLab = permiso_general & "pp" & "06"
            pTrabajarEnfer = permiso_general & "pp" & "07"
            General.deshabilitarControles(Me)
            General.deshabilitarBotones(ToolStrip1)
            If SesionActual.tienePermiso(pTrabajarMedico) Then
                General.habilitarControles(paginaMedico)
                General.habilitarControles(gbDatosBasicos)
                txtidentificacion.ReadOnly = True
                txtpaciente.ReadOnly = True
                txtedad.ReadOnly = True
                txtorden.ReadOnly = True
                txtfecha.Value = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
                txtfechayhora.Value = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
                If txtcodigo.Text = "" Then
                    General.deshabilitarBotones(ToolStrip1)
                    btguardar.Enabled = True
                    btcancelar.Enabled = False
                Else
                    General.deshabilitarBotones(ToolStrip1)
                    bteditar.Enabled = True

                End If
                TabControl1.SelectedIndex = 0
            End If
            cargarMedico()

            If SesionActual.tienePermiso(pTrabajarLab) OrElse SesionActual.tienePermiso(pTrabajarEnfer) Then

                If SesionActual.tienePermiso(pTrabajarMedico) And txtcodigo.Text = "" Then
                    MsgBox("Debe ser diligenciado primero por el medico", MsgBoxStyle.Exclamation)
                    Exit Sub
                ElseIf SesionActual.tienePermiso(pTrabajarMedico) Then
                    General.deshabilitarBotones(ToolStrip1)

                    bteditar.Enabled = True
                End If
            End If



            comboboxColumn = dgvlab.Columns("gs")
            comboboxColumn.Items.Add("A")
            comboboxColumn.Items.Add("B")
            comboboxColumn.Items.Add("O")
            comboboxColumn.Items.Add("AB")

            comboboxColumn2 = dgvlab.Columns("RH")
            comboboxColumn2.Items.Add("Positivo")
            comboboxColumn2.Items.Add("Negativo")

            establecerTablaLaboratorio()
            With dgvlab

                .Columns.Item("Codigo").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("Codigo").DataPropertyName = "Codigo Bolsa"

                .Columns.Item("bolsa").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("bolsa").DataPropertyName = "bolsa"

                .Columns.Item("gs").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("gs").DataPropertyName = "gs"

                .Columns.Item("rh").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("rh").DataPropertyName = "rh"

                .Columns.Item("sello").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("sello").DataPropertyName = "sello"

                .Columns.Item("prueba").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("prueba").DataPropertyName = "prueba"

                .Columns.Item("fecha").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("fecha").DataPropertyName = "fecha"

                .Columns.Item("usuario_creacion").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("usuario_creacion").DataPropertyName = "usuario_creacion"

                .Columns.Item("usuario_real").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("usuario_real").DataPropertyName = "usuario_real"
            End With

            dgvlab.AutoGenerateColumns = False
            dgvlab.DataSource = dtLaboratorio
            dgvlab.ReadOnly = True
            dgvlab.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvlab.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            establecerTablaEnfermera()


            With dgvenf

                .Columns.Item("CodigoE").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("CodigoE").DataPropertyName = "Codigo Bolsa"

                .Columns.Item("bolsae").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("bolsae").DataPropertyName = "bolsae"

                .Columns.Item("aplicada").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("aplicada").DataPropertyName = "aplicada"

                .Columns.Item("pa").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("pa").DataPropertyName = "pa"

                .Columns.Item("pulso").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("pulso").DataPropertyName = "pulso"

                .Columns.Item("temperatura").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("temperatura").DataPropertyName = "temperatura"

                .Columns.Item("fechae1").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("fechae1").DataPropertyName = "fechae1"

                .Columns.Item("fechae2").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("fechae2").DataPropertyName = "fechae2"

                .Columns.Item("respondio").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("respondio").DataPropertyName = "respondio"

                .Columns.Item("usuario_creacione").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("usuario_creacione").DataPropertyName = "usuario_creacione"

                .Columns.Item("usuario_real1").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("usuario_real1").DataPropertyName = "usuario_real"
            End With

            dgvenf.AutoGenerateColumns = False
            dgvenf.DataSource = dtEnfermeria
            dgvenf.ReadOnly = True
            dgvenf.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvenf.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            establecerTablaEnfermera2()

            With dgvenfr
                .Columns.Item("CodigoEn").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("CodigoEn").DataPropertyName = "Codigo Bolsa"


                .Columns.Item("bolsar").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("bolsar").DataPropertyName = "bolsar"

                .Columns.Item("hora").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("hora").DataPropertyName = "hora"

                .Columns.Item("par").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("par").DataPropertyName = "par"

                .Columns.Item("pulsor").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("pulsor").DataPropertyName = "pulsor"

                .Columns.Item("temperaturar").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("temperaturar").DataPropertyName = "temperaturar"

                .Columns.Item("describalo").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("describalo").DataPropertyName = "describalo"

                .Columns.Item("rechaza").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("rechaza").DataPropertyName = "rechaza"

                .Columns.Item("observaciones").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("observaciones").DataPropertyName = "observaciones"

                .Columns.Item("usuario_creacioner").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("usuario_creacioner").DataPropertyName = "usuario_creacioner"

                .Columns.Item("usuario_real2").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item("usuario_real2").DataPropertyName = "usuario_real"

            End With

            dgvenfr.AutoGenerateColumns = False
            dgvenfr.DataSource = dtEnfermeria2
            dgvenfr.ReadOnly = True
            dgvenfr.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvenfr.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            cargarLaboratorio()
            cargarLaboratorio2()
            cargarEnfermera2()
            cargarEnfermera()
            If txtcodigo.Text = "" Then
                combosanguineo.SelectedIndex = 0
                Comborhp.SelectedIndex = 0
            End If

            If txtcodigo.Text <> "" Then
                btguardar.Enabled = False
                bteditar.Enabled = True
                btcancelar.Enabled = False
                btimprimir.Enabled = True
                General.deshabilitarControles(paginaMedico)
                General.deshabilitarControles(gbDatosBasicos)
                General.deshabilitarControles(paginaLab)
                General.deshabilitarControles(paginaEnf)
            End If

            If SesionActual.tienePermiso(pTrabajarMedico) AndAlso txtcodigo.Text = "" AndAlso SesionActual.tienePermiso(pTrabajarLab) Then
                General.habilitarControles(paginaLab)
            End If
            If SesionActual.tienePermiso(pTrabajarMedico) AndAlso txtcodigo.Text = "" AndAlso SesionActual.tienePermiso(pTrabajarEnfer) Then
                General.habilitarControles(paginaEnf)
            End If
        End If
        If Not SesionActual.tienePermiso(pTrabajarMedico) AndAlso Not SesionActual.tienePermiso(pTrabajarLab) AndAlso Not String.IsNullOrEmpty(txtcodigo.Text) Then
            If SesionActual.tienePermiso(pTrabajarEnfer) And String.IsNullOrEmpty(dgvlab.Rows(dgvlab.CurrentCell.RowIndex).Cells("bolsa").Value) And SesionActual.codigoEP = Constantes.CODIGOEP_TRANSFUSION Then
                MsgBox("Debe ser diligenciado la pestaña de laboratorio", MsgBoxStyle.Exclamation)
                bteditar.Enabled = False
                Exit Sub
            End If
        End If
        ComboEnfermera.Visible = False
        dgvlab.Columns("codigo").Visible = False
        dgvenf.Columns("codigoe").Visible = False
        dgvenfr.Columns("codigoen").Visible = False
    End Sub

    Public Sub establecerTablaEnfermera2()
        Dim esrt0, eerst1, eerst2, eerst3, eerst4, eerst5, eerst6, eerst7, eerst8, eerst9, eerst10 As New DataColumn

        esrt0.ColumnName = "CodigoEn"
        esrt0.DataType = Type.GetType("System.String")
        esrt0.DefaultValue = String.Empty
        dtEnfermeria2.Columns.Add(esrt0)

        eerst1.ColumnName = "bolsar"
        eerst1.DataType = Type.GetType("System.String")
        eerst1.DefaultValue = String.Empty
        dtEnfermeria2.Columns.Add(eerst1)

        eerst2.ColumnName = "hora"
        eerst2.DataType = Type.GetType("System.DateTime")
        eerst2.DefaultValue = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        dtEnfermeria2.Columns.Add(eerst2)

        eerst3.ColumnName = "par"
        eerst3.DataType = Type.GetType("System.String")
        eerst3.DefaultValue = String.Empty
        dtEnfermeria2.Columns.Add(eerst3)

        eerst4.ColumnName = "pulsor"
        eerst4.DataType = Type.GetType("System.String")
        eerst4.DefaultValue = String.Empty
        dtEnfermeria2.Columns.Add(eerst4)

        eerst5.ColumnName = "temperaturar"
        eerst5.DataType = Type.GetType("System.String")
        eerst5.DefaultValue = String.Empty
        dtEnfermeria2.Columns.Add(eerst5)


        eerst6.ColumnName = "describalo"
        eerst6.DataType = Type.GetType("System.String")
        eerst6.DefaultValue = String.Empty
        dtEnfermeria2.Columns.Add(eerst6)

        eerst7.ColumnName = "rechaza"
        eerst7.DataType = Type.GetType("System.String")
        eerst7.DefaultValue = String.Empty
        dtEnfermeria2.Columns.Add(eerst7)

        eerst8.ColumnName = "observaciones"
        eerst8.DataType = Type.GetType("System.String")
        eerst8.DefaultValue = String.Empty
        dtEnfermeria2.Columns.Add(eerst8)

        eerst9.ColumnName = "usuario_creacioner"
        eerst9.DataType = Type.GetType("System.String")
        eerst9.DefaultValue = String.Empty
        dtEnfermeria2.Columns.Add(eerst9)

        eerst10.ColumnName = "usuario_real2"
        eerst10.DataType = Type.GetType("System.String")
        eerst10.DefaultValue = String.Empty
        dtEnfermeria2.Columns.Add(eerst10)
    End Sub


    Public Sub establecerTablaEnfermera()

        Dim eswt0, eest1, eest2, eest3, eest4, eest5, eest6, eest7, eest8, eest9, eest10 As New DataColumn

        eswt0.ColumnName = "CodigoEn"
        eswt0.DataType = Type.GetType("System.String")
        eswt0.DefaultValue = String.Empty
        dtEnfermeria.Columns.Add(eswt0)

        eest1.ColumnName = "bolsae"
        eest1.DataType = Type.GetType("System.String")
        eest1.DefaultValue = String.Empty
        dtEnfermeria.Columns.Add(eest1)

        eest2.ColumnName = "aplicada"
        eest2.DataType = Type.GetType("System.String")
        eest2.DefaultValue = String.Empty
        dtEnfermeria.Columns.Add(eest2)

        eest3.ColumnName = "pa"
        eest3.DataType = Type.GetType("System.String")
        eest3.DefaultValue = String.Empty
        dtEnfermeria.Columns.Add(eest3)

        eest4.ColumnName = "pulso"
        eest4.DataType = Type.GetType("System.String")
        eest4.DefaultValue = String.Empty
        dtEnfermeria.Columns.Add(eest4)

        eest5.ColumnName = "temperatura"
        eest5.DataType = Type.GetType("System.String")
        eest5.DefaultValue = String.Empty
        dtEnfermeria.Columns.Add(eest5)

        eest6.ColumnName = "fechae1"
        eest6.DataType = Type.GetType("System.DateTime")
        eest6.DefaultValue = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        dtEnfermeria.Columns.Add(eest6)

        eest7.ColumnName = "fechae2"
        eest7.DataType = Type.GetType("System.DateTime")
        eest7.DefaultValue = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        dtEnfermeria.Columns.Add(eest7)

        comboboxColumn3 = dgvenf.Columns("respondio")
        comboboxColumn3.Items.Add("SI")
        comboboxColumn3.Items.Add("NO")

        eest8.ColumnName = "respondio"
        eest8.DataType = Type.GetType("System.String")
        eest8.DefaultValue = "SI"
        dtEnfermeria.Columns.Add(eest8)

        eest9.ColumnName = "usuario_creacione"
        eest9.DataType = Type.GetType("System.String")
        dtEnfermeria.Columns.Add(eest9)

        eest10.ColumnName = "usuario_real1"
        eest10.DataType = Type.GetType("System.String")
        dtEnfermeria.Columns.Add(eest10)

        eest1 = Nothing : eest2 = Nothing : eest3 = Nothing : eest4 = Nothing : eest5 = Nothing
    End Sub

    Public Sub establecerTablaLaboratorio()

        Dim est0, est1, est2, est3, est4, est5, est6, est7, est8, est9 As New DataColumn

        est0.ColumnName = "Codigo"
        est0.DataType = Type.GetType("System.String")
        est0.DefaultValue = String.Empty
        dtLaboratorio.Columns.Add(est0)

        est1.ColumnName = "bolsa"
        est1.DataType = Type.GetType("System.String")
        est1.DefaultValue = String.Empty
        dtLaboratorio.Columns.Add(est1)

        est6.ColumnName = "gs"
        est6.DataType = Type.GetType("System.String")
        est6.DefaultValue = "A"
        dtLaboratorio.Columns.Add(est6)

        est7.ColumnName = "RH"
        est7.DataType = Type.GetType("System.String")
        est7.DefaultValue = "Positivo"
        dtLaboratorio.Columns.Add(est7)

        est2.ColumnName = "sello"
        est2.DataType = Type.GetType("System.String")
        est2.DefaultValue = String.Empty
        dtLaboratorio.Columns.Add(est2)

        est3.ColumnName = "prueba"
        est3.DataType = Type.GetType("System.String")
        est3.DefaultValue = String.Empty
        dtLaboratorio.Columns.Add(est3)

        est4.ColumnName = "fecha"
        est4.DataType = Type.GetType("System.DateTime")
        est4.DefaultValue = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        dtLaboratorio.Columns.Add(est4)

        est5.ColumnName = "usuario_creacion"
        est5.DataType = Type.GetType("System.String")
        dtLaboratorio.Columns.Add(est5)

        est9.ColumnName = "usuario_real"
        est9.DataType = Type.GetType("System.String")
        dtLaboratorio.Columns.Add(est9)

        est1 = Nothing : est2 = Nothing : est3 = Nothing : est4 = Nothing : est5 = Nothing : est9 = Nothing
    End Sub

    Public Sub cargarDatosPaciente(codOrden As String, identificacion As String, paciente As String, edad As String)
        txtorden.Text = codOrden
        txtidentificacion.Text = identificacion
        txtpaciente.Text = paciente
        txtedad.Text = edad
    End Sub


    Public Function guardarTransfusion() As TransfusionSanguinea
        Dim objTransfusion = New TransfusionSanguinea

        objTransfusion.CodigoTransfusion = txtcodigo.Text
        objTransfusion.CodigoOrden = txtorden.Text
        objTransfusion.codigoProcedimiento = codigoProcedimiento
        objTransfusion.Cuantas = txtcuantas.Text
        objTransfusion.Diagnostico = txtdiagnostico.Text
        objTransfusion.fechaSala = txtfechayhora.Value
        objTransfusion.globuloRoja = rglobulo.Checked
        objTransfusion.sangre = rsangre.Checked
        objTransfusion.globulRoroja2 = rglobulo2.Checked
        objTransfusion.GrupoSanguineo = combosanguineo.SelectedItem
        objTransfusion.Otros = rotros.Checked
        objTransfusion.Plaquetas = rplaquetas.Checked
        objTransfusion.Plasma = rplasma.Checked
        objTransfusion.Fecha = txtfecha.Value
        objTransfusion.Rh = Comborhp.SelectedItem
        objTransfusion.transfusionesPrevia = rsi1.Checked
        objTransfusion.RASangre = rsi2.Checked
        objTransfusion.RAplasma = rsi3.Checked
        objTransfusion.RAOtros = rsi4.Checked
        objTransfusion.RAnacidoMuerto = rsi5.Checked
        objTransfusion.RAAborto = rsi6.Checked
        objTransfusion.RAEnfHemoliticaRNfeto = rsi7.Checked
        objTransfusion.Transfundir = txtsolicita.Text
        objTransfusion.Reserva = txtreserva.Text
        objTransfusion.Sala = txtsala.Text
        objTransfusion.codigoEp = SesionActual.codigoEP
        objTransfusion.Usuario = SesionActual.idUsuario
        Select Case modulo

            Case Constantes.AM
                objTransfusion.usuarioreal = ComboMedico.SelectedValue
            Case Constantes.AF
                objTransfusion.usuarioreal = ComboMedico.SelectedValue
        End Select
        Return objTransfusion
    End Function

    Public Function guardarLaboratorio2() As TransfusionSanguinea
        Dim objTransfusion = New TransfusionSanguinea

        objTransfusion.rastreo = txtrastreo.Text
        objTransfusion.observaciones = txtobservaciones.Text
        objTransfusion.codigoEp = SesionActual.codigoEP


        For Each drFila As DataRow In dtLaboratorio.Rows

            If drFila.Item("bolsa").ToString <> String.Empty Then
                Dim drRespuesta As DataRow = objTransfusion.dtLaboratorio.NewRow

                drRespuesta.Item("Codigo_TS") = txtcodigo.Text
                drRespuesta.Item("Codigo Bolsa") = drFila.Item("Codigo Bolsa")
                drRespuesta.Item("bolsa") = drFila.Item("bolsa")
                drRespuesta.Item("gs") = drFila.Item("gs")
                drRespuesta.Item("rh") = drFila.Item("RH")
                drRespuesta.Item("sello") = drFila.Item("sello")
                drRespuesta.Item("prueba") = drFila.Item("prueba")
                drRespuesta.Item("fecha") = drFila.Item("fecha")
                drRespuesta.Item("usuario_creacion") = SesionActual.idUsuario
                Select Case modulo
                    Case Constantes.AM
                        drRespuesta.Item("usuario_real") = ComboBacteriologo.SelectedValue
                    Case Constantes.AF
                        drRespuesta.Item("usuario_real") = ComboBacteriologo.SelectedValue
                End Select

                objTransfusion.dtLaboratorio.Rows.Add(drRespuesta)
            End If
        Next

        Return objTransfusion
    End Function

    Public Function guardarEnfermera2() As TransfusionSanguinea
        Dim objTransfusion = New TransfusionSanguinea
        objTransfusion.codigoEp = SesionActual.codigoEP
        For Each drFila As DataRow In dtEnfermeria.Rows

            If drFila.Item("bolsae").ToString <> String.Empty Then
                Dim drRespuesta As DataRow = objTransfusion.dtEnfermera.NewRow

                drRespuesta.Item("Codigo_TS") = txtcodigo.Text
                drRespuesta.Item("Codigo Bolsa") = drFila.Item("Codigo Bolsa")
                drRespuesta.Item("bolsae") = drFila.Item("bolsae")
                drRespuesta.Item("aplicada") = drFila.Item("aplicada")
                drRespuesta.Item("pa") = drFila.Item("pa")
                drRespuesta.Item("pulso") = drFila.Item("pulso")
                drRespuesta.Item("temperatura") = Funciones.castFromDbItemVacio(drFila.Item("temperatura"))
                drRespuesta.Item("fechae1") = drFila.Item("fechae1")
                drRespuesta.Item("fechae2") = drFila.Item("fechae2")
                drRespuesta.Item("respondio") = drFila.Item("respondio")
                drRespuesta.Item("usuario_creacione") = SesionActual.idUsuario
                Select Case modulo
                    Case Constantes.AM
                        drRespuesta.Item("usuario_real") = ComboBacteriologo.SelectedValue
                    Case Constantes.AF
                        drRespuesta.Item("usuario_real") = ComboBacteriologo.SelectedValue
                End Select
                objTransfusion.dtEnfermera.Rows.Add(drRespuesta)
            End If
        Next


        For Each drFila As DataRow In dtEnfermeria2.Rows
            If drFila.Item("bolsar").ToString <> String.Empty Then
                Dim drRespuesta As DataRow = objTransfusion.dtenfermera2.NewRow

                drRespuesta.Item("Codigo_TS") = txtcodigo.Text
                drRespuesta.Item("Codigo Bolsa") = drFila.Item("Codigo Bolsa")
                drRespuesta.Item("bolsar") = drFila.Item("bolsar")
                drRespuesta.Item("hora") = drFila.Item("hora")
                drRespuesta.Item("par") = drFila.Item("par")
                drRespuesta.Item("pulsor") = drFila.Item("pulsor")
                drRespuesta.Item("temperaturar") = drFila.Item("temperaturar")
                drRespuesta.Item("describalo") = drFila.Item("describalo").ToString
                drRespuesta.Item("rechaza") = drFila.Item("rechaza")
                drRespuesta.Item("observaciones") = drFila.Item("observaciones")
                drRespuesta.Item("usuario_creacioner") = SesionActual.idUsuario
                Select Case modulo
                    Case Constantes.AM
                        drRespuesta.Item("usuario_real") = ComboEnfermera.SelectedValue
                    Case Constantes.AF
                        drRespuesta.Item("usuario_real") = ComboEnfermera.SelectedValue
                End Select

                objTransfusion.dtenfermera2.Rows.Add(drRespuesta)
            End If
        Next

        Return objTransfusion
    End Function

    Public Function validarMedico()
        If SesionActual.tienePermiso(pTrabajarMedico) Then Return True
        If combosanguineo.SelectedIndex = 0 Then
            MsgBox("Por favor seleccione Grupo sanguineo", MsgBoxStyle.Exclamation)
            combosanguineo.Focus()
            Return False
        ElseIf Comborhp.SelectedIndex = 0 Then
            MsgBox("Por favor seleccione el RH", MsgBoxStyle.Exclamation)
            Comborhp.Focus()
            Return False
        ElseIf txtdiagnostico.Text = "" Then
            MsgBox("El campo diagnostico se encuentra vacio", MsgBoxStyle.Exclamation)
            txtdiagnostico.Focus()
            Return False
        ElseIf txtsala.Text = "" Then
            MsgBox("El campo Transfundir (SALA) se encuentra vacio", MsgBoxStyle.Exclamation)
            txtsala.Focus()
            Return False
        ElseIf rsi1.Checked = True And txtcuantas.Text = "" Then
            MsgBox("El campo Transfusion previas (Cuantas) se encuentra vacio", MsgBoxStyle.Exclamation)
            txtcuantas.Focus()
            Return False
        End If
        Return True
    End Function

    Public Sub cargarMedico()
        Select Case modulo
            Case Constantes.HC
                consulta = Consultas.TRANSFUSION_SANGUINEA_MED_BUSCAR
            Case Constantes.AM
                consulta = Consultas.TRANSFUSION_SANGUINEA_MED_BUSCAR_R
            Case Constantes.AF
                consulta = Consultas.TRANSFUSION_SANGUINEA_MED_BUSCAR_RR
        End Select
        Dim ordenCargar As Integer
        If txtorden.Text = "" Then
            ordenCargar = -1
        Else
            ordenCargar = txtorden.Text
        End If
        Dim lista As New List(Of String)
        lista.Add(ordenCargar)
        lista.Add(codigoProcedimiento)
        Dim dt As New DataTable
        General.llenarTabla(consulta, lista, dt)
        If dt.Rows.Count > 0 Then
            txtorden.Text = dt.Rows(0).Item("Codigo_orden")
            codigoProcedimiento = dt.Rows(0).Item("codigo_Procedimiento")
            txtcodigo.Text = dt.Rows(0).Item("Codigo_TS")
            txtfecha.Value = dt.Rows(0).Item("fecha")
            combosanguineo.SelectedItem = dt.Rows(0).Item("Grupo_sanguineo")
            Comborhp.SelectedItem = dt.Rows(0).Item("rh")
            txtsolicita.Text = dt.Rows(0).Item("Transfundir")
            txtreserva.Text = dt.Rows(0).Item("Reserva")
            rsangre.Checked = dt.Rows(0).Item("sangre")
            rglobulo2.Checked = dt.Rows(0).Item("Globulo_roja2")
            rglobulo.Checked = dt.Rows(0).Item("Globulo_roja")
            rplasma.Checked = dt.Rows(0).Item("Plasma")
            rplaquetas.Checked = dt.Rows(0).Item("Plaquetas")
            rotros.Checked = dt.Rows(0).Item("Otros")
            txtsala.Text = dt.Rows(0).Item("Sala")
            txtfechayhora.Value = dt.Rows(0).Item("Fecha_sala")
            rsi1.Checked = dt.Rows(0).Item("Transfusiones_previa")

            Select Case modulo
                Case Constantes.AM
                    ComboMedico.SelectedValue = dt.Rows(0).Item("Usuario_real")
                Case Constantes.AF
                    ComboMedico.SelectedValue = dt.Rows(0).Item("Usuario_real")
            End Select

            If rsi1.Checked = True Then
                rno1.Checked = False
            Else
                rno1.Checked = True
            End If
            txtcuantas.Text = dt.Rows(0).Item("Cuantas")
            rsi2.Checked = dt.Rows(0).Item("R_A_Sangre")
            If rsi2.Checked = True Then
                rno2.Checked = False
            Else
                rno2.Checked = True
            End If
            rsi3.Checked = dt.Rows(0).Item("R_A_plasma")
            If rsi3.Checked = True Then
                rno3.Checked = False
            Else
                rno3.Checked = True
            End If
            rsi4.Checked = dt.Rows(0).Item("R_A_Otros")
            If rsi4.Checked = True Then
                rno4.Checked = False
            Else
                rno4.Checked = True
            End If
            rsi5.Checked = dt.Rows(0).Item("R_A_nacido_muerto")
            If rsi5.Checked = True Then
                rno5.Checked = False
            Else
                rno5.Checked = True
            End If
            rsi6.Checked = dt.Rows(0).Item("R_A_Aborto")
            If rsi6.Checked = True Then
                rno6.Checked = False
            Else
                rno6.Checked = True
            End If
            rsi7.Checked = dt.Rows(0).Item("R_A_Enf_Hemolitica_RN_feto")
            If rsi7.Checked = True Then
                rno7.Checked = False
            Else
                rno7.Checked = True
            End If
            txtdiagnostico.Text = dt.Rows(0).Item("Diagnostico")
        End If
    End Sub

    Public Sub cargarLaboratorio()
        Select Case modulo
            Case Constantes.HC
                consulta = Consultas.TRANSFUSION_SANGUINEA_LAB_BUSCAR
            Case Constantes.AM
                consulta = Consultas.TRANSFUSION_SANGUINEA_LAB_BUSCAR_R
            Case Constantes.AF
                consulta = Consultas.TRANSFUSION_SANGUINEA_LAB_BUSCAR_RR
        End Select

        Dim lista As New List(Of String)
        lista.Add(txtcodigo.Text)

        General.llenarTabla(consulta, lista, dtLaboratorio)
        If dtLaboratorio.Rows.Count >= 0 Then
            Dim filasAgregar As Integer
            filasAgregar = cantidad - dtLaboratorio.Rows.Count
            Funciones.agregarFilas(dtLaboratorio, filasAgregar)
            Select Case modulo
                Case Constantes.AM

                    ComboBacteriologo.SelectedValue = dtLaboratorio.Rows(0).Item("usuario_real")

                Case Constantes.AF

                    ComboBacteriologo.SelectedValue = dtLaboratorio.Rows(0).Item("usuario_real")

            End Select
        End If

    End Sub

    Public Sub cargarLaboratorio2()
        Select Case modulo
            Case Constantes.HC
                consulta = Consultas.TRANSFUSION_SANGUINEA_LAB2_BUSCAR
            Case Constantes.AM
                consulta = Consultas.TRANSFUSION_SANGUINEA_LAB2_BUSCAR_R
            Case Constantes.AF
                consulta = Consultas.TRANSFUSION_SANGUINEA_LAB2_BUSCAR_RR
        End Select

        Dim lista As New List(Of String)
        lista.Add(txtcodigo.Text)
        Dim dt As New DataTable
        General.llenarTabla(consulta, lista, dt)
        If dt.Rows.Count > 0 Then
            txtrastreo.Text = dt.Rows(0).Item("rastreo")
            txtobservaciones.Text = dt.Rows(0).Item("observaciones")
        End If

    End Sub

    Public Sub cargarEnfermera()
        Select Case modulo
            Case Constantes.HC
                consulta = Consultas.TRANSFUSION_SANGUINEA_ENF_BUSCAR
            Case Constantes.AM
                consulta = Consultas.TRANSFUSION_SANGUINEA_ENF_BUSCAR_R
            Case Constantes.AF
                consulta = Consultas.TRANSFUSION_SANGUINEA_ENF_BUSCAR_RR
        End Select

        Dim lista As New List(Of String)
        lista.Add(txtcodigo.Text)

        General.llenarTabla(consulta, lista, dtEnfermeria)
        If dtEnfermeria.Rows.Count >= 0 Then
            Dim filasAgregar As Integer
            filasAgregar = cantidad - dtEnfermeria.Rows.Count
            Funciones.agregarFilas(dtEnfermeria, filasAgregar)

            Select Case modulo
                Case Constantes.AM

                    ComboEnfermera.SelectedValue = dtEnfermeria.Rows(0).Item("usuario_real")

                Case Constantes.AF

                    ComboEnfermera.SelectedValue = dtEnfermeria.Rows(0).Item("usuario_real")
            End Select
        End If

    End Sub

    Public Sub cargarEnfermera2()
        Select Case modulo
            Case Constantes.HC
                consulta = Consultas.TRANSFUSION_SANGUINEA_ENF2_BUSCAR
            Case Constantes.AM
                consulta = Consultas.TRANSFUSION_SANGUINEA_ENF2_BUSCAR_R
            Case Constantes.AF
                consulta = Consultas.TRANSFUSION_SANGUINEA_ENF2_BUSCAR_RR
        End Select

        Dim lista As New List(Of String)
        lista.Add(txtcodigo.Text)

        General.llenarTabla(consulta, lista, dtEnfermeria2)

        If dtEnfermeria2.Rows.Count >= 0 Then
            Dim filasAgregar As Integer
            filasAgregar = cantidad - dtEnfermeria2.Rows.Count
            Funciones.agregarFilas(dtEnfermeria2, filasAgregar)

            Select Case modulo
                Case Constantes.AM
                    If ComboEnfermera.SelectedValue <> -1 Then
                        ComboEnfermera.SelectedValue = dtEnfermeria2.Rows(0).Item("usuario_real")
                    End If
                Case Constantes.AF
                    If ComboEnfermera.SelectedValue <> -1 Then
                        ComboEnfermera.SelectedValue = dtEnfermeria2.Rows(0).Item("usuario_real")
                    End If
            End Select
        End If
    End Sub

    Public Function validarLaboratorio()
        dgvlab.EndEdit()
        dtLaboratorio.AcceptChanges()
        If TabControl1.SelectedIndex = 1 Then
            For i = 0 To dtLaboratorio.Rows.Count - 1
                If dtLaboratorio.Rows(i).Item("bolsa").ToString <> "" AndAlso dtLaboratorio.Rows(i).Item("sello").ToString = "" AndAlso
                   dtLaboratorio.Rows(i).Item("prueba").ToString = "" Then
                    MsgBox("Por favor si esta colocando un numero de bolsa los demas campos no pueden estar vacio", MsgBoxStyle.Exclamation)
                    Return False
                ElseIf dtLaboratorio.Rows(i).Item("bolsa").ToString = "" AndAlso dtLaboratorio.Rows(i).Item("sello").ToString <> "" AndAlso
                    dtLaboratorio.Rows(i).Item("prueba").ToString <> "" Then
                    MsgBox("Por favor coloque el numero de bolsa", MsgBoxStyle.Exclamation)
                    Return False
                End If
            Next
        End If

        Return True
    End Function

    Public Function validarEnfermera()
        dgvenf.EndEdit()
        dgvenfr.EndEdit()
        dtEnfermeria.AcceptChanges()
        dtEnfermeria2.AcceptChanges()
        If TabControl1.SelectedIndex = 2 Then
            For i = 0 To dtEnfermeria.Rows.Count - 1
                If dtEnfermeria.Rows(i).Item("bolsae").ToString <> "" AndAlso dtEnfermeria.Rows(i).Item("pulso").ToString = "" AndAlso
                   dtEnfermeria.Rows(i).Item("pa").ToString = "" AndAlso dtEnfermeria.Rows(i).Item("temperatura").ToString = "" Then
                    MsgBox("Por favor si esta colocando un numero de bolsa los demas campos no pueden estar vacio", MsgBoxStyle.Exclamation)
                    Return False
                ElseIf dtEnfermeria.Rows(i).Item("bolsae").ToString = "" AndAlso dtEnfermeria.Rows(i).Item("pulso").ToString <> "" AndAlso
                   dtEnfermeria.Rows(i).Item("pa").ToString <> "" AndAlso dtEnfermeria.Rows(i).Item("temperatura").ToString <> "" Then
                    MsgBox("Por favor coloque el numero de bolsa", MsgBoxStyle.Exclamation)
                    Return False
                ElseIf dtEnfermeria2.Rows(i).Item("bolsar").ToString <> "" AndAlso dtEnfermeria2.Rows(i).Item("pulsor").ToString = "" AndAlso
                       dtEnfermeria2.Rows(i).Item("par").ToString = "" AndAlso dtEnfermeria2.Rows(i).Item("temperaturar").ToString = "" Then
                    MsgBox("Por favor si esta colocando un numero de bolsa los demas campos no pueden estar vacio", MsgBoxStyle.Exclamation)
                    Return False
                ElseIf dtEnfermeria2.Rows(i).Item("bolsar").ToString = "" AndAlso dtEnfermeria2.Rows(i).Item("pulsor").ToString <> "" AndAlso
                   dtEnfermeria2.Rows(i).Item("par").ToString <> "" AndAlso dtEnfermeria2.Rows(i).Item("temperaturar").ToString <> "" Then
                    MsgBox("Por favor coloque el numero de bolsa", MsgBoxStyle.Exclamation)
                    Return False
                End If
            Next
        End If
        Return True
    End Function

    Public Sub guardarMedico(Optional pSegundoPlano As Boolean = False, Optional codigoOrdenSegundoPlano As Integer = -1)
        Dim objTransfusion_D As New TransfusionSanguineaBLL
        Dim objTransfusion As TransfusionSanguinea

        Try
            If (pSegundoPlano = False AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes) OrElse pSegundoPlano = True Then
                If pSegundoPlano = True Then
                    txtorden.Text = codigoOrdenSegundoPlano
                End If
                btimprimir.Enabled = False
                objTransfusion = guardarTransfusion()
                objTransfusion_D.crearTransfusion(modulo, objTransfusion)
                txtcodigo.Text = objTransfusion.CodigoTransfusion
                guardarLaboratorio()
                guardarEnfermera()
                CodigoTemporal = txtcodigo.Text
                usuarioActual = SesionActual.idUsuario
                If pSegundoPlano = False Then
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    btguardar.Enabled = False
                    bteditar.Enabled = True
                    btcancelar.Enabled = False
                    btimprimir.Enabled = True
                    cargarLaboratorio()
                    cargarEnfermera2()
                    cargarEnfermera()
                    General.deshabilitarControles(paginaMedico)
                    General.deshabilitarControles(gbDatosBasicos)
                    General.deshabilitarControles(paginaLab)
                    General.deshabilitarControles(paginaEnf)
                End If
                'guardarSegundoPlano()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dgvlab_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvlab.DataError

    End Sub

    Private Sub dgvenf_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvenf.DataError

    End Sub

    Private Sub rno1_CheckedChanged(sender As Object, e As EventArgs) Handles rno1.CheckedChanged
        If rno1.Checked = True Then
            txtcuantas.Enabled = False
            txtcuantas.Text = 0
        Else
            txtcuantas.Enabled = True

        End If
    End Sub

    Private Sub dgvlab_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvlab.CellEndEdit
        dgvlab.EndEdit()
        dtLaboratorio.AcceptChanges()

        For i = 0 To dgvlab.RowCount - 1
            If dgvlab.Rows(i).Cells("bolsa").Value <> "" Then
                If i > 0 Then
                    If dgvlab.Rows(i).Cells("bolsa").Value = dgvlab.Rows(i - 1).Cells("bolsa").Value AndAlso dgvlab.Rows(i).Cells("bolsa").Value <> "" Then
                        MsgBox("El numero de bolsa no se puede repetir", MsgBoxStyle.Exclamation)
                        dgvlab.Rows(i).Cells("bolsa").Value = ""
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub dgvenf_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvenf.CellEndEdit
        dgvenf.EndEdit()
        dtEnfermeria.AcceptChanges()
        For i = 0 To dgvenf.RowCount - 1
            If dgvenf.Rows(i).Cells("bolsae").Value <> "" Then

                If i > 0 Then
                    If dgvenf.Rows(i).Cells("bolsae").Value = dgvenf.Rows(i - 1).Cells("bolsae").Value Then
                        MsgBox("El numero de bolsa no se puede repetir", MsgBoxStyle.Exclamation)
                        dgvenf.Rows(i).Cells("bolsae").Value = ""
                    End If
                End If
            End If

        Next

    End Sub

    Private Sub dgvenfr_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvenfr.CellEndEdit
        dgvenfr.EndEdit()
        dtEnfermeria2.AcceptChanges()

        For i = 0 To dgvenfr.RowCount - 1
            If dgvenfr.Rows(i).Cells("bolsar").Value <> "" Then
                If i > 0 Then
                    If dgvenfr.Rows(i).Cells("bolsar").Value = dgvenfr.Rows(i - 1).Cells("bolsar").Value Then
                        MsgBox("El numero de bolsa no se puede repetir", MsgBoxStyle.Exclamation)
                        dgvenfr.Rows(i).Cells("bolsar").Value = ""
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub txtsolicita_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtsolicita.KeyPress, txtreserva.KeyPress, txtcuantas.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub

    Private Sub txtsolicita_TextChanged(sender As Object, e As EventArgs) Handles txtsolicita.TextChanged, txtreserva.TextChanged
        validarCantidades()
    End Sub

    Private Function validarCantidades() As Boolean
        Dim cantidadSolicitada, cantidadReservada As Integer
        If txtsolicita.Text = "" Then
            cantidadSolicitada = 0
        Else
            cantidadSolicitada = txtsolicita.Text
        End If
        If txtreserva.Text = "" Then
            cantidadReservada = 0
        Else
            cantidadReservada = txtreserva.Text
        End If
        If cantidad <cantidadSolicitada + cantidadReservada Then
            MsgBox("Cantidad solicitada mas reservada no puede ser mayor a la enviada: " & cantidad, MsgBoxStyle.Exclamation)
            txtsolicita.Text = ""
            txtreserva.Text = ""
            Return False
        End If
        Return True
    End Function



    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try
            Dim objTransfusion As New TransfusionSanguinea
            objTransfusion.modulo = modulo
            objTransfusion.CodigoTransfusion = txtcodigo.Text
            objTransfusion.imprimirReporte()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub



    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea cancelar este registro?", 32 + 1, "cancelar") = 1 Then

            If txtcodigo.Text = "" Then
                If SesionActual.tienePermiso(pTrabajarMedico ) Then
                    MsgBox("Por favor  debe diligenciar el formato", MsgBoxStyle.Exclamation)
                End If
            Else
                General.deshabilitarControles(Me)
                General.deshabilitarBotones(ToolStrip1)
                bteditar.Enabled = True
                btimprimir.Enabled = True
            End If
        End If

    End Sub

    Private Sub Form_TransfusionSanguinea_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If txtcodigo.Text = "" And IsNothing(vFormPadre.dgvHemoderivado.Rows(vFormPadre.dgvHemoderivado.CurrentRow.Index).Cells("dgFormatoHemo").Tag) Then
            If SesionActual.tienePermiso(pTrabajarMedico) Then
                If MsgBox("No ha guardado, Si continua no se enviará este hemoderivado ¿Desea continuar?  ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    e.Cancel = True
                Else
                    vFormPadre.eliminaFilaDt(vFormPadre.dgvHemoderivado.DataSource, vFormPadre.dgvHemoderivado.CurrentRow.Index)
                End If
            ElseIf Not SesionActual.tienePermiso(pTrabajarMedico) Then
                If MsgBox("No ha guardado, Si continua no se enviará este hemoderivado ¿Desea continuar?  ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    e.Cancel = True
                Else
                    vFormPadre.eliminaFilaDt(vFormPadre.dgvHemoderivado.DataSource, vFormPadre.dgvHemoderivado.CurrentRow.Index)
                End If
            End If
        ElseIf txtcodigo.Text = "" And IsNothing(vFormPadre.dgvHemoderivado.Rows(vFormPadre.dgvHemoderivado.CurrentRow.Index).Cells("dgFormatoHemo").Tag) = False Then
            Visible = False
            e.Cancel = True
        End If

    End Sub

    Public Sub guardarLaboratorio()
        Dim objTransfusion_D As New TransfusionSanguineaBLL
        Dim objTransfusion As TransfusionSanguinea

        Try
            objTransfusion = guardarLaboratorio2()
            If txtcodigo.Text <> "" Then
                objTransfusion.CodigoTransfusion = txtcodigo.Text
            End If
            objTransfusion_D.crearLaboratorio(modulo, objTransfusion)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        TabControl1.SelectedIndex = 1
        If SesionActual.tienePermiso(pTrabajarMedico) Then
            General.habilitarControles(paginaMedico)
            General.habilitarControles(gbDatosBasicos)
            General.deshabilitarBotones(ToolStrip1)
            btguardar.Enabled = True
            btcancelar.Enabled = True
            TabControl1.SelectedIndex = 0
            habilitarCampos()
        End If

        If SesionActual.tienePermiso(pTrabajarLab) And Not String.IsNullOrEmpty(txtcodigo.Text) Then
            General.habilitarControles(paginaLab)
            General.deshabilitarBotones(ToolStrip1)
            btguardar.Enabled = True
            btcancelar.Enabled = True
            TabControl1.SelectedIndex = 1
            deshabilitarCampos()
            dgvlab.Columns("codigo").Visible = False
            dgvenf.Columns("codigoe").Visible = False
            dgvenfr.Columns("codigoen").Visible = False

        End If
        If SesionActual.tienePermiso(pTrabajarEnfer) And Not String.IsNullOrEmpty(dgvlab.Rows(dgvlab.CurrentCell.RowIndex).Cells("bolsa").Value) Then
            General.habilitarControles(paginaEnf)
            General.deshabilitarBotones(ToolStrip1)
            btguardar.Enabled = True
            btcancelar.Enabled = True
            TabControl1.SelectedIndex = 2
            deshabilitarCampos()
            dgvlab.Columns("codigo").Visible = False
            dgvenf.Columns("codigoe").Visible = False
            dgvenfr.Columns("codigoen").Visible = False
        End If

        If SesionActual.tienePermiso(pTrabajarEnfer) AndAlso SesionActual.codigoEP <> Constantes.CODIGOEP_TRANSFUSION Then
            General.habilitarControles(paginaEnf)
            General.habilitarControles(paginaLab)
            General.deshabilitarBotones(ToolStrip1)
            btguardar.Enabled = True
            btcancelar.Enabled = True
            TabControl1.SelectedIndex = 2
            deshabilitarCampos()
            dgvlab.Columns("codigo").Visible = False
            dgvenf.Columns("codigoe").Visible = False
            dgvenfr.Columns("codigoen").Visible = False
        End If

        If SesionActual.tienePermiso(pTrabajarMedico) And (modulo = Constantes.AM Or modulo = Constantes.AF) Then
            General.habilitarControles(paginaMedico)
            General.habilitarControles(gbDatosBasicos)
            General.deshabilitarBotones(ToolStrip1)
            btguardar.Enabled = True
            btcancelar.Enabled = True
            habilitarCampos()
        End If
        bteditar.Enabled = False
    End Sub

    Public Sub habilitarCampos()
        rsangre.Enabled = True
        rglobulo.Enabled = True
        rglobulo2.Enabled = True
        rplasma.Enabled = True
        rplaquetas.Enabled = True
        rotros.Enabled = True
    End Sub
    Public Sub deshabilitarCampos()
        txtidentificacion.ReadOnly = True
        txtpaciente.ReadOnly = True
        txtfecha.Enabled = False
        txtedad.ReadOnly = True
        txtorden.ReadOnly = True
        RichTextBox1.ReadOnly = True
        RichTextBox2.ReadOnly = True
        Comborhp.Enabled = False
        combosanguineo.Enabled = False
        txtsolicita.ReadOnly = True
        txtreserva.ReadOnly = True
        rsangre.Enabled = False
        rglobulo.Enabled = False
        rglobulo2.Enabled = False
        rplasma.Enabled = False
        rplaquetas.Enabled = False
        rotros.Enabled = False
    End Sub
    Public Sub guardarEnfermera()
        Dim objTransfusion_D As New TransfusionSanguineaBLL
        Dim objTransfusion As TransfusionSanguinea

        Try
            objTransfusion = guardarEnfermera2()
            If txtcodigo.Text <> "" Then
                objTransfusion.CodigoTransfusion = txtcodigo.Text
            End If
            objTransfusion_D.crearEnfermera(modulo, objTransfusion)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub opcionesGrupo(tipo As Integer)
        Select Case tipo
            Case Constantes.GLOBULO_ROJO
                rplaquetas.Enabled = False
                rsangre.Checked = True
                rplasma.Enabled = False

            Case Constantes.PLAQUETA
                rplaquetas.Checked = True
                rplasma.Enabled = False
                rglobulo2.Enabled = False
                rsangre.Enabled = False
                rotros.Enabled = False
                rglobulo.Enabled = False
                Label92.Text = "Rastreo de anticuerpos irregulares:"
                txtrastreo.Location = New Point(232, 10)
            Case Constantes.PLASMA
                rplasma.Checked = True
                rplaquetas.Enabled = False
                rsangre.Enabled = False
                rotros.Enabled = False
                rglobulo.Enabled = False
                rglobulo2.Enabled = False
                Label92.Text = "Rastreo de anticuerpos irregulares:"
                txtrastreo.Location = New Point(232, 10)
        End Select
    End Sub


    Public Sub instanciaModulo(codmodulo As String, codProcedimiento As String, codCantidad As String, tipo As Integer)
        modulo = codmodulo
        codigoProcedimiento = codProcedimiento
        cantidad = codCantidad
        opcionesGrupo(tipo)

    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgvenf.EndEdit()
        dgvenfr.EndEdit()
        dgvlab.EndEdit()
        dgvlab.CommitEdit(DataGridViewDataErrorContexts.Commit)
        dtEnfermeria.AcceptChanges()
        dtEnfermeria2.AcceptChanges()
        dtLaboratorio.AcceptChanges()
        Try
            If String.IsNullOrEmpty(txtsolicita.Text) Then
                MsgBox("Digite la cantidad solicitada", MsgBoxStyle.Exclamation)
                txtsolicita.Focus()
            ElseIf ComboMedico.Visible = True And ComboMedico.SelectedIndex <= 0 Then
                MsgBox("Por favor seleccione al medico", MsgBoxStyle.Exclamation)
                ComboMedico.Focus()
            ElseIf ComboBacteriologo.Visible = True And ComboBacteriologo.SelectedIndex <= 0 Then
                MsgBox("Por favor seleccione a la bacteriologo", MsgBoxStyle.Exclamation)
                ComboBacteriologo.Focus()
            ElseIf combosanguineo.SelectedIndex = -1 Then
                MsgBox("Por favor seleccione el grupo sanguineo", MsgBoxStyle.Exclamation)
                combosanguineo.Focus()
            ElseIf Comborhp.SelectedIndex = -1 Then
                MsgBox("Por favor seleccione el RH", MsgBoxStyle.Exclamation)
                Comborhp.Focus()
            ElseIf String.IsNullOrEmpty(txtsala.Text) Then
                MsgBox("Digite la sala donde se va transfundir", MsgBoxStyle.Exclamation)
                txtsala.Focus()
            ElseIf String.IsNullOrEmpty(txtdiagnostico.Text) Then
                MsgBox("Digite el diagnostico", MsgBoxStyle.Exclamation)
                txtdiagnostico.Focus()
            Else
                If validarMedico() AndAlso validarLaboratorio() AndAlso validarEnfermera() And validarCantidades() Then
                    If String.IsNullOrEmpty(txtcodigo.Text) Then
                        vFormPadre.dgvHemoderivado.Rows(vFormPadre.dgvHemoderivado.CurrentRow.Index).Cells("dgFormatoHemo").Tag = Me
                        vFormPadre.dgvHemoderivado.Rows(vFormPadre.dgvHemoderivado.CurrentCell.RowIndex).Cells("dgFormatoHemo").Value = My.Resources.ok2
                        vFormPadre.dgvHemoderivado.Rows(vFormPadre.dgvHemoderivado.CurrentCell.RowIndex).Cells("dgFormatoHemo").Style.BackColor = Color.LightGreen
                        Visible = False
                        MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                        Exit Sub
                    Else
                        guardarMedico()
                    End If
                End If
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub

    Sub mostrarInfo(pSmg As String, pColorFuenteLetra As Color, pColorFondoPanel As Color, Optional pOcultar As Boolean = False)
        If InvokeRequired Then
            Invoke(New MethodInvoker(Sub() mostrarInfo(pSmg, pColorFuenteLetra, pColorFondoPanel, pOcultar)))
        Else
            If pOcultar Then
                PnlInfo.Visible = False
            Else
                lbinfo.Text = pSmg.ToUpper : lbinfo.ForeColor = pColorFuenteLetra : PictureBox2.Image = My.Resources.info
                PnlInfo.BackColor = pColorFondoPanel : PnlInfo.BringToFront() : PnlInfo.Visible = True
                '  System.Media.SystemSounds.Asterisk.Play()
            End If
        End If
    End Sub


End Class