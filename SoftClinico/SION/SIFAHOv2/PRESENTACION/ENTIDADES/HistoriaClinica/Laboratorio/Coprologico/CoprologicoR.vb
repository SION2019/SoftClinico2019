Public Class CoprologicoR
    Inherits Coprologico
    Public Sub New()
        sqlAnularCoprologico = ConsultasHC.EXAMENES_PARACLINICOS_COPRO_ANULAR_R
        sqlGuardarCoprologico = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_COPRO_R
        sqlCargarRegistroCoprologico = ConsultasHC.PARAMETROS_EXAMES_COPRO_R
        nombrePDF = ConstantesHC.NOMBRE_PDF_COPROLOGICO_R
    End Sub
End Class
