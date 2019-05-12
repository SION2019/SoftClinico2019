Public Class ExamenLaboratorioRR
    Inherits ExamenLaboratorio
    Public Sub New()
        idReporte = Constantes.REPORTE_AF
        sqlCargarPaciente = ConsultasHC.CARGAR_PACIENTE_EXAMEN_RR
        sqlVerificarRegistro = ConsultasHC.VERIFICAR_REGISTRO_RR
    End Sub
End Class
