Imports System.Data.SqlClient
Public Class CajaBancoDAL
    Public Function crearCajaBanco(ByVal objcajaBanco As CajaBanco, pUSuario As Integer) As String
        Try
            Using dbCommand As New SqlCommand
                objcajaBanco.comprobante = FuncionesContables.verificarConsecutivo(SesionActual.idEmpresa, objcajaBanco.codigoDocumento)
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_CAJA_BANCO_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@Comprobante", SqlDbType.NVarChar)).Value = objcajaBanco.comprobante
                dbCommand.Parameters.Add(New SqlParameter("@id_empresa", SqlDbType.Int)).Value = objcajaBanco.idEmpresa
                dbCommand.Parameters.Add(New SqlParameter("@id_tercero", SqlDbType.Int)).Value = objcajaBanco.idTercero
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_Recibo", SqlDbType.Date)).Value = objcajaBanco.fechaRecibo
                dbCommand.Parameters.Add(New SqlParameter("@detalle_mov", SqlDbType.NVarChar)).Value = objcajaBanco.detalleMov
                dbCommand.Parameters.Add(New SqlParameter("@detalle_cajaBanco", SqlDbType.Structured)).Value = objcajaBanco.dtCuentas
                dbCommand.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.Int)).Value = pUSuario
                objcajaBanco.comprobante = CType(dbCommand.ExecuteScalar, String)
                FuncionesContables.aumentarConsecutivo(objcajaBanco.idEmpresa, objcajaBanco.codigoDocumento)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objcajaBanco.comprobante
    End Function

    Public Sub actualizarCajaBanco(ByVal objcajaBanco As CajaBanco, pUSuario As Integer)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_CAJA_BANCO_ACTUALIZAR"
                dbCommand.Parameters.Add(New SqlParameter("@Comprobante", SqlDbType.NVarChar)).Value = objcajaBanco.comprobante
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_Recibo", SqlDbType.Date)).Value = objcajaBanco.fechaRecibo
                dbCommand.Parameters.Add(New SqlParameter("@detalle_mov", SqlDbType.NVarChar)).Value = objcajaBanco.detalleMov
                dbCommand.Parameters.Add(New SqlParameter("@detalle_cajaBanco", SqlDbType.Structured)).Value = objcajaBanco.dtCuentas
                dbCommand.Parameters.Add(New SqlParameter("@Usuario_Actualizacion", SqlDbType.Int)).Value = pUSuario
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
