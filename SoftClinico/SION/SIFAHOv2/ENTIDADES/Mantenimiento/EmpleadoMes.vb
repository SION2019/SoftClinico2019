Public Class EmpleadoMes
    Public Property idEmpleado As Integer
    Public Property fecha As Date
    Public Property codigoEp As Integer

    Public Sub guardarRegistro()
        EmpleadoMesDAL.guardarEmpleado(Me)
    End Sub
End Class
