Public Class EmpleadoSalario
    Public Property idSalario As Integer
    Public Property idEmpresa As Integer
    Public Property idEmpleado As Integer
    Public Property valor As Double

    Sub New()

    End Sub

    Sub New(drSalario As DataRow)

        idSalario = Funciones.castDBItem(drSalario.Item("id_salario"))
        idEmpresa = Funciones.castDBItem(drSalario.Item("id_empresa"))
        idEmpleado = Funciones.castDBItem(drSalario.Item("id_empleado"))
        valor = Funciones.castDBItem(drSalario.Item("valor_salario"))

    End Sub
End Class
