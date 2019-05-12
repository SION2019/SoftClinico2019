Imports System.Threading
Public Class FormGenerarFacturaCapitado
    Private objFactura As New FacturaAtencionCapitada
    Dim perG As New Buscar_Permisos_generales
    Dim permisoGeneral As String
    Dim pEditar As String
    Dim pAnular As String
    Dim pNuevo As String
    Dim pBuscar As String
    Dim pImprimir As String
    Dim pExonerar As String
    Dim pReporte As String
    Dim usuarioActual As String
    Dim moduloTemporal As String
    Dim codigoTemporal As String
    Dim valorLetraTemporal As String

    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form__FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub btBuscarContrato_Click(sender As Object, e As EventArgs) Handles btBuscarContrato.Click
        Try
            buscaContrato()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub buscaContrato()
        Dim params As New List(Of String)
        params.Add(Nothing)
        params.Add(SesionActual.codigoEP)
        General.buscarElemento(objFactura.sqlBuscarContrato,
                           params,
                           AddressOf cargarContrato,
                           TitulosForm.BUSQUEDA_CLIENTES,
                           False, Constantes.TAMANO_MEDIANO, True)
    End Sub

    Public Sub cargarContrato(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        Dim dt As New DataTable
        General.llenarTabla(objFactura.sqlCargarContrato, params, dt)
        If dt.Rows.Count > 0 Then
            textcodcontrato.Text = dt.Rows(0).Item("Contrato")
            objFactura.CodigoContrato = dt.Rows(0).Item("Contrato")
            textcodcliente.Text = dt.Rows(0).Item("NIT").ToString
            textdv.Text = dt.Rows(0).Item("DV")
            textcliente.Text = dt.Rows(0).Item("Cliente")

            texttarifa.Text = "P: " & dt.Rows(0).Item("Tarifa Procedimientos")
            texttarifa.Text = texttarifa.Text & "   L: " & dt.Rows(0).Item("Tarifa Laboratorio")
            texttarifa.Text = texttarifa.Text & "   I: " & dt.Rows(0).Item("Tarifa Imagenología")
            textlistamed.Text = dt.Rows(0).Item("Lista Precio Medicamento")

            If String.IsNullOrEmpty(objFactura.codigoFactura) Then
                iniciarForm()
                objFactura.fechaFactura = txtfechaFactura.Value
                objFactura.calcularFechas()
                txtFechaVence.Value = objFactura.fechaVencimiento
            End If
        End If
    End Sub

    Private Sub iniciarForm()
        btResumen.Enabled = True
        General.limpiarControles(gbAtencionCapita)
        General.limpiarControles(gbInformacionFactura)
        General.limpiarControles(gbDetalleServicios)
        datePeriodoCapitado.Enabled = True
        numValorFactura.Enabled = True
        txtObservacion.ReadOnly = False
        numValorFactura.ReadOnly = False

    End Sub

    Private Sub FormGenerarFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        General.limpiarControles(Me)
        cargarPermisos()
        Label1.Text = Label1.Text & " CAPITA"
        General.deshabilitarControles(Me)
        If Not SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) OrElse (Tag.codigo <> ConstantesAsis.CODIGO_MENU_FACTURA_ASISTENCIAL AndAlso Tag.codigo <> ConstantesAsis.CODIGO_MENU_FACTURA_EXTERNA) Then
            tssEditar.Visible = False
            bteditar.Visible = False
        End If
    End Sub


    Private Sub cargarPermisos()
        permisoGeneral = perG.buscarPermisoGeneral(Name, Tag.modulo)
        pNuevo = permisoGeneral & "pp" & "01"
        pEditar = permisoGeneral & "pp" & "02"
        pAnular = permisoGeneral & "pp" & "03"
        pBuscar = permisoGeneral & "pp" & "04"
        pReporte = permisoGeneral & "pp" & "05"
        pImprimir = permisoGeneral & "pp" & "06"
        pExonerar = permisoGeneral & "pp" & "07"
    End Sub

    Private Sub enlazarDgvExterna()

        dgvConsolidado.DataSource = objFactura.dtConsolidado
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(pBuscar) Then
            Dim tbl As DataRow = Nothing
            Dim params As New List(Of String)
            Dim tamanoBusqueda As Integer
            params.Add(Nothing)
            params.Add(SesionActual.codigoEP)
            tamanoBusqueda = Constantes.TAMANO_MEDIANO
            Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(objFactura.sqlBuscarFactura,
                                                                              params, TitulosForm.BUSQUEDA_FACTURAS, False, tamanoBusqueda, True)
            tbl = formBusqueda.rowResultados
            If tbl IsNot Nothing Then

                cargarFactura(tbl(0))
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub
    Private Sub cargarFactura(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(SesionActual.idEmpresa)
        Dim dt As New DataTable
        General.llenarTabla(objFactura.sqlCargarFactura, params, dt)
        If dt.Rows.Count > 0 Then
            objFactura.codigoFactura = pCodigo
            textcodfactura.Text = objFactura.codigoFactura
            objFactura.fechaInicio = dt.Rows(0).Item("pERIODO")
            objFactura.observacion = dt.Rows(0).Item("OBSERVACION")
            objFactura.fechaFactura = dt.Rows(0).Item("Fecha_Factura")
            objFactura.fechaVencimiento = dt.Rows(0).Item("Fecha_Vence")
            objFactura.totalFactura = dt.Rows(0).Item("Total_Factura")
            objFactura.CodigoContrato = dt.Rows(0).Item("Codigo_Contrato")
            datePeriodoCapitado.Value = objFactura.fechaInicio
            txtObservacion.Text = objFactura.observacion
            txtfechaFactura.Value = objFactura.fechaFactura
            txtFechaVence.Value = objFactura.fechaVencimiento
            numValorFactura.Value = CDbl(objFactura.totalFactura)
            cargarContrato(objFactura.CodigoContrato)
            cargarPendientes()
            General.habilitarBotones(ToolStrip1)
            btcancelar.Enabled = False
            btguardar.Enabled = False
        End If
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            If validar() Then
                guardarFactura()
            End If
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub


    Private Sub guardarFactura()

        objFactura.observacion = txtObservacion.Text
        objFactura.usuario = SesionActual.idUsuario
        objFactura.totalFactura = numValorFactura.Value
        objFactura.guardarFactura()
        textcodfactura.Text = objFactura.codigoFactura
        General.deshabilitarControles(Me)
        General.habilitarBotones(ToolStrip1)
        btguardar.Enabled = False
        btcancelar.Enabled = False

        MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
    End Sub

    Private Function validar() As Boolean
        Dim mensaje As String
        mensaje = objFactura.verificarClausulas()

        If Not String.IsNullOrEmpty(mensaje) Then
            mensaje = mensaje
            MsgBox(mensaje, MsgBoxStyle.Exclamation)
            If objFactura.tipo <> 2 Then
                btguardar.Enabled = False
            End If
            Return False
        End If
        If String.IsNullOrEmpty(txtObservacion.Text) Then
            mensaje = "Por favor digite la observación de la factura!"
            MsgBox(mensaje, MsgBoxStyle.Exclamation)
            txtObservacion.Focus()
            Return False
        End If
        objFactura.totalFactura = numValorFactura.Value
        If objFactura.totalFactura = 0 Then
            mensaje = "Factura en 0."
            MsgBox(mensaje, MsgBoxStyle.Exclamation)
            Return False
        End If
        Return True

    End Function


    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(pAnular) Then
            General.limpiarControles(gbAtencionCapita)
            General.limpiarControles(gbInformacionFactura)
            General.limpiarControles(gbDetalleServicios)
            General.deshabilitarBotones(ToolStrip1)
            btBuscarContrato.Enabled = True
            btcancelar.Enabled = True
            btnuevo.Enabled = False
            mensajeAyuda.RemoveAll()
            objFactura.codigoFactura = ""

        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar) Then
            mensajeAyuda.RemoveAll()
            objFactura.codigoFactura = ""
        End If
    End Sub


    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(pAnular) Then
            Try
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    objFactura.usuario = SesionActual.idUsuario
                    objFactura.anularFactura()
                    objFactura.codigoFactura = ""
                    General.limpiarControles(Me)
                    General.deshabilitarBotones(ToolStrip1)
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                End If
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(pEditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                editarFacturaAsistencial()
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub editarFacturaAsistencial()
        General.deshabilitarBotones(ToolStrip1)
        btguardar.Enabled = True
        btcancelar.Enabled = True
    End Sub


    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try

            objFactura.imprimirFactura()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub dgv_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivoNo0
    End Sub

    Private Sub dgvParaclinicos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
        MsgBox(Mensajes.CANTIDAD_VALIDA, MsgBoxStyle.Exclamation)
    End Sub

    Private Sub cargarPendientes()
        objFactura.cargarPendientes()
        dgvConsolidado.DataSource = objFactura.dtConsolidado
        If String.IsNullOrEmpty(textcodfactura.Text) Then btguardar.Enabled = True
    End Sub
    Private Sub btAtenciones(sender As Object, e As EventArgs) Handles btResumen.Click
        If String.IsNullOrEmpty(textcodcontrato.Text) Then
            Exit Sub
        End If

        Dim dtFacturas As New DataTable
        Dim params As New List(Of String)
        Dim periodo As String
        periodo = datePeriodoCapitado.Value.Year & "-" & datePeriodoCapitado.Value.Month & "-01"
        objFactura.fechaInicio = CDate(periodo).Date
        params.Add(Format(objFactura.fechaInicio, Constantes.FORMATO_FECHA_ACTUAL))
        params.Add(objFactura.CodigoContrato)
        General.llenarTabla(objFactura.periodoVerificar, params, dtFacturas)
        Dim facturas As String
        If dtFacturas.Rows.Count > 0 Then
            For i = 0 To dtFacturas.Rows.Count - 1
                facturas += vbCrLf & vbCrLf & "Factura: " & dtFacturas.Rows(i).Item("Codigo_Factura")
            Next
            MsgBox("¡Periodo inválido!" & facturas, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Try
            cargarPendientes()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub



    Private Sub datePeriodoCapitado_ValueChanged(sender As Object, e As EventArgs) Handles datePeriodoCapitado.ValueChanged
        If btcancelar.Enabled = True Then
            General.limpiarControles(gbDetalleServicios)
            mensajeAyuda.RemoveAll()
            objFactura.codigoFactura = ""
        End If

    End Sub

    Private Sub btSoportes_Click(sender As Object, e As EventArgs) Handles btSoportes.Click
        Cursor = Cursors.WaitCursor
        btSoportes.Enabled = False
        'Try
        '    objFactura.imprimirSoporte()
        'Catch ex As Exception
        '    General.manejoErrores(ex)
        'End Try
        btSoportes.Enabled = True
        Cursor = Cursors.Default
    End Sub
    Private Function generardtConsolidado() As SoporteExterno
        Dim facturacion As New SoporteExterno
        For i = 0 To objFactura.dtConsolidado.Rows.Count - 1

        Next

        Return facturacion
    End Function
End Class