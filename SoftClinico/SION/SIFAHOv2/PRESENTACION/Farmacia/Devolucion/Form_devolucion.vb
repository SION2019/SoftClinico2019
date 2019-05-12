Public Class Form_devolucion
    Dim objDevolucionPem As DevolucionPem
    Dim perG As New Buscar_Permisos_generales
    Dim permisoGeneral, pNuevo, pEditar, pAnular, pBuscar, PbuscarPem As String
#Region "Funciones"
    Function validarForm() As Boolean
        dgvproductos.EndEdit()
        dgvInsumos.EndEdit()
        objDevolucionPem.tablaMedicamentos.AcceptChanges()
        objDevolucionPem.tablaInsumos.AcceptChanges()
        If objDevolucionPem.tablaMedicamentos.Select("[Concentración_Devuelta] > 0 and bodega =''").Count > 0 Then
            MsgBox("Debe escoger la bodega de producción para la cual va el medicamento!", MsgBoxStyle.Exclamation)
            Return False
        ElseIf objDevolucionPem.tablaMedicamentos.Select("[Cantidad_Devuelta] > 0 and bodega =''").Count > 0 Then
            MsgBox("Debe escoger la bodega comercial para la cual va el medicamento!", MsgBoxStyle.Exclamation)
            Return False
        ElseIf objDevolucionPem.tablaMedicamentos.Select("bodega =''").Count = objDevolucionPem.tablaMedicamentos.Rows.Count And objDevolucionPem.tablaMedicamentos.Rows.Count > 0 Then
            MsgBox("Debe asignar la bodega destino de cada uno de los productos!", MsgBoxStyle.Exclamation)
            Return False
        ElseIf (objDevolucionPem.tablaMedicamentos.Select("[Cantidad_Devuelta] = 0 and [Concentración_Devuelta] = 0 ").Count = objDevolucionPem.tablaMedicamentos.Rows.Count) AndAlso (objDevolucionPem.tablaInsumos.Select("Cantidad_Devuelta = 0").Count = objDevolucionPem.tablaInsumos.Rows.Count) Then
            MsgBox("Debe colocar la cantidad o concentración de por lo menos un medicamento o insumo antes de guardar!", MsgBoxStyle.Exclamation)
            Return False
        End If
        Return True
    End Function
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Function activarCelda(ByRef e As DataGridViewCellEventArgs) As Boolean
        Dim valor As Boolean = True
        If Funciones.filaValida(e.RowIndex) AndAlso
          (Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Cantidad_Devuelta", dgvproductos) OrElse Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Concentración_devuelta", dgvproductos)) AndAlso
           btguardar.Enabled = True Then
            valor = False
        End If
        Return valor
        '  Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Concentración_Devuelta", dgvproductos))
    End Function
    Function contarNumeroColumnasDgv(ByRef dgv As DataGridView) As Boolean
        If dgv.Columns.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region
#Region "Metodos"
    Sub buscarBodegaLote(ByVal filaActual As Integer)
        Dim filaRegistroBodega As DataRow
        Dim params As New List(Of String)
        Dim filasTabla As DataRowCollection = objDevolucionPem.tablaMedicamentos.Rows
        params.Add(filasTabla(filaActual).Item("Reg_lote"))
        filaRegistroBodega = General.cargarItem(Consultas.DEVOLUCION_BUSCAR_BODEGA_REG_LOTE, params)
        cargarBodegaSeleccionada(filaRegistroBodega)

    End Sub
    Sub empalmarObjetoToDiseno()
        txtCodigo.Text = objDevolucionPem.codigoDevolucionPunto
        txtCodigoDespacho.Text = objDevolucionPem.codigoDespachoPunto
        txtCodigoPem.Text = objDevolucionPem.codigoPem
        rTxtObservacion.Text = objDevolucionPem.observacion
        dtpkFechaDevolucion.Value = objDevolucionPem.fechaDevolucion
    End Sub
    Sub empalmarDisenoToObjeto()
        objDevolucionPem.codigoDevolucionPunto = txtCodigo.Text
        objDevolucionPem.codigoDespacho = txtCodigoDespacho.Text
        objDevolucionPem.codigoPem = txtCodigoPem.Text
        objDevolucionPem.observacion = rTxtObservacion.Text
        objDevolucionPem.fechaDevolucion = dtpkFechaDevolucion.Value
    End Sub
    Sub inicializarForm()
        objDevolucionPem = New DevolucionPem
        permisoGeneral = perG.buscarPermisoGeneral(Name)
        pNuevo = permisoGeneral & "pp" & "01"
        pEditar = permisoGeneral & "pp" & "02"
        pAnular = permisoGeneral & "pp" & "03"
        pBuscar = permisoGeneral & "pp" & "04"
        PbuscarPem = permisoGeneral & "pp" & "05"
        limpiarControles()
        configurarDgv()
        deshabilitarControlesInternos()
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Sub deshabilitarControlesInternos()
        txtPaciente.ReadOnly = True
        txtContrato.ReadOnly = True
        txtCliente.ReadOnly = True
        txtAreaServicio.ReadOnly = True
        txtEdad.ReadOnly = True
    End Sub
    Sub CargarListadoPemAsociadoDespachoPem(ByVal codigoDespacho As Integer)
        txtCodigoPem.ResetText()
        limpiarControles()
        objDevolucionPem.codigoDespacho = codigoDespacho
        obtenerCodigoDespachoPemPunto()
        txtCodigoDespacho.Text = objDevolucionPem.codigoDespachoPunto
        limpiarControles()
    End Sub
    Sub obtenerCodigoDespachoPemPunto()
        Dim params As New List(Of String)
        params.Add(objDevolucionPem.codigoDespacho)
        Dim fila As DataRow
        fila = General.cargarItem(Consultas.DEVOLUCION_CODIGO_DESPACHO_PEM_PUNTO, params)
        If Not IsNothing(fila) Then
            objDevolucionPem.codigoDespachoPunto = fila.Item(0)
        End If
    End Sub
    Sub limpiarControles()
        objDevolucionPem.tablaInsumos.Clear()
        objDevolucionPem.tablaMedicamentos.Clear()
        txtPaciente.ResetText()
        txtContrato.ResetText()
        txtCliente.ResetText()
        txtEdad.ResetText()
        txtAreaServicio.ResetText()
    End Sub
    Sub llenarInformacionPem()
        Dim fila As DataRow = objDevolucionPem.llenarInformacionPem
        If Not IsNothing(fila) Then
            txtPaciente.Text = fila.Item(0).ToString.ToUpper
            txtContrato.Text = fila.Item(1).ToString.ToUpper
            txtCliente.Text = fila.Item(2).ToString.ToUpper
            txtAreaServicio.Text = fila.Item(3).ToString.ToUpper
            txtEdad.Text = fila.Item(4).ToString.ToUpper

        End If
    End Sub
    Sub cargarBodegaSeleccionada(ByVal fila As DataRow)
        If Not IsNothing(fila) Then
            objDevolucionPem.tablaMedicamentos.Rows(dgvproductos.CurrentRow.Index).Item("Codigo_Bodega") = fila.Item(0)
            objDevolucionPem.tablaMedicamentos.Rows(dgvproductos.CurrentRow.Index).Item("Bodega") = fila.Item(1)
        End If
    End Sub
    Sub configurarDgv()

        With dgvproductos
            .DataSource = objDevolucionPem.tablaMedicamentos
            If contarNumeroColumnasDgv(dgvproductos) Then
                .Columns("Concentración_Pedida").HeaderText = "Concentración Pedida"
                .Columns("Concentración_Despachada").HeaderText = "Concentración Despachada"
                .Columns("Cantidad_Pedida").HeaderText = "Cantidad Pedida"
                .Columns("Cantidad_Despachada").HeaderText = "Cantidad Despachada"
                .Columns("Cantidad_Devuelta").HeaderText = "Cantidad Dosis Devuelta"
                .Columns("Concentración_Devuelta").HeaderText = "Concentración Dosis Devuelta"
                .Columns("Cantidad_Dosis_Unitaria").HeaderText = "Cantidad Dosis Unitaria"
                .Columns("Concentracion_Dosis_Unitaria").HeaderText = "Concentracion Dosis Unitaria"
                .Columns("Cantidad_Pedida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Concentración_Pedida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Concentración_Despachada").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Cantidad_Pedida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Cantidad_Despachada").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Cantidad_Devuelta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Concentración_Devuelta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Cantidad_Dosis_Unitaria").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Concentracion_Dosis_Unitaria").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Cantidad_Devuelta").DefaultCellStyle.NullValue = 0
                .Columns("Concentración_Devuelta").DefaultCellStyle.NullValue = 0
                .Columns("Codigo_Bodega").Visible = False
                .Columns("Reg_lote").Visible = False
                .Columns("Desripción").Frozen = True
            End If
        End With

        With dgvInsumos
            .DataSource = objDevolucionPem.tablaInsumos
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            If contarNumeroColumnasDgv(dgvInsumos) Then
                .Columns("Cantidad_Pedida").HeaderText = "Cantidad Pedida"
                .Columns("Cantidad_Despachada").HeaderText = "Cantidad Despachada"
                .Columns("Cantidad_Devuelta").HeaderText = "Cantidad Devuelta"
                .Columns("Cantidad_Pedida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Cantidad_Despachada").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Cantidad_Devuelta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("reg_lote").Visible = False
                .Columns("Codigo_Bodega").Visible = False
                .Columns("Desripción").Frozen = True
            End If
        End With
        General.diseñoDGV(dgvInsumos)
        General.diseñoDGV(dgvproductos)
        autoAjustarColumnas()
    End Sub
    Sub autoAjustarColumnas()
        For Each col As DataGridViewColumn In dgvproductos.Columns
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
        For Each col As DataGridViewColumn In dgvInsumos.Columns
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
    End Sub
    Sub listarPemsDespachados()
        Dim params As New List(Of String)
        params.Add(objDevolucionPem.codigoDespacho)
        params.Add(Nothing)
        General.buscarElemento(Consultas.DEVOLUCION_LISTAR_PEMS,
                               params,
                               AddressOf cargarPem,
                               TitulosForm.BUSQUEDA_DEVOLUCION,
                               False,
                               Constantes.TAMANO_MEDIANO,
                               True)

    End Sub
    Sub cargarPem(ByVal codigoPem As Integer)
        objDevolucionPem.codigoPem = codigoPem
        txtCodigoPem.Text = codigoPem
        limpiarControles()
        objDevolucionPem.llenarDatosPem(objDevolucionPem.codigoPem)
        llenarInformacionPem()
        configurarDgv()
    End Sub
    Sub imprimir()
        Cursor = Cursors.WaitCursor
        Dim reporte As New rptDevolucion
        Try
            Dim tbl As New Hashtable
            tbl.Add("@pCodigoDevolucion", objDevolucionPem.codigoDevolucion)
            tbl.Add("@pPunto", SesionActual.codigoEP)
            Funciones.getReporteNoFTP(reporte, Nothing, "", Constantes.FORMATO_PDF, tbl)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub
    Sub limpiarBodegaFilaActual(ByVal filaActual As Integer)
        dgvproductos.Rows(filaActual).Cells("Codigo_Bodega").Value = ""
        dgvproductos.Rows(filaActual).Cells("Bodega").Value = ""
    End Sub
    Sub cargarDevolucion(ByVal codigo As String)
        objDevolucionPem.codigoDevolucion = codigo
        objDevolucionPem.cargarDevolcion()
        CargarListadoPemAsociadoDespachoPem(objDevolucionPem.codigoDespacho)
        empalmarObjetoToDiseno()
        llenarInformacionPem()
        objDevolucionPem.cargarDetalle()
        configurarDgv()
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, btanular, btimprimir)
    End Sub
#End Region
#Region "Botones"
    Private Sub btBuscarPem_Click(sender As Object, e As EventArgs) Handles btBuscarPem.Click
        listarPemsDespachados()
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(pNuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            deshabilitarControlesInternos()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub Btbuscar_proveedores_Click(sender As Object, e As EventArgs) Handles Btbuscar_proveedores.Click
        If SesionActual.tienePermiso(PbuscarPem) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.codigoEP)
            params.Add(Nothing)
            General.buscarElemento(Consultas.DEVOLUCION_PEM_BUSCAR_DESPACHO_PEM,
                                   params,
                                   AddressOf CargarListadoPemAsociadoDespachoPem,
                                   TitulosForm.BUSQUEDA_DESPACHO_PEM,
                                   True,
                                   Constantes.TAMANO_MEDIANO,
                                   True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            If validarForm() AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + vbYesNo) = MsgBoxResult.Yes Then
                Dim objDevolucionBLL As New DevolucionPemBLL
                empalmarDisenoToObjeto()
                objDevolucionBLL.guardarDevolucionPem(objDevolucionPem, SesionActual.idUsuario, SesionActual.codigoEP)
                General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, btanular, btimprimir)
                cargarDevolucion(objDevolucionPem.codigoDevolucion)

            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(pAnular) Then
            Try
                Dim objDevolucionBLL As New DevolucionPemBLL
                If objDevolucionBLL.verificarAnular(objDevolucionPem) Then
                    If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        objDevolucionBLL.anularDevolucion(objDevolucionPem, SesionActual.idUsuario)
                        General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                    End If
                Else
                    MsgBox("No se puede anular ya que alguna de las cantidades o concentración devueltas tuvo movimiento!!", MsgBoxStyle.Exclamation)
                End If
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(pBuscar) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.codigoEP)
            params.Add(Nothing)
            General.buscarElemento(Consultas.DEVOLUCION_BUSCAR,
                                   params,
                                   AddressOf cargarDevolucion,
                                   TitulosForm.BUSQUEDA_DESPACHO_PEM,
                                   True,
                                   Constantes.TAMANO_MEDIANO,
                                   True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub
    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If txtCodigo.Text <> "" Then
            imprimir()
        Else
            MsgBox("Debe elegir la devolucion que desea imprimir !!")
        End If

    End Sub
#End Region
#Region "Eventos de datagridview"
    Private Sub dgvInsumos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInsumos.CellClick
        If Funciones.filaValida(e.RowIndex) Then
            dgvInsumos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = Not Funciones.validarCeldaActiva(dgvInsumos, e, "Cantidad_Devuelta", btguardar)
        End If
    End Sub
    Private Sub dgvInsumos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInsumos.CellEnter
        If Funciones.filaValida(e.RowIndex) Then
            dgvInsumos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = Not Funciones.validarCeldaActiva(dgvInsumos, e, "Cantidad_Devuelta", btguardar)
        End If
    End Sub
    Private Sub dgvInsumos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvInsumos.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
    End Sub
    Private Sub dgvInsumos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInsumos.CellEndEdit
        If Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Cantidad_Devuelta", dgvInsumos) Then
            If dgvInsumos.Rows(e.RowIndex).Cells("Cantidad_Devuelta").Value > dgvInsumos.Rows(e.RowIndex).Cells("Cantidad_Despachada").Value Then
                dgvInsumos.Rows(e.RowIndex).Cells("Cantidad_Devuelta").Value = 0
                MsgBox(Mensajes.NO_SUPERAR_CANTIDAD_ENTREGADA_DEVOLUCION_PEM, MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub
    Private Sub dgvproductos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvproductos.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
    End Sub
    Private Sub dgvproductos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellEnter
        If Funciones.filaValida(e.RowIndex) Then
            dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = activarCelda(e)
        End If
    End Sub
    Private Sub dgvproductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellClick
        If Funciones.filaValida(e.RowIndex) Then
            dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = activarCelda(e)
        End If
    End Sub
    Private Sub dgvproductos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellEndEdit
        If Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Cantidad_Devuelta", dgvproductos) OrElse
           Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Concentración_Devuelta", dgvproductos) Then
            Dim celdas As DataGridViewCellCollection = dgvproductos.Rows(e.RowIndex).Cells
            If celdas("Cantidad_Devuelta").Value > 0 Then
                celdas("Concentración_Devuelta").Value = 0
            End If
            If celdas("Concentración_Devuelta").Value > 0 Then
                celdas("Cantidad_Devuelta").Value = 0
            End If

            If celdas("Concentración_Devuelta").Value > celdas("Concentración_Despachada").Value OrElse
               celdas("Cantidad_Devuelta").Value > celdas("Cantidad_Despachada").Value Then
                celdas("Cantidad_Devuelta").Value = 0
                celdas("Concentración_Devuelta").Value = 0
                buscarBodegaLote(e.RowIndex)
                MsgBox(Mensajes.NO_SUPERAR_CANTIDAD_ENTREGADA_DEVOLUCION_PEM, MsgBoxStyle.Exclamation)
            ElseIf celdas(e.ColumnIndex).Value > 0 Then
                Dim objPemBll As New DevolucionPemBLL
                If objPemBll.verificarBodegaDestino(objDevolucionPem, e.RowIndex) = False Then
                    limpiarBodegaFilaActual(e.RowIndex)
                Else
                    buscarBodegaLote(e.RowIndex)
                End If
            End If
        End If
    End Sub
    Private Sub dgvproductos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvproductos.DataError
        e.Cancel = False
    End Sub
    Private Sub dgvproductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellDoubleClick
        If Funciones.verificacionPosicionActual(dgvproductos, e, "Bodega") AndAlso btguardar.Enabled AndAlso dgvproductos.Rows(e.RowIndex).Cells("Bodega").Value = "" Then
            Dim params As New List(Of String)
            params.Add(SesionActual.codigoEP)
            If dgvproductos.Rows(e.RowIndex).Cells("Cantidad_Devuelta").Value > 0 Then
                params.Add(Constantes.BODEGA_COMERCIAL)
            ElseIf dgvproductos.Rows(e.RowIndex).Cells("Concentración_Devuelta").Value > 0 Then
                params.Add(Constantes.BODEGA_PRODUCCION)
            End If
            params.Add(Nothing)
            General.buscarItem(Consultas.DEVOLUCION_BUSCAR_BODEGA_PRINC_PREPA,
                               params,
                               AddressOf cargarBodegaSeleccionada,
                               TitulosForm.BUSQUEDA_BODEGA,
                               True)
        End If
    End Sub
#End Region
    Private Sub Form_devolucion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
End Class