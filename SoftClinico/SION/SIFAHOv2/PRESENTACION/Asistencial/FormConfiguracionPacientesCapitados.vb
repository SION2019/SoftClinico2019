Public Class FormConfiguracionPacientesCapitados
    Dim dtPacientes, dtCapitados, dtCodigosIdentificacion As New DataTable
    Dim ds As New DataSet
    Dim idEps As Integer
    Dim Cargando As FormCargando
    Dim segundoPlano As Threading.Thread
    Dim sw As Boolean
    Private Sub btTrasladarPacientes_Click(sender As Object, e As EventArgs) Handles btTrasladarPacientes.Click
        If dgvPacientes.Rows.Count > 0 Then
            btTrasladarPacientes.Visible = False
            If MsgBox("Este proceso pueder tardar unos minutos, Desea continuar", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
                segundoPlano = New Threading.Thread(AddressOf llenarTabla)
                segundoPlano.Start()
            End If
        End If
    End Sub

    Private Sub btImportar_Click(sender As Object, e As EventArgs) Handles btImportar.Click
        importarExcel(dgvPacientes)
        ds = dgvPacientes.DataSource
        If dgvPacientes.Rows.Count > 0 Then
            dtPacientes = ds.Tables("Datos").Copy
        End If
    End Sub
    Private Sub btbuscareps_Click(sender As Object, e As EventArgs) Handles btbuscareps.Click
        Dim params As New List(Of String)
        params.Add(Nothing)
        General.buscarElemento(Consultas.EPS_LISTAR,
                               params,
                               AddressOf cargarEPS,
                               TitulosForm.BUSQUEDA_EPS,
                               False, 0, True)

    End Sub
    Public Sub cargarEPS(pCodigo As String)
        Dim drFila As DataRow
        Dim params As New List(Of String)
        params.Add(pCodigo)
        drFila = General.cargarItem(Consultas.EPS_CARGAR, params)
        General.limpiarControles(Me)
        idEps = pCodigo
        TextnombreEps.Text = drFila.Item(0)
    End Sub
    Private Sub llenarTabla()

        For indice = 0 To dtPacientes.Rows.Count - 1
            If dtPacientes.Rows(indice).Item("DOCUMENTO").ToString <> "" Then
                Try
                    Using dbCommand As New SqlCommand
                        dbCommand.Connection = FormPrincipal.cnxion
                        dbCommand.CommandType = CommandType.StoredProcedure
                        dbCommand.CommandText = "PROC_PACIENTE_CAPITADO_CREAR"
                        dbCommand.Parameters.Add(New SqlParameter("@ID", SqlDbType.NVarChar)).Value = ""
                        dbCommand.Parameters.Add(New SqlParameter("@COD_INDENTI", SqlDbType.Int)).Value = consultarCodigoIdentificacion(dtPacientes.Rows(indice).Item("TIPO_DOC").ToString)
                        dbCommand.Parameters.Add(New SqlParameter("@DOC_PACIENTE", SqlDbType.NVarChar)).Value = dtPacientes.Rows(indice).Item("DOCUMENTO")
                        dbCommand.Parameters.Add(New SqlParameter("@COD_PAIS_EXP", SqlDbType.NVarChar)).Value = 1
                        dbCommand.Parameters.Add(New SqlParameter("@COD_DEPAR_EXP", SqlDbType.NVarChar)).Value = dtPacientes.Rows(indice).Item("DPTO")
                        dbCommand.Parameters.Add(New SqlParameter("@COD_MUN_EXP", SqlDbType.NVarChar)).Value = dtPacientes.Rows(indice).Item("MUN")
                        dbCommand.Parameters.Add(New SqlParameter("@FECHA_NAC", SqlDbType.Date)).Value = dtPacientes.Rows(indice).Item("FECHA_NAC")
                        dbCommand.Parameters.Add(New SqlParameter("@COD_PAIS_NAC", SqlDbType.NVarChar)).Value = 1
                        dbCommand.Parameters.Add(New SqlParameter("@COD_DEPAR_NAC", SqlDbType.NVarChar)).Value = dtPacientes.Rows(indice).Item("DPTO")
                        dbCommand.Parameters.Add(New SqlParameter("@COD_MUN_NAC", SqlDbType.NVarChar)).Value = dtPacientes.Rows(indice).Item("MUN")
                        dbCommand.Parameters.Add(New SqlParameter("@PAPELLIDO", SqlDbType.NVarChar)).Value = dtPacientes.Rows(indice).Item("P_APELLIDO")
                        dbCommand.Parameters.Add(New SqlParameter("@SAPELLIDO", SqlDbType.NVarChar)).Value = dtPacientes.Rows(indice).Item("S_APELLIDO")
                        dbCommand.Parameters.Add(New SqlParameter("@PNOMBRE", SqlDbType.NVarChar)).Value = dtPacientes.Rows(indice).Item("P_NOMBRE")
                        dbCommand.Parameters.Add(New SqlParameter("@SNOMBRE", SqlDbType.NVarChar)).Value = dtPacientes.Rows(indice).Item("S_NOMBRE")
                        'dbCommand.Parameters.Add(New SqlParameter("@COD_ESTADO", SqlDbType.Int)).Value = objPaciente.codEstadoCivil
                        dbCommand.Parameters.Add(New SqlParameter("@COD_GENERO", SqlDbType.Int)).Value = IIf(dtPacientes.Rows(indice).Item("SEXO") = "M", 0, 1)
                        dbCommand.Parameters.Add(New SqlParameter("@COD_EPS", SqlDbType.Int)).Value = idEps
                        'dbCommand.Parameters.Add(New SqlParameter("@COD_TIPO_AFIL", SqlDbType.Int)).Value = objPaciente.codTipoAfiliacion
                        'dbCommand.Parameters.Add(New SqlParameter("@COD_OCUPAC", SqlDbType.Int)).Value = objPaciente.codOcupacion
                        dbCommand.Parameters.Add(New SqlParameter("@COD_CLASE_SOC", SqlDbType.Int)).Value = 4
                        dbCommand.Parameters.Add(New SqlParameter("@COD_ZONA", SqlDbType.Int)).Value = IIf(dtPacientes.Rows(indice).Item("ZONA") = "U", 1, 2)
                        dbCommand.Parameters.Add(New SqlParameter("@DIRECCION", SqlDbType.NVarChar)).Value = IIf(dtPacientes.Rows(indice).Item("DIRECCION") = "", "No Registra", dtPacientes.Rows(indice).Item("DIRECCION"))
                        dbCommand.Parameters.Add(New SqlParameter("@COD_PAIS_RES", SqlDbType.NVarChar)).Value = 1
                        dbCommand.Parameters.Add(New SqlParameter("@COD_DEPAR_RES", SqlDbType.NVarChar)).Value = dtPacientes.Rows(indice).Item("DPTO")
                        dbCommand.Parameters.Add(New SqlParameter("@COD_MUN_RES", SqlDbType.NVarChar)).Value = dtPacientes.Rows(indice).Item("MUN")
                        'dbCommand.Parameters.Add(New SqlParameter("@TELEFONO", SqlDbType.NVarChar)).Value = objPaciente.telefonoPaciente
                        dbCommand.Parameters.Add(New SqlParameter("@CELULAR", SqlDbType.NVarChar)).Value = dtPacientes.Rows(indice).Item("TELEFONO")
                        dbCommand.Parameters.Add(New SqlParameter("@USUARIO_CREACION", SqlDbType.Int)).Value = SesionActual.idUsuario
                        'dbCommand.Parameters.Add(New SqlParameter("@CORREO", SqlDbType.NVarChar)).Value = objPaciente.correo
                        dbCommand.ExecuteNonQuery()
                    End Using
                Catch ex As Exception
                    Throw ex
                End Try
            End If
        Next
        btTrasladarPacientes.Visible = True
        MsgBox("Se han registrado " & dtPacientes.Rows.Count & " pacientes", MsgBoxStyle.Information)
    End Sub

    Private Sub llenarCodigoIdentificacion()
        Dim dt As New DataTable
        General.llenarTabla(Consultas.TIPO_IDENTIFICACION_LISTAR, Nothing, dtCodigosIdentificacion)
    End Sub

    Private Sub Label3_MouseHover(sender As Object, e As EventArgs) Handles Label3.MouseHover
        lbFormato.Visible = True
    End Sub

    Private Sub Label3_MouseLeave(sender As Object, e As EventArgs) Handles Label3.MouseLeave
        lbFormato.Visible = False
    End Sub

    Private Sub FormConfiguracionPacientesCapitados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCodigoIdentificacion()
    End Sub

    Private Function consultarCodigoIdentificacion(sigla As String)
        Dim results As DataRow = dtCodigosIdentificacion.Select("Sigla= '" & sigla & "'")(0)
        Return results(0)
    End Function

End Class