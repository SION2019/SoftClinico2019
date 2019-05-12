Public Class Bloque
    Inherits ArchivoHC
    Public Property Bloque As String
    Public Sub New()
        sqlGuardar = Consultas.GUARDAR_BLOQUE
        sqlBusqueda = Consultas.BUSCAR_BLOQUE
        sqlCargar = Consultas.CARGAR_BLOQUE
    End Sub
End Class
