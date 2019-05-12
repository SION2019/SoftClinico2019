Imports System.Threading
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class Form_ecocardiograma
    Dim reporteSegundoPlano As Thread
    Dim reporte As New ftp_reportes
    Dim activoAM, activoAF As Boolean
    Dim objEcocardiograma As Eco
    Dim usuarioActual, nRegistro, codigoTipo, moduloTemporal As String
    Dim codigoTemporal As String = String.Empty
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, Pnuevo, Peditar, Panular, PBuscar As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub colorDeshabilitarControl()
        Rtdescripcion.BackColor = Control.DefaultBackColor
        Rtconclusiones.BackColor = Control.DefaultBackColor
    End Sub
    Private Sub colorHabilitarControl()
        Rtdescripcion.BackColor = Color.White
        Rtconclusiones.BackColor = Color.White
    End Sub
    Private Sub ocultarPestañas()
        '----oculta las pestaña--
        TabPage1.Parent = Nothing
        TabPage2.Parent = Nothing
        TabPage3.Parent = Nothing
        TabPage4.Parent = Nothing
        '--------------------------
    End Sub
    Private Sub visiblePestañasEco(Codigo As Integer)
        ocultarPestañas()
        Select Case Codigo
            Case Constantes.CODIGO_ECOCARDIOGRAMA
                TabPage1.Parent = TabControl1
                TabPage2.Parent = TabControl1
                TabPage3.Parent = TabControl1
                TabPage4.Parent = TabControl1
            Case Constantes.CODIGO_ECO_ESTRES
                TabPage2.Parent = TabControl1
        End Select
    End Sub
    Private Sub validarCamposGrilla()
        With dgvparametros
            .Columns("dgmedicion").ReadOnly = True
            .Columns("dgvalorespPacientes").ReadOnly = False
            .Columns("dgvaloresNormales").ReadOnly = False
        End With
    End Sub
    Private Sub validarDgv()
        With dgvparametros
            .ReadOnly = False
            .Columns.Item("dgcodigo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgcodigo").DataPropertyName = Constantes.CODIGO_PARAMETRO
            .Columns.Item("dgmedicion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgmedicion").DataPropertyName = Constantes.MEDICION
            .Columns.Item("dgvalorespPacientes").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgvalorespPacientes").DataPropertyName = Constantes.VALORES_PACIENTE
            .Columns.Item("dgvaloresNormales").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgvaloresNormales").DataPropertyName = Constantes.VALORES_NORMALES
        End With
    End Sub
    Private Sub Form_ecocardiograma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        If String.IsNullOrEmpty(moduloTemporal) Then
            moduloTemporal = Tag.modulo
        End If
        objEcocardiograma = GeneralHC.fabricaHC.crear(Constantes.CODIGO_ECO & Tag.modulo)
        objEcocardiograma.codigoMenu = Tag.codigo
        objEcocardiograma.instanciaObjeto(Tag.modulo)
        cargarPermisos()
        Label1.Text = objEcocardiograma.validarFormulario()
        objEcocardiograma.usuario = SesionActual.idUsuario
        objEcocardiograma.idEmpresa = SesionActual.codigoEP
        activoAM = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AM & "'")
        activoAF = General.getEstadoVF(Consultas.MODULO_VERIFICAR & SesionActual.codigoEP & ",'" & Constantes.AF & "'")
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        ocultarPestañas()
        btnuevo.Enabled = True
        btbuscar.Enabled = True
        validarDgv()
        '-------------------------------------------------------------------------
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        If SesionActual.tienePermiso(Pnuevo) Then
            If SesionActual.tienePermiso(Constantes.OPCION_ESPECIAL) Then
                Dim tbl As DataRow = Nothing
                Dim params As New List(Of String)
                params.Add(Constantes.LISTA_CARGO_ORDEN_MEDICA)
                params.Add(SesionActual.idEmpresa)
                Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(Consultas.BUSQUEDA_EMPLEADO_HC, params, TitulosForm.BUSQUEDA_EMPLEADO_HC, True)
                tbl = formBusqueda.rowResultados
                If tbl IsNot Nothing Then
                    objEcocardiograma.usuarioReal = tbl(0)
                Else
                    MsgBox(Mensajes.SELECCIONE_LISTADO_EMPLEADO, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            Else
                objEcocardiograma.usuarioReal = SesionActual.idUsuario
            End If
            General.limpiarControles(Me)
            colorHabilitarControl()
            ocultarPestañas()
            codigoTemporal = String.Empty
            btbuscarPaciente.Enabled = True
            iniciarForm()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.Yes Then
            General.deshabilitarBotones(ToolStrip1)
            General.deshabilitarControles(Me)
            General.limpiarControles(Me)
            colorDeshabilitarControl()
            ocultarPestañas()
            codigoTemporal = String.Empty
            btnuevo.Enabled = True
            btbuscar.Enabled = True
        End If
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Cursor = Cursors.WaitCursor
        Try

            objEcocardiograma.MostrarReporte()
            objEcocardiograma.imprimir()

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.Yes Then
                colorHabilitarControl()
                iniciarForm()
            End If
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub iniciarForm()
        General.deshabilitarBotones(ToolStrip1)
        General.habilitarControles(TabControl1)
        validarCamposGrilla()
        dtfecha.Enabled = True
        btguardar.Enabled = True
        btcancelar.Enabled = True
        Button1.Enabled = True
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        params.Add(objEcocardiograma.codigoTipoEco)
        params.Add(Nothing)

        General.buscarItem(objEcocardiograma.sqlBuscarRegistro,
                               params,
                               AddressOf cargarRegistros,
                               TitulosForm.BUSQUEDA_ECOCARDIOGRAMA,
                               False, True, Constantes.TAMANO_MEDIANO)
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        dgvparametros.EndEdit()
        If condicionesGuardar() = True Then
            guardarEcos()
        End If
    End Sub

    Private Function condicionesGuardar() As Boolean
        Dim validar As Boolean = False
        If txtregistro.Text = "" Then
            MsgBox("¡ Por favor seleccione el paciente!", MsgBoxStyle.Exclamation)
            txtidentificacion.Focus()
        ElseIf Rtdescripcion.Text = "" Then
            MsgBox("¡ Por favor digite la descripcion del examen!", MsgBoxStyle.Exclamation)
            Rtdescripcion.Focus()
        ElseIf objEcocardiograma.codigoTipoEco = Constantes.CODIGO_ECOCARDIOGRAMA _
            And objEcocardiograma.objEcocardiograma.dtParametro.Select("Valores_Pacientes <> ''").Count = 0 Then
            MsgBox("¡ Por favor digite por lo menos un valor en algun parametro!", MsgBoxStyle.Exclamation)
            dgvparametros.Focus()
        Else
            validar = True
        End If
        Return validar
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cargarDocumento()
    End Sub
    Public Overridable Sub cargarDocumento()
        Try
            Dim rutaArchivo, rutaFinal As String
            With componente
                .InitialDirectory = ""
                .Filter = "Todos los archivos de imagen|*.pdf"
                .Title = "Seleccionar Archivo"
            End With
            If componente.ShowDialog() = DialogResult.OK Then
                rutaArchivo = componente.FileName
                rutaFinal = Path.GetTempPath & "Electro"
                While Directory.Exists(rutaFinal)
                    My.Computer.FileSystem.DeleteDirectory(rutaFinal, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                    Threading.Thread.Sleep(Constantes.TIEMPO_ESPERA + 2000)
                End While
                Do
                    Directory.CreateDirectory(rutaFinal)
                    Threading.Thread.Sleep(Constantes.TIEMPO_ESPERA)
                Loop While Not Directory.Exists(rutaFinal)
                rutaFinal = rutaFinal & ConstantesHC.CARPETA_VISTA_PREVIA_ARCHIVO & txtregistro.Text & ConstantesHC.NOMBRE_PDF_SEPARADOR & Format(Now, "HH'h'mm'm'ss's'") & ConstantesHC.EXTENSION_ARCHIVO_PDF
                Dim Doc As New Document()
                Dim fs As New FileStream(rutaFinal, FileMode.Create, FileAccess.Write, FileShare.None)
                Dim copy As New PdfCopy(Doc, fs)
                Doc.Open()
                Dim archivoPDF As PdfReader
                Dim numeroPagina As Integer 'Número de páginas de cada pdf
                Dim numeroPaginaActual, totalNumeroPaginas As Integer
                Dim nuevo As String = enumerarPaginasPDF(rutaArchivo, numeroPaginaActual, totalNumeroPaginas)
                Try
                    archivoPDF = New PdfReader(nuevo)
                    numeroPagina = archivoPDF.NumberOfPages
                    Dim pagina As Integer = 0
                    Do While pagina < numeroPagina
                        pagina += 1
                        copy.AddPage(copy.GetImportedPage(archivoPDF, pagina))
                    Loop
                    copy.FreeReader(archivoPDF)
                    archivoPDF.Close()
                Catch ex As Exception
                    archivoPDF.Close()
                End Try
                Doc.Close()
                Doc.Dispose()
                copy.Close()
                copy.Dispose()
                Process.Start(rutaFinal)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function enumerarPaginasPDF(ruta As String, ByRef numeroPaginaActual As Integer, totalNumeroPaginas As Integer) As String
        ' Creamos una lista de archivos para concatenar
        Dim oldFile As String = ruta
        Dim newFile As String = Replace(ruta, ".pdf", "Resultado.pdf")

        ' Create reader
        Dim reader As New PdfReader(oldFile)
        Dim size As Rectangle = reader.GetPageSizeWithRotation(1)
        Dim document As New Document(size)

        ' Create the writer
        Dim fs As New FileStream(newFile, FileMode.Create, FileAccess.Write)
        Dim writer As PdfWriter = PdfWriter.GetInstance(document, fs)
        document.Open()
        Dim cb As PdfContentByte = writer.DirectContent
        'document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate())
        ' Set the font, color and size properties for writing text to the PDF
        Dim bf As BaseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)

        ' Write text in the PDF
        Dim n As Integer = reader.NumberOfPages
        Dim pagina As Integer
        Do While pagina < n
            cb.SetColorFill(BaseColor.BLACK)
            cb.SetFontAndSize(bf, 9)
            pagina += 1
            numeroPaginaActual += 1

            ' Put the text on a new page in the PDF 
            Dim page As PdfImportedPage = writer.GetImportedPage(reader, pagina)
            cb.AddTemplate(page, 0, 6)
            Dim text As String = txtpaciente.Text.ToLower & "   " & txtedad.Text.Replace("año(s)", "Años") & "        " & UCase(Mid(txtsexo.Text, 1, 1)) & txtsexo.Text.Substring(1, txtsexo.Text.Length - 1).ToLower
            cb.BeginText()
            ' Set the alignment and coordinates here

            cb.ShowTextAligned(1, text, size.Width - 629, size.Height - 22, 0)
            cb.SetFontAndSize(bf, 8)
            Dim fecha As String
            fecha = dtfecha.Value.ToString
            fecha = fecha.Replace("/", "-")
            fecha = fecha.Replace(". ", "")
            fecha = fecha.Replace(".", "")
            fecha = fecha.ToUpper()
            Dim fechaTxt() As String = fecha.Split(" ")
            fecha = fechaTxt(0) & "  " & "   " & fechaTxt(1) & "  " & fechaTxt(2)
            cb.ShowTextAligned(1, fecha, size.Width - 100, size.Height - 553, 0)
            cb.EndText()
            document.NewPage()
        Loop
        ' Close the objects
        document.Close()
        document.Dispose()
        fs.Dispose()
        writer.Dispose()
        reader.Dispose()
        Return newFile
    End Function

    Private Sub guardarEcos()
        If MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
            Try
                cargarObjeto()
                objEcocardiograma.guardarRegistro()
                codigoTemporal = objEcocardiograma.codigo
                nRegistro = objEcocardiograma.nRegistro
                usuarioActual = objEcocardiograma.usuario
                codigoTipo = objEcocardiograma.codigoTipoEco
                General.habilitarBotones(ToolStrip1)
                General.deshabilitarControles(Me)
                colorDeshabilitarControl()
                btguardar.Enabled = False
                btcancelar.Enabled = False
                btguardar.Enabled = False
                'guardarReporte()
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        End If
    End Sub

    Private Sub btanular_Click(sender As Object, e As EventArgs) Handles btanular.Click
        If SesionActual.tienePermiso(Panular) Then
            Try
                If MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                    objEcocardiograma.anularEco(activoAM, activoAF)
                    ''falta el eliminar archivo del pdf de salida voluntaria
                    MsgBox(Mensajes.ANULADO, MsgBoxStyle.Information)
                    General.limpiarControles(Me)
                    General.deshabilitarBotones(ToolStrip1)
                    btnuevo.Enabled = True
                    btbuscar.Enabled = True
                End If
            Catch ex As Exception
                General.manejoErrores(ex)
            End Try
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub cargarObjeto()
        objEcocardiograma.usuario = SesionActual.idUsuario
        objEcocardiograma.usuarioReal = IIf(String.IsNullOrEmpty(objEcocardiograma.usuarioReal), objEcocardiograma.usuario, objEcocardiograma.usuarioReal)
        objEcocardiograma.idEmpresa = SesionActual.codigoEP
        objEcocardiograma.fechaRegistro = dtfecha.Value
        objEcocardiograma.codigo = codigoTemporal
        objEcocardiograma.objEcocardiograma.ventana = Textventana.Text
        objEcocardiograma.descripcionHallazgo = Rtdescripcion.Rtf
        objEcocardiograma.objEcocardiograma.conclusion = Rtconclusiones.Rtf
    End Sub
    Private Sub btbuscarPaciente_Click(sender As Object, e As EventArgs) Handles btbuscarPaciente.Click
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        params.Add(objEcocardiograma.codigoTipoEco)
        params.Add(Nothing)
        General.buscarItem(objEcocardiograma.sqlBuscarPaciente,
                                  params,
                                  AddressOf cargarPaciente,
                                  TitulosForm.BUSQUEDA_PACIENTE,
                                  False, True, Constantes.TAMANO_MEDIANO)
    End Sub

    Public Sub cargarPaciente(pCodigo As DataRow)
        Dim verificarServicioNeo As Boolean
        Dim dFila As DataRow
        Dim params As New List(Of String)
        objEcocardiograma.CodigoOrden = pCodigo.Item(0)
        objEcocardiograma.CodigoProcedimiento = pCodigo.Item(1)
        params.Add(objEcocardiograma.CodigoOrden)
        params.Add(objEcocardiograma.CodigoProcedimiento)
        dFila = General.cargarItem(objEcocardiograma.sqlCargarPaciente, params)
        objEcocardiograma.objEcocardiograma.codigoArea = dFila.Item("codigo_area")
        txtregistro.Text = dFila.Item("Registro")
        txtidentificacion.Text = dFila.Item("Documento")
        txtfechaingreso.Text = Format(CDate(dFila.Item("Fecha_Admision").ToString), Constantes.FORMATO_FECHA_HORA_GEN)
        txtpaciente.Text = dFila.Item("Paciente").ToString
        txtsexo.Text = dFila.Item("Genero").ToString
        txtedad.Text = dFila.Item("Edad").ToString
        txtcodigocontrato.Text = dFila.Item("Codigo_EPS").ToString
        txtcontrato.Text = dFila.Item("Contrato").ToString
        lblentorno.Text = dFila.Item("Descripcion_Area_Servicio").ToString
        txtcama.Text = dFila.Item("Cama").ToString
        Txtjustificacion.Text = dFila.Item("Justificacion").ToString
        Txtexamen.Text = dFila.Item("Descripcion")
        dtfecha.Text = Format(dFila.Item("Fecha"), Constantes.FORMATO_FECHA_HORA_GEN)
        txtCodigoOrden.Text = dFila.Item("Codigo_Orden")
        visiblePestañasEco(objEcocardiograma.codigoTipoEco)
        verificarServicioNeo = General.getEstadoVF(Consultas.AREA_SERVICIO_VERIFICAR &
                                    objEcocardiograma.objEcocardiograma.codigoArea)

        If objEcocardiograma.codigoTipoEco = Constantes.CODIGO_ECO_ESTRES Then
            Rtdescripcion.Clear()
        Else
            Textventana.Text = Constantes.VENTANA

            Rtdescripcion.Text = If(verificarServicioNeo = False,
                                    Constantes.DESCRIPCION_ECOCARDIOGRAMA,
                                    Constantes.DESCRIPCION_ECOCARDIOGRAMA_NEO)

            Rtconclusiones.Text = Constantes.CONCLUSIONES_ECOCARDIOGRAMA
            objEcocardiograma.objEcocardiograma.cargarParametros()
            dgvparametros.DataSource = objEcocardiograma.objEcocardiograma.dtParametro
        End If
        General.deshabilitarBotones(ToolStrip1)
        General.habilitarControles(TabControl1)
        dtfecha.Enabled = True
        btguardar.Enabled = True
        btcancelar.Enabled = True
    End Sub
    Private Sub cargarRegistros(pCodigo As DataRow)
        Dim params As New List(Of String)
        Dim dFila As DataRow

        Try
            codigoTemporal = pCodigo.Item(0)
            params.Add(codigoTemporal)
            objEcocardiograma.codigo = codigoTemporal
            params.Add(objEcocardiograma.codigoTipoEco)
            dFila = General.cargarItem(objEcocardiograma.sqlCargarRegistro, params)
            txtregistro.Text = dFila.Item("Registro")
            txtidentificacion.Text = dFila.Item("Documento")
            txtfechaingreso.Text = Format(CDate(dFila.Item("Fecha_Admision").ToString), Constantes.FORMATO_FECHA_HORA_GEN)
            txtpaciente.Text = dFila.Item("Paciente").ToString
            txtsexo.Text = dFila.Item("Genero").ToString
            txtedad.Text = dFila.Item("Edad").ToString
            txtcodigocontrato.Text = dFila.Item("Codigo_EPS").ToString
            txtcontrato.Text = dFila.Item("Contrato").ToString
            lblentorno.Text = dFila.Item("Descripcion_Area_Servicio").ToString
            txtcama.Text = dFila.Item("Cama").ToString
            Txtjustificacion.Text = dFila.Item("Justificacion").ToString
            Txtexamen.Text = dFila.Item("Descripcion")
            txtCodigoOrden.Text = dFila.Item("Codigo_Orden")
            objEcocardiograma.CodigoProcedimiento = dFila.Item("codigo")
            dtfecha.Text = Format(dFila.Item("Fecha_Examen"), Constantes.FORMATO_FECHA_HORA_GEN)
            Try
                Rtdescripcion.Rtf = dFila.Item("Descripcion_eco")
            Catch ex As Exception
                Rtdescripcion.Text = dFila.Item("Descripcion_eco")
            End Try
            objEcocardiograma.CodigoOrden = dFila.Item("Codigo_Orden")
            objEcocardiograma.nRegistro = txtregistro.Text
            visiblePestañasEco(objEcocardiograma.codigoTipoEco)
            Label1.Text = objEcocardiograma.validarFormulario()
            If objEcocardiograma.codigoTipoEco = Constantes.CODIGO_ECOCARDIOGRAMA Then
                Textventana.Text = dFila.Item("Ventana_acustica")
                Try
                    Rtconclusiones.Rtf = dFila.Item("Conclusion")
                Catch ex As Exception
                    Rtconclusiones.Text = dFila.Item("Conclusion")
                End Try
                params.Clear()
                params.Add(codigoTemporal)
                General.llenarTabla(objEcocardiograma.objEcocardiograma.sqlCargarDetalle, params, objEcocardiograma.objEcocardiograma.dtParametro)
                dgvparametros.DataSource = objEcocardiograma.objEcocardiograma.dtParametro
            End If

            objEcocardiograma.banderaGuardar = True

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
        colorDeshabilitarControl()
        General.habilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        btguardar.Enabled = False
        btcancelar.Enabled = False
    End Sub

    Private Sub Form_ecocardiograma_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub cargarPermisos()
        permiso_general = perG.buscarPermisoGeneral(Name, moduloTemporal)
        Pnuevo = permiso_general & "pp" & "01"
        Peditar = permiso_general & "pp" & "02"
        Panular = permiso_general & "pp" & "03"
        PBuscar = permiso_general & "pp" & "04"
    End Sub
End Class