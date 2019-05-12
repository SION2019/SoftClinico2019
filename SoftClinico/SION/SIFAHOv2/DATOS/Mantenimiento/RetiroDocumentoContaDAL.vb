Imports System.Data.Sql
Public Class RetiroDocumentoContaDAL

    Public Shared Sub guardarDocumento(objDocumento As RetiroDocumento)
        Try
            Using comando = New SqlCommand
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = FormPrincipal.cnxion
                comando.CommandText = "PROC_RETIRO_DOCUMENTO_GUARDAR_ANULADO"
                comando.Parameters.Add(New SqlParameter("@observacion", SqlDbType.NVarChar)).Value = objDocumento.observacion
                comando.Parameters.Add(New SqlParameter("@comprobante", SqlDbType.NVarChar)).Value = objDocumento.comprobante
                comando.Parameters.Add(New SqlParameter("@usuario", SqlDbType.Int)).Value = objDocumento.usuario
                comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
