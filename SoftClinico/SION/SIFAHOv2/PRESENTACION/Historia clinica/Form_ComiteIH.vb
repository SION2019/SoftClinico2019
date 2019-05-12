Public Class Form_ComiteIH
    Dim dt As New DataTable
    Public Function muestraImagen()
        Return PictureBox1.Image
    End Function
    Private Sub Form_ComiteIH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim thisDay As DateTime = DateTime.Today
        dtfecha.Text = thisDay.ToString("d")
        dtfecha2.Text = thisDay.ToString("d")
        General.cargarCombo(Consultas.AREA_SERVICIO_LISTAR_CONTRATO & "" & SesionActual.codigoEP & ",'','" & Constantes.VALOR_PREDETERMINADO & "',''", "Descripción", "Código", Comboservicio)
    End Sub
    Private Sub Comboentorno_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles Comboservicio.SelectedValueChanged
        TextBusqueda.ResetText()
        If Comboservicio.ValueMember <> "" Then
            llenardgv(Comboservicio.SelectedValue, dtfecha, dtfecha2)
        End If
    End Sub

    Private Sub TextBusqueda_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBusqueda.TextChanged
        If Comboservicio.ValueMember <> "" Then
            llenardgv(Comboservicio.SelectedValue, dtfecha, dtfecha2)
        End If
    End Sub

    Private Sub Bconsultar_Click(sender As System.Object, e As System.EventArgs) 
        If Comboservicio.ValueMember <> "" Then
            llenardgv(Comboservicio.SelectedValue, dtfecha, dtfecha2)
        End If
    End Sub

    Private Sub selPendientes_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles seltodos.CheckedChanged, selPendientes.CheckedChanged
        If Comboservicio.ValueMember <> "" Then
            llenardgv(Comboservicio.SelectedValue, dtfecha, dtfecha2)
        End If
    End Sub

    Private Sub dtfecha_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtfecha.ValueChanged
        If Comboservicio.ValueMember <> "" Then
            llenardgv(Comboservicio.SelectedValue, dtfecha, dtfecha2)
        End If
    End Sub

    Private Sub dtfecha2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtfecha2.ValueChanged
        If Comboservicio.ValueMember <> "" Then
            llenardgv(Comboservicio.SelectedValue, dtfecha, dtfecha2)
        End If
    End Sub
    Private Sub enlazarTabla()
        With dgvrayosx

            .Columns.Item("Fecha_solicitud").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("Fecha_solicitud").DataPropertyName = "Fecha_solicitud"

            .Columns.Item("FechaAdm").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("FechaAdm").DataPropertyName = "Fecha_Admision"

            .Columns.Item("Numero_Registro").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("Numero_Registro").DataPropertyName = "Registro"

            .Columns.Item("Codigo_Solicitud").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("Codigo_Solicitud").DataPropertyName = "Codigo_Solicitud"

            .Columns.Item("dgNombre").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgNombre").DataPropertyName = "Nombre"

            .Columns.Item("dgEPS").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgEPS").DataPropertyName = "EPS"

            .Columns.Item("Motivo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("Motivo").DataPropertyName = "Motivo"

            .Columns.Item("dgentorno").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgentorno").DataPropertyName = "Codigo_Area_Servicio"

            .Columns.Item("Descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("Descripcion").DataPropertyName = "Descripcion_Area_Servicio"

            dgvrayosx.AutoGenerateColumns = False
            dgvrayosx.DataSource = dt
        End With
    End Sub
    Private Sub llenardgv(pservicio, pfecha1, pfecha2)
        Dim params As New List(Of String)

        pservicio = Comboservicio.SelectedValue
        pfecha1 = dtfecha.Value
        pfecha2 = dtfecha2.Value
        params.Add(pservicio)
        params.Add(pfecha1)
        params.Add(pfecha2)

        If Comboservicio.SelectedIndex = 0 Then
            dgvrayosx.DataSource = Nothing
            Exit Sub
        End If

        If selPendientes.Checked = True Then
            General.llenarTabla(Consultas.COMITE_INFECCION_IHP, params, dt)
        ElseIf seltodos.Checked = True Then
            General.llenarTabla(Consultas.COMITE_INFECCION_IHR, params, dt)
        End If

        enlazarTabla()

        Label4.Text = dt.Rows.Count
    End Sub
    Private Sub dgvrayosx_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvrayosx.CellDoubleClick
        If dt.Rows.Count > 0 Then
            Form_Infeccion_IH.fechaSolicitud.Value = dgvrayosx.Rows(dgvrayosx.CurrentCell.RowIndex).Cells(0).Value
            Form_Infeccion_IH.fechaadmision.Text = dgvrayosx.Rows(dgvrayosx.CurrentCell.RowIndex).Cells(1).Value
            Form_Infeccion_IH.txtregistro.Text = dgvrayosx.Rows(dgvrayosx.CurrentCell.RowIndex).Cells(2).Value
            Form_Infeccion_IH.Txtcodigo.Text = dgvrayosx.Rows(dgvrayosx.CurrentCell.RowIndex).Cells(3).Value
            Form_Infeccion_IH.txtpaciente.Text = dgvrayosx.Rows(dgvrayosx.CurrentCell.RowIndex).Cells(4).Value
            Form_Infeccion_IH.motivoSolicitud.Text = dgvrayosx.Rows(dgvrayosx.CurrentCell.RowIndex).Cells(6).Value
            Form_Infeccion_IH.Show()
            Form_Infeccion_IH.Focus()
            Form_Infeccion_IH.cargarDatos(dgvrayosx.Rows(dgvrayosx.CurrentCell.RowIndex).Cells(3).Value)
        End If
    End Sub
End Class