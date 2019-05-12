Public Class EpicrisisRR
    Inherits Epicrisis
    Public Sub New()
        busquedaAutomatica = Consultas.BUSQUEDA_EPICRISIS_AUTOMATICA_RR
        cargaPaciente = Consultas.BUSQUEDA_PACIENTE_EPICRISIS_CARGAR
        cargaDiagEgreso = Consultas.DIAGNOSTICOS_EGRESO_EPICRISIS_RR
        cargaDiagImpresion = Consultas.DIAGNOSTICOS_IMPRESION_EPICRISIS_RR
        cargaDiagRemision = Consultas.DIAGNOSTICOS_REMISION_EPICRISIS_RR
        cargaEpicrisis = Consultas.BUSQUEDA_EPICRISIS_CARGAR_RR
        anulaEpicrisis = Consultas.ANULAR_EPICRISIS_RR
        nombrePDF = ConstantesHC.NOMBRE_PDF_EPICRISIS_RR
        busquedaEpicrisis = Consultas.BUSQUEDA_EPICRISIS_RR
        busquedaPaciente = Consultas.LISTA_PACIENTE_EPICRISIS_RR
        cambioEstadoAtencion = Consultas.CERRAR_PACIENTE
        verificarFecha = ConsultasHC.FECHA_EPICRISIS_VERIFICAR_RR
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
    End Sub
    Public Overrides Sub guardarEpicrisis()
        Dim epicrisis As New EpicrisisBLL
        epicrisis.guardarEpicrisisRR(Me)
    End Sub
    Public Overrides Function obtenerFechaUltimaEvo() As DateTime
        Dim params As New List(Of String)
        params.Add(registro)
        Dim filaResultado As DataRow = General.cargarItem(Consultas.FECHA_ULTIMA_EVOLUCION_EPICRISISRR, params)
        If Not IsNothing(filaResultado) Then
            Return filaResultado.Item(0)
        Else
            Return Nothing
        End If
    End Function
End Class
