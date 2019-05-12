Public Class TerceroUsuario
    Public Property idTercero As Integer
    Public Property idEmpresa As Integer
    Public Property usuario As String
    Public Property codigoPerfil As Integer
    Public Property clave As String
    Public Property estado As Integer

    Sub New()

    End Sub

    Sub New(tercero As Tercero, idEmpresa As Integer)
        idTercero = tercero.idTercero
        idEmpresa = idEmpresa
    End Sub

    Sub New(drUsuario As DataRow)
        idTercero = Funciones.castFromDbItem(drUsuario.Item("id_empleado"))
        idEmpresa = Funciones.castFromDbItem(drUsuario.Item("id_empresa"))
        usuario = Funciones.castFromDbItem(drUsuario.Item("usuario"))
        codigoPerfil = Funciones.castFromDbItem(drUsuario.Item("codigo_perfil"))
        estado = Funciones.castFromDbItem(drUsuario.Item("estado_usuario"))
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then
            Return False
        End If
        If Me.GetType IsNot obj.GetType Then
            Return False
        End If

        Dim otroUsuario As TerceroUsuario = CType(obj, TerceroUsuario)
        If otroUsuario.idTercero <> Me.idTercero Or
           otroUsuario.idEmpresa <> Me.idEmpresa Or
           otroUsuario.usuario <> Me.usuario Or
           otroUsuario.codigoPerfil <> Me.codigoPerfil Or
           otroUsuario.estado <> Me.estado Then

            Return False
        End If

        Return True
    End Function
End Class
