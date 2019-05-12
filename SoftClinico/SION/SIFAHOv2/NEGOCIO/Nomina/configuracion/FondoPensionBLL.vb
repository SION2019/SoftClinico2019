Public Class FondoPensionBLL
    Dim cmd As New FondoPensionDAL
    Public Sub guardar_pension(ByRef codigo As TextBox, ByVal descripcion As String)

        cmd.guardar_pension(codigo, descripcion)

    End Sub
    Public Function anular_pension(ByVal codigo As String) As Boolean
        If cmd.anular_pension(codigo) = True Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
