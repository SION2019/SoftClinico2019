Imports System.Data.SqlClient
Public Class ProgramCitaMedicaDAL

    Public Shared Sub guardarCitaMedica(objCita As ProgramCitaMedica)
        Try
            Using comando = New SqlCommand
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "PROC_PROGRAM_CITA_GUARDAR"
                comando.Parameters.Add(New SqlParameter("@ID_MEDICO", SqlDbType.NVarChar)).Value = objCita.codigoIdMedico
                comando.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.NVarChar)).Value = objCita.codigoAtencion
                comando.Parameters.Add(New SqlParameter("@IDENTIPACIENTE", SqlDbType.NVarChar)).Value = objCita.identipaciente
                comando.Parameters.Add(New SqlParameter("@FECHAATENCION", SqlDbType.DateTime)).Value = objCita.fecha
                comando.Parameters.Add(New SqlParameter("@Observacion", SqlDbType.NVarChar)).Value = objCita.observacion
                comando.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.Int)).Value = objCita.usuario
                comando.Parameters.Add(New SqlParameter("@Codigo_ep", SqlDbType.Int)).Value = SesionActual.codigoEP
                comando.Parameters.Add(New SqlParameter("@TablaPAR", SqlDbType.Structured)).Value = objCita.dtParaclinicosNuevo
                comando.Parameters.Add(New SqlParameter("@TablaPRO", SqlDbType.Structured)).Value = objCita.dtProcedimiento
                objCita.codigoAtencion = CType(comando.ExecuteScalar, Integer)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
