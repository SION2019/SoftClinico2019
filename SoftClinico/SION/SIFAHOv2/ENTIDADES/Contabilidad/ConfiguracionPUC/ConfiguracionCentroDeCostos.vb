Public Class ConfiguracionCentroDeCostos
    Public Property dtCuentas As DataTable
    Sub New()
        dtCuentas = New DataTable
        dtCuentas.Columns.Add("CuentaHomologa", Type.GetType("System.String"))
        dtCuentas.Columns.Add("Cuenta", Type.GetType("System.String"))
        dtCuentas.Columns.Add("sede", Type.GetType("System.Boolean"))
    End Sub
End Class
