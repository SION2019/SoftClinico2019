Public Class DetalleGlosa
    Public Property identificador As String
    Public Property dtGlosa As DataTable
    Public Property sumaTotalGlosas As Double
    Public Property sumaTotalGlosaAceptada As Double

    Sub New()
        dtGlosa = New DataTable
        dtGlosa.Columns.Add("Codigo_Glosa", Type.GetType("System.String"))
        dtGlosa.Columns.Add("Codigo_Factura", Type.GetType("System.String"))
        dtGlosa.Columns.Add("Codigo_general", Type.GetType("System.Int32"))
        dtGlosa.Columns.Add("Codigo_especifico", Type.GetType("System.Int32"))
        dtGlosa.Columns.Add("Valor", Type.GetType("System.Double"))
        dtGlosa.Columns.Add("codigo_respuesta", Type.GetType("System.String"))
        dtGlosa.Columns.Add("valor_Aceptado", Type.GetType("System.Double"))
        dtGlosa.Columns.Add("observacion", Type.GetType("System.String"))
    End Sub
End Class
