Public Class SerologiaRR
    Inherits Serologia
    Public Sub New()
        sqlAnularSerologia = ConsultasHC.EXAMENES_PARACLINICOS_SEROL_ANULAR_RR
        sqlGuardarSerologia = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_SEROLOGIA_RR
        sqlCargarRegistroSerologia = ConsultasHC.PARAMETROS_EXAMES_SEROL_RR
        nombrePDF = ConstantesHC.NOMBRE_PDF_SEROLOGIA_RR
    End Sub
End Class
