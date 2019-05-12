Public Class EmpleadoAuxilio
    Public Property idEmpleado As Integer

    Public Property idEmpresa As Integer

    Public Property idAuxilio As Integer

    Public Property valor As Double

    Sub New()

    End Sub
    Sub New(drEmpleadoAuxilio As DataRow)
        idEmpleado = Funciones.castDBItem(drEmpleadoAuxilio.Item("id_empleado"))
        idEmpresa = Funciones.castDBItem(drEmpleadoAuxilio.Item("id_empresa"))
        idAuxilio = Funciones.castDBItem(drEmpleadoAuxilio.Item("ID_Aux_Transporte"))
        valor = Funciones.castDBItem(drEmpleadoAuxilio.Item("valor_auxilio"))
    End Sub

End Class
