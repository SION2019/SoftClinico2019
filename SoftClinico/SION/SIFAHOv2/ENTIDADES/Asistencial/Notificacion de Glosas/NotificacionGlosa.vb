Public Class NotificacionGlosa
    Public Property identificador As String
    Public Property dtGlosa As DataTable

    Sub New()

        dtGlosa = New DataTable
        dtGlosa.Columns.Add("Codigo_Glosa", Type.GetType("System.String"))
        dtGlosa.Columns.Add("Id_Empresa", Type.GetType("System.Int32"))
        dtGlosa.Columns.Add("Codigo_Factura", Type.GetType("System.String"))
        dtGlosa.Columns.Add("Fecha_Limite_Recepcion", Type.GetType("System.DateTime"))
        dtGlosa.Columns.Add("Fecha_Notificacion_Glosa", Type.GetType("System.DateTime"))
        dtGlosa.Columns.Add("Notificacion_Extemporanea", Type.GetType("System.Boolean"))
        dtGlosa.Columns.Add("Valor_Glosa", Type.GetType("System.Double"))
        dtGlosa.Columns.Add("Glosa_Facuracion", Type.GetType("System.Double"))
        dtGlosa.Columns.Add("Glosa_Tarifa", Type.GetType("System.Double"))
        dtGlosa.Columns.Add("Glosa_Soporte", Type.GetType("System.Double"))
        dtGlosa.Columns.Add("Glosa_Autorizacion", Type.GetType("System.Double"))
        dtGlosa.Columns.Add("Glosa_Cobertura", Type.GetType("System.Double"))
        dtGlosa.Columns.Add("Glosa_Pertinencia", Type.GetType("System.Double"))
        dtGlosa.Columns.Add("Devolucion", Type.GetType("System.Double"))
        dtGlosa.Columns.Add("Valor_Glosa_Aceptada", Type.GetType("System.Double"))
        dtGlosa.Columns.Add("Fecha_LRespuesta_Glosa", Type.GetType("System.DateTime"))
        dtGlosa.Columns.Add("Fecha_Respuesta_Glosa", Type.GetType("System.DateTime"))
        dtGlosa.Columns.Add("Respondida", Type.GetType("System.Boolean"))
        dtGlosa.Columns.Add("Glosa_Ratificada", Type.GetType("System.Double"))
        dtGlosa.Columns.Add("Fecha_Conciliacion", Type.GetType("System.DateTime"))
        dtGlosa.Columns.Add("Valor_IPS_Aceptada", Type.GetType("System.Double"))
        dtGlosa.Columns.Add("Valor_EPS_Aceptada", Type.GetType("System.Double"))
        dtGlosa.Columns.Add("Valor_a_Pagar", Type.GetType("System.Double"))
        dtGlosa.Columns.Add("Glosa1", Type.GetType("System.Double"))
        dtGlosa.Columns.Add("Glosa2", Type.GetType("System.Double"))
        dtGlosa.Columns.Add("Glosa3", Type.GetType("System.Double"))
        dtGlosa.Columns.Add("Glosa4", Type.GetType("System.Double"))
        dtGlosa.Columns.Add("Glosa5", Type.GetType("System.Double"))
        dtGlosa.Columns.Add("Glosa6", Type.GetType("System.Double"))
        dtGlosa.Columns.Add("Glosa8", Type.GetType("System.Double"))
        dtGlosa.Columns.Add("Terminada", Type.GetType("System.Boolean"))
        dtGlosa.Columns.Add("usuario", Type.GetType("System.Int32"))
    End Sub
End Class
