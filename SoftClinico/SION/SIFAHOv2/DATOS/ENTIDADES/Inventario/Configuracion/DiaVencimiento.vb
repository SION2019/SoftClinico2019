Public Class DiaVencimiento

    Public Property codigo As String
    Public Property nombre As Integer

    Public Sub guardarVencimiento()
        VencimientoDAL.GuardarAactualizar(Me)
    End Sub
End Class
