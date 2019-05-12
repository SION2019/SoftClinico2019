Public Class ClienteBLL
    Dim objClienteDAL As New Clientes_C
    Public Sub Guardarcliente(objCliente As Cliente)
        If String.IsNullOrEmpty(objCliente.codigo) Then
            objClienteDAL.Guardarcliente(objCliente)
        Else
            objClienteDAL.actualizarCliente(objCliente)
        End If
    End Sub
End Class
