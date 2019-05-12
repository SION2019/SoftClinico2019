Public Class NotaCliente
    Public Property identificador As String
    Public Property comprobante As String
    Public Property idEmpresa As Integer
    Public Property idCliente As Integer
    Public Property codigoDoc As Integer
    Public Property fechaRecibo As Date
    Public Property detalleMov As String
    Public Property codigoDocumento As Integer
    Public Property valorDebito As Double
    Public Property valorCredito As Double
    Public Property valorSubtotal As Double
    Public Property usuarioCreacion As Integer
    Public Property usuarioActualizacion As Integer
    Public Property dtCuentas As DataTable

    Sub New()
        dtCuentas = New DataTable
        dtCuentas.Columns.Add("comprobante", Type.GetType("System.String"))
        dtCuentas.Columns.Add("codigo_Factura", Type.GetType("System.String"))
        dtCuentas.Columns.Add("idEmpresa", Type.GetType("System.Int32"))
        dtCuentas.Columns.Add("codigo_puc", Type.GetType("System.Int32"))
        dtCuentas.Columns.Add("codigoCuenta", Type.GetType("System.String"))
        dtCuentas.Columns.Add("debito", Type.GetType("System.Double"))
        dtCuentas.Columns.Add("credito", Type.GetType("System.Double"))
        dtCuentas.Columns.Add("orden", Type.GetType("System.Int32"))
    End Sub
End Class
