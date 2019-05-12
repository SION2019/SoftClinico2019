Imports System.IO
Imports System.Threading
Public Class Form_resultado
    Public Property historiaClinica As Form_Historia_clinica
    Public Property imagenologia As Form_Imagenologia
    Dim objExamen As ExamenResultado
    Dim objExamenBLL As New ExamenResultadoBLL
    Dim reporteSegundoPlano As Thread
    Dim reporte As New ftp_reportes
    Dim activoAM, activoAF, vPDF, vImagenDCM As Boolean
    Dim permiso_general, pEditar,
        pAnular, pImagen, pPdf, pSubir As String
    Dim perG As New Buscar_Permisos_generales

    Private reporteParams As New ReporteParams
    Public Property formListaCita As FormListaPendienteCita
    Private Sub ocultarVisor()
        pdfArchivos.Visible = False
        controlDCM.Visible = False
        TamañoNormalToolStripMenuItem.Visible = False
    End Sub
    Private Sub btSubir_Click(sender As Object, e As EventArgs) Handles btSubir.Click
        If SesionActual.tienePermiso(pPdf) Then
            objExamenBLL.cargarPDF(pdfArchivos, openPdf, objExamen)
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub Form_resultado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        reporteParams.activoAM = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AM & "'")
        reporteParams.activoAF = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AF & "'")

        Try
            With dgvArchivos
                .Columns.Item(0).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item(0).DataPropertyName = "ruta"
                .Columns.Item(1).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns.Item(1).DataPropertyName = "nombreArchivo"
                .DataSource = objExamen.dtExamen
                .Columns("idArchivo").Visible = False
                .Columns("Archivo").Visible = False
                .Columns("dgquitar").DisplayIndex = 4
                .AutoGenerateColumns = False
            End With

            '--- Clono la estructura de la tabla examen 
            objExamen.dtExamenEliminados = objExamen.dtExamen.Clone

            controlDCM.DCMopenBtnEnabled = False
            controlDCM.DCMbestFitZoom = True
            txtNota.ReadOnly = False
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(pEditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then

                'If reporteParams.moduloTemporal <> Constantes.HC _
                If objExamen.codigoTipo = ConstantesHC.CODIGO_IMAGEN_DCM Then
                    If BuscarUsuarioReal(objExamen.tipoExam) = False Then
                        Return
                    End If
                End If
                General.deshabilitarBotones(ToolStrip1)
                General.deshabilitarControles(Me)
                controlDCM.Visible = vImagenDCM
                pdfArchivos.Visible = vPDF
                btSubir.Enabled = vPDF
                btImagen.Enabled = vImagenDCM
                btguardar.Enabled = True
                btcancelar.Enabled = True
                'If rbEditable.Checked = True Then
                txtNota.ReadOnly = False
                'Else
                '    rbEditable.Enabled = True
                'End If
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub dgvArchivos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArchivos.CellContentClick
        objExamenBLL.visualizar(GroupControlDCM, e.RowIndex, e.ColumnIndex, objExamen)
    End Sub

    Private Sub dgvArchivos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArchivos.CellDoubleClick
        If objExamen.dtExamen.Rows.Count > 0 And btguardar.Enabled = True Then
            Try
                If e.ColumnIndex = 0 Then
                    objExamenBLL.quitarResultadoDgv(e.RowIndex, objExamen)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub TamañoNormalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TamañoNormalToolStripMenuItem.Click
        objExamenBLL.visorImagenCompleta(GroupControlDCM, True)
        TamañoNormalToolStripMenuItem.Visible = False
        TamañoCompletoToolStripMenuItem.Visible = True
    End Sub

    Private Sub btImagen_Click(sender As Object, e As EventArgs) Handles btImagen.Click
        If SesionActual.tienePermiso(pImagen) Then
            For Each fila As DataRow In objExamen.cargarImagen(openPdf).Select
                objExamen.dtExamen.ImportRow(fila)
            Next
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        Dim params As New List(Of String)
        If SesionActual.tienePermiso(pAnular) Then
            If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Try
                    params.Add(CInt(objExamen.CodigoOrden))
                    params.Add(objExamen.CodigoProcedimiento)
                    params.Add(CInt(SesionActual.idUsuario))
                    params.Add(CInt(SesionActual.codigoEP))
                    params.Add(CInt(objExamen.editado))
                    params.Add(objExamen.procedencia)
                    General.ejecutarSQL(objExamen.sqlAnularRegistro, params)
                    If Not IsNothing(imagenologia) Then
                        imagenologia.cargarDatos()
                    End If
                    If Not IsNothing(historiaClinica) Then
                        historiaClinica.cargarOrdenMedica()
                    End If
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    Dispose()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.Yes Then
            Dispose()
        End If
    End Sub

    Private Sub TamañoCompletoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TamañoCompletoToolStripMenuItem.Click
        objExamenBLL.visorImagenCompleta(GroupControlDCM)
        TamañoNormalToolStripMenuItem.Visible = True
        TamañoCompletoToolStripMenuItem.Visible = False
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If String.IsNullOrWhiteSpace(txtNota.Text) And
            objExamen.codigoTipo = ConstantesHC.CODIGO_IMAGEN_DCM Then
            'rbEditable.Checked = True Then
            Exec.SavingMsg("Favor Digitar la observación", txtNota)
        ElseIf objExamen.dtExamen.Rows.Count = 0 And reporteParams.moduloTemporal = Constantes.HC Then
            MsgBox("Debe agregar por lo menos un Soporte de algún Examén", MsgBoxStyle.Exclamation)
            dgvArchivos.Focus()
        ElseIf objExamen.dtExamen.Rows.Count = 0 And reporteParams.moduloTemporal = Constantes.LB Then
            MsgBox("Debe agregar por lo menos un Soporte de algún Examén", MsgBoxStyle.Exclamation)
            dgvArchivos.Focus()
        Else
            guardarRegistro()
        End If
    End Sub
    Private Sub guardarRegistro()
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Try
                cargarObjeto()
                objExamen.guardarRegistro()
                General.deshabilitarBotones(ToolStrip1)
                General.deshabilitarControles(Me)
                bteditar.Enabled = True
                btanular.Enabled = True
                validacionSegundoPlano()
                objExamen.cargarImagenDicom()
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            btimprimir.Enabled = True
        End If
    End Sub

    Public Function cargarResultado(codigoOrden As Integer, codigoProcedimiento As String,
                               nombreProcedimiento As String,
                               modulo As String,
                               codigoTipo As Integer,
                               tipoExam As String, Optional registro As Integer = 0,
                                Optional procedencia As Integer = 0) As Boolean

        Dim verificarUsuario As Boolean

        cargarPermisos(If(modulo = Constantes.DC, Constantes.HC, modulo))
        modulo = If(modulo <> Constantes.CODIGO_MENU_AUDM AndAlso modulo <> Constantes.CODIGO_MENU_AUDF, Constantes.HC, modulo)
        ocultarVisor()
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Groupnota)
        Try

            objExamen = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_IMAGENOLOGIA & modulo)
            cargarVariableNecesarias(codigoProcedimiento, codigoOrden, codigoTipo, modulo)

            objExamen.nombreArchivo = registro & codigoOrden & codigoProcedimiento ' armo el nombre del archivo de audio, para las grabaciones

            txtCodigo.Text = codigoOrden
            txtCodigoExamen.Text = codigoProcedimiento
            txtExamen.Text = nombreProcedimiento
            objExamen.tipoExam = tipoExam
            objExamen.nRegistro = registro
            objExamen.procedencia = procedencia

            objExamen.cargarResultado()

            txtNota.Text = objExamen.observacion
            vImagenDCM = objExamen.muestraVisorDicom
            vPDF = objExamen.muestraVisorPDF

            controlDCM.Visible = vImagenDCM
            pdfArchivos.Visible = vPDF

            validarBotones()

            General.deshabilitarControles(panelGrabadora)

            '---- valida si ya hay registro existente 

            If objExamen.verificarRegistroGuardado = False Then

                If objExamen.codigoTipo = ConstantesHC.CODIGO_IMAGEN_DCM Or
                    tipoExam = Constantes.EXAM_LAB Then
                    verificarUsuario = BuscarUsuarioReal(tipoExam)
                    If verificarUsuario = False Then
                        Return verificarUsuario
                    End If
                Else
                    verificarUsuario = True
                End If
                btGrabar.Enabled = True
                txtNota.ReadOnly = True
            Else
                verificarUsuario = True

                If objExamen.existeAudio = True Then
                    File.WriteAllBytes(System.IO.Path.GetTempPath & ConstantesHC.NOMBRE_PDF_SEPARADOR4 & objExamen.nombreArchivo &
                                            ConstantesHC.EXTENSION_ARCHIVO_MP3, objExamen.archivoAudio)
                    btReproducir.Enabled = True
                End If
                If Not String.IsNullOrEmpty(objExamen.observacion) Then
                    'rbEditable.Checked = True
                End If
                'rbEditable.Enabled = False
            End If

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

        Return verificarUsuario

    End Function
    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Cursor = Cursors.WaitCursor
        Try
            objExamen.imprimir()
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub Form_resultado_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            My.Computer.Audio.Stop()
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub cargarVariableNecesarias(codigoProcedimiento As String,
                                         codigoOrden As Integer,
                                         codigoTipo As Integer,
                                         modulo As String)
        Label1.Text = objExamen.titulo
        objExamen.usuario = SesionActual.idUsuario
        objExamen.idEmpresa = SesionActual.codigoEP
        objExamen.CodigoOrden = codigoOrden
        objExamen.CodigoProcedimiento = codigoProcedimiento
        objExamen.codigoTipo = codigoTipo
        reporteParams.moduloTemporal = modulo
    End Sub

    Private Sub dgvArchivos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArchivos.CellEnter
        If dgvArchivos.Focused = True Then
            objExamenBLL.visualizar(GroupControlDCM, e.RowIndex, e.ColumnIndex, objExamen)
        End If
    End Sub

    Private Sub validarBotones()
        If objExamen.verificarRegistroGuardado = True Then
            objExamen.cargarImagenDicom()
            bteditar.Enabled = True
            btanular.Enabled = True
            btSubir.Enabled = False
            btImagen.Enabled = False
            '--- si el registro es una imagen diagnostica se habilita el boton de imprimir 
            If objExamen.codigoTipo = ConstantesHC.CODIGO_IMAGEN_DCM Then
                btimprimir.Enabled = True
            End If
            '--------------------------------------------------------------------------
        Else
            If SesionActual.tienePermiso(pSubir) Then
                btSubir.Enabled = vPDF
                btImagen.Enabled = vImagenDCM
                txtNota.ReadOnly = False
                btguardar.Enabled = True
                btcancelar.Enabled = True
            Else
                btSubir.Enabled = False
                btImagen.Enabled = False
            End If
            btimprimir.Enabled = False
        End If
    End Sub

    Private Sub cargarPermisos(modulo As String)
        permiso_general = perG.buscarPermisoGeneral(Form_Imagenologia.Name, modulo)
        pSubir = permiso_general & "pp" & "02"
        pImagen = permiso_general & "pp" & "03"
        pPdf = permiso_general & "pp" & "04"
        pEditar = permiso_general & "pp" & "05"
        pAnular = permiso_general & "pp" & "06"
    End Sub
    Private Function BuscarUsuarioReal(codigoTipo As String) As Boolean
        Dim verificarUsuarioReal As Boolean = True
        Dim verificarTipoExamen As Integer = Nothing
        Dim tbl As DataRow = Nothing
        Dim params As New List(Of String)

        If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
            If codigoTipo = Constantes.EXAM_LAB Then
                params.Add(Constantes.LISTA_CARGO_EXAMEN_LAB)
            Else
                params.Add(Constantes.LISTA_CARGO_IMAGENOLOGIA)
            End If
            params.Add(SesionActual.idEmpresa)
            Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True)
            tbl = formBusqueda.rowResultados
            If tbl IsNot Nothing Then
                objExamen.usuarioReal = tbl(0)
            Else
                MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                verificarUsuarioReal = False
            End If
        End If
        Return verificarUsuarioReal
    End Function
    'Private Sub rbEditable_Click(sender As Object, e As EventArgs)
    '    If rbEditable.Checked = True Then
    '        txtNota.ReadOnly = False
    '    Else
    '        txtNota.ReadOnly = True
    '        txtNota.Clear()
    '    End If
    'End Sub
    Private Sub cargarObjeto()
        objExamen.usuarioReal = IIf(objExamen.usuarioReal = 0, SesionActual.idUsuario, objExamen.usuarioReal)
        objExamen.observacion = txtNota.Text
        objExamen.contador = Constantes.TERMINADO
    End Sub

    Private Sub btPlantilla_Click(sender As Object, e As EventArgs) Handles btPlantilla.Click
        Dim formPlantilla As FormPlantillaArchivo
        If SesionActual.tienePermiso(pPdf) Then
            formPlantilla = New FormPlantillaArchivo
            formPlantilla.formResultado = Me
            formPlantilla.cargarProcedimiento(txtCodigoExamen.Text, txtExamen.Text)
            formPlantilla.cargarPaciente(txtCodigo.Text)
            formPlantilla.ShowDialog()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub validacionSegundoPlano()
        If Not IsNothing(imagenologia) Then
            imagenologia.cargarDatos()
        End If
        If Not IsNothing(historiaClinica) Then
            historiaClinica.cargarOrdenMedica()
        End If
        If Not IsNothing(formListaCita) Then
            formListaCita.cargarCitasPendiente()
        End If
        ' If objExamen.codigoTipo = ConstantesHC.CODIGO_IMAGEN_DCM Then
        'guardarSegundoPlano()
        ' End If
    End Sub
    Private Sub btEliminar_Click(sender As Object, e As EventArgs) Handles btEliminar.Click
        General.deshabilitarControles(panelGrabadora)
        objExamen.archivoAudio = Nothing
        btGrabar.Enabled = True
    End Sub
    Private Sub btPausa_Click(sender As Object, e As EventArgs) Handles btPausa.Click
        My.Computer.Audio.Stop()
        General.deshabilitarControles(panelGrabadora)
        btReproducir.Enabled = True
        btEliminar.Enabled = True
    End Sub
    Private Sub btGrabar_Click_1(sender As Object, e As EventArgs) Handles btGrabar.Click
        objExamenBLL.llamarGrabadora()
        General.deshabilitarControles(panelGrabadora)
        btDetener.Enabled = True
    End Sub
    Private Sub btDetener_Click(sender As Object, e As EventArgs) Handles btDetener.Click
        objExamen.archivoAudio = File.ReadAllBytes(objExamenBLL.guardarArchivo(objExamen.nombreArchivo))
        General.deshabilitarControles(panelGrabadora)
        btReproducir.Enabled = True
        btEliminar.Enabled = True
    End Sub
    Private Sub btReproducir_Click(sender As Object, e As EventArgs) Handles btReproducir.Click
        objExamenBLL.reproducirAudio(objExamen.nombreArchivo)
        General.deshabilitarControles(panelGrabadora)
        btPausa.Enabled = True
    End Sub
    Private Sub descargarImagenDicom()
        Dim contenedorDicom As New AxezDICOMax.AxezDICOMX
        If objExamen.dtExamen.Rows.Count > 0 Then
        End If
    End Sub
    Public Sub cargarPlantilla(ruta As String, nombre As String, imagen As Byte())
        objExamen.dtExamen.Rows.Add()
        objExamen.dtExamen.Rows(objExamen.dtExamen.Rows.Count - 1).Item("ruta") = ruta
        objExamen.dtExamen.Rows(objExamen.dtExamen.Rows.Count - 1).Item("NombreArchivo") = nombre
        objExamen.dtExamen.Rows(objExamen.dtExamen.Rows.Count - 1).Item("Archivo") = imagen
    End Sub
End Class