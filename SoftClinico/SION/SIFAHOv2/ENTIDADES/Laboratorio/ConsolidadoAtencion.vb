Public Class ConsolidadoAtencion
    Inherits Consolidado

    Public Property codigoAtencion As Integer
    Public Overrides Sub iniciarProcesos()
        dtProcesos.Clear()
        dtProcesos.Rows.Add("Creando carpetas", 0)
        dtProcesos.Rows.Add("Atencion laboratorio", 0)
        dtProcesos.Rows.Add("Generando Exámenes", 0)
        dtProcesos.Rows.Add("Generando Laboratorio", 0)
        dtProcesos.Rows.Add("Generando Documentos", 0)
        dtProcesos.Rows.Add("Uniendo documentos", 0)
        dtProcesos.Rows.Add("Generando folio", 0)
        dtProcesos.Rows.Add("Limpiando temporales", 0)
    End Sub
End Class
