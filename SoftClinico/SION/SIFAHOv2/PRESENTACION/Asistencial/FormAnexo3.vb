Imports System.Data.SqlClient
Imports System.Threading
Public Class FormAnexo3
    Dim dtAnexo As New DataTable
    Dim cmd As New Anexo3BLL
    Dim reporte As New ftp_reportes
    Dim busproced, respuesta, BuscarAnexo3 As Boolean
    Dim Servicio, prioridad, ingreso, areaTraslado As Integer
    Dim i As Integer
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar, codigoTemporal, codigoOrden, emailEPS As String
    Dim elementoAEliminar As New List(Of String)
    Shared hilo As Thread
    Dim vParams As New List(Of String)

    Private Sub Form_Anexo3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso_general = perG.buscarPermisoGeneral(Name)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
        fecha.Text = Funciones.Fecha(Constantes.FORMATO_FECHA)
        establecer_tabla()
        Dim params As New List(Of String)
        params.Add(txtCodigoArea.Text)
        If String.IsNullOrEmpty(txtCodigoRemision.Text) Then
            btguardar.Enabled = False
            bteditar.Enabled = False
            btcancelar.Enabled = False
            btanular.Enabled = False
            DeshabilitarControlesManual()
        End If

    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox("¿Desea cancelar este registro?", 32 + 1, "cancelar") = 1 Then
            DeshabilitarControlesManual()
            limpiarControles()
            elementoAEliminar.Clear()
            btnuevo.Enabled = True
            fecha.Text = Funciones.Fecha(Constantes.FORMATO_FECHA)
            btguardar.Enabled = False
            bteditar.Enabled = False
            btanular.Enabled = False
            btcancelar.Enabled = False
            btimprimir.Enabled = False
            btbuscar.Enabled = True
        End If
    End Sub

    Public Sub limpiarControles()
        txtorden.Clear()
        txtobservacion.Clear()
        txtjustificacion.Clear()
        rdhospitalizacion.Checked = False
        rdnoprioridad.Checked = False
        rdservicios.Checked = False
        dtAnexo.Clear()
        areaTraslado = Constantes.VALOR_PREDETERMINADO
    End Sub
    Private Sub Form__FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Modal Then Exit Sub
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
    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular ) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                General.anularRegistro(Consultas.ANULAR_ANEXO3 & txtorden.Text & "," & SesionActual.idUsuario)
                MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                DeshabilitarControlesManual()
                limpiarControles()
                btanular.Enabled = False
                fecha.Text = Funciones.Fecha(Constantes.FORMATO_FECHA)
                btguardar.Enabled = False
                bteditar.Enabled = False
                btimprimir.Enabled = False
                btcancelar.Enabled = False
                btnuevo.Enabled = True
            End If
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Public Sub DeshabilitarControlesManual()
        txtobservacion.ReadOnly = True
        txtjustificacion.ReadOnly = True
        GroupBox3.Enabled = False
        GroupBox5.Enabled = False
        GroupBox8.Enabled = False
        dgvanexo.Columns("Inicio").ReadOnly = True
        dgvanexo.Columns("Fin").ReadOnly = True
        dgvanexo.Columns("CodigoCUPS").ReadOnly = True
    End Sub
    Public Sub HabilitarControlesManual()
        txtobservacion.ReadOnly = False
        txtjustificacion.ReadOnly = False
        GroupBox3.Enabled = True
        GroupBox5.Enabled = True
        GroupBox8.Enabled = True
        dgvanexo.Columns("Inicio").ReadOnly = False
        dgvanexo.Columns("Fin").ReadOnly = False
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar ) Then
            HabilitarControlesManual()
            btcancelar.Enabled = True '--Cancelar--
            btguardar.Enabled = True '--Guardar-
            bteditar.Enabled = False
            btbuscar.Enabled = False
            dgvanexo.Columns("Dias").ReadOnly = True
            btimprimir.Enabled = False
            btanular.Enabled = False
            btnuevo.Enabled = False
            dtAnexo.Rows.Add()
            elementoAEliminar.Clear()
            textTraslado.ReadOnly = True
            btBuscarEsp.Enabled = True
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Public Sub VerificarCodigo()
        Dim dt As New DataTable
        General.llenarTablaYdgv(Consultas.ANEXO3_VERIFICAR_CODIGO_PROCEDIMIENTO & "'" & dgvanexo.Rows(dgvanexo.CurrentCell.RowIndex).Cells(1).Value & "'", dt)
        If dt.Rows.Count > 0 Then
            If dgvanexo.Rows(dgvanexo.CurrentCell.RowIndex).Cells("Servicios").Value.ToString = "" Then
                dtAnexo.Rows.Add()
                dgvanexo.Columns(1).ReadOnly = False
                dgvanexo.Columns(3).ReadOnly = False
                dgvanexo.Columns(4).ReadOnly = False
                dgvanexo.Rows(dgvanexo.CurrentCell.RowIndex).Cells("Estado").Value = Constantes.ITEM_NUEVO
            End If
            dtAnexo.Rows(dgvanexo.CurrentCell.RowIndex).Item("Servicio") = dt.Rows(0).Item("Descripcion").ToString
        Else
            MsgBox("Codigo no Existente", 48, "Atencion")
        End If
    End Sub

    Private Sub dgvanexo_CellEnter(sender As Object, e As DataGridViewCellEventArgs)


    End Sub

    Private Function validarControles()


        If txtobservacion.Text = "" Then
            MsgBox("Por favor digitar manejo integral", MsgBoxStyle.Exclamation)
            txtobservacion.Focus()
            Return False
        ElseIf txtjustificacion.Text = "" Then
            MsgBox("Por favor digitar justificacion clinica", MsgBoxStyle.Exclamation)
            txtjustificacion.Focus()
            Return False
        ElseIf dgvanexo.Rows.Count = 1 Then
            MsgBox("Por favor seleccione un procedimiento", 48, MsgBoxStyle.Exclamation)
            dgvanexo.Focus()
            Return False
        ElseIf Not String.IsNullOrEmpty(txtCodigoRemision.Text) AndAlso String.IsNullOrEmpty(textTraslado.text) Then
            MsgBox("¡Por favor seleccione el servicio donde será trasladado el paciente!", 48, MsgBoxStyle.Exclamation)
            btBuscarEsp.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub guardarAnexo()
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Try
                If rdposterior.Checked = True Then
                    Servicio = Constantes.ANEXO3_POSTERIOR
                Else
                    Servicio = Constantes.ANEXO3_SERVICIO
                End If
                If rdprioridad.Checked = True Then
                    prioridad = Constantes.ANEXO3_PRIORIDAD
                Else
                    prioridad = Constantes.ANEXO3_NO_PRIORIDAD
                End If

                If drconsulta.Checked = True Then
                    ingreso = Constantes.ANEXO3_CONSULTA_EXTERNA
                ElseIf rdurgencia.Checked = True Then
                    ingreso = Constantes.ANEXO3_URGENCIA
                ElseIf rdhospitalizacion.Checked = True Then
                    ingreso = Constantes.ANEXO3_HOSPITALARIO
                End If
                Dim solicitud As String = fecha.Text & "-" & txtcontador.Text
                Dim vAnexo3 As New Anexo3
                vAnexo3.orden = txtorden.Text
                vAnexo3.registro = txtregistro.Text
                vAnexo3.nsolicitud = solicitud
                vAnexo3.tipoanexo = txttipoinforme.Text
                vAnexo3.manejo = txtobservacion.Text
                vAnexo3.justificacion = txtjustificacion.Text
                vAnexo3.tiposervicio = Servicio
                vAnexo3.prioridad = prioridad
                vAnexo3.ingreso = ingreso
                vAnexo3.servicio = txtservicio.Text
                vAnexo3.servicioNuevo = areaTraslado
                vAnexo3.usuario = SesionActual.idUsuario
                vAnexo3.dtanexo = dgvanexo.DataSource
                vAnexo3.elementoAEliminar = elementoAEliminar
                vAnexo3.codigoNW = ""
                vAnexo3.remision = txtCodigoRemision.Text
                vAnexo3.guardarAnexo3()

                txtorden.Text = vAnexo3.orden
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                codigoTemporal = vAnexo3.registro
                codigoOrden = vAnexo3.orden
                ' guardarReporteAnexo()
                btguardar.Enabled = False
                btcancelar.Enabled = True
                bteditar.Enabled = True
                btbuscar.Enabled = True
                btnuevo.Enabled = True
                btanular.Enabled = True
                btcancelar.Enabled = False
                btimprimir.Enabled = True
                cargardgv()
                DeshabilitarControlesManual()
                If Modal Then

                    Dim params As New List(Of String)
                    params.Add(txtorden.Text)
                    vParams.Add(General.getValorConsulta(ConsultasHC.REGISTRO_ANEXO3_VERIFICAR, params))
                End If
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub


    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgvanexo.EndEdit()

        If validarControles() Then
            guardarAnexo()
        End If
    End Sub

    Public Sub establecer_tabla()
        If dtAnexo.Columns.Count = 0 Then
            Dim col1, col2, col3, col4, col5, col6 As New DataColumn

            col1.ColumnName = "CodigoCUPS"
            col1.DataType = Type.GetType("System.String")
            dtAnexo.Columns.Add(col1)

            col2.ColumnName = "Servicio"
            col2.DataType = Type.GetType("System.String")
            dtAnexo.Columns.Add(col2)

            col3.ColumnName = "Inicio"
            col3.DefaultValue = Format(Date.Now, "dd-MM-yyyy")
            dtAnexo.Columns.Add(col3)

            col4.ColumnName = "Fin"
            col4.DefaultValue = Format(Date.Now, "dd-MM-yyyy")
            dtAnexo.Columns.Add(col4)

            col5.ColumnName = "Dias"
            col5.DataType = Type.GetType("System.String")
            dtAnexo.Columns.Add(col5)

            col6.ColumnName = "Estado"
            col6.DataType = Type.GetType("System.String")
            dtAnexo.Columns.Add(col6)
            With dgvanexo
                .Columns("CodigoCUPS").ReadOnly = False
                .Columns("CodigoCUPS").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("CodigoCUPS").DataPropertyName = "CodigoCUPS"
                .Columns("Servicios").ReadOnly = True
                .Columns("Servicios").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("Servicios").DataPropertyName = "Servicio"
                .Columns("Inicio").ReadOnly = True
                .Columns("Inicio").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("Inicio").DataPropertyName = "Inicio"
                .Columns("Fin").ReadOnly = True
                .Columns("Fin").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("Fin").DataPropertyName = "Fin"
                .Columns("Dias").ReadOnly = True
                .Columns("Dias").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("Dias").DataPropertyName = "Dias"
                .Columns("ANULAR").ReadOnly = True
                .Columns("ANULAR").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("ANULAR").DisplayIndex = CInt(dgvanexo.ColumnCount - 1)
            End With
            dgvanexo.DataSource = dtAnexo
            dgvanexo.Columns("Estado").Visible = False
            dgvanexo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvanexo.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            col1 = Nothing : col2 = Nothing : col3 = Nothing : col4 = Nothing : col5 = Nothing : col6 = Nothing
        End If

    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If btguardar.Enabled = True Then
            MsgBox("Por favor guarde la información del anexo3", MsgBoxStyle.Information)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        btimprimir.Enabled = False
        Try
            Dim ruta, area, nombreArchivo As String
            area = ConstantesHC.NOMBRE_PDF_ANEXO_3
            nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtorden.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = IO.Path.GetTempPath() & nombreArchivo
            'ftp_reportes.llamarArchivo(ruta, nombreArchivo, txtorden.Text, area)
            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_ANEXO_3, txtorden.Text, New rptAnexo3,
                                    txtorden.Text, "{VISTA_ANEXO3.N_Orden} = " & txtorden.Text & "",
                                    ConstantesHC.NOMBRE_PDF_ANEXO_3, IO.Path.GetTempPath)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        btimprimir.Enabled = True
        Cursor = Cursors.Default
    End Sub
    Private Sub guardarReporteAnexo()
        Try
            reporte.crearReportePDF(ConstantesHC.NOMBRE_PDF_ANEXO_3, codigoTemporal, New rptAnexo3,
                                    codigoOrden, "{VISTA_ANEXO3.N_Orden} = " & codigoOrden & "",
                                    ConstantesHC.NOMBRE_PDF_ANEXO_3, IO.Path.GetTempPath)

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Private Sub dgvanexo_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvanexo.CellFormatting
        If e.ColumnIndex = 4 OrElse e.ColumnIndex = 3 Then
            e.Value = Format(Format(CDate(e.Value).Date, Constantes.FORMATO_FECHA2), "")
        End If

    End Sub

    Private Sub dgvanexo_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvanexo.DataError

    End Sub

    Public Sub cargardgv()
        Dim params As New List(Of String)
        params.Add(txtorden.Text)
        params.Add(txtregistro.Text)
        General.llenarTabla(Consultas.BUSQUEDA_ANEXO3_DETALLE_REGISTRO, params, dtAnexo)
        For i = 0 To dtAnexo.Rows.Count - 1
            dtAnexo.Rows(i).Item("Estado") = Constantes.ITEM_CARGADO
        Next
    End Sub

    Public Sub cargardgvAutomatico()
        Dim params As New List(Of String)
        params.Add(txtregistro.Text)
        General.llenarTabla(Consultas.CARGAR_ANEXO3_DETALLE_AUTO, params, dtAnexo)
        For i = 0 To dtAnexo.Rows.Count - 1
            dtAnexo.Rows(i).Item("Estado") = Constantes.ITEM_NUEVO
        Next
    End Sub

    Private Sub dgvanexo_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvanexo.CellDoubleClick
        If btguardar.Enabled = False Then
            Exit Sub
        End If
        If (dgvanexo.Rows(dgvanexo.CurrentCell.RowIndex).Cells("CodigoCUPS").Selected = True Or dgvanexo.Rows(dgvanexo.CurrentCell.RowIndex).Cells("Servicios").Selected = True) And dtAnexo.Rows(dgvanexo.CurrentCell.RowIndex).Item("Estado").ToString = "" Then
            General.agregarItemsQx(Consultas.LISTA_PROCEDIMIENTOS_CUPS & txtregistro.Text &
                                   ConstantesHC.NOMBRE_PDF_SEPARADOR3, TitulosForm.BUSQUEDA_PROCEDIMIENTOS_CUPS,
                                  dgvanexo, dtAnexo)
            For i = 0 To dtAnexo.Rows.Count - 2
                If Not dtAnexo.Rows(i).Item("Estado").ToString = Constantes.ITEM_CARGADO Then
                    dtAnexo.Rows(i).Item("Estado") = Constantes.ITEM_NUEVO
                End If
                dtAnexo.Rows(i).Item("Dias") = DateDiff(DateInterval.Day, dtAnexo.Rows(i).Item("Inicio"), dtAnexo.Rows(i).Item("Fin")) + 1
            Next

        ElseIf dgvanexo.Rows(dgvanexo.CurrentCell.RowIndex).Cells("ANULAR").Selected = True And dtAnexo.Rows(dgvanexo.CurrentCell.RowIndex).Item("Estado").ToString <> "" Then
            If dtAnexo.Rows(dgvanexo.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_NUEVO Then
                dtAnexo.Rows.RemoveAt(e.RowIndex)
            ElseIf dtAnexo.Rows(dgvanexo.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_CARGADO Then
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    elementoAEliminar.Add(Consultas.ANEXO3_ANULAR_DETALLE & "'" & dgvanexo.Rows(dgvanexo.CurrentCell.RowIndex).Cells("CodigoCUPS").Value & "'," & SesionActual.idUsuario)
                    dtAnexo.Rows.RemoveAt(e.RowIndex)
                End If
            End If
        End If
    End Sub

    Private Sub btEnviarCorreos_Click(sender As Object, e As EventArgs) Handles btEnviarCorreos.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim correoConfigurado As Correo
            Dim listaCorreos As New List(Of Correo)
            listaCorreos = General.cargarInformacionCorreo("a30202pp09")
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
    Private Sub iniciarEnvioCorreo(ByRef pCorreo As Correo)
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
    Private Sub iniciarHilo(ByRef pCorreo As Correo)
        Try
            hilo = New System.Threading.Thread(AddressOf enviarCorreo)
            hilo.Start(pCorreo)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btBuscarEPROC_Click(sender As Object, e As EventArgs) Handles btBuscarEsp.Click
        Dim params As New List(Of String)
        params.Add(Constantes.VALOR_PREDETERMINADO)
        params.Add(Nothing)
        params.Add(Constantes.VALOR_PREDETERMINADO)
        params.Add(txtregistro.Text)
        params.Add(Nothing)
        General.buscarElemento(Consultas.AREA_SERVICIO_ANEXO3_LISTAR,
                             params,
                             AddressOf cargarArea,
                             TitulosForm.BUSQUEDA_AREA_SERVICIO,
                             False, 0, True)
    End Sub
    Private Sub cargarArea(pCodigo As Integer)
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(SesionActual.codigoEP)
        General.llenarTabla(Consultas.CARGA_AREA_SERVICIO, params, dt)
        areaTraslado = pCodigo
        If dt.Rows.Count > 0 Then
            textTraslado.Text = dt.Rows(0).Item("Descripción").ToString()
            btLimpiar.Visible = True
            btLimpiar.Enabled = True
        End If
    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        areaTraslado = Constantes.VALOR_PREDETERMINADO
        textTraslado.Clear()
        btLimpiar.Visible = False
    End Sub

    Private Sub enviarCorreo(ByVal correoConfigurado As Correo)
        correoConfigurado.asunto += "No."
        General.ConfigurarCorreo(correoConfigurado,
                                 Constantes.FORMULARIO.ANEXO3,
                                 "",
                                 emailEPS)
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
    Private Function generarReporte(ByVal correoConfigurado As Correo) As Boolean
        Dim rprte As New rptAnexo3
        Dim tbl As New Hashtable
        Dim ruta, area, nombreArchivo As String
        Dim nombreAnexo3 As String = "Anexo3_" & 3 & Constantes.FORMATO_PDF
        tbl = Nothing
        area = ConstantesHC.NOMBRE_PDF_ANEXO_3
        nombreArchivo = area & ConstantesHC.NOMBRE_PDF_SEPARADOR & txtorden.Text & ConstantesHC.EXTENSION_ARCHIVO_PDF
        ruta = IO.Path.GetTempPath() & Constantes.FORMULARIO.ANEXO3 & "\" & nombreAnexo3

        Try
            Funciones.getReporteNoFTP(rprte,
                                      "{VISTA_ANEXO3.N_Orden} = " & txtorden.Text & "",
                                      area,
                                      Constantes.FORMATO_PDF,
                                      tbl,
                                      If(ruta = "", Nothing, ruta),
                                      False)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If SesionActual.tienePermiso(PBuscar) Then
            BuscarAnexo3 = True
            General.buscarElemento(Consultas.BUSQUEDA_ANEXO3_CARGAR_REGISTRO & txtregistro.Text,
                                                     Nothing,
                                                     AddressOf cargarAnexo3,
                                                     TitulosForm.BUSQUEDA_ANEXO1,
                                                     False, 0, True)
            BuscarAnexo3 = False
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Sub cargarAnexo3(pcodigo As String)
        Using dt As New DataTable()
            Dim vSQL = Consultas.CARGAR_ANEXO3_CARGAR_REGISTRO & txtregistro.Text & ", " & pcodigo
            General.llenarTablaYdgv(vSQL, dt)
            Dim dw = dt(0)
            If BuscarAnexo3 = True Then
                txtorden.Text = pcodigo
                txtobservacion.Text = dw(1).ToString()
                Dim fechasoli As String = dw(3).ToString()
                fecha.Text = fechasoli.Remove(9, 0)
                txtcontador.Text = fechasoli.ToString.Substring(11)
                'txtservicio.Text = dw(4).ToString()
                Dim respuesta As Integer
                respuesta = dw(5).ToString()
                Select Case respuesta
                    Case Constantes.ANEXO3_CONSULTA_EXTERNA
                        drconsulta.Checked = True
                    Case Constantes.ANEXO3_URGENCIA
                        rdurgencia.Checked = True
                    Case Constantes.ANEXO3_HOSPITALARIO
                        rdhospitalizacion.Checked = True
                End Select
                respuesta = dw(6).ToString()
                Select Case respuesta
                    Case Constantes.ANEXO3_PRIORIDAD
                        rdprioridad.Checked = True
                    Case Constantes.ANEXO3_NO_PRIORIDAD
                        rdnoprioridad.Checked = True
                End Select
                respuesta = dw(7).ToString()
                Select Case respuesta
                    Case Constantes.ANEXO3_POSTERIOR
                        rdposterior.Checked = True
                    Case Constantes.ANEXO3_SERVICIO
                        rdservicios.Checked = True
                End Select

                txtobservacion.Text = dw(8).ToString()
                txtjustificacion.Text = dw(9).ToString()
                cargarArea(IIf(String.IsNullOrEmpty(dw(10).ToString()), Constantes.VALOR_PREDETERMINADO, dw(10).ToString()))
                cargardgv()

                bteditar.Enabled = True
                btanular.Enabled = True
                btcancelar.Enabled = True
                btguardar.Enabled = False
                btimprimir.Enabled = True
                btEnviarCorreos.Enabled = True
                DeshabilitarControlesManual()
            ElseIf busproced = True Then
                Dim bndra As Boolean
                For i = 0 To dgvanexo.Rows.Count - 1
                    If dgvanexo.Rows(i).Cells("Codigo CUPS").Value.ToString.Equals(dw(0).ToString) Then
                        bndra = True
                    End If
                Next
                If Not bndra Then
                    dgvanexo.Rows(dgvanexo.RowCount - 1).Cells("Codigo Cups").Value = dw(0).ToString
                    dgvanexo.Rows(dgvanexo.RowCount - 1).Cells("Servicio").Value = dw(1).ToString
                    dtAnexo.Rows.Add()
                    dgvanexo.Rows(dgvanexo.RowCount - 1).Cells("Codigo CUPS").Selected = True
                Else
                    MsgBox("El Código CUPS " + dgvanexo.Rows(dgvanexo.RowCount - 1).Cells("Codigo CUPS").Value.ToString + " ya existe en esta lista ", 64, "Atención")

                End If
            End If
            btcancelar.Enabled = False
        End Using
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            limpiarControles()
            nuevoRegistro()
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub

    Private Sub nuevoRegistro()
        dgvanexo.Columns(0).ReadOnly = True
        dgvanexo.Columns("CodigoCUPS").ReadOnly = True

        dgvanexo.Columns(5).ReadOnly = False
        HabilitarControlesManual()
        elementoAEliminar.Clear()
        btnuevo.Enabled = False
        btguardar.Enabled = True
        btcancelar.Enabled = True
        btbuscar.Enabled = False
        btimprimir.Enabled = False
        btanular.Enabled = False
        bteditar.Enabled = False
        btBuscarEsp.Enabled = True
        dtAnexo.Rows.Add()
        dtAnexo.Rows(0).Item("Inicio") = Funciones.Fecha(Constantes.FORMATO_FECHA)
        dtAnexo.Rows(0).Item("Fin") = Funciones.Fecha(Constantes.FORMATO_FECHA)
        dgvanexo.Columns("Dias").ReadOnly = True
        VerificarRegistro()
        textTraslado.ReadOnly = True
    End Sub

    Private Sub dgvanexo_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvanexo.CellEndEdit
        Dim fecha1, fecha2 As Date

        If dgvanexo.Rows(dgvanexo.CurrentCell.RowIndex).Cells("CodigoCUPS").Selected = True Then
            For i = 0 To dtAnexo.Rows.Count - 1
                If dtAnexo.Rows(i).Item("CodigoCUPS").ToString <> "" Then
                    VerificarCodigo()

                End If
            Next
        ElseIf e.ColumnIndex = 3 Or e.ColumnIndex = 4 Then
            For i = 0 To dtAnexo.Rows.Count - 1
                If dgvanexo.Rows(i).Cells(3).Value.ToString = "" Then
                    dgvanexo.Rows(i).Cells(5).Value = ""
                Else
                    fecha1 = CDate(dgvanexo.Rows(i).Cells(3).Value).Date
                    fecha2 = CDate(dgvanexo.Rows(i).Cells(4).Value).Date
                    dgvanexo.Rows(i).Cells(5).Value = DateDiff(DateInterval.Day, fecha1, fecha2) + 1
                    If fecha2.Date < fecha1.Date Then
                        MsgBox("La fecha final no puede ser menor a la final incial", MsgBoxStyle.Exclamation)
                        dgvanexo.Rows(i).Cells(3).Value = Today.Date
                        dgvanexo.Rows(i).Cells(4).Value = Today.Date
                        dgvanexo.Rows(i).Cells(5).Value = 1
                    End If
                End If
            Next
        End If
    End Sub
    Public Sub VerificarRegistro()
        Dim dt As New DataTable
        Dim contador As Integer
        General.llenarTablaYdgv(Consultas.ANEXO3_VERIFICAR_REGISTRO & txtregistro.Text.ToString, dt)
        contador = dt.Rows(0).Item("Registro").ToString
        txtcontador.Text = contador + 1
    End Sub

    Private Sub dgvanexo_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub dgvanexo_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvanexo.CellLeave
        If dgvanexo.Rows(dgvanexo.CurrentCell.RowIndex).Cells("Inicio").Selected = True Or dgvanexo.Rows(dgvanexo.CurrentCell.RowIndex).Cells("Inicio").Selected = True Then
            If IsDBNull(dgvanexo.Rows(dgvanexo.CurrentCell.RowIndex).Cells(1).Value) Then
                MsgBox("Por favor seleccione el procedimiento", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Public Sub iniciarForm(ByRef params As List(Of String))
        vParams = params
        txtregistro.Text = params(0)
        txtpaciente.Text = params(1)
        txtidentificacion.Text = params(2)
        txtcontrato.Text = params(3)
        VerificarRegistro()
        txttipoinforme.Text = params(4)
        txtCodigoArea.Text = params(5)
        Dim dtDatosPaciente As New DataTable
        Dim params2 As New List(Of String)
        params2.Add(txtregistro.Text)
        General.llenarTabla(ConsultasAsis.AREA_ADMISION_CARGAR, params2, dtDatosPaciente)
        txtservicio.Text = dtDatosPaciente.Rows(0).Item(0)
        If params.Count > 7 Then
            If IsNumeric(params(7)) Then
                cargarDatosAutomaticos(params(7))
            Else
                emailEPS = params(7)
            End If
        End If

        ShowDialog()
    End Sub

    Private Sub cargarDatosAutomaticos(pCodigo As Integer)
        establecer_tabla()
        txtCodigoRemision.Text = pCodigo
        Using dt As New DataTable()
            Dim vSQL = Consultas.CARGAR_ANEXO3_CARGAR_AUTO & pCodigo
            General.llenarTablaYdgv(vSQL, dt)
            If dt.Rows.Count > 0 Then
                Dim dw = dt(0)
                txtobservacion.Text = dw(0).ToString()
                txtjustificacion.Text = dw(1).ToString()
            End If

            rdhospitalizacion.Checked = True
            rdprioridad.Checked = True
            rdposterior.Checked = True
            cargarArea(txtCodigoArea.Text)

            If txtservicio.Text = textTraslado.Text Then
                textTraslado.Clear()
                areaTraslado = Constantes.VALOR_PREDETERMINADO
            End If
            cargardgvAutomatico()
            nuevoRegistro()
        End Using
    End Sub
End Class