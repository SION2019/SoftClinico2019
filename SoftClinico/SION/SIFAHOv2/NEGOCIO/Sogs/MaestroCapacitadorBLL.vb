Public Class MaestroCapacitadorBLL
    Dim cmd As New MaestroCapacitadorDAL
    Public Sub establecer_tabla(dtCapacitacion As DataTable)
        Dim col1, col2, col3, col4, col5, col6, col7, col8, col9 As New DataColumn

        col1.ColumnName = "Num"
        col1.DataType = Type.GetType("System.String")
        dtCapacitacion.Columns.Add(col1)

        col2.ColumnName = "Codigo"
        col2.DataType = Type.GetType("System.Int32")
        dtCapacitacion.Columns.Add(col2)

        col3.ColumnName = "Tema"
        col3.DataType = Type.GetType("System.String")
        dtCapacitacion.Columns.Add(col3)

        col4.ColumnName = "Fecha"
        col4.DataType = Type.GetType("System.String")
        dtCapacitacion.Columns.Add(col4)

        col5.ColumnName = "Id_capacitador"
        col5.DataType = Type.GetType("System.Int32")
        dtCapacitacion.Columns.Add(col5)

        col6.ColumnName = "Capacitador"
        col6.DataType = Type.GetType("System.String")
        dtCapacitacion.Columns.Add(col6)

        col7.ColumnName = "Dirigido_A"
        col7.DataType = Type.GetType("System.String")
        col7.DefaultValue = "Dirigido A"
        dtCapacitacion.Columns.Add(col7)

        col8.ColumnName = "Asistentes"
        col8.DataType = Type.GetType("System.String")
        col8.DefaultValue = "Asistentes"
        dtCapacitacion.Columns.Add(col8)

        col9.ColumnName = "Accion"
        col9.DataType = Type.GetType("System.String")
        dtCapacitacion.Columns.Add(col9)

    End Sub

End Class
