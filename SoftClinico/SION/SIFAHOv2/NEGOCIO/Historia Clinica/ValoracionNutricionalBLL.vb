Public Class ValoracionNutricionalBLL
    Dim objValoracion_C As New ValoracionNutricionalDAL

    Public Function crearValoracionN(objValoracion As ValoracionNutricional)
        If String.IsNullOrEmpty(objValoracion.CodigoValoracion) Then
            Return objValoracion_C.crearValoracion(objValoracion)
        Else
            Return objValoracion_C.actualizarValoracion(objValoracion)
        End If
        Return objValoracion
    End Function
End Class
