Public Class CertificadoRetencionBLL

    Public Shared Sub obtenerValorRetencion(params As CertificadoRetencionParams)
        CertificadoRetencionDAL.obtenerValorRetencion(params)
    End Sub

    Public Shared Sub generarCertificadoRetencion(certificadoParams As CertificadoRetencionParams)

        Dim rptCertificado As New rptCertificadoRetefuente

        Dim rango As String = certificadoParams.fechaInicio & " - " & certificadoParams.fechaFin
        rptCertificado.SetParameterValue("IdEmpresa", certificadoParams.idEmpresa)
        rptCertificado.SetParameterValue("rango", rango)

        Funciones.getReporteNoFTP(rptCertificado, Nothing, "certificado_retencion_01")
    End Sub

End Class
