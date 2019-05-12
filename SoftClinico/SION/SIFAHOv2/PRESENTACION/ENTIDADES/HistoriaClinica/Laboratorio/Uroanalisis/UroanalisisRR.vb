Public Class UroanalisisRR
    Inherits Uroanalisis
    Public Sub New()
        sqlAnularUroanalisis = ConsultasHC.EXAMENES_PARACLINICOS_UROANAL_ANULAR_RR
        sqlGuardarUroanalisis = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_UROA_RR
        sqlCargarRegistroUroanalisis = ConsultasHC.PARAMETROS_EXAMES_UROA_RR
        nombrePDF = ConstantesHC.NOMBRE_PDF_UROANALISIS_RR
    End Sub
End Class
