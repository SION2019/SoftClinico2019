Public Class TintaChinaRR
    Inherits TintaChina
    Public Sub New()
        sqlAnularTinta = ConsultasHC.EXAMENES_PARACLINICOS_TINTA_ANULAR_RR
        sqlGuardarTinta = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_TINTA_RR
        sqlCargarRegistroTinta = ConsultasHC.PARAMETROS_EXAMES_TINTA_RR
        nombrePDF = ConstantesHC.NOMBRE_PDF_TINTA_RR
    End Sub
End Class
