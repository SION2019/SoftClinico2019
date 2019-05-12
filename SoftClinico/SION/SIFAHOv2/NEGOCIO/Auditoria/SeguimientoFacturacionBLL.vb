Public Class SeguimientoFacturacionBLL
    Public Function SumarVal(dtable As DataTable, columnaRevision As String, condicion As String) As DataTable
        Dim filas As DataRow()
        Dim dtContenedor As New DataTable
        Dim dtRespuesta As New DataTable
        dtRespuesta.Columns.Add("Cantidad")
        dtRespuesta.Columns.Add("Total")
        filas = dtable.Select("(CONVERT(" & columnaRevision & ",'System.String') <> '' " & condicion & ")")
        dtContenedor = dtable.Clone
        For Each fila As DataRow In filas
            dtContenedor.ImportRow(fila)
        Next
        dtRespuesta.Rows.Add()
        dtRespuesta.Rows(0).Item("Cantidad") = dtContenedor.Rows.Count
        dtRespuesta.Rows(0).Item("Total") = If(dtContenedor.Rows.Count = 0, 0, dtContenedor.Compute("sum(" & columnaRevision & ")", ""))

        Return dtRespuesta
    End Function
    Public Function PromediarVal(dtable As DataTable, columna As String) As Integer
        Dim ResPromedio As String
        ResPromedio = If(IsDBNull(dtable.Compute("Avg(" & columna & ")", columna & " Is Not Null")), 0, dtable.Compute("Avg(" & columna & ")", columna & " Is Not Null"))
        Return ResPromedio
    End Function
End Class
