Public Class ComidaHora_D
    Dim comidasCmd As New ComidaHoraDAL
    Public Sub guardar(ByRef objComida As ComidasHoras,
                       ByVal usuario As String,
                       ByVal punto As Integer)
        If objComida.codigo = "" Then
            comidasCmd.guardar(objComida, usuario, punto)
        Else
            comidasCmd.actualizar(objComida, usuario)
        End If
    End Sub
    Public Sub anular(ByRef objComida As ComidasHoras,
                      ByVal usuario As String)
        comidasCmd.anular(objComida, usuario)
    End Sub

End Class
