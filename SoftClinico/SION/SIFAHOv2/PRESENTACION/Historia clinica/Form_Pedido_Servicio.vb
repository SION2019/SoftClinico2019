Public Class Form_Pedido_Servicio
    Dim objP As Pedido_Servicio
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, pbuscar_proveedor As String
    Dim cmd As New PedidoServicioBLL
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
#Region "Eventos Botones"
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Try
                    cmd.anular(objP)
                    LimpiarObjeto()
                    General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try


            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If General.fnFormEditar(Me, ToolStrip1, btguardar, btcancelar) = True Then
                objP.detallePedido.Rows.Add()
                mtxtFecha.Enabled = False
                txtEstado.ReadOnly = True
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add("")
            params.Add(SesionActual.codigoEP)


            General.buscarElemento(Consultas.BUSCAR_PEDIDO_SERVICIO,
                                   params,
                                   AddressOf cargarPedido,
                                   TitulosForm.BUSQUEDA_PEDIDO_SERVICIO,
                                   False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarForm() Then
            establecerObjeto()
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Try

                    Dim tbl As New DataTable
                    Dim filas As DataRow()
                    tbl = objP.detallePedido.Clone
                    filas = objP.detallePedido.Select("Cantidad > 0", "")
                    For Each fila In filas
                        tbl.ImportRow(fila)
                    Next
                    objP.detallePedido.Clear()
                    objP.detallePedido.Merge(tbl)
                    tbl.Dispose()

                    If objP.codigoPedido = "" Then
                        cmd.guardar(objP)
                        txtCodigo.Text = objP.codigoPedido
                    Else
                        cmd.actualizar(objP)
                    End If
                    General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)

                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub
    Private Sub dgvproductos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvproductos.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
            txtEstado.ReadOnly = True
            LimpiarObjeto()
            mostrarInformacion()
            objP.detallePedido.Rows.Add()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub dgvproductos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellEnter
        If e.RowIndex >= 0 Then
            dgvproductos.ReadOnly = False
            If btguardar.Enabled = True AndAlso dgvproductos.Columns("Cantidad").Index = e.ColumnIndex And dgvproductos.RowCount - 1 <> e.RowIndex Then
                dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
            Else
                dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            End If
        End If
    End Sub
#End Region
    Private Sub Form_Pedido_Servicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        objP = New Pedido_Servicio

        Dim parametros As New List(Of String)
        parametros.Add(SesionActual.idUsuario)
        parametros.Add(SesionActual.idEmpresa)

        permiso_general = perG.buscarPermisoGeneral(Name, Tag.modulo)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"

        General.cargarCombo(Consultas.LISTAR_AREAS_EMPLEADO, parametros, "Descripcion_Area_Servicio", "Codigo_Area_servicio", cmbArea)
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)

        enlazardgv()
    End Sub
#Region "Metodos"
    Function validarForm() As Boolean
        dgvproductos.EndEdit()
        objP.detallePedido.AcceptChanges()
        If cmbArea.SelectedValue = -1 Then
            MsgBox("Debe escoger el area de servicio", MsgBoxStyle.Exclamation)
            Return False
        ElseIf objP.detallePedido.Rows.Count = 1 OrElse objP.detallePedido.Select("Cantidad=0").Count > 1 Then
            MsgBox("Debe colocar todas la cantidades correctas", MsgBoxStyle.Exclamation)
            Return False
        End If

        Return True
    End Function

    Sub enlazardgv()

        With dgvproductos
            .Columns("Codigo").ReadOnly = True
            .Columns("Codigo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Codigo").DataPropertyName = "Codigo"
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").DataPropertyName = "Descripcion"
            .Columns("Cantidad").ReadOnly = True
            .Columns("Cantidad").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cantidad").DataPropertyName = "Cantidad"
        End With

        dgvproductos.AutoGenerateColumns = False
        dgvproductos.DataSource = objP.detallePedido
        dgvproductos.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub

    Private Sub dgvproductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellDoubleClick
        If e.RowIndex >= 0 Then
            If dgvproductos.Columns("ANULAR").Index = e.ColumnIndex And btguardar.Enabled = True AndAlso e.RowIndex <> dgvproductos.RowCount - 1 Then
                Funciones.quitarFilas(objP.detallePedido, e.RowIndex)
            ElseIf e.RowIndex = dgvproductos.RowCount - 1 AndAlso (dgvproductos.Columns("Codigo").Index = e.ColumnIndex OrElse dgvproductos.Columns("Descripcion").Index = e.ColumnIndex) AndAlso btguardar.Enabled = True Then
                Dim params As New List(Of String)

                General.busquedaItems(Consultas.LISTAR_EQUIVALENCIAS_PEDIDO_SERVICO,
                                      params,
                                      TitulosForm.BUSQUEDA_EQUIVALENCIA_PEDIDO_SERVICO,
                                      dgvproductos,
                                      objP.detallePedido,
                                      0,
                                      1,
                                      dgvproductos.Columns("Codigo").Index,
                                      True,
                                      True,
                                      0,
                                      False)

            End If
        End If
    End Sub

    Private Sub Form_Pedido_Servicio_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
    Sub establecerObjeto()
        objP.codigoPedido = txtCodigo.Text
        objP.areaServicio = cmbArea.SelectedValue
        objP.fechaPedido = Convert.ToDateTime(mtxtFecha.Value)
        objP.estado = If(General.getEstadoInventario(Constantes.PENDIENTE) = txtEstado.Text, Constantes.PENDIENTE, Constantes.TERMINADO)
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If txtCodigo.Text = "" Then
            MsgBox("Debe elegir un pedido para imprimir !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        Else
            Try
                Cursor = Cursors.WaitCursor
                Dim rprte As New rptPedidoServicio
                Funciones.getReporteNoFTP(rprte, "{F_PEDIDO_SERVICIO_UCI_D.Codigo_Pedido} =" & objP.codigoPedido & " and {F_PEDIDO_SERVICIO_UCI_D.Anulado} = false", "OrdenCompra", Constantes.FORMATO_PDF)
                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
                General.manejoErrores(ex)
            End Try
        End If
    End Sub

    Sub LimpiarObjeto()
        objP.codigoPedido = ""
        objP.areaServicio = -1
        objP.fechaPedido = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        objP.estado = Constantes.PENDIENTE
        objP.detallePedido.Clear()
    End Sub
    Sub mostrarInformacion()
        txtCodigo.Text = objP.codigoPedido
        cmbArea.SelectedValue = objP.areaServicio
        mtxtFecha.Value = objP.fechaPedido
        txtEstado.Text = General.getEstadoInventario(objP.estado)

    End Sub
    Sub cargarPedido(codigo As String)
        cmd.cargarDatos(objP, codigo)
        mostrarInformacion()
        General.posBuscarForm(Me, ToolStrip1, bteditar, btbuscar, btanular, btnuevo)
        If objP.estado = True Then
            btanular.Enabled = False
        Else
            btanular.Enabled = True
        End If
        btimprimir.Enabled = True
    End Sub
#End Region
#Region "Eventos de la dgv"
    Private Sub dgvproductos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvproductos.KeyDown
        If btguardar.Enabled = True Then
            If Funciones.filaValida(dgvproductos.CurrentCell.RowIndex) AndAlso dgvproductos.CurrentCell.RowIndex = dgvproductos.RowCount - 1 AndAlso dgvproductos.Columns("ANULAR").Index <> dgvproductos.CurrentCell.ColumnIndex Then
                If e.KeyValue = Keys.F3 Then
                    Dim params As New List(Of String)

                    General.busquedaItems(Consultas.LISTAR_EQUIVALENCIAS_PEDIDO_SERVICO,
                                          params,
                                          TitulosForm.BUSQUEDA_EQUIVALENCIA_PEDIDO_SERVICO,
                                          dgvproductos,
                                          objP.detallePedido,
                                          0,
                                          1,
                                          dgvproductos.Columns("Codigo").Index,
                                          True,
                                          True,
                                          0,
                                          False)


                End If
            End If
        End If

    End Sub
    Private Sub dgvproductos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvproductos.DataError
        e.Cancel = False
    End Sub
#End Region
End Class