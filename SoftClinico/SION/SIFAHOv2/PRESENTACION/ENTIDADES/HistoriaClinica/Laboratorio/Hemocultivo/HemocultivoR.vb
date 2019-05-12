Public Class HemocultivoR
    Inherits Hemocultivo
    Public Sub New()
        sqlAnularHemocultivo = ConsultasHC.EXAMENES_PARACLINICOS_HEMOC_ANULAR_R
        sqlGuardarHemocultivo = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_HEMOC_R
        sqlCargarRegistroHemocultivo = ConsultasHC.PARAMETROS_EXAMES_HEMOC_R
        nombrePDF = ConstantesHC.NOMBRE_PDF_HEMOCULTIVO_R
    End Sub
End Class
