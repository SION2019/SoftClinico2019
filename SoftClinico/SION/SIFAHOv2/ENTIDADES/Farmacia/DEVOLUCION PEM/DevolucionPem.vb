Public Class DevolucionPem
    Inherits Despacho
    Public Property codigoDevolucion As String
    Public Property codigoDevolucionPunto As String
    Public Property codigoDespacho As Integer
    Public Property codigoDespachoPunto As Integer
    Public Property codigoPem As Integer
    Public Property observacion As String
    Public Property fechaDevolucion As DateTime
    Public Property tablaMedicamentos As DataTable
    Public Property tablaInsumos As DataTable
    Sub New()
        tablaMedicamentos = New DataTable
        tablaInsumos = New DataTable
    End Sub
    Sub llenarDatosPem(ByVal pCodigoPem As Integer)
        codigoPem = pCodigoPem
        Dim params As New List(Of String)
        params.Add(codigoPem)
        params.Add(codigoDespacho)
        General.llenarTabla(Consultas.DEVOLUCION_LISTAR_PEMS_MEDICAMENTOS, params, tablaMedicamentos)
        params.Clear()
        params.Add(codigoPem)
        params.Add(codigoDespacho)
        General.llenarTabla(Consultas.DEVOLUCION_LISTAR_PEMS_INSUMOS, params, tablaInsumos)
    End Sub
    Public Sub cargarDevolcion()
        Dim params As New List(Of String)
        params.Add(codigoDevolucion)
        Try
            Dim fila As DataRow = General.cargarItem(Consultas.DEVOLUCION_CARGAR, params)
            codigoDevolucionPunto = fila.Item(0)
            codigoPem = fila.Item(1)
            codigoDespacho = fila.Item(2)
            codigoDespachoPunto = fila.Item(3)
            observacion = fila.Item(4)
            fechaDevolucion = fila.Item(5)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        params.Clear()
    End Sub
    Public Sub cargarDetalle()
        Dim params As New List(Of String)
        params.Add(codigoDevolucion)
        params.Add(codigoDespacho)
        params.Add(codigoPem)
        General.llenarTabla(Consultas.DEVOLUCION_CARGAR_MEDICAMENTOS, params, tablaMedicamentos, True)
        params.Clear()
        params.Add(codigoDevolucion)
        params.Add(codigoDespacho)
        params.Add(codigoPem)
        General.llenarTabla(Consultas.DEVOLUCION_CARGAR_INSUMOS, params, tablaInsumos, True)
    End Sub
    Public Function llenarInformacionPem() As DataRow
        Dim fila As DataRow
        Dim params As New List(Of String)
        params.Add(codigoPem)
        fila = General.cargarItem(Consultas.DEVOLUCION_INFORMACION_PEM, params)
        Return fila
    End Function
End Class
