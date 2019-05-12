Public Class OxigenoRR
    Inherits Oxigeno
    Sub New()
        modulo = Constantes.REPORTE_AF
        oxigenoCargarGuardados = ConsultasHC.OXIGENO_CARGAR_PRIMERA_VEZ_RR
    End Sub
    Public Overrides Sub imprimirOxigeno()
        Dim nombreArchivo, ruta, codigoNombre As String
        codigoNombre = nRegistro
        nombreArchivo = ConstantesHC.NOMBRE_PDF_OXIGENO_FISIO_RR & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigoNombre & ConstantesHC.EXTENSION_ARCHIVO_PDF
        ruta = Path.GetTempPath() & nombreArchivo
        ftp_reportes.llamarArchivo(ruta, ConstantesHC.NOMBRE_PDF_OXIGENO_FISIO_RR, nRegistro, oxiegenReporte)
        Process.Start(ruta)
    End Sub
End Class
