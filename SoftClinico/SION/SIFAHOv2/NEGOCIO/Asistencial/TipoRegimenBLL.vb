Public Class Regimen_D
    Dim regimen As New Regimen_C
    Public Function guardar(ByVal codigo As String, ByVal descripcion As Integer)
        Dim respuesta As String
        respuesta = regimen.GuardarAactualizar(codigo, descripcion)
        If respuesta <> "" Then
            FormRegimen.txtcodigo.Text = respuesta
            Return True
        Else
            Return False
        End If
    End Function


    Public Function anular(ByVal codigo As String)
        If regimen.devoAnular(codigo) Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
