Public Class Hemocultivo

    Public Property sqlGuardarHemocultivo As String
    Public Property sqlAnularHemocultivo As String
    Public Property sqlCargarRegistroHemocultivo As String
    Public Property nombrePDF As String
    Public Sub New()
        sqlAnularHemocultivo = ConsultasHC.EXAMENES_PARACLINICOS_HEMOC_ANULAR
        sqlGuardarHemocultivo = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_HEMOC
        sqlCargarRegistroHemocultivo = ConsultasHC.PARAMETROS_EXAMES_HEMOC
        nombrePDF = ConstantesHC.NOMBRE_PDF_HEMOCULTIVO
    End Sub
    Public Function consultaReporteHemocultivo(codigoOrden As Integer, modulo As String, idEmpresa As Integer) As String
        Dim consulta As String
        consulta = "{VISTA_HEMOCULTIVO.Codigo_orden}=" & codigoOrden &
                    "  And {D_EMPLEADO.Id_empresa} =" & idEmpresa &
                    " And {VISTA_HEMOCULTIVO.Modulo} =" & modulo & ""
        Return consulta
    End Function

End Class
