Public Class TerceroUsuario
    Public Property idTercero As Integer
    Public Property idEmpresa As Integer
    Public Property usuario As String

    Sub New()

    End Sub

    Sub New(drUsuario As DataRow)
        idTercero = Funciones.castDBItem(drUsuario.Item("id_empleado"))
        idEmpresa = Funciones.castDBItem(drUsuario.Item("id_empresa"))
        usuario = Funciones.castDBItem(drUsuario.Item("usuario"))
    End Sub
End Class
