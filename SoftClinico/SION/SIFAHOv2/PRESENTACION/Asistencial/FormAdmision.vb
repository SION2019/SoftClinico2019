Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading
Public Class FormAdmision
    Private dtTraslado, dtDiagnostico As New DataTable
    Private dtImagen As New DataTable
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, Ptraslado, Panexo1, Panexo2, Panexo3, Ppaciente, Pdocumento, emailEPS,
        PBuscarRemision As String
    Private respuesta As Boolean
    Dim estadoAtencion, idPaciente, idTercero, idContacto As Integer
    Dim guardarEn2doPlano As Thread
    Dim reporte As New ftp_reportes
    Dim arrFile() As Byte
    Dim elementoAEliminar As New List(Of String)
    Dim objLista As New ListaCheck
    Dim idEspecialidad, idInstitucion As Integer
    Dim idRemision As Integer
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function

    Private Sub enlazarTablas()
        If dtDiagnostico.Columns.Count > 0 Then Exit Sub
        Dim codigo, descripcion, estado, codigoServicio,
            codigoCups, descripcionTras, valorTras, observacionTraslado,
            codigoTraslado, observacion As New DataColumn

        codigo.ColumnName = "Codigo_CIE"
        codigo.DataType = Type.GetType("System.String")
        dtDiagnostico.Columns.Add(codigo)

        descripcion.ColumnName = "Descripcion"
        descripcion.DataType = Type.GetType("System.String")
        dtDiagnostico.Columns.Add(descripcion)

        estado.ColumnName = "Estado"
        estado.DataType = Type.GetType("System.String")
        dtDiagnostico.Columns.Add(estado)

        observacion.ColumnName = "Observacion"
        observacion.DataType = Type.GetType("System.String")
        dtDiagnostico.Columns.Add(observacion)

        codigo = Nothing : descripcion = Nothing : estado = Nothing

        dgvdiagnosticos.DataSource = dtDiagnostico
        dgvdiagnosticos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

        With dgvdiagnosticos
            .Columns("Codigo_CIE").ReadOnly = True
            .Columns("Codigo_CIE").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigo_CIE").DataPropertyName = "Codigo_CIE"
            .Columns("Codigo_CIE").HeaderText = "Código CIE"
            .Columns("Codigo_CIE").Width = 75
            .Columns("Codigo_CIE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").DataPropertyName = "Descripcion"
            .Columns("Descripcion").HeaderText = "Descripción del diagnóstico"
            .Columns("Descripcion").Width = 600
            .Columns("Observacion").DataPropertyName = "Observacion"
            .Columns("Observacion").HeaderText = "Observación del diagnóstico"
            .Columns("Observacion").Width = 215
            .Columns("Observacion").ReadOnly = True
            .Columns("Estado").DataPropertyName = "Estado"
            .Columns("Estado").HeaderText = "Estado"
            .Columns("Estado").Visible = False
            .Columns("anulardiagevo").ReadOnly = True
            .Columns("anulardiagevo").DisplayIndex = CInt(dgvdiagnosticos.ColumnCount - 1)
            .Columns("anulardiagevo").Width = 80
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With

        '--------------------------------------------------
        codigoServicio.ColumnName = "Codigo_servicio"
        codigoServicio.DataType = Type.GetType("System.String")
        dtTraslado.Columns.Add(codigoServicio)

        codigoCups.ColumnName = "Codigo_Procedimiento"
        codigoCups.DataType = Type.GetType("System.String")
        dtTraslado.Columns.Add(codigoCups)

        descripcionTras.ColumnName = "Descripcion"
        descripcionTras.DataType = Type.GetType("System.String")
        dtTraslado.Columns.Add(descripcionTras)

        valorTras.ColumnName = "Precio"
        valorTras.DataType = Type.GetType("System.String")
        dtTraslado.Columns.Add(valorTras)

        observacionTraslado.ColumnName = "Observaciones"
        observacionTraslado.DataType = Type.GetType("System.String")
        dtTraslado.Columns.Add(observacionTraslado)

        codigoTraslado.ColumnName = "Codigo_tras"
        codigoTraslado.DataType = Type.GetType("System.String")
        dtTraslado.Columns.Add(codigoTraslado)

        With dgvtraslados
            .Columns.Item(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(0).DataPropertyName = "Codigo_servicio"
            .Columns.Item(0).ReadOnly = True

            .Columns.Item(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(1).DataPropertyName = "Codigo_Procedimiento"
            .Columns.Item(1).ReadOnly = True

            .Columns.Item(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(2).DataPropertyName = "Descripcion"
            .Columns.Item(2).ReadOnly = True

            .Columns.Item(3).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(3).DataPropertyName = "Precio"
            .Columns.Item(3).ReadOnly = True

            .Columns.Item(4).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(4).DataPropertyName = "Observaciones"

            .Columns.Item(5).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(5).DataPropertyName = "Codigo_tras"
            .Columns.Item(5).ReadOnly = True

        End With

        dgvtraslados.AutoGenerateColumns = False
        dgvtraslados.DataSource = dtTraslado
        dgvtraslados.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvtraslados.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        '--------------------------------------------------

        dgvdocumentos.AutoGenerateColumns = False
        dgvdocumentos.DataSource = dtImagen
        dgvdocumentos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvdocumentos.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Private Sub FormAdmision_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permisos()
        reporte.usuarioActual = SesionActual.idUsuario
        Panel.Visible = False
        cargarComboInicial()
        enlazarTablas()
        If Not String.IsNullOrEmpty(textnombrepaciente.Text) Then Exit Sub
        General.deshabilitarControles(Me)
        tsTraslado.Enabled = True
        tsPacientes.Enabled = True
        deshabilitarBotonesRaros()
        btImprimirRecibo.Enabled = False
        tsValorConsulta.Enabled = True
        tsRemisiones.Enabled = False
    End Sub
    Public Sub cargarAdmisionAnexo(pParams As List(Of String))
        txtCodigoSolicitud.Text = pParams(1)
        Dim params As New List(Of String)
        If pParams(1) <> Constantes.VALOR_PREDETERMINADO Then
            params.Add(txtCodigoSolicitud.Text)
            Txtcodigo.Text = General.getValorConsulta(ConsultasHC.REGISTRO_SOLICITUD_VERIFICAR, params)
        End If
        cargarComboInicial()
        enlazarTablas()
        permisos()
        If pParams(1) <> Constantes.VALOR_PREDETERMINADO Then
            cargarAdmision(Txtcodigo.Text)
        Else
            cargarAdmision(pParams(0))
        End If

        If SesionActual.tienePermiso(Peditar) Then
            edicion()
            MsgBox(Mensajes.NUEVA_ADMISION, MsgBoxStyle.Information)

            fecha_admision.Enabled = True
            If pParams.Count > 2 And pParams(2) <> Constantes.VALOR_PREDETERMINADO Then
                cargarInstitucion(ConstantesAsis.INSTITUCION_UCI_SABANA)
                TextcodigoContrato.Clear()
                Textnombrecontrato.Clear()
            End If


            frenarTimer()
            btnuevo.Visible = False
            btbuscar.Visible = False
            ToolStripSeparator1.Visible = False
            ToolStripSeparator3.Visible = False

            If pParams(1) <> Constantes.VALOR_PREDETERMINADO Then
                fecha_admision.Value = General.fechaActualServidor()
                comboAreaSegunPadre()
                Comboservicio.SelectedValue = General.getValorConsulta(ConsultasHC.AREA_TRASLADO_SOLICITUD_VERIFICAR, params)
                Txtcodigo.Clear()
            End If

            For i = 0 To dgvdiagnosticos.RowCount - 1
                dgvdiagnosticos.Rows(i).Cells("Estado").Value = Constantes.ITEM_NUEVO
            Next
            ShowDialog()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub
    Private Sub comboAreaSegunPadre()
        Dim params As New List(Of String)
        params.Add(Txtcodigo.Text)
        Dim dt As New DataTable
        General.llenarTabla(Consultas.BUSQUEDA_ADMISION_CARGAR, params, dt)
        Dim servicioNeonatal = General.getEstadoVF(Consultas.AREA_SERVICIO_VERIFICAR & dt.Rows(0).Item("Codigo_Area_Servicio"))
        For i = 1 To Comboservicio.DataSource.rows.count - 1
            If Comboservicio.DataSource.rows(i).item("neonatal") <> servicioNeonatal Then
                Comboservicio.DataSource.rows(i).delete()
            End If

        Next
    End Sub

    Private Sub cargarComboInicial()
        Try
            If dtDiagnostico.Columns.Count > 0 Then Exit Sub
            General.cargarCombo(Consultas.PAIS_LISTAR, "Nombre", "Código", Combopais)
            Combopais.SelectedIndex = 0
            General.cargarCombo(Consultas.PAIS_LISTAR, "Nombre", "Código", Combopais_r)
            Combopais_r.SelectedIndex = 0
            General.cargarCombo(Consultas.BUSQUEDA_TIPO_DOCUMENTO, "Descripción", "Código", Combotipoidentificacion)
            General.cargarCombo(Consultas.BUSQUEDA_TIPO_DOCUMENTO, "Descripción", "Código", Combotipodocumento_r)
            General.cargarCombo(Consultas.VIA_INGRESO_BUSCAR, "Descripcion_Via", "Codigo_Via", Combovia)
            General.cargarCombo(Consultas.CAUSA_EXTERNA_LISTAR, "Descripcion Causa", "Código", Combocausa)
            General.cargarCombo(Consultas.TRIAGE_BUSCAR, "Descripcion", "Codigo_Triage", Combotriage)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        idPaciente = -1
    End Sub

    Private Sub permisos()
        ControlFirma()
        ControlFirmaResponsable()
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        Pdocumento = permiso_general & "pp" & "05"
        Ptraslado = permiso_general & "pp" & "06"
        Panexo1 = permiso_general & "pp" & "07"
        Panexo2 = permiso_general & "pp" & "08"
        Panexo3 = permiso_general & "pp" & "09"
        PBuscarRemision = permiso_general & "pp" & "10"
    End Sub

    Private Sub dgvdiagnosticos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdiagnosticos.CellDoubleClick
        Try
            General.abrirJustificacion(dgvdiagnosticos, dtDiagnostico, PanelJustificacion, txtJustificacion, "Observacion", Not btguardar.Enabled)
            If btguardar.Enabled = False Then
                Exit Sub
            End If
            If (dgvdiagnosticos.Rows(dgvdiagnosticos.CurrentCell.RowIndex).Cells("Codigo_CIE").Selected = True Or dgvdiagnosticos.Rows(dgvdiagnosticos.CurrentCell.RowIndex).Cells("Descripcion").Selected = True) And dtDiagnostico.Rows(dgvdiagnosticos.CurrentCell.RowIndex).Item("CODIGO_CIE").ToString = "" Then
                General.agregarItems(Consultas.BUSQUEDA_DIAGNOSTICO_CIE_COMBINADA, TitulosForm.BUSQUEDA_DIAGNOSTICO_CIE, dgvdiagnosticos, dtDiagnostico)
            ElseIf dgvdiagnosticos.Rows(dgvdiagnosticos.CurrentCell.RowIndex).Cells("anulardiagevo").Selected = True And dtDiagnostico.Rows(dgvdiagnosticos.CurrentCell.RowIndex).Item("Codigo_CIE").ToString <> "" Then
                If dtDiagnostico.Rows(dgvdiagnosticos.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_NUEVO Then
                    dtDiagnostico.Rows.RemoveAt(e.RowIndex)
                ElseIf dtDiagnostico.Rows(dgvdiagnosticos.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_CARGADO Then
                    If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then

                        respuesta = General.anularRegistro(Consultas.INGRESO_UCI_ANULAR_DIAG & "'" & Txtcodigo.Text & "','" & dtDiagnostico.Rows(dgvdiagnosticos.CurrentCell.RowIndex).Item("Codigo_CIE") & "'")
                        If respuesta = True Then
                            MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                            General.llenarTablaYdgv(Consultas.CARGAR_DIAGNOSTICOS_ADMISION & "'" & Txtcodigo.Text & "'", dtDiagnostico)
                            dtDiagnostico.Rows.Add()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub dgvtraslados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtraslados.CellDoubleClick
        If dgvtraslados.Rows.Count > 0 Then
            Dim objAdmision As New Admision
            objAdmision.nRegistro = Txtcodigo.Text
            If btguardar.Enabled = False Then
                Exit Sub
            End If

            If ((dgvtraslados.Rows(dgvtraslados.CurrentCell.RowIndex).Cells(1).Selected = True) Or (dgvtraslados.Rows(dgvtraslados.CurrentCell.RowIndex).Cells(2).Selected = True)) And
                dtTraslado.Rows(dgvtraslados.CurrentCell.RowIndex).Item(0).ToString = "" Then
                General.agregarTraslados(dgvtraslados, dtTraslado, Txtcodigo.Text, idTercero)
            ElseIf dgvtraslados.Rows(dgvtraslados.CurrentCell.RowIndex).Cells("anular").Selected = True And
                        dtTraslado.Rows(dgvtraslados.CurrentCell.RowIndex).Item(1).ToString <> "" Then

                If String.IsNullOrEmpty(dtTraslado.Rows(dgvtraslados.CurrentCell.RowIndex).Item(0).ToString) Then
                    dtTraslado.Rows.RemoveAt(e.RowIndex)
                ElseIf dtTraslado.Rows(dgvtraslados.CurrentCell.RowIndex).Item(0).ToString <> "" Then
                    If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                        elementoAEliminar.Add(Consultas.ANULAR_TRASLADO & "'" &
                                              dtTraslado.Rows(dgvtraslados.CurrentCell.RowIndex).Item(0) &
                                              "'," & SesionActual.idUsuario)
                        dtTraslado.Rows.RemoveAt(e.RowIndex)
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub TextEst_Leave(sender As System.Object, e As System.EventArgs) Handles TextEst.Leave
        Panel.Visible = False
        dgvtraslados.Rows(dgvtraslados.CurrentCell.RowIndex).Cells(4).Value = TextEst.Text
    End Sub
    Private Sub Comboservicio_SelectedValueChanged(sender As Object, e As EventArgs) Handles Comboservicio.SelectedValueChanged
        If Comboservicio.SelectedIndex > 0 Then
            General.cargarCombo(Consultas.CAMAS_DISPONIBLES & "'" & Comboservicio.SelectedValue & "','" & SesionActual.codigoEP & "','" & Txtcodigo.Text & "'", "Cama", "Id", Combocama)
        Else
            Combocama.DataSource = Nothing
        End If
    End Sub
    Private Sub Combopais_r_SelectedValueChanged(sender As Object, e As EventArgs) Handles Combopais_r.SelectedValueChanged
        General.cargarCombo(Consultas.DPTO_LISTAR & "'" & Combopais.SelectedValue.ToString & "'", "Nombre", "Codigo_Departamento", Combodepartamento_r)
    End Sub
    Private Sub Combodepartamento_r_SelectedValueChanged(sender As Object, e As EventArgs) Handles Combodepartamento_r.SelectedValueChanged
        General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & Combodepartamento_r.SelectedValue.ToString & "'", "Nombre", "Codigo_Municipio", Combociudad_r)
    End Sub
    Private Sub Combopais_SelectedValueChanged(sender As Object, e As EventArgs) Handles Combopais.SelectedValueChanged
        General.cargarCombo(Consultas.DPTO_LISTAR & "'" & Combopais.SelectedValue.ToString & "'", "Nombre", "Codigo_Departamento", Combodepartamento)
    End Sub
    Private Sub Combodepartamento_SelectedValueChanged(sender As Object, e As EventArgs) Handles Combodepartamento.SelectedValueChanged
        General.cargarCombo(Consultas.CIUDAD_LISTAR & "'" & Combodepartamento.SelectedValue.ToString & "'", "Nombre", "Codigo_Municipio", Combociudad)
    End Sub
    Private Sub dgvtraslados_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvtraslados.CellClick
        If dgvtraslados.Rows.Count > 1 Then

            If e.ColumnIndex = 4 Then
                If Not IsDBNull(dtTraslado.Rows(dgvtraslados.CurrentCell.RowIndex).Item("Codigo_Procedimiento")) Then
                    If String.IsNullOrEmpty(dtTraslado.Rows(dgvtraslados.CurrentCell.RowIndex).Item("Codigo_Procedimiento")) Then
                        Panel.Visible = True
                        TextEst.Clear()
                        TextEst.Select()
                    Else
                        Panel.Visible = True
                        TextEst.Text = dtTraslado.Rows(dgvtraslados.CurrentCell.RowIndex).Item("Observaciones").ToString
                        TextEst.Select()

                        If btguardar.Enabled = False Then
                            TextEst.ReadOnly = True
                        Else
                            TextEst.ReadOnly = False
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub dgvdiagnosticos_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvdiagnosticos.KeyDown
        If dgvdiagnosticos.ReadOnly And btguardar.Enabled = True Then
            If e.KeyCode = Keys.F3 Then
                General.agregarDiagnosticosCIE(dgvdiagnosticos, dtDiagnostico)
            End If
        End If
    End Sub
    Private Sub dgvtraslados_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvtraslados.KeyDown
        If dgvtraslados.ReadOnly = False And btguardar.Enabled = True Then
            If e.KeyCode = Keys.F3 And dgvtraslados.ReadOnly = False Then
                General.agregarTraslados(dgvtraslados, dtTraslado, idTercero, Txtcodigo.Text)
            End If
        End If
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim indiceTab As Integer = TabControl1.SelectedIndex
        Select Case indiceTab
            Case 2
                If String.IsNullOrEmpty(Txtcodigo.Text) Then
                    MsgBox("Solo se puede agregar traslados a un paciente previamente guardado", MsgBoxStyle.Exclamation, "Informacion")
                    TabControl1.SelectedIndex = 0
                End If
            Case 3
                If String.IsNullOrEmpty(Txtcodigo.Text) Then
                    MsgBox("Solo se puede agregar documentos a un paciente previamente guardado", MsgBoxStyle.Exclamation, "Informacion")
                    TabControl1.SelectedIndex = 0
                Else
                    Cursor = Cursors.WaitCursor
                    cargarDocumentos()
                    Cursor = Cursors.Default
                    General.cargarCombo(Consultas.TIPO_DOCUMENTO_EMPLEADO_LISTAR & "'" & Constantes.DOCUMENTO_PACIENTE & "','" & Comboservicio.SelectedValue & "','" & Txtcodigo.Text & "'", "Descripción", "Código", combodescripciondocu)
                    btexaminar.Enabled = True
                    combodescripciondocu.Visible = False
                    Labeltipodoc.Visible = False
                End If

        End Select
    End Sub

    Private Sub btexaminar_Click(sender As Object, e As EventArgs) Handles btexaminar.Click
        General.subirimagen(picturedocu, openimagen, True)
        If IsNothing(picturedocu.Image) Then
            btguardarimagen.Enabled = False
            combodescripciondocu.Visible = False
            Labeltipodoc.Visible = False
        Else
            btguardarimagen.Enabled = True
            combodescripciondocu.Visible = True
            Labeltipodoc.Visible = True
            combodescripciondocu.Enabled = True
            combodescripciondocu.Focus()
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
        elementoAEliminar.Clear()
        txtJustificacion.Clear()
        PanelJustificacion.Visible = False
        frenarTimer()
        If Modal Then
            Me.Dispose()
        End If
        tsTraslado.Enabled = True
        tsPacientes.Enabled = True
        tsRemisiones.Enabled = False
        tsValorConsulta.Enabled = True
        SigPlusNET1.ClearTablet()
        SigPlusNET2.ClearTablet()
    End Sub

    Private Sub btguardarimagen_Click(sender As Object, e As EventArgs) Handles btguardarimagen.Click
        If combodescripciondocu.SelectedIndex < 1 Then
            MsgBox("Por favor seleccione el tipo de documento que desea subir", MsgBoxStyle.Exclamation)
            combodescripciondocu.Focus()
        Else
            guardarDocumentos()
        End If
    End Sub
    Private Sub Btfirma_Click(sender As Object, e As EventArgs) Handles Btfirma.Click
        Dim abrirFormularioFirma As Thread
        abrirFormularioFirma = New Thread(AddressOf cargarSegundoPlanoAcompañante)
        abrirFormularioFirma.Name = "Firma Acompañante"
        abrirFormularioFirma.SetApartmentState(ApartmentState.STA)
        abrirFormularioFirma.Start()
    End Sub
    Private Sub cargarSegundoPlanoAcompañante()
        llamarFormularioFirma(Txtcodigo.Text, Btborrar_firma, Picfirma, Constantes.ID_ADMISIONES_A)
    End Sub
    Private Sub cargarSegundoPlanoResponsable()
        llamarFormularioFirma(Txtcodigo.Text, Btborrar_firma, Picfirma, Constantes.ID_ADMISIONES_R)
    End Sub
    Private Sub llamarFormularioFirma(codigo As Integer, boton As Button, Picfirma As PictureBox, idTipo As String)
        Dim objfirma As Object
        Dim lectura As New Topaz.SigPlusNET
        Dim encedido As Boolean = lectura.LCDRefresh(0, 0, 0, 240, 64)

        If encedido = True Then
            objfirma = New FormFirmaDigital
            objfirma.iniciarForm(Me)
            objfirma.crearImagen(idTipo, codigo)
        Else
            objfirma = New Form_firmas
            objfirma.iniciarForm(Me)
            objfirma.crearImagen(idTipo, codigo, Picfirma)
        End If
        objfirma.ShowDialog()
        boton.Enabled = True
    End Sub
    Private Sub Btfirma_r_Click(sender As Object, e As EventArgs) Handles Btfirma_r.Click
        Dim abrirFormularioFirma As Thread
        abrirFormularioFirma = New Thread(AddressOf cargarSegundoPlanoResponsable)
        abrirFormularioFirma.Name = "Firma Responsable"
        abrirFormularioFirma.SetApartmentState(ApartmentState.STA)
        abrirFormularioFirma.Start()
    End Sub
    Private Sub Btborrar_firma_r_Click(sender As Object, e As EventArgs) Handles Btborrar_firma_r.Click
        If MsgBox("Desea eliminar la firma", MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
            respuesta = General.anularRegistro(Consultas.ANULAR_FIRMA_RESPON & CInt(IIf(String.IsNullOrEmpty(Txtcodigo.Text), Constantes.VALOR_PREDETERMINADO, Txtcodigo.Text)))
            If respuesta = True Then
                PicfirmaR.Image = Nothing
                SigPlusNET2.ClearTablet()
            End If
        End If
    End Sub
    Private Sub Btborrar_firma_Click(sender As Object, e As EventArgs) Handles Btborrar_firma.Click
        If MsgBox("Desea eliminar la firma", MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
            respuesta = General.anularRegistro(Consultas.ANULAR_FIRMA_ACOMP & CInt(IIf(String.IsNullOrEmpty(Txtcodigo.Text), Constantes.VALOR_PREDETERMINADO, Txtcodigo.Text)))
            If respuesta = True Then
                Picfirma.Image = Nothing
                SigPlusNET1.ClearTablet()
            End If
        End If
    End Sub
    Private Sub guardarDocumentos()
        Dim objAdmisionBll As New AdmisionBLL
        Dim dtDocumento As New DataTable

        Try

            objAdmisionBll.guardarDocumentos(crearDocumentos(), Consultas.GUARDAR_DOCUMENTOS_ADMISION)
            General.llenarTablaYdgv(Consultas.CARGAR_DOCUMENTOS_ADMISION & CInt(Txtcodigo.Text), dtDocumento)
            General.cargarCombo(Consultas.TIPO_DOCUMENTO_EMPLEADO_LISTAR & "'" & Constantes.DOCUMENTO_PACIENTE & "',
                '" & Comboservicio.SelectedValue & "','" & Txtcodigo.Text & "'", "Descripción", "Código", combodescripciondocu)
            btguardarimagen.Enabled = False
            combodescripciondocu.Visible = False
            Labeltipodoc.Visible = False
            cargarDocumentos()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Private Sub texthc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles texthistoria.KeyDown
        If e.KeyCode = Keys.F3 And texthistoria.ReadOnly = False Then
            General.buscarElemento(Consultas.PACIENTE_BUSQUEDA,
                                   Nothing,
                                   AddressOf cargarPaciente,
                                   TitulosForm.BUSQUEDA_PACIENTE,
                                   False)
        End If
    End Sub

    Public Sub cargarDatosAdmision()
        Dim params As New List(Of String)
        Dim ms As MemoryStream
        Dim ruta As String
        Dim bites() As Byte

        ControlFirma()
        params.Add(Txtcodigo.Text)

        Dim dt As New DataTable
        General.llenarTabla(Consultas.BUSQUEDA_ADMISION_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            textnombrepaciente.Text = dt.Rows(0).Item("paciente").ToString
            Textestrato.Text = dt.Rows(0).Item("CLASE_SOCIAL")
            Textregimen.Text = dt.Rows(0).Item("REGIMEN")
            Texttipoafiliacion.Text = dt.Rows(0).Item("Descripcion_Afiliacion")
            txteps.Text = dt.Rows(0).Item("Nombre_Eps")
            Textcodeps.Text = dt.Rows(0).Item("Codigo_ePS")
            Textdireccion.Text = dt.Rows(0).Item("Direccion").ToString
            Textidentacompañante.Text = dt.Rows(0).Item("Identificacion_A").ToString
            Texttelefono.Text = dt.Rows(0).Item("Telefono_A").ToString
            textnombreacompanante.Text = dt.Rows(0).Item("Acompañante").ToString
            Textcedulatercero.Text = dt.Rows(0).Item("nit").ToString
            idContacto = dt.Rows(0).Item("Id_Contacto").ToString
            Textnombretercero.Text = dt.Rows(0).Item("Contacto").ToString
            emailEPS = dt.Rows(0).Item("email").ToString
            If Not IsDBNull(dt.Rows(0).Item("Codigo_Identificacion_A")) Then
                Combotipoidentificacion.SelectedValue = dt.Rows(0).Item("Codigo_Identificacion_A").ToString
            Else
                Combotipoidentificacion.SelectedValue = Constantes.VALOR_PREDETERMINADO
            End If
            If Not IsDBNull(dt.Rows(0).Item("Codigo_Pais")) Then
                Combopais.SelectedValue = dt.Rows(0).Item("Codigo_Pais").ToString
            Else
                Combopais.SelectedValue = Constantes.VALOR_PREDETERMINADO
            End If
            If Not IsDBNull(dt.Rows(0).Item("Codigo_Departamento")) Then
                Combodepartamento.SelectedValue = dt.Rows(0).Item("Codigo_Departamento").ToString
            Else
                Combodepartamento.SelectedValue = Constantes.VALOR_PREDETERMINADO
            End If
            If Not IsDBNull(dt.Rows(0).Item("Codigo_Municipio")) Then
                Combociudad.SelectedValue = dt.Rows(0).Item("Codigo_Municipio").ToString
            Else
                Combociudad.SelectedValue = Constantes.VALOR_PREDETERMINADO
            End If

            If Not IsDBNull(dt.Rows(0).Item("Firma")) Then
                bites = dt.Rows(0).Item("Firma")
                ms = New MemoryStream(bites)
                Try
                    Picfirma.Image = Image.FromStream(ms)
                    ms.Dispose()
                    bites = Nothing
                    Picfirma.Visible = True
                Catch ex As Exception
                    ruta = Path.GetTempPath & Txtcodigo.Text & "_A" & "SIG"
                    File.WriteAllBytes(ruta, bites)
                    SigPlusNET1.ImportSigFile(ruta)
                    panelFirma.Visible = True
                End Try
            Else
                Picfirma.Visible = True
                Picfirma.Image = Nothing
            End If

            Textdireccion_r.Text = dt.Rows(0).Item("Direccion_R").ToString
            Textidentificacion_responsable.Text = dt.Rows(0).Item("Identificacion_R").ToString
            Texttelefono_r.Text = dt.Rows(0).Item("Telefono_R").ToString
            Textnombre_responsable.Text = dt.Rows(0).Item("Responsable").ToString
            Textobsevacion.Text = dt.Rows(0).Item("observacion").ToString
            If Not IsDBNull(dt.Rows(0).Item("Codigo_Identificacion_R")) Then
                Combotipodocumento_r.SelectedValue = dt.Rows(0).Item("Codigo_Identificacion_R").ToString
            Else
                Combotipodocumento_r.SelectedValue = Constantes.VALOR_PREDETERMINADO
            End If
            If Not IsDBNull(dt.Rows(0).Item("Codigo_Pais_R")) Then
                Combopais_r.SelectedValue = dt.Rows(0).Item("Codigo_Pais_R").ToString
            Else
                Combopais_r.SelectedValue = Constantes.VALOR_PREDETERMINADO
            End If
            If Not IsDBNull(dt.Rows(0).Item("Codigo_Departamento_r")) Then
                Combodepartamento_r.SelectedValue = dt.Rows(0).Item("Codigo_Departamento_r").ToString
            Else
                Combodepartamento_r.SelectedValue = Constantes.VALOR_PREDETERMINADO
            End If
            If Not IsDBNull(dt.Rows(0).Item("Codigo_Municipio_r")) Then
                Combociudad_r.SelectedValue = dt.Rows(0).Item("Codigo_Municipio_r").ToString
            Else
                Combociudad_r.SelectedValue = Constantes.VALOR_PREDETERMINADO
            End If
            If Not IsDBNull(dt.Rows(0).Item("Firma_R")) Then
                bites = dt.Rows(0).Item("Firma_R")
                ms = New MemoryStream(bites)
                Try
                    PicfirmaR.Image = Image.FromStream(ms)
                    ms.Dispose()
                    bites = Nothing
                    PicfirmaR.Visible = True
                Catch ex As Exception
                    ruta = Path.GetTempPath & Txtcodigo.Text & "_R" & "SIG"
                    File.WriteAllBytes(ruta, bites)
                    SigPlusNET2.ImportSigFile(ruta)
                    panelFirmaR.Visible = True
                End Try
            Else
                PicfirmaR.Visible = True
                PicfirmaR.Image = Nothing
            End If
            texthistoria.Text = dt.Rows(0).Item("Documento_paciente")
            Textautorizacion.Text = dt.Rows(0).Item("N_Autorizacion")
            cargarEspecialidad(dt.Rows(0).Item("Codigo_Especialidad"))
            TextcodigoContrato.Text = dt.Rows(0).Item("Codigo_Contrato")
            cargarContrato(TextcodigoContrato.Text)
            Comboservicio.SelectedValue = dt.Rows(0).Item("Codigo_Area_Servicio")
            General.cargarCombo(Consultas.CAMAS_DISPONIBLES & "'" & Comboservicio.SelectedValue & "','" & SesionActual.codigoEP & "','" & Txtcodigo.Text & "'", "Cama", "Id", Combocama)
            Combotriage.SelectedValue = dt.Rows(0).Item("Codigo_Triage")
            idTercero = dt.Rows(0).Item("Id_Eps")
            idPaciente = dt.Rows(0).Item("Identi_Paciente")

            fecha_admision.Value = dt.Rows(0).Item("Fecha_Admision")
            Combocausa.SelectedValue = dt.Rows(0).Item("Causas_Externa")
            Combocama.SelectedValue = dt.Rows(0).Item("Codigo_Cama").ToString
            Combovia.SelectedValue = dt.Rows(0).Item("Via_Ingreso")
            cargarInstitucion(dt.Rows(0).Item("Institucion"))
            nudSaldoSOAT.Value = dt.Rows(0).Item("valorSOAT")
            NumValorConsulta.Value = dt.Rows(0).Item("valorConsulta")
            cbSaldoSOAT.Checked = nudSaldoSOAT.Value > 0
            cargarDiagnisticos()
            cargarTraslados()
            General.deshabilitarControles(Me)
            General.habilitarBotones(Me.ToolStrip1)
            Dim estado As Integer = dt.Rows(0).Item("Codigo_Estado_Atencion")
            Select Case estado
                Case Constantes.ESTADO_ATENCION_INICIADO
                    rbIniciado.Checked = True
                Case Constantes.ESTADO_ATENCION_REVISION
                    rbRevision.Checked = True
                Case Constantes.ESTADO_ATENCION_CERRADO
                    rbCerrado.Checked = True
                Case Constantes.ESTADO_ATENCION_ABIERTO
                    rbReabrir.Checked = True
                Case Constantes.ESTADO_ATENCION_FACTURADO
                    rbFacturado.Checked = True
                Case Constantes.ESTADO_ATENCION_PREFACTURADO
                    rbPrefacturado.Checked = True
                Case Constantes.ESTADO_ATENCION_AUDITORIA
                    rbAuditoria.Checked = True
            End Select

            Btfirma.Enabled = True
            Btfirma_r.Enabled = True
            Btborrar_firma.Enabled = True
            Btborrar_firma_r.Enabled = True
            btguardar.Enabled = False
            btcancelar.Enabled = False
            Checkacomp.Checked = True
            CheckRespon.Checked = True
            TabControl1.SelectedIndex = 0
            habilitarBotonesRaros()
        End If
    End Sub
    Private Sub ControlFirma()
        panelFirma.Visible = False
        Picfirma.Visible = False
    End Sub
    Private Sub ControlFirmaResponsable()
        PicfirmaR.Visible = False
        panelFirmaR.Visible = False
    End Sub
    Public Sub cargarFirmaAcomp(registro)
        Dim params As New List(Of String)
        Dim bites() As Byte
        Dim ms As MemoryStream
        Dim ruta As String
        ControlFirma()
        params.Add(registro)

        Dim dt As New DataTable
        General.llenarTabla(Consultas.FIRMA_ACOMP_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then

            If Not IsDBNull(dt.Rows(0).Item("Firma")) Then

                bites = dt.Rows(0).Item("Firma")
                ms = New MemoryStream(bites)

                Try
                    Picfirma.Refresh()
                    Picfirma.Image = Image.FromStream(ms)
                    Picfirma.Refresh()
                    Picfirma.Visible = True
                Catch ex As Exception
                    ruta = Path.GetTempPath & Txtcodigo.Text & "_A" & "SIG"
                    File.WriteAllBytes(ruta, bites)
                    SigPlusNET1.ImportSigFile(ruta)
                    panelFirma.Visible = True
                End Try

                ms.Dispose()
                bites = Nothing
            Else
                Picfirma.Visible = True
                Picfirma.Image = Nothing
            End If
        End If
    End Sub
    Public Sub cargarFirmaRespon(registro)
        Dim params As New List(Of String)
        Dim bites() As Byte
        Dim ms As MemoryStream
        Dim ruta As String
        ControlFirmaResponsable()
        params.Add(registro)

        Dim dt As New DataTable
        General.llenarTabla(Consultas.FIRMA_RESPON_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            If Not IsDBNull(dt.Rows(0).Item("Firma_R")) Then

                bites = dt.Rows(0).Item("Firma_R")
                ms = New MemoryStream(bites)

                Try
                    PicfirmaR.Refresh()
                    PicfirmaR.Image = Image.FromStream(ms)
                    PicfirmaR.Refresh()
                    PicfirmaR.Visible = True
                Catch ex As Exception
                    ruta = Path.GetTempPath & Txtcodigo.Text & "_R" & "SIG"
                    File.WriteAllBytes(ruta, bites)
                    SigPlusNET2.ImportSigFile(ruta)
                    panelFirmaR.Visible = True
                End Try

                ms.Dispose()
                bites = Nothing
            Else
                PicfirmaR.Visible = True
                PicfirmaR.Image = Nothing
            End If
        End If
    End Sub
    Public Sub cargarEstadoPaciente()
        Dim params As New List(Of String)
        params.Add(Txtcodigo.Text)
        Dim dt As New DataTable
        General.llenarTabla(Consultas.BUSQUEDA_ADMISION_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            General.deshabilitarControles(GroupBox8)
            Dim estado As Integer = dt.Rows(0).Item("Codigo_Estado_Atencion")
            Select Case estado
                Case Constantes.ESTADO_ATENCION_CERRADO
                    If General.consultarPacienteFacturado(Txtcodigo.Text) Then
                        rbFacturado.Enabled = True
                    Else
                        rbReabrir.Enabled = True
                    End If
                Case Constantes.ESTADO_ATENCION_ABIERTO
                    If General.consultarPacienteFacturado(Txtcodigo.Text) Then
                        rbFacturado.Enabled = True
                    Else
                        rbCerrado.Enabled = True
                    End If
                Case Constantes.ESTADO_ATENCION_FACTURADO
                    rbReabrir.Enabled = True
                Case Constantes.ESTADO_ATENCION_PREFACTURADO
                    rbReabrir.Enabled = True
                Case Constantes.ESTADO_ATENCION_AUDITORIA
                    rbReabrir.Enabled = True
            End Select
        End If
    End Sub
    Private Sub dgvdocumentos_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvdocumentos.DataError

    End Sub
    Private Sub cargarTraslados()
        General.llenarTablaYdgv(Consultas.CARGAR_TRASLADOS_ADMISION & "'" & Txtcodigo.Text & "'", dtTraslado)
    End Sub
    Private Sub cargarDiagnisticos()
        General.llenarTablaYdgv(Consultas.CARGAR_DIAGNOSTICOS_ADMISION & "'" & Txtcodigo.Text & "'", dtDiagnostico)
        For indiceDiagnostico = 0 To dtDiagnostico.Rows.Count - 1
            dtDiagnostico.Rows(indiceDiagnostico).Item("Estado") = Constantes.ITEM_CARGADO
        Next
    End Sub

    Private Sub Form__FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Modal Then Exit Sub
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


    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                edicion()
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub edicion()
        General.habilitarControles(Me)
        General.deshabilitarBotones(ToolStrip1)
        cargarEstadoPaciente()
        elementoAEliminar.Clear()
        TextEst.ReadOnly = False
        textnombrepaciente.ReadOnly = True
        Textestrato.ReadOnly = True
        Textregimen.ReadOnly = True
        Texttipoafiliacion.ReadOnly = True
        txteps.ReadOnly = True
        Textcodeps.ReadOnly = True
        Btfirma.Enabled = False
        Btfirma_r.Enabled = False
        Btborrar_firma.Enabled = False
        Btborrar_firma_r.Enabled = False
        dtDiagnostico.Rows.Add()
        dtTraslado.Rows.Add()
        btguardar.Enabled = True
        btcancelar.Enabled = True
        Textcedulatercero.ReadOnly = True
        TextcodigoContrato.ReadOnly = True
        Textnombretercero.ReadOnly = True
        Textnombrecontrato.ReadOnly = True
        btguardarimagen.Enabled = False
        dgvdiagnosticos.ReadOnly = True
        dgvtraslados.ReadOnly = True
        textEspecialidad.ReadOnly = True
        TextInstitucion.ReadOnly = True
        General.deshabilitarControles(GroupBox2)
        fecha_admision.Enabled = True
        With dgvtraslados
            .Columns.Item(0).Visible = False
            .Columns.Item(4).ReadOnly = False
        End With
        cargarSOAT()
        deshabilitarBotonesRaros()
    End Sub

    Private Sub cargarDocumentos()
        Dim params As New List(Of String)
        params.Add(Txtcodigo.Text)
        General.llenarTabla(Consultas.CARGAR_DOCUMENTOS_ADMISION, params, dtImagen)
        If dtImagen.Rows.Count > 0 Then
            asignarImagenDatagrid()
        End If
    End Sub
    Private Sub asignarImagenDatagrid()
        For indice = 0 To dtImagen.Rows.Count - 1
            If dtImagen.Rows(indice).Item("Extension_Doc").ToString = Constantes.FORMATO_PDF Or IsDBNull(dtImagen.Rows(indice).Item("Extension_Doc")) Then
                dgvdocumentos.Rows(indice).Cells(2).Value = My.Resources.picpdf
            End If
        Next
    End Sub
    Public Sub cargarDatosResponsable(identificacion)
        Dim params As New List(Of String)
        params.Add(Txtcodigo.Text)
        Dim dt As New DataTable
        Textidentificacion_responsable.Text = identificacion
        General.llenarTablaYdgv(Consultas.RESPONSABLE_CARGAR_ADMISION & "'" & Textidentificacion_responsable.Text & "'", dt)
        If dt.Rows.Count > 0 Then
            Textdireccion_r.Text = dt.Rows(0).Item("Direccion")
            Texttelefono_r.Text = dt.Rows(0).Item("Telefono")
            Textnombre_responsable.Text = dt.Rows(0).Item("Nombre")
            Combotipodocumento_r.SelectedValue = dt.Rows(0).Item("Codigo_Identificacion")
            Combopais_r.SelectedValue = dt.Rows(0).Item("Codigo_Pais")
            Combodepartamento_r.SelectedValue = dt.Rows(0).Item("Codigo_Departamento")
            Combociudad_r.SelectedValue = dt.Rows(0).Item("Codigo_Municipio")
            If Not IsDBNull(dt.Rows(0).Item("Firma")) Then
                Dim bites() As Byte = dt.Rows(0).Item("Firma")
                Dim ms As New MemoryStream(bites)
                Picfirma.Image = Image.FromStream(ms)
                ms.Dispose()
                bites = Nothing
            Else
                Picfirma.Image = Nothing
            End If
        End If
    End Sub
    Public Sub cargarDatosAcompañante(identificacion)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(identificacion)
        General.llenarTabla(Consultas.ACOMPAÑANTE_CARGAR_ADMISION, params, dt)
        If dt.Rows.Count > 0 Then
            Textdireccion.Text = dt.Rows(0).Item("Direccion")
            Textidentacompañante.Text = dt.Rows(0).Item("Id_Acompanante")
            Texttelefono.Text = dt.Rows(0).Item("Telefono")
            textnombreacompanante.Text = dt.Rows(0).Item("Nombre")
            Combotipoidentificacion.SelectedValue = dt.Rows(0).Item("Codigo_Identificacion")
            Combopais.SelectedValue = dt.Rows(0).Item("Codigo_Pais")
            Combodepartamento.SelectedValue = dt.Rows(0).Item("Codigo_Departamento")
            Combociudad.SelectedValue = dt.Rows(0).Item("Codigo_Municipio")
            If Not IsDBNull(dt.Rows(0).Item("Firma")) Then
                Dim bites() As Byte = dt.Rows(0).Item("Firma")
                Dim ms As New MemoryStream(bites)
                Picfirma.Image = Image.FromStream(ms)
                ms.Dispose()
                bites = Nothing
            Else
                Picfirma.Image = Nothing
            End If

        End If
    End Sub
    Public Sub cargarDatosPaciente()
        Dim objFormPaciente As New Form_paciente
        Dim dtPaciente, dtAdmision As New DataTable
        Dim params As New List(Of String)
        params.Add(texthistoria.Text)
        General.llenarTabla(Consultas.VALIDAR_PACIENTE_ADMISION, params, dtPaciente)
        If dtPaciente.Rows.Count = 0 Then
            General.llenarTabla(Consultas.PACIENTES_CARGAR_ADMISION, params, dtAdmision)
            If dtAdmision.Rows.Count > 0 Then
                textnombrepaciente.Text = dtAdmision.Rows(0).Item("paciente").ToString
                Textestrato.Text = dtAdmision.Rows(0).Item("CLASE_SOCIAL").ToString
                Textregimen.Text = dtAdmision.Rows(0).Item("REGIMEN").ToString
                Texttipoafiliacion.Text = dtAdmision.Rows(0).Item("Descripcion_Afiliacion").ToString
                txteps.Text = dtAdmision.Rows(0).Item("Nombre_Eps").ToString
                Textcodeps.Text = dtAdmision.Rows(0).Item("Codigo_ePS").ToString
                idPaciente = dtAdmision.Rows(0).Item("Identi_Paciente").ToString
                idTercero = dtAdmision.Rows(0).Item("Id_eps").ToString
                TextcodigoContrato.Clear()
                Textnombrecontrato.Clear()
                textnombrepaciente.ReadOnly = True
                Textestrato.ReadOnly = True
                Textregimen.ReadOnly = True
                Texttipoafiliacion.ReadOnly = True
                txteps.ReadOnly = True
                Textcodeps.ReadOnly = True
                btbuscarcontrato.Enabled = True
                btbuscartercero.Enabled = True
            Else
                If MsgBox("La identificación no existe, ¿desea agregar un nuevo paciente?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = vbYes Then
                    If General.verificar_formulario(Form_paciente) = False Then
                        General.cargarForm(objFormPaciente)
                        respuesta = True
                        objFormPaciente.formAdmisiones = Me
                        objFormPaciente.btnuevo.PerformClick()
                        objFormPaciente.textidentificacion.Text = texthistoria.Text
                        btguardar.Enabled = True
                        btcancelar.Enabled = True
                        objFormPaciente.combotipoident.Focus()
                    End If
                End If
            End If
        Else
            Comboservicio.SelectedValue = dtPaciente.Rows(0).Item("Codigo_Area_Servicio")
            MsgBox("Este paciente se encuentra actualmente atendido en: " & Comboservicio.Text.ToLower & "", MsgBoxStyle.Information)
            Txtcodigo.Text = dtPaciente.Rows(0).Item("N_Registro")
            cargarDatosAdmision()
        End If

    End Sub

    Private Sub texthistoria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Texttelefono_r.KeyPress, Texttelefono.KeyPress, texthistoria.KeyPress, Textautorizacion.KeyPress
        ValidacionDigitacion.validarValoresNumericos(e)
        If Asc(e.KeyChar) = 13 Then
            respuesta = False
            cargarDatosPaciente()
        End If
    End Sub
    Private Sub Textidentacompañante_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Textidentacompañante.KeyPress
        ValidacionDigitacion.validarValoresNumericos(e)
        If Asc(e.KeyChar) = 13 Then
            cargarDatosAcompañante(Textidentacompañante.Text)
        End If
    End Sub
    Private Sub Textidentificacion_r_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Textidentificacion_responsable.KeyPress
        ValidacionDigitacion.validarValoresNumericos(e)
        If Asc(e.KeyChar) = 13 Then
            cargarDatosResponsable(Textidentificacion_responsable.Text)
        End If
    End Sub
    Private Sub btcopiar_Click(sender As Object, e As EventArgs) Handles btcopiar.Click
        Textnombre_responsable.Text = textnombreacompanante.Text
        Texttelefono_r.Text = Texttelefono.Text
        Textidentificacion_responsable.Text = Textidentacompañante.Text
        Textdireccion_r.Text = Textdireccion.Text
        Combotipodocumento_r.SelectedValue = Combotipoidentificacion.SelectedValue
        Combopais_r.SelectedValue = Combopais.SelectedValue
        Combodepartamento_r.SelectedValue = Combodepartamento.SelectedValue
        Combociudad_r.SelectedValue = Combociudad.SelectedValue
        PicfirmaR.Image = Picfirma.Image
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Dim objAdmision As New Admision
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        objAdmision.nRegistro = Txtcodigo.Text
        Try
            objAdmision.imprimirReporte()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub
    Private Sub guardarReporte()
        Try

            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_ADMISION, Txtcodigo.Text, New rpt_Admisiones,
                                        Txtcodigo.Text, "{VISTA_ADMISION.N_Registro} = " & Txtcodigo.Text & "",
                                       ConstantesHC.NOMBRE_PDF_ADMISION, IO.Path.GetTempPath)

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    'Private Sub guardarSegundoPlano()
    '    guardarEn2doPlano = New Thread(AddressOf guardarReporte)
    '    guardarEn2doPlano.Name = "Guardar Admision"
    '    guardarEn2doPlano.SetApartmentState(ApartmentState.STA)
    '    guardarEn2doPlano.Start()
    'End Sub
    'Private Sub btanexo2_Click(sender As Object, e As EventArgs) Handles btOpcionAnexo2.Click
    '    If SesionActual.tienePermiso(Panexo2) Then
    '        If Txtcodigo.Text = "" Then
    '            MsgBox("Por favor seleccione un paciente.", MsgBoxStyle.Exclamation)
    '            Exit Sub
    '        End If
    '        FormPrincipal.Cursor = Cursors.WaitCursor
    '        Dim anexo2 As New FormAnexo2
    '        anexo2.txtregistro.Text = Txtcodigo.Text
    '        anexo2.CargarPaciente()
    '        anexo2.ShowDialog()
    '        FormPrincipal.Cursor = Cursors.Default
    '    Else
    '        MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
    '    End If
    'End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add("")
            params.Add(SesionActual.codigoEP)
            General.buscarElemento(Consultas.BUSQUEDA_ADMISION,
                                   params,
                                   AddressOf cargarAdmision,
                                   TitulosForm.BUSQUEDA_ADMISION,
                                   False, 0, True)

        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub cargarAdmision(pCodigo As String)
        Txtcodigo.Text = pCodigo
        TimerAlerta.Stop()
        cargarDatosAdmision()
        tsDocumentos.Enabled = True
        tsRemisiones.Enabled = False
        tsDocumentos.BackColor = Color.Gainsboro
        TimerAlerta.Start() '---colocado por lycans para la lista de documentos no quitar
        verificarDocumentos()
    End Sub

    Public Sub cargarPaciente(pCodigo As String)
        Dim drPaciente As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        drPaciente = General.cargarItem(Consultas.PACIENTE_CARGAR, params)
        If Not IsNothing(drPaciente) Then
            texthistoria.Text = drPaciente.Item(1).ToString()
            cargarDatosPaciente()
            cbSaldoSOAT.Checked = False
        Else
            idRemision = Nothing
            MsgBox("No se encuentran los datos del paciente!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        End If
        If idRemision > 0 Then
            cargarInformacionRemisionExterior(idRemision)
        End If
    End Sub


    Private Sub dgvdocumentos_CellContentClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvdocumentos.CellContentClick
        If dgvdocumentos.Rows.Count > 0 Then
            Dim bites() As Byte = dgvdocumentos.SelectedCells(2).Value
            Dim ms As New MemoryStream(bites)
            With picturedocu
                If dtImagen.Rows(dgvdocumentos.CurrentCell.RowIndex).Item("Extension_Doc").ToString = Constantes.FORMATO_PDF Then
                    .Image = My.Resources.picpdf
                Else
                    .Image = Image.FromStream(ms)
                    .SizeMode = PictureBoxSizeMode.Zoom
                    .BorderStyle = BorderStyle.None
                End If
            End With
        End If
    End Sub
    Private Sub dgvdocumentos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdocumentos.CellDoubleClick
        If e.ColumnIndex = 4 Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                respuesta = General.anularRegistro(Consultas.ELIMINAR_DOCUMENTO & "
            '" & dgvdocumentos.Rows(dgvdocumentos.CurrentRow.Index).Cells(0).Value & "','" & Constantes.ID_ADMISIONES_A & "' ")
                If respuesta = True Then
                    cargarDocumentos()
                    picturedocu.Image = Nothing
                    General.cargarCombo(Consultas.TIPO_DOCUMENTO_EMPLEADO_LISTAR & "'" & Constantes.DOCUMENTO_PACIENTE & "','" & Comboservicio.SelectedValue & "','" &
                                     Txtcodigo.Text & "'", "Descripción", "Código", combodescripciondocu)
                End If
            End If
        ElseIf e.ColumnIndex = 2 Then
            verArchivo()
        End If
    End Sub
    Private Sub verArchivo()
        Dim params As New List(Of String)
        Dim dt As New DataTable
        params.Add(dgvdocumentos.Rows(dgvdocumentos.CurrentRow.Index).Cells(0).Value.ToString())
        Dim tempfileurl As String = System.IO.Path.GetTempPath + DateTime.Now.ToString("yyyyMMdd_HHmmss")
        General.llenarTabla(Consultas.DOCUMENTO_PACIENTE_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            If dtImagen.Rows(dgvdocumentos.CurrentCell.RowIndex).Item("Extension_Doc") = Constantes.FORMATO_PDF Then
                tempfileurl += "-tempdocu" + Constantes.FORMATO_PDF
                My.Computer.FileSystem.WriteAllBytes(tempfileurl, dt.Rows(0).Item("Imagen"), True)
                Process.Start("file://" + tempfileurl)
            Else
                tempfileurl += "-tempimg.png"
                picturedocu.Image.Save(tempfileurl, Imaging.ImageFormat.Png)
                Process.Start("file://" + tempfileurl)
            End If
        End If
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Try
            If SesionActual.tienePermiso(Panular) Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    respuesta = General.anularRegistro(Consultas.ANULAR_ADMISION & SesionActual.idUsuario & "," & CInt(Txtcodigo.Text) & "")

                    If respuesta = True Then
                        frenarTimer()
                        General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                    End If
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Function validarInformacion()

        If texthistoria.Text = "" Then
            MsgBox("Favor seleccionar el paciente", MsgBoxStyle.Exclamation, "Atencion")
            TabControl1.SelectedIndex = 0
            texthistoria.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(textEspecialidad.Text) Then
            MsgBox("Favor seleccionar la especialidad a la que va el paciente", MsgBoxStyle.Exclamation, "Atencion")
            TabControl1.SelectedIndex = 0
            textEspecialidad.Focus()
            Return False
        ElseIf IsDate(fecha_admision.Text) = False Then
            MsgBox("El valor de la Fecha no es valida", MsgBoxStyle.Exclamation, "Atencion")
            TabControl1.SelectedIndex = 0
            fecha_admision.Focus()
            Return False
        ElseIf Combotriage.SelectedIndex = 0 Then
            MsgBox("Por favor seleccione si aplica o no triage", MsgBoxStyle.Exclamation, "Atencion")
            TabControl1.SelectedIndex = 0
            Combotriage.Focus()
            Return False
        ElseIf TextcodigoContrato.Text = "" Then
            MsgBox("Favor seleccionar el Cliente", MsgBoxStyle.Exclamation, "Atencion")
            TabControl1.SelectedIndex = 0
            btbuscarcontrato.Focus()
            Return False
        ElseIf Combotriage.SelectedIndex = 1 OrElse Comboservicio.SelectedIndex > 0 Then
            If Combovia.SelectedIndex < 1 Then
                MsgBox("Favor seleccionar la vía de ingreso", MsgBoxStyle.Exclamation, "Atencion")
                TabControl1.SelectedIndex = 1
                Combovia.Focus()
                Return False
            ElseIf Comboservicio.SelectedIndex < 1 Then
                MsgBox("Favor seleccionar el área de servicio", MsgBoxStyle.Exclamation, "Atencion")
                TabControl1.SelectedIndex = 1
                Comboservicio.Focus()
                Return False
            ElseIf Combocausa.SelectedIndex < 1 Then
                MsgBox("Favor seleccionar la causa del ingreso", MsgBoxStyle.Exclamation, "Atencion")
                TabControl1.SelectedIndex = 1
                Combocausa.Focus()
                Return False
            ElseIf Combocama.SelectedIndex < 1 Then
                MsgBox("Favor seleccionar la cama a la que va el paciente", MsgBoxStyle.Exclamation, "Atencion")
                TabControl1.SelectedIndex = 1
                Combocama.Focus()
                Return False
            ElseIf String.IsNullOrEmpty(TextInstitucion.Text) Then
                MsgBox("Favor seleccionar la Institución de donde viene remitido el paciente", MsgBoxStyle.Exclamation, "Atencion")
                TabControl1.SelectedIndex = 1
                TextInstitucion.Focus()
                Return False
            End If
        End If
        If Checkacomp.Checked = True Then
            If Combotipoidentificacion.SelectedIndex = 0 Then
                MsgBox("Debe seleccionar el tipo de documento del acompañante", MsgBoxStyle.Exclamation, "Atencion")
                TabControl1.SelectedIndex = 0
                Combotipoidentificacion.Focus()
                Return False
            ElseIf Textidentacompañante.Text = "" Then
                MsgBox("Debe digitar la identificacion del acompañante", MsgBoxStyle.Exclamation, "Atencion")
                TabControl1.SelectedIndex = 0
                Textidentacompañante.Focus()
                Return False
            ElseIf textnombreacompanante.Text = "" Then
                MsgBox("Debe digitar el nombre del acompañante", MsgBoxStyle.Exclamation, "Atencion")
                TabControl1.SelectedIndex = 0
                textnombreacompanante.Focus()
                Return False
            End If
        End If
        If CheckRespon.Checked = True Then
            If Combotipodocumento_r.SelectedIndex = 0 Then
                MsgBox("Debe seleccionar el tipo de documento del responsable", MsgBoxStyle.Exclamation, "Atencion")
                TabControl1.SelectedIndex = 0
                Combotipodocumento_r.Focus()
                Return False
            ElseIf Textidentificacion_responsable.Text = "" Then
                MsgBox("Debe digitar la identificacion del responsable", MsgBoxStyle.Exclamation, "Atencion")
                TabControl1.SelectedIndex = 0
                Textidentificacion_responsable.Focus()
                Return False
            ElseIf Textnombre_responsable.Text = "" Then
                MsgBox("Debe digitar el nombre del responsable", MsgBoxStyle.Exclamation, "Atencion")
                TabControl1.SelectedIndex = 0
                Textnombre_responsable.Focus()
                Return False
            End If
        End If
        If dtDiagnostico.Rows.Item(0).Item(0).ToString = "" AndAlso Comboservicio.SelectedIndex > 0 Then
            MsgBox("Favor seleccionar al menos un diagnostico", MsgBoxStyle.Exclamation, "Atencion")
            TabControl1.SelectedIndex = 1
            dgvdiagnosticos.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub btbuscartercero_Click(sender As Object, e As EventArgs) Handles btbuscartercero.Click
        Dim params As New List(Of String)
        params.Add("")
        params.Add(SesionActual.idEmpresa)
        General.buscarElemento(Consultas.BUSQUEDA_TERCERO_CLIENTE,
                              params,
                              AddressOf cargarTercero,
                              TitulosForm.BUSQUEDA_TERCERO,
                              True, 0, True)
    End Sub
    Private Sub cargarTercero(pCodigo As Integer)
        Dim dtTercero As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.TERCERO_CARGAR, params, dtTercero)
        If dtTercero.Rows.Count > 0 Then
            idContacto = pCodigo
            Textcedulatercero.Text = dtTercero.Rows(0).Item("NIT").ToString()
            Textnombretercero.Text = dtTercero.Rows(0).Item("Tercero").ToString()
        End If
    End Sub

    Private Sub btbuscarcontrato_Click(sender As Object, e As EventArgs) Handles btbuscarcontrato.Click
        Dim params As New List(Of String)
        params.Add(idTercero)
        params.Add(SesionActual.codigoEP)
        General.buscarElemento(Consultas.CLIENTES_EPS_LISTAR,
                             params,
                             AddressOf cargarContrato,
                             TitulosForm.BUSQUEDA_CONTRATO,
                             False, 0, True)
    End Sub
    Private Sub cargarContrato(pCodigo As Integer)
        Dim dtContrato As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.BUSQUEDA_CONTRATO_CARGAR, params, dtContrato)
        If dtContrato.Rows.Count > 0 Then
            TextcodigoContrato.Text = pCodigo
            Textnombrecontrato.Text = IIf(dtContrato.Rows(0).Item("Valor_Evento").ToString() > 0, "Evento", "Capitado") & " - " & dtContrato.Rows(0).Item("CLIENTE").ToString()
            emailEPS = dtContrato.Rows(0).Item("email").ToString
            Combotriage.Focus()
            General.cargarCombo(Consultas.AREA_SERVICIO_LISTAR_CONTRATO & "" & SesionActual.codigoEP & ",'','" & pCodigo & "',''", "Descripción", "Código", Comboservicio)
        End If
    End Sub
    Private Function validarEstadoAtencion()
        Select Case True
            Case rbIniciado.Checked
                estadoAtencion = Constantes.ESTADO_ATENCION_INICIADO
            Case rbRevision.Checked
                estadoAtencion = Constantes.ESTADO_ATENCION_REVISION
            Case rbAuditoria.Checked
                estadoAtencion = Constantes.ESTADO_ATENCION_AUDITORIA
            Case rbCerrado.Checked
                estadoAtencion = Constantes.ESTADO_ATENCION_CERRADO
            Case rbFacturado.Checked
                estadoAtencion = Constantes.ESTADO_ATENCION_FACTURADO
            Case rbPrefacturado.Checked
                estadoAtencion = Constantes.ESTADO_ATENCION_PREFACTURADO
            Case rbReabrir.Checked
                estadoAtencion = Constantes.ESTADO_ATENCION_ABIERTO
        End Select
        Return estadoAtencion
    End Function

    Private Sub Textidentacompañante_Leave(sender As Object, e As EventArgs) Handles Textidentacompañante.Leave
        If Textidentacompañante.Text <> String.Empty Then
            cargarDatosAcompañante(Textidentacompañante.Text)
        End If
    End Sub

    Private Sub Checkacomp_CheckedChanged(sender As Object, e As EventArgs) Handles Checkacomp.CheckedChanged
        If Checkacomp.Checked = True Then
            GrupoAcomp.Enabled = True
        Else
            GrupoAcomp.Enabled = False
            Checkacomp.Enabled = True
        End If
    End Sub



    Public Sub verificarDocumentos()
        '--no quitar att lycans,
        'recorre el indice si encuentra un cero es porque hay documentos pendientes
        If String.IsNullOrEmpty(Txtcodigo.Text) Then Exit Sub
        objLista.registro = Txtcodigo.Text
        Dim dt = objLista.verificarDocumentos()
        For i = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item("indice") = 0 Then
                tsDocumentos.BackColor = Color.Salmon
                Exit Sub
            Else
                tsDocumentos.BackColor = Color.SeaGreen
            End If
        Next
    End Sub

    Private Sub TimerAlerta_Tick(sender As Object, e As EventArgs) Handles TimerAlerta.Tick
        verificarDocumentos()
    End Sub

    Private Sub CheckRespon_CheckedChanged(sender As Object, e As EventArgs) Handles CheckRespon.CheckedChanged
        If CheckRespon.Checked = True Then
            GrupoRespon.Enabled = True
        Else
            GrupoRespon.Enabled = False
            CheckRespon.Enabled = True
        End If
    End Sub

    Private Sub cbSaldoSOAT_CheckedChanged(sender As CheckBox, e As EventArgs) Handles cbSaldoSOAT.CheckedChanged
        cargarSOAT()
    End Sub
    Private Sub cargarSOAT()
        nudSaldoSOAT.ReadOnly = Not (cbSaldoSOAT.Checked AndAlso btguardar.Enabled)
        nudSaldoSOAT.Enabled = (cbSaldoSOAT.Checked AndAlso btguardar.Enabled)
    End Sub

    Private Sub btBuscarEPROC_Click(sender As Object, e As EventArgs) Handles btBuscarEsp.Click
        Dim params As New List(Of String)
        General.buscarElemento(Consultas.ESPECIALIDAD_LISTAR,
                             Nothing,
                             AddressOf cargarEspecialidad,
                             TitulosForm.BUSQUEDA_CONTRATO,
                             False, 0, True)
    End Sub
    Private Sub cargarEspecialidad(pCodigo As Integer)
        Dim dtEspecialidad As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.BUSQUEDA_ESPECIALIDADES_CARGAR, params, dtEspecialidad)
        If dtEspecialidad.Rows.Count > 0 Then
            idEspecialidad = pCodigo
            textEspecialidad.Text = dtEspecialidad.Rows(0).Item("Descripción").ToString()
        End If
    End Sub

    Private Sub btInstitucion_Click(sender As Object, e As EventArgs) Handles btInstitucion.Click
        Dim params As New List(Of String)
        General.buscarElemento(Consultas.INSTITUCIONES_LISTAR,
                               Nothing,
                               AddressOf cargarInstitucion,
                               TitulosForm.BUSQUEDA_INSTITUCION,
                               True,
                               0,
                               True)
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        If cbSaldoSOAT.Checked = True Then
            Dim form As New FormFuRips
            form.pasarRegistro(Txtcodigo.Text, Tag.modulo)
            General.cargarForm(form)
        Else
            MsgBox("Esta admision no aplica SOAT", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub cargarInstitucion(pCodigo As Integer)
        Dim dtInstitucion As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.INSTITUCIONES_CARGAR, params, dtInstitucion)
        idInstitucion = pCodigo
        If dtInstitucion.Rows.Count > 0 Then
            TextInstitucion.Text = dtInstitucion.Rows(0).Item("Descripcion_Institucion").ToString()
        End If
    End Sub

    Private Sub btOpcionAnex1_Click(sender As Object, e As EventArgs)
        If SesionActual.tienePermiso(Panexo1) Then
            If Txtcodigo.Text = "" Then
                MsgBox("Por favor seleccione un paciente.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            Dim cmd As New Anexo1BLL
            Dim anexo1 As New FormAnexo1
            FormPrincipal.Cursor = Cursors.WaitCursor
            anexo1.txtpaciente.Text = textnombrepaciente.Text
            anexo1.txtcontrato.Text = txteps.Text
            anexo1.txtidentificacion.Text = texthistoria.Text
            anexo1.txtregistro.Text = Txtcodigo.Text
            anexo1.VerificarRegistro()
            anexo1.txttipoinforme.Text = Constantes.CORRECCION_INCONSISTENCIAS
            anexo1.ShowDialog()
            FormPrincipal.Cursor = Cursors.Default
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub Anexo1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Anexo1ToolStripMenuItem.Click
        If SesionActual.tienePermiso(Panexo1) Then
            If Txtcodigo.Text = "" Then
                MsgBox("Por favor seleccione un paciente.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            Dim cmd As New Anexo1BLL
            Dim anexo1 As New FormAnexo1
            FormPrincipal.Cursor = Cursors.WaitCursor
            anexo1.txtpaciente.Text = textnombrepaciente.Text
            anexo1.txtcontrato.Text = txteps.Text
            anexo1.txtidentificacion.Text = texthistoria.Text
            anexo1.txtregistro.Text = Txtcodigo.Text
            anexo1.VerificarRegistro()
            anexo1.txttipoinforme.Text = Constantes.CORRECCION_INCONSISTENCIAS
            anexo1.ShowDialog()
            FormPrincipal.Cursor = Cursors.Default
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Anexo3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Anexo3ToolStripMenuItem.Click
        If SesionActual.tienePermiso(Panexo3) Then
            If Txtcodigo.Text = "" Then
                MsgBox("Por favor seleccione un paciente.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            Dim anexo3 As New FormAnexo3
            Dim params As New List(Of String)
            params.Add(Txtcodigo.Text)
            params.Add(textnombrepaciente.Text)
            params.Add(texthistoria.Text)
            params.Add(txteps.Text)
            params.Add(Constantes.AUTORIZACION_SERVICIO)
            params.Add(Comboservicio.SelectedValue)
            params.Add(IIf(Comboservicio.SelectedValue < 0, "", Comboservicio.Text))
            params.Add(emailEPS)
            anexo3.iniciarForm(params)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub ImprCertificadoSoatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprCertificadoSoatToolStripMenuItem.Click
        If Not String.IsNullOrEmpty(Txtcodigo.Text) And cbSaldoSOAT.Checked = True Then
            Dim objAdmision As New Admision
            Cursor = Cursors.WaitCursor
            btimprimir.Enabled = False
            objAdmision.nRegistro = Txtcodigo.Text
            Try
                objAdmision.imprimirCertificado()
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
            btimprimir.Enabled = True
            Cursor = Cursors.Default
            btimprimir.Enabled = True
            Cursor = Cursors.Default
        Else
            MsgBox("No puedes imprimir el certificado porque el paciente no es atencion SOAT", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub FuRipsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FuRipsToolStripMenuItem.Click
        If cbSaldoSOAT.Checked = True Then
            Dim form As New FormFuRips
            form.pasarRegistro(Txtcodigo.Text, Tag.modulo)
            General.cargarForm(form)
        Else
            MsgBox("Esta admision no aplica SOAT", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btImprimirRecibo_Click(sender As Object, e As EventArgs) Handles btImprimirRecibo.Click
        Dim valorLetra As String
        Dim rptValorConsulta As New rptValorConsulta
        Dim Convertir As New ConvertirNumeros
        Convertir.Convertir_Numero(NumValorConsulta.Value)
        valorLetra = Convertir.NumeroConvertido
        Try
            Dim tbl As New Hashtable
            tbl.Add("@valorConsulta", NumValorConsulta.Value)
            tbl.Add("@valorEnLetras", valorLetra)
            tbl.Add("@usuario", SesionActual.nombreCompleto)
            Cursor = Cursors.WaitCursor
            Funciones.getReporteNoFTP(rptValorConsulta, "{VISTA_PACIENTES.N_Registro} = " & Txtcodigo.Text & "AND {VISTA_EMPRESAS.Id_empresa}=" & SesionActual.idEmpresa & "", "Recibo Atención", Constantes.FORMATO_PDF, tbl)
            Cursor = Cursors.Default
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub TrasladosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsTraslado.Click
        If SesionActual.tienePermiso(Ptraslado) Then
            Dim TrasladoAmbulancia As New Form_Traslado_Ambulancia
            TrasladoAmbulancia.ShowDialog()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub EspecialidadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsEspecialidades.Click
        Dim especialidad As New Form_especialidades
        especialidad.ShowDialog()
    End Sub
    Private Sub ValorConsultaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsValorConsulta.Click
        General.cargarForm(FormConsolidadoConsulta)
    End Sub

    Private Sub PacienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsPacientes.Click
        Dim vFormPaciente As New Form_paciente
        vFormPaciente.ShowDialog()
    End Sub

    Private Sub ListaDeDocumentosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDocumentos.Click
        If Not String.IsNullOrEmpty(Txtcodigo.Text) Then
            Dim listado As New FormListaAdmision
            listado.cargarRegistro(Txtcodigo.Text)
            General.cargarForm(listado)
        End If
    End Sub
    Private Sub tsRemisiones_Click(sender As Object, e As EventArgs) Handles tsRemisiones.Click
        If SesionActual.tienePermiso(PBuscarRemision) Then
            Dim params As New List(Of String)
            params.Add("")
            params.Add(SesionActual.codigoEP)
            General.buscarItem(Consultas.PACIENTE_BUSQUEDA_REMISION,
                                   params,
                                   AddressOf cargarPacienteRemisionado,
                                   TitulosForm.BUSQUEDA_ADMISION,
                                   False,
                                   Constantes.TAMANO_MEDIANO,
                                   True)

        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Anexo2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Anexo2ToolStripMenuItem.Click
        If SesionActual.tienePermiso(Panexo2) Then
            If Txtcodigo.Text = "" Then
                MsgBox("Por favor seleccione un paciente.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            FormPrincipal.Cursor = Cursors.WaitCursor
            Dim anexo2 As New FormAnexo2
            anexo2.txtregistro.Text = Txtcodigo.Text
            anexo2.CargarPaciente()
            anexo2.ShowDialog()
            FormPrincipal.Cursor = Cursors.Default
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Combotipoidentificacion_SelectedValueChanged(sender As Object, e As EventArgs) Handles Combotipoidentificacion.SelectedValueChanged
        If Combotipoidentificacion.SelectedIndex > 0 Then

            If Combotipoidentificacion.SelectedValue = Constantes.DOCUMENTO_ADULTO_SIN_IDENTIFICACION Then
                Textidentacompañante.ReadOnly = True
                Textidentacompañante.Text = Constantes.TEXTO_NO_APLICA
            Else
                Textidentacompañante.ReadOnly = False
            End If
        End If
    End Sub
    Private Sub Combotipodocumento_r_SelectedValueChanged(sender As Object, e As EventArgs) Handles Combotipodocumento_r.SelectedValueChanged
        If Combotipodocumento_r.SelectedIndex > 0 Then
            If Combotipodocumento_r.SelectedValue = Constantes.DOCUMENTO_ADULTO_SIN_IDENTIFICACION Then
                Textidentificacion_responsable.ReadOnly = True
                Textidentificacion_responsable.Text = Constantes.TEXTO_NO_APLICA
            Else
                Textidentificacion_responsable.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub texthistoria_Leave(sender As Object, e As EventArgs) Handles texthistoria.Leave
        If texthistoria.Text <> String.Empty And respuesta = True And General.verificar_formulario(Form_paciente) = False Then
            cargarDatosPaciente()
        End If
    End Sub

    Private Sub btbuscarcliente_Click(sender As Object, e As EventArgs) Handles btbuscarpaciente.Click
        General.buscarElemento(Consultas.PACIENTE_BUSQUEDA,
                               Nothing,
                               AddressOf cargarPaciente,
                               TitulosForm.BUSQUEDA_PACIENTE,
                               True,
                               0,
                               True)

    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarInformacion() Then
            txtJustificacion_Leave(sender, e)
            guardarAdmision()
        End If
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            dtDiagnostico.Rows.Add()
            dtTraslado.Rows.Add()
            elementoAEliminar.Clear()
            textnombrepaciente.ReadOnly = True
            Textestrato.ReadOnly = True
            Textregimen.ReadOnly = True
            Texttipoafiliacion.ReadOnly = True
            txteps.ReadOnly = True
            Textcodeps.ReadOnly = True
            Btfirma.Enabled = False
            Btfirma_r.Enabled = False
            Btborrar_firma.Enabled = False
            Btborrar_firma_r.Enabled = False
            GroupBox8.Enabled = True
            Comboservicio.SelectedValue = Constantes.VALOR_PREDETERMINADO
            TabControl1.SelectedIndex = 0
            texthistoria.Focus()
            Textcedulatercero.ReadOnly = True
            TextcodigoContrato.ReadOnly = True
            Textnombretercero.ReadOnly = True
            Textnombrecontrato.ReadOnly = True
            Checkacomp.Checked = True
            CheckRespon.Checked = True
            dgvdiagnosticos.ReadOnly = True
            rbIniciado.Checked = True
            textEspecialidad.ReadOnly = True
            TextInstitucion.ReadOnly = True
            frenarTimer()
            nudSaldoSOAT.Enabled = False
            Groupoestados.Enabled = True
            rbCerrado.Enabled = False
            rbFacturado.Enabled = False
            rbReabrir.Enabled = False
            rbRevision.Enabled = False
            rbPrefacturado.Enabled = False
            idInstitucion = Constantes.VALOR_PREDETERMINADO
            deshabilitarBotonesRaros()
            btbuscarcontrato.Enabled = False
            btbuscartercero.Enabled = False
            SigPlusNET1.ClearTablet()
            SigPlusNET2.ClearTablet()
            tsRemisiones.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub frenarTimer()
        TimerAlerta.Stop()
        tsDocumentos.BackColor = Color.Gainsboro
    End Sub
    Private Sub dgv_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvdiagnosticos.KeyPress
        General.abrirJustificacion(dgvdiagnosticos, dtDiagnostico, PanelJustificacion, txtJustificacion, "Observacion", Not btguardar.Enabled, e.KeyChar)
    End Sub
    Private Sub txtJustificacion_Leave(sender As Object, e As EventArgs) Handles txtJustificacion.Leave
        Try
            If PanelJustificacion.Visible = True Then
                PanelJustificacion.Visible = False
                dgvdiagnosticos.Rows(dgvdiagnosticos.CurrentRow.Index).Cells("Observacion").Value = txtJustificacion.Text
                txtJustificacion.Clear()
                dtDiagnostico.AcceptChanges()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Private Sub guardarAdmision()
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

            Dim objAdmisionBll As New AdmisionBLL
            Try

                Txtcodigo.Text = objAdmisionBll.guardarAdmision(crearAdmision())
                cargarDiagnisticos()
                guardarTraslado()
                cargarTraslados()
                'guardarSegundoPlano()
                'guardarReporte()
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)

                General.deshabilitarControles(Me)
                General.habilitarBotones(Me.ToolStrip1)
                Btfirma.Enabled = True
                Btfirma_r.Enabled = True
                btguardar.Enabled = False
                btcancelar.Enabled = False
                habilitarBotonesRaros()
                tsPacientes.Enabled = True
                tsTraslado.Enabled = True
                tsRemisiones.Enabled = False
                If Modal Then
                    If txtCodigoSolicitud.Text <> Constantes.VALOR_PREDETERMINADO Then
                        MsgBox(Mensajes.NUEVA_ADMISION_GENERADA & Txtcodigo.Text, MsgBoxStyle.Information)
                    End If
                    Close()
                End If
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
    Private Sub guardarTraslado()
        If dgvtraslados.RowCount > 1 Then
            Try
                AdmisionBLL.guardarTraslado(crearAdmision(), elementoAEliminar)
                General.deshabilitarControles(Me)
                General.habilitarBotones(Me.ToolStrip1)
                btguardar.Enabled = False
                btcancelar.Enabled = False
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
    Public Function crearAdmision() As Admision
        Dim objAdmision As New Admision
        objAdmision.codigoEstado = validarEstadoAtencion()
        objAdmision.solicitud = txtCodigoSolicitud.Text
        objAdmision.nRegistro = Txtcodigo.Text
        objAdmision.identiPaciente = idPaciente
        objAdmision.fechaAdmision = fecha_admision.Value
        objAdmision.CodigoEp = SesionActual.codigoEP
        objAdmision.codigoEspecialidad = idEspecialidad
        objAdmision.codigoTriage = Combotriage.SelectedValue
        objAdmision.codigoContrato = TextcodigoContrato.Text
        objAdmision.codigoArea = Comboservicio.SelectedValue
        objAdmision.idContacto = IIf(String.IsNullOrEmpty(Textcedulatercero.Text), Constantes.VALOR_PREDETERMINADO, idContacto)
        objAdmision.codigoIdAcompanate = Combotipoidentificacion.SelectedValue
        objAdmision.idAcompanate = Textidentacompañante.Text
        objAdmision.acompanante = textnombreacompanante.Text
        objAdmision.Direccion = Textdireccion.Text
        objAdmision.telAcompanate = Texttelefono.Text
        objAdmision.codigoPais = Combopais.SelectedValue
        objAdmision.codigoDepartamento = Combodepartamento.SelectedValue
        objAdmision.codigoMunicipio = Combociudad.SelectedValue
        objAdmision.codigoIdResponsable = Combotipodocumento_r.SelectedValue
        objAdmision.idResponsable = Textidentificacion_responsable.Text
        objAdmision.responsable = Textnombre_responsable.Text
        objAdmision.direccionResponsable = Textdireccion_r.Text
        objAdmision.telResponsable = Texttelefono_r.Text
        objAdmision.codigoPaisResponsable = Combopais_r.SelectedValue
        objAdmision.codigoDepartamentoResponsable = Combodepartamento_r.SelectedValue
        objAdmision.codigoMunicipioResponsable = Combociudad_r.SelectedValue
        objAdmision.usuario = SesionActual.idUsuario
        objAdmision.numAutorizacion = Textautorizacion.Text
        objAdmision.viaIngreso = Combovia.SelectedValue
        objAdmision.institucion = idInstitucion
        objAdmision.causaExterna = Combocausa.SelectedValue
        objAdmision.codigoEstado = estadoAtencion
        objAdmision.codigoCama = IIf(IsNothing(Combocama.SelectedValue), Constantes.VALOR_PREDETERMINADO, Combocama.SelectedValue)
        objAdmision.dtDiagnostico = dtDiagnostico
        objAdmision.dtTraslado = dtTraslado
        objAdmision.opcionRespon = CheckRespon.Checked
        objAdmision.opcionAcomp = Checkacomp.Checked
        objAdmision.observacion = Textobsevacion.Text
        objAdmision.documentoPaciente = texthistoria.Text
        objAdmision.valorSOAT = nudSaldoSOAT.Value
        objAdmision.valorConsulta = NumValorConsulta.Value
        objAdmision.remisionExterna = idRemision
        Return objAdmision
    End Function
    Public Function crearDocumentos() As Admision
        Dim objAdmision As New Admision
        Dim arrFile() As Byte
        Dim ms As New MemoryStream
        picturedocu.Image.Save(ms, Imaging.ImageFormat.Jpeg)
        arrFile = File.ReadAllBytes(openimagen.FileName)
        objAdmision.nRegistro = Txtcodigo.Text
        objAdmision.tipoDocumento = combodescripciondocu.SelectedValue
        objAdmision.imagen = arrFile
        objAdmision.extensionDoc = Path.GetExtension(openimagen.FileName).ToLower()
        objAdmision.tipo = Constantes.ID_ADMISIONES_A
        Return objAdmision
    End Function
    Private Sub habilitarBotonesRaros()
        toolBtOpciones.Enabled = True
    End Sub
    Private Sub deshabilitarBotonesRaros()
        toolBtOpciones.Enabled = False
    End Sub
#Region "Julio"
    Public Sub cargarPacienteRemisionado(fila As DataRow)
        idRemision = fila.Item("Código Remisión")
        cargarPaciente(fila.Item(0))
    End Sub
    Sub cargarInformacionRemisionExterior(ByVal codigo As Integer)
        Dim dts As New DataSet
        Dim params As New List(Of String)
        params.Add(codigo)
        General.llenarDataSet(Consultas.REMISION_EXTERIOR_CARGAR_INFO_REMISION, params, dts)
        Dim tablas As DataTableCollection = dts.Tables
        If tablas.Count > 0 Then
            If tablas.Contains("Table") AndAlso tablas("Table").Rows.Count > 0 Then
                Dim filaActual As DataRow = tablas("Table").Rows(0)
                Combotipoidentificacion.SelectedValue = filaActual.Item("Codigo_Identificacion")
                Textidentacompañante.Text = filaActual.Item("id_acompanante")
                textnombreacompanante.Text = filaActual.Item("nombre")
                Combopais.SelectedValue = filaActual.Item("codigo_pais")
                Combodepartamento.SelectedValue = filaActual.Item("codigo_departamento")
                Combociudad.SelectedValue = filaActual.Item("codigo_municipio")
                Texttelefono.Text = filaActual.Item("telefono")
                Textdireccion.Text = filaActual.Item("direccion")
                Dim bytes() As Byte
                If Not IsDBNull(filaActual.Item("Firma")) Then
                    bytes = filaActual.Item("Firma")
                End If
                cargarFirmas(bytes, "_A", Picfirma, panelFirma, SigPlusNET1)
            End If

            If tablas.Contains("Table1") AndAlso tablas("Table1").Rows.Count > 0 Then
                Dim filaActual As DataRow = tablas("Table1").Rows(0)
                Combotipodocumento_r.SelectedValue = filaActual.Item("Codigo_Identificacion")
                Textidentificacion_responsable.Text = filaActual.Item("id_responsable")
                Textnombre_responsable.Text = filaActual.Item("nombre")
                Combopais_r.SelectedValue = filaActual.Item("codigo_pais")
                Combodepartamento_r.SelectedValue = filaActual.Item("codigo_departamento")
                Combociudad_r.SelectedValue = filaActual.Item("codigo_municipio")
                Texttelefono_r.Text = filaActual.Item("telefono")
                Textdireccion_r.Text = filaActual.Item("direccion")
                Dim bytes() As Byte
                If Not IsDBNull(filaActual.Item("Firma")) Then
                    bytes = filaActual.Item("Firma")
                End If
                cargarFirmas(bytes, "_A", PicfirmaR, panelFirmaR, SigPlusNET2)
            End If

            Dim filaActDiag As DataRowCollection = dtDiagnostico.Rows
            filaActDiag.Clear()
            If tablas.Contains("Table2") AndAlso tablas("Table2").Rows.Count > 0 Then
                For indice = 0 To tablas("Table2").Rows.Count - 1
                    filaActDiag.Add()
                    filaActDiag(filaActDiag.Count - 1).Item("Codigo_CIE") = tablas("Table2").Rows(indice).Item("Codigo_CIE")
                    filaActDiag(filaActDiag.Count - 1).Item("Descripcion") = tablas("Table2").Rows(indice).Item("Descripcion")
                    filaActDiag(filaActDiag.Count - 1).Item("Estado") = Constantes.ITEM_NUEVO
                    filaActDiag(filaActDiag.Count - 1).Item("Observacion") = tablas("Table2").Rows(indice).Item("Observacion")
                Next
            End If
            filaActDiag.Add()
        End If
    End Sub
    Sub cargarFirmas(ByVal bites As Byte(),
                     ByVal tipo As String,
                     ByRef pict As PictureBox,
                     ByRef panel As Panel,
                     ByRef tpz As Topaz.SigPlusNET)

        If Not IsDBNull(bites) AndAlso Not IsNothing(bites) Then
            Dim ruta As String
            Try
                Using ms = New MemoryStream(bites)
                    pict.Image = Image.FromStream(ms)
                End Using
                pict.Visible = True
            Catch ex As Exception
                ruta = Path.GetTempPath & Txtcodigo.Text & tipo & "SIG"
                File.WriteAllBytes(ruta, bites)
                tpz.ImportSigFile(ruta)
                panel.Visible = True
            End Try
        Else
            panel.Visible = False
            pict.Image = Nothing
        End If
    End Sub
#End Region
End Class