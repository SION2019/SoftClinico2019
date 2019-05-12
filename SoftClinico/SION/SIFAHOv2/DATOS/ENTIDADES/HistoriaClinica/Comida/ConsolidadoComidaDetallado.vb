Public Class ConsolidadoComidaDetallado
    Public Property tblDetalleDias As DataTable
    Public Property areaServicio As Integer
    Public Property modulo As String

    Sub New()
        tblDetalleDias = New DataTable
        tblDetalleDias.Columns.Add("Area", Type.GetType("System.String"))
        tblDetalleDias.Columns.Add("Fecha", Type.GetType("System.String"))
        tblDetalleDias.Columns.Add("CantidadD", Type.GetType("System.Int32"))
        tblDetalleDias.Columns.Add("cantidadA", Type.GetType("System.Int32"))
        tblDetalleDias.Columns.Add("cantidadC", Type.GetType("System.Int32"))

    End Sub
End Class
