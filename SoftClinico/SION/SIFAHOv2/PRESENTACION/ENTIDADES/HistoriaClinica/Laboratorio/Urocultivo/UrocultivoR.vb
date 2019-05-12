Public Class UrocultivoR
    Inherits Urocultivo
    Public Sub New()
        sqlAnularUrocultivo = ConsultasHC.EXAMENES_PARACLINICOS_UROCUL_ANULAR_R
        sqlGuardarUrocultivo = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_UROC_R
        sqlCargarRegistroUrocultivo = ConsultasHC.PARAMETROS_EXAMES_UROC_R
        nombrePDF = ConstantesHC.NOMBRE_PDF_UROCULTIVO_R
    End Sub
End Class
