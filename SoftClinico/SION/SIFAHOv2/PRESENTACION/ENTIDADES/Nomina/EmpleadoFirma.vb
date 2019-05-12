Public Class EmpleadoFirma
    Public Property idEmpleado As Integer
    Public Property imagen As Image

    Sub New()

    End Sub

    Sub New(drEmpleadoFirma As DataRow)

        idEmpleado = Funciones.castDBItem(drEmpleadoFirma.Item("id_empleado"))
        Dim bytes() As Byte = Funciones.castDBItem(drEmpleadoFirma.Item("firma"))

        If bytes IsNot Nothing Then
            imagen = Image.FromStream(New MemoryStream(bytes))
        End If

    End Sub

End Class
