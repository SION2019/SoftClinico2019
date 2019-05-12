Imports System.Threading
Public Class Form_Estancia_Prolongada
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim perG As New Buscar_Permisos_generales
    Dim reporte As New ftp_reportes
    Dim guardarEn2doPlano As Thread
    Dim moduloTemporal As String
    Dim activoAM, activoAF, respuestan As Boolean
    Dim usuarioInforme, contadorDiag, CodigoTemporal, nRegistro, usuarioActual As Integer
    Dim objEstancia As New EstanciaProlongada
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            iniciarForm()
            btanular.Enabled = False
            btimprimir.Enabled = False
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub iniciarForm()
        General.habilitarControles(Me)
        btguardar.Enabled = True
        btcancelar.Enabled = True
        btanular.Enabled = False
        bteditar.Enabled = False
        btnuevo.Enabled = False
        txtregistro.ReadOnly = True
        txtpaciente.ReadOnly = True
        txtfecha.ReadOnly = True
        txtfechaingreso.ReadOnly = True
        txtregistro.ReadOnly = True
        TXTEPS.ReadOnly = True
        txtidentificacion.ReadOnly = True
    End Sub

    Private Sub limpiar()
        cargarDatos()
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea cancelar este registro?", 32 + 1, "cancelar") = 1 Then
            General.deshabilitarControles(Me)
            btcancelar.Enabled = False
            bteditar.Enabled = True
            btanular.Enabled = False
            btnuevo.Enabled = True
            btguardar.Enabled = False
            limpiar()
            btimprimir.Enabled = False
        End If
    End Sub

    Public Sub preCargarDatosEstancia(ByRef pHistoriaClinica As HistoriaClinica)
        txtregistro.Text = pHistoriaClinica.nRegistro
        moduloTemporal = pHistoriaClinica.modulo
        objEstancia = pHistoriaClinica.objEstancia
    End Sub

    Public Sub cargarDatos()
        General.cargarCombo(Consultas.BUSQUEDA_EMPLEADO_HC & Constantes.LISTA_CARGO_EVOLUCION & "," & SesionActual.idEmpresa & "", "Empleado", "Id_empleado", cbomedico)
        Dim lista As New List(Of String)
        lista.Add(txtregistro.Text)
        Dim dt As New DataTable
        General.llenarTabla(objEstancia.cargarDatos, lista, dt)
        If dt.Rows.Count > 0 Then
            General.deshabilitarControles(Me)
            objEstancia.justificacion = dt.Rows(0).Item("JUSTIFICACION").ToString
            objEstancia.resultado = dt.Rows(0).Item("RESULTADO").ToString
            objEstancia.conducta = dt.Rows(0).Item("CONDUCTA").ToString
            objEstancia.idempleado = dt.Rows(0).Item("ID_EMPLEADO_MEDICO")
            objEstancia.fecha = dt.Rows(0).Item("FECHA").ToString
            txtjustificacion.Text = objEstancia.justificacion
            txtresultado.Text = objEstancia.resultado
            txtconducta.Text = objEstancia.conducta
            cbomedico.SelectedValue = objEstancia.idempleado
            txtfecha.Text = objEstancia.fecha
            cbomedico.Enabled = False
            bteditar.Enabled = True
            btimprimir.Enabled = True
            btguardar.Enabled = False
            btcancelar.Enabled = False
            btnuevo.Enabled = False
            btanular.Enabled = True
        End If
        objEstancia.cargarDiagnosticos()
        dgvestancia.DataSource = objEstancia.dtEstancia
    End Sub


    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                objEstancia.registro = txtregistro.Text
                objEstancia.anular()
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                General.deshabilitarControles(Me)
                txtjustificacion.Clear()
                txtconducta.Clear()
                txtresultado.Clear()
                limpiar()
                btnuevo.Enabled = True
                btguardar.Enabled = False
                bteditar.Enabled = True
                btcancelar.Enabled = False
                btanular.Enabled = False
                btimprimir.Enabled = False
            End If
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub Form_Estancia_Prolongada_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

    Public Function validarControles()
        If cbomedico.SelectedIndex < 1 Then
            MsgBox("Seleccione el Medico", MsgBoxStyle.Exclamation)
            cbomedico.Focus()
            Return False
        ElseIf txtjustificacion.Text = "" Then
            MsgBox("El campo justificacion se encuentra vacio", MsgBoxStyle.Exclamation)
            txtjustificacion.Focus()
            Return False
        ElseIf txtresultado.Text = "" Then
            MsgBox("El campo resultado se encuentra vacio", MsgBoxStyle.Exclamation)
            txtresultado.Focus()
            Return False
        ElseIf txtconducta.Text = "" Then
            MsgBox("El campo resultado se conducta vacio", MsgBoxStyle.Exclamation)
            txtconducta.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarControles() Then
            crearEstancia()
        End If
    End Sub

    Public Sub cargarPaciente(vFormHistoriaClinica As Form_Historia_clinica)
        txtregistro.Text = vFormHistoriaClinica.txtRegistro.Text
        txtpaciente.Text = vFormHistoriaClinica.txtNombre.Text
        txtfechaingreso.Text = vFormHistoriaClinica.txtAdmision.Text
        txtidentificacion.Text = vFormHistoriaClinica.txtHC.Text
        TXTEPS.Text = vFormHistoriaClinica.txtNombreContrato.Text
    End Sub

    Private Sub guardarSegundoPlano()

        'guardarEn2doPlano = New Thread(AddressOf guardarReporte)
        'guardarEn2doPlano.Name = "Guardar Estancia Prolongada"
        'guardarEn2doPlano.SetApartmentState(ApartmentState.STA)
        'guardarEn2doPlano.Start()
    End Sub


    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try
            objEstancia.imprimir()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub


    Public Sub crearEstancia()
        Dim objEstancia_D As New EstanciaProlongadaBLL
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                guardarEstancia()
                objEstancia.guardarEstancia()
                nRegistro = txtregistro.Text
                usuarioActual = SesionActual.idUsuario
                CodigoTemporal = txtregistro.Text
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                General.deshabilitarControles(Me)
                btguardar.Enabled = False
                btcancelar.Enabled = False
                bteditar.Enabled = True
                btanular.Enabled = True
                btimprimir.Enabled = True
                guardarSegundoPlano()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Public Sub guardarEstancia()

        objEstancia.registro = txtregistro.Text
        objEstancia.conducta = txtconducta.Text
        objEstancia.fecha = txtfecha.Text
        objEstancia.idempleado = cbomedico.SelectedValue
        objEstancia.justificacion = txtjustificacion.Text
        objEstancia.resultado = txtresultado.Text
        objEstancia.usuario = SesionActual.idUsuario

    End Sub

    Private Sub Form_Estancia_Prolongada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        activoAM = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AM & "'")
        activoAF = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AF & "'")
        permiso_general = perG.buscarPermisoGeneral(Name, moduloTemporal)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        txtfecha.Text = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)

        With dgvestancia
            .Columns.Item(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(0).DataPropertyName = "Codigo"
            .Columns.Item(0).ReadOnly = True

            .Columns.Item(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(1).DataPropertyName = "Descripcion"
            .Columns.Item(1).ReadOnly = True
        End With
        dgvestancia.DataSource = objEstancia.dtEstancia
        dgvestancia.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvestancia.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)

        objEstancia.cargarDiagnosticos()
        General.deshabilitarControles(Me)
        If cbomedico.DataSource = Nothing Then
            General.cargarCombo(Consultas.BUSQUEDA_EMPLEADO_HC & Constantes.LISTA_CARGO_EVOLUCION & "," & SesionActual.idEmpresa & "", "Empleado", "Id_empleado", cbomedico)
        End If
        btnuevo.Visible = False
        ToolStripSeparator1.Visible = False
        limpiar()
        iniciarForm()
        cbomedico.Enabled = True
        dgvestancia.ReadOnly = True
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then

        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub
End Class