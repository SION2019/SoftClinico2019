Public Class AntibioticoJustificacionBLL

    Public Shared Sub guardarAntibiotico(objAntibiotico As JustificacionMedicamento)
        If String.IsNullOrEmpty(objAntibiotico.codigo) Then
            objAntibiotico.codigo = Constantes.VALOR_PREDETERMINADO
            AntibioticoJustificacionDAL.guardarAntibiotico(objAntibiotico)
        Else
            AntibioticoJustificacionDAL.actualizarAntibiotico(objAntibiotico)
        End If
    End Sub
End Class
