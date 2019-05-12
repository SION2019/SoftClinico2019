Public Class EmpleadoViatico
    Public Property idEmpleado As Integer
    Public Property idEmpresa As Integer

    Public Property idViatico As Integer
    Public Property valor As Double

    Sub New()
    End Sub

    Sub New(drEmpleadoViatico As DataRow)

        idEmpleado = Funciones.castDBItem(drEmpleadoViatico.Item("id_empleado"))
        idEmpresa = Funciones.castDBItem(drEmpleadoViatico.Item("id_empresa"))
        idViatico = Funciones.castDBItem(drEmpleadoViatico.Item("id_viatico"))
        valor = Funciones.castDBItem(drEmpleadoViatico.Item("valor_viatico"))

    End Sub

End Class
