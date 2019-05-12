Public Class Reporte
    Public Property tablaRespuesta As DataTable
    Enum tipoConsulta
        REPORTE_TRASLADO = 0
        REPORTE_ORDEN_COMPRA = 1
        REPORTE_RECEPCION_TECNICA = 2
        REPORTE_RECEPCION_TECNICA_TRASLADO = 3
    End Enum
    Sub New()
        tablaRespuesta = New DataTable
    End Sub
    Public Sub realizarConsulta(ByRef listaParametros As List(Of String), ByVal opcion As tipoConsulta)

        Dim consultaRealizada As String = ""
        Select Case opcion
            Case tipoConsulta.REPORTE_TRASLADO
                consultaRealizada = Consultas.REPORTE_INVENTARIO_TRASLADOS
            Case tipoConsulta.REPORTE_ORDEN_COMPRA
                consultaRealizada = Consultas.REPORTE_INVENTARIO_COMPRAS
            Case tipoConsulta.REPORTE_RECEPCION_TECNICA
                consultaRealizada = Consultas.REPORTE_INVENTARIO_RECEPCION_TECNICA
            Case tipoConsulta.REPORTE_RECEPCION_TECNICA_TRASLADO
                consultaRealizada = Consultas.REPORTE_INVENTARIO_RECEPCION_TECNICA_TRASLADO
        End Select
        tablaRespuesta.Columns.Clear()
        tablaRespuesta.Clear()
        General.llenarTabla(consultaRealizada, listaParametros, tablaRespuesta)
    End Sub
End Class
