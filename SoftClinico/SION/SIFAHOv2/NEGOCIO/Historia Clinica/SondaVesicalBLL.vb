Public Class SondaVesicalBLL

    Public Shared Sub guardarSonda(Codigo_Sonda As Object, N_Registro As String, Fecha_Colocacion As Date, Microorganismo As String, Fecha_retiro As Date, usuario As Integer, dtsonda As DataTable)
        SondaVersicalDAL.guardarSonda(Codigo_Sonda, N_Registro, Fecha_Colocacion, Microorganismo, Fecha_retiro, usuario, dtsonda)
    End Sub

    Public Shared Sub guardarVeno(codigo_veno As Object, N_Registro As String, Fecha_Colocacion As Date, usuario As Integer, dtsonda As DataTable)
        SondaVersicalDAL.guardarVeno(codigo_veno, N_Registro, Fecha_Colocacion, usuario, dtsonda)
    End Sub

End Class
