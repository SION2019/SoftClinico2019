Public Class PlazoEntregaBLL
    Dim plazoCmd As New PlazoDAL
    Public Sub guardar(ByRef objPlazo As Plazo, ByVal usuario As String)
        If objPlazo.codigo = "" Then
            plazoCmd.guardar(objPlazo, usuario)
        Else
            plazoCmd.actualizar(objPlazo, usuario)
        End If
    End Sub
    Public Sub anular(ByRef objPlazo As Plazo, ByVal usuario As String)
        plazoCmd.anular(objPlazo, usuario)
    End Sub
End Class
