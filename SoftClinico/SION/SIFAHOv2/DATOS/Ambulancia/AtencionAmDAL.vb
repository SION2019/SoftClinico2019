Public Class AtencionAmDAL
    Public Shared Sub guardarAtencionAM(objAtencionAM As AtencionAM)
        Try
            Using comando = New SqlCommand()
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = objAtencionAM.sqlGuardarAtencionAM
                comando.Parameters.Add(New SqlParameter("@CodTrasPaciente", SqlDbType.NVarChar)).Value = objAtencionAM.codAtencion
                comando.Parameters.Add(New SqlParameter("@IdPaciente", SqlDbType.Int)).Value = objAtencionAM.identiPaciente
                comando.Parameters.Add(New SqlParameter("@IdServicio", SqlDbType.NVarChar)).Value = objAtencionAM.codigoSolicitudServicio
                comando.Parameters.Add(New SqlParameter("@IdContrato", SqlDbType.Int)).Value = CInt(objAtencionAM.codigoContrato)
                comando.Parameters.Add(New SqlParameter("@CodProcedimiento", SqlDbType.NVarChar)).Value = objAtencionAM.codProcedimiento
                comando.Parameters.Add(New SqlParameter("@TipoDia", SqlDbType.NChar)).Value = objAtencionAM.tipoDia
                comando.Parameters.Add(New SqlParameter("@CodTarifaTrip", SqlDbType.Int)).Value = CInt(objAtencionAM.idTripulacion)
                comando.Parameters.Add(New SqlParameter("@FechaSalida", SqlDbType.DateTime)).Value = objAtencionAM.salida
                comando.Parameters.Add(New SqlParameter("@FechaLlegada", SqlDbType.DateTime)).Value = objAtencionAM.llegada
                comando.Parameters.Add(New SqlParameter("@Observaciones", SqlDbType.NVarChar)).Value = objAtencionAM.observaciones
                comando.Parameters.Add(New SqlParameter("@FechaRetorno", SqlDbType.DateTime)).Value = objAtencionAM.retorno
                comando.Parameters.Add(New SqlParameter("@FechaRegreso", SqlDbType.DateTime)).Value = objAtencionAM.regreso
                comando.Parameters.Add(New SqlParameter("@KMSAdicionales", SqlDbType.Decimal)).Value = objAtencionAM.kmAdicional
                comando.Parameters.Add(New SqlParameter("@RecargoNocturno", SqlDbType.Bit)).Value = objAtencionAM.recargoNocturno
                comando.Parameters.Add(New SqlParameter("@HHAdicionales", SqlDbType.Decimal)).Value = objAtencionAM.cantidadHoraAdicional
                comando.Parameters.Add(New SqlParameter("@valorTraslado", SqlDbType.Decimal)).Value = objAtencionAM.valorTrasladoMasTarifa
                comando.Parameters.Add(New SqlParameter("@Total", SqlDbType.Decimal)).Value = objAtencionAM.valorTotalAtencion
                comando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Int)).Value = objAtencionAM.usuario
                comando.Parameters.Add(New SqlParameter("@IdTarifa", SqlDbType.Int)).Value = CInt(objAtencionAM.idTarifa)
                comando.Parameters.Add(New SqlParameter("@TablaTRI", SqlDbType.Structured)).Value = objAtencionAM.dtTablaTripulacion
                comando.Parameters.Add(New SqlParameter("@TablaLPre", SqlDbType.Structured)).Value = objAtencionAM.dtTablaDiagnostico
                objAtencionAM.codAtencion = CType(comando.ExecuteNonQuery, String) 'devuelve el codigo interno
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
