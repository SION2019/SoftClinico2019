Imports System.Data.SqlClient
Imports System.IO
Public Class ManualUsuarioDAL

    Dim dt As New DataTable

    Public Function Cargar_opciones() As DataTable
        Dim cadena As String
        Dim dt2 As New DataTable

        Try
            cadena = "EXEC [PROC_MENU_CARGAR] "
            dt.Clear()
            dt2.Clear 
            dt.Columns.Add("Codigo_menu")
            dt.Columns.Add("Descripcion_menu")
            dt.Rows.Add("0", "---- seleccione ----")
            Using da = New SqlDataAdapter(cadena, FormPrincipal.cnxion)
                da.Fill(dt)
            End Using
            cadena = "EXEC [PROC_MENU_CARGAR_2] "
            Using da = New SqlDataAdapter(cadena, FormPrincipal.cnxion)
                da.Fill(dt2)
            End Using

            dt.Merge(dt2)
            dt2.Dispose()
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
        Return dt
        cadena = Nothing
        dt.Dispose()
    End Function

    Public Function subir(ruta As String, codigo As String) As Boolean
        Dim doc As Byte()
        Try
            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction()
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandText = "DELETE FROM A_MENU_MANUAL WHERE codigo_menu='" & codigo & "'"
                    consulta.ExecuteNonQuery()
                    consulta.CommandText = "Insert Into [A_MENU_MANUAL] (codigo_menu,archivo)Values(@codigo_menu,@archivo)"
                    doc = File.ReadAllBytes(ruta)
                    With consulta
                        .Parameters.Add(New SqlParameter("@codigo_menu", SqlDbType.NVarChar)).Value = codigo
                        .Parameters.Add(New SqlParameter("@archivo", SqlDbType.VarBinary, doc.Length)).Value = doc
                    End With
                    consulta.ExecuteNonQuery()
                    Try
                        trnsccion.Commit()
                        Return True
                    Catch ex As Exception
                        Try
                            trnsccion.Rollback()
                            Throw ex
                        Catch ex1 As Exception
                            Throw ex
                        End Try
                        Return False
                    End Try
                End Using
                doc = Nothing
            End Using
        Catch ex As Exception
            Throw ex
            Return False
        End Try


    End Function

    Public Shared Sub llamar_archivo(Nombre_form As String)

        Dim cadena As String
        Dim archivo As Byte()
        cadena = Consultas.BUSQUEDA_MANUAL_DEUSUARIO & "'" & Nombre_form & "'"
        archivo = Nothing
        Using da = New SqlCommand(cadena, FormPrincipal.cnxion)
            Using resultado = da.ExecuteReader
                If resultado.HasRows Then
                    resultado.Read()
                    archivo = resultado.Item("archivo")
                End If
            End Using
        End Using
        Dim cnd, ruta As String
        If IsNothing(archivo) OrElse IsDBNull(archivo) Then
            ruta = Mensajes.MENSAJE_MANUAL
        Else
            cnd = "Manual" & Nombre_form & ".pdf"
            ruta = System.IO.Path.GetTempPath() & cnd
            File.WriteAllBytes(ruta, archivo)
            archivo = Nothing
            Process.Start(ruta)
        End If
        cnd = Nothing
        cadena = Nothing
    End Sub

    Public Function cargar_manual(codigo As String) As String
        Dim cadena As String
        cadena = "select 'Este formulario ya tiene manual' archivo from [A_MENU_MANUAL] where Codigo_menu='" & codigo & "'"

        Using da = New SqlCommand(cadena, FormPrincipal.cnxion)
            Using resultado = da.ExecuteReader
                If resultado.HasRows Then
                    resultado.Read()
                    cadena = resultado.Item("archivo")
                Else cadena = ""
                End If
            End Using
        End Using

        Return cadena
        cadena = Nothing
    End Function


End Class
