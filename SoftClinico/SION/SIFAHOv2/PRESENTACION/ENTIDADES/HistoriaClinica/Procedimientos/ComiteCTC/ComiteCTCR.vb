Public Class ComiteCTCR
    Inherits ComiteCTC
    Public Sub New()
        titulo = "COMITE TECNICO CIENTIFICO (C.T.C): AUDITORÍA MÉDICA"
        sqlCargarDiagnostico = Consultas.EVO_DIAG_ULTIMO_REG_R
        sqlBuscarRegistro = Consultas.BUSQUEDA_BUSCAR_CTC_R
        sqlCargarRegistro = Consultas.CARGAR_CTC_R
        sqlCargarPaciente = Consultas.CARGAR_PACIENTE_CTC_R
        sqlBuscarPaciente = Consultas.BUSQUEDA_BUSCAR_PACIENTE_CTC_R
    End Sub
End Class
