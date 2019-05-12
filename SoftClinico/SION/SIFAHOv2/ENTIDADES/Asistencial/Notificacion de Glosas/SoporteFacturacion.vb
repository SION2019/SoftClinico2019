Public Class SoporteFacturacion
    Public Property dtFacturacion As DataTable
    Public Property idEps As Integer
    Public Property idCarpetaActual As String
    Public Property dtConfigurado As DataTable
    Public Property dtConfiguradoCopia As DataTable
    Public Property bdPendiente As New BindingSource
    Public Property bdConfigurado As New BindingSource
    Public Property accion As Integer
    Public Sub cargarSoporte()
        If dtConfigurado.Rows.Count = 0 Then
            Dim dtTemporal As New DataTable
            dtTemporal = dtConfigurado.Copy
            Dim params As New List(Of String)
            params.Add(idEps)
            General.llenarTabla(Consultas.SOPORTE_CONFIGURACION_FACTURA_CARGAR, params, dtConfigurado)
        End If
        copiarSoportes()
    End Sub

    Public Sub cargarCarpetas()
        Dim params As New List(Of String)
        params.Add(idEps)
        General.llenarTabla(Consultas.SOPORTE_CARPETAS_CARGAR, params, dtFacturacion)
    End Sub

    Public Sub guardar()
        SoporteConsolidadoDAL.guadarConfiguracion(Me)
    End Sub
    Sub New()
        dtFacturacion = New DataTable
        dtFacturacion.Columns.Add("Id Carpeta", Type.GetType("System.String"))
        dtFacturacion.Columns.Add("Carpeta", Type.GetType("System.String"))


        dtConfigurado = New DataTable
        dtConfigurado.Columns.Add("Id Carpeta", Type.GetType("System.String"))
        dtConfigurado.Columns.Add("Codigo parametro", Type.GetType("System.String"))
        dtConfigurado.Columns.Add("Descripción", Type.GetType("System.String"))
        bdPendiente.DataSource = dtConfigurado

        dtConfiguradoCopia = New DataTable
        dtConfiguradoCopia.Columns.Add("Id Carpeta", Type.GetType("System.String"))
        dtConfiguradoCopia.Columns.Add("Codigo parametro", Type.GetType("System.String"))
        dtConfiguradoCopia.Columns.Add("Descripción", Type.GetType("System.String"))
    End Sub

    Public Sub moverSoporte(vOpcion As Integer, idSoporte As String)
        Dim dw_soporte As DataRow() = dtConfigurado.Select("[Codigo parametro]='" & idSoporte & "'", "")
        If dw_soporte.Count = 0 Then Exit Sub
        Dim fila As DataRow = dw_soporte(0)
        Dim indiceFila As Integer = dtConfigurado.Rows.IndexOf(fila)
        If vOpcion = 1 Then
            dtConfigurado.Rows(indiceFila).Item("Id Carpeta") = idCarpetaActual
        Else
            dtConfigurado.Rows(indiceFila).Item("Id Carpeta") = "-1"
        End If
        copiarSoportes()
    End Sub
    Private Sub copiarSoportes()
        dtConfiguradoCopia = dtConfigurado.Copy
        bdConfigurado.DataSource = dtConfiguradoCopia
    End Sub

End Class
