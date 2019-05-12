Imports System.Data.SqlClient
Imports System.Data
Public Class RipsDAL


    Public Shared Sub ripsAmbulanciaAt(objRips As Rips)
        Try
            Using consulta = New SqlDataAdapter("PROC_RIPS_AMBULANCIA_AT", FormPrincipal.cnxion)
                consulta.SelectCommand.CommandType = CommandType.StoredProcedure
                consulta.SelectCommand.Parameters.Add(New SqlParameter("@idempresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                consulta.SelectCommand.Parameters.Add(New SqlParameter("@tabla", SqlDbType.Structured)).Value = objRips.dtNew
                consulta.Fill(objRips.dtDinamico)
                objRips.generarArchivosDinamicos()

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub





    Public Shared Sub ripsAmbulanciaUs(objRips As Rips)
        Try
            Using consulta = New SqlDataAdapter("PROC_RIPS_AMBULANCIA_US", FormPrincipal.cnxion)
                consulta.SelectCommand.CommandType = CommandType.StoredProcedure
                consulta.SelectCommand.Parameters.Add(New SqlParameter("@tabla", SqlDbType.Structured)).Value = objRips.dtNew
                consulta.Fill(objRips.dtDinamico)
                objRips.generarArchivosDinamicos()

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Public Shared Sub ripsAmbulanciaAf(objRips As Rips)
        Try
            Using consulta = New SqlDataAdapter("PROC_RIPS_AMBULANCIA_AF", FormPrincipal.cnxion)
                consulta.SelectCommand.CommandType = CommandType.StoredProcedure
                consulta.SelectCommand.Parameters.Add(New SqlParameter("@FECHA_EXP", SqlDbType.Date)).Value = objRips.fechaExp
                consulta.SelectCommand.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = objRips.fecha
                consulta.SelectCommand.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = objRips.fecha2
                consulta.SelectCommand.Parameters.Add(New SqlParameter("@idempresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                consulta.SelectCommand.Parameters.Add(New SqlParameter("@tabla", SqlDbType.Structured)).Value = objRips.dtNew
                consulta.Fill(objRips.dtDinamico)
                objRips.generarArchivosDinamicos()

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub configuracionDinamica(objRips As Rips)
        Try
            Using consulta = New SqlDataAdapter("PROC_RIPS_DINAMICO", FormPrincipal.cnxion)
                consulta.SelectCommand.CommandType = CommandType.StoredProcedure
                consulta.SelectCommand.Parameters.Add(New SqlParameter("@id_empresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                consulta.SelectCommand.Parameters.Add(New SqlParameter("@codigo_tipo_rip", SqlDbType.Int)).Value = objRips.codigoTipoRips
                consulta.SelectCommand.Parameters.Add(New SqlParameter("@codigogrupo", SqlDbType.Int)).Value = objRips.codigoGrupo
                consulta.SelectCommand.Parameters.Add(New SqlParameter("@tbl_factura", SqlDbType.Structured)).Value = objRips.dtNew
                consulta.SelectCommand.Parameters.Add(New SqlParameter("@ideps", SqlDbType.Int)).Value = objRips.idEPS
                consulta.Fill(objRips.dtDinamico)
                objRips.generarArchivosDinamicos()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Shared Sub configuracionGuardar(objRips As Rips, ByRef form As FormRips)
        Try
            Using comando = New SqlCommand("PROC_RIPS_CONFIGURACION_CREAR")
                comando.Connection = FormPrincipal.cnxion
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.Add(New SqlParameter("@codigogrupo", SqlDbType.Int)).Value = objRips.codigoGrupo
                comando.Parameters.Add(New SqlParameter("@descripcion", SqlDbType.NVarChar)).Value = objRips.descripcion
                comando.Parameters.Add(New SqlParameter("@codigorips", SqlDbType.Int)).Value = objRips.codigoTipoRips
                comando.Parameters.Add(New SqlParameter("@tabla", SqlDbType.Structured)).Value = objRips.dtListaConfigurada
                comando.Parameters.Add(New SqlParameter("@usuario", SqlDbType.Int)).Value = objRips.usuario
                objRips.codigoGrupo = CInt(comando.ExecuteScalar())

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
