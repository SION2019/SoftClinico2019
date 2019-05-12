Imports System.Data.SqlClient
Public Class FormDuplicarHistoria
    Dim objDuplicarHistoria As DuplicarHistoriaClinica
    Dim navegadorDatos As New BindingSource
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, PBuscarPaciente, PDuplicar As String
    Dim objFormCargado As FormCargando
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btbuscarpaciente_Click(sender As Object, e As EventArgs) Handles btbuscarpaciente.Click
        Dim params As New List(Of String)
        If SesionActual.tienePermiso(PBuscarPaciente) Then
            params.Add(String.Empty)
            params.Add(SesionActual.codigoEP)
            General.limpiarControles(Me)
            dgvFactura.Enabled = True
            objDuplicarHistoria.bdraIdentificaDestino = True
            General.buscarElemento(objDuplicarHistoria.sqlBuscarAdmision,
                                   params,
                                   AddressOf cargarAdmision,
                                   TitulosForm.BUSQUEDA_ADMISION,
                                   False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub
    Private Sub cargarAdmision(pCodigoAdmis As Integer)
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(pCodigoAdmis)
        Try
            dFila = General.cargarItem(objDuplicarHistoria.sqlCargarAdmision, params)
            If Not IsNothing(dFila) Then
                If objDuplicarHistoria.bdraIdentificaDestino = True Then
                    objDuplicarHistoria.RegistroDestino = pCodigoAdmis
                    cargarCamposAdmisiondDestino(dFila)
                    cargarFacturas()
                    objDuplicarHistoria.bdraIdentificaDestino = False
                Else
                    objDuplicarHistoria.RegistroOrigen = pCodigoAdmis
                    cargarCamposAdmisionOrigen(dFila)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cargarFacturas()
        Dim params As New List(Of String)
        Try
            params.Add(objDuplicarHistoria.idGenero)
            params.Add(objDuplicarHistoria.idArea)
            General.llenarTabla(objDuplicarHistoria.sqlCargarFactura, params, objDuplicarHistoria.dtFactura)
            navegadorDatos.DataSource = objDuplicarHistoria.dtFactura
            dgvFactura.DataSource = navegadorDatos.DataSource
            formatoGilla()
            btcancelar.Enabled = True
            txtBuscar.ReadOnly = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub formatoGilla()
        With dgvFactura
            .Columns("Registro").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("paciente").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Fecha").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("EPS").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Valor").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Registro").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns("paciente").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("EPS").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("Fecha").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns("Valor").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns("Valor").DefaultCellStyle.Format = "C2"
        End With
    End Sub
    Private Sub cargarCamposAdmisionOrigen(dFila As DataRow)
        TxtRegistroOrigen.Text = objDuplicarHistoria.RegistroOrigen
        txtidentiOrigen.Text = dFila.Item("Documento_paciente")
        txtpacienteOrigen.Text = dFila.Item("Paciente")
        txtFechaOrigen.Text = dFila.Item("Fecha_Admision")
        txtGeneroOrigen.Text = dFila.Item("Genero")
        txtAreaOrigen.Text = dFila.Item("Area_Servicio")
        txtEdadOrigen.Text = dFila.Item("Edad")
    End Sub
    Private Sub cargarCamposAdmisiondDestino(dFila As DataRow)
        TxtRegistroDestino.Text = objDuplicarHistoria.RegistroDestino
        txtidentiDestino.Text = dFila.Item("Documento_paciente")
        txtpacienteDestino.Text = dFila.Item("Paciente")
        txtFechaDestino.Text = dFila.Item("Fecha_Admision")
        txtGeneroDestino.Text = dFila.Item("Genero")
        txtAreaDestino.Text = dFila.Item("Area_Servicio")
        txtEdadDestino.Text = dFila.Item("Edad")
        txtAdministradora.Text = dFila.Item("EPS")
        objDuplicarHistoria.idGenero = dFila.Item("Codigo_Genero")
        objDuplicarHistoria.idArea = dFila.Item("Codigo_Area_Servicio")
    End Sub
    Private Sub FormDuplicarHistoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        permiso_general = perG.buscarPermisoGeneral(Name)
        PBuscarPaciente = permiso_general & "pp" & "01"
        PDuplicar = permiso_general & "pp" & "02"
        objDuplicarHistoria = New DuplicarHistoriaClinica
        General.deshabilitarControles(Me)
        btbuscarpaciente.Enabled = True
    End Sub
    Private Sub dgvFactura_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFactura.CellClick
        Dim dtFila As New DataView
        If objDuplicarHistoria.dtFactura.Rows.Count > 0 Then
            dtFila = navegadorDatos.DataSource.DefaultView()
            cargarAdmision(dtFila.ToTable.Rows(dgvFactura.CurrentCell.RowIndex).Item("Registro"))
            btDuplicar.Enabled = True
        End If
    End Sub
    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                navegadorDatos.Filter = "Registro Like '%" & txtBuscar.Text &
                                        "%' OR Paciente Like '%" & txtBuscar.Text &
                                        "%' OR EPS LIKE '%" & txtBuscar.Text & "%'"
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub btDuplicar_Click(sender As Object, e As EventArgs) Handles btDuplicar.Click
        Try
            If SesionActual.tienePermiso(PDuplicar) Then
                If validarCampos() = True Then
                    If MsgBox(Mensajes.DUPLICAR, 32 + 1, TitulosForm.DUPLICAR) = 1 Then

                        objFormCargado = New FormCargando
                        objFormCargado.Show()
                        Dim segundoPlano As System.Threading.Thread
                        segundoPlano = New Threading.Thread(AddressOf guardarSegundoPlano)
                        segundoPlano.Start()
                    End If
                End If
            Else
                MsgBox(Mensajes.SINPERMISO)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub guardarSegundoPlano()
        Dim params As New List(Of String)
        Dim respuesta As String

        Me.Cursor = Cursors.WaitCursor

        params.Add(objDuplicarHistoria.RegistroOrigen)
        params.Add(objDuplicarHistoria.RegistroDestino)
        respuesta = General.getValorConsulta(objDuplicarHistoria.sqlDuplicar, params)
        objFormCargado.Dispose()

        If Not String.IsNullOrEmpty(respuesta) _
            AndAlso respuesta = 0 Then
            General.deshabilitarBotones(ToolStrip1)
            dgvFactura.Enabled = False
            btimprimir.Enabled = True
            btbuscarpaciente.Enabled = True
            MsgBox("Registro duplicado, con ¡ Exito !", MsgBoxStyle.Information)
        Else
            MsgBox("Ocurrio un problema, no se pudo duplicar; La historia Clinica", MsgBoxStyle.Critical)
        End If

        Me.Cursor = Cursors.Default
    End Sub
    Private Function validarCampos() As Boolean
        Dim bandera As Boolean
        If IsNothing(TxtRegistroDestino.Text) Then
            MsgBox("¡ Favor Seleccionar la Admisión de Origén !", MsgBoxStyle.Exclamation)
            btbuscarpaciente.Focus()
        ElseIf IsNothing(TxtRegistroDestino.Text) Then
            MsgBox("¡ Favor Seleccionar la Admisión de Destino !", MsgBoxStyle.Exclamation)
            dgvFactura.Focus()
        Else
            bandera = True
        End If
        Return bandera
    End Function

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, 32 + 1, TitulosForm.CANCELAR) = 1 Then
            General.limpiarControles(Me)
            General.deshabilitarBotones(ToolStrip1)
            dgvFactura.Enabled = True
            btbuscarpaciente.Enabled = True
        End If
    End Sub
    Private Sub FormDuplicarHistoria_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If btDuplicar.Enabled = True Then
            e.Cancel = True
            MsgBox(Mensajes.CAMBIOS_SIN_GUARDAR, MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
End Class