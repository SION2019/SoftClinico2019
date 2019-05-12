Public Class EstudioLaboratorio
    Inherits EstudioImagenologia

    Sub New()
        sqlConsulta = Consultas.EXAMEN_LABORATORIO_CARGAR
        moduloReporte = 4
    End Sub
End Class
