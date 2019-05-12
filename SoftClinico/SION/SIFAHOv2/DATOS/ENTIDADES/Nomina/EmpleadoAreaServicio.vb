Public Class EmpleadoAreaServicio
    Public Property idEmpleado As Integer
    Public Property idEmpresa As Integer
    Public Property codigoAreaServicio As Integer
    Public Property descripcion As String

    Public ReadOnly Property areaDescripcion As String
        Get
            Return codigoAreaServicio & " | " & descripcion
        End Get
    End Property


End Class
