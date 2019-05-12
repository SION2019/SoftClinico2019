Public Class RetiroDocumento
    Public Property dtDocumento As DataTable
    Public Property fecha As Date
    Public Property fecha2 As Date
    Public Property observacion As String
    Public Property usuario As Integer
    Public Property comprobante As String
    Public Property busqueda As String
    Public Property anulado As Boolean
    Public Sub cargarDatos()
        Dim params As New List(Of String)
        params.Add(fecha)
        params.Add(fecha2)
        params.Add(SesionActual.idEmpresa)
        params.Add(anulado)
        params.Add(busqueda)
        General.llenarTabla(Consultas.RETIRO_DOCUMENTO, params, dtDocumento)
    End Sub


    Public Sub guardarRegistro()
        RetiroDocumentoContaDAL.guardarDocumento(Me)
    End Sub
    Sub New()
        dtDocumento = New DataTable

        dtDocumento.Columns.Add("Fecha comprobante", Type.GetType("System.DateTime"))
        dtDocumento.Columns.Add("Comprobante", Type.GetType("System.String"))
        dtDocumento.Columns.Add("Detalle", Type.GetType("System.String"))
        dtDocumento.Columns.Add("Nit tercero", Type.GetType("System.String"))
        dtDocumento.Columns.Add("Tercero", Type.GetType("System.String"))
        dtDocumento.Columns.Add("Débito", Type.GetType("System.String"))
        dtDocumento.Columns.Add("Crédito", Type.GetType("System.String"))
    End Sub
End Class
