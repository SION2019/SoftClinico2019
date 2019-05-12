Imports System.Data.SqlClient
Public Class Form_tipo_Referencia
    'Dim cmd As New ClaseSocialBLL
    'Public buscar_clase_social As Boolean
    'Private Sub Tiposidentificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    General.deshabilitarBotones(ToolStrip1)
    '    btnuevo.Enabled = True '--Nuevo--
    '    btbuscar.Enabled = True '--Buscar--
    '    General.deshabilitarControles(Me)
    'End Sub

    'Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
    '    'descripcion guarda los documentos y actualiza: 
    '    'Autor: poseidon
    '    'fecha_creacion: 01/06/2016

    '    If txtnombre.Text = "" Then
    '        MsgBox("¡ Por favor digite el nombre de la Clase social !", MsgBoxStyle.OkOnly And MsgBoxStyle.Exclamation)
    '        txtnombre.Focus()
    '    Else
    '        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

    '            If (txtcodigo.Text, txtnombre.Text) = True Then
    '                General.deshabilitarBotones(ToolStrip1)
    '                General.deshabilitarControles(Me)
    '                btnuevo.Enabled = True
    '                btbuscar.Enabled = True
    '                bteditar.Enabled = True
    '                btanular.Enabled = True
    '                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
    '            End If

    '        End If
    '    End If
    'End Sub

    'Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
    '    'descripcion Anula un registro: 
    '    'Autor: poseidon
    '    'fecha_creacion: 01/06/2016
    '    If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
    '        If (txtcodigo.Text) = True Then
    '            General.deshabilitarBotones(ToolStrip1)
    '            General.deshabilitarControles(Me)
    '            btnuevo.Enabled = True
    '            btbuscar.Enabled = True
    '            MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
    '        Else
    '            '' aqui se va a poner algo si o no?
    '        End If
    '    End If
    'End Sub

    'Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
    '    General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
    '    txtnombre.Focus()

    'End Sub

    'Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
    '    General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
    'End Sub

    'Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
    '    General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    'End Sub

    'Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
    '    buscar_clase_social = True
    '    'cmd.BUSCAR()
    '    If txtcodigo.Text <> "" Then
    '        General.deshabilitarBotones(ToolStrip1)
    '        btnuevo.Enabled = True
    '        bteditar.Enabled = True
    '        btanular.Enabled = True
    '        btbuscar.Enabled = True
    '        btcancelar.Enabled = True
    '    End If
    'End Sub


    'Private Sub Tiposidentificacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '    If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
    '        Me.Dispose()
    '    Else
    '        e.Cancel = True
    '    End If
    'End Sub

End Class