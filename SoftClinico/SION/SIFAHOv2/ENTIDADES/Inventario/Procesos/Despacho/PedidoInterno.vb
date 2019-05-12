Public Class PedidoInterno
    Public Property codigoPedidoPunto As String
    Public Property codigoPedido As String
    Public Property codigoBodegaSolicitante As Integer
    Public Property codigoBodegaSolicitada As Integer
    Public Property enlace As BindingSource
    Public Property fechaPedido As DateTime
    Public Property tblProductos As DataTable
    Public Property esExterno As Boolean
    Sub New()

        enlace = New BindingSource
        tblProductos = New DataTable
        tblProductos.Columns.Add("Codigo", Type.GetType("System.String"))
        tblProductos.Columns.Add("Nombre", Type.GetType("System.String"))
        tblProductos.Columns.Add("Stock", Type.GetType("System.Int32"))
        tblProductos.Columns.Add("Stock Solicitante", Type.GetType("System.Int32"))
        tblProductos.Columns.Add("Consumo_Promedio", Type.GetType("System.Double"))
        tblProductos.Columns.Add("Cantidad", Type.GetType("System.Int32"))
        tblProductos.Columns.Add("Verificacion", Type.GetType("System.Boolean"))

        tblProductos.Columns("Stock").DefaultValue = 0
        tblProductos.Columns("Cantidad").DefaultValue = 0
        tblProductos.Columns("Consumo_Promedio").DefaultValue = 0
        tblProductos.Columns("Verificacion").Expression = "IIf(Cantidad > 0, True, False)"
    End Sub
End Class
