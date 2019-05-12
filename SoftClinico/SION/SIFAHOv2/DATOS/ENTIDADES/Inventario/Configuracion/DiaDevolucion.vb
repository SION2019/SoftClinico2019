Public Class DiaDevolucion

    Public Property codigo As String
    Public Property nombre As String

    Public Sub guararDevolucuion()
        DevolucionDAL.GuardarAactualizar(Me)
    End Sub
End Class
