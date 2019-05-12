Public Class PuntoServicio

    Property codigo As String
    Property observaciones As String
    Property direccion As String
    Property nombre As String
    Property telefono As String
    Property correspondencia As String
    Property Combopais As String
    Property Combodepartamento As String
    Property Combociudad As String
    Property id_responsable As String
    Property asignar As Boolean
    Property activo As Boolean


    Public Function getPuntoNombre() As String
        Return codigo & " | " & nombre
    End Function

End Class
