Public Class Estante
    Inherits ArchivoHC
    Public Property estante As String
    Public Sub New()
        sqlGuardar = Consultas.GUARDAR_ESTANTE
        sqlBusqueda = Consultas.BUSCAR_ESTANTE
        sqlCargar = Consultas.CARGAR_ESTANTE
    End Sub

End Class
