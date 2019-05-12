Public Class ComiteCTCRR
    Inherits ComiteCTC
    Public Sub New()
        sqlCargarDiagnostico = Consultas.EVO_DIAG_ULTIMO_REG_RR
        titulo = "COMITE TECNICO CIENTIFICO (C.T.C): AUDITORÍA FACTURACIÓN"
        sqlBuscarRegistro = Consultas.BUSQUEDA_BUSCAR_CTC_RR
        sqlCargarRegistro = Consultas.CARGAR_CTC_RR
        sqlCargarPaciente = Consultas.CARGAR_PACIENTE_CTC_RR
        sqlBuscarPaciente = Consultas.BUSQUEDA_BUSCAR_PACIENTE_CTC_RR
    End Sub
End Class
