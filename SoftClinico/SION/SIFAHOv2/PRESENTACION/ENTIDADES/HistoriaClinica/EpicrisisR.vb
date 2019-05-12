Public Class EpicrisisR
    Inherits Epicrisis
    Public Sub New()
        busquedaAutomatica = Consultas.BUSQUEDA_EPICRISIS_AUTOMATICA_R
        cargaPaciente = Consultas.BUSQUEDA_PACIENTE_EPICRISIS_CARGAR_R
        cargaDiagEgreso = Consultas.DIAGNOSTICOS_EGRESO_EPICRISIS_R
        cargaDiagImpresion = Consultas.DIAGNOSTICOS_IMPRESION_EPICRISIS_R
        cargaDiagRemision = Consultas.DIAGNOSTICOS_REMISION_EPICRISIS_R
        cargaEpicrisis = Consultas.BUSQUEDA_EPICRISIS_CARGAR_R
        anulaEpicrisis = Consultas.ANULAR_EPICRISIS_R
        nombrePDF = ConstantesHC.NOMBRE_PDF_EPICRISIS_R
        busquedaEpicrisis = Consultas.BUSQUEDA_EPICRISIS_R
        busquedaPaciente = Consultas.LISTA_PACIENTE_EPICRISIS_R
        cambioEstadoAtencion = Consultas.CERRAR_PACIENTE_R
        titulo = "EPICRISIS: AUDITORÍA MÉDICA"
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
        ftp_reportes.eliminarArchivo(ConstantesHC.NOMBRE_PDF_EPICRISIS_R & ConstantesHC.NOMBRE_PDF_SEPARADOR & registro & ConstantesHC.EXTENSION_ARCHIVO_PDF)
        If activoAF = True Then
            ftp_reportes.eliminarArchivo(ConstantesHC.NOMBRE_PDF_EPICRISIS_RR & ConstantesHC.NOMBRE_PDF_SEPARADOR & registro & ConstantesHC.EXTENSION_ARCHIVO_PDF)
        End If
    End Sub
    Public Overrides Sub guardarEpicrisis()
        Dim epicrisis As New EpicrisisBLL
        epicrisis.guardarEpicrisisR(Me)
    End Sub

End Class
