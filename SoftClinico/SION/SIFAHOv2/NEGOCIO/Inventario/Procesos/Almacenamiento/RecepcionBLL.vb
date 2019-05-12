Public Class RecepcionBLL
    Dim cmd As New RecepcionDAL
    Public Sub CargarLotesRecepcion(ByVal codigo As Integer, ByVal Codigo_producto As Integer, ByVal Codigo_bodega As Integer, ByRef tbl As DataTable)
        cmd.CargarLotesRecepcion(codigo, Codigo_producto, Codigo_bodega, tbl)
    End Sub
    Public Function ContadorProdcutos(ByRef dt As DataTable) As Integer
        Return dt.Select("Codigo <> ''").Count
    End Function
    Public Function verificarBodegaIndividual(ByVal codigo As Integer) As String
        Return cmd.verificarBodegaIndividual(codigo)
    End Function

    Public Sub guardar(ByRef objRecepcionTecnica As RecepcionTecnica,
                       ByVal punto As Integer,
                       ByVal usuario As Integer)
        Try
            cmd.guardarRecepcion(objRecepcionTecnica, punto, usuario)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Function verificacionAnularRecepcion(ByVal objRecepcion As RecepcionTecnica, ByVal usuario As Integer) As Boolean
        If cmd.verificacionAnularRecepcion(objRecepcion, usuario) = True Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub anularRecepcion(ByVal objRecepcion As RecepcionTecnica, ByVal usuario As String)
        Try
            cmd.anular(objRecepcion, usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function verificarCantidadesEnCero(ByVal nombreTabla As String, ByRef tbllotes As DataTableCollection) As List(Of Integer)
        Dim listaResultados As New List(Of Integer)
        listaResultados.Add(0)
        For indiceFila = 0 To tbllotes(nombreTabla).Rows.Count - 1
            If tbllotes(nombreTabla).Rows(indiceFila).Item("Cantidad") = 0 Then
                listaResultados(0) = 1
                listaResultados.Add(indiceFila)
            End If
        Next
        Return listaResultados
    End Function
End Class
