Public Class EstanteBLL
    Public Shared Function guardarEstantes(objEstante As Estante)
        EstanteDAL.guardarEstante(objEstante)
        Return objEstante
    End Function
End Class
