Public Class FormBloque
    Dim objBloque As Bloque
    Dim objEstante As Estante
    Private Sub FormBloque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objBloque = New Bloque
        objEstante = New Estante
        General.cargarCombo(objEstante.sqlBusqueda, "Estante", "Codigo", cbEstante)
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        General.deshabilitarControles(ToolStrip1)
        btguardar.Enabled = True
        btcancelar.Enabled = True
        cbEstante.Enabled = True
        txtBloque.ReadOnly = False
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
            General.deshabilitarControles(ToolStrip1)
            btguardar.Enabled = True
            btcancelar.Enabled = True
            cbEstante.Enabled = True
            txtBloque.ReadOnly = False
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.Yes Then
            General.deshabilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            btnuevo.Enabled = True
            btbuscar.Enabled = True
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Try
                cargarObjBloque()
                BloqueBLL.guardarBloque(objBloque)
                General.habilitarBotones(ToolStrip1)
                General.deshabilitarControles(Me)
                btguardar.Enabled = False
                btcancelar.Enabled = False
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            Catch ex As Exception
                general.manejoErrores(ex) 
            End Try
        End If
    End Sub
    Private Sub cargarObjBloque()
        objBloque.codigoBloque = txtCodigo.Text
        objBloque.codigoEstante = cbEstante.SelectedValue
        objBloque.Bloque = txtBloque.Text
        objBloque.usuario = SesionActual.idUsuario
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        General.buscarElemento(objBloque.sqlBusqueda,
                                   Nothing,
                                   AddressOf cargarBloque,
                                   TitulosForm.BUSQUEDA_BLOQUE,
                                   False, 0, True)

        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
    End Sub

    Private Sub cargarBloque(pCodigo As String)
        Dim dFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        dFila = General.cargarItem(objBloque.sqlCargar, params)
        txtBloque.Text = dFila.Item(0)
        cbEstante.SelectedValue = dFila.Item(1)
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then

        End If
    End Sub
End Class