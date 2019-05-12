Imports System.Data.SqlClient
Public Class ReferenciaTipoBLL
    Dim cmd As New ReferenciaTipoDAL
    Public Function guardar_tiporeferencia(ByVal codigo As String, ByVal descripcion As String) As Boolean
        Dim codigo_ent As String = ""

        codigo_ent = cmd.guardar_tiporeferencias(codigo, descripcion)
        If codigo_ent = "" Then
            Return False
        Else
            Form_tipo_Referencia.txtcodigo.Text = codigo_ent
            Return True
        End If
        codigo_ent = Nothing

    End Function
    Public Function anular_tiporeferencia(ByVal codigo As String) As Boolean
        If cmd.anular_tiporeferencia(codigo) = True Then
            Return True
        Else
            Return False
        End If
    End Function

End Class