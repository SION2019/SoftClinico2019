Public Class ParaclinicoLaboratorioR
    Inherits ParaclinicoLaboratorio
    Public Sub New()
        titulo = TitulosForm.EXAMEN_LABORATORIO_R
        moduloReporte = Constantes.REPORTE_AM
        editado = 1
        sqlExamenesGuardar = ConsultasHC.LABORATORIO_PARACLINICO_CREAR_R
        sqlCargarPaciente = ConsultasHC.CARGAR_PACIENTE_EXAMEN_R
        sqlCargarParametros = ConsultasHC.CARGAR_PARAMETRO_LABORATORIO_R
        sqlExamenesAnular = sqlExamenesAnular = ConsultasHC.LABORATORIO_PARACLINICO_ANULAR_R
    End Sub
    Public Overrides Sub cargarNombrePDF()
        Select Case tipoExamen
            Case ConstantesHC.TIPO_EXAMEN_ELECTROLITO
                area = ConstantesHC.NOMBRE_PDF_ELECTROLITO_R
            Case ConstantesHC.TIPO_EXAMEN_HEMOGRAMA
                area = ConstantesHC.NOMBRE_PDF_HEMOGRAMA_R
            Case ConstantesHC.TIPO_EXAMEN_QUIMICASANGUINEA
                area = ConstantesHC.NOMBRE_PDF_QUIMICASANGUINEA_R
            Case ConstantesHC.TIPO_EXAMEN_UROCULTIVO
                area = ConstantesHC.NOMBRE_PDF_UROCULTIVO_R
            Case ConstantesHC.TIPO_EXAMEN_UROANALISIS
                area = ConstantesHC.NOMBRE_PDF_UROANALISIS_R
            Case ConstantesHC.TIPO_EXAMEN_HEMOCULTIVO
                area = ConstantesHC.NOMBRE_PDF_HEMOCULTIVO_R
            Case ConstantesHC.TIPO_EXAMEN_COPROLOGICO
                area = ConstantesHC.NOMBRE_PDF_COPROLOGICO_R
            Case ConstantesHC.TIPO_EXAMEN_COPROSCOPICO
                area = ConstantesHC.NOMBRE_PDF_COPROSCOPICO_R
            Case ConstantesHC.TIPO_EXAMEN_SEROLOGIA
                area = ConstantesHC.NOMBRE_PDF_SEROLOGIA_R
            Case ConstantesHC.TIPO_EXAMEN_TINTACHINA
                area = ConstantesHC.NOMBRE_PDF_TINTACHINA_R
            Case ConstantesHC.TIPO_EXAMEN_IMAGENOLOGIA
                area = ConstantesHC.NOMBRE_PDF_IMAGENOLOGIA_R
            Case ConstantesHC.TIPO_EXAMEN_GASESARTERIALES
                area = ConstantesHC.NOMBRE_PDF_GASESARTERIALES_R
            Case ConstantesHC.TIPO_EXAMEN_TIEMPO_TP
                area = ConstantesHC.NOMBRE_PDF_TIEMPOP_R
            Case ConstantesHC.TIPO_EXAMEN_TIEMPO_TTP
                area = ConstantesHC.NOMBRE_PDF_TIEMPOPT_R
            Case Else
                area = ConstantesHC.NOMBRE_PDF_EXAMEN_PARA_R
        End Select
    End Sub
End Class
