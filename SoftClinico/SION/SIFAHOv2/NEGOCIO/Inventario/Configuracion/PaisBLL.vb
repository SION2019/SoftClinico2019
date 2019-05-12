Imports System.Data.SqlClient
Public Class PaisBLL
    Dim paisCmd As PaisDAL
    Public Sub guardar(ByRef objPais As Pais)
        paisCmd = New PaisDAL
        If objPais.codigo = "" Then
            paisCmd.guardar(objPais)
        Else
            paisCmd.actualizar(objPais)
        End If
    End Sub
    Public Sub Anular(ByRef objPais As Pais)
        paisCmd = New PaisDAL
        paisCmd.anular(objPais)
    End Sub
End Class
