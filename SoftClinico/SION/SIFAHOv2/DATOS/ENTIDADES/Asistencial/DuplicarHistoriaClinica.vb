Public Class DuplicarHistoriaClinica
    Property idGenero As Integer
    Property idArea As Integer
    Property sqlCargarFactura As String
    Property sqlDuplicar As String
    Property sqlBuscarAdmision As String
    Property sqlCargarAdmision As String
    Property dtFactura As DataTable
    Property RegistroOrigen As Integer
    Property RegistroDestino As Integer
    Property bdraIdentificaDestino As Boolean
    Public Sub New()
        dtFactura = New DataTable
        sqlCargarAdmision = "[SP_ADMISION_DUPLICAR_CARGAR]"
        sqlBuscarAdmision = "[SP_ADMISION_DUPLICAR_BUSCAR]"
        sqlDuplicar = "SP_DUPLICA_HC"
        sqlCargarFactura = "[SP_FACTURA_DUPLICAR_CARGAR]"
    End Sub
End Class
