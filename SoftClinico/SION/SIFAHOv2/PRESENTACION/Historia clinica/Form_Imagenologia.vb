Imports System.Threading
Public Class Form_Imagenologia
    Dim objImagenologia As EstudioImagenologia
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general As String
    Dim moduloAuxiliar As String
    Dim moduloPermiso As String
    Shared hilo As Thread
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Public Sub cargarNotificacion(drFila As DataRow)
        dtFechaInicio.Value = drFila.Item("Fecha")
        dtFechaInicio.Value = drFila.Item("Fecha")
        busquedaPaciente.Text = drFila.Item("Nombre")
        If comboAreaServicio.ValueMember <> "" Then
            cargarDatos()
        End If
    End Sub
    Private Sub ocultarprocedencia()
        If SesionActual.idEmpresa <> Constantes.UCI Then
            GbProcedencia.Visible = False
        End If
    End Sub
    Private Sub Form_Imagenologia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        moduloPermiso = If(Tag.modulo = Constantes.CODIGO_MENU_IMAGENOLOGIA, Constantes.CODIGO_MENU_LABORATORIO, Tag.Modulo)

        objImagenologia = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_ESTUDIO_IMAG & moduloPermiso)

        ocultarprocedencia()

        If String.IsNullOrEmpty(objImagenologia.modulo) Then
            objImagenologia.modulo = Tag.modulo
        End If

        objImagenologia.tituloFormulario(Tag.modulo)
        Label1.Text = objImagenologia.titulo

        Try
            enlazarDatatableGrilla()
            establecerPermisos()
            cargarCombo()
            cargarDatos()
            'dgvimagen.Columns("dgImagen").Visible = (Tag.modulo = Constantes.CODIGO_MENU_IMAGENOLOGIA)
            dgvimagen.Columns("dgAbrirAtencion").Visible = (Tag.modulo = Constantes.CODIGO_MENU_IMAGENOLOGIA)
            dgvimagen.Columns("Abrirlaboratorio").Visible = (Tag.modulo = Constantes.CODIGO_MENU_LABORATORIO)

            If selpendiente.Checked = True Then
                dgvimagen.Columns("dgImprimir").Visible = False
            Else
                dgvimagen.Columns("dgImprimir").Visible = True
            End If

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub
    Private Sub convertirCeldas()
        Dim celdaImagen, celdaImagen2, celdaImagen3 As DataGridViewImageCell
        For fila = 0 To objImagenologia.dtImagenologia.Rows.Count - 1

            celdaImagen = New DataGridViewImageCell
            celdaImagen2 = New DataGridViewImageCell
            celdaImagen3 = New DataGridViewImageCell

            dgvimagen.Rows(fila).Cells(11) = celdaImagen
            dgvimagen.Rows(fila).Cells(12) = celdaImagen2
            dgvimagen.Rows(fila).Cells(13) = celdaImagen3
        Next
    End Sub
    Private Sub cargarCombo()
        Dim moduloAreaServicio As String
        If objImagenologia.modulo = Constantes.AM Or objImagenologia.modulo = Constantes.AF Then
            moduloAreaServicio = Constantes.HC
        Else
            moduloAreaServicio = objImagenologia.modulo
        End If

        General.cargarCombo(Consultas.AREA_SERVICIO_LISTAR_CONTRATO & "" & SesionActual.codigoEP & ",'" &
                                          moduloAreaServicio &
                                          "','" & Constantes.VALOR_PREDETERMINADO & "',''", "Descripción", "Código", comboAreaServicio)
        Dim dtNuevo As DataTable
        dtNuevo = comboAreaServicio.DataSource.copy
        dtNuevo.Rows(0).Item(1) = "TODOS"
        comboAreaServicio.DataSource = dtNuevo
    End Sub
    Private Sub establecerPermisos()
        permiso_general = perG.buscarPermisoGeneral(Name, objImagenologia.modulo)
        objImagenologia.pVer = permiso_general & "pp" & "01"
        objImagenologia.pPendiente = permiso_general & "pp" & "07"
        objImagenologia.pRealizado = permiso_general & "pp" & "08"
        objImagenologia.pEnvioCorreo = permiso_general & "pp" & "09"

        If SesionActual.tienePermiso(objImagenologia.pRealizado) Then
            selrealizado.Visible = True
            selrealizado.Checked = True
            comboAreaServicio.Enabled = True
            dtFechaInicio.Enabled = True
            dtFechaFin.Enabled = True
        End If
        If SesionActual.tienePermiso(objImagenologia.pPendiente) Then
            selpendiente.Visible = True
            selpendiente.Checked = True
            comboAreaServicio.Enabled = True
            dtFechaInicio.Enabled = True
            dtFechaFin.Enabled = True
        End If
    End Sub
    Private Sub comboAreaServicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboAreaServicio.SelectedIndexChanged
        cargarDatos()
    End Sub

    Private Sub desde_ValueChanged(sender As Object, e As EventArgs) Handles dtFechaInicio.ValueChanged
        cargarDatos()
    End Sub
    Private Sub Form_Imagenologia_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub hasta_ValueChanged(sender As Object, e As EventArgs) Handles dtFechaFin.ValueChanged
        cargarDatos()
    End Sub

    Private Sub busquedaPaciente_TextChanged(sender As Object, e As EventArgs) Handles busquedaPaciente.TextChanged
        cargarDatos()
    End Sub

    Private Sub selpendiente_CheckedChanged(sender As Object, e As EventArgs) Handles selpendiente.CheckedChanged
        cargarDatos()
    End Sub

    Private Sub selrealizado_CheckedChanged(sender As Object, e As EventArgs) Handles selrealizado.CheckedChanged
        cargarDatos()
    End Sub

    Private Sub dgvimagen_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvimagen.CellContentClick
        Dim respuesta As Boolean
        If SesionActual.tienePermiso(objImagenologia.pVer) Then
            If objImagenologia.dtImagenologia.Rows.Count > 0 Then
                If e.ColumnIndex = dgvimagen.Columns("dgAbrirAtencion").Index Then
                    Dim abrirAtencion As New FormAtencionLaboratorio
                    moduloAuxiliar = moduloPermiso
                    abrirAtencion.cargarDatos(moduloAuxiliar, dgvimagen.Rows(dgvimagen.CurrentCell.RowIndex).Cells("dgcodigoorden").Value)
                    FormPrincipal.Cursor = Cursors.WaitCursor
                    abrirAtencion.ShowDialog()
                    If abrirAtencion.WindowState = FormWindowState.Minimized Then
                        abrirAtencion.WindowState = FormWindowState.Normal
                    End If
                    FormPrincipal.Cursor = Cursors.Default
                ElseIf e.ColumnIndex = dgvimagen.Columns("dgImagen").Index Then
                    If Tag.modulo = Constantes.CODIGO_MENU_LABORATORIO Then
                        Try
                            Dim paraclinicoLab As New AtencionParaclinicoLaboratorio
                            paraclinicoLab.codigoOrden = dgvimagen.Rows(dgvimagen.CurrentCell.RowIndex).Cells("dgCodigoOrden").Value
                            paraclinicoLab.codigoProcedimiento = dgvimagen.Rows(dgvimagen.CurrentCell.RowIndex).Cells("dgCodigoProcedimiento").Value
                            paraclinicoLab.cargarNombrePDF()
                            paraclinicoLab.areaExamen = "A"
                            paraclinicoLab.imprimir()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    Else
                        Dim form As New Form_resultado
                        respuesta = form.cargarResultado(dgvimagen.Rows(e.RowIndex).Cells("dgCodigoorden").Value,
                                             dgvimagen.Rows(e.RowIndex).Cells("dgCodigoProcedimiento").Value,
                                              objImagenologia.dtImagenologia.Rows(e.RowIndex).Item("Descripcion"), objImagenologia.modulo,
                                              If(dgvimagen.Rows(e.RowIndex).Cells("dgTipoExamen").Value = Constantes.EXAM_LAB,
                                                         ConstantesHC.CODIGO_PDF, ConstantesHC.CODIGO_IMAGEN_DCM),
                                             dgvimagen.Rows(e.RowIndex).Cells("dgTipoExamen").Value,, objImagenologia.procedencia)

                        If respuesta = True Then
                            form.MdiParent = FormPrincipal
                            form.imagenologia = Me
                            form.Show()
                        End If
                    End If

                ElseIf e.ColumnIndex = dgvimagen.Columns("abrirlaboratorio").Index Then
                    Dim Form As New FormExamenParaclinicosNuevo
                    Form.cargarPaciente(dgvimagen.Rows(e.RowIndex).Cells("dgCodigoorden").Value,
                                               dgvimagen.Rows(e.RowIndex).Cells("dgCodigoProcedimiento").Value,
                                               objImagenologia.modulo,
                                               objImagenologia.dtImagenologia.Rows(e.RowIndex).Item("Resultado"),
                                               dgvimagen.Rows(e.RowIndex).Cells("dgTipoExamen").Value)
                    Form.ShowDialog()

                ElseIf e.ColumnIndex = dgvimagen.Columns("dgImprimir").Index Then
                    moduloAuxiliar = moduloPermiso
                    imprimirSolicitud()
                End If
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Public Sub cargarDatos()
        Dim params As New List(Of String)
        If comboAreaServicio.ValueMember <> String.Empty Then
            If selrealizado.Checked = True Then

                dgvimagen.Columns("dgImagen").Visible = True
                dgvimagen.Columns("dgImprimir").Visible = True
                objImagenologia.existencia = 1
            Else
                If (Tag.modulo = Constantes.CODIGO_MENU_LABORATORIO) Then
                    dgvimagen.Columns("dgImagen").Visible = False
                End If
                dgvimagen.Columns("dgImprimir").Visible = False
                objImagenologia.existencia = 0
            End If
            objImagenologia.cargarDatos(CDate(dtFechaInicio.Value).Date,
                                        CDate(dtFechaFin.Value).Date,
                                        If(comboAreaServicio.SelectedValue = Constantes.VALOR_PREDETERMINADO, Nothing, comboAreaServicio.SelectedValue),
                                        busquedaPaciente.Text,
                                        SesionActual.codigoEP)
            validarImagen()
            dgvimagen.DataSource = objImagenologia.dtImagenologia
            npaciente.Text = objImagenologia.dtImagenologia.Rows.Count
        End If
    End Sub
    Private Sub validarImagen()
        For i = 0 To dgvimagen.Rows.Count - 1
            dgvimagen.Rows(i).Cells("dgImprimir").Value = My.Resources.Printermini_icon
            If selrealizado.Checked = True Then
                dgvimagen.Rows(i).Cells("dgImagen").Value = My.Resources.OK
                If objImagenologia.dtImagenologia.Columns.Contains("correo") AndAlso Not IsDBNull(objImagenologia.dtImagenologia.Rows(i).Item("correo")) Then
                    dgvimagen.Rows(i).Cells("dgEnviar").Value = My.Resources.Mail_icon__1_
                Else
                    dgvimagen.Rows(i).Cells("dgEnviar").Value = My.Resources._new
                End If
            Else
                dgvimagen.Rows(i).Cells("dgImagen").Value = My.Resources._new
                dgvimagen.Rows(i).Cells("dgEnviar").Value = My.Resources._new
            End If
        Next
    End Sub
    Public Sub imprimirSolicitud()
        Cursor = Cursors.WaitCursor
        Try
            objImagenologia.modulo = moduloAuxiliar
            objImagenologia.tipo = dgvimagen.Rows(dgvimagen.CurrentCell.RowIndex).Cells("dgTipoExamen").Value
            If objImagenologia.tipo = Constantes.HISTORIA_CLIN Then
                objImagenologia.nRegistro = dgvimagen.Rows(dgvimagen.CurrentCell.RowIndex).Cells("dgRegistro").Value
            Else
                objImagenologia.nRegistro = dgvimagen.Rows(dgvimagen.CurrentCell.RowIndex).Cells("dgCodigoOrden").Value
            End If
            objImagenologia.CodigoProcedimiento = dgvimagen.Rows(dgvimagen.CurrentCell.RowIndex).Cells("dgCodigoProcedimiento").Value
            objImagenologia.imprimirReporte()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub enlazarDatatableGrilla()
        With dgvimagen
            .Columns("dgRegistro").DataPropertyName = "Registro"
            .Columns("dgCodigoOrden").DataPropertyName = "Codigo_Orden"
            .Columns("dgCodigoProcedimiento").DataPropertyName = "Codigo_Procedimiento"
            .Columns("dgCodigoEspecialidad").DataPropertyName = "Codigo_Especialidad"
            .Columns("dgTipoExamen").DataPropertyName = "TipoExamen"
            .Columns("dgNombre").DataPropertyName = "paciente"
            .Columns("dgNombre").ReadOnly = True
            .Columns("dgEPS").DataPropertyName = "eps"
            .Columns("dgEPS").ReadOnly = True
            .Columns("dgDescripcion").DataPropertyName = "descripcion"
            .Columns("dgDescripcion").ReadOnly = True
            .Columns("dgArea").DataPropertyName = "area_servicio"
            .Columns("dgArea").ReadOnly = True
            .Columns("dgFecha").DataPropertyName = "fecha"
            .Columns("dgFecha").ReadOnly = True
            .Columns("dgAbrirAtencion").DataPropertyName = "Abrir_Atencion"
            .Columns("dgImagen").DataPropertyName = "Abrir_Resultado"
            .Columns("Abrirlaboratorio").DataPropertyName = "Abrir_Laboratorio"
            .Columns("dgImprimir").DataPropertyName = "Imprimir"
            .Columns("dgEnviar").DataPropertyName = "Enviar"
            .DataSource = objImagenologia.dtImagenologia
            .AutoGenerateColumns = False
        End With
    End Sub
    Private Sub dgvimagen_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvimagen.CellClick
        Dim correoConfigurado = New Correo
        If e.ColumnIndex = 14 Then
            If SesionActual.tienePermiso(objImagenologia.pEnvioCorreo) Then
                If selrealizado.Checked = True Then
                    If Not IsDBNull(objImagenologia.dtImagenologia.Rows(dgvimagen.CurrentCell.RowIndex).Item("correo")) Then
                        Dim listaCorreos As New List(Of Correo)
                        listaCorreos = General.cargarInformacionCorreo(Me.Tag.codigo)
                        If Not IsNothing(listaCorreos) Then
                            correoConfigurado = New Correo
                            correoConfigurado = listaCorreos.First()
                            iniciarEnvioCorreo(correoConfigurado)
                        Else
                            MsgBox("Aún no tiene configurado ningún correo para este formulario!", MsgBoxStyle.Exclamation)
                        End If
                    End If
                Else
                    MsgBox("Aún no tiene resultado!", MsgBoxStyle.Exclamation)
                End If
            Else
                MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            End If
        End If
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
    Private Sub enviarCorreo(ByVal correoConfigurado As Correo)
        General.ConfigurarCorreo(correoConfigurado,
                                  Constantes.FORMULARIO.RESULTADO,
                                  "Se adjunto el Resultado de Laboratorio del codigo de atención no. " &
                                  dgvimagen.Rows(dgvimagen.CurrentCell.RowIndex).Cells("dgCodigoOrden").Value,
                                  objImagenologia.dtImagenologia.Rows(dgvimagen.CurrentCell.RowIndex).Item("correo"))
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
        Dim nombreResultadoreporte As String = "Resultado_" & dgvimagen.Rows(dgvimagen.CurrentCell.RowIndex).Cells("dgCodigoOrden").Value & Constantes.FORMATO_PDF
        Dim campoVista As String = Nothing
        Dim cadena As String = Nothing
        Dim rprte As ReportClass = Nothing
        Try
            Dim tbl As New Hashtable
            If dgvimagen.Rows(dgvimagen.CurrentCell.RowIndex).Cells("dgTipoExamen").Value = Constantes.ATENCION_LAB Then
                rprte = New rptResultadoAtencion
                cadena = "{VISTA_RESULTADO_PARACLINICO_ATENCION.Codigo_Orden} = " &
                          dgvimagen.Rows(dgvimagen.CurrentCell.RowIndex).Cells("dgCodigoOrden").Value &
                          " And {VISTA_RESULTADO_PARACLINICO_ATENCION.Codigo_Procedimiento}='" &
                          dgvimagen.Rows(dgvimagen.CurrentCell.RowIndex).Cells("dgCodigoProcedimiento").Value &
                          "' AND {VISTA_RESULTADO_PARACLINICO_ATENCION.Modulo}= 4"
            ElseIf dgvimagen.Rows(dgvimagen.CurrentCell.RowIndex).Cells("dgTipoExamen").Value = Constantes.EXAM_LAB Then
                campoVista = "Laboratorio"
                rprte = New rptExamenParaclinicoAtencion
                tbl.Add("@Codigo_Orden", dgvimagen.Rows(dgvimagen.CurrentCell.RowIndex).Cells("dgCodigoOrden").Value)
                tbl.Add("@Codigo_Procedimiento", dgvimagen.Rows(dgvimagen.CurrentCell.RowIndex).Cells("dgCodigoProcedimiento").Value)
                tbl.Add("@Tipo_Examen", Constantes.EXAM_LAB)
                cadena = " {VISTA_PARACLINICOS_RESULTADO_ATENCION.Codigo_Orden}=" &
                                                 dgvimagen.Rows(dgvimagen.CurrentCell.RowIndex).Cells("dgCodigoOrden").Value &
                                                 " AND {VISTA_PARACLINICOS_RESULTADO_ATENCION." & campoVista & "}='" &
                                                 dgvimagen.Rows(dgvimagen.CurrentCell.RowIndex).Cells("dgDescripcion").Value &
                                                 "' AND {VISTA_PARACLINICOS_RESULTADO_ATENCION.MODULO} = 4"
            End If
            Return Funciones.getReporteNoFTP(rprte, cadena,
                                             campoVista,
                                             Constantes.FORMATO_PDF,
                                             tbl,
                                             correoConfigurado.rutaArchivo & "\" & nombreResultadoreporte,
                                             False)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub rbExterno_CheckedChanged(sender As Object, e As EventArgs) Handles rbExterno.CheckedChanged
        If Not IsNothing(objImagenologia) Then
            objImagenologia.procedencia = 1
            cargarDatos()
        End If
    End Sub

    Private Sub rbInterno_CheckedChanged(sender As Object, e As EventArgs) Handles rbInterno.CheckedChanged
        If Not IsNothing(objImagenologia) Then
            objImagenologia.procedencia = 0
            cargarDatos()
        End If
    End Sub
End Class