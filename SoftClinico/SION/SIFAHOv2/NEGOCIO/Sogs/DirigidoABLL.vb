Public Class DirigidoABLL
    Dim cmd As New DirigidoADAL
    Public Sub establecer_tablas()
        Dim col1, col2 As New DataColumn

        col1.ColumnName = "Seleccionar"
        col1.DataType = Type.GetType("System.Boolean")
        col1.DefaultValue = False
        Form_dirigidos.dtdirigido.Columns.Add(col1)

        col2.ColumnName = "Accion"
        col2.DataType = Type.GetType("System.String")
        Form_dirigidos.dtdirigido.Columns.Add(col2)

    End Sub
    Public Function cargar_cargos() As DataTable
        Dim dt As New DataTable
        dt = cmd.cargar_cargos()
        Return dt
    End Function

End Class
