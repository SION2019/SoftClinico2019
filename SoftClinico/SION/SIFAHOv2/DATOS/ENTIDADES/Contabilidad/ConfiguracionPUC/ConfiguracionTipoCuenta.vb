Public Class ConfiguracionTipoCuenta
    Public Property dtCuentas As DataTable
    Sub New()
        dtCuentas = New DataTable
        dtCuentas.Columns.Add("Cuenta", Type.GetType("System.String"))
        dtCuentas.Columns.Add("Tipo", Type.GetType("System.Int32"))
    End Sub
End Class
