Public Class RecaudoBLL
    Public Shared Function guardarRecaudo(objRecaudo As Recaudo)

        If IsNothing(Funciones.verificaExistenciaRecaudo(objRecaudo.comprobante)) Then
            FuncionesContables.aumentarConsecutivo(SesionActual.idEmpresa, objRecaudo.codigoDocumento)
        End If

        RecaudoDAL.guardarRecaudo(objRecaudo)
        Return objRecaudo

    End Function
End Class
