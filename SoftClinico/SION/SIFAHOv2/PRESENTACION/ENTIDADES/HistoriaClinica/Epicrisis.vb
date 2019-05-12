Imports G8LIAT

Public Class Epicrisis
    Public Property moduloReporte As Integer
    Public Property codigo As String
    Public Property registro As Integer
    Public Property fecha As DateTime
    Public Property nota As String
    Public Property estadoSalida As Integer
    Public Property destino As Integer
    Public Property institucion As Integer
    Public Property observacion As String
    Public Property usuarioReal As Integer
    Public Property usuario As Integer
    Public Property codigoEp As Integer
    Public Property dtDiagEgreso As New DataTable
    Public Property dtRemision As New DataTable
    Public Property dtImpresion As New DataTable
    Public Property busquedaAutomatica As String
    Public Property cargaPaciente As String
    Public Property cargaDiagEgreso As String
    Public Property cargaDiagImpresion As String
    Public Property cargaDiagRemision As String
    Public Property cargaEpicrisis As String
    Public Property anulaEpicrisis As String
    Public Property nombrePDF As String
    Public Property busquedaEpicrisis As String
    Public Property busquedaPaciente As String
    Public Property titulo As String
    Public Property cambioEstadoAtencion As String

    Public Sub New()
        busquedaAutomatica = Consultas.BUSQUEDA_EPICRISIS_AUTOMATICA
        cargaPaciente = Consultas.BUSQUEDA_PACIENTE_EPICRISIS_CARGAR
        cargaDiagEgreso = Consultas.DIAGNOSTICOS_EGRESO_EPICRISIS
        cargaDiagImpresion = Consultas.DIAGNOSTICOS_IMPRESION_EPICRISIS
        cargaDiagRemision = Consultas.DIAGNOSTICOS_REMISION_EPICRISIS
        cargaEpicrisis = Consultas.BUSQUEDA_EPICRISIS_CARGAR
        anulaEpicrisis = Consultas.ANULAR_EPICRISIS
        nombrePDF = ConstantesHC.NOMBRE_PDF_EPICRISIS
        busquedaEpicrisis = Consultas.BUSQUEDA_EPICRISIS
        busquedaPaciente = Consultas.LISTA_PACIENTE_EPICRISIS
        cambioEstadoAtencion = Consultas.CERRAR_PACIENTE
        titulo = "EPICRISIS: HISTORIA CLÍNICA"
        crearTabla(dtRemision)
        crearTabla(dtImpresion)
        crearTabla(dtDiagEgreso)
    End Sub

    Public Sub crearTabla(ByRef dt As DataTable)
        Dim codigo, descripcion As New DataColumn
        codigo.ColumnName = "Código"
        codigo.DataType = Type.GetType("System.String")
        dt.Columns.Add(codigo)

        descripcion.ColumnName = "Descripción"
        descripcion.DataType = Type.GetType("System.String")
        dt.Columns.Add(descripcion)
    End Sub

    Public Sub cargarDiagnosticosEgreso()
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(registro)
        General.llenarTabla(cargaDiagEgreso, params, dtDiagEgreso)

    End Sub

    Public Sub cargarDiagnosticosImpresion()
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(registro)
        General.llenarTabla(cargaDiagImpresion, params, dtImpresion)
    End Sub

    Public Sub cargaDiagnosticosRemision()
        Dim dt As New DataTable
        Dim params As New List(Of String)
        params.Add(registro)
        General.llenarTabla(cargaDiagRemision, params, dtRemision)
    End Sub

    Public Overridable Sub anularEpicrisis(activoAM As Boolean, activoAF As Boolean)
        Dim params As New List(Of String)
        params.Add(SesionActual.idUsuario)
        params.Add(registro)
        params.Add(SesionActual.codigoEP)
        General.ejecutarSQL(anulaEpicrisis, params)
        ''falta el eliminar archivo del pdf de salida voluntaria
        ftp_reportes.eliminarArchivo(ConstantesHC.NOMBRE_PDF_EPICRISIS & ConstantesHC.NOMBRE_PDF_SEPARADOR & registro & ConstantesHC.EXTENSION_ARCHIVO_PDF)
        If activoAM = True Then
            ftp_reportes.eliminarArchivo(ConstantesHC.NOMBRE_PDF_EPICRISIS_R & ConstantesHC.NOMBRE_PDF_SEPARADOR & registro & ConstantesHC.EXTENSION_ARCHIVO_PDF)
        End If
        If activoAF = True Then
            ftp_reportes.eliminarArchivo(ConstantesHC.NOMBRE_PDF_EPICRISIS_RR & ConstantesHC.NOMBRE_PDF_SEPARADOR & registro & ConstantesHC.EXTENSION_ARCHIVO_PDF)
        End If
    End Sub

    Public Sub imprimir()
        Dim ruta, nombreArchivo As String
        nombreArchivo = nombrePDF & ConstantesHC.NOMBRE_PDF_SEPARADOR & registro & ConstantesHC.EXTENSION_ARCHIVO_PDF
        ruta = IO.Path.GetTempPath() & nombreArchivo
        ftp_reportes.llamarArchivo(ruta, nombreArchivo, registro, nombrePDF)
        Process.Start(ruta)
    End Sub

    Public Sub cambiarEstadoAtencion(pCodigoEstado As Integer)
        Dim params As New List(Of String)
        params.Add(registro)
        params.Add(pCodigoEstado)
        params.Add(SesionActual.codigoEP)
        General.ejecutarSQL(cambioEstadoAtencion, params)
    End Sub

    Public Overridable Sub guardarEpicrisis()
        Dim epicrisis As New EpicrisisBLL
        epicrisis.guardarEpicrisis(Me)
    End Sub
End Class
