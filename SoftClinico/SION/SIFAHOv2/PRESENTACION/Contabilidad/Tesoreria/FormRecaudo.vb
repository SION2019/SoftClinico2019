Public Class FormRecaudo
    Dim objRecaudo As Recaudo
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub HabilitarDGVColumnas()
        With dgvCuentas
            .ReadOnly = False
            .Columns("dgNumFactura").ReadOnly = False
            .Columns("dgCuenta").ReadOnly = False
            .Columns("dgDescripcion").ReadOnly = True
            .Columns("dgDebito").ReadOnly = False
            .Columns("dgCredito").ReadOnly = False
        End With
    End Sub
    Private Sub FormRecaudo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        'permisos de uso de boton
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        objRecaudo = New Recaudo
        objRecaudo.codigoPuc = FuncionesContables.obtenerPucActivo()
        objRecaudo.codigoep = SesionActual.idEmpresa
        objRecaudo.codigoDocumento = Constantes.RECAUDO_DE_CLIENTES
        objRecaudo.usuario = SesionActual.idUsuario
        objRecaudo.codigoPuc = FuncionesContables.obtenerPucActivo()
        validarDgv()
        HabilitarDGVColumnas()
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
    Private Sub validarDgv()
        With dgvCuentas
            .ReadOnly = False
            .Columns("dgOrden").DataPropertyName = "Orden"
            .Columns("dgNumFactura").DataPropertyName = "Codigo_factura"
            .Columns("dgCuenta").DataPropertyName = "Codigo_cuenta"
            .Columns("dgDescripcion").DataPropertyName = "Descripcion"
            .Columns("dgDebito").DataPropertyName = "Debito"
            .Columns("dgCredito").DataPropertyName = "Credito"
            .Columns("dgQuitar").DisplayIndex = 6
            .DataSource = objRecaudo.dtDetalle
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            .AutoGenerateColumns = False
        End With
    End Sub
    Private Sub bttercero_Click(sender As Object, e As EventArgs) Handles bttercero.Click
        Dim params As New List(Of String)
        params.Add(String.Empty)

        General.buscarElemento(Consultas.BUSQUEDA_TERCERO,
                      params,
                      AddressOf cargarTercero,
                      TitulosForm.BUSQUEDA_TERCERO,
                      True, 0, True)
    End Sub
    Public Sub cargarTercero(pCodigo)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        objRecaudo.codigoTercero = pCodigo
        Try
            General.llenarTabla(Consultas.TERCERO_CARGAR, params, dt)
            If dt.Rows.Count > 0 Then
                textproveedor.Text = dt.Rows(0).Item("Nit").ToString()
                textnombreproveedor.Text = dt.Rows(0).Item("Tercero").ToString()
                objRecaudo.codigoTercero = pCodigo
                objRecaudo.dtDetalle.Clear()
                objRecaudo.dtDetalle.Rows.Add()
                calcular()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub dgvCuentas_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvCuentas.CellFormatting
        If objRecaudo.dtDetalle.Rows.Count > 0 Then
            If e.ColumnIndex = 5 Or e.ColumnIndex = 6 Then
                e.Value = If(Not IsDBNull(e.Value), Format(Val(e.Value), "c2"), 0)
            End If
        End If
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.deshabilitarBotones(ToolStrip1)
            General.limpiarControles(Me)
            HabilitarDGVColumnas()
            txtcodigo.Text = FuncionesContables.verificarConsecutivo(objRecaudo.codigoep, objRecaudo.codigoDocumento)
            textobserva.ReadOnly = False
            fechadoc.Enabled = True
            bttercero.Enabled = True
            btguardar.Enabled = True
            btcancelar.Enabled = True
            PnlInfo.Visible = False
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        General.limpiarControles(Me)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
    End Sub
    Private Sub calcular()
        textvalordebito.Text = Format(objRecaudo.dtDetalle.Compute("SUM(Debito)", ""), "C")
        textvalorcredito.Text = Format(objRecaudo.dtDetalle.Compute("SUM(Credito)", ""), "C")
        textdiferencia.Text = Format((textvalordebito.Text - textvalorcredito.Text), "C")
    End Sub
    Private Sub dgvCuentas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCuentas.CellEndEdit
        Dim dFila As DataRow
        Dim params As New List(Of String)
        Try
            If objRecaudo.dtDetalle.Rows.Count > 0 Then
                If e.ColumnIndex = 5 Or e.ColumnIndex = 6 Then
                    calcular()
                Else
                    If e.ColumnIndex = 2 And IsDBNull(dgvCuentas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) = False Then
                        digitarDetalleSaldo(dgvCuentas.Rows(e.RowIndex).Cells(2).Value, textproveedor.Text)
                        Me.dgvCuentas.Rows(e.RowIndex).Cells(1).Value = e.RowIndex
                    Else
                        If e.ColumnIndex = 3 And IsDBNull(dgvCuentas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) = False Then
                            If dgvCuentas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Length > 4 Then
                                params.Add(objRecaudo.codigoPuc)
                                params.Add(dgvCuentas.Rows(e.RowIndex).Cells(3).Value)
                                dFila = FuncionesContables.digitarCuenta(params)
                                If Not IsNothing(dFila) Then
                                    Me.dgvCuentas.Rows(e.RowIndex).Cells(4).Value = dFila.Item(2)
                                    Me.dgvCuentas.Rows(e.RowIndex).Cells(1).Value = e.RowIndex
                                    Dim UltFila As Integer = objRecaudo.dtDetalle.Rows.Count - 1
                                    Dim ActFila As Integer = dgvCuentas.CurrentRow.Index
                                    If UltFila = ActFila Then
                                        objRecaudo.dtDetalle.Rows.Add()
                                    End If
                                End If
                            Else
                                MsgBox("No se encontro la Cuenta", MsgBoxStyle.Exclamation)
                                dgvCuentas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = String.Empty
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub dgvCuentas_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvCuentas.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
    End Sub

    Private Sub dgvCuentas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCuentas.CellDoubleClick
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        Try
            If objRecaudo.dtDetalle.Rows.Count > 0 Then
                If e.ColumnIndex = 0 Then
                    If Not IsDBNull(objRecaudo.dtDetalle.Rows(dgvCuentas.CurrentCell.RowIndex).Item("Descripcion")) Then
                        objRecaudo.dtDetalle.Rows.RemoveAt(dgvCuentas.CurrentCell.RowIndex)
                        calcular()
                        Me.dgvCuentas.Rows(e.RowIndex).Cells(1).Value = e.RowIndex
                    End If
                ElseIf e.ColumnIndex = 2 Then
                    If textproveedor.Text <> String.Empty Then
                        dgvCuentas.EndEdit()
                        buscarFacturas(e.RowIndex)
                    Else
                        MsgBox(Mensajes.SELECCIONAR_CLIENTE, MsgBoxStyle.Information)
                        bttercero_Click(sender, e)
                    End If
                ElseIf e.ColumnIndex = 3 Then
                    dgvCuentas.EndEdit()
                    buscarCuentaPuc(e.RowIndex)
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub buscarFacturas(index As Integer)
        Dim params As New List(Of String)
        params.Add(objRecaudo.codigoTercero)
        params.Add(SesionActual.idEmpresa)
        params.Add(String.Empty)
        General.buscarElemento(Consultas.SALDO_PENDIENTE_CLIENTE_BUSCAR,
                           params,
                           AddressOf cargarDetalleSaldo,
                           TitulosForm.BUSQUEDA_SALDO_PENDIENTE, False)
        Me.dgvCuentas.Rows(index).Cells(1).Value = index
    End Sub
    Private Sub buscarCuentaPuc(fila As Integer)
        Dim params As New List(Of String)
        Try
            If objRecaudo.dtDetalle.Rows.Count > 0 Then
                params.Add(objRecaudo.codigoPuc)
                params.Add(String.Empty)
                General.buscarElemento(Consultas.BUSQUEDA_CUENTAS_PUC,
                       params,
                       AddressOf cargarCuentas,
                       TitulosForm.BUSQUEDA_CUENTAS_PUC, False)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cargarCuentas(pCodigo As String)
        Dim params As New List(Of String)
        Dim dfila As DataRow
        Try
            params.Add(objRecaudo.codigoPuc)
            params.Add(pCodigo)
            dfila = FuncionesContables.digitarCuenta(params)
            If Not IsNothing(dfila) Then
                Me.dgvCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Cells("dgCuenta").Value = dfila.Item(1)
                Me.dgvCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Cells("dgDescripcion").Value = dfila.Item(2)
                Me.dgvCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Cells("dgOrden").Value = dgvCuentas.CurrentCell.RowIndex
                Dim UltFila As Integer = objRecaudo.dtDetalle.Rows.Count - 1
                Dim ActFila As Integer = dgvCuentas.CurrentRow.Index
                If UltFila = ActFila Then
                    objRecaudo.dtDetalle.Rows.Add()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub digitarDetalleSaldo(pCodigo As String, pcliente As String)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        Dim contenido As String = "[Codigo_factura] = '" + pCodigo + "'"
        Try
            If objRecaudo.dtDetalle.Select(contenido).Count = 0 Then
                params.Add(pCodigo)
                params.Add(pcliente)
                dFila = General.cargarItem(Consultas.SALDO_PENDIENTE_CLIENTE_DIGITAR, params)
                If Not IsNothing(dFila) Then
                    objRecaudo.dtDetalle.Rows(dgvCuentas.CurrentCell.RowIndex).Item("Codigo_factura") = pCodigo
                    objRecaudo.dtDetalle.Rows(dgvCuentas.CurrentCell.RowIndex).Item("Codigo_cuenta") = dFila.Item(0)
                    objRecaudo.dtDetalle.Rows(dgvCuentas.CurrentCell.RowIndex).Item("Descripcion") = dFila.Item(1)
                    objRecaudo.dtDetalle.Rows(dgvCuentas.CurrentCell.RowIndex).Item("Credito") = dFila.Item(2)
                    calcular()
                    objRecaudo.dtDetalle.Rows.Add()
                Else
                    MsgBox("No se encontro la Factura", MsgBoxStyle.Exclamation)
                End If
            Else
                MsgBox("¡ Ya se encuentra seleccionado !", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Public Sub cargarDetalleSaldo(pCodigo As String)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        Dim contenido As String = "[Codigo_factura] = '" + pCodigo + "'"
        Try
            If objRecaudo.dtDetalle.Select(contenido).Count = 0 Then
                params.Add(pCodigo)
                dFila = General.cargarItem(Consultas.SALDO_PENDIENTE_CLIENTE_CARGAR, params)
                If Not IsNothing(dFila) Then
                    objRecaudo.dtDetalle.Rows(dgvCuentas.Rows.Count - 1).Item("Codigo_factura") = pCodigo
                    objRecaudo.dtDetalle.Rows(dgvCuentas.Rows.Count - 1).Item("Codigo_cuenta") = dFila.Item(0)
                    objRecaudo.dtDetalle.Rows(dgvCuentas.Rows.Count - 1).Item("Descripcion") = dFila.Item(1)
                    objRecaudo.dtDetalle.Rows(dgvCuentas.Rows.Count - 1).Item("Credito") = dFila.Item(2)
                    calcular()
                    objRecaudo.dtDetalle.Rows.Add()
                End If
            Else
                MsgBox("¡ Ya se encuentra seleccionado !", MsgBoxStyle.Exclamation)
                objRecaudo.dtDetalle.Rows(dgvCuentas.Rows.Count - 1).Item("Codigo_factura") = Nothing
                buscarFacturas(dgvCuentas.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Public Sub cargarObjeto()
        objRecaudo.comprobante = txtcodigo.Text
        objRecaudo.fechaDocum = fechadoc.Value
        objRecaudo.valorDebito = textvalordebito.Text
        objRecaudo.valorCredito = textvalorcredito.Text
        objRecaudo.valorSubTotal = textdiferencia.Text
        objRecaudo.Movimiento = textobserva.Text

        For indice = 0 To objRecaudo.dtDetalle.Rows.Count - 1
            objRecaudo.dtDetalle.Rows(indice).Item("Orden") = indice
        Next
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            If validarGuardar() = True Then
                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    cargarObjeto()
                    Try
                        RecaudoBLL.guardarRecaudo(objRecaudo)
                        General.habilitarBotones(ToolStrip1)
                        General.deshabilitarControles(Me)
                        cargarRegistroDetalleRecaudo(objRecaudo.comprobante)
                        btguardar.Enabled = False
                        btcancelar.Enabled = False
                        MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    Catch ex As Exception
                        Throw ex
                    End Try
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Function validarGuardar() As Boolean
        Dim validar As Boolean = False
        If textproveedor.Text = String.Empty Then
            MsgBox("¡ Favor Seleccionar un Tercero !", MsgBoxStyle.Exclamation)
            bttercero.Focus()
        ElseIf textdiferencia.Text <> 0 Then
            MsgBox("¡La diferencia debe ser Cero(0)!", MsgBoxStyle.Exclamation)
            textdiferencia.Focus()
        ElseIf String.IsNullOrEmpty(textobserva.Text) Then
            MsgBox("¡Observacion esta en Blanco...!", MsgBoxStyle.Exclamation)
            textobserva.Focus()
        ElseIf Me.textvalordebito.Text = 0 Or Me.textvalorcredito.Text = 0 Then
            MsgBox("¡El Detalle del Recaudo esta en Cero(0)!", MsgBoxStyle.Exclamation)
        Else
            validar = True
        End If

        If FuncionesContables.verificarFecha(fechadoc.Value) Then
            mostrarInfo(String.Format(Mensajes.PERIODO_CONTABLE_CERRADO), Color.White, Color.Red)
            Return False
        Else
            mostrarInfo(Nothing, Nothing, Nothing, True)
            PnlInfo.Visible = False
        End If

        'If FuncionesContables.validarFechaFutura(fechadoc) = False Then
        '    Return False
        'End If
        Return validar
    End Function

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                General.deshabilitarBotones(ToolStrip1)
                objRecaudo.dtDetalle.Rows.Add()
                textobserva.ReadOnly = False
                fechadoc.Enabled = True
                btguardar.Enabled = True
                btcancelar.Enabled = True
                dgvCuentas.ReadOnly = False
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.buscarElemento(objRecaudo.sqlBuscarRecaudo &
                                   ConstantesHC.NOMBRE_PDF_SEPARADOR3 & objRecaudo.codigoep,
                                 Nothing,
                                 AddressOf cargarRegistroRecaudo,
                                 TitulosForm.BUSQUEDA_RECAUDO, False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub cargarRegistroRecaudo(pCodigo As String)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        Try
            params.Add(pCodigo)
            dFila = General.cargarItem(objRecaudo.sqlCargarRecaudo, params)
            txtcodigo.Text = pCodigo
            objRecaudo.codigoTercero = dFila.Item("Id_Tercero")
            textproveedor.Text = dFila.Item("Nit")
            textnombreproveedor.Text = dFila.Item("Cliente")
            textobserva.Text = dFila.Item("detalle_mov")
            textvalorcredito.Text = Format(dFila.Item("Valor_credito"), "C")
            textvalordebito.Text = Format(dFila.Item("Valor_debito"), "C")
            textdiferencia.Text = Format(dFila.Item("Valor_Subtotal"), "C")
            fechadoc.Value = dFila.Item("Fecha_recibo")
            cargarRegistroDetalleRecaudo(pCodigo)
            If FuncionesContables.verificarFecha(fechadoc.Value) Then
                mostrarInfo(String.Format(Mensajes.PERIODO_CONTABLE_CERRADO), Color.White, Color.Red)
                bteditar.Enabled = False
            Else
                mostrarInfo(Nothing, Nothing, Nothing, True)
                PnlInfo.Visible = False
            End If
            General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btImprimir)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Sub mostrarInfo(pSmg As String, pColorFuenteLetra As Color, pColorFondoPanel As Color, Optional pOcultar As Boolean = False)
        If InvokeRequired Then
            Invoke(New MethodInvoker(Sub() mostrarInfo(pSmg, pColorFuenteLetra, pColorFondoPanel, pOcultar)))
        Else
            If pOcultar Then
                PnlInfo.Visible = False
            Else
                lbinfo.Text = pSmg.ToUpper : lbinfo.ForeColor = pColorFuenteLetra : PictureBox2.Image = My.Resources.Gifs_ANimados_Señalas_Viales__31_
                PnlInfo.BackColor = pColorFondoPanel : PnlInfo.BringToFront() : PnlInfo.Visible = True
            End If
        End If
    End Sub
    Private Sub cargarRegistroDetalleRecaudo(pCodigo As String)
        Dim params As New List(Of String)
        Try
            params.Add(pCodigo)
            General.llenarTabla(objRecaudo.sqlCargarDetalleRecaudo, params, objRecaudo.dtDetalle)
            dgvCuentas.DataSource = objRecaudo.dtDetalle
            dgvCuentas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvCuentas.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            dgvCuentas.AutoGenerateColumns = False
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub dgvCuentas_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvCuentas.DataError
        MsgBox("Cantidad Invalida..", MsgBoxStyle.Exclamation)
    End Sub

    Private Sub fechadoc_ValueChanged(sender As Object, e As EventArgs) Handles fechadoc.ValueChanged
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        Try
            If CDate(fechadoc.Value).Date <= CDate(Funciones.Fecha(23)).Date Then
                If FuncionesContables.verificarFecha(CDate(fechadoc.Value).Date) Then
                    MsgBox(Mensajes.PERIODO_CONTABLE_CERRADO, MsgBoxStyle.Exclamation)
                    fechadoc.Value = Date.Today
                    Exit Sub
                End If
            Else
                MsgBox("¡ la Fecha no puede ser mayor a la actual !", MsgBoxStyle.Exclamation)
                fechadoc.Value = Date.Today
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        Dim reporte As New ftp_reportes
        Cursor = Cursors.WaitCursor
        Try
            Dim ruta, area, nombreArchivo As String
            area = Constantes.NOMBRE_PDF_COMPROBANTE_RC
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtcodigo.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo

            reporte.crearReportePDF(Constantes.NOMBRE_PDF_COMPROBANTE_RC, txtcodigo.Text, New rptRecaudo,
                         txtcodigo.Text, "{VISTA_REPORTE_RECAUDO.Comprobante} = '" & txtcodigo.Text & "'",
                          Constantes.NOMBRE_PDF_COMPROBANTE_RC, IO.Path.GetTempPath)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvCuentas_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvCuentas.KeyDown
        If btguardar.Enabled = False Then Exit Sub
        If objRecaudo.dtDetalle.Rows.Count > 0 Then
            If e.KeyCode = Keys.F3 Then
                dgvCuentas.EndEdit()
                buscarFacturas(dgvCuentas.CurrentCell.RowIndex)
            ElseIf e.KeyCode = Keys.F2 Then
                buscarCuentaPuc(dgvCuentas.CurrentCell.RowIndex)
            End If
        End If
    End Sub

    Private Sub dgvCuentas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCuentas.CellClick
        If btguardar.Enabled = False Then Exit Sub
        Try
            If objRecaudo.dtDetalle.Rows.Count > 0 Then

                validarCreditoDebito(e.ColumnIndex, dgvCuentas.CurrentCell.RowIndex)

            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub dgvCuentas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCuentas.CellEnter
        If btguardar.Enabled = False Then Exit Sub
        Try
            If objRecaudo.dtDetalle.Rows.Count > 0 Then
                validarCreditoDebito(e.ColumnIndex, dgvCuentas.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub ValidarCreditoDebito(posicion As Integer)
        Try
            Select Case posicion
                Case 5 '------------- Posicion de la columna Debito
                    If dgvCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Cells("dgCredito").Value > 0 Then
                        dgvCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Cells(posicion).ReadOnly = True
                    End If
                Case 6 '-------------- Posicion de la columna Credito
                    If dgvCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Cells("dgDebito").Value > 0 Then
                        dgvCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Cells(posicion).ReadOnly = True
                    End If
            End Select
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub validarCreditoDebito(columna As Integer, fila As Integer)
        Try
            If objRecaudo.dtDetalle.Rows.Count > 0 Then
                dgvCuentas.Rows(fila).Cells(columna).ReadOnly = False
                ValidarCreditoDebito(columna)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

End Class