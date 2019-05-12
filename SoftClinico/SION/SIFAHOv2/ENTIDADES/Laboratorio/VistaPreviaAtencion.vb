Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Threading
Public Class VistaPreviaAtencion
    Inherits VistaPrevia
    Private direccion As String
    Private rutaUnion As String
    Public Property erroresEncontrados As String
    Public Property codigoProcedimiento As String
    Sub New()
        listaCarga = ConsultasHC.VISTA_PREVIA_ATENCION
        docCarga = ConsultasHC.VISTA_PREVIA_BD_LISTAR
        codigoMenu = Constantes.CODIGO_MENU_IMAG
        'codigoReporte = Constantes.TipoEXAMAtencion
        reporteExame = If(SesionActual.codigoEnlace = 2, New rptExamenParaclinico_ReyFalse, New rptExamenParaclinico)
    End Sub
    Public Overrides Sub eliminarCarpetaDetalle()

        While Directory.Exists(direccion)
            My.Computer.FileSystem.DeleteDirectory(direccion, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Threading.Thread.Sleep(Constantes.TIEMPO_ESPERA + 2000)
        End While

    End Sub
    Public Overrides Sub crearCarpetaDetalle()
        direccion = Path.GetTempPath & Replace(nombrePaciente, " ", "")
        eliminarCarpetaDetalle()
        Do
            Directory.CreateDirectory(direccion)
            Threading.Thread.Sleep(Constantes.TIEMPO_ESPERA)
        Loop While Not Directory.Exists(direccion)
        objConsolidado.dtProcesos.Rows(0).Item(1) = 1
    End Sub
    Public Overrides Sub crearParte1()
        Try
            Dim listReportes As New List(Of DocumentoVistaPrevia)

            objConsolidado.Generando2doPlanoParte1 = True
            Dim reporte As New ftp_reportes
            Dim paso As String
            Dim errores As New List(Of String)
            Dim raiz As String

            crearImagenologia(listReportes)
            crearFactura(listReportes)

            For i = 0 To listReportes.Count - 1
                paso = listReportes.Item(i).nombrePDF & " - " & listReportes.Item(i).formula
                Try
                    Dim params As New List(Of String)
                    params.Add(listReportes.Item(i).codigoAdicional)
                    params.Add(listReportes.Item(i).codigoAdicional2)
                    raiz = direccion & "\" & listReportes.Item(i).nombrePDF & ConstantesHC.NOMBRE_PDF_SEPARADOR & listReportes.Item(i).codigoAdicional & ".pdf"
                    reporte.crearReportePDF(listReportes.Item(i).nombrePDF, registro, listReportes.Item(i).reporte,
                                           listReportes.Item(i).codigoAdicional, listReportes.Item(i).formula,
                                           listReportes.Item(i).area, direccion,, True, params, raiz)
                    listDocumentos.Rows.Add(listReportes.Item(i).nombrePDF, raiz)
                Catch ex As Exception
                    errores.Add(paso)
                End Try
            Next
            If errores.Count > 0 Then
                paso = ""
                For i = 0 To errores.Count - 1
                    paso = paso & errores.Item(i) & vbCrLf
                Next
                erroresEncontrados += vbCrLf & "Error en Consolidado: parte 1. " & paso
            End If
            objConsolidado.Generando2doPlanoParte1 = False
        Catch ex As Exception

            objConsolidado.Generando2doPlanoParte1 = False
            erroresEncontrados += vbCrLf & "Error en Consolidado: parte 1. " & ex.Message
        End Try
        objConsolidado.dtProcesos.Rows(1).Item(1) = 1
    End Sub

    Public Overrides Sub crearParte2()
        Try

            Dim listReportes As New List(Of DocumentoVistaPrevia)

            objConsolidado.Generando2doPlanoParte2 = True
            Dim inicioExamenes As Integer
            crearElectrolitos(listReportes)
            Dim reporte As New ftp_reportes
            Dim params As New List(Of String)
            Dim paso As String
            Dim errores As New List(Of String)
            Dim raiz As String
            For i = inicioExamenes To listReportes.Count - 1
                paso = listReportes.Item(i).nombrePDF & " - " & listReportes.Item(i).formula
                Try
                    params.Clear()
                    params.Add(listReportes.Item(i).codigoAdicional)
                    params.Add(listReportes.Item(i).codigoAdicional2)
                    params.Add(listReportes.Item(i).codigoAdicional3)
                    raiz = direccion & "\" & listReportes.Item(i).nombrePDF & ConstantesHC.NOMBRE_PDF_SEPARADOR & listReportes.Item(i).codigoAdicional & ".pdf"
                    reporte.crearReportePDF(listReportes.Item(i).nombrePDF, registro, listReportes.Item(i).reporte,
                                                listReportes.Item(i).codigoAdicional, listReportes.Item(i).formula,
                                                listReportes.Item(i).area, direccion, listReportes.Item(i).codigoAdicional2, True, params, raiz)
                    listDocumentos.Rows.Add(listReportes.Item(i).nombrePDF, raiz)
                Catch ex As Exception
                    errores.Add(paso)
                End Try
            Next
            If errores.Count > 0 Then
                paso = ""
                For i = 0 To errores.Count - 1
                    paso = paso & errores.Item(i) & vbCrLf
                Next
                erroresEncontrados += vbCrLf & "Error en Consolidado: parte 3. " & paso
            End If
            objConsolidado.Generando2doPlanoParte2 = False
        Catch ex As Exception
            objConsolidado.Generando2doPlanoParte2 = False
            erroresEncontrados += vbCrLf & "Error en Consolidado: parte 2. " & ex.Message
        End Try
        objConsolidado.dtProcesos.Rows(2).Item(1) = 1
    End Sub

    Public Overrides Sub crearParte3()
        objConsolidado.Generando2doPlanoParte3 = True
        Try
            Dim listReportes As New List(Of DocumentoVistaPrevia)
            Dim paso As String
            Dim errores As New List(Of String)
            crearAdmision(listReportes)

            Dim reporte As New ftp_reportes
            Dim raiz As String
            For i = 0 To listReportes.Count - 1
                paso = listReportes.Item(i).nombrePDF & " - " & listReportes.Item(i).formula
                Try
                    raiz = direccion & "\" & listReportes.Item(i).nombrePDF & ConstantesHC.NOMBRE_PDF_SEPARADOR & listReportes.Item(i).codigoAdicional & ".pdf"
                    reporte.crearReportePDF(listReportes.Item(i).nombrePDF, registro, listReportes.Item(i).reporte,
                                            listReportes.Item(i).codigoAdicional, listReportes.Item(i).formula,
                                           listReportes.Item(i).area, direccion,, True,, raiz)
                    listDocumentos.Rows.Add(listReportes.Item(i).nombrePDF, raiz)
                Catch ex As Exception
                    errores.Add(paso)
                End Try
            Next
            descargarDocumentos(paso, errores)
            If errores.Count > 0 Then
                paso = ""
                For i = 0 To errores.Count - 1
                    paso = paso & errores.Item(i) & vbCrLf
                Next
                erroresEncontrados += vbCrLf & "Error en Consolidado: parte 3. " & paso
            End If

            objConsolidado.Generando2doPlanoParte3 = False
        Catch ex As Exception
            objConsolidado.Generando2doPlanoParte3 = False
            erroresEncontrados += vbCrLf & "Error en Consolidado: parte 3. " & ex.Message
        End Try
        objConsolidado.dtProcesos.Rows(3).Item(1) = 1
    End Sub

    Public Overrides Sub crearParte4()
        Try

            Dim listReportes As New List(Of DocumentoVistaPrevia)
            objConsolidado.Generando2doPlanoParte4 = True
            Dim inicioExamenes As Integer

            Dim reporte As New ftp_reportes
            Dim params As New List(Of String)
            Dim paso As String
            Dim errores As New List(Of String)
            Dim raiz As String

            For i = inicioExamenes To listReportes.Count - 1
                paso = listReportes.Item(i).nombrePDF & " - " & listReportes.Item(i).formula
                Try
                    params.Clear()
                    params.Add(listReportes.Item(i).codigoAdicional)
                    params.Add(listReportes.Item(i).codigoAdicional2)
                    raiz = direccion & "\" & listReportes.Item(i).nombrePDF & ConstantesHC.NOMBRE_PDF_SEPARADOR & listReportes.Item(i).codigoAdicional & ".pdf"
                    reporte.crearReportePDF(listReportes.Item(i).nombrePDF, registro, listReportes.Item(i).reporte,
                                           listReportes.Item(i).codigoAdicional, listReportes.Item(i).formula,
                                           listReportes.Item(i).area, direccion,, True, params, raiz)
                    listDocumentos.Rows.Add(listReportes.Item(i).nombrePDF, raiz)
                Catch ex As Exception
                    errores.Add(paso)
                End Try
            Next
            inicioExamenes = listReportes.Count
            For i = inicioExamenes To listReportes.Count - 1
                paso = listReportes.Item(i).nombrePDF & " - " & listReportes.Item(i).formula
                Try
                    params.Clear()
                    params.Add(listReportes.Item(i).codigoAdicional)
                    params.Add(listReportes.Item(i).codigoAdicional2)
                    Dim parametro As String
                    If listReportes.Item(i).nombrePDF = ConstantesHC.NOMBRE_PDF_IMAGENOLOGIA OrElse
                       listReportes.Item(i).nombrePDF = ConstantesHC.NOMBRE_PDF_IMAGENOLOGIA_R OrElse
                       listReportes.Item(i).nombrePDF = ConstantesHC.NOMBRE_PDF_IMAGENOLOGIA_RR Then
                        parametro = listReportes.Item(i).codigoAdicional + listReportes.Item(i).codigoAdicional2
                    Else
                        parametro = listReportes.Item(i).codigoAdicional
                    End If
                    raiz = direccion & "\" & listReportes.Item(i).nombrePDF & ConstantesHC.NOMBRE_PDF_SEPARADOR & parametro & ".pdf"
                    reporte.crearReportePDF(listReportes.Item(i).nombrePDF, registro, listReportes.Item(i).reporte,
                                                parametro, listReportes.Item(i).formula,
                                                listReportes.Item(i).area, direccion, listReportes.Item(i).codigoAdicional2, True, params, raiz)
                    listDocumentos.Rows.Add(listReportes.Item(i).nombrePDF, raiz)
                Catch ex As Exception
                    errores.Add(paso)
                End Try
            Next
            If errores.Count > 0 Then
                paso = ""
                For i = 0 To errores.Count - 1
                    paso = paso & errores.Item(i) & vbCrLf
                Next
                erroresEncontrados += vbCrLf & "Error en Consolidado: parte 4. " & paso
            End If
            objConsolidado.Generando2doPlanoParte4 = False
        Catch ex As Exception
            objConsolidado.Generando2doPlanoParte4 = False
            erroresEncontrados += vbCrLf & "Error en Consolidado: parte 4. " & ex.Message
        End Try
        objConsolidado.dtProcesos.Rows(4).Item(1) = 1
    End Sub

    Public Overrides Sub organizarLista(listaRutas As List(Of String))
        Dim dtLista As New DataTable
        General.llenarTabla(listaCarga, Nothing, dtLista)
        For j = 0 To dtLista.Rows.Count - 1
            For i = 0 To listDocumentos.Rows.Count - 1
                If dtLista.Rows(j).Item("Bandera").ToString.ToUpper = listDocumentos.Rows(i).Item("Bandera").ToString.ToUpper Then
                    listaRutas.Add(listDocumentos.Rows(i).Item("Direccion").ToString.Trim)
                End If
            Next
        Next

    End Sub

    Public Overrides Sub crearCarpetaConsolidado()
        rutaUnion = direccion & ConstantesHC.CARPETA_VISTA_PREVIA

        While Directory.Exists(rutaUnion)
            My.Computer.FileSystem.DeleteDirectory(rutaUnion, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Threading.Thread.Sleep(Constantes.TIEMPO_ESPERA + 1000)
        End While
        Do
            Directory.CreateDirectory(direccion & ConstantesHC.CARPETA_VISTA_PREVIA)
            Threading.Thread.Sleep(Constantes.TIEMPO_ESPERA)
        Loop While Not Directory.Exists(direccion & ConstantesHC.CARPETA_VISTA_PREVIA)
        rutaUnion = direccion & ConstantesHC.CARPETA_VISTA_PREVIA & ConstantesHC.CARPETA_VISTA_PREVIA_ARCHIVO & registro & ConstantesHC.NOMBRE_PDF_SEPARADOR & Format(Now, "HH'h'mm'm'ss's'") & ConstantesHC.EXTENSION_ARCHIVO_PDF
    End Sub

    Private Function enumerarPaginasPDF(ruta As String, ByRef numeroPaginaActual As Integer, totalNumeroPaginas As Integer) As String
        ' Creamos una lista de archivos para concatenar
        Dim oldFile As String = ruta
        Dim newFile As String = oldFile
        'Dim newFile As String = Replace(ruta, ".pdf", "Paginado.pdf")

        '' Create reader
        'Dim reader As New PdfReader(oldFile)
        'Dim size As Rectangle = reader.GetPageSizeWithRotation(1)
        'Dim document As New Document(size)

        '' Create the writer
        'Dim fs As New FileStream(newFile, FileMode.Create, FileAccess.Write)
        'Dim writer As PdfWriter = PdfWriter.GetInstance(document, fs)
        'document.Open()
        'Dim cb As PdfContentByte = writer.DirectContent
        ''document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate())
        '' Set the font, color and size properties for writing text to the PDF
        'Dim bf As BaseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)

        '' Write text in the PDF
        'Dim n As Integer = reader.NumberOfPages
        'Dim pagina As Integer
        'Do While pagina < n
        '    cb.SetColorFill(BaseColor.BLACK)
        '    cb.SetFontAndSize(bf, 8)
        '    pagina += 1
        '    numeroPaginaActual += 1

        '    ' Put the text on a new page in the PDF 
        '    Dim page As PdfImportedPage = writer.GetImportedPage(reader, pagina)
        '    cb.AddTemplate(page, 0, 0)
        '    Dim text As String = "Folio " & numeroPaginaActual & " de " & totalNumeroPaginas
        '    cb.BeginText()
        '    ' Set the alignment and coordinates here
        '    cb.ShowTextAligned(1, text, 50, 20, 0)
        '    cb.EndText()

        '    document.NewPage()
        'Loop
        '' Close the objects
        'document.Close()
        'document.Dispose()
        'fs.Dispose()
        'writer.Dispose()
        'reader.Dispose()
        Return newFile
    End Function
    Public Overrides Sub unirDocumentos()
        Try
            Dim listaRutas As New List(Of String)
            organizarLista(listaRutas)
            crearCarpetaConsolidado()
            Dim Doc As New Document()
            Dim fs As New FileStream(rutaUnion, FileMode.Create, FileAccess.Write, FileShare.None)
            Dim copy As New PdfCopy(Doc, fs)
            Doc.Open()
            Dim archivoPDF As PdfReader
            Dim archivoImg As PdfImage
            Dim numeroPagina As Integer 'Número de páginas de cada pdf
            Dim numeroPaginaActual, totalNumeroPaginas As Integer
            For Each pdf2 In listaRutas
                If Not File.Exists(pdf2) Then
                Else
                    Try
                        archivoPDF = New PdfReader(pdf2)
                        totalNumeroPaginas = totalNumeroPaginas + archivoPDF.NumberOfPages
                        archivoPDF.Close()
                    Catch ex As Exception
                    End Try
                End If
            Next

            For Each pdf2 In listaRutas
                If Not File.Exists(pdf2) Then
                    If MsgBox("Hubo un problema al momento de cargar algun soporte, aceptar: ignorar,  cancelar: cargar de nuevo", MsgBoxStyle.OkCancel, "Informaciòn") = MsgBoxResult.Ok Then
                    Else
                        Exit Sub
                    End If
                Else
                    Try
                        'If Not pdf2.ToString.Contains(".pdf") Then
                        '    Doc.Add(iTextSharp.text.Image.GetInstance(pdf2))
                        'Else
                        archivoPDF = New PdfReader(enumerarPaginasPDF(pdf2, numeroPaginaActual, totalNumeroPaginas))
                        numeroPagina = archivoPDF.NumberOfPages
                        Dim pagina As Integer = 0
                        Do While pagina < numeroPagina
                            pagina += 1
                            copy.AddPage(copy.GetImportedPage(archivoPDF, pagina))
                        Loop
                        copy.FreeReader(archivoPDF)
                        archivoPDF.Close()
                        'End If
                    Catch ex As Exception
                    End Try
                End If
            Next
            Doc.Close()
            Doc.Dispose()
            copy.Close()
            copy.Dispose()
            formPlataforma.obtenerRuta(rutaUnion)
        Catch ex As Exception
            Throw ex
        End Try
        objConsolidado.dtProcesos.Rows(5).Item(1) = 1
        objConsolidado.dtProcesos.Rows(6).Item(1) = 1
    End Sub

    Public Overrides Sub descargarDocumentos(ByRef paso As String, errores As List(Of String))
        Dim params As New List(Of String)
        Dim raiz As String
        params.Add(registro)
        params.Add(Constantes.TipoEXAMAtencion)
        General.llenarTabla(docCarga, params, listDocumentosBD)
        For i = 0 To listDocumentosBD.Rows.Count - 1

            raiz = direccion & "\" & listDocumentosBD.Rows(i).Item("Bandera") & ConstantesHC.NOMBRE_PDF_SEPARADOR & i & listDocumentosBD.Rows(i).Item("Extension")
            paso = raiz
            Try
                File.WriteAllBytes(raiz, listDocumentosBD.Rows(i).Item("Archivo"))
                listDocumentos.Rows.Add(listDocumentosBD.Rows(i).Item("Bandera"), raiz)
                FileClose()
            Catch ex As Exception
                errores.Add(paso)
            End Try
        Next
    End Sub

    Public Overrides Sub crearElectrolitos(listReportes As List(Of DocumentoVistaPrevia))
        Try
            Dim params As New List(Of String)
            Dim tipoExamenDescripcion, campoVista As String
            Dim valor As New DataTable
            params.Add(registro)
            params.Add(codigoReporte)
            General.llenarTabla("PROC_LABORATORIO_ATENCION_LISTAR", params, valor)
            If valor.Rows.Count > 0 Then
                Dim documento As New DocumentoVistaPrevia

                documento.nombrePDF = ConstantesHC.NOMBRE_PDF_LAB
                documento.reporte = New rptExamenParaclinicoAtencion
                documento.codigoAdicional = registro
                documento.codigoAdicional2 = valor.Rows(0).Item("codigo_procedimiento")
                documento.codigoAdicional3 = Constantes.TipoEXAMAtencion
                tipoExamenDescripcion = valor.Rows(0).Item("descripcion")
                campoVista = "Laboratorio"
                codigoReporte = 4
                documento.formula = " {VISTA_PARACLINICOS_RESULTADO_ATENCION.Codigo_Orden}=" & registro &
                    " AND {VISTA_PARACLINICOS_RESULTADO_ATENCION.codigoBandera}<> ''" &
                    " AND {VISTA_PARACLINICOS_RESULTADO_ATENCION.Tipo_Examen}='" & Constantes.TipoEXAMAtencion & "'" &
                   " AND {VISTA_PARACLINICOS_RESULTADO_ATENCION.MODULO}=" & codigoReporte & ""
                documento.area = documento.nombrePDF
                listReportes.Add(documento)
            End If
        Catch ex As Exception
            erroresEncontrados += vbCrLf & "Error en LABORATORIO. " & ex.Message
        End Try
    End Sub

    Public Overrides Sub crearAdmision(listReportes As List(Of DocumentoVistaPrevia))
        Try
            Dim params As New List(Of String)
            Dim valor As New DataTable

            General.llenarTabla("PROC_ATENCION_LISTAR", params, valor)
            If valor.Rows.Count > 0 Then

                Dim documento As New DocumentoVistaPrevia
                documento.nombrePDF = ConstantesHC.NOMBRE_PDF_ATENCION_LAB
                documento.reporte = New rptAtencionLab
                documento.codigoAdicional = registro
                documento.formula = "{VISTA_ATENCION_LABORATORIO.Codigo} = " & registro & ""
                documento.area = documento.nombrePDF
                listReportes.Add(documento)

            End If
        Catch ex As Exception
            erroresEncontrados += vbCrLf & "Error en ATENCION. " & ex.Message
        End Try
    End Sub


    Public Overrides Sub crearImagenologia(listReportes As List(Of DocumentoVistaPrevia))
        Try
            Dim params As New List(Of String)
            Dim valor As New DataTable
            params.Add(registro)
            params.Add(codigoReporte)
            General.llenarTabla("PROC_IMAGENOLOGIA_ATENCION_LISTAR", params, valor)
            If valor.Rows.Count > 0 Then


                Dim documento As New DocumentoVistaPrevia
                documento.nombrePDF = ConstantesHC.NOMBRE_PDF_ATENCION
                documento.reporte = New rptImagenologiaAtencion
                documento.codigoAdicional = registro
                documento.formula = "{VISTA_ATENCION_LAB.Codigo_atencion} = " & registro & ""
                documento.area = documento.nombrePDF
                listReportes.Add(documento)

            End If
        Catch ex As Exception
            erroresEncontrados += vbCrLf & "Error en IMAGENOLOGIA. " & ex.Message
        End Try
    End Sub

    Public Overrides Sub crearFactura(listReportes As List(Of DocumentoVistaPrevia))
        Try

            Dim valor As New DataTable
            Dim codigoFactura As String
            Dim tipo, totalFctura As String
            Dim params As New List(Of String)
            params.Add(registro)
            General.llenarTabla("PROC_FACTURA_ATENCION_REGISTRO_LISTAR", params, valor)
            If valor.Rows.Count > 0 Then
                codigoFactura = valor.Rows(0).Item("Codigo_Factura")
                tipo = valor.Rows(0).Item("TipoFactura")
                totalFctura = valor.Rows(0).Item("Total_Factura")
                Dim documento = New DocumentoVistaPrevia
                documento.nombrePDF = ConstantesHC.NOMBRE_PDF_FACTURA_ATENCION
                documento.reporte = New rptFacturaExterna
                documento.codigoAdicional = FuncionesContables.Convertir_Numero(totalFctura)
                documento.codigoAdicional2 = registro

                documento.formula = "{VISTA_FACTURACION.codigo_factura} = '" & codigoFactura &
                                    "' AND {VISTA_FACTURACION.TipoFactura}=" & tipo &
                                    " AND {VISTA_FACTURACION.Id_Empresa}=" & SesionActual.idEmpresa & ""
                documento.area = documento.nombrePDF
                listReportes.Add(documento)
            End If
        Catch ex As Exception
            erroresEncontrados += vbCrLf & "Error en FACTURA. " & ex.Message
        End Try
    End Sub

End Class
