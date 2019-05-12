Imports System.Data.SqlClient
Public Class ProductoAsignacionDAL
    Public Function asignarProductos(ByVal tabla As DataTable, ByVal codigo_bodega As Integer) As Boolean
        Try
            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure

                    For i = 0 To tabla.Rows.Count - 1
                        consulta.Parameters.Clear()
                        consulta.CommandText = "[PROC_PRODUCTOS_ASIGNAR]"
                        consulta.Parameters.Add(New SqlParameter("@CODIGO_BODEGA", SqlDbType.NVarChar))
                        consulta.Parameters("@CODIGO_BODEGA").Value = codigo_bodega
                        consulta.Parameters.Add(New SqlParameter("@CODIGO_PRODUCTO", SqlDbType.NVarChar))
                        consulta.Parameters("@CODIGO_PRODUCTO").Value = tabla.Rows(i).Item("Codigo")
                        consulta.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.NVarChar))
                        consulta.Parameters("@Usuario").Value = SesionActual.idUsuario
                        consulta.ExecuteNonQuery()
                    Next

                    Try
                        trnsccion.Commit()
                        Return True
                    Catch ex As Exception
                        trnsccion.Rollback()
                        general.manejoErrores(ex) 
                        Return False

                    End Try
                End Using
            End Using

        Catch ex As Exception
            general.manejoErrores(ex) 
            Return False
        End Try
    End Function
    Public Function quitarProductos(ByRef objProductoBodega As AsignarProductosBodega, ByRef dt As DataTable) As Boolean
        Try
            Using consulta = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction
                    consulta.Connection = FormPrincipal.cnxion
                    consulta.Transaction = trnsccion
                    consulta.CommandType = CommandType.StoredProcedure

                    For i = 0 To dt.Rows.Count - 1
                        consulta.Parameters.Clear()
                        consulta.CommandText = "[PROC_PRODUCTOS_QUITAR]"
                        consulta.Parameters.Add(New SqlParameter("@codigo_Producto", SqlDbType.Int)).Value = dt.Rows(i).Item("Codigo")
                        consulta.Parameters.Add(New SqlParameter("@codigo_bodega", SqlDbType.Int)).Value = objProductoBodega.codigoBodega
                        consulta.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = SesionActual.idUsuario
                        consulta.ExecuteNonQuery()
                    Next

                    Try
                        trnsccion.Commit()
                        Return True
                    Catch ex As Exception
                        trnsccion.Rollback()
                        general.manejoErrores(ex) 
                        Return False

                    End Try
                End Using
            End Using

        Catch ex As Exception
            general.manejoErrores(ex) 
            Return False
        End Try
    End Function
End Class
