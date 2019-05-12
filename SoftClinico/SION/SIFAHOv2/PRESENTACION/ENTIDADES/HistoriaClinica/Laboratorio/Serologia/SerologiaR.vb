Public Class SerologiaR
    Inherits Serologia
    Public Sub New()
        sqlAnularSerologia = ConsultasHC.EXAMENES_PARACLINICOS_SEROL_ANULAR_R
        sqlGuardarSerologia = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_SEROLOGIA_R
        sqlCargarRegistroSerologia = ConsultasHC.PARAMETROS_EXAMES_SEROL_R
        nombrePDF = ConstantesHC.NOMBRE_PDF_SEROLOGIA_R
    End Sub
End Class
