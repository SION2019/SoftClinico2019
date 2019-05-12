Public Class ConvencionLaboralBLL
    Dim cmd As New ConvencionHorario
    Public Function guardar_convencion(pConvencion As Convencion) As String
        Dim codigo_convencion As String = ""


        codigo_convencion = cmd.guardar_convencion(pConvencion)

        Return codigo_convencion

    End Function

End Class
