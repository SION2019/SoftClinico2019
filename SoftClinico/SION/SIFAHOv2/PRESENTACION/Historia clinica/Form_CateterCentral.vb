Public Class Form_CateterCentral
    Dim dtAnte, dtDespues As New DataTable
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim perG As New Buscar_Permisos_generales
    Dim reporte As New ftp_reportes
    Dim objCateter As New CateterCentral
    Dim modulo As String
    Private Sub Form_CateterCentral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        establecerTabla()
        permiso_general = perG.buscarPermisoGeneral(Name, modulo)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"

        With dgvantes
            .Columns.Item(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(0).DataPropertyName = "Codigo"
            .Columns.Item(0).ReadOnly = True

            .Columns.Item(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(1).DataPropertyName = "Descripcion"
            .Columns.Item(1).ReadOnly = True

            .Columns.Item(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(2).DataPropertyName = "Respuesta"
            .Columns.Item(2).ReadOnly = False
        End With

        establecerTablaDespues()
        With dgvdespues
            .Columns.Item(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(0).DataPropertyName = "Codigo"
            .Columns.Item(0).ReadOnly = True

            .Columns.Item(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(1).DataPropertyName = "Descripcion"
            .Columns.Item(1).ReadOnly = True

            .Columns.Item(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(2).DataPropertyName = "Respuesta"
            .Columns.Item(2).ReadOnly = False
        End With
        dgvantes.DataSource = dtAnte
        dgvdespues.DataSource = dtDespues

        dgvantes.AutoGenerateColumns = False
        dgvdespues.AutoGenerateColumns = False
        cargarAntes()
        cargarDespues()
        Dim params As New List(Of String)
        params.Add(Constantes.CARGO_MEDICO_GENERAL_UCI & "," & Constantes.CARGO_MEDICO_ESPECIALISTA)
        params.Add(SesionActual.idEmpresa)
        General.cargarCombo(ConsultasAmbu.CARGO_AM_BUSCAR, params, "Empleado", "Id_empleado", Cboenfermeros)
        deshabilitar()
    End Sub

    Public Sub cargarModulo(ByVal tag As String)
        modulo = tag
    End Sub
    Public Sub establecerTabla()
        Dim A, A1, A2 As New DataColumn

        A.ColumnName = "Codigo"
        A.DataType = Type.GetType("System.String")
        dtAnte.Columns.Add(A)

        A1.ColumnName = "Descripcion"
        A1.DataType = Type.GetType("System.String")
        dtAnte.Columns.Add(A1)

        A2.ColumnName = "Respuesta"
        A2.DataType = Type.GetType("System.String")
        dtAnte.Columns.Add(A2)
        A = Nothing : A1 = Nothing : A2 = Nothing
    End Sub

    Public Sub establecerTablaDespues()
        Dim A, A1, A2 As New DataColumn

        A.ColumnName = "Codigo"
        A.DataType = Type.GetType("System.String")
        dtDespues.Columns.Add(A)

        A1.ColumnName = "Descripcion"
        A1.DataType = Type.GetType("System.String")
        dtDespues.Columns.Add(A1)

        A2.ColumnName = "Respuesta"
        A2.DataType = Type.GetType("System.String")
        dtDespues.Columns.Add(A2)
        A = Nothing : A1 = Nothing : A2 = Nothing
    End Sub

    Private Sub limpiar()
        txtfechainsercion.Text = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        txtfechaseguimiento.Text = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        txtobservacion.Clear()
        txtcausas.Clear()
        txtcodigo.Clear()
        Label18.Visible = False
        Label19.Visible = False
        fecharetiro.Visible = False
        Cboenfermeros.SelectedValue = -1
        rinotropicos.Checked = False
        rntp.Checked = False
        rmidazolam.Checked = False
        ranfotericina.Checked = False
        rsolucion.Checked = False
        rotra.Checked = False
        rsalas.Checked = False
        rsalaspro.Checked = False
        rotros.Checked = False
        ryugular.Checked = False
        recutaneo.Checked = False
        rmonolumen.Checked = False
        rfemoral.Checked = False
        rbilumen.Checked = False
        rtrilumen.Checked = False
        rarterial.Checked = False
        rotros3.Checked = False
        txtcual1.Clear()
        txtcual2.Clear()
        txtcual3.Clear()
    End Sub

    Public Function crearCateterCentral() As CateterCentral
        Dim objCateterCentral = New CateterCentral
        objCateterCentral.Codigo = txtcodigo.Text
        objCateterCentral.registro = txtregistro.Text
        objCateterCentral.fecha_insercion = CDate(txtfechainsercion.Value).Date
        objCateterCentral.causa = txtcausas.Text
        objCateterCentral.observacion = txtobservacion.Text
        objCateterCentral.fecha_retiro = CDate(fecharetiro.Value).Date
        objCateterCentral.inotropicos = rinotropicos.Checked
        objCateterCentral.midazolan = rmidazolam.Checked
        objCateterCentral.anfotericina = ranfotericina.Checked
        objCateterCentral.solucion = rsolucion.Checked
        objCateterCentral.otra = rotra.Checked
        objCateterCentral.cual = txtcual1.Text
        objCateterCentral.usuarioRealiza = Cboenfermeros.SelectedValue
        objCateterCentral.usuario = SesionActual.idUsuario
        objCateterCentral.salacx = rsalas.Checked
        objCateterCentral.salaproc = rsalaspro.Checked
        objCateterCentral.otrasala = rotros.Checked
        objCateterCentral.cualsala = txtcual2.Text
        objCateterCentral.yugular = ryugular.Checked
        objCateterCentral.subclavio = rsubclavio.Checked
        objCateterCentral.femoral = rfemoral.Checked
        objCateterCentral.bi = rbilumen.Checked
        objCateterCentral.tri = rtrilumen.Checked
        objCateterCentral.drum = rdrum.Checked
        objCateterCentral.epic = recutaneo.Checked
        objCateterCentral.swain = rswan.Checked
        objCateterCentral.larterial = rarterial.Checked
        objCateterCentral.otro = rotros3.Checked
        objCateterCentral.cualcat = txtcual3.Text

        For Each drFila As DataRow In dtAnte.Rows
            Dim drRespuesta As DataRow = objCateterCentral.dtCateter.NewRow

            drRespuesta.Item("Codigo_CTC") = txtcodigo.Text
            drRespuesta.Item("Codigo_Criterio") = drFila.Item("Codigo")
            drRespuesta.Item("respuesta") = drFila.Item("respuesta")

            objCateterCentral.dtCateter.Rows.Add(drRespuesta)
        Next

        For Each drFila As DataRow In dtDespues.Rows
            Dim drRespuesta As DataRow = objCateterCentral.dtCateter.NewRow

            drRespuesta.Item("Codigo_CTC") = txtcodigo.Text
            drRespuesta.Item("Codigo_Criterio") = drFila.Item("Codigo")
            drRespuesta.Item("respuesta") = drFila.Item("respuesta")

            objCateterCentral.dtCateter.Rows.Add(drRespuesta)
        Next

        Return objCateterCentral
    End Function
    Private Sub deshabilitar()
        txtcausas.ReadOnly = False
        txtfechainsercion.Enabled = False
        txtfechaseguimiento.Enabled = False
        txtobservacion.ReadOnly = True
        txtcual1.ReadOnly = True
        txtcual2.ReadOnly = True
        txtcual3.ReadOnly = True
        Cboenfermeros.Enabled = False
        rinotropicos.Enabled = False
        rntp.Enabled = False
        rmidazolam.Enabled = False
        ranfotericina.Enabled = False
        rsolucion.Enabled = False
        rotra.Enabled = False
        rsalas.Enabled = False
        rsalaspro.Enabled = False
        rotros.Enabled = False
        ryugular.Enabled = False
        rsubclavio.Enabled = False
        rfemoral.Enabled = False
        rbilumen.Enabled = False
        rtrilumen.Enabled = False
        rdrum.Enabled = False
        rswan.Enabled = False
        rarterial.Enabled = False
        rotros3.Enabled = False
        recutaneo.Enabled = False
        rmonolumen.Enabled = False
        dgvantes.ReadOnly = True
        dgvdespues.ReadOnly = True
        txtcausas.ReadOnly = True
        fecharetiro.Enabled = False
        txtpaciente.ReadOnly = True
        txtregistro.ReadOnly = True
        Checkdespues.Enabled = False
        Checkseleccionar.Enabled = False
    End Sub

    Private Sub Form_CateterCentral_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Public Sub habilitar()
        txtfechainsercion.Enabled = True
        txtfechaseguimiento.Enabled = True
        txtobservacion.ReadOnly = False
        txtobservacion.Clear()
        txtcausas.ReadOnly = False
        Cboenfermeros.Enabled = True
        fecharetiro.Enabled = True
        rinotropicos.Enabled = True
        rntp.Enabled = True
        rmidazolam.Enabled = True
        ranfotericina.Enabled = True
        rsolucion.Enabled = True
        rotra.Enabled = True
        rsalas.Enabled = True
        rsalaspro.Enabled = True
        rotros.Enabled = True
        ryugular.Enabled = True
        rsubclavio.Enabled = True
        recutaneo.Enabled = True
        rmonolumen.Enabled = True
        rfemoral.Enabled = True
        rbilumen.Enabled = True
        rtrilumen.Enabled = True
        rdrum.Enabled = True
        rswan.Enabled = True
        rarterial.Enabled = True
        rotros3.Enabled = True

    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            Dim param As New List(Of String)
            param.Add(txtregistro.Text)
            General.buscarElemento(Consultas.BUSCAR_CATETER_CENTRAL_CARGAR2, param,
                                   AddressOf cargarRegistro,
                                   TitulosForm.BUSQUEDA_CATETER_CENTRAL, True, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub cargarRegistro(codigo As Integer)
        Dim dt As New DataTable
        General.llenarTablaYdgv(Consultas.BUSCAR_CATETER_CENTRAL_CARGAR & codigo, dt)
        If dt.Rows.Count > 0 Then
            txtcodigo.Text = dt.Rows(0).Item("Codigo_CTC").ToString
            txtobservacion.Text = dt.Rows(0).Item("Observacion").ToString
            txtcausas.Text = dt.Rows(0).Item("CAUSA").ToString
            txtfechainsercion.Value = dt.Rows(0).Item("Fecha_insercion").ToString
            fecharetiro.Value = dt.Rows(0).Item("Fecha_retiro").ToString
            rinotropicos.Checked = dt.Rows(0).Item("INOTROPICOS").ToString
            rntp.Checked = dt.Rows(0).Item("NTP").ToString
            rmidazolam.Checked = dt.Rows(0).Item("MIDAZOLAM").ToString
            ranfotericina.Checked = dt.Rows(0).Item("ANFOTERICINA").ToString
            rsolucion.Checked = dt.Rows(0).Item("SOLUCION").ToString
            rotra.Checked = dt.Rows(0).Item("OTRA").ToString
            txtcual1.Text = dt.Rows(0).Item("CUAL").ToString
            Cboenfermeros.SelectedValue = dt.Rows(0).Item("usuario_REALIZA").ToString
            rsalas.Checked = dt.Rows(0).Item("SALACX").ToString
            rsalaspro.Checked = dt.Rows(0).Item("SALAPROC").ToString
            rotros.Checked = dt.Rows(0).Item("OTRASALA").ToString
            txtcual2.Text = dt.Rows(0).Item("CUALSALA").ToString
            ryugular.Checked = dt.Rows(0).Item("YUGULAR").ToString
            rsubclavio.Checked = dt.Rows(0).Item("SUBCLAVIO").ToString
            rfemoral.Checked = dt.Rows(0).Item("FEMORAL").ToString
            rmonolumen.Checked = dt.Rows(0).Item("MONO").ToString
            rbilumen.Checked = dt.Rows(0).Item("BI").ToString
            rtrilumen.Checked = dt.Rows(0).Item("TRI").ToString
            rdrum.Checked = dt.Rows(0).Item("DRUM").ToString
            recutaneo.Checked = dt.Rows(0).Item("EPIC").ToString
            rswan.Checked = dt.Rows(0).Item("SWAN").ToString
            rarterial.Checked = dt.Rows(0).Item("LARTERIAL").ToString
            rotros3.Checked = dt.Rows(0).Item("OTRO").ToString
            txtcual3.Text = dt.Rows(0).Item("CUALCAT").ToString
            bteditar.Enabled = True
            btanular.Enabled = True

            btnuevo.Enabled = True
            btimprimir.Enabled = True
            cargarAntes()
            cargarDespues()
            txtcual1.ReadOnly = True
            txtcual2.ReadOnly = True
            txtcual3.ReadOnly = True
            Checkdespues.Enabled = False
            Checkseleccionar.Enabled = False
            btcancelar.Enabled = False
        End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            General.habilitarControles(Me)
            btcancelar.Enabled = True
            btguardar.Enabled = True
            btnuevo.Enabled = False
            btanular.Enabled = False
            btimprimir.Enabled = False
            bteditar.Enabled = False
            txtregistro.ReadOnly = True
            btbuscar.Enabled = False
            deshabilitarControles()
            txtpaciente.ReadOnly = True
            txtcual1.ReadOnly = True
            txtcual2.ReadOnly = True
            txtcual3.ReadOnly = True
            Checkdespues.Enabled = True
            Checkseleccionar.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim lista As New List(Of String)
                lista.Add(txtcodigo.Text)
                lista.Add(SesionActual.idUsuario)
                General.ejecutarSQL(Consultas.ANULAR_CATETER_CENTRAL, lista)

                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                General.deshabilitarControles(Me)
                limpiar()
                btnuevo.Enabled = True
                btbuscar.Enabled = True
                btguardar.Enabled = False
                bteditar.Enabled = False
                btcancelar.Enabled = False
                btanular.Enabled = False
                btimprimir.Enabled = False
                txtcodigo.Clear()
                cargarAntes()
                cargarDespues()
                Checkdespues.Enabled = False
                Checkseleccionar.Enabled = False
            End If
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea cancelar este registro?", 32 + 1, "cancelar") = 1 Then
            General.deshabilitarControles(Me)
            btcancelar.Enabled = False
            bteditar.Enabled = False
            btanular.Enabled = False
            btbuscar.Enabled = True
            btnuevo.Enabled = True
            btguardar.Enabled = False
            btimprimir.Enabled = False
            limpiar()
            txtcodigo.Clear()
            cargarAntes()
            cargarDespues()
            Checkdespues.Enabled = False
            Checkseleccionar.Enabled = False
        End If

    End Sub

    Public Function validarControles()
        dgvantes.EndEdit()
        dgvdespues.EndEdit()
        dtDespues.AcceptChanges()
        dtAnte.AcceptChanges()

        If rinotropicos.Checked = False And rntp.Checked = False And rmidazolam.Checked = False And ranfotericina.Checked = False And rsolucion.Checked = False And rotra.Checked = False Then
            MsgBox("Debe seleccionar algun indicador del cateter", MsgBoxStyle.Exclamation)
            Return False
        ElseIf rsalas.Checked = False And rsalaspro.Checked = False And rotros.Checked = False Then
            MsgBox("Debe seleccionar lugar paso a cateter", MsgBoxStyle.Exclamation)
            Return False
        ElseIf ryugular.Checked = False And rsubclavio.Checked = False And rfemoral.Checked = False Then
            MsgBox("Debe seleccionar sitio de insercion de cateter", MsgBoxStyle.Exclamation)
            Return False
        ElseIf rmonolumen.Checked = False And rbilumen.Checked = False And rtrilumen.Checked = False And rdrum.Checked = False And recutaneo.Checked = False And rswan.Checked = False And rarterial.Checked = False And rotros3.Checked = False Then
            MsgBox("Debe seleccionar sitio de insercion de cateter", MsgBoxStyle.Exclamation)
            Return False
        ElseIf Cboenfermeros.SelectedValue = -1 Then
            MsgBox("Debe seleccione la persona que esta realizando el procedimiento", MsgBoxStyle.Exclamation)
            Cboenfermeros.Focus()
            Return False
        ElseIf dtAnte.Select("respuesta=false").Count = dtAnte.Rows.Count Then
            MsgBox("Debe seleccionar algun registro  antes del procedimiento", MsgBoxStyle.Exclamation)
            Return False
        ElseIf dtDespues.Select("respuesta=false").Count = dtDespues.Rows.Count Then
            MsgBox("Debe seleccionar algun registro  despues del procedimiento", MsgBoxStyle.Exclamation)
            Return False
        End If
        Return True
    End Function
    Private Sub btguardar_Click_1(sender As Object, e As EventArgs) Handles btguardar.Click
        dgvantes.CommitEdit(DataGridViewDataErrorContexts.Commit)
        dgvantes.EndEdit()
        dgvdespues.CommitEdit(DataGridViewDataErrorContexts.Commit)
        dgvdespues.EndEdit()
        If validarControles() Then
            crearCateter()
        End If
    End Sub

    Private Sub rotra_CheckedChanged(sender As Object, e As EventArgs) Handles rotra.CheckedChanged
        If rotra.Checked = True Then
            txtcual1.ReadOnly = False
        Else
            txtcual1.ReadOnly = True
            txtcual1.Clear()
        End If
    End Sub

    Private Sub rotros_CheckedChanged(sender As Object, e As EventArgs) Handles rotros.CheckedChanged
        If rotros.Checked = True Then
            txtcual2.ReadOnly = False
        Else
            txtcual2.ReadOnly = True
            txtcual2.Clear()
        End If
    End Sub

    Private Sub rotros3_CheckedChanged(sender As Object, e As EventArgs) Handles rotros3.CheckedChanged
        If rotros3.Checked = True Then
            txtcual3.ReadOnly = False
        Else
            txtcual3.ReadOnly = True
            txtcual3.Clear()
        End If
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If btguardar.Enabled = True Then
            MsgBox("Por favor guarde la información del cateter", MsgBoxStyle.Information)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try
            Dim ruta, area, nombreArchivo As String
            area = ConstantesHC.NOMBRE_PDF_CATETER
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtcodigo.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo

            guardarReportecateter()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub guardarReportecateter()
        Try
            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_CATETER, txtregistro.Text, New rptCateterCentral,
                                    txtcodigo.Text, "{VISTA_CATETER_CENTRAL.Codigo_CTC} = " & txtcodigo.Text & "",
                                    ConstantesHC.NOMBRE_PDF_CATETER, IO.Path.GetTempPath)

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub dgvantes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvantes.CellContentClick
        If e.ColumnIndex = 2 Then
            validarCheck(dgvdespues.CurrentCell.RowIndex)
        End If
    End Sub

    Private Sub validarCheck(i As Integer)
        If dtDespues.Rows.Count > 0 Then
            dgvdespues.CommitEdit(DataGridViewDataErrorContexts.Commit)
            dgvdespues.EndEdit()

            If dtDespues.Rows(i).Item(1).ToString.ToLower.Contains("retir") And dtDespues.Rows(i).Item(2) = True Then
                Label18.Visible = True
                txtcausas.Visible = True
                fecharetiro.Visible = True
                Label19.Visible = True
            Else
                Label18.Visible = False
                txtcausas.Visible = False
                fecharetiro.Visible = False
                Label19.Visible = False
            End If

        End If
    End Sub

    Private Sub Checkseleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles Checkseleccionar.CheckedChanged
        If Checkseleccionar.Checked = True Then
            For i = 0 To dgvantes.Rows.Count - 1
                dgvantes.Rows(i).Cells("Respuesta").Value = True
                Checkseleccionar.Text = "Deshabilitar todo"
            Next
        Else
            For i = 0 To dgvantes.Rows.Count - 1
                dgvantes.Rows(i).Cells("Respuesta").Value = False
                Checkseleccionar.Text = "Habilitar todo"
            Next
        End If
    End Sub

    Private Sub Checkdespues_CheckedChanged(sender As Object, e As EventArgs) Handles Checkdespues.CheckedChanged
        If Checkdespues.Checked = True Then
            For i = 0 To dgvdespues.Rows.Count - 1
                dgvdespues.Rows(i).Cells("Respuesta1").Value = True
                Checkdespues.Text = "Deshabilitar todo"
            Next
        Else
            For i = 0 To dgvdespues.Rows.Count - 1
                dgvdespues.Rows(i).Cells("Respuesta1").Value = False
                Checkdespues.Text = "Habilitar todo"
            Next
        End If
    End Sub


    Public Sub cargarAntes()
        Dim params As New List(Of String)
        params.Add(txtcodigo.Text)
        If txtcodigo.Text <> "" Then
            General.llenarTabla(Consultas.CATETER_CENTRAL_BUSCAR_ANTES, params, dtAnte)
        Else
            General.llenarTablaYdgv(Consultas.CATETER_CENTRAL_BUSCAR_ANTES2, dtAnte)
        End If
    End Sub

    Public Sub cargarDespues()
        Dim params As New List(Of String)
        params.Add(txtcodigo.Text)
        If txtcodigo.Text <> "" Then
            General.llenarTabla(Consultas.CATETER_CENTRAL_BUSCAR_DESPUES, params, dtDespues)
        Else
            General.llenarTablaYdgv(Consultas.CATETER_CENTRAL_BUSCAR_DESPUES2, dtDespues)
        End If

    End Sub

    Public Sub crearCateter()
        Dim objCateter_D As New CateterCentralBLL
        Dim objCateter As CateterCentral



        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                objCateter = crearCateterCentral()
                objCateter_D.crearCateter(objCateter)
                txtcodigo.Text = objCateter.Codigo

                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                General.deshabilitarControles(Me)
                btguardar.Enabled = False
                btcancelar.Enabled = False
                btbuscar.Enabled = True
                bteditar.Enabled = True
                btanular.Enabled = True
                btnuevo.Enabled = True
                btimprimir.Enabled = True
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Public Sub cargarPaciente(registro As String, paciente As String)
        txtregistro.Text = registro
        txtpaciente.Text = paciente
    End Sub

    Public Sub deshabilitarControles()
        dgvantes.Columns("codigo").ReadOnly = True
        dgvantes.Columns("Descripcion").ReadOnly = True
        dgvdespues.Columns("codigo1").ReadOnly = True
        dgvdespues.Columns("Descripcion1").ReadOnly = True
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.habilitarControles(Me)
            limpiar()
            btbuscar.Enabled = False
            deshabilitarControles()
            cargarAntes()
            cargarDespues()
            btguardar.Enabled = True
            btcancelar.Enabled = True
            btanular.Enabled = False
            btimprimir.Enabled = False
            bteditar.Enabled = False
            btnuevo.Enabled = False
            txtregistro.ReadOnly = True
            txtpaciente.ReadOnly = True
            txtcual1.ReadOnly = True
            txtcual2.ReadOnly = True
            txtcual3.ReadOnly = True
            Checkdespues.Enabled = True
            Checkseleccionar.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

End Class