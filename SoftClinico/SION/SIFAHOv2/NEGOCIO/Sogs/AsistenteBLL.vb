Public Class AsistenteBLL
    Dim cmd As New AsistenteDAL
    Public Sub establecer_tablas()
        Dim col1, col2, col3 As New DataColumn

        col1.ColumnName = "Codigo"
        col1.DataType = Type.GetType("System.String")
        Form_Asistentes.dtasistente.Columns.Add(col1)

        col2.ColumnName = "Empleado"
        col2.DataType = Type.GetType("System.String")
        Form_Asistentes.dtasistente.Columns.Add(col2)

        col3.ColumnName = "Accion"
        col3.DataType = Type.GetType("System.String")
        Form_Asistentes.dtasistente.Columns.Add(col3)

    End Sub

End Class
