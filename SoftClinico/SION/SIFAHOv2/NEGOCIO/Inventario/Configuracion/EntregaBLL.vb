Public Class EntregaBLL
    Dim entrega As New EntregaDAL
    Public Sub guardar_plazo(ByVal codigo As Object, ByVal dia As String)

        entrega.GuardarAactualizar_PLAZA(codigo, dia)

    End Sub

End Class
