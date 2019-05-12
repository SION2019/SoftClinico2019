Public Class FormCuentaCobro
    Dim objCuentaCobro As New CuentaCobro
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, PBuscarOrdenCompra As String
    Private Sub FormCuentaCobro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarForm()
    End Sub
    Private Sub txtcodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcodigo.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub
    Private Sub FormCuentaCobro_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
#Region "Botones"
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            inhabilitarControlesInternos()
            objCuentaCobro.codigoCuentaCobro = ""
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub Btbuscar_proveedores_Click(sender As Object, e As EventArgs) Handles Btbuscar_proveedores.Click
        If SesionActual.tienePermiso(PBuscarOrdenCompra) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.codigoEP)
            params.Add(Nothing)
            General.buscarItem(Consultas.CUENTA_COBRO_BUSCAR_ORDEN_COMPRA,
                               params,
                               AddressOf cargagarOrdenCompra,
                               TitulosForm.BUSQUEDA_PROVEEDOR,
                               True,
                               True,
                               Constantes.TAMANO_MEDIANO)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar) Then
            objCuentaCobro.codigoCuentaCobro = ""
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarDatosFormulario() AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                Dim objCuentaCobroBLL As New CuentaCobroBLL
                empalmarDisenioToObjeto()
                objCuentaCobroBLL.guardarCuentaCobro(objCuentaCobro, SesionActual.idUsuario)
                General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                cargarCuentaCobro(objCuentaCobro.codigoCuentaCobro)
            Catch ex As Exception
                general.manejoErrores(ex)
            End Try
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.codigoEP)
            params.Add(Nothing)
            General.buscarElemento(Consultas.CUENTA_COBRO_BUSCAR,
                                   params,
                                   AddressOf cargarCuentaCobro,
                                   TitulosForm.BUSQUEDA_CUENTA_COBRO,
                                   True,
                                   Constantes.TAMANO_MEDIANO,
                                   True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim objCuentaCobroBLL As New CuentaCobroBLL
                Try
                    objCuentaCobroBLL.anularCuentaCobro(objCuentaCobro, SesionActual.idUsuario)
                    General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                Catch ex As Exception
                    general.manejoErrores(ex)
                End Try
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Sub cargarCuentaCobro(pCodigo As String)
        objCuentaCobro.codigoCuentaCobro = pCodigo
        Dim params As New List(Of String)
        Dim fila As DataRow
        params.Add(objCuentaCobro.codigoCuentaCobro)
        fila = General.cargarItem(Consultas.CUENTA_COBRO_CARGAR_CUENTA_COBRO, params)
        If Not IsNothing(fila) Then
            objCuentaCobro.codigoCuentaCobro = fila.Item(0)
            objCuentaCobro.consecutivoInterno = fila.Item(1)
            objCuentaCobro.fechaCuentaCobro = fila.Item(2)
            objCuentaCobro.codigoOrden = fila.Item(3)
            objCuentaCobro.codigoOrdenPunto = fila.Item(4)
        End If

        cargarEncabezadoOrdenCompra()
        General.llenarTabla(Consultas.CUENTA_COBRO_CARGAR_CUENTA_COBRO_DETALLE, params, objCuentaCobro.tablaCuentaCobro)
        empalmarObjetoToDisenio()
        totalizarCuentaCobro()
        General.posBuscarForm(Me, ToolStrip1, bteditar, btanular, btnuevo, btbuscar)
        btimprimir.Enabled = True
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If General.fnFormEditar(Me, ToolStrip1, btguardar, btcancelar) Then
                inhabilitarControlesInternos()
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
#End Region
#Region "Eventos de la grilla"
    Private Sub dgvproductos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellEnter
        If Funciones.filaValida(e.RowIndex) Then
            dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = validarCeldaActual(dgvproductos, e, btguardar)
        End If
    End Sub
    Private Sub dgvproductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellClick
        If Funciones.filaValida(e.RowIndex) Then
            dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = validarCeldaActual(dgvproductos, e, btguardar)
        End If
    End Sub
    Private Sub dgvproductos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvproductos.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
    End Sub
    Private Sub dgvproductos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvproductos.DataError
        e.Cancel = True
    End Sub
    Private Sub dgvproductos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellEndEdit
        If Funciones.filaValida(e.RowIndex) Then
            If dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString = "" Then
                dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
            End If
            Dim filas = objCuentaCobro.tablaCuentaCobro.Rows
            If filas(e.RowIndex).Item("CantFac") > filas(e.RowIndex).Item("Cant") Then
                filas(e.RowIndex).Item("CantFac") = 0
                MsgBox("La cantidad factura no puede ser mayor a la cantidad ordenada ! ", MsgBoxStyle.Exclamation)
            End If
        End If
        totalizarCuentaCobro()
    End Sub
    Private Sub dgvproductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellDoubleClick
        If btguardar.Enabled = True Then
            If Funciones.filaValida(e.RowIndex) AndAlso
               (Funciones.verificacionPosicionActual(dgvproductos, e, "ANULAR") AndAlso dgvproductos.Rows(e.RowIndex).Cells("Codigo").Value.ToString <> "") Then
                quitarFilas(objCuentaCobro.tablaCuentaCobro, e)
            End If
        End If
    End Sub
#End Region
#Region "Metodos"
    Sub empalmarObjetoToDisenio()
        txtcodigo.Text = objCuentaCobro.consecutivoInterno
        dtFechaCuentaCobro.Value = objCuentaCobro.fechaCuentaCobro
    End Sub
    Sub empalmarDisenioToObjeto()
        objCuentaCobro.consecutivoInterno = txtcodigo.Text
        objCuentaCobro.fechaCuentaCobro = dtFechaCuentaCobro.Value
    End Sub
    Sub verificarExistenciaConsecutivo()
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        params.Add(txtidproveedor.Text)
        Dim resultadoFila As DataRow = General.cargarItem(Consultas.CUENTA_COBRO_VERIFICAR_EXISTENCIA_CONSECUTIVO, params)
        txtcodigo.ResetText()
        If Not IsNothing(resultadoFila) Then
            If Not IsDBNull(resultadoFila.Item(0)) Then
                txtcodigo.Text = resultadoFila.Item(0)
                txtcodigo.ReadOnly = True
                Return
            End If
        End If
        txtcodigo.ReadOnly = False
        dgvproductos.Focus()

    End Sub
    Sub inhabilitarControlesInternos()
        txtidproveedor.ReadOnly = True
        txtproveedor.ReadOnly = True
        txtformadepago.ReadOnly = True
        MtxtfechaOrden.Enabled = False
        txtObservaciones.ReadOnly = True
        txtTotal.ReadOnly = True
    End Sub
    Sub inicializarForm()
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        PBuscarOrdenCompra = permiso_general & "pp" & "05"
        totalizarCuentaCobro()
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
        enlazarGrilla()
    End Sub
    Sub totalizarCuentaCobro()
        Try
            Dim total? As Double
            objCuentaCobro.tablaCuentaCobro.AcceptChanges()
            If objCuentaCobro.tablaCuentaCobro.Rows.Count = 0 Then
                total = 0
            Else
                total = Format(If(IsNothing(objCuentaCobro.tablaCuentaCobro.Compute("Sum(Total)", "")), 0, objCuentaCobro.tablaCuentaCobro.Compute("Sum(Total)", "")), "C2")
            End If
            txtTotal.Text = Format(Total, "C2")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub enlazarGrilla()
        With dgvproductos
            .Columns("Codigo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigo").DataPropertyName = "Codigo_Producto"
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").DataPropertyName = "Descripcion"
            .Columns("Marca").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Marca").DataPropertyName = "Marca"
            .Columns("Presentacion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Presentacion").DataPropertyName = "Presentacion"
            .Columns("Cantidad").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cantidad").DataPropertyName = "Cant"
            .Columns("CantFac").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantFac").DataPropertyName = "CantFac"
            .Columns("CantFal").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantFal").DataPropertyName = "CantFal"
            .Columns("Costo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Costo").DataPropertyName = "Valor"
            .Columns("Total").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Total").DataPropertyName = "Total"
            .ReadOnly = True
            .AutoGenerateColumns = False
            .DataSource = objCuentaCobro.tablaCuentaCobro
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With
    End Sub
    Public Sub quitarFilas(ByRef tbl As DataTable,
                           ByRef e As DataGridViewCellEventArgs)
        Funciones.quitarFilas(tbl, e.RowIndex)
    End Sub
    Sub cargagarOrdenCompra(ByVal fila As DataRow)
        objCuentaCobro.codigoOrden = fila.Item(0)
        objCuentaCobro.codigoOrdenPunto = fila.Item(1)
        cargarEncabezadoOrdenCompra()
        cargarDetalleOrdenCompra()
        verificarExistenciaConsecutivo()
        totalizarCuentaCobro()
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If txtcodigo.Text = "" Then
            MsgBox("Debe elegir una orden para imprimir !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        Else
            Try
                Cursor = Cursors.WaitCursor
                Dim rprte As New rptCuentaCobro
                Dim Convertir As New ConvertirNumeros
                Dim tbl As New Hashtable
                Dim valor As Double = CDbl(txtTotal.Text)
                tbl.Add("valorEnLetras", FuncionesContables.Convertir_Numero(valor))
                tbl.Add("Empresa", SesionActual.idEmpresa)
                tbl.Add("@pCodigo", objCuentaCobro.codigoCuentaCobro)
                Funciones.getReporteNoFTP(rprte, Nothing, "CuentaCobro", Constantes.FORMATO_PDF, tbl)
                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
                general.manejoErrores(ex)
            End Try
        End If
    End Sub

    Sub cargarEncabezadoOrdenCompra()
        Dim params As New List(Of String)
        params.Add(objCuentaCobro.codigoOrden)
        Dim filaRegistro As DataRow
        filaRegistro = General.cargarItem(Consultas.CUENTA_COBRO_CARGAR_ORDEN_COMPRA, params)
        txtcodigoOrden.Text = objCuentaCobro.codigoOrdenPunto
        txtidproveedor.Text = filaRegistro.Item(0)
        txtproveedor.Text = filaRegistro.Item(1)
        txtformadepago.Text = filaRegistro.Item(2)
        MtxtfechaOrden.Value = filaRegistro.Item(3)
        txtObservaciones.Text = filaRegistro.Item(4)
    End Sub
    Sub cargarDetalleOrdenCompra()
        Dim params As New List(Of String)
        params.Add(objCuentaCobro.codigoOrden)
        General.llenarTabla(Consultas.CUENTA_COBRO_CARGAR_ORDEN_COMPRA_DETALLE, params, objCuentaCobro.tablaCuentaCobro)
    End Sub
#End Region
#Region "Funciones"
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Function validarCeldaActual(ByVal dgvProductos As DataGridView,
                                ByRef e As DataGridViewCellEventArgs,
                                ByRef btnGuardar As ToolStripButton)
        If Funciones.filaValida(e.RowIndex) AndAlso (Funciones.validarCeldaActiva(dgvProductos, e, "CantFac", btnGuardar) OrElse
                                                     Funciones.validarCeldaActiva(dgvProductos, e, "Costo", btnGuardar)) Then
            Return False
        Else
            Return True
        End If
    End Function
    Function validarDatosFormulario() As Boolean
        objCuentaCobro.tablaCuentaCobro.AcceptChanges()
        dgvproductos.EndEdit()
        dgvproductos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Dim resp As Boolean = False
        If txtcodigo.Text = "" Then
            MsgBox("Debe digitar el consecutivo de la factura!", MsgBoxStyle.Exclamation)
            Exec.SacudirCrtl(txtcodigo)
            txtcodigo.Focus()
            Return False
        ElseIf objCuentaCobro.tablaCuentaCobro.Rows.Count = objCuentaCobro.tablaCuentaCobro.Select("CantFac = 0").Count Then
            MsgBox("Debe colocar por lo menos 1 producto para generar la factura!", MsgBoxStyle.Exclamation)
            Exec.SacudirCrtl(dgvproductos)
            Return False
        Else
            Return True
        End If
    End Function
#End Region
End Class