Public Class Form_listado_medicamento_dispositivos_medicos
    Dim tblProductos As New DataTable

    Dim enlace As New BindingSource
    Private Sub Form_listado_medicamento_dispositivos_medicos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvproductos.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 7)
        llenarDatosdgv(Constantes.MEDICAMENTO)
        contarFilas()
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        llenarDatosdgv(Constantes.MEDICAMENTO)
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        llenarDatosdgv(Constantes.INSUMO)
    End Sub
    Private Sub Form__FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Public Sub llenarDatosdgv(ByVal TipoBus As String)
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        params.Add(TipoBus)
        General.llenarTabla(Consultas.LISTADO_MEDICAMENTOS_INSUMOS, params, tblProductos)
        enlace.DataSource = tblProductos
        dgvproductos.DataSource = enlace
        dgvproductos.EndEdit()
        dgvproductos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        tblProductos.AcceptChanges()
        dgvproductos.ReadOnly = True
        dgvproductos.Enabled = True
        contarFilas()
    End Sub
    Private Sub txtBusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtBusqueda.TextChanged
        txtBusqueda.Text = Funciones.validarComillaSimple(txtBusqueda.Text)
        enlace.Filter = "[Principio Activo] like '%" & txtBusqueda.Text & "%' or [Presentación Comercial] like '%" & txtBusqueda.Text & "%' or [Lote] like '%" & txtBusqueda.Text & "%'"
    End Sub
    Private Sub dgvproductos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvproductos.CellFormatting
        If e.ColumnIndex = 9 Then
            Select Case dgvproductos.Rows(e.RowIndex).Cells(10).Value
                Case "Amarillo"
                    e.CellStyle.BackColor = Color.Yellow
                Case "Verde"
                    e.CellStyle.BackColor = Color.Green
                Case "Rojo"
                    e.CellStyle.BackColor = Color.Red
            End Select
        End If
    End Sub
    Sub contarFilas()
        If dgvproductos.Columns.Contains("Color") Then
            dgvproductos.Columns("Color").Visible = False
        End If
        Label7.Text = "No. total de productos: " & tblProductos.Rows.Count
    End Sub
    Private Sub btImpirmir_Click(sender As Object, e As EventArgs) Handles btImpirmir.Click
        Dim tblParametros As New Hashtable
        tblParametros.Add("@pCODIGO_EP", SesionActual.codigoEP)
        tblParametros.Add("@pLINEA", If(RadioButton1.Checked, Constantes.MEDICAMENTO, Constantes.INSUMO))
        Try
            Dim rpt As New rptLitadoBasicoMedicamento
            Try
                Cursor = Cursors.WaitCursor
                Funciones.getReporteNoFTP(rpt, "{VISTA_EMPRESAS.Id_empresa} = " & SesionActual.idEmpresa,
                                          ConstantesHC.NOMBRE_PDF_LIQUIDACION, Constantes.FORMATO_PDF, tblParametros)
                Cursor = Cursors.Default
            Catch ex As Exception
                general.manejoErrores(ex)
            End Try

        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub
End Class