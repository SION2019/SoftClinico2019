Public Class Form_Infeccion_IH
    Dim codigoEvo As Integer
    Dim dtIH, dtIHDC As New DataTable
    Dim perG As New Buscar_Permisos_generales
    Dim reporte As New ftp_reportes
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If Combomedico.SelectedIndex < 1 Then
            MsgBox("Debe escoger un médico", MsgBoxStyle.Information)
        ElseIf MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Dim objInfeccionIH_D As New InfeccionIhBLL

            Try
                Txtcodigo.Text = objInfeccionIH_D.guardarInfeccionIH(crearInfeccionIH(), SesionActual.idUsuario)
                General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                btimprimir.Enabled = True
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
    Private Sub vent_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles vent.CheckedChanged
        If vent.Checked = False Then
            dtvent.Visible = False
        Else
            dtvent.Visible = True
        End If
    End Sub

    Private Sub cvc_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cvc.CheckedChanged
        If cvc.Checked = False Then
            dtcvc.Visible = False
        Else
            dtcvc.Visible = True
        End If
    End Sub

    Private Sub sondaV_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles sondaV.CheckedChanged
        If sondaV.Checked = False Then
            dtsondav.Visible = False
        Else
            dtsondav.Visible = True
        End If
    End Sub

    Private Sub sondaN_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles sondaN.CheckedChanged
        If sondaN.Checked = False Then
            dtsondaN.Visible = False
        Else
            dtsondaN.Visible = True
        End If
    End Sub
    Private Sub enlazarTabla()

        Dim A, A1, A2, A3, B, B1, B2, B3 As New DataColumn

        A.ColumnName = "Codigo_criterio"
        A.DataType = Type.GetType("System.String")
        dtIH.Columns.Add(A)

        A1.ColumnName = "Descripcion_criterio"
        A1.DataType = Type.GetType("System.String")
        dtIH.Columns.Add(A1)

        A2.ColumnName = "Respuesta"
        A2.DataType = Type.GetType("System.String")
        dtIH.Columns.Add(A2)

        With dgvDetalleInfeccion
            .Columns.Item(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(0).DataPropertyName = "Codigo_criterio"
            .Columns.Item(0).ReadOnly = True

            .Columns.Item(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(1).DataPropertyName = "Descripcion_criterio"
            .Columns.Item(1).ReadOnly = True

            .Columns.Item(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(2).DataPropertyName = "Respuesta"
            .Columns.Item(2).ReadOnly = False

        End With

        dgvDetalleInfeccion.DataSource = dtIH
        dgvDetalleInfeccion.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        '----
        B.ColumnName = "Código"
        B.DataType = Type.GetType("System.String")
        dtIHDC.Columns.Add(B)

        B1.ColumnName = "Descripción"
        B1.DataType = Type.GetType("System.String")
        dtIHDC.Columns.Add(B1)

        With dgvunion
            .Columns.Item(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(0).DataPropertyName = "Código"
            .Columns.Item(0).ReadOnly = True

            .Columns.Item(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(1).DataPropertyName = "Descripción"
            .Columns.Item(1).ReadOnly = True

        End With
        dgvunion.DataSource = dtIHDC
        dgvunion.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Public Function crearInfeccionIH() As InfeccionIH
        Dim aislamiento As String
        Dim objInfeccionIH As New InfeccionIH

        If rno.Checked = False Then
            aislamiento = "No"
        Else
            aislamiento = "Si"
        End If

        objInfeccionIH.codigoSolicitud = Txtcodigo.Text
        objInfeccionIH.nRegistro = txtregistro.Text
        objInfeccionIH.fechaSolicitud = fechaSolicitud.Value
        objInfeccionIH.medico = Combomedico.SelectedValue
        objInfeccionIH.motivo = motivoSolicitud.Text
        objInfeccionIH.codigoEvo = codigoEvo
        objInfeccionIH.fechaAnalisis = fechaanalisis.Value
        objInfeccionIH.analisis = textanalisis.Text
        objInfeccionIH.paquete = textpaquete.Text
        objInfeccionIH.infectologo = comboinfectologo.SelectedValue
        objInfeccionIH.neonatologo = comboneonatologo.SelectedValue
        objInfeccionIH.coordinadorNeonatos = combocoordinadorneo.SelectedValue
        objInfeccionIH.coordinadorAdulto = combocoordinadoradulto.SelectedValue
        objInfeccionIH.auditorCuentas = audicuentas.SelectedValue
        objInfeccionIH.auditorConcu = audicon.SelectedValue
        objInfeccionIH.coordinadorAdminis = coordinadoradmin.SelectedValue
        objInfeccionIH.fumador = fumador.Checked
        objInfeccionIH.diabetes = diabetes.Checked
        objInfeccionIH.medicamentos = medicamentos.Checked
        objInfeccionIH.menor1000 = menor.Checked
        objInfeccionIH.obesidad = obesidad.Checked
        objInfeccionIH.inmunoSupresion = Inmunosupresion.Checked
        objInfeccionIH.prematuro = prematuro.Checked
        objInfeccionIH.otros = otros.Checked
        objInfeccionIH.cvc = cvc.Checked
        objInfeccionIH.ventilacion = vent.Checked
        objInfeccionIH.sondaV = sondaV.Checked
        objInfeccionIH.sondaNasogastrica = sondaN.Checked
        objInfeccionIH.aislamiento = aislamiento
        objInfeccionIH.fechaCvc = dtcvc.Value
        objInfeccionIH.fechaVent = dtvent.Value
        objInfeccionIH.fechaSondaV = dtsondav.Value
        objInfeccionIH.fechaSondaN = dtsondaN.Value
        objInfeccionIH.fechaAlta = dtalta.Value
        objInfeccionIH.observacion = obser.Text
        objInfeccionIH.inicial = textinicial.Text
        objInfeccionIH.modificacion1 = m1.Text
        objInfeccionIH.modificacion2 = m2.Text
        objInfeccionIH.modificacion3 = m3.Text
        objInfeccionIH.justificacion1 = j1.Text
        objInfeccionIH.justificacion2 = j2.Text
        objInfeccionIH.justificacion3 = j3.Text
        objInfeccionIH.fechaMicro1 = dt1.Value
        objInfeccionIH.muestra1 = t1.Text
        objInfeccionIH.germen1 = g1.Text
        objInfeccionIH.fechaMicro2 = dt2.Value
        objInfeccionIH.muestra2 = t2.Text
        objInfeccionIH.germen2 = g2.Text
        objInfeccionIH.fechaMicro3 = dt3.Value
        objInfeccionIH.muestra3 = t3.Text
        objInfeccionIH.germen3 = g2.Text
        objInfeccionIH.fechaMicro4 = dt4.Value
        objInfeccionIH.muestra4 = t4.Text
        objInfeccionIH.germen4 = g4.Text
        objInfeccionIH.fechaMicro5 = dt5.Value
        objInfeccionIH.muestra5 = t5.Text
        objInfeccionIH.germen5 = g5.Text
        objInfeccionIH.fechaMicro6 = dt6.Value
        objInfeccionIH.muestra6 = t6.Text
        objInfeccionIH.germen6 = g6.Text

        For Each drFila As DataRow In dtIH.Rows
            Dim drRespuesta As DataRow = objInfeccionIH.dtRespuestas.NewRow

            drRespuesta.Item("codigo_solicitud") = objInfeccionIH.codigoSolicitud
            drRespuesta.Item("codigo_criterio") = drFila.Item("codigo_criterio")
            drRespuesta.Item("respuesta") = drFila.Item("respuesta")

            objInfeccionIH.dtRespuestas.Rows.Add(drRespuesta)
        Next

        Return objInfeccionIH
    End Function
    Public Sub cargarDiagnosticos(codigoEvolucion)
        codigoEvo = codigoEvolucion
        General.llenarTablaYdgv(Consultas.EVOLUCION_MEDICA_DIAGNOSTICA_CARGAR &
                                   codigoEvolucion, dtIHDC)

        With dgvunion
            .Columns("Estado").Visible = False
        End With
        cargardgvs()
    End Sub
    Public Sub cargardgvs()
        Dim consulta As String

        If Txtcodigo.Text = "" Then
            consulta = Consultas.IH_GRILLA_LLENAR
        Else
            consulta = Consultas.IH_GRILLA_CARGAR
        End If
        General.llenarTablaYdgv(consulta &
                                  "'" & txtregistro.Text & "'", dtIH)
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        General.formNuevo(TabControl1, ToolStrip1, btguardar, btcancelar)
        Txtcodigo.Clear()
        Combomedico.SelectedIndex = 0
        Combomedico.Enabled = True
        MsgBox("Por favor, seleccione a continuación la evolución médica.", MsgBoxStyle.Exclamation)
        Dim params As New List(Of String)
        params.Add(txtregistro.Text)

        General.buscarElemento(Consultas.LISTAR_EVOLUCIONES,
                               params,
                               AddressOf cargarDiagnosticos,
                               TitulosForm.BUSQUEDA_EVOLUCION,
                               False)
    End Sub
    Public Sub cargarDatos(pCodigo As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.IH_CARGAR, params, dt)

        Txtcodigo.Text = pCodigo
        motivoSolicitud.Text = dt.Rows(0).Item("Motivo").ToString()
        Combomedico.SelectedValue = dt.Rows(0).Item("Medico").ToString()
        codigoEvo = dt.Rows(0).Item("Codigo_Evo").ToString()
        fechaSolicitud.Value = dt.Rows(0).Item("Fecha_Solicitud").ToString()
        textpaquete.Text = dt.Rows(0).Item("Paquete").ToString()
        fumador.Checked = dt.Rows(0).Item("Fumador").ToString()
        diabetes.Checked = dt.Rows(0).Item("Diabetes").ToString()
        medicamentos.Checked = dt.Rows(0).Item("Medicamentos").ToString()
        menor.Checked = dt.Rows(0).Item("Menor1000").ToString()
        obesidad.Checked = dt.Rows(0).Item("Obesidad").ToString()
        Inmunosupresion.Checked = dt.Rows(0).Item("inmunosupresion").ToString()
        prematuro.Checked = dt.Rows(0).Item("Prematuro").ToString()
        otros.Checked = dt.Rows(0).Item("Otros").ToString()
        cvc.Checked = dt.Rows(0).Item("CVC").ToString()
        vent.Checked = dt.Rows(0).Item("Ventilacion").ToString()
        sondaN.Checked = dt.Rows(0).Item("SondaN").ToString()
        If dt.Rows(0).Item("Aislamiento").ToString() = "NO" Then
            rno.Checked = True
        Else
            rsi.Checked = True
        End If
        dtcvc.Value = dt.Rows(0).Item("FechaCVC").ToString()
        dtvent.Value = dt.Rows(0).Item("FechaVent").ToString()
        dtsondav.Value = dt.Rows(0).Item("FechaSondaV").ToString()
        dtsondaN.Value = dt.Rows(0).Item("FechaSondaN").ToString()
        dtalta.Value = dt.Rows(0).Item("FechaAlta").ToString()
        obser.Text = dt.Rows(0).Item("Observacion").ToString()
        textinicial.Text = dt.Rows(0).Item("Inicial").ToString()
        m1.Text = dt.Rows(0).Item("Modificacion1").ToString()
        m2.Text = dt.Rows(0).Item("Modificacion2").ToString()
        m3.Text = dt.Rows(0).Item("Modificacion3").ToString()
        j1.Text = dt.Rows(0).Item("Justificacion1").ToString()
        j2.Text = dt.Rows(0).Item("Justificacion2").ToString()
        j3.Text = dt.Rows(0).Item("Justificacion3").ToString()
        dt1.Value = dt.Rows(0).Item("Fechamicro1").ToString()
        g1.Text = dt.Rows(0).Item("Germen1").ToString()
        t1.Text = dt.Rows(0).Item("Muestra1").ToString()
        dt2.Value = dt.Rows(0).Item("Fechamicro2").ToString()
        g2.Text = dt.Rows(0).Item("Germen2").ToString()
        t2.Text = dt.Rows(0).Item("Muestra2").ToString()
        dt3.Value = dt.Rows(0).Item("Fechamicro3").ToString()
        g3.Text = dt.Rows(0).Item("Germen3").ToString()
        t3.Text = dt.Rows(0).Item("Muestra3").ToString()
        dt4.Value = dt.Rows(0).Item("Fechamicro4").ToString()
        g4.Text = dt.Rows(0).Item("Germen4").ToString()
        t4.Text = dt.Rows(0).Item("Muestra4").ToString()
        dt5.Value = dt.Rows(0).Item("Fechamicro5").ToString()
        g5.Text = dt.Rows(0).Item("Germen5").ToString()
        t5.Text = dt.Rows(0).Item("Muestra5").ToString()
        dt6.Value = dt.Rows(0).Item("Fechamicro6").ToString()
        g6.Text = dt.Rows(0).Item("Germen6").ToString()
        t6.Text = dt.Rows(0).Item("Muestra6").ToString()
        comboinfectologo.SelectedValue = dt.Rows(0).Item("infectologo").ToString()
        comboneonatologo.SelectedValue = dt.Rows(0).Item("neonatologo").ToString()
        coordinadoradmin.SelectedValue = dt.Rows(0).Item("coordinador_Adminis").ToString()
        combocoordinadoradulto.SelectedValue = dt.Rows(0).Item("coordinador_adulto").ToString()
        combocoordinadorneo.SelectedValue = dt.Rows(0).Item("coordinador_Neonatos").ToString()
        audicuentas.SelectedValue = dt.Rows(0).Item("Auditor_Cuentas").ToString()
        audicon.SelectedValue = dt.Rows(0).Item("Auditor_Concu").ToString()
        textanalisis.Text = dt.Rows(0).Item("Analisis").ToString()

        cargarDiagnosticos(codigoEvo)
        General.habilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btguardar.Enabled = False
        btcancelar.Enabled = False
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Dim params As New List(Of String)
        params.Add(txtregistro.Text)

        General.buscarElemento(Consultas.IH_BUSCAR,
                               params,
                               AddressOf cargarDatos,
                               TitulosForm.BUSQUEDA_EVOLUCION,
                               False, 0, True)
    End Sub

    Private Sub Form_Infeccion_IH_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
        Try
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim params As New List(Of String)

                params.Add(Txtcodigo.Text)
                params.Add(SesionActual.idUsuario)

                General.ejecutarSQL(Consultas.ANULAR_INFECCION_IH, params)

                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)

            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(TabControl1, ToolStrip1, btnuevo, btbuscar)
        Txtcodigo.Clear()
        'Combomedico.SelectedIndex = 0
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
        General.deshabilitarControles(Groupac)
    End Sub
    Public Sub cargarInformacionPaciente(ByVal registro As Integer)
        Dim dt As New DataTable
        General.llenarTablaYdgv(Consultas.BUSQUEDA_ADMISION_CARGAR & registro, dt)
        txtregistro.Text = registro
        txtpaciente.Text = dt.Rows(0).Item("Paciente")
        fechaadmision.Text = dt.Rows(0).Item("Fecha_Admision")
    End Sub
    Private Sub cargarComboInfectologo()
        Dim params As New List(Of String)
        params.Add(Constantes.CARGO_INFECTOLOGIA)
        params.Add(SesionActual.idEmpresa)
        General.cargarCombo(ConsultasAmbu.CARGO_AM_BUSCAR, params, "Empleado", "Id_empleado", comboinfectologo)
    End Sub
    Private Sub cargarComboMedico()
        Dim params As New List(Of String)
        params.Add(Constantes.CARGO_INTENSIVISTA & "," & Constantes.CARGO_MEDICO_GENERAL_UCI & "," & Constantes.CARGO_PEDIATRA & "," & Constantes.CARGO_INTERNISTA)
        params.Add(SesionActual.idEmpresa)
        General.cargarCombo(ConsultasAmbu.CARGO_AM_BUSCAR, params, "Empleado", "Id_empleado", Combomedico)
    End Sub
    Private Sub cargarComboCoordAdulto()
        Dim params As New List(Of String)
        params.Add(Constantes.CARGO_INTENSIVISTA & "," & Constantes.CARGO_MEDICO_GENERAL_UCI & "," & Constantes.CARGO_INTERNISTA)
        params.Add(SesionActual.idEmpresa)
        General.cargarCombo(ConsultasAmbu.CARGO_AM_BUSCAR, params, "Empleado", "Id_empleado", combocoordinadoradulto)
    End Sub
    Private Sub cargarComboCoordNeonatal()
        Dim params As New List(Of String)
        params.Add(Constantes.CARGO_PEDIATRA & "," & Constantes.CARGO_MEDICO_GENERAL_UCI)
        params.Add(SesionActual.idEmpresa)
        General.cargarCombo(ConsultasAmbu.CARGO_AM_BUSCAR, params, "Empleado", "Id_empleado", combocoordinadorneo)
    End Sub
    Private Sub cargarComboCoordAdmin()
        Dim params As New List(Of String)
        params.Add(Constantes.CARGO_COORDINADOR_ADMINISTRATIVO)
        params.Add(SesionActual.idEmpresa)
        General.cargarCombo(ConsultasAmbu.CARGO_AM_BUSCAR, params, "Empleado", "Id_empleado", coordinadoradmin)
    End Sub
    Private Sub cargarComboNeonatologo()
        Dim params As New List(Of String)
        params.Add(Constantes.CARGO_PEDIATRA)
        params.Add(SesionActual.idEmpresa)
        General.cargarCombo(ConsultasAmbu.CARGO_AM_BUSCAR, params, "Empleado", "Id_empleado", comboneonatologo)
    End Sub
    Private Sub cargarComboAuditCuentas()
        Dim params As New List(Of String)
        params.Add(Constantes.CARGO_AUDITOR_MEDICO)
        params.Add(SesionActual.idEmpresa)
        General.cargarCombo(ConsultasAmbu.CARGO_AM_BUSCAR, params, "Empleado", "Id_empleado", audicuentas)
    End Sub
    Private Sub cargarComboAuditConcurrente()
        Dim params As New List(Of String)
        params.Add(Constantes.CARGO_AUDITOR_MEDICO)
        params.Add(SesionActual.idEmpresa)
        General.cargarCombo(ConsultasAmbu.CARGO_AM_BUSCAR, params, "Empleado", "Id_empleado", audicon)
    End Sub

    Private Sub Form_Infeccion_IH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name, Tag.modulo)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        Panel1.Enabled = True
        enlazarTabla()
        cargarComboInfectologo()
        cargarComboMedico()
        cargarComboCoordAdulto()
        cargarComboCoordNeonatal()
        cargarComboCoordAdmin()
        cargarComboNeonatologo()
        cargarComboAuditCuentas()
        cargarComboAuditConcurrente()
        General.deshabilitarControles(Me)
    End Sub
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Dim rptInfeccionIH As New rptInfeccionIH
        Try
            Cursor = Cursors.WaitCursor
            Funciones.getReporteNoFTP(rptInfeccionIH, "{VISTA_INFECCION_IH.Codigo_Solicitud} = " & Txtcodigo.Text & " AND {VISTA_INFECCION_IH.N_registro} = " & txtregistro.Text & "", "HC")
            Cursor = Cursors.Default
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

End Class