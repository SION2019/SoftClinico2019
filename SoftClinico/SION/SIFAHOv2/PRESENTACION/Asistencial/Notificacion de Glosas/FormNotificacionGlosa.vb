Public Class FormNotificacionGlosa
    Dim dtGlosas As New DataTable
    Dim idTercero As Integer
    Dim valorColumna As Integer
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, PGeneral, PDetallado, PNotaCredito As String
    Dim reporte As New ftp_reportes
    Public Property objDetalleGlosa As DetalleGlosa
    Private Sub FormNotificacionGlosa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        PGeneral = permiso_general & "pp" & "05"
        PDetallado = permiso_general & "pp" & "06"
        PNotaCredito = permiso_general & "pp" & "07"
        enlanzarTabla()
        ocultarColumnas()
        btOpcionDetallado.Enabled = True
        btOpcionGeneral.Enabled = True
        OpcionBtSemaforo.Enabled = True
        btnActa.Image = My.Resources.borrartxt
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub enlanzarTabla()

        Dim est0, est1, est2, est3, est4, est5, est6, est7, est8, est9, est10, est11, est12, est13,
            est14, est15, est16, est17, est18, est19, est20, est21, est22, est23, est24, est25, est26, est27,
            est28, est29, est30, est31, est32, est33, est34, est35 As New DataColumn


        est1.ColumnName = "Codigo_factura"
        est1.DataType = Type.GetType("System.String")
        est1.DefaultValue = String.Empty
        dtGlosas.Columns.Add(est1)

        est2.ColumnName = "Fecha_Factura"
        est2.DataType = Type.GetType("System.DateTime")
        dtGlosas.Columns.Add(est2)

        est3.ColumnName = "documento_paciente"
        est3.DataType = Type.GetType("System.String")
        est3.DefaultValue = String.Empty
        dtGlosas.Columns.Add(est3)

        est4.ColumnName = "Paciente"
        est4.DataType = Type.GetType("System.String")
        est4.DefaultValue = String.Empty
        dtGlosas.Columns.Add(est4)

        est0.ColumnName = "Fecha_Egreso"
        est0.DataType = Type.GetType("System.DateTime")
        dtGlosas.Columns.Add(est0)

        est6.ColumnName = "Total_Factura"
        est6.DataType = Type.GetType("System.Decimal")
        est6.DefaultValue = 0
        dtGlosas.Columns.Add(est6)

        est7.ColumnName = "Fecha_Radicado"
        est7.DataType = Type.GetType("System.DateTime")
        dtGlosas.Columns.Add(est7)

        est8.ColumnName = "Fecha_Limite_Recepcion"
        est8.DataType = Type.GetType("System.DateTime")
        est8.DefaultValue = Date.Today
        dtGlosas.Columns.Add(est8)

        est9.ColumnName = "Fecha_Notificacion_Glosa"
        est9.DataType = Type.GetType("System.DateTime")
        est9.DefaultValue = Date.Today
        dtGlosas.Columns.Add(est9)

        est10.ColumnName = "Notificacion_Extemporanea"
        est10.DataType = Type.GetType("System.Boolean")
        est10.DefaultValue = False
        dtGlosas.Columns.Add(est10)

        est11.ColumnName = "Valor_Glosa"
        est11.DataType = Type.GetType("System.Decimal")
        est11.DefaultValue = 0
        dtGlosas.Columns.Add(est11)

        est12.ColumnName = "Glosa_Por_Facuracion"
        est12.DataType = Type.GetType("System.Decimal")
        est12.DefaultValue = 0
        dtGlosas.Columns.Add(est12)

        est13.ColumnName = "Glosa_Por_Tarifa"
        est13.DataType = Type.GetType("System.Decimal")
        est13.DefaultValue = 0
        dtGlosas.Columns.Add(est13)

        est14.ColumnName = "Glosa_Por_Soporte"
        est14.DataType = Type.GetType("System.Decimal")
        est14.DefaultValue = 0
        dtGlosas.Columns.Add(est14)

        est15.ColumnName = "Glosa_Por_Autorizacion"
        est15.DataType = Type.GetType("System.Decimal")
        est15.DefaultValue = 0
        dtGlosas.Columns.Add(est15)

        est16.ColumnName = "Glosa_Por_Cobertura"
        est16.DataType = Type.GetType("System.Decimal")
        est16.DefaultValue = 0
        dtGlosas.Columns.Add(est16)

        est17.ColumnName = "Glosa_Por_Pertinencia"
        est17.DataType = Type.GetType("System.Decimal")
        est17.DefaultValue = 0
        dtGlosas.Columns.Add(est17)

        est18.ColumnName = "Devolucion"
        est18.DataType = Type.GetType("System.Decimal")
        est18.DefaultValue = 0
        dtGlosas.Columns.Add(est18)

        est19.ColumnName = "Valor_Glosa_Aceptada"
        est19.DataType = Type.GetType("System.Decimal")
        est19.DefaultValue = 0
        dtGlosas.Columns.Add(est19)

        est20.ColumnName = "Limite_Respuesta_Glosa"
        est20.DataType = Type.GetType("System.DateTime")
        est20.DefaultValue = Date.Today
        dtGlosas.Columns.Add(est20)

        est21.ColumnName = "Fecha_Respuesta_Glosa"
        est21.DataType = Type.GetType("System.DateTime")
        est21.DefaultValue = Date.Today
        dtGlosas.Columns.Add(est21)

        est22.ColumnName = "Respondida"
        est22.DataType = Type.GetType("System.Boolean")
        est22.DefaultValue = False
        dtGlosas.Columns.Add(est22)

        est23.ColumnName = "Glosa_Ratificada"
        est23.DataType = Type.GetType("System.Decimal")
        est23.DefaultValue = 0
        dtGlosas.Columns.Add(est23)

        est24.ColumnName = "Fecha_Conciliacion"
        est24.DataType = Type.GetType("System.DateTime")
        est24.DefaultValue = Date.Today
        dtGlosas.Columns.Add(est24)

        est25.ColumnName = "Valor_IPS_Aceptada"
        est25.DataType = Type.GetType("System.Decimal")
        est25.DefaultValue = 0
        dtGlosas.Columns.Add(est25)

        est26.ColumnName = "Valor_EPS_Aceptada"
        est26.DataType = Type.GetType("System.Decimal")
        est26.DefaultValue = 0
        dtGlosas.Columns.Add(est26)

        est27.ColumnName = "Valor_a_Pagar"
        est27.DataType = Type.GetType("System.Decimal")
        est27.DefaultValue = 0
        dtGlosas.Columns.Add(est27)

        est28.ColumnName = "Glosa1"
        est28.DataType = Type.GetType("System.Decimal")
        est28.DefaultValue = 0
        dtGlosas.Columns.Add(est28)

        est29.ColumnName = "Glosa2"
        est29.DataType = Type.GetType("System.Decimal")
        est29.DefaultValue = 0
        dtGlosas.Columns.Add(est29)

        est30.ColumnName = "Glosa3"
        est30.DataType = Type.GetType("System.Decimal")
        est30.DefaultValue = 0
        dtGlosas.Columns.Add(est30)

        est31.ColumnName = "Glosa4"
        est31.DataType = Type.GetType("System.Decimal")
        est31.DefaultValue = 0
        dtGlosas.Columns.Add(est31)

        est32.ColumnName = "Glosa5"
        est32.DataType = Type.GetType("System.Decimal")
        est32.DefaultValue = 0
        dtGlosas.Columns.Add(est32)

        est33.ColumnName = "Glosa6"
        est33.DataType = Type.GetType("System.Decimal")
        est33.DefaultValue = 0
        dtGlosas.Columns.Add(est33)

        est34.ColumnName = "Glosa8"
        est34.DataType = Type.GetType("System.Decimal")
        est34.DefaultValue = 0
        dtGlosas.Columns.Add(est34)

        est35.ColumnName = "Terminada"
        est35.DefaultValue = False
        dtGlosas.Columns.Add(est35)

        With dgvGlosas
            .Columns.Item("dgfactura").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgfactura").DataPropertyName = "Codigo_factura"

            .Columns.Item("dgfechafactura").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgfechafactura").DataPropertyName = "Fecha_Factura"

            .Columns.Item("dgidentificacion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgidentificacion").DataPropertyName = "documento_paciente"

            .Columns.Item("dgpaciente").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgpaciente").DataPropertyName = "Paciente"

            .Columns.Item("dgfechaegreso").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgfechaegreso").DataPropertyName = "Fecha_Egreso"

            .Columns.Item("dgvalorfactura").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgvalorfactura").DataPropertyName = "Total_Factura"

            .Columns.Item("dgfecharadicacion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgfecharadicacion").DataPropertyName = "Fecha_Radicado"

            .Columns.Item("dgfechalimite").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgfechalimite").DataPropertyName = "Fecha_Limite_Recepcion"

            .Columns.Item("dgfechanotificarglosa").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgfechanotificarglosa").DataPropertyName = "Fecha_Notificacion_Glosa"

            .Columns.Item("dgnotificacionextemporanea").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgnotificacionextemporanea").DataPropertyName = "Notificacion_Extemporanea"

            .Columns.Item("dgvalorglosa").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgvalorglosa").DataPropertyName = "Valor_Glosa"

            .Columns.Item("dgfacturacion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgfacturacion").DataPropertyName = "Glosa_Por_Facuracion"

            .Columns.Item("dgtarifa").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgtarifa").DataPropertyName = "Glosa_Por_Tarifa"

            .Columns.Item("dgsoporte").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgsoporte").DataPropertyName = "Glosa_Por_Soporte"

            .Columns.Item("dgautorizacion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgautorizacion").DataPropertyName = "Glosa_Por_Autorizacion"

            .Columns.Item("dgcobertura").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgcobertura").DataPropertyName = "Glosa_Por_Cobertura"

            .Columns.Item("dgpertinencia").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgpertinencia").DataPropertyName = "Glosa_Por_Pertinencia"

            .Columns.Item("dgdevolucion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgdevolucion").DataPropertyName = "Devolucion"

            .Columns.Item("dgvalorglosaaceptada").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgvalorglosaaceptada").DataPropertyName = "Valor_Glosa_Aceptada"

            .Columns.Item("dgfecharespuesta").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgfecharespuesta").DataPropertyName = "Fecha_Respuesta_Glosa"

            .Columns.Item("dgfechalrespuesta").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgfechalrespuesta").DataPropertyName = "Limite_Respuesta_Glosa"

            .Columns.Item("dgrespondida").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgrespondida").DataPropertyName = "Respondida"
            .Columns.Item("dgrespondida").ReadOnly = True

            .Columns.Item("dgratificada").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgratificada").DataPropertyName = "Glosa_Ratificada"

            .Columns.Item("dgfechaconciliacion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgfechaconciliacion").DataPropertyName = "Fecha_Conciliacion"

            .Columns.Item("dgvalorips").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgvalorips").DataPropertyName = "Valor_IPS_Aceptada"

            .Columns.Item("dgvaloreps").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgvaloreps").DataPropertyName = "Valor_EPS_Aceptada"
            .Columns.Item("dgvaloreps").ReadOnly = True

            .Columns.Item("dgvalorapagar").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgvalorapagar").DataPropertyName = "Valor_a_Pagar"

            .Columns.Item("dgglosaaceptada1").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgglosaaceptada1").DataPropertyName = "Glosa1"

            .Columns.Item("dgglosaaceptada2").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgglosaaceptada2").DataPropertyName = "Glosa2"

            .Columns.Item("dgglosaaceptada3").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgglosaaceptada3").DataPropertyName = "Glosa3"

            .Columns.Item("dgglosaaceptada4").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgglosaaceptada4").DataPropertyName = "Glosa4"

            .Columns.Item("dgglosaaceptada5").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgglosaaceptada5").DataPropertyName = "Glosa5"

            .Columns.Item("dgglosaaceptada6").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgglosaaceptada6").DataPropertyName = "Glosa6"

            .Columns.Item("dgglosaaceptada8").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgglosaaceptada8").DataPropertyName = "Glosa8"

            .Columns.Item("dgselect").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgselect").DataPropertyName = "Terminada"

        End With
        dgvGlosas.AutoGenerateColumns = False
        dgvGlosas.DataSource = dtGlosas
        dgvGlosas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGlosas.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        dgvGlosas.ReadOnly = True
    End Sub
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
    Private Sub btbuscareps_Click(sender As Object, e As EventArgs) Handles btbuscareps.Click
        Dim params As New List(Of String)
        params.Add("")
        params.Add(SesionActual.idEmpresa)
        General.buscarElemento(Consultas.NOTIFICACION_GLOSA_BUSCAR_CLIENTES,
                              params,
                              AddressOf cargarTercero,
                              TitulosForm.BUSQUEDA_TERCERO,
                              True, Constantes.TAMANO_MEDIANO, True)

    End Sub
    Public Sub cargarTercero(pCodigo)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        idTercero = pCodigo
        General.llenarTabla(Consultas.CONTA_CLIENTE_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            textcodeps.Text = dt.Rows(0).Item("Nit").ToString()
            Textnombreeps.Text = dt.Rows(0).Item("CLIENTE").ToString()
            dtGlosas.Clear()
            dtGlosas.Rows.Add()
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
        OpcionBtSemaforo.Enabled = True
        btVisualizaPDF.Enabled = True
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If General.fnFormEditar(Me, ToolStrip1, btguardar, btcancelar) Then
                dtGlosas.Rows.Add()
                habilitarGrilla()
                btnActa.Enabled = False
            End If
        Else
        MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim params As New List(Of String)
                params.Add(txtcodigo.Text)
                params.Add(SesionActual.idUsuario)
                General.ejecutarSQL(Consultas.NOTIFICACION_GLOSA_ANULAR, params)
                General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
            End If
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            Dim params As New List(Of String)
            params.Add("")
            params.Add(SesionActual.codigoEP)
            General.buscarElemento(Consultas.NOTIFICACION_GLOSA_BUSCAR,
                                   params,
                                   AddressOf cargarDatos,
                                   TitulosForm.BUSQUEDA_GLOSAS,
                                   False, Constantes.TAMANO_MEDIANO, True)
        Else
        MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub
    Private Sub cargarDatos(pCodigo As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.NOTIFICACION_GLOSA_FACTURA_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            idTercero = dt.Rows(0).Item("Id_cliente").ToString()
            Textnombreeps.Text = dt.Rows(0).Item("EPS").ToString()
            textcodeps.Text = dt.Rows(0).Item("Nit").ToString()
            llenarDetalleGlosa(pCodigo)
            verificarActa(txtcodigo.Text, textcodeps.Text)
            General.habilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            btguardar.Enabled = False
            btcancelar.Enabled = False
            btnActa.Enabled = True
            btOpcionDetallado.Enabled = True
            btOpcionGeneral.Enabled = True
            OpcionBtSemaforo.Enabled = True
        End If
    End Sub

    Private Sub llenarDetalleGlosa(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        txtcodigo.Text = pCodigo
        General.llenarTabla(Consultas.NOTIFICACION_GLOSA_DETALLE_CARGAR, params, dtGlosas)
        dgvGlosas.DataSource = dtGlosas
        dgvGlosas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGlosas.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        mostrarColumnas()
        dgvalorglosa.ReadOnly = True
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            General.limpiarControles(Me)
            General.deshabilitarBotones(ToolStrip1)
            General.habilitarControles(Me)
            ocultarColumnas()
            dtGlosas.Rows.Add()
            txtcodigo.ReadOnly = True
            Textnombreeps.ReadOnly = True
            textcodeps.ReadOnly = True
            btguardar.Enabled = True
            btcancelar.Enabled = True
            btbuscareps.Focus()
            habilitarGrilla()
            btnActa.Enabled = False
        Else
        MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Function validarInformacion() As Boolean
        dgvGlosas.EndEdit()
        dtGlosas.AcceptChanges()
        If Textnombreeps.Text = "" Then
            MsgBox("¿Debe escoger una EPS?", MsgBoxStyle.Exclamation)
            Return False
        End If
        Return True
    End Function
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarInformacion() Then
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                guardarGlosa()
            End If
        End If
    End Sub
    Public Sub guardarDesdeGlosaDetalle()
        dgvGlosas.EndEdit()
        dtGlosas.AcceptChanges()
        Dim objNotificacionGlosaBll As New NotificacionGlosaBLL
        Try
            txtcodigo.Text = objNotificacionGlosaBll.guardarNotificacionGlosa(crearNotificacionGlosa())
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Public Sub guardarGlosa()
        dgvGlosas.EndEdit()
        dtGlosas.AcceptChanges()
        Dim objNotificacionGlosaBll As New NotificacionGlosaBLL
        Try
            If txtcodigo.Text <> String.Empty Then
                General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                btimprimir.Enabled = True
            End If
            txtcodigo.Text = objNotificacionGlosaBll.guardarNotificacionGlosa(crearNotificacionGlosa())
            cargarDatos(txtcodigo.Text)
            mostrarColumnas()
            habilitarGrilla()
            OpcionBtSemaforo.Enabled = True
            btVisualizaPDF.Enabled = True
            btnActa.Enabled = True
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Public Sub verificarActa(pCodigo, nitCliente)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(nitCliente)
        General.llenarTabla(Consultas.ACTA_GLOSA_BUSCAR, params, dt)
        If dt.Rows.Count > 0 Then
            btnActa.Image = My.Resources.Adobe_PDF_Document_icon
        Else
            btnActa.Image = My.Resources.borrartxt
        End If
    End Sub

    Public Function crearNotificacionGlosa() As NotificacionGlosa
        Dim objNotificacionGlosa As New NotificacionGlosa
        objNotificacionGlosa.identificador = txtcodigo.Text
        dgvGlosas.EndEdit()
        dtGlosas.AcceptChanges()

        For Each drFila As DataRow In dtGlosas.Rows
            If drFila.Item("Codigo_factura").ToString <> "" Then
                Dim drCuenta As DataRow = objNotificacionGlosa.dtGlosa.NewRow
                drCuenta.Item("Codigo_Glosa") = txtcodigo.Text
                drCuenta.Item("Id_Empresa") = SesionActual.idEmpresa
                drCuenta.Item("Codigo_factura") = drFila.Item("Codigo_factura")
                drCuenta.Item("Fecha_Limite_Recepcion") = drFila.Item("Fecha_Limite_Recepcion")
                drCuenta.Item("Fecha_Notificacion_Glosa") = drFila.Item("Fecha_Notificacion_Glosa")
                drCuenta.Item("Notificacion_Extemporanea") = drFila.Item("Notificacion_Extemporanea")
                drCuenta.Item("Valor_Glosa") = drFila.Item("Valor_Glosa")
                drCuenta.Item("Glosa_Facuracion") = drFila.Item("Glosa_Por_Facuracion")
                drCuenta.Item("Glosa_Tarifa") = drFila.Item("Glosa_Por_Tarifa")
                drCuenta.Item("Glosa_Soporte") = drFila.Item("Glosa_Por_Soporte")
                drCuenta.Item("Glosa_Autorizacion") = drFila.Item("Glosa_Por_Autorizacion")
                drCuenta.Item("Glosa_Cobertura") = drFila.Item("Glosa_Por_Cobertura")
                drCuenta.Item("Glosa_Pertinencia") = drFila.Item("Glosa_Por_Pertinencia")
                drCuenta.Item("Devolucion") = drFila.Item("Devolucion")
                drCuenta.Item("Valor_Glosa_Aceptada") = drFila.Item("Valor_Glosa_Aceptada")
                drCuenta.Item("Fecha_LRespuesta_Glosa") = drFila.Item("Limite_Respuesta_Glosa")
                drCuenta.Item("Fecha_Respuesta_Glosa") = drFila.Item("Fecha_Respuesta_Glosa")
                drCuenta.Item("Respondida") = drFila.Item("Respondida")
                drCuenta.Item("Glosa_Ratificada") = drFila.Item("Glosa_Ratificada")
                drCuenta.Item("Fecha_Conciliacion") = drFila.Item("Fecha_Conciliacion")
                drCuenta.Item("Valor_IPS_Aceptada") = drFila.Item("Valor_IPS_Aceptada")
                drCuenta.Item("Valor_EPS_Aceptada") = drFila.Item("Valor_EPS_Aceptada")
                drCuenta.Item("Valor_a_Pagar") = drFila.Item("Valor_a_Pagar")
                drCuenta.Item("Glosa1") = drFila.Item("Glosa1")
                drCuenta.Item("Glosa2") = drFila.Item("Glosa2")
                drCuenta.Item("Glosa3") = drFila.Item("Glosa3")
                drCuenta.Item("Glosa4") = drFila.Item("Glosa4")
                drCuenta.Item("Glosa5") = drFila.Item("Glosa5")
                drCuenta.Item("Glosa6") = drFila.Item("Glosa6")
                drCuenta.Item("Glosa8") = drFila.Item("Glosa8")
                drCuenta.Item("Terminada") = drFila.Item("Terminada")
                drCuenta.Item("usuario") = SesionActual.idUsuario
                objNotificacionGlosa.dtGlosa.Rows.Add(drCuenta)

            End If
        Next
        Return objNotificacionGlosa
    End Function
    Private Sub abrirFormDetalleGlosa()
        Dim registroNuevo
        If dgvGlosas.Rows(dgvGlosas.CurrentRow.Index).Cells(valorColumna).Value = 0 Then
            registroNuevo = True
        Else
            registroNuevo = False
        End If

        FormGlosaDetalle.llenarCodificacionGeneral(asignarValorColumnaDgv(valorColumna))
        FormGlosaDetalle.MdiParent = FormPrincipal
        FormGlosaDetalle.objFormNotificacion = Me
        FormGlosaDetalle.formulario = 0
        FormGlosaDetalle.Show()
        FormGlosaDetalle.llenarDvgGlosas(txtcodigo.Text, dgvGlosas.Rows(dgvGlosas.CurrentRow.Index).Cells(0).Value, dgvGlosas.Rows(dgvGlosas.CurrentRow.Index).Cells(3).Value, registroNuevo)
    End Sub
    Public Function asignarValorColumnaDgv(columna As Integer)

        Dim htGlosasCol As New Hashtable

        htGlosasCol.Add(11, 1)
        htGlosasCol.Add(12, 2)
        htGlosasCol.Add(13, 3)
        htGlosasCol.Add(14, 4)
        htGlosasCol.Add(15, 5)
        htGlosasCol.Add(16, 6)
        htGlosasCol.Add(17, 8)

        Return htGlosasCol.Item(columna)

    End Function
    Private Sub dgvGlosas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGlosas.CellDoubleClick
        valorColumna = e.ColumnIndex
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        params.Add(idTercero)

        If btguardar.Enabled = False Then
            Exit Sub
        End If
        If textcodeps.Text = String.Empty Then
            MsgBox("Debe escoger una EPS")
            btbuscareps.Focus()
        Else
            Try
                If valorColumna > 10 And valorColumna < 18 Then
                    abrirFormDetalleGlosa()
                End If

                If (dgvGlosas.Rows(dgvGlosas.CurrentCell.RowIndex).Cells("dgfactura").Selected = True Or dgvGlosas.Rows(dgvGlosas.CurrentCell.RowIndex).Cells("dgfechafactura").Selected = True) And textcodeps.Text <> String.Empty Then
                    General.busquedaItems(Consultas.NOTIFICACION_GLOSA_FACTURA_BUSCAR, params, TitulosForm.BUSQUEDA_FACTURAS, dgvGlosas, dtGlosas, 0, 7, 0, 0, True)
                End If
                VerificarNotificacionExtemporanea()
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub
    Private Sub VerificarNotificacionExtemporanea()
        For indice = 0 To dgvGlosas.Rows.Count - 1
            If dgvGlosas.Rows.Count > 1 Then

                If CDate(dgvGlosas.Rows(indice).Cells(8).Value) > CDate(dgvGlosas.Rows(indice).Cells(7).Value) Then
                    dgvGlosas.Rows(indice).Cells("dgnotificacionextemporanea").Value = True
                Else
                    dgvGlosas.Rows(indice).Cells("dgnotificacionextemporanea").Value = False
                End If
            End If
        Next
    End Sub
    Public Sub habilitarGrilla()
        With dgvGlosas
            .Columns.Item("dgfactura").ReadOnly = True
            .Columns.Item("dgfechafactura").ReadOnly = True
            .Columns.Item("dgidentificacion").ReadOnly = True
            .Columns.Item("dgfecharadicacion").ReadOnly = True
            .Columns.Item("dgfechalimite").ReadOnly = False
            .Columns.Item("dgpaciente").ReadOnly = True
            .Columns.Item("dgfechaegreso").ReadOnly = True
            .Columns.Item("dgvalorfactura").ReadOnly = True
            .Columns.Item("dgnotificacionextemporanea").ReadOnly = True
            .Columns.Item("dgfacturacion").ReadOnly = True
            .Columns.Item("dgtarifa").ReadOnly = True
            .Columns.Item("dgsoporte").ReadOnly = True
            .Columns.Item("dgautorizacion").ReadOnly = True
            .Columns.Item("dgcobertura").ReadOnly = True
            .Columns.Item("dgpertinencia").ReadOnly = True
            .Columns.Item("dgdevolucion").ReadOnly = True
            .Columns.Item("dgvalorglosaaceptada").ReadOnly = True
            .Columns.Item("dgValorGlosa").ReadOnly = False
        End With
    End Sub
    Private Sub mostrarColumnas()
        dgvGlosas.Columns("dgValorGlosa").Visible = True
        dgvGlosas.Columns("dgfacturacion").Visible = True
        dgvGlosas.Columns("dgtarifa").Visible = True
        dgvGlosas.Columns("dgsoporte").Visible = True
        dgvGlosas.Columns("dgautorizacion").Visible = True
        dgvGlosas.Columns("dgcobertura").Visible = True
        dgvGlosas.Columns("dgpertinencia").Visible = True
        'dgvGlosas.Columns("dgdevolucion").Visible = True
        dgvGlosas.Columns("dgvalorglosaaceptada").Visible = True
        dgvGlosas.Columns("dgfecharespuesta").Visible = True
        dgvGlosas.Columns("dgfechalrespuesta").Visible = True
        dgvGlosas.Columns("dgrespondida").Visible = True
        dgvGlosas.Columns("dgratificada").Visible = True
        dgvGlosas.Columns("dgfechaconciliacion").Visible = True
        dgvGlosas.Columns("dgvalorips").Visible = True
        dgvGlosas.Columns("dgvaloreps").Visible = True
        dgvGlosas.Columns("dgvalorapagar").Visible = True
        dgvGlosas.Columns("dgselect").Visible = True
    End Sub
    Private Sub ocultarColumnas()
        dgvGlosas.Columns("dgValorGlosa").Visible = False
        dgvGlosas.Columns("dgfacturacion").Visible = False
        dgvGlosas.Columns("dgtarifa").Visible = False
        dgvGlosas.Columns("dgsoporte").Visible = False
        dgvGlosas.Columns("dgautorizacion").Visible = False
        dgvGlosas.Columns("dgcobertura").Visible = False
        dgvGlosas.Columns("dgpertinencia").Visible = False
        dgvGlosas.Columns("dgdevolucion").Visible = False
        dgvGlosas.Columns("dgvalorglosaaceptada").Visible = False
        dgvGlosas.Columns("dgfecharespuesta").Visible = False
        dgvGlosas.Columns("dgfechalrespuesta").Visible = False
        dgvGlosas.Columns("dgrespondida").Visible = False
        dgvGlosas.Columns("dgratificada").Visible = False
        dgvGlosas.Columns("dgfechaconciliacion").Visible = False
        dgvGlosas.Columns("dgvalorips").Visible = False
        dgvGlosas.Columns("dgvaloreps").Visible = False
        dgvGlosas.Columns("dgvalorapagar").Visible = False
        dgvGlosas.Columns("dgselect").Visible = False
    End Sub
    Private Sub btinfdetalle_Click(sender As Object, e As EventArgs) Handles btOpcionDetallado.Click
        If SesionActual.tienePermiso(PDetallado) Then
            Dim objFormInformeDetalle As New FormInformeGeneralGlosa
            General.cargarForm(objFormInformeDetalle)
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub
    Private Sub OpcionBtSemaforo_Click(sender As Object, e As EventArgs) Handles OpcionBtSemaforo.Click
        Dim objFormSemaforoGlosa As New FormSemaforoGlosa
        General.cargarForm(objFormSemaforoGlosa)
    End Sub

    Private Sub btVisualizaPDF_Click(sender As Object, e As EventArgs) Handles btVisualizaPDF.Click
        Dim objFormInformeGeneral As New FormReporteAceptacionGlosa
        General.cargarForm(objFormInformeGeneral)
    End Sub

    Private Sub dgvGlosas_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvGlosas.DataError

    End Sub

    Private Sub dgvGlosas_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvGlosas.KeyDown
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        params.Add(idTercero)

        If btguardar.Enabled = False Then
            Exit Sub
        End If

        If e.KeyCode = Keys.F3 Then
            If textcodeps.Text = String.Empty Then
                MsgBox("Debe escoger una EPS")
                btbuscareps.Focus()
            Else
                If (dgvGlosas.Rows(dgvGlosas.CurrentCell.RowIndex).Cells("dgfactura").Selected = True Or dgvGlosas.Rows(dgvGlosas.CurrentCell.RowIndex).Cells("dgfechafactura").Selected = True) And textcodeps.Text <> String.Empty Then
                    General.busquedaItems(Consultas.NOTIFICACION_GLOSA_FACTURA_BUSCAR, params, TitulosForm.BUSQUEDA_FACTURAS, dgvGlosas, dtGlosas, 0, 7, 0, 0, True)
                End If
            End If
        ElseIf e.KeyCode = Keys.Delete And dgvGlosas.Rows(dgvGlosas.CurrentCell.RowIndex).Cells(0).Value.ToString <> "" Then
            dgvGlosas.Rows.RemoveAt(dgvGlosas.CurrentRow.Index)
        End If

    End Sub

    Private Sub btinfGeneral_Click(sender As Object, e As EventArgs) Handles btOpcionGeneral.Click
        If SesionActual.tienePermiso(PGeneral) Then
            Dim objFormInformeGeneral As New FormInformeGeneralDetalle
            General.cargarForm(objFormInformeGeneral)
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub dgvGlosas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGlosas.CellEndEdit
        If dgvGlosas.Rows(e.RowIndex).Cells("dgfactura").Value <> "" Then
            dgvGlosas.Rows(e.RowIndex).Cells("dgvalorglosaaceptada").Value = (CDbl(dgvGlosas.Rows(e.RowIndex).Cells("dgglosaaceptada1").Value) + CDbl(dgvGlosas.Rows(e.RowIndex).Cells("dgglosaaceptada2").Value) + CDbl(dgvGlosas.Rows(e.RowIndex).Cells("dgglosaaceptada3").Value) + CDbl(dgvGlosas.Rows(e.RowIndex).Cells("dgglosaaceptada4").Value) + CDbl(dgvGlosas.Rows(e.RowIndex).Cells("dgglosaaceptada5").Value) + CDbl(dgvGlosas.Rows(e.RowIndex).Cells("dgglosaaceptada6").Value) + CDbl(dgvGlosas.Rows(e.RowIndex).Cells("dgglosaaceptada8").Value))
            If e.ColumnIndex = 25 Then
                dgvGlosas.Rows(e.RowIndex).Cells("dgvalorips").Value = dgvGlosas.Rows(e.RowIndex).Cells("dgratificada").Value - dgvGlosas.Rows(e.RowIndex).Cells("dgvaloreps").Value
            End If
            If e.ColumnIndex = 24 Then
                dgvGlosas.Rows(e.RowIndex).Cells("dgvaloreps").Value = dgvGlosas.Rows(e.RowIndex).Cells("dgratificada").Value - dgvGlosas.Rows(e.RowIndex).Cells("dgvalorips").Value
            End If

            If dgvGlosas.Rows(e.RowIndex).Cells("dgrespondida").Value = True Then
                dgvGlosas.Rows(e.RowIndex).Cells("dgratificada").Value = CDbl(dgvGlosas.Rows(e.RowIndex).Cells(10).Value)
                If dgvGlosas.Rows(e.RowIndex).Cells("dgratificada").Value = 0 Then
                    dgvGlosas.Rows(e.RowIndex).Cells("dgvalorapagar").Value = dgvGlosas.Rows(e.RowIndex).Cells("dgvalorglosaaceptada").Value
                Else
                    dgvGlosas.Rows(e.RowIndex).Cells("dgvalorapagar").Value = dgvGlosas.Rows(e.RowIndex).Cells("dgvalorips").Value
                End If
            Else
                dgvGlosas.Rows(e.RowIndex).Cells("dgratificada").Value = "0,00"
                dgvGlosas.Rows(e.RowIndex).Cells("dgvalorapagar").Value = "0,00"
            End If
            If CDate(dgvGlosas.Rows(e.RowIndex).Cells(8).Value) > CDate(dgvGlosas.Rows(e.RowIndex).Cells(7).Value) Then
                dgvGlosas.Rows(e.RowIndex).Cells("dgnotificacionextemporanea").Value = True
            Else
                dgvGlosas.Rows(e.RowIndex).Cells("dgnotificacionextemporanea").Value = False
            End If
            If e.ColumnIndex = 8 Then
                dgvGlosas.Rows(e.RowIndex).Cells("dgfechalrespuesta").Value = CDate(dgvGlosas.Rows(e.RowIndex).Cells("dgfechanotificarglosa").Value).AddDays(15)
            End If

        End If
    End Sub

    Private Sub dgvGlosas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGlosas.CellEnter
        If dgvGlosas.Rows(e.RowIndex).Cells("dgfactura").Value <> "" Then
            dgvGlosas.Rows(e.RowIndex).Cells("dgvalorglosaaceptada").Value = (CDbl(dgvGlosas.Rows(e.RowIndex).Cells("dgglosaaceptada1").Value) + CDbl(dgvGlosas.Rows(e.RowIndex).Cells("dgglosaaceptada2").Value) + CDbl(dgvGlosas.Rows(e.RowIndex).Cells("dgglosaaceptada3").Value) + CDbl(dgvGlosas.Rows(e.RowIndex).Cells("dgglosaaceptada4").Value) + CDbl(dgvGlosas.Rows(e.RowIndex).Cells("dgglosaaceptada5").Value) + CDbl(dgvGlosas.Rows(e.RowIndex).Cells("dgglosaaceptada6").Value) + CDbl(dgvGlosas.Rows(e.RowIndex).Cells("dgglosaaceptada8").Value))
            If e.ColumnIndex = 25 Then
                dgvGlosas.Rows(e.RowIndex).Cells("dgvalorips").Value = dgvGlosas.Rows(e.RowIndex).Cells("dgratificada").Value - dgvGlosas.Rows(e.RowIndex).Cells("dgvaloreps").Value
            End If
            If e.ColumnIndex = 24 Then
                dgvGlosas.Rows(e.RowIndex).Cells("dgvaloreps").Value = dgvGlosas.Rows(e.RowIndex).Cells("dgratificada").Value - dgvGlosas.Rows(e.RowIndex).Cells("dgvalorips").Value
            End If
            If dgvGlosas.Rows(e.RowIndex).Cells("dgrespondida").Value = True Then
                If dgvGlosas.Rows(e.RowIndex).Cells("dgratificada").Value = 0 Then
                    dgvGlosas.Rows(e.RowIndex).Cells("dgvalorapagar").Value = dgvGlosas.Rows(e.RowIndex).Cells("dgvalorglosaaceptada").Value
                Else
                    dgvGlosas.Rows(e.RowIndex).Cells("dgvalorapagar").Value = dgvGlosas.Rows(e.RowIndex).Cells("dgvalorips").Value
                End If
            Else
                dgvGlosas.Rows(e.RowIndex).Cells("dgvalorapagar").Value = "0,00"
            End If

            If CDate(dgvGlosas.Rows(e.RowIndex).Cells(8).Value) > CDate(dgvGlosas.Rows(e.RowIndex).Cells(7).Value) Then
                dgvGlosas.Rows(e.RowIndex).Cells("dgnotificacionextemporanea").Value = True
            Else
                dgvGlosas.Rows(e.RowIndex).Cells("dgnotificacionextemporanea").Value = False
            End If

        End If
    End Sub
    Private Sub cargarActa()
        Dim Form = New Form_resultado
        Form.cargarResultado(txtcodigo.Text,
                             textcodeps.Text,
                             Textnombreeps.Text,
                             Constantes.DC,
                              0, '-- indica que tipo de arhivo va abrir (0-pdf, 1-imagen)
                             Constantes.TipoGlosa)
        Form.ShowDialog()
    End Sub
    Private Sub btnacta_Click(sender As Object, e As EventArgs) Handles btnActa.Click
        If txtcodigo.Text <> String.Empty And dgvGlosas.Rows.Count > 0 Then
            cargarActa()
        End If
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Dim rptRespuestaGlosa As New rptRespuestaGlosa
        Try
            Cursor = Cursors.WaitCursor
            Funciones.getReporteNoFTP(rptRespuestaGlosa, "{VISTA_RESPUESTA_GLOSAS.Código notificación glosa} = " & txtcodigo.Text & " AND {VISTA_EMPRESAS.Id_empresa}=" & SesionActual.idEmpresa & "", "Notificación Glosa")
            Cursor = Cursors.Default
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub
End Class