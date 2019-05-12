Public Class EmpleadoAuxilio
    Public Property idEmpleado As Integer

    Public Property idEmpresa As Integer

    Public Property idAuxilio As Integer

    Public Property valor As Double

    Sub New()

    End Sub

    Sub New(tercero As Tercero, idEmpresa As Integer)
        idEmpleado = tercero.idTercero
        Me.idEmpresa = idEmpresa
    End Sub
    Sub New(drEmpleadoAuxilio As DataRow)
        idEmpleado = Funciones.castFromDbItem(drEmpleadoAuxilio.Item("id_empleado"))
        idEmpresa = Funciones.castFromDbItem(drEmpleadoAuxilio.Item("id_empresa"))
        idAuxilio = Funciones.castFromDbItem(drEmpleadoAuxilio.Item("ID_Aux_Transporte"))
        valor = Funciones.castFromDbItem(drEmpleadoAuxilio.Item("valor_auxilio"))
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then
            Return False
        End If
        If Me.GetType IsNot obj.GetType Then
            Return False
        End If

        Dim otroAuxilio As EmpleadoAuxilio = CType(obj, EmpleadoAuxilio)
        If otroAuxilio.idEmpleado <> Me.idEmpleado Or
           otroAuxilio.idEmpresa <> Me.idEmpresa Or
           otroAuxilio.idAuxilio <> Me.idAuxilio Or
           otroAuxilio.valor <> Me.valor Then
            Return False
        End If

        Return True
    End Function

End Class
