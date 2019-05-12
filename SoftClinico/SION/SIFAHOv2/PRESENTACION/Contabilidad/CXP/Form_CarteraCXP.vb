Public Class Form_CarteraCXP
    Dim dtCartera As New DataTable
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, identificador, comprobante As String
    Dim codigoPuc, codigoDocumento As Integer
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub llenardgv(pCodigo As DateTime, idempresa As Integer)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(idempresa)
        General.llenarTabla(Consultas.CARTERA_CXP_CUENTAS_CARGAR, params, dtCartera)
        dgvCartera.Rows(dgvCartera.RowCount - 1).Cells(0).Selected = True
    End Sub
    Private Sub dgvCuentas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCartera.CellEnter

        If e.ColumnIndex = 6 Then
            FuncionesContables.ValidarCreditoDebito(dgvCartera, Constantes.COLUMNA_DEBITO, Constantes.COLUMNA_CREDITO)
        ElseIf e.ColumnIndex = 7 Then
            FuncionesContables.ValidarCreditoDebito(dgvCartera, Constantes.COLUMNA_CREDITO, Constantes.COLUMNA_DEBITO)
        End If
        deshabilitarColumnas()
    End Sub

    Private Sub dgvCuentas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCartera.CellClick
        If e.ColumnIndex = 6 Then
            FuncionesContables.ValidarCreditoDebito(dgvCartera, Constantes.COLUMNA_DEBITO, Constantes.COLUMNA_CREDITO)
        ElseIf e.ColumnIndex = 7 Then
            FuncionesContables.ValidarCreditoDebito(dgvCartera, Constantes.COLUMNA_CREDITO, Constantes.COLUMNA_DEBITO)
        End If
        deshabilitarColumnas()
    End Sub
    Private Sub fechadoc_Leave(sender As Object, e As EventArgs) Handles fechadoc.Leave
        FuncionesContables.validarFechaFutura(fechadoc)
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
    Public Function validarDatosDgv()
        If (dgvCartera.RowCount = 1) Then
            MsgBox("No se puede guardar registros en blanco", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Atención")
            dgvCartera.Focus()
            Return False
        Else
            For i = 0 To dgvCartera.Rows.Count - 2

                If dgvCartera.Rows(i).Cells("cuenta").Value.ToString = "" Then
                    MsgBox("El tercero " + dgvCartera.Rows(i).Cells("Tercero").Value.ToString + ", no tiene cuenta configurada", 48, "Atención")
                    Return False
                End If
            Next
        End If
        Return True
    End Function
    Private Sub deshabilitarColumnas()
        With dgvCartera
            .Columns.Item("Factura").ReadOnly = True
            .Columns.Item("nit").ReadOnly = True
            .Columns.Item("Tercero").ReadOnly = True
            .Columns.Item("Descripcion").ReadOnly = True
            .Columns.Item("Cuenta").ReadOnly = True
        End With
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            dtCartera.Clear()
            dtCartera.Rows.Add()
            Textsigla.Focus()
            Textsigla.Text = Constantes.SIGLA_SALDOS_INICIALES
            General.deshabilitarBotones(ToolStrip1)
            General.habilitarControles(Me)
            btguardar.Enabled = True
            btcancelar.Enabled = True
            dgvCartera.Focus()
            identificador = String.Empty
            deshabilitarColumnas()
            Textvalorcredito.Text = FormatCurrency(0, 2)
            Textvalordebito.Text = FormatCurrency(0, 2)
            Textdiferencia.Text = FormatCurrency(0, 2)
            Textsigla.ReadOnly = True
            Textvalorcredito.ReadOnly = True
            Textvalordebito.ReadOnly = True
            Textdiferencia.ReadOnly = True
            PnlInfo.Visible = False
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub cargarDatos(pCodigo As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        identificador = pCodigo
        General.llenarTabla(Consultas.CARTERA_CXP_CARGAR, params, dt)
        Textsigla.Text = Constantes.SIGLA_SALDOS_INICIALES
        cargarDocumento(Textsigla.Text)
        comprobante = pCodigo
        fechadoc.Value = dt.Rows(0).Item("Fecha_Doc").ToString()
        llenardgv(fechadoc.Value, SesionActual.idEmpresa)
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
        calcularTotales()
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

            General.buscarElemento(Consultas.CARTERA_CXP_BUSCAR,
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
                dtCartera.Rows.Add()
                deshabilitarColumnas()
                Textsigla.ReadOnly = True
                Textvalorcredito.ReadOnly = True
                Textvalordebito.ReadOnly = True
                Textdiferencia.ReadOnly = True
                deshabilitarColumnas()
                General.deshabilitarBotones(ToolStrip1)
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

    Private Sub dgvcartera_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvCartera.EditingControlShowing,
            dgvCartera.EditingControlShowing
        If dgvCartera.CurrentCell.ColumnIndex = 6 Or dgvCartera.CurrentCell.ColumnIndex = 7 Or dgvCartera.CurrentCell.ColumnIndex = 0 Then
            AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarValoresNumericos
        End If
    End Sub
    Private Sub calcularTotales()

        Try
            Dim valorDebito, sumaDebito, sumaCredito, valorCredito As Double
            If dgvCartera.Rows.Count > 1 Then
                For indicedgvCartera = 0 To dgvCartera.Rows.Count - 1
                    If dgvCartera.Rows(indicedgvCartera).Cells("Descripcion").Value.ToString <> "" Then
                        sumaDebito = CDbl(dgvCartera.Rows(indicedgvCartera).Cells(6).Value)
                        sumaCredito = CDbl(dgvCartera.Rows(indicedgvCartera).Cells(7).Value)
                        valorDebito = valorDebito + sumaDebito
                        valorCredito = valorCredito + sumaCredito
                    End If
                Next
                Textdiferencia.Text = FormatCurrency((CDbl(valorDebito) - CDbl(valorCredito)), 2)
                Textvalordebito.Text = CDbl(valorDebito).ToString("C2")
                Textvalorcredito.Text = CDbl(valorCredito).ToString("C2")
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    'Public Sub calcularTotales()
    '    If IsDBNull(dtCartera.Compute("Sum(Debito)", "")) Then
    '        Textvalordebito.Text = FormatCurrency(0, 2)
    '    Else
    '        Textvalordebito.Text = FormatCurrency(dtCartera.Compute("Sum(Debito)", ""), 2)
    '    End If
    '    If IsDBNull(dtCartera.Compute("Sum(Credito)", "")) Then
    '        Textvalorcredito.Text = FormatCurrency(0, 2)
    '    Else
    '        Textvalorcredito.Text = FormatCurrency(dtCartera.Compute("Sum(Credito)", ""), 2)
    '    End If
    '    Textdiferencia.Text = FormatCurrency(Math.Abs(CDbl(Textvalordebito.Text) - CDbl(Textvalorcredito.Text)), 2)
    'End Sub
    Private Sub dgvcartera_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvCartera.KeyDown
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        If e.KeyCode = Keys.F3 And btguardar.Enabled = True Then
            General.busquedaItems(Consultas.FACTURAS_CXP_BUSCAR, params, TitulosForm.BUSQUEDA_CAJA_BANCO, dgvCartera, dtCartera, 0, 4, 0, 0)
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
    Private Sub dgvCartera_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCartera.CellEndEdit
        If dtCartera.Rows(dgvCartera.CurrentRow.Index).Item("Debito").ToString = "" Then
            dgvCartera.Rows(dgvCartera.CurrentCell.RowIndex).Cells("Debito").Value = 0

        ElseIf dtCartera.Rows(dgvCartera.CurrentRow.Index).Item("Credito").ToString = "" Then
            dgvCartera.Rows(dgvCartera.CurrentCell.RowIndex).Cells("Credito").Value = 0
        End If
        dtCartera.AcceptChanges()
        calcularTotales()
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
    Public Sub enlazarTabla()
        Dim col1, col2, col3, col4, col5, col6, col7, col8, col9 As New DataColumn

        col1.ColumnName = "Factura"
        col1.DataType = Type.GetType("System.String")
        dtCartera.Columns.Add(col1)

        col2.ColumnName = "Nit"
        col2.DataType = Type.GetType("System.String")
        dtCartera.Columns.Add(col2)

        col3.ColumnName = "Tercero"
        col3.DataType = Type.GetType("System.String")
        dtCartera.Columns.Add(col3)

        col4.ColumnName = "Cuenta"
        col4.DataType = Type.GetType("System.String")
        dtCartera.Columns.Add(col4)

        col5.ColumnName = "Descripcion"
        col5.DataType = Type.GetType("System.String")
        dtCartera.Columns.Add(col5)

        col6.ColumnName = "Debito"
        col6.DataType = Type.GetType("System.Double")
        col6.DefaultValue = 0
        dtCartera.Columns.Add(col6)

        col7.ColumnName = "Credito"
        col7.DataType = Type.GetType("System.Double")
        col7.DefaultValue = 0
        dtCartera.Columns.Add(col7)

        col8.ColumnName = "Comprobante"
        col8.DataType = Type.GetType("System.String")
        dtCartera.Columns.Add(col8)

        col9.ColumnName = "Estado"
        col9.DataType = Type.GetType("System.Int32")
        dtCartera.Columns.Add(col9)

        With dgvCartera
            .Columns.Item("dgComprobante").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgComprobante").DataPropertyName = "Comprobante"

            .Columns.Item("Factura").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("Factura").DataPropertyName = "Factura"

            .Columns.Item("nit").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("nit").DataPropertyName = "Nit"
            .Columns.Item("nit").ReadOnly = True

            .Columns.Item("Tercero").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("Tercero").DataPropertyName = "Tercero"
            .Columns.Item("Tercero").ReadOnly = True

            .Columns.Item("Cuenta").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("Cuenta").DataPropertyName = "Cuenta"

            .Columns.Item("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("Descripcion").DataPropertyName = "Descripcion"
            .Columns.Item("Descripcion").ReadOnly = True

            .Columns.Item("Debito").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("Debito").DataPropertyName = "Debito"

            .Columns.Item("Credito").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("Credito").DataPropertyName = "Credito"

            .Columns.Item("estado").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("estado").DataPropertyName = "Estado"

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With

        dgvCartera.AutoGenerateColumns = False
        dgvCartera.DataSource = dtCartera
        dgvCartera.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvCartera.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Private Sub Form_CarteraCXP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        enlazarTabla()
        General.deshabilitarControles(Me)

        codigoDocumento = Constantes.SALDOS_INICIALES
    End Sub
    Private Function validaInformacion() As Boolean
        dgvCartera.EndEdit()

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
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validaInformacion() Then
            If FuncionesContables.validardgv(dtCartera) Then
                If validarDatosDgv() Then
                    If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                        codigoPuc = FuncionesContables.obtenerPucActivo()
                        Dim objcarteraCXP_D As New CarteraCuentaPorPagarBLL
                        calcularTotales()
                        Try
                            objcarteraCXP_D.guardarCarteraCXP(crearCarteraCXP())
                            General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                            FuncionesContables.removerUltimafila(dtCartera, dgvCartera)
                        Catch ex As Exception
                            General.manejoErrores(ex)
                        End Try
                    End If
                End If
            End If
        End If
    End Sub
    Public Function crearCarteraCXP() As CarteraCXP
        Dim objcarteraCXP As New CarteraCXP
        Dim valorDebito, valorCredito As Double
        valorDebito = Textvalordebito.Text
        valorCredito = Textvalorcredito.Text
        objcarteraCXP.identificador = comprobante

        Dim index As Integer = 0
        For Each drFila As DataRow In dtCartera.Rows
            If drFila.Item("Factura").ToString <> "" Then
                Dim drCuenta As DataRow = objcarteraCXP.dtCartera.NewRow
                Dim drCuentaP As DataRow = objcarteraCXP.dtCarteraP.NewRow
                If String.IsNullOrEmpty(identificador) Then
                    drCuenta.Item("comprobante") = FuncionesContables.verificarConsecutivo(SesionActual.idEmpresa, codigoDocumento)
                Else
                    drCuenta.Item("comprobante") = drFila.Item("comprobante")
                End If
                drCuenta.Item("codigo_puc") = codigoPuc
                drCuenta.Item("codigoCuenta") = drFila.Item("Cuenta")
                drCuenta.Item("debito") = drFila.Item("debito")
                drCuenta.Item("credito") = drFila.Item("credito")
                drCuenta.Item("orden") = index
                drCuentaP.Item("comprobante") = drCuenta.Item("comprobante")
                drCuentaP.Item("idEmpresa") = SesionActual.idEmpresa
                drCuentaP.Item("codigoDocumento") = codigoDocumento
                drCuentaP.Item("codigoFactura") = drFila.Item("Factura")
                drCuentaP.Item("idProveedor") = drFila.Item("Nit")
                drCuentaP.Item("fechaRecibo") = fechadoc.Value.Date
                drCuentaP.Item("fechaVence") = fechadoc.Value.Date
                drCuentaP.Item("fechaDoc") = fechadoc.Value.Date
                drCuentaP.Item("valorDebito") = valorDebito
                drCuentaP.Item("valorCredito") = valorCredito
                drCuentaP.Item("usuario") = SesionActual.idUsuario
                objcarteraCXP.dtCartera.Rows.Add(drCuenta)
                objcarteraCXP.dtCarteraP.Rows.Add(drCuentaP)
                index += 1
                If String.IsNullOrEmpty(identificador) Then
                    FuncionesContables.aumentarConsecutivo(SesionActual.idEmpresa, codigoDocumento)
                End If
            End If
        Next

        Return objcarteraCXP
    End Function
    Private Sub dgvcartera_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCartera.CellDoubleClick
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        Try
            If btguardar.Enabled = False Then
                Exit Sub
            End If
            If (dgvCartera.Rows(dgvCartera.CurrentCell.RowIndex).Cells("Factura").Selected = True) And dtCartera.Rows(dgvCartera.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
                General.busquedaItems(Consultas.FACTURAS_CXP_BUSCAR, params, TitulosForm.BUSQUEDA_CAJA_BANCO, dgvCartera, dtCartera, 0, 4, 0, 0)
            ElseIf dgvCartera.Rows(dgvCartera.CurrentCell.RowIndex).Cells("anular").Selected = True And dtCartera.Rows(dgvCartera.CurrentCell.RowIndex).Item("Factura").ToString <> "" Then
                If dtCartera.Rows(dgvCartera.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_NUEVO Then
                    dtCartera.Rows.RemoveAt(e.RowIndex)
                End If
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
End Class