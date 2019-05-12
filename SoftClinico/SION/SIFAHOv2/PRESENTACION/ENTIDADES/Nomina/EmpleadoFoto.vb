Public Class EmpleadoFoto
    Public Property idEmpleado As Integer
    Public Property imagen As Image

    Sub New()

    End Sub

    Sub New(drEmpleadoFoto As DataRow)

        idEmpleado = Funciones.castDBItem(drEmpleadoFoto.Item("id_empleado"))
        Dim bytes() As Byte = Funciones.castDBItem(drEmpleadoFoto.Item("foto"))

        If bytes IsNot Nothing Then
            imagen = Image.FromStream(New MemoryStream(bytes))
        End If

    End Sub

End Class
