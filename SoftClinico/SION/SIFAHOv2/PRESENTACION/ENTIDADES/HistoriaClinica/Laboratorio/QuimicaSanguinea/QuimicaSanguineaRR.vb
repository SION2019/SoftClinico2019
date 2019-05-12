Public Class QuimicaSanguineaRR
    Inherits QuimicaSanguinea
    Public Sub New()
        sqlAnularQuimica = ConsultasHC.EXAMENES_PARACLINICOS_QUIMICA_ANULAR_RR
        sqlGuardarQuimica = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_QUIMICA_RR
        sqlCargarRegistroQuimica = ConsultasHC.PARAMETROS_EXAMES_QUIMICA_RR
        nombrePDF = ConstantesHC.NOMBRE_PDF_QUIMICA_RR
        editado = Constantes.EDITADO
    End Sub

End Class
