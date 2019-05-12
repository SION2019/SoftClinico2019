Public Class FormAjusteInventario
    Private objAjuste As New AjusteInventario
    Dim nombreTabla As String
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
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
    Private Sub FormAjusteInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarForm()
    End Sub

    Private Sub PnlLotes_VisibleChanged(sender As Object, e As EventArgs) Handles PnlLotes.VisibleChanged
        dgvProductos.Enabled = Not PnlLotes.Visible
    End Sub
#End Region
#Region "Metodo"
    Public Sub cargarBodega(codigo As Integer)
        Dim fila As DataRow
        Dim params As New List(Of String)
        params.Add(codigo)

        fila = General.cargarItem(Consultas.AJUSTE_BODEGA_CARGAR, params)
        txtCodigoBodega.Text = codigo
        txtNombreBodega.Text = fila.Item("Nombre")
        objAjuste.codigoBodega = codigo

        limpiarTablas()
    End Sub
    Sub limpiarTablas()
        establecerVisiblePanelLotes(False)
        objAjuste.dtAjustes.Clear()
        objAjuste.tblLotes.Clear()
        objAjuste.dtAjustes.Rows.Add()
    End Sub
    Sub inicializarForm()
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Panular = permiso_general & "pp" & "02"
        PBuscar = permiso_general & "pp" & "03"

        With dgvProductos
            .Columns("CodigoProducto").ReadOnly = True
            .Columns("CodigoProducto").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CodigoProducto").DataPropertyName = "Codigo"
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").DataPropertyName = "Descripcion"
            .Columns("Marca").ReadOnly = True
            .Columns("Marca").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Marca").DataPropertyName = "Marca"
            .Columns("Stock").ReadOnly = True
            .Columns("Stock").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Stock").DataPropertyName = "Stock"
            .Columns("cantidad").ReadOnly = True
            .Columns("cantidad").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("cantidad").DataPropertyName = "Cantidad ajuste"
            .Columns("CostoAjuste").ReadOnly = True
            .Columns("CostoAjuste").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CostoAjuste").DataPropertyName = "Costo ajuste"
            .Columns("LotesM").ReadOnly = True
            .Columns("LotesM").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("LotesM").DataPropertyName = "Lote"
        End With
        dgvProductos.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        dgvProductos.DataSource = objAjuste.dtAjustes
        enlazarTablaDetalle()
        General.deshabilitarControles(Me)
    End Sub
    Sub enlazarTablaDetalle()
        With dgvLotes
            .Columns("Reg_Lote").ReadOnly = True
            .Columns("Reg_Lote").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Reg_Lote").DataPropertyName = "Reg_Lote"

            .Columns("Num_lote").ReadOnly = True
            .Columns("Num_lote").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Num_lote").DataPropertyName = "Numero Lote"

            .Columns("fecha").ReadOnly = True
            .Columns("fecha").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("fecha").DataPropertyName = "Fecha Vence"

            .Columns("stockLote").ReadOnly = True
            .Columns("stockLote").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("stockLote").DataPropertyName = "Stock"

            .Columns("conteo").ReadOnly = True
            .Columns("conteo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("conteo").DataPropertyName = "Conteo"

            .Columns("costo").ReadOnly = True
            .Columns("costo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("costo").DataPropertyName = "Costo"

            .Columns("CantidadAjuste").ReadOnly = True
            .Columns("CantidadAjuste").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("CantidadAjuste").DataPropertyName = "Cant Ajuste"

            .Columns("observacion").ReadOnly = True
            .Columns("observacion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("observacion").DataPropertyName = "Observacion"

            .Columns("excepcion").ReadOnly = True
            .Columns("excepcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("excepcion").DataPropertyName = "excepcion"
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With
    End Sub
    Sub establecerVisiblePanelLotes(ByVal valor As Boolean)
        PnlLotes.Visible = valor
    End Sub
    Sub deshabilitarControlesInternos()
        txtNombreBodega.ReadOnly = True
        TxtDescripcionProducto.ReadOnly = True
    End Sub
    Public Sub controlDgvLote()
        dgvLotes.Columns("costo").ReadOnly = True
        dgvLotes.Columns("CantidadAjuste").ReadOnly = True
        dgvLotes.Columns("Num_lote").ReadOnly = True
        dgvLotes.Columns("fecha").ReadOnly = True
        dgvLotes.Columns("stocklote").ReadOnly = True
        dgvLotes.Columns("observacion").ReadOnly = True
    End Sub
    Public Sub controlDgvProductos()
        dgvProductos.Columns("CodigoProducto").ReadOnly = True
        dgvProductos.Columns("Descripcion").ReadOnly = True
        dgvProductos.Columns("Marca").ReadOnly = True
        dgvProductos.Columns("Stock").ReadOnly = True
        dgvProductos.Columns("cantidad").ReadOnly = True
        dgvProductos.Columns("CostoAjuste").ReadOnly = True
        dgvProductos.Columns("LotesM").ReadOnly = True
    End Sub
    Sub empalmarDisenioToObjeto()
        objAjuste.codigoAjuste = txtcodigo.Text
        objAjuste.codigoBodega = txtCodigoBodega.Text
        objAjuste.fechaAjuste = fechaajustee.Value
    End Sub
    Sub empalmarObjetoToDisenio()
        txtcodigo.Text = objAjuste.codigoAjuste
        txtCodigoBodega.Text = objAjuste.codigoBodega
        fechaajustee.Value = objAjuste.fechaAjuste
    End Sub
    Public Sub cargarBusqueda(codigo As Integer)
        Dim filaRegistro As DataRow
        Dim params As New List(Of String)
        params.Add(codigo)
        filaRegistro = General.cargarItem(Consultas.AJUSTE_INVENTARIO_CARGAR, params)
        If Not IsNothing(filaRegistro) Then
            txtcodigo.Text = codigo

            txtNombreBodega.Text = filaRegistro.Item("nombre").ToString
            txtCodigoBodega.Text = filaRegistro.Item("Codigo Bodega").ToString
            fechaajustee.Value = filaRegistro.Item("Fecha ajuste").ToString

            objAjuste.codigoAjuste = txtcodigo.Text
            objAjuste.cargarProductoBodega()
            General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, btanular, Nothing)
            PnlLotes.Visible = False
            txtJustificacion.ReadOnly = True
        End If
    End Sub
    Sub activarCelda(e As DataGridViewCellEventArgs)
        dgvLotes.Columns(e.ColumnIndex).ReadOnly = True
        If txtcodigo.Text = "" Then
            If Funciones.filaValida(e.RowIndex) AndAlso
               dgvLotes.Rows(e.RowIndex).Cells("Reg_lote").Value.ToString = "" AndAlso
                (Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Num_lote", dgvLotes) OrElse
                 Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Fecha", dgvLotes) OrElse
                 Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Costo", dgvLotes)) Then
                dgvLotes.Columns(e.ColumnIndex).ReadOnly = False
            End If
            dgvLotes.Columns("Conteo").ReadOnly = False
        End If
    End Sub
#End Region
#Region "Funciones"
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function


    Function nombrarTabla() As String
        Dim IndiceFilaActual As Integer = dgvProductos.CurrentRow.Index
        Dim filaActual As DataRow = objAjuste.dtAjustes.Rows(IndiceFilaActual)
        Return objAjuste.nombrarTabla(filaActual.Item("Codigo"), IndiceFilaActual)
    End Function
#End Region
#Region "Eventos DGV"
    Private Sub dgvProductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        If Funciones.verificacionPosicionActual(dgvProductos, e, "CodigoProducto") OrElse Funciones.verificacionPosicionActual(dgvProductos, e, "Descripcion") Then
            Dim params As New List(Of String)
            params.Add(Nothing)
            params.Add(txtCodigoBodega.Text)
            General.busquedaItems(Consultas.AJUSTE_PRODUCTO_BODEGA_BUSCAR, params, TitulosForm.BUSQUEDA_PRODUCTOS, dgvProductos, objAjuste.dtAjustes, 0, 3, 0, 0, 1, 0)
        ElseIf Funciones.verificacionPosicionActual(dgvProductos, e, "Anular") And e.RowIndex <> dgvProductos.RowCount - 1 Then
            objAjuste.dtAjustes.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub
    Private Sub dgvProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellClick
        If Funciones.verificacionPosicionActual(dgvProductos, e, "LotesM") Then
            Dim IndiceFilaActual As Integer = dgvProductos.CurrentRow.Index
            Dim filaActual As DataRow = objAjuste.dtAjustes.Rows(IndiceFilaActual)
            If String.IsNullOrEmpty(filaActual.Item("Codigo").ToString) Then
                MsgBox("Debe cargar los producto de " & txtNombreBodega.Text & "", MsgBoxStyle.Exclamation)
            Else
                nombreTabla = objAjuste.nombrarTabla(filaActual.Item("Codigo"), IndiceFilaActual)
                objAjuste.establecerNuevaTabla(filaActual.Item("Codigo"), IndiceFilaActual, nombreTabla)
                TxtDescripcionProducto.Text = filaActual.Item("Descripcion")
                If Not String.IsNullOrEmpty(txtcodigo.Text) Then
                    objAjuste.cargarLotesRegistro(objAjuste.tblLotes.Tables(nombreTabla), nombreTabla, IndiceFilaActual)
                    btNuevoLote.Enabled = False
                Else
                    objAjuste.cargarLotes(filaActual.Item("Codigo"), nombreTabla)
                    btNuevoLote.Enabled = True
                End If
                dgvLotes.DataSource = objAjuste.tblLotes.Tables(nombreTabla)
                establecerVisiblePanelLotes(True)
            End If
        End If
    End Sub
    Private Sub dgvLotes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLotes.CellDoubleClick
        If dgvLotes.Rows.Count > 0 AndAlso e.ColumnIndex = dgvLotes.Columns("Quitar").Index Then
            General.abrirJustificacion(dgvLotes, dgvLotes.DataSource, PanelJustificacionConcurrencia, txtJustificacion, "observacion", Not btguardar.Enabled)
            If objAjuste.tblLotes.Tables(nombrarTabla()).Rows(e.RowIndex).Item("Reg_lote").ToString = "" Then
                objAjuste.tblLotes.Tables(nombrarTabla()).Rows.RemoveAt(e.RowIndex)
            End If

        End If
    End Sub
    Private Sub dgvLotes_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvLotes.EditingControlShowing
        If dgvLotes.CurrentCell.ColumnIndex = 5 OrElse dgvLotes.CurrentCell.ColumnIndex = 6 Then
            AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivo
        Else
            RemoveHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivo
        End If
    End Sub
    Private Sub dgvProductos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvProductos.DataError
        MsgBox(Mensajes.CANTIDAD_VALIDA, MsgBoxStyle.Exclamation)
    End Sub
    Private Sub dgvLotes_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvLotes.DataError
        MsgBox(Mensajes.CANTIDAD_VALIDA, MsgBoxStyle.Exclamation)
    End Sub
    Private Sub dgvLotes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLotes.CellContentClick
        activarCelda(e)
    End Sub
    Private Sub dgvLotes_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLotes.CellEnter
        activarCelda(e)
    End Sub
    Private Sub dgvLotes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLotes.CellClick
        activarCelda(e)
    End Sub
    Private Sub dgvProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellContentClick

    End Sub
#End Region
#Region "Botones"
    Private Sub Btbuscar_proveedores_Click(sender As Object, e As EventArgs) Handles Btbuscar_proveedores.Click
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        General.buscarElemento(Consultas.BUSQUEDA_BODEGA,
                                    params,
                                    AddressOf cargarBodega,
                                    TitulosForm.BUSQUEDA_BODEGA,
                                    False, 0, True)
    End Sub
    Private Sub BtSalirlOTES_Click(sender As Object, e As EventArgs) Handles BtSalirlOTES.Click
        Dim sumarCantidadLotes As Integer
        Dim sumarCostoLotes As Double
        txtJustificacionParaclinico_Leave(sender, e)
        dgvLotes.EndEdit()
        dgvLotes.DataSource.AcceptChanges()

        dgvProductos.Enabled = True
        If btguardar.Enabled = False Then
            PnlLotes.Visible = False
            Exit Sub
        End If


        For i = 0 To dgvLotes.RowCount - 1
            If String.IsNullOrEmpty(dgvLotes.Rows(i).Cells("conteo").Value.ToString) = False Then
                If String.IsNullOrEmpty(dgvLotes.Rows(i).Cells("observacion").Value.ToString) Then
                    MsgBox("La columna observación es obligatorio", MsgBoxStyle.Exclamation)
                    dgvLotes.Rows(i).Cells("observacion").Selected = True
                    Exit Sub
                Else
                    sumarCantidadLotes = sumarCantidadLotes + dgvLotes.Rows(i).Cells("CantidadAjuste").Value
                    sumarCostoLotes = sumarCostoLotes + (dgvLotes.Rows(i).Cells("costo").Value * dgvLotes.Rows(i).Cells("CantidadAjuste").Value)
                End If
            End If
        Next

        dgvProductos.Rows(dgvProductos.CurrentCell.RowIndex).Cells("cantidad").Value = sumarCantidadLotes
        dgvProductos.Rows(dgvProductos.CurrentCell.RowIndex).Cells("CostoAjuste").Value = FormatCurrency(Math.Abs(sumarCostoLotes), 2)
        PnlLotes.Visible = False
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            controlDgvLote()
            controlDgvProductos()
            deshabilitarControlesInternos()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub txtJustificacionParaclinico_Leave(sender As Object, e As EventArgs) Handles txtJustificacion.Leave
        Try
            If PanelJustificacionConcurrencia.Visible = True Then
                PanelJustificacionConcurrencia.Visible = False
                If dgvLotes.Rows(dgvLotes.CurrentRow.Index).Cells("observacion").Selected = True Then
                    dgvLotes.Rows(dgvLotes.CurrentRow.Index).Cells("observacion").Value = txtJustificacion.Text
                End If
                txtJustificacion.Clear()
                dgvLotes.EndEdit()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub dgvLotes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvLotes.KeyPress
        General.abrirJustificacion(dgvLotes, dgvLotes.DataSource, PanelJustificacionConcurrencia, txtJustificacion, "observacion", Not btguardar.Enabled, e.KeyChar, True)
    End Sub
    Public Function validar()
        If dgvProductos.RowCount < 1 OrElse objAjuste.dtAjustes.Rows.Count = 1 Then
            MsgBox("¡No ha realizado ningun movimiento!", MsgBoxStyle.Exclamation)
            Return False
        End If

        dgvLotes.EndEdit()
        dgvLotes.DataSource.AcceptChanges()

        For i = 0 To dgvProductos.Rows.Count - 2
            nombreTabla = objAjuste.nombrarTabla(objAjuste.dtAjustes.Rows(i).Item("Codigo"), i)
            If objAjuste.verificarExistenciaTabla(nombreTabla) Then
                If Not objAjuste.tblLotes.Tables(nombreTabla).Select("Convert([Conteo],'System.String')<>''", "").Count > 0 Then
                    MsgBox("No se ha seleccionado el lote de un producto", MsgBoxStyle.Exclamation)
                    Return False
                End If
            End If
        Next


        Return True
    End Function
    Public Sub guardar()
        If validar() Then

            Try
                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

                    objAjuste.codigoAjuste = txtcodigo.Text
                    objAjuste.codigoBodega = txtCodigoBodega.Text
                    objAjuste.fechaAjuste = fechaajustee.Value
                    objAjuste.usuario = SesionActual.idUsuario
                    objAjuste.guardarAjuste()
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    txtcodigo.Text = objAjuste.codigoAjuste
                    btguardar.Enabled = False
                    Dim nombreTabla As String = nombrarTabla()
                    objAjuste.cargarProductoBodega()
                    objAjuste.cargarLotesRegistro(objAjuste.tblLotes.Tables(nombreTabla), nombreTabla, dgvProductos.CurrentRow.Index)
                    btanular.Enabled = True
                    btcancelar.Enabled = False
                    btbuscar.Enabled = True
                    btnuevo.Enabled = True
                    General.deshabilitarControles(Me)
                End If
            Catch ex As Exception
                general.manejoErrores(ex)
            End Try
        End If
    End Sub

    Private Sub dgvLotes_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLotes.CellEndEdit

        If dgvLotes.Columns("Fecha").Index = e.ColumnIndex Then
            Dim mes As Integer = DateDiff(DateInterval.Month, dgvLotes.Rows(e.RowIndex).Cells("Fecha").Value, CDate(Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)).Date)
            If mes >= -3 Then
                If MsgBox("¿ Desea colocar este lote como exepcion ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    dgvLotes.Rows(e.RowIndex).Cells("Excepcion").Value = True
                Else
                    dgvLotes.Rows(e.RowIndex).Cells("Excepcion").Value = False
                    dgvLotes.Rows(e.RowIndex).Cells("Fecha").Value = DateAdd(DateInterval.Month, 3, CDate(Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)).Date)
                End If
            Else
                dgvLotes.Rows(e.RowIndex).Cells("Excepcion").Value = False
            End If
        End If
        dgvLotes.CommitEdit(DataGridViewDataErrorContexts.Commit)
        dgvLotes.EndEdit()


    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        txtJustificacionParaclinico_Leave(sender, e)
        dgvProductos.EndEdit()
        dgvLotes.EndEdit()
        guardar()
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add(Nothing)
            General.buscarElemento(Consultas.AJUSTE_INVENTARIO_BUSCAR,
                                    params,
                                    AddressOf cargarBusqueda,
                                    TitulosForm.BUSQUEDA_AJUSTE,
                                    False,
                                    Constantes.TAMANO_MEDIANO,
                                    True)
        Else

            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub
    Private Sub btNuevoLote_Click(sender As Object, e As EventArgs) Handles btNuevoLote.Click
        nombreTabla = nombrarTabla()
        Dim tabla As DataTableCollection = objAjuste.tblLotes.Tables
        If objAjuste.verificarExistenciaTabla(nombreTabla) Then
            If tabla(nombreTabla).Rows.Count > 0 Then
                If tabla(nombreTabla).Rows(tabla(nombreTabla).Rows.Count - 1).Item("Numero lote").ToString <> "" Then
                    tabla(nombreTabla).Rows.Add()
                    tabla(nombreTabla).Rows(tabla(nombreTabla).Rows.Count - 1).Item("Fecha Vence") = DateAdd(DateInterval.Month, 3, CDate(Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)).Date)
                End If
            Else
                tabla(nombreTabla).Rows.Add()
            End If
        End If

    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Dim params As New List(Of String)
                params.Add(txtcodigo.Text)
                params.Add(SesionActual.idUsuario)
                If General.getEstadoVF(Consultas.AJUSTE_INVENTARIO_ANULAR, params) = True Then
                    General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                Else
                    MsgBox(Mensajes.ANULAR_AJUSTE_INVENTARIO_NO_PERMITIDO, MsgBoxStyle.Critical)
                End If
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
#End Region
End Class