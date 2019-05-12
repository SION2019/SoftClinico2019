Public Class HemogramaRR
    Inherits Hemograma
    Public Sub New()
        sqlAnularHemograma = ConsultasHC.EXAMENES_PARACLINICOS_HEMOG_ANULAR_RR
        sqlGuardarHemograma = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_QUIMICA_RR
        sqlCargarRegistroHemograma = ConsultasHC.PARAMETROS_EXAMES_HEMOGRAMA
        nombrePDF = ConstantesHC.NOMBRE_PDF_HEMOGRAMA_RR
        Editado = Constantes.EDITADO
    End Sub
End Class
