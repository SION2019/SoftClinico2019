Public Class QuimicaSanguineaR
    Inherits QuimicaSanguinea

    Public Sub New()
        sqlAnularQuimica = ConsultasHC.EXAMENES_PARACLINICOS_QUIMICA_ANULAR_R
        sqlGuardarQuimica = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_QUIMICA_R
        sqlCargarRegistroQuimica = ConsultasHC.PARAMETROS_EXAMES_QUIMICA_R
        nombrePDF = ConstantesHC.NOMBRE_PDF_QUIMICA_R
        editado = Constantes.EDITADO
    End Sub

End Class
