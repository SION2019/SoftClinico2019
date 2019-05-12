Public Class EscalaBradenBLL
    Dim consulta As New EscalaBradenDAL

    Public Function guardarBraden(N_Registro As Integer, Fecha As Date, USUARIO As Integer, dtEscala As DataTable)
        Dim respuesta As String

        respuesta = consulta.guardarBraden(N_Registro, Fecha, USUARIO, dtEscala)
        If respuesta <> "" Then
            Form_Braden.textregistro.Text = respuesta
            Return True
        Else
            Return False
        End If
    End Function
End Class
