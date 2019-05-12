Public Class ParaclinicoLaboratorioRR
    Inherits ParaclinicoLaboratorio
    Public Sub New()
        titulo = TitulosForm.EXAMEN_LABORATORIO_R
        moduloReporte = Constantes.REPORTE_AF
        editado = 1
        area = ConstantesHC.NOMBRE_PDF_EXAMEN_PARA_RR
        sqlExamenesGuardar = ConsultasHC.LABORATORIO_PARACLINICO_CREAR_RR
        sqlCargarPaciente = ConsultasHC.CARGAR_PACIENTE_EXAMEN_RR
        sqlCargarParametros = ConsultasHC.CARGAR_PARAMETRO_LABORATORIO_RR
        sqlExamenesAnular = ConsultasHC.LABORATORIO_PARACLINICO_ANULAR_RR
    End Sub
    Public Overrides Sub cargarNombrePDF()
        Select Case tipoExamen
            Case ConstantesHC.TIPO_EXAMEN_ELECTROLITO
                area = ConstantesHC.NOMBRE_PDF_ELECTROLITO_RR
            Case ConstantesHC.TIPO_EXAMEN_HEMOGRAMA
                area = ConstantesHC.NOMBRE_PDF_HEMOGRAMA_RR
            Case ConstantesHC.TIPO_EXAMEN_QUIMICASANGUINEA
                area = ConstantesHC.NOMBRE_PDF_QUIMICASANGUINEA_RR
            Case ConstantesHC.TIPO_EXAMEN_UROCULTIVO
                area = ConstantesHC.NOMBRE_PDF_UROCULTIVO_RR
            Case ConstantesHC.TIPO_EXAMEN_UROANALISIS
                area = ConstantesHC.NOMBRE_PDF_UROANALISIS_RR
            Case ConstantesHC.TIPO_EXAMEN_HEMOCULTIVO
                area = ConstantesHC.NOMBRE_PDF_HEMOCULTIVO_RR
            Case ConstantesHC.TIPO_EXAMEN_COPROLOGICO
                area = ConstantesHC.NOMBRE_PDF_COPROLOGICO_RR
            Case ConstantesHC.TIPO_EXAMEN_COPROSCOPICO
                area = ConstantesHC.NOMBRE_PDF_COPROSCOPICO_RR
            Case ConstantesHC.TIPO_EXAMEN_SEROLOGIA
                area = ConstantesHC.NOMBRE_PDF_SEROLOGIA_RR
            Case ConstantesHC.TIPO_EXAMEN_TINTACHINA
                area = ConstantesHC.NOMBRE_PDF_TINTACHINA_RR
            Case ConstantesHC.TIPO_EXAMEN_IMAGENOLOGIA
                area = ConstantesHC.NOMBRE_PDF_IMAGENOLOGIA_RR
            Case ConstantesHC.TIPO_EXAMEN_GASESARTERIALES
                area = ConstantesHC.NOMBRE_PDF_GASESARTERIALES_RR
            Case ConstantesHC.TIPO_EXAMEN_TIEMPO_TP
                area = ConstantesHC.NOMBRE_PDF_TIEMPOP_RR
            Case ConstantesHC.TIPO_EXAMEN_TIEMPO_TTP
                area = ConstantesHC.NOMBRE_PDF_TIEMPOPT_RR
            Case Else
                area = ConstantesHC.NOMBRE_PDF_EXAMEN_PARA_RR
        End Select
    End Sub
End Class
