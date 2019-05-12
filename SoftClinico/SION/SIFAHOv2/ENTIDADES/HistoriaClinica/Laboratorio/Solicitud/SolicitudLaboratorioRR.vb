Public Class SolicitudLaboratorioRR
    Inherits SolicitudLaboratorio
    Public Sub New()
        sqlCargarExamen = ConsultasHC.EXAMEN_LABORATORIO_CARGAR_RR
        sqlGenerarLaboratorio = ConsultasHC.EXAMEN_LABORATORIO_GUARDAR_RR
        sqlBuscarSolicitud = ConsultasHC.SOLICITUD_LABORATORIO_BUSCAR_RR
        sqlCargarSolicitud = ConsultasHC.SOLICITUD_LABORATORIO_CARGAR_RR
        sqlAnularSolicitud = ConsultasHC.SOLICITUD_LABORATORIO_ANULAR_RR
        editado = Constantes.EDITADO
    End Sub
End Class
