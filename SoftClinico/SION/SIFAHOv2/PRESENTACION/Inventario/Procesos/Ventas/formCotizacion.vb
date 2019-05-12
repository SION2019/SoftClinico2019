Public Class formCotizacion

    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, pBuscarCliente As String
    Dim objCoti As Cotizacion
    Dim cmd As New CotizacionBLL
    Private Sub formCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarForm()
    End Sub
    Sub inicializarForm()
        Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        objCoti = New Cotizacion
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        pBuscarCliente = permiso_general & "pp" & "05"
        General.formatDatePicker(dpFecha, objCoti.fecha)
        enlazardgv()
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
#Region "Metodo"
    Sub asignarValores(ByVal tipo As Boolean)
        General.calculosProcesoInventario(objCoti.tblProductos,
                                          objCoti.tblProductos.Columns("Cantidad").ColumnName,
                                          objCoti.tblProductos.Columns("Precio").ColumnName,
                                          objCoti.tblProductos.Columns("Total").ColumnName,
                                          objCoti.tblProductos.Columns("Iva").ColumnName,
                                          objCoti.tblProductos.Columns("ValorIva").ColumnName,
                                          objCoti.tblProductos.Columns("Descuento").ColumnName,
                                          objCoti.tblProductos.Columns("ValorDescuento").ColumnName,
                                          tipo)
        txtbruto.Text = FormatCurrency(If(IsDBNull(objCoti.tblProductos.Compute("Sum(Total)", "")), 0, objCoti.tblProductos.Compute("Sum(Total)", "")), 2)
        txtiva.Text = FormatCurrency(If(IsDBNull(objCoti.tblProductos.Compute("Sum(ValorIva)", "")), 0, objCoti.tblProductos.Compute("Sum(ValorIva)", "")), 2)
        txtdescuento.Text = FormatCurrency(If(IsDBNull(objCoti.tblProductos.Compute("Sum(ValorDescuento)", "")), 0, objCoti.tblProductos.Compute("Sum(ValorDescuento)", "")), 2)
        txttotal.Text = FormatCurrency((CDbl(txtbruto.Text) + CDbl(txtiva.Text)) - CDbl(txtdescuento.Text), 2)
    End Sub
    Sub buscarProductos()
        If txtCodigoCliente.Text = "" Then
            MsgBox("Debe escoger al cliente ante de escoger los productos ", MsgBoxStyle.Exclamation)
        Else
            Dim params As New List(Of String)
            params.Add(txtCodigoCliente.Text)
            params.Add(SesionActual.codigoEP)
          

            General.busquedaItems(Consultas.BUSQUEDA_COTIZACION_PRODUCTOS,
                                 params,
                                 TitulosForm.BUSQUEDA_PRODUCTOS,
                                 dgvproductos,
                                 objCoti.tblProductos,
                                 0,
                                 5,
                                 dgvproductos.Columns("Cantidad").Index,
                                 False,
                                 True ,
                                 0,
                                 False,
                                 Nothing)

        End If
    End Sub
    Function validarFormulario()
        objCoti.tblProductos.AcceptChanges()
        If txtCodigoCliente.Text = "" Then
            MsgBox("Debe escoger el cliente ", MsgBoxStyle.Exclamation)
            Btbuscar_proveedores.Focus()
            Return False
        ElseIf objCoti.tblProductos.Select("cantidad= 0", "").Count > 1 Then
            MsgBox("Debe colocar las cantidades a los productos ", MsgBoxStyle.Exclamation)
            dgvproductos.Focus()
            Return False
        End If
        Return True
    End Function
    Sub cargarCotizacion(ByVal codigo As Integer)
        Dim params As New List(Of String)
        params.Add(codigo)
        Dim fila As DataRow = General.cargarItem(Consultas.BUSQUEDA_COTIZACION_INDIVIDUAL, params)
        objCoti.codigoCotizacion = fila.Item("Codigo_Cotizacion")
        objCoti.codigoCotizacionPunto = fila.Item("Codigo")
        objCoti.codigoCliente = fila.Item("id_cliente")
        objCoti.fecha = fila.Item("Fecha")
        objCoti.observacion = fila.Item("Observaciones")
        objCoti.estado = fila.Item("Estado")
        empalmarObjetoToDiseno()
        cargarCliente(objCoti.codigoCliente)
        params.Clear()
        params.Add(objCoti.codigoCotizacion)
        General.llenarTabla(Consultas.BUSQUEDA_COTIZACION_INDIVIDUAL_DETALLE, params, objCoti.tblProductos)
        asignarValores(True)
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
        btimprimir.Enabled = True
    End Sub
    Sub empalmarObjetoToDiseno()
        txtcodigo.Text = objCoti.codigoCotizacionPunto
        dpFecha.Value = objCoti.fecha
        txtestado.Text = If(objCoti.estado = Constantes.PENDIENTE, General.getEstadoInventario(Constantes.PENDIENTE), General.getEstadoInventario(Constantes.TERMINADO))
        txtCodigoCliente.Text = objCoti.codigoCliente
        txtObservaciones.Text = objCoti.observacion
    End Sub
    Sub empalmarDisenoToObjeto()
        objCoti.codigoCotizacionPunto = txtcodigo.Text
        objCoti.fecha = dpFecha.Value
        objCoti.estado = General.getEstadoInventarioString(txtestado.Text)
        objCoti.codigoCliente = txtCodigoCliente.Text
        objCoti.observacion = txtObservaciones.Text
    End Sub
    Sub guardar()
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Try
                empalmarDisenoToObjeto()
                Dim objetoCotizacionBLL As New CotizacionBLL
                If validarFormulario() Then
                    objetoCotizacionBLL.persistirDatos(objCoti, SesionActual.idUsuario)
                    General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                    cargarCotizacion(objCoti.codigoCotizacion)
                End If
            Catch ex As Exception
                general.manejoErrores(ex)
            End Try

        End If
    End Sub
    Sub deshabiliatrControlesInternos()
        txtestado.ReadOnly = True
        txtNombreCliente.ReadOnly = True
        txtbruto.ReadOnly = True
        txtiva.ReadOnly = True
        txtdescuento.ReadOnly = True
        txttotal.ReadOnly = True
    End Sub
    Sub enlazardgv()
        With dgvproductos
            .Columns("Codigo").DataPropertyName = "Codigo"
            .Columns("Codigo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").DataPropertyName = "Descripcion"
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Marca").DataPropertyName = "Marca"
            .Columns("Marca").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Iva").DataPropertyName = "Iva"
            .Columns("Iva").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descuento").DataPropertyName = "Descuento"
            .Columns("Descuento").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cantidad").DataPropertyName = "Cantidad"
            .Columns("Cantidad").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Stock").DataPropertyName = "Stock"
            .Columns("Stock").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Precio").DataPropertyName = "Precio"
            .Columns("Precio").SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoGenerateColumns = False
            .DataSource = objCoti.tblProductos
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With
    End Sub
    Public Sub cargarCliente(ByVal codigo As String)
        objCoti.codigoCliente = codigo
        Dim params As New List(Of String)
        params.Add(objCoti.codigoCliente)
        params.Add(SesionActual.idEmpresa)
        Dim fila As DataRow
        fila = General.cargarItem(Consultas.BUSQUEDA_CLIENTES_INDIVIDUAL, params)
        txtCodigoCliente.Text = fila.Item(0)
        txtNombreCliente.Text = fila.Item(3)
        objCoti.tblProductos.Clear()
        objCoti.tblProductos.Rows.Add()
    End Sub
    Public Sub cargarCotiza(pCodigo As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.BUSQUEDA_LISTAR_COTI_CLIENTE, params, dt)
        txtCodigoCliente.Text = pCodigo
        txtNombreCliente.Text = dt.Rows(0).Item("Nombre").ToString
    End Sub

#End Region
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
#Region "Eventos de la dgv"
    Private Sub dgvproductos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvproductos.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
    End Sub
    Private Sub dgvproductos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvproductos.KeyDown
        If e.KeyCode = Keys.F3 AndAlso dgvproductos.Columns("ANULAR").Index <> dgvproductos.CurrentCell.ColumnIndex Then
            buscarProductos()
        End If
    End Sub
    Private Sub dgvproductos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellEnter
        dgvproductos.ReadOnly = False
        If (dgvproductos.Columns("Descuento").Index = e.ColumnIndex OrElse
            dgvproductos.Columns("Cantidad").Index = e.ColumnIndex OrElse
            dgvproductos.Columns("Precio").Index = e.ColumnIndex) And
            e.RowIndex < dgvproductos.Rows.Count - 1 And txtestado.Text = General.getEstadoInventario(Constantes.PENDIENTE) And btguardar.Enabled = True Then
            dgvproductos.Columns(e.ColumnIndex).ReadOnly = False
        Else
            dgvproductos.Columns(e.ColumnIndex).ReadOnly = True
        End If
    End Sub
    Private Sub dgvproductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellDoubleClick
        If btguardar.Enabled = True Then
            If dgvproductos.Columns(TitulosForm.ANULAR).Index = e.ColumnIndex AndAlso e.RowIndex < dgvproductos.RowCount - 1 Then
                If txtcodigo.Text = "" Then
                    If MsgBox(Mensajes.QUITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        objCoti.tblProductos.Rows.RemoveAt(dgvproductos.CurrentRow.Index)
                    End If
                Else
                    If cmd.verificarAnular(objCoti.codigoCotizacion) = True AndAlso cmd.verificarAnularIndividual(objCoti.codigoCotizacion) = True Then
                        If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            General.anularRegistro(
                                Consultas.ANULAR_PRODUCTO_INDIVIDUAL_COTIZACION & " " & objCoti.codigoCotizacion & "," & objCoti.tblProductos.Rows(dgvproductos.CurrentRow.Index).Item("Codigo") & "," & SesionActual.idUsuario)
                            objCoti.tblProductos.Rows.RemoveAt(dgvproductos.CurrentRow.Index)
                        End If
                    Else
                        MsgBox("No se puede anular este producto", MsgBoxStyle.Exclamation)
                    End If
                End If
                asignarValores(False)
            ElseIf Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Codigo", dgvproductos) OrElse
                   Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Descripcion", dgvproductos) Then
                buscarProductos()
            End If
        End If
    End Sub
    Private Sub dgvproductos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellEndEdit
        Try
            If dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Equals("") Then
                dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
            End If
            asignarValores(False)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
#End Region

#Region "Eventos de los botones"
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                If General.anularRegistro(Consultas.ANULAR_COTIZACION & " " & objCoti.codigoCotizacion & "," & SesionActual.idUsuario) Then
                    General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                End If
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If txtcodigo.Text = "" Then
            MsgBox("Debe elegir una orden para imprimir !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        Else
            Try
                Cursor = Cursors.WaitCursor
                Dim rprte As New rptCotizacion
                Dim Convertir As New ConvertirNumeros
                Dim tbl As New Hashtable
                Dim valor As Double = CDbl(txttotal.Text)
                tbl.Add("valor_en_letras", FuncionesContables.Convertir_Numero(valor))
                Funciones.getReporteNoFTP(rprte, "{I_COTIZACION.Codigo_Cotizacion} =" & objCoti.codigoCotizacion,
                                          "Cotizacion",
                                          Constantes.FORMATO_PDF,
                                          tbl)
                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
    Private Sub Btbuscar_proveedores_Click(sender As Object, e As EventArgs) Handles Btbuscar_proveedores.Click
        If SesionActual.tienePermiso(pBuscarCliente) Then
            Dim params As New List(Of String)
            params.Add(Nothing)
            params.Add(SesionActual.idEmpresa)
            General.buscarElemento(Consultas.LISTA_CLIENTE,
                                   params,
                                   AddressOf cargarCotiza,
                                   TitulosForm.BUSQUEDA_CLIENTES_COTIZACION,
                                   True,
                                   Constantes.TAMANO_MEDIANO,
                                   True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            txtestado.Text = General.getEstadoInventario(Constantes.PENDIENTE)
            deshabiliatrControlesInternos()
            Btbuscar_proveedores.Focus()
            objCoti.tblProductos.Rows.Add()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarFormulario() = True Then
            guardar()
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add(Nothing)
            params.Add(SesionActual.codigoEP)
            General.buscarElemento(Consultas.BUSQUEDA_COTIZACION,
                                   params,
                                   AddressOf cargarCotizacion,
                                   TitulosForm.BUSQUEDA_COTIZACION,
                                   True,
                                   Constantes.TAMANO_MEDIANO,
                                   True
                                    )
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If cmd.verificarAnular(objCoti.codigoCotizacion) = True Then
                If General.fnFormEditar(Me, ToolStrip1, btguardar, btcancelar) = True Then
                    deshabiliatrControlesInternos()
                    Btbuscar_proveedores.Enabled = True
                    objCoti.tblProductos.Rows.Add()
                End If
                Btbuscar_proveedores.Enabled = False
            Else
                MsgBox("No se puede editar")
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
#End Region
End Class