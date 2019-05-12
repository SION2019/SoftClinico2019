Imports System.Data.SqlClient
Public Class TransportadoraBLL
    Dim trans As New TransportadoraDAL
    Public Sub guardartrans(ByVal codigo As Object, ByVal nombre As String, ByVal usuario As String)

        trans.guardartrans(codigo, nombre, usuario)

    End Sub

    Public Function anulartrans(ByVal codigo As String, ByVal usuario As String) As Boolean
        Dim resultado As Boolean
        resultado = trans.transaAnular(codigo, usuario)
        If resultado <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
