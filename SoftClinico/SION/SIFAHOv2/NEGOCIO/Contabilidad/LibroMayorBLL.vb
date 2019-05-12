Public Class LibroMayorBLL

    Public Sub calcularlibroMayor(params As LibroMayorParams)
        Dim libroDAL As New LibroMayorDAL

        libroDAL.calcularLibroMayor(params)
    End Sub
End Class
