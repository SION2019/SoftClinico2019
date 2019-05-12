Public Class CierreDocumentos
    Public Property identificador As String
    Public Property comprobante As String
    Public Property idEmpresa As Integer
    Public Property fechaInicio As Date
    Public Property fechaFin As Date
    Public Property valorDebito As Double
    Public Property valorCredito As Double
    Public Property usuarioCreacion As Integer
    Public Property usuarioActualizacion As Integer
    Public Property dtCierre As DataTable

    Sub New()
        dtCierre = New DataTable
        dtCierre.Columns.Add("comprobante", Type.GetType("System.String"))
        dtCierre.Columns.Add("codigo_puc", Type.GetType("System.Int32"))
        dtCierre.Columns.Add("codigoCuenta", Type.GetType("System.String"))
        dtCierre.Columns.Add("debito", Type.GetType("System.Double"))
        dtCierre.Columns.Add("credito", Type.GetType("System.Double"))
        dtCierre.Columns.Add("orden", Type.GetType("System.Int32"))

    End Sub
End Class
