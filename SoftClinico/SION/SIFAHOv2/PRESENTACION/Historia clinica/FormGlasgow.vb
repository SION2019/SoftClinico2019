Public Class FormGlasgow
    Dim vGlasgow As Glasgow
    Dim vDgv As DataGridView
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim acumulado As Integer
        acumulado = GeneralHC.calcularGlasgow(gbReaccion)
        acumulado = acumulado + GeneralHC.calcularGlasgow(gbRverbal)
        acumulado = acumulado + GeneralHC.calcularGlasgow(gbRmotora)
        vGlasgow.sumaTotal = acumulado
        Close()
    End Sub
    Public Sub iniciarForm(ByRef pGlasgow As Glasgow)
        vGlasgow = pGlasgow
    End Sub

End Class