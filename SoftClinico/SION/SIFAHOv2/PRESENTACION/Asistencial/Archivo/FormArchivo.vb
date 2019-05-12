Public Class FormArchivo
    Dim objArchivo As Archivo
    Private Sub FormArchivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objArchivo = New Archivo
        General.cargarCombo(objArchivo.objEstante.sqlBusqueda, "Estante", "Codigo", cbEstante)
        General.cargarCombo(objArchivo.objBloque.sqlBusqueda, "Bloque", "Codigo", cbBloque)
        General.cargarCombo(objArchivo.objFila.sqlBusqueda, "Fila", "Codigo", cbFila)
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(grupo)
        btnuevo.Enabled = True
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        buscarFactura()
        If txtcodigo.Text <> String.Empty Then
            General.deshabilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            General.habilitarControles(grupo)
            btguardar.Enabled = True
            btcancelar.Enabled = True
        Else
            MsgBox(Mensajes.SELECCIONAR_FACTURA)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.Yes Then
            General.deshabilitarBotones(ToolStrip1)
            General.deshabilitarControles(grupo)
            General.limpiarControles(Me)
            btnuevo.Enabled = True
        End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
            General.deshabilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            General.habilitarControles(grupo)
            btguardar.Enabled = True
            btcancelar.Enabled = True
        End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Try
                cargarObjArchivo()
                ArchivohcBLL.guardarArchivo(objArchivo)
                General.habilitarBotones(ToolStrip1)
                General.deshabilitarControles(grupo)
                btguardar.Enabled = False
                btcancelar.Enabled = False
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            Catch ex As Exception
                general.manejoErrores(ex) 
            End Try
        End If
    End Sub

    Private Sub cargarObjArchivo()
        objArchivo.codigoFactura = txtcodigo.Text
        objArchivo.CodigoFila = cbFila.SelectedValue
        objArchivo.usuario = SesionActual.idUsuario
    End Sub
    Private Sub buscarFactura()
        General.buscarElemento(objArchivo.sqlBusqueda,
                              Nothing,
                              AddressOf cargarFactura,
                              TitulosForm.BUSQUEDA_FACTURA,
                              False)
    End Sub
    Private Sub cargarFactura(pCodigo As String)
        Dim dFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        dFila = General.cargarItem(objArchivo.sqlCargarFactura, params)
        txtcodigo.Text = dFila.Item(0)
        txtPaciente.Text = dFila.Item(1)
        dtFechaFactura.Text = dFila.Item(2)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim form As New FormFila
        form.MdiParent = FormPrincipal
        form.Show()
        form.Focus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim form As New FormBloque
        form.MdiParent = FormPrincipal
        form.Show()
        form.Focus()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim form As New FormEstante
        form.MdiParent = FormPrincipal
        form.Show()
        form.Focus()
    End Sub
End Class