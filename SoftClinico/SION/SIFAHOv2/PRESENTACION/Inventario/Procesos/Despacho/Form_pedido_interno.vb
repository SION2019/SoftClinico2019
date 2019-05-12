Public Class Form_pedido_interno
    Dim objPedidoInterno As PedidoInterno
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, PBuscarEmpresas, pRealizarPedidosExternos As String
    Private Sub Form_pedido_interno_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarForm()
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
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub txtBusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtBusqueda.TextChanged
        txtBusqueda.Text = Funciones.validarComillaSimple(txtBusqueda.Text)
        filtrar()
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub
    Private Sub cmbPuntoServicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPuntoServicio.SelectedIndexChanged
        habilitarAutomatico()
        If cmbPuntoServicio.SelectedIndex > 0 And CmbBodSolicitante.SelectedIndex > 0 Then
            llenarComboBodegaSoliciatada()
        End If
    End Sub
    Private Sub CmbBodSolicitante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBodSolicitante.SelectedIndexChanged
        habilitarAutomatico()
        If cmbPuntoServicio.SelectedIndex > 0 Then
            llenarComboBodegaSoliciatada()
        End If
    End Sub
    Private Sub CmbBodSolicitada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBodSolicitada.SelectedIndexChanged
        habilitarAutomatico()
    End Sub
    Private Sub chkAutomatico_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutomatico.CheckedChanged
        If chkAutomatico.Checked = True AndAlso txtCodigo.Text = "" Then
            Cursor = Cursors.WaitCursor
            llenarAutomatico()
            contarNumeroProductos()
            Cursor = Cursors.Default
        Else
            objPedidoInterno.tblProductos.Clear()
            objPedidoInterno.tblProductos.Rows.Add()
        End If
    End Sub
    Sub contarNumeroProductos()
        lblCantidadProductos.Text = "No. Equivalencias: " & contarFilas()
    End Sub
#Region "Botones"
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        cancelar()
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        nuevo()
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        guardar()
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        editar()
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        anularPedido()
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        buscar()
    End Sub
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        imprimir()
    End Sub
#End Region
#Region "Metodos"
    Sub imprimir()
        If txtCodigo.Text = "" Then
            MsgBox("Debe elegir un pedido para imprimir !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        Else
            Try
                Cursor = Cursors.WaitCursor
                Dim rprte As New rptPedidoInterno
                Funciones.getReporteNoFTP(rprte, "{VISTA_PEDIDO_INTERNO.codigo_pedido} = " & objPedidoInterno.codigoPedido, "PedidoInterno", Constantes.FORMATO_PDF)
                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
    Sub guardar()
        dgvproductos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        objPedidoInterno.tblProductos.AcceptChanges()
        objPedidoInterno.enlace.Filter = ""
        If CmbBodSolicitante.SelectedIndex < 1 Then
            MsgBox("Debe escoger la bodega Solicitante antes de guardar !!", MsgBoxStyle.Information)
            CmbBodSolicitante.Focus()
        ElseIf CmbBodSolicitada.SelectedIndex < 1 Then
            MsgBox("Debe escoger la bodega solicitada antes de guardar !!", MsgBoxStyle.Information)
            CmbBodSolicitada.Focus()
        ElseIf objPedidoInterno.tblProductos.Rows.Count = 1 Then
            MsgBox("Debe escoger por lo menos 1 equivalencia a pedir antes de guardar !!", MsgBoxStyle.Information)
        Else
            For Indice = 0 To objPedidoInterno.tblProductos.Rows.Count - 2
                If objPedidoInterno.tblProductos.Rows(Indice).Item("cantidad").ToString = "0" Then
                    MsgBox("Debe colocar las cantidades correctas antes de guardar !!", MsgBoxStyle.Information)
                    Exit Sub
                End If
            Next
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Try
                    Dim cmd As New PedidoInternoBLL
                    empalmarDiseñoToObjeto()
                    cmd.guardarPedido(objPedidoInterno, SesionActual.idUsuario, SesionActual.codigoEP)
                    General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                    cargarPedido(objPedidoInterno.codigoPedido)
                Catch ex As Exception
                    general.manejoErrores(ex)
                End Try

            End If
        End If
    End Sub
    Sub buscar()
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.codigoEP)
            params.Add(Nothing)
            General.buscarElemento(Consultas.BUSQUEDA_PEDIDO_INTERNO_BUSCAR, params,
                                AddressOf cargarPedido,
                                 TitulosForm.BUSQUEDA_PEDIDO_TRASLADOS, True,
                                  Constantes.TAMANO_MEDIANO,
                                  True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub cancelar()
        If General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar) Then
            cmbPuntoServicio.DataSource = Nothing
            CmbBodSolicitada.DataSource = Nothing
        End If
    End Sub
    Sub nuevo()
        If SesionActual.tienePermiso(Pnuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            dpFechaPedido.Value = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
            txtEstado.Text = General.getEstadoInventario(0)
            desactivarControlesInternos()
            llenarEmpesaPuntoActual()
            objPedidoInterno.tblProductos.Rows.Add()
            CmbBodSolicitante.Focus()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Function contarFilas() As Integer
        Dim filas As Integer?
        filas = objPedidoInterno.tblProductos.Select("Codigo <> ''", "").Count
        Return If(IsDBNull(filas), 0, filas)
    End Function
    Sub anularPedido()
        If SesionActual.tienePermiso(Panular) Then
            Dim cmd As New PedidoInternoBLL
            If cmd.verificarExistenciaPedidoInterno(objPedidoInterno) = True Then
                MsgBox("No se puede anular este pedido por que ya fue trasladado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Else
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    Try
                        cmd.AnularPedido(objPedidoInterno, SesionActual.idUsuario)
                        General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                    Catch ex As Exception
                        general.manejoErrores(ex)
                    End Try
                End If
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub editar()
        If SesionActual.tienePermiso(Peditar) Then
            Dim cmd As New PedidoInternoBLL
            If cmd.verificarExistenciaPedidoInterno(objPedidoInterno) = False Then
                If General.fnFormEditar(Me, ToolStrip1, btguardar, btcancelar) Then
                    bloquearContolesSoloLectura()
                    objPedidoInterno.tblProductos.Rows.Add()
                    objPedidoInterno.tblProductos.AcceptChanges()
                    CmbBodSolicitante.Enabled = False
                    cmbPuntoServicio.Enabled = True
                    CmbBodSolicitada.Enabled = True
                End If
            Else
                MsgBox("No se puede editar este pedido !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub bloquearContolesSoloLectura()
        txtEstado.ReadOnly = True
        txtPunto.ReadOnly = True
        txtEmpresa.ReadOnly = True
        txtNombreEmpresaSolicitada.ReadOnly = True
    End Sub
    Sub inicializarForm()
        objPedidoInterno = New PedidoInterno
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        pRealizarPedidosExternos = permiso_general & "pp" & "06"
        objPedidoInterno.enlace.DataSource = objPedidoInterno.tblProductos
        configurarDgv()
        cargarComboSolicitante()
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
        chkAutomatico.Checked = False
    End Sub
    Sub configurarDgv()
        With dgvproductos
            .Columns("Codigo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigo").DataPropertyName = "Codigo"
            .Columns("Nombre").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Nombre").DataPropertyName = "Nombre"
            .Columns("Stock").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Stock").DataPropertyName = "Stock"
            .Columns("Consumo_Promedio").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Consumo_Promedio").DataPropertyName = "Consumo_Promedio"
            .Columns("Cantidad").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cantidad").DataPropertyName = "Cantidad"
            .Columns("Verificacion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Verificacion").DataPropertyName = "Verificacion"
            .AutoGenerateColumns = False
            .DataSource = objPedidoInterno.enlace
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With
    End Sub
    Sub cargarComboSolicitante()
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        General.cargarCombo(Consultas.BOD_SOLICITANTE_LISTAR, params, "Nombre", "Codigo", CmbBodSolicitante)
    End Sub
    Sub filtrar()
        objPedidoInterno.enlace.Filter = String.Format("[Nombre]  LIKE '%" & Replace(txtBusqueda.Text, "%", "") & "%'")
        If txtBusqueda.Text = "" Then
            objPedidoInterno.enlace.Filter = ""
        End If
    End Sub
    Sub desactivarControlesInternos()

        txtNombreEmpresaSolicitada.ReadOnly = True
        btnBuscarEmpresa.Enabled = True
        bloquearContolesSoloLectura()
    End Sub
    Sub buscarEmpresa()
        Dim params As New List(Of String)
        params.Add("")
        General.buscarElemento(Consultas.BUSQUEDA_EMPRESAS_PEDIDO_INTERNO,
                               params,
                               AddressOf cargarEmpresaSolicitada,
                               TitulosForm.BUSQUEDA_EMPRESA,
                               False, 0, True)
    End Sub
    Private Sub Valid(ByVal sender As System.Object, ByVal e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Or (Asc(e.KeyChar) = 46) Or (Asc(e.KeyChar) = 44) Or (Asc(e.KeyChar) = 8) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Public Sub cargarEmpresaSolicitada(ByVal pCodigo As String)
        Dim fila As DataRow
        fila = cargarInformacionEmpresa(pCodigo)
        txtCodigoEmpresaSolicitada.Text = fila.Item(0)
        txtNombreEmpresaSolicitada.Text = fila.Item(1)
        llenarComboPuntoServicio()
    End Sub
    Public Function cargarInformacionEmpresa(ByVal pCodigo As String) As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        Dim fila As DataRow
        fila = General.cargarItem(Consultas.CARGAR_EMPRESA_PEDIDO_INTERNO, params)
        Return fila
    End Function
    Sub cargarEmpresaDeBodega(ByVal pcodigoBodega As String)
        Dim params As New List(Of String)
        params.Add(pcodigoBodega)
        Dim fila As DataRow
        fila = General.cargarItem(Consultas.CARGAR_EMPRESA_ASOCIADA_A_BODEGA_PEDIDO_INTERNO, params)
        txtCodigoEmpresaSolicitada.Text = fila.Item(0)
        txtNombreEmpresaSolicitada.Text = fila.Item(1)
    End Sub
    Sub llenarComboPuntoServicio()
        Dim params As New List(Of String)
        params.Add(txtCodigoEmpresaSolicitada.Text)
        General.cargarCombo(Consultas.PUNTO_ASOCIADO_EMPRESA, params, "Nombre", "Codigo", cmbPuntoServicio)
    End Sub
    Sub llenarComboBodegaSoliciatada()
        Dim params As New List(Of String)
        params.Add(cmbPuntoServicio.SelectedValue)
        params.Add(CmbBodSolicitante.SelectedValue)
        General.cargarCombo(Consultas.BOD_SOACIADA_PUNTO, params, "Nombre", "Codigo", CmbBodSolicitada)
    End Sub
    Public Sub cargarDetallePedido()
        Dim params As New List(Of String)
        params.Add(objPedidoInterno.codigoPedido)
        General.llenarTabla(Consultas.DET_PEDIDO_INTERNO, params, objPedidoInterno.tblProductos)
        objPedidoInterno.enlace.DataSource = objPedidoInterno.tblProductos
    End Sub
    Private Sub btnBuscarEmpresa_Click_1(sender As Object, e As EventArgs) Handles btnBuscarEmpresa.Click
        If SesionActual.tienePermiso(Peditar) Then
            buscarEmpresa()
        Else
            MsgBox("No se puede editar este pedido !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        End If
    End Sub
    Public Sub cargarPedido(pCodigo As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        params.Add(pCodigo)

        General.llenarTabla(Consultas.BUSQUEDA_PEDIDO_INTERNO_CARGAR, params, dt)
        objPedidoInterno.codigoPedido = pCodigo
        objPedidoInterno.codigoPedidoPunto = dt.Rows(0).Item("Codigo")
        objPedidoInterno.codigoBodegaSolicitante = dt.Rows(0).Item("Codigo_Bodega")
        objPedidoInterno.fechaPedido = dt.Rows(0).Item("Fecha")
        txtEstado.Text = General.getEstadoInventario(dt.Rows(0).Item("Estado"))
        cargarEmpresaDeBodega(dt.Rows(0).Item("Codigo_Bodega2"))
        cargarEmpresaSolicitada(txtCodigoEmpresaSolicitada.Text)
        cmbPuntoServicio.SelectedValue = dt.Rows(0).Item("Codigo_Punto")
        objPedidoInterno.codigoBodegaSolicitada = dt.Rows(0).Item("Codigo_Bodega2")
        objPedidoInterno.esExterno = dt.Rows(0).Item("esExterno")
        cargarDetallePedido()
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
        btimprimir.Enabled = True
        llenarEmpesaPuntoActual()
        empalmarObjetoToDiseño()
        contarNumeroProductos()
    End Sub
    Sub llenarEmpesaPuntoActual()
        txtEmpresa.Text = Funciones.empresaActual.razonSocial
        txtPunto.Text = SesionActual.nombreSede
    End Sub
    Sub llenarAutomatico()
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        params.Add(CmbBodSolicitante.SelectedValue)
        params.Add(CmbBodSolicitada.SelectedValue)
        General.llenarTabla(Consultas.BUSQUEDA_PEDIDO_INTERNO_AUTOMATICO, params, objPedidoInterno.tblProductos)
        objPedidoInterno.tblProductos.Rows.Add()
    End Sub
    Sub verificarCeldasActivas(e As DataGridViewCellEventArgs)
        dgvproductos.ReadOnly = False
        If Funciones.filaValida(e.RowIndex) Then
            If btguardar.Enabled = True AndAlso (e.RowIndex < dgvproductos.Rows.Count - 1) Then
                If e.ColumnIndex = dgvproductos.Columns("Cantidad").Index Then
                    dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
                Else
                    dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
                End If
            Else
                dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            End If
        End If
    End Sub
    Sub empalmarDiseñoToObjeto()
        objPedidoInterno.codigoPedidoPunto = txtCodigo.Text
        objPedidoInterno.codigoBodegaSolicitante = CmbBodSolicitante.SelectedValue
        objPedidoInterno.codigoBodegaSolicitada = CmbBodSolicitada.SelectedValue
        objPedidoInterno.fechaPedido = dpFechaPedido.Value
        objPedidoInterno.esExterno = ckbPedidoExterno.Checked
    End Sub
    Sub empalmarObjetoToDiseño()
        txtCodigo.Text = objPedidoInterno.codigoPedidoPunto
        CmbBodSolicitante.SelectedValue = objPedidoInterno.codigoBodegaSolicitante
        CmbBodSolicitada.SelectedValue = objPedidoInterno.codigoBodegaSolicitada
        dpFechaPedido.Value = objPedidoInterno.fechaPedido

    End Sub
    Sub habilitarAutomatico()
        If cmbPuntoServicio.SelectedIndex > 0 AndAlso CmbBodSolicitante.SelectedIndex > 0 AndAlso CmbBodSolicitada.SelectedIndex > 0 AndAlso btguardar.Enabled Then
            chkAutomatico.Enabled = True
        Else
            chkAutomatico.Enabled = False
        End If
    End Sub
    Private Sub ckbPedidoExterno_MouseDown(sender As Object, e As MouseEventArgs) Handles ckbPedidoExterno.MouseDown
        If SesionActual.tienePermiso(pRealizarPedidosExternos) Then
            ckbPedidoExterno.Enabled = True
        Else
            ckbPedidoExterno.Enabled = False
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub ckbPedidoExterno_CheckedChanged(sender As Object, e As EventArgs) Handles ckbPedidoExterno.CheckedChanged
        objPedidoInterno.tblProductos.Clear()
        dgvproductos.Columns("Consumo_Promedio").Visible = Not ckbPedidoExterno.Checked
        If btguardar.Enabled Then
            objPedidoInterno.tblProductos.Rows.Add()
        End If
    End Sub

    Private Sub dgvproductos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvproductos.KeyDown
        buscarEquivalnecias()
    End Sub
#End Region
#Region "Eventos Datagridview"
    Private Sub dgvproductos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvproductos.DataError
        e.Cancel = False
    End Sub

    Private Sub dgvproductos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellEndEdit

        If Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Cantidad", dgvproductos) And e.RowIndex < (dgvproductos.Rows.Count - 1) Then
            Dim codigo As String = dgvproductos.Rows(dgvproductos.CurrentRow.Index).Cells("Codigo").Value
            Dim fila As DataRow = objPedidoInterno.tblProductos.Select("Codigo='" & codigo & "'", "")(0)
            Dim posicion As Integer = 0

            posicion = objPedidoInterno.tblProductos.Rows.IndexOf(fila)

            Dim filaActualTBL As DataRow = objPedidoInterno.tblProductos.Rows(posicion)
            Dim filaActualDGV As DataGridViewRow = dgvproductos.Rows(e.RowIndex)

            If filaActualTBL.Item("Cantidad").ToString <> "" Then
                If filaActualDGV.Cells("Cantidad").Value > 0 Then

                    If Not ckbPedidoExterno.Checked Then
                        'Dim consumoProm As Integer = filaActualDGV.Cells("Consumo_Promedio").Value
                        'Dim cantidad As Integer = filaActualDGV.Cells("Cantidad").Value
                        'Dim stock As Integer = filaActualDGV.Cells("Stock").Value
                        'If consumoProm > 0 OrElse stock > 0 Then
                        '    If (cantidad > consumoProm) OrElse
                        '       (stock >= consumoProm) OrElse
                        '       ((consumoProm - stock) < cantidad) Then
                        '        filaActualDGV.Cells("Cantidad").Value = 0
                        '        MsgBox("Por favor rectifique las cantidades!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                        '    End If
                        'End If

                    Else
                        If txtCodigo.Text <> "" AndAlso filaActualTBL.Item("Estado") = Constantes.ITEM_CARGADO Then
                            filaActualTBL.Item("Estado") = Constantes.ITEM_MODIFICADO
                        End If
                    End If
                    filaActualTBL.AcceptChanges()
                End If
            Else
                filaActualTBL.Item("Cantidad") = 0
                MsgBox("Debe colocar un valor valido", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub
    Private Sub dgvproductos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellEnter
        verificarCeldasActivas(e)
    End Sub
    Private Sub dgvproductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellClick
        verificarCeldasActivas(e)
    End Sub
    Private Sub dgvproductos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvproductos.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivo
    End Sub
    Sub buscarEquivalnecias()
        If Funciones.filaValida(dgvproductos.CurrentRow.Index) Then
            If btguardar.Enabled = True Then
                If CmbBodSolicitante.SelectedValue = -1 Then
                    MsgBox("Debe seleccionar la bodega solicitante !!", MsgBoxStyle.Information)
                ElseIf CmbBodSolicitada.SelectedValue = -1 OrElse IsNothing(CmbBodSolicitada.SelectedValue) Then
                    MsgBox("Debe seleccionar la bodega Soliciada !!", MsgBoxStyle.Information)
                ElseIf CmbBodSolicitante.SelectedValue = CmbBodSolicitada.SelectedValue Then
                    MsgBox("No se puede hacer pedido a la misma bodega !!", MsgBoxStyle.Information)
                Else

                    If (dgvproductos.CurrentCell.ColumnIndex = dgvproductos.Columns("Codigo").Index OrElse dgvproductos.CurrentCell.ColumnIndex = dgvproductos.Columns("Nombre").Index) Then
                        Dim params As New List(Of String)
                        params.Add(SesionActual.codigoEP)
                        params.Add(CmbBodSolicitante.SelectedValue)
                        params.Add(CmbBodSolicitada.SelectedValue)
                        params.Add(Constantes.VALOR_NO_APLICA)
                        General.busquedaItems(Consultas.BUSQUEDA_PEDIDO_INTERNO, params,
                                              TitulosForm.BUSQUEDA_EQUIVALENCIA,
                                              dgvproductos,
                                              objPedidoInterno.tblProductos,
                                              0,
                                              4,
                                              0,
                                              False,
                                              True,
                                              0,
                                              False,
                                              Nothing,
                                              Constantes.TAMANO_MEDIANO)
                    ElseIf dgvproductos.CurrentCell.ColumnIndex = dgvproductos.Columns(TitulosForm.ANULAR).Index AndAlso btguardar.Enabled AndAlso dgvproductos.CurrentRow.Index < dgvproductos.RowCount - 1 Then
                        If MsgBox(Mensajes.QUITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.QUITAR_FILAS) = MsgBoxResult.Yes Then
                            objPedidoInterno.tblProductos.Rows.RemoveAt(dgvproductos.CurrentRow.Index)
                        End If
                    End If
                    contarNumeroProductos()
                End If
            End If
        End If
    End Sub
    Private Sub dgvproductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellDoubleClick
        buscarEquivalnecias()
    End Sub
#End Region
End Class