Imports System.Net.Mail
Imports System.Threading
Imports System.IO
Public Class ProgramacionOrdenCompra

    Dim objProgramacionCompraBLL As New ProgramacionOrdenComprasBLL
    Dim objProgramacionCompra As New ProgramacionOrdenCompras
    Dim perG As New Buscar_Permisos_generales
    Dim hilo As New Thread(AddressOf crearReporteOrdenCompra)
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String

#Region "Botones"
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            Try
                If objProgramacionCompraBLL.verificarExistenciaProgramacionMesActual() = False Then
                    Cursor = Cursors.WaitCursor
                    Dim params As New List(Of String)
                    params.Add(SesionActual.codigoEP)
                    params.Add(cmbMes.SelectedItem)
                    params.Add(ndFactor.Value)
                    listarProveedores(Consultas.PROGRAMACION_COMPRA_LISTAR_PROVEEDORES, params)
                    cargarListadoProductosComprar()
                    eliminarProveedorSinProductos()
                    Cursor = Cursors.Default
                    'General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
                    General.deshabilitarBotones(ToolStrip1)
                    btguardar.Enabled = True
                    btcancelar.Enabled = True
                    RbPro.Checked = True
                    txtRango.ReadOnly = True
                    controlesSoloLectura()
                    deshabilitarControlesFiltro

                Else
                    MsgBox("Ya se ha generado la programación de compra para el mes de " & obtenerNombreMesActual(Now.Month) & " !", MsgBoxStyle.Exclamation)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarForm() Then
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + vbYesNo) = MsgBoxResult.Yes Then
                Try
                    empalmarDisenioToObjeto()
                    objProgramacionCompraBLL.guardarProgramacionOrdenCompra(objProgramacionCompra, SesionActual.idUsuario, SesionActual.codigoEP)
                    cargarDatosProgramacionOrdenCompra(objProgramacionCompra.codigoProgramacion)
                    General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, Nothing, btanular)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            If objProgramacionCompraBLL.VerificarExistenciaOrdenesRescepcionadas() = False Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    objProgramacionCompraBLL.anularProgramacionOrdenCompra(objProgramacionCompra, SesionActual.idUsuario)
                    General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                    objProgramacionCompra.tblProveedores.Clear()
                End If
            Else
                MsgBox("No se puede anular la programación ya que alguna orden se ha recepcionado !", MsgBoxStyle.Exclamation)
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar) Then
            LbProveedores.DataSource = Nothing
            objProgramacionCompra.tblLotes.Reset()
            limpiarGrilla()
            LbProveedores.Refresh()
            dgvproductos.Refresh()
            habilitarControlesFiltro()
        End If
    End Sub
    Sub habilitarControlesFiltro()
        cmbMes.Enabled = True
        ndFactor.Enabled = True
        ndFactor.ReadOnly = False
    End Sub
    Sub limpiarGrilla()
        dgvproductos.DataSource = Nothing
        dgvproductos.Columns.Clear()
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.codigoEP)
            params.Add(Nothing)
            General.buscarElemento(
                                Consultas.PROGRAMACION_COMPRA_BUSCAR,
                                params,
                                AddressOf cargarDatosProgramacionOrdenCompra,
                                TitulosForm.BUSQUEDA_PROGRAMACION_ORDEN_COMPRA,
                                False,
                                Constantes.TAMANO_MEDIANO,
                                True
                               )
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btEnviarMails_Click(sender As Object, e As EventArgs) Handles btEnviarMails.Click
        If txtcodigo.Text <> "" Then
            enlazarGrillaCorreos()
            Dim params As New List(Of String)
            params.Add(objProgramacionCompra.codigoProgramacion)
            General.llenarTabla(Consultas.PROGRAMACION_COMPRA_CARGAR_LISTA_PROVEEDORES_CORREOS, params, objProgramacionCompra.tblProveedoresCorreos, True)
            configurarBarraProgreso()
            pnlProveedores.BringToFront()
            pnlProveedores.Visible = True
            btSalir.Enabled = True
            btEnviar.Enabled = True
            chkTodos.Enabled = True
            chkTodos.Checked = True
        Else
            MsgBox("Debe escoger la programación antes de enviar los correos!", MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btSalir_Click(sender As Object, e As EventArgs) Handles btSalir.Click
        pnlProveedores.Visible = False
    End Sub
    Private Sub btEnviar_Click(sender As Object, e As EventArgs) Handles btEnviar.Click
        limpiarObjetoEnviocorreo()
        llenarDstosEnvioPordefecto()
        Dim listadoProveedores As String = ""
        For indiceProveedor = 0 To objProgramacionCompra.tblProveedoresCorreos.Rows.Count - 1
            If objProgramacionCompra.tblProveedoresCorreos.Rows(indiceProveedor).Item("Mail").ToString = "" Then
                listadoProveedores += objProgramacionCompra.tblProveedoresCorreos.Rows(indiceProveedor).Item("proveedor") & vbNewLine
            End If
        Next
        If listadoProveedores <> "" Then
            MsgBox("Proveedores sin configurar correos: " & vbNewLine & listadoProveedores, MsgBoxStyle.Exclamation)
            If MsgBox("¿ Desea enviar los corres de los proveedores que los tienen configurados ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                pgbEmails.Maximum = objProgramacionCompra.tblProveedoresCorreos.Select("Verificacion = True").Count
                crearNuevoHilo()
            End If
        End If
    End Sub
    Sub crearNuevoHilo()
        If Not IsNothing(hilo) Then
            If hilo.IsAlive Then
                Try
                    hilo.Abort()
                Catch ex As Exception
                Finally
                    inicialHilo()
                End Try
            Else
                inicialHilo()
            End If
        Else
            inicialHilo()
        End If
    End Sub
    Sub inicialHilo()
        hilo = Nothing
        hilo = New System.Threading.Thread(AddressOf crearReporteOrdenCompra)
        hilo.Start()
    End Sub
    Sub configurarBarraProgreso()
        pgbEmails.Value = 0
        pgbEmails.Minimum = 0
    End Sub
#End Region
#Region "Metodos"
    Sub deshabilitarControlesFiltro()
        cmbMes.Enabled = False
        ndFactor.ReadOnly = True
        ndFactor.Enabled = False
    End Sub
    Sub llenarDstosEnvioPordefecto()
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        Dim fila As DataRow = General.cargarItem(Consultas.USUARIO_ENVIO_CORREO_CARGAR_TERCERO_CONFIGURADO, params)
        If Not IsNothing(fila) Then
            objProgramacionCompra.objEnviocorreo.CodigoConfiguracion = fila.Item(0)
            'objProgramacionCompra.objEnviocorreo.idTercero = fila.Item(1)
            objProgramacionCompra.objEnviocorreo.contreseña = fila.Item(3)
            objProgramacionCompra.objEnviocorreo.email = fila.Item(4)
        End If
    End Sub
    Sub limpiarObjetoEnviocorreo()
        objProgramacionCompra.objEnviocorreo.CodigoConfiguracion = ""
        ' objProgramacionCompra.objEnviocorreo.idTercero = 0
        objProgramacionCompra.objEnviocorreo.contreseña = ""
        objProgramacionCompra.objEnviocorreo.email = ""
    End Sub
    Sub crearReporteOrdenCompra()
        Dim params As New List(Of String)
        Dim filaOrdenesProveedor As DataRow
        For indiceMail = 0 To objProgramacionCompra.tblProveedoresCorreos.Rows.Count - 1
            If objProgramacionCompra.tblProveedoresCorreos.Rows(indiceMail).Item("Verificacion") = True Then

                params.Clear()
                params.Add(objProgramacionCompra.codigoProgramacion)
                params.Add(objProgramacionCompra.tblProveedoresCorreos.Rows(indiceMail).Item("Id"))
                filaOrdenesProveedor = General.cargarItem(Consultas.PROGRAMACION_COMPRA_OBTENER_CODIGO_ORDEN_POR_PROVEEDOR, params)

                If Not IsNothing(filaOrdenesProveedor) Then
                    If generarReporteOrdenCompra(filaOrdenesProveedor.Item(0), objProgramacionCompra.tblProveedoresCorreos.Rows(indiceMail).Item("Id")) AndAlso
                        enviarCorreo(objProgramacionCompra.tblProveedoresCorreos.Rows(indiceMail).Item("Id"), filaOrdenesProveedor.Item(1),
                                    If(objProgramacionCompra.tblProveedoresCorreos.Rows(indiceMail).Item("Mail").ToString <> "", "juliomeza05@hotmail.com", objProgramacionCompra.tblProveedoresCorreos.Rows(indiceMail).Item("Mail").ToString)) Then
                        dgvProveedoresCorreos.Rows(indiceMail).Cells("Estado").Value = New Bitmap(My.Resources.OK)
                    Else
                        dgvProveedoresCorreos.Rows(indiceMail).Cells("Estado").Value = New Bitmap(My.Resources.error_fuck)
                    End If
                    pgbEmails.Value += 1
                End If

            End If
        Next

        MsgBox("Correos enviados correctamente!", MsgBoxStyle.Information)
        pgbEmails.Value = 0

        Try
            hilo.Abort()
        Catch ex As ThreadAbortException
        End Try
    End Sub
    Sub enlazarGrillaCorreos()
        With dgvProveedoresCorreos
            .Columns("Proveedor").DataPropertyName = "proveedor"
            .Columns("Email").DataPropertyName = "Mail"
            .Columns("Verificacion").DataPropertyName = "Verificacion"
            .AutoGenerateColumns = False
            .DataSource = objProgramacionCompra.tblProveedoresCorreos
        End With
    End Sub
    Sub inicializarForm()
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
        cmbMes.SelectedIndex = 0
        habilitarControlesFiltro()
    End Sub
    Sub empalmarObjetoToDisenio()
        txtcodigo.Text = objProgramacionCompra.codigoProgramacion
        MtxtfechaOrden.Value = objProgramacionCompra.fechaProgramacion
    End Sub
    Sub empalmarDisenioToObjeto()
        objProgramacionCompra.codigoProgramacion = txtcodigo.Text
        objProgramacionCompra.fechaProgramacion = MtxtfechaOrden.Value
    End Sub
    Sub listarProveedores(ByVal cadenaLlenado As String, ByRef params As List(Of String))
        objProgramacionCompraBLL.llenarListaProveedoresOrdenes(LbProveedores, SesionActual.codigoEP, objProgramacionCompra.tblProveedores, "Id", "proveedor", cadenaLlenado, params)
    End Sub
    Sub cargarListadoProductosComprar()
        Dim nombreTabla As String = ""
        Dim tablas As DataTableCollection = objProgramacionCompra.tblLotes.Tables

        For indiceItem = 0 To LbProveedores.Items.Count - 1
            nombreTabla = objProgramacionCompra.nombrarTabla(LbProveedores.Items(indiceItem)(0))

            If Not objProgramacionCompra.verificarExistenciaTabla(nombreTabla) Then
                objProgramacionCompra.agregarTabla(nombreTabla)
                agregarColumnasTabla(tablas(nombreTabla))
            End If

            Dim listParams As New List(Of String)
            listParams.Add(SesionActual.codigoEP)
            listParams.Add(LbProveedores.Items(indiceItem)(0))

            If tablas(nombreTabla).Columns.Contains("Total") Then
                tablas(nombreTabla).Columns("Total").Expression = ""
            End If
            If tablas(nombreTabla).Columns.Contains("Orden") = False Then
                tablas(nombreTabla).Columns.Add("Orden", Type.GetType("System.Int32"))
                tablas(nombreTabla).Columns("Orden").AutoIncrement = True
                tablas(nombreTabla).Columns("Orden").AutoIncrementStep = 1
            End If

            Dim paramshash As New Hashtable
            Dim tblParametros As New DataTable


            For Each tabla In tablas
                Dim dtv As New DataView(tabla)
                Dim tblTempProductos As New DataTable
                tblTempProductos = dtv.ToTable(True, "Código")
                tblParametros.Merge(tblTempProductos)

            Next

            paramshash.Add("@pPunto", SesionActual.codigoEP)
            paramshash.Add("@pIdProveedor", LbProveedores.Items(indiceItem)(0))
            paramshash.Add("@pMeses", cmbMes.SelectedItem)
            paramshash.Add("@pFactor", ndFactor.Value)
            General.llenarTablaParametroTabla(Consultas.PROGRAMACION_COMPRA_LISTAR_PRODUCTOS, paramshash, tblParametros, tablas(nombreTabla), True)
            tablas(nombreTabla).Rows.Add()
        Next
        General.diseñoDGV(dgvproductos)
    End Sub
    Sub eliminarProveedorSinProductos()
        Dim resp As Boolean = False
        Dim tablas As DataTableCollection = objProgramacionCompra.tblLotes.Tables
        Dim tablaProveedores As DataTable = objProgramacionCompra.tblProveedores
        Dim nombreTabla As String

        For indiceItem = 0 To tablaProveedores.Rows.Count - 1
            nombreTabla = objProgramacionCompra.nombrarTabla(tablaProveedores.Rows(indiceItem).Item("Id"))
            If tablas(nombreTabla).Rows.Count = 1 Then
                objProgramacionCompra.quitarTabla(nombreTabla)
                tablaProveedores.Rows.RemoveAt(indiceItem)
                resp = True
                Exit For
            End If
        Next
        If resp Then
            eliminarProveedorSinProductos()
        End If
    End Sub
    Sub agregarColumnasTabla(ByRef tbl As DataTable)
        Dim columnas As DataColumnCollection = tbl.Columns
        columnas.Add("Código")
        columnas.Add("Descripción")
        columnas.Add("Marca")
        columnas.Add("Presentación")
        columnas.Add("Stock Equivalencia", Type.GetType("System.Int32")).DefaultValue = 0
        columnas.Add("Stock Producto", Type.GetType("System.Int32")).DefaultValue = 0
        columnas.Add("CPM", Type.GetType("System.Int32")).DefaultValue = 0
        columnas.Add("Iva", Type.GetType("System.Double")).DefaultValue = 0
        columnas.Add("cantidad", Type.GetType("System.Int32")).DefaultValue = 0
        columnas.Add("Descuento", Type.GetType("System.Double")).DefaultValue = 0
        columnas.Add("Costo", Type.GetType("System.Double")).DefaultValue = 0
        columnas.Add("Total", Type.GetType("System.Double")).DefaultValue = 0
    End Sub
    Sub cargarListadoProductosGuardados(ByVal codigoProgramacion As Integer)
        Dim nombreTabla As String = ""
        Dim tablas As DataTableCollection = objProgramacionCompra.tblLotes.Tables
        For indiceItem = 0 To LbProveedores.Items.Count - 1
            nombreTabla = objProgramacionCompra.nombrarTabla(LbProveedores.Items(indiceItem)(0))
            objProgramacionCompra.agregarTabla(nombreTabla)
            If objProgramacionCompra.verificarExistenciaTabla(nombreTabla) Then
                Dim listParams As New List(Of String)
                listParams.Add(codigoProgramacion)
                listParams.Add(SesionActual.codigoEP)
                listParams.Add(LbProveedores.Items(indiceItem)(0))
                If tablas(nombreTabla).Columns.Contains("Total") Then
                    tablas(nombreTabla).Columns("Total").Expression = ""
                End If
                If tablas(nombreTabla).Columns.Contains("Orden") = False Then
                    tablas(nombreTabla).Columns.Add("Orden", Type.GetType("System.Int32"))
                    tablas(nombreTabla).Columns("Orden").AutoIncrement = True
                    tablas(nombreTabla).Columns("Orden").AutoIncrementStep = 1
                End If
                General.llenarTabla(Consultas.PROGRAMACION_COMPRA_CARGAR_PRODUCTOS_GUARDADOS, listParams, tablas(nombreTabla), True)
            End If
        Next
        General.diseñoDGV(dgvproductos)
    End Sub
    Sub cargarDatosProgramacionOrdenCompra(ByVal codigoProgrmacion As Integer)
        objProgramacionCompra.codigoProgramacion = codigoProgrmacion
        Dim fila As DataRow
        Dim params As New List(Of String)
        params.Add(objProgramacionCompra.codigoProgramacion)
        fila = General.cargarItem(Consultas.PROGRAMACION_COMPRA_CARGAR_DATOS_PROGRAMACION, params)
        If Not IsNothing(fila) Then
            objProgramacionCompra.fechaProgramacion = fila.Item(1)
            txtRango.Text = "No. Compra Inicial: " & fila.Item(2) & " | No. Compra Final: " & fila.Item(3)
        End If
        params.Clear()
        params.Add(objProgramacionCompra.codigoProgramacion)
        listarProveedores(Consultas.PROGRAMACION_COMPRA_BUSCAR_INDIVIDUAL, params)
        cargarListadoProductosGuardados(objProgramacionCompra.codigoProgramacion)
        empalmarObjetoToDisenio()
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, btEnviarMails, btanular)
    End Sub
    Sub calcularOrdenProveedor()
        Dim subtotal, iva, descuento As Double
        Dim filas As DataRow()
        Dim tblTemp As New DataTable
        Dim nombreTabla As String = ""

        nombreTabla = objProgramacionCompra.nombrarTabla(LbProveedores.SelectedValue)
        'Calcular cada unos de los campos
        objProgramacionCompra.tblLotes.Tables(nombreTabla).Columns("Total").Expression = "Cantidad * Costo"
        objProgramacionCompra.tblLotes.Tables(nombreTabla).AcceptChanges()
        subtotal = If(IsDBNull(objProgramacionCompra.tblLotes.Tables(nombreTabla).Compute("Sum(Total)", "")), 0, objProgramacionCompra.tblLotes.Tables(nombreTabla).Compute("Sum(Total)", ""))

        tblTemp = objProgramacionCompra.tblLotes.Tables(nombreTabla).Clone()
        filas = objProgramacionCompra.tblLotes.Tables(nombreTabla).Select("iva > 0", "")
        For Each fila In filas
            tblTemp.ImportRow(fila)
        Next
        tblTemp.Columns.Add("TotalIva", Type.GetType("System.Double"))
        tblTemp.Columns("TotalIva").Expression = "Total * (iva/100)"
        iva = If(IsDBNull(tblTemp.Compute("Sum(TotalIva)", "")), 0, tblTemp.Compute("Sum(TotalIva)", ""))

        tblTemp.Reset()

        tblTemp = objProgramacionCompra.tblLotes.Tables(nombreTabla).Clone()
        filas = objProgramacionCompra.tblLotes.Tables(nombreTabla).Select("Descuento > 0", "")
        For Each fila In filas
            tblTemp.ImportRow(fila)
        Next
        tblTemp.Columns.Add("TotalDescuento", Type.GetType("System.Double"))
        tblTemp.Columns("TotalDescuento").Expression = "Total * (Descuento/100)"
        descuento = If(IsDBNull(tblTemp.Compute("Sum(TotalDescuento)", "")), 0, tblTemp.Compute("Sum(TotalDescuento)", ""))

        'Información al diseño
        txtbruto.Text = FormatCurrency(subtotal, 2)
        txtiva.Text = FormatCurrency(iva, 2)
        txtdescuento.Text = FormatCurrency(descuento, 2)
        txttotal.Text = FormatCurrency((subtotal + iva) - descuento, 2)
    End Sub
    Sub controlesSoloLectura()
        txtbruto.ReadOnly = True
        txtiva.ReadOnly = True
        txtdescuento.ReadOnly = True
        txttotal.ReadOnly = True
    End Sub
    Sub buscarProductos()
        Dim nombreTabla As String = ""
        Dim seleccionados As String = ""
        nombreTabla = objProgramacionCompra.nombrarTabla(LbProveedores.SelectedValue)

        seleccionados = General.getCadenaSeleccionados(objProgramacionCompra.tblLotes.Tables(nombreTabla), seleccionados, 0)

        Dim params As New List(Of String)
        params.Add(LbProveedores.SelectedValue)
        params.Add(If(RbCosto.Checked, "Costo", "Proveedor"))
        params.Add(SesionActual.codigoEP)
        params.Add(seleccionados)

        General.buscarElemento(Consultas.BUSQUEDA_PRODUCTOS_POR_PROVEEDOR,
                               params,
                               AddressOf cargarProductoBuscado,
                               TitulosForm.BUSQUEDA_PRODUCTOS_INDIVIDUAL_CONTEO,
                               True,
                               Constantes.TAMANO_MEDIANO,
                               True)

    End Sub
    Sub cargarProductoBuscado(ByVal codigo As String)
        Dim proveedor As String = VerificarExistenciaProductoEnProveedores(codigo)
        Dim fila As DataRow
        If proveedor <> "" Then
            If MsgBox("El producto se encuentra en la compra del proveedor: " & proveedor & vbNewLine & "¿ Desea colocar el producto de todas formas ?", MsgBoxStyle.Question + vbYesNo) = MsgBoxResult.Yes Then
                fila = obtenerInformacionProducto(codigo)
                asignarProductoDatagrid(fila)
            End If
        Else
            fila = obtenerInformacionProducto(codigo)
            asignarProductoDatagrid(fila)
        End If

    End Sub
    Sub asignarProductoDatagrid(ByVal fila As DataRow)
        Dim nombreTabla As String = ""
        nombreTabla = objProgramacionCompra.nombrarTabla(LbProveedores.SelectedValue)
        If objProgramacionCompra.verificarExistenciaTabla(nombreTabla) Then
            Dim ultimaFila As Integer = objProgramacionCompra.tblLotes.Tables(nombreTabla).Rows.Count - 1
            objProgramacionCompra.tblLotes.Tables(nombreTabla).Rows(ultimaFila).Item("Código") = fila.Item(0)
            objProgramacionCompra.tblLotes.Tables(nombreTabla).Rows(ultimaFila).Item("Descripción") = fila.Item(1)
            objProgramacionCompra.tblLotes.Tables(nombreTabla).Rows(ultimaFila).Item("Marca") = fila.Item(2)
            objProgramacionCompra.tblLotes.Tables(nombreTabla).Rows(ultimaFila).Item("Presentación") = fila.Item(3)
            objProgramacionCompra.tblLotes.Tables(nombreTabla).Rows(ultimaFila).Item("Stock Equivalencia") = fila.Item(5)
            objProgramacionCompra.tblLotes.Tables(nombreTabla).Rows(ultimaFila).Item("Stock Producto") = fila.Item(6)
            objProgramacionCompra.tblLotes.Tables(nombreTabla).Rows(ultimaFila).Item("CPM") = fila.Item(8)
            objProgramacionCompra.tblLotes.Tables(nombreTabla).Rows(ultimaFila).Item("IVA") = fila.Item(4)
            objProgramacionCompra.tblLotes.Tables(nombreTabla).Rows(ultimaFila).Item("Cantidad") = 0
            objProgramacionCompra.tblLotes.Tables(nombreTabla).Rows(ultimaFila).Item("Descuento") = 0
            objProgramacionCompra.tblLotes.Tables(nombreTabla).Rows(ultimaFila).Item("Costo") = fila.Item(7)
            objProgramacionCompra.tblLotes.Tables(nombreTabla).Rows.Add()
        End If
    End Sub
#End Region
#Region "Eventos Grilla"
    Private Sub dgvProveedoresCorreos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProveedoresCorreos.CellEnter
        dgvProveedoresCorreos.ReadOnly = False
        If Funciones.filaValida(e.RowIndex) Then
            If e.ColumnIndex = dgvProveedoresCorreos.Columns("Verificacion").Index Then
                dgvProveedoresCorreos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
            Else
                dgvProveedoresCorreos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            End If
        End If
    End Sub
    Private Sub dgvProveedoresCorreos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProveedoresCorreos.CellClick
        dgvProveedoresCorreos.ReadOnly = False
        If Funciones.filaValida(e.RowIndex) Then
            If e.ColumnIndex = dgvProveedoresCorreos.Columns("Verificacion").Index Then
                dgvProveedoresCorreos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
            Else
                dgvProveedoresCorreos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            End If
        End If
    End Sub
    Private Sub dgvproductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellClick
        If Funciones.filaValida(e.RowIndex) Then
            If (e.ColumnIndex = dgvproductos.Columns("Cantidad").Index OrElse e.ColumnIndex = dgvproductos.Columns("Descuento").Index) AndAlso btguardar.Enabled Then
                dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
            Else
                dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            End If
        End If
    End Sub
    Private Sub dgvproductos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellEnter
        If Funciones.filaValida(e.RowIndex) Then
            If (e.ColumnIndex = dgvproductos.Columns("Cantidad").Index OrElse e.ColumnIndex = dgvproductos.Columns("Descuento").Index) AndAlso btguardar.Enabled Then
                dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
            Else
                dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            End If
        End If
    End Sub
    Private Sub dgvproductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellDoubleClick
        If Funciones.filaValida(e.RowIndex) Then
            If dgvproductos.RowCount = 2 Then
                MsgBox("La orden debe tener por lo menos 1 producto ! ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            If e.ColumnIndex = dgvproductos.Columns("quitar").Index AndAlso dgvproductos.Rows(e.RowIndex).Cells(0).Value.ToString <> "" Then
                If MsgBox(Mensajes.QUITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim nombreTabla As String = objProgramacionCompra.nombrarTabla(LbProveedores.SelectedValue)
                    objProgramacionCompra.tblLotes.Tables(nombreTabla).Rows.RemoveAt(e.RowIndex)
                End If
            ElseIf e.ColumnIndex <> dgvproductos.Columns("quitar").Index AndAlso dgvproductos.Rows(e.RowIndex).Cells(0).Value.ToString = "" Then
                buscarProductos()
            End If
        End If
    End Sub
    Private Sub dgvproductos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellEndEdit
        calcularOrdenProveedor()
    End Sub
    Private Sub dgvproductos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvproductos.EditingControlShowing
        If dgvproductos.Columns("Cantidad").Index = dgvproductos.CurrentCell.ColumnIndex Then
            AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivo
        Else
            AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
        End If
    End Sub

#End Region
#Region "Otros Eventos"
    Private Sub ProgramacionOrdenCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        inicializarForm()
        controlesSoloLectura()
    End Sub

    Private Sub chkTodos_CheckStateChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckStateChanged
        For indiceFila = 0 To objProgramacionCompra.tblProveedoresCorreos.Rows.Count - 1
            objProgramacionCompra.tblProveedoresCorreos.Rows(indiceFila).Item("Verificacion") = chkTodos.Checked
        Next
    End Sub
    Private Sub LbProveedores_MouseDown(sender As Object, e As MouseEventArgs) Handles LbProveedores.MouseDown
        CtmQuitar.Enabled = btguardar.Enabled
    End Sub
    Private Sub QuitarToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles QuitarToolStripMenuItem.Click
        If LbProveedores.SelectedIndex >= 0 Then
            If MsgBox(Mensajes.QUITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim nombreTabla As String = objProgramacionCompra.nombrarTabla(LbProveedores.SelectedValue)
                objProgramacionCompra.quitarTabla(nombreTabla)
                objProgramacionCompra.tblProveedores.Rows.RemoveAt(LbProveedores.SelectedIndex)
                dgvproductos.DataSource = Nothing
            End If
        End If
    End Sub
    Private Sub QuitarProductoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim nombreTabla As String = objProgramacionCompra.nombrarTabla(LbProveedores.SelectedValue)
        If objProgramacionCompra.tblLotes.Tables(nombreTabla).Select("CONVERT(Código, 'System.String')  <> ''").Count = 1 Then
            MsgBox("Debe tener por lo menos 1 producto la orden de compra," & vbNewLine & "Si no desea tener productos en esta orden de compra quite el proveedor!", MsgBoxStyle.Exclamation)
        Else
            objProgramacionCompra.tblLotes.Tables(nombreTabla).Rows.RemoveAt(dgvproductos.CurrentRow.Index)
        End If
    End Sub
    Private Sub AgregarProductoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If LbProveedores.SelectedIndex >= 0 And btguardar.Enabled Then
            Dim numeroFilas As Integer
            Dim nombreTabla As String = ""
            nombreTabla = objProgramacionCompra.nombrarTabla(LbProveedores.SelectedValue)
            numeroFilas = objProgramacionCompra.tblLotes.Tables(nombreTabla).Rows.Count
            If Not String.IsNullOrEmpty(objProgramacionCompra.tblLotes.Tables(nombreTabla).Rows(numeroFilas - 1).Item(0).ToString) Then
                objProgramacionCompra.tblLotes.Tables(nombreTabla).Rows.Add()
            End If
        End If
    End Sub
    Private Sub LbProveedores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LbProveedores.SelectedIndexChanged
        If LbProveedores.SelectedIndex >= 0 AndAlso (btguardar.Enabled OrElse txtcodigo.Text <> "") Then
            limpiarGrilla()
            Dim nombreTabla As String = ""
            nombreTabla = objProgramacionCompra.nombrarTabla(LbProveedores.SelectedValue)


            With dgvproductos

                .DataSource = objProgramacionCompra.tblLotes.Tables(nombreTabla)

                If Not .Columns.Contains("quitar") Then
                    Dim column As New DataGridViewImageColumn
                    column.Name = "quitar"
                    column.HeaderText = "Quitar"
                    column.Image = My.Resources.trash_icon
                    .Columns.Add(column)
                End If

                If .Columns.Count > 0 Then
                    .Columns("Costo").DefaultCellStyle.Format = "C2"
                    .Columns("Total").DefaultCellStyle.Format = "C2"
                    .Columns("Stock Equivalencia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Stock Producto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Iva").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Descuento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("CPM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Costo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("Orden").Visible = False
                    .Columns("Codigo_Interno").Visible = False
                    For indiceColumna = 0 To dgvproductos.ColumnCount - 1
                        .Columns(indiceColumna).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        '.Columns(indiceColumna).SortMode = DataGridViewColumnSortMode.NotSortable
                    Next
                End If
            End With
            calcularOrdenProveedor()
        End If
    End Sub
#End Region
#Region "Funciones"
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Function validarForm() As Boolean
        Dim resp As Boolean = True
        Dim nombreTabla As String = ""
        'Se recorre el listado de proveedores
        For indiceProveedor = 0 To LbProveedores.Items.Count - 1
            nombreTabla = objProgramacionCompra.nombrarTabla(LbProveedores.Items(indiceProveedor)(0))
            'Se verifica si exite la tabla en el dataset
            If objProgramacionCompra.verificarExistenciaTabla(nombreTabla) Then
                If objProgramacionCompra.tblLotes.Tables(nombreTabla).Select("Cantidad <= 0").Count > 0 Then
                    MsgBox("Debe colocar las cantidades correctas del proveedor: " & LbProveedores.Items(indiceProveedor)(1), MsgBoxStyle.Exclamation)
                    resp = False
                    Exit For
                End If
            End If
        Next
        Return resp
    End Function
    Function VerificarExistenciaProductoEnProveedores(ByVal codigo As String) As String
        Dim resp As String = ""
        Dim nombreTabla As String = ""
        'Se recorre el listado de proveedores
        For indiceProveedor = 0 To LbProveedores.Items.Count - 1
            nombreTabla = objProgramacionCompra.nombrarTabla(LbProveedores.Items(indiceProveedor)(0))
            'Se verifica si exite la tabla en el dataset
            If objProgramacionCompra.verificarExistenciaTabla(nombreTabla) Then
                If objProgramacionCompra.tblLotes.Tables(nombreTabla).Select("Código='" & codigo & "'").Count > 0 Then
                    resp = LbProveedores.Items(indiceProveedor)(1)
                    Exit For
                End If
            End If
        Next
        Return resp
    End Function
    Function obtenerInformacionProducto(ByVal codigo As Integer) As DataRow
        Dim params As New List(Of String)
        params.Add(LbProveedores.SelectedValue)
        params.Add(If(RbCosto.Checked, "Costo", "Proveedor"))
        params.Add(SesionActual.codigoEP)
        params.Add(codigo)
        Dim fila As DataRow = General.cargarItem(Consultas.PROGRAMACION_COMPRA_CARGAR_PRODUCTOS, params)
        Return fila
    End Function
    Function obtenerNombreMesActual(ByVal numeroMes As Integer) As String
        Dim nombre As String = ""
        Select Case numeroMes
            Case 1
                nombre = "enero"
            Case 2
                nombre = "febrero"
            Case 3
                nombre = "marzo"
            Case 4
                nombre = "abril"
            Case 5
                nombre = "mayo"
            Case 6
                nombre = "junio"
            Case 7
                nombre = "julio"
            Case 8
                nombre = "agosto"
            Case 9
                nombre = "septiembre"
            Case 10
                nombre = "octubre"
            Case 11
                nombre = "noviembre"
            Case 12
                nombre = "diciembre"
        End Select
        Return nombre
    End Function
    Function crearCarpetasOrdenes(ByVal idProveedor As String) As String
        Dim ruta As String = objProgramacionCompra.rutaTemporales & idProveedor
        If Directory.Exists(ruta) = False Then
            System.IO.Directory.CreateDirectory(ruta)
        End If
        Return ruta
    End Function
    Function enviarCorreo(ByVal Proveedor As String, ByVal codigoOdenCompra As Integer, Optional ByVal correoDestino As String = "") As Boolean
        Try
            ' Dim Remitente As String = "juliomeza05@hotmail.com"

            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential(objProgramacionCompra.objEnviocorreo.email, objProgramacionCompra.objEnviocorreo.contreseña)
            Smtp_Server.Port = 25
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.live.com"


            Dim archivos() As String = Directory.GetFiles(crearCarpetasOrdenes(Proveedor))
            For Each archivo In archivos
                Dim archivoAdjunto As New System.Net.Mail.Attachment(archivo)
                e_mail.Attachments.Add(archivoAdjunto)
            Next

            e_mail.From = New MailAddress(objProgramacionCompra.objEnviocorreo.email)
            e_mail.To.Add(If(correoDestino <> "", "juliomeza05@hotmail.com", correoDestino))
            e_mail.Subject = "ORDEN DE COMPRA No. " & codigoOdenCompra & " DE SAIS IPS S.A.S"
            e_mail.IsBodyHtml = False
            e_mail.Body = "Adjunto Orden de compra no. " & codigoOdenCompra
            Smtp_Server.Send(e_mail)
            e_mail.Dispose()
            Smtp_Server.Dispose()
        Catch error_t As Exception
            Return False
        End Try

        Return True
    End Function
    Function generarReporteOrdenCompra(ByVal CodigoOrden As String, ByVal proveedor As Integer) As Boolean
        Try
            Dim nombreOdenCompra As String = "Orden_" & proveedor & Constantes.FORMATO_PDF
            Dim rprte As New RPT_ORDEN_COMPRA
            Dim Convertir As New ConvertirNumeros
            Dim tbl As New Hashtable
            Dim valor As Double = CDbl(0) ' ojo colocar el parametro de total orden compra
            tbl.Add("valor_en_letras", FuncionesContables.Convertir_Numero(valor))
            Funciones.getReporteNoFTP(rprte, "{VISTA_EMPRESAS.Id_empresa}=" & SesionActual.idEmpresa &
                                             " And {I_ORDEN_COMPRA.Codigo_Orden} = " & CodigoOrden &
                                             " And {I_ORDEN_COMPRA_D.Anulado}= False", "OrdenCompra", Constantes.FORMATO_PDF, tbl, crearCarpetasOrdenes(proveedor) & "\" & nombreOdenCompra, False)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function


#End Region
End Class