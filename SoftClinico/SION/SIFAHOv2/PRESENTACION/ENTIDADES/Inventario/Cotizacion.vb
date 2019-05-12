Public Class Cotizacion
    Public Property codigo As String
    Public Property codigoCliente As Integer
    Public Property fecha As DateTime
    Public Property observacion As String
    Public Property estado As Integer
    Public Property tblProductos As DataTable
    Sub New()
        tblProductos = New DataTable
        tblProductos.Columns.Add("Codigo", Type.GetType("System.String"))
        tblProductos.Columns.Add("Descripcion", Type.GetType("System.String"))
        tblProductos.Columns.Add("Marca", Type.GetType("System.String"))
        tblProductos.Columns.Add("Stock", Type.GetType("System.Int64"))
        tblProductos.Columns.Add("Iva", Type.GetType("System.Double"))
        tblProductos.Columns.Add("Precio", Type.GetType("System.Double"))
        tblProductos.Columns.Add("Cantidad", Type.GetType("System.Int64"))
        tblProductos.Columns.Add("Descuento", Type.GetType("System.Double"))
        tblProductos.Columns.Add("Total", Type.GetType("System.Double"))
        tblProductos.Columns.Add("ValorIva", Type.GetType("System.Double"))
        tblProductos.Columns.Add("ValorDescuento", Type.GetType("System.Double"))

        tblProductos.Columns("Descuento").DefaultValue = 0
        tblProductos.Columns("Iva").DefaultValue = 0
        tblProductos.Columns("Cantidad").DefaultValue = 0
        tblProductos.Columns("Total").DefaultValue = 0
        tblProductos.Columns("ValorIva").DefaultValue = 0
        tblProductos.Columns("ValorDescuento").DefaultValue = 0
    End Sub

End Class
