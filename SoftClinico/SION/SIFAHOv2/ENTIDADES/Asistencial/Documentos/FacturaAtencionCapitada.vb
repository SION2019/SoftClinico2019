Public Class FacturaAtencionCapitada
    Inherits FacturaAtencionAsistencial
    Public Property fechaInicio As Date
    Public Property periodoVerificar As String
    Public Property lista As New DataTable
    Public Property sqlPrecargarConsolidado As String
    Public Sub New()
        sqlPrecargarConsolidado = ConsultasAsis.FACTURA_CAPITA_CONSOLIDADO_CARGAR
        sqlBuscarContrato = ConsultasAsis.FACTURA_CAPITA_CLIENTE_BUSCAR
        periodoVerificar = ConsultasAsis.FACTURA_CAPITA_PERIODO_VERIFICAR
        sqlBuscarFactura = ConsultasAsis.FACTURA_CAPITA_BUSCAR
        sqlCargarFactura = ConsultasAsis.FACTURA_CAPITA_CARGAR
        nombreReportePDF()
    End Sub

    Public Sub cargarPendientes()
        Dim params As New List(Of String)
        params.Add(CodigoContrato)
        params.Add(Format(fechaInicio, Constantes.FORMATO_FECHA_GEN))
        General.llenarTabla(sqlPrecargarConsolidado, params, dtConsolidado)
    End Sub

    Public Overrides Sub nombreReportePDF()
        nombrePDF = ConstantesHC.NOMBRE_PDF_FACTURA_CAPITA
        tipo = 10
        moduloReporte = Constantes.REPORTE_HC
    End Sub
    Public Overrides Sub guardarFactura()
        Try '
            totalFactura = CLng(totalFactura)
            FacturaAtencionAsistencialDAL.guardarFacturaCapita(Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Overrides Sub imprimirFactura()
        Try
            Dim nombreArchivo, ruta, valorLetraTemporal As String
            Dim reporte As New ftp_reportes
            nombreArchivo = nombrePDF & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigoFactura & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = Path.GetTempPath() & nombreArchivo
            valorLetraTemporal = FuncionesContables.Convertir_Numero(totalFactura)
            Dim params As New List(Of String)
            params.Add(valorLetraTemporal)
            reporte.crearReportePDF(nombrePDF, codigoFactura, New rptFacturaCapita,
                                    codigoFactura,
                                  "{VISTA_FACTURACION.codigo_factura} = '" & codigoFactura & "'
                                  AND {VISTA_FACTURACION.Id_Empresa}=" & SesionActual.idEmpresa & "",
                                  nombrePDF, IO.Path.GetTempPath,,, params)
        Catch ex As Exception
            MsgBox(ex.Message & "Error en imprimirFactura ")
        End Try
    End Sub

End Class
