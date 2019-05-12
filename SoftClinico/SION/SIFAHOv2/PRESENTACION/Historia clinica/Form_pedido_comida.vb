Imports System.Net.Mail
Imports System.Threading
Public Class Form_pedido_comida
    Shared hilo As Thread
    Shared objPedidoComida As PedidoComida
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, pbuscar_proveedor, pEspecial, codigoTercero, pTodasAreas, pAnularComida As String
#Region "Boton"
    Private Sub btOpcionEspecial_Click(sender As Object, e As EventArgs) Handles btOpcionEspecial.Click
        If btguardar.Enabled = False Then Exit Sub
        If SesionActual.tienePermiso(pEspecial) Then
            cbTipoComida.Enabled = True
            mtxtFecha.Enabled = True
            mtxtFecha.Focus()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.limpiarControles(Me)
            objPedidoComida = New PedidoComida

            If verificarHorasPedido(objPedidoComida) OrElse SesionActual.tienePermiso(pEspecial) Then
                If verificarExistenciaComida() Then
                    MsgBox("Ya la comida " & Funciones.getNombreComida(objPedidoComida.tipoComida).ToLower & " fue enviada a el proveedor !", MsgBoxStyle.Exclamation)
                    reestablecerDespuesValidacion()
                Else
                    General.formNuevo(Me, ToolStrip1, btguardar, btcancelar)
                    deshabiliarControlesInternos()
                    mtxtFecha.Value = objPedidoComida.fechaPedido
                    Dim fila As DataRow
                    Dim params As New List(Of String)
                    params.Add(SesionActual.codigoEP)
                    fila = General.cargarItem("[PROC_OBTENER_TIPO_COMIDA]", params)
                    If Not IsNothing(fila) Then
                        objPedidoComida.tipoComida = Funciones.getCodigoComida(fila.Item(0).ToString)
                    End If
                    cbTipoComida.SelectedItem = Funciones.getNombreComida(objPedidoComida.tipoComida)
                    cargarProveedor(Funciones.obtenerValorPredeterminado(Constantes.PROVEEDOR_PREDETERMINADO))
                End If
            Else
                MsgBox("No se puede enviar pedido de comida a esta hora !", MsgBoxStyle.Exclamation)
                reestablecerDespuesValidacion()
            End If
            Btbuscar_proveedores.Focus()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgvproductos.EndEdit()
        dgvproductos.DataSource.acceptChanges
        totalComidas(objPedidoComida, mostarColumna())
        If validarForm(objPedidoComida) AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            guardar(objPedidoComida)
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add(SesionActual.codigoEP)
            params.Add("")
            General.buscarElemento(Consultas.BUSCAR_PEDIDO_COMIDA,
                                   params,
                                   AddressOf cargarPedidoComida,
                                   TitulosForm.BUSQUEDA_TIPO_COMIDA,
                                   False,
                                   Constantes.TAMANO_MEDIANO,
                                   True
                                     )
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs)
        If SesionActual.tienePermiso(Peditar) Then
            btguardar.Enabled = True
            btcancelar.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub Btbuscar_proveedores_Click(sender As Object, e As EventArgs) Handles Btbuscar_proveedores.Click
        If SesionActual.tienePermiso(pbuscar_proveedor) Then
            Dim params As New List(Of String)
            params.Add("")
            General.buscarElemento(Consultas.BUSCAR_TERCERO_PEDIDO_COMIDAS,
                                   params,
                                   AddressOf cargarProveedor,
                                   TitulosForm.BUSQUEDA_TERCERO,
                                   False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Try
                    anular(objPedidoComida)
                Catch ex As Exception
                    General.manejoErrores(ex)
                End Try
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        If txtCodigo.Text <> "" Then
            imprimir(True)
        Else
            MsgBox("Antes de imprimir escoja el pedido", MsgBoxStyle.Exclamation)
        End If
    End Sub
#End Region
#Region "Metodos"
    Shared Function generarReporte(ByVal correoConfigurado As Correo) As Boolean
        Dim nombreComidareporte As String = "Comida_" & objPedidoComida.codigo & Constantes.FORMATO_PDF
        Dim reporte As New rptPedidoComidas
        Try
            Dim tbl As New Hashtable
            tbl.Add("@pCodigo", objPedidoComida.codigo)
            tbl.Add("@pIdEmpresa", SesionActual.idEmpresa)
            Return Funciones.getReporteNoFTP(reporte, Nothing, "", Constantes.FORMATO_PDF, tbl, correoConfigurado.rutaArchivo & "\" & nombreComidareporte, False)
        Catch ex As Exception
            Return False
        End Try

    End Function


    Sub imprimir(ByVal soloImprimir As Boolean)

        'Cursor = Cursors.WaitCursor
        Dim nombreComidareporte As String = "Comida_" & objPedidoComida.codigo & Constantes.FORMATO_PDF
        Dim reporte As New rptPedidoComidas
        Try
            Dim tbl As New Hashtable
            tbl.Add("@pCodigo", objPedidoComida.codigo)
            tbl.Add("@pIdEmpresa", SesionActual.idEmpresa)
            Funciones.getReporteNoFTP(reporte, Nothing, "", Constantes.FORMATO_PDF, tbl, If(soloImprimir, Nothing, crearCarpetasOrdenes(objPedidoComida.codigo) & "\" & nombreComidareporte), If(soloImprimir, True, False))
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        ' Cursor = Cursors.Default
    End Sub

    Function crearCarpetasOrdenes(ByVal CodigoComida As String) As String
        Dim ruta As String = Path.GetTempPath & "Comida" & CodigoComida
        If Directory.Exists(ruta) = False Then
            System.IO.Directory.CreateDirectory(ruta)
        End If
        Return ruta
    End Function
    Sub inicializarForm()
        objPedidoComida = New PedidoComida
        permiso_general = perG.buscarPermisoGeneral(Name, Tag.modulo)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        pbuscar_proveedor = permiso_general & "pp" & "05"
        pEspecial = permiso_general & "pp" & "06"
        pAnularComida = permiso_general & "pp" & "07"
        Dim params As New List(Of String)
        params.Add(SesionActual.idUsuario)
        params.Add(SesionActual.codigoEP)
        params.Add(Nothing)
        General.cargarCombo(Consultas.PROC_AREA_SERVICIO_EMPLEADO_LLENAR, params, "Descripción", "Código", cmbArea)
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
        cbTipoComida.SelectedIndex = 0
    End Sub
    Sub reestablecerDespuesValidacion()
        CheckForIllegalCrossThreadCalls = False
        General.posLoadForm(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub
    Public Sub cargarPedidoComida(ByVal pCodigo As Integer)
        objPedidoComida.codigo = pCodigo
        Dim params As New List(Of String)
        params.Add(objPedidoComida.codigo)
        Dim fila As DataRow
        fila = General.cargarItem(Consultas.CARGAR_PEDIDO_COMIDA_INDIVIDUAL, params)
        objPedidoComida.fechaPedido = fila.Item(1)
        objPedidoComida.areaServicio = fila.Item(2)
        objPedidoComida.codigoProveedor = fila.Item(3)
        objPedidoComida.tipoComida = fila.Item(4)
        txtCodigoProveedor.Text = fila.Item(5)
        reflejarObjeto(objPedidoComida)
        cargarProveedor(objPedidoComida.codigoProveedor)
        enlazardgv(objPedidoComida)
        General.llenarTabla(Consultas.CARGAR_PEDIDO_COMIDA_INDIVIDUAL_DETALLE, params, objPedidoComida.tblComida)
        totalComidas(objPedidoComida, mostarColumna())
        General.posBuscarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
        btEnviar.Enabled = True
        btImprimir.Enabled = True
        dgvproductos.ReadOnly = True
    End Sub
    Sub totalComidas(ByRef objPedidoComida As PedidoComida,
                     ByVal Columna As String)
        txtToltal.Text = FormatCurrency(If(IsDBNull(objPedidoComida.tblComida.Compute("Sum(" & Columna & ")", "Suspender = False")), 0, objPedidoComida.tblComida.Compute("Sum(" & Columna & ")", "Suspender = False")), 2)
    End Sub
    Function mostarColumna() As String
        Dim nombreColumnaRetornar As String = ""
        Select Case Funciones.getCodigoComida(cbTipoComida.SelectedItem)
            Case Constantes.NO_PUEDE
                nombreColumnaRetornar = ""
            Case Constantes.DESAYUNO
                dgvproductos.Columns("Desayuno").Visible = True
                dgvproductos.Columns("ValorDesayuno").Visible = True
                nombreColumnaRetornar = "ValorDesayuno"
            Case Constantes.ALMUERZO
                dgvproductos.Columns("Almuerzo").Visible = True
                dgvproductos.Columns("ValorAlmuerzo").Visible = True
                nombreColumnaRetornar = "ValorAlmuerzo"
            Case Constantes.CENA
                dgvproductos.Columns("Cena").Visible = True
                dgvproductos.Columns("ValorCena").Visible = True
                nombreColumnaRetornar = "ValorCena"
        End Select
        Return nombreColumnaRetornar
    End Function
    Sub enlazardgv(ByRef objPedidoComida As PedidoComida)
        With dgvproductos
            .Columns("nomPa").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("nomPa").DataPropertyName = "Paciente"
            .Columns("Cama").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cama").DataPropertyName = "Cama"
            .Columns("Edad").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Edad").DataPropertyName = "Edad"
            .Columns("Desayuno").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Desayuno").DataPropertyName = "Desayuno"
            .Columns("Desayuno").Visible = False
            .Columns("Almuerzo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Almuerzo").DataPropertyName = "Almuerzo"
            .Columns("Almuerzo").Visible = False
            .Columns("Cena").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Cena").DataPropertyName = "Cena"
            .Columns("Cena").Visible = False
            .Columns("ValorDesayuno").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("ValorDesayuno").DataPropertyName = "ValorDesayuno"
            .Columns("ValorDesayuno").Visible = False
            .Columns("ValorAlmuerzo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("ValorAlmuerzo").DataPropertyName = "ValorAlmuerzo"
            .Columns("ValorAlmuerzo").Visible = False
            .Columns("ValorCena").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("ValorCena").DataPropertyName = "ValorCena"
            .Columns("ValorCena").Visible = False
            .Columns("Suspender").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Suspender").DataPropertyName = "Suspender"
            .Columns("Suspender").Visible = True
            .Columns("Observacion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Observacion").DataPropertyName = "Observacion"
            .Columns("Observacion").Visible = True
            .ReadOnly = True
            .AutoGenerateColumns = False
            .DataSource = objPedidoComida.tblComida
            .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        End With
    End Sub
    Sub cargarProveedor(pCodigo As String)
        Dim fila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        fila = General.cargarItem(Consultas.CARGAR_TERCERO_PEDIDO_COMIDAS, params)
        If Not IsNothing(fila) Then
            codigoTercero = fila(0)
            txtCodigoProveedor.Text = pCodigo
            txtRazonSocial.Text = fila(1).ToString
            txtTelefono.Text = fila(2).ToString
            txtEmail.Text = fila(3).ToString
        End If
        objPedidoComida.emailProveedor = txtEmail.Text
    End Sub
    Sub deshabiliarControlesInternos()
        txtRazonSocial.ReadOnly = True
        txtTelefono.ReadOnly = True
        txtEmail.ReadOnly = True
        cbTipoComida.Enabled = False
        txtToltal.ReadOnly = True
        mtxtFecha.Enabled = False
    End Sub
    Sub guardar(ByRef objPedidoComida As PedidoComida)
        Try
            Dim pedidoComidasCMD As New PedidoComidaBLL
            establecerObjeto(objPedidoComida)
            pedidoComidasCMD.guardar(objPedidoComida, SesionActual.idUsuario)
            General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, Nothing, btanular)
            cargarPedidoComida(objPedidoComida.codigo)
            txtCodigo.Text = objPedidoComida.codigo
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Sub anular(ByRef objPedidoComida As PedidoComida)
        Try
            Dim pedidoComidasCMD As New PedidoComidaBLL
            establecerObjeto(objPedidoComida)
            pedidoComidasCMD.anular(objPedidoComida, SesionActual.idUsuario)
            General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub dgvproductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellClick
        verificarPosicion(sender, e)
    End Sub
    Private Sub dgvproductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellContentClick
        verificarPosicion(sender, e)
    End Sub
    Private Sub dgvproductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellDoubleClick

        General.abrirJustificacion(dgvproductos, objPedidoComida.tblComida, pnlObservacion, txtObservacion, "Observacion", Not btguardar.Enabled)
    End Sub
    Sub verificarPosicion(sender As Object, e As DataGridViewCellEventArgs)
        If Funciones.filaValida(e.RowIndex) AndAlso btguardar.Enabled AndAlso Funciones.validarColumnaActual(e.ColumnIndex, e.RowIndex, "Suspender", dgvproductos) Then
            dgvproductos.ReadOnly = False
            If SesionActual.tienePermiso(pAnularComida) Then
                dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
            Else
                'MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
                dgvproductos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
                dgvproductos.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
            Exit Sub
        Else
            dgvproductos.ReadOnly = True
        End If

    End Sub
    Sub llenarComidasPedidas(ByRef objPedidoComida As PedidoComida)

        Dim params As New List(Of String)
        params.Add(objPedidoComida.areaServicio)
        params.Add(objPedidoComida.fechaPedido.Date)
        params.Add(objPedidoComida.tipoComida)
        General.llenarTabla(Consultas.LLENAR_PEDIDO_COMIDAS, params, objPedidoComida.tblComida)
    End Sub
    Sub establecerObjeto(ByVal objPedidoComida As PedidoComida)
        objPedidoComida.codigo = txtCodigo.Text
        objPedidoComida.codigoProveedor = codigoTercero
        objPedidoComida.areaServicio = cmbArea.SelectedValue
        objPedidoComida.fechaPedido = mtxtFecha.Value
        objPedidoComida.tipoComida = Funciones.getCodigoComida(cbTipoComida.SelectedItem)
    End Sub
    Private Sub txtObservacion_Leave(sender As Object, e As EventArgs) Handles txtObservacion.Leave
        Try
            If pnlObservacion.Visible = True Then
                pnlObservacion.Visible = False
                dgvproductos.Rows(dgvproductos.CurrentRow.Index).Cells("Observacion").Value = txtObservacion.Text
                txtObservacion.Clear()
                objPedidoComida.tblComida.AcceptChanges()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub btEnviar_Click(sender As Object, e As EventArgs) Handles btEnviar.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim correoConfigurado As Correo
            Dim listaCorreos As New List(Of Correo)

            listaCorreos = General.cargarInformacionCorreo(Me.Tag.codigo)
            If Not IsNothing(listaCorreos) Then
                If listaCorreos.Count > 1 Then
                    pnlUsuarioPass.Visible = True
                    cmbCorreos.Items.Clear()
                    For Each correo As Correo In listaCorreos
                        cmbCorreos.Items.Add(correo.correo)
                    Next
                    cmbCorreos.Tag = listaCorreos
                    cmbCorreos.Enabled = True
                    btnEnviar.Enabled = True
                    btSalirPanel.Enabled = True
                    cmbCorreos.SelectedIndex = 0
                Else
                    correoConfigurado = New Correo
                    correoConfigurado = listaCorreos.First()
                    iniciarEnvioCorreo(correoConfigurado)
                End If
            Else
                MsgBox("Aún no tiene configurado ningún correo para este formulario!", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

        Cursor = Cursors.Default
    End Sub
    Shared Sub iniciarEnvioCorreo(ByRef pCorreo As Correo)
        If Not IsNothing(hilo) Then
            If hilo.IsAlive Then
                MsgBox("Ya esta en proceso un envio, debe esperar para volver a enviar un nuevo correo!", MsgBoxStyle.Critical)
            Else
                iniciarHilo(pCorreo)
            End If
        Else
            iniciarHilo(pCorreo)
        End If
    End Sub
    Shared Sub iniciarHilo(ByRef pCorreo As Correo)
        Try
            hilo = New System.Threading.Thread(AddressOf Form_pedido_comida.enviarCorreo)
            hilo.Start(pCorreo)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Shared Sub enviarCorreo(ByVal correoConfigurado As Correo)
        General.ConfigurarCorreo(correoConfigurado,
                                  Constantes.FORMULARIO.PEDIDO_COMIDA,
                                  "Se adjunto el pedido de comida no. " & objPedidoComida.codigo,
                                  objPedidoComida.emailProveedor)
        Try
            If generarReporte(correoConfigurado) AndAlso Funciones.enviarCorreo(correoConfigurado) Then
                MsgBox("Correo enviado !", MsgBoxStyle.Information)
            Else
                MsgBox("Correo no enviado !", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        For Each correoConfigurado As Correo In cmbCorreos.Tag
            If cmbCorreos.SelectedItem = correoConfigurado.correo Then
                pnlUsuarioPass.Visible = False
                iniciarEnvioCorreo(correoConfigurado)
            End If
        Next
    End Sub
    Private Sub btSalirPanel_Click(sender As Object, e As EventArgs) Handles btSalirPanel.Click
        pnlUsuarioPass.Visible = Not pnlUsuarioPass.Visible
    End Sub
    Private Sub bteditar_Click_1(sender As Object, e As EventArgs) Handles bteditar.Click
        If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            General.deshabilitarBotones(ToolStrip1)
            btguardar.Enabled = True
            btcancelar.Enabled = True
        End If
    End Sub
    Private Sub Form_pedido_comida_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
    Sub reflejarObjeto(ByVal objPedidoComida As PedidoComida)
        txtCodigo.Text = objPedidoComida.codigo
        codigoTercero = objPedidoComida.codigoProveedor
        cmbArea.SelectedValue = objPedidoComida.areaServicio
        mtxtFecha.Value = objPedidoComida.fechaPedido
        cbTipoComida.SelectedItem = Funciones.getNombreComida(objPedidoComida.tipoComida)
    End Sub
#End Region
#Region "Funciones"
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Function verificarExistenciaComida()
        Dim RsultadoVerificacion As Boolean = False
        objPedidoComida.areaServicio = cmbArea.SelectedValue
        objPedidoComida.fechaPedido = mtxtFecha.Value
        objPedidoComida.tipoComida = Funciones.getCodigoComida(cbTipoComida.SelectedItem)
        Try
            Dim pedidoComidasCMD As New PedidoComidaBLL
            RsultadoVerificacion = pedidoComidasCMD.verificarExixtencia(objPedidoComida)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Return RsultadoVerificacion
    End Function
    Function validarForm(ByRef objPedidoComida As PedidoComida) As Boolean
        dgvproductos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        dgvproductos.EndEdit()
        objPedidoComida.tblComida.AcceptChanges()

        If txtCodigoProveedor.Text = "" Then
            MsgBox("Debe escoger el proveedor de comidas correspondiente !", MsgBoxStyle.Exclamation)
            Return False
        ElseIf cmbArea.SelectedValue = -1 Then
            MsgBox("Debe escoger un area de servicio !", MsgBoxStyle.Exclamation)
            Return False
        ElseIf objPedidoComida.tblComida.Rows.Count = 0 Then
            MsgBox("No hay ningún paciente con orden de comida !", MsgBoxStyle.Exclamation)
            Return False
        ElseIf objPedidoComida.tblComida.Select("Suspender = True").Count = objPedidoComida.tblComida.Rows.Count Then
            MsgBox("El pedido debe tener por lo menos una comida para enviar !", MsgBoxStyle.Exclamation)
            Return False
        ElseIf objPedidoComida.tblComida.Select("Suspender = True And (Observacion ='' or Observacion is null)").Count > 0 Then
            MsgBox("Cada comida suspendida debe tener su observación !", MsgBoxStyle.Exclamation)
            Return False
        End If
        Return True
    End Function
    Function verificarHorasPedido(ByRef objPedidoComida As PedidoComida) As Boolean
        Dim fila As DataRow
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        fila = General.cargarItem(Consultas.CARGAR_TIPO_COMIDA, params)

        If fila Is Nothing Then
            Return False
        End If

        objPedidoComida.tipoComida = fila(0)
        If Funciones.getNombreComida(objPedidoComida.tipoComida) = "" Then
            Return False
        Else
            Return True
        End If
    End Function
#End Region
#Region "Otros Eventos"
    Private Sub Form_pedido_comida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarForm()
    End Sub
    Private Sub cmbArea_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbArea.SelectedValueChanged, cbTipoComida.SelectedValueChanged
        If cmbArea.SelectedIndex > 0 And txtCodigo.Text = "" And cbTipoComida.SelectedIndex > 0 Then
            If verificarExistenciaComida() Then
                MsgBox("Ya la comida " & Funciones.getNombreComida(objPedidoComida.tipoComida).ToLower & " fue enviada a el proveedor !", MsgBoxStyle.Exclamation)
                objPedidoComida.tblComida.Clear()
            Else
                enlazardgv(objPedidoComida)
                llenarComidasPedidas(objPedidoComida)
                totalComidas(objPedidoComida, mostarColumna())
            End If
        Else
            dgvproductos.Columns("Desayuno").Visible = False
            dgvproductos.Columns("ValorDesayuno").Visible = False
            dgvproductos.Columns("Almuerzo").Visible = False
            dgvproductos.Columns("ValorAlmuerzo").Visible = False
            dgvproductos.Columns("Cena").Visible = False
            dgvproductos.Columns("ValorCena").Visible = False
        End If
    End Sub




    'Private Sub dgvproductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproductos.CellDoubleClick
    '    If Funciones.filaValida(e.RowIndex) Then
    '        'If Funciones.validarCeldaActiva(dgvproductos, e, "anularQuitar", btguardar) = True Then
    '        '    Funciones.quitarFilas(objPedidoComida.tblComida, e.RowIndex)
    '        'Else
    '        If txtCodigo.Text <> "" Then
    '                If SesionActual.tienePermiso(pAnularComida) Then
    '                    If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
    '                        Try
    '                            Dim pedidoComidasCMD As New PedidoComidaBLL
    '                            establecerObjeto(objPedidoComida)
    '                            pedidoComidasCMD.anularComida(objPedidoComida, dgvproductos.CurrentRow.Index, SesionActual.idUsuario)
    '                            cargarPedidoComida(objPedidoComida.codigo)
    '                        Catch ex As Exception
    '                            general.manejoErrores(ex)
    '                        End Try
    '                    End If
    '                Else
    '                    MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
    '                End If
    '            End If
    '        End If
    'End Sub
#End Region
End Class