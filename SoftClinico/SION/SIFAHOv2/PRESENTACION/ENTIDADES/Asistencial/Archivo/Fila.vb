Public Class Fila
    Inherits ArchivoHC
    Public Property fila As String
    Public Sub New()
        sqlGuardar = Consultas.GUARDAR_FILA
        sqlBusqueda = Consultas.BUSCAR_FILA
        sqlCargar = Consultas.CARGAR_FILA
    End Sub
End Class
