Public Class EcocardiogramaBLL
    Dim cmd As New EcocardiogramaDAL
    Public Shared Function guardarEcocardiograma(objEco As Eco)
        Try
            If objEco.CodigoTipoEco = Constantes.CODIGO_ECOCARDIOGRAMA Then
                EcocardiogramaDAL.guardarEcocardiograma(objEco)
            Else
                EcocardiogramaDAL.guardarEcocardiogramaStres(objEco)
            End If

        Catch ex As Exception
            Throw
        End Try

        Return objEco

    End Function



End Class
