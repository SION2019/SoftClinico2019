Public Class Indicadores
    Public Property dtIndicador As DataTable
    Public Property dtIndicadorMeta As DataTable
    Public Property dtCapacidad As DataTable
    Public Property dtGrafico As DataTable
    Public Property dtGraficoM As DataTable
    Public Property dtGraficoF As DataTable
    Public Property periodo As Integer
    Public Property usuario As Integer
    Public Property codigo As Integer
    Public Property Nivel As Integer
    Public Property CAP As Integer
    Public Property codEstancia As String
    Public Property Estancia As String
    Public Property sqlGuardarIndicadorMeta As String
    Public Sub New()
        dtIndicador = New DataTable
        dtGrafico = New DataTable
        dtGraficoM = New DataTable
        dtGraficoF = New DataTable
        dtIndicadorMeta = New DataTable

        dtCapacidad = New DataTable
        dtCapacidad.Columns.Add("Codigo_Area_servicio", Type.GetType("System.Int32"))
        dtCapacidad.Columns.Add("C_Intensivo", Type.GetType("System.Int32"))
        dtCapacidad.Columns.Add("C_Intermedio", Type.GetType("System.Int32"))
        dtCapacidad.Columns.Add("C_Basico", Type.GetType("System.Int32"))
        dtCapacidad.Columns.Add("O_Intensivo", Type.GetType("System.Int32"))
        dtCapacidad.Columns.Add("O_Intermedio", Type.GetType("System.Int32"))
        dtCapacidad.Columns.Add("O_Basico", Type.GetType("System.Int32"))
        dtCapacidad.Columns.Add("PE_Intensivo", Type.GetType("System.Double"))
        dtCapacidad.Columns.Add("PE_Intermedio", Type.GetType("System.Double"))
        dtCapacidad.Columns.Add("PE_Basico", Type.GetType("System.Double"))

        sqlGuardarIndicadorMeta = Consultas.INDICADORES_METAS_CREAR


    End Sub
End Class
