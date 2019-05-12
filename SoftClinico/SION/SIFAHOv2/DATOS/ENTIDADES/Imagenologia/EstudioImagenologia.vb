Public Class EstudioImagenologia
    Inherits ExamenResultado
    Property usuarioInforme As Integer
    Property pPendiente As String
    Property pRealizado As String
    Property pEnvioCorreo As String
    Property pVer As String
    Property sqlConsulta As String
    Property dtImagenologia As DataTable
    Property existencia As Integer
    Public Property nombreReporte As String
    Public Property tipo As String
    Property procedencia As Integer
    Public Sub New()
        dtImagenologia = New DataTable
        dtImagenologia.Columns.Add("Registro", Type.GetType("System.Int32"))
        dtImagenologia.Columns.Add("paciente", Type.GetType("System.String"))
        dtImagenologia.Columns.Add("eps", Type.GetType("System.String"))
        dtImagenologia.Columns.Add("descripcion", Type.GetType("System.String"))
        dtImagenologia.Columns.Add("area_servicio", Type.GetType("System.String"))
        dtImagenologia.Columns.Add("fecha", Type.GetType("System.DateTime"))
        dtImagenologia.Columns.Add("Codigo_Orden", Type.GetType("System.Int32"))
        dtImagenologia.Columns.Add("Codigo_Procedimiento", Type.GetType("System.String"))
        dtImagenologia.Columns.Add("Codigo_Especialidad", Type.GetType("System.String"))
        dtImagenologia.Columns.Add("TipoExamen", Type.GetType("System.String"))
        dtImagenologia.Columns.Add("Abrir_Atencion", Type.GetType("System.String"))
        dtImagenologia.Columns.Add("Abrir_Resultado", Type.GetType("System.Object"))
        dtImagenologia.Columns.Add("Abrir_Laboratorio", Type.GetType("System.String"))
        dtImagenologia.Columns.Add("Imprimir", Type.GetType("System.Object"))
        dtImagenologia.Columns.Add("Enviar", Type.GetType("System.Object"))
        sqlConsulta = ConsultasHC.IMAGENOLOGIA_CARGAR
    End Sub

    Public Sub tituloFormulario(moduloReal As String)
        Select Case moduloReal
            Case Constantes.HC
                titulo = TitulosForm.TITULO_IMAGENOLOGIA
            Case Constantes.AM
                titulo = TitulosForm.TITULO_IMAGENOLOGIA_R
            Case Constantes.AF
                titulo = TitulosForm.TITULO_IMAGENOLOGIA_RR
            Case Else
                titulo = TitulosForm.TITULO_ESTUDIO
        End Select
    End Sub
    Public Sub cargarDatos(fechaInicio As Date,
                           fechaFin As Date,
                           codigoArea As String,
                           cadena As String, codigoEP As Integer)
        Dim params As New List(Of String)
        params.Add(fechaInicio)
        params.Add(fechaFin)
        params.Add(codigoArea)
        params.Add(existencia)
        params.Add(cadena)
        params.Add(codigoEP)
        params.Add(procedencia)
        General.llenarTabla(sqlConsulta, params, dtImagenologia)
    End Sub

    Public Sub imprimirReporte()
        Try
            Dim nombreArchivo, ruta, formula, codigoNombre, vista, modul As String
            vista = ""
            If modulo = Constantes.HC Then
                nombreReporte = ConstantesHC.NOMBRE_PDF_IMAGENOLOGIA
                modul = Constantes.REPORTE_HC
            ElseIf modulo = Constantes.AM Then
                nombreReporte = ConstantesHC.NOMBRE_PDF_IMAGENOLOGIA_R
                modul = Constantes.REPORTE_AM
            Else
                nombreReporte = ConstantesHC.NOMBRE_PDF_IMAGENOLOGIA_RR
                modul = Constantes.REPORTE_AF
            End If
            Dim reportes As New Object
            If tipo = Constantes.HISTORIA_CLIN Then
                reportes = New rptImagenologia
                vista = "{VISTA_IMAGENOLOGIA_SOLICITUD.N_Registro} = " & nRegistro & " AND {VISTA_IMAGENOLOGIA_SOLICITUD.codigo_procedimiento} ='" & CodigoProcedimiento & "' AND {VISTA_IMAGENOLOGIA_SOLICITUD.modulo} = " & modul & ""
            ElseIf tipo = Constantes.ATENCION_LAB Then
                reportes = New rptImagenologiaAtencion
                vista = "{VISTA_ATENCION_LAB.Codigo_atencion} = " & nRegistro & " AND {VISTA_ATENCION_LAB.codigo_procedimiento} ='" & CodigoProcedimiento & "'"
                nombreReporte = ConstantesHC.NOMBRE_PDF_ATENCION
            ElseIf tipo = Constantes.EXAM_LAB Then
                reportes = New rptExamenesLab
                vista = "{VISTA_EXAMEN_LAB.Codigo_atencion} = " & nRegistro & " AND {VISTA_EXAMEN_LAB.codigo_procedimiento} ='" & CodigoProcedimiento & "'"
                nombreReporte = ConstantesHC.NOMBRE_PDF_LAB
            End If
            codigoNombre = nRegistro
            nombreArchivo = nombreReporte & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigoNombre & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = Path.GetTempPath() & nombreArchivo
            formula = vista
            Dim reporte As New ftp_reportes
            reporte.crearReportePDF(nombreReporte, nRegistro, reportes,
                                  codigoNombre, formula,
                                  nombreReporte, IO.Path.GetTempPath)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
