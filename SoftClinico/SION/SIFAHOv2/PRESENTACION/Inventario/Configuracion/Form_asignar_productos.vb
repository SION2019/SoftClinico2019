Public Class Form_asignar_productos
    Dim objProductoAsignacionBll As New ProductoAsignacionBLL
    Dim objAsignarProductosBodega As AsignarProductosBodega
    Public Property objBodega As BodegaE
    Private Sub Form_asignar_productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarForm()
    End Sub
#Region "Metodos"
    Sub inicializarForm()
        objAsignarProductosBodega = New AsignarProductosBodega
        objAsignarProductosBodega.codigoBodega = objBodega.codigo
        dgvAsignados.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        dgvPorAsignar.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        cargarProductosGenerales()
        For i = 0 To dgvPorAsignar.Columns.Count - 1
            dgvPorAsignar.Columns(i).ReadOnly = True
        Next
        For i = 0 To dgvAsignados.Columns.Count - 1
            dgvAsignados.Columns(i).ReadOnly = True
        Next
    End Sub
    Public Sub cargarProductosGenerales()
        llenarTablaSinAsingar()
        llenarTablaAsignados()
        enlazarDgvs()
    End Sub
    Sub llenarTablaSinAsingar()
        Dim params As New List(Of String)
        params.Add(objAsignarProductosBodega.codigoBodega)
        General.llenarTabla(Consultas.PRODUCTOS_BODEGA_SIN_ASIGNAR, params, objAsignarProductosBodega.tablaProductosSinAsignar)
    End Sub
    Sub llenarTablaAsignados()
        Dim params As New List(Of String)
        params.Add(objAsignarProductosBodega.codigoBodega)
        General.llenarTabla(Consultas.PRODUCTOS_BODEGA_ASIGNADOS, params, objAsignarProductosBodega.tablaProductosAsignados)
    End Sub
    Sub llenarTablaSinAsingarBusqueda()
        Dim params As New List(Of String)
        params.Add(objAsignarProductosBodega.codigoBodega)
        params.Add(txtBusquedaSinasignar.Text)
        params.Add(obtenerProductosSeleccionados(objAsignarProductosBodega.tablaProductosSinAsignar))
        General.llenarTabla(Consultas.PRODUCTOS_BODEGA_SIN_ASIGNAR_BUSCAR, params, objAsignarProductosBodega.tablaProductosSinAsignar)
    End Sub
    Sub llenarTablaAsingados()
        Dim params As New List(Of String)
        params.Add(objAsignarProductosBodega.codigoBodega)
        params.Add(txtBusquedaASignados.Text)
        params.Add(obtenerProductosSeleccionados(objAsignarProductosBodega.tablaProductosAsignados))
        General.llenarTabla(Consultas.PRODUCTOS_BODEGA_ASIGNADOS_BUSCAR, params, objAsignarProductosBodega.tablaProductosAsignados)
    End Sub
    Sub enlazarDgvs()
        establecerEnlaceNoAsignados()
        establecerEnlaceAsignados()
    End Sub
    Sub establecerEnlaceNoAsignados()
        dgvPorAsignar.DataSource = objAsignarProductosBodega.tablaProductosSinAsignar
        dgvPorAsignar.AutoGenerateColumns = False
        dgvPorAsignar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub
    Sub establecerEnlaceAsignados()
        dgvAsignados.DataSource = objAsignarProductosBodega.tablaProductosAsignados
        dgvAsignados.AutoGenerateColumns = False
        dgvAsignados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

#End Region
#Region "Funciones"
    Function obtenerProductosSeleccionados(ByVal tablaProductos As DataTable) As String
        Dim productos As String
        For indiceFila = 0 To tablaProductos.Rows.Count - 1
            If tablaProductos.Rows(indiceFila).Item("Asignar") = True Then
                If indiceFila = 0 Then
                    productos = tablaProductos.Rows(indiceFila).Item("Codigo")
                Else
                    productos += Chr(44) & tablaProductos.Rows(indiceFila).Item("Codigo")
                End If

            End If
        Next
        Return productos
    End Function
    Function estraerProductosSeleecionados(ByRef tbl As DataTable) As DataTable
        Dim tblTemp As New DataTable
        Dim filas As DataRow()
        tblTemp = tbl.Clone
        filas = tbl.Select("[Asignar] = True", "")
        For Each fila As DataRow In filas
            tblTemp.ImportRow(fila)
        Next
        Return tblTemp
    End Function
#End Region
#Region "Eventos de controles"
    Private Sub txtBusquedaSinasignar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBusquedaSinasignar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtBusquedaSinasignar.Text = Funciones.validarComillaSimple(txtBusquedaSinasignar.Text)
            Dim tblTemp As New DataTable
            tblTemp = estraerProductosSeleecionados(objAsignarProductosBodega.tablaProductosSinAsignar)
            llenarTablaSinAsingarBusqueda()
            objAsignarProductosBodega.tablaProductosSinAsignar.Merge(tblTemp)
        End If
    End Sub
    Private Sub txtBusquedaASignados_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBusquedaASignados.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtBusquedaASignados.Text = Funciones.validarComillaSimple(txtBusquedaASignados.Text)
            Dim tblTemp As New DataTable
            tblTemp = estraerProductosSeleecionados(objAsignarProductosBodega.tablaProductosAsignados)
            llenarTablaAsingados()
            objAsignarProductosBodega.tablaProductosAsignados.Merge(tblTemp)
        End If
    End Sub
#End Region
#Region "Botones"
    Private Sub Btnasignados_Click(sender As Object, e As EventArgs) Handles Btnasignados.Click
        dgvPorAsignar.DataSource = objProductoAsignacionBll.seleccionados_sin_asignar(objAsignarProductosBodega.tablaProductosSinAsignar)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        dgvAsignados.DataSource = objProductoAsignacionBll.seleccionados_asignados(objAsignarProductosBodega.tablaProductosAsignados)
    End Sub
    Private Sub btnVerTodos_Click(sender As Object, e As EventArgs) Handles btnVerTodos.Click
        dgvPorAsignar.Columns(dgvPorAsignar.Columns.Count - 1).Visible = True
        txtBusquedaSinasignar.ResetText()
        establecerEnlaceNoAsignados()
    End Sub
    Private Sub btnVerTodos2_Click(sender As Object, e As EventArgs) Handles btnVerTodos2.Click
        dgvAsignados.Columns(dgvAsignados.Columns.Count - 1).Visible = True
        txtBusquedaASignados.ResetText()
        establecerEnlaceAsignados()
    End Sub
    Private Sub Asignar_Click(sender As Object, e As EventArgs) Handles Asignar.Click
        objAsignarProductosBodega.tablaProductosSinAsignar.AcceptChanges()
        If objAsignarProductosBodega.tablaProductosSinAsignar.Select("[Asignar] = True").Count > 0 Then
            If MsgBox("¿ Desea asignar los productos ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If objProductoAsignacionBll.asignar_productos(objAsignarProductosBodega.tablaProductosSinAsignar, objAsignarProductosBodega.codigoBodega) = True Then
                    txtBusquedaASignados.ResetText()
                    txtBusquedaSinasignar.ResetText()
                    cargarProductosGenerales()
                    MsgBox("Asignación Exitosa !!", MsgBoxStyle.Information)
                End If
            End If
        Else
            MsgBox("Debe seleccionar productos antes de asignarlos")
        End If

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If objAsignarProductosBodega.tablaProductosAsignados.Select("[Asignar] = True").Count > 0 Then
            If MsgBox("¿ Desea quitar los productos ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If objProductoAsignacionBll.quitar_productos(objAsignarProductosBodega) = True Then
                    txtBusquedaASignados.ResetText()
                    txtBusquedaSinasignar.ResetText()
                    cargarProductosGenerales()
                    MsgBox("Productos quitados con éxito !!", MsgBoxStyle.Information)
                End If
            End If
        Else
            MsgBox("Debe seleccionar productos antes de quitarlos")
        End If
    End Sub
#End Region
    Private Sub dgvAsignados_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAsignados.CellClick

        If Funciones.filaValida(e.RowIndex) Then
            If Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Asignar", dgvAsignados) Then
                If objProductoAsignacionBll.verificar_existencia_producto(dgvAsignados.Rows(e.RowIndex).Cells("Codigo").Value, objBodega.codigo) = True Then
                    dgvAsignados.Rows(e.RowIndex).Cells("Asignar").ReadOnly = True
                    dgvAsignados.Rows(e.RowIndex).Cells("Asignar").Value = False
                    MsgBox("No puede retirar de bodega debido a que tiene stock habil en bodega !!", MsgBoxStyle.Information)
                Else
                    dgvAsignados.Rows(e.RowIndex).Cells("Asignar").ReadOnly = False
                End If
            Else
                dgvAsignados.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            End If
        End If
    End Sub
    Private Sub dgvPorAsignar_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPorAsignar.CellClick
        If Funciones.filaValida(e.RowIndex) Then
            If Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Asignar", dgvAsignados) Then
                dgvPorAsignar.Rows(e.RowIndex).Cells("Asignar").ReadOnly = False
            Else
                dgvPorAsignar.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            End If
        End If

    End Sub
    Private Sub Form__FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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


End Class