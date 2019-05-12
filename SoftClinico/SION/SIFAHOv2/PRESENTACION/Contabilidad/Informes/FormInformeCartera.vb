Public Class FormInformeCartera
    Private Sub FormInformeCartera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.cargarCombo(Consultas.NOTIFICACION_GLOSA_BUSCAR_CLIENTES & "'" & Nothing & "'" & "," & "'" & SesionActual.idEmpresa & "'", "Cliente", "Id_Cliente", Comboeps)
    End Sub
    Private Sub Form_antici_decucci_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Public Sub sumarTotal()
        Dim tmas360 As Double = 0
        For i = 0 To dgvCartera.Rows.Count - 1
            tmas360 += dgvCartera.Rows(i).Cells(10).Value
        Next
        textvalortotal.Text = Math.Abs(tmas360)
        textvalortotal.Text = CDbl(textvalortotal.Text).ToString("C2")
    End Sub
    Private Sub btexcel_Click(sender As Object, e As EventArgs) Handles btexcel.Click
        btexcel.Enabled = False
        Try
            Dim nombreRpt As String = Label1.Text.ToLower & " " & Comboeps.Text.ToLower
            Dim dtCartera As New DataTable
            Dim params As New List(Of String)
            params.Add(Comboeps.SelectedValue)
            params.Add(SesionActual.idEmpresa)
            General.llenarTabla(Consultas.INFORME_DE_CARTERA, params, dtCartera)
            Cursor = Cursors.WaitCursor
            Dim rutaArchivo As String = FuncionesExcel.exportarDataTable(dtCartera, nombreRpt)
            Process.Start("file:///" & rutaArchivo)
        Catch ex As Exception
            general.manejoErrores(ex)
        Finally
            Cursor = Cursors.Default
        End Try
        btexcel.Enabled = True
    End Sub
    Private Sub cargarDatos()
        Dim dtCartera As New DataTable
        Dim params As New List(Of String)
        params.Add(Comboeps.SelectedValue)
        params.Add(SesionActual.idEmpresa)
        General.llenarTabla(Consultas.INFORME_DE_CARTERA, params, dtCartera)
        dgvCartera.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        dgvCartera.DataSource = dtCartera
        dgvCartera.Columns(3).Frozen = True
        dgvCartera.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCartera.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCartera.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCartera.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCartera.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCartera.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCartera.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCartera.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCartera.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCartera.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCartera.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCartera.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCartera.Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCartera.Columns(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCartera.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCartera.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCartera.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCartera.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCartera.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCartera.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCartera.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCartera.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvCartera.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        sumarTotal()
        With dgvCartera
            .Columns(4).DefaultCellStyle.Format = ("N0")
            .Columns(5).DefaultCellStyle.Format = ("N0")
            .Columns(6).DefaultCellStyle.Format = ("N0")
            .Columns(7).DefaultCellStyle.Format = ("N0")
            .Columns(8).DefaultCellStyle.Format = ("N0")
            .Columns(9).DefaultCellStyle.Format = ("N0")
            .Columns(10).DefaultCellStyle.Format = ("N0")
        End With
    End Sub

    Private Sub Comboeps_SelectedValueChanged(sender As Object, e As EventArgs) Handles Comboeps.SelectedValueChanged
        If Comboeps.SelectedIndex > 0 Then
            cargarDatos()
        End If
    End Sub
End Class