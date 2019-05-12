Public Class ComiteCTC
    Inherits Procedimientos
    Public Property Codigo_Solic As Integer
    Public Property Codigo_PEM As Integer
    Public Property Encabezado As String
    Public Property Decision As String
    Public Property dtdiag As DataTable
    Public Property dtAsistentes As DataTable
    Public Property dtMedicamento As DataTable
    Public Property sqlCargarDiagnostico As String

    Sub New()
        sqlBuscarPaciente = Consultas.BUSQUEDA_BUSCAR_PACIENTE_CTC
        sqlCargarPaciente = Consultas.CARGAR_PACIENTE_CTC
        sqlCargarRegistro = Consultas.CARGAR_CTC
        sqlBuscarRegistro = Consultas.BUSQUEDA_BUSCAR_CTC
        sqlCargarDiagnostico = Consultas.EVO_DIAG_ULTIMO_REG
        titulo = "COMITE TECNICO CIENTIFICO (C.T.C): HISTORIA CLÍNICA"
        '---- Diagnostico
        dtdiag = New DataTable
        '---- Asistentes
        dtAsistentes = New DataTable
        '---- Medicamento
        dtMedicamento = New DataTable

        dtdiag.Columns.Add("Codigo", Type.GetType("System.String"))
        dtdiag.Columns.Add("Descripcion", Type.GetType("System.String"))

        dtAsistentes.Columns.Add("Indice", Type.GetType("System.Int32"))
        dtAsistentes.Columns.Add("Cargo", Type.GetType("System.String"))
        dtAsistentes.Columns.Add("ID_Empleado", Type.GetType("System.Int32"))
        dtAsistentes.Columns.Add("Cedula", Type.GetType("System.String"))
        dtAsistentes.Columns.Add("Nombre", Type.GetType("System.String"))

        dtMedicamento.Columns.Add("Codigo", Type.GetType("System.Int32"))
        dtMedicamento.Columns.Add("Medicamento", Type.GetType("System.String"))
        dtMedicamento.Columns.Add("dosis", Type.GetType("System.String"))
        dtMedicamento.Columns.Add("cant", Type.GetType("System.String"))
        dtMedicamento.Columns.Add("dias", Type.GetType("System.String"))
    End Sub

    Public Overrides Sub guardarRegistro()
        If codigo = String.Empty Then
            codigo = -1
        End If
        ComiteTecnicoCientificoBLL.guardarCTC(Me)
    End Sub

End Class
