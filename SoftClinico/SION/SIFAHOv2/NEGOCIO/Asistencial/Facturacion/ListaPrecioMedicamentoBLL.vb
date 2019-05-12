Public Class ListaPrecioMedicamentoBLL
    Dim LISTA As New ListaPrecioMedicamentoDAL
    Public Function llenar_dgv(LISTA_M As String, todo As Integer) As DataTable
        Dim dt As DataTable
        dt = LISTA.CARGar_dgv(LISTA_M, todo)
        Return dt
    End Function

    Public Function guardar(codigo As String, descripcion As String, tabla As DataTable, ByVal ventaDirecta As Boolean) As String
        Dim cod As String

        cod = LISTA.guardar(codigo, descripcion, tabla, ventaDirecta)

        Return cod

    End Function

    Public Function anular_LISTA(ByVal codigo As String) As Boolean
        If LISTA.anular_LISTA(codigo) = True Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
