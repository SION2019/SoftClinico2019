Public Class ExamenResultadoRR
    Inherits ExamenResultado
    Sub New()
        titulo = TitulosForm.TITULO_RESULT_RR
        area = ConstantesHC.NOMBRE_PDF_RESULTADO_RR
        sqlCargarRegistro = ConsultasHC.RESULTADO_EXAMENES_CARGAR_RR
        sqlCargarRegistroDetalle = ConsultasHC.RESULTADO_EXAMENES_CARGAR_D_RR
        sqlAnularRegistro = ConsultasHC.RESULTADO_EXAMEN_ANULAR_RR
        sqlGuardarRegistro = ConsultasHC.RESULTADO_EXAMEN_GUARDAR_RR
        editado = 1
    End Sub
    Public Overrides Sub guardarRegistro()
        ExamenResultadoBLL.guardarResultado(Me)
    End Sub

End Class
