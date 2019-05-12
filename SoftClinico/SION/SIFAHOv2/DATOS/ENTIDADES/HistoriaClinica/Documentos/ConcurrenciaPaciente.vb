Imports System.Data.SqlClient
Public Class ConcurrenciaPaciente
    Public Property dtConcurrencia As DataTable

    Sub New()
        dtConcurrencia = New DataTable
        dtConcurrencia.Columns.Add("fecha", Type.GetType("System.DateTime"))
        dtConcurrencia.Columns.Add("codigo_cama", Type.GetType("System.String"))
        dtConcurrencia.Columns.Add("N_Registro", Type.GetType("System.String"))
        dtConcurrencia.Columns.Add("tot", Type.GetType("System.Boolean"))
        dtConcurrencia.Columns.Add("sv", Type.GetType("System.Boolean"))
        dtConcurrencia.Columns.Add("ct", Type.GetType("System.Boolean"))
        dtConcurrencia.Columns.Add("mah", Type.GetType("System.Boolean"))
        dtConcurrencia.Columns.Add("CUR", Type.GetType("System.Boolean"))
        dtConcurrencia.Columns.Add("pendientes", Type.GetType("System.String"))
        dtConcurrencia.Columns.Add("correcciones", Type.GetType("System.String"))
        dtConcurrencia.Columns.Add("generalidades_r", Type.GetType("System.String"))
        dtConcurrencia.Columns.Add("generalidades_v", Type.GetType("System.String"))
        dtConcurrencia.Columns.Add("observaciones_auditoria", Type.GetType("System.String"))
        dtConcurrencia.Columns.Add("usuario_creacion", Type.GetType("System.String"))


    End Sub
End Class
