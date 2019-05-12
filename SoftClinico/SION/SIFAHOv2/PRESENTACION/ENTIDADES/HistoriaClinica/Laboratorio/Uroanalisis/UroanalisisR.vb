Public Class UroanalisisR
    Inherits Uroanalisis
    Public Sub New()
        sqlAnularUroanalisis = ConsultasHC.EXAMENES_PARACLINICOS_UROANAL_ANULAR_R
        sqlGuardarUroanalisis = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_UROA_R
        sqlCargarRegistroUroanalisis = ConsultasHC.PARAMETROS_EXAMES_UROA_R
        nombrePDF = ConstantesHC.NOMBRE_PDF_UROANALISIS_R
    End Sub
End Class
