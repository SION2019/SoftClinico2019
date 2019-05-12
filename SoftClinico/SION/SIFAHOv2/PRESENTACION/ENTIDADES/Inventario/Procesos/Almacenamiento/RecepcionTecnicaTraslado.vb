Public Class RecepcionTecnicaTraslado
    Inherits Despacho
    Public Property codigoRecepcion As String
    Public Property codigoTraslado As Integer
    Public Property fechaRecepcion As DateTime
    Public Property tblProdcutos As DataTable
    Sub New()
        tblLotes = New DataSet
        tblProdcutos = New DataTable
        tblProdcutos.Columns.Add("Codigo_producto", Type.GetType("System.Int64"))
        tblProdcutos.Columns.Add("Descripcion", Type.GetType("System.String"))
        tblProdcutos.Columns.Add("Marca", Type.GetType("System.String"))
        tblProdcutos.Columns.Add("CantPed", Type.GetType("System.Int64"))
        tblProdcutos.Columns.Add("CantEnv", Type.GetType("System.Int64"))
        tblProdcutos.Columns.Add("CantFal", Type.GetType("System.Int64"))
        tblProdcutos.Columns.Add("Confirmacion", Type.GetType("System.Boolean"))
    End Sub
    Sub colocarColumnasTabla(ByVal nombreTabla As String)
        tblLotes.Tables(nombreTabla).Columns.Add("Reg_lote", Type.GetType("System.Int64"))
        tblLotes.Tables(nombreTabla).Columns.Add("Num_lote", Type.GetType("System.String"))
        tblLotes.Tables(nombreTabla).Columns.Add("Fecha_Vence", Type.GetType("System.DateTime"))
        tblLotes.Tables(nombreTabla).Columns.Add("CantEnv", Type.GetType("System.Int64"))
        tblLotes.Tables(nombreTabla).Columns.Add("Costo", Type.GetType("System.Int64"))
        tblLotes.Tables(nombreTabla).Columns.Add("Excepcion", Type.GetType("System.Boolean"))
    End Sub

End Class
