Public Class EpicrisisRR
    Inherits Epicrisis
    Public Sub New()
        busquedaAutomatica = Consultas.BUSQUEDA_EPICRISIS_AUTOMATICA_RR
        cargaPaciente = Consultas.BUSQUEDA_PACIENTE_EPICRISIS_CARGAR_RR
        cargaDiagEgreso = Consultas.DIAGNOSTICOS_EGRESO_EPICRISIS_RR
        cargaDiagImpresion = Consultas.DIAGNOSTICOS_IMPRESION_EPICRISIS_RR
        cargaDiagRemision = Consultas.DIAGNOSTICOS_REMISION_EPICRISIS_RR
        cargaEpicrisis = Consultas.BUSQUEDA_EPICRISIS_CARGAR_RR
        anulaEpicrisis = Consultas.ANULAR_EPICRISIS_RR
        nombrePDF = ConstantesHC.NOMBRE_PDF_EPICRISIS_RR
        busquedaEpicrisis = Consultas.BUSQUEDA_EPICRISIS_RR
        busquedaPaciente = Consultas.LISTA_PACIENTE_EPICRISIS_RR
        cambioEstadoAtencion = Consultas.CERRAR_PACIENTE_RR
        titulo = "EPICRISIS: AUDITORÍA FACTURACIÓN"
        crearTabla(dtRemision)
        crearTabla(dtImpresion)
        crearTabla(dtDiagEgreso)
    End Sub
    Public Overrides Sub anularEpicrisis(activoAM As Boolean, activoAF As Boolean)
        Dim params As New List(Of String)
        params.Add(SesionActual.idUsuario)
        params.Add(registro)
        params.Add(SesionActual.codigoEP)
        General.ejecutarSQL(anulaEpicrisis, params)
        ''falta el eliminar archivo del pdf de salida voluntaria
        ftp_reportes.eliminarArchivo(ConstantesHC.NOMBRE_PDF_EPICRISIS_RR & ConstantesHC.NOMBRE_PDF_SEPARADOR & registro & ConstantesHC.EXTENSION_ARCHIVO_PDF)
    End Sub
    Public Overrides Sub guardarEpicrisis()
        Dim epicrisis As New EpicrisisBLL
        epicrisis.guardarEpicrisisRR(Me)
    End Sub
End Class
