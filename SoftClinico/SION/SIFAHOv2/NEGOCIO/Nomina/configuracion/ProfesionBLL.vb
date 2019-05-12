Public Class ProfesionBLL
    Dim cmd As New ProfesionDAL
    Public Sub guardar_profesion(ByRef txtCodigo As Object, ByVal descripcion As String)
        cmd.guardar_profesion(txtCodigo, descripcion)
    End Sub

    Public Sub anular_profesion(ByVal codigo As String)
        cmd.anular_profesion(codigo)
    End Sub

End Class
