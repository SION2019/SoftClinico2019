Public Class PlataformaDocDAL
    Public Shared Function guardarPlataformaDoc(objPlataformaDoc As PlataformaDoc)
        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction()
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.CommandType = CommandType.StoredProcedure
                    comando.CommandText = objPlataformaDoc.SqlGuardarPlataformaDoc
                    comando.Parameters.Add(New SqlParameter("@TablaDoc", SqlDbType.Structured)).Value = objPlataformaDoc.DtPlatformaDoc
                    comando.Parameters.Add(New SqlParameter("@TablaDocE", SqlDbType.Structured)).Value = objPlataformaDoc.DtEliminar
                    comando.Parameters.Add(New SqlParameter("@TablaDet", SqlDbType.Structured)).Value = objPlataformaDoc.DtPerfilAux
                    comando.Parameters.Add(New SqlParameter("@TablaMenu", SqlDbType.Structured)).Value = objPlataformaDoc.DtMenu
                    comando.Parameters.Add(New SqlParameter("@TablaMM", SqlDbType.Structured)).Value = objPlataformaDoc.DtMenuManual
                    comando.Parameters.Add(New SqlParameter("@TablaPerfilMenu", SqlDbType.Structured)).Value = objPlataformaDoc.DtPerfilMenu
                    comando.ExecuteNonQuery()
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objPlataformaDoc
    End Function
    Public Shared Function guardarPlataformaDocDesc(ObjPlataformaDoc As PlataformaDoc)
        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction()
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.CommandType = CommandType.StoredProcedure
                    comando.CommandText = ObjPlataformaDoc.SqlGuardarPlataformaDocDesc
                    comando.Parameters.Add(New SqlParameter("@NombreCategoria", SqlDbType.NVarChar)).Value = ObjPlataformaDoc.NomCategoria
                    Dim rowsAffected As Integer = comando.ExecuteNonQuery()
                    trnsccion.Commit()
                    If rowsAffected = 0 Then
                        MsgBox("LA CATEGORIA " & ObjPlataformaDoc.NomCategoria & " YA EXISTE...!", MsgBoxStyle.Exclamation)
                        ObjPlataformaDoc.BdAceptar = 3
                    End If
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return ObjPlataformaDoc
    End Function
End Class
