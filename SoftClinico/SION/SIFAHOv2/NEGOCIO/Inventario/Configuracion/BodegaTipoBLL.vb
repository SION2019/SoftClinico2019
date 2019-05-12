Public Class BodegaTipoBLL
    Dim cmd As New BodegaTipoDAL
    Public Sub guardarTipoBodega(ByRef objTipoBodega As TipoBodega, ByVal usuario As Integer)
        Try
            If objTipoBodega.codigo = "" Then
                cmd.guardar(objTipoBodega, usuario)
            Else
                cmd.actualizar(objTipoBodega, usuario)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
