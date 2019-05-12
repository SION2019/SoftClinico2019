Public Class FormRemision
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, pBuscarCliente, pBuscarCotizacion As String
    Dim objRemi As RemisionProducto
    Dim cmd As New RemisionInventarioBLL
    Dim tipodgv As Integer
    Private Sub FormRemision_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objRemi = New RemisionProducto
        enlazarColumnas()
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        pBuscarCliente = permiso_general & "pp" & "05"
        pBuscarCotizacion = permiso_general & "pp" & "06"
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
        iniciarValores()
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function

#Region "Metodos"
    Public Sub cargarRemision(ByVal codigoRemision As Integer)
        Dim params As New List(Of String)
        Dim tblTemp As New DataTable


        params.Add(codigoRemision)
        General.llenarTabla(Consultas.CARGAR_REMISIONES_CLIENTE, params, tblTemp)


        objRemi.codigoCotizacion = IIf(tblTemp.Rows(0).Item(0) Is DBNull.Value, "", tblTemp.Rows(0).Item(0))
        objRemi.codigoCliente = tblTemp.Rows(0).Item(1)
        objRemi.codigoRemision = codigoRemision
        objRemi.fechaRemision = tblTemp.Rows(0).Item(3)
        objRemi.observacionRemision = tblTemp.Rows(0).Item(4)
        objRemi.estado = tblTemp.Rows(0).Item("Estado")
        cargarContratoCliente(objRemi.codigoCliente)
        cmbContrato.SelectedValue = tblTemp.Rows(0).Item("codigo_contrato")

        txtcodigo.Text = objRemi.codigoRemision
        txtCodigoCliente.Text = objRemi.codigoCliente
        txtNombreCliente.Text = tblTemp.Rows(0).Item(2)
        txtCodigoCotizacion.Text = objRemi.codigoCotizacion
        DtpFecha.Value = objRemi.fechaRemision
        txtObservaciones.Text = objRemi.observacionRemision
        txtEstado.Text = General.getEstadoInventario(objRemi.estado)
        'Medicamentos 
        params.Clear()
        params.Add(codigoRemision)
        params.Add(Constantes.MEDICAMENTO)
        General.llenarTabla(Consultas.CARGAR_REMISIONES_DETALLE_INVENTARIO, params, objRemi.tblMedicamentos)
        'Insumos 
        params.Clear()
        params.Add(codigoRemision)
        params.Add(Constantes.INSUMO)
        General.llenarTabla(Consultas.CARGAR_REMISIONES_DETALLE_INSUMO_INVENTARIO, params, objRemi.tblInsumos)
        'procedimientos
        'params.Clear()
        'params.Add(codigoRemision)
        'General.llenarTabla(Consultas.CARGAR_REMISIONES_DETALLE_PROCEDIMIENTOS_INVENTARIO, params, objRemi.tblProcedimientos)



        tblTemp.Reset()
        dgvProductos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        dgvInsumos.CommitEdit(DataGridViewDataErrorContexts.Commit)

        tab.SelectedIndex = 0

        objRemi.tblLotesMedIns.Reset()
        Dim filasMedicamentos As DataRowCollection = objRemi.tblMedicamentos.Rows
        Dim tablas As DataTableCollection = objRemi.tblLotesMedIns.Tables
        For i = 0 To filasMedicamentos.Count - 1
            params.Clear()
            dgvProductos.Rows(i).Cells("Codigo_bodega").Value = filasMedicamentos(i).Item("Codigo_bodega")

            nombrarTabla(filasMedicamentos(i).Item("Codigo"), i, Constantes.MEDICAMENTO)
            objRemi.tblLotesMedIns.Tables.Add(objRemi.nombreTabla)

            params.Add(objRemi.codigoRemision)
            params.Add(filasMedicamentos(i).Item("Codigo"))
            params.Add(Constantes.MEDICAMENTO)
            objRemi.IndexTbl = i
            cargarBodega(filasMedicamentos(i).Item("Codigo_bodega"))
            General.llenarTabla(Consultas.CARGAR_REMISIONES_DETALLE_LOTES_INVENTARIO, params, tablas(objRemi.nombreTabla))

        Next

        tab.SelectedIndex = 1
        Dim filasInsumos As DataRowCollection = objRemi.tblInsumos.Rows

        For i = 0 To filasInsumos.Count - 1
            params.Clear()
            dgvInsumos.Rows(i).Cells("Codigo_BodegaI").Value = filasInsumos(i).Item("Codigo_BodegaI")

            nombrarTabla(filasInsumos(i).Item("CodigoI"), i, Constantes.INSUMO)
            tablas.Add(objRemi.nombreTabla)

            params.Add(objRemi.codigoRemision)
            params.Add(filasInsumos(i).Item("CodigoI"))
            params.Add(Constantes.INSUMO)
            objRemi.IndexTbl = i
            cargarBodegaI(filasInsumos(i).Item("Codigo_bodegaI"))
            General.llenarTabla(Consultas.CARGAR_REMISIONES_DETALLE_LOTES_INVENTARIO, params, tablas(objRemi.nombreTabla))
        Next
        tab.SelectedIndex = 0
        tblTemp.Dispose()
        objRemi.tblLotesMedIns.AcceptChanges()
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, btanular, btimprimir)
        carcularTotales()
        If objRemi.estado = True Then
            btanular.Enabled = False
        End If
    End Sub
    Sub iniciarValores()
        TxtTotalMedicamentos.Text = FormatCurrency(0, 2)
        TxtTotalInsumos.Text = FormatCurrency(0, 2)
        TxtTotalProcedimiento.Text = FormatCurrency(0, 2)
        TxtTotal.Text = FormatCurrency(0, 2)
    End Sub
    Sub bloquearControlesInternos()
        txtNombreCliente.ReadOnly = True
        txtCodigoCotizacion.ReadOnly = True
        txtCodigoCliente.ReadOnly = True
        TxtTotalMedicamentos.ReadOnly = True
        TxtTotalInsumos.ReadOnly = True
        TxtTotalProcedimiento.ReadOnly = True
        TxtTotal.ReadOnly = True
        TxtDescripcionProducto.ReadOnly = True
        TxtCantidadProducto.ReadOnly = True
        txtEstado.ReadOnly = True
    End Sub
    Public Sub cargarCotizacion(ByVal codigo As String)
        Dim tblTemp As New DataTable

        objRemi.codigoCotizacion = CInt(codigo)
        txtCodigoCotizacion.Text = objRemi.codigoCotizacion

        Dim params As New List(Of String)
        params.Add(objRemi.codigoCotizacion)

        General.llenarTabla(Consultas.BUSQUEDA_COTIZACION_CLIENTE, params, tblTemp)
        cargarCliente(tblTemp.Rows(0).Item(0))
        tblTemp.Dispose()
    End Sub
    Public Sub cargarCliente(ByVal codigo As String)
        Dim params As New List(Of String)
        Dim fila As DataRow
        objRemi.codigoCliente = codigo
        params.Add(objRemi.codigoCliente)
        params.Add(SesionActual.idEmpresa)

        fila = General.cargarItem(Consultas.BUSQUEDA_CLIENTES_INDIVIDUAL, params)
        txtCodigoCliente.Text = fila.Item(1)
        txtNombreCliente.Text = fila.Item(3)
        objRemi.tblMedicamentos.Clear()
        objRemi.tblInsumos.Clear()
        objRemi.tblProcedimientos.Clear()
        If txtCodigoCotizacion.Text <> "" Then
            cargarDetalleCotizacion()
        End If
        objRemi.tblMedicamentos.Rows.Add()
        objRemi.tblInsumos.Rows.Add()
        objRemi.tblProcedimientos.Rows.Add()
        cargarContratoCliente(objRemi.codigoCliente)
    End Sub
    Sub cargarContratoCliente(ByVal cliente As Integer)
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        params.Add(cliente)
        General.cargarCombo(Consultas.REMISION_INVENTARIO_LISTAR_CONTRATOS, params, "Nombre", "Codigo", cmbContrato)
    End Sub
    Sub cargarDetalleCotizacion()
        General.llenarTablaYdgv(Consultas.CLASIFICACION_MEDICAMENTOS_INSUMOS_REMISION & " " & Constantes.MEDICAMENTO & "," & objRemi.codigoCotizacion, objRemi.tblMedicamentos)
        General.llenarTablaYdgv(Consultas.CLASIFICACION_MEDICAMENTOS_INSUMOS_REMISION & " " & Constantes.INSUMO & "," & objRemi.codigoCotizacion, objRemi.tblInsumos)
        iniciarValores()
    End Sub
    Sub enlazarColumnas()
        With dgvProductos
            .Columns("CodigoProducto").DataPropertyName = "Codigo"
            .Columns("CodigoProducto").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").DataPropertyName = "Descripcion"
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Marca").DataPropertyName = "Marca"
            .Columns("Marca").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cantidad").DataPropertyName = "Cantidad"
            .Columns("Cantidad").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigo_bodega").DataPropertyName = "Codigo_bodega"
            .Columns("Codigo_bodega").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Bodega_Escoger").DataPropertyName = "Bodega_Escoger"
            .Columns("Bodega_Escoger").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantidadDes").DataPropertyName = "CantidadDes"
            .Columns("CantidadDes").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Precio").DataPropertyName = "Precio"
            .Columns("Precio").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Total").DataPropertyName = "Total"
            .Columns("Total").SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        dgvProductos.AutoGenerateColumns = False
        dgvProductos.DataSource = objRemi.tblMedicamentos
        dgvProductos.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)

        With dgvInsumos
            .Columns("CodigoProductoI").DataPropertyName = "CodigoI"
            .Columns("CodigoProductoI").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DescripcionI").DataPropertyName = "DescripcionI"
            .Columns("DescripcionI").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("MarcaI").DataPropertyName = "MarcaI"
            .Columns("MarcaI").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantidadI").DataPropertyName = "CantidadI"
            .Columns("CantidadI").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigo_BodegaI").DataPropertyName = "Codigo_bodegaI"
            .Columns("Codigo_BodegaI").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("BodegaI_Escoger").DataPropertyName = "BodegaI_Escoger"
            .Columns("BodegaI_Escoger").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantidadDesI").DataPropertyName = "CantidadDesI"
            .Columns("CantidadDesI").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("PrecioI").DataPropertyName = "PrecioI"
            .Columns("PrecioI").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("TotalI").DataPropertyName = "TotalI"
            .Columns("TotalI").SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        dgvInsumos.AutoGenerateColumns = False
        dgvInsumos.DataSource = objRemi.tblInsumos
        dgvInsumos.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)

        With dgvProce
            .Columns("CodigoPro").DataPropertyName = "CodigoPro"
            .Columns("CodigoPro").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("DescripcionPro").DataPropertyName = "DescripcionPro"
            .Columns("DescripcionPro").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantidadPro").DataPropertyName = "CantidadPro"
            .Columns("CantidadPro").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("PrecioPro").DataPropertyName = "PrecioPro"
            .Columns("PrecioPro").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("TotalPro").DataPropertyName = "TotalPro"
            .Columns("TotalPro").SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        dgvProce.AutoGenerateColumns = False
        dgvProce.DataSource = objRemi.tblProcedimientos
        dgvProce.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Sub enlazarColumnasLotes()
        With dgvLotes
            .Columns("Reg_lote").DataPropertyName = "Reg_lote"
            .Columns("Reg_lote").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Reg_lote").Visible = False
            .Columns("Num_lote").DataPropertyName = "Num_lote"
            .Columns("Num_lote").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Num_lote").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns("Fecha").DataPropertyName = "Fecha"
            .Columns("Fecha").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("stockLote").DataPropertyName = "Stock"
            .Columns("stockLote").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantidadLote").DataPropertyName = "Cantidad"
            .Columns("CantidadLote").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Costo").DataPropertyName = "Precio"
            .Columns("Costo").HeaderText = "Precio"
            .Columns("Costo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("TotalLote").DataPropertyName = "Total"
            .Columns("TotalLote").SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        dgvLotes.AutoGenerateColumns = False
        dgvLotes.DataSource = objRemi.tblLotesMedIns.Tables(objRemi.nombreTabla)
        dgvLotes.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Sub nombrarTabla(ByVal Codigo As Integer,
                     ByVal indice As Integer,
                     ByVal tipo As String)
        objRemi.nombreTabla = tipo & Codigo & indice
    End Sub
    Sub validarLote()
        Dim filas As DataGridViewRowCollection = dgvLotes.Rows
        Dim filaActualLote As Integer = dgvLotes.CurrentRow.Index
        Dim columanActualLote As Integer = dgvLotes.CurrentCell.ColumnIndex
        Dim tblActual As DataTable = dgvLotes.DataSource
        Dim filtro As String = "SUM(Cantidad)"
        Dim cantidadVendidas As Integer = If(IsDBNull(tblActual.Compute(filtro, "")), 0, tblActual.Compute(filtro, ""))
        If filaActualLote >= 0 AndAlso dgvLotes.Columns("CantidadLote").Index = columanActualLote Then
            If String.IsNullOrEmpty(filas(filaActualLote).Cells("CantidadLote").Value.ToString) Then
                filas(filaActualLote).Cells("CantidadLote").Value = 0
            End If
            If CInt(TxtCantidadProducto.Text) > 0 Then
                If filas(filaActualLote).Cells("CantidadLote").Value > CInt(TxtCantidadProducto.Text) OrElse
                    cantidadVendidas > CInt(TxtCantidadProducto.Text) Then
                    mostrarMesajeValidacion(filaActualLote)
                End If
            End If
            If filas(filaActualLote).Cells("CantidadLote").Value > filas(filaActualLote).Cells("StockLote").Value Then
                mostrarMesajeValidacion(filaActualLote)
            End If
        End If
    End Sub
    Sub mostrarMesajeValidacion(ByVal filaActualLote As Integer)
        objRemi.tblLotesMedIns.Tables(objRemi.nombreTabla).Rows(filaActualLote).Item("Cantidad") = 0
        MsgBox("La cantidad a despachar no puede ser mayor a la cantidad pedida ni mayor al stock actual", MsgBoxStyle.Exclamation)
    End Sub
    Sub llenarLotes(ByRef dgv As DataGridView,
                    ByVal ColumnaProducto As String,
                    ByVal ColumnaBodega As String,
                    ByVal ColumnaLote As String,
                    ByVal Descripcion As String,
                    ByVal Cantidad As String,
                    ByRef tipo As Integer)

        Dim tablas As DataTableCollection = objRemi.tblLotesMedIns.Tables
        Dim filas As DataRowCollection
        Dim filaActual As Integer = dgv.CurrentRow.Index
        Dim columnaActual As Integer = dgv.CurrentCell.ColumnIndex
        Dim columnaCodigo As String

        If tipo = Constantes.INSUMO Then
            columnaCodigo = "CodigoI"
            filas = objRemi.tblInsumos.Rows
        Else
            columnaCodigo = "Codigo"
            filas = objRemi.tblMedicamentos.Rows
        End If

        If filaActual >= 0 Then
            If dgv.Columns(ColumnaLote).Index = columnaActual AndAlso dgv.Rows(filaActual).Cells(ColumnaBodega).Value.ToString <> "" Then

                'Se pasan los parametros a el panel
                TxtDescripcionProducto.Text = dgv.Rows(filaActual).Cells(Descripcion).Value
                TxtCantidadProducto.Text = dgv.Rows(filaActual).Cells(Cantidad).Value

                'se nombra la tabla del dataset
                nombrarTabla(filas(filaActual).Item(columnaCodigo), filaActual, If(tipo = Constantes.INSUMO, Constantes.INSUMO, Constantes.MEDICAMENTO))

                'se arma la nueva tabla en el dataset
                If objRemi.tblLotesMedIns.Tables.Contains(objRemi.nombreTabla) = False Then
                    objRemi.agredarColumnasDataSet(objRemi.nombreTabla, If(tipo = Constantes.INSUMO, Constantes.INSUMO, Constantes.MEDICAMENTO), filas(filaActual).Item(ColumnaBodega))
                End If

                enlazarColumnasLotes()

                If tablas(objRemi.nombreTabla).Rows.Count = 0 Then
                    Dim params As New List(Of String)
                    params.Add(filas(filaActual).Item(columnaCodigo))
                    params.Add(filas(filaActual).Item(ColumnaBodega))
                    params.Add(cmbContrato.SelectedValue)
                    params.Add(SesionActual.codigoEP)
                    General.llenarTabla(Consultas.REMISION_CARGAR_LOTES_DISPONIBLES, params, tablas(objRemi.nombreTabla))
                End If

                dgvLotes.DataSource = tablas(objRemi.nombreTabla)
                PnlLotes.Visible = True
            End If
        End If
    End Sub
    Sub quitarTabla(ByRef dgv As DataGridView, ByVal columnaBodega As String)
        If dgv.Columns(columnaBodega).Index = dgv.CurrentCell.ColumnIndex Then
            If objRemi.tblLotesMedIns.Tables.Contains(objRemi.nombreTabla) = True Then
                objRemi.tblLotesMedIns.Tables.Remove(objRemi.nombreTabla)
            End If
        End If
    End Sub
    Function validarFormulario() As Boolean

        objRemi.tblProcedimientos.AcceptChanges()
        objRemi.tblInsumos.AcceptChanges()
        objRemi.tblMedicamentos.AcceptChanges()
        If Not validarCliente() Then
            Return False
        ElseIf (objRemi.tblMedicamentos.Select("cantidad = 0 ", "").Count = 1 And objRemi.tblMedicamentos.Rows.Count = 1) AndAlso
               (objRemi.tblInsumos.Select("cantidadI = 0 ", "").Count = 1 And objRemi.tblInsumos.Rows.Count = 1) AndAlso
               (objRemi.tblProcedimientos.Select("CantidadPro = 0 ", "").Count = 1 And objRemi.tblProcedimientos.Rows.Count = 1) Then
            MsgBox("Debe ingresar por lo menos un medicamento, insumo o procedimiento", MsgBoxStyle.Exclamation)
            Return False
        ElseIf objRemi.tblMedicamentos.Select("CantidadDes = 0 ", "").Count > 1 Then
            MsgBox("Debe ingresar las cantidades en los medicamentos", MsgBoxStyle.Exclamation)
            Return False
        ElseIf objRemi.tblInsumos.Select("CantidadDesI = 0 ", "").Count > 1 Then
            MsgBox("Debe ingresar las cantidades en los insumos", MsgBoxStyle.Exclamation)
            Return False
        ElseIf objRemi.tblProcedimientos.Select("CantidadPro = 0 ", "").Count > 1 Then
            MsgBox("Debe ingresar las cantidades de los procedimientos seleccionados", MsgBoxStyle.Exclamation)
            Return False
        ElseIf objRemi.tblProcedimientos.Select("PrecioPro = 0 ", "").Count > 1 Then
            MsgBox("Debe ingresar los costos de los procedimientos seleccionados", MsgBoxStyle.Exclamation)
            Return False
        End If
        Return True
    End Function
    Function validarCliente() As Boolean
        If txtCodigoCliente.Text <> "" AndAlso cmbContrato.SelectedValue > -1 Then
            Return True
        Else
            MsgBox("Debe escoger el cliente o el contrato del cliente!", MsgBoxStyle.Exclamation)
            Return False
        End If
    End Function
    Function guardar() As Boolean
        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + vbYesNo) = vbYes Then
                cmd.guardar(objRemi)
            Else
                Return False
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
            Return False
        End Try
        Return True
    End Function
    Sub carcularTotales()
        Dim tablaMedicamentos, tablaInsumos, tablaProcedimientos As DataTable

        tablaMedicamentos = objRemi.tblMedicamentos
        tablaInsumos = objRemi.tblInsumos
        tablaProcedimientos = objRemi.tblProcedimientos

        tablaMedicamentos.AcceptChanges()
        tablaInsumos.AcceptChanges()
        tablaProcedimientos.AcceptChanges()

        TxtTotalMedicamentos.Text = FormatCurrency(If(IsNothing(tablaMedicamentos.Compute("Sum(Total)", "")) Or (IsDBNull(tablaMedicamentos.Compute("Sum(Total)", ""))), 0, tablaMedicamentos.Compute("Sum(Total)", "")), 2)
        TxtTotalInsumos.Text = FormatCurrency(If(IsNothing(tablaInsumos.Compute("Sum(TotalI)", "")) Or (IsDBNull(tablaInsumos.Compute("Sum(TotalI)", ""))), 0, tablaInsumos.Compute("Sum(TotalI)", "")), 2)
        TxtTotalProcedimiento.Text = FormatCurrency(If(IsNothing(tablaProcedimientos.Compute("Sum(TotalPro)", "")) Or (IsDBNull(tablaProcedimientos.Compute("Sum(TotalPro)", ""))), 0, tablaProcedimientos.Compute("Sum(TotalPro)", "")), 2)
        TxtTotal.Text = FormatCurrency(CDbl(TxtTotalMedicamentos.Text) + CDbl(TxtTotalInsumos.Text) + CDbl(TxtTotalProcedimiento.Text), 2)
    End Sub
    Sub validarFocodgv(ByRef dgv As DataGridView, ByVal columnaLotes As String, ByVal columnaBodega As String, ByVal precio As String)
        dgv.ReadOnly = False
        Dim filaActual As Integer = dgv.CurrentRow.Index
        Dim columnaActual As Integer = dgv.CurrentCell.ColumnIndex

        If filaActual < dgv.Rows.Count - 1 AndAlso
            (dgv.Columns(columnaLotes).Index = columnaActual OrElse
             dgv.Columns(columnaBodega).Index = columnaActual OrElse
             dgv.Columns(precio).Index = columnaActual) AndAlso
           btguardar.Enabled = True Then
            dgv.Rows(filaActual).Cells(columnaActual).ReadOnly = False
        Else
            dgv.Rows(filaActual).Cells(columnaActual).ReadOnly = True
        End If
    End Sub
#End Region
#Region "Eventos de los botones"
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar ) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.codigoEP)


            General.buscarElemento(Consultas.BUSCAR_REMISIONES_INVENTARIO,
                                   params,
                                   AddressOf cargarRemision,
                                   TitulosForm.BUSQUEDA_REMISION_INVENTARIO,
                                   False,
                                   Constantes.TAMANO_MEDIANO,
                                   True)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        objRemi.fechaRemision = DtpFecha.Value
        objRemi.codigoCotizacion = txtCodigoCotizacion.Text
        objRemi.observacionRemision = txtObservaciones.Text
        objRemi.codigoContrato = cmbContrato.SelectedValue
        If validarFormulario() Then
            If guardar() Then
                General.posGuardarForm(Me, ToolStrip1, btbuscar, btnuevo, btanular, btimprimir)
                cargarRemision(objRemi.codigoRemision)
                tab.SelectedIndex = 0
            End If
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
        iniciarValores()
    End Sub
    Private Sub Btbuscar_proveedores_Click(sender As Object, e As EventArgs) Handles Btbuscar_proveedores.Click
        If SesionActual.tienePermiso(pBuscarCliente ) Then
            txtCodigoCotizacion.ResetText()
            Dim params As New List(Of String)
            params.Add(Nothing)
            params.Add(SesionActual.idEmpresa)

            General.buscarElemento(Consultas.LISTA_CLIENTE,
                                   params,
                                   AddressOf cargarCliente,
                                   TitulosForm.BUSQUEDA_CLIENTES_COTIZACION,
                                   False, 0, True)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            bloquearControlesInternos()
            DtpFecha.Value = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
            objRemi.tblMedicamentos.Rows.Add()
            objRemi.tblInsumos.Rows.Add()
            objRemi.tblProcedimientos.Rows.Add()
            objRemi.estado = 0
            txtEstado.Text = General.getEstadoInventario(objRemi.estado)
            Btbuscar_proveedores.Focus()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btnBuscarCotizacion_Click(sender As Object, e As EventArgs) Handles btnBuscarCotizacion.Click
        If SesionActual.tienePermiso(pBuscarCliente ) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.codigoEP)
            General.buscarElemento(Consultas.LISTA_CLIENTE_PUNTO,
                                   params,
                                   AddressOf cargarCotizacion,
                                   TitulosForm.BUSQUEDA_CLIENTES_COTIZACION,
                                   False, 0, True)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub BtSalirlOTES_Click_1(sender As Object, e As EventArgs) Handles BtSalirlOTES.Click
        Dim filas As DataRowCollection
        Dim filaActual As Integer
        Dim columnaCantidad As String = ""
        Dim columnaPrecio As String = ""
        Dim tablas As DataTableCollection = objRemi.tblLotesMedIns.Tables
        Dim nombreTabla As String = objRemi.nombreTabla

        If tipodgv = Constantes.MEDICAMENTO Then
            filas = objRemi.tblMedicamentos.Rows
            filaActual = dgvProductos.CurrentRow.Index
            columnaCantidad = "CantidadDes"
            columnaPrecio = "Precio"
        ElseIf tipodgv = Constantes.INSUMO Then
            filas = objRemi.tblInsumos.Rows
            filaActual = dgvInsumos.CurrentRow.Index
            columnaCantidad = "CantidadDesI"
            columnaPrecio = "PrecioI"
        End If


        filas(filaActual).Item(columnaCantidad) = If(IsDBNull(tablas(nombreTabla).Compute("Sum(Cantidad)", "")), 0, tablas(nombreTabla).Compute("Sum(Cantidad)", ""))
        filas(filaActual).Item(columnaPrecio) = If(IsDBNull(tablas(nombreTabla).Compute("Sum(Precio)", "")), 0, tablas(nombreTabla).Compute("Sum(Precio)", "") / tablas(nombreTabla).Select("Precio> 0", "").Count)

        carcularTotales()
        PnlLotes.Visible = False
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + vbYesNo) = MsgBoxResult.Yes Then
                Try
                    cmd.anular(objRemi)
                    General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                Catch ex As Exception
                    general.manejoErrores(ex)
                End Try
            End If
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
#End Region
#Region "Eventos de las dgv"
    Private Sub dgvProductos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellEnter
        validarFocodgv(dgvProductos, "LotesM", "Codigo_bodega", "Precio")
    End Sub
    Private Sub dgvInsumos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInsumos.CellEnter
        validarFocodgv(dgvInsumos, "LotesI", "Codigo_BodegaI", "PrecioI")
    End Sub
    Private Sub dgvLotes_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLotes.CellEndEdit
        validarLote()
    End Sub
    Private Sub dgvLotes_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLotes.CellEnter
        dgvLotes.ReadOnly = False
        If btguardar.Enabled = True And txtcodigo.Text = "" Then
            If e.ColumnIndex = dgvLotes.Columns("CantidadLote").Index Then
                dgvLotes.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
            Else
                dgvLotes.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            End If
        Else
            dgvLotes.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
        End If
    End Sub
    Private Sub dgvLotes_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLotes.CellContentDoubleClick
        If e.RowIndex >= 0 Then
            If dgvLotes.Columns("AnularLote").Index = e.ColumnIndex Then
                If MsgBox(Mensajes.QUITAR, MsgBoxStyle.Question + vbYesNo) = vbYes Then
                    objRemi.tblLotesMedIns.Tables(objRemi.nombreTabla).Rows(dgvLotes.CurrentRow.Index).Item("Cantidad") = 0
                End If

            End If
        End If
    End Sub
    Private Sub dgvInsumos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvInsumos.DataError
    End Sub
    Private Sub dgvInsumos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInsumos.CellEndEdit
        nombrarTabla(objRemi.tblInsumos.Rows(dgvInsumos.CurrentRow.Index).Item("CodigoI"), dgvInsumos.CurrentRow.Index, Constantes.INSUMO)
        quitarTabla(dgvInsumos, "Codigo_BodegaI")
        carcularTotales()
    End Sub
    Private Sub dgvProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProductos.KeyDown
        If validarTeclaF3(e) Then
            buscarProductos()
        End If
    End Sub
    Public Sub verificarBodegaIndividual(ByRef tbl As DataTable, ByVal Cod As String, ByVal CodBod As String, ByVal Bod As String, ByVal indiceFila As Integer)
        Dim objRecepcionTecnica As New RecepcionBLL
        Dim resultadoBodega As String = ""

        resultadoBodega = objRecepcionTecnica.verificarBodegaIndividual(tbl.Rows(indiceFila).Item(Cod))
        If resultadoBodega.Contains("|") Then
            Dim vectorResultado() As String
            Dim codigoBodega, nombreBodega As String
            vectorResultado = resultadoBodega.Split("|")
            codigoBodega = Trim(vectorResultado(0))
            nombreBodega = Trim(vectorResultado(1))
            tbl.Rows(indiceFila).Item(CodBod) = codigoBodega
            tbl.Rows(indiceFila).Item(Bod) = nombreBodega
        Else
            tbl.Rows(indiceFila).Item(CodBod) = ""
            tbl.Rows(indiceFila).Item(Bod) = resultadoBodega
        End If

    End Sub
    Private Sub dgvInsumos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvInsumos.KeyDown
        If validarTeclaF3(e) Then
            buscarInsumos()
        End If
    End Sub
    Function validarTeclaF3(ByRef e As KeyEventArgs) As Boolean
        Return e.KeyCode = Keys.F3 AndAlso validarCliente()
    End Function

    Private Sub dgvProce_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProce.KeyDown
        If validarTeclaF3(e) Then
            Dim params As New List(Of String)
            params.Add(txtCodigoCliente.Text)
            General.busquedaItems(Consultas.BUSCAR_PROCEDIMIENTOS_REMISION,
                                  params,
                                  TitulosForm.BUSQUEDA_PROCEDIMIENTOS_REMISION,
                                  dgvProce,
                                  objRemi.tblProcedimientos,
                                  0,
                                  2,
                                  0,
                                  True,
                                  True,
                                  0,
                                  False)
        End If
    End Sub
    Private Sub dgvProce_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProce.CellEndEdit
        If Funciones.verificacionPosicionActual(dgvProce, e, "CantidadPro") Then
            nombrarTabla(objRemi.tblProcedimientos.Rows(dgvProce.CurrentRow.Index).Item("CodigoPro"), dgvProce.CurrentRow.Index, Constantes.procedimiento)
            quitarTabla(dgvProce, "CodigoPro")
            carcularTotales()
        End If
    End Sub
    Private Sub dgvProductos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellEndEdit
        nombrarTabla(objRemi.tblMedicamentos.Rows(dgvProductos.CurrentRow.Index).Item("Codigo"), dgvProductos.CurrentRow.Index, Constantes.MEDICAMENTO)
        quitarTabla(dgvProductos, "Codigo_Bodega")
        carcularTotales()
    End Sub
    Private Sub dgvProce_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProce.CellEnter
        dgvProce.ReadOnly = False
        If e.RowIndex < dgvProce.Rows.Count - 1 AndAlso dgvProce.Columns("CantidadPro").Index = dgvProce.CurrentCell.ColumnIndex Then
            dgvProce.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
        Else
            dgvProce.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
        End If
    End Sub
    Private Sub dgvProductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick
        Dim filAct As Integer = dgvProductos.CurrentCell.RowIndex
        Dim colAct As Integer = e.ColumnIndex
        Dim filas = objRemi.tblMedicamentos.Rows
        If Funciones.filaValida(filAct) AndAlso validarCliente() Then
            If Funciones.validarColumnaActual(colAct, filAct, "CodigoProducto", dgvProductos) OrElse Funciones.validarColumnaActual(colAct, filAct, "Descripcion", dgvProductos) Then
                buscarProductos()
            ElseIf btguardar.Enabled = True AndAlso colAct = dgvProductos.Columns(TitulosForm.ANULAR).Index AndAlso
                   txtcodigo.Text = "" AndAlso
                   filAct < filas.Count - 1 Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    filas.RemoveAt(filAct)
                    carcularTotales()
                End If
            End If
        End If
    End Sub
    Sub buscarProductos()
        Dim filAct As Integer = dgvProductos.CurrentCell.RowIndex
        Dim colAct As Integer = dgvProductos.CurrentCell.ColumnIndex
        Dim tabla = objRemi.tblMedicamentos

        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        params.Add(cmbContrato.SelectedValue)

        General.busquedaItems(Consultas.BUSCAR_MEDICAMENTOS_REMISION,
                              params,
                              TitulosForm.BUSQUEDA_MEDICAMENTOS_INSUMOS,
                              dgvProductos,
                              tabla,
                              0,
                              2,
                              0,
                              False,
                              True,
                              0,
                              False)

        For indiceFila = 0 To tabla.Rows.Count - 1
            If Not IsDBNull(tabla.Rows(indiceFila).Item("Codigo")) Then
                verificarBodegaIndividual(tabla, "Codigo", "Codigo_Bodega", "Bodega_Escoger", indiceFila)
            End If
        Next
    End Sub
    Private Sub dgvInsumos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInsumos.CellDoubleClick
        Dim filaActual As Integer = dgvInsumos.CurrentRow.Index
        Dim columnaActual As Integer = dgvInsumos.CurrentCell.ColumnIndex
        Dim tabla = objRemi.tblInsumos

        If Funciones.filaValida(filaActual) And txtCodigoCliente.Text <> "" Then
            If Funciones.validarColumnaActual(columnaActual, filaActual, "CodigoProductoI", dgvInsumos) OrElse
               Funciones.validarColumnaActual(columnaActual, filaActual, "DescripcionI", dgvInsumos) Then
                buscarInsumos()
            ElseIf btguardar.Enabled = True AndAlso columnaActual = dgvInsumos.Columns("anularIn").Index AndAlso
                   txtcodigo.Text = "" AndAlso filaActual < tabla.Rows.Count - 1 Then
                'Quitar los lotes asociados al producto 
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    objRemi.tblInsumos.Rows.RemoveAt(filaActual)
                    carcularTotales()
                End If
            End If
        End If
    End Sub
    Sub buscarInsumos()
        Dim filaActual As Integer = dgvInsumos.CurrentRow.Index
        Dim columnaActual As Integer = dgvInsumos.CurrentCell.ColumnIndex
        Dim tabla = objRemi.tblInsumos
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        params.Add(cmbContrato.SelectedValue)
        General.busquedaItems(Consultas.BUSCAR_INSUMOS_REMISION,
                          params,
                          TitulosForm.BUSQUEDA_MEDICAMENTOS_INSUMOS,
                          dgvInsumos,
                          objRemi.tblInsumos,
                          0,
                          2,
                          0,
                          False,
                          True,
                          0,
                          False)
        For indiceFila = 0 To tabla.Rows.Count - 1
            If Not IsDBNull(tabla.Rows(indiceFila).Item("CodigoI")) Then
                verificarBodegaIndividual(tabla, "CodigoI", "Codigo_BodegaI", "BodegaI_Escoger", indiceFila)
            End If
        Next
    End Sub
    Private Sub dgvProce_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProce.CellDoubleClick
        If Funciones.filaValida(e.RowIndex) And txtCodigoCliente.Text <> "" Then
            If Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "CodigoPro", dgvProce) OrElse
               Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "DescripcionPro", dgvProce) Then
                Dim params As New List(Of String)
                params.Add(txtCodigoCliente.Text)
                params.Add(SesionActual.idEmpresa)
                General.busquedaItems(Consultas.BUSCAR_PROCEDIMIENTOS_REMISION,
                                      params,
                                      TitulosForm.BUSQUEDA_PROCEDIMIENTOS_REMISION,
                                      dgvProce,
                                      objRemi.tblProcedimientos,
                                      0,
                                      2,
                                      0,
                                      True,
                                      True,
                                      0,
                                      False)
            ElseIf btguardar.Enabled = True AndAlso
                   e.ColumnIndex = dgvProce.Columns("anularPro").Index AndAlso
                   txtcodigo.Text = "" AndAlso
                   e.RowIndex < objRemi.tblProcedimientos.Rows.Count - 1 Then
                'Quitar los lotes asociados al producto 
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    objRemi.tblProcedimientos.Rows.RemoveAt(dgvProce.CurrentCell.RowIndex)
                    carcularTotales()
                End If
            End If
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
    Private Sub dgvProductos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvProductos.DataError, dgvInsumos.DataError, dgvProce.DataError, dgvLotes.DataError
        e.Cancel = True
    End Sub
    Private Sub dgvInsumos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvInsumos.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
    End Sub
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        imprimir()
    End Sub
    Sub imprimir()
        If txtcodigo.Text = "" Then
            MsgBox("Debe elegir una remisión para imprimir !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        Else
            Try
                Cursor = Cursors.WaitCursor
                Dim rprte As New rptRemisiones
                Funciones.getReporteNoFTP(rprte, "{VISTA_REMISION_INVENTARIO.Anulado}=False and  {VISTA_REMISION_INVENTARIO.Codigo_Remision} =" & objRemi.codigoRemision & " and {VISTA_EMPRESAS.Id_empresa} = " & SesionActual.idEmpresa, "RemisionInv", Constantes.FORMATO_PDF)
                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
                general.manejoErrores(ex)
            End Try
        End If
    End Sub

    Private Sub dgvLotes_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvLotes.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
    End Sub
    Private Sub dgvProce_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvProce.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
    End Sub
    Private Sub dgvInsumos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInsumos.CellContentClick
        Dim filaActual As Integer = e.RowIndex
        Dim columnaActual As Integer = e.ColumnIndex
        If Funciones.filaValida(filaActual) Then
            If columnaActual = dgvInsumos.Columns("LotesI").Index Then
                tipodgv = Constantes.INSUMO
                llenarLotes(dgvInsumos, "CodigoProductoI", "Codigo_BodegaI", "LotesI", "DescripcionI", "CantidadI", Constantes.INSUMO)
            ElseIf columnaActual = dgvInsumos.Columns("BtnBodegasI").Index AndAlso btguardar.Enabled AndAlso Not IsDBNull(dgvInsumos.Rows(filaActual).Cells("CodigoProductoI").Value) Then
                'Buscar la bodega en la cual se va ingresar el producto
                Dim params As New List(Of String)
                params.Add(SesionActual.codigoEP)
                params.Add(objRemi.tblInsumos.Rows(filaActual).Item("CodigoI"))
                params.Add(Nothing)
                objRemi.IndexTbl = e.RowIndex
                General.buscarElemento(Consultas.LLENAR_BODEGAS_EN_DGV,
                                       params,
                                       AddressOf cargarBodegaI,
                                       TitulosForm.BUSQUEDA_BODEGA,
                                       False)
            End If
        End If

    End Sub
    Private Sub dgvProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellContentClick
        Dim filaActual As Integer = e.RowIndex
        Dim columnaActual As Integer = e.ColumnIndex
        If Funciones.filaValida(filaActual) Then
            If columnaActual = dgvProductos.Columns("LotesM").Index Then
                tipodgv = Constantes.MEDICAMENTO
                llenarLotes(dgvProductos, "CodigoProducto", "Codigo_Bodega", "LotesM", "Descripcion", "Cantidad", Constantes.MEDICAMENTO)
            ElseIf columnaActual = dgvProductos.Columns("BtnBodegas").Index And btguardar.Enabled And Not IsDBNull(dgvProductos.Rows(filaActual).Cells("CodigoProducto").Value) Then
                'Buscar la bodega en la cual se va ingresar el producto
                Dim params As New List(Of String)
                params.Add(SesionActual.codigoEP)
                params.Add(objRemi.tblMedicamentos.Rows(filaActual).Item("Codigo"))
                params.Add(Nothing)
                objRemi.IndexTbl = filaActual
                General.buscarElemento(Consultas.LLENAR_BODEGAS_EN_DGV,
                                       params,
                                       AddressOf cargarBodega,
                                       TitulosForm.BUSQUEDA_BODEGA,
                                       False)
            End If
        End If
    End Sub
    Sub cargarBodega(ByVal pCodigoBodega As Integer)
        Dim dr As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigoBodega)
        dr = General.cargarItem(Consultas.CARGAR_BODEGA, params)
        objRemi.tblMedicamentos.Rows(objRemi.IndexTbl).Item("Codigo_Bodega") = pCodigoBodega
        objRemi.tblMedicamentos.Rows(objRemi.IndexTbl).Item("Bodega_Escoger") = dr.Item(0)
        dgvProductos.Rows(objRemi.IndexTbl).Cells("Bodega_Escoger").Selected = True
    End Sub
    Sub cargarBodegaI(ByVal pCodigoBodega As Integer)
        Dim dr As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigoBodega)
        dr = General.cargarItem(Consultas.CARGAR_BODEGA, params)
        objRemi.tblInsumos.Rows(objRemi.IndexTbl).Item("Codigo_BodegaI") = pCodigoBodega
        objRemi.tblInsumos.Rows(objRemi.IndexTbl).Item("BodegaI_Escoger") = dr.Item(0)
        dgvInsumos.Rows(objRemi.IndexTbl).Cells("BodegaI_Escoger").Selected = True
    End Sub
#End Region
End Class