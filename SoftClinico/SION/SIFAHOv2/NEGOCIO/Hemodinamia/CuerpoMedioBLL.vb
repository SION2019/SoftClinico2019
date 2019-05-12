Public Class CuerpoMedioBLL
    Public Shared Sub guardarTarifaMedica(objCuerpoMedico As CuerpoMedico)
        CuerpoMedicoDAL.guardarTarifaMedica(objCuerpoMedico)
    End Sub
    Public Shared Sub guardarCuerpoMedico(objCuerpoMedico As CuerpoMedico)
        CuerpoMedicoDAL.guardarCuerpoMedico(objCuerpoMedico)
    End Sub
End Class
