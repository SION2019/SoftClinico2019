Public Class BloqueBLL
    Public Shared Function guardarBloque(objBloque As Bloque)
        BloqueDAL.guardarBloque(objBloque)
        Return objBloque
    End Function
End Class
