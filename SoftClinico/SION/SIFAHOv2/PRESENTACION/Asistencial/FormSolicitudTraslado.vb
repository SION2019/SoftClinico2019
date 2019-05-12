Public Class FormSolicitudTraslado
    Dim dt As New DataTable
    Dim perG As New Buscar_Permisos_generales
    Dim permisoGeneral, pVerPendientes, pVerRealizados As String
    Private Sub Form_Listado_Paciente_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        permisoGeneral = perG.buscarPermisoGeneral(Name)
        pVerPendientes = permisoGeneral & "pp" & "01"
        pVerRealizados = permisoGeneral & "pp" & "02"
        Try
            Dim params As New List(Of String)
            params.Add(SesionActual.idUsuario)
            params.Add(SesionActual.codigoEP)
            params.Add(Nothing)
            General.cargarCombo(Consultas.PROC_AREA_SERVICIO_EMPLEADO_LLENAR, params, "Descripción", "Código", comboAreaServicio)
            Dim dtNuevo As DataTable
            dtNuevo = comboAreaServicio.DataSource.copy
            dtNuevo.Rows.Add()
            dtNuevo.Rows(dtNuevo.Rows.Count - 1).Item(0) = Constantes.ITEM_DGV_SELECCIONE_VALOR
            dtNuevo.Rows(dtNuevo.Rows.Count - 1).Item(1) = "TODOS"
            comboAreaServicio.DataSource = dtNuevo

        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
        listarPaciente()
    End Sub
    Private Sub dgvmanual_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvmanual.CellDoubleClick
        If dgvmanual.RowCount > 0 AndAlso e.RowIndex >= 0 AndAlso selPendiente.Checked Then
            FormPrincipal.Cursor = Cursors.WaitCursor
            If (dgvmanual.Rows(e.RowIndex).Cells("Código remisión").Value.ToString <> Constantes.VALOR_PREDETERMINADO AndAlso
                dgvmanual.Rows(e.RowIndex).Cells("Codigo_Solicitud").Value.ToString = Constantes.VALOR_PREDETERMINADO) OrElse
               (dgvmanual.Rows(e.RowIndex).Cells("Codigo_Triage").Value.ToString <> Constantes.VALOR_PREDETERMINADO AndAlso
               dgvmanual.Rows(e.RowIndex).Cells("Traslado_Urgencias").Value.ToString = Constantes.VALOR_PREDETERMINADO) OrElse
               dgvmanual.Rows(e.RowIndex).Cells("Traslado_hc").Value.ToString <> Constantes.VALOR_PREDETERMINADO Then
                abrirRemision()
            ElseIf dgvmanual.Rows(e.RowIndex).Cells("Traslado_Urgencias").Value.ToString <> Constantes.VALOR_PREDETERMINADO Then
                abrirAnexo2()
            Else
                abrirAdmision(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Registro Anterior").ToString, dgvmanual.Rows(dgvmanual.CurrentRow.Index).Cells("Codigo_Solicitud").Value, dgvmanual.Rows(e.RowIndex).Cells("Código remisión").Value.ToString)
                listarPaciente()
            End If
            FormPrincipal.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub abrirAdmision(registro As Integer, solicitud As Integer, Optional remision As Integer = Constantes.VALOR_PREDETERMINADO)
        Dim formAdmision As New FormAdmision
        General.limpiarControles(formAdmision)
        If formAdmision.WindowState = FormWindowState.Minimized Then
            formAdmision.WindowState = FormWindowState.Normal
        End If
        Dim params As New List(Of String)
        params.Add(registro)
        params.Add(solicitud)
        params.Add(remision)
        formAdmision.cargarAdmisionAnexo(params)
    End Sub
    Private Sub abrirRemision()
        Dim anexo3 As New FormAnexo3
        Dim params As New List(Of String)
        params.Add(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Registro Anterior").ToString)
        params.Add(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Paciente").ToString)
        params.Add(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Identificación").ToString)
        params.Add(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("EPS").ToString)
        params.Add(Constantes.AUTORIZACION_SERVICIO)
        params.Add(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Área").ToString)
        params.Add(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Descripción área").ToString)
        params.Add(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Código Remisión").ToString)
        anexo3.iniciarForm(params)
        If dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Código Remisión").ToString = Constantes.VALOR_PREDETERMINADO AndAlso params(params.Count - 1) <> Constantes.VALOR_PREDETERMINADO Then
            abrirAdmision(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Registro Anterior").ToString, params(params.Count - 1))
        End If

        listarPaciente()
    End Sub

    Private Sub abrirAnexo2()
        Dim anexo2 As New FormAnexo2
        Dim params As New List(Of String)
        params.Add(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Registro Anterior").ToString)
        anexo2.iniciarForm(params)
        If dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Código Remisión").ToString = Constantes.VALOR_PREDETERMINADO AndAlso
            params(params.Count - 1) <> Constantes.VALOR_PREDETERMINADO Then
            abrirAdmision(dt.Rows(dgvmanual.CurrentCell.RowIndex).Item("Registro Anterior").ToString, dgvmanual.Rows(dgvmanual.CurrentRow.Index).Cells("Codigo_Solicitud").Value, dgvmanual.Rows(dgvmanual.CurrentRow.Index).Cells("Código remisión").Value.ToString)
        End If
        listarPaciente()
    End Sub
    Private Sub comboAreaServicio_SelectedValueChanged(sender As Object, e As EventArgs) Handles comboAreaServicio.SelectedValueChanged
        If IsNumeric(comboAreaServicio.SelectedValue) Then
            listarPaciente()
        End If
    End Sub
    Private Sub selCerrados_CheckedChanged(sender As Object, e As EventArgs) Handles selRealizado.CheckedChanged
        listarPaciente()
    End Sub
    Public Sub listarPaciente()
        Dim area As String
        area = comboAreaServicio.SelectedValue.ToString
        If comboAreaServicio.SelectedIndex = 0 Then
            area = "-2"
        End If

        Try
            Dim estadoAtencion As Integer
            Dim consulta As String = ""
            If selPendiente.Checked = True Then
                estadoAtencion = Constantes.PENDIENTE
            ElseIf selRealizado.Checked = True Then
                estadoAtencion = Constantes.TERMINADO
            End If

            consulta = Consultas.LISTA_PACIENTE_REMISION

            General.llenarTablaYdgv(consulta & "'" & busquedaPaciente.Text & "','" &
                                                     area & "'," &
                                                     estadoAtencion & "," &
                                                     SesionActual.codigoEP & "," &
                                                     SesionActual.codigoPerfil, dt)
            dgvmanual.DataSource = dt

            dgvmanual.ReadOnly = True
            For i = 0 To dgvmanual.Columns.Count - 1
                dgvmanual.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                dgvmanual.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                dgvmanual.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvmanual.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Next
            dgvmanual.Columns("Registro").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvmanual.Columns("Registro").Frozen = True
            dgvmanual.Columns("Registro").HeaderText = "Documento"
            dgvmanual.Columns("Registro").Width = "140"
            dgvmanual.Columns("Paciente").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvmanual.Columns("Paciente").Frozen = True
            dgvmanual.Columns("Paciente").Width = "300"
            dgvmanual.Columns("Admisión").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvmanual.Columns("Admisión").Width = "150"
            dgvmanual.Columns("Estancia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvmanual.Columns("Estancia").Width = "82"
            dgvmanual.Columns("EPS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvmanual.Columns("EPS").Width = "320"
            dgvmanual.Columns("Área").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvmanual.Columns("Área").Width = "40"
            dgvmanual.Columns("Área").Visible = False
            dgvmanual.Columns("Descripción área").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvmanual.Columns("Descripción área").Width = "150"
            dgvmanual.Columns("Contrato").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvmanual.Columns("Contrato").Width = "50"
            dgvmanual.Columns("Contrato").Visible = False
            dgvmanual.Columns("Edad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvmanual.Columns("Edad").Width = "90"
            dgvmanual.Columns("Sexo").Width = "40"
            dgvmanual.Columns("Sexo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvmanual.Columns("Color").Visible = False
            dgvmanual.Columns("Estancia").Visible = False
            dgvmanual.Columns("Identificación").Visible = False
            dgvmanual.Columns("Código Remisión").Visible = False
            dgvmanual.Columns("Codigo_solicitud").Visible = False
            dgvmanual.Columns("Codigo_solicitud").Visible = False
            dgvmanual.Columns("CODIGO_TRIAGE").Visible = False
            dgvmanual.Columns("TRASLADO_URGENCIAS").Visible = False
            dgvmanual.Columns("Traslado_HC").Visible = False
            dgvmanual.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvmanual.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 8)
            consultarCantidadPaciente(estadoAtencion, area)
        Catch ex As Exception
            general.manejoErrores(ex) 
        End Try
    End Sub

    Private Sub consultarCantidadPaciente(estadoAtencion As Integer, area As String)
        Dim consulta As String = ""
        consulta = Consultas.CANTIDAD_PACIENTE_REMISION

        Dim params As New List(Of String)
        params.Add(area)
        params.Add(estadoAtencion)
        params.Add(SesionActual.codigoEP)
        npaciente.Text = General.getValorConsulta(consulta, params)

        For j As Int32 = 0 To dgvmanual.Rows.Count - 1
            dgvmanual.Rows(j).DefaultCellStyle.BackColor = Color.FromArgb(dgvmanual.Rows(j).Cells("Color").Value)
        Next
    End Sub
    Private Sub busquedaPaciente_KeyDown(sender As Object, e As KeyEventArgs) Handles busquedaPaciente.KeyDown
        If e.KeyCode = Keys.Enter Then
            busquedaPaciente.Text = Funciones.validarComillaSimple(busquedaPaciente.Text)
            listarPaciente()
        End If
    End Sub
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
End Class