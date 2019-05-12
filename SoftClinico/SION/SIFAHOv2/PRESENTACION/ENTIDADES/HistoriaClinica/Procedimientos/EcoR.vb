Public Class EcoR
    Inherits Eco
    Public Sub New()
        sqlBuscarPaciente = Consultas.BUSQUEDA_BUSCAR_PACIENTE_ECOCARDIOGRAMAR
        sqlCargarPaciente = Consultas.CARGAR_PACIENTE_ECOCARDIOGRAMAR
        sqlBuscarRegistro = Consultas.BUSQUEDA_BUSCAR_ECOCARDIOGRAMAR
        sqlCargarRegistro = Consultas.CARGAR_ECOCARDIOGRAMAR
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
