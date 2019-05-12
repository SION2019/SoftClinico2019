Imports System.Data.SqlClient
Public Class Form_dirigidos
    Dim cmd As New DirigidoABLL
    Public buscar_clase_social As Boolean
    Public dtdirigido As New DataTable
    Private Sub Tiposidentificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.deshabilitarBotones(ToolStrip1)
        btguardar.Enabled = True

        dtdirigido = cmd.cargar_cargos
        cmd.establecer_tablas()
        dgvcapacitacion.DataSource = dtdirigido

        dgvcapacitacion.Columns("Codigo").ReadOnly = True
        dgvcapacitacion.Columns("Codigo").SortMode = DataGridViewColumnSortMode.NotSortable

        dgvcapacitacion.Columns("Cargo").ReadOnly = True
        dgvcapacitacion.Columns("Cargo").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcapacitacion.Columns("Cargo").Width = 100

        dgvcapacitacion.Columns("Seleccionar").ReadOnly = False
        dgvcapacitacion.Columns("Seleccionar").SortMode = DataGridViewColumnSortMode.NotSortable

        dgvcapacitacion.Columns("accion").ReadOnly = True
        dgvcapacitacion.Columns("accion").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcapacitacion.Columns("accion").Visible = False

        dgvcapacitacion.Columns(TitulosForm.ANULAR).Visible = True
        dgvcapacitacion.Columns(TitulosForm.ANULAR).DisplayIndex = 4

        dgvcapacitacion.AutoGenerateColumns = False

    End Sub


    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Dim dtaux As New DataTable
        'descripcion guarda los documentos y actualiza: 
        'Autor: poseidon
        'fecha_creacion: 01/06/2016 
        dgvcapacitacion.EndEdit()
        Form_maestro_capacitacion.cargo.Columns.Add()
        Form_maestro_capacitacion.cargo.Columns.Add()

        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            ' Form_maestro_capacitacion.cargo = dtdirigido.Select("Seleccionar = true")
            For j = 0 To dtdirigido.Rows.Count - 1
                If dtdirigido.Rows(j).Item("Seleccionar") = True Then
                    Form_maestro_capacitacion.cargo.Rows(j).Item(0) = dtdirigido.Rows(j).Item("Codigo")
                    Form_maestro_capacitacion.cargo.Rows(j).Item(1) = dtdirigido.Rows(j).Item("Cargo")
                    Dispose()
                End If
            Next
        End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        'descripcion Anula un registro: 
        'Autor: poseidon
        'fecha_creacion: 01/06/2016
        'If MsgBox(Mensajes.ANULAR,MsgBoxStyle .Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
        '    If cmd.anular_clasesocial(txtcodigo.Text) = True Then
        '        General.deshabilitarBotones(ToolStrip1)
        '        General.deshabilitarControles(Me)
        '        btnuevo.Enabled = True
        '        btbuscar.Enabled = True
        '        MsgBox(Mensajes.ANULAdo, MsgBoxStyle.Information)
        '    Else
        '        '' aqui se va a poner algo si o no?
        '    End If
        'End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        General.deshabilitarBotones(ToolStrip1)
        btguardar.Enabled = True '--Guardar--
    End Sub




    Private Sub Tiposidentificacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

End Class