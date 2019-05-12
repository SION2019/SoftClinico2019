Public Class FilaBLL
    Public Shared Function guardarFila(objFila As Fila)
        FilaDAL.guardarFila(objFila)
        Return objFila
    End Function
End Class
