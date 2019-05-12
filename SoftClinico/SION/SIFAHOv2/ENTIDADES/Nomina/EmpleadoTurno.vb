Public Class EmpleadoTurno
    Public Property idTurno As Integer
    Public Property idEmpresa As Integer
    Public Property idEmpleado As Integer
    Public Property valor As Double

    Sub New()

    End Sub

    Sub New(tercero As Tercero, idEmpresa As Integer)
        idEmpleado = tercero.idTercero
        idEmpresa = idEmpresa
    End Sub

    Sub New(drEmpleadoTurno As DataRow)
        idTurno = Funciones.castFromDbItem(drEmpleadoTurno.Item("id_turno"))
        idEmpresa = Funciones.castFromDbItem(drEmpleadoTurno.Item("id_empresa"))
        idEmpleado = Funciones.castFromDbItem(drEmpleadoTurno.Item("id_empleado"))
        valor = Funciones.castFromDbItem(drEmpleadoTurno.Item("valor_turno"))
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then
            Return False
        End If
        If Me.GetType IsNot obj.GetType Then
            Return False
        End If

        Dim otroTurno As EmpleadoTurno = CType(obj, EmpleadoTurno)
        If otroTurno.idTurno <> Me.idTurno Or
           otroTurno.idEmpresa <> Me.idEmpresa Or
           otroTurno.idEmpleado <> Me.idEmpleado Or
            otroTurno.valor <> Me.valor Then
            Return False
        End If

        Return True
    End Function

End Class
