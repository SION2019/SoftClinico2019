Public Class CierrePeriodos
    Public Property dtCierre As DataTable
    Sub New()
        dtCierre = New DataTable
        dtCierre.Columns.Add("fecha", Type.GetType("System.DateTime"))
        dtCierre.Columns.Add("usuario", Type.GetType("System.Int32"))
    End Sub
End Class
