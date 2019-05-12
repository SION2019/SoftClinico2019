Public Class EmpleadoSalario
    Public Property idSalario As Integer?
    Public Property idEmpresa As Integer
    Public Property idEmpleado As Integer
    Public Property valor As Double

    Sub New()

    End Sub

    Sub New(tercero As Tercero, empresa As Integer)
        idEmpleado = tercero.idTercero
        Me.idEmpresa = idEmpresa
    End Sub

    Sub New(drSalario As DataRow)

        idSalario = Funciones.castFromDbItem(drSalario.Item("id_salario"))
        idEmpresa = Funciones.castFromDbItem(drSalario.Item("id_empresa"))
        idEmpleado = Funciones.castFromDbItem(drSalario.Item("id_empleado"))
        valor = Funciones.castFromDbItem(drSalario.Item("valor_salario"))

    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then
            Return False
        End If
        If Me.GetType IsNot obj.GetType Then
            Return False
        End If

        Dim otroSalario As EmpleadoSalario = CType(obj, EmpleadoSalario)
        If otroSalario.idSalario <> Me.idSalario Or
           otroSalario.idEmpresa <> Me.idEmpresa Or
           otroSalario.idEmpleado <> Me.valor Then
            Return False
        End If

        Return True
    End Function

End Class
