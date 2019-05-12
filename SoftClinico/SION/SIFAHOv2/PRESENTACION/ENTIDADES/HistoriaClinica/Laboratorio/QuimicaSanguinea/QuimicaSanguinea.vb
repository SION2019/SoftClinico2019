Public Class QuimicaSanguinea

    Public Property sqlGuardarQuimica As String
    Public Property sqlAnularQuimica As String
    Public Property sqlCargarRegistroQuimica As String
    Public Property nombrePDF As String
    Public Property editado As Integer
    Public Sub New()
        sqlAnularQuimica = ConsultasHC.EXAMENES_PARACLINICOS_QUIMICA_ANULAR
        sqlGuardarQuimica = ConsultasHC.GUARDAR_EXAMENES_PARACLINICOS_QUIMICA
        sqlCargarRegistroQuimica = ConsultasHC.PARAMETROS_EXAMES_QUIMICA
        nombrePDF = ConstantesHC.NOMBRE_PDF_QUIMICA
    End Sub
    Public Function consultaReporteQuimica(codigoOrden As Integer, modulo As String, idEmpresa As Integer) As String
        Dim consulta As String
        consulta = "{VISTA_QUIMICA_SANGUINEA.Codigo_orden} =" & codigoOrden &
                   " And {VISTA_QUIMICA_SANGUINEA.Modulo} =" & modulo &
                   " And {D_EMPLEADO.Id_empresa} =" & idEmpresa & ""
        Return consulta
    End Function
End Class
