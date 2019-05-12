Public Class DespachoPedidoServicio
    Inherits Despacho
    Public Property codigoDespachoPedido As String
    Public Property codigoPedido As String
    Public Property codigoDespacho As String
    Public Property fechaDespacho As DateTime
    Public Property tblBodegas As New DataTable
    Public Property tblDetalle As New DataTable
    Public Property externo As Boolean

    Sub New()

        tblLotes = New DataSet
        'Tabla de bodegas 
        tblBodegas.Columns.Add("Codigo_Bodega", Type.GetType("System.String"))
        tblBodegas.Columns.Add("Nombre", Type.GetType("System.String"))
        tblBodegas.Columns.Add("Usar", Type.GetType("System.Boolean"))
        tblBodegas.Columns("Usar").DefaultValue = False

        'Tabla detalle de pedido de servivio
        tblDetalle.Columns.Add("CodigoInterno", Type.GetType("System.String"))
        tblDetalle.Columns.Add("Descripcion", Type.GetType("System.String"))
        tblDetalle.Columns.Add("CantidadPedida", Type.GetType("System.Int16"))
        tblDetalle.Columns.Add("CantidadDespachada", Type.GetType("System.Int16"))


    End Sub
End Class
