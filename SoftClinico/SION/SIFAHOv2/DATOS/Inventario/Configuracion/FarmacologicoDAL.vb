Imports System.Data.SqlClient
Public Class FarmacologicoDAL

    Public Shared Sub guardarFarmacologico(objFarmaco As GrupoFarmaco)
        Try
            If String.IsNullOrEmpty(objFarmaco.codigo) Then

                Using comando = New SqlCommand
                    comando.CommandType = CommandType.StoredProcedure
                    comando.Connection = FormPrincipal.cnxion
                    comando.CommandText = "PROC_GRUPOFARMACOLOGICO_CREAR"
                    comando.Parameters.Add(New SqlParameter("@nombre", SqlDbType.NVarChar)).Value = objFarmaco.nombre
                    comando.Parameters.Add(New SqlParameter("@clinea", SqlDbType.Int)).Value = objFarmaco.combofarmaco
                    comando.Parameters.Add(New SqlParameter("@usuario_creacion", SqlDbType.Int)).Value = objFarmaco.usuario
                    objFarmaco.codigo = CType(comando.ExecuteScalar, Integer)
                End Using
            Else
                Using comando = New SqlCommand
                    comando.CommandType = CommandType.StoredProcedure
                    comando.Connection = FormPrincipal.cnxion
                    comando.CommandText = "PROC_GRUPOFARMACOLOGICO_ACTUALIZAR"
                    comando.Parameters.Add(New SqlParameter("@nombre", SqlDbType.NVarChar)).Value = objFarmaco.nombre
                    comando.Parameters.Add(New SqlParameter("@codigo_linea", SqlDbType.NVarChar)).Value = objFarmaco.combofarmaco
                    comando.Parameters.Add(New SqlParameter("@codigo_grupo", SqlDbType.Int)).Value = objFarmaco.codigo
                    comando.Parameters.Add(New SqlParameter("@usuario_actualizacion", SqlDbType.Int)).Value = objFarmaco.usuario
                    comando.ExecuteNonQuery()
                End Using
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
