Public Class DespachoPEMBLL
    Dim objDespachoPEMDAL As New DespachoPemDAL
    Sub guardarDespachoPEM(ByRef objDespachoPEM As DespachoPEM,
                           ByVal usuario As Integer,
                           ByVal punto As Integer)
        Try
            objDespachoPEMDAL.guardarDespachoPem(objDespachoPEM, usuario, punto)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub anularDespachoPEM(ByRef objDespachoPEM As DespachoPEM,
                          ByVal usuario As Integer)
        Try
            objDespachoPEMDAL.anularDespachoPem(objDespachoPEM, usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
