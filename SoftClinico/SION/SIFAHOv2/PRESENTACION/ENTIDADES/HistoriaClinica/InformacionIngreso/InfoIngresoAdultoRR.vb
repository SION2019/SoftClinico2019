Public Class InfoIngresoAdultoRR
    Inherits InfoIngresoAdulto
    Public Sub New()
        sqlDetalleCarga = Consultas.INFO_INGRESO_CARGARRR
        sqlDetalleImpresionCarga = Consultas.INFOIMPRESION_DIAGNOSTICA_CARGARRR
        sqlDetalleRemisionCarga = Consultas.INFOREMISION_DIAGNOSTICA_CARGARRR
        nombreReporte = ConstantesHC.NOMBRE_PDF_INGRESO_MEDICORR
    End Sub

    Public Overrides Sub guardarDetalle()
        HistoriaClinicaBLL.guardarInfoIngresoRR(Me)
    End Sub
End Class
