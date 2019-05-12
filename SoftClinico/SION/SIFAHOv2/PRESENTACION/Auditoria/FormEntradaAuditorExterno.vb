Public Class FormEntradaAuditorExterno
    Dim objAuditor As New AuditorExterno
    Dim nRegistro As Integer
    Private Sub FormEntradaAuditorExterno_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With dgvAuditor
            .Columns("Fecha").ReadOnly = True
            .Columns.Item("Fecha").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Fecha").DataPropertyName = "Fecha Entrada"

            .Columns("Descripcion").ReadOnly = True
            .Columns.Item("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Descripcion").DataPropertyName = "Descripcion"

            .Columns("Horae").ReadOnly = True
            .Columns.Item("Horae").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Horae").DataPropertyName = "Hora Entrada"

            .Columns("Horas").ReadOnly = True
            .Columns.Item("Horas").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Horas").DataPropertyName = "Hora Salida"

        End With
        cargarPaciente()
        cargarRegistros()
    End Sub

    Public Sub obtenerRegistro(ByVal registro As Integer)
        nRegistro = registro
    End Sub
    Public Sub cargarPaciente()
        objAuditor.registro = nRegistro
        objAuditor.cargarPaciente()
        txtregistro.Text = objAuditor.registro
        txtpaciente.Text = objAuditor.nombre
        txteps.Text = objAuditor.eps
        txtfecha.Text = objAuditor.fechaAdmision
    End Sub

    Public Sub cargarRegistros()
        Dim params As New List(Of String)
        params.Add(nRegistro)
        objAuditor.ideps = General.getValorConsulta(Consultas.AUDITOR_GET_IDEPS, params)
        objAuditor.fecha = fechaauditor.Value
        objAuditor.registro = nRegistro
        objAuditor.cargarRegistros()
        dgvAuditor.DataSource = objAuditor.dtAuditor
    End Sub

    Private Sub fechaauditor_ValueChanged(sender As Object, e As EventArgs) Handles fechaauditor.ValueChanged
        cargarRegistros()
    End Sub
End Class