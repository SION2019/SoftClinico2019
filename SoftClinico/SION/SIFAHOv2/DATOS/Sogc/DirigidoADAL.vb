Imports System.Data.SqlClient
Public Class DirigidoADAL
    Public Function cargar_cargos() As DataTable
        Using dt As New DataTable
            Using consultar As New SqlDataAdapter("SELECT Codigo_Cargo Codigo,Descripcion_Cargo Cargo FROM D_EMPLEADO_CARGO", FormPrincipal.cnxion)
                consultar.Fill(dt)
            End Using
            Return dt
        End Using
    End Function
End Class
