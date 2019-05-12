Imports System.Data.SqlClient
Public Class AtencionLabDAL

    Public Shared Sub guardarAtencionLab(objAtencion As AtencionLaboratorio)
        Try
            Using comando = New SqlCommand
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "PROC_ATENCION_LABORATORIO_GUARDAR"
                comando.Parameters.Add(New SqlParameter("@CONTRATO", SqlDbType.NVarChar)).Value = objAtencion.codigoContrato
                comando.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.NVarChar)).Value = objAtencion.codigoAtencion
                comando.Parameters.Add(New SqlParameter("@IDENTIPACIENTE", SqlDbType.NVarChar)).Value = objAtencion.identipaciente
                comando.Parameters.Add(New SqlParameter("@FECHAATENCION", SqlDbType.DateTime)).Value = objAtencion.fecha
                comando.Parameters.Add(New SqlParameter("@Observacion", SqlDbType.NVarChar)).Value = objAtencion.observacion
                comando.Parameters.Add(New SqlParameter("@CODIGOEP", SqlDbType.Int)).Value = objAtencion.codigoEP
                comando.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.Int)).Value = objAtencion.usuario
                comando.Parameters.Add(New SqlParameter("@TablaPAR", SqlDbType.Structured)).Value = objAtencion.dtParaclinicosNuevo
                comando.Parameters.Add(New SqlParameter("@TablaPRO", SqlDbType.Structured)).Value = objAtencion.dtProcedimiento
                comando.Parameters.Add(New SqlParameter("@TablaHEM", SqlDbType.Structured)).Value = objAtencion.dtHemoderivados
                comando.Parameters.Add(New SqlParameter("@TablaMED", SqlDbType.Structured)).Value = objAtencion.dtMedicamentos
                comando.Parameters.Add(New SqlParameter("@TablaINS", SqlDbType.Structured)).Value = objAtencion.dtInsumo
                comando.Parameters.Add(New SqlParameter("@CODIGO_CITA", SqlDbType.Int)).Value = objAtencion.codigoCita
                objAtencion.codigoAtencion = CType(comando.ExecuteScalar, Integer)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub guardarDocumento(objAdmision As AtencionLaboratorio)
        Try
            Using dbCommand As New SqlCommand("PROC_DOCUMENTO_EXTERNO_GUARDAR")
                dbCommand.Parameters.Clear()
                dbCommand.CommandType = CommandType.StoredProcedure
                dbCommand.Connection = FormPrincipal.cnxion
                dbCommand.Parameters.Add(New SqlParameter("@codigoAtencion", SqlDbType.Int))
                dbCommand.Parameters("@codigoAtencion").Value = objAdmision.codigoAtencion
                dbCommand.Parameters.Add(New SqlParameter("@CODIGO_DOC", SqlDbType.Int))
                dbCommand.Parameters("@CODIGO_DOC").Value = objAdmision.tipoDocumento
                dbCommand.Parameters.Add(New SqlParameter("@IMAGEN", SqlDbType.VarBinary))
                dbCommand.Parameters("@IMAGEN").Value = objAdmision.imagen
                dbCommand.Parameters.Add(New SqlParameter("@EXTENSION", SqlDbType.NVarChar))
                dbCommand.Parameters("@EXTENSION").Value = objAdmision.extensionDoc
                dbCommand.Parameters.Add(New SqlParameter("@tipo", SqlDbType.NVarChar))
                dbCommand.Parameters("@tipo").Value = objAdmision.tipo
                dbCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
