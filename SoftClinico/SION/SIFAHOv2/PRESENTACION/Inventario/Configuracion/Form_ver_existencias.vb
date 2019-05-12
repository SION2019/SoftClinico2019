Public Class Form_ver_existencias
    Dim objVerExistencia As VerExixtenciasBodega
    Private Sub Form_ver_existencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objVerExistencia = New VerExixtenciasBodega
        cargarDatos()
    End Sub
    Public Sub setCodigoBodega(ByVal codigoBodega As Integer)
        objVerExistencia.codigoBodega = codigoBodega
        cargarDatos()
    End Sub
    Sub cargarDatos()
        objVerExistencia.listarProductosAsignadosBodega(TxtBuscar.Text)
        configurarGrid()
    End Sub
    Sub configurarGrid()
        With DgvProductosLotes
            .DataSource = objVerExistencia.tblProductos
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            If contarNumeroColumnasDgv(DgvProductosLotes) Then
                .Columns("Codigo").HeaderText = "Código"
                .Columns("Nombre").HeaderText = "Descripción"
                .Columns("Marca").HeaderText = "Marca"
                .Columns("Stock").HeaderText = "Stock"
                .Columns("Stock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Stock").DefaultCellStyle.NullValue = 0
                .Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                If .Columns.Contains("Lotes") = False Then
                    Dim columnaBoton As New DataGridViewButtonColumn
                    columnaBoton.Name = "Lotes"
                    columnaBoton.Text = "Detallado Lotes"
                    columnaBoton.UseColumnTextForButtonValue = True
                    columnaBoton.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO_ARIAL, 9)
                    DgvProductosLotes.Columns.Add(columnaBoton)
                    .Columns("Lotes").HeaderText = "Lotes"
                End If
                .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            End If
        End With


    End Sub
    Sub configurarGridLotes()
        With dgvDetalladoLotes
            .DataSource = objVerExistencia.tblLotes
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            If contarNumeroColumnasDgv(DgvProductosLotes) Then
                .Columns("Stock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("No. Lote").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("Costo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Costo").DefaultCellStyle.Format = "C2"
                .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            End If
        End With
    End Sub

    Function contarNumeroColumnasDgv(ByRef dgv As DataGridView) As Boolean
        If dgv.Columns.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub Form_ver_existencias_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub
    Private Sub TxtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBuscar.KeyPress
        If Asc(e.KeyChar) = 13 OrElse TxtBuscar.Text = "" Then
            TxtBuscar.Text = Funciones.validarComillaSimple(TxtBuscar.Text)
            cargarDatos()
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ocultarMotrarPanel()
    End Sub
    Sub ocultarMotrarPanel()
        pnlLotes.BringToFront()
        pnlLotes.Visible = Not pnlLotes.Visible
    End Sub

    Private Sub DgvProductosLotes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvProductosLotes.CellContentClick
        If Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Lotes", DgvProductosLotes) Then
            objVerExistencia.listarLotesDePorducto(objVerExistencia.tblProductos.Rows(e.RowIndex).Item("Codigo"))
            configurarGridLotes()
            asignarProductoPadreToPanel()
            ocultarMotrarPanel()
        End If
    End Sub
    Sub asignarProductoPadreToPanel()
        txtProducto.Text = objVerExistencia.tblProductos.Rows(DgvProductosLotes.CurrentRow.Index).Item("Nombre")
        txtMarca.Text = objVerExistencia.tblProductos.Rows(DgvProductosLotes.CurrentRow.Index).Item("Marca")
    End Sub
End Class