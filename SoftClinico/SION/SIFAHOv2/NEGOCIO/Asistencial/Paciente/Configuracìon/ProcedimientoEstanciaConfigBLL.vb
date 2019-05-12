Imports System.Data.SqlClient
Public Class ProcedimientoEstanciaConfigBLL
    Dim cmd As New EstanciaConfigProcedimientoDAL
    Public Function guardarProcedimiento(objProcedimiento As ConfiguracionProcedimientoCups)
        cmd.Guardarconfiguracionprocedimientos(objProcedimiento)
        Return objProcedimiento
    End Function
End Class
