Public Class FormPYG
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub llenarDgvCuentas()
        Dim params As New List(Of String)
        params.Add(Format(CDate(dtFechaInicio.Value), Constantes.FORMATO_FECHA_GEN))
        params.Add(Format(CDate(dtFechaFin.Value), Constantes.FORMATO_FECHA_GEN))
        Dim dtCuentas As New DataTable
        Cursor = Cursors.WaitCursor
        General.llenarTabla(Consultas.PYG_CARGAR, params, dtCuentas)
        If dtCuentas.Rows.Count > 0 Then
            dgvCuentas.DataSource = dtCuentas
            dgvCuentas.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvCuentas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvCuentas.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvCuentas.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvCuentas.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvCuentas.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvCuentas.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvCuentas.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvCuentas.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvCuentas.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvCuentas.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvCuentas.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvCuentas.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvCuentas.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvCuentas.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvCuentas.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvCuentas.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvCuentas.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvCuentas.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvCuentas.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            With dgvCuentas
                .Columns(2).DefaultCellStyle.Format = ("N0")
                .Columns(3).DefaultCellStyle.Format = ("N0")
                .Columns(4).DefaultCellStyle.Format = ("N0")
                .Columns(5).DefaultCellStyle.Format = ("N0")
                .Columns(6).DefaultCellStyle.Format = ("N0")
                .Columns(7).DefaultCellStyle.Format = ("N0")
                .Columns(8).DefaultCellStyle.Format = ("N0")
                .Columns(9).DefaultCellStyle.Format = ("N0")
            End With
            Cursor = Cursors.Default
        End If
        For i = 0 To dgvCuentas.Rows.Count - 1
            If dgvCuentas.Rows(i).Cells(0).Value = "" Or dgvCuentas.Rows(i).Cells(0).Value = "XXX" Then
                dgvCuentas.Rows(i).DefaultCellStyle.Font = New Font(dgvCuentas.DefaultCellStyle.Font, FontStyle.Bold)
                dgvCuentas.Rows(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
        Next
    End Sub
    Private Sub dtFecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtFechaFin.KeyPress
        If e.KeyChar = Chr(13) Then
            llenarDgvCuentas()
        End If
    End Sub

    Private Sub btexcel_Click(sender As Object, e As EventArgs) Handles btexcel.Click
        btexcel.Enabled = False
        Try
            Dim nombreRpt As String = "P Y G"
            Dim dtInforme As New DataTable
            Dim params As New List(Of String)
            params.Add(dtFechaInicio.Value)
            params.Add(dtFechaFin.Value)
            Cursor = Cursors.WaitCursor
            General.llenarTabla(Consultas.PYG_CARGAR, params, dtInforme)
            Dim rutaArchivo As String = FuncionesExcel.exportarDataTable(dtInforme, nombreRpt)
            Process.Start("file:///" & rutaArchivo)
        Catch ex As Exception
            general.manejoErrores(ex)
        Finally
            Cursor = Cursors.Default
        End Try
        btexcel.Enabled = True
    End Sub
End Class