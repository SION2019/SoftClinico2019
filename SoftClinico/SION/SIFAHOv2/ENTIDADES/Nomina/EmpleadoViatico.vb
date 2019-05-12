Public Class EmpleadoViatico
    Public Property idEmpleado As Integer
    Public Property idEmpresa As Integer

    Public Property idViatico As Integer
    Public Property valor As Double

    Sub New()
    End Sub

    Sub New(tercero As Tercero, idEmpresa As Integer)
        idEmpleado = tercero.idTercero
        Me.idEmpresa = idEmpresa
    End Sub
    Sub New(drEmpleadoViatico As DataRow)

        idEmpleado = Funciones.castFromDbItem(drEmpleadoViatico.Item("id_empleado"))
        idEmpresa = Funciones.castFromDbItem(drEmpleadoViatico.Item("id_empresa"))
        idViatico = Funciones.castFromDbItem(drEmpleadoViatico.Item("id_viatico"))
        valor = Funciones.castFromDbItem(drEmpleadoViatico.Item("valor_viatico"))

    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then
            Return False
        End If
        If Me.GetType IsNot obj.GetType Then
            Return False
        End If

        Dim otroViatico As EmpleadoViatico = CType(obj, EmpleadoViatico)
        If otroViatico.idEmpleado <> Me.idEmpleado OrElse
           otroViatico.idEmpresa <> Me.idEmpresa OrElse
           otroViatico.idViatico <> Me.idViatico OrElse
            otroViatico.valor <> Me.valor Then
            Return False
        End If

        Return True
    End Function

End Class
