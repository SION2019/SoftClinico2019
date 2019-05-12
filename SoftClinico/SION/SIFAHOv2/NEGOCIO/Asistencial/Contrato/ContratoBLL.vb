Public Class ContratoBLL
    Dim objContratoDAL As New ContratoDAL
    Public Function guardarContrato(ByVal objContrato As ContratoEps, elementoAEliminar As List(Of String)) As String
        If String.IsNullOrEmpty(objContrato.codigoContrato) Then
            Return objContratoDAL.guardarContrato(objContrato, elementoAEliminar)
        Else
            objContratoDAL.actualizarContrato(objContrato, elementoAEliminar)
        End If
        Return objContrato.codigoContrato
    End Function

End Class
