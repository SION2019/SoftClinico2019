Public Class Form_ClasificacionCuentas
    Private pucActivo As Integer = FuncionesContables.obtenerPucActivo()

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        General.formEditar(Me, ToolStrip1, btguardar, btcancelar)

        txtCodigoCuenta.ReadOnly = True
        txtDescripcionCuenta.ReadOnly = True
        btBusquedaCuenta.Enabled = False

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

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click

        Dim params As New List(Of String)
        params.Add(pucActivo)
        params.Add(Nothing)

        Try
            General.buscarElemento(Consultas.BUSQUEDA_CUENTAS_UCI,
                               params,
                               AddressOf cargarCuentaUCI,
                               TitulosForm.BUSQUEDA_CUENTAS_UCI,
                               False, 0, True)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub Form_ClasificacionCuentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)

        'Combo Tipo
        General.cargarCombo(Consultas.GRUPO_HC_CONFIG_LISTAR, "descripcion", "codigo", cbTipo)

        'Combo Movimiento
        cargarComboMovimiento()

        'Combo Entorno de atencion
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        params.Add(Nothing)
        params.Add(Constantes.VALOR_PREDETERMINADO)
        params.Add(Nothing)

        General.cargarCombo(Consultas.AREA_SERVICIO_LISTAR_CONTRATO,
                            params,
                            "Descripción",
                            "Código",
                             cbEntorno)
    End Sub
    Public Sub cargarCuentaPuc(ByVal pCodigoCuenta As String)
        Dim drCuentaPuc As DataRow
        Dim params As New List(Of String)

        params.Add(pucActivo)
        params.Add(pCodigoCuenta)

        drCuentaPuc = General.cargarItem(Consultas.CUENTAS_PUC_CARGAR, params)

        Dim objCuentaPUC As New CuentaPUC(drCuentaPuc)

        txtCodigoCuenta.Text = objCuentaPUC.getCodigo()
        txtDescripcionCuenta.Text = objCuentaPUC.getDescripcion()
    End Sub

    Public Sub cargarCuentaUCI(ByVal pCodigoCuenta As String)
        Dim drCuentaUCI As DataRow
        Dim params As New List(Of String)
        params.Add(pucActivo)
        params.Add(pCodigoCuenta)

        drCuentaUCI = General.cargarItem(Consultas.CUENTAS_UCI_CARGAR, params)

        txtCodigoCuenta.Text = pCodigoCuenta
        txtDescripcionCuenta.Text = drCuentaUCI.Item("descripcion")
        cbTipo.SelectedValue = drCuentaUCI.Item("tipo")
        cbMovimiento.SelectedValue = drCuentaUCI.Item("movimiento")
        cbEntorno.SelectedValue = drCuentaUCI.Item("entorno")

        General.posBuscarForm(Me, ToolStrip1, btnuevo, bteditar, btanular, btbuscar)
        btBusquedaCuenta.Enabled = False


    End Sub

    Private Sub cargarComboMovimiento()
        Dim dtMovimiento As New DataTable
        Dim drMovimiento As DataRow

        'Se llena informacion en el datatable
        dtMovimiento.Columns.Add("Codigo")
        dtMovimiento.Columns.Add("Descripcion")

        drMovimiento = dtMovimiento.NewRow
        drMovimiento.Item("Codigo") = Constantes.COMBO_VALOR_PREDETERMINADO
        drMovimiento.Item("Descripcion") = Constantes.COMBO_TEXTO_PREDETERMINADO
        dtMovimiento.Rows.Add(drMovimiento)

        drMovimiento = dtMovimiento.NewRow
        drMovimiento.Item("Codigo") = Constantes.CUENTAS_UCI_MOVIMIENTO_COBRAR
        drMovimiento.Item("Descripcion") = Constantes.CUENTAS_UCI_MOVIMIENTO_COBRAR_DESC
        dtMovimiento.Rows.Add(drMovimiento)

        drMovimiento = dtMovimiento.NewRow
        drMovimiento.Item("Codigo") = Constantes.CUENTAS_UCI_MOVIMIENTO_PAGAR
        drMovimiento.Item("Descripcion") = Constantes.CUENTAS_UCI_MOVIMIENTO_PAGAR_DESC
        dtMovimiento.Rows.Add(drMovimiento)

        'Se configura el combo
        cbMovimiento.DataSource = dtMovimiento
        cbMovimiento.ValueMember = "Codigo"
        cbMovimiento.DisplayMember = "Descripcion"

    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click

        Try
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim params As New List(Of String)
                params.Add(pucActivo)
                params.Add(txtCodigoCuenta.Text)
                params.Add(SesionActual.idUsuario)

                General.ejecutarSQL(Consultas.ANULAR_CUENTA_UCI, params)
                General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)

            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarFormulario() AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            guardarCuentaUCI()
        End If

    End Sub

    Private Function validarFormulario() As Boolean

        If txtCodigoCuenta.Text = String.Empty Then
            MsgBox("Favor escoja la cuenta!", MsgBoxStyle.Exclamation)
        ElseIf cbTipo.SelectedValue = Constantes.COMBO_VALOR_PREDETERMINADO Then
            MsgBox("Favor escoja el tipo de la cuenta!", MsgBoxStyle.Exclamation)
        ElseIf cbMovimiento.SelectedValue = Constantes.COMBO_VALOR_PREDETERMINADO Then
            MsgBox("Favor escoja el movimiento de la cuenta!", MsgBoxStyle.Exclamation)
        ElseIf cbEntorno.SelectedValue = Constantes.COMBO_VALOR_PREDETERMINADO Then
            MsgBox("Favor escoja el entorno de atencion de la cuenta!", MsgBoxStyle.Exclamation)
        Else
            Return True
        End If
        Return False

    End Function

    Public Sub guardarCuentaUCI()
        Dim objClasificacionCuentaBLL As New CuentaClasificacionBLL

        Try
            objClasificacionCuentaBLL.guardarCuentaUCI(crearCuentaUCI())
            General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Public Function crearCuentaUCI() As ClasificacionCuentaHC
        Dim cuentaUCI As New ClasificacionCuentaHC

        cuentaUCI.codigoPuc = pucActivo
        cuentaUCI.codigoCuenta = txtCodigoCuenta.Text
        cuentaUCI.codigoGrupoHC = cbTipo.SelectedValue
        cuentaUCI.tipoMovimiento = cbMovimiento.SelectedValue
        cuentaUCI.codigoAreaServicio = cbEntorno.SelectedValue
        cuentaUCI.anulado = False

        Return cuentaUCI

    End Function

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
        txtDescripcionCuenta.ReadOnly = True
        limpiarFormulario()
    End Sub

    Private Sub limpiarFormulario()
        txtCodigoCuenta.Text = String.Empty
        txtDescripcionCuenta.Text = String.Empty
    End Sub

    Private Sub btBusquedaCuenta_Click(sender As Object, e As EventArgs) Handles btBusquedaCuenta.Click
        Dim params As New List(Of String)
        params.Add(pucActivo)
        params.Add(Nothing)

        Try
            General.buscarElemento(Consultas.BUSQUEDA_CUENTAS_PUC,
                                   params,
                                   AddressOf cargarCuentaPuc,
                                   TitulosForm.BUSQUEDA_CUENTAS_PUC,
                                   False, 0, True)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
End Class