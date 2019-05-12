Public Class HojaRutaR
    Inherits HojaRuta
    Public Sub New()
        sqlCargarHojaRuta = Consultas.CARGAR_HOJA_RUTA_R
        sqlGuardarHojaRuta = Consultas.GUARDAR_HOJA_RUTA_R
        sqlcargarDiagnostico = Consultas.CARGAR_DIAGNOTICO_HOJA_RUTA_R
        sqlCargarManejo = Consultas.CARGAR_MANEJO_HOJA_RUTA_R
        sqlGuardarTareasProgram = Consultas.GUARDAR_TAREAS_HOJA_RUTA_R
        sqlCargarTareaProgram = Consultas.CARGAR_HOJA_RUTA_TAREA_R
        editado = Constantes.EDITADO
        titulo = TitulosForm.TITULO_HOJA_RUTA_AM
        vista = Constantes.REPORTE_AM
        nombrePdf = ConstantesHC.NOMBRE_PDF_HOJA_RUTA_R
    End Sub


End Class
