Public Class OxigenoR
    Inherits Oxigeno
    Sub New()
        modulo = Constantes.REPORTE_AM
        oxigenoCargarGuardados = ConsultasHC.OXIGENO_CARGAR_PRIMERA_VEZ_R
    End Sub
    Public Overrides Sub imprimirOxigeno()
        Dim nombreArchivo, ruta, codigoNombre As String
        codigoNombre = nRegistro
        nombreArchivo = ConstantesHC.NOMBRE_PDF_OXIGENO_FISIO_R & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigoNombre & ConstantesHC.EXTENSION_ARCHIVO_PDF
        ruta = Path.GetTempPath() & nombreArchivo
        ftp_reportes.llamarArchivo(ruta, ConstantesHC.NOMBRE_PDF_OXIGENO_FISIO_R, nRegistro, oxiegenReporte)
        Process.Start(ruta)
    End Sub
End Class
