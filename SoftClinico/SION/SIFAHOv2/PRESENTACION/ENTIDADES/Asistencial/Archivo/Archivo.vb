Public Class Archivo
    Inherits ArchivoHC
    Public Property objBloque As Bloque
    Public Property objEstante As Estante
    Public Property objFila As Fila
    Public Property sqlCargarFactura As String
    Public Sub New()
        sqlGuardar = Consultas.GUARDAR_ARCHIVO
        sqlBusqueda = Consultas.BUSCAR_ARCHIVO
        sqlCargar = Consultas.CARGAR_ARCHIVO
        sqlCargarFactura = Consultas.CARGAR_FACTURA

        objEstante = New Estante
        objBloque = New Bloque
        objFila = New Fila
    End Sub
End Class
