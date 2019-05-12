Imports System.Data.SqlClient
Public Class DepartamentoBLL
    Dim cmd As New DepartamentoDAL
    Public Function guardar_depar(ByVal codigo As String, ByVal descripcion As String, ByVal pais As String) As Boolean
        Dim codigo_ent As String = ""

        codigo_ent = cmd.guardar_depar(codigo, descripcion, pais)
        If codigo_ent = "" Then
            Return False
        Else
            Form_Departamento.txtcodigo.Text = codigo_ent
            Return True
        End If
        codigo_ent = Nothing

    End Function
    Public Function anular_depar(ByVal codigo As String, ByVal pais As String) As Boolean
        If cmd.anular_depar(codigo, pais) = True Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
