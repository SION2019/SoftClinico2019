Public Class Observacion
    Public Property codigo As String
    Public Property descripcion As String
    Public Property usuario As Integer


    Public Sub guardarObservaciones()
        ProductoObservacionDAL.GuardarObservacion(Me)
    End Sub
End Class
