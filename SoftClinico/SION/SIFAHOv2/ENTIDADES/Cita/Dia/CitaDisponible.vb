Public Class CitaDisponible
    Inherits CitaPrevia
    Private posicionLabelX As Integer
    Private posicionLabelY As Integer
    Private posicionPanelX As Integer
    Public Sub New()
        altura = Constantes.ALTURA_CITA_DISPONIBLE
        anchura = Constantes.ANCHURA_CITA_DISPONIBLE
        posicionPanelX = 120 '------- posicion x en el panel
        descripcion = Constantes.CITA_DISPONIBLE
        posicionLabelX = 560
        posicionLabelY = 9
    End Sub
    Public Function crearPanelDisponible(posicionPanelY As Integer) As Panel
        Dim panel As New Panel
        panel.Location = New Point(posicionPanelX, posicionPanelY)
        panel.Size = New Point(anchura, altura)
        panel.BackColor = color
        panel.BorderStyle = BorderStyle.FixedSingle
        panel.Controls.Add(crearEtiquetaDisponible())
        panel.Cursor = Cursors.Hand
        panel.Tag = hora
        panel.Show()
        Return panel
    End Function
    Public Function crearEtiquetaDisponible() As Label
        Dim etiqueta As New Label
        etiqueta.Location = New Point(posicionLabelX, posicionLabelY)
        etiqueta.Size = New Point(56, 13)
        etiqueta.Text = descripcion
        Return etiqueta
    End Function
End Class
