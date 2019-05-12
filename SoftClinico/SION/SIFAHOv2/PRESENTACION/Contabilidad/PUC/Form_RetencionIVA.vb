Public Class Form_RetencionIVA
    Private codigoPUC As String
    Private descripcionPUC As String

    Private Sub Form_RetencionIVA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
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

    Public Sub cargarInfoPUC(ByVal pCodigoPUC As String, ByVal pDescripcionPUC As String)

        codigoPUC = pCodigoPUC
        descripcionPUC = pDescripcionPUC

        txtCodigoPUC.Text = codigoPUC
        txtDescripcionPUC.Text = descripcionPUC

    End Sub

    Private Sub btBusquedaCuenta_Click(sender As Object, e As EventArgs) Handles btBusquedaCuenta.Click

        Dim params As New List(Of String)
        params.Add(txtCodigoPUC.Text)
        params.Add(Nothing)

        General.buscarElemento(Consultas.BUSQUEDA_CUENTAS_PUC_RETENCION,
                               params,
                               AddressOf cargarCuentaPUC,
                               TitulosForm.BUSQUEDA_CUENTAS_PUC_RETENCION,
                               False, 0, True)

    End Sub

    Public Sub cargarCuentaPUC(ByVal pCodigoCuenta As String)
        Dim drCuentaPUC As DataRow
        Dim params As New List(Of String)

        params.Add(codigoPUC)
        params.Add(pCodigoCuenta)

        drCuentaPUC = General.cargarItem(Consultas.CUENTAS_DETALLE_CARGAR,
                                        params)

        Dim objCuentaPUC As New CuentaPUC(drCuentaPUC)
        General.limpiarControles(Me)

        cargarInfoPUC(codigoPUC, descripcionPUC)
        txtCodigoCuenta.Text = objCuentaPUC.getCodigo
        txtNombreCuenta.Text = objCuentaPUC.getDescripcion
    End Sub

    Public Sub cargarRetencionIVA(ByVal pCodigoCuenta As String)
        cargarCuentaPUC(pCodigoCuenta)
        Dim params As New List(Of String)
        Dim drRetencionIva As DataRow

        params.Add(codigoPUC)
        params.Add(pCodigoCuenta)

        drRetencionIva = General.cargarItem(Consultas.RETENCION_IVA_CARGAR, params)
        Dim objRetencionIVA As New RetencionIVA(drRetencionIva)

        txtBase.Text = objRetencionIVA.base
        txtTasa.Text = objRetencionIVA.tasa
        txtObservacion.Text = objRetencionIVA.observacion

        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
    End Sub

    Private Sub txtBase_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBase.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub

    Private Sub txtTasa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTasa.KeyPress
        ValidacionDigitacion.validarSoloNumerosPositivo(e)
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click

        General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
        txtDescripcionPUC.ReadOnly = True
        txtNombreCuenta.ReadOnly = True
        cargarInfoPUC(codigoPUC, descripcionPUC)

    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Try
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim params As New List(Of String)

                params.Add(txtCodigoPUC.Text)
                params.Add(txtCodigoCuenta.Text)
                params.Add(SesionActual.idUsuario)

                General.ejecutarSQL(Consultas.ANULAR_RETENCION_IVA, params)
                General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)

                txtCodigoPUC.Text = codigoPUC
                txtDescripcionPUC.Text = descripcionPUC

            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try


    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
        cargarInfoPUC(codigoPUC, descripcionPUC)
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Dim params As New List(Of String)
        params.Add(txtCodigoPUC.Text)
        params.Add(Nothing)

        General.buscarElemento(Consultas.BUSQUEDA_RETENCION_IVA,
                               params,
                               AddressOf cargarRetencionIVA,
                               TitulosForm.BUSQUEDA_RETENCION_IVA,
                               False, 0, True)


    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        General.formEditar(Me, ToolStrip1, btguardar, btcancelar)
        txtDescripcionPUC.ReadOnly = True
        txtNombreCuenta.ReadOnly = True
        btBusquedaCuenta.Enabled = False
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click

        If validarFormulario() AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            guardarRetencionIVA()
        End If
    End Sub

    Private Sub guardarRetencionIVA()
        Try
            IVARetencionBLL.guardarRetencionIVA(crearRetencionIVA, SesionActual.idUsuario)
            General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub

    Public Function crearRetencionIVA() As RetencionIVA
        Dim objRetencionIVA As New RetencionIVA

        objRetencionIVA.codigoPUC = txtCodigoPUC.Text
        objRetencionIVA.codigoCuenta = txtCodigoCuenta.Text
        objRetencionIVA.base = txtBase.Text
        objRetencionIVA.tasa = txtTasa.Text
        objRetencionIVA.observacion = txtObservacion.Text

        Return objRetencionIVA
    End Function

    Private Function validarFormulario() As Boolean

        If txtCodigoCuenta.Text = String.Empty Then
            MsgBox("Favor escoger la cuenta ", MsgBoxStyle.Exclamation)
        ElseIf txtBase.Text = String.Empty Then
            MsgBox("Favor ingresar la base", MsgBoxStyle.Exclamation)
        ElseIf txtTasa.Text = String.Empty Then
            MsgBox("Favor ingresar la tasa", MsgBoxStyle.Exclamation)
        Else
            Return True
        End If

        Return False
    End Function
End Class