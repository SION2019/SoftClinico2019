Public Class CitaPrevia
    Property altura As Integer
    Property anchura As Integer
    Property descripcion As String
    Property color As Color
    Property estado As String
    Property hora As String
    Public Function colorLabel() As Color
        Select Case estado
            Case "P"
                color = Color.FromArgb(192, 192, 255)
            Case "C"
                color = Color.FromArgb(255, 192, 192)
            Case "R"
                color = Color.FromArgb(192, 255, 192)
        End Select
        Return color
    End Function
End Class
