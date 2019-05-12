Public Class HistorialEquipos
    Public Property codigo As Integer
    Public Property dtHistorial As DataTable
    Public Property dtActualizados As DataTable
    Public Property checkComputo As Boolean

    Public Property fecha As Date

    Public Property busqueda As String
    Public Sub cargarHistorialEquipo()
        If checkComputo = True Then
            Dim params As New List(Of String)
            params.Add(codigo)
            params.Add(SesionActual.codigoEP)
            General.llenarTabla(Consultas.EQUIPOS_COMPUTOR_CARGAR, params, dtHistorial)
        Else
            Dim params As New List(Of String)
            params.Add(codigo)
            params.Add(SesionActual.codigoEP)
            General.llenarTabla(Consultas.EQUIPOS_BIOMEDICOS_CARGAR, params, dtHistorial)
        End If
    End Sub

    Public Function obtenerDatosEquipo(codigo As Integer) As EquipoComputo

        Dim params As New List(Of String)
        params.Add(codigo)
        params.Add(SesionActual.codigoEP)
        Dim drEquipo As DataRow = General.cargarItem(Consultas.EQUIPOS_DATOS_EQUIPOS_COMPUTO, params)
        Dim objEquipoComputo = New EquipoComputo

        objEquipoComputo.nombre = drEquipo.Item("Nombre_equipo").ToString
        objEquipoComputo.marca = drEquipo.Item("marca").ToString
        objEquipoComputo.modelo = drEquipo.Item("modelo").ToString
        objEquipoComputo.area = drEquipo.Item("Ubicacion").ToString
        objEquipoComputo.discoDuro = drEquipo.Item("disco_duro").ToString
        objEquipoComputo.procesador = drEquipo.Item("procesador").ToString
        objEquipoComputo.ram = drEquipo.Item("Memoria_ram").ToString
        objEquipoComputo.board = drEquipo.Item("board").ToString
        objEquipoComputo.serial = drEquipo.Item("Serial_equipo").ToString


        Return objEquipoComputo

    End Function

    Public Sub cargarEquiposActualizadosoDesactualizados()
        dtActualizados = New DataTable
        Dim params As New List(Of String)
        params.Add(fecha)
        General.llenarTabla(Consultas.EQUIPOS_ACTUALIZADOS, params, dtActualizados)
    End Sub

    Public Function obtenerDatosBio(codigo As Integer) As EquiposBiomedicos
        Dim params As New List(Of String)
        params.Add(codigo)
        params.Add(SesionActual.codigoEP)
        Dim drEquipo As DataRow = General.cargarItem(Consultas.EQUIPOS_BIOMEDICOS_INFORMACION, params)
        Dim objEquipoBio As New EquiposBiomedicos
        objEquipoBio.nombre = drEquipo.Item("Equipo")
        objEquipoBio.marca = drEquipo.Item("marca")
        objEquipoBio.modelo = drEquipo.Item("modelo")
        objEquipoBio.area = drEquipo.Item("ubicacion")
        Return objEquipoBio
    End Function
    Sub New()
        dtHistorial = New DataTable
        dtHistorial.Columns.Add("Fecha", Type.GetType("System.DateTime"))
        dtHistorial.Columns.Add("Preventivo", Type.GetType("System.String"))
        dtHistorial.Columns.Add("Correctivo", Type.GetType("System.String"))
        dtHistorial.Columns.Add("Falla reportada", Type.GetType("System.String"))
        dtHistorial.Columns.Add("Trabajo realizado", Type.GetType("System.String"))
        dtHistorial.Columns.Add("observacion", Type.GetType("System.String"))
    End Sub
End Class
