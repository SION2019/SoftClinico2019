Public Class CajaCompensacionBLL
    Dim objCajaCompensacionDAL As New CajaCompensacionDAL
    Public Function guardarCajaCompensacion(ByVal objCajaCompensacion As CajaCompensacion) As String
        If String.IsNullOrEmpty(objCajaCompensacion.codigo) Then
            Return objCajaCompensacionDAL.crearCajaCompensacion(objCajaCompensacion)
        Else
            objCajaCompensacionDAL.actualizarCajaCompensacion(objCajaCompensacion)
        End If
        Return objCajaCompensacion.codigo
    End Function

End Class
