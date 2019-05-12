Public Class Form_maestro_capacitacion
    Dim cmd As New MaestroCapacitadorBLL
    Public dt_capacitacion, dtasistentes, cargo As New DataTable
    Private Sub deshabilita_botenes()
        btnuevo.Enabled = False
        btguardar.Enabled = False
        btbuscar.Enabled = False
        bteditar.Enabled = False
        btcancelar.Enabled = False
        btanular.Enabled = False
        btimprimir.Enabled = False
        Btbuscar_respo.Enabled = False
    End Sub
    Private Sub deshabilita_controles()
        Dom_años.ReadOnly = True
        Textresponsable.ReadOnly = True
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form_maestro_capacitacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        deshabilita_botenes()
        deshabilita_controles()
        btnuevo.Enabled = True
        cmd.establecer_tabla(dt_capacitacion)

        'If dgvcapacitacion.ColumnCount = 0 Then

        dgvcapacitacion.Columns("Num").ReadOnly = True
        dgvcapacitacion.Columns("Num").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcapacitacion.Columns.Item("Num").DataPropertyName = "Num"
        dgvcapacitacion.Columns("Num").Visible = False

        dgvcapacitacion.Columns("Codigo").ReadOnly = True
        dgvcapacitacion.Columns("Codigo").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcapacitacion.Columns.Item("Codigo").DataPropertyName = "Codigo"

        dgvcapacitacion.Columns("Tema").ReadOnly = True
        dgvcapacitacion.Columns("Tema").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcapacitacion.Columns.Item("Tema").DataPropertyName = "Tema"
        dgvcapacitacion.Columns("Tema").Width = 100

        dgvcapacitacion.Columns("Fecha").ReadOnly = True
        dgvcapacitacion.Columns("Fecha").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcapacitacion.Columns.Item("Fecha").DataPropertyName = "Fecha"

        dgvcapacitacion.Columns("Id_capacitador").ReadOnly = True
        dgvcapacitacion.Columns("Id_capacitador").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcapacitacion.Columns.Item("Id_capacitador").DataPropertyName = "Id_capacitador"

        dgvcapacitacion.Columns("Capacitador").ReadOnly = True
        dgvcapacitacion.Columns("Capacitador").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcapacitacion.Columns.Item("Capacitador").DataPropertyName = "Capacitador"

        dgvcapacitacion.Columns("Dirigido_A").ReadOnly = True
        dgvcapacitacion.Columns("Dirigido_A").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcapacitacion.Columns.Item("Dirigido_A").DataPropertyName = "Dirigido_A"
        dgvcapacitacion.Columns("Dirigido_A").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'dgvcapacitacion.Columns("Dirigido A").DefaultCellStyle.Font = new font(constantes.TIPO_LETRA_ELEMENTO, 9, FontStyle.Underline)
        'dgvcapacitacion.Columns("Dirigido A").DefaultCellStyle.ForeColor = Color.Black

        dgvcapacitacion.Columns("Asistentes").ReadOnly = True
        dgvcapacitacion.Columns("Asistentes").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcapacitacion.Columns.Item("Asistentes").DataPropertyName = "Asistentes"
        dgvcapacitacion.Columns("Asistentes").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'dgvcapacitacion.Columns("Asistentes").DefaultCellStyle.Font = new font(constantes.TIPO_LETRA_ELEMENTO, 9, FontStyle.Underline)
        'dgvcapacitacion.Columns("Asistentes").DefaultCellStyle.ForeColor = Color.Black

        dgvcapacitacion.Columns("Accion").ReadOnly = True
        dgvcapacitacion.Columns("Accion").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcapacitacion.Columns.Item("Accion").DataPropertyName = "Accion"
        dgvcapacitacion.Columns("Accion").Visible = False

        'dgvcapacitacion.Columns(9).ReadOnly = True
        'dgvcapacitacion.Columns(9).SortMode = DataGridViewColumnSortMode.NotSortable

        dgvcapacitacion.Columns(TitulosForm.ANULAR).Visible = True
        dgvcapacitacion.Columns(TitulosForm.ANULAR).DisplayIndex = 9

        'End If
        dgvcapacitacion.DataSource = dt_capacitacion
        dgvcapacitacion.AutoGenerateColumns = False

    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        deshabilita_botenes()
        Dom_años.Text = Format(CDate(Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)), "yyyy")
        btguardar.Enabled = True
        btcancelar.Enabled = True
        Btbuscar_respo.Enabled = True
        With dgvcapacitacion
            .Columns("Tema").ReadOnly = False
            .Columns("Id_capacitador").ReadOnly = False
            .Columns("capacitador").ReadOnly = False
        End With
        dt_capacitacion.Rows.Add()
        conteo_filas()
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        deshabilita_botenes()
        btnuevo.Enabled = True
        Textresponsable.Clear()
        Dom_años.Text = ""
        With dgvcapacitacion
            .Columns("Tema").ReadOnly = True
            .Columns("Id_capacitador").ReadOnly = True
            .Columns("capacitador").ReadOnly = True
        End With
    End Sub
    Private Sub dgvcapacitacion_RowPostPaint(sender As System.Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvcapacitacion.RowPostPaint
        Dim nombre As String
        Using b As New SolidBrush(dgvcapacitacion.RowHeadersDefaultCellStyle.ForeColor)
            nombre = dt_capacitacion.Rows(e.RowIndex).Item("Num")
            e.Graphics.DrawString(nombre, dgvcapacitacion.Rows(e.RowIndex).Cells(0).InheritedStyle.Font, b, e.RowBounds.Location.X + 14, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Private Sub Btbuscar_respo_Click(sender As Object, e As EventArgs) Handles Btbuscar_respo.Click
        General.buscarElemento("EXEC [PROC_REPONSABLE_CAPACITACION]",
                               Nothing,
                               AddressOf cargarResponsableCapacitacion,
                               "Busqueda de responsable",
                               False, 0, True)
    End Sub

    Public Sub cargarResponsableCapacitacion(pCodigo As String)

    End Sub

    Private Sub conteo_filas()
        For j = 0 To dt_capacitacion.Rows.Count - 1
            dt_capacitacion.Rows(j).Item("Num") = j
        Next
    End Sub

    Private Sub dgvcapacitacion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvcapacitacion.CellContentClick
        If dt_capacitacion.Rows.Count > 0 Then
            If e.ColumnIndex = 7 Then
                Form_dirigidos.ShowDialog()
            ElseIf e.ColumnIndex = 8 Then
                Form_Asistentes.ShowDialog()
            End If
        End If
    End Sub
    Private Sub dgvcapacitacion_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvcapacitacion.KeyDown
        If dt_capacitacion.Rows.Count - 1 Then
            If dgvcapacitacion.CurrentCell.ColumnIndex = 5 Or dgvcapacitacion.CurrentCell.ColumnIndex = 6 Then
                If e.KeyCode = Keys.F3 Then
                    General.buscarElemento("EXEC [PROC_REPONSABLE_CAPACITACION]",
                               Nothing,
                               AddressOf cargarResponsableCapacitacion,
                               "Busqueda de responsable",
                               False, 0, True)
                End If
            End If
        End If
    End Sub

    Private Sub dgvcapacitacion_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvcapacitacion.CellLeave
        Dim aux As Boolean
        If dt_capacitacion.Rows.Count > 0 Then
            If e.ColumnIndex = 3 Then
                dgvcapacitacion.EndEdit()

                For j = 0 To dt_capacitacion.Rows.Count - 1
                    If IsDBNull(dt_capacitacion.Rows(j).Item("Tema")) Then
                        aux = True
                    End If
                Next

                If aux = False Then
                    If Not IsDBNull(dt_capacitacion.Rows(dgvcapacitacion.CurrentCell.RowIndex).Item("Tema")) Then
                        dt_capacitacion.Rows.Add()
                        conteo_filas()
                    End If
                End If
            End If
        End If
    End Sub
End Class