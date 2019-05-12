Public Class HoraDisponible
    Inherits HoraCita
    Public Sub New()
        altura = Constantes.ALTURA_HORA_DISPONIBLE
        anchura = Constantes.ANCHURA_HORA_DISPONIBLE
    End Sub
    Public Function crearPanelHoraDisponible(posicionPanelY As Integer, posicionLabelY As Integer) As Panel
        Return crearPanelHora(posicionPanelY, posicionLabelY)
    End Function
End Class
