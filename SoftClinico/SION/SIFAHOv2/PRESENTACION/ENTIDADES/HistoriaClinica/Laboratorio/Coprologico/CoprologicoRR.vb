Public Class CoprologicoRR
    Inherits Coprologico

    Public Sub New()
        sqlAnularCoprologico = ConsultasHC.EXAMENES_PARACLINICOS_COPRO_ANULAR_RR
        sqlGuardarCoprologico = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_COPRO_RR
        sqlCargarRegistroCoprologico = ConsultasHC.PARAMETROS_EXAMES_COPRO_RR
        nombrePDF = ConstantesHC.NOMBRE_PDF_COPROLOGICO_RR
    End Sub
End Class
