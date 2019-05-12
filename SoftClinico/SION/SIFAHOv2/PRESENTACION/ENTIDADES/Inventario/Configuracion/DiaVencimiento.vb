Public Class DiaVencimiento

    Public Property codigo As String
    Public Property nombre As String

    Public Sub guardarVencimiento()
        VencimientoDAL.GuardarAactualizar(Me)
    End Sub
End Class
