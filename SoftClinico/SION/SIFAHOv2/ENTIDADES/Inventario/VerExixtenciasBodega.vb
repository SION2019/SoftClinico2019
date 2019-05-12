Public Class VerExixtenciasBodega
    Public Property codigoBodega As Integer
    Public Property tblProductos As DataTable
    Public Property tblLotes As DataTable
    Sub New()
        tblProductos = New DataTable
        tblLotes = New DataTable
    End Sub

    Public Sub listarProductosAsignadosBodega(ByVal busqueda As String)
        Dim params As New List(Of String)
        params.Add(codigoBodega)
        params.Add(busqueda)
        General.llenarTabla(Consultas.LISTAR_EXISTENCIAS_EN_BODEGA, params, tblProductos)
    End Sub
    Public Sub listarLotesDePorducto(ByVal codigo As Integer)
        Dim params As New List(Of String)
        params.Add(codigoBodega)
        params.Add(codigo)
        General.llenarTabla(Consultas.LISTAR_EXISTENCIAS_LOTES_PRODUCTOS_EN_BODEGAS, params, tblLotes, True)
    End Sub
End Class
