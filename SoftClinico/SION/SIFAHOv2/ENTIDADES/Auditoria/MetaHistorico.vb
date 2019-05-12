Public Class MetaHistorico
    Public Property dtHistorico As DataTable
    Public Property consultaHistoricoCargar As String
    Public Property fechaInicio As Date
    Public Property fechaFin As Date
    Public Sub New()
        dtHistorico = New DataTable

        dtHistorico.Columns.Add("IdEmpleado", Type.GetType("System.Int32"))
        dtHistorico.Columns.Add("Empleado", Type.GetType("System.String"))
        dtHistorico.Columns.Add("FechaMeta", Type.GetType("System.String"))
        dtHistorico.Columns.Add("Total", Type.GetType("System.Double")).DefaultValue = 0
        dtHistorico.Columns.Add("MetaAlcanzada", Type.GetType("System.Double")).DefaultValue = 0
        dtHistorico.Columns.Add("Porcentaje", Type.GetType("System.Double")).DefaultValue = 0
        consultaHistoricoCargar = ConsultasNom.EMPLEADO_META_ALCANZADA_CARGAR
    End Sub
    Public Sub cargarHistorico()
        Dim params As New List(Of String)
        params.Add(SesionActual.codigoEP)
        params.Add(Format(fechaInicio, Constantes.FORMATO_FECHA2))
        params.Add(Format(fechaFin, Constantes.FORMATO_FECHA2))
        General.llenarTabla(consultaHistoricoCargar, params, dtHistorico)
    End Sub
End Class
