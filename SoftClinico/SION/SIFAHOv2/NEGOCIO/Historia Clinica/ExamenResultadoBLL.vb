Public Class ExamenResultadoBLL
    Dim formVisor As Form = Nothing
    Dim control As SplitContainer
    Dim panel As Panel
    Dim nombreControl As String = Nothing
    Public Function guardarResultado(objResultado As ExamenResultado)

        generalConsecutivoImagen(objResultado)

        ExamenResultadoDAL.guardarResultado(objResultado)

        Return objResultado

    End Function
    Public Function guardarResultadoLab(objResultado As ExamenResultado)

        generalConsecutivoImagen(objResultado)

        ExamenResultadoDAL.guardarResultadoLab(objResultado)

        Return objResultado

    End Function

    Public Function guardarResultadoExamen(objResultado As ExamenResultado)

        generalConsecutivoImagen(objResultado)

        ExamenResultadoDAL.guardarResultadoExamenLab(objResultado)

        Return objResultado

    End Function
    Private Sub generalConsecutivoImagen(objResultado As ExamenResultado)

        If objResultado.dtExamen.Rows.Count > 0 Then
            For fila = 0 To objResultado.dtExamen.Rows.Count - 1
                If IsDBNull(objResultado.dtExamen.Rows(fila).Item("idArchivo")) Then
                    objResultado.dtExamen.Rows(fila).Item("idArchivo") = Constantes.VALOR_PREDETERMINADO
                End If
            Next
        End If
    End Sub
    Public Sub visorImagenCompleta(ByRef grupo As GroupBox,
                                    Optional cerrar As Boolean = False)
        If cerrar = False Then
            formVisor = New Windows.Forms.Form
        Else
            control = formVisor.Controls(0)
            grupo.Controls.Add(control)
            control.Panel2Collapsed = False
            formVisor.Dispose()
            Exit Sub
        End If
        Try
            nombreControl = setTipoControl(grupo)
            control = grupo.Controls.Item(0)
            formVisor.FormBorderStyle = FormBorderStyle.None
            formVisor.WindowState = FormWindowState.Maximized
            formVisor.ContextMenuStrip = grupo.ContextMenuStrip
            formVisor.Controls.Add(control)
            control.Dock = DockStyle.Fill
            control.Panel2Collapsed = True
            formVisor.Show()
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
    End Sub
    Private Function setTipoControl(grupo As GroupBox) As String
        Dim nombreControl As String = Nothing
        For Each ctrol As Control In grupo.Controls(0).Controls(0).Controls
            If ctrol.Visible = True Then
                nombreControl = ctrol.Name
            End If
        Next
        Return nombreControl
    End Function
    Public Sub cargarPDF(pdfArchivos As Object, openPdf As OpenFileDialog, objResultadoExam As ExamenResultado)
        Dim arrFile() As Byte = Nothing
        Dim dr As New DataTable
        dr = General.subirPdf(pdfArchivos, openPdf)
        If dr.Rows.Count > 0 Then
            arrFile = File.ReadAllBytes(dr.Rows(dr.Rows.Count - 1).Item(0))
            objResultadoExam.dtExamen.Rows.Add()
            objResultadoExam.dtExamen.Rows(objResultadoExam.dtExamen.Rows.Count - 1).Item("ruta") = dr.Rows(dr.Rows.Count - 1).Item(0)
            objResultadoExam.dtExamen.Rows(objResultadoExam.dtExamen.Rows.Count - 1).Item("nombreArchivo") = dr.Rows(dr.Rows.Count - 1).Item(1)
            objResultadoExam.dtExamen.Rows(objResultadoExam.dtExamen.Rows.Count - 1).Item("Archivo") = arrFile
        End If
    End Sub
    Public Sub visualizar(grupo As Object, indiceFila As Integer, indiceColumna As Integer, objResultadoExam As ExamenResultado)
        Dim control As Object
        Try
            If objResultadoExam.dtExamen.Rows.Count > 0 Then
                If indiceColumna <> 0 Then
                    control = grupo.Controls(0).Controls(0).Controls
                    If control.item("pdfArchivos").Visible = True Then
                        If Not IsDBNull(objResultadoExam.dtExamen.Rows(indiceFila).Item("ruta")) Then
                            control.item("pdfArchivos").LoadFile(objResultadoExam.dtExamen.Rows(indiceFila).Item("ruta"))
                        End If
                    ElseIf control.item("controlDCM").Visible = True Then
                        If System.IO.Path.GetExtension(objResultadoExam.dtExamen.Rows(indiceFila).Item("ruta").ToString) = ConstantesHC.EXTENSION_ARCHIVO_MP4 Then
                            Process.Start(objResultadoExam.dtExamen.Rows(indiceFila).Item("ruta").ToString)
                        Else
                            control.item("controlDCM").DCMfilename = Replace(objResultadoExam.dtExamen.Rows(indiceFila).Item("ruta").ToString(), "JPEG", "jpg")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub quitarResultadoDgv(indiceFila As Integer,
                                  objResultadoExam As ExamenResultado)
        Dim filaEliminar As DataRow
        Try
            If Not IsDBNull(objResultadoExam.dtExamen.Rows(indiceFila).Item("idArchivo")) Then
                filaEliminar = objResultadoExam.dtExamen.Rows(indiceFila)
                objResultadoExam.dtExamenEliminados.ImportRow(filaEliminar)
            End If
            objResultadoExam.dtExamen.Rows.RemoveAt(indiceFila)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Declare Function mciSendString Lib "winmm.dll" _
                             Alias "mciSendStringA" (ByVal lpstrCommand As String,
                                                     ByVal lpstrReturnString As String,
                                                     ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer
    Public Sub llamarGrabadora()
        mciSendString("open new Type waveaudio Alias recsound", "", 0, 0)
        mciSendString("record recsound", "", 0, 0)
    End Sub

    Public Function guardarArchivo(NombreArchivo As String) As String
        Dim ruta As String
        ruta = System.IO.Path.GetTempPath & ConstantesHC.NOMBRE_PDF_SEPARADOR4 & NombreArchivo &
                                            ConstantesHC.EXTENSION_ARCHIVO_MP3
        mciSendString("save recsound " & ruta, "", 0, 0)
        mciSendString("close recsound", "", 0, 0)
        Return ruta
    End Function
    Public Sub reproducirAudio(NombreArchivo As String)
        Dim ruta As String
        ruta = System.IO.Path.GetTempPath & ConstantesHC.NOMBRE_PDF_SEPARADOR4 & NombreArchivo &
                                            ConstantesHC.EXTENSION_ARCHIVO_MP3
        Try
            My.Computer.Audio.Play(ruta, AudioPlayMode.BackgroundLoop)
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
    End Sub


End Class
