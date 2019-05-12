Public Class CuentasPorCobrar
    Public Property identificador As String
    Public Property factura As String
    Public Property idEmpresa As Integer
    Public Property codigoDocumento As Integer
    Public Property idCliente As Integer
    Public Property fechaRecibo As Date
    Public Property fechaVence As Date
    Public Property fechaDoc As Date
    Public Property fechaNRad As Date
    Public Property valorDebito As Double
    Public Property valorCredito As Double
    Public Property usuarioCreacion As Integer
    Public Property usuarioActualizacion As Integer
    Public Property dtCuentas As DataTable
    Public Property observacion As String

    Sub New()
        dtCuentas = New DataTable
        dtCuentas.Columns.Add("factura", Type.GetType("System.String"))
        dtCuentas.Columns.Add("idEmpresa", Type.GetType("System.String"))
        dtCuentas.Columns.Add("codigo_puc", Type.GetType("System.Int32"))
        dtCuentas.Columns.Add("codigoCuenta", Type.GetType("System.String"))
        dtCuentas.Columns.Add("debito", Type.GetType("System.Double"))
        dtCuentas.Columns.Add("credito", Type.GetType("System.Double"))
        dtCuentas.Columns.Add("orden", Type.GetType("System.Int32"))
    End Sub
End Class
