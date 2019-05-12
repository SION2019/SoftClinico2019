Public Class ConfiguracionCentroDeCostosBLL
    Dim objCentroCostoDAL As New ConfiguracionCentroDeCostosDAL
    Public Sub guardar(ByVal objCosto As ConfiguracionCentroDeCostos)
        Me.objCentroCostoDAL.crearConfiguracion(objCosto)
    End Sub
End Class
