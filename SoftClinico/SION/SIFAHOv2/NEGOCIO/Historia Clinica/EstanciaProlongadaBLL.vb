Public Class EstanciaProlongadaBLL
    Public Shared Sub crearEstancias(objEstancia As EstanciaProlongada)
        EstanciaProlongadaDAL.crearEstancia(objEstancia)
    End Sub
    Public Shared Sub crearEstanciasR(objEstancia As EstanciaProlongadaR)
        EstanciaProlongadaDAL.crearEstanciaR(objEstancia)
    End Sub
    Public Shared Sub crearEstanciasRR(objEstancia As EstanciaProlongadaRR)
        EstanciaProlongadaDAL.crearEstanciaRR(objEstancia)
    End Sub

End Class
