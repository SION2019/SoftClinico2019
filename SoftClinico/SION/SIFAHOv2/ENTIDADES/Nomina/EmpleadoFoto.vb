Public Class EmpleadoFoto
    Public Property idEmpleado As Integer
    Public Property foto As Image

    Sub New()

    End Sub

    Sub New(tercero As Tercero)
        idEmpleado = tercero.idTercero
    End Sub

    Sub New(drEmpleadoFoto As DataRow)

        idEmpleado = Funciones.castFromDbItem(drEmpleadoFoto.Item("id_empleado"))
        Dim bytes() As Byte = Funciones.castFromDbItem(drEmpleadoFoto.Item("foto"))

        If bytes IsNot Nothing Then
            foto = Image.FromStream(New MemoryStream(bytes))
        End If

    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then
            Return False
        End If
        If Me.GetType IsNot obj.GetType Then
            Return False
        End If

        Dim otraFoto As EmpleadoFoto = CType(obj, EmpleadoFoto)
        If otraFoto.idEmpleado <> Me.idEmpleado Or
           Not otraFoto.foto.Equals(Me.foto) Then

            Return False
        End If

        Return True
    End Function




End Class
