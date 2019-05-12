Public Class ParametroVentilacionR
    Inherits ParametroVentilacion
    Sub New()
        sqlDetalleCarga = ConsultasHC.PARAMETRO_VENTILACION_CARGAR_R
        sqlDatoPacienteCarga = ConsultasHC.SABANA_PACIENTE_CARGAR_R
        sqlCodigoSabanaCarga = ConsultasHC.PARAMETRO_VENTILACION_CODIGO_SABANA_CARGAR_R
        nombreReporte = ConstantesHC.NOMBRE_PDF_PARAMETRO_VENTI_R
        moduloReporte = Constantes.REPORTE_AM
    End Sub
    Public Overrides Sub guardarDetalle()
        If String.IsNullOrEmpty(codigoSabana) Then
            codigoSabana = Constantes.VALOR_PREDETERMINADO
            ParametroVentilacionDAL.guardarParametroVentilacionAM(Me)
        Else
            editado = ConstantesHC.VALOR_EDITADO
            ParametroVentilacionDAL.actualizarParametroVentilacionAM(Me)
        End If
    End Sub
End Class
