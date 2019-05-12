Public Class FormSispro
    Dim fechaInforme, fechaActual As Date
    Dim fechaInicio, fechaFinal As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function

    Private Sub llenarDgvSispro()
        Dim params As New List(Of String)
        params.Add(Format(CDate(fechaDesde.Value), Constantes.FORMATO_FECHA_GEN))
        params.Add(Format(CDate(fechaHasta.Value), Constantes.FORMATO_FECHA_GEN))
        params.Add(SesionActual.idEmpresa)
        Dim dtSispro As New DataTable
        Cursor = Cursors.WaitCursor
        btGenerar.Enabled = False
        General.llenarTabla(Consultas.INFORME_SISPRO, params, dtSispro)
        If dtSispro.Rows.Count > 0 Then
            dgvSispro.DataSource = dtSispro
            dgvSispro.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvSispro.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvSispro.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvSispro.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvSispro.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvSispro.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvSispro.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvSispro.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvSispro.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvSispro.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvSispro.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvSispro.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvSispro.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvSispro.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvSispro.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvSispro.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvSispro.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvSispro.Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvSispro.Columns(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvSispro.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvSispro.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvSispro.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvSispro.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvSispro.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            With dgvSispro
                .Columns(11).DefaultCellStyle.Format = ("N0")
                .Columns(15).DefaultCellStyle.Format = ("N0")
                .Columns(16).DefaultCellStyle.Format = ("N0")
                .Columns(18).DefaultCellStyle.Format = ("N0")
            End With
        End If
        btGenerar.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvSispro_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvSispro.DataError

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btGenerar.Click
        llenarDgvSispro()
    End Sub


    Private Sub btexcel_Click(sender As Object, e As EventArgs) Handles btexcel.Click
        btexcel.Enabled = False
        Try
            Dim nombreRpt As String = "Informe Sispro"
            Dim dtInforme As New DataTable
            Dim params As New List(Of String)
            params.Add(Format(CDate(fechaDesde.Value), Constantes.FORMATO_FECHA_GEN))
            params.Add(Format(CDate(fechaHasta.Value), Constantes.FORMATO_FECHA_GEN))
            params.Add(SesionActual.idEmpresa)
            Cursor = Cursors.WaitCursor
            General.llenarTabla(Consultas.INFORME_SISPRO, params, dtInforme)
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