Public Class FormConfPlantillaInfoEspecial
    Dim objPlantilla As New ConfPlantillaInfo
    Dim dtImagen As New DataTable
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btBuscarProcedimiento_Click(sender As Object, e As EventArgs) Handles btBuscarProcedimiento.Click
        Dim params As New List(Of String)
        params.Add(109)
        General.buscarElemento(Consultas.PROCEDIMIENTOS_CUPS_IMAGENOLOGIA_BUSCAR,
                                  params,
                                  AddressOf cargarProcedimientos,
                                  TitulosForm.BUSQUEDA_PROCEDIMIENTOS_CUPS,
                                  False, 0, True)
    End Sub
    Private Sub cargarProcedimientos(pcodigo As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pcodigo)
        params.Add(0)
        General.llenarTabla(Consultas.PROCEDIMIENTOS_CUPS_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            txtCodProcedimiento.Text = pcodigo
            txtDescProcedimiento.Text = dt.Rows(0).Item(1).ToString()
            cmbArea.Enabled = True
            txtNomDiagnostico.ReadOnly = False
            txtInterDiagnostico.ReadOnly = False
        End If
    End Sub

    Private Sub FormConfPlantillaInfoEspecial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.deshabilitarControles(Me)
        General.cargarCombo(Consultas.PERFIL_PARACLINICO_AREA_SERVICIO_BUSCAR, "Descripcion", "Codigo", cmbArea)
        dgvdocumentos.DataSource = dtImagen
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        General.limpiarControles(Me)
        btBuscarProcedimiento.Enabled = True
        btnuevo.Enabled = False
        btbuscar.Enabled = False
        btguardar.Enabled = True
        btcancelar.Enabled = True
        btexaminar.Enabled = True
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub

    'Private Sub txtInterDiagnostico_TextChanged(sender As Object, e As EventArgs) Handles txtInterDiagnostico.TextChanged
    '    Label8.Text = CType(sender, TextBox).Text.Length.ToString()
    'End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarInformacion() = True Then Exit Sub
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            If cargarObjetos() = True Then
                Try
                    ConfPlantillaInfBLL.guardarConfPlanillaInf(objPlantilla)
                    General.habilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    btguardar.Enabled = False
                    btcancelar.Enabled = False
                    txtCodPlantilla.Text = objPlantilla.codigoPlantilla
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    btexaminar.Enabled = True
                    If IsNothing(picturedocu.Image) Then
                    Else
                        guardarPdf()
                    End If
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub
    Private Function validarInformacion()
        If String.IsNullOrEmpty(txtCodProcedimiento.Text) Then
            MsgBox("No ha seleccionado un Procedimiento...", MsgBoxStyle.Information)
            Return True
        ElseIf cmbArea.SelectedValue = 0 Then
            MsgBox("No ha escogido un Area de Servicio...", MsgBoxStyle.Information)
            Return True
        ElseIf String.IsNullOrEmpty(txtNomDiagnostico.Text) Then
            MsgBox("No ha escrito un Nombre para el Diagnostico...", MsgBoxStyle.Information)
            Return True
        ElseIf String.IsNullOrEmpty(txtInterDiagnostico.Text) Then
            MsgBox("No ha escrito una Interpretación para el diagnostico...", MsgBoxStyle.Information)
            Return True
        End If
        Return False
    End Function

    Private Function cargarObjetos() As Boolean
        Try
            objPlantilla.codigoPlantilla = txtCodPlantilla.Text
            objPlantilla.codigoProcedimiento = txtCodProcedimiento.Text
            objPlantilla.codigoAreaServicio = cmbArea.SelectedValue
            objPlantilla.nombreDiag = txtNomDiagnostico.Text
            objPlantilla.descripcionDiag = txtInterDiagnostico.Text
            objPlantilla.usarioCreacion = SesionActual.idUsuario
        Catch ex As Exception
            General.manejoErrores(ex)
            Return False
        End Try
        Return True
    End Function
    'Public Function crearDocumentos()
    '    Dim arrFile() As Byte
    '    Dim ms As New MemoryStream
    '    picturedocu.Image.Save(ms, Imaging.ImageFormat.Jpeg)
    '    arrFile = File.ReadAllBytes(openimagen.FileName)
    '    objPlantilla.codigoPlantilla = txtCodPlantilla.Text
    '    objPlantilla.pdf = arrFile
    '    Return objPlantilla
    'End Function
    Public Function crearDocumentos() As Admision
        Dim objAdmision As New Admision
        Dim arrFile() As Byte
        Dim ms As New MemoryStream
        picturedocu.Image.Save(ms, Imaging.ImageFormat.Jpeg)
        arrFile = File.ReadAllBytes(openimagen.FileName)
        objAdmision.nRegistro = txtCodPlantilla.Text
        objAdmision.tipoDocumento = 0
        objAdmision.imagen = arrFile
        objAdmision.extensionDoc = Path.GetExtension(openimagen.FileName).ToLower()
        objAdmision.tipo = Constantes.ID_ECOCARDIOGRAMA
        Return objAdmision
    End Function
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Dim params As New List(Of String)
        params.Add("")
        General.buscarElemento(objPlantilla.sqlBuscarConfPlantillaInf,
                                   params,
                                   AddressOf cargarConfPlantillaInf,
                                   TitulosForm.BUSQUEDA_PLANTILLA_INFO,
                                   False, 0, True)
    End Sub
    Private Sub cargarConfPlantillaInf(pCodigo As Integer)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(pCodigo)
        Try
            dFila = General.cargarItem(objPlantilla.sqlCargarConfPlantillaInf, params)
            objPlantilla.codigoPlantilla = pCodigo
            txtCodPlantilla.Text = pCodigo
            txtCodProcedimiento.Text = dFila.Item(0)
            txtDescProcedimiento.Text = dFila.Item(1)
            cmbArea.SelectedValue = dFila.Item(2)
            txtNomDiagnostico.Text = dFila.Item(3)
            txtInterDiagnostico.Text = dFila.Item(4)
            General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
            cargarDocumentos()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        General.deshabilitarControles(Me)
        btnuevo.Enabled = False
        btguardar.Enabled = True
        btbuscar.Enabled = False
        bteditar.Enabled = False
        btcancelar.Enabled = True
        btanular.Enabled = False
        btexaminar.Enabled = True
        txtInterDiagnostico.ReadOnly = False
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
            Try
                objPlantilla.AnularConfPlantillaInf()
                General.deshabilitarBotones(ToolStrip1)
                General.deshabilitarControles(Me)
                General.limpiarControles(Me)
                btbuscar.Enabled = True
                btnuevo.Enabled = True
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub

    Private Sub FormConfPlantillaInfoEspecial_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

    Private Sub btexaminar_Click(sender As Object, e As EventArgs) Handles btexaminar.Click
        General.subirimagen(picturedocu, openimagen, True)

    End Sub
    Private Sub guardarPdf()
        Dim objAdmisionBll As New AdmisionBLL
        Dim dtDocumento As New DataTable
        Try
            objAdmisionBll.guardarDocumentos(crearDocumentos(), Consultas.GUARDAR_DOCUMENTOS_ADMISION)
            cargarDocumentos()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub asignarImagenDatagrid()
        For indice = 0 To dtImagen.Rows.Count - 1
            dgvdocumentos.Rows(indice).Cells(2).Value = My.Resources.Adobe_PDF_Document_icon
        Next
    End Sub
    Private Sub cargarDocumentos()
        Dim params As New List(Of String)
        params.Add(txtCodPlantilla.Text)
        params.Add(Constantes.ID_ECOCARDIOGRAMA)
        General.llenarTabla(Consultas.DOCUMENTOS_ECOCARDIOGRAMA_CARGAR, params, dtImagen)
        If dtImagen.Rows.Count > 0 Then
            asignarImagenDatagrid()
        End If
    End Sub
    Private Sub dgvdocumentos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdocumentos.CellDoubleClick
        If e.ColumnIndex = 0 Then
            Dim respuesta As Boolean
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                respuesta = General.anularRegistro(Consultas.ELIMINAR_DOCUMENTO & "
            '" & dgvdocumentos.Rows(dgvdocumentos.CurrentRow.Index).Cells(1).Value & "','" & Constantes.ID_ECOCARDIOGRAMA & "' ")
                If respuesta = True Then
                    cargarDocumentos()
                    picturedocu.Image = Nothing
                End If
            End If
        ElseIf e.ColumnIndex = 2 Then
            verArchivo()
        End If
    End Sub
    Private Sub verArchivo()
        Dim params As New List(Of String)
        Dim dt As New DataTable
        params.Add(dgvdocumentos.Rows(dgvdocumentos.CurrentRow.Index).Cells(1).Value.ToString())
        Dim tempfileurl As String = System.IO.Path.GetTempPath + DateTime.Now.ToString("yyyyMMdd_HHmmss")
        General.llenarTabla(Consultas.DOCUMENTO_ECO_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            tempfileurl += "-tempdocu" + Constantes.FORMATO_PDF
            My.Computer.FileSystem.WriteAllBytes(tempfileurl, dt.Rows(0).Item("Imagen"), True)
            Process.Start("file://" + tempfileurl)
        End If
    End Sub

    Private Sub dgvdocumentos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvdocumentos.DataError

    End Sub
End Class