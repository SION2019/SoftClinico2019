Public Class ConsolidadoComida
    Public Property tblDesayunos As DataTable
    Public Property tblAlmuerzos As DataTable
    Public Property tblCenas As DataTable
    Sub New()

        tblDesayunos = New DataTable
        tblAlmuerzos = New DataTable
        tblCenas = New DataTable

        tblDesayunos.Columns.Add("Codigo_Comida", Type.GetType("System.String"))
        tblDesayunos.Columns.Add("Nombre", Type.GetType("System.String"))
        tblDesayunos.Columns.Add("Cantidad", Type.GetType("System.Int32"))
        tblDesayunos.Columns.Add("Valor", Type.GetType("System.Double"))
        tblDesayunos.Columns.Add("Valor_total", Type.GetType("System.Double"))
        tblDesayunos.Columns("Valor_total").Expression = "Cantidad*Valor"

        tblAlmuerzos = tblDesayunos.Clone
        tblCenas = tblDesayunos.Clone
    End Sub
End Class
