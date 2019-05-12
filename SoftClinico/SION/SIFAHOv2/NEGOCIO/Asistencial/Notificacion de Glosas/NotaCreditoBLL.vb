Public Class NotaCreditoBLL
    Dim objNotaCreditoDAL As New NotaCreditoDAL
    Public Function guardarNotaCredito(ByVal objNotaCredito As NotaCredito) As String
        If String.IsNullOrEmpty(objNotaCredito.Id_Nota) Then
            Return objNotaCreditoDAL.CrearNotaCredito(objNotaCredito)
        Else
            objNotaCreditoDAL.actualizarNotaCredito(objNotaCredito)
        End If
        Return objNotaCredito.Id_Nota
    End Function
End Class
