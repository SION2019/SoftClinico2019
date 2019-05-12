Public Class ExamenLaboratorio
    Public Property usuarioReal As String
    Public Property usuario As String
    Public Property fechaReal As DateTime
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
    Public Sub New()
        sqlCargarPaciente = ConsultasHC.CARGAR_PACIENTE_EXAMEN
        sqlVerificarRegistro = ConsultasHC.VERIFICAR_REGISTRO
        dtExamen = New DataTable
        dtExamen.Columns.Add("Codigo", Type.GetType("System.String"))
        dtExamen.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtExamen.Columns.Add("Resultado", Type.GetType("System.Decimal"))
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
    Public Sub instanciaObjeto(Modulo As String)
        objElectrolito = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_ELECTROLITO & Modulo)
        objHemograma = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_HEMOGRAMA & Modulo)
        objQuimicaSanguinea = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_QUIMICA_SANGUINEA & Modulo)
        objHemocultivo = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_HEMOCULTIVO & Modulo)
        objUrocultivo = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_UROCULTIVO & Modulo)
        objUroanalisis = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_UROANALISIS & Modulo)
        objCoprologico = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_COPROLOGICO & Modulo)
        objSerologia = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_SEROLOGIA & Modulo)
        objTintaChina = GeneralHC.fabricaHC.crear(ConstantesHC.CODIGO_TINTA_CHINA & Modulo)
    End Sub
    Public Sub cargarDatosExamenes()
        Dim params As New List(Of String)
        params.Add(codigoOrden)
        params.Add(codigoGenero)
        params.Add(CodigoExamen)
        Select Case CodigoTipoExamen + 100
            Case ConstantesHC.CODIGO_ELECTROLITO
                titulo = TitulosForm.TITULO_ELECTROLITO
                sqlCargarParametro = objElectrolito.sqlCargarRegistroElectrolito
            Case ConstantesHC.CODIGO_HEMOGRAMA
                titulo = TitulosForm.TITULO_HEMOGRAMA
                sqlCargarParametro = objHemograma.sqlCargarRegistroHemograma
            Case ConstantesHC.CODIGO_QUIMICA_SANGUINEA
                titulo = TitulosForm.TITULO_QUIMICA_SANGUINEA
                sqlCargarParametro = objQuimicaSanguinea.sqlCargarRegistroQuimica
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
        End Select
        General.anularRegistro(sqlAnularExamen & usuario &
             ConstantesHC.NOMBRE_PDF_SEPARADOR3 & codigoOrden &
             ConstantesHC.NOMBRE_PDF_SEPARADOR3 & codigoEP &
             ConstantesHC.NOMBRE_PDF_SEPARADOR3 & objElectrolito.editado)
    End Sub
End Class
