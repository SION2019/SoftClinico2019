Public Class CateterismoCardiaco
    Public Property codigoDescripcion As String
    Public Property codigoCateterismo As String
    Public Property codigoOrden As String
    Public Property codigoProcedimiento As String
    Public Property fechaCateterismo As DateTime
    Public Property idCargo As Integer
    Public Property idAnestesiologo As Integer
    Public Property idRemitido As Integer
    Public Property anularInformeCateterismo As String
    Public Property buscarInformeCateterismo As String
    Public Property cargarInformeCateterismo As String
    Public Property sqlPacienteBuscar As String
    Public Property sqlPacienteCargar As String
    Public Property sqlCargarDetalle As String
    Public Property anulaEpicrisis As String
    Public Property tipoPuncion As Integer
    Public Property tblResultadosInforme As DataTable
    Public Property usuario As Integer
    Public Property usuarioReal As Integer
    Public Property titulo As String
    Public Property nombrePDF As String
    Public Property modulo As String
    Public Property codigoExamen As String
    Public Property dtInformeCateterismo As New DataTable
    Public Property registro As Integer
    Public Property banderaGuardar As Boolean
    Public Property moduloReporte As Integer
    Sub New()
        anularInformeCateterismo = Consultas.INFORME_CATETERISMO_ANULAR
        cargarInformeCateterismo = Consultas.INFORME_CATETERISMO_CARGAR
        sqlPacienteBuscar = Consultas.INFORME_CATETERISMO_PACIENTE_BUSCAR
        sqlPacienteCargar = Consultas.INFORME_CATETERISMO_PACIENTE_CARGAR
        sqlCargarDetalle = Consultas.INFORME_CATETERISMO_CARGAR_D
        nombrePDF = ConstantesHC.NOMBRE_PDF_CATETERISMO
        buscarInformeCateterismo = "[SP_CATETERISMO_BUSCAR]"
        titulo = TitulosForm.TITULO_INFORME_HEMODINAMIA
        moduloReporte = Constantes.REPORTE_HC
    End Sub
    Public Overridable Sub guardarCateterismo()
        Dim cateterismoCardiacoBLL As New CateterismoCardiacoBLL
        cateterismoCardiacoBLL.guardarCateterismo(Me)
    End Sub
    Public Overridable Sub anularCateterismo(activoAM As Boolean, activoAF As Boolean)
        Dim params As New List(Of String)
        params.Add(SesionActual.idUsuario)
        params.Add(codigoCateterismo)
        params.Add(SesionActual.codigoEP)
        General.ejecutarSQL(anularInformeCateterismo, params)

    End Sub
    Public Sub imprimir()
        Dim ruta, nombreArchivo As String
        nombreArchivo = nombrePDF & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigoCateterismo & ConstantesHC.EXTENSION_ARCHIVO_PDF
        ruta = IO.Path.GetTempPath() & nombreArchivo
        'ftp_reportes.llamarArchivo(ruta, nombreArchivo, registro, nombrePDF)
        Dim reporte As New ftp_reportes
        Dim params As New List(Of String)
        params.Add(titulo)
        params.Add(titulo)
        reporte.crearReportePDF(nombrePDF, codigoCateterismo, New rptInformeCateterismo,
                                  codigoCateterismo, "{VISTA_INFORME_CATETERISMO.Codigo_Informe} = " & codigoCateterismo & " AND {VISTA_INFORME_CATETERISMO.Modulo}=" & moduloReporte & "",
                                  nombrePDF, IO.Path.GetTempPath,,, params)

    End Sub

End Class

