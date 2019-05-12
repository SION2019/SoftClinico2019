Public Class Form_Lista_Precio_Medicamento
    Dim enlce_dta As BindingSource = New BindingSource
    Dim i, c As Integer
    Dim lista As New ListaPrecioMedicamentoBLL
    Dim perG As New Buscar_Permisos_generales
    Dim dt As New DataTable
    Dim permiso_general, Pnuevo, Peditar, Panular As String
    Dim reporte As New ftp_reportes
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            txtBusqueda.Clear()
            txtcodigo.Clear()
            txtnombre.Clear()
            llenar_dgv(1)
            dt.AcceptChanges()
            dgvprocedimiento.DataSource = enlce_dta
            dgvprocedimiento.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvprocedimiento.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            Editar()
            enlce_dta.Filter = ""
            dgvprocedimiento.CommitEdit(DataGridViewDataErrorContexts.Commit)
            dgvprocedimiento.Focus()
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If

    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, Nothing)
        btbuscar.Enabled = True
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        General.mensajeProximante()
        Exit Sub
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                If lista.anular_LISTA(txtcodigo.Text) = True Then
                    txtnombre.Clear()
                    txtBusqueda.Clear()
                    txtcodigo.Clear()
                    DUPLICAR.Enabled = False
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    btanular.Enabled = False
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                End If
            End If
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub
    Private Sub dgvprocedimiento_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvprocedimiento.EditingControlShowing
        If dgvprocedimiento.CurrentCell.ColumnIndex = 3 Then
            Dim dText As DataGridViewTextBoxEditingControl = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
            RemoveHandler dText.KeyPress, AddressOf validar_Keypress
            AddHandler dText.KeyPress, AddressOf validar_Keypress
        End If
    End Sub

    Private Sub Form__FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If btguardar.Enabled = True Then
            e.Cancel = True
            MsgBox(Mensajes.CAMBIOS_SIN_GUARDAR, MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If dgvprocedimiento.CurrentCell.ColumnIndex = 3 Then
            Dim caracter As Char = e.KeyChar
            Dim txt As TextBox = CType(sender, TextBox)
            If (Char.IsNumber(caracter)) Or (caracter = ChrW(Keys.Back)) Or e.KeyChar = CChar(ChrW(Keys.Space)) Or
            (caracter = ",") And (txt.Text.Contains(",") = False) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If txtnombre.Text = "" Then
            MsgBox("¡ Por favor digite el nombre de la lista de precio !", MsgBoxStyle.Exclamation,)
            txtnombre.Focus()
            Exit Sub
        ElseIf MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        dgvprocedimiento.EndEdit()
        dt.AcceptChanges()
        Dim dttmp As New DataTable
        Dim filas As DataRow()
        dttmp = dt.Clone
        filas = dt.Select("Estado = 'True'")
        For Each row As DataRow In filas
            dttmp.ImportRow(row)
        Next
        Dim vNuevoCodigo As String = lista.guardar(txtcodigo.Text, txtnombre.Text, dttmp, CkVentaDirecta.Checked)
        If vNuevoCodigo <> "" Then
            txtcodigo.Text = vNuevoCodigo
            General.posGuardarForm(Me, ToolStrip1, btnuevo, bteditar, Nothing, btanular)
            btbuscar.Enabled = True
            DUPLICAR.Enabled = True
            btImprimir.Enabled = False
            CkVentaDirecta.Enabled = False
            txtBusqueda.ReadOnly = False
            txtBusqueda.Enabled = True
            txtBusqueda.Clear()
            llenar_dgv(0)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtBusqueda.TextChanged
        txtBusqueda.Text = Funciones.validarComillaSimple(txtBusqueda.Text)
        enlce_dta.Filter = " [Descripción] LIKE '%" + txtBusqueda.Text.Trim() + "%' or [Categoria] LIKE '%" + txtBusqueda.Text.Trim() + "%'  "
        For i As Int32 = 0 To dgvprocedimiento.Rows.Count - 1
            If dgvprocedimiento.Rows(i).Cells("Estado").Value = True Then
                dgvprocedimiento.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192) 'Color.Yellow
            End If
        Next
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                llenar_dgv(1)
                Editar()
            End If
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub buscar(Optional todo As Boolean = False)
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        If todo Then
            params.Add(1)
        Else
            params.Add(0)
        End If

        params.Add(Nothing)
        General.buscarElemento(Consultas.BUSQUEDA_LISTA_PRECIO_MEDICAMENTO, params, AddressOf cargar, TitulosForm.BUSQUEDA_LISTA_PRECIO_MEDICAMENTO, True, 0, True)

    End Sub

    Sub cargar(pcodigo As String)
        txtcodigo.Text = pcodigo.Split("|")(0)
        txtnombre.Text = pcodigo.Split("|")(1)
        Dim params As New List(Of String)
        params.Add(txtcodigo.Text)
        Dim fila As DataRow = General.cargarItem(Consultas.LISTA_PRECIO_TIPO_LISTA, params)
        If Not IsNothing(fila) Then
            CkVentaDirecta.Checked = CBool(fila.Item(0))
        End If
        btnuevo.Enabled = True
        bteditar.Enabled = True
        btanular.Enabled = True
        btbuscar.Enabled = True
        btcancelar.Enabled = False
        btImprimir.Enabled = True
        llenar_dgv(0)
        txtBusqueda.Enabled = True
        txtBusqueda.ReadOnly = False
        dgvprocedimiento.ReadOnly = True
        DUPLICAR.Enabled = True
        txtBusqueda.ReadOnly = False

    End Sub

    Private Sub DUPLICAR_Click(sender As Object, e As EventArgs) Handles DUPLICAR.Click
        txtcodigo.Clear()
        txtnombre.Clear()
        Editar()
        For i = 0 To dt.Rows.Count - 1
            dt.Rows(i).Item("Estado") = True
        Next
    End Sub

    Private Sub dgvprocedimiento_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvprocedimiento.CellEndEdit
        dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).Cells("Estado").Value = True
        dgvprocedimiento.Rows(dgvprocedimiento.CurrentRow.Index).DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192) 'Color.Yellow
    End Sub

    'Private Sub dgvprocedimiento_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvprocedimiento.CellFormatting
    '    If e.ColumnIndex = 3 Then
    '        If IsDBNull(e.Value) Then
    '            e.Value = Format(Val(0), "c2")
    '        Else
    '            e.Value = Format(Val(e.Value), "c2")
    '        End If
    '    End If
    'End Sub

    Private Sub txtnombre_TextChanged(sender As Object, e As EventArgs) Handles txtnombre.TextChanged

    End Sub

    Private Sub dgvprocedimiento_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvprocedimiento.DataError
        MsgBox(Mensajes.CANTIDAD_VALIDA, MsgBoxStyle.Exclamation)
    End Sub

    Private Sub tsImprimirHoja_Click(sender As Object, e As EventArgs) Handles tsImprimirHoja.Click
        buscar()
    End Sub

    Private Sub tsImprimirTodas_Click(sender As Object, e As EventArgs) Handles tsImprimirTodas.Click
        buscar(True)
    End Sub

    Private Sub dgvprocedimiento_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvprocedimiento.CellContentClick

    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        btImprimir.Enabled = False
        Try
            Dim ruta, area, nombreArchivo As String
            area = ConstantesHC.NOMBRE_PDF_LISTA_PRECIO
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtcodigo.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            guardarLista()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btImprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub guardarLista()
        Try

            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_LISTA_PRECIO, txtcodigo.Text, New rptListaPrecio,
                                    txtcodigo.Text, "{VISTA_LISTA_PRECIO_MEDICAMENTOS.codigo_lista_precio} = " & txtcodigo.Text & "",
                                    ConstantesHC.NOMBRE_PDF_LISTA_PRECIO, IO.Path.GetTempPath)

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub ReportePDFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportePDFToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        btImprimir.Enabled = False
        Try
            Dim ruta, area, nombreArchivo As String
            area = ConstantesHC.NOMBRE_PDF_LISTA_PRECIO
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtcodigo.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            guardarLista()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btImprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

        Try
            Dim nombreRpt As String = "Lista de precio"
            Dim dtInforme As New DataTable
            Dim params As New List(Of String)
            params.Add(txtcodigo.Text)
            Cursor = Cursors.WaitCursor
            General.llenarTabla(Consultas.LISTA_PRECIO_EXCEL, params, dtInforme)
            Dim rutaArchivo As String = FuncionesExcel.exportarDataTable(dtInforme, nombreRpt)
            Process.Start("file:///" & rutaArchivo)
        Catch ex As Exception
            General.manejoErrores(ex)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub Editar()
        dgvprocedimiento.MultiSelect = False
        dgvprocedimiento.Rows(0).Cells("Descripción").Selected = True
        btguardar.Enabled = True
        btanular.Enabled = False
        bteditar.Enabled = False
        btbuscar.Enabled = False
        btcancelar.Enabled = True
        btnuevo.Enabled = False
        btImprimir.Enabled = False
        txtnombre.ReadOnly = False
        txtBusqueda.Enabled = True
        txtBusqueda.ReadOnly = False
        CkVentaDirecta.Enabled = True
        DUPLICAR.Enabled = False
        dgvprocedimiento.ReadOnly = False
        dgvprocedimiento.Columns(1).ReadOnly = True
        dgvprocedimiento.Columns(2).ReadOnly = True
    End Sub

    Private Sub Form_SOAT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        txtBusqueda.Enabled = False
        txtnombre.ReadOnly = True
        DUPLICAR.Enabled = False
        CkVentaDirecta.Enabled = False
        btImprimir.Enabled = False
    End Sub

    Public Sub llenar_dgv(todo As Integer)
        dt.Clear()
        dt = lista.llenar_dgv(txtcodigo.Text, todo)
        Dim i As Integer
        enlce_dta.DataSource = dt
        dgvprocedimiento.DataSource = enlce_dta.DataSource
        dgvprocedimiento.ReadOnly = False
        dgvprocedimiento.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvprocedimiento.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        If dt.Rows.Count > 0 Then
            For i = 0 To dgvprocedimiento.Columns.Count - 1
                dgvprocedimiento.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                dgvprocedimiento.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                dgvprocedimiento.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            dgvprocedimiento.Columns(0).Visible = False
            dgvprocedimiento.Columns(1).Width = 740
            dgvprocedimiento.Columns(2).Width = 55
            dgvprocedimiento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvprocedimiento.Columns(3).Width = 110
            dgvprocedimiento.Columns(4).Visible = False
            dgvprocedimiento.Columns(5).Width = 50
            dgvprocedimiento.Columns(1).ReadOnly = True
            dgvprocedimiento.Columns(2).ReadOnly = True
            dgvprocedimiento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End If
        Funciones.validarCantidadCaracteresDGV(dgvprocedimiento, "Valor unitario", 10)
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub

End Class