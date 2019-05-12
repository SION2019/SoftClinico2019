Public Class RecepcionTecnicaTrasladoBLL
    Dim cmd As New RecepcionTecnicaTrasladoDAL

    Public Sub guardarRecepciontralado(ByVal objRecepcion As RecepcionTecnicaTraslado, ByVal usuario As Integer, ByVal punto As Integer)
        cmd.guardarRecepcionTralado(objRecepcion, usuario, punto)
    End Sub
    Public Function verificacion_anular_recepcion(ByVal codigo As Integer) As Boolean
        Return cmd.verificacion_anular_recepcion(codigo)
    End Function
    Public Function anular(ByVal codigo_recepcion As Integer) As Boolean
        Return cmd.anular(codigo_recepcion) = True
    End Function
End Class
