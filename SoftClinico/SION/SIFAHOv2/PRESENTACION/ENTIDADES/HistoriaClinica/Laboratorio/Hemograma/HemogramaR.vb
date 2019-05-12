Public Class HemogramaR
    Inherits Hemograma
    Public Sub New()
        sqlAnularHemograma = ConsultasHC.EXAMENES_PARACLINICOS_HEMOG_ANULAR_R
        sqlGuardarHemograma = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_HEMOG_R
        sqlCargarRegistroHemograma = ConsultasHC.PARAMETROS_EXAMES_HEMOGRAMA_R
        nombrePDF = ConstantesHC.NOMBRE_PDF_HEMOGRAMA_R
        Editado = Constantes.EDITADO

    End Sub
End Class
