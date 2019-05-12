Public Class BajaProducto
    Public Property codigoBajaPunto As String
    Public Property codigoBaja As String
    Public Property fechaBaja As DateTime
    Public Property motivo As Integer
    Public Property codigoBodega As Integer
    Public Property tblProductos As DataTable
    Public Property enlace As New BindingSource
    Sub New()
        tblProductos = New DataTable
        tblProductos.Columns.Add("Codigo_producto", Type.GetType("System.Int64"))
        tblProductos.Columns.Add("Descripcion", Type.GetType("System.String"))
        tblProductos.Columns.Add("Marca", Type.GetType("System.String"))
        tblProductos.Columns.Add("Reg_lote", Type.GetType("System.Int64"))
        tblProductos.Columns.Add("Num_lote", Type.GetType("System.String"))
        tblProductos.Columns.Add("Fecha_Vence", Type.GetType("System.String"))
        tblProductos.Columns.Add("Stock", Type.GetType("System.Int64"))
        tblProductos.Columns.Add("Cantidad", Type.GetType("System.Double"))
        tblProductos.Columns.Add("Costo", Type.GetType("System.Double"))
        tblProductos.Columns.Add("Ok", Type.GetType("System.Boolean"))
        tblProductos.Columns.Add("Total", Type.GetType("System.Double"))

        tblProductos.Columns("OK").Expression = "IIF(Cantidad > 0, True, False)"
        tblProductos.Columns("Total").Expression = "(Cantidad * Costo)"
    End Sub
End Class
