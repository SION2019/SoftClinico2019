Public Class FormInformeExogena
    Dim fechaInicio As String = "01-01-"
    Dim fechaFinal As String = "31-12-"
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form_antici_decucci_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub btexcel_Click(sender As Object, e As EventArgs) Handles btexcel.Click
        Dim consulta As String
        btexcel.Enabled = False
        Try
            Dim nombreRpt As String = LabelTitulo.Text
            Dim dtInforme As New DataTable
            Dim params As New List(Of String)
            params.Add(fechaInicio & dtAño.Value.Year)
            params.Add(fechaFinal & dtAño.Value.Year)
            params.Add(SesionActual.idEmpresa)
            params.Add(comboInforme.SelectedValue)
            consulta = elegirInforme(comboInforme.SelectedValue)
            Cursor = Cursors.WaitCursor
            General.llenarTabla(consulta, params, dtInforme)
            Dim rutaArchivo As String = FuncionesExcel.exportarDataTable(dtInforme, nombreRpt)
            Process.Start("file:///" & rutaArchivo)
        Catch ex As Exception
            general.manejoErrores(ex)
        Finally
            Cursor = Cursors.Default
        End Try
        btexcel.Enabled = True
    End Sub
    Private Sub FormInformeExogena_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.cargarCombo(Consultas.INFORMES_DIAN_LISTAR, "Descripción", "Código", comboInforme)
    End Sub
    Private Sub llenarDgvExogena()
        Dim consulta As String
        Dim params As New List(Of String)
        params.Add(Format(CDate(fechaInicio & dtAño.Value.Year), Constantes.FORMATO_FECHA_GEN))
        params.Add(Format(CDate(fechaFinal & dtAño.Value.Year), Constantes.FORMATO_FECHA_GEN))
        params.Add(SesionActual.idEmpresa)
        params.Add(comboInforme.SelectedValue)
        consulta = elegirInforme(comboInforme.SelectedValue)
        Dim dtExogena As New DataTable
        Cursor = Cursors.WaitCursor
        General.llenarTabla(consulta, params, dtExogena)
        dgvExogena.DataSource = dtExogena
        dgvExogena.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvExogena.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvExogena.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvExogena.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvExogena.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvExogena.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvExogena.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvExogena.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvExogena.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvExogena.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvExogena.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvExogena.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvExogena.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvExogena.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvExogena.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvExogena.Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        Cursor = Cursors.Default
    End Sub

    Public Function elegirInforme(codigoInforme As String)
        Dim htInforme As New Hashtable
        htInforme.Add("1001", "PROC_INFORME_1001")
        htInforme.Add("1003", "PROC_INFORME_1003")
        htInforme.Add("1007", "PROC_INFORME_1007")
        htInforme.Add("1008", "PROC_INFORME_1008")
        htInforme.Add("1009", "PROC_INFORME_1009")
        htInforme.Add("1010", "PROC_INFORME_1010")
        Return htInforme.Item(codigoInforme)
    End Function

    Private Sub comboInforme_SelectedValueChanged(sender As Object, e As EventArgs) Handles comboInforme.SelectedValueChanged
        If comboInforme.SelectedIndex > 0 Then
            LabelTitulo.Text = comboInforme.Text.ToUpper
            llenarDgvExogena
        End If
    End Sub
End Class