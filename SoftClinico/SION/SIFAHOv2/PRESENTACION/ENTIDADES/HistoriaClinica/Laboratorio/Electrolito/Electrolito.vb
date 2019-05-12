Public Class Electrolito
    Public Property sqlGuardarElectrolito As String
    Public Property sqlAnularElectrolito As String
    Public Property sqlCargarRegistroElectrolito As String
    Public Property nombrePDF As String
    Public Property editado As Integer
    Public Sub New()
        sqlAnularElectrolito = ConsultasHC.EXAMENES_PARACLINICOS_ELECTRO_ANULAR
        sqlGuardarElectrolito = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_ELECTRO
        sqlCargarRegistroElectrolito = ConsultasHC.PARAMETROS_EXAMES_ELECTROLITOS
        nombrePDF = ConstantesHC.NOMBRE_PDF_ELECTROLITO
    End Sub
    Public Function consultaReporteElectrolito(codigoOrden As Integer, modulo As String, idEmpresa As Integer) As String
        Dim consulta As String
        consulta = "{VISTA_ELECTROLITO.Codigo_orden}=" & codigoOrden &
                    "  And {D_EMPLEADO.Id_empresa} =" & idEmpresa &
                    " And {VISTA_ELECTROLITO.Modulo} =" & modulo & ""
        Return consulta
    End Function
End Class
