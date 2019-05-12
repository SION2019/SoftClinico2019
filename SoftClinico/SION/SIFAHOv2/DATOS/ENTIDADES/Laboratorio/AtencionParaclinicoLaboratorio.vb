Public Class AtencionParaclinicoLaboratorio
    Inherits ParaclinicoLaboratorio
    Public Sub New()
        titulo = TitulosForm.ATENCION_EXAMEN_LABORATORIO
        moduloReporte = Constantes.REPORTE_LB
        sqlExamenesGuardar = "[SP_ATENCION_EXAMEN_PARACLINICO_RESULTADO_CREAR]"
        sqlCargarPaciente = "[SP_ATENCION_PACIENTE_EXAMEN_CARGAR]"
        sqlCargarParametros = "[SP_ATENCION_PARACLINICO_RESULTADO_CARGAR]"
        sqlExamenesAnular = "[SP_ATENCION_EXAMEN_PARACLINICO_RESULTADO_ANULADO]"
    End Sub

End Class
