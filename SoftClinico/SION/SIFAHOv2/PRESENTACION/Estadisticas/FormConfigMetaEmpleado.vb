Public Class FormConfigMetaEmpleado
    Dim perG As New Buscar_Permisos_generales
    Dim formPadre As New FormFacturacionPorEmpleados
    Dim permiso_general, Peditar As String
    Dim objConfigMeta As New ConfigMetaEmpleado

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        Try
            dgvEmpleado.EndEdit()
            dgvMetas.EndEdit()

            If validar() AndAlso MsgBox(Mensajes.GUARDAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.GUARDAR) = MsgBoxResult.Yes Then
                objConfigMeta.diaCorte = cbCorte.SelectedItem
                objConfigMeta.meta1 = numMetaHC.Value
                objConfigMeta.meta2 = numMetaAM.Value
                objConfigMeta.meta3 = numMetaAF.Value
                objConfigMeta.guardarMeta()
                MsgBox(Mensajes.GUARDADO, MsgBoxStyle.Information)
                formPadre.cargarEmpleadoMeta()
                Close()
            End If

        Catch ex As Exception
            General.manejoErrores(ex)
        End Try

    End Sub
    Private Function validar()
        If cbCorte.SelectedIndex < 1 Then
            MsgBox("¡Por favor seleccione el día de corte para cada periodo!", MsgBoxStyle.Exclamation)
            Return False
        Else
            For i = 0 To objConfigMeta.dtEmpleado.Rows.Count - 1
                If objConfigMeta.dtEmpleado.Rows(i).Item("metaSostenimiento") > 0 AndAlso objConfigMeta.dtEmpleado.Rows(i).Item("codigoContrato") < 0 Then
                    MsgBox("Por favor seleccione el contrato para: " & objConfigMeta.dtEmpleado.Rows(i).Item("empleado"), MsgBoxStyle.Exclamation)
                    Return False
                End If
            Next
        End If
        Return True
    End Function

    Private Sub cbCargo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCargo.SelectedIndexChanged
        If IsNumeric(cbCargo.SelectedValue) AndAlso Not IsNothing(objConfigMeta.dsEmpleado.DataSource) Then
            Dim cargo As String
            If cbCargo.SelectedIndex = 0 Then
                cargo = "SIN CARGO"
            Else
                If cbCargo.SelectedValue = Constantes.VALOR_PREDETERMINADO Then
                    cargo = ""
                Else
                    cargo = cbCargo.Text
                End If

            End If
                objConfigMeta.dsEmpleado.Filter = "[Cargo] LIKE '%" + cargo + "%'"
        End If


    End Sub

    Private Sub btcancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        If MsgBox(Mensajes.CANCELAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.CANCELAR) = MsgBoxResult.No Then
            Exit Sub
        End If
        General.deshabilitarControles(gbPrincipal)
        General.deshabilitarBotones(ToolStrip1)
        bteditar.Enabled = True
        cargarEmpleado()
    End Sub

    Private Sub bteditar_Click(sender As Object, e As EventArgs) Handles bteditar.Click
        If SesionActual.tienePermiso(Peditar) Then
            If MsgBox(Mensajes.EDITAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.EDITAR) = MsgBoxResult.No Then
                Exit Sub
            End If
            General.habilitarControles(gbPrincipal)
            General.habilitarBotones(ToolStrip1)
            bteditar.Enabled = False
            cargarEmpleado()
            habilitarGrilla()
        Else
            MsgBox(Mensajes.SINPERMISO, MsgBoxStyle.Exclamation)
        End If

    End Sub

    Public Sub cargarEmpleado()
        objConfigMeta.cargarMetaGeneral()
        objConfigMeta.cargarEmpleados(btguardar.Enabled)
        objConfigMeta.cargarEmpleadoMeta()
        cbCorte.SelectedItem = objConfigMeta.diaCorte
        numMetaHC.Value = objConfigMeta.meta1
        numMetaAM.Value = objConfigMeta.meta2
        numMetaAF.Value = objConfigMeta.meta3
        cbCargo.SelectedIndex = cbCargo.Items.Count - 1
        dgvEmpleado.Columns("dgMetas").DisplayIndex = 9
    End Sub
    Public Sub iniciarForm(form As FormFacturacionPorEmpleados)
        formPadre = form
    End Sub


    Private Sub FormConfigMetaEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormPrincipal.Cursor = Cursors.Default
        permiso_general = perG.buscarPermisoGeneral(Name)
        Peditar = permiso_general & "pp" & "01"
        enlazarTabla(dgvEmpleado, objConfigMeta.dsEmpleado.DataSource)
        enlazarTablaMeta(dgvMetas, objConfigMeta.dsEmpleadoMeta.DataSource)
        Dim params As New List(Of String)
        params.Add(Nothing)
        General.cargarCombo(Consultas.CARGO_LISTAR, params, "Descripción cargo", "Código", cbCargo)
        Dim dtNuevo As DataTable
        dtNuevo = cbCargo.DataSource.copy
        dtNuevo.Rows.Add()
        dtNuevo.Rows(dtNuevo.Rows.Count - 1).Item(0) = Constantes.ITEM_DGV_SELECCIONE_VALOR
        dtNuevo.Rows(dtNuevo.Rows.Count - 1).Item(1) = "TODOS"
        cbCargo.DataSource = dtNuevo
        cbCorte.SelectedIndex = 0
        bteditar.Enabled = True
        habilitarGrilla()
        habilitarGrillaMeta()
        General.deshabilitarControles(gbPrincipal)
        PictureBox2.Image = Global.Celer.My.Resources.Resources.chart_add_icon
    End Sub
    Private Sub habilitarGrilla()
        dgvEmpleado.Columns("dgIdEmpleado").ReadOnly = True
        dgvEmpleado.Columns("dgEmpleado").ReadOnly = True
        dgvEmpleado.Columns("dgCargo").ReadOnly = True
        dgvEmpleado.Columns("dgCodigoContrato").ReadOnly = True
        dgvEmpleado.Columns("dgContrato").ReadOnly = True
        dgvEmpleado.Columns("dgValorTurno").ReadOnly = True
        dgvEmpleado.Columns("dgTurnos").ReadOnly = True
        dgvEmpleado.Columns("dgPromedio").ReadOnly = True
        dgvEmpleado.Columns("dgMetaSostenimiento").ReadOnly = False
        dgvEmpleado.Columns("dgActivo").ReadOnly = False
    End Sub
    Private Sub textbusqueda1_TextChanged(sender As Object, e As EventArgs) Handles textbusqueda1.TextChanged
        objConfigMeta.dsEmpleado.Filter = "Empleado like '%" & textbusqueda1.Text & "%'"
    End Sub
    Private Sub habilitarGrillaMeta()
        dgvMetas.ReadOnly = False
        dgvMetas.Columns("dgIdEmpleadoMeta").ReadOnly = True
        dgvMetas.Columns("dgEmpleadoMeta").ReadOnly = True
        dgvMetas.Columns("dgIdMeta").ReadOnly = True
        dgvMetas.Columns("dgValorMeta").ReadOnly = Not btguardar.Enabled
        dgvMetas.Columns("dgPorcentaje").ReadOnly = Not btguardar.Enabled
    End Sub
    Private Sub dgvEmpleado_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvEmpleado.CellFormatting
        If e.ColumnIndex = 6 OrElse e.ColumnIndex = 8 OrElse e.ColumnIndex = 9 Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), "c2")
            Else
                e.Value = Format(Val(e.Value), "c2")
            End If
        ElseIf e.ColumnIndex = 7 Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), "n2")
            Else
                e.Value = Format(Val(e.Value), "n2")
            End If
        End If
    End Sub
    Private Sub dgvEmpleadoMeta_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvMetas.CellFormatting
        If e.ColumnIndex = 4 Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), "c2")
            Else
                e.Value = Format(Val(e.Value), "c2")
            End If
        ElseIf e.ColumnIndex = 5 Then
            If IsDBNull(e.Value) Then
                e.Value = Format(Val(0), "p2")
            Else
                e.Value = Format(Val(e.Value) / 100, "p2")
            End If
        End If
    End Sub
    Private Sub dgvEmpleado_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvEmpleado.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivo
    End Sub
    Private Sub dgvEmpleadoMeta_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvMetas.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf ValidacionDigitacion.validarSoloNumerosPositivo
    End Sub

    Private Sub dgvEmpleado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmpleado.CellContentClick
        If e.ColumnIndex = dgvEmpleado.Columns("dgMetas").Index Then
            pnlMeta.Visible = True
            gbPrincipal.Enabled = False
            tsAgregar.Enabled = btguardar.Enabled
            dgvMetas.Columns("dgAnularMeta").Visible = btguardar.Enabled
            objConfigMeta.dsEmpleadoMeta.Filter = "[Empleado] LIKE '%" + dgvEmpleado.Rows(dgvEmpleado.CurrentCell.RowIndex).Cells(dgvEmpleado.Columns("dgEmpleado").Index).Value.ToString + "%'"
            dgvMetas.Columns("dgIdEmpleadoMeta").Visible = False
            habilitarGrillaMeta()
            ToolStrip1.Enabled = False
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsGuardar.Click
        If validarMeta() Then
            pnlMeta.Visible = False
            gbPrincipal.Enabled = True
            ToolStrip1.Enabled = True
            PictureBox2.Image = Celer.My.Resources.Resources.chart_add_icon
        End If

    End Sub
    Private Function validarMeta() As Boolean
        dgvMetas.EndEdit()
        For i = 0 To dgvMetas.RowCount - 1
            If IsDBNull(dgvMetas.Rows(i).Cells(4).Value) OrElse dgvMetas.Rows(i).Cells(4).Value = 0 OrElse
                IsDBNull(dgvMetas.Rows(i).Cells(5).Value) OrElse dgvMetas.Rows(i).Cells(5).Value = 0 Then

                MsgBox("¡Por favor, primero ingrese los valores correctamente!" & vbCrLf &
                       "El valor de la meta y porcentaje no puede ser 0.", MsgBoxStyle.Exclamation)
                dgvMetas.Rows(i).Cells(3).Selected = True
                Return False
            End If
            If i > 0 Then
                If IIf(dgvMetas.Rows(i).Cells(4).Value < dgvMetas.Rows(i - 1).Cells(4).Value OrElse
                              dgvMetas.Rows(i).Cells(5).Value < dgvMetas.Rows(i).Cells(5).Value, True, False) = True Then
                    MsgBox("¡Por favor, primero ingrese los valores correctamente!" & vbCrLf &
                           "El valor de la meta y porcentaje no pueden ser inferiores a la Anterior.", MsgBoxStyle.Exclamation)
                    dgvMetas.Rows(i).Cells(3).Selected = True
                    Return False
                End If

            End If
        Next
        Return True

    End Function

    Public Shared Sub enlazarTabla(dgv As DataGridView, dt As DataTable)
        With dgv
            .Columns(0).DataPropertyName = "IdEmpleado"
            .Columns(1).DataPropertyName = "Empleado"
            .Columns(2).DataPropertyName = "Cargo"
            .Columns(3).DataPropertyName = "CodigoContrato"
            .Columns(4).DataPropertyName = "Contrato"
            .Columns(5).DataPropertyName = "ValorTurno"
            .Columns(6).DataPropertyName = "Turnos"
            .Columns(7).DataPropertyName = "Promedio"
            .Columns(8).DataPropertyName = "MetaSostenimiento"
            .Columns(10).DataPropertyName = "Activo"
        End With
        dgv.DataSource = dt
        dgv.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 8)
    End Sub

    Private Sub dgvMetas_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMetas.CellContentDoubleClick
        If e.ColumnIndex = dgvMetas.Columns("dgAnularMeta").Index Then
            If Not MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Exit Sub
            End If
            dgvMetas.Rows.RemoveAt(e.RowIndex)
            dgvMetas.DataSource.acceptchanges()

            For i = 0 To dgvMetas.RowCount - 1
                dgvMetas.Rows(i).Cells("dgIdMeta").Value = i + 1
            Next
        End If
    End Sub

    Private Sub tsAgregar_Click(sender As Object, e As EventArgs) Handles tsAgregar.Click
        If dgvMetas.Rows.Count = 0 OrElse validarMeta() Then
            objConfigMeta.dtEmpleadoMeta.Rows.Add()
            objConfigMeta.dtEmpleadoMeta.Rows(objConfigMeta.dtEmpleadoMeta.Rows.Count - 1).Item("Empleado") = dgvEmpleado.Rows(dgvEmpleado.CurrentCell.RowIndex).Cells(dgvEmpleado.Columns("dgEmpleado").Index).Value.ToString
            objConfigMeta.dtEmpleadoMeta.Rows(objConfigMeta.dtEmpleadoMeta.Rows.Count - 1).Item("IdEmpleado") = dgvEmpleado.Rows(dgvEmpleado.CurrentCell.RowIndex).Cells(dgvEmpleado.Columns("dgIdEmpleado").Index).Value.ToString
            objConfigMeta.dtEmpleadoMeta.Rows(objConfigMeta.dtEmpleadoMeta.Rows.Count - 1).Item("IdMeta") = dgvMetas.Rows.Count
        End If

    End Sub

    Private Sub dgvEmpleado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmpleado.CellDoubleClick
        If btguardar.Enabled = True AndAlso e.RowIndex >= 0 AndAlso e.ColumnIndex = dgvEmpleado.Columns("dgContrato").Index Then
            Dim params As New List(Of String)
            params.Add(dgvEmpleado.Rows(dgvEmpleado.CurrentCell.RowIndex).Cells("dgIdEmpleado").Value)
            params.Add(Nothing)
            General.buscarElemento(ConsultasNom.EMPLEADO_META_CONTRATO_BUSCAR,
                              params,
                              AddressOf cargarContrato,
                              TitulosForm.BUSQUEDA_CONTRATO,
                              False)
        End If
    End Sub

    Private Sub cargarContrato(pCodigo As Integer)
        Cursor = Cursors.WaitCursor
        Dim params As New List(Of String)
        Dim dFila As DataRow
        params.Add(pCodigo)
        Try
            dFila = General.cargarItem(ConsultasNom.EMPLEADO_META_CONTRATO_CARGAR, params)

            dgvEmpleado.Rows(dgvEmpleado.CurrentCell.RowIndex).Cells("dgCodigoContrato").Value = pCodigo
            dgvEmpleado.Rows(dgvEmpleado.CurrentCell.RowIndex).Cells("dgContrato").Value = dFila.Item(0)
            dgvEmpleado.EndEdit()
        Catch ex As Exception
            general.manejoErrores(ex)
        End Try
        Cursor = Cursors.Default
    End Sub

    Public Shared Sub enlazarTablaMeta(dgv As DataGridView, dt As DataTable)
        With dgv
            .Columns(0).DataPropertyName = "IdEmpleado"
            .Columns(1).DataPropertyName = "Empleado"
            .Columns(2).DataPropertyName = "IdMeta"
            .Columns(3).DataPropertyName = "Valor"
            .Columns(4).DataPropertyName = "Porcentaje"
        End With
        dgv.DataSource = dt
        dgv.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Private Sub F_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If MsgBox(Mensajes.SALIR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.SALIR) = MsgBoxResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If

    End Sub
End Class