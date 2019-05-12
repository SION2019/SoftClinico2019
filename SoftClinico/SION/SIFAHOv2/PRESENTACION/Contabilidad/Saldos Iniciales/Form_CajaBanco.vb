Public Class Form_CajaBanco
    Dim dtCuentas As New DataTable
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, identificador As String
    Dim codigoPuc, codigoDocumento As Integer
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
    Private Sub fechadoc_Leave(sender As Object, e As EventArgs) Handles fechadoc.Leave
        FuncionesContables.validarFechaFutura(fechadoc)
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Function valiadarInformacion() As Boolean
        If FuncionesContables.verificarFecha(fechadoc.Value) Then
            mostrarInfo(String.Format(Mensajes.PERIODO_CONTABLE_CERRADO), Color.White, Color.Red)
            Return False
        Else
            mostrarInfo(Nothing, Nothing, Nothing, True)
            PnlInfo.Visible = False
        End If
        If dtCuentas.Rows.Count <= 1 Then
            MsgBox("Corrija el movimiento, debe agregar una cuenta")
            Return False
        End If
        If FuncionesContables.validarFechaFutura(fechadoc) = False Then
            Return False
        End If
        Return True
    End Function
    Private Sub dgvCuentas_CellFormatting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvcuentas.CellFormatting
        If e.ColumnIndex = 3 Or e.ColumnIndex = 5 Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), "c2")
            Else
                e.Value = Format(Val(e.Value), "c2")
            End If
        End If

    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If valiadarInformacion() Then
            If FuncionesContables.validarDatosDgv(dgvcuentas, 1) Then

                If FuncionesContables.validardgv(dtCuentas) Then

                    If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                        codigoPuc = FuncionesContables.obtenerPucActivo()

                        Dim objcajaBanco_D As New CajaBancoBLL

                        Try
                            objcajaBanco_D.guardarCajaBanco(crearCajaBanco(), SesionActual.idUsuario)
                            General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                            llenardgv(txtcodigo.Text, SesionActual.idEmpresa)
                        Catch ex As Exception
                            General.manejoErrores(ex)
                        End Try

                    End If
                End If
            End If
        End If
    End Sub
    Private Sub llenardgv(pCodigo As String, idempresa As Integer)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(idempresa)
        txtcodigo.Text = pCodigo
        SesionActual.idEmpresa = idempresa
        General.llenarTabla(Consultas.CAJA_BANCO_CARGAR_CUENTAS, params, dtCuentas)

    End Sub
    Private Sub cargarDocumento(codigo As String)
        Dim objDocumentoContable As DocumentoContable = FuncionesContables.cargarDocumento(codigo)
        If objDocumentoContable IsNot Nothing Then
            codigoDocumento = objDocumentoContable.codigo
            Textsigla.Text = codigo
            Textnombredocumento.Text = objDocumentoContable.descripcion
        Else
            MsgBox("No se encontró ningún documento")
            btBusquedaDocumento.PerformClick()
        End If
    End Sub
    Public Function crearCajaBanco() As CajaBanco
        Dim objCajaBanco As New CajaBanco
        If String.IsNullOrEmpty(identificador) Then
            txtcodigo.Text = FuncionesContables.verificarConsecutivo(SesionActual.idEmpresa, codigoDocumento)
        End If
        objCajaBanco.identificador = identificador
        objCajaBanco.codigoDocumento = codigoDocumento
        objCajaBanco.comprobante = txtcodigo.Text
        objCajaBanco.idEmpresa = SesionActual.idEmpresa
        objCajaBanco.idTercero = SesionActual.idEmpresa
        objCajaBanco.fechaRecibo = fechadoc.Value
        objCajaBanco.detalleMov = Textdetalle.Text

        Dim index As Integer = 0
        For Each drFila As DataRow In dtCuentas.Rows
            If drFila.Item("codigoCuenta").ToString <> "" Then
                Dim drCuenta As DataRow = objCajaBanco.dtCuentas.NewRow
                drCuenta.Item("comprobante") = objCajaBanco.comprobante
                drCuenta.Item("codigo_puc") = codigoPuc
                drCuenta.Item("codigoCuenta") = drFila.Item("codigoCuenta")
                drCuenta.Item("debito") = drFila.Item("debito")
                drCuenta.Item("credito") = drFila.Item("credito")
                drCuenta.Item("orden") = index
                objCajaBanco.dtCuentas.Rows.Add(drCuenta)
                index += 1
            End If
        Next
        Return objCajaBanco
    End Function
    Private Sub bloquearColumnas()
        With dgvcuentas
            .Columns.Item("Nombre").ReadOnly = True
        End With
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            dtCuentas.Clear()
            dtCuentas.Rows.Add()
            txtcodigo.Text = FuncionesContables.verificarConsecutivo(SesionActual.idEmpresa, codigoDocumento)
            Textsigla.Focus()
            Textsigla.Text = Constantes.SIGLA_SALDOS_INICIALES
            General.deshabilitarBotones(ToolStrip1)
            General.habilitarControles(Me)
            btguardar.Enabled = True
            btcancelar.Enabled = True
            dgvcuentas.Focus()
            identificador = String.Empty
            bloquearColumnas()
            PnlInfo.Visible = False
            Textsigla.ReadOnly = True
            Textnombredocumento.ReadOnly = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargarDatos(pCodigo)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.CAJA_BANCO_CARGAR, params, dt)
        Textsigla.Text = Constantes.SIGLA_SALDOS_INICIALES
        cargarDocumento(Textsigla.Text)
        txtcodigo.Text = pCodigo
        Textdetalle.Text = dt.Rows(0).Item("detalle_mov").ToString()
        fechadoc.Value = dt.Rows(0).Item("Fecha_Recibo").ToString()
        llenardgv(txtcodigo.Text, SesionActual.idEmpresa)
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
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.idEmpresa)

            General.buscarElemento(Consultas.CAJA_BANCO_BUSCAR,
                                   params,
                                   AddressOf cargarDatos,
                                   TitulosForm.BUSQUEDA_CAJA_BANCO,
                                   False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                identificador = txtcodigo.Text
                dtCuentas.Rows.Add()
                bloquearColumnas()
                Textsigla.ReadOnly = True
                Textnombredocumento.ReadOnly = True
                General.deshabilitarBotones(ToolStrip1)
                dgvcuentas.ReadOnly = False
                bloquearColumnas()
                btguardar.Enabled = True
                btcancelar.Enabled = True
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub

    Private Sub dgvcuentas_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvcuentas.EditingControlShowing,
            dgvcuentas.EditingControlShowing
        If dgvcuentas.CurrentCell.ColumnIndex = 3 Or dgvcuentas.CurrentCell.ColumnIndex = 5 Or dgvcuentas.CurrentCell.ColumnIndex = 1 Then
            AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
        End If
    End Sub

    Private Sub dgvcuentas_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvcuentas.KeyDown
        If e.KeyCode = Keys.F3 And btguardar.Enabled = True Then
            Dim consulta As String
            If Rcaja.Checked = True Then
                consulta = Consultas.CUENTAS_CAJA_BUSCAR
            Else
                consulta = Consultas.CUENTAS_BANCO_BUSCAR
            End If
            General.agregarItems(consulta, TitulosForm.BUSQUEDA_CAJA_BANCO, dgvcuentas, dtCuentas)
        End If
    End Sub
    Private Sub dgvCuentas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvcuentas.CellEnter
        If e.ColumnIndex = 2 Then
            FuncionesContables.ValidarCreditoDebito(dgvcuentas, Constantes.COLUMNA_DEBITO, Constantes.COLUMNA_CREDITO)
        ElseIf e.ColumnIndex = 4 Then
            FuncionesContables.ValidarCreditoDebito(dgvcuentas, Constantes.COLUMNA_CREDITO, Constantes.COLUMNA_DEBITO)
        End If
        bloquearColumnas()
    End Sub

    Private Sub dgvCuentas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvcuentas.CellClick
        If e.ColumnIndex = 3 Then
            FuncionesContables.ValidarCreditoDebito(dgvcuentas, Constantes.COLUMNA_DEBITO, Constantes.COLUMNA_CREDITO)
        ElseIf e.ColumnIndex = 5 Then
            FuncionesContables.ValidarCreditoDebito(dgvcuentas, Constantes.COLUMNA_CREDITO, Constantes.COLUMNA_DEBITO)
        End If
        bloquearColumnas()
    End Sub
    Private Function digitarCuenta(params As List(Of String)) As DataRow
        Dim params2 As New List(Of String)
        params2.Add("")
        params.Add(dtCuentas.Rows(dgvcuentas.CurrentRow.Index).Item(0).ToString)
        Dim consulta As String
        Dim drCuenta As DataRow
        If Rcaja.Checked = True Then
            consulta = Consultas.CUENTAS_CAJA_BUSCAR
        Else
            consulta = Consultas.CUENTAS_BANCO_BUSCAR
        End If
        drCuenta = General.cargarItem(consulta, params2)
        If Not IsNothing(drCuenta) Then
            Return drCuenta
        Else
            MsgBox("Cuenta inválida", MsgBoxStyle.Exclamation)
        End If
        Return Nothing
    End Function
    Private Sub dgvcuentas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvcuentas.CellEndEdit
        If e.ColumnIndex = 1 Then
            If dtCuentas.Rows(dgvcuentas.CurrentRow.Index).Item(0).ToString <> "" Then
                Dim params As New List(Of String)
                params.Add(codigoPuc)
                params.Add(dtCuentas.Rows(dgvcuentas.CurrentRow.Index).Item(0).ToString)

                Dim fila As DataRow
                fila = digitarCuenta(params)
                If Not IsNothing(fila) Then

                    dtCuentas.Rows(dgvcuentas.CurrentCell.RowIndex).Item("Estado") = Constantes.ITEM_NUEVO
                    If dtCuentas.Rows(dgvcuentas.CurrentRow.Index).Item(0).ToString <> "" And dtCuentas.Rows(dgvcuentas.CurrentRow.Index).Item(1).ToString = "" Then
                        dtCuentas.Rows(dgvcuentas.CurrentRow.Index).Item(1) = fila(1)
                        dtCuentas.Rows.Add()
                    Else
                        dtCuentas.Rows(dgvcuentas.CurrentRow.Index).Item(1) = fila(1)
                    End If
                Else
                    dgvcuentas.Rows(dgvcuentas.CurrentCell.RowIndex).Cells("codigoCuenta").Value = String.Empty
                    dgvcuentas.Rows(dgvcuentas.CurrentCell.RowIndex).Cells("nombre").Value = String.Empty
                End If

            End If

            If dtCuentas.Rows(dgvcuentas.CurrentRow.Index).Item("Debito").ToString = "" Then
                dgvcuentas.Rows(dgvcuentas.CurrentCell.RowIndex).Cells("Debito").Value = 0
            ElseIf dtCuentas.Rows(dgvcuentas.CurrentRow.Index).Item("Credito").ToString = "" Then
                dgvcuentas.Rows(dgvcuentas.CurrentCell.RowIndex).Cells("Credito").Value = 0
            End If
            dtCuentas.AcceptChanges()
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

    Private Sub Rbanco_CheckedChanged(sender As Object, e As EventArgs) Handles Rbanco.CheckedChanged
        dtCuentas.Clear()
        dtCuentas.Rows.Add()
    End Sub

    Private Sub Rcaja_CheckedChanged(sender As Object, e As EventArgs) Handles Rcaja.CheckedChanged
        dtCuentas.Clear()
        dtCuentas.Rows.Add()
    End Sub
    Private Sub Textsigla_Leave(sender As Object, e As EventArgs) Handles Textsigla.Leave
        If Textsigla.Text <> "" Then
            cargarDocumento(Textsigla.Text)
            txtcodigo.Text = FuncionesContables.verificarConsecutivo(SesionActual.idEmpresa, codigoDocumento)
        End If
    End Sub
    Private Sub Form_CajaBanco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        enlazarTabla()
        General.deshabilitarControles(Me)

        codigoDocumento = Constantes.SALDOS_INICIALES
    End Sub
    Private Sub enlazarTabla()

        Dim A1, A2, A3, A4, A5, A6 As New DataColumn

        A1.ColumnName = "codigoCuenta"
        A1.DataType = Type.GetType("System.String")
        dtCuentas.Columns.Add(A1)

        A2.ColumnName = "Nombre"
        A2.DataType = Type.GetType("System.String")
        dtCuentas.Columns.Add(A2)

        A3.ColumnName = "Debito"
        A3.DataType = Type.GetType("System.Double")
        A3.DefaultValue = "0,00"
        dtCuentas.Columns.Add(A3)

        A6.ColumnName = "Estado"
        A6.DataType = Type.GetType("System.String")
        dtCuentas.Columns.Add(A6)

        A4.ColumnName = "Credito"
        A4.DataType = Type.GetType("System.Double")
        A4.DefaultValue = "0,00"
        dtCuentas.Columns.Add(A4)

        A5.ColumnName = "orden"
        A5.DataType = Type.GetType("System.Int32")
        dtCuentas.Columns.Add(A5)

        With dgvcuentas

            .Columns.Item("codigoCuenta").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("codigoCuenta").DataPropertyName = "codigoCuenta"

            .Columns.Item("nombre").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("nombre").DataPropertyName = "Nombre"
            .Columns.Item("nombre").ReadOnly = True

            .Columns.Item("debito").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("debito").DataPropertyName = "Debito"
            .Columns.Item("debito").ReadOnly = False

            .Columns.Item("estado").DataPropertyName = "Estado"
            .Columns.Item("estado").HeaderText = "Estado"
            .Columns.Item("estado").Visible = False

            .Columns.Item("credito").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("credito").DataPropertyName = "Credito"
            .Columns.Item("credito").ReadOnly = False

            .Columns.Item("orden").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("orden").DataPropertyName = "orden"
            .Columns.Item("orden").Visible = False

            .Columns.Item("anular").ReadOnly = True
            .Columns.Item("anular").Width = 80

        End With
        dgvcuentas.DataSource = dtCuentas
        dgvcuentas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvcuentas.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Private Sub dgvcuentas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvcuentas.CellDoubleClick

        Dim consulta As String
        If Rcaja.Checked = True Then
            consulta = Consultas.CUENTAS_CAJA_BUSCAR
        Else
            consulta = Consultas.CUENTAS_BANCO_BUSCAR
        End If
        Try
            If btguardar.Enabled = False Then
                Exit Sub
            End If
            If (dgvcuentas.Rows(dgvcuentas.CurrentCell.RowIndex).Cells("codigoCuenta").Selected = True Or dgvcuentas.Rows(dgvcuentas.CurrentCell.RowIndex).Cells("Nombre").Selected = True) And dtCuentas.Rows(dgvcuentas.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
                General.agregarItems(consulta, TitulosForm.BUSQUEDA_CAJA_BANCO, dgvcuentas, dtCuentas)
            ElseIf dgvcuentas.Rows(dgvcuentas.CurrentCell.RowIndex).Cells("anular").Selected = True And dtCuentas.Rows(dgvcuentas.CurrentCell.RowIndex).Item("codigoCuenta").ToString <> "" Then
                dtCuentas.Rows.RemoveAt(e.RowIndex)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Private Sub form_cajabanco_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) And Panel3.Visible = True Then
            Panel3.Visible = False
            base.Text = ""
            total.Text = ""
            dgvcuentas.Focus()
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
                dgvcuentas.Enabled = True

                ToolStrip1.Enabled = True
                If base.Text <> "" Then
                    If nat.Text = Constantes.PUC_NATURALEZA_DEBITO Then
                        dtCuentas.Rows(dgvcuentas.CurrentRow.Index).Item(3) = total.Text
                    Else
                        dtCuentas.Rows(dgvcuentas.CurrentRow.Index).Item(4) = total.Text
                    End If
                End If
                base.Text = ""
                total.Text = ""
                dgvcuentas.Focus()
            End If

        End If
    End Sub
    Private Sub dgvcuentas_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvcuentas.DataError
        If e.ColumnIndex = 2 Then
            For i = 0 To dgvcuentas.Rows.Count - 1
                If dgvcuentas.Rows(i).Cells(2).Value.ToString = "" Then
                    MsgBox("Por Favor ingrese un valor ", MsgBoxStyle.Exclamation)
                End If
            Next
        ElseIf e.ColumnIndex = 4 Then
            For i = 0 To dgvcuentas.Rows.Count - 1
                If dgvcuentas.Rows(i).Cells(4).Value.ToString = "" Then
                    MsgBox("Por Favor ingrese un valor ", MsgBoxStyle.Exclamation)
                End If
            Next
        End If
    End Sub
End Class