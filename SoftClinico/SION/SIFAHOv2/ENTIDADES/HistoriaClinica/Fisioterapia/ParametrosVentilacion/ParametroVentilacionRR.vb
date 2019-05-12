Public Class ParametroVentilacionRR
    Inherits ParametroVentilacion
    Sub New()
        sqlDetalleCarga = ConsultasHC.PARAMETRO_VENTILACION_CARGAR_RR
        sqlDatoPacienteCarga = ConsultasHC.SABANA_PACIENTE_CARGAR_RR
        sqlCodigoSabanaCarga = ConsultasHC.PARAMETRO_VENTILACION_CODIGO_SABANA_CARGAR_RR
        nombreReporte = ConstantesHC.NOMBRE_PDF_PARAMETRO_VENTI_RR
        moduloReporte = Constantes.REPORTE_AF
    End Sub
    Public Overrides Sub guardarDetalle()
        If String.IsNullOrEmpty(codigoSabana) Then
            codigoSabana = Constantes.VALOR_PREDETERMINADO
            ParametroVentilacionDAL.guardarParametroVentilacionAF(Me)
        Else
            editado = ConstantesHC.VALOR_EDITADO
            ParametroVentilacionDAL.actualizarParametroVentilacionAF(Me)
        End If
    End Sub


End Class
