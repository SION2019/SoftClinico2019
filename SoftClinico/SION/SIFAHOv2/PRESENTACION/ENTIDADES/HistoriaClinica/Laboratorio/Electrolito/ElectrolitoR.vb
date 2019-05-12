Public Class ElectrolitoR
    Inherits Electrolito
    Public Sub New()
        sqlAnularElectrolito = ConsultasHC.EXAMENES_PARACLINICOS_ELECTRO_ANULAR_R
        sqlGuardarElectrolito = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_ELECTRO_R
        sqlCargarRegistroElectrolito = ConsultasHC.PARAMETROS_EXAMES_ELECTROLITOS_R
        nombrePDF = ConstantesHC.NOMBRE_PDF_ELECTROLITO_R
        editado = Constantes.EDITADO
    End Sub
End Class
