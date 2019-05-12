Imports System.Reflection

Public Class Form_Conteo
    Dim objConteo As Conteo
    Dim perG As New Buscar_Permisos_generales
    Dim permisoGeneral, pNuevo, pEditar, pAnular, pBuscar, nombreTabla As String
    Private Sub Form_Conteo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarForm()
    End Sub
#Region "FUNCIONES"
    Function validarFormulario() As Boolean
        If cmbComboBodega.SelectedIndex < 1 Then
            MsgBox("Debe seleccionar la bodega que desea realizar conteo ", MsgBoxStyle.Exclamation)
            cmbComboBodega.Focus()
            Return False
        ElseIf objConteo.tblProductos.Select("Conteo=0").Count = objConteo.tblProductos.Rows.Count Then
            MsgBox("No se puede haber conteo en 0", MsgBoxStyle.Exclamation)
            dgvproductos.Focus()
            Return False
        End If
        Return True
    End Function
    Function exonerarProductos() As String
        Dim cadenaCodigo As String = ""
        For indiceProducto = 0 To objConteo.tblProductos.Rows.Count - 1
            If Not String.IsNullOrEmpty(objConteo.tblProductos.Rows(indiceProducto).Item("Codigo")) Then
                If indiceProducto > 0 Then
                    cadenaCodigo = cadenaCodigo & Chr(44)
                End If
                cadenaCodigo = cadenaCodigo & Chr(36) & objConteo.tblProductos.Rows(indiceProducto).Item("Codigo") & Chr(36)
            End If
        Next
        If String.IsNullOrEmpty(cadenaCodigo) Then
            cadenaCodigo = Chr(36) & Chr(36)
        End If
        Return cadenaCodigo
    End Function
#End Region
#Region "METODOS"
    Sub imprimir()
        If txtcodigo.Text = "" Then
            MsgBox("Debe elegir un conteo para imprimir !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        Else
            Cursor = Cursors.WaitCursor
            Dim reporte As New rptConteo
            Try
                Dim tbl As New Hashtable
                tbl.Add("@CodigoConteo", objConteo.codigoConteo)
                Funciones.getReporteNoFTP(reporte, "{VISTA_EMPRESAS.Id_empresa} = " & SesionActual.idEmpresa, "Conteo", Constantes.FORMATO_PDF, tbl)
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
            Cursor = Cursors.Default

        End If
    End Sub
    Sub busquedaInterna()
        Cursor = Cursors.WaitCursor
        If Not String.IsNullOrEmpty(txtBusqueda.Text) Then

            objConteo.enlace.Filter = "[Descripcion] like '%" & txtBusqueda.Text.Trim() & "%' or [Marca] like '%" & txtBusqueda.Text.Trim() & "%'"
        Else
            objConteo.enlace.Filter = ""
        End If

        Cursor = Cursors.Default
    End Sub
    Sub guardar()
        Try
            If validarFormulario() Then
                Dim cmd As New ConteoBLL
                Dim tipoCargado As Boolean = False
                empalmarDisenoToObjeto()

                Dim respuesta As MsgBoxResult
                respuesta = MsgBox(Mensajes.GUARDAR & vbNewLine & "SI --> Guardado Parcial " & vbNewLine & "NO --> Guardardo Total ", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel)
                limpiarFiltro()
                If respuesta = MsgBoxResult.Yes Then
                    cmd.guardarConteoAuxiliar(objConteo, SesionActual.idUsuario)
                    General.posGuardarForm(Me, ToolStrip1, btnAbrir, Nothing, btbuscar, btanular)
                ElseIf respuesta = MsgBoxResult.No Then
                    cmd.guardarConteo(objConteo, SesionActual.idUsuario)
                    General.posGuardarForm(Me, ToolStrip1, btnuevo, Nothing, btbuscar, btanular)
                    tipoCargado = True
                ElseIf respuesta = MsgBoxResult.Cancel Then
                    Exit Sub
                End If

                limpiar()
                If tipoCargado = True Then
                    cargarConteo(objConteo.codigoConteo)
                Else
                    cargarConteoAuxiliar()
                End If
                contarProductos()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Sub limpiarFiltro()
        txtBusqueda.ResetText()
        objConteo.enlace.Filter = Nothing
    End Sub
    Sub limpiar()
        txtBusqueda.ResetText()
        busquedaInterna()
    End Sub
    Sub contarProductos()
        lblCantidadProductos.Text = "No. Productos: " & If(objConteo.tblProductos.Rows.Count = 0, 0, objConteo.tblProductos.Rows.Count)
    End Sub
    Sub calcularCostoTotalConteo()
        LblTotalConteo.Text = "Total: " & FormatCurrency(If(IsDBNull(objConteo.tblProductos.Compute("sum(Total)", "")), 0, objConteo.tblProductos.Compute("sum(Total)", "")), 2)
    End Sub
    Sub cancelar()
        If General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar) Then
            limpiarFiltro()
            objConteo.tblLotes.Reset()
            objConteo.tblProductos.Clear()
            PnlLotes.Visible = False
            contarProductos()
            calcularCostoTotalConteo()
        End If
    End Sub
    Sub salirPanelLotes()
        dgvLotes.EndEdit()
        dgvLotes.CommitEdit(DataGridViewDataErrorContexts.Commit)
        calcularDetalleLotes(dgvproductos.CurrentRow.Index)
        Dim swt As Boolean = True
        For indiceFila = 0 To dgvLotes.RowCount - 1
            If dgvLotes.Rows(indiceFila).Cells("LoteNum").Value.ToString = "" Then
                MsgBox("Debe ingresar el Lote para la fila: " & indiceFila, MsgBoxStyle.Exclamation)
                dgvLotes.Rows(indiceFila).Cells("LoteNum").Selected = True
                swt = False
                Exit For
            ElseIf dgvLotes.Rows(indiceFila).Cells("CostoLote").Value.ToString = "" Then
                MsgBox("Debe ingresar el costo para la fila: " & indiceFila, MsgBoxStyle.Exclamation)
                dgvLotes.Rows(indiceFila).Cells("CostoLote").Selected = True
                swt = False
                Exit For
            End If
        Next
        If swt = True Then
            PnlLotes.Visible = False
        End If
    End Sub
    Sub nuevoLote()
        Dim nombreTabla As String = dgvLotes.DataSource.ToString
        objConteo.tblLotes.Tables(nombreTabla).Rows.Add()
        objConteo.tblLotes.Tables(nombreTabla).Rows(objConteo.tblLotes.Tables(nombreTabla).Rows.Count - 1).Item("Reg_lote") = ""
        objConteo.tblLotes.Tables(nombreTabla).Rows(objConteo.tblLotes.Tables(nombreTabla).Rows.Count - 1).Item("LoteNum") = ""
        objConteo.tblLotes.Tables(nombreTabla).Rows(objConteo.tblLotes.Tables(nombreTabla).Rows.Count - 1).Item("FechaVence") = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        objConteo.tblLotes.Tables(nombreTabla).Rows(objConteo.tblLotes.Tables(nombreTabla).Rows.Count - 1).Item("ConteoLote") = 0
        objConteo.tblLotes.Tables(nombreTabla).Rows(objConteo.tblLotes.Tables(nombreTabla).Rows.Count - 1).Item("Costo") = 0.0
        objConteo.tblLotes.Tables(nombreTabla).Rows(objConteo.tblLotes.Tables(nombreTabla).Rows.Count - 1).Item("StockLote") = 0
        objConteo.tblLotes.Tables(nombreTabla).Rows(objConteo.tblLotes.Tables(nombreTabla).Rows.Count - 1).Item("Excepcion") = False
    End Sub
    Sub guardarLotes()
        Dim nombreTabla As String = dgvLotes.DataSource.ToString
        If objConteo.tblLotes.Tables(nombreTabla).Select("LoteNum = ''", "").Count > 0 Then
            MsgBox("Debe ingresar todos los lotes correctos", MsgBoxStyle.Exclamation)
        Else
            calcularDetalleLotes(dgvproductos.CurrentRow.Index, True)
            PnlLotes.Visible = False
        End If
    End Sub
    Sub inicializarForm()
        objConteo = New Conteo
        permisoGeneral = perG.buscarPermisoGeneral(Name)
        pNuevo = permisoGeneral & "pp" & "01"
        pEditar = permisoGeneral & "pp" & "02"
        pAnular = permisoGeneral & "pp" & "03"
        pBuscar = permisoGeneral & "pp" & "04"
        configurarDgvProducto()
        objConteo.enlace.Filter = ""
        objConteo.enlace.DataSource = objConteo.tblProductos
        cargarComboBodega()
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Sub cargarComboBodega()
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        General.cargarCombo(Consultas.BUSQUEDA_BODEGAS_CONTEO, params, "Nombre", "Codigo_Bodega", cmbComboBodega)
    End Sub
    Sub nuevo()
        If SesionActual.tienePermiso(pNuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            dpFecha.Value = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
            limpiarTablas()
            txtEstado.Enabled = False
            txtEstado.Text = General.getEstadoInventario(Constantes.PENDIENTE)
            contarProductos()
            calcularCostoTotalConteo()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub limpiarTablas()
        objConteo.tblLotes.Reset()
        objConteo.tblProductos.Clear()
    End Sub
    Sub buscar()
        If SesionActual.tienePermiso(pBuscar) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.codigoEP)
            params.Add(Nothing)
            General.buscarElemento(Consultas.BUSQUEDA_CONTEO,
                                   params,
                                   AddressOf cargarConteo,
                                   TitulosForm.BUSQUEDA_CONTEO,
                                   False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub cargarConteoAuxiliar()
        objConteo.tblLotes.Clear()
        Dim params As New List(Of String)
        params.Add(cmbComboBodega.SelectedValue)
        Dim fila As DataRow = General.cargarItem(Consultas.CARGAR_ENCABEZADO_CONTEO_AUXILIAR, params)

        objConteo.codigoConteo = fila.Item("Codigo_conteo")
        objConteo.observacion = fila.Item("Observaciones")
        objConteo.fechaConteo = fila.Item("Fecha")
        objConteo.codigoBodega = fila.Item("Codigo_Bodega")
        params.Clear()
        params.Add(objConteo.codigoConteo)
        General.llenarTabla(Consultas.CARGAR_DETALLE_CONTEO_AUXILIAR, params, objConteo.tblProductos)
        cargarLotesGuardadosTemporales()
        General.posBuscarForm(Me, ToolStrip1, btnAbrir, btbuscar, Nothing, btanular)
        calcularCostoTotalConteo()
        empalmarObjetoToDiseno()
    End Sub
    Sub cargarLotesGuardadosTemporales()
        Dim filas As DataRowCollection = objConteo.tblProductos.Rows
        For indiceProducto = 0 To filas.Count - 1
            Dim nombreTabla As String = objConteo.nombrarTabla(filas(indiceProducto).Item("Codigo"))
            If objConteo.verificarExistenciaTabla(nombreTabla) = False Then
                objConteo.agregarTabla(nombreTabla)
            End If
            objConteo.agregarColumnasDataset(nombreTabla)
            Dim params As New List(Of String)
            params.Add(objConteo.codigoConteo)
            params.Add(filas(indiceProducto).Item("Codigo"))
            General.llenarTabla(Consultas.CARGAR_DETALLE_LOTES_CONTEO_AUXILIAR, params, objConteo.tblLotes.Tables(nombreTabla))
            calcularDetalleLotes(indiceProducto, True)
        Next
    End Sub
    Sub cargarConteo(codigo As Integer)
        objConteo.codigoConteo = codigo
        Dim params As New List(Of String)
        params.Add(objConteo.codigoConteo)
        Dim fila As DataRow = General.cargarItem(Consultas.CARGAR_ENCABEZADO_CONTEO, params)
        objConteo.observacion = fila.Item("Observaciones")
        objConteo.fechaConteo = fila.Item("Fecha_Creacion")
        objConteo.codigoBodega = fila.Item("Codigo_Bodega")
        txtEstado.Text = General.getEstadoInventario(Constantes.TERMINADO)
        cargarDetalleCodiogoConteoTotal()
        empalmarObjetoToDiseno()
        contarProductos()
        calcularCostoTotalConteo()
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, btcancelar, btimprimir)
        txtBusqueda.Enabled = True
        txtBusqueda.ReadOnly = False
    End Sub
    Sub cargarDetalleCodiogoConteoTotal()
        Dim params As New List(Of String)
        params.Add(objConteo.codigoConteo)
        General.llenarTabla(Consultas.CARGAR_DETALLE_CONTEO, params, objConteo.tblProductos)
        objConteo.tblProductos.AcceptChanges()
        cargarLotesConteoTotal()
    End Sub
    Sub cargarLotesConteoTotal()
        objConteo.tblLotes.Reset()
        Dim nombreTabla As String = ""
        For indiceProducto = 0 To objConteo.tblProductos.Rows.Count - 1
            nombreTabla = objConteo.nombrarTabla(objConteo.tblProductos.Rows(indiceProducto).Item("Codigo"))

            If objConteo.verificarExistenciaTabla(nombreTabla) = False Then
                objConteo.agregarTabla(nombreTabla)
                objConteo.agregarColumnasDataset(nombreTabla)
            End If
            Dim params As New List(Of String)
            params.Add(objConteo.codigoConteo)
            params.Add(objConteo.tblProductos.Rows(indiceProducto).Item("Codigo"))
            General.llenarTabla(Consultas.CARGAR_DETALLE_LOTES_CONTEO, params, objConteo.tblLotes.Tables(nombreTabla))
            calcularDetalleLotes(indiceProducto, True)
        Next
        objConteo.tblProductos.AcceptChanges()
    End Sub
    Public Sub asignarValoresNuevaFila(ByVal IndiceFila As Integer)
        objConteo.tblProductos.Rows(IndiceFila).Item("Codigo") = ""
        objConteo.tblProductos.Rows(IndiceFila).Item("Descripcion") = ""
        objConteo.tblProductos.Rows(IndiceFila).Item("Marca") = ""
        objConteo.tblProductos.Rows(IndiceFila).Item("Stock") = 0
        objConteo.tblProductos.Rows(IndiceFila).Item("Conteo") = 0
        objConteo.tblProductos.Rows(IndiceFila).Item("Costo") = 0
        objConteo.tblProductos.Rows(IndiceFila).Item("Ubicacion") = ""
    End Sub
    Public Sub configurarDgvProducto()
        With dgvproductos
            .Columns("Codigo").DataPropertyName = "Codigo"
            .Columns("Descripcion").DataPropertyName = "Descripcion"
            .Columns("Marca").DataPropertyName = "Marca"
            .Columns("Stock").DataPropertyName = "Stock"
            .Columns("Conteo").DataPropertyName = "Conteo"
            .Columns("Costo").DataPropertyName = "Costo"
            .Columns("Total").DataPropertyName = "Total"
            .Columns("Ubicacion").DataPropertyName = "Ubicacion"
            .Columns("Estado").DataPropertyName = "Estado"
            .AutoGenerateColumns = False
            .DataSource = objConteo.enlace
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With
    End Sub
    Public Sub configurarDgvLotes(ByRef nombreTabla As String)
        With dgvLotes
            .Columns("Reg_lote").DataPropertyName = "Reg_lote"
            .Columns("LoteNum").DataPropertyName = "LoteNum"
            .Columns("FechaVence").DataPropertyName = "FechaVence"
            .Columns("StockLote").DataPropertyName = "StockLote"
            .Columns("ConteoLote").DataPropertyName = "ConteoLote"
            .Columns("CostoLote").DataPropertyName = "Costo"
            .Columns("Excepcion").DataPropertyName = "Excepcion"
            .AutoGenerateColumns = False
            .DataSource = objConteo.tblLotes.Tables(nombreTabla)
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With
    End Sub
    Sub llenarTablaProductos()
        Dim params As New List(Of String)
        params.Add(cmbComboBodega.SelectedValue)

        General.llenarTabla(Consultas.CARGAR_COMBO_CONTEO, params, objConteo.tblProductos)
    End Sub
    Sub calcularDetalleLotes(ByVal indiceActualdgv As Integer, Optional cargadoAux As Boolean = False)
        Dim sumaCantidadLotes As String = "Sum(ConteoLote)"
        Dim SumaCostos As String = "Sum(Costo)"
        Dim filtro As String = "ConteoLote> 0"
        Dim filaActualDgvProductos As DataGridViewRow = dgvproductos.Rows(indiceActualdgv)
        Dim nombreTabla As String = objConteo.nombrarTabla(filaActualDgvProductos.Cells("Codigo").Value)

        objConteo.tblLotes.Tables(nombreTabla).AcceptChanges()
        Dim cantidadLotesContados As Integer = objConteo.tblLotes.Tables(nombreTabla).Select(filtro).Count
        Dim tablas As DataTable = objConteo.tblLotes.Tables(nombreTabla)
        'tablas.AcceptChanges() '<-- ojo se debe quitar esto
        Dim resulCantLotes = tablas.Compute(sumaCantidadLotes, filtro)
        Dim cantidadConteo As Integer = If(IsDBNull(resulCantLotes) OrElse IsNothing(resulCantLotes), 0, resulCantLotes)
        Dim resulSumCosto As Object = tablas.Compute(SumaCostos, filtro)
        Dim costoProducto As Double = If(cantidadLotesContados = 0, 0, (If(IsDBNull(resulSumCosto) OrElse IsNothing(resulSumCosto), 0, resulSumCosto) / cantidadLotesContados))

        If objConteo.tblLotes.Tables(nombreTabla).Rows.Count > 0 Then
            filaActualDgvProductos.Cells("Conteo").Value = cantidadConteo
            filaActualDgvProductos.Cells("Costo").Value = costoProducto
            filaActualDgvProductos.Cells("Total").Value = filaActualDgvProductos.Cells("Conteo").Value * filaActualDgvProductos.Cells("Costo").Value
            'objConteo.tblProductos.AcceptChanges()
            'dgvproductos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Else
            filaActualDgvProductos.Cells("Costo").Value = 0
            filaActualDgvProductos.Cells("Conteo").Value = 0
            filaActualDgvProductos.Cells("Total").Value = 0
        End If

        aceptarCambiosFilaActual()
        'Dim fila As Integer = objConteo.tblProductos.Rows.IndexOf(objConteo.tblProductos.Select("Codigo='" & filaActualDgvProductos.Cells("Codigo").Value & "'")(0))
        'objConteo.tblProductos.Rows(fila).AcceptChanges()
        'dgvproductos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        'dgvproductos.EndEdit()

        If cargadoAux = False Then
            tablas.AcceptChanges()
        End If
    End Sub
    Sub aceptarCambiosFilaActual()
        Dim filaActualDgvProductos As DataGridViewRow = dgvproductos.Rows(dgvproductos.CurrentRow.Index)
        Dim fila As Integer = objConteo.tblProductos.Rows.IndexOf(objConteo.tblProductos.Select("Codigo='" & filaActualDgvProductos.Cells("Codigo").Value & "'")(0))
        objConteo.tblProductos.Rows(fila).AcceptChanges()
    End Sub
    Sub empalmarDisenoToObjeto()
        objConteo.codigoConteo = txtcodigo.Text
        objConteo.fechaConteo = dpFecha.Value
        objConteo.codigoBodega = cmbComboBodega.SelectedValue
        objConteo.observacion = txtObservacion.Text
    End Sub
    Sub empalmarObjetoToDiseno()
        txtcodigo.Text = objConteo.codigoConteo
        dpFecha.Value = objConteo.fechaConteo
        cmbComboBodega.SelectedValue = objConteo.codigoBodega
        txtObservacion.Text = objConteo.observacion
    End Sub
    Sub colocarLotesBuscados()
        Dim tblTemp As New DataTable
        Dim params As New List(Of String)
        params.Add(dgvproductos.Rows(dgvproductos.CurrentRow.Index).Cells("Codigo").Value.ToString)
        params.Add(cmbComboBodega.SelectedValue)
        params.Add(dgvLotes.Rows(dgvLotes.CurrentRow.Index).Cells("Lotenum").Value.ToString)
        General.llenarTabla(Consultas.BUSQUEDA_LOTES_EXISTENTES, params, tblTemp)
        Dim nombreTabla As String = dgvLotes.DataSource.ToString
        Dim indiceFila As Integer = 0

        While indiceFila < tblTemp.Rows.Count
            If indiceFila > 0 Then
                objConteo.tblLotes.Tables(nombreTabla).Rows.Add()
            End If
            objConteo.tblLotes.Tables(nombreTabla).Rows(objConteo.tblLotes.Tables(nombreTabla).Rows.Count - 1).Item("Reg_lote") = tblTemp.Rows(indiceFila).Item("Reg_lote")
            objConteo.tblLotes.Tables(nombreTabla).Rows(objConteo.tblLotes.Tables(nombreTabla).Rows.Count - 1).Item("LoteNum") = tblTemp.Rows(indiceFila).Item("Num_lote")
            objConteo.tblLotes.Tables(nombreTabla).Rows(objConteo.tblLotes.Tables(nombreTabla).Rows.Count - 1).Item("FechaVence") = tblTemp.Rows(indiceFila).Item("Fecha_Vence")
            objConteo.tblLotes.Tables(nombreTabla).Rows(objConteo.tblLotes.Tables(nombreTabla).Rows.Count - 1).Item("StockLote") = tblTemp.Rows(indiceFila).Item("Stock")
            objConteo.tblLotes.Tables(nombreTabla).Rows(objConteo.tblLotes.Tables(nombreTabla).Rows.Count - 1).Item("Costo") = tblTemp(indiceFila).Item("Costo")
            objConteo.tblLotes.Tables(nombreTabla).Rows(objConteo.tblLotes.Tables(nombreTabla).Rows.Count - 1).Item("Excepcion") = tblTemp.Rows(indiceFila).Item("Exepcion")
            indiceFila += 1
        End While

    End Sub
    Sub abrirConte()
        Cursor = Cursors.WaitCursor
        dgvproductos.Enabled = True
        txtBusqueda.Enabled = True
        txtBusqueda.ReadOnly = False
        cargarProductosFaltantes()
        General.deshabilitarBotones(ToolStrip1)
        btguardar.Enabled = True
        btcancelar.Enabled = True
        Cursor = Cursors.Default
    End Sub
    Sub cargarProductosFaltantes()
        Dim params As New List(Of String)
        Dim tblTemp As New DataTable
        params.Add(cmbComboBodega.SelectedValue)
        General.llenarTabla(Consultas.CARGAR_COMBO_CONTEO, params, tblTemp)
        objConteo.tblProductos.Merge(tblTemp)
        'For Each fila As DataRow In tblTemp.Rows
        '    objConteo.tblProductos.ImportRow(fila)
        'Next
        contarProductos()
    End Sub
#End Region
#Region "EVENTOS DE LA dgv DE LOTES"
    Private Sub dgvLotes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLotes.CellClick
        If Funciones.filaValida(e.RowIndex) Then
            If txtEstado.Text = General.getEstadoInventario(Constantes.TERMINADO) Then
                dgvLotes.Enabled = True
                dgvLotes.ReadOnly = True
            Else
                With dgvLotes
                    dgvLotes.Enabled = True
                    dgvLotes.ReadOnly = False
                    If dgvLotes.Rows(e.RowIndex).Cells("Reg_lote").Value.ToString <> "" Then
                        .Columns("LoteNum").ReadOnly = True
                        .Columns("costoLote").ReadOnly = False
                        .Columns("FechaVence").ReadOnly = True
                    Else
                        .Columns("LoteNum").ReadOnly = False
                        .Columns("costoLote").ReadOnly = False
                        .Columns("FechaVence").ReadOnly = False
                    End If
                    .Columns("Reg_lote").ReadOnly = True
                    .Columns("Excepcion").ReadOnly = True
                    .Columns("ConteoLote").ReadOnly = False
                    .Columns("StockLote").ReadOnly = True
                End With
            End If
        End If
    End Sub
    Private Sub dgvLotes_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvLotes.EditingControlShowing
        If dgvLotes.Columns("ConteoLote").Index = dgvLotes.CurrentCell.ColumnIndex Then
            AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivo
        Else
            RemoveHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivo
            AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.devolverKeyPress

        End If
    End Sub
    Private Sub dgvLotes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLotes.CellDoubleClick
        If Funciones.filaValida(e.RowIndex) Then
            If dgvLotes.Columns("QuitarLote").Index = dgvLotes.CurrentCell.ColumnIndex And btguardar.Enabled = True Then
                If MsgBox("¿ Desea quitar lotes ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim nombreTabla As String = dgvLotes.DataSource.ToString
                    If objConteo.tblLotes.Tables(nombreTabla).Rows(dgvLotes.CurrentRow.Index).Item("StockLote") = 0 Then
                        objConteo.tblLotes.Tables(nombreTabla).Rows.RemoveAt(dgvLotes.CurrentRow.Index)
                    Else
                        objConteo.tblLotes.Tables(nombreTabla).Rows(dgvLotes.CurrentRow.Index).Item("ConteoLote") = 0
                        calcularDetalleLotes(dgvproductos.CurrentRow.Index)
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub dgvLotes_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLotes.CellEndEdit
        Dim filaActualDGV As DataGridViewRow = dgvLotes.Rows(e.RowIndex)
        Dim nombreTabla As String = dgvLotes.DataSource.ToString

        If dgvLotes.Columns("FechaVence").Index = e.ColumnIndex Then
            Dim dias As Integer = DateDiff(DateInterval.Month, filaActualDGV.Cells("FechaVence").Value, CDate(Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)).Date)
            If dias >= -3 Then
                If MsgBox("¿ Desea colocar este lote como exepcion ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    filaActualDGV.Cells("Excepcion").Value = True
                Else
                    filaActualDGV.Cells("Excepcion").Value = False
                    filaActualDGV.Cells("FechaVence").Value = DateAdd(DateInterval.Month, 3, CDate(Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)).Date)
                End If
            Else
                filaActualDGV.Cells("Excepcion").Value = False
            End If
        ElseIf dgvLotes.Columns("LoteNum").Index = e.ColumnIndex Then
            Dim cantidad As Integer = objConteo.tblLotes.Tables(nombreTabla).Select("LoteNum = '" & filaActualDGV.Cells("LoteNum").Value & "'", "").Count
            If cantidad <= 1 AndAlso cantidad >= 0 Then
                colocarLotesBuscados()
            Else
                MsgBox("No puede colocar el mismo lote más de una vez !", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                filaActualDGV.Cells("LoteNum").Value = ""
            End If
        ElseIf dgvLotes.Columns("ConteoLote").Index = e.ColumnIndex Then
            dgvproductos.Rows(dgvproductos.CurrentRow.Index).Cells("Estado").Value = Constantes.CONTADO
            calcularDetalleLotes(dgvproductos.CurrentRow.Index, True)
        End If

    End Sub

#End Region
#Region "EVENTOS DE LA dgv DE PRODUCTOS"
    Private Sub dgvproductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellContentClick
        If Funciones.verificacionPosicionActual(dgvproductos, e, "Lote") AndAlso btnAbrir.Enabled = True Then
            MsgBox("Debe abrir el conteo !", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If Funciones.verificacionPosicionActual(dgvproductos, e, "Lote") AndAlso dgvproductos(dgvproductos.Columns("Codigo").Index, e.RowIndex).Value <> "" Then
            TxtDescripcionProducto.Text = dgvproductos.Rows(e.RowIndex).Cells("Descripcion").Value
            txtNombreMarca.Text = dgvproductos.Rows(e.RowIndex).Cells("Marca").Value
            TxtDescripcionProducto.ReadOnly = True
            txtNombreMarca.ReadOnly = True

            Dim nombretabla As String = objConteo.nombrarTabla(dgvproductos.Rows(e.RowIndex).Cells("Codigo").Value.ToString)
            If objConteo.verificarExistenciaTabla(nombretabla) = False Then
                objConteo.agregarTabla(nombretabla)
                objConteo.agregarColumnasDataset(nombretabla)

                Dim params As New List(Of String)
                params.Add(dgvproductos(dgvproductos.Columns("Codigo").Index, e.RowIndex).Value)
                params.Add(cmbComboBodega.SelectedValue)
                General.llenarTabla(Consultas.CARGAR_LOTES_EXISTES_CONTEO, params, objConteo.tblLotes.Tables(nombretabla))


            End If
            configurarDgvLotes(nombretabla)
            dgvLotes.DataSource = objConteo.tblLotes.Tables(nombretabla)
            General.deshabilitarBotones(ToolStrip2)
            BtSalirlOTES.Enabled = True
            If txtEstado.Text = General.getEstadoInventario(Constantes.PENDIENTE) Then
                General.habilitarBotones(ToolStrip2)
            End If
            PnlLotes.Visible = True
        End If
    End Sub
    Private Sub dgvproductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellDoubleClick
        If Funciones.filaValida(e.RowIndex) Then
            If dgvproductos.CurrentCell.ColumnIndex = dgvproductos.Columns("Anular").Index And
               dgvproductos(dgvproductos.Columns("Codigo").Index, e.RowIndex).Value <> "" And txtEstado.Text = General.getEstadoInventario(Constantes.PENDIENTE) Then
                If MsgBox("¿ Desea quitar Producto ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim nombreTabla As String = objConteo.nombrarTabla(dgvproductos(dgvproductos.Columns("Codigo").Index, e.RowIndex).Value, e.RowIndex)
                    If objConteo.verificarExistenciaTabla(nombreTabla) Then
                        objConteo.quitarTabla(nombreTabla)
                    End If
                    dgvproductos.Rows.RemoveAt(e.RowIndex)
                    contarProductos()
                End If
            End If
        End If
    End Sub
    Private Sub dgvproductos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvproductos.KeyDown
        If btguardar.Enabled = True Then
            If cmbComboBodega.SelectedIndex > 0 Then
                If e.KeyCode = Keys.F3 AndAlso dgvproductos(dgvproductos.Columns("Codigo").Index, dgvproductos.CurrentRow.Index).Value = "" Then
                    Dim fila As DataRow
                    Dim params As New List(Of String)
                    params.Add(cmbComboBodega.SelectedValue)
                    Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.CARGAR_COMBO_CONTEO, params, TitulosForm.BUSQUEDA_PRODUCTOS_INDIVIDUAL_CONTEO, True)
                    fila = formBusqueda.rowResultados
                    If fila IsNot Nothing Then
                        objConteo.tblProductos.Rows(objConteo.tblProductos.Rows.Count - 1).Item("Codigo") = fila(0)
                        objConteo.tblProductos.Rows(objConteo.tblProductos.Rows.Count - 1).Item("Descripcion") = fila(1)
                        objConteo.tblProductos.Rows(objConteo.tblProductos.Rows.Count - 1).Item("Marca") = fila(2)
                        objConteo.tblProductos.Rows(objConteo.tblProductos.Rows.Count - 1).Item("Stock") = fila(3)
                        objConteo.tblProductos.Rows(objConteo.tblProductos.Rows.Count - 1).Item("Conteo") = fila(4)
                        objConteo.tblProductos.Rows(objConteo.tblProductos.Rows.Count - 1).Item("Costo") = fila(5)
                        objConteo.tblProductos.Rows(objConteo.tblProductos.Rows.Count - 1).Item("Ubicacion") = fila(6)
                        objConteo.tblProductos.Rows.Add()
                        asignarValoresNuevaFila(objConteo.tblProductos.Rows.Count - 1)
                    End If
                End If
            Else
                MsgBox("Debe escoger la bodega Primero ", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub
    Private Sub dgvproductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellClick
        dgvproductos.Enabled = True
        dgvproductos.ReadOnly = True
    End Sub
    'Private Sub dgvproductos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvproductos.CellFormatting
    '    If e.ColumnIndex = dgvproductos.Columns("Conteo").Index AndAlso e.Value = -1 Then
    '        e.Value = Format(Constantes.SIN_CONTAR, "")
    '    End If
    'End Sub
    Private Sub dgvLotes_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvLotes.DataError, dgvproductos.DataError
        e.Cancel = False
    End Sub
#End Region
#Region "EVENTOS DE LOS BOTONES"
    Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click
        abrirConte()
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        nuevo()
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        buscar()
    End Sub
    Private Sub BtSalirlOTES_Click(sender As Object, e As EventArgs) Handles BtSalirlOTES.Click
        salirPanelLotes()
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        cancelar()
    End Sub
    Private Sub BtNuevoLotes_Click(sender As Object, e As EventArgs) Handles BtNuevoLotes.Click
        nuevoLote()
    End Sub
    Private Sub BtGuardarLotes_Click(sender As Object, e As EventArgs) Handles BtGuardarLotes.Click
        guardarLotes()
        calcularCostoTotalConteo()
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        guardar()
    End Sub
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        imprimir()
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(pAnular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + vbYesNo) = MsgBoxResult.Yes Then
                Try
                    Dim objConteoBLL As New ConteoBLL
                    objConteoBLL.anularConteoAuxiliar(objConteo)
                    General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
#End Region
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
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
    Private Sub PnlLotes_VisibleChanged(sender As Object, e As EventArgs) Handles PnlLotes.VisibleChanged
        dgvproductos.Enabled = Not PnlLotes.Visible
    End Sub
    Private Sub cmbComboBodega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbComboBodega.SelectedIndexChanged
        If cmbComboBodega.SelectedIndex > 0 And txtEstado.Text = General.getEstadoInventario(Constantes.PENDIENTE) Then
            If objConteo.tblProductos.Rows.Count > 0 Then
                If MsgBox("Hay un conteo en curso ¿ Desea cancelarlo ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            If General.getEstadoVF(Consultas.VERIFICAR_EXITENCIA_CONTEO_AUXILIAR & " " & cmbComboBodega.SelectedValue) = True Then
                If MsgBox("Hay un conteo pendiente para esta bodega, ¿ Desea continuar ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    cargarConteoAuxiliar()
                    Cursor = Cursors.Default
                End If
            Else
                Cursor = Cursors.WaitCursor
                objConteo.tblProductos.Clear()
                llenarTablaProductos()
                Cursor = Cursors.Default
            End If
            contarProductos()
            dgvproductos.Focus()
        End If
    End Sub
    Private Sub txtBusqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusqueda.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBusqueda.Text = Funciones.validarComillaSimple(txtBusqueda.Text)
            busquedaInterna()
        End If
    End Sub


End Class