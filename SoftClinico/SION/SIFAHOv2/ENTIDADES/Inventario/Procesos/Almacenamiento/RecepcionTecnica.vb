Public Class RecepcionTecnica
    Inherits Despacho
    Public Property codigoRecepcionPunto As String
    Public Property codigoRecepcion As String
    Public Property codigoOrden As Integer
    Public Property codigoOrdenPunto As String
    Public Property codigoTransportadora As Integer
    Public Property noFactura As String
    Public Property guia As String
    Public Property fechaRecepcion As DateTime
    Public Property tblProductos As DataTable
    Sub New()
        tblLotes = New DataSet
        tblProductos = New DataTable

        tblProductos.Columns.Add("Codigo", Type.GetType("System.String"))
        tblProductos.Columns.Add("Descripcion", Type.GetType("System.String"))
        tblProductos.Columns.Add("Marca", Type.GetType("System.String"))
        tblProductos.Columns.Add("Iva", Type.GetType("System.Int32"))
        tblProductos.Columns.Add("Descuento", Type.GetType("System.Int32"))
        tblProductos.Columns.Add("Cantidad", Type.GetType("System.Int32"))
        tblProductos.Columns.Add("Cantida_Recibida", Type.GetType("System.Int32"))
        tblProductos.Columns.Add("Cantidad_Faltante", Type.GetType("System.Int32"))
        tblProductos.Columns.Add("Costo", Type.GetType("System.Double"))
        tblProductos.Columns.Add("Total", Type.GetType("System.Double"))
        tblProductos.Columns.Add("Codigo_Bodega", Type.GetType("System.String"))
        tblProductos.Columns.Add("Bodega_Escoger", Type.GetType("System.String"))


        tblProductos.Columns("Iva").DefaultValue = 0
        tblProductos.Columns("Descuento").DefaultValue = 0
        tblProductos.Columns("Cantidad").DefaultValue = 0
        tblProductos.Columns("Cantida_Recibida").DefaultValue = 0
        tblProductos.Columns("Cantidad_Faltante").DefaultValue = 0
        tblProductos.Columns("Total").DefaultValue = 0
        tblProductos.Columns("Bodega_Escoger").DefaultValue = Constantes.SELECCIONE_BODEGA

        tblProductos.Columns("Total").Expression = ("Cantida_Recibida * Costo")
        tblProductos.Columns("Cantidad_Faltante").Expression = ("(Cantidad - Cantida_Recibida)")
    End Sub
    Public Sub colocarColumnasTablaLotes(ByVal tabla As String)
        tblLotes.Tables(tabla).Columns.Add("Reg_lote", Type.GetType("System.String"))
        tblLotes.Tables(tabla).Columns.Add("Num_lote", Type.GetType("System.String"))
        tblLotes.Tables(tabla).Columns.Add("Fecha", Type.GetType("System.DateTime"))
        tblLotes.Tables(tabla).Columns.Add("Cantidad", Type.GetType("System.Int32"))
        tblLotes.Tables(tabla).Columns.Add("Excepcion", Type.GetType("System.Boolean"))
        tblLotes.Tables(tabla).Columns("Fecha").DefaultValue = CDate(Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA))
        tblLotes.Tables(tabla).Columns("Cantidad").DefaultValue = 0
        tblLotes.Tables(tabla).Columns("Excepcion").DefaultValue = False
    End Sub
End Class
