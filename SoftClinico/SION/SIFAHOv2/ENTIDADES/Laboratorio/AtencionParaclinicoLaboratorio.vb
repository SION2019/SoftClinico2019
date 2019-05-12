Public Class AtencionParaclinicoLaboratorio
    Inherits ParaclinicoLaboratorio
    Public Sub New()
        titulo = TitulosForm.ATENCION_EXAMEN_LABORATORIO
        moduloReporte = Constantes.REPORTE_LB
        sqlExamenesGuardar = "[PROC_ATENCION_EXAMEN_PARACLINICO_RESULTADO_CREAR]"
        sqlCargarPaciente = "[PROC_ATENCION_PACIENTE_EXAMEN_CARGAR]"
        sqlCargarParametros = "[PROC_ATENCION_PARACLINICO_RESULTADO_CARGAR]"
        sqlExamenesAnular = "[PROC_ATENCION_EXAMEN_PARACLINICO_RESULTADO_ANULADO]"
    End Sub

End Class
