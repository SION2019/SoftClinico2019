Public Class Conteo
    Inherits Despacho
    Public Property codigoConteo As String
    Public Property fechaConteo As DateTime
    Public Property codigoBodega As Integer
    Public Property observacion As String
    Public Property enlace As BindingSource
    Public Property tblProductos As DataTable
    Sub New()
        tblProductos = New DataTable
        tblLotes = New DataSet
        enlace = New BindingSource

        tblProductos.Columns.Add("Codigo", Type.GetType("System.String"))
        tblProductos.Columns.Add("Descripcion", Type.GetType("System.String"))
        tblProductos.Columns.Add("Marca", Type.GetType("System.String"))
        tblProductos.Columns.Add("Stock", Type.GetType("System.Int32"))
        tblProductos.Columns.Add("Conteo", Type.GetType("System.Int32"))
        tblProductos.Columns.Add("Costo", Type.GetType("System.Double"))
        tblProductos.Columns.Add("Total", Type.GetType("System.Double"))
        tblProductos.Columns.Add("Ubicacion", Type.GetType("System.String"))
        tblProductos.Columns.Add("Estado", Type.GetType("System.String"))
        tblProductos.Columns("Estado").DefaultValue = Constantes.SIN_CONTAR
        tblProductos.Columns("Total").DefaultValue = 0
        tblProductos.Columns("Conteo").DefaultValue = 0
        tblProductos.Columns("Costo").DefaultValue = 0
        'tblProductos.Columns("Total").Expression = "Conteo*Costo"
    End Sub
    Sub agregarColumnasDataset(ByVal nombreTabla As String)
        If tblLotes.Tables(nombreTabla).Columns.Count = 0 Then
            tblLotes.Tables(nombreTabla).Columns.Add("Reg_lote", Type.GetType("System.String"))
            tblLotes.Tables(nombreTabla).Columns.Add("LoteNum", Type.GetType("System.String"))
            tblLotes.Tables(nombreTabla).Columns.Add("FechaVence", Type.GetType("System.DateTime"))
            tblLotes.Tables(nombreTabla).Columns.Add("StockLote", Type.GetType("System.Int32"))
            tblLotes.Tables(nombreTabla).Columns.Add("ConteoLote", Type.GetType("System.Int32"))
            tblLotes.Tables(nombreTabla).Columns.Add("Costo", Type.GetType("System.Double"))
            tblLotes.Tables(nombreTabla).Columns.Add("Excepcion", Type.GetType("System.Boolean"))
            tblLotes.Tables(nombreTabla).Columns("ConteoLote").DefaultValue = 0
            tblLotes.Tables(nombreTabla).Columns("Excepcion").DefaultValue = False
        End If
    End Sub
End Class
