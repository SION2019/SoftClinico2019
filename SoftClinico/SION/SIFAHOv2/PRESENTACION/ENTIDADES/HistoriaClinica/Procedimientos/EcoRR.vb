Public Class EcoRR
    Inherits Eco
    Public Sub New()
        sqlBuscarPaciente = Consultas.BUSQUEDA_BUSCAR_PACIENTE_ECOCARDIOGRAMARR
        sqlCargarPaciente = Consultas.CARGAR_PACIENTE_ECOCARDIOGRAMARR
        sqlBuscarRegistro = Consultas.BUSQUEDA_BUSCAR_ECOCARDIOGRAMARR
        sqlCargarRegistro = Consultas.CARGAR_ECOCARDIOGRAMARR
    End Sub
    Public Overrides Sub guardarRegistro()
        If String.IsNullOrEmpty(codigo) Then
            codigo = -1
        Else
            editado = 1
        End If
        EcocardiogramaBLL.guardarEcocardiograma(Me)
    End Sub
End Class
