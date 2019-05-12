Imports System.Data.SqlClient

Public Class DocumentoContableDAL

    Public Sub crearDocumentoContable(objDocumentoContable As DocumentoContable, pUsuario As Integer)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_DOCUMENTO_CONTABLE_CREAR"

                dbCommand.Parameters.Add(New SqlParameter("@sigla", SqlDbType.NVarChar)).Value = objDocumentoContable.sigla
                dbCommand.Parameters.Add(New SqlParameter("@descripcion_documento", SqlDbType.NVarChar)).Value = objDocumentoContable.descripcion
                dbCommand.Parameters.Add(New SqlParameter("@usuario", SqlDbType.Int)).Value = pUsuario

                objDocumentoContable.codigo = CType(dbCommand.ExecuteScalar, String)
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub actualizarDocumentoContable(objDocumentoContable As DocumentoContable, pUsuario As Integer)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_DOCUMENTO_CONTABLE_ACTUALIZAR"

                dbCommand.Parameters.Add(New SqlParameter("@codigo_documento", SqlDbType.Int)).Value = objDocumentoContable.codigo
                dbCommand.Parameters.Add(New SqlParameter("@sigla", SqlDbType.NVarChar)).Value = objDocumentoContable.sigla
                dbCommand.Parameters.Add(New SqlParameter("@descripcion_documento", SqlDbType.NVarChar)).Value = objDocumentoContable.descripcion
                dbCommand.Parameters.Add(New SqlParameter("@usuario", SqlDbType.Int)).Value = pUsuario
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

End Class
