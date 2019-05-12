Public Class HoraCita
    Property altura As Integer
    Property anchura As Integer
    Property hora As String
    Property color As Color
    Property posicionPanelX As Integer
    Private posicionLabelX As Integer
    Public Sub New()
        posicionPanelX = Constantes.HORA_POCISION_PANEL_X
        posicionLabelX = Constantes.HORA_POCISION_LABEL_X
    End Sub
    Public Function crearPanelHora(posicionPanelY As Integer, posicionLabelY As Integer) As Panel
        Dim panel As New Panel
        panel.Location = New Point(posicionPanelX, posicionPanelY)
        panel.Size = New Point(anchura, altura)
        panel.BackColor = color
        panel.BorderStyle = BorderStyle.FixedSingle
        panel.Controls.Add(crearEtiquetaHora(posicionLabelY))
        panel.Show()
        Return panel
    End Function
    Public Function crearEtiquetaHora(posicionLabelY As Integer) As Label
        Dim etiqueta As New Label
        etiqueta.Location = New Point(posicionLabelX, posicionLabelY)
        etiqueta.Size = New Point(34, 13)
        etiqueta.Text = hora
        Return etiqueta
    End Function

End Class
