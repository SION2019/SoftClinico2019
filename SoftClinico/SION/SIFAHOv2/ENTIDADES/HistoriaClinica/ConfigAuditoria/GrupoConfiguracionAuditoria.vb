Public Class GrupoConfiguracionAuditoria
    Public Property codigoGrupo As String
    Public Property nombreGrupo As String
    Public Property dtGrupoConfiguracion As DataTable

    Sub New()
        dtGrupoConfiguracion = New DataTable
        dtGrupoConfiguracion.Columns.Add("CodigoGrupo", Type.GetType("System.String"))
        dtGrupoConfiguracion.Columns.Add("Código", Type.GetType("System.Int32"))
        dtGrupoConfiguracion.Columns.Add("NombreGrupo", Type.GetType("System.String"))
        dtGrupoConfiguracion.Columns.Add("usuario", Type.GetType("System.Int32"))
    End Sub
End Class
