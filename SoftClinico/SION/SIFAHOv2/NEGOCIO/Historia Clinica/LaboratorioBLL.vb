Public Class LaboratorioBLL
    Public Shared Function guardarSolicitudLab(objSolicitud As SolicitudLaboratorio)
        LaboratorioDAL.guardarSolicitud(objSolicitud)
        Return objSolicitud
    End Function
End Class
