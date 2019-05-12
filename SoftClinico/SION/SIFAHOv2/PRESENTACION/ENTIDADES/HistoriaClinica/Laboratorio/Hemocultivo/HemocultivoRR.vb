Public Class HemocultivoRR
    Inherits Hemocultivo
    Public Sub New()
        sqlAnularHemocultivo = ConsultasHC.EXAMENES_PARACLINICOS_HEMOC_ANULAR_RR
        sqlGuardarHemocultivo = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_HEMOC_RR
        sqlCargarRegistroHemocultivo = ConsultasHC.PARAMETROS_EXAMES_HEMOC_RR
        nombrePDF = ConstantesHC.NOMBRE_PDF_HEMOCULTIVO_RR
    End Sub
End Class
