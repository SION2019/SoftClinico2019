Public Class FormFacturaVSRadicado
    Private objFactVSradic As New FactuVSRadicado
    Private bdNavegador As New BindingSource
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormFacturaVSRadicado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvFactuVSRadicado.ReadOnly = True
        dtFechaInicio.Value = dtFechaInicio.Value.Date.AddDays(-dtFechaInicio.Value.Day).AddDays(1)
    End Sub
    Private Sub cargarCliente(codigoCliente As String)
        Dim params As New List(Of String)
        Dim dtFila As DataRow
        params.Add(codigoCliente)
        dtFila = General.cargarItem("PROC_LISTAR_CLIENTES_CARGAR", params)
        TxtCodigoCliente.Text = dtFila.Item("Nit")
        txtCliente.Text = dtFila.Item("Cliente")
        If objFactVSradic.dttable.Rows.Count > 0 Then
            chbRadicado.Checked = False
            bdNavegador.Filter = "Cliente like '%" + txtCliente.Text + "%'"
            calculos()
        End If
        btLimpiar.Visible = True
    End Sub
    Private Sub llenarInformacion()
        Dim params As New List(Of String)
        Try
            Cursor = Cursors.WaitCursor
            params.Add(Format(dtFechaInicio.Value.Date, Constantes.FORMATO_FECHA2))
            params.Add(Format(dtFechaFin.Value.Date, Constantes.FORMATO_FECHA2))
            params.Add(SesionActual.idEmpresa)
            params.Add(txtCliente.Text)
            General.llenarTabla("PROC_FACTURAS_RADICADAS_CONSULTAR", params, objFactVSradic.dttable)
            bdNavegador.Dispose()
            bdNavegador.DataSource = objFactVSradic.dttable
            dgvFactuVSRadicado.DataSource = bdNavegador.DataSource
            validarGrilla()
            dgvFactuVSRadicado.Columns("Paciente").Frozen = True
            calculos()
        Catch ex As Exception
            General.mensajeError(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub calculos()
        Dim dtw As DataView
        Dim dtInforme As New DataTable
        Try

            dtw = bdNavegador.DataSource.DefaultView()
            dtInforme = dtw.ToTable

            If dtInforme.Rows.Count > 0 Then
                If chbRadicado.Checked = False Then
                    Try
                        txtvalorRadicado.Text = Format(dtInforme.Compute("SUM(Valor)", "Radicado = True"), "C")
                        Try
                            txtValorSinRadicar.Text = Format(dtInforme.Compute("SUM(Valor)", "Radicado = False"), "C")
                        Catch ex As Exception
                            txtValorSinRadicar.Text = Format(Constantes.PENDIENTE, "C")
                        End Try
                    Catch ex As Exception
                        Try
                            txtvalorRadicado.Text = Format(Constantes.PENDIENTE, "C")
                            txtValorSinRadicar.Text = Format(dtInforme.Compute("SUM(Valor)", "Radicado = False"), "C")
                        Catch ex1 As Exception
                            txtValorSinRadicar.Text = Format(Constantes.PENDIENTE, "C")
                        End Try
                    End Try
                Else
                    txtValorSinRadicar.Text = Format(dtInforme.Compute("SUM(Valor)", "Radicado = False"), "C")
                End If
            End If

            lbNumRegistro.Text = "Registro: Nº " & dtInforme.Rows.Count.ToString

        Catch ex As Exception
            General.mensajeError(ex.Message)
        End Try
    End Sub
    Private Sub dgvFactuVSRadicado_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvFactuVSRadicado.CellFormatting
        If objFactVSradic.dttable.Rows.Count > 0 Then
            If e.ColumnIndex = 7 Or e.ColumnIndex = 11 Or e.ColumnIndex = 12 Then
                e.Value = If(Not IsDBNull(e.Value), Format(Val(e.Value), "c2"), 0)
            End If
        End If
    End Sub
    Private Sub btbuscartercero_Click(sender As Object, e As EventArgs) Handles btbuscartercero.Click
        Dim params As New List(Of String)
        params.Add(String.Empty)
        params.Add(SesionActual.idEmpresa)
        General.buscarElemento(Consultas.BUSQUEDA_CLIENTES_CONTRATO,
                             params,
                             AddressOf cargarCliente,
                             TitulosForm.BUSQUEDA_CONTRATO,
                             False, 0, True)
    End Sub
    Private Sub validarGrilla()
        For columnas = 0 To dgvFactuVSRadicado.ColumnCount - 1
            dgvFactuVSRadicado.Columns(columnas).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
    End Sub
    Private Sub chbRadicado_Click(sender As Object, e As EventArgs) Handles chbRadicado.Click
        If objFactVSradic.dttable.Rows.Count > 0 Then
            If chbRadicado.Checked = True Then
                bdNavegador.Filter = "Radicado = False and Cliente Like '%" + txtCliente.Text + "%'"
            Else
                If Not String.IsNullOrEmpty(TxtCodigoCliente.Text) Then
                    bdNavegador.Filter = "Cliente like '%" + txtCliente.Text + "%'"
                Else
                    bdNavegador.Filter = String.Empty
                End If
            End If
            calculos()
        End If
    End Sub
    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        TxtCodigoCliente.Clear()
        txtCliente.Clear()
        btLimpiar.Visible = False
        chbRadicado.Checked = False
        If objFactVSradic.dttable.Rows.Count > 0 Then
            bdNavegador.Filter = String.Empty
            llenarInformacion()
        End If
    End Sub
    Private Sub btexcel_Click(sender As Object, e As EventArgs) Handles btexcel.Click
        Dim dtw As DataView
        btexcel.Enabled = False
        Try
            Dim nombreRpt As String = "Facturacion vs Radicacion"
            Dim dtInforme As New DataTable
            Cursor = Cursors.WaitCursor
            dtw = bdNavegador.DataSource.DefaultView()
            dtInforme = dtw.ToTable
            Dim rutaArchivo As String = FuncionesExcel.exportarDataTable(dtReporte(dtInforme), nombreRpt)
            Process.Start("file:///" & rutaArchivo)
        Catch ex As Exception
            General.manejoErrores(ex)
        Finally
            Cursor = Cursors.Default
        End Try
        btexcel.Enabled = True
    End Sub
    Private Function dtReporte(dt As DataTable) As DataTable
        Dim dtClone As New DataTable
        dtClone = dt.Copy
        dtClone.Columns.Remove("Radicado")
        dtClone.Columns.Remove("Fecha Recibida")
        dtClone.Columns.Remove("Debito")
        dtClone.Columns.Remove("Credito")
        Return dtClone
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CDate(dtFechaInicio.Value).Date <= CDate(dtFechaFin.Value).Date Then
            llenarInformacion()
        Else
            MsgBox("La fecha final no puede ser mayor a la fecha inicial", MsgBoxStyle.Exclamation)
            dtFechaFin.Value = DateTime.Now
        End If
    End Sub

End Class