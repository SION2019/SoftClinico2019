Public Class ConfiguracionConceptosDianBLL
    Dim objConceptoDianDAL As New ConfiguracionConceptosDianDAL
    Public Sub guardarConcepto(ByVal objConceptoDian As ConfiguracionConceptosDian)
        Me.objConceptoDianDAL.crearConfiguracion(objConceptoDian)
    End Sub
End Class
