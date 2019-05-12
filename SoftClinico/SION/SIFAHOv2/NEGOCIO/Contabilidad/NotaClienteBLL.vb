Public Class NotaClienteBLL
    Dim objNotaClienteDal As New NotaClienteDAL
    Public Sub guardarNotaCliente(ByVal objNotaCliente As NotaCliente,
                                         ByVal pUsuario As Integer)
        If String.IsNullOrEmpty(objNotaCliente.identificador) Then
            objNotaClienteDal.crearNotaCliente(objNotaCliente, pUsuario)
        Else
            objNotaClienteDal.actualizarNotaCliente(objNotaCliente, pUsuario)
        End If

    End Sub
End Class
