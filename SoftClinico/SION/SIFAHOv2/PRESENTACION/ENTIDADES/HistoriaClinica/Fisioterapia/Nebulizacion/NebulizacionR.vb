Public Class NebulizacionR
    Inherits Nebulizacion
    Sub New()
        modulo = Constantes.REPORTE_AM
        oxigenoCargarGuardados = ConsultasHC.OXIGENO_CARGAR_PRIMERA_VEZ_R
    End Sub
    Public Overrides Sub cargarNebulizacion()
        Dim params As New List(Of String)
        params.Add(codigoOrden)
        General.llenarTabla(ConsultasHC.NEBULIZACION_CARGAR_R, params, tablaNebulacion)
    End Sub
    Public Overrides Sub getFechaEgreso()
        Dim params As New List(Of String)
        params.Add(nRegistro)
        Dim fila As DataRow
        fila = General.cargarItem(ConsultasHC.OXIGENO_FECHA_EGRESO_R, params)
        If Not IsNothing(fila(0)) Then
            fechaEgreso = fila(0)
        Else
            fechaEgreso = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        End If
    End Sub
    Public Overrides Sub imprimirNebulizacion(ByVal lista As ListBox)
        Dim nombreArchivo, ruta, formula, codigoNombre As String
        codigoNombre = codigoOrden


        If lista.SelectedIndex = 0 Then
            nombreArchivo = ConstantesHC.NOMBRE_PDF_NEBULIZACION_FISIO_R & ConstantesHC.NOMBRE_PDF_SEPARADOR & nRegistro & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = Path.GetTempPath() & nombreArchivo
            ftp_reportes.llamarArchivo(ruta, nombreArchivo, nRegistro, ConstantesHC.NOMBRE_PDF_NEBULIZACION_FISIO_R)
        Else
            nombreArchivo = ConstantesHC.NOMBRE_PDF_NEBULIZACION_FISIO_R & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigoNombre & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = Path.GetTempPath() & nombreArchivo
            formula = "{VISTA_FISIOTERAPIA_NEBULIZACION.Codigo_Orden} = " & codigoOrden & " AND {VISTA_FISIOTERAPIA_NEBULIZACION.Modulo}=" & modulo
            Dim reporte As New ftp_reportes
            reporte.crearYGuardarReporte(ConstantesHC.NOMBRE_PDF_NEBULIZACION_FISIO_R,
                                         nRegistro, New rptFisioterapiaNebulizacion,
                                         codigoNombre,
                                         formula,
                                         ConstantesHC.NOMBRE_PDF_NEBULIZACION_FISIO_R,
                                         IO.Path.GetTempPath,, False)
        End If

        Process.Start(ruta)
    End Sub
End Class
