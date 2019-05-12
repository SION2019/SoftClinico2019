Public Class CasoProblemaBLL
    Public Shared Function guardarCasoProblema(objCasoProblema As CasoProblema) As CasoProblema
        CasoProblemaDAL.guardarCasoProblema(objCasoProblema)
        Return objCasoProblema
    End Function
End Class
