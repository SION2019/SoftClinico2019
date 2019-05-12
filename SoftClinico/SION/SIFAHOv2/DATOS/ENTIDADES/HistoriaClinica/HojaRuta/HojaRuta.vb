Public Class HojaRuta
    Public Property modulo As String
    Public Property registro As Integer
    Public Property fechaActual As Date
    Public Property usuario As Integer
    Public Property codigoEP As Integer
    Public Property editado As Integer
    Public Property codigoArea As Integer
    Public Property codigoEstado As Integer
    Public Property dtHojaRuta As DataTable
    Public Property dtFilaSelec As DataTable
    Public Property dtElementos As DataTable
    Public Property dtProgram As DataTable
    Public Property sqlCargarHojaRuta As String
    Public Property sqlGuardarHojaRuta As String
    Public Property sqlGuardarTareasProgram As String
    Public Property sqlcargarDiagnostico As String
    Public Property sqlCargarManejo As String
    Public Property sqlCargarTareaProgram As String
    Public Property observacionesHC As String
    Public Property observacionesAM As String
    Public Property observacionesAF As String
    Public Property vista As Integer
    Public Property Estado As Integer
    Public Property columnaHC As Boolean
    Public Property columnaAM As Boolean
    Public Property columnaAF As Boolean
    Public Property titulo As String
    Public Property idEmpresa As Integer
    Public Property nombrePdf As String
    Public Property idEmpleado As Integer
    Public Sub New()

        dtFilaSelec = New DataTable
        dtHojaRuta = New DataTable

        dtHojaRuta.Columns.Add("N_Registro", Type.GetType("System.Int32"))
        dtHojaRuta.Columns.Add("Nombre", Type.GetType("System.String"))
        dtHojaRuta.Columns.Add("Edad", Type.GetType("System.String"))
        dtHojaRuta.Columns.Add("Genero", Type.GetType("System.String"))
        dtHojaRuta.Columns.Add("Fecha_Ingreso", Type.GetType("System.DateTime"))
        dtHojaRuta.Columns.Add("Estancia", Type.GetType("System.String"))
        dtHojaRuta.Columns.Add("Diagnostico", Type.GetType("System.String"))
        dtHojaRuta.Columns.Add("Manejo", Type.GetType("System.String"))
        dtHojaRuta.Columns.Add("Tarea_Pendiente", Type.GetType("System.String"))
        dtHojaRuta.Columns.Add("Obser_medica", Type.GetType("System.String")).DefaultValue = String.Empty
        dtHojaRuta.Columns.Add("Obser_Revisoria", Type.GetType("System.String")).DefaultValue = String.Empty
        dtHojaRuta.Columns.Add("Obser_Facturacion", Type.GetType("System.String")).DefaultValue = String.Empty
        dtHojaRuta.Columns.Add("Estado", Type.GetType("System.Int32"))

        dtElementos = New DataTable
        dtElementos.Columns.Add("Num", Type.GetType("System.Int32"))
        dtElementos.Columns.Add("Descripcion", Type.GetType("System.String"))

        dtProgram = New DataTable
        dtProgram.Columns.Add("Num", Type.GetType("System.Int32"))
        dtProgram.Columns.Add("id_programacion", Type.GetType("System.Int32"))
        dtProgram.Columns.Add("Descripcion", Type.GetType("System.String")).DefaultValue = String.Empty
        dtProgram.Columns.Add("HC", Type.GetType("System.String"))
        dtProgram.Columns.Add("AM", Type.GetType("System.String"))
        dtProgram.Columns.Add("AF", Type.GetType("System.String"))
        dtProgram.Columns.Add("comentario", Type.GetType("System.String"))
        dtProgram.Columns.Add("Realizado", Type.GetType("System.Boolean")).DefaultValue = 0

        sqlCargarHojaRuta = Consultas.CARGAR_HOJA_RUTA
        sqlGuardarHojaRuta = Consultas.GUARDAR_HOJA_RUTA
        sqlcargarDiagnostico = Consultas.CARGAR_DIAGNOTICO_HOJA_RUTA
        sqlCargarManejo = Consultas.CARGAR_MANEJO_HOJA_RUTA
        sqlGuardarTareasProgram = Consultas.GUARDAR_TAREAS_HOJA_RUTA
        sqlCargarTareaProgram = Consultas.CARGAR_HOJA_RUTA_TAREA
        titulo = TitulosForm.TITULO_HOJA_RUTA_HC
        nombrePdf = ConstantesHC.NOMBRE_PDF_HOJA_RUTA
        vista = Constantes.REPORTE_HC

    End Sub
    Public Sub cargarHojaRuta(txt As String)
        Dim params As New List(Of String)
        params.Add(codigoArea)
        params.Add(fechaActual.Date)
        params.Add(codigoEstado)
        params.Add(txt)
        General.llenarTabla(sqlCargarHojaRuta, params, dtHojaRuta)
    End Sub

    Public Sub cargarDiagnostico()
        Dim params As New List(Of String)
        params.Add(registro)
        params.Add(fechaActual.Date)
        General.llenarTabla(sqlcargarDiagnostico, params, dtElementos)
    End Sub
    Public Sub cargarManejo()
        Dim params As New List(Of String)
        params.Add(registro)
        params.Add(fechaActual.Date)
        General.llenarTabla(sqlCargarManejo, params, dtElementos)
    End Sub
    Public Sub cargarTareasProgram()
        Dim params As New List(Of String)
        params.Add(registro)
        params.Add(fechaActual.Date)
        General.llenarTabla(sqlCargarTareaProgram, params, dtProgram)
    End Sub
    Public Sub validarOcultoDgv(visorHC As Boolean,
                                visorAM As Boolean,
                                visorAF As Boolean)
        If visorHC = True Then
            columnaHC = True
        End If
        If visorAM = True Then
            columnaAM = True
        End If
        If visorAF = True Then
            columnaAF = True
        End If
    End Sub

End Class
