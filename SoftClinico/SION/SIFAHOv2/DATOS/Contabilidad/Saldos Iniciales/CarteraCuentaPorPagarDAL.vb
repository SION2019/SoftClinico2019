Imports System.Data.SqlClient
Public Class CarteraCuentaPorPagarDAL
    Public Sub crearCarteraCXP(ByVal objcarteraCXP As CarteraCXP)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_CARTERA_CXP_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@carteracxp", SqlDbType.Structured)).Value = objcarteraCXP.dtCarteraP
                dbCommand.Parameters.Add(New SqlParameter("@detalle_carteracxp", SqlDbType.Structured)).Value = objcarteraCXP.dtCartera
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub actualizarCarteraCXP(ByVal objcarteraCXP As CarteraCXP)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_CARTERA_CXP_ACTUALIZAR"
                dbCommand.Parameters.Add(New SqlParameter("@comprobante", SqlDbType.NVarChar)).Value = objcarteraCXP.identificador
                dbCommand.Parameters.Add(New SqlParameter("@detalle_carteracxp", SqlDbType.Structured)).Value = objcarteraCXP.dtCartera
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
