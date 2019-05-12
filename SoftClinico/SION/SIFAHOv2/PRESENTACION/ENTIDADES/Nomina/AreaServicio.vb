Public Class AreaServicio

    Public Property codigo As Integer
    Public Property descripcion As String

    Public Function getAreaDescripcion()
        Return codigo & " | " & descripcion
    End Function


End Class
