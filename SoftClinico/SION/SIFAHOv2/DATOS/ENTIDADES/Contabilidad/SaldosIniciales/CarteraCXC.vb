Public Class CarteraCXC
    Public Property identificador As String
    Public Property usuarioCreacion As Integer
    Public Property usuarioActualizacion As Integer
    Public Property dtCartera As DataTable
    Public Property dtCarteraP As DataTable
    Sub New()
        dtCartera = New DataTable
        dtCarteraP = New DataTable
        dtCartera.Columns.Add("comprobante", Type.GetType("System.String"))
        dtCarteraP.Columns.Add("comprobante", Type.GetType("System.String"))
        dtCarteraP.Columns.Add("idEmpresa", Type.GetType("System.Int32"))
        dtCartera.Columns.Add("idEmpresa", Type.GetType("System.Int32"))
        dtCarteraP.Columns.Add("codigoDocumento", Type.GetType("System.Int32"))
        dtCarteraP.Columns.Add("codigoFactura", Type.GetType("System.String"))
        dtCartera.Columns.Add("codigo_puc", Type.GetType("System.Int32"))
        dtCarteraP.Columns.Add("idProveedor", Type.GetType("System.Int32"))
        dtCarteraP.Columns.Add("fechaRecibo", Type.GetType("System.DateTime"))
        dtCarteraP.Columns.Add("fechaVence", Type.GetType("System.DateTime"))
        dtCarteraP.Columns.Add("fechaDoc", Type.GetType("System.DateTime"))
        dtCarteraP.Columns.Add("valorDebito", Type.GetType("System.Double"))
        dtCarteraP.Columns.Add("valorCredito", Type.GetType("System.Double"))
        dtCartera.Columns.Add("codigoCuenta", Type.GetType("System.String"))
        dtCartera.Columns.Add("debito", Type.GetType("System.Double"))
        dtCartera.Columns.Add("credito", Type.GetType("System.Double"))
        dtCartera.Columns.Add("orden", Type.GetType("System.Int32"))
        dtCarteraP.Columns.Add("usuario", Type.GetType("System.Int32"))
    End Sub

End Class
