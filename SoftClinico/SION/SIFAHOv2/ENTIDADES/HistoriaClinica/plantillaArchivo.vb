Public Class plantillaArchivo
    Property dtAchivo As DataTable

    Public Sub New()
        dtAchivo = New DataTable
        dtAchivo.Columns.Add("Codigo_Plantilla", Type.GetType("System.Int32"))
        dtAchivo.Columns.Add("NombreDiag", Type.GetType("System.String"))
    End Sub
End Class
