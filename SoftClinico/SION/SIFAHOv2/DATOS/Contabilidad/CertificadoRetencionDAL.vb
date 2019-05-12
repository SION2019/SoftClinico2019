Public Class CertificadoRetencionDAL

    Public Shared Sub obtenerValorRetencion(params As CertificadoRetencionParams)
        Try
            Using dbCommand As New SqlCommand
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.CommandText = "PROC_E_CERTIFICADO_RETENCION_CARGAR"

                dbCommand.Parameters.Add(New SqlParameter("@id_empresa", SqlDbType.Int)).Value = params.idEmpresa
                dbCommand.Parameters.Add(New SqlParameter("@id_tercero", SqlDbType.Int)).Value = params.idTercero
                dbCommand.Parameters.Add(New SqlParameter("@fecha_inicio", SqlDbType.DateTime)).Value = params.fechaInicio
                dbCommand.Parameters.Add(New SqlParameter("@fecha_fin", SqlDbType.DateTime)).Value = params.fechaFin
                dbCommand.Parameters.Add(New SqlParameter("@resultado", SqlDbType.Bit))
                dbCommand.Parameters("@resultado").Direction = ParameterDirection.Output

                dbCommand.ExecuteNonQuery()

                params.resultado = dbCommand.Parameters("@resultado").Value
            End Using

        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
