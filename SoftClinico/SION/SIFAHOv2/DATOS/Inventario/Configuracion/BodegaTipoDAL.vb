Imports System.Data.SqlClient
Public Class BodegaTipoDAL
    Public Sub guardar(ByRef objTipoBodega As TipoBodega, ByVal usuario As Integer)
        Try

            Using Consulta As New SqlCommand("PROC_TIPO_BODEGA_CREAR")
                Consulta.CommandType = CommandType.StoredProcedure
                Consulta.Connection = FormPrincipal.cnxion
                Consulta.Parameters.Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar))
                Consulta.Parameters("@DESCRIPCION").Value = objTipoBodega.nombre
                Consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.NVarChar))
                Consulta.Parameters("@USUARIO").Value = usuario
                objTipoBodega.codigo = CType(Consulta.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        'If verificar_formulario(Bodega) = True Then
        '    Bodega.llenar_tipo_bodega()
        'End If


    End Sub
    Public Sub actualizar(ByRef objTipoBodega As TipoBodega, ByVal usuario As Integer)
        Try
            Using Consulta As New SqlCommand("PROC_TIPO_BODEGA_ACTUALIZAR")
                Consulta.CommandType = CommandType.StoredProcedure
                Consulta.Connection = FormPrincipal.cnxion
                Consulta.Parameters.Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar))
                Consulta.Parameters("@DESCRIPCION").Value = objTipoBodega.nombre
                Consulta.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.NVarChar))
                Consulta.Parameters("@CODIGO").Value = objTipoBodega.codigo
                Consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.NVarChar))
                Consulta.Parameters("@USUARIO").Value = usuario
                Consulta.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        'If verificar_formulario(Bodega) = True Then
        '    Bodega.llenar_tipo_bodega()
        'End If
    End Sub
    Private Function verificar_formulario(form As Windows.Forms.Form) As Boolean
        Dim valor As Boolean = False
        For Each f As Windows.Forms.Form In Application.OpenForms
            If f.Name = form.Name Then
                valor = True
            End If
        Next
        Return valor
    End Function
End Class
