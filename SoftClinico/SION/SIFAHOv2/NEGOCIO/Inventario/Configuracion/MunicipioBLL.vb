Imports System.Data.SqlClient
Public Class MunicipioBLL

    Dim cmd As New MunicipioDAL
    Public Function guardar_muni(ByVal codigo As String, ByVal descripcion As String, ByVal pais As String, ByVal departamento As String) As Boolean
        Dim codigo_ent As String = ""

        codigo_ent = cmd.guardar_muni(codigo, descripcion, pais, departamento)
        If codigo_ent = "" Then
            Return False
        Else
            Form_Ciudad.txtcodigo.Text = codigo_ent
            Return True
        End If
        codigo_ent = Nothing

    End Function
    Public Function anular_muni(ByVal codigo As String, ByVal pais As String, ByVal departamento As String) As Boolean
        If cmd.anular_muni(codigo, pais, departamento) = True Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
