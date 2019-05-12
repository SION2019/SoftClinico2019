Public Class ProveedorBLL
    Dim objProveedorDAL As New ProveedorDAL
    Public Sub guardarProveedor(ByVal objProveedor As Proveedor)
        If String.IsNullOrEmpty(objProveedor.idProveedor) Then
            objProveedorDAL.guardarProveedor(objProveedor)
        Else
            objProveedorDAL.actualizarProveedor(objProveedor)
        End If

    End Sub
    Public Sub proveedorAnular(ByVal objProveedor As Proveedor)
        objProveedorDAL.proveedorAnular(objProveedor)
    End Sub

End Class
