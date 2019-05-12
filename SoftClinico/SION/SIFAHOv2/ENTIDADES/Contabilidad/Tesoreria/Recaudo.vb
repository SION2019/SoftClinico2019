Public Class Recaudo
    Public Property comprobante As String
    Public Property Movimiento As String
    Public Property usuario As Integer
    Public Property codigoep As Integer
    Public Property fechaDocum As DateTime
    Public Property codigoTercero As Integer
    Public Property observacion As String
    Public Property valorDebito As Double
    Public Property valorCredito As Double
    Public Property valorSubTotal As Double
    Public Property dtDetalle As DataTable
    Public Property codigoPuc As Integer
    Public Property codigoDocumento As Integer
    Public Property sqlGuardarRecaudo As String
    Public Property sqlCargarRecaudo As String
    Public Property sqlCargarDetalleRecaudo As String
    Public Property sqlBuscarRecaudo As String
    Public Property verificarExistencia As Boolean
    Public Sub New()
        dtDetalle = New DataTable
        dtDetalle.Columns.Add("Orden", Type.GetType("System.Int32"))
        dtDetalle.Columns.Add("Codigo_factura", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Codigo_cuenta", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Debito", Type.GetType("System.Double")).DefaultValue = 0
        dtDetalle.Columns.Add("Credito", Type.GetType("System.Double")).DefaultValue = 0
        sqlBuscarRecaudo = Consultas.RECAUDO_BUSCAR
        sqlGuardarRecaudo = Consultas.RECAUDO_GUARDAR
        sqlCargarRecaudo = Consultas.RECAUDO_CARGAR
        sqlCargarDetalleRecaudo = Consultas.RECAUDO_CARGAR_D
    End Sub

End Class
