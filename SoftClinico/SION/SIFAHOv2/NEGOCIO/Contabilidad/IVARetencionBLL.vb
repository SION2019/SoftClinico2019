Public Class IVARetencionBLL

    Public Shared Sub guardarRetencionIVA(ByVal objRetencionIVA As RetencionIVA,
                                        ByVal pUsuario As Integer)

        RetencionIvaDAL.crearRetencionIVA(objRetencionIVA, pUsuario)

    End Sub

End Class
