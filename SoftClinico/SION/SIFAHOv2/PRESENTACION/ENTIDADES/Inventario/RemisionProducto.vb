Public Class RemisionProducto
    Public Property codigoCotizacion As String
    Public Property codigoCliente As Integer
    Public Property codigoRemision As Integer
    Public Property fechaRemision As DateTime
    Public Property observacionRemision As String
    Public Property nombreTabla As String
    Public Property tblMedicamentos As DataTable
    Public Property tblInsumos As DataTable
    Public Property tblProcedimientos As DataTable
    Public Property tblLotesMedIns As DataSet
    Public Property IndexTbl As Integer
    Sub New()
        tblMedicamentos = New DataTable()
        tblMedicamentos.Columns.Add("Codigo", Type.GetType("System.String"))
        tblMedicamentos.Columns.Add("Descripcion", Type.GetType("System.String"))
        tblMedicamentos.Columns.Add("Marca", Type.GetType("System.String"))
        tblMedicamentos.Columns.Add("Codigo_Bodega", Type.GetType("System.String"))
        tblMedicamentos.Columns.Add("Bodega_Escoger", Type.GetType("System.String"))
        tblMedicamentos.Columns.Add("Cantidad", Type.GetType("System.Int64"))
        tblMedicamentos.Columns.Add("CantidadDes", Type.GetType("System.Int64"))
        tblMedicamentos.Columns.Add("Precio", Type.GetType("System.Double"))
        tblMedicamentos.Columns.Add("Total", Type.GetType("System.Double"))
        tblMedicamentos.Columns.Add("Estado", Type.GetType("System.String"))
        tblMedicamentos.Columns("Cantidad").DefaultValue = 0
        tblMedicamentos.Columns("CantidadDes").DefaultValue = 0
        tblMedicamentos.Columns("Precio").DefaultValue = 0
        tblMedicamentos.Columns("Total").DefaultValue = 0
        tblMedicamentos.Columns("Total").Expression = ("CantidadDes*Precio")

        tblInsumos = New DataTable()
        tblInsumos.Columns.Add("CodigoI", Type.GetType("System.String"))
        tblInsumos.Columns.Add("DescripcionI", Type.GetType("System.String"))
        tblInsumos.Columns.Add("MarcaI", Type.GetType("System.String"))
        tblInsumos.Columns.Add("Codigo_BodegaI", Type.GetType("System.String"))
        tblInsumos.Columns.Add("BodegaI_Escoger", Type.GetType("System.String"))
        tblInsumos.Columns.Add("CantidadI", Type.GetType("System.Int64"))
        tblInsumos.Columns.Add("CantidadDesI", Type.GetType("System.Int64"))
        tblInsumos.Columns.Add("PrecioI", Type.GetType("System.Double"))
        tblInsumos.Columns.Add("TotalI", Type.GetType("System.Double"))
        tblInsumos.Columns.Add("EstadoI", Type.GetType("System.String"))
        tblInsumos.Columns("CantidadI").DefaultValue = 0
        tblInsumos.Columns("CantidadDesI").DefaultValue = 0
        tblInsumos.Columns("PrecioI").DefaultValue = 0
        tblInsumos.Columns("TotalI").DefaultValue = 0
        tblInsumos.Columns("TotalI").Expression = ("CantidadDesI*PrecioI")


        tblProcedimientos = New DataTable()
        tblProcedimientos.Columns.Add("CodigoPro", Type.GetType("System.String"))
        tblProcedimientos.Columns.Add("DescripcionPro", Type.GetType("System.String"))
        tblProcedimientos.Columns.Add("PrecioPro", Type.GetType("System.Double"))
        tblProcedimientos.Columns.Add("CantidadPro", Type.GetType("System.Int64"))
        tblProcedimientos.Columns.Add("TotalPro", Type.GetType("System.Double"))
        tblProcedimientos.Columns.Add("Estado", Type.GetType("System.String"))
        tblProcedimientos.Columns("CantidadPro").DefaultValue = 0
        tblProcedimientos.Columns("PrecioPro").DefaultValue = 0
        tblProcedimientos.Columns("TotalPro").Expression = ("CantidadPro*PrecioPro")

        tblLotesMedIns = New DataSet

    End Sub
    Public Sub agredarColumnasDataSet(ByVal nombreTabla As String, ByVal tipo As Integer, ByVal bodega As Integer)
        tblLotesMedIns.Tables.Add(nombreTabla)
        tblLotesMedIns.Tables(nombreTabla).Columns.Add("Reg_lote", Type.GetType("System.Int64"))
        tblLotesMedIns.Tables(nombreTabla).Columns.Add("Num_lote", Type.GetType("System.String"))
        tblLotesMedIns.Tables(nombreTabla).Columns.Add("Fecha", Type.GetType("System.String"))
        tblLotesMedIns.Tables(nombreTabla).Columns.Add("Stock", Type.GetType("System.Int64"))
        tblLotesMedIns.Tables(nombreTabla).Columns.Add("Cantidad", Type.GetType("System.Int64"))
        tblLotesMedIns.Tables(nombreTabla).Columns.Add("Costo", Type.GetType("System.Double"))
        tblLotesMedIns.Tables(nombreTabla).Columns.Add("Total", Type.GetType("System.Double"))
        tblLotesMedIns.Tables(nombreTabla).Columns.Add("Bodega", Type.GetType("System.String"))
        tblLotesMedIns.Tables(nombreTabla).Columns.Add("Tipo", Type.GetType("System.String"))

        tblLotesMedIns.Tables(nombreTabla).Columns("Bodega").DefaultValue = bodega
        tblLotesMedIns.Tables(nombreTabla).Columns("Tipo").DefaultValue = tipo
        tblLotesMedIns.Tables(nombreTabla).Columns("Cantidad").DefaultValue = 0
        tblLotesMedIns.Tables(nombreTabla).Columns("Costo").DefaultValue = 0
        tblLotesMedIns.Tables(nombreTabla).Columns("Total").DefaultValue = 0
        tblLotesMedIns.Tables(nombreTabla).Columns("Total").Expression = ("Cantidad*Costo")
    End Sub
End Class
