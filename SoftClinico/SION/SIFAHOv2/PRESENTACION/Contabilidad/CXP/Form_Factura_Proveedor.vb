Public Class Form_Factura_Proveedor
    Dim dtCuentas As New DataTable
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, identificador As String
    Dim codigoPuc, codigoDocumento, idTercero, vPorcentaje As Integer
    Private Sub validarControles()
        Textsigla.ReadOnly = True
        Textforma_pago.ReadOnly = True
        Textnombredocumento.ReadOnly = True
        textnombreproveedor.ReadOnly = True
        textproveedor.ReadOnly = True
        fecharecibo.Enabled = False
        btguardar.Enabled = True
        btcancelar.Enabled = True
        textproveedor.ReadOnly = True
        Textcodfactura.ReadOnly = True
        bttercero.Focus()
        deshabilitarColumnas()
        base.ReadOnly = False
        PnlInfo.Visible = False
        btcxp.Enabled = True
        General.deshabilitarControles(gpCuentas)
    End Sub
    Private Sub diseñoDgv()
        dgvCuentas.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCuentas.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCuentas.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCuentas.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCuentas.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCuentas.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCuentas.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub
    Private Sub llenardgv(pCodigo As String, idempresa As Integer)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(idempresa)
        txtcodigo.Text = pCodigo
        SesionActual.idEmpresa = idempresa
        General.llenarTabla(Consultas.CUENTAS_CXP_PROVEEDOR_DETALLE_CARGAR, params, dtCuentas)
        If dtCuentas.Rows.Count > 0 Then
            calcularTotales()
        Else
            textdiferencia.Text = FormatCurrency(0, 2)
        End If
        diseñoDgv()
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
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

        If textproveedor.Text = "" Then
            MsgBox("Por Favor Elija el proveedor", 48, "Atención")
            bttercero.Focus()
        ElseIf Textcodfactura.Text = "" Then
            MsgBox("Por Favor digite el numero de factura", 48, "Atención")
            btfactura.Focus()
        ElseIf CDbl(textvalorcredito.Text) = 0 Or CDbl(textvalordebito.Text) = 0 Then
            MsgBox("Por Favor Corrija el movimiento, los saldos debito y credito no son iguales o estan en CERO", 48, "Atención")
            dgvCuentas.Focus()
        ElseIf Format(CDate(fecharecibo.Value), "yyyyMMdd") = Format(CDate(fechavence.Value), "yyyyMMdd") And Textforma_pago.Text = "Credito" Then
            MsgBox("La fecha de vencimiento no puede ser igual a la fecha de recibo si fue una compra a crédito", 48, "Atención")
            fechavence.Focus()
        ElseIf Format(CDate(fecharecibo.Value), "yyyyMMdd") > Format(CDate(fechavence.Value), "yyyyMMdd") Then
            MsgBox("La fecha de vencimiento no puede ser menor a la fecha de recibo", 48, "Atención")
            fechavence.Focus()
        ElseIf CDbl(textdiferencia.Text) <> 0 Then
            MsgBox("Por corrija el movimiento la diferencia debe ser cero", 48, "Atención")
        ElseIf FuncionesContables.validardgv(dtCuentas) = False Then
        ElseIf FuncionesContables.verificarFecha(fechadoc.Value) Then
            mostrarInfo(String.Format(Mensajes.PERIODO_CONTABLE_CERRADO), Color.White, Color.Red)
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
            Dim valorDebito, sumaDebito, sumaCredito, valorCredito, valorIva, valorRetencion As Double

            If dgvCuentas.Rows.Count > 1 Then

                For indicedgvCuentas = 0 To dgvCuentas.Rows.Count - 1
                    If dgvCuentas.Rows(indicedgvCuentas).Cells("Descripcion").Value.ToString <> "" Then
                        sumaDebito = CDbl(dgvCuentas.Rows(indicedgvCuentas).Cells(4).Value)
                        sumaCredito = CDbl(dgvCuentas.Rows(indicedgvCuentas).Cells(5).Value)
                        valorDebito = valorDebito + sumaDebito
                        valorCredito = valorCredito + sumaCredito
                        If dgvCuentas.Rows(indicedgvCuentas).Cells(0).Value.ToString.StartsWith("2408") Or dgvCuentas.Rows(indicedgvCuentas).Cells(0).Value.ToString.StartsWith("5115") Or dgvCuentas.Rows(indicedgvCuentas).Cells(0).Value.ToString.StartsWith("5215") Then
                            valorIva = CDbl(valorIva) + CDbl(dgvCuentas.Rows(indicedgvCuentas).Cells(4).Value) - CDbl(dgvCuentas.Rows(indicedgvCuentas).Cells(5).Value)
                        End If
                        If dgvCuentas.Rows(indicedgvCuentas).Cells(0).Value.ToString.StartsWith("1355") Or dgvCuentas.Rows(indicedgvCuentas).Cells(0).Value.ToString.StartsWith("2365") Or dgvCuentas.Rows(indicedgvCuentas).Cells(0).Value.ToString.StartsWith("2368") Then
                            valorRetencion = CDbl(valorRetencion) + CDbl(dgvCuentas.Rows(indicedgvCuentas).Cells(4).Value) - CDbl(dgvCuentas.Rows(indicedgvCuentas).Cells(5).Value)
                        End If
                    End If
                Next
                textdiferencia.Text = FormatCurrency((CDbl(valorDebito) - CDbl(valorCredito)), 2)
                textvaloriva.Text = CDbl(valorIva).ToString("C2")
                textvalorrete.Text = CDbl(valorRetencion).ToString("C2")
                textvalordebito.Text = CDbl(valorDebito).ToString("C2")
                textvalorcredito.Text = CDbl(valorCredito).ToString("C2")
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub cargarDocumento(codigo As String)
        Dim objDocumentoContable As DocumentoContable = FuncionesContables.cargarDocumento(codigo)
        codigoDocumento = objDocumentoContable.codigo
        Textsigla.Text = codigo.ToUpper
        Textnombredocumento.Text = objDocumentoContable.descripcion
    End Sub

    Private Sub dgvcuentas_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvCuentas.KeyDown
        Dim params As New List(Of String)
        params.Add(codigoPuc)
        params.Add("")
        If e.KeyCode = Keys.F3 And btguardar.Enabled = True Then
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
            If FuncionesContables.validarDatosDgv(dgvCuentas, 2) Then
                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                    codigoPuc = FuncionesContables.obtenerPucActivo()
                    calcularTotales()
                    dgvCuentas.EndEdit()
                    dtCuentas.AcceptChanges()
                    Dim objcuentasCxpBll As New CuentaPorPagarBLL
                    Try
                        objcuentasCxpBll.guardarCuentaPorPagar(crearCuentasCXP(), SesionActual.idUsuario)
                        llenardgv(txtcodigo.Text, SesionActual.idEmpresa)
                        General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                    Catch ex As Exception
                        General.manejoErrores(ex)
                    End Try
                End If
            End If
        End If
    End Sub
    Public Function crearCuentasCXP() As CuentasPorPagar
        Dim objcuentasCXP As New CuentasPorPagar
        Dim valorDebito, valorCredito, valorIva, valorRete As Double
        valorDebito = textvalordebito.Text
        valorCredito = textvalorcredito.Text
        valorIva = textvaloriva.Text
        valorRete = textvalorrete.Text
        If String.IsNullOrEmpty(identificador) Then
            txtcodigo.Text = FuncionesContables.verificarConsecutivo(SesionActual.idEmpresa, codigoDocumento)
        End If
        objcuentasCXP.comprobante = txtcodigo.Text
        objcuentasCXP.idEmpresa = SesionActual.idEmpresa
        objcuentasCXP.idProveedor = idTercero
        objcuentasCXP.fechaRecibo = fecharecibo.Value
        objcuentasCXP.fechaVence = fechavence.Value
        objcuentasCXP.fechaDoc = fechadoc.Value
        objcuentasCXP.observacion = textobserva.Text
        objcuentasCXP.identificador = identificador
        objcuentasCXP.codigoDocumento = codigoDocumento
        objcuentasCXP.factura = Textcodfactura.Text
        objcuentasCXP.valorDebito = valorDebito
        objcuentasCXP.valorCredito = valorCredito
        objcuentasCXP.valorIva = valorIva
        objcuentasCXP.valorRete = valorRete
        Dim Index As Integer = 0
        For Each drFila As DataRow In dtCuentas.Rows
            If drFila.Item("Cuenta").ToString <> "" Then
                Dim drCuenta As DataRow = objcuentasCXP.dtCuentas.NewRow
                drCuenta.Item("comprobante") = txtcodigo.Text
                drCuenta.Item("codigo_puc") = codigoPuc
                drCuenta.Item("codigoCuenta") = drFila.Item("Cuenta")
                drCuenta.Item("debito") = drFila.Item("debito")
                drCuenta.Item("credito") = drFila.Item("credito")
                drCuenta.Item("orden") = Index
                objcuentasCXP.dtCuentas.Rows.Add(drCuenta)
                Index += 1
            End If
        Next
        Return objcuentasCXP
    End Function

    Private Sub Form_Factura_Proveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        dgvCuentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgvCuentas.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
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
        codigoPuc = FuncionesContables.obtenerPucActivo()
        General.deshabilitarControles(Me)
        codigoDocumento = Constantes.COMPROBANTE_DE_CAUSACION
    End Sub
    Private Sub deshabilitarColumnas()
        With dgvCuentas
            .Columns.Item("Descripcion").ReadOnly = True
            .Columns.Item("Naturaleza").ReadOnly = True
        End With
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.limpiarControles(Me)
            General.deshabilitarBotones(ToolStrip1)
            General.habilitarControles(Me)
            txtcodigo.Text = FuncionesContables.verificarConsecutivo(SesionActual.idEmpresa, codigoDocumento)
            Textsigla.Text = Constantes.SIGLA_COMPROBANTE_DE_CAUSACION
            cargarDocumento(Textsigla.Text)
            validarControles()
            textvalorcredito.Text = FormatCurrency(0, 2)
            textvalordebito.Text = FormatCurrency(0, 2)
            textdiferencia.Text = FormatCurrency(0, 2)
            Textcodfactura.Enabled = True
            fecharecibo.Enabled = True
            total.ReadOnly = True
            identificador = String.Empty
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargarDatos(pCodigo As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(SesionActual.idEmpresa)
        General.llenarTabla(Consultas.CUENTAS_CXP_PROVEEDOR_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            codigoDocumento = dt.Rows(0).Item("Codigo_Documento").ToString()
            Textsigla.Text = Constantes.SIGLA_COMPROBANTE_DE_CAUSACION
            cargarDocumento(Textsigla.Text)
            fechadoc.Value = dt.Rows(0).Item("Fecha_Doc").ToString()
            fecharecibo.Value = dt.Rows(0).Item("Fecha_Recibo").ToString()
            fechavence.Value = dt.Rows(0).Item("Fecha_Vence").ToString()
            textnombreproveedor.Text = dt.Rows(0).Item("Tercero").ToString()
            textproveedor.Text = dt.Rows(0).Item("Nit").ToString()
            Textcodfactura.Text = dt.Rows(0).Item("Factura").ToString()
            textobserva.Text = dt.Rows(0).Item("observacion").ToString()
            textvalordebito.Text = dt.Rows(0).Item("valor_debito").ToString()
            textvalorcredito.Text = dt.Rows(0).Item("valor_credito").ToString()
            textvaloriva.Text = dt.Rows(0).Item("valor_Iva").ToString()
            textvalorrete.Text = dt.Rows(0).Item("valor_rete").ToString()
            idTercero = dt.Rows(0).Item("Id_Proveedor").ToString()
            llenardgv(pCodigo, SesionActual.idEmpresa)
            General.habilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            btguardar.Enabled = False
            btcancelar.Enabled = False
            Textcodfactura.Enabled = False
            If FuncionesContables.verificarFecha(fechadoc.Value) Then
                mostrarInfo(String.Format(Mensajes.PERIODO_CONTABLE_CERRADO), Color.White, Color.Red)
                bteditar.Enabled = False
            Else
                mostrarInfo(Nothing, Nothing, Nothing, True)
                PnlInfo.Visible = False
            End If
            If FuncionesContables.verificarComprobante(pCodigo) Then
                mostrarInfo(String.Format(Mensajes.COMPROBANTE_ANULADO), Color.White, Color.Red)
                General.deshabilitarBotones(ToolStrip1)
                btbuscar.Enabled = True
                btnuevo.Enabled = True
            End If
            dgvCuentas.Focus()
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
            If btguardar.Enabled = False Then
                Exit Sub
            End If
            If (dgvCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Cells("Cuenta").Selected = True Or dgvCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Cells("Descripcion").Selected = True) Then
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
            ElseIf dgvCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Cells("anular").Selected = True And dtCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Item("Cuenta").ToString <> "" Then
                dtCuentas.Rows.RemoveAt(e.RowIndex)
            End If
            diseñoDgv()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub cargarFacturaGuardada(pFactura As String, pProveedor As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        Dim paramsFactura As New List(Of String)
        paramsFactura.Add(pFactura)
        paramsFactura.Add(pProveedor)
        paramsFactura.Add(SesionActual.idEmpresa)
        params.Add(pFactura)
        params.Add(pProveedor)
        params.Add(SesionActual.idEmpresa)
        If Not String.IsNullOrEmpty(pFactura) Then
            General.llenarTabla(Consultas.FACTURA_PROVEEDOR_GUARDADA, paramsFactura, dt)
            If dt.Rows.Count > 0 Then
                txtcodigo.Text = dt.Rows(0).Item("Comprobante").ToString()
                cargarDatos(txtcodigo.Text)
                General.deshabilitarControles(Me)
                General.habilitarBotones(ToolStrip1)
                btguardar.Enabled = False
                btcancelar.Enabled = False
            Else
                dt.Clear()
                General.llenarTabla(Consultas.FACTURA_PROVEEDOR_CARGAR, params, dt)
                If dt.Rows.Count > 0 Then
                    fecharecibo.Value = dt.Rows(0).Item("Fecha_Recepcion").ToString()
                    fechavence.Value = dt.Rows(0).Item("Fecha_Vence").ToString()
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
            diseñoDgv()
        End If
    End Sub
    Private Sub cargarFactura(pFactura As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pFactura)
        params.Add(idTercero)
        params.Add(SesionActual.idEmpresa)
        General.llenarTabla(Consultas.FACTURA_PROVEEDOR_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            dtCuentas.Clear()
            dtCuentas.Rows.Add()
        End If
        Textcodfactura.Text = pFactura
        fecharecibo.Value = dt.Rows(0).Item("Fecha_Recepcion").ToString()
        fechavence.Value = dt.Rows(0).Item("Fecha_Vence").ToString()
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
                Dim paramsRetencion As New List(Of String)
                paramsRetencion.Add(codigoPuc)
                paramsRetencion.Add(dtCuentas.Rows(dgvCuentas.CurrentRow.Index).Item(0).ToString)
                Dim filaRetencion As DataRow
                filaRetencion = FuncionesContables.llenarRetencion(paramsRetencion)
                diseñoDgv()

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
            diseñoDgv()
        End If
    End Sub

    Private Sub bttercero_Click(sender As Object, e As EventArgs) Handles bttercero.Click
        Dim params As New List(Of String)
        params.Add("")
        params.Add(SesionActual.idEmpresa)
        General.buscarElemento(Consultas.BUSQUEDA_PROVEEDOR,
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
        General.llenarTabla(Consultas.CONTA_PROVEEDOR_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            textproveedor.Text = dt.Rows(0).Item("Nit").ToString()
            textnombreproveedor.Text = dt.Rows(0).Item("Proveedor").ToString()
            Textforma_pago.Text = dt.Rows(0).Item("Forma_Pago").ToString()
            Textcodfactura.ReadOnly = False
            Textcodfactura.Focus()
            dtCuentas.Clear()
            Textcodfactura.Clear()
        End If
    End Sub

    Private Sub btfactura_Click(sender As Object, e As EventArgs) Handles btfactura.Click
        If textnombreproveedor.Text <> "" Then
            Dim params As New List(Of String)
            params.Add(SesionActual.codigoEP)
            params.Add(idTercero)
            General.buscarElemento(Consultas.FACTURAS_PROVEEDOR_BUSCAR,
                                  params,
                                  AddressOf cargarFactura,
                                  TitulosForm.BUSQUEDA_FACTURAS,
                                  False, 0, True)
        Else
            MsgBox("Debe escoger un tercero", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.idEmpresa)

            General.buscarElemento(Consultas.CUENTAS_CXP_PROVEEDOR_BUSCAR,
                                   params,
                                   AddressOf cargarDatos,
                                   TitulosForm.BUSQUEDA_COMPROBANTE_CAUSACION,
                                   False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If FuncionesContables.consultarMovimientosComprobante(Consultas.COMPROBANTE_CAUSACION_CONSULTAR, txtcodigo.Text) Then
                If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                    identificador = txtcodigo.Text
                    dtCuentas.Rows.Add()
                    dgvCuentas.ReadOnly = False
                    deshabilitarColumnas()
                    bttercero.Enabled = False
                    btBusquedaDocumento.Enabled = False
                    bttercero.Enabled = False
                    btfactura.Enabled = False
                    Textcodfactura.Enabled = False
                    validarControles()
                    total.ReadOnly = True
                    General.deshabilitarBotones(ToolStrip1)
                    btguardar.Enabled = True
                    btcancelar.Enabled = True
                    fechadoc.Enabled = True
                End If
            Else
                    MsgBox("No se puede editar el comprobante  por que registra otros movimientos", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub base_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles base.KeyPress, porcentaje.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub
    Private Sub crearCuentaPorCobrar(idproveedor As Integer)
        Dim diferencia As Double
        dgvCuentas.EndEdit()
        dtCuentas.AcceptChanges()
        If textproveedor.Text <> "" Then
            Dim params As New List(Of String)
            params.Add(idproveedor)
            params.Add(SesionActual.idEmpresa)
            idTercero = idproveedor
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
                diferencia = FormatCurrency((CDbl(valorDebito) - CDbl(valorCredito)), 2)
                Dim dtProvedor As New DataTable
                General.llenarTabla(Consultas.CUENTA_POR_PAGAR_CREAR, params, dtProvedor)

                If dtProvedor.Rows.Count > 0 Then
                    For indicedtCuentas = 0 To dgvCuentas.Rows.Count - 1
                        If dgvCuentas.Rows(indicedtCuentas).Cells(1).Value.ToString = dtProvedor.Rows(0).Item("Cuenta").ToString Then
                            MsgBox("Ya existe una cuenta proveedor en el movimiento")
                            Exit Sub
                        End If
                    Next

                    dtCuentas.Rows(dtCuentas.Rows.Count - 1).Item("Cuenta") = dtProvedor.Rows(0).Item("Cuenta")
                    dtCuentas.Rows(dtCuentas.Rows.Count - 1).Item("Descripcion") = dtProvedor.Rows(0).Item("Descripcion")
                    dtCuentas.Rows(dtCuentas.Rows.Count - 1).Item("Naturaleza") = dtProvedor.Rows(0).Item("Naturaleza")
                    If dtProvedor.Rows(0).Item("Naturaleza") = Constantes.NATURALEZA_DEBITO Then
                        dtCuentas.Rows(dtCuentas.Rows.Count - 1).Item("Debito") = Math.Abs(diferencia)
                        dtCuentas.Rows(dtCuentas.Rows.Count - 1).Item("Credito") = "0,00"
                        dtCuentas.Rows.Add()
                    Else
                        dtCuentas.Rows(dtCuentas.Rows.Count - 1).Item("Debito") = "0,00"
                        dtCuentas.Rows(dtCuentas.Rows.Count - 1).Item("Credito") = Math.Abs(diferencia)
                        dtCuentas.Rows.Add()
                    End If

                Else
                    MsgBox("No hay una cuenta asignada a este proveedor", 48, "Atención")
                End If
            End If
            Else
            MsgBox("Por favor elija un proveedor", 48, "Atención")
        End If
    End Sub
    Private Sub btcxp_Click(sender As Object, e As EventArgs) Handles btcxp.Click
        crearCuentaPorCobrar(idTercero)
    End Sub

    Private Sub dgvCuentas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCuentas.CellEnter
        calcularTotales()
        If e.ColumnIndex = 4 Then
            FuncionesContables.ValidarCreditoDebito(dgvCuentas, Constantes.COLUMNA_DEBITO, Constantes.COLUMNA_CREDITO)
        ElseIf e.ColumnIndex = 5 Then
            FuncionesContables.ValidarCreditoDebito(dgvCuentas, Constantes.COLUMNA_CREDITO, Constantes.COLUMNA_DEBITO)
        End If
        deshabilitarColumnas()
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
    Private Sub btCuentas_Click(sender As Object, e As EventArgs)
        Dim formCuenta As New Form_CuentasPUC
        formCuenta.ShowDialog()
    End Sub

    Private Sub dgvCuentas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCuentas.CellClick
        If e.ColumnIndex = 4 Then
            FuncionesContables.ValidarCreditoDebito(dgvCuentas, Constantes.COLUMNA_DEBITO, Constantes.COLUMNA_CREDITO)
        ElseIf e.ColumnIndex = 5 Then
            FuncionesContables.ValidarCreditoDebito(dgvCuentas, Constantes.COLUMNA_CREDITO, Constantes.COLUMNA_DEBITO)
        End If
        deshabilitarColumnas()
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
        PnlInfo.Visible = False
    End Sub

    Private Sub dgvcartera_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvCuentas.EditingControlShowing,
            dgvCuentas.EditingControlShowing
        If dgvCuentas.CurrentCell.ColumnIndex = 5 Or dgvCuentas.CurrentCell.ColumnIndex = 4 Or dgvCuentas.CurrentCell.ColumnIndex = 1 Then
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
    '--------------- proximo a quitar 
    'Private Sub btBusquedaDocumento_Click(sender As Object, e As EventArgs) Handles btBusquedaDocumento.Click
    '    General.buscarElemento(Consultas.DOCUMENTOS_SIGLA_BUSCAR,
    '                          Nothing,
    '                          AddressOf cargarDocumento,
    '                          TitulosForm.BUSQUEDA_DOCUMENTOS_CONTABLES,
    '                          False)
    'End Sub

    Private Sub Textcodfactura_Leave(sender As Object, e As EventArgs) Handles Textcodfactura.Leave
        If Not String.IsNullOrEmpty(textproveedor.Text) Then
            cargarFacturaGuardada(Textcodfactura.Text, idTercero)
        End If
    End Sub
    Private Sub form_factura_proveedor_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) And Panel3.Visible = True Then
            Panel3.Visible = False
            base.Text = ""
            total.Text = ""
            dgvCuentas.Focus()
        ElseIf Panel3.Visible = True And e.KeyChar = Chr(13) Then
            If base.Focused() = True Then
                If base.Text <> "" Then
                    If base.Text <> 0 Then

                        total.Text = (CDbl(base.Text) * CDbl(porcentaje.Text)) / CDbl(100)
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

    Private Sub fechadoc_Leave(sender As Object, e As EventArgs) Handles fechadoc.Leave
        FuncionesContables.validarFechaFutura(fechadoc)
    End Sub
End Class