Public Class ConteoBLL
    Dim cmd As New ConteoDAL
    Public Sub guardarConteoAuxiliar(ByRef objConto As Conteo, ByVal usuario As Integer)
        Try
            cmd.verificarTipoGuardado(objConto, usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub guardarConteo(ByRef objConteo As Conteo, ByVal usuario As Integer)
        Try
            cmd.guardarConteo(objConteo, usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub anularConteoAuxiliar(ByRef objConteo As Conteo)
        Try
            cmd.anularConteo(objConteo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
