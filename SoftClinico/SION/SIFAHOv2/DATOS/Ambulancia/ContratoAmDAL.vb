Public Class ContratoAmDAL
    Public Shared Sub guardarContratoAM(objContratoAM As ContratosAM)
        Try
            Using comando = New SqlCommand()
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = objContratoAM.sqlGuardarContratoAM
                comando.Parameters.Add(New SqlParameter("@CodigoContrato ", SqlDbType.NVarChar)).Value = objContratoAM.codigoContrato
                comando.Parameters.Add(New SqlParameter("@IdEmpresa", SqlDbType.Int)).Value = objContratoAM.idEmpresa
                comando.Parameters.Add(New SqlParameter("@IdCliente", SqlDbType.Int)).Value = objContratoAM.idCliente
                comando.Parameters.Add(New SqlParameter("@IdEPS", SqlDbType.Int)).Value = objContratoAM.idEPS
                comando.Parameters.Add(New SqlParameter("@CodAdmin", SqlDbType.NVarChar)).Value = objContratoAM.codigoAdmin
                comando.Parameters.Add(New SqlParameter("@NumContrato", SqlDbType.NVarChar)).Value = objContratoAM.numContrato
                comando.Parameters.Add(New SqlParameter("@CodPais", SqlDbType.NVarChar)).Value = objContratoAM.codigoPais
                comando.Parameters.Add(New SqlParameter("@CodDpto", SqlDbType.NVarChar)).Value = objContratoAM.codigoDpto
                comando.Parameters.Add(New SqlParameter("@CodMun", SqlDbType.NVarChar)).Value = objContratoAM.codigoMunicipio
                comando.Parameters.Add(New SqlParameter("@IdResponsable", SqlDbType.Int)).Value = objContratoAM.idRepresentante
                comando.Parameters.Add(New SqlParameter("@NombreRep", SqlDbType.NVarChar)).Value = objContratoAM.NombreRep
                comando.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.Date)).Value = objContratoAM.fecha
                comando.Parameters.Add(New SqlParameter("@FechaVen", SqlDbType.Date)).Value = objContratoAM.fechaVencimento
                comando.Parameters.Add(New SqlParameter("@Plazo", SqlDbType.SmallInt)).Value = objContratoAM.plazo
                comando.Parameters.Add(New SqlParameter("@Estado", SqlDbType.Bit)).Value = objContratoAM.estado
                comando.Parameters.Add(New SqlParameter("@Observacion", SqlDbType.NVarChar)).Value = objContratoAM.Observaciones
                comando.Parameters.Add(New SqlParameter("@TCodREF", SqlDbType.Int)).Value = objContratoAM.TipoCodRef
                comando.Parameters.Add(New SqlParameter("@CodHA", SqlDbType.Int)).Value = objContratoAM.CodigoHA
                comando.Parameters.Add(New SqlParameter("@tabla", SqlDbType.Structured)).Value = objContratoAM.dtTraslados
                comando.Parameters.Add(New SqlParameter("@CodManual", SqlDbType.NVarChar)).Value = objContratoAM.codigoManual
                comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objContratoAM.Usuario
                objContratoAM.codigoContrato = CType(comando.ExecuteNonQuery, String) 'devuelve el codigo interno
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
