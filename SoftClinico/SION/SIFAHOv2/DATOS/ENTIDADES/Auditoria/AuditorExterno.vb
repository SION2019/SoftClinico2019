Public Class AuditorExterno

    Public Property dtAuditor As DataTable
    Public Property fecha As Date
    Public Property ideps As Integer
    Public Property dtEps As New DataTable
    Public Property registro As Integer
    Public Property nombre As String
    Public Property eps As String
    Public Property fechaAdmision As Date
    Public Sub cargarRegistros()
        Dim params As New List(Of String)
        params.Add(Format(fecha, "yyyyMMdd"))
        params.Add(ideps)
        params.Add(registro)
        General.llenarTabla(Consultas.AUDITOR_EXTERNO_ENTRADA_CARGAR, params, dtAuditor)
    End Sub

    Public Sub verificarAuditor()
        Dim parms As New List(Of String)
        parms.Add(ideps)
        parms.Add(registro)
        General.llenarTabla(Consultas.AUDITOR_VERIFICAR_EPS, parms, dtEps)
    End Sub

    Public Sub cargarPaciente()
        Dim dt As New DataTable
        Dim list As New List(Of String)
        list.Add(registro)
        General.llenarTabla(Consultas.LISTA_PACIENTE_CHEQUEO, list, dt)
        If dt.Rows.Count > 0 Then
            nombre = dt.Rows(0).Item("paciente")
            eps = dt.Rows(0).Item("eps")
            fechaAdmision = dt.Rows(0).Item("fecha_admision")
        End If
    End Sub
    Sub New()
        dtAuditor = New DataTable

        dtAuditor.Columns.Add("Fecha Entrada", Type.GetType("System.DateTime"))
        dtAuditor.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtAuditor.Columns.Add("Hora Entrada", Type.GetType("System.String"))
        dtAuditor.Columns.Add("Hora Salida", Type.GetType("System.String"))
    End Sub
End Class
