Public Class CpisBLL
    Public Shared Function guardarCPIS(N_Registro As Integer, Fecha As Date, USUARIO As Integer, dtCPIS As DataTable)
        Return CpisDAL.guardarCpis(N_Registro, Fecha, USUARIO, dtCPIS)
    End Function
End Class
