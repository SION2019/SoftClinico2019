Public Class EstanciaProlongadaR
    Inherits EstanciaProlongada
    Sub New()
        cargarDatos = Consultas.ESTANCIA_PRO_CARGAR_DATOS_R
        cargaDiagnosticos = Consultas.DIAGNOSTICOS_ESTANCIA_PRO_R
        anulaEstancia = Consultas.ANULAR_ESTANCIA_PRO_R
        nombrePDF = ConstantesHC.NOMBRE_PDF_ESTANCIA_PRO_R
        moduloReporte = Constantes.REPORTE_AM
        crearTablaEstancia()
    End Sub
    Public Overrides Sub guardarEstancia()
        EstanciaProlongadaBLL.crearEstanciasR(Me)
    End Sub
End Class
