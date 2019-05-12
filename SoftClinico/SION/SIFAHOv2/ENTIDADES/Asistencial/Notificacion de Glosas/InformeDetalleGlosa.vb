Public Class InformeDetalleGlosa
    Public Property dtGlosa As DataTable


    Sub New()
        dtGlosa = New DataTable
        dtGlosa.Columns.Add("mes", Type.GetType("System.String"))
        dtGlosa.Columns.Add("eps", Type.GetType("System.String"))
        dtGlosa.Columns.Add("factura", Type.GetType("System.String"))
        dtGlosa.Columns.Add("valor", Type.GetType("System.String"))
        dtGlosa.Columns.Add("objecion", Type.GetType("System.String"))
        dtGlosa.Columns.Add("glosa", Type.GetType("System.String"))
        dtGlosa.Columns.Add("levantada", Type.GetType("System.String"))
        dtGlosa.Columns.Add("fecha_c", Type.GetType("System.String"))
        dtGlosa.Columns.Add("fecha_r", Type.GetType("System.String"))
        dtGlosa.Columns.Add("porc_obj", Type.GetType("System.String"))
        dtGlosa.Columns.Add("porc_glosa", Type.GetType("System.String"))
        dtGlosa.Columns.Add("devolucion", Type.GetType("System.String"))
        dtGlosa.Columns.Add("devolucion_aceptada", Type.GetType("System.String"))
    End Sub
End Class
