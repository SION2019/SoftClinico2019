Public Class Bitacora

    Public Property dtBitacora As DataTable
    Public Property opcionComputo As Boolean
    Public Property opcionBiomedico As Boolean
    Public Property codigoEp As Integer
    Public Property usuario As Integer
    Public Property fecha As Date
    Public Property textBusqueda As String
    Sub New()
        dtBitacora = New DataTable
        dtBitacora.Columns.Add("Código", Type.GetType("System.String"))
        dtBitacora.Columns.Add("Equipo", Type.GetType("System.String"))
        dtBitacora.Columns.Add("Marca", Type.GetType("System.String"))
        dtBitacora.Columns.Add("Modelo", Type.GetType("System.String"))
        dtBitacora.Columns.Add("Ubicacion", Type.GetType("System.String"))
        dtBitacora.Columns.Add("Preventivo", Type.GetType("System.Boolean"))
        dtBitacora.Columns.Add("Correctivo", Type.GetType("System.Boolean"))
        dtBitacora.Columns.Add("Falla reportada", Type.GetType("System.String"))
        dtBitacora.Columns.Add("Trabajo realizado", Type.GetType("System.String"))
        dtBitacora.Columns.Add("observacion", Type.GetType("System.String"))


    End Sub

    Public Sub guardar()
        BitacoraDAL.guardarBitacora(Me)
    End Sub

    Public Sub guardarBiomedico()
        BitacoraDAL.guardarBitacoraBiomedico(Me)
    End Sub

    Public Sub cargarEquipos()
        If opcionComputo = True Then
            Dim params As New List(Of String)
            params.Add(textBusqueda)
            params.Add(codigoEp)
            params.Add(fecha)
            General.llenarTabla(Consultas.EQUIPOS_COMPUTOR_BUSCAR, params, dtBitacora)
        ElseIf opcionBiomedico = True Then
            Dim params As New List(Of String)
            params.Add(textBusqueda)
            params.Add(fecha)
            General.llenarTabla(Consultas.EQUIPOS_BIOMEDICOS_BUSCAR, params, dtBitacora)
        End If
    End Sub



End Class
