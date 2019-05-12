Public Class OtroSiBLL
    Dim cmd As New OtroSiDAL
    Public Function Guardarotrosi(ByRef pOtroSi As OtroSi) As Boolean
        Dim respuesta As String = ""


        respuesta = cmd.Guardarotrosi(pOtroSi)

        If respuesta = "" Then
            Return False
        Else
            pOtroSi.codigo = respuesta
            Return True
        End If
        respuesta = Nothing

    End Function
    Public Function otrosiAnular(ByVal codigo As String, ByVal usuario As String)
        cmd.otrosiAnular(codigo, usuario)
        Return True
    End Function
End Class
