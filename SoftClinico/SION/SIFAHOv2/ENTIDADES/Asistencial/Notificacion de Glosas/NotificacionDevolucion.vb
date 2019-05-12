Public Class NotificacionDevolucion
    Public Property identificador As String
    Public Property dtDevolucion As DataTable

    Sub New()

        dtDevolucion = New DataTable
        dtDevolucion.Columns.Add("Codigo_Devolucion", Type.GetType("System.String"))
        dtDevolucion.Columns.Add("Id_Empresa", Type.GetType("System.Int32"))
        dtDevolucion.Columns.Add("Codigo_Factura", Type.GetType("System.String"))
        dtDevolucion.Columns.Add("Fecha_Notificacion_Limite", Type.GetType("System.DateTime"))
        dtDevolucion.Columns.Add("Fecha_Notificacion_Dev", Type.GetType("System.DateTime"))
        dtDevolucion.Columns.Add("Notificacion_Extemporanea", Type.GetType("System.Boolean"))
        dtDevolucion.Columns.Add("Valor_Glosa", Type.GetType("System.Double"))
        dtDevolucion.Columns.Add("Devolucion", Type.GetType("System.Double"))
        dtDevolucion.Columns.Add("Valor_Glosa_Aceptada", Type.GetType("System.Double"))
        dtDevolucion.Columns.Add("Fecha_LRespuesta_Dev", Type.GetType("System.DateTime"))
        dtDevolucion.Columns.Add("Fecha_Respuesta_Dev", Type.GetType("System.DateTime"))
        dtDevolucion.Columns.Add("Respondida", Type.GetType("System.Boolean"))
        dtDevolucion.Columns.Add("Codigo_factura_Nueva", Type.GetType("System.String"))
        dtDevolucion.Columns.Add("Valor_a_Pagar", Type.GetType("System.Double"))
        dtDevolucion.Columns.Add("Terminada", Type.GetType("System.Boolean"))
        dtDevolucion.Columns.Add("usuario", Type.GetType("System.Int32"))
    End Sub
End Class
