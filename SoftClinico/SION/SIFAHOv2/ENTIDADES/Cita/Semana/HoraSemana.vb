Public Class HoraSemana
    Inherits CitaPrevia
    Property hora As String
    Public Sub New()
        altura = 78
        anchura = 70
    End Sub
    Public Function crearPanelHora(posicionPanelY As Integer) As Panel
        Dim panel As New Panel
        panel.Location = New Point(0, posicionPanelY)
        panel.Size = New Point(anchura, altura)
        panel.BackColor = color
        panel.BorderStyle = BorderStyle.FixedSingle
        panel.Controls.Add(crearEtiquetaSemHora())
        panel.Show()
        Return panel
    End Function
    Private Function crearEtiquetaSemHora() As Label
        Dim etiqueta As New Label
        etiqueta.Location = New Point(16, 32)
        etiqueta.Size = New Point(38, 15)
        etiqueta.Text = hora
        Return etiqueta
    End Function
End Class
