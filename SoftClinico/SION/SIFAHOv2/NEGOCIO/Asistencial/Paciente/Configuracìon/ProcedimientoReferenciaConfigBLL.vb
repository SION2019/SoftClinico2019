Imports System.Data.SqlClient
Public Class ProcedimientoReferenciaConfigBLL
    Dim cmd As New ConfigProcedExamDAL
    Public Function guardarReferencia(objProcedimiento As ConfigReferenciaExam)
        cmd.Guardarconfiguracionprocedimientos(objProcedimiento)
        Return objProcedimiento
    End Function
End Class
