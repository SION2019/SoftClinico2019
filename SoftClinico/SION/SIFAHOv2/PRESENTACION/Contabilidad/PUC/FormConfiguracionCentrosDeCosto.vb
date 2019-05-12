Public Class FormConfiguracionCentrosDeCosto
    Dim dgvAsignada As New BindingSource
    Dim dtCuentas As New DataTable
    Private Sub Textdescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextFiltro.TextChanged
        dgvAsignada.Filter = "[Cuenta] LIKE '" + TextFiltro.Text.Trim() + "%' or [Nombre] LIKE '%" + TextFiltro.Text.Trim() + "%'"
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form_antici_decucci_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
        bloquearColumnas()
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub cargarCuentas()
        Dim params As New List(Of String)
        params.Add(FuncionesContables.obtenerPucActivo)
        General.llenarTabla(Consultas.CUENTAS_LISTAR, params, dtCuentas)
        dgvAsignada.DataSource = dtCuentas
        dgvcuentas.DataSource = dgvAsignada
        dgvcuentas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvcuentas.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        dgvcuentas.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvcuentas.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    End Sub
    Private Sub bloquearColumnas()
        With dgvcuentas
            .Columns("Cuenta").ReadOnly = True
            .Columns("Nombre").ReadOnly = True
            txtCuentaPUC.ReadOnly = True
        End With
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
        cargarCuentas()
        bloquearColumnas()
    End Sub
    Private Function validarInformacion()
        If txtCodigoCuenta.Text = "" Then
            MsgBox("¡Por favor escoja una cuenta!", MsgBoxStyle.Exclamation)
            btBusquedaCuenta.Focus()
            Return False
        End If
        Return True
    End Function
    Public Function crearConfiguracion() As ConfiguracionCentroDeCostos
        Dim objConcepto As New ConfiguracionCentroDeCostos
        Dim filas As DataRow()
        objConcepto.dtCuentas.Clear()
        filas = dtCuentas.Select("Seleccionar ='True'", "")
        For Each drFila As DataRow In dtCuentas.Rows
            If drFila.Item("Seleccionar") = True Then
                Dim drCuenta As DataRow = objConcepto.dtCuentas.NewRow
                drCuenta.Item("CuentaHomologa") = txtCodigoCuenta.Text
                drCuenta.Item("Cuenta") = drFila.Item("Cuenta")
                drCuenta.Item("sede") = drFila.Item("Sede 50")
                objConcepto.dtCuentas.Rows.Add(drCuenta)
            End If
        Next
        Return objConcepto
    End Function
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarInformacion() Then
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                Dim objCostos_D As New ConfiguracionCentroDeCostosBLL
                Try
                    dgvcuentas.EndEdit()
                    dtCuentas.AcceptChanges()
                    objCostos_D.guardar(crearConfiguracion())
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                    General.deshabilitarControles(Me)
                    General.habilitarBotones(Me.ToolStrip1)
                    cargarDatos()
                    btguardar.Enabled = False
                    btcancelar.Enabled = False
                Catch ex As Exception
                    general.manejoErrores(ex)
                End Try
            End If
        End If
    End Sub
    Private Sub cargarDatos()
        Dim params As New List(Of String)
        params.Add(txtCodigoCuenta.Text)
        General.llenarTabla(Consultas.CONFIGURACION_CENTRO_COSTO_CARGAR, params, dtCuentas)
        dgvAsignada.DataSource = dtCuentas
        dgvcuentas.DataSource = dtCuentas
        dgvcuentas.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        dgvcuentas.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvcuentas.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        TextFiltro.ReadOnly = False
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Dim tbl As DataRow = Nothing
        Dim params As New List(Of String)
        params.Add(FuncionesContables.obtenerPucActivo)
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.CONFIGURACION_CENTRO_COSTO_BUSCAR, params, TitulosForm.BUSQUEDA_CONFIGURACION_AUDITORIA, False)
        tbl = formBusqueda.rowResultados
        If tbl IsNot Nothing Then
            General.habilitarBotones(ToolStrip1)
            btguardar.Enabled = False
            btcancelar.Enabled = False

            txtCodigoCuenta.Text = tbl(0)

            cargarDatos()
        Else
            Exit Sub
        End If
    End Sub
    Private Sub ChTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChTodos.CheckedChanged
        If ChTodos.Checked = True Then
            For indice = 0 To dgvcuentas.Rows.Count - 1
                dgvcuentas.Rows(indice).Cells("Seleccionar").Value = True
            Next
        Else
            For indice = 0 To dgvcuentas.Rows.Count - 1
                dgvcuentas.Rows(indice).Cells("Seleccionar").Value = False
            Next
        End If
        dtCuentas.AcceptChanges()
    End Sub

    Private Sub FormConfiguracionCentrosDeCosto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btnuevo.Enabled = True
        btbuscar.Enabled = True
    End Sub

    Private Sub btBusquedaCuenta_Click(sender As Object, e As EventArgs) Handles btBusquedaCuenta.Click
        Dim params As New List(Of String)
        params.Add(FuncionesContables.obtenerPucActivo)
        params.Add(Nothing)

        General.buscarElemento(Consultas.BUSQUEDA_CUENTAS_PUC,
                               params,
                               AddressOf cargarCuentaPUC,
                               TitulosForm.BUSQUEDA_CUENTAS_PUC,
                               False, 0, True)
    End Sub
    Public Sub cargarCuentaPUC(ByVal pCodigoCuenta As String)
        Dim dtCuentasPUC As New DataTable

        Dim params As New List(Of String)
        params.Add(FuncionesContables.obtenerPucActivo)
        params.Add(pCodigoCuenta)

        General.llenarTabla(Consultas.CUENTAS_PUC_CARGAR,
                            params,
                            dtCuentasPUC)

        Dim objCuentaPUC As New CuentaPUC(dtCuentasPUC.Rows(0))

        txtCodigoCuenta.Text = objCuentaPUC.getCodigo
        txtCuentaPUC.Text = objCuentaPUC.getDescripcion
    End Sub

    Private Sub dgvcuentas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvcuentas.CellDoubleClick
        If e.ColumnIndex = 3 Then
            Dim tbl As DataRow = Nothing
            Try
                If btguardar.Enabled = False Then
                    Exit Sub
                End If
                Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.PUNTOS_SERVICIO_LISTAR, Nothing, TitulosForm.BUSQUEDA_PUNTO_SERVICIO, True)
                tbl = formBusqueda.rowResultados
                If tbl IsNot Nothing Then
                    dtCuentas.Rows(dgvcuentas.CurrentCell.RowIndex).Item("Codigo") = tbl(0)
                End If
            Catch ex As Exception
                general.manejoErrores(ex)
            End Try
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        FormConfiguracionTipoCuenta.MdiParent = FormPrincipal
        General.cargarForm(FormConfiguracionTipoCuenta)
    End Sub


End Class