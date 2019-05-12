Public Class Consolidado
    Public Property N_Registro As Integer
    Public Property Codigo_Menu As String
    Public Property Generando As Boolean
    Public Property Generando2doPlanoParte1 As Boolean
    Public Property Generando2doPlanoParte2 As Boolean
    Public Property Generando2doPlanoParte3 As Boolean
    Public Property Generando2doPlanoParte4 As Boolean
    Public Property dtProcesos As New DataTable
    Public Property errorGeneracion As Boolean = False

    Public Sub New()
        dtProcesos.Columns.Add("Descripción", Type.GetType("System.String"))
        dtProcesos.Columns.Add("Finalizado", Type.GetType("System.Boolean"))
    End Sub

    Public Overridable Sub iniciarProcesos()
        dtProcesos.Clear()
        dtProcesos.Rows.Add("Creando carpetas", 0)
        dtProcesos.Rows.Add("Generando Ordenes y factura", 0)
        dtProcesos.Rows.Add("Generando Exámenes", 0)
        dtProcesos.Rows.Add("Generando Procedimientos y anexos", 0)
        dtProcesos.Rows.Add("Generando Sabana de aplicacion", 0)
        dtProcesos.Rows.Add("Uniendo documentos", 0)
        dtProcesos.Rows.Add("Generando folio", 0)
        dtProcesos.Rows.Add("Limpiando temporales", 0)
    End Sub


End Class
