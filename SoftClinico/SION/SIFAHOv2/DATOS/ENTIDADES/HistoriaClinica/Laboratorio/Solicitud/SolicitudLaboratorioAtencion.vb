Public Class SolicitudLaboratorioAtencion
    Inherits SolicitudLaboratorio
    Public Sub New()
        sqlGenerarLaboratorio = ConsultasHC.EXAMEN_LABORATORIO_GUARDAR
        sqlCargarExamen = ConsultasHC.EXAMEN_LABORATORIO_ATENCION_CARGAR
        sqlBuscarSolicitud = ConsultasHC.SOLICITUD_LABORATORIO_BUSCAR
        sqlCargarComboLaboratorio = ConsultasHC.LISTA_LABORATORIO_CARGAR
        sqlCargarSolicitud = ConsultasHC.SOLICITUD_LABORATORIO_CARGAR
        sqlAnularSolicitud = ConsultasHC.SOLICITUD_LABORATORIO_ANULAR
    End Sub

    Public Overrides Sub asignarValores(objPadre As Object)
        codigoOrden = objPadre.codigoAtencion
        tipoExamen = Constantes.TipoEXAMAtencion
    End Sub
End Class
