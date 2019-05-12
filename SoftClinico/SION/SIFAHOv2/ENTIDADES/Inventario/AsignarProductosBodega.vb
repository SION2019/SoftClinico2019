Public Class AsignarProductosBodega
    Public Property tablaProductosSinAsignar As DataTable
    Public Property tablaProductosAsignados As DataTable
    Public Property codigoBodega As Integer
    Sub New()
        tablaProductosSinAsignar = New DataTable
        tablaProductosAsignados = New DataTable
    End Sub
End Class
