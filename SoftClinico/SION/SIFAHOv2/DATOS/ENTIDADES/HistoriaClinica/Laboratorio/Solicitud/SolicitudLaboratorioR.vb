Public Class SolicitudLaboratorioR
    Inherits SolicitudLaboratorio
    Public Sub New()
        sqlCargarExamen = ConsultasHC.EXAMEN_LABORATORIO_CARGAR_R
        sqlGenerarLaboratorio = ConsultasHC.EXAMEN_LABORATORIO_GUARDAR_R
        sqlBuscarSolicitud = ConsultasHC.SOLICITUD_LABORATORIO_BUSCAR_R
        sqlCargarSolicitud = ConsultasHC.SOLICITUD_LABORATORIO_CARGAR_R
        sqlAnularSolicitud = ConsultasHC.SOLICITUD_LABORATORIO_ANULAR_R
        editado = Constantes.EDITADO
    End Sub
End Class
