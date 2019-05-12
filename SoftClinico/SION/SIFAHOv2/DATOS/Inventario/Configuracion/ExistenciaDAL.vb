Imports System.Data.SqlClient
Public Class ExistenciaDAL
    Public Function verExistencias(ByVal Codigo_bodegas As Integer) As DataTable
        Using dt As New DataTable
            Using consultor As New SqlDataAdapter("[SP_VER_EXISTENCIAS] '" & Codigo_bodegas & "'", FormPrincipal.cnxion)
                consultor.Fill(dt)
            End Using
            Return dt
        End Using
    End Function
    Public Function verExistenciasLotesDetalle(ByVal Codigo_bodegas As Integer, ByVal codigo_producto As Integer) As DataTable
        Using dt As New DataTable
            Using consultor As New SqlDataAdapter("[SP_VER_EXISTENCIAS_LOTES_DETALLE] " & Codigo_bodegas & "," & codigo_producto, FormPrincipal.cnxion)
                consultor.Fill(dt)
            End Using
            Return dt
        End Using
    End Function
End Class
