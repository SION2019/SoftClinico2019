Public Class EstadoDeCuentas
    Public Property dtCuentas As DataTable
    Sub New()

        dtCuentas = New DataTable

        dtCuentas.Columns.Add("Desde", Type.GetType("System.DateTime"))
        dtCuentas.Columns.Add("Hasta", Type.GetType("System.DateTime"))
        dtCuentas.Columns.Add("nit", Type.GetType("System.String"))
        dtCuentas.Columns.Add("factura", Type.GetType("System.String"))
        dtCuentas.Columns.Add("FechaRecibo", Type.GetType("System.DateTime"))
        dtCuentas.Columns.Add("FechaVence", Type.GetType("System.DateTime"))
        dtCuentas.Columns.Add("a30dias", Type.GetType("System.Double"))
        dtCuentas.Columns.Add("a60dias", Type.GetType("System.Double"))
        dtCuentas.Columns.Add("a90dias", Type.GetType("System.Double"))
        dtCuentas.Columns.Add("a180dias", Type.GetType("System.Double"))
        dtCuentas.Columns.Add("a360dias", Type.GetType("System.Double"))
        dtCuentas.Columns.Add("mas360dias", Type.GetType("System.Double"))
        dtCuentas.Columns.Add("Total30dias", Type.GetType("System.Double"))
        dtCuentas.Columns.Add("Total_60dias", Type.GetType("System.Double"))
        dtCuentas.Columns.Add("Total_90dias", Type.GetType("System.Double"))
        dtCuentas.Columns.Add("Total_180dias", Type.GetType("System.Double"))
        dtCuentas.Columns.Add("Total_360dias", Type.GetType("System.Double"))
        dtCuentas.Columns.Add("Total_mas360dias", Type.GetType("System.Double"))
        dtCuentas.Columns.Add("numDias", Type.GetType("System.Int32"))
    End Sub


End Class
