Imports System.Data.SqlClient

Public Class PucDAL

    Public Sub crearPUC(objPUC As Puc, pUsuario As Integer)

        Dim codigoPUC As String = Nothing

        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_PUC_CREAR"

                dbCommand.Parameters.Add(New SqlParameter("@ano", SqlDbType.Int)).Value = objPUC.ano
                dbCommand.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.NVarChar)).Value = objPUC.descripcion
                dbCommand.Parameters.Add(New SqlParameter("@activo", SqlDbType.Bit)).Value = objPUC.activo
                dbCommand.Parameters.Add(New SqlParameter("@Usuario_creacion", SqlDbType.Int)).Value = pUsuario
                objPUC.codigo = CType(dbCommand.ExecuteScalar, String)

            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub actualizarPUC(objPUC As Puc, pUsuario As Integer)

        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_PUC_ACTUALIZAR"

                'Parametros
                dbCommand.Parameters.Add(New SqlParameter("@codigo_puc", SqlDbType.Int)).Value = objPUC.codigo
                dbCommand.Parameters.Add(New SqlParameter("@ano", SqlDbType.Int)).Value = objPUC.ano
                dbCommand.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.NVarChar)).Value = objPUC.descripcion
                dbCommand.Parameters.Add(New SqlParameter("@activo", SqlDbType.Bit)).Value = objPUC.activo
                dbCommand.Parameters.Add(New SqlParameter("@Usuario_actualizacion", SqlDbType.Int)).Value = pUsuario

                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

End Class
