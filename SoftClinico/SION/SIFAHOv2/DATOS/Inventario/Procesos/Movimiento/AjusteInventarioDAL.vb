Imports System.Data.SqlClient
Public Class AjusteInventarioDAL

    Public Shared Sub guardarAjuste(ByRef objAjuste As AjusteInventario)
        Try
            Dim nombreTabla As String
            Using comando = New SqlCommand
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction

                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.CommandType = CommandType.StoredProcedure

                    comando.CommandText = "[PROC_AJUSTE_INVENTARIO_CREAR]"
                    comando.Parameters.Add(New SqlParameter("@codigobodega", SqlDbType.Int)).Value = objAjuste.codigoBodega
                    comando.Parameters.Add(New SqlParameter("@fechaajuste", SqlDbType.DateTime)).Value = objAjuste.fechaAjuste
                    comando.Parameters.Add(New SqlParameter("@usuario", SqlDbType.Int)).Value = objAjuste.usuario
                    objAjuste.codigoAjuste = CType(comando.ExecuteScalar, Integer)


                    For i = 0 To objAjuste.dtAjustes.Rows.Count - 2
                        nombreTabla = objAjuste.nombrarTabla(objAjuste.dtAjustes.Rows(i).Item("Codigo"), i)
                        If objAjuste.verificarExistenciaTabla(nombreTabla) Then

                            comando.CommandText = "[PROC_AJUSTE_INVENTARIO_CREAR_DETALLE]"
                            comando.Parameters.Clear()

                            comando.Parameters.Add(New SqlParameter("@codigoajuste", SqlDbType.NVarChar)).Value = objAjuste.codigoAjuste
                            comando.Parameters.Add(New SqlParameter("@codigobodega", SqlDbType.Int)).Value = objAjuste.codigoBodega
                            comando.Parameters.Add(New SqlParameter("@usuario", SqlDbType.Int)).Value = objAjuste.usuario
                            comando.Parameters.Add(New SqlParameter("@codigoProducto", SqlDbType.NVarChar)).Value = objAjuste.dtAjustes.Rows(i).Item("Codigo")

                            Dim dttmp As New DataTable
                            Dim filas As DataRow()

                            dttmp = objAjuste.tblLotes.Tables(nombreTabla).Clone
                            filas = objAjuste.tblLotes.Tables(nombreTabla).Select("Observacion <> ''")

                            For Each row As DataRow In filas
                                dttmp.ImportRow(row)
                            Next

                            comando.Parameters.Add(New SqlParameter("@tabla", SqlDbType.Structured)).Value = dttmp
                            comando.ExecuteNonQuery()

                        End If

                    Next
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
