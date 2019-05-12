Public Class TrasladoProducto
    Inherits Despacho
    Public Property codigoTrasladoPunto As String
    Public Property codigoPedido As String
    Public Property codigoPedidoPunto As String
    Public Property codigoTraslado As String
    Public Property bodegaSolicitante As String
    Public Property bodegaSolicitada As String
    Public Property fechaTraslado As DateTime
    Public Property estadoTraslado As Boolean
    Public Property aumentoBodeg As Boolean
    Public Property noGuia As String
    Public Property trasnportadora As String
    Public Property tblProductos As New DataTable
    Public Property porcentaje As Boolean
    Public Property activarPrincial As Boolean

    Sub New()
        activarPrincial = False
        tblLotes = New DataSet
        tblProductos.Columns.Add("Codigo_Interno", Type.GetType("System.Int32"))
        tblProductos.Columns.Add("Nombre_equi", Type.GetType("System.String"))
        tblProductos.Columns.Add("Stock", Type.GetType("System.Int32"))
        tblProductos.Columns.Add("CantPed", Type.GetType("System.Int32"))
        tblProductos.Columns.Add("CantEnt", Type.GetType("System.Int32"))
        tblProductos.Columns.Add("CantFalt", Type.GetType("System.Int32"), "(CantPed - CantEnt)")
        tblProductos.Columns.Add("CPQ", Type.GetType("System.Int32"))
        tblProductos.Columns.Add("Codigo", Type.GetType("System.String"))
        tblProductos.Columns.Add("Nombre_producto", Type.GetType("System.String"))
        tblProductos.Columns.Add("Marca", Type.GetType("System.String"))
        tblProductos.Columns.Add("Agregada", Type.GetType("System.String"))
        tblProductos.Columns.Add("Total_P", Type.GetType("System.Double"))
        tblProductos.Columns.Add("Stock_solicitante", Type.GetType("System.Int32"))

        tblProductos.Columns("Stock").DefaultValue = 0
        tblProductos.Columns("CantPed").DefaultValue = 0
        tblProductos.Columns("CantEnt").DefaultValue = 0
        tblProductos.Columns("CPQ").DefaultValue = 0
        tblProductos.Columns("Stock_solicitante").DefaultValue = 0
    End Sub
    Public Sub llenarTablaLotes(ByVal nombreTabla As String)
        If Funciones.contarColumnasTablas(tblLotes.Tables(nombreTabla)) = 0 Then
            tblLotes.Tables(nombreTabla).Columns.Add("Reg_lote", Type.GetType("System.String"))
            tblLotes.Tables(nombreTabla).Columns.Add("Num_lote", Type.GetType("System.String"))
            tblLotes.Tables(nombreTabla).Columns.Add("Fecha", Type.GetType("System.DateTime"))
            tblLotes.Tables(nombreTabla).Columns.Add("stock", Type.GetType("System.Int32"))
            tblLotes.Tables(nombreTabla).Columns.Add("Cantidad", Type.GetType("System.Int32"))
            tblLotes.Tables(nombreTabla).Columns.Add("Costo", Type.GetType("System.Double"))
            tblLotes.Tables(nombreTabla).Columns.Add("Total", Type.GetType("System.Double"), "Costo*Cantidad")

            tblLotes.Tables(nombreTabla).Columns("Fecha").DefaultValue = Date.Today
            tblLotes.Tables(nombreTabla).Columns("stock").DefaultValue = 0
            tblLotes.Tables(nombreTabla).Columns("Cantidad").DefaultValue = 0
            tblLotes.Tables(nombreTabla).Columns("Costo").DefaultValue = 0
            tblLotes.Tables(nombreTabla).Columns("Total").DefaultValue = 0
        End If
    End Sub
End Class
