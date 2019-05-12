Public Class EstanciaProlongadaRR
    Inherits EstanciaProlongada
    Sub New()
        cargarDatos = Consultas.ESTANCIA_PRO_CARGAR_DATOS_RR
        cargaDiagnosticos = Consultas.DIAGNOSTICOS_ESTANCIA_PRO_RR
        anulaEstancia = Consultas.ANULAR_ESTANCIA_PRO_RR
        nombrePDF = ConstantesHC.NOMBRE_PDF_ESTANCIA_PRO_RR
        moduloReporte = Constantes.REPORTE_AF
        crearTablaEstancia()
    End Sub
    Public Overrides Sub guardarEstancia()
        EstanciaProlongadaBLL.crearEstanciasRR(Me)
    End Sub
End Class
