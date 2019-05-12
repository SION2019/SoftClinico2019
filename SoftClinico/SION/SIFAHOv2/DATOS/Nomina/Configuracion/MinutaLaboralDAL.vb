Imports System.Data.SqlClient
Imports System.IO
Public Class MinutaLaboralDAL
    Public Sub guardar_minuta(ByRef form_minutas1 As Form_minutas)
        Try
            If form_minutas1.Txtcodigo.Text = "" Then
                Using Consulta As New SqlCommand("PROC_MINUTA_CREAR")
                    Consulta.CommandType = CommandType.StoredProcedure
                    Consulta.Connection = FormPrincipal.cnxion
                    Consulta.Parameters.Add(New SqlParameter("@Tipo", SqlDbType.NVarChar)).Value = form_minutas1.combotipo.SelectedValue
                    Consulta.Parameters.Add(New SqlParameter("@Activo", SqlDbType.Bit)).Value = form_minutas1.chActivo.Checked
                    Consulta.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.NVarChar)).Value = form_minutas1.TextNombre.Text
                    Consulta.Parameters.Add(New SqlParameter("@documento", SqlDbType.NVarChar)).Value = form_minutas1.rbTextMinuta.Rtf
                    Consulta.Parameters.Add(New SqlParameter("@longitud", SqlDbType.Int)).Value = 0
                    Consulta.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.NVarChar)).Value = SesionActual.idUsuario

                    form_minutas1.Txtcodigo.Text = Consulta.ExecuteScalar
                End Using
            Else
                Using Consulta As New SqlCommand("PROC_MINUTA_ACTUALIZAR")
                    Consulta.CommandType = CommandType.StoredProcedure
                    Consulta.Connection = FormPrincipal.cnxion
                    Consulta.Parameters.Add(New SqlParameter("@codigo", SqlDbType.NVarChar)).Value = form_minutas1.Txtcodigo.Text
                    Consulta.Parameters.Add(New SqlParameter("@Tipo", SqlDbType.NVarChar)).Value = form_minutas1.combotipo.SelectedValue
                    Consulta.Parameters.Add(New SqlParameter("@Activo", SqlDbType.Bit)).Value = form_minutas1.chActivo.Checked
                    Consulta.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.NVarChar)).Value = form_minutas1.TextNombre.Text
                    Consulta.Parameters.Add(New SqlParameter("@documento", SqlDbType.NVarChar)).Value = form_minutas1.rbTextMinuta.Rtf
                    Consulta.Parameters.Add(New SqlParameter("@longitud", SqlDbType.Int)).Value = 0
                    Consulta.Parameters.Add(New SqlParameter("@Usuario_actualizacion", SqlDbType.NVarChar)).Value = SesionActual.idUsuario
                    Consulta.ExecuteNonQuery()
                End Using
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Function anular_minuta(ByRef codigo As TextBox)
        Try
            Using Consulta As New SqlCommand("PROC_MINUTA_ANULAR")
                Consulta.CommandType = CommandType.StoredProcedure
                Consulta.Connection = FormPrincipal.cnxion
                Consulta.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.Int))
                Consulta.Parameters("@CODIGO").Value = CInt(codigo.Text)
                Consulta.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
