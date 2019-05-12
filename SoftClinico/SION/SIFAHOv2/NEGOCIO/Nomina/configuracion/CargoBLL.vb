Public Class CargoBLL
    Dim objCargoDAL As New CargoDAL
    Public Function guardarCargo(ByVal objCargo As Cargo) As String
        If String.IsNullOrEmpty(objCargo.codigo) Then
            Return objCargoDAL.crearCargo(objCargo)
        Else
            objCargoDAL.actualizarCargo(objCargo)
        End If
        Return Nothing
    End Function
    Public Function anularCargo(ByVal objCargo As Cargo) As Boolean
        If objCargoDAL.anularCargo(objCargo) = True Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
