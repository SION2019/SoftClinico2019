Public Class ListaCita
    Property dtLista As DataTable
    Public Sub New()
        dtLista = New DataTable
        dtLista.Columns.Add("Id", Type.GetType("System.String"))
        dtLista.Columns.Add("Codigo_Procedimiento", Type.GetType("System.String"))
        dtLista.Columns.Add("Hora", Type.GetType("System.String"))
        dtLista.Columns.Add("Paciente", Type.GetType("System.String"))
        dtLista.Columns.Add("Procedimiento", Type.GetType("System.String"))
        dtLista.Columns.Add("Resultado", Type.GetType("System.String"))
        dtLista.Columns.Add("Estado", Type.GetType("System.String"))
        dtLista.Columns.Add("Realizado", Type.GetType("System.Boolean"))

    End Sub

End Class
