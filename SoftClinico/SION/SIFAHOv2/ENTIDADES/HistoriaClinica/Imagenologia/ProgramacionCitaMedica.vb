Public Class ProgramacionCitaMedica
    Property sqlConsultaCargar As String
    Property sqlConsultaCargarDetalle As String
    Property sqlConsultaDatos As String
    Property dtProgramCita As DataTable
    Property dtProgramCitaDetalle As DataTable
    Property banderaDia As Boolean
    Property pocisionActual As Integer = 1
    Property contenedor As Integer
    Property dtFectivo As DataTable
    Public Sub New()
        dtProgramCita = New DataTable
        dtProgramCitaDetalle = New DataTable
        dtFectivo = New DataTable

        dtProgramCita.Columns.Add("Hora", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia1", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia2", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia3", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia4", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia5", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia6", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia7", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia8", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia9", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia10", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia11", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia12", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia13", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia14", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia15", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia16", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia17", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia18", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia19", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia20", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia21", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia22", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia23", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia24", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia25", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia26", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia27", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia28", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia29", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia30", Type.GetType("System.String"))
        dtProgramCita.Columns.Add("Dia31", Type.GetType("System.String"))

        dtProgramCitaDetalle.Columns.Add("Codigo_Cita", Type.GetType("System.String"))
        dtProgramCitaDetalle.Columns.Add("Documento", Type.GetType("System.String"))
        dtProgramCitaDetalle.Columns.Add("Paciente", Type.GetType("System.String"))
        dtProgramCitaDetalle.Columns.Add("EPS", Type.GetType("System.String"))
        dtProgramCitaDetalle.Columns.Add("Edad", Type.GetType("System.String"))
        dtProgramCitaDetalle.Columns.Add("Genero", Type.GetType("System.String"))
        dtProgramCitaDetalle.Columns.Add("Medico Tratante", Type.GetType("System.String"))
        dtProgramCitaDetalle.Columns.Add("Fecha de Programación", Type.GetType("System.String"))
        dtProgramCitaDetalle.Columns.Add("Estado", Type.GetType("System.String"))

        sqlConsultaCargar = "[PROC_PROGRAMACION_CITA_CARGAR]"
        sqlConsultaCargarDetalle = "[PROC_PROGRAMACION_CITA_DETALLE]"
        sqlConsultaDatos = "[PROC_DATOS_CITA]"
    End Sub

End Class
