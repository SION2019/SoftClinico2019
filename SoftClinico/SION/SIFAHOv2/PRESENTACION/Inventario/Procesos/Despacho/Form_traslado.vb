Imports System.Data.SqlClient
Imports System.Threading
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class Form_traslado

    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, pbuscar_pedidos As String
    Dim objTraslado As New TrasladoProducto
    'Diseño hecho por manuel 
    Private Sub Form_traslado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarForm()
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
#Region "Metodos"
    Sub inicializarForm()
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        pbuscar_pedidos = permiso_general & "pp" & "05"
        cargarCombox()
        enlazardgvDatatable()
        Dim cmd As New TrasladoProductoBLL
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
        cmd.calcularTotales(objTraslado, LblCostoTotal, LblCantidad_productos)
    End Sub
    Sub cargarCombox()
        General.cargarCombo(Consultas.TRANSPORTADORA_LISTAR, "Descripcion", "Codigo_transportadora", CmbTransportadora)
        General.cargarCombo(Consultas.BOD_SOLICITADA_LISTAR, "Nombre", "Codigo", CmbBodSolicitada)
        General.cargarCombo(Consultas.BOD_SOLICITADA_LISTAR, "Nombre", "Codigo", CmbBodSolicitante)
    End Sub

    Sub busquedaProducto()
        Dim productosSeleccionados As String = ""
        For indiceProducto = 0 To objTraslado.tblProductos.Rows.Count - 1
            If objTraslado.tblProductos.Rows(indiceProducto).Item("Codigo").ToString <> "" Then
                If productosSeleccionados <> "" Then
                    productosSeleccionados = productosSeleccionados & Chr(44)
                End If
                productosSeleccionados = productosSeleccionados & Chr(36) & objTraslado.tblProductos.Rows(indiceProducto).Item("Codigo") & Chr(36)
            End If
        Next

        'Dim comilla As String = Chr(39) 'comilla simple
        'Dim separador As String = Chr(44) '(,)

        Dim params As New List(Of String)
        params.Add(objTraslado.bodegaSolicitada)
        params.Add(dgvproductos.Rows(dgvproductos.CurrentRow.Index).Cells("Codigo_Interno").Value)
        params.Add(productosSeleccionados)
        params.Add("")
        General.buscarElemento(Consultas.BUSCAR_PRODUCTOS_TRASLADO,
                               params,
                               AddressOf cargarProductodgv,
                               TitulosForm.BUSQUEDA_PRODUCTOS_INDIVIDUAL_CONTEO,
                               False)
    End Sub
    Sub cargarProductodgv(ByVal pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        Dim fila As DataRow
        fila = General.cargarItem(Consultas.CARGAR_INFORMACION_PRODUCTO, params)
        dgvproductos.Rows(dgvproductos.CurrentRow.Index).Cells("Codigo").Value = fila.Item(0)
        dgvproductos.Rows(dgvproductos.CurrentRow.Index).Cells("Nombre_producto").Value = fila.Item(1)
        dgvproductos.Rows(dgvproductos.CurrentRow.Index).Cells("Marca").Value = fila.Item(2)
    End Sub
    Sub buscarPedidos()
        Try
            If Funciones.verificarServidor50Only() Then
                Dim params As New List(Of String)
                params.Add(SesionActual.codigoEP)
                params.Add(Nothing)
                General.buscarElemento(Consultas.BUSCAR_PEDIDO_TRASLADOS,
                                       params,
                                       AddressOf cargarPedido,
                                       TitulosForm.BUSQUEDA_PEDIDO_TRASLADOS,
                                       True,
                                       Constantes.TAMANO_GRANDE,
                                       True)
            Else
                objTraslado.activarPrincial = True
                Dim params As New List(Of String)
                params.Add(SesionActual.codigoEP)
                params.Add(Nothing)
                General.buscarElemento(Consultas.BUSCAR_PEDIDO_TRASLADOS_DESTINO_PRINCIPAL,
                                       params,
                                       AddressOf cargarPedido,
                                       TitulosForm.BUSQUEDA_PEDIDO_TRASLADOS,
                                       True,
                                       Constantes.TAMANO_GRANDE,
                                       False)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub cargarPedido(ByVal pCodigo As String)
        Try
            Cursor = Cursors.WaitCursor
            objTraslado.codigoPedido = pCodigo
            Dim params As New List(Of String)
            params.Add(objTraslado.codigoPedido)

            Dim fila As DataRow = General.cargarItem(If(objTraslado.activarPrincial, "[PROC_TRASLADO_CARGAR_PEDIDO_INTERNO_CODIGO_PUNTO_DESTINO_PRINCIPAL]", "[PROC_TRASLADO_CARGAR_PEDIDO_INTERNO_CODIGO_PUNTO]"), params)
            objTraslado.codigoPedidoPunto = fila.Item(0)

            params.Clear()
            params.Add(objTraslado.codigoPedido)
            fila = General.cargarItem(If(objTraslado.activarPrincial, Consultas.BUSCAR_PEDIDO_TRASLADOS_CARGAR_DESTINO_PRINCIPAL, Consultas.BUSCAR_PEDIDO_TRASLADOS_CARGAR), params)
            objTraslado.bodegaSolicitante = fila.Item(1)
            objTraslado.bodegaSolicitada = fila.Item(2)
            txtCodigoPedido.Text = objTraslado.codigoPedidoPunto
            CmbBodSolicitante.SelectedValue = fila.Item(1)
            CmbBodSolicitada.SelectedValue = fila.Item(2)
            txtEmpresa.Text = fila.Item(3)
            txtPuntoServicio.Text = fila.Item(4)
            cargarDetallePedido(pCodigo)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub cargarDetallePedido(ByVal codigo_pedido As Integer)
        objTraslado.tblLotes.Reset()
        objTraslado.tblProductos.Clear()
        Dim params As New List(Of String)
        params.Add(codigo_pedido)
        params.Add(CmbBodSolicitada.SelectedValue)
        params.Add(CmbBodSolicitante.SelectedValue)
        params.Add(SesionActual.codigoEP)
        General.llenarTabla(If(objTraslado.activarPrincial, Consultas.BUSCAR_PEDIDO_TRASLADOS_CARGAR_DETALLE_DESTINO_PRINCIPAL, Consultas.BUSCAR_PEDIDO_TRASLADOS_CARGAR_DETALLE), params, objTraslado.tblProductos)
        PnlLotes.Visible = False
    End Sub
    Sub limpiarProducto(ByVal fila As Int16)
        objTraslado.tblProductos.Rows(fila).Item("Codigo") = ""
        objTraslado.tblProductos.Rows(fila).Item("Nombre_producto") = ""
        objTraslado.tblProductos.Rows(fila).Item("Marca") = ""
        objTraslado.tblProductos.Rows(fila).Item("CantEnt") = 0
        objTraslado.tblProductos.Rows(fila).Item("Total_p") = 0
        dgvproductos.EndEdit()
        dgvproductos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        objTraslado.tblProductos.AcceptChanges()
    End Sub
    Public Sub limpiarcontroles()
        General.limpiarControles(Me)
        objTraslado.tblProductos.Clear()
        LblCostoTotal.Text = "Total Despacho: " & Format(0, "c2")
        LblCantidad_productos.Text = "Productos: " & Format(0, "c2")
    End Sub
    Sub enlazardgvDatatableLotes(ByVal nombreTabla As String)
        With dgvLotes
            .Columns("Reg_lote").ReadOnly = False
            .Columns("Reg_lote").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Reg_lote").DataPropertyName = "Reg_lote"
            .Columns("Reg_lote").Visible = False
            .Columns("Num_lote").ReadOnly = True
            .Columns("Num_lote").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Num_lote").DataPropertyName = "Num_lote"
            .Columns("Fecha").ReadOnly = True
            .Columns("Fecha").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Fecha").DataPropertyName = "Fecha"
            .Columns("stockLote").ReadOnly = True
            .Columns("stockLote").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("stockLote").DataPropertyName = "stock"
            .Columns("Cantidad").ReadOnly = False
            .Columns("Cantidad").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cantidad").DataPropertyName = "Cantidad"
            .Columns("Costo").ReadOnly = False
            .Columns("Costo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Costo").DataPropertyName = "Costo"
            .Columns("Total").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Total").DataPropertyName = "Total"
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .AutoGenerateColumns = False
            .DataSource = objTraslado.tblLotes.Tables(nombreTabla)
        End With
    End Sub
    Sub enlazardgvDatatable()
        With dgvproductos
            .Columns("Codigo_Interno").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigo_Interno").DataPropertyName = "Codigo_Interno"
            .Columns("Codigo_Interno").ReadOnly = True
            .Columns("Nombre_equi").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Nombre_equi").DataPropertyName = "Nombre_equi"
            .Columns("Nombre_equi").ReadOnly = True
            .Columns("Stock").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Stock").DataPropertyName = "Stock"
            .Columns("Stock").ReadOnly = True
            .Columns("Stock_bod_solicitante").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Stock_bod_solicitante").DataPropertyName = "Stock_solicitante"
            .Columns("Stock_bod_solicitante").ReadOnly = True
            .Columns("CantPed").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantPed").DataPropertyName = "CantPed"
            .Columns("CantPed").ReadOnly = True
            .Columns("CantEnt").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantEnt").DataPropertyName = "CantEnt"
            .Columns("CantEnt").ReadOnly = True
            .Columns("CantFalt").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantFalt").DataPropertyName = "CantFalt"
            .Columns("CantFalt").ReadOnly = True
            .Columns("CPQ").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CPQ").DataPropertyName = "CPQ"
            .Columns("CPQ").ReadOnly = True
            .Columns("Codigo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigo").DataPropertyName = "Codigo"
            .Columns("Codigo").ReadOnly = True
            .Columns("Nombre_producto").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Nombre_producto").DataPropertyName = "Nombre_producto"
            .Columns("Nombre_producto").ReadOnly = True
            .Columns("Marca").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Marca").DataPropertyName = "Marca"
            .Columns("Marca").ReadOnly = True
            .Columns("Total_P").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Total_P").DataPropertyName = "Total_P"
            .Columns("Total_P").ReadOnly = True
            .AutoGenerateColumns = False
            .DataSource = objTraslado.tblProductos
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With
    End Sub
    Private Sub Valid(ByVal sender As System.Object, ByVal e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Or (Asc(e.KeyChar) = 8) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Function validarCeldaActual(ByVal dgvProductos As DataGridView,
                                ByRef e As DataGridViewCellEventArgs,
                                ByRef btnGuardar As ToolStripButton,
                                ByVal nombreColumna As String)
        If (Funciones.validarCeldaActiva(dgvProductos, e, nombreColumna, btnGuardar)) Then
            Return False
        Else
            Return True
        End If
    End Function
    Sub cargarTraslado(ByVal Codigo As String)
        Dim fila As DataRow
        Dim params As New List(Of String)
        params.Add(Codigo)
        fila = General.cargarItem(If(objTraslado.activarPrincial, Consultas.TRASLADO_CARGAR_INFORMACION_DESTINO_PRINCIPAL, Consultas.TRASLADO_CARGAR_INFORMACION), params)
        objTraslado.codigoTraslado = Codigo
        objTraslado.codigoTrasladoPunto = fila.Item("Codigo_Traslado_Punto")
        objTraslado.noGuia = fila.Item("No_Guia")
        objTraslado.fechaTraslado = Format(fila.Item("Fecha_Traslado"), Constantes.FORMATO_FECHA_HORA_GEN)
        txtEstado.Text = General.getEstadoInventario(fila.Item("Estado"))
        objTraslado.trasnportadora = fila.Item("Codigo_Transportadora")
        ChkAumento.Checked = CBool(fila.Item("Porcen"))
        objTraslado.codigoPedido = fila.Item("Codigo_Pedido")
        objTraslado.bodegaSolicitante = fila.Item("Codigo_Bodega_Origen")
        objTraslado.bodegaSolicitada = fila.Item("Codigo_Bodega_Destino")
        objTraslado.porcentaje = fila.Item("Porcen")
        txtEmpresa.Text = fila.Item("Empresa")
        txtPuntoServicio.Text = fila.Item("Punto")
        General.llenarTabla("[PROC_TRASLADO_CARGAR_DETALLE]", params, objTraslado.tblProductos)

        params.Clear()
        params.Add(objTraslado.codigoPedido)
        Dim filaPunto As DataRow = General.cargarItem(If(objTraslado.activarPrincial, "[PROC_TRASLADO_CARGAR_PEDIDO_INTERNO_CODIGO_PUNTO_DESTINO_PRINCIPAL]", "[PROC_TRASLADO_CARGAR_PEDIDO_INTERNO_CODIGO_PUNTO]"), params)
        objTraslado.codigoPedidoPunto = filaPunto.Item(0)
        txtCodigoPedido.Text = objTraslado.codigoPedidoPunto
        Dim cmd As New TrasladoProductoBLL
        cmd.calcularTotales(objTraslado, LblCostoTotal, LblCantidad_productos)
        empalmarObjetoToDiseno()
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, btimprimir, btanular)
    End Sub
    Sub empalmarObjetoToDiseno()
        ChkAumento.Checked = objTraslado.porcentaje
        txtcodigo.Text = objTraslado.codigoTrasladoPunto
        txtGuia.Text = objTraslado.noGuia
        dpFechaTraslado.Value = objTraslado.fechaTraslado
        CmbTransportadora.SelectedValue = objTraslado.trasnportadora
        CmbBodSolicitante.SelectedValue = objTraslado.bodegaSolicitante
        CmbBodSolicitada.SelectedValue = objTraslado.bodegaSolicitada
    End Sub
    Sub empalmarDisenoToObjeto()
        objTraslado.porcentaje = ChkAumento.Checked
        objTraslado.codigoTrasladoPunto = txtcodigo.Text
        objTraslado.noGuia = txtGuia.Text
        objTraslado.fechaTraslado = dpFechaTraslado.Value
        objTraslado.trasnportadora = CmbTransportadora.SelectedValue
        objTraslado.bodegaSolicitante = CmbBodSolicitante.SelectedValue
        objTraslado.bodegaSolicitada = CmbBodSolicitada.SelectedValue
    End Sub
    Sub deshabilitarControlesInternos()
        CmbBodSolicitada.Enabled = False
        CmbBodSolicitante.Enabled = False
        txtEstado.ReadOnly = True
        txtEmpresa.ReadOnly = True
        txtPuntoServicio.ReadOnly = True
    End Sub
#End Region
#Region "Botones"
    Private Sub btnBuscar_pedidos_Click_1(sender As Object, e As EventArgs) Handles btnBuscar_pedidos.Click
        If SesionActual.tienePermiso(pbuscar_pedidos ) Then
            buscarPedidos()
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub BtSalirlOTES_Click(sender As Object, e As EventArgs) Handles BtSalirlOTES.Click
        PnlLotes.Visible = False
        Dim cmd As New TrasladoProductoBLL
        cmd.calcularTotales(objTraslado, LblCostoTotal, LblCantidad_productos)
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            dgvLotes.CommitEdit(DataGridViewDataErrorContexts.Commit)
            dgvproductos.CommitEdit(DataGridViewDataErrorContexts.Commit)

            If txtGuia.Text = "" Then
                txtGuia.Focus()
                MsgBox("Debe ingresar el No. guia !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            ElseIf CmbTransportadora.SelectedIndex < 1 Then
                CmbTransportadora.Focus()
                MsgBox("Debe escoger la transportadora !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            ElseIf objTraslado.tblProductos.Select("CantEnt = 0").Count = dgvproductos.RowCount Then
                dgvproductos.Focus()
                MsgBox("Debe despachar por lo menos un producto para poder guardar el traslado !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Else
                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    Try
                        Dim cmd As New TrasladoProductoBLL
                        empalmarDisenoToObjeto()
                        cmd.GuardarTraslado(objTraslado, SesionActual.codigoEP, SesionActual.idUsuario)
                        cargarTraslado(objTraslado.codigoTraslado)
                        General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, btanular, btimprimir)
                    Catch ex As Exception
                        general.manejoErrores(ex)
                    End Try
                End If
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If txtcodigo.Text = "" Then
            MsgBox("Debe elegir un traslado para imprimir !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        Else
            Cursor = Cursors.WaitCursor
            Dim formula As String = ""
            Dim reporte As ReportClass
            formula = "{VISTA_TRASLADO_INVENTARIO.Codigo_traslado} =" & objTraslado.codigoTraslado
            If Funciones.verificarServidor50Only() Then
                reporte = New RPT_TRASLADO
            Else
                reporte = New RPT_TRASLADO_ALTERNO
            End If

            Try
                Funciones.getReporteNoFTP(reporte, formula, "", Constantes.FORMATO_PDF)
            Catch ex As Exception
                general.manejoErrores(ex)
            End Try
            Cursor = Cursors.Default
        End If

    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Try
            If SesionActual.tienePermiso(Panular ) Then
                Dim cmd As New TrasladoProductoBLL
                If cmd.verificacionTrasladoAnular(objTraslado.codigoTraslado) = True Then
                    If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                        cmd.anular(objTraslado, SesionActual.idUsuario)
                        General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                    End If
                Else
                    MsgBox("No se puede anular el trasado por que ya tiene una recepción de traslado asociada !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                End If
            Else
               MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Try

                'If Funciones.verificarServidor50Only() Then

                Dim params As New List(Of String)
                    params.Add(SesionActual.codigoEP)
                    params.Add("")
                    General.buscarElemento(Consultas.BUSCAR_TRASLADOS,
                                       params,
                                       AddressOf cargarTraslado,
                                       TitulosForm.BUSQUEDA_TRASLADOS,
                                       True,
                                       Constantes.TAMANO_GRANDE,
                                       True
                                       )
                'Else
                '    objTraslado.activarPrincial = True
                '    Dim params As New List(Of String)
                '    params.Add(SesionActual.codigoEP)
                '    params.Add("")
                '    General.buscarElemento(Consultas.BUSCAR_TRASLADOS_DESTINO_PRINCIPAL,
                '                       params,
                '                       AddressOf cargarTraslado,
                '                       TitulosForm.BUSQUEDA_TRASLADOS,
                '                       True,
                '                       Constantes.TAMANO_GRANDE,
                '                       True
                '                       )
                'End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            objTraslado.codigoTraslado = ""
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            btnBuscar_pedidos.Enabled = True
            txtEstado.Text = General.getEstadoInventario(Constantes.PENDIENTE)
            dpFechaTraslado.Value = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
            deshabilitarControlesInternos()
            txtcodigo.Focus()
            objTraslado.activarPrincial = False
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    'Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
    '    If SesionActual.tienePermiso(Peditar ) Then

    '    Else
    '       MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
    '    End If
    'End Sub
#End Region
#Region "Eventos dgv"
    Private Sub dgvproductos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvproductos.KeyDown
        If e.KeyCode = Keys.F3 AndAlso
            btguardar.Enabled AndAlso
            (dgvproductos.CurrentCell.ColumnIndex = dgvproductos.Columns("Codigo").Index OrElse dgvproductos.CurrentCell.ColumnIndex = dgvproductos.Columns("Nombre_producto").Index) Then
            busquedaProducto()
        End If
    End Sub
    Private Sub dgvLotes_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLotes.CellEndEdit
        Dim cmd As New TrasladoProductoBLL
        cmd.calcular_lotes(objTraslado, dgvLotes, dgvproductos, TxtCantidadProducto)
    End Sub
    Private Sub dgvproductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellClick

    End Sub
    Private Sub dgvLotes_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvLotes.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
    End Sub
    Private Sub dgvproductos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellEnter
        dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = validarCeldaActual(dgvproductos, e, btguardar, "Lote")
    End Sub

    Private Sub dgvLotes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLotes.CellClick
        dgvLotes.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = validarCeldaActual(dgvLotes, e, btguardar, "Cantidad")
    End Sub
    Private Sub dgvproductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellDoubleClick
        If Funciones.filaValida(e.RowIndex) Then
            If btguardar.Enabled Then
                If (dgvproductos.CurrentCell.ColumnIndex = dgvproductos.Columns("Codigo").Index OrElse dgvproductos.CurrentCell.ColumnIndex = dgvproductos.Columns("Nombre_producto").Index) Then
                    busquedaProducto()
                ElseIf Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, TitulosForm.ANULAR, dgvproductos) AndAlso MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    Dim cmd As New TrasladoProductoBLL
                    If txtcodigo.Text = "" Then
                        Dim nombreTabla As String = objTraslado.nombrarTabla(objTraslado.tblProductos.Rows(e.RowIndex).Item("Codigo").ToString, e.RowIndex)
                        If objTraslado.verificarExistenciaTabla(nombreTabla) Then
                            objTraslado.quitarTabla(nombreTabla)
                        End If
                        limpiarProducto(e.RowIndex)
                        cmd.calcularTotales(objTraslado, LblCostoTotal, LblCantidad_productos)
                        For indiceFila = 0 To objTraslado.tblProductos.Rows.Count - 1
                            If objTraslado.tblProductos.Rows(e.RowIndex).Item("Codigo_Interno") = objTraslado.tblProductos.Rows(indiceFila).Item("Codigo_Interno") AndAlso
                               objTraslado.tblProductos.Rows(e.RowIndex).Item("CantPed") <> objTraslado.tblProductos.Rows(indiceFila).Item("CantPed") Then
                                objTraslado.tblProductos.Rows(e.RowIndex).Item("CantPed") += objTraslado.tblProductos.Rows(indiceFila).Item("CantPed")
                                objTraslado.tblProductos.Rows.RemoveAt(indiceFila)
                                Exit For
                            End If
                        Next
                    Else
                        If cmd.verificarAnularProducto(objTraslado.codigoTraslado, objTraslado.tblProductos.Rows(e.RowIndex).Item("Codigo")) Then
                            If objTraslado.tblProductos.Rows.Count = 1 Then
                                MsgBox("Debe haber por lo menos (1) producto en el traslado", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
                                Exit Sub
                            End If
                            Try
                                cmd.anularProducto(objTraslado.codigoTraslado,
                                                   objTraslado.tblProductos.Rows(e.RowIndex).Item("Codigo_interno"),
                                                   objTraslado.tblProductos.Rows(e.RowIndex).Item("Codigo"),
                                                   objTraslado.codigoPedido,
                                                   CmbBodSolicitada.SelectedValue,
                                                   SesionActual.idUsuario)
                                cargarTraslado(objTraslado.codigoTraslado)
                            Catch ex As Exception
                                general.manejoErrores(ex)
                            End Try
                        Else
                            MsgBox("El producto no se puede anular ya que tiene una recepción de traslado asociada !", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub dgvproductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellContentClick
        If Funciones.verificacionPosicionActual(dgvproductos, e, "Lote") Then
            If objTraslado.tblProductos.Rows(e.RowIndex).Item("Codigo").ToString <> "" Then
                PnlLotes.BringToFront()
                PnlLotes.Visible = True
                TxtDescripcionProducto.Text = objTraslado.tblProductos.Rows(e.RowIndex).Item("Nombre_producto")
                TxtCantidadProducto.Text = objTraslado.tblProductos.Rows(e.RowIndex).Item("CantPed")
                TxtDescripcionProducto.ReadOnly = True
                TxtCantidadProducto.ReadOnly = True
                Dim nombreTabla As String
                nombreTabla = objTraslado.nombrarTabla(objTraslado.tblProductos.Rows(e.RowIndex).Item("Codigo").ToString, e.RowIndex)
                objTraslado.agregarTabla(nombreTabla)
                objTraslado.llenarTablaLotes(nombreTabla)
                enlazardgvDatatableLotes(nombreTabla)
                Dim cmd As New TrasladoProductoBLL
                If txtcodigo.Text <> "" Then
                    objTraslado.tblLotes.Tables(nombreTabla).Clear()
                    cmd.cargarLotesDespachados(nombreTabla, objTraslado.tblProductos.Rows(e.RowIndex).Item("Codigo").ToString, objTraslado)
                Else
                    If objTraslado.tblLotes.Tables(nombreTabla).Rows.Count = 0 Then
                        cmd.cargarLotesDespachar(nombreTabla, objTraslado.tblProductos.Rows(e.RowIndex).Item("Codigo").ToString, CmbBodSolicitada.SelectedValue, objTraslado)
                    End If
                    dgvLotes.Enabled = True
                End If
            Else
                MsgBox("Debe escoger un producto antes de trasladar los lotes !", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub dgvLotes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLotes.CellDoubleClick
        If Funciones.filaValida(e.RowIndex) Then
            If objTraslado.codigoTraslado = "" Then
                If Funciones.verificacionPosicionActual(dgvLotes, e, "DataGridViewImageColumn2") Then
                    Dim nombreTabla As String = objTraslado.nombrarTabla(objTraslado.tblProductos.Rows(dgvproductos.CurrentRow.Index).Item("Codigo"), dgvproductos.CurrentRow.Index)
                    If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                        objTraslado.tblLotes.Tables(nombreTabla).Rows(dgvLotes.CurrentRow.Index).Item("Cantidad") = 0
                        dgvLotes.CommitEdit(DataGridViewDataErrorContexts.Commit)
                        dgvLotes.EndEdit()
                        Dim cmd As New TrasladoProductoBLL
                        cmd.calcular_lotes(objTraslado, dgvLotes, dgvproductos, TxtCantidadProducto)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub txtEstado_TextChanged(sender As Object, e As EventArgs) Handles txtEstado.TextChanged

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub txtGuia_TextChanged(sender As Object, e As EventArgs) Handles txtGuia.TextChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub dgvLotes_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvLotes.DataError
        e.Cancel = False
        MsgBox("Valor invalido!", MsgBoxStyle.Exclamation)
    End Sub


#End Region
    Private Sub AgregarEquivalenciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarEquivalenciaToolStripMenuItem.Click
        Dim cmd As New TrasladoProductoBLL
        cmd.dividirEquivalencia(objTraslado, dgvproductos)
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
    Private Sub PnlLotes_VisibleChanged(sender As Object, e As EventArgs) Handles PnlLotes.VisibleChanged
        dgvproductos.Enabled = Not PnlLotes.Visible
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub
End Class
