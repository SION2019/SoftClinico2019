Imports System.Data.SqlClient
Imports System.IO
Public Class Form_minutas_c
    Public Function guardar_minuta(ByVal codigo_min As String, ByVal descripcion As String, ByRef form_minutas1 As Form_minutas) As String
        Dim codigo As String = ""
        Dim nwTmpFileUrl As String
        Dim doc As Byte()
        nwTmpFileUrl = Path.GetTempPath + DateTime.Now.Ticks.ToString + ".docx"
        form_minutas1.textminuta.document.SaveAs(nwTmpFileUrl)
        form_minutas1.limpiar_wrd()
        doc = File.ReadAllBytes(nwTmpFileUrl)
        form_minutas1.setTempfileurl(nwTmpFileUrl)
        Try
            If codigo_min = "" Then
                Using Consulta As New SqlCommand("SP_MINUTA_CREAR")
                    Consulta.CommandType = CommandType.StoredProcedure
                    Consulta.Connection = form_principal.cnxion
                    Consulta.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.NVarChar)).Value = descripcion
                    Consulta.Parameters.Add(New SqlParameter("@documento", SqlDbType.VarBinary, doc.Length)).Value = doc
                    Consulta.Parameters.Add(New SqlParameter("@longitud", SqlDbType.Int)).Value = doc.Length
                    Consulta.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.NVarChar)).Value = form_principal.usuarioActual
                    codigo = Consulta.ExecuteScalar

                End Using
            Else
                Using Consulta As New SqlCommand("SP_MINUTA_ACTUALIZAR")
                    Consulta.CommandType = CommandType.StoredProcedure
                    Consulta.Connection = form_principal.cnxion
                    Consulta.Parameters.Add(New SqlParameter("@codigo", SqlDbType.NVarChar)).Value = codigo_min
                    Consulta.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.NVarChar)).Value = descripcion
                    Consulta.Parameters.Add(New SqlParameter("@documento", SqlDbType.VarBinary, doc.Length)).Value = doc
                    Consulta.Parameters.Add(New SqlParameter("@longitud", SqlDbType.Int)).Value = doc.Length
                    Consulta.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.NVarChar)).Value = form_principal.usuarioActual
                    Consulta.ExecuteNonQuery()
                    codigo = codigo_min
                End Using
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return codigo
        codigo = Nothing
    End Function
    Public Function anular_minuta(ByVal codigo As String) As Boolean
        Try
            Using Consulta As New SqlCommand("SP_MINUTA_ANULAR")
                Consulta.CommandType = CommandType.StoredProcedure
                Consulta.Connection = form_principal.cnxion
                Consulta.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.Int))
                Consulta.Parameters("@CODIGO").Value = CInt(codigo)
                Consulta.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function
    Public Function llenar_info(codigo) As String
        Dim tempfileurl As String = ""

        Dim cadena As String = "select Documento from D_CONTRATO_MINUTA where Codigo_minuta='" + codigo + "'"





        Try
            Using consulta As New SqlCommand(cadena, form_principal.cnxion)
                tempfileurl = Path.GetTempPath + DateTime.Now.Ticks.ToString + ".docx"

                File.WriteAllBytes(tempfileurl, consulta.ExecuteScalar())
            End Using


            Return tempfileurl
        Catch ex As Exception
            Dim err As [String] = ex.Message
            Return ""
        End Try
    End Function


End Class
