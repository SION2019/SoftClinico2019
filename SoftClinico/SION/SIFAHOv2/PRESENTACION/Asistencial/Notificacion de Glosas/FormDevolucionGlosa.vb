Public Class FormDevolucionGlosa
    Dim dtGlosas As New DataTable
    Dim idTercero As Integer
    Dim valorColumna As Integer
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, PGeneral, PDetallado, PNotaCredito As String
    Dim reporte As New ftp_reportes
    Public Property objDetalleGlosa As DetalleGlosa
    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        'If SesionActual.tienePermiso(Pnuevo) Then
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
        'Else
        '    MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        'End If
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
    Private Sub FormDevolucionGlosa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        est8.ColumnName = "Fecha_Notificacion_Limite"
        est8.DataType = Type.GetType("System.DateTime")
        est8.DefaultValue = Date.Today
        dtGlosas.Columns.Add(est8)

        est9.ColumnName = "Fecha_Notificacion_Dev"
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

        est18.ColumnName = "Devolucion"
        est18.DataType = Type.GetType("System.Decimal")
        est18.DefaultValue = 0
        dtGlosas.Columns.Add(est18)

        est19.ColumnName = "Valor_Glosa_Aceptada"
        est19.DataType = Type.GetType("System.Decimal")
        est19.DefaultValue = 0
        dtGlosas.Columns.Add(est19)

        est20.ColumnName = "Fecha_LRespuesta_Dev"
        est20.DataType = Type.GetType("System.DateTime")
        est20.DefaultValue = Date.Today
        dtGlosas.Columns.Add(est20)

        est21.ColumnName = "Fecha_Respuesta_Dev"
        est21.DataType = Type.GetType("System.DateTime")
        est21.DefaultValue = Date.Today
        dtGlosas.Columns.Add(est21)

        est22.ColumnName = "Respondida"
        est22.DataType = Type.GetType("System.Boolean")
        est22.DefaultValue = False
        dtGlosas.Columns.Add(est22)

        est23.ColumnName = "Codigo_factura_Nueva"
        est23.DataType = Type.GetType("System.String")
        est23.DefaultValue = String.Empty
        dtGlosas.Columns.Add(est23)

        est27.ColumnName = "Valor_a_Pagar"
        est27.DataType = Type.GetType("System.Decimal")
        est27.DefaultValue = 0
        dtGlosas.Columns.Add(est27)

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
            .Columns.Item("dgfechalimite").DataPropertyName = "Fecha_Notificacion_Limite"

            .Columns.Item("dgfechanotificarglosa").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgfechanotificarglosa").DataPropertyName = "Fecha_Notificacion_Dev"

            .Columns.Item("dgnotificacionextemporanea").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgnotificacionextemporanea").DataPropertyName = "Notificacion_Extemporanea"

            .Columns.Item("dgvalorglosa").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgvalorglosa").DataPropertyName = "Valor_Glosa"

            .Columns.Item("dgdevolucion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgdevolucion").DataPropertyName = "Devolucion"

            .Columns.Item("dgvalorglosaaceptada").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgvalorglosaaceptada").DataPropertyName = "Valor_Glosa_Aceptada"

            .Columns.Item("dgfecharespuesta").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgfecharespuesta").DataPropertyName = "Fecha_Respuesta_Dev"

            .Columns.Item("dgfechalrespuesta").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgfechalrespuesta").DataPropertyName = "Fecha_LRespuesta_Dev"

            .Columns.Item("dgrespondida").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgrespondida").DataPropertyName = "Respondida"
            .Columns.Item("dgrespondida").ReadOnly = True

            .Columns.Item("dgNuevaFactura").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgNuevaFactura").DataPropertyName = "Codigo_factura_Nueva"

            .Columns.Item("dgNuevaFechaRadicacion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgNuevaFechaRadicacion").DataPropertyName = "Fecha_Radicacion_Nueva"

            .Columns.Item("dgNuevoCliente").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgNuevoCliente").DataPropertyName = "Nuevo_Cliente"

            .Columns.Item("dgselect").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgselect").DataPropertyName = "Terminada"

        End With
        dgvGlosas.AutoGenerateColumns = False
        dgvGlosas.DataSource = dtGlosas
        dgvGlosas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGlosas.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        dgvGlosas.ReadOnly = True
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

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        'If SesionActual.tienePermiso(PBuscar) Then
        Dim params As New List(Of String)
            params.Add("")
            params.Add(SesionActual.codigoEP)
            General.buscarElemento(Consultas.NOTIFICACION_DEVOLUCION_BUSCAR,
                                   params,
                                   AddressOf cargarDatos,
                                   TitulosForm.BUSQUEDA_DEVOLUCION,
                                   False, Constantes.TAMANO_MEDIANO, True)
        'Else
        '    MsgBox(Mensajes.SINPERMISO)
        'End If
    End Sub
    Private Sub cargarDatos(pCodigo As String)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        General.llenarTabla(Consultas.NOTIFICACION_DEVOLUCION_FACTURA_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            idTercero = dt.Rows(0).Item("Id_cliente").ToString()
            Textnombreeps.Text = dt.Rows(0).Item("EPS").ToString()
            textcodeps.Text = dt.Rows(0).Item("Nit").ToString()
            llenarDetalleGlosa(pCodigo)
            General.habilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            btguardar.Enabled = False
            btcancelar.Enabled = False
            OpcionBtSemaforo.Enabled = True
        End If
    End Sub
    Private Sub llenarDetalleGlosa(pCodigo As String)
        Dim params As New List(Of String)
        params.Add(pCodigo)
        txtcodigo.Text = pCodigo
        General.llenarTabla(Consultas.NOTIFICACION_DEVOLUCION_DETALLE_CARGAR, params, dtGlosas)
        dgvGlosas.DataSource = dtGlosas
        dgvGlosas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGlosas.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        mostrarColumnas()
        dgvalorglosa.ReadOnly = True
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        'If SesionActual.tienePermiso(Peditar) Then
        If General.fnFormEditar(Me, ToolStrip1, btguardar, btcancelar) Then
                dtGlosas.Rows.Add()
                habilitarGrilla()
            End If
        'Else
        '    MsgBox(Mensajes.SINPERMISO)
        'End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        General.formCancelar(Me, ToolStrip1, btnuevo, btbuscar)
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        'If SesionActual.tienePermiso(Panular) Then
        If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim params As New List(Of String)
                params.Add(txtcodigo.Text)
                params.Add(SesionActual.idUsuario)
                General.ejecutarSQL(Consultas.NOTIFICACION_DEVOLUCION_ANULAR, params)
                General.posAnularForm(Me, ToolStrip1, btnuevo, btbuscar)
            End If
        'Else
        '    MsgBox(Mensajes.SINPERMISO)
        'End If
    End Sub

    Private Sub dgvGlosas_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvGlosas.KeyDown
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        params.Add(idTercero)
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 Then
            If (dgvGlosas.Rows(dgvGlosas.CurrentCell.RowIndex).Cells("dgfactura").Selected = True Or dgvGlosas.Rows(dgvGlosas.CurrentCell.RowIndex).Cells("dgfechafactura").Selected = True) And textcodeps.Text <> String.Empty Then
                General.busquedaItems(Consultas.NOTIFICACION_DEVOLUCION_FACTURA_BUSCAR, params, TitulosForm.BUSQUEDA_FACTURAS, dgvGlosas, dtGlosas, 0, 7, 0, 0)
            End If
        ElseIf e.KeyCode = Keys.Delete And dgvGlosas.Rows(dgvGlosas.CurrentCell.RowIndex).Cells(0).Value.ToString <> "" Then
            dgvGlosas.Rows.RemoveAt(dgvGlosas.CurrentRow.Index)
        End If
    End Sub
    Private Sub dgvGlosas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGlosas.CellEnter
        If dgvGlosas.Rows(e.RowIndex).Cells("dgfactura").Value <> "" Then
            If CDate(dgvGlosas.Rows(e.RowIndex).Cells(8).Value) > CDate(dgvGlosas.Rows(e.RowIndex).Cells(7).Value) Then
                dgvGlosas.Rows(e.RowIndex).Cells("dgnotificacionextemporanea").Value = True
            Else
                dgvGlosas.Rows(e.RowIndex).Cells("dgnotificacionextemporanea").Value = False
            End If
        End If
    End Sub
    Private Sub dgvGlosas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGlosas.CellDoubleClick
        valorColumna = e.ColumnIndex
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        params.Add(idTercero)

        If btguardar.Enabled = False Then
            Exit Sub
        End If

        Try
            If valorColumna = 11 Then
                abrirFormDetalleGlosa()
            End If

            If (dgvGlosas.Rows(dgvGlosas.CurrentCell.RowIndex).Cells("dgfactura").Selected = True Or dgvGlosas.Rows(dgvGlosas.CurrentCell.RowIndex).Cells("dgfechafactura").Selected = True) And textcodeps.Text <> String.Empty Then
                General.busquedaItems(Consultas.NOTIFICACION_GLOSA_FACTURA_BUSCAR, params, TitulosForm.BUSQUEDA_FACTURAS, dgvGlosas, dtGlosas, 0, 7, 0, 0, True)
            End If
            VerificarNotificacionExtemporanea()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
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
    Public Sub guardarDesdeGlosaDetalle()
        dgvGlosas.EndEdit()
        dtGlosas.AcceptChanges()
        Dim objNotificacionGlosaBll As New NotificacionDevolucionBLL
        Try
            txtcodigo.Text = objNotificacionGlosaBll.guardarNotificacionDevolucion(crearNotificacionDevolucion())
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If validarInformacion() Then
            If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                guardarGlosa()
            End If
        End If
    End Sub
    Public Sub guardarGlosa()
        dgvGlosas.EndEdit()
        dtGlosas.AcceptChanges()
        Dim objNotificacionDevolucionBll As New NotificacionDevolucionBLL
        Try
            If txtcodigo.Text <> String.Empty Then
                General.posGuardarForm(Me, ToolStrip1, btnuevo, btbuscar, bteditar, btanular)
                btimprimir.Enabled = True
            End If
            txtcodigo.Text = objNotificacionDevolucionBll.guardarNotificacionDevolucion(crearNotificacionDevolucion())
            cargarDatos(txtcodigo.Text)
            mostrarColumnas()
            habilitarGrilla()
            OpcionBtSemaforo.Enabled = True
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
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
    Private Sub abrirFormSemaforo()
        FormSemaforoGlosa.MdiParent = FormPrincipal
        FormSemaforoGlosa.formulario = 1
        FormSemaforoGlosa.Show()
    End Sub
    Private Sub OpcionBtSemaforo_Click(sender As Object, e As EventArgs) Handles OpcionBtSemaforo.Click
        abrirFormSemaforo()
    End Sub

    Private Sub btOpcionDetallado_Click(sender As Object, e As EventArgs) Handles btOpcionDetallado.Click
        Dim objFormInformeDetalle As New FormInformeGeneralGlosa
        objFormInformeDetalle.formulario = 1
        General.cargarForm(objFormInformeDetalle)

    End Sub

    'Private Sub dgvGlosas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGlosas.CellContentClick
    '    Dim dt As New DataTable
    '    Dim params As New List(Of String)
    '    params.Add(dgvGlosas.Rows(dgvGlosas.CurrentRow.Index).Cells(0).Value)
    '    General.llenarTabla(ConsultasAsis.CODIGO_RESPUESTA_CONSULTAR, params, dt)
    '    If e.ColumnIndex = 19 And btguardar.Enabled = True And dt.Rows.Count > 0 Then
    '        Try
    '            If dgvGlosas.Rows(dgvGlosas.CurrentRow.Index).Cells(19).Value = False Then
    '                dgvGlosas.Rows(dgvGlosas.CurrentRow.Index).Cells(19).Value = True
    '                General.anularRegistro(ConsultasAsis.FACTURA_ANULAR & "'" & dgvGlosas.Rows(dgvGlosas.CurrentRow.Index).Cells(0).Value & "'," & SesionActual.idEmpresa & "," & SesionActual.idUsuario & "")
    '            Else
    '                dgvGlosas.Rows(dgvGlosas.CurrentRow.Index).Cells(19).Value = False
    '                General.anularRegistro(ConsultasAsis.FACTURA_DESANULAR & "'" & dgvGlosas.Rows(dgvGlosas.CurrentRow.Index).Cells(0).Value & "'," & SesionActual.idEmpresa & "," & SesionActual.idUsuario & "")
    '            End If
    '        Catch ex As Exception
    '            General.manejoErrores(ex)
    '        End Try
    '    End If
    'End Sub

    Public Function crearNotificacionDevolucion() As NotificacionDevolucion
        Dim objNotificacionDevolucion As New NotificacionDevolucion
        objNotificacionDevolucion.identificador = txtcodigo.Text
        dgvGlosas.EndEdit()
        dtGlosas.AcceptChanges()

        For Each drFila As DataRow In dtGlosas.Rows
            If drFila.Item("Codigo_factura").ToString <> "" Then
                Dim drCuenta As DataRow = objNotificacionDevolucion.dtDevolucion.NewRow
                drCuenta.Item("Codigo_Devolucion") = txtcodigo.Text
                drCuenta.Item("Id_Empresa") = SesionActual.idEmpresa
                drCuenta.Item("Codigo_factura") = drFila.Item("Codigo_factura")
                drCuenta.Item("Fecha_Notificacion_Limite") = drFila.Item("Fecha_Notificacion_Limite")
                drCuenta.Item("Fecha_Notificacion_Dev") = drFila.Item("Fecha_Notificacion_Dev")
                drCuenta.Item("Notificacion_Extemporanea") = drFila.Item("Notificacion_Extemporanea")
                drCuenta.Item("Valor_Glosa") = drFila.Item("Valor_Glosa")
                drCuenta.Item("Devolucion") = drFila.Item("Devolucion")
                drCuenta.Item("Valor_Glosa_Aceptada") = drFila.Item("Valor_Glosa_Aceptada")
                drCuenta.Item("Fecha_LRespuesta_Dev") = drFila.Item("Fecha_LRespuesta_Dev")
                drCuenta.Item("Fecha_Respuesta_Dev") = drFila.Item("Fecha_Respuesta_Dev")
                drCuenta.Item("Respondida") = drFila.Item("Respondida")
                drCuenta.Item("Codigo_factura_Nueva") = drFila.Item("Codigo_factura_Nueva")
                drCuenta.Item("Valor_a_Pagar") = drFila.Item("Valor_a_Pagar")
                drCuenta.Item("Terminada") = drFila.Item("Terminada")
                drCuenta.Item("usuario") = SesionActual.idUsuario
                objNotificacionDevolucion.dtDevolucion.Rows.Add(drCuenta)
            End If
        Next
        Return objNotificacionDevolucion
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
        FormGlosaDetalle.objFormDevolucion = Me
        FormGlosaDetalle.formulario = 1
        FormGlosaDetalle.Show()
        FormGlosaDetalle.llenarDvgGlosas(txtcodigo.Text, dgvGlosas.Rows(dgvGlosas.CurrentRow.Index).Cells(0).Value, dgvGlosas.Rows(dgvGlosas.CurrentRow.Index).Cells(3).Value, registroNuevo)
    End Sub
    Public Function asignarValorColumnaDgv(columna As Integer)
        Dim htGlosasCol As New Hashtable
        htGlosasCol.Add(11, 8)
        Return htGlosasCol.Item(columna)
    End Function
    Private Sub dgvGlosas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGlosas.CellEndEdit
        If dgvGlosas.Rows(e.RowIndex).Cells("dgfactura").Value <> "" Then
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
            .Columns.Item("dgdevolucion").ReadOnly = True
            .Columns.Item("dgvalorglosaaceptada").ReadOnly = True
            .Columns.Item("dgValorGlosa").ReadOnly = False
            .Columns.Item("dgNuevaFactura").ReadOnly = False
            .Columns.Item("dgNuevaFechaRadicacion").ReadOnly = False
            .Columns.Item("dgNuevoCliente").ReadOnly = False
        End With
    End Sub
    Private Sub mostrarColumnas()
        dgvGlosas.Columns("dgValorGlosa").Visible = True
        dgvGlosas.Columns("dgdevolucion").Visible = True
        dgvGlosas.Columns("dgvalorglosaaceptada").Visible = True
        dgvGlosas.Columns("dgfecharespuesta").Visible = True
        dgvGlosas.Columns("dgfechalrespuesta").Visible = True
        dgvGlosas.Columns("dgrespondida").Visible = True
        dgvGlosas.Columns("dgselect").Visible = True
        dgvGlosas.Columns("dgNuevaFactura").Visible = True
        dgvGlosas.Columns("dgNuevaFechaRadicacion").Visible = True
        dgvGlosas.Columns("dgNuevoCliente").Visible = True
    End Sub
    Private Sub ocultarColumnas()
        dgvGlosas.Columns("dgValorGlosa").Visible = False
        dgvGlosas.Columns("dgdevolucion").Visible = False
        dgvGlosas.Columns("dgvalorglosaaceptada").Visible = False
        dgvGlosas.Columns("dgfecharespuesta").Visible = False
        dgvGlosas.Columns("dgfechalrespuesta").Visible = False
        dgvGlosas.Columns("dgrespondida").Visible = False
        dgvGlosas.Columns("dgvalorglosaaceptada").Visible = False
        dgvGlosas.Columns("dgselect").Visible = False
        dgvGlosas.Columns("dgNuevaFactura").Visible = False
        dgvGlosas.Columns("dgNuevaFechaRadicacion").Visible = False
        dgvGlosas.Columns("dgNuevoCliente").Visible = False
    End Sub

End Class