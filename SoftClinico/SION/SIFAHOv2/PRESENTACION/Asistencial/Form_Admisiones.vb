Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading
Public Class Form_Admisiones
    Dim dtDocumento, dtTraslado, dtDiagnostico As New DataTable
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim respuesta As Boolean
    Dim estadoAtencion, idPaciente, idTercero As Integer
    Dim guardarEn2doPlano As Thread
    Dim reporte As New ftp_reportes
    Dim arrFile() As Byte
    Dim elementoAEliminar As New List(Of String)

    Private Sub enlazarTablas()
        Dim codigo, descripcion, estado, codigo_t, codigo_cups_t, descripcion_t, valor_t, observacion_t, codigo_tras_t, col1, col2, col3, col4 As New DataColumn

        codigo.ColumnName = "Codigo_CIE"
        codigo.DataType = Type.GetType("System.String")
        dtDiagnostico.Columns.Add(codigo)

        descripcion.ColumnName = "Descripcion"
        descripcion.DataType = Type.GetType("System.String")
        dtDiagnostico.Columns.Add(descripcion)

        estado.ColumnName = "Estado"
        estado.DataType = Type.GetType("System.String")
        dtDiagnostico.Columns.Add(estado)

        codigo = Nothing : descripcion = Nothing : estado = Nothing

        dgvdiagnosticos.DataSource = dtDiagnostico
        dgvdiagnosticos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgvdiagnosticos.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
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
            .Columns("Descripcion").Width = 815
            .Columns("Estado").DataPropertyName = "Estado"
            .Columns("Estado").HeaderText = "Estado"
            .Columns("Estado").Visible = False
            .Columns("anulardiagevo").ReadOnly = True
            .Columns("anulardiagevo").DisplayIndex = CInt(dgvdiagnosticos.ColumnCount - 1)
            .Columns("anulardiagevo").Width = 80
        End With

        '--------------------------------------------------

        codigo_t.ColumnName = "Codigo"
        codigo_t.DataType = Type.GetType("System.String")
        dtTraslado.Columns.Add(codigo_t)

        codigo_cups_t.ColumnName = "Codigo_CUPS"
        codigo_cups_t.DataType = Type.GetType("System.String")
        dtTraslado.Columns.Add(codigo_cups_t)

        descripcion_t.ColumnName = "Descripcion"
        descripcion_t.DataType = Type.GetType("System.String")
        dtTraslado.Columns.Add(descripcion_t)

        valor_t.ColumnName = "Precio"
        valor_t.DataType = Type.GetType("System.String")
        dtTraslado.Columns.Add(valor_t)

        observacion_t.ColumnName = "Observaciones"
        observacion_t.DataType = Type.GetType("System.String")
        dtTraslado.Columns.Add(observacion_t)

        codigo_tras_t.ColumnName = "Codigo_tras"
        codigo_tras_t.DataType = Type.GetType("System.String")
        dtTraslado.Columns.Add(codigo_tras_t)

        With dgvtraslados
            .Columns.Item(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(0).DataPropertyName = "Codigo"
            .Columns.Item(0).ReadOnly = True

            .Columns.Item(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(1).DataPropertyName = "Codigo_CUPS"
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
        dgvtraslados.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        '--------------------------------------------------
        col1.ColumnName = "Codigo_Doc"
        col1.DataType = Type.GetType("System.String")
        col1.DefaultValue = ""
        dtDocumento.Columns.Add(col1)

        col2.ColumnName = "Descripcion"
        col2.DataType = Type.GetType("System.String")
        col2.DefaultValue = ""
        dtDocumento.Columns.Add(col2)

        col3.ColumnName = "Imagen"
        col3.DataType = Type.GetType("System.Byte[]")
        dtDocumento.Columns.Add(col3)

        col4.ColumnName = "Fecha"
        col4.DataType = Type.GetType("System.DateTime")
        dtDocumento.Columns.Add(col4)

        With dgvdocumentos

            .Columns.Item(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(0).DataPropertyName = "Codigo_Doc"

            .Columns.Item(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(1).DataPropertyName = "Descripcion"

            .Columns.Item(2).DataPropertyName = "Imagen"

            .Columns.Item(3).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item(3).DataPropertyName = "Fecha"
        End With


        dgvdocumentos.AutoGenerateColumns = False
        dgvdocumentos.DataSource = dtDocumento
        dgvdocumentos.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Private Sub Form_Admisiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        reporte.usuarioActual = FormPrincipal.usuarioActual
        Panel.Visible = False
        enlazarTablas()
        General.deshabilitarControles(Me)
        Try
            General.cargarCombo(Consultas.PAIS_LISTAR, "Nombre", "Código", Combopais)
            Combopais.SelectedIndex = 0
            General.cargarCombo(Consultas.PAIS_LISTAR, "Nombre", "Código", Combopais_r)
            Combopais_r.SelectedIndex = 0

            General.cargarCombo(Consultas.ESPECIALIDAD_LISTAR, "Descripción", "Código", Comboespecialidad)
            General.cargarCombo(Consultas.CAUSA_EXTERNA_LISTAR, "Descripcion Causa", "Código", Combocausa)
            General.cargarCombo(Consultas.TIPO_IDENTIFICACION_LISTAR, "Descripción", "Código", Combotipoidentificacion)
            General.cargarCombo(Consultas.TIPO_IDENTIFICACION_LISTAR, "Descripción", "Código", Combotipodocumento_r)
            General.cargarCombo(Consultas.BUSQUEDA_TERCERO, "tercero", "Id_tercero", Combocontacto)
            General.cargarCombo(Consultas.AREA_SERVICIO_LISTAR & "" & FormPrincipal.codigoPuntoActual & ",'',''", "Descripción", "Código", Comboservicio)
            General.cargarCombo(Consultas.VIA_INGRESO_LISTAR, "Descripcion_Via", "Codigo_Via", Combovia)
            General.cargarCombo(Consultas.INSTITUCIONES_LISTAR, "Descripción", "Código", Comboinstitucion)

            comboTriaje()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        idPaciente = -1
    End Sub
    Private Sub dgvdiagnosticos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdiagnosticos.CellDoubleClick
        Try
            If btguardar.Enabled = False Then
                Exit Sub
            End If
            If (dgvdiagnosticos.Rows(dgvdiagnosticos.CurrentCell.RowIndex).Cells("Codigo_CIE").Selected = True Or dgvdiagnosticos.Rows(dgvdiagnosticos.CurrentCell.RowIndex).Cells("Descripcion").Selected = True) And dtDiagnostico.Rows(dgvdiagnosticos.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
                General.agregarDiagnosticosCIE(dgvdiagnosticos, dtDiagnostico)
            ElseIf dgvdiagnosticos.Rows(dgvdiagnosticos.CurrentCell.RowIndex).Cells("anulardiagevo").Selected = True And dtDiagnostico.Rows(dgvdiagnosticos.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
                If dtDiagnostico.Rows(dgvdiagnosticos.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_NUEVO Then
                    dtDiagnostico.Rows.RemoveAt(e.RowIndex)
                ElseIf dtDiagnostico.Rows(dgvdiagnosticos.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_CARGADO Then
                    If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then

                        respuesta = General.anularSinTransaccion(Consultas.INGRESO_UCI_ANULAR_DIAG & "'" & Txtcodigo.Text & "','" & dtDiagnostico.Rows(dgvdiagnosticos.CurrentCell.RowIndex).Item("Codigo_CIE") & "'")
                        If respuesta = True Then
                            MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                            General.llenarTablaYdgv(Consultas.CARGAR_DIAGNOSTICOS_ADMISION & "'" & Txtcodigo.Text & "'", dtDiagnostico)
                            dtDiagnostico.Rows.Add()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgvtraslados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtraslados.CellDoubleClick
        If dgvtraslados.Rows.Count > 0 Then

            If btguardar.Enabled = False Then
                Exit Sub
            End If

            If (dgvtraslados.Rows(dgvtraslados.CurrentCell.RowIndex).Cells(1).Selected = True Or
                dgvtraslados.Rows(dgvtraslados.CurrentCell.RowIndex).Cells(2).Selected = True) And
                dtTraslado.Rows(dgvtraslados.CurrentCell.RowIndex).Item(1).ToString = "" Then
                General.agregarTraslados(dgvtraslados, dtTraslado, idTercero)
            ElseIf dgvtraslados.Rows(dgvtraslados.CurrentCell.RowIndex).Cells("anular").Selected = True And
                        dtTraslado.Rows(dgvtraslados.CurrentCell.RowIndex).Item(1).ToString <> "" Then

                If String.IsNullOrEmpty(dtTraslado.Rows(dgvtraslados.CurrentCell.RowIndex).Item(0).ToString) Then
                    dtTraslado.Rows.RemoveAt(e.RowIndex)
                ElseIf dtTraslado.Rows(dgvtraslados.CurrentCell.RowIndex).Item(0).ToString <> "" Then
                    If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                        elementoAEliminar.Add(Consultas.ANULAR_TRASLADO & "'" &
                                              dtTraslado.Rows(dgvtraslados.CurrentCell.RowIndex).Item(0) &
                                              "'," & FormPrincipal.usuarioActual)
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
    Private Sub Comboservicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Comboservicio.SelectedValueChanged
        If Comboservicio.SelectedIndex <> 0 Then
            General.cargarCombo(Consultas.CAMAS_DISPONIBLES & "'" & Comboservicio.SelectedValue & "','" & FormPrincipal.codigoPuntoActual & "','" & Txtcodigo.Text & "'", "Cama", "Id", Combocama)
        End If
    End Sub

    Public Sub comboTriaje()
        Dim dt As New DataTable
        dt.Columns.Add("Codigo")
        dt.Columns.Add("Nombre")
        dt.Rows.Add()
        dt.Rows(0).Item("Codigo") = 0
        dt.Rows(0).Item("Nombre") = "-- Seleccione --"
        dt.Rows.Add()
        dt.Rows(1).Item("Codigo") = "1"
        dt.Rows(1).Item("Nombre") = "NIVEL I"
        dt.Rows.Add()
        dt.Rows(2).Item("Codigo") = "2"
        dt.Rows(2).Item("Nombre") = "NIVEL II"
        dt.Rows.Add()
        dt.Rows(3).Item("Codigo") = "3"
        dt.Rows(3).Item("Nombre") = "NIVEL III"
        dt.Rows.Add()
        dt.Rows(4).Item("Codigo") = "4"
        dt.Rows(4).Item("Nombre") = "NIVEL IV"
        dt.Rows.Add()
        dt.Rows(5).Item("Codigo") = "5"
        dt.Rows(5).Item("Nombre") = "NIVEL V"
        dt.Rows.Add()

        Combotriage.Items.Clear()
        Combotriage.DataSource = Nothing
        Combotriage.DataSource = dt
        Combotriage.DisplayMember = "Nombre"
        Combotriage.ValueMember = "Codigo"
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
    Private Sub combodescripciondocu_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles combodescripciondocu.SelectedIndexChanged
        If combodescripciondocu.SelectedIndex <> 0 Then
            picturedocu.Image = Nothing
            btsubirimagen.Enabled = True
        Else
            picturedocu.Image = Nothing
            btsubirimagen.Enabled = False
        End If
    End Sub
    Private Sub dgvtraslados_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvtraslados.CellClick
        If dgvtraslados.Rows.Count > 1 Then

            If e.ColumnIndex = 4 Then
                If Not IsDBNull(dtTraslado.Rows(dgvtraslados.CurrentCell.RowIndex).Item("Codigo_Cups")) Then
                    If String.IsNullOrEmpty(dtTraslado.Rows(dgvtraslados.CurrentCell.RowIndex).Item("Codigo_Cups")) Then
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
            ElseIf e.ColumnIndex = 6 Then

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
                General.agregarTraslados(dgvtraslados, dtTraslado, idTercero)
            End If
        End If
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 3 Then
            If String.IsNullOrEmpty(Txtcodigo.Text) Then
                MsgBox("Solo se puede agregar documentos a un paciente previamente guardado", 64, "Informacion")
                combodescripciondocu.Enabled = False
                TabControl1.SelectedIndex = 0
            Else
                General.cargarCombo(Consultas.TIPO_DOCUMENTO_EMPLEADO_LISTAR & "'" & Constantes.DOCUMENTO_PACIENTE & "','" & Comboservicio.SelectedValue & "','" & Txtcodigo.Text & "'", "Descripción", "Código", combodescripciondocu)
                combodescripciondocu.Enabled = True
            End If
        ElseIf TabControl1.SelectedIndex = 2 Then
            If String.IsNullOrEmpty(texthistoria.Text) Then
                MsgBox("Debe ingresar los datos del paciente ", 64, "Informacion")
                TabControl1.SelectedIndex = 0
                texthistoria.Focus()
            End If
        End If
    End Sub
    Private Sub btanexo1_Click(sender As Object, e As EventArgs) Handles btOpcionAnexo1.Click
        If Txtcodigo.Text = "" Then
            MsgBox("Por favor seleccione un paciente.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim cmd As New Anexo1BLL
        FormPrincipal.Cursor = Cursors.WaitCursor
        Form_Anexo1.MdiParent = FormPrincipal
        Dim anexo1 As New Form_Anexo1
        anexo1.txtpaciente.Text = textnombrepaciente.Text
        anexo1.txtcontrato.Text = txteps.Text
        anexo1.txtidentificacion.Text = texthistoria.Text
        anexo1.txtregistro.Text = Txtcodigo.Text
        anexo1.VerificarRegistro()
        anexo1.txttipoinforme.Text = Constantes.CORRECCION_INCONSISTENCIAS
        anexo1.ShowDialog()
        FormPrincipal.Cursor = Cursors.Default
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
        elementoAEliminar.Clear()
    End Sub
    Private Sub btsubirimagen_Click(sender As Object, e As EventArgs) Handles btsubirimagen.Click
        General.subirimagen(picturedocu, openimagen)
        If IsNothing(picturedocu.Image) Then
            btguardarimagen.Enabled = False
        Else
            btguardarimagen.Enabled = True
            Using bmp As New Bitmap(picturedocu.Image), ms As New MemoryStream()
                bmp.Save(ms, picturedocu.Image.RawFormat)
                arrFile = ms.GetBuffer
            End Using
        End If
    End Sub
    Private Sub btguardarimagen_Click(sender As Object, e As EventArgs) Handles btguardarimagen.Click
        guardarDocumentos()
    End Sub
    Private Sub Btfirma_Click(sender As Object, e As EventArgs) Handles Btfirma.Click
        Dim objFormFirma As New Form_firmas
        objFormFirma.crearImagen(Constantes.ID_ADMISIONES_A, Txtcodigo.Text, Picfirma)
        objFormFirma.ShowDialog()
        Btborrar_firma.Enabled = True
    End Sub
    Private Sub Btfirma_r_Click(sender As Object, e As EventArgs) Handles Btfirma_r.Click
        Dim objFormFirma As New Form_firmas
        objFormFirma.crearImagen(Constantes.ID_ADMISIONES_R, Txtcodigo.Text, Picfirma)
        Form_firmas.ShowDialog()
        Btborrar_firma.Enabled = True
    End Sub
    Private Sub Btborrar_firma_r_Click(sender As Object, e As EventArgs) Handles Btborrar_firma_r.Click
        If MsgBox("Desea eliminar la firma", MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
            respuesta = General.anularSinTransaccion(Consultas.ANULAR_FIRMA_RESPON & CInt(Txtcodigo.Text) & "")
            If respuesta = True Then
                PicfirmaR.Image = Nothing
            End If
        End If
    End Sub
    Private Sub Btborrar_firma_Click(sender As Object, e As EventArgs) Handles Btborrar_firma.Click
        If MsgBox("Desea eliminar la firma", MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
            respuesta = General.anularSinTransaccion(Consultas.ANULAR_FIRMA_ACOMP & CInt(Txtcodigo.Text) & "")
            If respuesta = True Then
                Picfirma.Image = Nothing
            End If
        End If
    End Sub
    Private Sub guardarDocumentos()

        Dim objAdmisionBll As New AdmisionBLL
        Try

            objAdmisionBll.guardarDocumentos(crearDocumentos(), Consultas.GUARDAR_DOCUMENTOS_ADMISION)
            General.llenarTablaYdgv(Consultas.CARGAR_DOCUMENTOS_ADMISION & CInt(Txtcodigo.Text), dtDocumento)
            General.cargarCombo(Consultas.TIPO_DOCUMENTO_EMPLEADO_LISTAR & "'" & Constantes.DOCUMENTO_PACIENTE & "',
                '" & Comboservicio.SelectedValue & "','" & Txtcodigo.Text & "'", "Descripción", "Código", combodescripciondocu)
            btguardarimagen.Enabled = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function crearDocumentos() As Admision
        Dim objAdmision As New Admision
        objAdmision.nRegistro = Txtcodigo.Text
        objAdmision.tipoDocumento = combodescripciondocu.SelectedValue
        objAdmision.imagen = arrFile
        Return objAdmision
    End Function
    Private Sub texthc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles texthistoria.KeyDown
        If e.KeyCode = Keys.F3 And texthistoria.ReadOnly = False Then
            General.buscarElemento(Consultas.BUSQUEDA_PACIENTE,
                                   Nothing,
                                   AddressOf cargarPaciente,
                                   TitulosForm.BUSQUEDA_PACIENTE,
                                   False)
        End If
    End Sub
    Public Sub cargarDatosAdmision()
        Dim dt As New DataTable

        General.llenarTablaYdgv(Consultas.BUSQUEDA_ADMISION_CARGAR & "'" & Txtcodigo.Text & "'", dt)
        textnombrepaciente.Text = dt.Rows(0).Item("paciente").ToString
        Textestrato.Text = dt.Rows(0).Item("CLASE_SOCIAL")
        Textregimen.Text = dt.Rows(0).Item("REGIMEN")
        Texttipoafiliacion.Text = dt.Rows(0).Item("Descripcion_Afiliacion")
        txteps.Text = dt.Rows(0).Item("Nombre_Eps")
        Textcodeps.Text = dt.Rows(0).Item("Codigo_ePS")
        Textdireccion.Text = dt.Rows(0).Item("Direccion").ToString
        Textcedula.Text = dt.Rows(0).Item("Identificacion_A").ToString
        Texttelefono.Text = dt.Rows(0).Item("Telefono_A").ToString
        textacompanante.Text = dt.Rows(0).Item("Acompañante").ToString
        Combotipoidentificacion.SelectedValue = dt.Rows(0).Item("Codigo_Identificacion_A").ToString

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
            Dim bites() As Byte = dt.Rows(0).Item("Firma")
            Dim ms As New MemoryStream(bites)
            Picfirma.Image = Image.FromStream(ms)
            ms.Dispose()
            bites = Nothing
        Else
            Picfirma.Image = Nothing
        End If
        Textdireccion_r.Text = dt.Rows(0).Item("Direccion_R").ToString
        Textidentificacion_r.Text = dt.Rows(0).Item("Identificacion_R").ToString
        Texttelefono_r.Text = dt.Rows(0).Item("Telefono_R").ToString
        Textnombre_r.Text = dt.Rows(0).Item("Responsable").ToString
        Combotipodocumento_r.SelectedValue = dt.Rows(0).Item("Codigo_Identificacion_R").ToString
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
            Dim bites() As Byte = dt.Rows(0).Item("Firma_R")
            Dim ms As New MemoryStream(bites)
            PicfirmaR.Image = Image.FromStream(ms)
            ms.Dispose()
            bites = Nothing
        Else
            PicfirmaR.Image = Nothing
        End If
        texthistoria.Text = dt.Rows(0).Item("Documento_paciente")
        Textautorizacion.Text = dt.Rows(0).Item("N_Autorizacion")
        Comboespecialidad.SelectedValue = dt.Rows(0).Item("Codigo_Especialidad")
        Comboservicio.SelectedValue = dt.Rows(0).Item("Codigo_Area_Servicio")
        Combotriage.SelectedValue = dt.Rows(0).Item("Codigo_Triage")
        idTercero = dt.Rows(0).Item("Id_Eps")
        idPaciente = dt.Rows(0).Item("Identi_Paciente")
        General.cargarCombo(Consultas.CLIENTES_EPS_LISTAR & "'" & idTercero & "','" & FormPrincipal.codigoPuntoActual & "'", "Descripción", "Código", Combocliente)
        Combocliente.SelectedValue = dt.Rows(0).Item("Codigo_Contrato")
        fecha_admision.Value = dt.Rows(0).Item("Fecha_Admision")
        Combocontacto.SelectedValue = dt.Rows(0).Item("Id_Contacto")
        Combocausa.SelectedValue = dt.Rows(0).Item("Causas_Externa")
        Combocama.SelectedValue = dt.Rows(0).Item("Codigo_Cama").ToString
        Combovia.SelectedValue = dt.Rows(0).Item("Via_Ingreso")

        Dim estado As Integer = dt.Rows(0).Item("Codigo_Estado_Atencion")
        Select Case estado
            Case 0
                rbIniciado.Checked = True
            Case 1
                rbCerrado.Checked = True
            Case 2
                rbReabrir.Checked = True
            Case 4
                rbFacturado.Checked = True
            Case 5
                rbAuditoria.Checked = True
        End Select
        Comboinstitucion.SelectedValue = dt.Rows(0).Item("Institucion")
        cargarTraslados()
        cargarDiagnisticos()
        cargarDocumentos()
        General.deshabilitarControles(Me)
        General.habilitarBotones(Me.ToolStrip1)
        Btfirma.Enabled = True
        Btfirma_r.Enabled = True
        Btborrar_firma.Enabled = True
        Btborrar_firma_r.Enabled = True
        btOpcionPaciente.Enabled = True
        btOpcionDocumentos.Enabled = True
        btOpcionAnexo1.Enabled = True
        btOpcionAnexo2.Enabled = True
        btOpcionAnexo3.Enabled = True
        btOpcionTraslado.Enabled = True
        btOpcionEspecialidad.Enabled = True
        btguardar.Enabled = False
        btcancelar.Enabled = False
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
    Private Sub btpaciente_Click(sender As Object, e As EventArgs) Handles btOpcionPaciente.Click
        Dim vFormPaciente As New Form_paciente

        If idPaciente <> -1 Then
            vFormPaciente.cargarPaciente(idPaciente)
        Else
            vFormPaciente.btnuevo_Click(sender, e)
        End If
        vFormPaciente.Show()
    End Sub
    Private Sub form_Admisiones_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub btespecialidades_Click(sender As Object, e As EventArgs) Handles btOpcionEspecialidad.Click
        Dim especialidad As New Form_especialidades
        especialidad.comboEspecialidad = Comboespecialidad
        especialidad.ShowDialog()
    End Sub
    Private Sub bttraslado_Click(sender As Object, e As EventArgs) Handles btOpcionTraslado.Click
        Dim Traslado_Ambulancia As New Form_Traslado_Ambulancia
        Traslado_Ambulancia.ShowDialog()

    End Sub
    Private Sub btdocumentos_Click(sender As Object, e As EventArgs) Handles btOpcionDocumentos.Click
        Dim Tipo_Documentos As New Form_Tipo_Documentos
        Tipo_Documentos.rbempledo.Visible = False
        Tipo_Documentos.rbempresa.Visible = False
        Tipo_Documentos.rbpaciente.Checked = True
        Tipo_Documentos.ShowDialog()
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If FormPrincipal.dtPermisos.Select("Codigo_Menu='" & Peditar & "'", "").Count > 0 Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                General.habilitarControles(Me)
                General.deshabilitarBotones(ToolStrip1)
                elementoAEliminar.Clear()
                TextEst.ReadOnly = False
                rbCerrado.Enabled = False
                rbFacturado.Enabled = False
                rbReabrir.Enabled = False
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
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub dgvdocumentos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdocumentos.CellContentClick
        If dgvdocumentos.Rows.Count <> 0 Then
            If e.ColumnIndex = 2 Then
                Dim bites() As Byte = dgvdocumentos.SelectedCells(2).Value
                Dim ms As New MemoryStream(bites)
                With picturedocu
                    .Image = Image.FromStream(ms)
                    .SizeMode = PictureBoxSizeMode.StretchImage
                    .BorderStyle = BorderStyle.None
                End With
            End If
        End If
    End Sub
    Private Sub cargarDocumentos()
        General.llenarTablaYdgv(Consultas.CARGAR_DOCUMENTOS_ADMISION & "'" & Txtcodigo.Text & "'", dtDocumento)
    End Sub
    Public Sub cargarDatosResponsable()
        Dim dt As New DataTable

        General.llenarTablaYdgv(Consultas.RESPONSABLE_CARGAR_ADMISION & "'" & Textidentificacion_r.Text & "'", dt)
        If dt.Rows.Count > 0 Then
            Textdireccion_r.Text = dt.Rows(0).Item("Direccion")
            Texttelefono_r.Text = dt.Rows(0).Item("Telefono")
            Textnombre_r.Text = dt.Rows(0).Item("Responsable")
            Combotipodocumento_r.SelectedValue = dt.Rows(0).Item("Codigo_Identificacion")
            Combopais_r.SelectedValue = dt.Rows(0).Item("Codigo_Pais")
            Combodepartamento_r.SelectedValue = dt.Rows(0).Item("Codigo_Departamento")
            Combociudad_r.SelectedValue = dt.Rows(0).Item("Codigo_Municipio")
            If Not IsDBNull(dt.Rows(0).Item("Firma")) Then
                Dim bites() As Byte = dt.Rows(0).Item("Firma")
                Dim ms As New MemoryStream(bites)
                PicfirmaR.Image = Image.FromStream(ms)
                ms.Dispose()
                bites = Nothing
            Else
                PicfirmaR.Image = Nothing
            End If
        End If
    End Sub
    Public Sub cargarDatosAcompañante()
        Dim dt As New DataTable

        General.llenarTablaYdgv(Consultas.ACOMPAÑANTE_CARGAR_ADMISION & "'" & Textcedula.Text & "'", dt)
        If dt.Rows.Count > 0 Then
            Textdireccion.Text = dt.Rows(0).Item("Direccion")
            Textcedula.Text = dt.Rows(0).Item("Id_acompanante")
            Texttelefono.Text = dt.Rows(0).Item("Telefono")
            textacompanante.Text = dt.Rows(0).Item("Nombre")
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
        Dim dta, dtb, dtc As New DataTable
        General.llenarTablaYdgv(Consultas.VALIDAR_PACIENTE_ADMISION & "'" & texthistoria.Text & "'", dta)
        If dta.Rows.Count = 0 Then
            General.llenarTablaYdgv(Consultas.PACIENTES_CARGAR_ADMISION & "'" & texthistoria.Text & "'", dtb)
            If dtb.Rows.Count > 0 Then
                textnombrepaciente.Text = dtb.Rows(0).Item("paciente")
                Textestrato.Text = dtb.Rows(0).Item("CLASE_SOCIAL")
                Textregimen.Text = dtb.Rows(0).Item("REGIMEN")
                Texttipoafiliacion.Text = dtb.Rows(0).Item("Descripcion_Afiliacion")
                txteps.Text = dtb.Rows(0).Item("Nombre_Eps")
                Textcodeps.Text = dtb.Rows(0).Item("Codigo_ePS")
                idPaciente = dtb.Rows(0).Item("Identi_Paciente")
                idTercero = dtb.Rows(0).Item("Id_eps")
                General.llenarTablaYdgv(Consultas.VALIDAR_CONTRATO_ADMISION & "'" & idTercero & "'", dtc)
                If dtc.Rows.Count = 0 Then
                    MsgBox(txteps.Text & " No tiene un contrato vigente", MsgBoxStyle.Exclamation)
                    General.limpiarControles(Me)
                Else
                    General.cargarCombo(Consultas.CLIENTES_EPS_LISTAR & "'" & idTercero & "',
                    '" & FormPrincipal.codigoPuntoActual & "'", "Descripción", "Código", Combocliente)
                End If
                textnombrepaciente.ReadOnly = True
                Textestrato.ReadOnly = True
                Textregimen.ReadOnly = True
                Texttipoafiliacion.ReadOnly = True
                txteps.ReadOnly = True
                Textcodeps.ReadOnly = True
            Else
                If MsgBox("La identificación no existe, ¿desea agregar un nuevo paciente?", MsgBoxStyle.YesNo) = vbYes Then
                    objFormPaciente.MdiParent = FormPrincipal
                    objFormPaciente.Show()
                    objFormPaciente.Focus()
                    objFormPaciente.btnuevo.PerformClick()
                    objFormPaciente.textidentificacion.Text = texthistoria.Text
                    btguardar.Enabled = True
                    btcancelar.Enabled = True
                    objFormPaciente.combotipoident.Focus()
                End If
            End If
        Else
            Comboservicio.SelectedValue = dta.Rows(0).Item("Codigo_Area_Servicio")
            MsgBox("Este paciente se encuentra actualmente atendido en: " & Comboservicio.Text & "", MsgBoxStyle.Information)

            Txtcodigo.Text = dta.Rows(0).Item("N_Registro")
            cargarDatosAdmision()

        End If
    End Sub
    Private Sub textacompanante_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Textnombre_r.KeyPress, textacompanante.KeyPress
        ValidacionDigitacion.validarAlfabetico(e)
    End Sub

    Private Sub texthistoria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles texthistoria.KeyPress, Textautorizacion.KeyPress,
     Texttelefono.KeyPress, Texttelefono_r.KeyPress
        ValidacionDigitacion.validarValoresNumericos(e)
        If Asc(e.KeyChar) = 13 Then
            cargarDatosPaciente()
        End If
    End Sub
    Private Sub Textcedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Textcedula.KeyPress
        ValidacionDigitacion.validarValoresNumericos(e)
        If Asc(e.KeyChar) = 13 Then
            cargarDatosAcompañante()
        End If
    End Sub
    Private Sub Textidentificacion_r_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Textidentificacion_r.KeyPress
        ValidacionDigitacion.validarValoresNumericos(e)
        If Asc(e.KeyChar) = 13 Then
            cargarDatosResponsable()
        End If
    End Sub
    Private Sub btcopiar_Click(sender As Object, e As EventArgs) Handles btcopiar.Click
        Textnombre_r.Text = textacompanante.Text
        Texttelefono_r.Text = Texttelefono.Text
        Textidentificacion_r.Text = Textcedula.Text
        Textdireccion_r.Text = Textdireccion.Text
        Combotipodocumento_r.SelectedValue = Combotipoidentificacion.SelectedValue
        Combopais_r.SelectedValue = Combopais.SelectedValue
        Combodepartamento_r.SelectedValue = Combodepartamento.SelectedValue
        Combociudad_r.SelectedValue = Combociudad.SelectedValue
        PicfirmaR.Image = Picfirma.Image
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False

        Try
            Dim ruta, area, nombreArchivo As String
            area = ConstantesHC.NOMBRE_PDF_ADMISION
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & Txtcodigo.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo

            ftp_reportes.llamarArchivo(ruta, nombreArchivo, Txtcodigo.Text, area)

            Process.Start(ruta)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub
    Private Sub guardarReporte()
        Try

            reporte.crearYGuardarReporte(ConstantesHC.NOMBRE_PDF_ADMISION, Txtcodigo.Text, New rpt_Admisiones,
                                        Txtcodigo.Text, "{VISTA_ADMISION.N_Registro} = " & Txtcodigo.Text & "",
                                       ConstantesHC.NOMBRE_PDF_ADMISION, IO.Path.GetTempPath)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub guardarSegundoPlano()
        guardarEn2doPlano = New Thread(AddressOf guardarReporte)
        guardarEn2doPlano.Name = "Guardar Admision"
        guardarEn2doPlano.SetApartmentState(ApartmentState.STA)
        guardarEn2doPlano.Start()
    End Sub
    Private Sub btanexo2_Click(sender As Object, e As EventArgs) Handles btOpcionAnexo2.Click
        If Txtcodigo.Text = "" Then
            MsgBox("Por favor seleccione un paciente.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        FormPrincipal.Cursor = Cursors.WaitCursor
        Dim anexo2 As New Form_Anexo2
        anexo2.txtregistro.Text = Txtcodigo.Text
        anexo2.CargarPaciente()
        anexo2.ShowDialog()
        FormPrincipal.Cursor = Cursors.Default
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If FormPrincipal.dtPermisos.Select("Codigo_Menu='" & PBuscar & "'", "").Count > 0 Then

            General.buscarElemento(Consultas.BUSQUEDA_ADMISION,
                                   Nothing,
                                   AddressOf cargarAdmision,
                                   TitulosForm.BUSQUEDA_ADMISION,
                                   False)

        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Information)
        End If
    End Sub

    Public Sub cargarAdmision(pCodigo As String)
        Txtcodigo.Text = pCodigo
        cargarDatosAdmision()
    End Sub

    Public Sub cargarPaciente(pCodigo As String)
        Dim drPaciente As DataRow
        Dim params As New List(Of String)
        drPaciente = General.cargarItem(Consultas.PACIENTE_CARGAR, params)
        texthistoria.Text = drPaciente.Item(1).ToString()
        cargarDatosPaciente()
    End Sub
    Private Sub dgvdocumentos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdocumentos.CellDoubleClick
        If e.ColumnIndex = 4 Then
            respuesta = General.anularSinTransaccion(Consultas.ELIMINAR_DOCUMENTO & "'" & Txtcodigo.Text & "',
            '" & dgvdocumentos.Rows(dgvdocumentos.CurrentRow.Index).Cells(0).Value & "'")
            If respuesta = True Then
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                cargarDocumentos()
                General.cargarCombo(Consultas.TIPO_DOCUMENTO_EMPLEADO_LISTAR & "'" & Constantes.DOCUMENTO_PACIENTE & "','" & Comboservicio.SelectedValue & "','" &
                                     Txtcodigo.Text & "'", "Descripción", "Código", combodescripciondocu)
            End If
        ElseIf e.ColumnIndex = 2 Then
            General.verImagen(picturedocu)
        End If
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Try
            If FormPrincipal.dtPermisos.Select("Codigo_Menu='" & Panular & "'", "").Count > 0 Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    respuesta = General.anularSinTransaccion(Consultas.ANULAR_ADMISION & FormPrincipal.usuarioActual & "," & CInt(Txtcodigo.Text) & "")

                    If respuesta = True Then
                        MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                        General.limpiarControles(Me)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvdocumentos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvdocumentos.DataError

    End Sub

    Private Function validarInformacion()

        If texthistoria.Text = "" Then
            MsgBox("Favor seleccionar el paciente", 48, "Atencion")
            TabControl1.SelectedIndex = 0
            texthistoria.Focus()
            Return False
        ElseIf Comboespecialidad.SelectedIndex < 1 Then
            MsgBox("Favor seleccionar la especialidad a la que va el paciente", 48, "Atencion")
            TabControl1.SelectedIndex = 0
            Comboespecialidad.Focus()
            Return False
        ElseIf Combocliente.SelectedIndex < 1 Then
            MsgBox("Favor seleccionar el Cliente", 48, "Atencion")
            TabControl1.SelectedIndex = 0
            Combocliente.Focus()
            Return False
        ElseIf Combocontacto.SelectedIndex < 1 Then
            MsgBox("Favor seleccionar el Contacto", 48, "Atencion")
            TabControl1.SelectedIndex = 0
            Combocontacto.Focus()
            Return False
        ElseIf Comboservicio.SelectedIndex < 1 Then
            MsgBox("Favor seleccionar el área de servicio", 48, "Atencion")
            TabControl1.SelectedIndex = 1
            Comboservicio.Focus()
            Return False
        ElseIf Combovia.SelectedIndex < 1 Then
            MsgBox("Favor seleccionar la vía de ingreso", 48, "Atencion")
            TabControl1.SelectedIndex = 1
            Combovia.Focus()
            Return False
        ElseIf Comboinstitucion.SelectedIndex < 1 Then
            MsgBox("Favor seleccionar la Institución de donde viene remitido el paciente", 48, "Atencion")
            TabControl1.SelectedIndex = 1
            Comboinstitucion.Focus()
            Return False
        ElseIf Combocausa.SelectedIndex < 1 Then
            MsgBox("Favor seleccionar la causa del ingreso", 48, "Atencion")
            TabControl1.SelectedIndex = 1
            Combocausa.Focus()
            Return False
        ElseIf Combocama.SelectedIndex < 1 Then
            MsgBox("Favor seleccionar la cama a la que va el paciente", 48, "Atencion")
            TabControl1.SelectedIndex = 1
            Combocama.Focus()
            Return False
        ElseIf dtDiagnostico.Rows(0).Item(0).ToString = "" Then
            MsgBox("Favor seleccionar al menos un diagnostico", 48, "Atencion")
            TabControl1.SelectedIndex = 1
            dgvdiagnosticos.Focus()
            Return False
        ElseIf IsDate(fecha_admision.Text) = False Then
            MsgBox("El valor de la Fecha no es valida", 48, "Atencion")
            TabControl1.SelectedIndex = 0
            fecha_admision.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub validarEstadoAtencion()

        Select Case True
            Case rbIniciado.Checked
                estadoAtencion = Constantes.ESTADO_ATENCION_INICIADO
            Case rbAuditoria.Checked
                estadoAtencion = Constantes.ESTADO_ATENCION_AUDITORIA
            Case rbCerrado.Checked
                estadoAtencion = Constantes.ESTADO_ATENCION_CERRADO
            Case rbFacturado.Checked
                estadoAtencion = Constantes.ESTADO_ATENCION_FACTURADO
            Case rbReabrir.Checked
                estadoAtencion = Constantes.ESTADO_ATENCION_ABIERTO
        End Select

    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarInformacion() Then
            guardarAdmision()
        End If
    End Sub
    Private Sub btanexo3_Click(sender As Object, e As EventArgs) Handles btOpcionAnexo3.Click
        If Txtcodigo.Text = "" Then
            MsgBox("Por favor seleccione un paciente.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        FormPrincipal.Cursor = Cursors.WaitCursor
        Dim anexo3 As New Form_Anexo3
        anexo3.txtregistro.Text = Txtcodigo.Text
        anexo3.txtpaciente.Text = textnombrepaciente.Text
        anexo3.txtidentificacion.Text = texthistoria.Text
        anexo3.txtcontrato.Text = txteps.Text
        anexo3.VerificarRegistro()
        anexo3.txttipoinforme.Text = Constantes.AUTORIZACION_SERVICIO
        anexo3.ShowDialog()
        FormPrincipal.Cursor = Cursors.Default
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If FormPrincipal.dtPermisos.Select("Codigo_Menu='" & Pnuevo & "'", "").Count > 0 Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            dtDiagnostico.Rows.Add()
            dtTraslado.Rows.Add()
            elementoAEliminar.Clear()
            rbCerrado.Enabled = False
            rbFacturado.Enabled = False
            rbReabrir.Enabled = False
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
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub guardarAdmision()
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            validarEstadoAtencion()

            Dim objAdmisionBll As New AdmisionBLL
            Try

                Txtcodigo.Text = objAdmisionBll.guardarAdmision(crearAdmision())
                guardarTraslado()
                cargarTraslados()
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                guardarSegundoPlano()
                General.deshabilitarControles(Me)
                General.habilitarBotones(Me.ToolStrip1)
                Btfirma.Enabled = True
                Btfirma_r.Enabled = True
                btguardar.Enabled = False
                btcancelar.Enabled = False
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub guardarTraslado()
        If dgvtraslados.RowCount > 1 Then

            Try
                Txtcodigo.Text = AdmisionBLL.guardarTraslado(Txtcodigo.Text, dtTraslado, elementoAEliminar)

                General.deshabilitarControles(Me)
                General.habilitarBotones(Me.ToolStrip1)
                btguardar.Enabled = False
                btcancelar.Enabled = False
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Function crearAdmision() As Admision
        Dim objAdmision As New Admision
        objAdmision.nRegistro = Txtcodigo.Text
        objAdmision.identiPaciente = idPaciente
        objAdmision.fechaAdmision = fecha_admision.Value
        objAdmision.CodigoEp = FormPrincipal.codigoPuntoActual
        objAdmision.codigoEspecialidad = Comboespecialidad.SelectedValue
        objAdmision.codigoTriage = Combotriage.SelectedValue
        objAdmision.codigoContrato = Combocliente.SelectedValue
        objAdmision.codigoArea = Comboservicio.SelectedValue
        objAdmision.idContacto = Combocontacto.SelectedValue
        objAdmision.codigoIdAcompanate = Combotipoidentificacion.SelectedValue
        objAdmision.idAcompanate = Textcedula.Text
        objAdmision.acompanante = textacompanante.Text
        objAdmision.Direccion = Textdireccion.Text
        objAdmision.telAcompanate = Texttelefono.Text
        objAdmision.codigoPais = Combopais.SelectedValue
        objAdmision.codigoDepartamento = Combodepartamento.SelectedValue
        objAdmision.codigoMunicipio = Combociudad.SelectedValue
        objAdmision.codigoIdResponsable = Combotipodocumento_r.SelectedValue
        objAdmision.idResponsable = Textidentificacion_r.Text
        objAdmision.responsable = Textnombre_r.Text
        objAdmision.direccionResponsable = Textdireccion_r.Text
        objAdmision.telResponsable = Texttelefono_r.Text
        objAdmision.codigoPaisResponsable = Combopais_r.SelectedValue
        objAdmision.codigoDepartamentoResponsable = Combodepartamento_r.SelectedValue
        objAdmision.codigoMunicipioResponsable = Combociudad_r.SelectedValue
        objAdmision.usuario = FormPrincipal.usuarioActual
        objAdmision.numAutorizacion = Textautorizacion.Text
        objAdmision.viaIngreso = Combovia.SelectedValue
        objAdmision.institucion = Comboinstitucion.SelectedValue
        objAdmision.causaExterna = Combocausa.SelectedValue
        objAdmision.codigoEstado = estadoAtencion
        objAdmision.codigoCama = Combocama.SelectedValue

        For Each drFila As DataRow In dtDiagnostico.Rows
            If drFila.Item("Codigo_Cie").ToString <> "" And drFila.Item("Estado").ToString = "0" Then
                objAdmision.nRegistro = Txtcodigo.Text
                Dim drDiag As DataRow = objAdmision.dtDiagnostico.NewRow
                drDiag.Item("N_Registro") = Txtcodigo.Text
                drDiag.Item("Codigo_Cie") = drFila.Item("Codigo_Cie")
                objAdmision.dtDiagnostico.Rows.Add(drDiag)
            End If
        Next
        Return objAdmision
    End Function
End Class