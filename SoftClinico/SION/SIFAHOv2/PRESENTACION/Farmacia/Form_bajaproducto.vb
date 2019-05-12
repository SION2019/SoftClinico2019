Public Class Form_bajaproducto
    Dim perG As New Buscar_Permisos_generales
    Dim objBaja As BajaProducto
    Dim permisoGeneral, pNuevo, pEditar, pAnular, pBuscar, pBuscarProveedor As String

    Private Sub Form_bajaproducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarForm()
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
#Region "Metodos"
    Sub inicializarForm()
        objBaja = New BajaProducto
        permisoGeneral = perG.buscarPermisoGeneral(Name)
        pNuevo = permisoGeneral & "pp" & "01"
        pEditar = permisoGeneral & "pp" & "02"
        pAnular = permisoGeneral & "pp" & "03"
        pBuscar = permisoGeneral & "pp" & "04"
        enlazarTabla()
        llenarCombos()
        identificarSede()
        calcularTotalBaja()
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Sub empalmarObjetoToDiseño()
        txtcodigo.Text = objBaja.codigoBaja
        MTxtFecha.Value = objBaja.fechaBaja
        cmbComboBodega.SelectedValue = objBaja.codigoBodega
        cmbTipoBaja.SelectedValue = objBaja.motivo
    End Sub
    Sub empalmarDiseñoToObjeto()
        objBaja.codigoBaja = txtcodigo.Text
        objBaja.fechaBaja = MTxtFecha.Value
        objBaja.codigoBodega = cmbComboBodega.SelectedValue
        objBaja.motivo = cmbTipoBaja.SelectedValue
    End Sub
    Sub llenarCombos()
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        General.cargarCombo(Consultas.BOD_SOLICITANTE_LISTAR, params, "Nombre", "Codigo", cmbComboBodega)
        General.cargarCombo(Consultas.TIPO_BAJA, "Descripcion", "Codigo", cmbTipoBaja)
    End Sub
    Sub contarProductos()
        Label4.Text = "No. Productos: " & objBaja.tblProductos.Rows.Count
    End Sub
    Public Sub identificarSede()
        TxtCodigoSede.Text = SesionActual.codigoEP
        TxtSede.Text = SesionActual.nombreSede
        TxtSede.ReadOnly = True
    End Sub
    Sub enlazarTabla()
        With dgvproductos
            .Columns("Codigo").ReadOnly = True
            .Columns("Codigo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigo").DataPropertyName = "Codigo_producto"
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").DataPropertyName = "Descripcion"
            .Columns("Marca").ReadOnly = True
            .Columns("Marca").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Marca").DataPropertyName = "Marca"
            .Columns("Num_Lote").ReadOnly = True
            .Columns("Num_Lote").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Num_Lote").DataPropertyName = "Num_lote"
            .Columns("Fecha").ReadOnly = True
            .Columns("Fecha").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Fecha").DataPropertyName = "Fecha_Vence"
            .Columns("Stock").ReadOnly = True
            .Columns("Stock").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Stock").DataPropertyName = "Stock"
            .Columns("Costo").ReadOnly = True
            .Columns("Costo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Costo").DataPropertyName = "Costo"
            .Columns("Cantidad").ReadOnly = True
            .Columns("Cantidad").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cantidad").DataPropertyName = "Cantidad"
            .Columns("Total").ReadOnly = True
            .Columns("Total").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Total").DataPropertyName = "Total"
            .Columns("ok").ReadOnly = True
            .Columns("ok").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("ok").DataPropertyName = "Ok"
            objBaja.enlace.DataSource = objBaja.tblProductos
            .AutoGenerateColumns = False
            .DataSource = objBaja.enlace.DataSource
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With
    End Sub
    Public Sub cargarDatos(pcodigo As String)
        Dim fila As DataRow
        Dim params As New List(Of String)
        params.Add(pcodigo)
        fila = General.cargarItem(Consultas.CARGAR_BAJA_PRODUCTO_ENCABEZADO, params)
        objBaja.codigoBaja = pcodigo
        objBaja.codigoBodega = fila.Item("Codigo_Bodega")
        objBaja.motivo = fila.Item("Codigo_Motivo")
        objBaja.fechaBaja = fila.Item("Fecha_Creacion")
        params.Clear()
        params.Add(objBaja.codigoBaja)
        empalmarObjetoToDiseño()
        General.llenarTabla(Consultas.CARGAR_BAJA_PRODUCTO_DETALLE, params, objBaja.enlace.DataSource)
        contarProductos()
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, btimprimir, btanular)
    End Sub
    Sub calcularTotalBaja()
        dgvproductos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        dgvproductos.EndEdit()
        objBaja.tblProductos.AcceptChanges()
        Dim total As Double = 0
        total = If(IsDBNull(objBaja.tblProductos.Compute("Sum(Total)", "")), 0, objBaja.tblProductos.Compute("Sum(Total)", ""))
        TxtTotal.Text = FormatCurrency(total, 2)
        TxtTotal.Enabled = False
    End Sub
    Sub verificarCeldas(ByRef e As DataGridViewCellEventArgs)
        If Funciones.filaValida(e.RowIndex) Then
            dgvproductos.ReadOnly = False
            If Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Cantidad", dgvproductos) AndAlso btguardar.Enabled Then
                dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
            Else
                dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            End If
        End If
    End Sub
#End Region
#Region "Botones"
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(pNuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            MTxtFecha.Value = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
            identificarSede()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
        identificarSede()
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(pAnular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Try
                    Dim cmd As New BajaProductoBLL
                    cmd.anularBajaProdcuto(objBaja, SesionActual.idUsuario)
                    General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                Catch ex As Exception
                    general.manejoErrores(ex)
                End Try
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            If cmbComboBodega.SelectedIndex = 0 Then
                MsgBox("Debe escoger la bodega de la cual se va hacer la baja", MsgBoxStyle.Exclamation)
                cmbComboBodega.Focus()
            ElseIf cmbTipoBaja.SelectedIndex = 0 Then
                MsgBox("Debe escoger el motivo de la baja", MsgBoxStyle.Exclamation)
                cmbTipoBaja.Focus()
            ElseIf objBaja.tblProductos.Select("Cantidad=0", "").Count = objBaja.tblProductos.Rows.Count Then
                MsgBox("Debe colocar la cantidad por lo menos a un producto", MsgBoxStyle.Exclamation)
                dgvproductos.Focus()
            Else
                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + vbYesNo) = MsgBoxResult.Yes Then
                    Dim tbl_temp As New DataTable
                    tbl_temp = objBaja.tblProductos.Clone

                    Dim filas As DataRow()

                    filas = objBaja.tblProductos.Select("Ok='True'", "")

                    For Each fila As DataRow In filas
                        tbl_temp.ImportRow(fila)
                    Next

                    objBaja.tblProductos.Clear()
                    objBaja.tblProductos.Merge(tbl_temp)
                    tbl_temp.Dispose()
                    filas = Nothing

                    Try
                        Dim cmd As New BajaProductoBLL
                        empalmarDiseñoToObjeto()
                        cmd.guardarBajaProducto(objBaja, SesionActual.idUsuario, SesionActual.codigoEP)
                        General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, btanular, btimprimir)
                        cargarDatos(objBaja.codigoBaja)
                    Catch ex As Exception
                        general.manejoErrores(ex)
                    End Try

                End If
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(pBuscar ) Then
            Dim vSQL = Consultas.BUSQUEDA_BAJA_INVENTARIO & ", " & SesionActual.codigoEP
            General.buscarElemento(vSQL, Nothing, AddressOf cargarDatos, TitulosForm.BUSQUEDA_BAJA_PRODUCTO, False, 0, True)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
#End Region
#Region "Eventos Grilla"
    Private Sub dgvproductos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvproductos.EditingControlShowing
        RemoveHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
    End Sub
    Private Sub dgvproductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellClick
        verificarCeldas(e)
    End Sub
    Private Sub dgvproductos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellEnter
        verificarCeldas(e)
    End Sub
    Private Sub dgvproductos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvproductos.DataError
        e.Cancel = False
    End Sub
    Private Sub dgvproductos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellEndEdit
        If dgvproductos.Rows(e.RowIndex).Cells("Stock").Value < dgvproductos.Rows(e.RowIndex).Cells("Cantidad").Value Then
            dgvproductos.Rows(e.RowIndex).Cells("Cantidad").Value = 0
            MsgBox("La cantidad no puede ser mayor a el stock disponible !", MsgBoxStyle.Exclamation)
        End If
        calcularTotalBaja()
    End Sub
    Private Sub dgvproductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellDoubleClick
        If Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "ANULAR", dgvproductos) AndAlso MsgBox(Mensajes.QUITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            dgvproductos.Rows(e.RowIndex).Cells("Cantidad").Value = 0
            calcularTotalBaja()
        End If
    End Sub
#End Region
#Region "Otros Metodos"
    Private Sub txtBusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtBusqueda.TextChanged
        txtBusqueda.Text = Funciones.validarComillaSimple(txtBusqueda.Text)
        objBaja.enlace.Filter = "[Descripcion] like '%" & txtBusqueda.Text & "%' or [Marca] like '%" & txtBusqueda.Text & "%' or [Num_lote] like '%" & txtBusqueda.Text & "%'"
    End Sub
    Private Sub cmbTipoBaja_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoBaja.SelectedIndexChanged
        If cmbTipoBaja.SelectedIndex > 0 And txtcodigo.Text = "" Then
            Cursor = Cursors.WaitCursor
            Dim params As New List(Of String)
            params.Add(cmbComboBodega.SelectedValue)
            params.Add(cmbTipoBaja.SelectedValue)
            General.llenarTabla(Consultas.CARGAR_LOTES_BAJA_PRODUCTO, params, objBaja.tblProductos)
            Cursor = Cursors.Default
            contarProductos()
            dgvproductos.Columns("Cantidad").ReadOnly = False
        Else
            objBaja.tblProductos.Clear()
            dgvproductos.Columns("Cantidad").ReadOnly = False
        End If
    End Sub
    Private Sub Form_bajaproducto_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub


#End Region
End Class