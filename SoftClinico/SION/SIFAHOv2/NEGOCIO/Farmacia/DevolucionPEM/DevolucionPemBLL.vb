Public Class DevolucionPemBLL
    Dim objDevolucionDLL As New DevolucionPemDAL
    Public Sub guardarDevolucionPem(ByRef objDevolucion As DevolucionPem,
                             ByVal usuario As Integer,
                             ByVal punto As Integer)
        Try
            objDevolucionDLL.guardarDevolucionPem(objDevolucion, usuario, punto)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub anularDevolucion(ByRef objDevolucion As DevolucionPem,
                                ByVal usuario As Integer)
        Try
            objDevolucionDLL.AnularDevolucionPem(objDevolucion, usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function verificarAnular(ByRef objDevolucion As DevolucionPem) As Boolean
        Return objDevolucionDLL.verificarAnular(objDevolucion)
    End Function
    Public Function verificarBodegaDestino(ByRef objDevolucion As DevolucionPem, ByVal filaActual As Integer) As Boolean
        Return objDevolucionDLL.verificarBodegaDestino(objDevolucion, filaActual)
    End Function
End Class
