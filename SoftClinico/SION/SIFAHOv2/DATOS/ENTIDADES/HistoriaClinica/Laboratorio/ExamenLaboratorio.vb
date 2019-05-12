Public Class ExamenLaboratorio
    Public Property idEmpresa As Integer
    Public Property usuarioReal As String
    Public Property usuario As String
    Public Property fechaReal As DateTime
    Public Property registro As Integer
    Public Property codigoOrden As Integer
    Public Property codigoGenero As Integer
    Public Property codigoEP As Integer
    Public Property sqlAnularExamen As String
    Public Property objQuimicaSanguinea As QuimicaSanguinea
    Public Property objHemograma As Hemograma
    Public Property objElectrolito As Electrolito
    Public Property objUrocultivo As Urocultivo
    Public Property objUroanalisis As Uroanalisis
    Public Property objHemocultivo As Hemocultivo
    Public Property objCoprologico As Coprologico
    Public Property objSerologia As Serologia
    Public Property objTintaChina As TintaChina
    Public Property objGrupoTorch As GrupoTorch
    Public Property objLiqCefaloraquideo As LiqCefaloraquideo
    Public Property objKOH As K_O_H
    Public Property objBaciloscopia As Baciloscopia
    Public Property objCultivoCualMuestra As CultCualquierMuestra
    Public Property objGasesArteriales As GasesArteriales
    Public Property CodigoExamen As Integer
    Public Property dtExamen As DataTable
    Public Property dtHemocultivo As DataTable
    Public Property titulo As String
    Public Property CodigoTipoExamen As Integer
    Public Property idReporte As Integer
    Public Property codigoLab As Integer
    Public Property sqlCargarPaciente As String
    Public Property sqlVerificarRegistro As String
    Public Property sqlCargarParametro As String
    Public Property editado As Integer
    Public Property modulo As String

    Private activoAM As Boolean
    Private activoAF As Boolean
    Private reporte As ReportClass
    Public Sub New()
        sqlCargarPaciente = ConsultasHC.CARGAR_PACIENTE_EXAMEN
        sqlVerificarRegistro = ConsultasHC.VERIFICAR_REGISTRO
        dtExamen = New DataTable
        dtExamen.Columns.Add("Codigo", Type.GetType("System.String"))
        dtExamen.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtExamen.Columns.Add("Resultado", Type.GetType("System.String"))
        dtExamen.Columns.Add("Comentario", Type.GetType("System.String"))
        dtExamen.Columns.Add("Referencia", Type.GetType("System.String"))
        dtExamen.Columns.Add("Unidad", Type.GetType("System.String"))

        dtHemocultivo = New DataTable
        dtHemocultivo.Columns.Add("Codigo", Type.GetType("System.Double"))
        dtHemocultivo.Columns.Add("Muestra", Type.GetType("System.String"))
        dtHemocultivo.Columns.Add("Resultado", Type.GetType("System.String"))
        dtHemocultivo.Columns.Add("Comentario", Type.GetType("System.String"))
        idReporte = Constantes.REPORTE_HC
    End Sub
    Public Sub instanciaObjeto()
        objElectrolito = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_ELECTROLITO & modulo)
        objHemograma = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_HEMOGRAMA & modulo)
        objQuimicaSanguinea = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_QUIMICA_SANGUINEA & modulo)
        objHemocultivo = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_HEMOCULTIVO & modulo)
        objUrocultivo = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_UROCULTIVO & modulo)
        objUroanalisis = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_UROANALISIS & modulo)
        objCoprologico = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_COPROLOGICO & modulo)
        objSerologia = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_SEROLOGIA & modulo)
        objTintaChina = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_TINTA_CHINA & modulo)
        objGrupoTorch = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_GRUPO_TORCH & modulo)
        objLiqCefaloraquideo = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_LIQ_CEFALORAQUIDEO & modulo)
        objKOH = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_KOH & modulo)
        objBaciloscopia = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_BACILOSCOPIA & modulo)
        objCultivoCualMuestra = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_CULTIVO_CUALQ_MUESTRA & modulo)
        objGasesArteriales = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_GASES_ARTERIALES & modulo)
    End Sub
    Public Sub cargarDatosExamenes()
        Dim params As New List(Of String)
        params.Add(codigoOrden)
        params.Add(codigoGenero)
        params.Add(CodigoExamen)
        Select Case CodigoTipoExamen
            Case ConstantesHC.CODIGO_ELECTROLITO
                titulo = TitulosForm.TITULO_ELECTROLITO
                sqlCargarParametro = objElectrolito.sqlCargarRegistroElectrolito
            Case ConstantesHC.CODIGO_HEMOGRAMA
                titulo = TitulosForm.TITULO_HEMOGRAMA
                sqlCargarParametro = objHemograma.sqlCargarRegistroHemograma
            Case ConstantesHC.CODIGO_QUIMICA_SANGUINEA
                titulo = TitulosForm.TITULO_QUIMICA_SANGUINEA
                sqlCargarParametro = objQuimicaSanguinea.sqlCargarRegistroQuimica
            Case ConstantesHC.CODIGO_GRUPO_TORCH
                titulo = TitulosForm.TITULO_GRUPO_TORCH
                sqlCargarParametro = objGrupoTorch.sqlCargarRegistroGrupoTorch
            Case ConstantesHC.CODIGO_GASES_ARTERIALES
                titulo = TitulosForm.TITULO_GASES_ARTERIALES
                sqlCargarParametro = objGasesArteriales.sqlCargarRegistroGasesArteriales
        End Select
        General.llenarTabla(sqlCargarParametro, params, dtExamen)
    End Sub
    Public Function cargarPacienteExamen() As DataRow
        Dim dFila As DataRow
        Dim params As New List(Of String)
        params.Add(codigoOrden)
        dFila = General.cargarItem(sqlCargarPaciente, params)
        Return dFila
    End Function
    Public Function verificarExistencia() As Integer
        Dim params As New List(Of String)
        Dim vVerificar As Integer
        Dim dFila As DataRow
        params.Add(codigoOrden)
        params.Add(CodigoExamen)
        params.Add(CodigoTipoExamen)
        dFila = General.cargarItem(sqlVerificarRegistro, params)
        vVerificar = dFila.Item(0)
        Return vVerificar
    End Function
    Public Sub cargarHemocultivo()
        Dim params As New List(Of String)
        params.Add(codigoOrden)
        General.llenarTabla(objHemocultivo.sqlCargarRegistroHemocultivo, params, dtHemocultivo)
    End Sub
    Public Sub anulaExamen()
        Select Case CodigoTipoExamen
            Case ConstantesHC.CODIGO_ELECTROLITO
                sqlAnularExamen = objElectrolito.sqlAnularElectrolito
            Case ConstantesHC.CODIGO_HEMOGRAMA
                sqlAnularExamen = objHemograma.sqlAnularHemograma
            Case ConstantesHC.CODIGO_QUIMICA_SANGUINEA
                sqlAnularExamen = objQuimicaSanguinea.sqlAnularQuimica
            Case ConstantesHC.CODIGO_UROCULTIVO
                sqlAnularExamen = objUrocultivo.sqlAnularUrocultivo
            Case ConstantesHC.CODIGO_UROANALISIS
                sqlAnularExamen = objUroanalisis.sqlAnularUroanalisis
            Case ConstantesHC.CODIGO_HEMOCULTIVO
                sqlAnularExamen = objHemocultivo.sqlAnularHemocultivo
            Case ConstantesHC.CODIGO_COPROLOGICO
                sqlAnularExamen = objCoprologico.sqlAnularCoprologico
            Case ConstantesHC.CODIGO_SEROLOGIA
                sqlAnularExamen = objSerologia.sqlAnularSerologia
            Case ConstantesHC.CODIGO_TINTA_CHINA
                sqlAnularExamen = objTintaChina.sqlAnularTinta
            Case ConstantesHC.CODIGO_GRUPO_TORCH
                sqlAnularExamen = objGrupoTorch.sqlAnularGrupoTorch
            Case ConstantesHC.CODIGO_LIQ_CEFALORAQUIDEO
                sqlAnularExamen = objLiqCefaloraquideo.sqlAnularLiqCefaloraquideo
            Case ConstantesHC.CODIGO_KOH
                sqlAnularExamen = objKOH.sqlAnularKOH
            Case ConstantesHC.CODIGO_BACILOSCOPIA
                sqlAnularExamen = objBaciloscopia.sqlAnularBaciloscopia
            Case ConstantesHC.CODIGO_CULTIVO_CUALQ_MUESTRA
                sqlAnularExamen = objCultivoCualMuestra.sqlAnularCultCualMuestra
            Case ConstantesHC.CODIGO_GASES_ARTERIALES
                sqlAnularExamen = objGasesArteriales.sqlAnularGasesArteriales
        End Select
        General.anularRegistro(sqlAnularExamen & usuario &
              ConstantesHC.NOMBRE_PDF_SEPARADOR3 & codigoOrden &
              ConstantesHC.NOMBRE_PDF_SEPARADOR3 & editado &
              ConstantesHC.NOMBRE_PDF_SEPARADOR3 & codigoEP)
    End Sub
    Public Sub generarReporteLab()
        Dim listaContenedor As New List(Of Object)
        listaContenedor = cargarDatosReporte()
        reporte = listaContenedor.Item(0)
        activoAM = General.getEstadoVF(Consultas.MODULO_VERIFICAR & codigoEP & ",'" & Constantes.AM & "'")
        activoAF = General.getEstadoVF(Consultas.MODULO_VERIFICAR & codigoEP & ",'" & Constantes.AF & "'")
        GeneralHC.crearInforme(modulo, activoAM, activoAF,
                               usuario, registro,
                               reporte, codigoOrden,
        Replace(Replace(Replace(listaContenedor.Item(1), "$3", Constantes.REPORTE_HC), "$2", idEmpresa), "$", codigoOrden),
        Replace(Replace(Replace(listaContenedor.Item(1), "$3", Constantes.REPORTE_AM), "$2", idEmpresa), "$", codigoOrden),
        Replace(Replace(Replace(listaContenedor.Item(1), "$3", Constantes.REPORTE_AF), "$2", idEmpresa), "$", codigoOrden),
        listaContenedor.Item(2),
        listaContenedor.Item(3),
        listaContenedor.Item(4))
    End Sub
    Private Function cargarDatosReporte() As List(Of Object)
        Dim listaContenedor As New List(Of Object)
        Select Case CodigoTipoExamen
            Case ConstantesHC.CODIGO_ELECTROLITO
                listaContenedor = objElectrolito.consultaReporteElectrolito
            Case ConstantesHC.CODIGO_HEMOGRAMA
                listaContenedor = objHemograma.consultaReporteHemograma
            Case ConstantesHC.CODIGO_QUIMICA_SANGUINEA
                listaContenedor = objQuimicaSanguinea.consultaReporteQuimica
            Case ConstantesHC.CODIGO_UROCULTIVO
                listaContenedor = objUrocultivo.consultaReporteUrocultivo
            Case ConstantesHC.CODIGO_UROANALISIS
                listaContenedor = objUroanalisis.consultaReporteUroanalisis
            Case ConstantesHC.CODIGO_HEMOCULTIVO
                listaContenedor = objHemocultivo.consultaReporteHemocultivo
            Case ConstantesHC.CODIGO_COPROLOGICO
                listaContenedor = objCoprologico.consultaReporteCoprologico
            Case ConstantesHC.CODIGO_SEROLOGIA
                listaContenedor = objSerologia.consultaReporteSerologia
            Case ConstantesHC.CODIGO_TINTA_CHINA
                listaContenedor = objTintaChina.consultaReporteTintaChina
            Case ConstantesHC.CODIGO_GRUPO_TORCH
                listaContenedor = objGrupoTorch.consultaReporteGrupoTorch
            Case ConstantesHC.CODIGO_LIQ_CEFALORAQUIDEO
                listaContenedor = objLiqCefaloraquideo.consultaReporteLiqCefaloraquideo
            Case ConstantesHC.CODIGO_KOH
                listaContenedor = objKOH.consultaReporteKOH
            Case ConstantesHC.CODIGO_BACILOSCOPIA
                listaContenedor = objBaciloscopia.consultaReporteBaciloscopia
            Case ConstantesHC.CODIGO_CULTIVO_CUALQ_MUESTRA
                listaContenedor = objCultivoCualMuestra.consultaReporteCultCualMuestra
            Case ConstantesHC.CODIGO_GASES_ARTERIALES
                listaContenedor = objGasesArteriales.consultaReporteGasesArteriales
        End Select

        Return listaContenedor

    End Function
    Public Function areaReporte() As String
        Dim area As String = Nothing
        Select Case CodigoTipoExamen
            Case ConstantesHC.CODIGO_ELECTROLITO
                area = objElectrolito.nombrePDF
            Case ConstantesHC.CODIGO_HEMOGRAMA
                area = objHemograma.nombrePDF
            Case ConstantesHC.CODIGO_QUIMICA_SANGUINEA
                area = objQuimicaSanguinea.nombrePDF
            Case ConstantesHC.CODIGO_UROCULTIVO
                area = objUrocultivo.nombrePDF
            Case ConstantesHC.CODIGO_UROANALISIS
                area = objUroanalisis.nombrePDF
            Case ConstantesHC.CODIGO_HEMOCULTIVO
                area = objHemocultivo.nombrePDF
            Case ConstantesHC.CODIGO_COPROLOGICO
                area = objCoprologico.nombrePDF
            Case ConstantesHC.CODIGO_SEROLOGIA
                area = objSerologia.nombrePDF
            Case ConstantesHC.CODIGO_TINTA_CHINA
                area = objTintaChina.nombrePDF
            Case ConstantesHC.CODIGO_GRUPO_TORCH
                area = objGrupoTorch.nombrePDF
            Case ConstantesHC.CODIGO_LIQ_CEFALORAQUIDEO
                area = objLiqCefaloraquideo.nombrePDF
            Case ConstantesHC.CODIGO_KOH
                area = objKOH.nombrePDF
            Case ConstantesHC.CODIGO_BACILOSCOPIA
                area = objBaciloscopia.nombrePDF
            Case ConstantesHC.CODIGO_CULTIVO_CUALQ_MUESTRA
                area = objCultivoCualMuestra.nombrePDF
            Case ConstantesHC.CODIGO_GASES_ARTERIALES
                area = objGasesArteriales.nombrePDF
        End Select
        Return area
    End Function
End Class
