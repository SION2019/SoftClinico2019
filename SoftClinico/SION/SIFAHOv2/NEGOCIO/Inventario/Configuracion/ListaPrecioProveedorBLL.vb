
Public Class ListaPrecioProveedorBLL
    Dim cmd As New ProveedorListaPrecioDAL
    Public Function validarExistencia(ByRef objListaProveedor As ListaPrecioProveedorCliente) As Boolean
        Return cmd.validarExistencia(objListaProveedor)
    End Function
    Public Sub guardarLista(ByVal objetoListaProveedor As ListaPrecioProveedorCliente)
        Try
            If objetoListaProveedor.codigoLista = "" Then
                cmd.guardarLista(objetoListaProveedor)
            Else
                cmd.ActualizarLista(objetoListaProveedor)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
