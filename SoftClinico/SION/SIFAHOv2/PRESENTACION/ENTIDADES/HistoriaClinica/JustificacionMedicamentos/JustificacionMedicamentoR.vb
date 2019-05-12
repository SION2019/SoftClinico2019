Public Class JustificacionMedicamentoR
    Inherits JustificacionMedicamento

    Sub New()
        diagnosticoSolicitado = Consultas.JUSTIFICACION_CARGAR_DIAG_R
        antibioticoTipo = Consultas.JUSTIFICACION_ANT_DETALLE_CARGAR_R
        anular = Consultas.ANULAR_JUSTIFICACION_ANTIBIOTICO_R
        medicamento = Consultas.JUSTIFICACION_ANT_MEDICAMENTO_CARGAR_R
        Antibioticos = Consultas.JUSTIFICACION_ANTIBIOTICO_CARGAR_R
        diagnosticoEvo = Consultas.DIAGNOSTICO_EVOLUCION_NOPOS_CARGAR_R
        diagnosticoEvo2 = Consultas.DIAGNOSTICO_EVOLUCION_NOPOS_CARGAR2_R
        guardarAntibiotico = Consultas.JUSTIFICACION_GUARDAR_R
        actualizarAntibiotico = Consultas.JUSTIFICACION_ACTUALIZAR_R
        nombrePDF = ConstantesHC.NOMBRE_PDF_JUSTIFICACION_R
        consultaBuscar = Consultas.JUSTIFICACION_ANT_REGISTRO_BUSCAR_R
        cargarBusqueda = Consultas.JUSTIFICACION_ANT_BUSCAR_R
        titulo = "JUSTIFICACIÓN DE ANTIBIOTICOS: AUDITORÍA MÉDICA"
    End Sub

    Public Overrides Sub guardarJustificacion()

        AntibioticoJustificacionBLL.guardarAntibiotico(Me)
    End Sub

End Class
