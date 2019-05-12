Public Class VerExixtenciasBodega
    Inherits Despacho
    Public Property codigoBodega As Integer
    Public Property tblProductos As DataTable
    Sub New()
        tblProductos = New DataTable
        tblLotes = New DataSet
    End Sub


End Class
