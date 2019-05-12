Public Class FormSolicitudLab
    Dim objSolicitudLab As SolicitudLaboratorio
    Dim objPadre As Object
    Dim aux As Boolean

    Public Sub iniciarForm(ByRef pForm As Object)
        objPadre = pForm
    End Sub
    Private Sub FormSolicitudLab_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objSolicitudLab = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_SOLICITUD_LAB & objPadre.modulo)
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        objSolicitudLab.asignarValores(objPadre)
        General.cargarCombo(objSolicitudLab.sqlCargarComboLaboratorio, "Laboratorio", "Codigo", cbLaboratorio)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        If objPadre.tipo = Constantes.TipoEXAMAtencion Then
            selTodos.Visible = True
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.Yes Then
            General.deshabilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            General.limpiarControles(Me)
            btnuevo.Enabled = True
            btbuscar.Enabled = True
            selTodos.Enabled = False
        End If
    End Sub
    Private Sub cbLaboratorio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLaboratorio.SelectedIndexChanged
        If Not String.IsNullOrEmpty(cbLaboratorio.ValueMember) Then
            cargarExamenes(cbLaboratorio.SelectedIndex)
        End If
    End Sub
    Private Sub cargarExamenes(posicion As Integer)
        objSolicitudLab.IdTercero = cbLaboratorio.SelectedValue
        objSolicitudLab.IdEmpresa = SesionActual.idEmpresa
        objSolicitudLab.cargarDatatableExamen(posicion)
        validarDgv()
        dgvSolicitudLab.DataSource = objSolicitudLab.dtExamen
        dgvSolicitudLab.AutoGenerateColumns = False
    End Sub
    Private Sub validarDgv()
        With dgvSolicitudLab
            .ReadOnly = False
            .Columns("dgCodigo").DataPropertyName = "Codigo"
            .Columns("dgCodigo").ReadOnly = True
            .Columns("dgDescripcion").DataPropertyName = "Examen"
            .Columns("dgDescripcion").ReadOnly = True
            .Columns("dgSeleccionar").DataPropertyName = "Seleccionado"
            .Columns("dgSeleccionar").ReadOnly = False
            .Columns("dgEstado").DataPropertyName = "Estado"
        End With
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgvSolicitudLab.EndEdit()
        objSolicitudLab.dtExamen.AcceptChanges()
        If cbLaboratorio.SelectedIndex = 0 Then
            Exec.SavingMsg("Debe Selecionar un Laboratorio ", cbLaboratorio)
        ElseIf objSolicitudLab.dtExamen.Select("Seleccionado = true").Count = 0 Then
            Exec.SavingMsg("Debe Selecionar un examén ", dgvSolicitudLab)
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

                cargarObjeto()
                Try
                    LaboratorioBLL.guardarSolicitudLab(objSolicitudLab)
                    General.deshabilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    txtcodigo.Text = objSolicitudLab.codigoSolicitud
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    btanular.Enabled = True
                    btimprimir.Enabled = True
                    selTodos.Enabled = False
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub
    Private Sub cargarObjeto()
        objSolicitudLab.codigoSolicitud = txtcodigo.Text
        objSolicitudLab.codigoLab = cbLaboratorio.SelectedValue
        objSolicitudLab.Usuario = SesionActual.idUsuario
        objSolicitudLab.UsuarioReal = SesionActual.idUsuario
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        General.deshabilitarBotones(ToolStrip1)
        General.limpiarControles(Me)
        btguardar.Enabled = True
        btcancelar.Enabled = True
        cbLaboratorio.Enabled = True
        selTodos.Enabled = True
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Dim params As New List(Of String)
        params.Add(String.Empty)
        params.Add(objSolicitudLab.nRegistro)
        params.Add(If(String.IsNullOrEmpty(objSolicitudLab.codigoOrden), Constantes.VALOR_PREDETERMINADO,
                                               objSolicitudLab.codigoOrden))
        General.buscarElemento(objSolicitudLab.sqlBuscarSolicitud,
                               params,
                               AddressOf cargarSolicitudLab,
                               TitulosForm.BUSQUEDA_SOLICITUDES,
                               False, 0, True)
    End Sub
    Private Sub cargarSolicitudLab(pCodigo As Integer)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(ConstantesHC.REGISTRO)
        params.Add(pCodigo)
        Try
            dFila = General.cargarItem(objSolicitudLab.sqlCargarSolicitud, params)
            objSolicitudLab.codigoSolicitud = pCodigo
            txtcodigo.Text = pCodigo
            cbLaboratorio.SelectedValue = dFila.Item(0)
            '-----------Cargamos el detalle 
            objSolicitudLab.cargarDatosSolicitud(pCodigo)
            validarDgv()
            dgvSolicitudLab.DataSource = objSolicitudLab.dtExamen
            dgvSolicitudLab.AutoGenerateColumns = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        selTodos.Enabled = False
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, btimprimir, btanular)
    End Sub
    Private Sub dgvSolicitudLab_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSolicitudLab.CellClick
        Dim estado As String
        If dgvSolicitudLab.RowCount > 0 And btguardar.Enabled = True Then
            If e.ColumnIndex = 2 Then
                estado = If(IsDBNull(dgvSolicitudLab.Rows(e.RowIndex).Cells("dgEstado").Value), Nothing, dgvSolicitudLab.Rows(e.RowIndex).Cells("dgEstado").Value)
                Select Case estado
                    Case String.Empty
                        dgvSolicitudLab.Rows(e.RowIndex).Cells("dgEstado").Value = Constantes.ITEM_NUEVO
                    Case Constantes.ITEM_NUEVO
                        dgvSolicitudLab.Rows(e.RowIndex).Cells("dgEstado").Value = Nothing
                End Select
            End If
        End If
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
            Try
                objSolicitudLab.anulaSolicitud()
                General.deshabilitarBotones(ToolStrip1)
                General.deshabilitarControles(Me)
                General.limpiarControles(Me)
                btbuscar.Enabled = True
                btnuevo.Enabled = True
                selTodos.Enabled = False
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
    Private Sub FormSolicitudLab_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Dim area, nombreArchivo, ruta As String
        Dim reporte As New ftp_reportes
        If objSolicitudLab.dtExamen.Rows.Count > 0 Then

            Cursor = Cursors.WaitCursor

            area = "Solicitud_Lab"

            Try

                nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & objSolicitudLab.codigoSolicitud & ConstantesHC.EXTENSION_ARCHIVO_PDF

                ruta = IO.Path.GetTempPath() & nombreArchivo

                reporte.crearReportePDF(area, objSolicitudLab.codigoOrden,
                                               New rptSolicitudLaboratorio,
                                               objSolicitudLab.codigoSolicitud, "{VISTA_LABORATORIO.Codigo_Solic}=" & objSolicitudLab.codigoSolicitud,
                                               area,
                                               IO.Path.GetTempPath)
            Catch ex As Exception
                General.manejoErrores(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub dgvSolicitudLab_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSolicitudLab.CellContentClick
        dgvSolicitudLab.EndEdit()
        If dgvSolicitudLab.Rows(e.RowIndex).Cells(2).Value = True Then
            If objPadre.tipo <> "A" AndAlso MsgBox(Mensajes.SOLICITUD_EXAMEN, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.BUSQUEDA_SOLICITUDES) <> MsgBoxResult.Yes Then
                dgvSolicitudLab.Rows(e.RowIndex).Cells(2).Value = False
                dgvSolicitudLab.EndEdit()
            End If
        End If
    End Sub

    Private Sub selTodos_CheckedChanged(sender As Object, e As EventArgs) Handles selTodos.CheckedChanged
        For i = 0 To dgvSolicitudLab.RowCount - 1
            dgvSolicitudLab.Rows(i).Cells("dgSeleccionar").Value = selTodos.Checked
        Next
        dgvSolicitudLab.EndEdit()
    End Sub
End Class