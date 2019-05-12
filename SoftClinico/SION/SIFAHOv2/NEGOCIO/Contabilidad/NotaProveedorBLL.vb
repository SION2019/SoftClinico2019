Public Class NotaProveedorBLL
    Dim objNotaProveedorDal As New NotaProveedorDAL
    Public Sub guardarNotaProveedor(ByVal objNotaProveedor As NotaProveedor,
                                         ByVal pUsuario As Integer)
        If String.IsNullOrEmpty(objNotaProveedor.identificador) Then
            objNotaProveedorDal.crearNotaProveedor(objNotaProveedor, pUsuario)
        Else
            objNotaProveedorDal.actualizarNotaProveedor(objNotaProveedor, pUsuario)
        End If

    End Sub
End Class
