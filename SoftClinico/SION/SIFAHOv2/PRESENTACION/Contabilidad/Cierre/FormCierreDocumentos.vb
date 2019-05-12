
Public Class FormCierreDocumentos
    Dim dtCierre, dtTraslado As New DataTable
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, identificador, nCuenta As String
    Dim codigoPuc, codigoDocumento, idTercero As Integer
    Private Sub FormCierreDocumentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        enlazarTabla()
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        Textnombredocumento.ReadOnly = True
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        Btcerrar.Enabled = False

    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Public Sub enlazarTabla()
        Dim col1, col2, col3, col4, ColT1, ColT2, ColT3, ColT4 As New DataColumn

        col1.ColumnName = "Cuenta"
        col1.DataType = Type.GetType("System.String")
        dtCierre.Columns.Add(col1)

        col2.ColumnName = "Descripcion"
        col2.DataType = Type.GetType("System.String")
        dtCierre.Columns.Add(col2)

        col3.ColumnName = "Debito"
        col3.DataType = Type.GetType("System.Double")
        col3.DefaultValue = 0
        dtCierre.Columns.Add(col3)

        col4.ColumnName = "Credito"
        col4.DataType = Type.GetType("System.Double")
        col4.DefaultValue = 0
        dtCierre.Columns.Add(col4)

        With dgvCierre
            .Columns.Item("Cuenta").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("Cuenta").DataPropertyName = "Cuenta"
            .Columns.Item("Cuenta").ReadOnly = True

            .Columns.Item("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("Descripcion").DataPropertyName = "Descripcion"
            .Columns.Item("Descripcion").ReadOnly = True

            .Columns.Item("Debito").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("Debito").DataPropertyName = "Debito"

            .Columns.Item("Credito").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("Credito").DataPropertyName = "Credito"

        End With
        dgvCierre.AutoGenerateColumns = False
        dgvCierre.DataSource = dtCierre
        dgvCierre.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvCierre.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)

        ColT1.ColumnName = "Cuenta"
        ColT1.DataType = Type.GetType("System.String")
        dtTraslado.Columns.Add(ColT1)

        ColT2.ColumnName = "Descripcion"
        ColT2.DataType = Type.GetType("System.String")
        dtTraslado.Columns.Add(ColT2)

        ColT3.ColumnName = "Debito"
        ColT3.DataType = Type.GetType("System.Double")
        ColT3.DefaultValue = 0
        dtTraslado.Columns.Add(ColT3)

        ColT4.ColumnName = "Credito"
        ColT4.DataType = Type.GetType("System.Double")
        ColT4.DefaultValue = 0
        dtTraslado.Columns.Add(ColT4)

        With dgvTraslado
            .Columns.Item("CuentaT").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("CuentaT").DataPropertyName = "Cuenta"
            .Columns.Item("CuentaT").ReadOnly = True

            .Columns.Item("DescripcionT").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("DescripcionT").DataPropertyName = "Descripcion"
            .Columns.Item("DescripcionT").ReadOnly = True

            .Columns.Item("DebitoT").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("DebitoT").DataPropertyName = "Debito"

            .Columns.Item("CreditoT").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("CreditoT").DataPropertyName = "Credito"

        End With
        dgvTraslado.AutoGenerateColumns = False
        dgvTraslado.DataSource = dtTraslado
        dgvTraslado.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTraslado.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        codigoPuc = FuncionesContables.obtenerPucActivo()
        General.deshabilitarControles(Me)
        codigoDocumento = Constantes.CIERRE_CONTABLE
    End Sub
    Private Sub llenardgvCierre(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        txtcodigo.Text = pCodigo
        General.llenarTabla(Consultas.CIERRE_DOCUMENTOS_DETALLE_CIERRE_CARGAR, params, dtCierre)
        dtCierre.Rows.RemoveAt(dtCierre.Rows.Count - 1)
        If dtCierre.Rows.Count > 0 Then
            calcularTotales()
        Else
            textdiferencia.Text = FormatCurrency(0, 2)
        End If
    End Sub
    Private Sub llenardgvTraslado(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        txtcodigo.Text = pCodigo
        General.llenarTabla(Consultas.CIERRE_DOCUMENTOS_DETALLE_TRASLADO_CARGAR, params, dtTraslado)
    End Sub
    Private Sub cargarDgvCierre(idEmpresa As Integer, fechaInicio As Date, fechaFin As Date)
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        params.Add(DtInicio.Value.Date)
        params.Add(DtFin.Value.Date)
        General.llenarTabla(Consultas.CIERRE_DOCUMENTOS_LLENAR, params, dtCierre)
    End Sub
    Public Function crearCierreDocumentos() As CierreDocumentos
        Dim objCierreDocumentos As New CierreDocumentos
        Dim valorDebito, valorCredito As Double
        valorDebito = textvalordebito.Text
        valorCredito = textvalorcredito.Text
        txtcodigo.Text = FuncionesContables.verificarConsecutivo(SesionActual.idEmpresa, codigoDocumento)
        objCierreDocumentos.comprobante = txtcodigo.Text
        objCierreDocumentos.idEmpresa = SesionActual.idEmpresa
        objCierreDocumentos.fechaInicio = DtInicio.Value.Date
        objCierreDocumentos.fechaFin = DtFin.Value.Date
        objCierreDocumentos.identificador = identificador
        objCierreDocumentos.valorDebito = valorDebito
        objCierreDocumentos.valorCredito = valorCredito
        Dim index As Integer = 0
        For Each drFila As DataRow In dtCierre.Rows
            If drFila.Item("Cuenta").ToString <> "" Then
                Dim drCuenta As DataRow = objCierreDocumentos.dtCierre.NewRow
                drCuenta.Item("comprobante") = txtcodigo.Text
                drCuenta.Item("codigo_puc") = codigoPuc
                drCuenta.Item("codigoCuenta") = drFila.Item("Cuenta")
                drCuenta.Item("debito") = drFila.Item("debito")
                drCuenta.Item("credito") = drFila.Item("credito")
                drCuenta.Item("orden") = index
                objCierreDocumentos.dtCierre.Rows.Add(drCuenta)
                index += 1
            End If
        Next
        For Each drFila As DataRow In dtTraslado.Rows
            Dim drCuenta As DataRow = objCierreDocumentos.dtCierre.NewRow
            drCuenta.Item("comprobante") = txtcodigo.Text
            drCuenta.Item("codigo_puc") = codigoPuc
            drCuenta.Item("codigoCuenta") = drFila.Item("Cuenta")
            drCuenta.Item("debito") = drFila.Item("debito")
            drCuenta.Item("credito") = drFila.Item("credito")
            drCuenta.Item("orden") = index
            objCierreDocumentos.dtCierre.Rows.Add(drCuenta)
            index += 1
        Next
        Return objCierreDocumentos
    End Function
    Private Sub calcularTotales()
        Try
            Dim valorDebito, sumaDebito, sumaCredito, valorCredito, diferencia As Double
            If dgvCierre.Rows.Count > 1 Then
                For indicedgvCartera = 0 To dgvCierre.Rows.Count - 1
                    If dgvCierre.Rows(indicedgvCartera).Cells("Descripcion").Value.ToString <> "" Then
                        sumaDebito = CDbl(dgvCierre.Rows(indicedgvCartera).Cells(2).Value)
                        sumaCredito = CDbl(dgvCierre.Rows(indicedgvCartera).Cells(3).Value)
                        valorDebito = valorDebito + sumaDebito
                        valorCredito = valorCredito + sumaCredito
                    End If
                Next
                diferencia = FormatCurrency((CDbl(valorDebito) - CDbl(valorCredito)), 2)
                textvalordebito.Text = CDbl(valorDebito).ToString("C2")
                textvalorcredito.Text = Math.Abs(valorCredito).ToString("C2")
                textdiferencia.Text = Math.Abs(diferencia).ToString("C2")
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    'Private Sub calcularTotales()
    '    If IsDBNull(dtCierre.Compute("Sum(Debito)", "")) Then
    '        textvalordebito.Text = FormatCurrency(0, 2)
    '    Else
    '        textvalordebito.Text = FormatCurrency(dtCierre.Compute("Sum(Debito)", ""), 2)
    '    End If

    '    If IsDBNull(dtCierre.Compute("Sum(Credito)", "")) Then
    '        textvalorcredito.Text = FormatCurrency(0, 2)
    '    Else
    '        textvalorcredito.Text = FormatCurrency(dtCierre.Compute("Sum(Credito)", ""), 2)
    '    End If
    '    textdiferencia.Text = FormatCurrency(Math.Abs(CDbl(textvalordebito.Text) - CDbl(textvalorcredito.Text)), 2)
    'End Sub
    Private Sub cerrarCuentas(puc As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(codigoPuc)
        General.llenarTabla(Consultas.CIERRE_DOCUMENTOS_CUENTAS_CERRAR, params, dt)
        If dt.Rows.Count > 0 Then
            dtCierre.Rows.Add()
            dtCierre.Rows(dtCierre.Rows.Count - 1).Item("Cuenta") = dt.Rows(0).Item("Cuenta").ToString()
            dtCierre.Rows(dtCierre.Rows.Count - 1).Item("Descripcion") = dt.Rows(0).Item("Nombre").ToString()
        End If
    End Sub
    Private Sub cruzarCuentas(cuenta As String)
        Dim dt As New DataTable
        Dim vDebito, vCredito As Double
        Dim params As New List(Of String)
        calcularTotales()
        vDebito = textvalordebito.Text
        vCredito = textvalorcredito.Text
        If CDbl(vDebito) > CDbl(vCredito) Then
            dtCierre.Rows(dtCierre.Rows.Count - 1).Item("Credito") = CDbl(textdiferencia.Text)
            nCuenta = "360505"
            vCredito = CDbl(textdiferencia.Text)
            vDebito = 0
        ElseIf CDbl(vCredito) > CDbl(vDebito) Then
            dtCierre.Rows(dtCierre.Rows.Count - 1).Item("Debito") = CDbl(textdiferencia.Text)
            nCuenta = "361005"
            vDebito = CDbl(textdiferencia.Text)
            vCredito = 0
        End If
        Dim params2 As New List(Of String)
        params2.Add(0)
        params2.Add(nCuenta)
        General.llenarTabla(Consultas.CUENTAS_PUC_CARGAR, params2, dt)
        If dt.Rows.Count > 0 Then
            dtTraslado.Rows.Add()
            dtTraslado.Rows(dtTraslado.Rows.Count - 1).Item("Cuenta") = dtCierre.Rows(dtCierre.Rows.Count - 1).Item("Cuenta")
            dtTraslado.Rows(dtTraslado.Rows.Count - 1).Item("Descripcion") = dtCierre.Rows(dtCierre.Rows.Count - 1).Item("Descripcion")
            dtTraslado.Rows(dtTraslado.Rows.Count - 1).Item("Debito") = dtCierre.Rows(dtCierre.Rows.Count - 1).Item("Credito")
            dtTraslado.Rows(dtTraslado.Rows.Count - 1).Item("Credito") = dtCierre.Rows(dtCierre.Rows.Count - 1).Item("Debito")
            dtTraslado.Rows.Add()
            dtTraslado.Rows(dtTraslado.Rows.Count - 1).Item("Cuenta") = nCuenta
            dtTraslado.Rows(dtTraslado.Rows.Count - 1).Item("Descripcion") = dt.Rows(0).Item("Descripcion").ToString()
            dtTraslado.Rows(dtTraslado.Rows.Count - 1).Item("Debito") = Math.Abs(vDebito)
            dtTraslado.Rows(dtTraslado.Rows.Count - 1).Item("Credito") = Math.Abs(vCredito)
            Btcerrar.Enabled = False
        End If
    End Sub
    Private Sub Btcerrar_Click(sender As Object, e As EventArgs) Handles Btcerrar.Click
        If dgvCierre.Rows.Count > 0 Then
            cerrarCuentas(codigoPuc)
            cruzarCuentas(nCuenta)
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
    Private Sub DtInicio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DtInicio.ValueChanged
        If DtFin.Value > DateTime.Now.Date Then
            DtFin.Value = DateTime.Now.Date
        End If
        If DtInicio.Value > DtFin.Value Then
            DtInicio.Value = DtFin.Value
        End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgvCierre.EndEdit()
        If Format(CDate(DtInicio.Value), Constantes.FORMATO_FECHA_GEN) >= Format(CDate(DtFin.Value), Constantes.FORMATO_FECHA_GEN) Then
            MsgBox("La fecha de fin no puede ser menor o igual a la fecha de inicio!", MsgBoxStyle.Information)
            DtFin.Focus()
        ElseIf Textnombredocumento.Text = "" Then
            MsgBox("Debe seleccionar el tipo de documento!", MsgBoxStyle.Information)
        ElseIf dtCierre.Rows.Count = 0 Then
            MsgBox("El lapso de tiempo no ha generado ningun registro!!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Información")
        ElseIf dtTraslado.Select("Cuenta='590505'").Count = 0 Then
            MsgBox("Debe cerrar las cuentas antes de guardar !!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Información")
        Else
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                codigoPuc = FuncionesContables.obtenerPucActivo()
                calcularTotales()
                dgvCierre.EndEdit()
                dtCierre.AcceptChanges()
                Dim objCierreDocumentosBLL As New CierreDocumentosBLL
                Try
                    objCierreDocumentosBLL.guardarCiereDocumentos(crearCierreDocumentos(), SesionActual.idUsuario)
                    General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                    FuncionesContables.aumentarConsecutivo(SesionActual.idEmpresa, codigoDocumento)
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub

    Private Sub btBusquedaDocumento_Click(sender As Object, e As EventArgs) Handles btBusquedaDocumento.Click
        General.buscarElemento(Consultas.DOCUMENTOS_SIGLA_BUSCAR,
                             Nothing,
                             AddressOf cargarDocumento,
                             TitulosForm.BUSQUEDA_DOCUMENTOS_CONTABLES,
                             False)
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
    Private Sub DtFin_CloseUp(sender As System.Object, e As System.EventArgs) Handles DtFin.CloseUp
        If DtFin.Value > DtInicio.Value Then
            cargarDgvCierre(SesionActual.idEmpresa, DtInicio.Value.Date, DtFin.Value.Date)
            calcularTotales()
        End If
    End Sub

    Private Sub DtInicio_CloseUp(sender As System.Object, e As System.EventArgs) Handles DtInicio.CloseUp
        If DtFin.Value > DtInicio.Value Then
            cargarDgvCierre(SesionActual.idEmpresa, DtInicio.Value.Date, DtFin.Value.Date)
            calcularTotales()
        End If
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.limpiarControles(Me)
            General.deshabilitarBotones(ToolStrip1)
            General.habilitarControles(Me)
            txtcodigo.Text = FuncionesContables.verificarConsecutivo(SesionActual.idEmpresa, codigoDocumento)
            Textsigla.Text = Constantes.SIGLA_CIERRE_CONTABLE
            Textsigla_Leave(sender, e)
            Textnombredocumento.ReadOnly = True
            btguardar.Enabled = True
            btcancelar.Enabled = True
            identificador = String.Empty
            textvalordebito.ReadOnly = True
            textvalorcredito.ReadOnly = True
            textdiferencia.ReadOnly = True
            Textsigla.ReadOnly = True
            textvalorcredito.Text = FormatCurrency(0, 2)
            textvalordebito.Text = FormatCurrency(0, 2)
            textdiferencia.Text = FormatCurrency(0, 2)
            dgvCierre.ReadOnly = True
            dgvTraslado.ReadOnly = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        'If SesionActual.tienePermiso(PBuscar) Then
        Dim params As New List(Of String)
            params.Add(SesionActual.idEmpresa)

            General.buscarElemento(Consultas.CIERRE_DOCUMENTOS_BUSCAR,
                                   params,
                                   AddressOf cargarDatos,
                                   TitulosForm.BUSQUEDA_DOCUMENTOS_CONTABLES,
                                   False, 0, True)
        'Else
        '    MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        'End If
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                identificador = txtcodigo.Text
                dgvTraslado.ReadOnly = True
                dgvCierre.ReadOnly = True
                textvalorcredito.ReadOnly = True
                textvalordebito.ReadOnly = True
                textdiferencia.ReadOnly = True
                Textsigla.ReadOnly = True
                General.deshabilitarBotones(ToolStrip1)
                btguardar.Enabled = True
                btcancelar.Enabled = True
            End If
        Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub dgvCierre_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCierre.CellEnter
        calcularTotales()
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub

    Private Sub Textsigla_Leave(sender As Object, e As EventArgs) Handles Textsigla.Leave
        If Textsigla.Text <> "" Then
            cargarDocumento(Textsigla.Text)
        End If
    End Sub
    Private Sub cargarDatos(pCodigo As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.CIERRE_DOCUMENTOS_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then

            Textsigla.Text = Constantes.SIGLA_CIERRE_CONTABLE
            cargarDocumento(Textsigla.Text)
            DtInicio.Value = dt.Rows(0).Item("Fecha_Inicio").ToString()
            DtFin.Value = dt.Rows(0).Item("Fecha_Fin").ToString()
            textvalordebito.Text = dt.Rows(0).Item("valor_debito").ToString()
            textvalorcredito.Text = dt.Rows(0).Item("valor_credito").ToString()
            llenardgvCierre(pCodigo)
            llenardgvTraslado(pCodigo)
            General.habilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            btguardar.Enabled = False
            btcancelar.Enabled = False
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
End Class