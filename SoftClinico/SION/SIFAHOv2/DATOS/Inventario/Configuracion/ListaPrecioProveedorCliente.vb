Public Class ListaPrecioProveedorCliente
    Public Property codigoLista As String
    Public Property idTercero As Integer
    Public Property nombreTercero As String
    Public Property nombreLista As String
    Public Property tblProductos As DataTable
    Public Property tipoLista As Integer
    Sub New()
        codigoLista = ""
        tblProductos = New DataTable
        tblProductos.Columns.Add("Codigo", Type.GetType("System.String"))
        tblProductos.Columns.Add("Descripcion", Type.GetType("System.String"))
        tblProductos.Columns.Add("Marca", Type.GetType("System.String"))
        tblProductos.Columns.Add("Costo", Type.GetType("System.Double"))
        tblProductos.Columns.Add("Precio", Type.GetType("System.Double"))

    End Sub
    Sub agregarColumnaBandera()
        If Not tblProductos.Columns.Contains("tipo") Then
            tblProductos.Columns.Add("tipo", Type.GetType("System.Int32"))
            tblProductos.Columns("tipo").DefaultValue = 0
        End If

    End Sub
    Sub quitarColumnaBandera()
        If tblProductos.Columns.Contains("tipo") Then
            tblProductos.Columns.Remove("tipo")
        End If
    End Sub
End Class
