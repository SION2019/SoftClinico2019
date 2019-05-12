Public Class ElectrolitoRR
    Inherits Electrolito
    Public Sub New()
        sqlAnularElectrolito = ConsultasHC.EXAMENES_PARACLINICOS_ELECTRO_ANULAR_RR
        sqlGuardarElectrolito = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_ELECTRO_RR
        sqlCargarRegistroElectrolito = ConsultasHC.PARAMETROS_EXAMES_ELECTROLITOS_RR
        nombrePDF = ConstantesHC.NOMBRE_PDF_ELECTROLITO_RR
        editado = Constantes.EDITADO
    End Sub
End Class
