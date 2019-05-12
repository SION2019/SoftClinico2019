Public Class CuentaCobro
    Public Property codigoOrden As Integer
    Public Property codigoOrdenPunto As Integer
    Public Property codigoCuentaCobro As String
    Public Property consecutivoInterno As Integer
    Public Property fechaCuentaCobro As DateTime
    Public Property tablaCuentaCobro As DataTable
    Sub New()
        tablaCuentaCobro = New DataTable
        tablaCuentaCobro.Columns.Add("Codigo_Producto", Type.GetType("System.String"))
        tablaCuentaCobro.Columns.Add("Descripcion", Type.GetType("System.String"))
        tablaCuentaCobro.Columns.Add("Marca", Type.GetType("System.String"))
        tablaCuentaCobro.Columns.Add("Presentacion", Type.GetType("System.String"))
        tablaCuentaCobro.Columns.Add("Cant", Type.GetType("System.Int32"))
        tablaCuentaCobro.Columns.Add("CantFac", Type.GetType("System.Int32"))
        tablaCuentaCobro.Columns.Add("CantFal", Type.GetType("System.Int32"), "iif((Cant-CantFac) >= 0,(Cant-CantFac),0) ")
        tablaCuentaCobro.Columns.Add("Valor", Type.GetType("System.Double"))
        tablaCuentaCobro.Columns.Add("Total", Type.GetType("System.Double"), "CantFac * Valor")
        tablaCuentaCobro.Columns("Cant").DefaultValue = 0
        tablaCuentaCobro.Columns("CantFac").DefaultValue = 0
        tablaCuentaCobro.Columns("CantFal").DefaultValue = 0
        tablaCuentaCobro.Columns("Valor").DefaultValue = 0
        tablaCuentaCobro.Columns("Total").DefaultValue = 0
    End Sub
End Class
