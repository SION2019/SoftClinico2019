Public Class UrocultivoRR
    Inherits Urocultivo
    Public Sub New()
        sqlAnularUrocultivo = ConsultasHC.EXAMENES_PARACLINICOS_UROCUL_ANULAR_RR
        sqlGuardarUrocultivo = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_UROC_RR
        sqlCargarRegistroUrocultivo = ConsultasHC.PARAMETROS_EXAMES_UROC_RR
        nombrePDF = ConstantesHC.NOMBRE_PDF_UROCULTIVO_RR
    End Sub
End Class
