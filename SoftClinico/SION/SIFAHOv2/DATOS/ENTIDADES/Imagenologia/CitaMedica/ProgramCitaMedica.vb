Public Class ProgramCitaMedica
    Public Property idEps As Integer
    Public Property identipaciente As Integer
    Public Property nombre As String
    Public Property fecha As DateTime
    Public Property codigoEP As Integer
    Public Property codigoIdMedico As Integer
    Public Property codigoAtencion As String
    Public Property observacion As String
    Public Property usuario As Integer
    Public Property celular As String
    Property cantidadTiempo As Integer
    Public Property dtParaclinicos As DataTable
    Public Property dtProcedimiento As DataTable
    Public Property dtParaclinicosNuevo As DataTable
    Public Property correo As String
    Public Sub cargarParaclinicos()
        Dim params As New List(Of String)
        params.Add(codigoAtencion)
        General.llenarTabla(Consultas.CITA_MEDICA_CARGAR_PARACLINICOS, params, dtParaclinicos)
    End Sub

    Public Sub cargarProcedimientos()
        Dim params As New List(Of String)
        params.Add(codigoAtencion)
        General.llenarTabla(Consultas.CITA_MEDICA_CARGAR_PROCEDIMIENTOS, params, dtProcedimiento)
    End Sub

    Public Sub guardarCitaMedica()
        dtParaclinicosNuevo = New DataTable
        dtParaclinicosNuevo = dtParaclinicos.Copy
        dtParaclinicosNuevo.Columns.Remove("Resultado")
        ProgramCitaMedicaDAL.guardarCitaMedica(Me)
    End Sub

    Public Sub establecerDGVParaclinico(dgvParaclinicos As DataGridView)
        With dgvParaclinicos
            .Columns.Item("dgcodigo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgcodigo").DataPropertyName = "Codigo"

            .Columns.Item("dgDescripcionp").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgDescripcionp").DataPropertyName = "Descripcion"

            .Columns.Item("dgcantidadp").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgcantidadp").DataPropertyName = "Cantidad"


            .Columns.Item("dganular").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dganular").DataPropertyName = "Quitar"
        End With
        dgvParaclinicos.DataSource = dtParaclinicos

    End Sub

    Public Sub establecerDGVprocedimientos(dgvProcedimientos As DataGridView)
        With dgvProcedimientos
            .Columns.Item("dgcodigop").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgcodigop").DataPropertyName = "Codigo"

            .Columns.Item("dgDescripcionps").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgDescripcionps").DataPropertyName = "Descripcion"

            .Columns.Item("dgcantidadps").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgcantidadps").DataPropertyName = "Cantidad"


            .Columns.Item("dganularps").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dganularps").DataPropertyName = "Quitar"
        End With
        dgvProcedimientos.DataSource = dtProcedimiento
    End Sub

    Sub New()
        dtParaclinicos = New DataTable
        dtParaclinicos.Columns.Add("Codigo", Type.GetType("System.String"))
        dtParaclinicos.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtParaclinicos.Columns.Add("Cantidad", Type.GetType("System.String"))
        dtParaclinicos.Columns.Add("Resultado", Type.GetType("System.String"))
        dtParaclinicos.Columns("Cantidad").DefaultValue = 0

        dtProcedimiento = New DataTable
        dtProcedimiento.Columns.Add("Codigo", Type.GetType("System.String"))
        dtProcedimiento.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtProcedimiento.Columns.Add("Cantidad", Type.GetType("System.String"))
        dtProcedimiento.Columns("Cantidad").DefaultValue = 0

    End Sub

End Class
