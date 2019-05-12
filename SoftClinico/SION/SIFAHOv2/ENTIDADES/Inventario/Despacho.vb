Public Class Despacho
    Public Property tblLotes As DataSet

    Public Sub agregarTabla(ByVal pnombre As String)
        If verificarExistenciaTabla(pnombre) = False Then
            tblLotes.Tables.Add(pnombre)
        End If
    End Sub
    Public Sub quitarTabla(ByVal pnombre As String)
        If verificarExistenciaTabla(pnombre) Then
            tblLotes.Tables.Remove(pnombre)
        End If
    End Sub
    Public Function verificarExistenciaTabla(ByVal pnombre As String) As Boolean
        Return tblLotes.Tables.Contains(pnombre)
    End Function
    Public Function nombrarTabla(ByVal codigo As String, Optional ByVal fila As String = "", Optional tipo As String = Nothing) As String
        Dim nombreTabla As String
        nombreTabla = "TBL" & codigo & fila & tipo
        Return nombreTabla
    End Function
End Class
