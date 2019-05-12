Public Class TintaChinaR
    Inherits TintaChina

    Public Sub New()
        sqlAnularTinta = ConsultasHC.EXAMENES_PARACLINICOS_TINTA_ANULAR_R
        sqlGuardarTinta = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_TINTA_R
        sqlCargarRegistroTinta = ConsultasHC.PARAMETROS_EXAMES_TINTA_R
        nombrePDF = ConstantesHC.NOMBRE_PDF_TINTA_R
    End Sub

End Class
