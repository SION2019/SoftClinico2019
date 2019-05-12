Public Class ListaComite

    Public Property codigo As Integer
    Public Property nombre As String


    Public Function getComiteNombre()
        Return codigo & " | " & nombre
    End Function


End Class
