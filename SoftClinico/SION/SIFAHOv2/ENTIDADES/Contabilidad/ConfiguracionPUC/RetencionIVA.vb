Public Class RetencionIVA
    Public Property codigoPUC As String
    Public Property codigoCuenta As String
    Public Property base As Double
    Public Property tasa As Double
    Public Property observacion As String

    Public Sub New()

    End Sub
    Public Sub New(drRetencionIVA As DataRow)
        codigoPUC = drRetencionIVA.Item("codigo_puc").ToString
        codigoCuenta = drRetencionIVA.Item("cuenta").ToString
        base = drRetencionIVA.Item("base").ToString
        tasa = drRetencionIVA.Item("tasa").ToString
        observacion = drRetencionIVA.Item("observacion").ToString
    End Sub

End Class
