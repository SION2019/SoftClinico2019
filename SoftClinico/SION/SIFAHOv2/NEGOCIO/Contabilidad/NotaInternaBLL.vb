Public Class CualquierNotaBLL
    Dim objCualquierNotaDal As New CualquierNotaDAL
    Public Sub guardarCualquierNota(ByVal objCualquierNota As NotaInterna,
                                         ByVal pUsuario As Integer)
        If String.IsNullOrEmpty(objCualquierNota.identificador) Then
            objCualquierNotaDal.crearCualquierNota(objCualquierNota, pUsuario)
        Else
            objCualquierNotaDal.actualizarCualquierNota(objCualquierNota, pUsuario)
        End If

    End Sub
End Class
