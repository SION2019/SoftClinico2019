Public Class FormFacturaVentas
    Dim dtCuentas As New DataTable
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, identificador As String
    Dim codigoPuc, codigoDocumento, idTercero As Integer
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub diseñoDgv()
        dgvCuentas.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCuentas.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCuentas.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCuentas.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCuentas.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCuentas.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCuentas.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub
    Private Sub llenarFactura(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        Textcodfactura.Text = pCodigo
        General.llenarTabla(Consultas.CUENTAS_CXC_CLIENTE_DETALLE_CARGAR, params, dtCuentas)
        diseñoDgv()

        If dtCuentas.Rows.Count > 0 Then
            calcularTotales()
            dtCuentas.Rows.Add()
        End If
    End Sub

    Private Sub llenarDetalleCuentas(pCodigo As String, idEmpresa As Integer)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(SesionActual.idEmpresa)
        Textcodfactura.Text = pCodigo
        General.llenarTabla(Consultas.CUENTAS_POR_COBRAR_DETALLE_CARGAR, params, dtCuentas)
        diseñoDgv()
        dgvCuentas.ReadOnly = True
        If dtCuentas.Rows.Count > 0 Then
            calcularTotales()
        Else
            textdiferencia.Text = FormatCurrency(0, 2)
        End If
    End Sub

    Private Sub dgvCuentas_CellFormatting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvCuentas.CellFormatting
        If e.ColumnIndex = 4 Or e.ColumnIndex = 5 Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), "c2")
            Else
                e.Value = Format(Val(e.Value), "c2")
            End If
        End If

    End Sub
    Private Function validarInformacion() As Boolean
        dgvCuentas.EndEdit()
        dtCuentas.AcceptChanges()
        If textproveedor.Text = "" Then
            MsgBox("Por Favor Elija el cliente", 48, "Atención")
            bttercero.Focus()
        ElseIf Textcodfactura.Text = "" Then
            MsgBox("Por Favor digite el numero de factura", 48, "Atención")
            btfactura.Focus()
        ElseIf Format(CDate(fecharecibo.Value), "yyyyMMdd") = Format(CDate(fechavence.Value), "yyyyMMdd") And Textforma_pago.Text = "Credito" Then
            MsgBox("La fecha de vencimiento no puede ser igual a la fecha de recibo si fue una compra a crédito", 48, "Atención")
            fechavence.Focus()
        ElseIf Format(CDate(fecharecibo.Value), "yyyyMMdd") > Format(CDate(fechavence.Value), "yyyyMMdd") Then
            MsgBox("La fecha de vencimiento no puede ser menor a la fecha de recibo", 48, "Atención")
            fechavence.Focus()
        ElseIf dgvCuentas.RowCount <= 1 Then
            MsgBox("Por favor corrija el movimiento la diferencia debe ser cero", 48, "Atención")
        ElseIf CDbl(textdiferencia.Text) <> 0 Then
            MsgBox("Por favor corrija el movimiento la diferencia debe ser cero", 48, "Atención")
        ElseIf FuncionesContables.validardgv(dtCuentas) = False Then
        ElseIf FuncionesContables.verificarFecha(fechadoc.Value) Then
            mostrarInfo(String.Format(Mensajes.PERIODO_CONTABLE_CERRADO), Color.White, Color.Red)
        ElseIf FuncionesContables.VerificarCuentaTercero(SesionActual.idEmpresa, idTercero, Consultas.CUENTA_POR_COBRAR_CREAR, dgvCuentas) = False Then
            MsgBox("Debe crear una cuenta por cobrar", MsgBoxStyle.Information)
            btcxc.Focus()
        ElseIf FuncionesContables.validarFechaFutura(fechadoc) = False Then
        Else
            mostrarInfo(Nothing, Nothing, Nothing, True)
            PnlInfo.Visible = False
            Return True
        End If
        Return False
    End Function

    Private Sub calcularTotales()
        Try
            Dim valorDebito, sumaDebito, sumaCredito, valorCredito As Double
            If dgvCuentas.Rows.Count > 1 Then
                For indicedgvCuentas = 0 To dgvCuentas.Rows.Count - 1
                    If dgvCuentas.Rows(indicedgvCuentas).Cells("Descripcion").Value.ToString <> "" Then
                        sumaDebito = CDbl(dgvCuentas.Rows(indicedgvCuentas).Cells(4).Value)
                        sumaCredito = CDbl(dgvCuentas.Rows(indicedgvCuentas).Cells(5).Value)
                        valorDebito = valorDebito + sumaDebito
                        valorCredito = valorCredito + sumaCredito
                    End If
                Next
                textdiferencia.Text = FormatCurrency((CDbl(valorCredito) - CDbl(valorDebito)), 2)
                textvalordebito.Text = CDbl(valorDebito).ToString("C2")
                textvalorcredito.Text = CDbl(valorCredito).ToString("C2")
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub cargarDocumento(codigo As String)
        Dim objDocumentoContable As DocumentoContable = FuncionesContables.cargarDocumento(codigo)
        If objDocumentoContable IsNot Nothing Then
            codigoDocumento = objDocumentoContable.codigo
            Textsigla.Text = codigo
            Textnombredocumento.Text = objDocumentoContable.descripcion
        Else
            MsgBox("No se encontró ningún documento", MsgBoxStyle.Information)
            btBusquedaDocumento.PerformClick()
        End If
    End Sub
    Private Sub dgvcuentas_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvCuentas.KeyDown
        Dim params As New List(Of String)
        params.Add(codigoPuc)
        params.Add("")
        If e.KeyCode = Keys.F3 And btguardar.Enabled = True And Textcodfactura.Text <> "" Then
            General.busquedaItems(Consultas.BUSQUEDA_CUENTAS_DETALLE_PUC, params, TitulosForm.BUSQUEDA_CUENTAS_PUC, dgvCuentas, dtCuentas, 0, 2, 0, 0, 0, 0, 1)
            Dim paramsRetencion As New List(Of String)
            paramsRetencion.Add(codigoPuc)
            paramsRetencion.Add(dtCuentas.Rows(dgvCuentas.CurrentRow.Index).Item(0).ToString)
            Dim filaRetencion As DataRow
            filaRetencion = FuncionesContables.llenarRetencion(paramsRetencion)
            If Not IsNothing(filaRetencion) Then
                lblivarete.Text = filaRetencion("Cuenta").ToString()
                porcentaje.Text = filaRetencion("tasa").ToString()
                porcentaje.Text = Replace(porcentaje.Text, ".", ",")
                nat.Text = filaRetencion("naturaleza").ToString()
                Panel3.Visible = True
                base.Focus()
            End If
            diseñoDgv()
        End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarInformacion() Then
            PnlInfo.Visible = False
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                codigoPuc = FuncionesContables.obtenerPucActivo()
                calcularTotales()

                Dim objcuentasCXCBll As New CuentasPorCobrarBLL
                Try
                    If chkNuevaRad.Checked = True Then
                        objcuentasCXCBll.guardarNuevaRadicacion(crearCuentasCXC())
                    Else
                        objcuentasCXCBll.guardarCuentaPorCobrar(crearCuentasCXC(), SesionActual.idUsuario)
                        llenarDetalleCuentas(Textcodfactura.Text, SesionActual.idEmpresa)
                    End If
                    General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                    chkNuevaRad.Checked = False
                    fechaNRad.Enabled = False
                    gboxNRad.Visible = False
                    chkNuevaRad.Visible = False
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub
    Public Function crearCuentasCXC() As CuentasPorCobrar
        Dim objcuentasCXC As New CuentasPorCobrar
        Dim valorDebito, valorCredito As Double
        valorDebito = textvalordebito.Text
        valorCredito = textvalorcredito.Text
        objcuentasCXC.factura = Textcodfactura.Text
        objcuentasCXC.idEmpresa = SesionActual.idEmpresa
        objcuentasCXC.idCliente = idTercero
        objcuentasCXC.fechaRecibo = fecharecibo.Value
        objcuentasCXC.fechaVence = fechavence.Value
        objcuentasCXC.fechaDoc = fechadoc.Value
        objcuentasCXC.identificador = identificador
        objcuentasCXC.codigoDocumento = codigoDocumento
        objcuentasCXC.valorDebito = valorDebito
        objcuentasCXC.valorCredito = valorCredito
        objcuentasCXC.fechaNRad = fechaNRad.Value
        objcuentasCXC.observacion = txtMotivo.Text
        Dim Index As Integer = 0
        For Each drFila As DataRow In dtCuentas.Rows
            If drFila.Item("Cuenta").ToString <> "" Then
                Dim drCuenta As DataRow = objcuentasCXC.dtCuentas.NewRow
                drCuenta.Item("factura") = Textcodfactura.Text
                drCuenta.Item("idEmpresa") = SesionActual.idEmpresa
                drCuenta.Item("codigo_puc") = codigoPuc
                drCuenta.Item("codigoCuenta") = drFila.Item("Cuenta")
                drCuenta.Item("debito") = drFila.Item("debito")
                drCuenta.Item("credito") = drFila.Item("credito")
                drCuenta.Item("orden") = Index
                objcuentasCXC.dtCuentas.Rows.Add(drCuenta)
                Index += 1

            End If
        Next
        Return objcuentasCXC
    End Function

    Private Sub FormFacturaVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        Dim cuenta, descripcion, naturaleza, debito, credito As New DataColumn

        cuenta.ColumnName = "Cuenta"
        cuenta.DataType = Type.GetType("System.String")
        dtCuentas.Columns.Add(cuenta)

        descripcion.ColumnName = "Descripcion"
        descripcion.DataType = Type.GetType("System.String")
        dtCuentas.Columns.Add(descripcion)

        naturaleza.ColumnName = "Naturaleza"
        naturaleza.DataType = Type.GetType("System.String")
        dtCuentas.Columns.Add(naturaleza)

        debito.ColumnName = "Debito"
        debito.DataType = Type.GetType("System.Double")
        dtCuentas.Columns.Add(debito)
        dtCuentas.Columns("Debito").DefaultValue = "0,00"

        credito.ColumnName = "Credito"
        credito.DataType = Type.GetType("System.Double")
        dtCuentas.Columns.Add(credito)
        dtCuentas.Columns("Credito").DefaultValue = "0,00"

        dgvCuentas.DataSource = dtCuentas
        btExonerar.Visible = False

        With dgvCuentas
            .Columns("Cuenta").ReadOnly = True
            .Columns("Cuenta").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cuenta").DataPropertyName = "Cuenta"
            .Columns("Cuenta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").DataPropertyName = "Descripcion"
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Naturaleza").ReadOnly = True
            .Columns("Naturaleza").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Naturaleza").DataPropertyName = "Naturaleza"
            .Columns("Debito").ReadOnly = True
            .Columns("Debito").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Debito").DataPropertyName = "Debito"
            .Columns("Credito").ReadOnly = True
            .Columns("Credito").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Credito").DataPropertyName = "Credito"
            .Columns("anular").ReadOnly = True
            .Columns("anular").DisplayIndex = CInt(dgvCuentas.ColumnCount - 1)
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
        dgvCuentas.DataSource = dtCuentas
        dgvCuentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgvCuentas.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        codigoPuc = FuncionesContables.obtenerPucActivo()
        General.deshabilitarControles(Me)
        codigoDocumento = Constantes.FACTURA_DE_VENTA

    End Sub
    Private Sub bloquearColumnas()
        With dgvCuentas
            .Columns("Naturaleza").ReadOnly = True
            .Columns("Descripcion").ReadOnly = True
        End With
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.limpiarControles(Me)
            General.deshabilitarBotones(ToolStrip1)
            General.habilitarControles(Me)
            Textsigla.Text = Constantes.SIGLA_FACTURA_VENTAS
            Textsigla_Leave(sender, e)
            Textsigla.ReadOnly = True
            Textforma_pago.ReadOnly = True
            Textnombredocumento.ReadOnly = True
            textnombreproveedor.ReadOnly = True
            Textnombredocumento.ReadOnly = True
            textproveedor.ReadOnly = True
            fecharecibo.Enabled = False
            btguardar.Enabled = True
            btcancelar.Enabled = True
            identificador = String.Empty
            bttercero.Focus()
            PnlInfo.Visible = False
            textvalorcredito.Text = FormatCurrency(0, 2)
            textvalordebito.Text = FormatCurrency(0, 2)
            textdiferencia.Text = FormatCurrency(0, 2)
            textvalorcredito.ReadOnly = True
            textvalordebito.ReadOnly = True
            textdiferencia.ReadOnly = True
            Textsigla.ReadOnly = True
            Textcodfactura.ReadOnly = True
            gboxNRad.Visible = False
            chkNuevaRad.Visible = False
            bloquearColumnas()
            total.ReadOnly = True
            Textcodfactura.ReadOnly = False
            fechaNRad.Enabled = False
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargarDatos(pCodigo As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.CUENTAS_CXC_CLIENTE_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            Textsigla.Text = dt.Rows(0).Item("Sigla").ToString()
            Textnombredocumento.Text = dt.Rows(0).Item("Descripcion_Documento").ToString()
            fechadoc.Value = dt.Rows(0).Item("Fecha_Doc").ToString()
            fecharecibo.Value = dt.Rows(0).Item("Fecha_Recibo").ToString()
            fechavence.Value = dt.Rows(0).Item("Fecha_Vence").ToString()
            textnombreproveedor.Text = dt.Rows(0).Item("Cliente").ToString()
            textproveedor.Text = dt.Rows(0).Item("Nit").ToString()
            Textcodfactura.Text = dt.Rows(0).Item("Factura").ToString()
            textvalordebito.Text = dt.Rows(0).Item("valor_debito").ToString()
            textvalorcredito.Text = dt.Rows(0).Item("valor_credito").ToString()
            idTercero = dt.Rows(0).Item("id_cliente").ToString()
            fechaNRad.Value = IIf(String.IsNullOrEmpty(dt.Rows(0).Item("Valor").ToString()), Today, dt.Rows(0).Item("Valor").ToString())
            If String.IsNullOrEmpty(fechaNRad.Value) = False Then
                TextBox1.Visible = False
            Else
                TextBox1.Visible = True
            End If
            llenarDetalleCuentas(pCodigo, SesionActual.idEmpresa)
            General.habilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            fechaNRad.Enabled = False
            chkNuevaRad.Checked = False
            btguardar.Enabled = False
            btcancelar.Enabled = False
            If FuncionesContables.verificarFecha(fechadoc.Value) Then
                mostrarInfo(String.Format(Mensajes.PERIODO_CONTABLE_CERRADO), Color.Black, Color.Red)
                bteditar.Enabled = False
            Else
                mostrarInfo(Nothing, Nothing, Nothing, True)
                PnlInfo.Visible = False
            End If
        End If
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
    Private Sub dgvcuentas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCuentas.CellDoubleClick
        Dim params As New List(Of String)
        params.Add(codigoPuc)
        params.Add("")
        Try
            If btguardar.Enabled = False Or FuncionesContables.consultarMovimientosComprobante(Consultas.FACTURA_VENTA_CONSULTAR, Textcodfactura.Text) = False Then
                Exit Sub
            End If
            If dgvCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Cells("Cuenta").Selected = True And Textcodfactura.Text <> "" Then
                General.busquedaItems(Consultas.BUSQUEDA_CUENTAS_DETALLE_PUC, params, TitulosForm.BUSQUEDA_CUENTAS_PUC, dgvCuentas, dtCuentas, 0, 2, 0, 0, 0, 0, 1)
            ElseIf dgvCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Cells("anular").Selected = True And dtCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Item("Cuenta").ToString <> "" Then
                dtCuentas.Rows.RemoveAt(e.RowIndex)

            End If
            diseñoDgv()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Private Sub cargarFacturaGuardada(pFactura As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        Dim params2 As New List(Of String)
        params.Add(pFactura)
        params2.Add(pFactura)
        params2.Add(idTercero)
        General.llenarTabla(Consultas.FACTURA_CLIENTE_GUARDADA, params, dt)
        If dt.Rows.Count > 0 Then
            Textcodfactura.Text = dt.Rows(0).Item("codigo_factura").ToString()
            cargarDatos(Textcodfactura.Text)
            General.deshabilitarControles(Me)
            General.habilitarBotones(ToolStrip1)
            btguardar.Enabled = False
            btcancelar.Enabled = False
        Else
            dt.Clear()
            General.llenarTabla(Consultas.FACTURA_CLIENTE_CARGAR, params2, dt)
            If dt.Rows.Count > 0 Then
                fecharecibo.Value = dt.Rows(0).Item("Fecha_Factura").ToString()
                fechavence.Value = dt.Rows(0).Item("Fecha_Vence").ToString()
                fecharecibo.Enabled = False
                fechavence.Enabled = False
                cargarFactura(Textcodfactura.Text)
            Else
                If dtCuentas.Rows.Count = 0 Then
                    If MsgBox("¿Factura no existe, desea ingresarla ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Ingresar") = MsgBoxResult.Yes Then
                        fecharecibo.Enabled = True
                        fechavence.Enabled = True
                        fecharecibo.Value = Date.Now
                        fechavence.Value = Date.Now
                        dtCuentas.Rows.Add()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub cargarFactura(pFactura As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pFactura)
        params.Add(idTercero)
        General.llenarTabla(Consultas.FACTURA_CLIENTE_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            Textcodfactura.Text = pFactura
            fecharecibo.Value = dt.Rows(0).Item("Fecha_Factura").ToString()
            fechavence.Value = dt.Rows(0).Item("Fecha_Vence").ToString()
            llenarFactura(Textcodfactura.Text)
            fecharecibo.Enabled = False
            fechavence.Enabled = False
            btExonerar.Visible = True
        End If
    End Sub
    Private Sub dgvcuentas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCuentas.CellEndEdit

        If dtCuentas.Rows(dgvCuentas.CurrentRow.Index).Item(0).ToString <> "" Then
            Dim params As New List(Of String)
            params.Add(codigoPuc)
            params.Add(dtCuentas.Rows(dgvCuentas.CurrentRow.Index).Item(0).ToString)

            Dim fila As DataRow
            fila = FuncionesContables.digitarCuenta(params)
            If Not IsNothing(fila) Then

                If dtCuentas.Rows(dgvCuentas.CurrentRow.Index).Item(0).ToString <> "" And dtCuentas.Rows(dgvCuentas.CurrentRow.Index).Item(1).ToString = "" Then
                    dtCuentas.Rows(dgvCuentas.CurrentRow.Index).Item(1) = fila(2)
                    dtCuentas.Rows(dgvCuentas.CurrentRow.Index).Item(2) = fila(5)
                    dtCuentas.Rows.Add()
                Else
                    dtCuentas.Rows(dgvCuentas.CurrentRow.Index).Item(1) = fila(2)
                    dtCuentas.Rows(dgvCuentas.CurrentRow.Index).Item(2) = fila(5)
                End If
            Else
                dgvCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Cells("Cuenta").Value = String.Empty
                dgvCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Cells("Descripcion").Value = String.Empty
                If dtCuentas.Rows.Count > 1 And dgvCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Cells("Cuenta").Value = String.Empty And e.RowIndex <> dgvCuentas.Rows.Count - 1 Then
                    dtCuentas.Rows.RemoveAt(e.RowIndex)
                    calcularTotales()
                End If
            End If
            If dtCuentas.Rows(dgvCuentas.CurrentRow.Index).Item(1).ToString = "" Then
                dgvCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Cells("Cuenta").Value = String.Empty
                Exit Sub
            Else
                Dim filaRetencion As DataRow
                filaRetencion = FuncionesContables.llenarRetencion(params)
                If Not IsNothing(filaRetencion) Then
                    lblivarete.Text = filaRetencion("Cuenta").ToString()
                    porcentaje.Text = filaRetencion("tasa").ToString()
                    porcentaje.Text = Replace(porcentaje.Text, ".", ",")
                    nat.Text = filaRetencion("naturaleza").ToString()
                    Panel3.Visible = True
                    base.Focus()
                End If

            End If

            If dtCuentas.Rows(dgvCuentas.CurrentRow.Index).Item("Debito").ToString = "" Then
                dgvCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Cells("Debito").Value = 0
            ElseIf dtCuentas.Rows(dgvCuentas.CurrentRow.Index).Item("Credito").ToString = "" Then
                dgvCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Cells("Credito").Value = 0
            End If
            dtCuentas.AcceptChanges()

        End If

    End Sub
    Private Sub base_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles base.KeyPress, porcentaje.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub
    Private Sub bttercero_Click(sender As Object, e As EventArgs) Handles bttercero.Click
        Dim params As New List(Of String)
        params.Add("")
        params.Add(SesionActual.idEmpresa)

        General.buscarElemento(Consultas.BUSQUEDA_CLIENTES,
                              params,
                              AddressOf cargarTercero,
                              TitulosForm.BUSQUEDA_TERCERO,
                              True, 0, True)

    End Sub
    Public Sub cargarTercero(pCodigo)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        idTercero = pCodigo
        General.llenarTabla(Consultas.CONTA_TERCERO_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            textproveedor.Text = dt.Rows(0).Item("Nit").ToString()
            textnombreproveedor.Text = dt.Rows(0).Item("Tercero").ToString()
            dtCuentas.Clear()
            Textcodfactura.Clear()
        End If
    End Sub

    Private Sub btfactura_Click(sender As Object, e As EventArgs) Handles btfactura.Click
        If textnombreproveedor.Text <> "" Then
            Dim params As New List(Of String)
            params.Add(idTercero)
            params.Add(SesionActual.idEmpresa)
            General.buscarElemento(Consultas.FACTURAS_CLIENTE_BUSCAR,
                                  params,
                                  AddressOf cargarFactura,
                                  TitulosForm.BUSQUEDA_FACTURAS,
                                  False, True, True)
        Else
            MsgBox("Debe escoger un tercero", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.idEmpresa)

            General.buscarElemento(Consultas.CUENTAS_CXC_CLIENTE_BUSCAR,
                                   params,
                                   AddressOf cargarDatos,
                                   TitulosForm.BUSQUEDA_FACTURA_DE_VENTAS,
                                   False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If FuncionesContables.consultarMovimientosComprobante(Consultas.FACTURA_VENTA_CONSULTAR, Textcodfactura.Text) Then
                If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.No Then
                    Exit Sub
                Else
                    identificador = Textcodfactura.Text
                    textvalorcredito.Text = FormatCurrency(0, 2)
                    textvalordebito.Text = FormatCurrency(0, 2)
                    textdiferencia.Text = FormatCurrency(0, 2)
                    dtCuentas.Rows.Add()
                    btBusquedaDocumento.Enabled = False
                    bttercero.Enabled = False
                    btfactura.Enabled = False
                    Textsigla.ReadOnly = True
                    textvalorcredito.ReadOnly = True
                    textvalordebito.ReadOnly = True
                    textdiferencia.ReadOnly = True
                    Textnombredocumento.ReadOnly = True
                    Textcodfactura.Enabled = False
                    btcxc.Enabled = True
                    dgvCuentas.ReadOnly = False
                    gboxNRad.Visible = True
                    chkNuevaRad.Visible = True
                    chkNuevaRad.Enabled = True
                    fechaNRad.Enabled = False
                    chkNuevaRad.Checked = False
                    bloquearColumnas()
                    General.deshabilitarBotones(ToolStrip1)
                    btguardar.Enabled = True
                    btcancelar.Enabled = True
                    base.ReadOnly = False
                End If
            Else
                If MsgBox("Solo puede editar la Fecha de Re-Radicación porque la factura registra otros movimientos. ¿Desea hacerlo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                    'MsgBox("No se puede editar la factura por que registra otros movimientos", MsgBoxStyle.Critical)
                    identificador = Textcodfactura.Text
                    gboxNRad.Visible = True
                    chkNuevaRad.Visible = True
                    chkNuevaRad.Enabled = True
                    fechaNRad.Enabled = False
                    chkNuevaRad.Checked = False
                    bloquearColumnas()
                    General.deshabilitarBotones(ToolStrip1)
                    btguardar.Enabled = True
                    btcancelar.Enabled = True
                    base.ReadOnly = False
                End If
            End If
        Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub crearCuentaPorCobrar(idCliente As Integer, idEmpresa As Integer)
        Dim diferencia As Double
        If textproveedor.Text <> "" Then
            Dim params As New List(Of String)
            params.Add(idCliente)
            params.Add(idEmpresa)
            idTercero = idCliente
            dgvCuentas.EndEdit()

            If dgvCuentas.Rows.Count > 1 Then
                Dim valorDebito, sumaDebito, sumaCredito, valorCredito As Double
                For indicedtCuentas = 0 To dgvCuentas.Rows.Count - 1
                    If dgvCuentas.Rows(indicedtCuentas).Cells(4).Value.ToString = "" Then
                        dgvCuentas.Rows(indicedtCuentas).Cells(4).Value = 0
                    End If
                    If dgvCuentas.Rows(indicedtCuentas).Cells(5).Value.ToString = "" Then
                        dgvCuentas.Rows(indicedtCuentas).Cells(5).Value = 0
                    End If
                    sumaDebito = CDbl(dgvCuentas.Rows(indicedtCuentas).Cells(4).Value)
                    sumaCredito = CDbl(dgvCuentas.Rows(indicedtCuentas).Cells(5).Value)
                    valorDebito = valorDebito + sumaDebito
                    valorCredito = valorCredito + sumaCredito
                Next
                diferencia = FormatCurrency((CDbl(valorCredito) - CDbl(valorDebito)), 2)
                Dim dtCliente As New DataTable
                General.llenarTabla(Consultas.CUENTA_POR_COBRAR_CREAR, params, dtCliente)
                If dtCliente.Rows.Count > 0 Then

                    For indicedtCuentas = 0 To dgvCuentas.Rows.Count - 1
                        If dgvCuentas.Rows(indicedtCuentas).Cells(1).Value.ToString = dtCliente.Rows(0).Item("Cuenta").ToString Then
                            MsgBox("Ya existe una cuenta cliente en el movimiento")
                            Exit Sub
                        End If
                    Next

                    dtCuentas.Rows(dtCuentas.Rows.Count - 1).Item("Cuenta") = dtCliente.Rows(0).Item("Cuenta")
                    dtCuentas.Rows(dtCuentas.Rows.Count - 1).Item("Descripcion") = dtCliente.Rows(0).Item("Descripcion")
                    dtCuentas.Rows(dtCuentas.Rows.Count - 1).Item("Naturaleza") = dtCliente.Rows(0).Item("Naturaleza")
                    If dtCliente.Rows(0).Item("Naturaleza") = Constantes.NATURALEZA_DEBITO Then
                        dtCuentas.Rows(dtCuentas.Rows.Count - 1).Item("Debito") = diferencia
                        dtCuentas.Rows(dtCuentas.Rows.Count - 1).Item("Credito") = "0,00"
                        dtCuentas.Rows.Add()
                    Else
                        dtCuentas.Rows(dtCuentas.Rows.Count - 1).Item("Debito") = "0,00"
                        dtCuentas.Rows(dtCuentas.Rows.Count - 1).Item("Credito") = diferencia
                        dtCuentas.Rows.Add()
                    End If
                    calcularTotales()
                Else
                    MsgBox("No hay una cuenta asignada a este cliente", 48, "Atención")
                End If
            End If
        Else
            MsgBox("Por favor elija el cliente", 48, "Atención")
        End If

    End Sub
    Private Sub btCXC_Click(sender As Object, e As EventArgs) Handles btCXC.Click
        crearCuentaPorCobrar(idTercero, SesionActual.idEmpresa)
    End Sub
    Private Sub dgvCuentas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCuentas.CellEnter
        calcularTotales()
        If e.ColumnIndex = 4 Then
            FuncionesContables.ValidarCreditoDebito(dgvCuentas, Constantes.COLUMNA_DEBITO, Constantes.COLUMNA_CREDITO)
        ElseIf e.ColumnIndex = 5 Then
            FuncionesContables.ValidarCreditoDebito(dgvCuentas, Constantes.COLUMNA_CREDITO, Constantes.COLUMNA_DEBITO)
        End If
        bloquearColumnas()
    End Sub
    Private Sub dgvcuentas_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvCuentas.DataError
        If e.ColumnIndex = 4 Then
            For i = 0 To dgvCuentas.Rows.Count - 1
                If dgvCuentas.Rows(i).Cells(4).Value.ToString = "" Then
                    MsgBox("Por Favor ingrese un valor ", MsgBoxStyle.Exclamation)
                End If
            Next
        ElseIf e.ColumnIndex = 5 Then
            For i = 0 To dgvCuentas.Rows.Count - 1
                If dgvCuentas.Rows(i).Cells(5).Value.ToString = "" Then
                    MsgBox("Por Favor ingrese un valor ", MsgBoxStyle.Exclamation)
                End If
            Next
        End If
    End Sub
    Private Sub dgvCuentas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCuentas.CellClick
        If e.ColumnIndex = 4 Then
            FuncionesContables.ValidarCreditoDebito(dgvCuentas, Constantes.COLUMNA_DEBITO, Constantes.COLUMNA_CREDITO)
        ElseIf e.ColumnIndex = 5 Then
            FuncionesContables.ValidarCreditoDebito(dgvCuentas, Constantes.COLUMNA_CREDITO, Constantes.COLUMNA_DEBITO)
        End If
        bloquearColumnas()
    End Sub

    Private Sub fechadoc_Leave(sender As Object, e As EventArgs) Handles fechadoc.Leave
        FuncionesContables.validarFechaFutura(fechadoc)
    End Sub
    Private Sub btCuentas_Click(sender As Object, e As EventArgs)
        Dim formCuenta As New Form_CuentasPUC
        formCuenta.ShowDialog()
    End Sub

    Private Sub chkNuevaRad_CheckedChanged(sender As Object, e As EventArgs) Handles chkNuevaRad.CheckedChanged
        fechaNRad.Enabled = Not (fechaNRad.Enabled)
        TextBox1.Visible = False
    End Sub

    Private Sub fechaNRad_ValueChanged(sender As Object, e As EventArgs) Handles fechaNRad.ValueChanged
        Dim fechaNuevaRadicacion As Date
        Dim fechaDocumento As Date
        If chkNuevaRad.Visible = True And gboxNRad.Visible = True Then
            fechaDocumento = Format(fechadoc.Value, Constantes.FORMATO_FECHA_ACTUAL)
            fechaNuevaRadicacion = Format(fechaNRad.Value, Constantes.FORMATO_FECHA_ACTUAL)
            If fechaNuevaRadicacion < fechaDocumento Then
                MsgBox("La Fecha de la Nueva Radicación no puede ser menor a la de la anterior Radicación")
                fechaNRad.Value = Today
            End If
        End If
    End Sub

    Private Sub btExonerar_Click(sender As Object, e As EventArgs) Handles btExonerar.Click
        GroupBox1.Enabled = False
        dgvCuentas.Enabled = False
        ToolStrip1.Enabled = False
        btExonerar.Enabled = False
        txtMotivo.Enabled = True
        txtMotivo.ReadOnly = False
        txtMotivo.Clear()
        General.habilitarBotones(ToolStrip3)
        gbMotivo.Visible = True
        gbMotivo.Enabled = True
        gbMotivo.BringToFront()
    End Sub

    Private Sub tsGuardarMotivo_Click(sender As Object, e As EventArgs) Handles tsGuardarMotivo.Click
        Dim objcuentasCXC As New CuentasPorCobrar
        Dim objcuentasCXCBll As New CuentasPorCobrarBLL
        If txtMotivo.TextLength = 0 Then
            MsgBox(Mensajes.EXONERAR_SIN_MOTIVO, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        objcuentasCXCBll.guardarExoneracion(crearCuentasCXC())
        btExonerar.Visible = False
        gbMotivo.Visible = False
        GroupBox1.Enabled = True
        ToolStrip1.Enabled = True
        General.limpiarControles(Me)
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        MsgBox(Mensajes.EXONERAR_FACTURA_ATENCION, MsgBoxStyle.Information)
    End Sub

    Private Sub tsCancelarMotivo_Click(sender As Object, e As EventArgs) Handles tsCancelarMotivo.Click
        gbMotivo.Visible = False
        GroupBox1.Enabled = True
        ToolStrip1.Enabled = True
        btExonerar.Enabled = True
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar) = True Then
            gboxNRad.Visible = False
            chkNuevaRad.Visible = False
            btExonerar.Visible = False
        End If
    End Sub
    Private Sub dgvcartera_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvCuentas.EditingControlShowing,
            dgvCuentas.EditingControlShowing
        If dgvCuentas.CurrentCell.ColumnIndex = 2 Or dgvCuentas.CurrentCell.ColumnIndex = 4 Or dgvCuentas.CurrentCell.ColumnIndex = 0 Then
            AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
        End If
    End Sub
    Private Sub Form_antici_decucci_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub btBusquedaDocumento_Click(sender As Object, e As EventArgs) Handles btBusquedaDocumento.Click
        General.buscarElemento(Consultas.DOCUMENTOS_SIGLA_BUSCAR,
                              Nothing,
                              AddressOf cargarDocumento,
                              TitulosForm.BUSQUEDA_DOCUMENTOS_CONTABLES,
                              False)
    End Sub
    Private Sub Textsigla_Leave(sender As Object, e As EventArgs) Handles Textsigla.Leave
        If Textsigla.Text <> "" Then
            cargarDocumento(Textsigla.Text)
        End If
    End Sub
    Private Sub Textcodfactura_Leave(sender As Object, e As EventArgs) Handles Textcodfactura.Leave
        If textproveedor.Text <> "" Then
            cargarFacturaGuardada(Textcodfactura.Text)
        Else
            bttercero.Focus()
        End If
    End Sub
    Private Sub form_factura_CLIENTE_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim vPorcentaje, vBase As Double
        If porcentaje.Text <> "" Then
            vPorcentaje = porcentaje.Text
        End If

        If base.Text <> "" Then
            vBase = base.Text
        End If
        If e.KeyChar = ChrW(Keys.Escape) And Panel3.Visible = True Then
            Panel3.Visible = False
            base.Text = ""
            total.Text = ""
            dgvCuentas.Focus()
        ElseIf Panel3.Visible = True And e.KeyChar = Chr(13) Then
            If base.Focused() = True Then
                If base.Text <> "" Then
                    If base.Text <> 0 Then
                        vPorcentaje = Replace(vPorcentaje, ".", ",")
                        total.Text = CDbl(vBase) * CDbl(vPorcentaje) / 100
                        total.Focus()
                    Else
                        MsgBox("la cantidad base no puede ser cero", MsgBoxStyle.Exclamation)
                        base.Focus()
                    End If
                Else
                    MsgBox("Digite cantidad base", MsgBoxStyle.Exclamation)
                    base.Focus()
                End If
            ElseIf total.Focused() = True Then
                Panel3.Visible = False
                dgvCuentas.Enabled = True
                bttercero.Enabled = True
                btfactura.Enabled = True

                Textcodfactura.Enabled = True
                ToolStrip1.Enabled = True
                If base.Text <> "" Then
                    If nat.Text = Constantes.PUC_NATURALEZA_DEBITO Then
                        dtCuentas.Rows(dgvCuentas.CurrentRow.Index).Item(3) = total.Text
                    Else
                        dtCuentas.Rows(dgvCuentas.CurrentRow.Index).Item(4) = total.Text
                    End If
                End If
                base.Text = ""
                total.Text = ""
                dgvCuentas.Focus()
            End If

        End If
    End Sub
End Class