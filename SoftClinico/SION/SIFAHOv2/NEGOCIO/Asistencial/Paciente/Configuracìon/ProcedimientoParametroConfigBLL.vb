Imports System.Data.SqlClient
Public Class ProcedimientoParametroConfigBLL
    Dim cmd As New ParametroConfigProcedimientoDAL
    Public Function guardarParametro(objParametro As ConfigParametroExam)
        cmd.GuardarconfigParametro(objParametro)
        Return objParametro
    End Function
End Class
