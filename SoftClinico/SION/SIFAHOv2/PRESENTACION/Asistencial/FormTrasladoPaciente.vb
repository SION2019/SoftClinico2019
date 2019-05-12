Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Graphics
Public Class FormTrasladoPaciente
    Dim objTrasladoPaciente As TrasladoPacienteSede
    Dim perG As New Buscar_Permisos_generales
    Dim permiso_general, PBuscarPaciente, PBuscarPacienteTodos, PTrasladar As String
    Dim segundoPlano As Threading.Thread
    'Dim objFormCargado As FormCargando
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub btbuscarpaciente_Click(sender As Object, e As EventArgs) Handles btbuscarpaciente.Click
        Dim params As New List(Of String)
        If SesionActual.tienePermiso(PBuscarPaciente) Then
            params.Add(String.Empty)
            params.Add(SesionActual.codigoEP)
            General.buscarElemento(objTrasladoPaciente.sqlBuscarAdmision,
                                   params,
                                   AddressOf cargarAdmision,
                                   TitulosForm.BUSQUEDA_ADMISION,
                                   False, 0, True)
        Else
            MsgBox(Mensajes.SINPERMISO)
        End If
    End Sub
    Private Sub btTodos_Click(sender As Object, e As EventArgs) Handles btTodos.Click
        Dim params As New List(Of String)
        If SesionActual.tienePermiso(PBuscarPacienteTodos) Then
            params.Add(String.Empty)
            params.Add(SesionActual.codigoEP)
            General.buscarElemento(objTrasladoPaciente.sqlBuscarAdmisionTodos,
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
            General.limpiarControles(Me)
            dFila = General.cargarItem(objTrasladoPaciente.sqlCargarAdmision, params)
            If Not IsNothing(dFila) Then
                objTrasladoPaciente.Registro = pCodigoAdmis
                cargarCamposAdmisiondDestino(dFila)
                General.habilitarControles(Me)
                General.deshabilitarControles(Groupdatos)
                txtcontrato.ReadOnly = True
                btbuscarpaciente.Enabled = True
                btTodos.Enabled = True
                cargarComboEmpresa()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cargarCamposAdmisiondDestino(dFila As DataRow)
        TxtRegistro.Text = objTrasladoPaciente.Registro
        txtidenti.Text = dFila.Item("Documento_paciente")
        txtpaciente.Text = dFila.Item("Paciente")
        txtFecha.Text = dFila.Item("Fecha_Admision")
        txtGenero.Text = dFila.Item("Genero")
        txtArea.Text = If(IsDBNull(dFila.Item("Area_Servicio")), String.Empty, dFila.Item("Area_Servicio"))
        txtEdad.Text = dFila.Item("Edad")
        txtEstado.Text = dFila.Item("Atencion")
        txtAdministradora.Text = dFila.Item("EPS")
        objTrasladoPaciente.idEPS = dFila.Item("Id_EPS")
        objTrasladoPaciente.idArea = dFila.Item("Codigo_Area_Servicio")
    End Sub
    Private Sub FormDuplicarHistoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        permiso_general = perG.buscarPermisoGeneral(Name)
        PBuscarPaciente = permiso_general & "pp" & "01"
        PTrasladar = permiso_general & "pp" & "02"
        PBuscarPacienteTodos = permiso_general & "pp" & "03"
        objTrasladoPaciente = New TrasladoPacienteSede
        cargarComboEmpresa()
        cargarComboPunto()
        cargarComboArea()
        cargarComboCama()
        General.deshabilitarControles(Me)
        btbuscarpaciente.Enabled = True
        btTodos.Enabled = True
    End Sub
    Private Sub cargarComboEmpresa()
        General.cargarCombo(Consultas.CONSULTAR_SEDES_TRASLADO, Nothing, "Razón Social", "Id_empresa", cbEmpresa)
    End Sub
    Private Sub cargarComboPunto()
        If Not String.IsNullOrEmpty(cbEmpresa.ValueMember) Then
            Dim params As New List(Of String)
            params.Add(cbEmpresa.SelectedValue.ToString)
            params.Add(SesionActual.codigoEP)
            General.cargarCombo(Consultas.CONSULTAR_PUNTO_TRASLADO, params, "Nombre", "Codigo_EP", cbPuntoServicio)
        End If
    End Sub
    Private Sub cargarComboArea()
        Dim params As New List(Of String)
        If Not String.IsNullOrEmpty(txtcodigocontrato.Text) Then
            params.Add(String.Empty)
            params.Add(cbPuntoServicio.SelectedValue.ToString)
            params.Add(String.Empty)
            params.Add(txtcodigocontrato.Text)
            params.Add(String.Empty)
            General.cargarCombo(Consultas.CONSULTAR_AREA_TRASLADO, params, "Descripción", "Código", cbAreaServicio)
        End If
    End Sub
    Private Sub cargarComboCama()
        Dim params As New List(Of String)
        If cbAreaServicio.ValueMember <> String.Empty Then
            params.Add(cbAreaServicio.SelectedValue.ToString)
            params.Add(cbPuntoServicio.SelectedValue.ToString)
            General.cargarCombo(Consultas.CONSULTAR_CAMA_TRASLADO, params, "Cama", "id", cbCama)
        End If
    End Sub
    Private Sub cargarObjeto()
        objTrasladoPaciente.idSede = cbEmpresa.SelectedValue
        objTrasladoPaciente.idPunto = cbPuntoServicio.SelectedValue
        objTrasladoPaciente.idContrato = txtcodigocontrato.Text
        objTrasladoPaciente.idArea = cbAreaServicio.SelectedValue
        objTrasladoPaciente.idCama = cbCama.SelectedValue
    End Sub
    Private Sub btTraslado_Click(sender As Object, e As EventArgs) Handles btTraslado.Click
        Dim params As New List(Of String)
        Try
            If SesionActual.tienePermiso(PTrasladar) Then
                If validarCampos() = True Then
                    If MsgBox(Mensajes.TRASLADO_PACIENTE, 32 + 1, TitulosForm.TRASLADO_PACIENTE) = 1 Then
                        Me.Cursor = Cursors.WaitCursor
                        cargarObjeto()
                        'objFormCargado = New FormCargando
                        'objFormCargado.Show()
                        'segundoPlano = New Threading.Thread(AddressOf trasladarPacienteSede)
                        trasladarPacienteSede()
                        'segundoPlano.Start()
                    End If
                End If
            Else
                MsgBox(Mensajes.SINPERMISO)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub trasladarPacienteSede()
        General.deshabilitarBotones(ToolStrip1)
        General.deshabilitarControles(Me)
        TrasladoPacienteBLL.traslado(objTrasladoPaciente)
        'objFormCargado.Dispose()
        If objTrasladoPaciente.respuesta = Constantes.PENDIENTE AndAlso
            Not IsNothing(objTrasladoPaciente.respuesta) Then
            btbuscarpaciente.Enabled = True
            MsgBox("Registro trasladado con exito, registro del destinatario: " & objTrasladoPaciente.registroDestino, MsgBoxStyle.Information)
        Else
            MsgBox("Ocurrio un problema, no se pudo trasladar; el paciente; Codigo error: " & objTrasladoPaciente.respuesta, MsgBoxStyle.Critical)
            General.habilitarControles(Me)
            General.deshabilitarControles(Groupdatos)
            txtcontrato.ReadOnly = True
            btbuscarpaciente.Enabled = True
            btTraslado.Enabled = True
            btcancelar.Enabled = True
        End If
    End Sub
    Private Function validarCampos() As Boolean
        Dim bandera As Boolean
        If IsNothing(TxtRegistro.Text) Then
            MsgBox("¡ Favor Seleccionar la Admisión de Origén !", MsgBoxStyle.Exclamation)
            btbuscarpaciente.Focus()
        ElseIf cbEmpresa.SelectedIndex = 0 Then
            MsgBox("¡ Favor Seleccionar la sede para trasladar el paciente !", MsgBoxStyle.Exclamation)
            cbEmpresa.Focus()
        ElseIf cbPuntoServicio.SelectedIndex = 0 Then
            MsgBox("¡ Favor Seleccionar el punto de servicio para trasladar el paciente !", MsgBoxStyle.Exclamation)
            cbPuntoServicio.Focus()
        ElseIf IsNothing(txtcodigocontrato.Text) Then
            MsgBox("¡ Favor Seleccionar el contrato para trasladar el paciente !", MsgBoxStyle.Exclamation)
            btBuscarContrato.Focus()
        ElseIf cbCama.SelectedIndex = 0 Then
            MsgBox("¡ Favor Seleccionar la cama disponible para trasladar el paciente !", MsgBoxStyle.Exclamation)
            cbCama.Focus()
        Else
            bandera = True
        End If
        Return bandera
    End Function

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, 32 + 1, TitulosForm.CANCELAR) = 1 Then
            General.limpiarControles(Me)
            General.deshabilitarControles(Me)
            General.deshabilitarBotones(ToolStrip1)
            btbuscarpaciente.Enabled = True
        End If
    End Sub
    Private Sub FormDuplicarHistoria_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If btTraslado.Enabled = True Then
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
    Private Sub btBuscarContrato_Click(sender As Object, e As EventArgs) Handles btBuscarContrato.Click
        Dim params As New List(Of String)
        params.Add(objTrasladoPaciente.idEPS)
        params.Add(cbPuntoServicio.SelectedValue.ToString)
        General.buscarElemento(Consultas.CONSULTAR_CONTRATO_TRASLADO,
                             params,
                             AddressOf cargarContrato,
                             TitulosForm.BUSQUEDA_CONTRATO,
                             False, 0, True)
    End Sub
    Private Sub cargarContrato(pCodigo As Integer)
        Dim dtContrato As New DataTable
        Dim params As New List(Of String)
        params.Add(pCodigo)
        params.Add(cbPuntoServicio.SelectedValue.ToString)
        General.llenarTabla(Consultas.CARGAR_CONTRATO_TRASLADO, params, dtContrato)
        If dtContrato.Rows.Count > 0 Then
            txtcodigocontrato.Text = pCodigo
            txtcontrato.Text = IIf(dtContrato.Rows(0).Item("Valor_Evento").ToString() > 0, "Evento", "Capitado") &
                               " - " & dtContrato.Rows(0).Item("CLIENTE").ToString()
            cargarComboArea()
        End If
    End Sub
    Private Sub cbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEmpresa.SelectedIndexChanged
        cargarComboPunto()
    End Sub
    Private Sub cbPuntoServicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPuntoServicio.SelectedIndexChanged
        If cbPuntoServicio.SelectedIndex <> 0 Then
            btBuscarContrato.Enabled = True
        Else
            btBuscarContrato.Enabled = False
        End If
    End Sub
    Private Sub cbAreaServicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAreaServicio.SelectedIndexChanged
        cargarComboCama()
    End Sub
    Private Sub cbCama_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCama.SelectedIndexChanged
        If cbCama.SelectedIndex = 0 Then
            btTraslado.Enabled = False
            btcancelar.Enabled = False
        Else
            btTraslado.Enabled = True
            btcancelar.Enabled = True
        End If
    End Sub
End Class