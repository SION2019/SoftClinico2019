Public Class HoraTomada
    Inherits HoraCita
    Public Sub New()
        altura = Constantes.ALTURA_HORA_TOMADA
        anchura = Constantes.ANCHURA_HORA_TOMADA
    End Sub
    Public Function crearPanelHoraTomada(posicionPanelY As Integer, posicionLabelY As Integer) As Panel
        Return crearPanelHora(posicionPanelY, posicionLabelY)
    End Function
End Class
