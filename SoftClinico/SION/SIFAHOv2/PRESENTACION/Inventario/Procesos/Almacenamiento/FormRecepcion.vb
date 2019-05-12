Imports System.Data.SqlClient
Imports System.Threading
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class FormRecepcion
    Dim objRecepcion As RecepcionTecnica
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, pbuscar_proveedor As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormRecepcion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarForm()
    End Sub
#Region "Metodos"
    Sub DeshabiliarTexboxValores()
        txtiva.ReadOnly = True
        txtdescuento.ReadOnly = True
        txtbruto.ReadOnly = True
        txttotal.ReadOnly = True
    End Sub
    Sub totalizar()
        Dim bruto, iva, descuento As Double
        For indiceFila = 0 To objRecepcion.tblProductos.Rows.Count - 1
            If objRecepcion.tblProductos.Rows(indiceFila).Item("Iva") > 0 Then
                iva = iva + (objRecepcion.tblProductos.Rows(indiceFila).Item("Total") * (objRecepcion.tblProductos.Rows(indiceFila).Item("Iva") / 100))
            End If
            If objRecepcion.tblProductos.Rows(indiceFila).Item("Iva") > 0 Then
                descuento = descuento + (objRecepcion.tblProductos.Rows(indiceFila).Item("Total") * (objRecepcion.tblProductos.Rows(indiceFila).Item("Descuento") / 100))
            End If
            bruto = bruto + objRecepcion.tblProductos.Rows(indiceFila).Item("Total")
        Next
        txtiva.Text = FormatCurrency(iva, 2)
        txtdescuento.Text = FormatCurrency(descuento, 2)
        txtbruto.Text = FormatCurrency(bruto, 2)
        txttotal.Text = FormatCurrency((iva + bruto) - descuento, 2)
    End Sub
    Private Sub cargarEncabezado(ByVal pcodigo As Integer)
        objRecepcion.codigoRecepcion = pcodigo
        Dim params As New List(Of String)
        params.Add(objRecepcion.codigoRecepcion)
        Dim fila As DataRow = General.cargarItem(Consultas.RECEPCION_CARGAR_ENCABEZADO, params)
        objRecepcion.codigoRecepcionPunto = fila.Item("Codigo_Recepcion_Punto")
        objRecepcion.codigoTransportadora = fila.Item("Codigo_Transportadora")
        objRecepcion.fechaRecepcion = fila.Item("Fecha_Recepcion")
        objRecepcion.noFactura = fila.Item("N_Factura")
        objRecepcion.guia = fila.Item("N_Guia")

        objRecepcion.codigoOrden = fila.Item("Codigo_orden")
        txtidproveedor.Text = fila.Item("Id_proveedor")
        txtproveedor.Text = fila.Item("Proveedor")
        txtFechaOrden.Text = fila.Item("Fecha_Orden")
        txtFechaLimite.Value = fila.Item("Fecha_Entrega")

        params.Clear()
        params.Add(objRecepcion.codigoOrden)
        Dim filaOrden As DataRow = General.cargarItem("[PROC_RECEPCION_CARGAR_ORDEN_COMPRA_CODIGO_PUNTO]", params)
        objRecepcion.codigoOrdenPunto = filaOrden.Item(0)

        params.Clear()
        params.Add(objRecepcion.codigoRecepcion)
        General.llenarTabla(Consultas.RECEPCION_CARGAR_DETALLE, params, objRecepcion.tblProductos)
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, btanular, btimprimir)
        totalizar()
        empalmarObjetoToDiseno()

    End Sub
    Sub inicializarForm()
        objRecepcion = New RecepcionTecnica
        configurarPermisos()
        configurarDgvProductos()
        cargartransportadora()
        totalizar()
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Sub configurarPermisos()
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
    End Sub
    Sub configurarDgvProductos()
        With dgvproductos
            .Columns("Codigo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigo").DataPropertyName = "Codigo"
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").DataPropertyName = "Descripcion"
            .Columns("Marca").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Marca").DataPropertyName = "Marca"
            .Columns("Marca").Frozen = True
            .Columns("Iva").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Iva").DataPropertyName = "Iva"
            .Columns("Iva").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Descuento").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descuento").DataPropertyName = "Descuento"
            .Columns("Descuento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("CantidadCompra").DataPropertyName = "Cantidad"
            .Columns("CantidadCompra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("CantidadCompra").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cantida_Recibida").DataPropertyName = "Cantida_Recibida"
            .Columns("Cantida_Recibida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Cantida_Recibida").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cantidad_Faltante").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cantidad_Faltante").DataPropertyName = "Cantidad_Faltante"
            .Columns("Cantidad_Faltante").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Costo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Costo").DataPropertyName = "Costo"
            .Columns("Total").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Total").DataPropertyName = "Total"
            .Columns("Bodega_Escoger").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Bodega_Escoger").DataPropertyName = "Bodega_Escoger"
            .Columns(TitulosForm.ANULAR).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Lotes").SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoGenerateColumns = False
            .DataSource = objRecepcion.tblProductos
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With
    End Sub
    Sub configurarDgvLotes()
        With dgvLotes
            .Columns("Reg_lote").ReadOnly = False
            .Columns("Reg_lote").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Reg_lote").DataPropertyName = "Reg_lote"
            .Columns("Reg_lote").Visible = False
            .Columns("Num_lote").ReadOnly = False
            .Columns("Num_lote").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Num_lote").DataPropertyName = "Num_lote"
            .Columns("Fecha").ReadOnly = False
            .Columns("Fecha").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Fecha").DataPropertyName = "Fecha"
            .Columns("Cantidad").ReadOnly = False
            .Columns("Cantidad").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cantidad").DataPropertyName = "Cantidad"
            .Columns("Excepcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Excepcion").DataPropertyName = "Excepcion"
            .AutoGenerateColumns = False
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With
    End Sub
    Sub cargartransportadora()
        General.cargarCombo(Consultas.BUSCAR_TRANSPORTADORA, "Descripcion", "Codigo_transportadora", cmbTrasportadora)
    End Sub
    Sub deshabiliarCamposOrden()
        txtCodigoOrden.ReadOnly = True
        txtidproveedor.ReadOnly = True
        txtproveedor.ReadOnly = True
        txtFechaOrden.Enabled = False
        txtFechaLimite.Enabled = False
    End Sub
    Sub nuevo()
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            objRecepcion.tblLotes.Tables.Clear()
            deshabiliarCamposOrden()
            DeshabiliarTexboxValores()
            MtxtFechaRecepcion.Value = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
            totalizar()
            txtcodigo.Focus()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub Valid(ByVal sender As System.Object, ByVal e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Or (Asc(e.KeyChar) = 8) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub inValid(ByVal sender As System.Object, ByVal e As KeyPressEventArgs)
        e.Handled = False
    End Sub
    Sub anularBtn()
        Try
            If SesionActual.tienePermiso(Panular ) Then
                Dim objRecepcionBll As New RecepcionBLL
                If objRecepcionBll.verificacionAnularRecepcion(objRecepcion, SesionActual.idUsuario) AndAlso MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    objRecepcionBll.anularRecepcion(objRecepcion, SesionActual.idUsuario)
                    General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                Else
                    MsgBox(Mensajes.NO_ANULAR_RECEPCION_TECNICA, MsgBoxStyle.Exclamation)
                End If
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub
    Sub buscarOrden()
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        params.Add(Nothing)
        General.buscarElemento(Consultas.RECEPCION_CARGAR_ORDEN_COMPRA,
                              params,
                              AddressOf cargarDatosOrden,
                              TitulosForm.BUSQUEDA_COMPRA,
                              True,
                              Constantes.TAMANO_MEDIANO,
                              True)
    End Sub
    Private Sub cargarDatosOrden(pCodigo)
        'se agregan parametros para cargar la orden de compra
        Dim params As New List(Of String)
        params.Add(pCodigo)

        Dim fila As DataRow = General.cargarItem("[PROC_RECEPCION_CARGAR_ORDEN_COMPRA_CODIGO_PUNTO]", params)
        objRecepcion.codigoOrdenPunto = fila.Item(0)

        txtCodigoOrden.Text = objRecepcion.codigoOrdenPunto
        objRecepcion.codigoOrden = pCodigo
        'se carga el encabezado de la orde de compra 
        fila = Nothing
        fila = General.cargarItem(Consultas.RECEPCION_CARGAR_ORDEN, params)
        'txtCodigoOrden.Text = fila.Item("Codigo_orden")
        txtidproveedor.Text = fila.Item("Id_proveedor")
        txtproveedor.Text = fila.Item("Proveedor")
        txtFechaOrden.Value = fila.Item("Fecha_Orden")
        txtFechaLimite.Value = fila.Item("Fecha_Entrega")
        'se agregan parametros para cargar el detalle de la orden de compra 
        params.Clear()
        params.Add(objRecepcion.codigoOrden)
        General.llenarTabla(Consultas.RECEPCION_CARGAR_ORDEN_COMPRA_DETALLE, params, objRecepcion.tblProductos)
        contarOrden(objRecepcion.tblProductos) ' se cuenta el numero de filas en el detalle de la orden de compra
        PnlLotes.Visible = False
        For indiceFila = 0 To objRecepcion.tblProductos.Rows.Count - 1
            verificarBodegaIndividual(indiceFila) 'se verifica la existencia en bodega de cada uno de los productos comprados
        Next
        totalizar()
    End Sub
    Sub contarOrden(ByRef tbl As DataTable)
        Dim objRecpcionBll As New RecepcionBLL
        nproducto.Text = objRecpcionBll.ContadorProdcutos(tbl)
    End Sub
    Sub empalmarDesenoToObjeto()
        objRecepcion.codigoRecepcionPunto = txtcodigo.Text
        objRecepcion.codigoOrdenPunto = txtCodigoOrden.Text
        objRecepcion.codigoTransportadora = cmbTrasportadora.SelectedValue
        objRecepcion.noFactura = txtfactura.Text
        objRecepcion.guia = txtguia.Text
        objRecepcion.fechaRecepcion = MtxtFechaRecepcion.Value
    End Sub
    Sub empalmarObjetoToDiseno()
        txtcodigo.Text = objRecepcion.codigoRecepcionPunto
        txtCodigoOrden.Text = objRecepcion.codigoOrdenPunto
        cmbTrasportadora.SelectedValue = objRecepcion.codigoTransportadora
        txtfactura.Text = objRecepcion.noFactura
        txtguia.Text = objRecepcion.guia
        MtxtFechaRecepcion.Value = objRecepcion.fechaRecepcion
    End Sub
    Public Sub verificarBodegaIndividual(ByVal indiceFila As Integer)
        Dim objRecepcionTecnica As New RecepcionBLL
        Dim resultadoBodega As String = ""

        resultadoBodega = objRecepcionTecnica.verificarBodegaIndividual(objRecepcion.tblProductos.Rows(indiceFila).Item("Codigo"))
        If resultadoBodega.Contains("|") Then
            Dim vectorResultado() As String
            Dim codigoBodega, nombreBodega As String
            vectorResultado = resultadoBodega.Split("|")
            codigoBodega = Trim(vectorResultado(0))
            nombreBodega = Trim(vectorResultado(1))
            objRecepcion.tblProductos.Rows(indiceFila).Item("Codigo_Bodega") = codigoBodega
            objRecepcion.tblProductos.Rows(indiceFila).Item("Bodega_Escoger") = nombreBodega
        Else
            objRecepcion.tblProductos.Rows(indiceFila).Item("Codigo_Bodega") = ""
            objRecepcion.tblProductos.Rows(indiceFila).Item("Bodega_Escoger") = resultadoBodega
        End If

    End Sub
    Function sumatoriaLotes(ByVal nombreTabla As String, ByRef tbl As DataTableCollection) As Integer
        Return If(IsDBNull(tbl(nombreTabla).Compute("SUM(Cantidad)", "")), 0, tbl(nombreTabla).Compute("SUM(Cantidad)", ""))
    End Function
    Public Function verificarSumatoriasLotes()
        Dim nombreTabla As String = ""
        Dim tblLotes As DataTableCollection = Nothing
        Dim respuesta As Boolean = True
        nombrarTabla(nombreTabla, tblLotes)
        dgvLotes.EndEdit()
        If objRecepcion.verificarExistenciaTabla(nombreTabla) Then
            tblLotes(nombreTabla).AcceptChanges()
            Dim cantidadesLotes As Integer = sumatoriaLotes(nombreTabla, tblLotes)
            If cantidadesLotes > CInt(TxtCantidadProducto.Text) Then
                tblLotes(nombreTabla).Rows(dgvLotes.CurrentRow.Index).Item("Cantidad") = 0
                dgvLotes.CommitEdit(DataGridViewDataErrorContexts.Commit)
                objRecepcion.tblProductos.Rows(dgvproductos.CurrentRow.Index).Item("Cantida_Recibida") = sumatoriaLotes(nombreTabla, tblLotes)
                MsgBox("La sumatoria de las cantidades de los lotes no puede ser mayor a la cantidad pedida del producto !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                respuesta = False
            Else
                objRecepcion.tblProductos.Rows(dgvproductos.CurrentRow.Index).Item("Cantida_Recibida") = cantidadesLotes
            End If
        End If
        Return respuesta
    End Function
    Function verificarCantidadesEnCero() As Boolean
        Dim nombreTabla As String = ""
        Dim tblLotes As DataTableCollection = Nothing
        nombrarTabla(nombreTabla, tblLotes)

        Dim objRecepcionTecnicaBll As New RecepcionBLL
        Dim listaResultado As New List(Of Integer)
        listaResultado = objRecepcionTecnicaBll.verificarCantidadesEnCero(nombreTabla, tblLotes)
        If listaResultado(0) = 1 Then
            dgvLotes.Rows(listaResultado(1)).Cells("Cantidad").Selected = True
            MsgBox(" Debe colocar la cantidad del lote : " & tblLotes(nombreTabla).Rows(listaResultado(1)).Item("Num_lote") & " !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Return False
        End If
        Return True
    End Function
    Sub nombrarTabla(ByRef nombreTabla As String, ByRef tbls As DataTableCollection)
        nombreTabla = objRecepcion.nombrarTabla(objRecepcion.tblProductos.Rows(dgvproductos.CurrentRow.Index).Item("Codigo"), dgvproductos.CurrentRow.Index)
        establecerNomenclaturaLotes(tbls)
    End Sub
    Sub establecerNomenclaturaLotes(ByRef tbls As DataTableCollection)
        tbls = objRecepcion.tblLotes.Tables
    End Sub
    Sub cancelar()
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
        DeshabiliarTexboxValores()
        totalizar()
    End Sub
    Sub nuevoLote()
        Dim tblLotes As DataTableCollection = Nothing
        Dim nombreTabla As String = ""
        nombrarTabla(nombreTabla, tblLotes)
        tblLotes(nombreTabla).Rows.Add()
        tblLotes(nombreTabla).Rows(tblLotes(nombreTabla).Rows.Count - 1).Item("Fecha") = DateAdd(DateInterval.Month, 3, CDate(Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)).Date)
    End Sub
    Sub ocultarPanel()
        If txtcodigo.Text = "" Then
            If verificarSumatoriasLotes() AndAlso verificarCantidadesEnCero() Then
                PnlLotes.Visible = False
            End If
        Else
            PnlLotes.Visible = False
        End If
    End Sub
    Private Sub guardarRecepcion()
        PnlLotes.Visible = False
        dgvLotes.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Try
            If validarFormulario() AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                empalmarDesenoToObjeto()
                Dim objRecpecionTecnicaBll As New RecepcionBLL
                objRecpecionTecnicaBll.guardar(objRecepcion, SesionActual.codigoEP, SesionActual.idUsuario)
                General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, btimprimir, btanular)
                cargarEncabezado(objRecepcion.codigoRecepcion)
                contarOrden(objRecepcion.tblProductos)
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub
    Private Function validarFormulario() As Boolean
        If txtCodigoOrden.Text = "" Then
            MsgBox("Debe elegir la orden antes de guardar !!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            btnOrden.Focus()
            Return False
        ElseIf cmbTrasportadora.SelectedIndex < 1 Then
            MsgBox("Debe elegir la transportadora antes de guardar !!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            cmbTrasportadora.Focus()
            Return False
        ElseIf txtfactura.Text = "" Then
            MsgBox("Debe ingresar el número de factura antes de guardar !!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            txtfactura.Focus()
            Return False
        ElseIf txtguia.Text = "" Then
            MsgBox("Debe ingresar el número de guia antes de guardar !!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            txtguia.Focus()
            Return False
        ElseIf objRecepcion.tblProductos.Select("Cantida_Recibida = 0", "").Count = dgvproductos.RowCount Then
            MsgBox("Debe ingresar las cantidades recibidas correctas antes de guardar !!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            dgvproductos.Focus()
            Return False
        End If
        Return True
    End Function
    Sub buscarRecepcion()
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add("")
            params.Add(SesionActual.codigoEP)
            General.buscarElemento(Consultas.RECEPCION_BUSCAR,
                                   params,
                                   AddressOf cargarEncabezado,
                                   TitulosForm.BUSQUEDA_RECEPCION,
                                   True,
                                   Constantes.TAMANO_MEDIANO,
                                   True)

        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub imprimir()
        If txtcodigo.Text = "" Then
            MsgBox("Debe elegir una recepción para imprimir !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        Else
            Cursor = Cursors.WaitCursor
            Dim reporte As New RPT_RECEPCION_TECNICA
            Try
                Funciones.getReporteNoFTP(reporte, "{I_RECEPCION_TECNICA.Codigo_Recepcion} =" & objRecepcion.codigoRecepcion, "", Constantes.FORMATO_PDF)
            Catch ex As Exception
                general.manejoErrores(ex)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
#End Region
#Region "Botones"
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        nuevo()
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        anularBtn()
    End Sub
    Private Sub btnOrden_Click(sender As Object, e As EventArgs) Handles btnOrden.Click
        buscarOrden()
    End Sub
    Private Sub BtSalir_Click(sender As Object, e As EventArgs) Handles BtSalirlOTES.Click
        ocultarPanel()
        totalizar()
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        cancelar()
    End Sub
    Private Sub BtNuevoLotes_Click(sender As Object, e As EventArgs) Handles BtNuevoLotes.Click
        nuevoLote()
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        guardarRecepcion()
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        buscarRecepcion()
    End Sub
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        imprimir()
    End Sub
    Private Sub BtGuardarLotes_Click(sender As Object, e As EventArgs)
        ocultarPanel()
        totalizar()
    End Sub

#End Region
#Region "Eventos de la grilla"
    Private Sub dgvproductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellDoubleClick
        '    If e.ColumnIndex = 12 And txtcodigo.Text = "" AndAlso dtProductos.Rows(e.RowIndex).Item("Bodega_Escoger") = "-- Seleccione Bodega --" Then

        '        Dim celda As New DataGridViewComboBoxCell
        '        'Dim cadena As String = ""
        '        Dim dc = New DataTable
        '        Dim col As New DataColumn
        '        Dim dr As DataRow = dc.NewRow()
        '        dc.Clear()
        '        If celda.Items.Count = 0 Then
        '            Try
        '                dc.Columns.Add("Codigo_Bodega")
        '                dc.Columns.Add("Nombre")
        '                dr(0) = "--"
        '                dr(1) = "- Elija Bodega -"
        '                dc.Rows.Add(dr)

        '                dc = cmd.llenar_combos_bodegas
        '                celda.DataSource = dc
        '                celda.DisplayMember = "Nombre"

        '                dgvproductos.Rows(dgvproductos.CurrentRow.Index).Cells("Bodega_Escoger") = celda
        '                SendKeys.Send("{F4}")
        '            Catch ex As Exception
        '                general.manejoErrores(ex)
        '            End Try


        '        End If
        '    ElseIf (TypeOf dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex) Is DataGridViewComboBoxCell) Then
        '        dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
        '    Else
        '        dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
        '    End If
    End Sub
    Private Sub dgvproductos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvproductos.DataError
        e.Cancel = False
    End Sub
    Private Sub dgvproductos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellEnter
        If txtcodigo.Text <> "" And dgvproductos.Rows(dgvproductos.CurrentRow.Index).Cells("Bodega_Escoger").Value <> Constantes.SELECCIONE_BODEGA Then
            dgvproductos.Rows(dgvproductos.CurrentRow.Index).Cells("Bodega_Escoger").ReadOnly = True
        End If
    End Sub
    Private Sub dgvproductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellContentClick
        If Funciones.filaValida(e.RowIndex) Then
            Dim cmd As New RecepcionBLL
            Dim tblLotes As DataTableCollection = Nothing
            Dim nombreTabla As String = ""
            nombrarTabla(nombreTabla, tblLotes)
            If e.ColumnIndex = dgvproductos.Columns("Lotes").Index Then
                'Crear los lotes o ve los lostes existenes creados en la recepcion
                If objRecepcion.tblProductos.Rows(e.RowIndex).Item("Bodega_Escoger") = Constantes.NO_TIENE Then
                    MsgBox("Debe asignar el producto por lo menos a una bodega !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                ElseIf objRecepcion.tblProductos.Rows(e.RowIndex).Item("Bodega_Escoger") = Constantes.SELECCIONE_BODEGA Then
                    MsgBox("Debe escoger por lo menos una bodega !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Else
                    PnlLotes.BringToFront()
                    PnlLotes.Visible = True
                    TxtDescripcionProducto.Text = objRecepcion.tblProductos.Rows(e.RowIndex).Item("Descripcion")
                    TxtCantidadProducto.Text = objRecepcion.tblProductos.Rows(e.RowIndex).Item("Cantidad")

                    TxtDescripcionProducto.ReadOnly = True
                    TxtCantidadProducto.ReadOnly = True

                    If objRecepcion.verificarExistenciaTabla(nombreTabla) = False Then
                        objRecepcion.agregarTabla(nombreTabla)
                        objRecepcion.colocarColumnasTablaLotes(nombreTabla)
                    End If

                    configurarDgvLotes()
                    dgvLotes.DataSource = tblLotes(nombreTabla)


                    If txtcodigo.Text <> "" Then
                        objRecepcion.tblLotes.Tables(nombreTabla).Clear()
                        cmd.CargarLotesRecepcion(objRecepcion.codigoRecepcion,
                                                 objRecepcion.tblProductos.Rows(dgvproductos.CurrentRow.Index).Item("Codigo"),
                                                 objRecepcion.tblProductos.Rows(dgvproductos.CurrentRow.Index).Item("Codigo_Bodega"),
                                                 tblLotes(nombreTabla))
                        dgvLotes.Enabled = False
                        BtNuevoLotes.Visible = False
                    Else
                        dgvLotes.Enabled = True
                        BtNuevoLotes.Visible = True
                    End If
                End If
            ElseIf e.ColumnIndex = dgvproductos.Columns(TitulosForm.ANULAR).Index AndAlso txtcodigo.Text = "" Then
                'Quitar los lotes asociados al producto 
                If objRecepcion.tblProductos.Rows(dgvproductos.CurrentRow.Index).Item("Cantida_Recibida") > 0 AndAlso
                    MsgBox(Mensajes.QUITAR_LOTE, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes AndAlso
                    objRecepcion.verificarExistenciaTabla(nombreTabla) Then
                    objRecepcion.quitarTabla(nombreTabla)
                    objRecepcion.tblProductos.Rows(dgvproductos.CurrentRow.Index).Item("Cantida_Recibida") = 0
                    verificarBodegaIndividual(dgvproductos.CurrentRow.Index)
                End If
            ElseIf e.ColumnIndex = dgvproductos.Columns("BtnBodegas").Index And btguardar.Enabled Then
                'Buscar la bodega en la cual se va ingresar el producto
                Dim params As New List(Of String)
                params.Add(SesionActual.codigoEP)
                params.Add(objRecepcion.tblProductos.Rows(dgvproductos.CurrentRow.Index).Item("Codigo"))
                params.Add(Nothing)
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
        objRecepcion.tblProductos.Rows(dgvproductos.CurrentRow.Index).Item("Codigo_Bodega") = pCodigoBodega
        objRecepcion.tblProductos.Rows(dgvproductos.CurrentRow.Index).Item("Bodega_Escoger") = dr.Item(0)
        dgvproductos.Rows(dgvproductos.CurrentRow.Index).Cells("Bodega_Escoger").Selected = True
    End Sub
    Private Sub dgvproductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellClick
        If Funciones.filaValida(e.RowIndex) Then
            If Trim(txtcodigo.Text) = "" And btguardar.Enabled = True Then
                dgvproductos.ReadOnly = True
                If e.ColumnIndex = dgvproductos.Columns("ANULAR").Index OrElse e.ColumnIndex = dgvproductos.Columns("BtnBodegas").Index OrElse e.ColumnIndex = dgvproductos.Columns("Lotes").Index Then
                    dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
                Else
                    dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
                End If
            End If
        End If
    End Sub
    Private Sub dgvLotes_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLotes.CellEndEdit
        dgvLotes.EndEdit()
        dgvLotes.CommitEdit(DataGridViewDataErrorContexts.Commit)
        If e.ColumnIndex = dgvLotes.Columns("Cantidad").Index Then
            If dgvLotes.Rows(e.RowIndex).Cells("Num_lote").Value.ToString = "" Then
                dgvLotes.Rows(e.RowIndex).Cells("Cantidad").Value = 0
                MsgBox("Debe Colocar el numero de lote primero !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                dgvLotes.Rows(e.RowIndex).Cells("Num_lote").Selected = True
            ElseIf dgvLotes.Rows(e.RowIndex).Cells("Cantidad").Value > CInt(TxtCantidadProducto.Text) Then
                dgvLotes.Rows(e.RowIndex).Cells("Cantidad").Value = 0
                dgvLotes.Rows(e.RowIndex).Cells("Cantidad").Selected = True
                MsgBox("la cantidad ingresada no puede ser mayor a la cantidad comprada!!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        ElseIf e.ColumnIndex = dgvLotes.Columns("Fecha").Index Then
            Dim int As Integer = DateDiff(DateInterval.Month, CDate(Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)).Date, dgvLotes.Rows(e.RowIndex).Cells("Fecha").Value)
            If DateDiff(DateInterval.Month, CDate(Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)).Date, dgvLotes.Rows(e.RowIndex).Cells("Fecha").Value) < 3 Then
                If MsgBox("La fecha de vencimiento es menor a 3 meses ¿ Desea Ingresarlo ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    dgvLotes.Rows(e.RowIndex).Cells("Fecha").Value = DateAdd(DateInterval.Month, 3, CDate(Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)).Date)
                Else
                    dgvLotes.Rows(e.RowIndex).Cells("Excepcion").Value = True
                End If
            Else
                dgvLotes.Rows(e.RowIndex).Cells("Excepcion").Value = False
            End If
        End If
    End Sub
    Private Sub dgvLotes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLotes.CellContentClick
        If Funciones.filaValida(e.RowIndex) Then
            If txtcodigo.Text = "" And e.ColumnIndex = dgvLotes.Columns("DataGridViewImageColumn2").Index Then
                If MsgBox(Mensajes.QUITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    Dim tblLotes As DataTableCollection = Nothing
                    Dim nombreTabla As String = ""
                    nombrarTabla(nombreTabla, tblLotes)
                    tblLotes(nombreTabla).Rows.RemoveAt(e.RowIndex)
                End If
            End If
        End If
    End Sub
    Private Sub dgvLotes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLotes.CellClick
        If Funciones.filaValida(e.RowIndex) AndAlso Trim(txtcodigo.Text) = "" Then
            dgvLotes.ReadOnly = False
            If Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Num_lote", dgvLotes) OrElse
               Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Fecha", dgvLotes) OrElse
               Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Cantidad", dgvLotes) Then
                dgvLotes.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
            Else
                dgvLotes.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            End If
        Else
            dgvLotes.ReadOnly = True
        End If
    End Sub
    Private Sub dgvLotes_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvLotes.EditingControlShowing
        If dgvLotes.Columns("Cantidad").Index = dgvLotes.CurrentCell.ColumnIndex Then
            RemoveHandler e.Control.KeyPress, AddressOf Valid
            AddHandler e.Control.KeyPress, AddressOf Valid
        Else
            RemoveHandler e.Control.KeyPress, AddressOf inValid
            AddHandler e.Control.KeyPress, AddressOf inValid
        End If
    End Sub
#End Region
#Region "Otros Eventos"
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
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub
#End Region

End Class