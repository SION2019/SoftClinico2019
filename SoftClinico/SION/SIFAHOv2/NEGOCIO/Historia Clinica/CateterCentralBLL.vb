Public Class CateterCentralBLL
    Dim objCateterC As New CateterCentralDAL
    Public Function crearCateter(ByVal objCateter As CateterCentral)
        If String.IsNullOrEmpty(objCateter.Codigo) Then
            Return objCateterC.crearCateter(objCateter)
        Else
            objCateterC.actualizarCateter(objCateter)
        End If
        Return objCateter
    End Function
End Class
