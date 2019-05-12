Public Class FormEstante
    Dim objEstante As Estante
    Private Sub FormEstante_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objEstante = New Estante
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        General.deshabilitarControles(ToolStrip1)
        btguardar.Enabled = True
        btcancelar.Enabled = True
        txtEstante.ReadOnly = False
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
            General.deshabilitarControles(ToolStrip1)
            btguardar.Enabled = True
            btcancelar.Enabled = True
            txtEstante.ReadOnly = False
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
                cargarObjEstante()
                EstanteBLL.guardarEstantes(objEstante)
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
    Private Sub cargarObjEstante()
        objEstante.codigoEstante = txtCodigo.Text
        objEstante.estante = txtEstante.Text
        objEstante.usuario = SesionActual.idUsuario
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        General.buscarElemento(objEstante.sqlBusqueda,
                                   Nothing,
                                   AddressOf cargarEstante,
                                   TitulosForm.BUSQUEDA_ESTANTE,
                                   False, 0, True)

        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
    End Sub

    Private Sub cargarEstante(pCodigo As String)
        Dim dFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        dFila = General.cargarItem(objEstante.sqlCargar, params)
        txtEstante.Text = dFila.Item(0)
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then

        End If
    End Sub
End Class