Public Class CateterismoCardiacoR
    Inherits CateterismoCardiaco
    Sub New()
        tblResultadosInforme = New DataTable
        tblResultadosInforme.Columns.Add("Codigo", Type.GetType("System.String"))
        tblResultadosInforme.Columns.Add("Resultado", Type.GetType("System.String"))
        anularInformeCateterismo = Consultas.INFORME_CATETERISMO_ANULAR_R
        cargarInformeCateterismo = Consultas.INFORME_CATETERISMO_CARGAR_R
        sqlPacienteBuscar = Consultas.INFORME_CATETERISMO_PACIENTE_BUSCAR_R
        sqlPacienteCargar = Consultas.INFORME_CATETERISMO_PACIENTE_CARGAR_R
        sqlCargarDetalle = Consultas.INFORME_CATETERISMO_CARGAR_R_D
        buscarInformeCateterismo = "[PROC_CATETERISMO_BUSCAR_R]"
        nombrePDF = ConstantesHC.NOMBRE_PDF_CATETERISMO_R
        titulo = TitulosForm.TITULO_INFORME_HEMODINAMIA_R
        moduloReporte = Constantes.REPORTE_AM
    End Sub
    Public Overrides Sub guardarCateterismo()
        Dim cateterismoCardiacoBLL As New CateterismoCardiacoBLL
        cateterismoCardiacoBLL.guardarCateterismoR(Me)
    End Sub
    Public Overrides Sub anularCateterismo(activoAM As Boolean, activoAF As Boolean)
        Dim params As New List(Of String)
        params.Add(SesionActual.idUsuario)
        params.Add(codigoCateterismo)
        params.Add(SesionActual.codigoEP)
        General.ejecutarSQL(anularInformeCateterismo, params)

    End Sub
End Class
