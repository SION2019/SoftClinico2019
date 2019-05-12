Public Class TarifaServicioBLL
    Dim objTarifaServicioDAL As New TarifaServicioDAL
    Public Function guardarTarifa(ByVal objTarifaServicio As TarifaDeServicios) As String

        If String.IsNullOrEmpty(objTarifaServicio.codigoHa) Then
            Return objTarifaServicioDAL.guardarTarifa(objTarifaServicio)
        Else
            objTarifaServicioDAL.actualizarTarifa(objTarifaServicio)
        End If

        Return objTarifaServicio.codigoHa
    End Function

End Class
