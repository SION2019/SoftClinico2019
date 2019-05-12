Public Class RecetarioBLL
    Dim objRecetario_C As New RecetarioDAL

    Public Sub crearRecetario(objRecetario As Recetario, codigo As Object)
        objRecetario_C.crearRecetario(objRecetario, codigo)
    End Sub
End Class
