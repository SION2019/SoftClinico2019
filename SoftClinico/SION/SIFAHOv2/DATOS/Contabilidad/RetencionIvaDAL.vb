Imports System.Data.SqlClient

Public Class RetencionIvaDAL

    Public Shared Sub crearRetencionIVA(ByVal objRetencionIVA As RetencionIVA, pUSuario As Integer)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_RETENCION_IVA_CREAR"

                'Parametros
                dbCommand.Parameters.Add(New SqlParameter("@codigo_puc", SqlDbType.Int)).Value = objRetencionIVA.codigoPUC
                dbCommand.Parameters.Add(New SqlParameter("@codigo_cuenta", SqlDbType.NVarChar)).Value = objRetencionIVA.codigoCuenta
                dbCommand.Parameters.Add(New SqlParameter("@base", SqlDbType.Float)).Value = objRetencionIVA.base
                dbCommand.Parameters.Add(New SqlParameter("@tasa", SqlDbType.Float)).Value = objRetencionIVA.tasa
                dbCommand.Parameters.Add(New SqlParameter("@observacion", SqlDbType.NVarChar)).Value = objRetencionIVA.observacion
                dbCommand.Parameters.Add(New SqlParameter("@usuario", SqlDbType.Int)).Value = pUSuario

                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

End Class
