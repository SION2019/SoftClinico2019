Public Class CateterismoCardiacoRR
    Inherits CateterismoCardiaco
    Sub New()
        tblResultadosInforme = New DataTable
        tblResultadosInforme.Columns.Add("Codigo", Type.GetType("System.String"))
        tblResultadosInforme.Columns.Add("Resultado", Type.GetType("System.String"))
        anularInformeCateterismo = Consultas.INFORME_CATETERISMO_ANULAR_RR
        cargarInformeCateterismo = Consultas.INFORME_CATETERISMO_CARGAR_RR
        sqlPacienteBuscar = Consultas.INFORME_CATETERISMO_PACIENTE_BUSCAR_RR
        sqlPacienteCargar = Consultas.INFORME_CATETERISMO_PACIENTE_CARGAR_RR
        sqlCargarDetalle = Consultas.INFORME_CATETERISMO_CARGAR_RR_D
        buscarInformeCateterismo = "[PROC_CATETERISMO_BUSCAR_RR]"
        nombrePDF = ConstantesHC.NOMBRE_PDF_CATETERISMO_RR
        titulo = TitulosForm.TITULO_INFORME_HEMODINAMIA_RR
        moduloReporte = Constantes.REPORTE_AF
    End Sub
    Public Overrides Sub guardarCateterismo()
        Dim cateterismoCardiacoBLL As New CateterismoCardiacoBLL
        cateterismoCardiacoBLL.guardarCateterismoRR(Me)
    End Sub
    Public Overrides Sub anularCateterismo(activoAM As Boolean, activoAF As Boolean)
        Dim params As New List(Of String)
        params.Add(SesionActual.idUsuario)
        params.Add(codigoCateterismo)
        General.ejecutarSQL(anularInformeCateterismo, params)
    End Sub
End Class
