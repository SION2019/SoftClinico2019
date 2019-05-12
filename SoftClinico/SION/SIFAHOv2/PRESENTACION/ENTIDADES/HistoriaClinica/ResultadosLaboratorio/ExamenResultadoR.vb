Public Class ExamenResultadoR
    Inherits ExamenResultado
    Sub New()
        titulo = TitulosForm.TITULO_RESULT_R
        area = ConstantesHC.NOMBRE_PDF_RESULTADO_R
        sqlCargarRegistro = ConsultasHC.RESULTADO_EXAMENES_CARGAR_R
        sqlCargarRegistroDetalle = ConsultasHC.RESULTADO_EXAMENES_CARGAR_D_R
        sqlAnularRegistro = ConsultasHC.RESULTADO_EXAMEN_ANULAR_R
        sqlGuardarRegistro = ConsultasHC.RESULTADO_EXAMEN_GUARDAR_R
        editado = 1
    End Sub
    Public Overrides Sub guardarRegistro()
        ExamenResultadoBLL.guardarResultado(Me)
    End Sub
End Class
