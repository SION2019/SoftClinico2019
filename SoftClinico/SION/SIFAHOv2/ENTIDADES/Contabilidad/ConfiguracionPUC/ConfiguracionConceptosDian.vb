Public Class ConfiguracionConceptosDian
    Public Property codigoConcepto As String
    Public Property dtCuentas As DataTable
    Sub New()
        dtCuentas = New DataTable
        dtCuentas.Columns.Add("Concepto", Type.GetType("System.String"))
        dtCuentas.Columns.Add("Cuenta", Type.GetType("System.String"))
        dtCuentas.Columns.Add("Iva", Type.GetType("System.Boolean"))
        dtCuentas.Columns.Add("Retencion.Prac", Type.GetType("System.Boolean"))
        dtCuentas.Columns.Add("Retencion.Asum", Type.GetType("System.Boolean"))
        dtCuentas.Columns.Add("IngPropios", Type.GetType("System.Boolean"))
        dtCuentas.Columns.Add("IngPorConsorcios", Type.GetType("System.Boolean"))
        dtCuentas.Columns.Add("Devolucion", Type.GetType("System.Boolean"))
    End Sub
End Class
