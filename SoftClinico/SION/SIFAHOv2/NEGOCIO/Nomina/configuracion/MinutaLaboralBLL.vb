Public Class MinutaLaboralBLL
    Dim cmd As New MinutaLaboralDAL
    Public Sub guardar_minuta(ByRef form_minutas1 As Form_minutas)
        cmd.guardar_minuta(form_minutas1)
    End Sub
    Public Sub anular_minuta(ByRef codigo As TextBox)
        cmd.anular_minuta(codigo)
    End Sub
End Class
