Public Class FormPagoDirecto
    Dim objComprobante As New PagosDirecto
    Dim codigoPuc, codigoDocumento As Integer
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Dim reporte As New ftp_reportes
    Private Sub btbuscarl_Click(sender As Object, e As EventArgs) Handles btbuscarl.Click
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        params.Add(Nothing)
        General.buscarElemento(Consultas.CONTA_TERCERO_BUSCAR,
                             params,
                             AddressOf cargarTercero,
                             TitulosForm.BUSQUEDA_TERCERO,
                             True, 0, True)
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
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

    Public Sub cargarTercero(pCodigoTercero As String)
        Dim drTercero As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigoTercero)

        drTercero = General.cargarItem(Consultas.CONTA_PROVEEDOR_CARGAR, params)
        txtid.Text = drTercero.Item("id_Proveedor")
        nitTercero.Text = drTercero.Item("Nit")
        txttercero.Text = drTercero.Item("Proveedor")
        txtfactura.Enabled = True
        txtfactura.ReadOnly = False
        txtmovimiento.ReadOnly = False
        objComprobante.dtComprobante.Rows.Add()
    End Sub

    Public Sub deshabilitarControles()
        btbuscarl.Enabled = False
    End Sub

    Public Sub habilitarControles()
        btbuscarl.Enabled = True
    End Sub
    Private Sub FormPagoDirecto_Load(sender As Object, e As EventArgs) Handles MyBase.Load, base.Enter
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        codigoPuc = FuncionesContables.obtenerPucActivo()
        dgvComprobante.DataSource = objComprobante.dtComprobante
        dgvComprobante.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvComprobante.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        dgvComprobante.ReadOnly = False
        dgvComprobante.Columns("descripcion").ReadOnly = True
        dgvComprobante.Columns("descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvComprobante.Columns("Comprobante causacion").Visible = False
        dgvComprobante.Columns("Comprobante causacion").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvComprobante.Columns("Codigo Factura").Visible = False
        dgvComprobante.Columns("Codigo Factura").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvComprobante.Columns("Codigo").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvComprobante.Columns("Debito").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvComprobante.Columns("Credito").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvComprobante.Columns("Orden").Visible = False
        dgvComprobante.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable

        Funciones.validarCantidadCaracteresDGV(dgvComprobante, "Codigo", 10)
        Funciones.validarCantidadCaracteresDGV(dgvComprobante, "Debito", 15)
        Funciones.validarCantidadCaracteresDGV(dgvComprobante, "Credito", 15)

        deshabilitarControles()
        codigoDocumento = Constantes.COMPROBANTE_DE_EGRESO
        dgvComprobante.Columns(0).DisplayIndex = 7
        'fechadoc.Enabled = False
        'Datefecha.Enabled = False
        PnlInfo.Visible = False
    End Sub

    Private Sub dgvCargos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvComprobante.CellDoubleClick
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        If e.ColumnIndex = 4 Then
            Dim params As New List(Of String)
            params.Add(codigoPuc)
            params.Add("")
            If (dgvComprobante.Rows(dgvComprobante.CurrentCell.RowIndex).Cells("Codigo").Selected = True Or dgvComprobante.Rows(dgvComprobante.CurrentCell.RowIndex).Cells("Descripcion").Selected = True) Then
                General.busquedaItems(Consultas.BUSQUEDA_CUENTAS_DETALLE_PUC, params, TitulosForm.BUSQUEDA_CUENTAS_PUC, dgvComprobante, objComprobante.dtComprobante, 2, 3, 0, 0)
                objComprobante.codigoCuenta = IsDBNull(dgvComprobante.Rows(dgvComprobante.CurrentCell.RowIndex).Cells("Codigo").Value)
                llenarRetencion(objComprobante.codigoCuenta)
            End If
        End If

        If e.ColumnIndex = 0 Then

            If Not String.IsNullOrEmpty(dgvComprobante.Rows(dgvComprobante.CurrentCell.RowIndex).Cells("Descripcion").Value.ToString) Then
                objComprobante.dtComprobante.Rows.RemoveAt(e.RowIndex)
                calcularTotales()
            End If
        End If
        'dgvComprobante.Columns("Comprobante causacion").Visible = True
        'dgvComprobante.Columns("Codigo Factura").Visible = True
    End Sub

    Public Sub calcularTotalesDgv()

        Try
            Dim valorDebito, sumaDebito, sumaCredito, valorCredito As Double

            For i = 0 To dgvComprobante.Rows.Count - 1
                If Not String.IsNullOrEmpty(Funciones.castFromDbItem(dgvComprobante.Rows(i).Cells("Codigo").Value)) Then
                    sumaDebito = CDbl(dgvComprobante.Rows(i).Cells("Debito").Value)
                    sumaCredito = CDbl(dgvComprobante.Rows(i).Cells("Credito").Value)

                    valorDebito = valorDebito + sumaDebito
                    valorCredito = valorCredito + sumaCredito
                End If
            Next
            objComprobante.diferencia = FormatCurrency((CDbl(valorDebito) - CDbl(valorCredito)), 2)
            objComprobante.debito = valorDebito
            objComprobante.credito = valorCredito
            objComprobante.retencion = FuncionesContables.sumaRetencion(codigoPuc, dgvComprobante)

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub dgvComprobante_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvComprobante.CellFormatting
        If e.ColumnIndex = 6 Or e.ColumnIndex = 7 Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), "c2")
            Else
                e.Value = Format(Val(e.Value), "c2")
            End If
        End If
    End Sub



    Private Sub dgvComprobante_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvComprobante.CellEndEdit
        If dgvComprobante.CurrentCell.ColumnIndex = 4 AndAlso dgvComprobante.Rows(dgvComprobante.CurrentCell.RowIndex).Cells("Codigo").Value.ToString.Length > 5 Then
            objComprobante.codigoCuenta = dgvComprobante.Rows(dgvComprobante.CurrentCell.RowIndex).Cells("Codigo").Value
            FuncionesContables.verificarCuenta(dgvComprobante.CurrentCell.RowIndex, 0,
                                               objComprobante.codigoCuenta, "Codigo",
                                               "Descripcion", objComprobante.dtComprobante)
            llenarRetencion(objComprobante.codigoCuenta)

        Else
            If Not (IsDBNull(dgvComprobante.Rows(dgvComprobante.CurrentCell.RowIndex).Cells("Codigo").Value) OrElse Not dgvComprobante.CurrentCell.ColumnIndex = 4) And
                dgvComprobante.Rows(dgvComprobante.CurrentCell.RowIndex).Cells("Codigo").Value.ToString.Length < 5 Then
                MsgBox("Cuenta errada, por favor digite una cuenta válida!", MsgBoxStyle.Exclamation)
                dgvComprobante.Rows(dgvComprobante.CurrentCell.RowIndex).Cells("Codigo").Value = ""
            End If
        End If
        dgvComprobante.Columns("Comprobante causacion").Visible = True
        dgvComprobante.Columns("Codigo Factura").Visible = True
        calcularTotales()
    End Sub

    Private Sub calcularTotales()

        objComprobante.codigoPuc = codigoPuc
        calcularTotalesDgv()
        txtcredito.Text = CDbl(objComprobante.credito).ToString("C2")
        txtdebito.Text = CDbl(objComprobante.debito).ToString("C2")
        txtretencion.Text = CDbl(objComprobante.retencion).ToString("C2")
        txtdiferencia.Text = CDbl(objComprobante.diferencia).ToString("C2")
    End Sub

    Private Sub llenarRetencion(pCuenta As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add("")
        params.Add(pCuenta)
        General.llenarTabla(Consultas.RETENCION_CUENTAS_RETENCION, params, dt)
        If dt.Rows.Count > 0 Then
            lblivarete.Text = dt.Rows(0).Item("cuenta").ToString()
            porcentaje.Text = dt.Rows(0).Item("tasa").ToString()
            porcentaje.Text = Replace(porcentaje.Text, ".", ",")
            nat.Text = dt.Rows(0).Item("naturaleza").ToString()
            Panel3.Visible = True
            base.Focus()
            dgvComprobante.Enabled = False
            btnuevo.Enabled = False
            btbuscar.Enabled = False
            bteditar.Enabled = False
            btguardar.Enabled = False
            btcancelar.Enabled = True
            btbuscarl.Enabled = False
        End If
    End Sub
    Private Sub dgvComprobante_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvComprobante.EditingControlShowing

        If dgvComprobante.CurrentCell.ColumnIndex = 4 Or dgvComprobante.CurrentCell.ColumnIndex = 6 Or dgvComprobante.CurrentCell.ColumnIndex = 7 Then
            AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click

        If Panel3.Visible = True Then
            btnuevo.Enabled = False
            Panel3.Visible = False
            dgvComprobante.Enabled = True
            dgvComprobante.Rows(dgvComprobante.CurrentCell.RowIndex).Cells("codigo").Value = ""
            dgvComprobante.Rows(dgvComprobante.CurrentCell.RowIndex).Cells("Descripcion").Value = ""
            dgvComprobante.Rows.RemoveAt(dgvComprobante.CurrentCell.RowIndex)

            bteditar.Enabled = False
            btguardar.Enabled = True
            base.Clear()
            total.Clear()
            btbuscarl.Enabled = True
            PnlInfo.Visible = False
        Else
            If MsgBox("¿Desea cancelar este registro?", 32 + 1, "cancelar") = 1 Then
                objComprobante.dtComprobante.Clear()
                btnuevo.Enabled = True
                txtcomprobante.Clear()
                btguardar.Enabled = False
                btimprimir.Enabled = False
                nitTercero.Clear()
                txtid.Clear()
                txtid.ReadOnly = True
                txtfactura.Clear()
                txtfactura.ReadOnly = True
                txttercero.Clear()
                btbuscarl.Enabled = False
                btbuscar.Enabled = True
                txtmovimiento.Clear()
                txtdebito.Clear()
                txtmovimiento.ReadOnly = False
                txtcredito.Clear()
                txtdiferencia.Clear()
                btcancelar.Enabled = False
                PnlInfo.Visible = False
            End If
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.idEmpresa)
            params.Add(Nothing)
            General.buscarElemento(Consultas.COMPROBANTE_EGRESO_BUSCAR,
                               params,
                               AddressOf cargarDatos,
                               TitulosForm.BUSQUEDA_COMPROBANTE_EGRESO,
                               False, 0, True)

            'If txtcomprobante.Text <> "" Then
            '    objComprobante.VerificarComprobante()
            '    If objComprobante.dt.Rows.Count > 0 Then
            '        mostrarInfo(String.Format(objComprobante.mensaje), Color.White, Color.Red)
            '    Else
            '        mostrarInfo(Nothing, Nothing, Nothing, True)
            '    End If
            'End If
            'General.deshabilitarControles(Me)
            'bteditar.Enabled = True
            'btimprimir.Enabled = True
            'dgvComprobante.Enabled = False
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub cargarDatos(pcodigo As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        params.Add(pcodigo)
        General.llenarTabla(Consultas.COMPROBANTE_EGRESO_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            txtcomprobante.Text = pcodigo
            txtmovimiento.Text = dt.Rows(0).Item("Detalle movimiento").ToString
            Datefecha.Text = dt.Rows(0).Item("fecha recibo").ToString
            fechadoc.Text = dt.Rows(0).Item("fecha pago").ToString
            txtid.Text = dt.Rows(0).Item("id tercero").ToString
            nitTercero.Text = dt.Rows(0).Item("Nit").ToString
            txttercero.Text = dt.Rows(0).Item("nombre proveedor").ToString
            txtfactura.Text = dt.Rows(0).Item("entrada").ToString
            fechadoc.Enabled = False
            Datefecha.Enabled = False
            objComprobante.comprobante = txtcomprobante.Text
            objComprobante.cargarComprobante()
            calcularTotales()
            dgvComprobante.Columns("Comprobante causacion").Visible = True
            dgvComprobante.Columns("Codigo Factura").Visible = True
            btbuscarl.Enabled = False
            If FuncionesContables.verificarFecha(fechadoc.Value) Then
                mostrarInfo(String.Format(Mensajes.PERIODO_CONTABLE_CERRADO), Color.White, Color.Red)
                bteditar.Enabled = False
            Else
                mostrarInfo(Nothing, Nothing, Nothing, True)
                PnlInfo.Visible = False
                bteditar.Enabled = True
            End If
            If FuncionesContables.verificarComprobante(pcodigo) Then
                mostrarInfo(String.Format(Mensajes.COMPROBANTE_ANULADO), Color.White, Color.Red)
                General.deshabilitarBotones(ToolStrip1)
                btbuscar.Enabled = True
                btnuevo.Enabled = True
            End If
            btimprimir.Enabled = True
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            objComprobante.fecha = fechadoc.Value.Date
            objComprobante.VerificarFecha()
            objComprobante.registroNuevo = False
            If objComprobante.periodoCerrado = False Then
                btguardar.Enabled = True
                btcancelar.Enabled = True
                bteditar.Enabled = False
                General.habilitarControles(Me)
                dgvComprobante.Columns("Descripcion").ReadOnly = True
                dgvComprobante.Columns("Codigo Factura").ReadOnly = True
                dgvComprobante.Columns("Comprobante causacion").ReadOnly = True
                nitTercero.ReadOnly = True
                txtcredito.ReadOnly = True
                txtretencion.ReadOnly = True
                txtmovimiento.Enabled = True
                txtmovimiento.ReadOnly = False
                txtdebito.ReadOnly = True
                txtdiferencia.ReadOnly = True
                txttercero.ReadOnly = True
                dgvComprobante.Enabled = True
                txtfactura.ReadOnly = False
                btnuevo.Enabled = False
                btbuscarl.Enabled = False
                Datefecha.Enabled = False
                fechadoc.Enabled = False
                btimprimir.Enabled = False
                btbuscar.Enabled = False
                txtfactura.Enabled = True
                txtcomprobante.ReadOnly = True
                objComprobante.dtComprobante.Rows.Add()
                mostrarInfo(Nothing, Nothing, Nothing, True)
            Else
                mostrarInfo(String.Format(objComprobante.mensaje), Color.White, Color.Red)
                btguardar.Enabled = False
                bteditar.Enabled = True
                btnuevo.Enabled = True
                fechadoc.Enabled = False
                Datefecha.Enabled = False
                txtfactura.Enabled = False
                txtmovimiento.Enabled = False
                btcancelar.Enabled = False
                dgvComprobante.Enabled = False
                btbuscarl.Enabled = False
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs)
        If SesionActual.tienePermiso(Panular) Then

        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub base_KeyPress(sender As Object, e As KeyPressEventArgs) Handles base.KeyPress
        ValidacionDigitacion.validarValoresNumericos(e)
    End Sub

    'Private Sub fechadoc_Leave(sender As Object, e As EventArgs) Handles fechadoc.Leave

    '    objComprobante.fecha = fechadoc.Value.Date
    '    objComprobante.VerificarFecha()
    '    If objComprobante.periodoCerrado = True Then
    '        mostrarInfo(String.Format(objComprobante.mensaje), Color.White, Color.Red)
    '        btguardar.Enabled = False

    '        bteditar.Enabled = False
    '        btnuevo.Enabled = True
    '        btbuscar.Enabled = True
    '        fechadoc.Enabled = False
    '        Datefecha.Enabled = False
    '        txtfactura.Enabled = False
    '        txtmovimiento.Enabled = False
    '        btcancelar.Enabled = False
    '        dgvComprobante.Enabled = False
    '        btbuscarl.Enabled = False
    '        If dgvComprobante.Rows.Count > 0 Then
    '            btbuscar.Enabled = False
    '            btguardar.Enabled = True
    '            btcancelar.Enabled = True
    '            bteditar.Enabled = False
    '            btimprimir.Enabled = False
    '            btnuevo.Enabled = False
    '            dgvComprobante.Enabled = True
    '            txtfactura.Enabled = True
    '            txtmovimiento.Enabled = True
    '            btcancelar.Enabled = True
    '            fechadoc.Enabled = True
    '            Datefecha.Enabled = True
    '            btbuscarl.Enabled = True
    '        End If
    '    Else
    '        mostrarInfo(Nothing, Nothing, Nothing, True)
    '    End If
    'End Sub

    'Private Sub fechaven_ValueChanged(sender As Object, e As EventArgs) Handles fechadoc.ValueChanged
    '    FuncionesContables.validarFechaFutura(fechadoc)
    '    objComprobante.fecha = fechadoc.Value.Date
    '    objComprobante.VerificarFecha()
    '    If objComprobante.periodoCerrado = True Then
    '        mostrarInfo(String.Format(objComprobante.mensaje), Color.White, Color.Red)
    '        If btnuevo.Enabled = False Then
    '            btguardar.Enabled = True
    '        Else
    '            btguardar.Enabled = False
    '        End If
    '        bteditar.Enabled = False
    '        dgvComprobante.Enabled = False
    '        txtfactura.Enabled = False
    '        txtmovimiento.Enabled = False
    '        btcancelar.Enabled = False
    '        fechadoc.Enabled = False
    '        Datefecha.Enabled = False
    '        btbuscarl.Enabled = False
    '        If dgvComprobante.Rows.Count > 0 Then
    '            btbuscar.Enabled = False
    '            btguardar.Enabled = True
    '            btcancelar.Enabled = True
    '            bteditar.Enabled = False
    '            btimprimir.Enabled = False
    '            btnuevo.Enabled = False
    '            dgvComprobante.Enabled = True
    '            txtfactura.Enabled = True
    '            txtmovimiento.Enabled = True
    '            btcancelar.Enabled = True
    '            fechadoc.Enabled = True
    '            Datefecha.Enabled = True
    '            btbuscarl.Enabled = True
    '        End If
    '    Else
    '        mostrarInfo(Nothing, Nothing, Nothing, True)
    '        If objComprobante.periodoCerrado = False And btnuevo.Enabled = False Then
    '            btbuscar.Enabled = False
    '            btguardar.Enabled = True
    '            btcancelar.Enabled = True
    '            bteditar.Enabled = False
    '            btimprimir.Enabled = False
    '        End If
    '    End If
    'End Sub

    Public Function validarControles()
        dgvComprobante.EndEdit()

        Dim vDebito, vCredito As Double
        vDebito = CDbl(txtcredito.Text)
        vCredito = CDbl(txtdebito.Text)
        If nitTercero.Text = "" Then
            MsgBox("Debe seleccionar un tercero", MsgBoxStyle.Exclamation)
            btbuscarl.Focus()
            Return False
        ElseIf txtfactura.Text = "" Then
            MsgBox("El campo factura se encuentra vacio", MsgBoxStyle.Exclamation)
            txtfactura.Focus()
            Return False
        ElseIf txtmovimiento.Text = "" Then
            MsgBox("El campo detalle del movimiento se encuentra vacio", MsgBoxStyle.Exclamation)
            txtmovimiento.Focus()
            Return False
        ElseIf CDbl(txtdiferencia.Text) <> 0 Then
            MsgBox("Por Favor Corrija el movimiento, los saldos debito y credito no son iguales", MsgBoxStyle.Exclamation)
            dgvComprobante.Focus()
            Return False
        ElseIf vCredito = 0 Or vDebito = 0 Then
            MsgBox("Por Favor Corrija el movimiento, los saldos debito y credito no son iguales o estan en CERO", MsgBoxStyle.Exclamation)
            dgvComprobante.Focus()
            Return False
        ElseIf FuncionesContables.validardgv(objComprobante.dtComprobante) = False Then
            Return False
        End If
        Return True
    End Function

    Public Sub guardarComprobante()
        dgvComprobante.EndEdit()

        Try
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                objComprobante.fecha = fechadoc.Value.Date
                objComprobante.VerificarFecha()

                If objComprobante.periodoCerrado = False Then
                    If (objComprobante.registroNuevo) Then
                        txtcomprobante.Text = FuncionesContables.verificarConsecutivo(SesionActual.idEmpresa, codigoDocumento)
                    End If
                    objComprobante.comprobante = txtcomprobante.Text
                    objComprobante.fecha = fechadoc.Value.Date
                    objComprobante.fecharec = Datefecha.Value.Date
                    objComprobante.movimiento = txtmovimiento.Text
                    objComprobante.idempresa = SesionActual.idEmpresa
                    objComprobante.usuario = SesionActual.idUsuario
                    objComprobante.documento = Constantes.COMPROBANTE_DE_EGRESO
                    objComprobante.entrada = txtfactura.Text
                    objComprobante.idtercero = txtid.Text
                    objComprobante.guardar()
                    If objComprobante.registroNuevo = True Then
                        FuncionesContables.aumentarConsecutivo(SesionActual.idEmpresa, codigoDocumento)
                    End If
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    btguardar.Enabled = False
                    bteditar.Enabled = True
                    btbuscar.Enabled = True
                    btimprimir.Enabled = True
                    objComprobante.cargarComprobante()
                    calcularTotales()
                    btnuevo.Enabled = True
                    btcancelar.Enabled = False
                    General.deshabilitarControles(Me)
                    dgvComprobante.Enabled = False
                Else
                    mostrarInfo(String.Format(objComprobante.mensaje), Color.White, Color.Red)
                    btguardar.Enabled = False
                    btbuscar.Enabled = True
                    bteditar.Enabled = False
                    btcancelar.Enabled = False
                    dgvComprobante.Enabled = False
                    fechadoc.Enabled = False
                    txtfactura.Enabled = False
                    Datefecha.Enabled = False
                    btbuscarl.Enabled = False
                    txtmovimiento.Enabled = False
                    btnuevo.Enabled = True
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarControles() Then
            guardarComprobante()
        End If
    End Sub

    Private Sub base_KeyDown(sender As Object, e As KeyEventArgs) Handles base.KeyDown
        If e.KeyCode = 13 Then
            If Panel3.Visible = True Then
                If base.Focused = True And base.Text <> "" Then
                    porcentaje.Text = Replace(porcentaje.Text, ".", ",")
                    total.Text = CDbl(base.Text) * CDbl(porcentaje.Text) / 100
                    total.Focus()
                Else
                    MsgBox("Digite cantidad base", MsgBoxStyle.Exclamation)
                    base.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        imprimir()
    End Sub

    Public Sub imprimir()

        Cursor = Cursors.WaitCursor

        Try
            Dim ruta, area, nombreArchivo As String
            area = ConstantesHC.NOMBRE_PDF_COMPROBANTE
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtcomprobante.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo

            guardarReportecateter()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub guardarReportecateter()

        Try

            Dim numeroLetra As New ConvertirNumeros
            numeroLetra.Convertir_Numero(txtcredito.Text)

            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_COMPROBANTE, txtcomprobante.Text, New rptComprobanteEgreso,
                         txtcomprobante.Text, "{VISTA_COMPROBANTE_EGRESO.Comprobante} = '" & txtcomprobante.Text & "'",
                           ConstantesHC.NOMBRE_PDF_COMPROBANTE, IO.Path.GetTempPath, numeroLetra.NumeroConvertido)

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub dgvComprobante_CellEnter_1(sender As Object, e As DataGridViewCellEventArgs) Handles dgvComprobante.CellEnter
        dgvComprobante.EndEdit()
        calcularTotales()
    End Sub

    Private Sub total_KeyDown(sender As Object, e As KeyEventArgs) Handles total.KeyDown
        If e.KeyCode = 13 Then
            If nat.Text = "D" Then
                dgvComprobante.Rows(dgvComprobante.CurrentCell.RowIndex).Cells("Credito").Value = total.Text
            Else
                dgvComprobante.Rows(dgvComprobante.CurrentCell.RowIndex).Cells("Debito").Value = total.Text
            End If
            Panel3.Visible = False
            dgvComprobante.Enabled = True
            btguardar.Enabled = True
            btbuscar.Enabled = True
        End If
    End Sub

    Private Sub dgvComprobante_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvComprobante.DataError
        MsgBox(Mensajes.CANTIDAD_VALIDA, MsgBoxStyle.Exclamation)
    End Sub

    Public Sub limpiarControles()
        nitTercero.Clear()
        txttercero.Clear()
        txtfactura.Clear()
        txtmovimiento.Clear()
        txtdebito.Clear()
        txtid.Clear()
        txtcredito.Clear()
        txtdiferencia.Clear()
        txtretencion.Clear()
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            txtcomprobante.Text = FuncionesContables.verificarConsecutivo(SesionActual.idEmpresa, codigoDocumento)
            objComprobante.dtComprobante.Clear()
            General.habilitarControles(Me)
            dgvComprobante.Columns("Descripcion").ReadOnly = True
            txtcomprobante.ReadOnly = True
            txtcredito.ReadOnly = True
            txtdebito.ReadOnly = True
            txtdiferencia.ReadOnly = True
            dgvComprobante.Columns("Comprobante causacion").Visible = False
            dgvComprobante.Columns("Codigo Factura").Visible = False
            bteditar.Enabled = False
            txtfactura.ReadOnly = True
            nitTercero.ReadOnly = True
            txttercero.ReadOnly = True
            txtid.ReadOnly = True
            dgvComprobante.ReadOnly = False
            txtretencion.ReadOnly = True
            btnuevo.Enabled = False
            btguardar.Enabled = True
            fechadoc.Text = Funciones.Fecha(Constantes.FORMATO_FECHA)
            btcancelar.Enabled = True
            fechadoc.Enabled = True
            btbuscarl.Enabled = True
            btimprimir.Enabled = False
            txtdebito.Clear()
            txtcredito.Clear()
            txtdiferencia.Clear()
            fechadoc.Enabled = True
            Datefecha.Enabled = True
            Datefecha.Enabled = True
            btbuscar.Enabled = False
            habilitarControles()
            limpiarControles()
            txtmovimiento.Enabled = True
            PnlInfo.Visible = False
            dgvComprobante.Enabled = True
            dgvComprobante.EndEdit()
            calcularTotales()
            objComprobante.registroNuevo = True
            objComprobante.fecha = fechadoc.Value.Date
            objComprobante.VerificarFecha()
            'If objComprobante.periodoCerrado = True Then
            '    btguardar.Enabled = False
            '    mostrarInfo(String.Format(objComprobante.mensaje), Color.White, Color.Red)
            'Else
            '    btguardar.Enabled = True
            '    PnlInfo.Visible = False
            'End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
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
End Class