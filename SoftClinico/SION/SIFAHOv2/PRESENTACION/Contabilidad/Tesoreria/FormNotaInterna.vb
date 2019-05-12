Public Class FormCualquierNota
    Dim dtCuentas As New DataTable
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, identificador As String
    Dim codigoPuc, codigoDocumento, idTercero As Integer
    Private Sub FormCualquierNota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        llenarDtCuentas()
        codigoPuc = FuncionesContables.obtenerPucActivo()
        General.deshabilitarControles(Me)
        codigoDocumento = Constantes.NOTA_INTERNA_DE_CONTABILIDAD

    End Sub
    Private Sub base_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles base.KeyPress, porcentaje.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub
    Private Sub bloquearColumnas()
        With dgvCuentas
            .Columns("Naturaleza").ReadOnly = True
            .Columns("Descripcion").ReadOnly = True
        End With
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub llenarDtCuentas()
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
            .Columns("Naturaleza").Visible = False
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
    Private Sub formatoDgv()
        dgvCuentas.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvCuentas.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCuentas.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCuentas.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCuentas.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgvCuentas.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCuentas.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    End Sub
    Private Sub llenardgvCuentas(pCodigo As String, idempresa As Integer)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(idempresa)
        txtcodigo.Text = pCodigo
        SesionActual.idEmpresa = idempresa
        General.llenarTabla(Consultas.NOTA_INTERNA_DETALLE_CARGAR, params, dtCuentas)
        formatoDgv()

        If dtCuentas.Rows.Count > 0 Then
            calcularTotales()
        Else
            textvalorcredito.Text = FormatCurrency(0, 2)
            textvalordebito.Text = FormatCurrency(0, 2)
            textdiferencia.Text = FormatCurrency(0, 2)
        End If
    End Sub
    Private Sub bttercero_Click(sender As Object, e As EventArgs) Handles bttercero.Click
        Dim params As New List(Of String)
        params.Add(String.Empty)
        params.Add(SesionActual.idEmpresa)
        General.buscarElemento(Consultas.BUSQUEDA_PROVEEDOR,
                            params,
                            AddressOf cargarTercero,
                            TitulosForm.BUSQUEDA_TERCERO,
                            True, 0, True)
    End Sub
    Private Sub cargarDatos(pCodigo As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(SesionActual.idEmpresa)
        txtcodigo.Text = pCodigo
        General.llenarTabla(Consultas.NOTA_INTERNA_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            Textsigla.Text = Constantes.SIGLA_NOTA_INTERNA
            cargarDocumento(Textsigla.Text)
            fechadoc.Value = dt.Rows(0).Item("Fecha_Recibo").ToString()
            textnombreproveedor.Text = dt.Rows(0).Item("Tercero").ToString()
            textproveedor.Text = dt.Rows(0).Item("Nit").ToString()
            textobserva.Text = dt.Rows(0).Item("detalle_mov").ToString()
            idTercero = dt.Rows(0).Item("id_tercero").ToString()
            llenardgvCuentas(pCodigo, SesionActual.idEmpresa)
            calcularTotales()
            General.habilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            btguardar.Enabled = False
            btcancelar.Enabled = False
            If FuncionesContables.verificarFecha(fechadoc.Value) Then
                mostrarInfo(String.Format(Mensajes.PERIODO_CONTABLE_CERRADO), Color.White, Color.Red)
                bteditar.Enabled = False
            Else
                mostrarInfo(Nothing, Nothing, Nothing, True)
                PnlInfo.Visible = False
            End If
            If FuncionesContables.VerificarComprobante(pCodigo) Then
                mostrarInfo(String.Format(Mensajes.COMPROBANTE_ANULADO), Color.White, Color.Red)
                General.deshabilitarBotones(ToolStrip1)
                btbuscar.Enabled = True
                btnuevo.Enabled = True
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
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.idEmpresa)

            General.buscarElemento(Consultas.NOTA_INTERNA_BUSCAR,
                                   params,
                                   AddressOf cargarDatos,
                                   TitulosForm.BUSQUEDA_NOTA_INTERNA,
                                   False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
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
            If dtCuentas.Rows(dgvCuentas.CurrentRow.Index).Item(0).ToString.StartsWith("22") Then
                MsgBox("No puede eliminar una cuenta de proveedores", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If (dgvCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Cells("Cuenta").Selected = True Or dgvCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Cells("Descripcion").Selected = True) Then
                General.busquedaItems(Consultas.BUSQUEDA_CUENTAS_DETALLE_PUC, params, TitulosForm.BUSQUEDA_CUENTAS_PUC, dgvCuentas, dtCuentas, 0, 2, 0, 0, 0, 0, 1)
            ElseIf dgvCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Cells("anular").Selected = True And dtCuentas.Rows(dgvCuentas.CurrentCell.RowIndex).Item("Cuenta").ToString <> "" Then
                dtCuentas.Rows.RemoveAt(e.RowIndex)
            End If
            formatoDgv()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
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
                    dtCuentas.Rows.Add()
                Else
                    dtCuentas.Rows(dgvCuentas.CurrentRow.Index).Item(1) = fila(2)
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
            formatoDgv()
        End If
    End Sub

    Public Sub cargarTercero(pCodigo)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        idTercero = pCodigo
        General.llenarTabla(Consultas.TERCERO_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            textproveedor.Text = dt.Rows(0).Item("Nit").ToString()
            textnombreproveedor.Text = dt.Rows(0).Item("Tercero").ToString()
        End If
    End Sub
    Private Sub btBusquedaDocumento_Click(sender As Object, e As EventArgs) Handles btBusquedaDocumento.Click
        General.buscarElemento(Consultas.DOCUMENTOS_SIGLA_BUSCAR,
                              Nothing,
                              AddressOf cargarDocumento,
                              TitulosForm.BUSQUEDA_DOCUMENTOS_CONTABLES,
                              False)
    End Sub
    Private Sub dgvCuentas_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvCuentas.EditingControlShowing,
            dgvCuentas.EditingControlShowing
        If dgvCuentas.CurrentCell.ColumnIndex = 3 Or dgvCuentas.CurrentCell.ColumnIndex = 4 Or dgvCuentas.CurrentCell.ColumnIndex = 1 Then
            AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
        End If
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.limpiarControles(Me)
            General.deshabilitarBotones(ToolStrip1)
            General.habilitarControles(Me)
            txtcodigo.Text = FuncionesContables.verificarConsecutivo(SesionActual.idEmpresa, codigoDocumento)
            Textsigla.Text = Constantes.SIGLA_NOTA_INTERNA
            Textsigla_Leave(sender, e)
            dtCuentas.Rows.Add()
            Textnombredocumento.ReadOnly = True
            textnombreproveedor.ReadOnly = True
            textproveedor.ReadOnly = True
            btguardar.Enabled = True
            btcancelar.Enabled = True
            textproveedor.ReadOnly = True
            identificador = String.Empty
            textvalorcredito.Text = FormatCurrency(0, 2)
            textvalordebito.Text = FormatCurrency(0, 2)
            textdiferencia.Text = FormatCurrency(0, 2)
            textvalorcredito.ReadOnly = True
            textvalordebito.ReadOnly = True
            textdiferencia.ReadOnly = True
            Textsigla.ReadOnly = True
            PnlInfo.Visible = False
            bttercero.Focus()
            bloquearColumnas()
            total.ReadOnly = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
            textvalorcredito.ReadOnly = True
            textvalordebito.ReadOnly = True
            textdiferencia.ReadOnly = True
            Textsigla.ReadOnly = True
            dtCuentas.Rows.Add()
            bttercero.Enabled = False
            bloquearColumnas()
            total.ReadOnly = True
            identificador = txtcodigo.Text
            base.ReadOnly = False
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub Textsigla_Leave(sender As Object, e As EventArgs) Handles Textsigla.Leave
        If Textsigla.Text <> "" Then
            cargarDocumento(Textsigla.Text)
        End If
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

    End Sub
    Private Sub dgvCuentas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCuentas.CellClick
        If e.ColumnIndex = 4 Then
            FuncionesContables.ValidarCreditoDebito(dgvCuentas, Constantes.COLUMNA_DEBITO, Constantes.COLUMNA_CREDITO)
        ElseIf e.ColumnIndex = 5 Then
            FuncionesContables.ValidarCreditoDebito(dgvCuentas, Constantes.COLUMNA_CREDITO, Constantes.COLUMNA_DEBITO)
        End If
        bloquearColumnas()
    End Sub

    Private Sub btCuentas_Click(sender As Object, e As EventArgs)
        Dim formCuenta As New Form_CuentasPUC
        formCuenta.ShowDialog()
    End Sub

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
                textdiferencia.Text = FormatCurrency((CDbl(valorDebito) - CDbl(valorCredito)), 2)
                textvalordebito.Text = CDbl(valorDebito).ToString("C2")
                textvalorcredito.Text = CDbl(valorCredito).ToString("C2")

            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
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
        End If
    End Sub
    Private Function validarInformacion() As Boolean
        dgvCuentas.EndEdit()
        Dim vDebito, vCredito As Double
        vDebito = CDbl(textvalordebito.Text)
        vCredito = CDbl(textvalorcredito.Text)
        If textproveedor.Text = "" Then
            MsgBox("Por Favor Elija el proveedor", 48, "Atención")
            bttercero.Focus()
            Return False
        ElseIf dtCuentas.Rows.Count <= 1 Then
            MsgBox("Por Favor Corrija el movimiento,Elija una cuenta ", 48, "Atención")
            Return False
        ElseIf CDbl(textdiferencia.Text) <> 0 Then
            MsgBox("Por Favor Corrija el movimiento, los saldos debito y credito no son iguales", 48, "Atención")
            dgvCuentas.Focus()
            Return False
        ElseIf vCredito = 0 Or vDebito = 0 Then
            MsgBox("Por Favor Corrija el movimiento, los saldos debito y credito no son iguales o estan en CERO", 48, "Atención")
            dgvCuentas.Focus()
            Return False
        End If
        If FuncionesContables.verificarFecha(fechadoc.Value) Then
            mostrarInfo(String.Format(Mensajes.PERIODO_CONTABLE_CERRADO), Color.White, Color.Red)
            Return False
        Else
            mostrarInfo(Nothing, Nothing, Nothing, True)
            PnlInfo.Visible = False
        End If

        If FuncionesContables.validarFechaFutura(fechadoc) = False Then
            Return False
        End If
        Return True
    End Function
    Private Sub fechadoc_Leave(sender As Object, e As EventArgs) Handles fechadoc.Leave
        FuncionesContables.validarFechaFutura(fechadoc)
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarInformacion() Then
            If FuncionesContables.validardgv(dtCuentas) Then
                If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

                    codigoPuc = FuncionesContables.obtenerPucActivo()
                    calcularTotales()
                    dgvCuentas.EndEdit()
                    dtCuentas.AcceptChanges()
                    Dim objCualquierNotaBll As New CualquierNotaBLL
                    Try
                        objCualquierNotaBll.guardarCualquierNota(crearCualquierNota(), SesionActual.idUsuario)
                        General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                        llenardgvCuentas(txtcodigo.Text, SesionActual.idEmpresa)
                    Catch ex As Exception
                        General.manejoErrores(ex)
                    End Try
                End If
            End If
        End If
    End Sub
    Public Function crearCualquierNota() As NotaInterna
        Dim objCualquierNota As New NotaInterna
        Dim valorDebito, valorCredito As Double
        valorDebito = textvalordebito.Text
        valorCredito = textvalorcredito.Text
        objCualquierNota.codigoDocumento = codigoDocumento
        objCualquierNota.comprobante = txtcodigo.Text
        objCualquierNota.idEmpresa = SesionActual.idEmpresa
        objCualquierNota.idProveedor = idTercero
        objCualquierNota.fechaRecibo = fechadoc.Value
        objCualquierNota.detalleMov = textobserva.Text
        objCualquierNota.identificador = identificador

        Dim Index As Integer = 0
        For Each drFila As DataRow In dtCuentas.Rows
            If drFila.Item("Cuenta").ToString <> "" Then
                Dim drCuenta As DataRow = objCualquierNota.dtCuentas.NewRow
                drCuenta.Item("comprobante") = txtcodigo.Text
                drCuenta.Item("codigo_puc") = codigoPuc
                drCuenta.Item("codigoCuenta") = drFila.Item("Cuenta")
                drCuenta.Item("debito") = drFila.Item("debito")
                drCuenta.Item("credito") = drFila.Item("credito")
                drCuenta.Item("orden") = Index
                objCualquierNota.dtCuentas.Rows.Add(drCuenta)
                Index += 1
            End If
        Next
        Return objCualquierNota
    End Function
    Private Sub formCualquierNota_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) And Panel3.Visible = True Then
            Panel3.Visible = False
            base.Text = ""
            total.Text = ""
            dgvCuentas.Focus()
        ElseIf Panel3.Visible = True And e.KeyChar = Chr(13) Then
            If base.Focused() = True Then
                If base.Text <> "" Then
                    If base.Text <> 0 Then
                        porcentaje.Text = Replace(porcentaje.Text, ".", ",")
                        total.Text = CDbl(base.Text) * CDbl(porcentaje.Text) / 100
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