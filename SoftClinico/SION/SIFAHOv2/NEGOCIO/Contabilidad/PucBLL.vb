Public Class PucBLL

    Dim objPUC_C As New PucDAL

    Public Function guardarPUC(objPUC As Puc, pUsuario As Integer) As String

        Dim codigoPUC As String = Nothing

        'Si es un nuevo PUC
        If objPUC.codigo = Nothing Then
            objPUC_C.crearPUC(objPUC, pUsuario)
        Else
            objPUC_C.actualizarPUC(objPUC, pUsuario)
        End If

        Return objPUC.codigo
    End Function


End Class
