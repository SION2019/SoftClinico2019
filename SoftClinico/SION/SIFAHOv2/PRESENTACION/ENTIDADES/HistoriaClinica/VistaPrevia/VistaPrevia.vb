Imports iTextSharp.text
Imports iTextSharp.text.pdf
Public Class VistaPrevia
    Inherits PdfPageEventHelper
    Public Property registro As Integer
    Public Property codigoMenu As String
    Public Property usuario As Integer
    Public Property listDocumentos As DataTable
    Public Property rutaArchivos As New DataTable
    Public Property listaCarga As String
    Public Property nombrePaciente As String
    Private direccion As String
    Private rutaUnion As String
    Public Sub New()
        listaCarga = ConsultasHC.VISTA_PREVIA_DOC_LISTAR
        codigoMenu = Constantes.CODIGO_MENU_HISTC
        listDocumentos = New DataTable
        listDocumentos.Columns.Add("Bandera", Type.GetType("System.String"))
        listDocumentos.Columns.Add("Archivo", Type.GetType("System.Byte[]"))

    End Sub
    Public Sub cargarDocumentos()
        Try
            Dim params As New List(Of String)
            params.Add(registro)
            params.Add(codigoMenu)
            params.Add(usuario)
            General.ejecutarSQL(ConsultasHC.VISTA_PREVIA_CREAR, params)
            params.Clear()
            params.Add(registro)
            General.llenarTabla(listaCarga, params, listDocumentos)
            direccion = Path.GetTempPath & Replace(nombrePaciente, " ", "")

            descargarDocumentos()
            unirDocumentos()
            params.Clear()
            params.Add(registro)
            params.Add(codigoMenu)
            params.Add(usuario)
            General.ejecutarSQL(ConsultasHC.VISTA_PREVIA_ACTUALIZAR, params)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub descargarDocumentos()
        Dim raiz As String
        If IsNothing(rutaArchivos.Columns("Direccion")) Then
            rutaArchivos.Columns.Add("Direccion")
        End If
        While Directory.Exists(direccion)

            My.Computer.FileSystem.DeleteDirectory(direccion, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Threading.Thread.Sleep(Constantes.TIEMPO_ESPERA + 1000)
        End While
        Do
            Directory.CreateDirectory(direccion)
            Threading.Thread.Sleep(Constantes.TIEMPO_ESPERA)
        Loop While Not Directory.Exists(direccion)
        rutaArchivos.Clear()
        For i = 0 To listDocumentos.Rows.Count - 1
            raiz = direccion & "\" & i & ConstantesHC.NOMBRE_PDF_SEPARADOR & listDocumentos.Rows(i).Item("Bandera") & ".pdf"
            File.WriteAllBytes(raiz, listDocumentos.Rows(i).Item("Archivo"))
            rutaArchivos.Rows.Add()
            rutaArchivos.Rows(rutaArchivos.Rows.Count - 1).Item("Direccion") = raiz
            FileClose()
        Next
    End Sub
    Private Sub unirDocumentos()
        Dim listaRutas As New List(Of String)

        Try
            For i = 0 To rutaArchivos.Rows.Count - 1
                listaRutas.Add(rutaArchivos.Rows(i).Item(0).ToString.Trim)
            Next
            rutaUnion = direccion & ConstantesHC.CARPETA_VISTA_PREVIA

            While Directory.Exists(rutaUnion)
                My.Computer.FileSystem.DeleteDirectory(rutaUnion, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                Threading.Thread.Sleep(Constantes.TIEMPO_ESPERA + 1000)
            End While
            Do
                Directory.CreateDirectory(direccion & ConstantesHC.CARPETA_VISTA_PREVIA)
                Threading.Thread.Sleep(Constantes.TIEMPO_ESPERA)
            Loop While Not Directory.Exists(direccion & ConstantesHC.CARPETA_VISTA_PREVIA)
            rutaUnion = direccion & ConstantesHC.CARPETA_VISTA_PREVIA & ConstantesHC.CARPETA_VISTA_PREVIA_ARCHIVO & registro & ConstantesHC.EXTENSION_ARCHIVO_PDF

            Dim Doc As New Document()
            Dim fs As New FileStream(rutaUnion, FileMode.Create, FileAccess.Write, FileShare.None)
            Dim copy As New PdfCopy(Doc, fs)
            Doc.Open()
            Dim archivoPDF As PdfReader

            Dim numeroPagina As Integer 'Número de páginas de cada pdf

            For Each pdf2 In listaRutas
                If Not File.Exists(pdf2) Then
                    If MsgBox("Hubo un problema al momento de cargar algun soporte, aceptar: ignorar,  cancelar: cargar de nuevo", MsgBoxStyle.OkCancel, "Informaciòn") = MsgBoxResult.Ok Then
                    Else
                        Exit Sub
                    End If
                Else
                    archivoPDF = New PdfReader(pdf2)
                    numeroPagina = archivoPDF.NumberOfPages
                    Dim pagina As Integer = 0
                    Try
                        Do While pagina < numeroPagina
                            pagina += 1
                            copy.AddPage(copy.GetImportedPage(archivoPDF, pagina))
                        Loop
                        copy.FreeReader(archivoPDF)
                        archivoPDF.Close()
                    Catch ex As Exception
                    End Try
                End If

            Next
            Doc.Close()
            'piePagina2()
            Process.Start(rutaUnion)
            Do
                My.Computer.FileSystem.DeleteDirectory(direccion, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                Threading.Thread.Sleep(Constantes.TIEMPO_ESPERA)
            Loop While Directory.Exists(direccion)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub piePagina2()
        Dim oldFile As String = rutaUnion

        Dim newFile As String = direccion & ConstantesHC.CARPETA_VISTA_PREVIA & ConstantesHC.CARPETA_VISTA_PREVIA_ARCHIVO & "COPIA_" & registro & ConstantesHC.EXTENSION_ARCHIVO_PDF

        Dim reader As PdfReader = Nothing

        Dim stamper As PdfStamper = Nothing

        Dim cb As PdfContentByte = Nothing

        Dim rect As Rectangle = Nothing

        Dim pageCount As Integer = 0

        Try
            reader = New PdfReader(oldFile)

            rect = reader.GetPageSizeWithRotation(1)

            stamper = New PdfStamper(reader, New FileStream(newFile, FileMode.Create))

            cb = stamper.GetOverContent(1)
            Dim ct = New ColumnText(cb)
            ct.Alignment = Element.ALIGN_LEFT
            ct.SetSimpleColumn(70, 36, PageSize.A4.Width - 36, PageSize.A4.Height - 300)
            Dim nTbl As PdfPTable = New PdfPTable(2)

            Dim rows As Single() = {135.0F, 145.0F}

            nTbl.SetTotalWidth(rows)

            nTbl.AddCell(New Paragraph("Application Ref No:", FontFactory.GetFont("Arial", 15)))
            nTbl.AddCell(New Paragraph("HPOBM00017", FontFactory.GetFont("Arial", 15)))
            nTbl.WriteSelectedRows(0, 20, 300, 835, stamper.GetOverContent(1))

            stamper.Close()
            reader.Close()
            ct.Go()
            rutaUnion = newFile
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub piePagina()
        Dim copyDoc As New Document()
        Dim rutaCopia As String
        Dim reader As PdfReader
        Dim totalPages As Integer
        rutaCopia = direccion & ConstantesHC.CARPETA_VISTA_PREVIA & ConstantesHC.CARPETA_VISTA_PREVIA_ARCHIVO & "COPIA_" & registro & ConstantesHC.EXTENSION_ARCHIVO_PDF
        Dim copyPdf As New PdfCopy(copyDoc, New FileStream(rutaCopia, FileMode.Create))
        copyPdf.SetPageSize(PageSize.A4.Rotate())
        copyDoc.Open()
        reader = New PdfReader(rutaUnion)
        totalPages = reader.NumberOfPages
        Dim copiedPage As PdfImportedPage
        Dim stamper As PdfCopy.PageStamp
        Dim georgia As Font = FontFactory.GetFont("georgia", 10.0F)
        georgia.Color = BaseColor.GRAY
        Dim c1 As Chunk
        Dim pagina As Integer = 0
        Try

            Do While pagina < totalPages
                pagina += 1
                copiedPage = copyPdf.GetImportedPage(reader, (pagina))
                stamper = copyPdf.CreatePageStamp(copiedPage)
                c1 = New Chunk("You can of course force a newline using \", georgia)
                ColumnText.ShowTextAligned(stamper.GetUnderContent(), Element.ALIGN_RIGHT, New Phrase(c1), 820.0F, 15, 0)
                stamper.AlterContents()

                copyPdf.AddPage(copiedPage)
            Loop
            copyPdf.Flush()
            reader.Close()
        Catch ex As Exception
            Throw ex
        End Try
        rutaUnion = rutaCopia
        copyPdf.Close()

    End Sub

End Class
