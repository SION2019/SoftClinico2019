Public Class FacturaAtencionAsistencialRR
    Inherits FacturaAtencionAsistencial

    Public Overrides Sub consultasCargarDatos()
        sqlPrecargarEstancias = ConsultasAsis.FACTURA_ESTANCIAS_CARGARR
        sqlPrecargarOxigenos = ConsultasAsis.FACTURA_OXIGENO_CARGARR
        sqlPrecargarParaclinicos = ConsultasAsis.FACTURA_PARACLINICOS_CARGARR
        sqlPrecargarHemoderivados = ConsultasAsis.FACTURA_HEMODERIVADOS_CARGARR
        sqlPrecargarProcedimientos = ConsultasAsis.FACTURA_PROCEDIMIENTOS_CARGARR
        sqlPrecargarMedicamentos = ConsultasAsis.FACTURA_MEDICAMENTOS_CARGARRR
        sqlPrecargarMedicamentosCTC = ConsultasAsis.FACTURA_CTC_MEDICAMENTOS_CARGARRR
        sqlPrecargarInsumos = ConsultasAsis.FACTURA_INSUMOS_CARGARR
        sqlBuscarContrato = ConsultasAsis.FACTURA_ATENCION_CLIENTE_BUSCARR
        sqlbuscarRegistroAFacturar = ConsultasAsis.FACTURA_ATENCION_REGISTRO_A_FACTURAR_BUSCARR
        sqlCargarRegistroAFacturar = ConsultasAsis.FACTURA_ATENCION_REGISTRO_A_FACTURAR_CARGARR
    End Sub
    Public Overrides Sub nombreReportePDF()
        If CTC = True Then
            nombrePDF = ConstantesHC.NOMBRE_PDF_FACTURA_CTC_RR
            tipo = 1
        Else
            nombrePDF = ConstantesHC.NOMBRE_PDF_FACTURA_RR
            tipo = 0
        End If
        nombreCertificadoPDF = ConstantesHC.NOMBRE_PDF_FACTURA_CERTIFICADO_RR
        moduloReporte = Constantes.REPORTE_AF
    End Sub
End Class
