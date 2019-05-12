Public Class AreaServicio

    Public Property codigo As Integer
    Public Property descripcion As String

    Public ReadOnly Property areaDescripcion As String
        Get
            Return codigo & " | " & descripcion
        End Get
    End Property



End Class
