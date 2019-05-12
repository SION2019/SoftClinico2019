Public Class Form_despacho_pedido_servicio
    Private objDespachoServicio As DespachoPedidoServicio
    Dim objetoDespachoC As New DespachoPedidoServicioBLL
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, PBuscarPedidos As String
    Private Sub Form_despacho_pedido_servicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objDespachoServicio = New DespachoPedidoServicio
        Dim parametros As New List(Of String)
        parametros.Add(SesionActual.idUsuario)
        parametros.Add(SesionActual.codigoEP)
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        PBuscarPedidos = permiso_general & "pp" & "05"
        objetoDespachoC.enlazarTablas(dgvproductos, objDespachoServicio.tblBodegas, objDespachoServicio.tblDetalle)
        General.cargarCombo(Consultas.LISTAR_AREAS_EMPLEADO, parametros, "Descripcion_Area_Servicio", "Codigo_Area_servicio", cmbArea)
        General.posLoadForm(Me, ToolStrip1, btnuevo, Nothing)
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
#Region "Botones"
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Dim lista As List(Of Object) = validarForm()
        If lista.Item(0) = True Then
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Try
                    objDespachoServicio.fechaDespacho = MtxtfechaDespacho.Text
                    objDespachoServicio.externo = ckbExterno.Checked

                    objetoDespachoC.guardar(objDespachoServicio, SesionActual.idUsuario)
                    'cargarDatosDespacho(objDespachoServicio.codigoDespacho)
                    General.posGuardarForm(Me, ToolStrip1, btnuevo, btImprimir, btanular, Nothing)
                Catch ex As Exception
                    general.manejoErrores(ex)
                End Try
            End If
        Else
            MsgBox(lista.Item(1), MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If General.formCancelar(Me, ToolStrip1, btnuevo, Nothing) Then
            deshabilitarInterno()
            LimpiarObjeto()
        End If
    End Sub
    Private Sub btBuscarPedidoServicio_Click(sender As Object, e As EventArgs) Handles btBuscarPedidoServicio.Click
        If SesionActual.tienePermiso(PBuscarPedidos ) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.codigoEP)
            Dim consulta As String
            If ckbExterno.Checked Then
                consulta = Consultas.DESPACHO_PEDIDO_SERVICIO_BUSQUEDA_PEDIDOS_EXT
            Else
                consulta = Consultas.DESPACHO_PEDIDO_SERVICIO_BUSQUEDA_PEDIDOS
            End If

            General.buscarElemento(consulta,
                                   params,
                                   AddressOf cargarPedidoServicio,
                                   TitulosForm.BUSQUEDA_PEDIDO_SERVICIO,
                                   False,
                                   0,
                                   True)

        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Try
                    objetoDespachoC.anular(objDespachoServicio, SesionActual.idUsuario)
                    LimpiarObjeto()
                    General.posAnularForm(Me, ToolStrip1, btnuevo, Nothing)
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub BuscarInternoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarInternoToolStripMenuItem.Click
        If SesionActual.tienePermiso(PBuscar) Then
            buscar(Consultas.DESPACHO_PEDIDO_SERVICIO_BUSCAR)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub BuscarExtrnoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarExtrnoToolStripMenuItem.Click
        If SesionActual.tienePermiso(PBuscar) Then
            buscar(Consultas.DESPACHO_PEDIDO_SERVICIO_BUSCAR_EXT)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub buscar(ByVal cadena As String)
        Dim params As New List(Of String)
        params.Add("")
        params.Add(SesionActual.codigoEP)
        General.buscarItem(cadena,
                            params,
                            AddressOf cargarDatosDespacho,
                            TitulosForm.BUSQUEDA_DESPACHO_PEDIDO,
                            False,
                            True,
                            Constantes.TAMANO_MEDIANO)
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo ) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            deshabilitarInterno()
            LimpiarObjeto()
            llenarBodegas()
            MtxtfechaDespacho.Value = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
            MtxtfechaDespacho.Enabled = False
        Else
           MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
#End Region
#Region "Metodos"
    Sub LimpiarObjeto()
        objDespachoServicio.codigoDespacho = ""
        objDespachoServicio.codigoPedido = ""
        objDespachoServicio.fechaDespacho = Nothing
        objDespachoServicio.tblBodegas.Clear()
        objDespachoServicio.tblDetalle.Clear()
        objDespachoServicio.tblLotes.Reset()
    End Sub
    Sub cargarPedidoServicio(ByVal codigoPedido As String)
        objDespachoServicio.codigoPedido = codigoPedido
        Dim params As New List(Of String)
        params.Add(objDespachoServicio.codigoPedido)
        Dim consulta As String
        If ckbExterno.Checked Then
            consulta = Consultas.DESPACHO_PEDIDO_SERVICIO_CARGAR_DATOS_PEDIDO_EXT
        Else
            consulta = Consultas.DESPACHO_PEDIDO_SERVICIO_CARGAR_DATOS_PEDIDO
        End If
        Dim fila As DataRow
        fila = General.cargarItem(consulta, params)

        If Not IsNothing(fila) Then
            txtCodigoPedido.Text = fila.Item(0)
            cmbArea.SelectedValue = fila.Item(1)
            MtxtfechaPedido.Text = fila.Item(2)
            params.Add(SesionActual.codigoEP)
            Dim consultaDetalle As String
            If ckbExterno.Checked Then
                consultaDetalle = Consultas.DESPACHO_PEDIDO_SERVICIO_CARGAR_DATOS_PEDIDO_DETALLE_EXT
            Else
                consultaDetalle = Consultas.DESPACHO_PEDIDO_SERVICIO_CARGAR_DATOS_PEDIDO_DETALLE
            End If
            General.llenarTabla(consultaDetalle, params, objDespachoServicio.tblDetalle)
        Else
            MsgBox("No se encontro información !", MsgBoxStyle.Exclamation)
        End If

        objDespachoServicio.tblLotes.Clear()
    End Sub
    Sub cargarDatosDespacho(ByVal filaParametro As DataRow)
        'ByVal codigoDespacho As String
        objDespachoServicio.codigoDespacho = filaParametro.Item(0)
        objDespachoServicio.codigoPedido = filaParametro.Item(1)

        Dim params As New List(Of String)
        params.Add(objDespachoServicio.codigoDespacho)
        If objDespachoServicio.codigoPedido >= 20000000 Then
            objDespachoServicio.externo = True
        Else
            objDespachoServicio.externo = False
        End If

        Dim fila As DataRow
        fila = General.cargarItem(Consultas.DESPACHO_PEDIDO_SERVICIO_CARGAR_ENCABEZADO, params)
        txtCodigo.Text = objDespachoServicio.codigoDespacho
        MtxtfechaDespacho.Text = fila.Item(0)
        txtCodigoPedido.Text = fila.Item(1)
        MtxtfechaPedido.Text = fila.Item(2)
        cmbArea.SelectedValue = fila.Item(3)
        ckbExterno.Checked = objDespachoServicio.externo
        General.llenarTabla(Consultas.DESPACHO_PEDIDO_SERVICIO_CARGAR_DETALLE, params, objDespachoServicio.tblDetalle)
        General.llenarTabla(Consultas.DESPACHO_PEDIDO_SERVICIO_CARGAR_BODEGAS_UTILIZADAS, params, objDespachoServicio.tblBodegas)

        objDespachoServicio.tblLotes.Reset()
        Dim nombreTabla As String

        For indiceTabla As Int16 = 0 To objDespachoServicio.tblDetalle.Rows.Count - 1
            params.Clear()
            params.Add(objDespachoServicio.codigoDespacho)
            params.Add(objDespachoServicio.tblDetalle.Rows(indiceTabla).Item("CodigoInterno"))
            nombreTabla = Funciones.nombrarTabla(indiceTabla, objDespachoServicio.tblDetalle.Rows(indiceTabla).Item("CodigoInterno"))
            objDespachoServicio.agregarTabla(nombreTabla)
            General.llenarTabla(Consultas.DESPACHO_PEDIDO_SERVICIO_CARGAR_DETALLE_LOTES, params, objDespachoServicio.tblLotes.Tables(nombreTabla))
        Next
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btImprimir, Nothing, btanular)
    End Sub
    Sub llenarBodegas()
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        General.llenarTabla(Consultas.BUSQUEDA_BODEGAS_CONTEO, params, objDespachoServicio.tblBodegas)
    End Sub
    Sub deshabilitarInterno()
        cmbArea.Enabled = False
        MtxtfechaPedido.Enabled = False
    End Sub
    Sub calularCantidades()
        Dim nombreTabla As String
        For indiceTablaEquivalencia As Int16 = 0 To objDespachoServicio.tblDetalle.Rows.Count - 1
            nombreTabla = Funciones.nombrarTabla(indiceTablaEquivalencia, objDespachoServicio.tblDetalle.Rows(indiceTablaEquivalencia).Item("CodigoInterno"))
            If objDespachoServicio.verificarExistenciaTabla(nombreTabla) Then
                objDespachoServicio.tblDetalle.Rows(indiceTablaEquivalencia).Item("CantidadDespachada") = If(IsDBNull(objDespachoServicio.tblLotes.Tables(nombreTabla).Compute("Sum(Cantidad)", "")), 0, objDespachoServicio.tblLotes.Tables(nombreTabla).Compute("Sum(Cantidad)", ""))
            Else
                objDespachoServicio.tblDetalle.Rows(indiceTablaEquivalencia).Item("CantidadDespachada") = 0
            End If
        Next
    End Sub
#End Region
#Region "Funciones"
    Function obtenerBodegas() As List(Of String)
        Dim listaBodega As New List(Of String)
        Dim filas As DataRow()
        filas = objDespachoServicio.tblBodegas.Select("Usar='True'", "")
        For Each fila In filas
            listaBodega.Add(fila.Item("Codigo_Bodega"))
        Next
        Return listaBodega
    End Function
    Function validarForm() As List(Of Object)
        Dim Lista As New List(Of Object)
        If objDespachoServicio.codigoPedido = "" Then
            Lista.Add(False)
            Lista.Add(Mensajes.ESCOGER_PEDIDO_SERVCIO)
        ElseIf objDespachoServicio.tblDetalle.Select("CantidadDespachada > 0").Count = 0 Then
            Lista.Add(False)
            Lista.Add(Mensajes.INGRESO_PRODUCTOS_VALIDACION)
        Else
            Lista.Add(True)
        End If
        Return Lista
    End Function
#End Region
#Region "Eventos de dgv"
    Private Sub dgvLotes_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvLotes.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivo
    End Sub
    Private Sub dgvBodegas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        If Funciones.filaValida(e.RowIndex) Then
            If objDespachoServicio.tblBodegas.Rows(e.RowIndex).Item("Usar") = False Then
                For indiceTabla As Int16 = 0 To objDespachoServicio.tblLotes.Tables.Count - 1
                    Dim filas As DataRow() = objDespachoServicio.tblLotes.Tables(indiceTabla).Select("Codigo_Bodega ='" & objDespachoServicio.tblBodegas.Rows(e.RowIndex).Item("Codigo_Bodega") & "'")
                    For Each fila In filas
                        objDespachoServicio.tblLotes.Tables(indiceTabla).Rows.Remove(fila)
                    Next
                Next
                calularCantidades()
            End If
        End If
    End Sub
    Private Sub dgvLotes_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLotes.CellEndEdit
        General.cantidadValidaCelda(dgvLotes, e)
        Dim nombreTabla As String = Funciones.nombrarTabla(dgvproductos.CurrentRow.Index, objDespachoServicio.tblDetalle.Rows(dgvproductos.CurrentRow.Index).Item("CodigoInterno"))
        objDespachoServicio.tblLotes.Tables(nombreTabla).Rows(e.RowIndex).Item("Cantidad") = Funciones.validarEntrada(objDespachoServicio.tblLotes.Tables(nombreTabla).Rows(e.RowIndex).Item("Stock"), objDespachoServicio.tblLotes.Tables(nombreTabla).Rows(e.RowIndex).Item("Cantidad"), Mensajes.MAYOR_STOCK)
        If Funciones.validarEntrada(objDespachoServicio.tblDetalle.Rows(dgvproductos.CurrentRow.Index).Item("CantidadPedida"), objDespachoServicio.tblLotes.Tables(nombreTabla).Compute("SUM(Cantidad)", ""), Mensajes.MAYOR_CANTIDAD_PEDIDA) = 0 Then
            objDespachoServicio.tblLotes.Tables(nombreTabla).Rows(e.RowIndex).Item("Cantidad") = 0
        End If

        calularCantidades()
    End Sub
    Private Sub dgvLotes_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvLotes.DataError
        MsgBox(Mensajes.VALOR_PERMITIDO, MsgBoxStyle.Critical)
    End Sub
    Private Sub dgvproductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellDoubleClick
        If Funciones.verificacionPosicionActual(dgvproductos, e, "ANULAR") And btguardar.Enabled = True Then
            General.quitarTabla(objDespachoServicio.tblLotes, Funciones.nombrarTabla(e.RowIndex, objDespachoServicio.tblDetalle.Rows(e.RowIndex).Item("CodigoInterno")))
            calularCantidades()
        End If
    End Sub
    Private Sub dgvproductos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellEnter
        dgvproductos.ReadOnly = True
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        If txtCodigo.Text = "" Then
            MsgBox("Debe elegir un despacho para imprimir !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        Else
            Try
                Cursor = Cursors.WaitCursor
                Dim rprte As New rptDespachoPedidoServicioNuevo
                Funciones.getReporteNoFTP(rprte, "{VISTA_DESPACHO_PEDIDO_SERVICIO.Codigo_Despacho}= " & objDespachoServicio.codigoDespacho, "DespachoPedidoServicio")

                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
    Private Sub dgvLotes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLotes.CellClick, dgvLotes.CellEnter
        If Funciones.filaValida(e.RowIndex) Then
            dgvLotes.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = Not Funciones.validarCeldaActiva(dgvLotes, e, "Cantidad_Des", btguardar)
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
    Private Sub dgvproductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellContentClick
        If Funciones.verificacionPosicionActual(dgvproductos, e, "Lotes") Then
            Dim nombreTabla As String = Funciones.nombrarTabla(dgvproductos.CurrentRow.Index, objDespachoServicio.tblDetalle.Rows(dgvproductos.CurrentRow.Index).Item("CodigoInterno"))
            Dim params As New List(Of String)
            params.Add(SesionActual.codigoEP)
            params.Add(objDespachoServicio.tblDetalle.Rows(dgvproductos.CurrentRow.Index).Item("CodigoInterno"))


            objDespachoServicio.agregarTabla(nombreTabla)
            objetoDespachoC.enlazarTablasLotes(dgvLotes, objDespachoServicio, nombreTabla)
            If txtCodigo.Text = "" AndAlso btguardar.Enabled Then
                If objDespachoServicio.tblLotes.Tables(nombreTabla).Rows.Count = 0 Then
                    General.llenarTabla(Consultas.DESPACHO_PEDIDO_SERVICIO_CARGAR_LOTES_DISPONIBLE, params, objDespachoServicio.tblLotes.Tables(nombreTabla))
                End If
            End If
        End If
    End Sub
    Private Sub dgvproductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellClick
        If Funciones.verificacionPosicionActual(dgvproductos, e, "Lotes") = False Then
            dgvLotes.DataSource = Nothing
        End If
    End Sub
#End Region
End Class