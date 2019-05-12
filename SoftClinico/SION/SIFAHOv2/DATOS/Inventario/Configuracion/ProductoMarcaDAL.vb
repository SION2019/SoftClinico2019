Imports System.Data.SqlClient
Imports System.IO
Public Class ProductoMarcaDAL
    Private Function verificar_formulario(form As Windows.Forms.Form) As Boolean
        Dim valor As Boolean = False
        For Each f As Windows.Forms.Form In Application.OpenForms
            If f.Name = form.Name Then
                valor = True
            End If
        Next
        Return valor
    End Function
    Public Sub actualizarMarca(ByVal objProductoMarca As Marca, ByVal usuario As Integer)
        Try
            Using Consulta As New SqlCommand("[PROC_MARCAS_ACTUALIZAR]")
                Consulta.CommandType = CommandType.StoredProcedure
                Consulta.Connection = FormPrincipal.cnxion
                Consulta.Parameters.Clear()
                Consulta.Parameters.Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar))
                Consulta.Parameters("@DESCRIPCION").Value = objProductoMarca.nombre
                Consulta.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.NVarChar))
                Consulta.Parameters("@CODIGO").Value = objProductoMarca.codigo
                Consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.NVarChar))
                Consulta.Parameters("@USUARIO").Value = usuario
                Consulta.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub guardarMarca(ByVal objProductoMarca As Marca, ByVal usuario As Integer)
        Try
            Using Consulta As New SqlCommand("PROC_MARCAS_CREAR")
                Consulta.CommandType = CommandType.StoredProcedure
                Consulta.Connection = FormPrincipal.cnxion
                Consulta.Parameters.Clear()
                Consulta.Parameters.Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar))
                Consulta.Parameters("@DESCRIPCION").Value = objProductoMarca.nombre
                Consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.NVarChar))
                Consulta.Parameters("@USUARIO").Value = usuario
                objProductoMarca.codigo = CInt(Consulta.ExecuteScalar())
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub anularMarca(ByVal objProductoMarca As Marca, ByVal usuario As Integer)
        Try
            Using Consulta As New SqlCommand("PROC_MARCAS_ANULAR")
                Consulta.CommandType = CommandType.StoredProcedure
                Consulta.Connection = FormPrincipal.cnxion
                Consulta.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.Int))
                Consulta.Parameters("@CODIGO").Value = objProductoMarca.codigo
                Consulta.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.NVarChar))
                Consulta.Parameters("@Usuario").Value = usuario
                Consulta.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
