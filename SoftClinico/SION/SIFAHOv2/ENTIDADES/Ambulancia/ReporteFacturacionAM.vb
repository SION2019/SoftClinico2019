Public Class ReporteFacturacionAM
    Public Property usuario As Integer
    Public Property codigo As Integer
    Public Property idTerceron As Integer
    Public Property diaInicial As DateTime
    Public Property diaFinal As DateTime
    Public Property cantidad As Integer
    Public Property valorTotal As Double
    Public Property codTrasladoPaciente As Integer
    Public Property dtTablaTraslado As DataTable
    Public Property dtTablaDetalle As DataTable
    Public Property dtTablaPIEDetalle As DataTable
    Public Property dtTablaConsolidado As DataTable
    Public Property sqlBuscarReporteInfAM As String
    Public Sub New()
        dtTablaTraslado = New DataTable
        dtTablaDetalle = New DataTable
        dtTablaPIEDetalle = New DataTable
        dtTablaConsolidado = New DataTable
        sqlBuscarReporteInfAM = ConsultasAmbu.REPORTE_INF_AM_BUSCAR
    End Sub
End Class
