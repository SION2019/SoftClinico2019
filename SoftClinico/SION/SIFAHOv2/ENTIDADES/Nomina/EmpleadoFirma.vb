Public Class EmpleadoFirma
    Public Property idEmpleado As Integer
    Public Property imagen As Image

    Sub New()

    End Sub
    Sub New(tercero As Tercero)
        idEmpleado = tercero.idTercero
    End Sub

    Sub New(drEmpleadoFirma As DataRow)

        idEmpleado = Funciones.castFromDbItem(drEmpleadoFirma.Item("id_empleado"))
        Dim bytes() As Byte = Funciones.castFromDbItem(drEmpleadoFirma.Item("firma"))

        If bytes IsNot Nothing Then
            imagen = Image.FromStream(New MemoryStream(bytes))
        End If

    End Sub

End Class
