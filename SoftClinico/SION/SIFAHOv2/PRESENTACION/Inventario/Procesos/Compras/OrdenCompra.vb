Imports System.Data.SqlClient
Imports System.Threading
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Net.Mail
Imports System.IO
Public Class OrdenCompra
    Shared hilo As Thread
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, pbuscar_proveedor, pCuentaCobro As String
    Public diasEntregaProveedor, codigoListaProveedor As Integer
    Shared objOrdenCompra As Compra
    Private Sub OrdenCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarFormulario()
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Mtxtfecha_orden_Leave(sender As Object, e As EventArgs) Handles MtxtfechaOrden.Leave
        MtxtEspera.Value  = Format(CDate(MtxtfechaOrden .Value ).AddDays(diasEntregaProveedor), Constantes.FORMATO_FECHA_GEN)
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
    Private Sub RbCosto_CheckedChanged(sender As Object, e As EventArgs) Handles RbCosto.CheckedChanged
        dgvproductos.Focus()
    End Sub
    Private Sub RbPro_CheckedChanged(sender As Object, e As EventArgs) Handles RbPro.CheckedChanged
        dgvproductos.Focus()
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cursor = Cursors.WaitCursor
        ManualUsuarioDAL.llamar_archivo(Name)
        Cursor = Cursors.Default
    End Sub
#Region "Metodos"
    Sub mostarOcultarPanel()
        pnlUsuarioPass.Visible = Not pnlUsuarioPass.Visible
    End Sub
    Private Sub inicializarFormulario()
        CheckForIllegalCrossThreadCalls = False
        objOrdenCompra = New Compra
        Dim cmd As New OrdenCompraBLL
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        pbuscar_proveedor = permiso_general & "pp" & "05"
        pCuentaCobro = permiso_general & "pp" & "06"
        cmd.configurarGrillaProductos(objOrdenCompra.tablaProductos, dgvproductos)
        enlazarTexboxsResultadosCompra()
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
        If SesionActual.tienePermiso(pCuentaCobro) Then
            ckCuentaCobro.Visible = True
        Else
            ckCuentaCobro.Visible = False
        End If
    End Sub
    Private Sub enlazarTexboxsResultadosCompra()
        txtbruto.DataBindings.Add("Text", objOrdenCompra.tablaProductos, "SumaValorBruto", True, DataSourceUpdateMode.OnPropertyChanged, 0, "c2")
        txtiva.DataBindings.Add("Text", objOrdenCompra.tablaProductos, "SumaValorIva", True, DataSourceUpdateMode.OnPropertyChanged, 0, "c2")
        txtdescuento.DataBindings.Add("Text", objOrdenCompra.tablaProductos, "SumaValorDescuento", True, DataSourceUpdateMode.OnPropertyChanged, 0, "c2")
        txttotal.DataBindings.Add("Text", objOrdenCompra.tablaProductos, "SumaValorTotal", True, DataSourceUpdateMode.OnPropertyChanged, 0, "c2")
    End Sub
    Public Sub cargarProveedor(pFila As DataRow)
        objOrdenCompra.codigoProveedor = pFila.Item(0).ToString
        txtidproveedor.Text = pFila.Item(0).ToString
        txtproveedor.Text = pFila.Item(2).ToString()
        txtformadepago.Text = pFila.Item(3).ToString()
        diasEntregaProveedor = pFila.Item(4).ToString()
        MtxtfechaOrden.Value = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        MtxtEspera.Value = Format(CDate(CDate(Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)).Date.ToShortDateString).AddDays(pFila.Item(4).ToString()), Constantes.FORMATO_FECHA_GEN)
        txtestado.Text = General.getEstadoInventario(Constantes.PENDIENTE)
        RbPro.Checked = True
        limpiarControlesInterno()
        If MsgBox("¿ Desea cargar los productos automaticos para el proveedor " & txtproveedor.Text & "?", MsgBoxStyle.Question + vbYesNo) = MsgBoxResult.Yes Then
            llenarProductoAutomaricos()
        End If
    End Sub
    Sub llenarProductoAutomaricos()
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        params.Add(objOrdenCompra.codigoProveedor)

        General.llenarTabla(Consultas.CARGAR_PRODUCTOS_PROMEDIO_PROVEEDOR, params, objOrdenCompra.tablaProductos)
        objOrdenCompra.tablaProductos.Rows.Add()
        contarProductos()
    End Sub
    Private Sub limpiarControlesInterno()
        txtObservaciones.Text = ""
        txtbruto.Text = ""
        txtiva.Text = ""
        txtdescuento.Text = ""
        txttotal.Text = ""
    End Sub
    Public Sub cargarCompra(pCodigo As String)
        objOrdenCompra.codigoCompra = pCodigo
        cargarOrdenEncabezado()
        contarProductos()
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
        btimprimir.Enabled = True
        btEnviarCorreos.Enabled = True
    End Sub
    Sub empalmarDiseñoToObjeto()
        'objOrdenCompra.codigoCompra = Nothing
        objOrdenCompra.cuentaCobro = ckCuentaCobro.Checked
        objOrdenCompra.codigoCompraPunto = txtcodigo.Text
        objOrdenCompra.fechaCompra = MtxtfechaOrden.Value
        objOrdenCompra.fechaEntrega = MtxtEspera.Value
        objOrdenCompra.codigoProveedor = txtidproveedor.Text
        objOrdenCompra.observacionCompra = txtObservaciones.Text
        objOrdenCompra.estado = If(txtestado.Text = "Pendiente", Constantes.PENDIENTE, Constantes.TERMINADO)
        objOrdenCompra.tablaProductos.AcceptChanges()
    End Sub
    Sub empalmarObjetoToDiseño()
        ckCuentaCobro.Checked = objOrdenCompra.cuentaCobro
        txtcodigo.Text = objOrdenCompra.codigoCompraPunto
        MtxtfechaOrden.Value = objOrdenCompra.fechaCompra
        MtxtEspera.Value = objOrdenCompra.fechaEntrega
        txtidproveedor.Text = objOrdenCompra.codigoProveedor
        txtObservaciones.Text = objOrdenCompra.observacionCompra
        txtestado.Text = General.getEstadoInventario(objOrdenCompra.estado)
    End Sub
    Sub configurarImpresion()
        If txtcodigo.Text = "" Then
            MsgBox("Debe elegir una orden para imprimir !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        Else
            Try
                Cursor = Cursors.WaitCursor
                Dim rprte As New RPT_ORDEN_COMPRA
                Dim Convertir As New ConvertirNumeros
                Dim tbl As New Hashtable
                Dim valor As Double = CDbl(txttotal.Text)
                tbl.Add("valor_en_letras", FuncionesContables.Convertir_Numero(valor))
                Funciones.getReporteNoFTP(rprte, "{VISTA_ORDEN_COMPRA_ENBEZADO.codigo_orden} =" & objOrdenCompra.codigoCompra, "OrdenCompra", Constantes.FORMATO_PDF, tbl)
                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
    Public Sub contarProductos()
        Dim objCompraBLL As New OrdenCompraBLL
        LblContador.Text = objCompraBLL.ContadorProdcutos(objOrdenCompra.tablaProductos)
    End Sub
    Public Sub cargarOrdenEncabezado()
        Dim params As New List(Of String)
        Dim fila As DataRow

        params.Add(objOrdenCompra.codigoCompra)
        fila = General.cargarItem(Consultas.CARGAR_ENCABEZADO_ORDEN_COMPRA, params)

        objOrdenCompra.codigoCompraPunto = fila.Item("Codigo_Orden_Punto")
        objOrdenCompra.codigoProveedor = fila.Item("Id_proveedor")
        txtproveedor.Text = fila.Item("Proveedor")
        objOrdenCompra.emailProveedor = fila.Item("email")
        objOrdenCompra.estado = fila.Item("estado")
        txtformadepago.Text = fila.Item("Forma_Pago")
        objOrdenCompra.fechaCompra = fila.Item("Fecha_Orden")
        objOrdenCompra.fechaEntrega = fila.Item("Fecha_Entrega")
        objOrdenCompra.observacionCompra = fila.Item("Observaciones")
        objOrdenCompra.diasEntregaProveedor = fila.Item("Dias")
        objOrdenCompra.cuentaCobro = If(IsDBNull(fila.Item("Cuenta_Cobro")), False, fila.Item("Cuenta_Cobro"))
        RbCosto.Checked = False
        RbPro.Checked = True
        General.llenarTabla(Consultas.CARGAR_DETALLE_ORDEN_COMPRA, params, objOrdenCompra.tablaProductos)
        empalmarObjetoToDiseño()
        btimprimir.Enabled = True
        btEnviarCorreos.Enabled = True
        contarProductos()
    End Sub
    Sub deshabilitarControlesInternos()
        txtestado.ReadOnly = True
        txtidproveedor.ReadOnly = True
        txtproveedor.ReadOnly = True
        txtformadepago.ReadOnly = True
        MtxtfechaOrden.Enabled = False
        MtxtEspera.Enabled = False
        txtbruto.ReadOnly = True
        txtiva.ReadOnly = True
        txtdescuento.ReadOnly = True
        txttotal.ReadOnly = True
    End Sub
    Private Sub anularOrdenCompra(objCompraBLL As OrdenCompraBLL)
        Try
            If objCompraBLL.anularCompra(objOrdenCompra, SesionActual.idUsuario) Then
                General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
            Else
                MsgBox("Esta orden no se puede anular !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Sub guardarCompra()
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Dim objOrdenCompraBALL As New OrdenCompraBLL
            empalmarDiseñoToObjeto()

            If MsgBox("¿ Desea Actualizar la lista Precio ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                objOrdenCompra.actualizarLista = True
            Else
                objOrdenCompra.actualizarLista = False
            End If

            Try
                objOrdenCompraBALL.guardarCompra(objOrdenCompra, SesionActual.idUsuario, SesionActual.codigoEP)
                General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                cargarOrdenEncabezado()
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
            End If
    End Sub
    Sub nuevaOrdenCompra()
        General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
        deshabilitarControlesInternos()
        Btbuscar_proveedores.Enabled = True
        RbCosto.Enabled = True
        RbPro.Enabled = True
        objOrdenCompra.tablaProductos.Rows.Add()
        Btbuscar_proveedores.Focus()
    End Sub
    Public Sub quitarFilas(ByRef objOrdenCompra As Compra,
                           ByRef e As DataGridViewCellEventArgs)
        Funciones.quitarFilas(objOrdenCompra.tablaProductos, e.RowIndex)
    End Sub
    Sub buscarProductos()
        Dim params As New List(Of String)
        params.Add(txtidproveedor.Text)
        params.Add(If(RbCosto.Checked, "Costo", "Proveedor"))
        params.Add(SesionActual.codigoEP)

        General.busquedaItems(Consultas.BUSQUEDA_PRODUCTOS_POR_PROVEEDOR,
                              params,
                              TitulosForm.BUSQUEDA_PRODUCTOS_INDIVIDUAL_CONTEO,
                              dgvproductos,
                              objOrdenCompra.tablaProductos,
                              0,
                              8,
                              dgvproductos.Columns("Cantidad").Index,
                              False,
                              True,
                              0,
                              True,
                              Nothing)
    End Sub
    Shared Sub iniciarEnvioCorreo(ByRef pCorreo As Correo)
        If Not IsNothing(hilo) Then
            If hilo.IsAlive Then
                MsgBox("Ya esta en proceso un envio, debe esperar para volver a enviar un nuevo correo!", MsgBoxStyle.Critical)
            Else
                iniciarHilo(pCorreo)
            End If
        Else
            iniciarHilo(pCorreo)
        End If
    End Sub
    Shared Sub iniciarHilo(ByRef pCorreo As Correo)
        Try
            hilo = New System.Threading.Thread(AddressOf OrdenCompra.enviarCorreo)
            hilo.Start(pCorreo)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
#Region "Botones"
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            nuevaOrdenCompra()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub Btbuscar_proveedores_Click(sender As Object, e As EventArgs) Handles Btbuscar_proveedores.Click
        If SesionActual.tienePermiso(pbuscar_proveedor) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.idEmpresa)
            params.Add(Nothing)
            General.buscarItem(Consultas.BUSQUEDA_PROVEEDOR_COMPRA,
                               params,
                               AddressOf cargarProveedor,
                               TitulosForm.BUSQUEDA_PROVEEDOR,
                               False,
                               True,
                               Constantes.TAMANO_MEDIANO)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add(Nothing)
            params.Add(SesionActual.codigoEP)
            General.buscarElemento(Consultas.BUSQUEDA_ORDEN_COMPRA,
                                   params,
                                   AddressOf cargarCompra,
                                   TitulosForm.BUSQUEDA_ORDEN_COMPRA,
                                   True,
                                   Constantes.TAMANO_MEDIANO,
                                   True)

        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If txtestado.Text = General.getEstadoInventario(Constantes.PENDIENTE) Then
                If General.fnFormEditar(Me, ToolStrip1, btguardar, btcancelar) Then
                    deshabilitarControlesInternos()
                    objOrdenCompra.tablaProductos.Rows.Add()
                End If
            Else
                MsgBox("Esta orden no se puede editar ya que tiene recepción técnica !", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim objCompraBLL As New OrdenCompraBLL
                anularOrdenCompra(objCompraBLL)
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        configurarImpresion()
    End Sub
    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        For Each correoConfigurado As Correo In cmbCorreos.Tag
            If cmbCorreos.SelectedItem = correoConfigurado.correo Then
                pnlUsuarioPass.Visible = False
                iniciarEnvioCorreo(correoConfigurado)
            End If
        Next
    End Sub
    Shared Function generarReporte(ByVal correoConfigurado As Correo, ByRef compra As Compra, ByVal total As String) As Boolean
        Dim params As New List(Of Object)
        params.Add(total)
        Return generarReporteOrdenCompra(compra.codigoCompra, compra.codigoProveedor, correoConfigurado.rutaArchivo, params)
    End Function
    Shared Sub enviarCorreo(ByVal correoConfigurado As Correo)
        correoConfigurado.asunto += "No." & objOrdenCompra.codigoCompraPunto
        General.ConfigurarCorreo(correoConfigurado,
                                 Constantes.FORMULARIO.ORDEN_COMPRA,
                                 "",
                                 objOrdenCompra.emailProveedor)
        Try
            If generarReporte(correoConfigurado, objOrdenCompra, txttotal.Text) AndAlso Funciones.enviarCorreo(correoConfigurado) Then
                MsgBox("Correo enviado !", MsgBoxStyle.Information)
            Else
                MsgBox("Correo no enviado !", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Shared Function generarReporteOrdenCompra(ByVal CodigoOrden As String, ByVal proveedor As Integer, Optional ruta As String = "", Optional ByRef params As List(Of Object) = Nothing) As Boolean
        Try
            Dim nombreOdenCompra As String = "Orden_" & proveedor & Constantes.FORMATO_PDF
            Dim rprte As New RPT_ORDEN_COMPRA

            Dim tbl As New Hashtable
            If Not IsNothing(params) Then
                Dim Convertir As New ConvertirNumeros
                tbl.Add("valor_en_letras", FuncionesContables.Convertir_Numero(params.Item(0)))
            Else
                tbl = Nothing
            End If
            Funciones.getReporteNoFTP(rprte, "{VISTA_ORDEN_COMPRA_ENBEZADO.codigo_orden} =" & CodigoOrden,
                                      "OrdenCompra",
                                      Constantes.FORMATO_PDF,
                                      tbl,
                                      If(ruta = "", Nothing, ruta & "\" & nombreOdenCompra),
                                      False)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarFormulario(objOrdenCompra) Then
            guardarCompra()
        End If
    End Sub
    Private Sub btSalir_Click(sender As Object, e As EventArgs)
        mostarOcultarPanel()
    End Sub
#End Region
#Region "Eventos Datagridview"
    Private Sub dgvproductos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvproductos.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
    End Sub
    Private Sub dgvproductos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvproductos.DataError
        e.Cancel = False
    End Sub
    Private Sub dgvproductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellDoubleClick
        If btguardar.Enabled = True Then
            If txtidproveedor.Text <> "" Then
                If Funciones.filaValida(e.RowIndex) AndAlso (Funciones.verificacionPosicionActual(dgvproductos, e, "ANULAR") AndAlso dgvproductos.Rows(e.RowIndex).Cells("Codigo").Value.ToString <> "") Then
                    quitarFilas(objOrdenCompra, e)
                ElseIf (Funciones.verificacionPosicionActual(dgvproductos, e, "Descripcion") OrElse (Funciones.verificacionPosicionActual(dgvproductos, e, "Codigo"))) Then
                    buscarProductos()
                End If
            Else
                MsgBox("Debe escoger el proveedor antes de selecionar los productos ! ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub
    Private Sub dgvproductos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellEndEdit
        If String.IsNullOrEmpty(dgvproductos.Rows(e.RowIndex).Cells("Cantidad").Value.ToString) Then
            dgvproductos.Rows(e.RowIndex).Cells("Cantidad").Value = 0
        End If
        objOrdenCompra.tablaProductos.AcceptChanges()
    End Sub
    Private Sub btSalirPanel_Click(sender As Object, e As EventArgs) Handles btSalirPanel.Click
        pnlUsuarioPass.Visible = Not pnlUsuarioPass.Visible
    End Sub
    Private Sub btEnviarCorreos_Click(sender As Object, e As EventArgs) Handles btEnviarCorreos.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim correoConfigurado As Correo
            Dim listaCorreos As New List(Of Correo)

            listaCorreos = General.cargarInformacionCorreo(Me.Tag.codigo)
            If Not IsNothing(listaCorreos) Then
                If listaCorreos.Count > 1 Then
                    pnlUsuarioPass.Visible = True
                    cmbCorreos.Items.Clear()
                    For Each correo As Correo In listaCorreos
                        cmbCorreos.Items.Add(correo.correo)
                    Next
                    cmbCorreos.Tag = listaCorreos
                    cmbCorreos.Enabled = True
                    btnEnviar.Enabled = True
                    btSalirPanel.Enabled = True
                    cmbCorreos.SelectedIndex = 0
                Else
                    correoConfigurado = New Correo
                    correoConfigurado = listaCorreos.First()
                    iniciarEnvioCorreo(correoConfigurado)
                End If
            Else
                MsgBox("Aún no tiene configurado ningún correo para este formulario!", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub dgvproductos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellEnter
        dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = validarCeldaActual(dgvproductos, e, btguardar)
    End Sub
    Private Sub dgvproductos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvproductos.KeyDown
        If btguardar.Enabled = True Then
            If e.KeyCode = Keys.F3 Then
                If txtproveedor.Text = "" Then
                    MsgBox("Debe escoger el proveedor antes de selecionar los productos ! ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                ElseIf dgvproductos.CurrentCell.ColumnIndex = dgvproductos.Columns("Codigo").Index OrElse dgvproductos.CurrentCell.ColumnIndex = dgvproductos.Columns("Descripcion").Index Then
                    buscarProductos()
                End If
            End If
        End If
    End Sub
#End Region
#Region "Funciones"
    Function validarCeldaActual(ByVal dgvProductos As DataGridView,
                                ByRef e As DataGridViewCellEventArgs,
                                ByRef btnGuardar As ToolStripButton)
        If Funciones.filaValida(e.RowIndex) AndAlso (Funciones.validarCeldaActiva(dgvProductos, e, "Cantidad", btnGuardar) OrElse
                                                     Funciones.validarCeldaActiva(dgvProductos, e, "Descuento", btnGuardar) OrElse
                                                     Funciones.validarCeldaActiva(dgvProductos, e, "Costo", btnGuardar)) AndAlso
                                                     e.RowIndex < dgvProductos.RowCount - 1 Then
            Return False
        Else
            Return True
        End If
    End Function
    Function validarFormulario(ByRef objOrdenCompra As Compra) As Boolean
        If txtidproveedor.Text = "" Then
            MsgBox("Debe escoger el proveedor para realizar la orden !!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            txtidproveedor.Focus()
            Return False
        ElseIf objOrdenCompra.tablaProductos.Select("cantidad= 0 and codigo<> '' ", "").Count > 0 Then
            MsgBox("Debe colocar cantidades a ordenar, correctas !!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            dgvproductos.Focus()
            Return False
        ElseIf objOrdenCompra.tablaProductos.Rows.Count = 1 Then
            MsgBox("Debe escoger por lo menos 1 producto para realizar la orden !!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            dgvproductos.Focus()
            Return False
        End If
        Return True
    End Function
#End Region
End Class