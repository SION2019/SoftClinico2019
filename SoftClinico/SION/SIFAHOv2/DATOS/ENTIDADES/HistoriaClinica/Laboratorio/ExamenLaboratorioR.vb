Public Class ExamenLaboratorioR
    Inherits ExamenLaboratorio
    Public Sub New()
        idReporte = Constantes.REPORTE_AM
        sqlCargarPaciente = ConsultasHC.CARGAR_PACIENTE_EXAMEN_R
        sqlVerificarRegistro = ConsultasHC.VERIFICAR_REGISTRO_R
        editado = Constantes.EDITADO
    End Sub
End Class
