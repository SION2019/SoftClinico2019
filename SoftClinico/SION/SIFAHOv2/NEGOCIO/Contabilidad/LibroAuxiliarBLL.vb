Public Class LibroAuxiliarBLL


    Public Shared Sub calcularLibroAuxiliar(params As LibroAuxiliarParams)
        LibroAuxiliarDAL.calcularLibroAuxiliar(params)
    End Sub

    Public Shared Function obtenerTerceroByNit(ByVal nit As String) As Integer
        Return TerceroDAL.getIdTercero(nit)
    End Function


End Class
