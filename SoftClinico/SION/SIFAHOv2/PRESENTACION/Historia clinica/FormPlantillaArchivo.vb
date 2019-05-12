Imports iTextSharp.text
Imports iTextSharp.text.pdf
Public Class FormPlantillaArchivo
    Dim plantillaArchivo As plantillaArchivo
    Property formResultado As Form_resultado
    Dim codigoArea, paciente, sexo, edad, registro, identificacion, entorno, cama As String
    Private Sub FormPlantillaArchivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        plantillaArchivo = New plantillaArchivo
        validarDataGrid()
        cargarArchivo()
    End Sub
    Private Sub validarDataGrid()
        With dgvPlantilla
            .ReadOnly = True
            .Columns("dgCodigo").DataPropertyName = "Codigo_Plantilla"
            .Columns("dgDescripcion").DataPropertyName = "NombreDiag"
            .DataSource = plantillaArchivo.dtAchivo
            .AutoGenerateColumns = False
        End With
    End Sub
    Private Sub cargarArchivo()
        Dim params As New List(Of String)
        params.Add(txtCodigoManual.Text)
        params.Add(codigoArea)
        General.llenarTabla(Consultas.PLANTILLA_CARGAR, params, plantillaArchivo.dtAchivo)
        dgvPlantilla.DataSource = plantillaArchivo.dtAchivo
    End Sub
    Public Sub cargarProcedimiento(codigoManual As String, nombreProcemiento As String)
        txtCodigoManual.Text = codigoManual
        txtDescripcion.Text = nombreProcemiento
    End Sub
    Public Sub cargarPaciente(pCodigo As String)
        Dim dFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(txtCodigoManual.Text)
        dFila = General.cargarItem(Consultas.CARGAR_PACIENTE_ECOCARDIOGRAMA, params)
        registro = dFila.Item("Registro")
        identificacion = dFila.Item("Documento")
        paciente = dFila.Item("Paciente").ToString
        sexo = dFila.Item("Genero").ToString
        edad = dFila.Item("Edad").ToString
        entorno = dFila.Item("Descripcion_Area_Servicio").ToString
        cama = dFila.Item("Cama").ToString
        codigoArea = dFila.Item("codigo_area")
        fechaElectro.Value = Format(dFila.Item("Fecha_Orden"), Constantes.FORMATO_FECHA_HORA_GEN)
        fechaElectro.Value = fechaElectro.Value.AddHours(1)
    End Sub
    Private Sub dgvPlantilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPlantilla.CellContentClick
        If plantillaArchivo.dtAchivo.Rows.Count > 0 Then
            If e.ColumnIndex = 0 Then
                subirArchivo()
            End If
        End If
    End Sub
    Private Sub subirArchivo()
        Dim params As New List(Of String)
        Dim dt As New DataTable
        Dim ruta As String
        params.Add(dgvPlantilla.Rows(dgvPlantilla.CurrentRow.Index).Cells(1).Value.ToString())
        Dim tempfileurl As String = System.IO.Path.GetTempPath + fechaElectro.Value.ToString("yyyyMMdd_HHmmss")
        General.llenarTabla(Consultas.DOCUMENTO_ECO_CARGAR, params, dt)
        If dt.Rows.Count > 0 Then
            tempfileurl += "-tempdocu" + Constantes.FORMATO_PDF
            System.IO.File.WriteAllBytes(tempfileurl, dt.Rows(0).Item("Imagen"))
            ruta = System.IO.Path.GetTempPath & paciente
            formResultado.cargarPlantilla(crearDocumento(tempfileurl, ruta), plantillaArchivo.dtAchivo.Rows(dgvPlantilla.CurrentRow.Index).Item("NombreDiag").ToString.ToLower, dt.Rows(0).Item("Imagen"))
            formResultado.txtNota.Text = plantillaArchivo.dtAchivo.Rows(dgvPlantilla.CurrentRow.Index).Item("DescripcionDiag")
            Close()
        End If
    End Sub
    Private Function crearDocumento(ruta As String, rutaFinal As String) As String
        Dim Doc As New Document()
        Dim fs As New FileStream(rutaFinal, FileMode.Create, FileAccess.Write, FileShare.None)
        Dim copy As New PdfCopy(Doc, fs)
        Doc.Open()
        Dim archivoPDF As PdfReader
        Dim numeroPagina As Integer
        Dim nuevo As String = enumerarPaginasPDF(ruta)
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
        Return rutaFinal
    End Function
    Private Function enumerarPaginasPDF(ruta As String) As String
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
            ' Put the text on a new page in the PDF 
            Dim page As PdfImportedPage = writer.GetImportedPage(reader, pagina)
            cb.AddTemplate(page, 0, 6)
            Dim text As String = identificacion & "   " & paciente.ToLower & "    " & edad.Replace("año(s)", "Años") & "      " & UCase(Mid(sexo, 1, 1)) & sexo.Substring(1, sexo.Length - 1).ToLower
            cb.BeginText()
            ' Set the alignment and coordinates here
            cb.ShowTextAligned(1, text, size.Width - 629, size.Height - 22, 0)
            'cb.SetFontAndSize(bf, 8)
            cb.SetFontAndSize(bf, 11)
            Dim nomEmpresa As String = SesionActual.nombreEmpresa & "  Reporte ECG"
            cb.ShowTextAligned(1, nomEmpresa, size.Width - 420, size.Height - 9, 0)

            cb.SetFontAndSize(bf, 9)
            Dim fecha As String
            fecha = fechaElectro.Value.ToString
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
End Class