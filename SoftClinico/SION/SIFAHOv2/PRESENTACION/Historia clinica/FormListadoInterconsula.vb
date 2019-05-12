Public Class FormListadoInterconsula
    Dim dtInterconsulta As New DataTable
    Dim opcion As Integer
    Dim codigoProceInterconsulta As String
    Dim dgvAsignada As New BindingSource
    Dim CodigoTemporal, moduloTemporal As String
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub FormListadoInterconsula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim thisDay As DateTime = DateTime.Today
        fechaInicio.Value = thisDay.ToString("d")
        fechaFin.Value = thisDay.ToString("d")
        General.cargarCombo(Consultas.AREA_SERVICIO_LISTAR_CONTRATO & "" & SesionActual.codigoEP & ",'','" & Constantes.VALOR_PREDETERMINADO & "',''", "Descripción", "Código", cmbAreaServicio)
        Dim dtNuevo As DataTable
        dtNuevo = cmbAreaServicio.DataSource.copy
        dtNuevo.Rows.Add()
        dtNuevo.Rows(dtNuevo.Rows.Count - 1).Item(0) = Constantes.ITEM_DGV_SELECCIONE_VALOR
        dtNuevo.Rows(dtNuevo.Rows.Count - 1).Item(1) = "TODOS"
        cmbAreaServicio.DataSource = dtNuevo
        If String.IsNullOrEmpty(moduloTemporal) Then
            moduloTemporal = Tag.modulo
        End If
    End Sub
    Private Function seleccionarItemCombobox()
        If cmbAreaServicio.SelectedIndex <= 0 Then
            dgvInterconsulta.DataSource = Nothing
            Label4.Text = 0
        Else
            Return True
        End If
        Return False
    End Function
    Private Sub Comboentorno_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbAreaServicio.SelectedValueChanged
        textBusqueda.ResetText()
        If seleccionarItemCombobox() Then
            llenardgv(cmbAreaServicio.SelectedValue, fechaInicio.Value, fechaFin.Value, codigoProceInterconsulta, opcion)
        End If
    End Sub

    Private Sub TextBusqueda_TextChanged(sender As System.Object, e As System.EventArgs) Handles textBusqueda.TextChanged
        If seleccionarItemCombobox() Then
            dgvAsignada.Filter = "[Paciente] LIKE '%" + textBusqueda.Text.Trim() + "%'"
        End If
    End Sub
    Private Sub rbRealizados_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbRealizados.CheckedChanged
        If rbRealizados.Checked = True Then
            opcion = 0
        End If
        If seleccionarItemCombobox() Then
            llenardgv(cmbAreaServicio.SelectedValue, fechaInicio.Value, fechaFin.Value, codigoProceInterconsulta, opcion)
        End If
    End Sub
    Private Sub rbPendientes_CheckedChanged(sender As Object, e As EventArgs) Handles rbPendientes.CheckedChanged
        If rbPendientes.Checked = True Then
            opcion = 1
        End If
        If seleccionarItemCombobox() Then
            llenardgv(cmbAreaServicio.SelectedValue, fechaInicio.Value, fechaFin.Value, codigoProceInterconsulta, opcion)
        End If
    End Sub
    Private Sub dtfecha_ValueChanged(sender As System.Object, e As System.EventArgs) Handles fechaInicio.ValueChanged
        If seleccionarItemCombobox() Then
            llenardgv(cmbAreaServicio.SelectedValue, fechaInicio.Value, fechaFin.Value, codigoProceInterconsulta, opcion)
        End If
    End Sub

    Private Sub dtfecha2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles fechaFin.ValueChanged
        If seleccionarItemCombobox() Then
            llenardgv(cmbAreaServicio.SelectedValue, fechaInicio.Value, fechaFin.Value, codigoProceInterconsulta, opcion)
        End If
    End Sub
    Private Sub llenardgv(servicio As Integer, fechaInicio As Date, fechaFin As Date, codigoProcedimiento As String, opcion As Integer)
        Dim params As New List(Of String)
        params.Add(servicio)
        params.Add(fechaInicio)
        params.Add(fechaFin)
        params.Add(codigoProcedimiento)
        params.Add(opcion)
        Cursor = Cursors.WaitCursor
        Dim consulta As String = ""

        If moduloTemporal = "ab" Then
            consulta = Consultas.INTERCONSULTAS_PENDIENTES_LISTAR
        ElseIf moduloTemporal = "ac" Then
            consulta = Consultas.INTERCONSULTAS_PENDIENTES_LISTAR_R
        ElseIf moduloTemporal = "ad" Then
            consulta = Consultas.INTERCONSULTAS_PENDIENTES_LISTAR_RR
        End If
        General.llenarTabla(consulta, params, dtInterconsulta)
        dgvInterconsulta.DataSource = dtInterconsulta
        dgvAsignada.DataSource = dtInterconsulta
        Label4.Text = dtInterconsulta.Rows.Count
        If dtInterconsulta.Rows.Count > 0 Then
            With dgvInterconsulta
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(0).Visible = False
                .Columns(4).Visible = False
                .Columns(6).Visible = False
            End With
            General.diseñoDGV(dgvInterconsulta)
        End If
        Cursor = Cursors.Default
    End Sub
    Private Sub dgvrayosx_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInterconsulta.CellDoubleClick
        If dtInterconsulta.Rows.Count > 0 Then
            FormInterconsulta.txtregistro.Text = dgvInterconsulta.Rows(dgvInterconsulta.CurrentRow.Index).Cells(0).Value
            FormInterconsulta.txtpaciente.Text = dgvInterconsulta.Rows(dgvInterconsulta.CurrentRow.Index).Cells(1).Value
            FormInterconsulta.txtedad.Text = dgvInterconsulta.Rows(dgvInterconsulta.CurrentRow.Index).Cells(2).Value
            FormInterconsulta.txtAreaServicio.Text = dgvInterconsulta.Rows(dgvInterconsulta.CurrentRow.Index).Cells(3).Value
            FormInterconsulta.txtCodigoOrden.Text = dgvInterconsulta.Rows(dgvInterconsulta.CurrentRow.Index).Cells(4).Value
            FormInterconsulta.txtfechaingreso.Text = dgvInterconsulta.Rows(dgvInterconsulta.CurrentRow.Index).Cells(5).Value
            FormInterconsulta.procedimientoInterconsulta = dgvInterconsulta.Rows(dgvInterconsulta.CurrentRow.Index).Cells(6).Value
            FormInterconsulta.moduloTemporal = moduloTemporal
            FormInterconsulta.cargarInterconsulta(dgvInterconsulta.Rows(dgvInterconsulta.CurrentRow.Index).Cells(4).Value, dgvInterconsulta.Rows(dgvInterconsulta.CurrentRow.Index).Cells(6).Value)
            FormInterconsulta.Show()
        End If
    End Sub

    Private Sub btBuscarProcedimiento_Click(sender As Object, e As EventArgs) Handles btBuscarProcedimiento.Click
        Dim params As New List(Of String)
        Dim tblProcedimientos As DataRow = Nothing
        params.Add(cmbAreaServicio.SelectedValue)
        params.Add(fechaInicio.Value)
        params.Add(fechaFin.Value)
        params.Add("")
        params.Add(opcion)
        Dim consulta As String = ""
        If moduloTemporal = "ab" Then
            consulta = Consultas.LISTA_ESPECIALIDAD_INTERCONSULTA
        ElseIf moduloTemporal = "ac" Then
            consulta = Consultas.LISTA_ESPECIALIDAD_INTERCONSULTA_R
        ElseIf moduloTemporal = "ad" Then
            consulta = Consultas.LISTA_ESPECIALIDAD_INTERCONSULTA_RR
        End If
        Dim formBusqueda As Form_BusquedaGeneral = General.buscarElemento(consulta, params, TitulosForm.BUSQUEDA_PROCEDIMIENTO, True)
        tblProcedimientos = formBusqueda.rowResultados
        If tblProcedimientos IsNot Nothing Then
            codigoProceInterconsulta = tblProcedimientos(0)
            txtProcedimiento.Text = tblProcedimientos(1)
            lbQuitar.Visible = True
        End If

        If seleccionarItemCombobox() Then
            llenardgv(cmbAreaServicio.SelectedValue, fechaInicio.Value, fechaFin.Value, codigoProceInterconsulta, opcion)
        End If
    End Sub

    Private Sub lbQuitar_Click(sender As Object, e As EventArgs) Handles lbQuitar.Click
        lbQuitar.Visible = False
        codigoProceInterconsulta = Nothing
        txtProcedimiento.Text = ""
        If seleccionarItemCombobox() Then
            llenardgv(cmbAreaServicio.SelectedValue, fechaInicio.Value, fechaFin.Value, codigoProceInterconsulta, opcion)
        End If
    End Sub
End Class