Public Class ContabilidadGeneral
    Public Property identificador As String
    Public Property comprobante As String
    Public Property idEmpresa As Integer
    Public Property idTercero As Integer
    Public Property fechaRecibo As Date
    Public Property codigoDocumento As Integer
    Public Property usuarioActualizacion As Integer
    Public Property usuarioCreacion As Integer
    Public Property dtCuentas As DataTable

    Sub New()
        dtCuentas = New DataTable
        dtCuentas.Columns.Add("comprobante", Type.GetType("System.String"))
        dtCuentas.Columns.Add("codigo_puc", Type.GetType("System.Int32"))
        dtCuentas.Columns.Add("codigoCuenta", Type.GetType("System.String"))
        dtCuentas.Columns.Add("idTercero", Type.GetType("System.Int32"))
        dtCuentas.Columns.Add("debito", Type.GetType("System.Double"))
        dtCuentas.Columns.Add("credito", Type.GetType("System.Double"))
        dtCuentas.Columns.Add("orden", Type.GetType("System.Int32"))
    End Sub
End Class
