Public Class FormProveedorLab
    Private objProveedorLab As ProveedorLab
    Private Sub FormProveedorLab_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objProveedorLab = New ProveedorLab
        General.cargarCombo(Consultas.TIPO_CODIGO_REFERENCIA_BUSCAR, "Nombre", "Código", Combocodref)
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs)
        General.deshabilitarBotones(ToolStrip1)
        General.limpiarControles(Me)
        objProveedorLab.codigo = String.Empty
        btManuales.Enabled = True
    End Sub
    Private Sub validarBusqueda()
        btManuales.Enabled = True
        btTarifa.Enabled = True
        Combocodref.Enabled = True
    End Sub
    Private Function validarCampo() As Boolean
        Dim resultado As Boolean
        If String.IsNullOrEmpty(txtManual.Text) Then
            MsgBox("¡ Favor Seleccione un Manual !", MsgBoxStyle.Information)
        ElseIf Combocodref.SelectedIndex = 0 Then
            MsgBox("¡ Favor Seleccione un codigo referencia !", MsgBoxStyle.Information)
        ElseIf String.IsNullOrEmpty(txtTarifa.Text) Then
            MsgBox("¡ Favor Seleccione una tarifa !", MsgBoxStyle.Information)
        Else
            resultado = True
        End If
        Return resultado
    End Function
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            If validarCampo() = True Then
                If MsgBox(Mensajes.GUARDAR, 32 + 1) = 1 Then
                    objProveedorLab.codigoReferencia = Combocodref.SelectedValue
                    ProveedorLabBLL.guardarProveedorLab(objProveedorLab)
                    General.deshabilitarBotones(ToolStrip1)
                    General.deshabilitarControles(Me)
                    bteditar.Enabled = True
                    btanular.Enabled = True
                    MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            General.mensajeError(ex.Message)
        End Try
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(gpDetalle)
        validarBusqueda()
        btguardar.Enabled = True
        btcancelar.Enabled = True
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs)
        General.deshabilitarControles(Me)
        General.deshabilitarBotones(ToolStrip1)
        General.limpiarControles(Me)
        objProveedorLab.codigo = String.Empty
        bteditar.Enabled = True
    End Sub
    Private Sub cargarProveedorLab(pCodigo As Integer)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        objProveedorLab.codigo = pCodigo
        params.Add(pCodigo)
        dFila = General.cargarItem("[PROC_PROVEEDOR_LAB_CARGAR]", params)
        If Not IsNothing(dFila) Then
            txtNit.Text = dFila("Nit")
            txtnombre.Text = dFila("Proveedor")
            cargarManual(If(IsDBNull(dFila("Codigo_Tarifa")), Constantes.VALOR_PREDETERMINADO, dFila("Codigo_Tarifa")))
            Combocodref.SelectedValue = If(IsDBNull(dFila("Codigo_Referencia")), Constantes.VALOR_PREDETERMINADO, dFila("Codigo_Referencia"))
            cargarTarifa(If(IsDBNull(dFila("Codigo_HAL")), Constantes.VALOR_PREDETERMINADO, dFila("Codigo_HAL")))
            General.posBuscarForm(Me, ToolStrip1, bteditar, bteditar, bteditar, btanular)
        Else
            General.posLoadForm(Me, ToolStrip1, bteditar, bteditar)
        End If
    End Sub
    Public Sub setTipoLista(ByVal pTipolista As Integer, ByVal pIdTercero As Integer, ByVal pNit As String, ByVal pNombreTercero As String)
        objProveedorLab.codigo = pIdTercero
        txtNit.Text = pNit
        txtnombre.Text = pNombreTercero
        cargarProveedorLab(pIdTercero)
    End Sub
    Private Sub btbuscarproveedor_Click(sender As Object, e As EventArgs) Handles btManuales.Click
        General.buscarElemento(Consultas.MANUAL_BUSCAR,
                               Nothing,
                               AddressOf cargarManual,
                               TitulosForm.BUSQUEDA_MANUAL,
                               True, 0, True)
    End Sub
    Private Sub cargarManual(pCodigo)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(pCodigo)
        objProveedorLab.codigoManual = pCodigo
        dFila = General.cargarItem("PROC_MANUAL_CARGAR", params)
        txtManual.Text = dFila(0)
    End Sub
    Private Sub btTarifa_Click(sender As Object, e As EventArgs) Handles btTarifa.Click
        Dim params As New List(Of String)
        params.Add(Combocodref.SelectedValue)
        General.buscarElemento(Consultas.TARIFA_SERVICIO_BUSCAR,
                               params,
                               AddressOf cargarTarifa,
                               TitulosForm.BUSQUEDA_TARIFAS,
                               True, 0, True)
    End Sub
    Private Sub cargarTarifa(pCodigo)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(pCodigo)
        objProveedorLab.codigoTarifa = pCodigo
        dFila = General.cargarItem("[PROC_TARIFA_SERVICIO_CARGAR]", params)
        txtTarifa.Text = dFila("Nombre")
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Try
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim params As New List(Of String)
                params.Add(objProveedorLab.codigo)
                params.Add(SesionActual.idUsuario)
                params.Add(SesionActual.idEmpresa)
                General.ejecutarSQL("[PROC_PROVEEDOR_LAB_ANULAR]", params)
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                General.limpiarControles(Me)
                btanular.Enabled = False
                btcancelar.Enabled = False
                bteditar.Enabled = False
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
End Class