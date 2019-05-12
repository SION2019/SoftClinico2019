Public Class LibroDiarioBLL

    Public Sub calcularLibroDiario(params As LibroDiarioParams)
        Dim libroDAL As New LibroDiarioDAL

        libroDAL.calcularLibroDiario(params)
    End Sub

End Class
