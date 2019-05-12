Public Class SeguimientoFacturacion
    Public Property modulo As String
    Public Property dtFacturacion As DataTable

    Public Sub cargarPacienteFactura()
        Dim respuestas As String = Nothing
        If modulo = Constantes.HC Then
            respuestas = Consultas.SEGUIMIENTO_FACTURACION
        ElseIf modulo = Constantes.AM Then
            respuestas = Consultas.SEGUIMIENTO_FACTURACION_R
        ElseIf modulo = Constantes.AF Then
            respuestas = Consultas.SEGUIMIENTO_FACTURACION_RR
        End If

        General.llenarTabla(respuestas, Nothing, dtFacturacion)
    End Sub

    Sub New()
        dtFacturacion = New DataTable
        dtFacturacion.Columns.Add("No", Type.GetType("System.String"))
        dtFacturacion.Columns.Add("Paciente", Type.GetType("System.String"))
        dtFacturacion.Columns.Add("Identificación", Type.GetType("System.String"))
        dtFacturacion.Columns.Add("Tipo Documento", Type.GetType("System.String"))
        dtFacturacion.Columns.Add("Area", Type.GetType("System.String"))
        dtFacturacion.Columns.Add("EPS", Type.GetType("System.String"))
        dtFacturacion.Columns.Add("Factura", Type.GetType("System.String"))
        dtFacturacion.Columns.Add("Valor", Type.GetType("System.Double"))
        dtFacturacion.Columns.Add("Fecha Factura", Type.GetType("System.DateTime"))
        dtFacturacion.Columns.Add("Fecha Ingreso", Type.GetType("System.DateTime"))
        dtFacturacion.Columns.Add("Fecha Egreso", Type.GetType("System.DateTime"))
        dtFacturacion.Columns.Add("Fecha Visado", Type.GetType("System.DateTime"))
        dtFacturacion.Columns.Add("Fecha Radicación", Type.GetType("System.DateTime"))
        dtFacturacion.Columns.Add("Dias Radicación", Type.GetType("System.String"))
        dtFacturacion.Columns.Add("Dias Visado", Type.GetType("System.String"))
        dtFacturacion.Columns.Add("Dias Facturado", Type.GetType("System.String"))
        dtFacturacion.Columns.Add("Estancias", Type.GetType("System.String"))
        dtFacturacion.Columns.Add("Total", Type.GetType("System.String"))
        dtFacturacion.Columns.Add("Atención", Type.GetType("System.String"))
    End Sub
End Class
