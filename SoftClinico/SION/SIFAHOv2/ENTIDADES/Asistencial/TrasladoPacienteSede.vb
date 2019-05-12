Public Class TrasladoPacienteSede
    Property Registro As Integer
    Property idEPS As Integer
    Property idArea As Integer
    Property idPunto As Integer
    Property idCama As Integer
    Property idContrato As Integer
    Property idSede As Integer
    Property sqlTraslado As String
    Property sqlBuscarAdmision As String
    Property sqlBuscarAdmisionTodos As String
    Property sqlCargarAdmision As String
    Property respuesta As String
    Property registroDestino As String
    Public Sub New()
        sqlCargarAdmision = "[PROC_ADMISION_DUPLICAR_CARGAR]"
        sqlBuscarAdmision = "[PROC_ADMISION_TRASLADAR_BUSCAR]"
        sqlBuscarAdmisionTodos = "[PROC_TODO_ADMISION_TRASLADAR_BUSCAR]"
        sqlTraslado = "PROC_TRASLADA_HISTORIA_CLINICA"
    End Sub
End Class
