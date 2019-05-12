Imports System.Data.SqlClient
Public Class ProcedimientoHemoderivadoConfigBLL
    Dim cmd As New HemoderivadoConfigProcedimientoDAL
    Public Function guardarProcedimiento(ByVal dt As DataTable, ByVal codigoGrupo As String) As Boolean
        Dim resultado As Boolean
        Try
            resultado = cmd.Guardarconfiguracionprocedimientos(dt, codigoGrupo)
        Catch ex As Exception
            Throw ex
        End Try
        If resultado = False Then
            Return False
        Else
            Return True
        End If
    End Function
End Class
