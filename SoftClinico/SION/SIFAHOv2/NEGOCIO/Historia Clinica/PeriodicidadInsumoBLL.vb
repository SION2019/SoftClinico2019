Public Class PeriodicidadInsumoBLL
    Dim objPerInsumosDAL As New InsumoPeriodicidadDAL
    Public Sub guardarInsumos(objPerInsumos As PeriodicInsumos)
        InsumoPeriodicidadDAL.guardarInsumos(objPerInsumos)
    End Sub
End Class
