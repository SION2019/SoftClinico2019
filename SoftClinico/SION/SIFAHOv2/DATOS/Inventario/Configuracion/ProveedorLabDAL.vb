Public Class ProveedorLabDAL
    Public Shared Function guardarProveedorLab(objPorveedorLab As ProveedorLab) As ProveedorLab
        Try
            Using comando = New SqlCommand()
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction()
                    comando.Connection = FormPrincipal.cnxion
                    comando.Transaction = trnsccion
                    comando.CommandType = CommandType.StoredProcedure
                    comando.Parameters.Clear()
                    comando.CommandText = "[PROC_PROVEEDOR_LAB_CREAR]"
                    comando.Parameters.Add(New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)).Value = objPorveedorLab.codigo
                    comando.Parameters.Add(New SqlParameter("@CODIGO_MANUAL", SqlDbType.Int)).Value = objPorveedorLab.codigoManual
                    comando.Parameters.Add(New SqlParameter("@CODIGO_REF", SqlDbType.Int)).Value = objPorveedorLab.codigoReferencia
                    comando.Parameters.Add(New SqlParameter("@CODIGO_TARIF", SqlDbType.Int)).Value = objPorveedorLab.codigoTarifa
                    comando.Parameters.Add(New SqlParameter("@IDEMPRESA", SqlDbType.Int)).Value = SesionActual.idEmpresa
                    comando.ExecuteNonQuery()
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objPorveedorLab
    End Function
End Class
