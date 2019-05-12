Public Class HistorialBuzon

    Public Property dtHistorial As DataTable

    Public Sub cargarHistorial()

        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        params.Add(SesionActual.idUsuario)
        General.llenarTabla(Consultas.BUZON_HISTORIAL, params, dtHistorial)
    End Sub

    Public Sub guardarRespuesta()
        BuzonDAL.guardarBuzonRespuesta(Me)
    End Sub

    Public Sub cargarHistorialRealizado()

        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        params.Add(SesionActual.idUsuario)
        General.llenarTabla(Consultas.BUZON_HISTORIAL_REALIZADO, params, dtHistorial)
    End Sub

    Sub New()
        dtHistorial = New DataTable
        dtHistorial.Columns.Add("Código", Type.GetType("System.String"))
        dtHistorial.Columns.Add("Empleado", Type.GetType("System.String"))
        dtHistorial.Columns.Add("Cargo", Type.GetType("System.String"))
        dtHistorial.Columns.Add("Fecha", Type.GetType("System.DateTime"))
        dtHistorial.Columns.Add("Mensaje recibido", Type.GetType("System.String"))
        dtHistorial.Columns.Add("Respuesta", Type.GetType("System.String"))
        dtHistorial.Columns.Add("Fecha respuesta", Type.GetType("System.DateTime"))
        dtHistorial.Columns("Fecha respuesta").DefaultValue = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
    End Sub

End Class
