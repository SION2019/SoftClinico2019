Imports System.Data.SqlClient
Public Class ProductoCualidadDAL
    Public Function guardar_cualidad(ByVal codigo_in As String, ByVal descripcion As String) As String
        Dim codigo As String = ""
        Try
            If codigo_in = "" Then
                Using Consulta As New SqlCommand("PROC_CUALIDADES_CREAR")
                    Consulta.CommandType = CommandType.StoredProcedure
                    Consulta.Connection = FormPrincipal.cnxion
                    Consulta.Parameters.Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar))
                    Consulta.Parameters("@DESCRIPCION").Value = descripcion
                    Consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.NVarChar))
                    Consulta.Parameters("@USUARIO").Value = SesionActual.idUsuario
                    codigo = CType(Consulta.ExecuteScalar, String)
                End Using
            Else
                Using Consulta As New SqlCommand("PROC_CUALIDADES_ACTUALIZAR")
                    Consulta.CommandType = CommandType.StoredProcedure
                    Consulta.Connection = FormPrincipal.cnxion
                    Consulta.Parameters.Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar))
                    Consulta.Parameters("@DESCRIPCION").Value = descripcion
                    Consulta.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.NVarChar))
                    Consulta.Parameters("@CODIGO").Value = codigo_in
                    Consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.NVarChar))
                    Consulta.Parameters("@USUARIO").Value = SesionActual.idUsuario
                    Consulta.ExecuteNonQuery()
                    codigo = codigo_in
                End Using
            End If
            If verificar_formulario(Equivalencia) = True Then
                General.cargarCombo(Consultas.CUALIDADES_LISTAR, "", "", Equivalencia.Combocualidad)
            End If
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try

        Return codigo
    End Function
    Public Function anular_cualidad(ByVal codigo As String) As Boolean
        Try
            Using Consulta As New SqlCommand("PROC_CUALIDADES_ANULAR")
                Consulta.CommandType = CommandType.StoredProcedure
                Consulta.Connection = FormPrincipal.cnxion
                Consulta.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.Int))
                Consulta.Parameters("@CODIGO").Value = CInt(codigo)
                Consulta.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.NVarChar))
                Consulta.Parameters("@Usuario").Value = SesionActual.idUsuario
                Consulta.ExecuteNonQuery()
            End Using
            If verificar_formulario(Equivalencia) = True Then
                General.cargarCombo(Consultas.CUALIDADES_LISTAR, "", "", Equivalencia.Combocualidad)
            End If

            Return True
        Catch ex As Exception
            general.manejoErrores(ex) 
            Return False
        End Try
    End Function

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
