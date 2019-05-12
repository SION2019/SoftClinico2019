Public Class Hemograma

    Public Property sqlGuardarHemograma As String
    Public Property sqlAnularHemograma As String
    Public Property sqlCargarRegistroHemograma As String
    Public Property nombrePDF As String
    Public Property Editado As Integer

    Public Sub New()
        sqlAnularHemograma = ConsultasHC.EXAMENES_PARACLINICOS_HEMOG_ANULAR
        sqlGuardarHemograma = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_HEMOG
        sqlCargarRegistroHemograma = ConsultasHC.PARAMETROS_EXAMES_HEMOGRAMA
        nombrePDF = ConstantesHC.NOMBRE_PDF_HEMOGRAMA
    End Sub

    Public Function consultaReporteHemograma(codigoOrden As Integer, modulo As String, idEmpresa As Integer) As String
        Dim consulta As String
        consulta = "{VISTA_HEMOGRAMA.Codigo_orden}=" & codigoOrden &
                    "  And {D_EMPLEADO.Id_empresa} =" & idEmpresa &
                    " And {VISTA_HEMOGRAMA.Modulo} =" & modulo & ""
        Return consulta
    End Function
End Class