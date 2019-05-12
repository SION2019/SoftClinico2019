Imports System.IO
Public Class Form_BusquedaGeneral
    Public Property consulta As String
    Public Property isOcultaCol As Boolean
    Public Property buscarAlDarEnter As Boolean
    Public Property metodoCarga As General.cargaInfoForm
    Public Property rowResultados As DataRow
    Public Property metodoCargaObj As General.cargaInfoFormObj
    Public Property isRetornaObj As Boolean

    Dim dtBusqueda As New DataTable
    Dim ex, ey As Integer
    Dim Arrastre As Boolean


    Private Sub dgvbusqueda_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvbusqueda.CellMouseDoubleClick
        If Funciones.filaValida(e.RowIndex) Then
            If isRetornaObj Then
                Dim filaSeleccionada As DataGridViewRow = dgvbusqueda.SelectedRows.Item(0)
                Dim registro As DataRow = DirectCast(filaSeleccionada.DataBoundItem.row, DataRow)

                metodoCargaObj.Invoke(registro)
                DialogResult = DialogResult.OK

            Else
                Dim codigo As String = dgvbusqueda.SelectedRows.Item(0).Cells.Item(0).Value.ToString
                If Not IsNothing(metodoCarga) Then
                    metodoCarga.Invoke(codigo)
                End If
                Dim row As DataRowView
                row = DirectCast(dgvbusqueda.CurrentRow.DataBoundItem, DataRowView)
                rowResultados = row.Row
                DialogResult = DialogResult.OK
            End If
        End If
    End Sub

    Public Overridable Sub Form_Busqueda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = Text
        Textbusqueda.Text = Funciones.validarComillaSimple(Textbusqueda.Text)
        llenardgv()
        Textbusqueda.SelectionStart = Textbusqueda.TextLength
        For I = 0 To dgvbusqueda.ColumnCount - 1
            dgvbusqueda.Columns(I).SortMode = DataGridViewColumnSortMode.Automatic
        Next
        If isOcultaCol Then
            dgvbusqueda.Columns(0).Visible = False
        End If
    End Sub
    Private Sub Textbusqueda_TextChanged(sender As Object, e As EventArgs) Handles Textbusqueda.TextChanged
        If buscarAlDarEnter = False Then
            Textbusqueda.Text = Funciones.validarComillaSimple(Textbusqueda.Text)
            llenardgv()
            Textbusqueda.SelectionStart = Textbusqueda.TextLength
        End If

    End Sub
    Private Sub Panel2_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel2.MouseDown
        ex = e.X
        ey = e.Y
        Arrastre = True
    End Sub

    Private Sub Panel2_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel2.MouseUp
        Arrastre = False
    End Sub

    Private Sub Panel2_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel2.MouseMove
        'Si el formulario no tiene borde (FormBorderStyle = none) la siguiente linea funciona bien

        If Arrastre Then Location = Me.PointToScreen(New Point(MousePosition.X - Location.X - ex, MousePosition.Y - Location.Y - ey))

        'pero si quieres dejar los bordes y la barra de titulo entonces es necesario descomentar la siguiente linea y comentar la anterior, osea ponerle el apostrofe

        'If Arrastre Then Me.Location = Me.PointToScreen(New Point(Me.MousePosition.X - Me.Location.X - ex - 8, Me.MousePosition.Y - Me.Location.Y - ey - 60))
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        Panel2_MouseDown(sender, e)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        Panel2_MouseUp(sender, e)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        Panel2_MouseMove(sender, e)
    End Sub

    Private Sub Label2_MouseDown(sender As Object, e As MouseEventArgs) Handles Label2.MouseDown
        Panel2_MouseDown(sender, e)
        ex += Label2.Location.X
    End Sub

    Private Sub Label2_MouseUp(sender As Object, e As MouseEventArgs) Handles Label2.MouseUp
        Panel2_MouseUp(sender, e)
    End Sub

    Private Sub Label2_MouseMove(sender As Object, e As MouseEventArgs) Handles Label2.MouseMove
        Panel2_MouseMove(sender, e)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Busqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles Textbusqueda.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        ElseIf buscarAlDarEnter = True And e.KeyCode = Keys.Enter Then
            Textbusqueda.Text = Funciones.validarComillaSimple(Textbusqueda.Text)
            llenardgv()
            Textbusqueda.SelectionStart = Textbusqueda.TextLength
        End If
    End Sub

    Public Sub llenardgv()
        Dim busqueda As New Form_busqueda_c
        If consulta <> "" Then
            dtBusqueda = busqueda.llenar(consulta, Textbusqueda.Text)
            dgvbusqueda.DataSource = dtBusqueda
            dgvbusqueda.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvbusqueda.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 8)
        End If

    End Sub
End Class