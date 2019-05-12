Imports System.Data.SqlClient
Public Class ContabilidadGeneralDAL
    Public Function crearContabilidadGeneral(ByVal objContaGeneral As ContabilidadGeneral, pUSuario As Integer) As String
        Try
            Using dbCommand As New SqlCommand
                objContaGeneral.comprobante = FuncionesContables.verificarConsecutivo(SesionActual.idEmpresa, objContaGeneral.codigoDocumento)
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_CONTABILIDAD_GENERAL_CREAR"
                dbCommand.Parameters.Add(New SqlParameter("@Comprobante", SqlDbType.NVarChar)).Value = objContaGeneral.comprobante
                dbCommand.Parameters.Add(New SqlParameter("@id_empresa", SqlDbType.Int)).Value = objContaGeneral.idEmpresa
                dbCommand.Parameters.Add(New SqlParameter("@id_tercero", SqlDbType.Int)).Value = objContaGeneral.idTercero
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_Recibo", SqlDbType.Date)).Value = objContaGeneral.fechaRecibo
                dbCommand.Parameters.Add(New SqlParameter("@detalle_contageneral", SqlDbType.Structured)).Value = objContaGeneral.dtCuentas
                dbCommand.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.Int)).Value = pUSuario
                objContaGeneral.comprobante = CType(dbCommand.ExecuteScalar, String)
                FuncionesContables.aumentarConsecutivo(objContaGeneral.idEmpresa, objContaGeneral.codigoDocumento)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return objContaGeneral.comprobante
    End Function

    Public Sub actualizarContabilidadGeneral(ByVal objContaGeneral As ContabilidadGeneral, pUSuario As Integer)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_CONTABILIDAD_GENERAL_ACTUALIZAR"
                dbCommand.Parameters.Add(New SqlParameter("@Comprobante", SqlDbType.NVarChar)).Value = objContaGeneral.comprobante
                dbCommand.Parameters.Add(New SqlParameter("@Fecha_Recibo", SqlDbType.Date)).Value = objContaGeneral.fechaRecibo
                dbCommand.Parameters.Add(New SqlParameter("@detalle_contageneral", SqlDbType.Structured)).Value = objContaGeneral.dtCuentas
                dbCommand.Parameters.Add(New SqlParameter("@Usuario_Creacion", SqlDbType.Int)).Value = pUSuario
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
