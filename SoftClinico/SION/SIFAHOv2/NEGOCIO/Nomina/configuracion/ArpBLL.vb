Public Class ArpBLL
    Dim objArpDAL As New ArpDAL
    Public Function guardarArp(ByVal objArp As ARL) As String
        If String.IsNullOrEmpty(objArp.codigoARL) Then
            Return objArpDAL.crearArp(objArp)
        Else
            objArpDAL.actualizarArp(objArp)
        End If
        Return Nothing
    End Function
    Public Sub anularARP(ByRef objARL As ARL)
        objArpDAL.anularARP(objARL)
    End Sub

End Class
