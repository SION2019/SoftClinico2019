Public Class FormGastosNomina
    Dim objPago As New PagoNomina
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormGastosNomina_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtRazonsocial.Text = "TODOS"
        objPago.codigoEmpresa = "-1"
        dgvGastosNomina.DataSource = objPago.Navegador.DataSource
        With dgvGastosNomina
            .Columns(0).Width = 140
            .Columns(1).Width = 100
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(2).Width = 300
            .Columns(3).Width = 200
            .Columns(4).Width = 100
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).Width = 70
        End With
    End Sub

    Private Sub btbuscartercero_Click(sender As Object, e As EventArgs) Handles btbuscartercero.Click
        Dim params As New List(Of String)
        params.Add(Nothing)
        General.buscarElemento(Consultas.BUSQUEDA_EMPRESA,
                                   params,
                                   AddressOf cargarEmpresa,
                                   TitulosForm.BUSQUEDA_EMPRESA,
                                   True,
                                   True,
                                   True)

    End Sub
    Public Sub cargarEmpresa(pCodigo As String)
        Dim drEmpresa As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        objPago.codigoEmpresa = pCodigo
        drEmpresa = General.cargarItem(Consultas.BUSQUEDA_EMPRESA_CARGAR, params)
        txtRazonsocial.Text = drEmpresa.Item("Razon_social").ToString
        rdbTodos.Checked = False
    End Sub
    Public Sub cargarObjetos()
        objPago.fechaInical = dtfecha_inicio.Value.Date
        objPago.fechaFin = dtfecha_fin.Value.Date
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cargarObjetos()
        objPago.cargarPagoNomina()
        Label6.Text = dgvGastosNomina.RowCount
        If Label6.Text = 0 Then
            btnExportar.Enabled = False
        Else
            btnExportar.Enabled = True
        End If
    End Sub

    Private Sub rdbTodos_Click(sender As Object, e As EventArgs) Handles rdbTodos.Click
        txtRazonsocial.Text = "TODOS"
        objPago.codigoEmpresa = "-1"
    End Sub

    Private Sub dgvGastosNomina_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvGastosNomina.CellFormatting
        If e.ColumnIndex = 4 Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), "c2")
            Else
                e.Value = Format(Val(e.Value), "c2")
            End If
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            Dim nombreRpt As String = "Reporte Gastos Nomina_"
            Dim ruta As String = FuncionesExcel.exportarDataTable(objPago.dtPagoNom, nombreRpt)
            Process.Start(ruta)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
End Class