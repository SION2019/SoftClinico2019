Public Class Form_CuentasPUC

    Private objCuentaPucBLL As New CuentaPucBLL
    Private dsCuentas As DataSet
    Private codigoPUC As String
    Private descripcionPUC As String
    Private anoPUC As String

    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        General.formNuevo(gbDetalleCuenta, ToolStrip1, btguardar, btcancelar)
        cargarInfoPUC(codigoPUC, anoPUC, descripcionPUC)
        txtCodigoCuenta.ReadOnly = False
        txtNivel.ReadOnly = True

        'Valor por defecto del check visible para una nueva cuenta
        chkVisible.Checked = True
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
        cargarInfoPUC(codigoPUC, anoPUC, descripcionPUC)
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        General.formEditar(gbDetalleCuenta, ToolStrip1, btguardar, btcancelar)
    End Sub

    Private Sub Form_CuentasPUC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cargarComboPUC(cbTipo, llenarSlTipoCuenta())
        cargarComboPUC(cbNaturaleza, llenarSlNaturaleza())

        General.posLoadForm(gbDetalleCuenta, ToolStrip1, btnuevo, btbuscar)

    End Sub

    Private Function llenarSlTipoCuenta() As SortedList
        Dim slTipoCuenta As New SortedList

        slTipoCuenta.Add(Constantes.COMBO_TEXTO_PREDETERMINADO, Constantes.COMBO_VALOR_PREDETERMINADO)
        slTipoCuenta.Add(FuncionesContables.getTipoCuentaPUC(Constantes.PUC_TIPO_DETALLE), Constantes.PUC_TIPO_DETALLE)
        slTipoCuenta.Add(FuncionesContables.getTipoCuentaPUC(Constantes.PUC_TIPO_TITULO), Constantes.PUC_TIPO_TITULO)

        Return slTipoCuenta
    End Function


    Private Function llenarSlNaturaleza() As SortedList
        Dim slNaturaleza As New SortedList

        slNaturaleza.Add(Constantes.COMBO_TEXTO_PREDETERMINADO, Constantes.COMBO_VALOR_PREDETERMINADO)
        slNaturaleza.Add(FuncionesContables.getNaturalezaCuenta(Constantes.PUC_NATURALEZA_DEBITO), Constantes.PUC_NATURALEZA_DEBITO)
        slNaturaleza.Add(FuncionesContables.getNaturalezaCuenta(Constantes.PUC_NATURALEZA_CREDITO), Constantes.PUC_NATURALEZA_CREDITO)

        Return slNaturaleza
    End Function

    Private Sub cargarComboPUC(ByRef comboPUC As ComboBox, ByVal dtPUC As SortedList)
        Dim bsCombo As New BindingSource

        bsCombo.DataSource = dtPUC

        comboPUC.Items.Clear()
        comboPUC.DataSource = bsCombo
        comboPUC.ValueMember = "value"
        comboPUC.DisplayMember = "key"
    End Sub

    Public Sub cargarInfoPUC(ByVal pCodigoPUC As String,
                             ByVal pAnoPUC As String,
                             ByVal pDescripcionPUC As String)

        codigoPUC = pCodigoPUC
        descripcionPUC = pDescripcionPUC
        anoPUC = pAnoPUC

        txtCodigoPUC.Text = codigoPUC
        txtDescripcionPUC.Text = descripcionPUC
        txtAnoPUC.Text = anoPUC

    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarFormulario() AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then

            Dim objCuentaPUC = crearCuentaPUC()
            guardarCuentaPUC(objCuentaPUC)
        End If

    End Sub

    Private Sub guardarCuentaPUC(ByVal objCuentaPUC As CuentaPUC)
        Try
            objCuentaPucBLL.guardarCuentaPUC(objCuentaPUC, SesionActual.idUsuario)
            General.posGuardarForm(gbDetalleCuenta, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Function crearCuentaPUC() As CuentaPUC
        Dim objCuentaPUC = New CuentaPUC()

        objCuentaPUC.setCodigoPUC(txtCodigoPUC.Text)
        objCuentaPUC.setCodigo(txtCodigoCuenta.Text)
        objCuentaPUC.setDescripcion(txtCuentaPUC.Text)
        objCuentaPUC.setTipo(cbTipo.SelectedValue)
        objCuentaPUC.setNivel(txtNivel.Text)
        objCuentaPUC.setNaturalea(cbNaturaleza.SelectedValue)
        objCuentaPUC.setClasifiacion(txtClasificacion.Text)
        objCuentaPUC.setCuentaPadre(txtCodigoPadre.Text)
        objCuentaPUC.setVisible(chkVisible.Checked)

        Return objCuentaPUC
    End Function

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Dim params As New List(Of String)
        params.Add(txtCodigoPUC.Text)
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
        params.Add(txtCodigoPUC.Text)
        params.Add(pCodigoCuenta)

        General.llenarTabla(Consultas.CUENTAS_PUC_CARGAR,
                            params,
                            dtCuentasPUC)

        Dim objCuentaPUC As New CuentaPUC(dtCuentasPUC.Rows(0))

        txtCodigoCuenta.Text = objCuentaPUC.getCodigo
        txtCuentaPUC.Text = objCuentaPUC.getDescripcion
        cbTipo.SelectedValue = objCuentaPUC.getTipo
        cbNaturaleza.SelectedValue = objCuentaPUC.getNaturaleza
        txtClasificacion.Text = objCuentaPUC.getClasificacion
        txtCodigoPadre.Text = objCuentaPUC.getCuentaPadre
        txtNombreCuentaPadre.Text = dtCuentasPUC.Rows(0).Item("NOMBRE_CUENTA_PADRE")
        txtNivel.Text = objCuentaPUC.getNivel
        chkVisible.Checked = objCuentaPUC.getVisible

        General.posBuscarForm(Me, ToolStrip1, btnuevo, bteditar, btanular, btbuscar)
        cargarArbolPUC("padre", "codigo_cuenta", "nombre")

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

    Private Function validarFormulario()

        If String.IsNullOrEmpty(txtCodigoCuenta.Text) Then
            MsgBox("Favor digitar codigo de la cuenta", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            txtCodigoCuenta.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtCuentaPUC.Text) Then
            MsgBox("Favor digitar el nombre de la cuenta", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            txtCuentaPUC.Focus()
            Return False

        ElseIf cbTipo.SelectedValue = Constantes.COMBO_VALOR_PREDETERMINADO Then
            MsgBox("Favor seleccionar el tipo de la cuenta", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            cbTipo.Focus()
            Return False

        ElseIf cbNaturaleza.SelectedValue = Constantes.COMBO_VALOR_PREDETERMINADO Then
            MsgBox("Favor seleccionar la naturaleza de la cuenta", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            cbNaturaleza.Focus()
            Return False

        ElseIf String.IsNullOrEmpty(txtNivel.Text) Then
            MsgBox("Favor digitar el nivel de la cuenta", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            txtNivel.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub txtCodigoCuenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoCuenta.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub

    Public Sub cargarArbolPUC(campoPadre As String,
                              campoHijo As String,
                              campoMostrado As String)
        Dim nodo As TreeNode
        Dim drCuentaPadre As DataRow()

        tvCuentasPUC.Enabled = True
        tvCuentasPUC.Nodes.Clear()
        tvCuentasPUC.ExpandAll()

        Try
            dsCuentas = New DataSet
            objCuentaPucBLL.cargarCuentas(txtCodigoPUC.Text, dsCuentas)
            drCuentaPadre = dsCuentas.Tables(campoPadre).Select()

            'Se recorren las cuentas Padre
            For Each drFila As DataRow In drCuentaPadre
                nodo = New TreeNode
                nodo.Name = drFila(campoHijo).ToString()
                nodo.Text = nodo.Name & "." & "  " & drFila(campoMostrado).ToString()

                tvCuentasPUC.Nodes.Add(nodo)

                'Se recorren las cuentas hijas
                crearSubcuentas(nodo, campoHijo)
            Next
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

        dsCuentas.Dispose()

    End Sub
    Private Sub crearSubcuentas(ByRef nodoPade As TreeNode, campoHijo As String)
        Dim expr As String = "padre ='" & nodoPade.Name & "'"
        Dim subnodo As TreeNode

        Try
            Dim aDrFilas As DataRow()
            aDrFilas = dsCuentas.Tables("Hijas").Select(expr, campoHijo)

            For Each drFila As DataRow In aDrFilas
                subnodo = New TreeNode
                subnodo.Name = drFila(campoHijo).ToString()
                subnodo.Text = subnodo.Name & "." & "  " & drFila("nombre").ToString()

                nodoPade.Nodes.Add(subnodo)
                crearSubcuentas(subnodo, campoHijo)
            Next
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Try
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim params As New List(Of String)

                params.Add(txtCodigoPUC.Text)
                params.Add(txtCodigoCuenta.Text)
                params.Add(SesionActual.idUsuario)

                General.ejecutarSQL(Consultas.ANULAR_CUENTA_PUC, params)

                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
                cargarInfoPUC(codigoPUC, anoPUC, descripcionPUC)
                cargarArbolPUC("padre", "codigo_cuenta", "nombre")

            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Private Sub txtNivel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNivel.KeyPress
        ValidacionDigitacion.validarValoresNumericos(e)
    End Sub

    Private Sub txtCodigoCuenta_Leave(sender As Object, e As EventArgs) Handles txtCodigoCuenta.Leave
        If txtCodigoCuenta.Text <> String.Empty Then
            validarCuenta(txtCodigoCuenta.Text)
        End If
    End Sub

    Public Sub validarCuenta(codigoCuenta As String)
        Dim pucActivo As Integer = FuncionesContables.obtenerPucActivo()
        Dim validaCuentaPuc As Integer
        validaCuentaPuc = FuncionesContables.validarCuentaPuc(pucActivo, txtCodigoCuenta.Text)

        If validaCuentaPuc = FuncionesContables.estadoCuentaPuc.invalida Then
            MsgBox("Cuenta invalida!", MsgBoxStyle.Exclamation)
            txtCodigoCuenta.Text = String.Empty
            txtCodigoPadre.Text = String.Empty
            txtNombreCuentaPadre.Text = String.Empty
            txtClasificacion.Text = String.Empty
            txtCodigoCuenta.Focus()
        ElseIf validaCuentaPuc = FuncionesContables.estadoCuentaPuc.existente Then
            Dim drCuentaPuc As DataRow
            Dim params As New List(Of String)
            params.Add(pucActivo)
            params.Add(codigoCuenta)
            drCuentaPuc = FuncionesContables.digitarCuenta(params)

            If Not IsNothing(drCuentaPuc) Then
                txtCuentaPUC.Text = drCuentaPuc("descripcion")
                txtCodigoPadre.Text = drCuentaPuc("padre")
                txtNombreCuentaPadre.Text = drCuentaPuc("nombre_cuenta_padre")
                txtClasificacion.Text = drCuentaPuc("clasificacion")
                txtNivel.Text = drCuentaPuc("nivel")
            End If
        Else
            Dim drCuentaPadre As DataRow
            Dim params As New List(Of String)
            params.Add(pucActivo)
            params.Add(codigoCuenta)
            drCuentaPadre = General.cargarItem("PROC_PUC_DETALLE_CARGAR_PADRE", params)

            txtCodigoPadre.Text = drCuentaPadre("codigo_cuenta")
            txtNombreCuentaPadre.Text = drCuentaPadre("descripcion")
            txtClasificacion.Text = drCuentaPadre("clasificacion")
            txtNivel.Text = CInt(drCuentaPadre("nivel")) + 1
        End If
    End Sub


End Class