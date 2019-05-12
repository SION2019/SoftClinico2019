Public Class ContratoLaboralDAL
    Public Function guardarContrato(ByRef contrato1 As Contrato)
        Try
            Using Consulta As New SqlCommand("PROC_CONTRATO_LABORAL_CREAR")
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction()
                    Consulta.Connection = FormPrincipal.cnxion
                    Consulta.Transaction = trnsccion
                    Consulta.CommandType = CommandType.StoredProcedure
                    Consulta.Parameters.Add(New SqlParameter("@ID_TERCERO", SqlDbType.Int)).Value = contrato1.idEmpleado
                    Consulta.Parameters.Add(New SqlParameter("@CODIGO_MIN", SqlDbType.Int)).Value = CInt(contrato1.codigoMinuta)
                    Consulta.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.NVarChar)).Value = contrato1.tipo
                    Consulta.Parameters.Add(New SqlParameter("@ID_empresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                    Consulta.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = contrato1.inicio
                    Consulta.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = contrato1.fin
                    Consulta.Parameters.Add(New SqlParameter("@AUXTRANS", SqlDbType.Int)).Value = CDbl(contrato1.auxilio)
                    Consulta.Parameters.Add(New SqlParameter("@SALARIO", SqlDbType.Int)).Value = CDbl(contrato1.salario)
                    Consulta.Parameters.Add(New SqlParameter("@USUARIO_CREACION", SqlDbType.NVarChar)).Value = SesionActual.idUsuario
                    Consulta.Parameters.Add(New SqlParameter("@ID_EMPRESA_NOM", SqlDbType.Int)).Value = contrato1.idEmpresaPagar
                    Consulta.Parameters.Add(New SqlParameter("@DIAS_PRUEBAS", SqlDbType.Int)).Value = contrato1.diasPrueba
                    Consulta.Parameters.Add(New SqlParameter("@Tabla", SqlDbType.Structured)).Value = contrato1.dtPunto
                    Consulta.Parameters.Add(New SqlParameter("@Numero_Grupo", SqlDbType.NVarChar)).Value = contrato1.numeroGrupo
                    Consulta.Parameters.Add(New SqlParameter("@Formacion", SqlDbType.NVarChar)).Value = contrato1.centro
                    Consulta.Parameters.Add(New SqlParameter("@sena", SqlDbType.Bit)).Value = contrato1.sena
                    Consulta.Parameters.Add(New SqlParameter("@NIT", SqlDbType.NVarChar)).Value = contrato1.nitCentro
                    Consulta.Parameters.Add(New SqlParameter("@DV", SqlDbType.NVarChar)).Value = contrato1.dvCentro
                    contrato1.codigo = Consulta.ExecuteScalar()
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
        Return contrato1
    End Function
    Public Function actualizarContrato(ByRef contrato1 As Contrato)
        Try
            Using Consulta As New SqlCommand("PROC_CONTRATO_LABORAL_ACTUALIZAR")
                Using trnsccion = FormPrincipal.cnxion.BeginTransaction()
                    Consulta.Connection = FormPrincipal.cnxion
                    Consulta.Transaction = trnsccion
                    Consulta.CommandType = CommandType.StoredProcedure
                    Consulta.Parameters.Add(New SqlParameter("@ID_CONTRATO", SqlDbType.Int)).Value = contrato1.codigo
                    Consulta.Parameters.Add(New SqlParameter("@ID_TERCERO", SqlDbType.Int)).Value = contrato1.idEmpleado
                    Consulta.Parameters.Add(New SqlParameter("@CODIGO_MIN", SqlDbType.Int)).Value = contrato1.codigoMinuta
                    Consulta.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.NVarChar)).Value = contrato1.tipo
                    Consulta.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = contrato1.inicio
                    Consulta.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = contrato1.fin
                    Consulta.Parameters.Add(New SqlParameter("@ID_empresa", SqlDbType.Int)).Value = SesionActual.idEmpresa
                    Consulta.Parameters.Add(New SqlParameter("@AUXTRANS", SqlDbType.Int)).Value = contrato1.auxilio
                    Consulta.Parameters.Add(New SqlParameter("@SALARIO", SqlDbType.Int)).Value = contrato1.salario
                    Consulta.Parameters.Add(New SqlParameter("@USUARIO_ACTUALIZACION", SqlDbType.Int)).Value = SesionActual.idUsuario
                    Consulta.Parameters.Add(New SqlParameter("@ID_EMPRESA_NOM", SqlDbType.Int)).Value = contrato1.idEmpresaPagar
                    Consulta.Parameters.Add(New SqlParameter("@DIAS_PRUEBAS", SqlDbType.Int)).Value = contrato1.diasPrueba
                    Consulta.Parameters.Add(New SqlParameter("@Tabla", SqlDbType.Structured)).Value = contrato1.dtPunto
                    Consulta.Parameters.Add(New SqlParameter("@Numero_Grupo", SqlDbType.NVarChar)).Value = contrato1.numeroGrupo
                    Consulta.Parameters.Add(New SqlParameter("@Formacion", SqlDbType.NVarChar)).Value = contrato1.centro
                    Consulta.Parameters.Add(New SqlParameter("@sena", SqlDbType.Bit)).Value = contrato1.sena
                    Consulta.Parameters.Add(New SqlParameter("@NIT", SqlDbType.NVarChar)).Value = contrato1.nitCentro
                    Consulta.Parameters.Add(New SqlParameter("@DV", SqlDbType.NVarChar)).Value = contrato1.dvCentro
                    Consulta.ExecuteNonQuery()
                    trnsccion.Commit()
                End Using
            End Using
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try

        Return contrato1
    End Function
    Public Function terminarContrato(ByVal codigo As String) As Boolean
        Try
            Using Consulta As New SqlCommand("PROC_CONTRATO_TERMINAR")
                Consulta.CommandType = CommandType.StoredProcedure
                Consulta.Connection = FormPrincipal.cnxion
                Consulta.Parameters.Add(New SqlParameter("@ID_CONTRATO", SqlDbType.Int))
                Consulta.Parameters("@ID_EMPLEADO").Value = CInt(codigo)
                Consulta.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.NVarChar))
                Consulta.Parameters("@USUARIO").Value = SesionActual.idUsuario
                Consulta.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            general.manejoErrores(ex) 
            Return False
        End Try
    End Function
    Public Function CargarSalarios() As DataTable
        Dim dt As New DataTable
        dt.Clear()
        Try
            Using Consulta = New SqlCommand("PROC_SALARIOS_BUSCAR")
                Consulta.CommandType = CommandType.StoredProcedure
                Consulta.Connection = FormPrincipal.cnxion
                Consulta.Parameters.Add(New SqlParameter("@Cadena", SqlDbType.NVarChar))
                Consulta.Parameters("@Cadena").Value = ""
                If Consulta.ExecuteNonQuery Then
                    Dim da As New SqlDataAdapter(Consulta)
                    da.Fill(dt)
                    Return dt
                Else
                    Return dt
                End If
            End Using
        Catch ex As Exception
            general.manejoErrores(ex) 
            Return dt
        End Try
        dt.Dispose()
    End Function
    Public Function cargarAuxTransporte() As DataTable
        Dim dt As New DataTable
        dt.Clear()
        Try
            Using Consulta = New SqlCommand("PROC_AUXTRANS_BUSCAR")
                Consulta.CommandType = CommandType.StoredProcedure
                Consulta.Connection = FormPrincipal.cnxion
                Consulta.Parameters.Add(New SqlParameter("@Cadena", SqlDbType.NVarChar))
                Consulta.Parameters("@Cadena").Value = ""
                If Consulta.ExecuteNonQuery Then
                    Dim da As New SqlDataAdapter(Consulta)
                    da.Fill(dt)
                    Return dt
                Else
                    Return dt
                End If
            End Using
        Catch ex As Exception
            general.manejoErrores(ex) 
            Return dt
        End Try
        dt.Dispose()
    End Function

    Public Shared Sub llenarDatosContratante(ByRef dtdatoscontratante As DataTable)
        Dim params As New List(Of String)
        Try
            params.Add(SesionActual.idEmpresa)
            General.llenarTabla("[PROC_CONTRATANTE_EMPLEADO]", params, dtdatoscontratante)
        Catch ex As Exception
            MsgBox("Error al cargar los datos del Contratante")
        End Try
    End Sub
    Public Shared Sub llenarDatosContratista(ByRef dtdatoscontratista As DataTable, idEmpleado As Integer)
        Dim params As New List(Of String)
        Try
            params.Add(idEmpleado)
            params.Add(SesionActual.idEmpresa)
            General.llenarTabla("[PROC_EMPLEADO_CONTRATO_MINUTA_CARGAR]", params, dtdatoscontratista)
        Catch ex As Exception
            MsgBox("Error al cargar los datos del Contratante")
        End Try
    End Sub
End Class
