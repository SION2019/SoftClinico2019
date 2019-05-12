Public Class ConfiguracionPorProceso
    Public Property tablaProcesos As New DataTable
    Public Property tblopciones As New DataSet
    Sub New()
        tablaProcesos = New DataTable
        tblopciones = New DataSet
    End Sub
    Sub cargarProcesos()
        Dim params As New List(Of String)
        General.llenarTabla(Consultas.CONFIGURACION_PROCESOS_CARGO_LISTAR,
                            params,
                            tablaProcesos,
                            True)

    End Sub
    Public Function nombrarTabla(ByVal codigo As String) As String
        Return "Tabla" & codigo
    End Function
    Public Function existeTabla(ByVal nombre As String) As Boolean
        Return tblopciones.Tables.Contains(nombre)
    End Function
    Public Sub agregarTabla(ByVal nombre As String)
        If Not existeTabla(nombre) Then
            tblopciones.Tables.Add(nombre)
            agregarColumnas(nombre)
        End If
    End Sub
    Public Sub agregarColumnas(ByVal nombre As String)
        If tblopciones.Tables(nombre).Columns.Count = 0 Then
            tblopciones.Tables(nombre).Columns.Add("Código", Type.GetType("System.String"))
            tblopciones.Tables(nombre).Columns.Add("Descripción", Type.GetType("System.String"))
            tblopciones.Tables(nombre).Columns.Add("Clasificar", Type.GetType("System.Boolean"))
        End If
    End Sub
    Public Sub cargarCargos(ByVal codigo As Integer, ByVal nombre As String)
        Dim params As New List(Of String)
        params.Add(codigo)
        General.llenarTabla(Consultas.CONFIGURACION_PROCESOS_CARGO_LISTAR_D, params, tblopciones.Tables(nombre))
    End Sub
End Class
