Public Class ConcurrenciaBLL
    Dim objConcurrencia_C As New ConcurrenciaDAL

    Public Sub guardarConcurrencia(objConcurrencia As ConcurrenciaPaciente, fecha As Date)
        objConcurrencia_C.guardarConcurrencia(objConcurrencia, fecha)
    End Sub
End Class
