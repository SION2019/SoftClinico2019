Public Class LiquidacionContratoBLL
    Dim objLiquidacionContrato As New LiquidacionContratoDAL
    Public Sub guardarLiquidacionContrato(ByVal objLiquidacion As LiquidacionContrato)
        objLiquidacionContrato.crearLiquidacionContrato(objLiquidacion)
    End Sub


End Class
