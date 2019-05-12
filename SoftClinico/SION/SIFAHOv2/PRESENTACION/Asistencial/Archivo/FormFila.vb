Imports System.Data.SqlClient
Public Class FormFila
    Dim objBloque As Bloque
    Dim objEstante As Estante
    Dim objFila As Fila
    Private Sub FormFila_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objBloque = New Bloque
        objEstante = New Estante
        objFila = New Fila
        General.cargarCombo(objEstante.sqlBusqueda, "Estante", "Codigo", cbEstante)
        General.cargarCombo(objBloque.sqlBusqueda, "Bloque", "Codigo", cbBloque)
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
        cbBloque.Enabled = True
        txtBloque.ReadOnly = False
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
            General.deshabilitarControles(ToolStrip1)
            btguardar.Enabled = True
            btcancelar.Enabled = True
            cbEstante.Enabled = True
            cbBloque.Enabled = True
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
                cargarObjFila()
                FilaBLL.guardarFila(objFila)
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

    Private Sub cargarObjFila()
        objFila.codigoFila = txtCodigo.Text
        objFila.codigoBloque = cbBloque.SelectedValue
        objFila.codigoEstante = cbEstante.SelectedValue
        objFila.fila = txtBloque.Text
        objFila.usuario = SesionActual.idUsuario
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        General.buscarElemento(objFila.sqlBusqueda,
                                   Nothing,
                                   AddressOf cargarFila,
                                   TitulosForm.BUSQUEDA_FILA,
                                   False, 0, True)

        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
    End Sub

    Private Sub cargarFila(pCodigo As String)
        Dim dFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        dFila = General.cargarItem(objFila.sqlCargar, params)
        txtBloque.Text = dFila.Item(0)
        cbEstante.SelectedValue = dFila.Item(1)
        cbBloque.SelectedValue = dFila.Item(2)
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then

        End If
    End Sub
End Class