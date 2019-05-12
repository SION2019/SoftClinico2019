Public Class EmpleadoHuella
    Public Property idEmpleado As Integer
    Public Property imagen As Image

    Sub New()

    End Sub

    Sub New(tercero As Tercero)
        idEmpleado = tercero.idTercero
    End Sub

End Class
