Imports System.Threading
Public Class FormEpicrisis
    Dim objEpicrisis As Epicrisis
    Dim respuesta, activoAM, activoAF As Boolean
    Dim perG As New Buscar_Permisos_generales
    Dim guardarEn2doPlano As Thread
    Dim usuarioInforme, area, idUsuario, usuarioActual As Integer
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, codigoTemporal, moduloTemporal, codigo As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
        nombre_usuario.Text = Nothing
    End Sub
    Private Sub enlazarTablas()
        dgvremision.DataSource = objEpicrisis.dtRemision
        With dgvremision
            .Columns("Código").ReadOnly = True
            .Columns("Código").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Código").DataPropertyName = "Código"
            .Columns("Código").HeaderText = "Código CIE"
            .Columns("Código").Width = 75
            .Columns("Código").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Descripción").ReadOnly = True
            .Columns("Descripción").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripción").DataPropertyName = "Descripción"
            .Columns("Descripción").HeaderText = "Descripción del diagnóstico"
            .Columns("Descripción").Width = 815

        End With
        dgvremision.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgvremision.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        '-------------------------------------------
        dgv_diag.DataSource = objEpicrisis.dtImpresion
        With dgv_diag
            .Columns("Código").ReadOnly = True
            .Columns("Código").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Código").DataPropertyName = "Código"
            .Columns("Código").HeaderText = "Código CIE"
            .Columns("Código").Width = 75
            .Columns("Código").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Descripción").ReadOnly = True
            .Columns("Descripción").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripción").DataPropertyName = "Descripción"
            .Columns("Descripción").HeaderText = "Descripción del diagnóstico"
            .Columns("Descripción").Width = 815
        End With
        dgv_diag.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgv_diag.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        '------------------------------
        dgv_diag_egreso.DataSource = objEpicrisis.dtDiagEgreso
        With dgv_diag_egreso
            .Columns("Código").ReadOnly = True
            .Columns("Código").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Código").DataPropertyName = "Código"
            .Columns("Código").HeaderText = "Código CIE"
            .Columns("Código").Width = 75
            .Columns("Código").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Descripción").ReadOnly = True
            .Columns("Descripción").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripción").DataPropertyName = "Descripción"
            .Columns("Descripción").HeaderText = "Descripción del diagnóstico"
            .Columns("Descripción").Width = 815
        End With

        dgv_diag_egreso.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgv_diag_egreso.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)

    End Sub
    Private Sub cargarEpicrisisAutomatica()
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(texthc.Text)
        General.llenarTabla(objEpicrisis.busquedaAutomatica, params, dt)
        For i = 0 To dt.Rows.Count - 1
            textepiciris.Text = textepiciris.Text & dt.Rows(i).Item("fecha") & vbNewLine & dt.Rows(i).Item("Analisis") & vbNewLine & vbNewLine
        Next
    End Sub
    Public Sub cargarPaciente()
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(texthc.Text)
        General.llenarTabla(objEpicrisis.cargaPaciente, params, dt)
        textnombre.Text = dt.Rows(0).Item("paciente").ToString
        textedad.Text = dt.Rows(0).Item("edad").ToString
        Textsexo.Text = dt.Rows(0).Item("Descripcion_genero").ToString
        Textestancia.Text = dt.Rows(0).Item("Dias_estancias").ToString
        textentorno.Text = dt.Rows(0).Item("Descripcion_area_servicio").ToString
        textidentificacion.Text = dt.Rows(0).Item("documento_paciente").ToString
        texthc.Text = dt.Rows(0).Item("n_registro").ToString
        fecha_admision.Text = dt.Rows(0).Item("fecha_admision").ToString
        cargarDiagnosticosEgreso()
        cargarDiagnosticosImpresion()
        cargarDiagnosticosRemision()
        cargarEpicrisisAutomatica()
    End Sub
    Public Sub cargarEpicrisis()

        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(objEpicrisis.registro)
        General.llenarTabla(objEpicrisis.cargaEpicrisis, params, dt)
        textnombre.Text = dt.Rows(0).Item("paciente").ToString
        textepiciris.Text = dt.Rows(0).Item("nota").ToString
        textedad.Text = dt.Rows(0).Item("edad")
        Textsexo.Text = dt.Rows(0).Item("Descripcion_genero")
        Textobservacion.Text = dt.Rows(0).Item("observacion").ToString
        Textestancia.Text = dt.Rows(0).Item("Dias_estancias")
        textentorno.Text = dt.Rows(0).Item("Descripcion_area_servicio")
        textidentificacion.Text = dt.Rows(0).Item("Documento_paciente").ToString
        texthc.Text = dt.Rows(0).Item("n_registro")
        fechaegreso.Value = dt.Rows(0).Item("fecha_egreso")
        fecha_admision.Text = dt.Rows(0).Item("fecha_admision")
        comboestadosalida.SelectedValue = dt.Rows(0).Item("Codigo_estado_salida").ToString
        General.cargarCombo(Consultas.DESTINO_LLENAR & " " & comboestadosalida.SelectedValue.ToString & " ", "Descripcion_Destino_Usuario", "Codigo_Destino_Usuario", combodestino)
        combodestino.SelectedValue = dt.Rows(0).Item("Codigo_destino_usuario").ToString
        Comboinstitucional.SelectedValue = dt.Rows(0).Item("Codigo_institucion").ToString
        nombre_usuario.Text = dt.Rows(0).Item("Usuario_Real").ToString
        usuarioInforme = dt.Rows(0).Item("id_Usuario_Real").ToString
        cargarDiagnosticosRemision()
        cargarDiagnosticosImpresion()
        cargarDiagnosticosEgreso()
        General.deshabilitarControles(Me)
        General.habilitarBotones(Me.ToolStrip1)
        cargarFirma(texthc.Text)
        btguardar.Enabled = False
        btcancelar.Enabled = False
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click

        Try
            If SesionActual.tienePermiso(Panular ) Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    objEpicrisis.anularEpicrisis(activoAM, activoAF)
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    abrirPaciente()
                    General.limpiarControles(Me)
                    General.deshabilitarBotones(ToolStrip1)
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click

        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False

        Try
            objEpicrisis.imprimir()
            If combodestino.SelectedValue = 4 Then
                objEpicrisis.imprimirRetiroVoluntario()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub
    Private Sub cargarDiagnosticosRemision()
        objEpicrisis.cargaDiagnosticosRemision()
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        crearEpicrisis()
        If validarInformacion() Then
            guardarEpicrisis()
        End If
    End Sub
    Private Sub cargarDiagnosticosImpresion()
        objEpicrisis.cargarDiagnosticosImpresion()
    End Sub
    Private Sub cargarDiagnosticosEgreso()
        objEpicrisis.cargarDiagnosticosEgreso()
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                General.habilitarControles(Me)
                General.deshabilitarBotones(ToolStrip1)
                General.deshabilitarControles(grupotextos)
                General.deshabilitarControles(GroupBox2)
                General.deshabilitarControles(GroupBox3)
                fechaegreso.Enabled = True
                btguardar.Enabled = True
                btcancelar.Enabled = True
                codigo = texthc.Text
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add("")
            params.Add(SesionActual.codigoEP)
            Dim tbl As DataRow = Nothing
            Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(objEpicrisis.busquedaEpicrisis, params, TitulosForm.BUSQUEDA_EPICRISIS, True, 0, True)
            tbl = formBusqueda.rowResultados
            If tbl IsNot Nothing Then
                texthc.Text = tbl(0)
                objEpicrisis.registro = texthc.Text
                cargarEpicrisis()
            End If

        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click

        If SesionActual.tienePermiso(Pnuevo) Then
            nombre_usuario.Text = Nothing
            If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
                Dim tbl As DataRow = Nothing
                Dim params As New List(Of String)
                params.Add(Constantes.LISTA_CARGO_EVOLUCION)
                params.Add(SesionActual.idEmpresa)
                Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True)
                tbl = formBusqueda.rowResultados
                If tbl IsNot Nothing Then
                    usuarioInforme = tbl(0)
                    nombre_usuario.Text = tbl(1)
                Else
                    MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            Else
                idUsuario = SesionActual.idUsuario
            End If
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            General.deshabilitarControles(grupotextos)
            General.deshabilitarControles(GroupBox2)
            General.deshabilitarControles(GroupBox3)
            btbuscarpaciente.Enabled = True
            fechaegreso.Enabled = True
            codigo = String.Empty
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Btfirma_Click(sender As Object, e As EventArgs) Handles Btfirma.Click
        Dim objfirma As New Form_firmas
        objfirma.iniciarForm(Me)
        objfirma.crearImagen(Constantes.ID_EPICRISIS, texthc.Text, Picaux)
        objfirma.ShowDialog()
        Btborrar_firma.Enabled = True
    End Sub

    Private Sub combodestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combodestino.SelectedIndexChanged
        If btguardar.Enabled = False Then
            Exit Sub
        End If

        If comboestadosalida.SelectedValue = 1 And combodestino.SelectedIndex = 1 Then
            Btfirma.Visible = True
            Btborrar_firma.Visible = True
            Picaux.Visible = True
        Else
            Btfirma.Visible = False
            Btborrar_firma.Visible = False
            Picaux.Visible = False
        End If
    End Sub

    Public Sub cargarFirma(registro)
        Dim params As New List(Of String)
        params.Add(registro)

        Dim dt As New DataTable
        General.llenarTabla(Consultas.FIRMA_RETIRO_CARGAR, params, dt)

        If Not IsDBNull(dt.Rows(0).Item("Firma")) Then
            Dim bites() As Byte = dt.Rows(0).Item("Firma")
            Dim ms As New MemoryStream(bites)
            Picaux.Refresh()
            Picaux.Image = Image.FromStream(ms)
            Picaux.Refresh()
            ms.Dispose()
            bites = Nothing
            Picaux.Visible = True
        Else
            Picaux.Image = Nothing
            Picaux.Visible = False
        End If

    End Sub

    Private Sub nombre_usuario_Click(sender As Object, e As EventArgs) Handles nombre_usuario.Click
        If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) And btguardar.Enabled = True Then
            Dim tbl As DataRow = Nothing
            Dim params As New List(Of String)
            params.Add(Constantes.LISTA_CARGO_EVOLUCION)
            params.Add(SesionActual.idEmpresa)
            Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True)
            tbl = formBusqueda.rowResultados
            If tbl IsNot Nothing Then
                usuarioInforme = tbl(0)
                nombre_usuario.Text = tbl(1)
            End If
        End If
    End Sub

    Private Sub Btborrar_firma_Click(sender As Object, e As EventArgs) Handles Btborrar_firma.Click
        If MsgBox("¿Desea eliminar el retiro voluntario?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
            respuesta = General.anularRegistro(Consultas.ANULAR_FIRMA_RETIRO & CInt(texthc.Text) & "")
            If respuesta = True Then
                Picaux.Image = Nothing
            End If
        End If
    End Sub

    Private Sub btbuscarpaciente_Click(sender As Object, e As EventArgs) Handles btbuscarpaciente.Click
        Dim tbl As DataRow = Nothing
        Dim params As New List(Of String)
        params.Add(Constantes.ESTADO_ATENCION_INICIADO)
        Select Case moduloTemporal
            Case Constantes.HC, Constantes.AM, Constantes.AF
                params.Add(Constantes.HC)
            Case Else
                params.Add(moduloTemporal)
        End Select
        params.Add(SesionActual.codigoEP)
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(objEpicrisis.busquedaPaciente, params, TitulosForm.BUSQUEDA_PACIENTE, True, 0, True)
        tbl = formBusqueda.rowResultados
        If tbl IsNot Nothing Then
            textepiciris.Clear()
            texthc.Text = tbl(0)
            objEpicrisis.registro = texthc.Text
            cargarPaciente()
        End If

    End Sub
    Private Sub Form_Epicrisis_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Public Sub tomarModulo(modulo As String)
        moduloTemporal = modulo
    End Sub
    Public Sub tomarRegistro(registro As String)
        objEpicrisis.registro = registro
    End Sub
    Private Sub Form_Epicrisis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        If String.IsNullOrEmpty(moduloTemporal) Then
            moduloTemporal = Tag.modulo
        End If
        objEpicrisis = GeneralHC.fabricaHC.crear(Constantes.CODIGO_EPICRISIS & moduloTemporal)
        Select Case moduloTemporal
            Case Constantes.CODIGO_MENU_HEMO
                Label1.Text = Replace(objEpicrisis.titulo, "HISTORIA CLÍNICA", "HEMODINÁMIA")
            Case Else
                Label1.Text = objEpicrisis.titulo
        End Select
        If moduloTemporal <> Constantes.AM And moduloTemporal <> Constantes.AF Then
            objEpicrisis.moduloReporte = Constantes.REPORTE_HC
        ElseIf moduloTemporal = Constantes.AM Then
            objEpicrisis.moduloReporte = Constantes.REPORTE_AM
        ElseIf moduloTemporal = Constantes.AF Then
            objEpicrisis.moduloReporte = Constantes.REPORTE_AF
        End If
        activoAM = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AM & "'")
        activoAF = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AF & "'")

        permiso_general = perG.buscarPermisoGeneral("FormEpicrisis", moduloTemporal)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.deshabilitarControles(Me)
        enlazarTablas()
        usuarioActual = SesionActual.idUsuario
        comboestadosalida.SelectedValue = Constantes.VALOR_PREDETERMINADO
        General.cargarCombo(Consultas.ESTADO_SALIDA_LISTAR, "Descripcion_Estado_salida", "Codigo_Estado_Salida", comboestadosalida)
        General.cargarCombo(Consultas.INSTITUCIONES_LISTAR, "Descripción", "Código", Comboinstitucional)

    End Sub
    Private Sub comboestadosalida_SelectedValueChanged(sender As Object, e As EventArgs) Handles comboestadosalida.SelectedValueChanged
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        General.cargarCombo(Consultas.DESTINO_LLENAR & " " & comboestadosalida.SelectedValue.ToString & " ", "Descripcion_Destino_Usuario", "Codigo_Destino_Usuario", combodestino)
    End Sub
    Private Function validarInformacion()
        Dim fechaUltimaEvolucion As DateTime = objEpicrisis.obtenerFechaUltimaEvo()
        If objEpicrisis.estadoSalida = 2 AndAlso Not fechaUltimaEvolucion.Equals(objEpicrisis.fecha) Then
            MsgBox("¡La hora de egreso no concuerda con la ultima evolución!" & vbNewLine & "(" & fechaUltimaEvolucion & ")", MsgBoxStyle.Exclamation)
            Return False
        End If
        Dim params As New List(Of String)
        params.Add(objEpicrisis.registro)
        params.Add(Format(objEpicrisis.fecha, Constantes.FORMATO_FECHA_HORA_GEN))
        Dim dtDocumentos As New DataTable
        General.llenarTabla(objEpicrisis.verificarFecha, params, dtDocumentos)
        If dtDocumentos.Rows.Count > 0 Then
            Dim mensajes As String
            mensajes = "¡EXISTEN DOCUMENTOS CON FECHA MAYOR A LA EPICRISIS!" & vbCrLf & vbCrLf
            For i = 0 To dtDocumentos.Rows.Count - 1
                mensajes += " - " & dtDocumentos.Rows(i).Item("Bandera") & vbCrLf
            Next
            mensajes += vbCrLf & "¡Por favor revise antes para continuar!"
            MsgBox(mensajes, MsgBoxStyle.Exclamation)
            Return False
        End If
        If texthc.Text = "" Then
            MsgBox("¡Debe seleccionar un paciente!", MsgBoxStyle.Exclamation)
            btbuscarpaciente.Focus()
            Return False
        ElseIf fechaegreso.Value.Date < fecha_admision.Value.Date Then
            MsgBox("¡No se puede colocar una fecha de egreso inferior a la admisión!", MsgBoxStyle.Exclamation)
            fechaegreso.Focus()
            Return False
        ElseIf textepiciris.Text = String.Empty Then
            MsgBox("¡No se puede guardar una epicrisis en blanco, por favor verifique!", MsgBoxStyle.Exclamation)
            TabControl1.SelectedIndex = 1
            textepiciris.Focus()
            Return False
        ElseIf comboestadosalida.SelectedIndex < 1 Then
            MsgBox("¡Por favor elija el estado de salida del paciente!", MsgBoxStyle.Exclamation)
            TabControl1.SelectedIndex = 2
            comboestadosalida.Focus()
            Return False
        ElseIf combodestino.SelectedIndex < 1 Then
            MsgBox("¡Por favor elija el destino del paciente!", MsgBoxStyle.Exclamation)
            TabControl1.SelectedIndex = 2
            combodestino.Focus()
            Return False
        ElseIf Comboinstitucional.SelectedIndex < 1 Then
            MsgBox("¡Por favor elija la institucion!", MsgBoxStyle.Exclamation)
            TabControl1.SelectedIndex = 2
            Comboinstitucional.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub abrirPaciente()
        objEpicrisis.cambiarEstadoAtencion(Constantes.ESTADO_ATENCION_INICIADO)
    End Sub
    Private Sub cerrarPaciente()
        objEpicrisis.cambiarEstadoAtencion(Constantes.ESTADO_ATENCION_CERRADO)
    End Sub
    Public Sub crearEpicrisis()
        objEpicrisis.codigo = codigo
        objEpicrisis.registro = texthc.Text
        objEpicrisis.fecha = (Format(fechaegreso.Value, Constantes.FORMATO_FECHA_HORA_GEN))
        objEpicrisis.nota = textepiciris.Text
        objEpicrisis.estadoSalida = comboestadosalida.SelectedValue
        objEpicrisis.destino = combodestino.SelectedValue
        objEpicrisis.institucion = Comboinstitucional.SelectedValue
        objEpicrisis.observacion = Textobservacion.Text
        objEpicrisis.usuario = SesionActual.idUsuario
        objEpicrisis.usuarioReal = usuarioInforme
        objEpicrisis.codigoEp = SesionActual.codigoEP
    End Sub
    Private Sub guardarEpicrisis()
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

            Try
                btimprimir.Enabled = False

                codigoTemporal = texthc.Text
                objEpicrisis.guardarEpicrisis()
                If combodestino.SelectedValue <> 4 Then
                    respuesta = General.anularRegistro(Consultas.ANULAR_FIRMA_RETIRO & CInt(texthc.Text) & "")
                    Picaux.Image = Nothing
                End If

                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                General.deshabilitarControles(Me)
                General.habilitarBotones(Me.ToolStrip1)
                'cerrarPaciente()
                btguardar.Enabled = False
                btcancelar.Enabled = False
                btimprimir.Enabled = False
                'verificarActivoYEdicion()
                'If combodestino.SelectedValue = 4 Then
                'guardarSegundoPlano()
                'End If
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
            btimprimir.Enabled = True
        End If
    End Sub
End Class