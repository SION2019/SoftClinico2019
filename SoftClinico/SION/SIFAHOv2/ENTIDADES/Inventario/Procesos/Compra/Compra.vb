Public Class Compra
    Public Property codigoCompraPunto As String
    Public Property codigoCompra As String
    Public Property fechaCompra As DateTime
    Public Property fechaEntrega As DateTime
    Public Property codigoProveedor As String
    Public Property observacionCompra As String
    Public Property diasEntregaProveedor As Integer
    Public Property codigoListaProveedor As Integer
    Public Property tablaProductos As DataTable
    Public Property estado As Integer
    Public Property actualizarLista As Boolean
    Public Property emailProveedor As String
    Public Property cuentaCobro As Boolean
    Public Property objEnviocorreo As UsuarioEnvioCorreo
    Sub New()
        objEnviocorreo = New UsuarioEnvioCorreo
        tablaProductos = New DataTable
        tablaProductos.Columns.Add("Codigo", Type.GetType("System.String"))
        tablaProductos.Columns.Add("Descripcion", Type.GetType("System.String"))
        tablaProductos.Columns.Add("Marca", Type.GetType("System.String"))
        tablaProductos.Columns.Add("Presentacion", Type.GetType("System.String"))
        tablaProductos.Columns.Add("Iva", Type.GetType("System.Double"))
        tablaProductos.Columns.Add("StockEqui", Type.GetType("System.Int32"))
        tablaProductos.Columns.Add("Stock", Type.GetType("System.Int32"))
        tablaProductos.Columns.Add("Costo", Type.GetType("System.Double"))
        tablaProductos.Columns.Add("CPM", Type.GetType("System.Int32"))
        tablaProductos.Columns.Add("Cantidad", Type.GetType("System.Int32"))
        tablaProductos.Columns.Add("Descuento", Type.GetType("System.Double"))
        tablaProductos.Columns.Add("Total", Type.GetType("System.Double"), "Cantidad * Costo")
        tablaProductos.Columns.Add("SumaValorBruto", Type.GetType("System.Double"), "Sum(Total)")
        tablaProductos.Columns.Add("ValorIva", Type.GetType("System.Double"), "Iva*Total/100")
        tablaProductos.Columns.Add("SumaValorIva", Type.GetType("System.Double"), "Sum(ValorIva)")
        tablaProductos.Columns.Add("ValorDescuento", Type.GetType("System.Double"), "Descuento*Total/100")
        tablaProductos.Columns.Add("SumaValorDescuento", Type.GetType("System.Double"), "Sum(ValorDescuento)")
        tablaProductos.Columns.Add("SumaValorTotal", Type.GetType("System.Double"), "(SumaValorBruto+SumaValorIva)-SumaValorDescuento")
        tablaProductos.Columns.Add("Orden", Type.GetType("System.Int32"))

        tablaProductos.Columns("Orden").AutoIncrement = True
        tablaProductos.Columns("Orden").AutoIncrementStep = 1

        tablaProductos.Columns("Iva").DefaultValue = 0
        tablaProductos.Columns("StockEqui").DefaultValue = 0
        tablaProductos.Columns("Stock").DefaultValue = 0
        tablaProductos.Columns("Costo").DefaultValue = 0
        tablaProductos.Columns("CPM").DefaultValue = 0
        tablaProductos.Columns("Cantidad").DefaultValue = 0
        tablaProductos.Columns("Descuento").DefaultValue = 0
        tablaProductos.Columns("Total").DefaultValue = 0
        tablaProductos.Columns("SumaValorBruto").DefaultValue = 0
        tablaProductos.Columns("ValorIva").DefaultValue = 0
        tablaProductos.Columns("SumaValorIva").DefaultValue = 0
        tablaProductos.Columns("ValorDescuento").DefaultValue = 0
        tablaProductos.Columns("SumaValorDescuento").DefaultValue = 0
        tablaProductos.Columns("SumaValorTotal").DefaultValue = 0

    End Sub
End Class
