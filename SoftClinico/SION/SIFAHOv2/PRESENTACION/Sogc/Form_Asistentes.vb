Imports System.Data.SqlClient
Public Class Form_Asistentes
    Dim cmd As New AsistenteBLL
    Public dtasistente As New DataTable
    Private Sub Tiposidentificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.deshabilitarBotones(ToolStrip1)
        btguardar.Enabled = True

        cmd.establecer_tablas()
        dgvasistentes.DataSource = dtasistente

        dgvasistentes.Columns("Codigo").ReadOnly = True
        dgvasistentes.Columns("Codigo").SortMode = DataGridViewColumnSortMode.NotSortable

        dgvasistentes.Columns("Empleado").ReadOnly = True
        dgvasistentes.Columns("Empleado").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvasistentes.Columns("Empleado").Width = 100

        dgvasistentes.Columns("accion").ReadOnly = True
        dgvasistentes.Columns("accion").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvasistentes.Columns("accion").Visible = False

        dgvasistentes.Columns(TitulosForm.ANULAR).Visible = True
        dgvasistentes.Columns(TitulosForm.ANULAR).DisplayIndex = 3

        dgvasistentes.AutoGenerateColumns = False

        dtasistente.Rows.Add()

    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        'descripcion guarda los documentos y actualiza: 
        'Autor: poseidon
        'fecha_creacion: 01/06/2016 

        dgvasistentes.EndEdit()
        If MsgBox("enviar cargos seleccionados", 32 + 1, "enviar") = MsgBoxResult.Yes Then
            Form_maestro_capacitacion.dtasistentes = dtasistente.Copy
        End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        'descripcion Anula un registro: 
        'Autor: poseidon
        'fecha_creacion: 01/06/2016
        'If MsgBox(Mensajes.ANULAR,MsgBoxStyle .Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
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

    Private Sub dgvcapacitacion_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvasistentes.KeyDown
        If dtasistente.Rows.Count > 0 Then
            If e.KeyCode = Keys.F3 Then

                General.buscarElemento("EXEC [PROC_ASISTENTES_CAPACITACION]",
                                       Nothing,
                                       AddressOf cargarAsistenteCapacitacion,
                                       "Busqueda de asistentes",
                                       False)
            End If
        End If
    End Sub

    Public Sub cargarAsistenteCapacitacion(pCodigo As String)

    End Sub
End Class