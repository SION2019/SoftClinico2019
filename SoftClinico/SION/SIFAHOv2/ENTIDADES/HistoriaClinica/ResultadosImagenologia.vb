Public Class ResultadosImagenologia

    Public Property tablaResultados As DataTable
    Sub New()
        tablaResultados = New DataTable()
        tablaResultados.Columns.Add("Registro", Type.GetType("System.String"))
        tablaResultados.Columns.Add("Paciente", Type.GetType("System.String"))
        tablaResultados.Columns.Add("EPS", Type.GetType("System.String"))
        tablaResultados.Columns.Add("Codigo_Orden", Type.GetType("System.String"))
        tablaResultados.Columns.Add("Codigo_Procedimiento", Type.GetType("System.String"))
        tablaResultados.Columns.Add("Descripcion", Type.GetType("System.String"))
        tablaResultados.Columns.Add("Area_servicio", Type.GetType("System.String"))
        tablaResultados.Columns.Add("Fecha", Type.GetType("System.String"))
        tablaResultados.Columns.Add("TipoExamen", Type.GetType("System.String"))
    End Sub
    Public Sub cargarResultados(ByVal punto As Integer,
                                ByVal cadenaFiltro As String,
                                ByVal fechaInicio As Date,
                                ByVal fechaFin As Date,
                                ByVal realizados As Boolean)
        Dim params As New List(Of String)
        params.Add(punto)
        params.Add(Format(fechaInicio, Constantes.FORMATO_FECHA_GEN))
        params.Add(Format(fechaFin, Constantes.FORMATO_FECHA_GEN))
        params.Add(cadenaFiltro)
        General.llenarTabla(If((realizados), Consultas.TABLERO_RESULTADO_REALIZADOS, Consultas.TABLERO_RESULTADO_PENDIENTES), params, tablaResultados)
    End Sub
End Class
