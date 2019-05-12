Public Class EmpleadoTurno
    Public Property idTurno As Integer
    Public Property idEmpresa As Integer
    Public Property idEmpleado As Integer
    Public Property valor As Double

    Sub New()

    End Sub

    Sub New(drEmpleadoTurno As DataRow)
        idTurno = Funciones.castDBItem(drEmpleadoTurno.Item("id_turno"))
        idEmpresa = Funciones.castDBItem(drEmpleadoTurno.Item("id_empresa"))
        idEmpleado = Funciones.castDBItem(drEmpleadoTurno.Item("id_empleado"))
        valor = Funciones.castDBItem(drEmpleadoTurno.Item("valor_turno"))
    End Sub

End Class
